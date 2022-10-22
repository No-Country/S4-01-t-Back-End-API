using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S4_Back_End_API.Data;
using S4_Back_End_API.DTOs;
using S4_Back_End_API.Models;

namespace S4_Back_End_API.Controllers
{
    [Route("api/recipe/details")]
    [ApiController]
    public class RecipesDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RecipesDetailsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //// GET: api/details
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        //{
        //    return await _context.Recipes.ToListAsync();
        //}

        // GET: api/details/5
        [HttpGet("{id}")]
        public ActionResult<RecipeDetailsDTO> GetRecipeDetails(int id)
        {
            try
            {
                var recipe = _context.Recipe_DietType.Where(r => r.RecipeId == id).Select(r => new RecipeDetailsDTO()
                {
                    RecipeId = r.RecipeId,

                    RecipePicturePath = r.RecipePicturePath,
                    RecipeTitle = r.RecipeTitle,
                    PreparationTime = r.PreparationTime,
                    DietTypes = r.Recipe_DietTypes.Where(r => r.RecipeId == id).Select(r => new DietType()
                        {
                            DietTypeId = r.DietType.DietTypeId,
                            DietTypeDescription = r.DietType.DietTypeDescription,
                        }).ToList(),
                    DifficultyLevels = _context.DifficultyLevels.Where(d => d.DifficultyLevelId == r.DifficultyLevelId).ToList(),
                    UserPicturePath = _context.AppUsers.Where(u => u.UserId == r.AppUserIds).Select(u => u.UserPicturePath).FirstOrDefault(),
                    UserName = _context.AppUsers.Where(u => u.UserId == r.AppUserIds).Select(u => u.UserName).FirstOrDefault(),
                    Ingredients = r.Ingredients.Select(r => new Ingredient() 
                        {
                            IngredientId = r.IngredientId,
                            IngredientDescription = r.IngredientDescription,
                            IngredientAmount = r.IngredientAmount,
                        }).ToList(),
                    RecipeSteps = r.RecipeSteps.Select(r => new RecipeStep()
                        {
                            Id = r.Id,
                            StepNumber = r.StepNumber,
                            StepDescription = r.StepDescription,
                        }).ToList(),

                    AppUserId = r.AppUserIds,
                    
                    TimesOfDay = r.Recipe_TimesOfDay.Where(r => r.RecipeId == id).Select(r => new TimeOfDay()
                        {
                            TimeOfDayId = r.TimeOfDay.TimeOfDayId,
                            TimeOfDayDescription = r.TimeOfDay.TimeOfDayDescription,
                        }).ToList(),
                    Flavors = _context.Flavors.Where(d => d.FlavorId == r.FlavorId).ToList(),
                    TotalLikes = r.Recipe_User_Likes.Count,
                }).FirstOrDefault();

                
                if (recipe == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                var recipeDTO = _mapper.Map<RecipeDTO>(recipe);

                return StatusCode(StatusCodes.Status200OK, recipeDTO);
            }
            catch (Exception)
            {   
                return StatusCode(StatusCodes.Status500InternalServerError);
              
            }
        }

        // PUT: api/RecipesDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRecipe(int id, Recipe recipe)
        //{
        //    if (id != recipe.RecipeId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(recipe).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RecipeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/RecipesDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<RecipeDetailsDTO> PostRecipe(RecipeDetailsDTO r)
        {
            try
            {
                var recipe = _mapper.Map<Recipe>(r);
                var _recipe = new Recipe()
                {
                    RecipePicturePath = recipe.RecipePicturePath,
                    RecipeTitle = recipe.RecipeTitle,
                    PreparationTime = recipe.PreparationTime,
                    DifficultyLevelId = recipe.DifficultyLevelId,
                    FlavorId = recipe.FlavorId,
                    TotalLikes = recipe.Recipe_User_Likes.Count,
                    AppUserIds = recipe.AppUserIds,
                };

                _context.Add(recipe);
                _context.SaveChangesAsync();


                foreach (var dtid in recipe.Recipe_DietTypes)
                {
                    var _recipe_dietType = new Recipe_DietType()
                    {
                        RecipeId = _recipe.RecipeId,
                        DietTypeId = dtid.DietTypeId,
                    };
                    _context.Recipe_DietTypes.Add(_recipe_dietType);
                    _context.SaveChangesAsync();
                }

                foreach (var tdid in recipe.Recipe_TimesOfDay)
                {
                    var _recipe_timeOfDay = new Recipe_TimeOfDay()
                    {
                        RecipeId = _recipe.RecipeId,
                        TimeOfDayId = tdid.TimeOfDayId,
                    };
                    _context.Recipe_TimesOfDay.Add(_recipe_timeOfDay);
                    _context.SaveChangesAsync();
                }


                //    var _user = new AppUser()
                //    {
                //        _context.AppUsers.Add( 
                //            UserPicturePath = _user.UserPicturePath ,
                //            UserName = _user.UserName,
                //        );

                //    };
                //UserPicturePath = _context.AppUsers.Where(u => u.UserId == r.AppUserId).Select(u => u.UserPicturePath).FirstOrDefault();
                //UserName = _context.AppUsers.Where(u => u.UserId == r.AppUserId).Select(u => u.UserName).FirstOrDefault();

                foreach(var ing in recipe.Ingredients)
                {
                    var _ingridient = new Ingredient()
                    {
                        IngredientId = ing.IngredientId,
                        IngredientDescription = ing.IngredientDescription,
                        IngredientAmount = ing.IngredientAmount,
                    };
                    _context.Ingredients.Add(_ingridient);
                    _context.SaveChangesAsync();
                }

                foreach (var stp in recipe.RecipeSteps)
                {
                    var _steps = new RecipeStep()
                    {
                        RecipeId = stp.RecipeId,
                        StepNumber = stp.StepNumber,
                        StepDescription = stp.StepDescription,
                    };
                    _context.RecipeSteps.Add(_steps);
                    _context.SaveChangesAsync();
                }

                if (_recipe == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                var recipeDTO = _mapper.Map<RecipeDTO>(_recipe);

                //return StatusCode(StatusCodes.Status200OK, recipeDTO);
                return CreatedAtAction("GetRecipe", new { id = recipeDTO.RecipeId }, recipeDTO);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

        // DELETE: api/RecipesDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var recipe = await _context.Recipe_DietType.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            _context.Recipe_DietType.Remove(recipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipe_DietType.Any(e => e.RecipeId == id);
        }
    }
}
