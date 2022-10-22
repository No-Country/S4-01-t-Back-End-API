using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Hosting;
using S4_Back_End_API.Data;
using S4_Back_End_API.DTOs;
using S4_Back_End_API.Models;

namespace S4_Back_End_API.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RecipesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/recipes/z/x
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<RecipeDTO>>> GetRecipes(string? x)
        {
            List<Recipe> recipes = new();
            Recipe rec = new ();
            switch (x)
            {
                case "n":
                            recipes = await _context.Recipe_DietType
                                        .Include(r => r.Recipe_User_Likes)
                                        .Include(r => r.Recipe_DietTypes)
                                        .OrderByDescending(r => r.CreationDate)
                                        .Take(10)
                                        .ToListAsync();
                    
                            break;

                case "v":
                            recipes = await _context.Recipe_DietType
                                        .Include(r => r.Recipe_User_Likes)
                                        .Include(r => r.Recipe_DietTypes)
                                        .OrderByDescending(r => r.TotalLikes)
                                        .Take(10)
                                        .ToListAsync();
                            break;

                case "r":
                    //Random rand = new();
                    //var i = rand.Next(0, recipes.Count-1);
                    rec = recipes.Where(r => r.RecipeId == 2).FirstOrDefault();
                    break;
                
                default:
                            recipes = await _context.Recipe_DietType
                                        .Include(r => r.Recipe_User_Likes)
                                        .Include(r => r.Recipe_DietTypes)
                                        .Take(10)
                                        .ToListAsync();
                            break;
            }
            //var recipes = await _context.Recipes
            //                    .Include(r => r.Recipe_User_Likes)
            //                    .Include(r => r.Recipe_DietTypes)
            //                    //.Include(r => r.DietTypes)
            //                    //.Include(r => r.Recipe_TimesOfDay)
            //                    .Take(10)
            //                    .ToListAsync();

            foreach (var r in recipes)
            {
                r.TotalLikes = r.Recipe_User_Likes.Count;
                r.Recipe_User_Likes.Clear();
            
                //IEnumerable e = from dt in _context.DietTypes
                //                    join rdt in r.Recipe_DietTypes on dt equals rdt.DietTypeId
                //                    select dt;
                
                //r.DietTypes = e.ToList().ForEach(x => x.dt.DietTypeDescription.Add());
            }
            //foreach (var item in recipes)
            //{
            //    item.DietTypes = _context.DietTypes.ToList().ForEach(dt => dt.DietTypeDescription.);
            //}
            
            if(recipes == null)
            { 
                var recipeDTO = _mapper.Map<Recipe, RecipeDTO>(rec);
                return StatusCode(StatusCodes.Status200OK, recipeDTO);

            }

            var recipesDTO = _mapper.Map<List<Recipe>, List<RecipeDTO>>(recipes);

            return StatusCode(StatusCodes.Status200OK, recipesDTO);
        }

        // GET: api/recipes/5
        [HttpGet("{id}")]
        public ActionResult<RecipeDTO> GetRecipe(int id)
        {
            try 
            {
                //var recipe = await _context.Recipes
                //                    .Include(r => r.Recipe_User_Likes)
                //                    //.Include(r => r.RecipeDietTypes)
                //                    .Include(r => r.Recipe_DietTypes)
                //                    .Include(r => r.Recipe_TimesOfDay)
                //                    .FirstOrDefaultAsync(r => r.RecipeId == id);

                var recipe = _context.Recipe_DietType.Where(r => r.RecipeId == id).Select(r => new RecipeDTO()
                {
                    RecipeId = r.RecipeId,
                    RecipePicturePath = r.RecipePicturePath,
                    PreparationTime = r.PreparationTime,
                    //DietTypes = r.Recipe_DietTypes.Select(r => r.DietType.DietTypeDescription).ToList(),
                    DietTypes = r.Recipe_DietTypes.Where(r => r.RecipeId == id).Select(r => new DietType()
                        {
                            DietTypeId = r.DietType.DietTypeId,
                            DietTypeDescription = r.DietType.DietTypeDescription,
                        }).ToList(),
                    RecipeTitle = r.RecipeTitle,
                    AppUserId = r.AppUserIds,
                    TotalLikes = r.Recipe_User_Likes.Count,
                }).FirstOrDefault();

                /*  # # #    CHECK   # # # */
                if (recipe == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }


                var recipeDTO = _mapper.Map<RecipeDTO>(recipe);

                /*  # # #    CHECK   # # # */
                return StatusCode(StatusCodes.Status200OK, recipeDTO);
                //return Ok(recipeDTO);
            }
            catch (Exception)
            {   /*  # # #    CHECK   # # # */
                return StatusCode(StatusCodes.Status500InternalServerError);
                //throw;
            }
        }


        ///////////////////////////  MODIFY DOWN HER  ///////////////////////////


        // PUT: api/recipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(int id, RecipeDTO recipe)
        {
            if (id != recipe.RecipeId)
            {
                return BadRequest();
            }

            _context.Entry(recipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/recipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(Recipe recipe)
        {
            _context.Recipe_DietType.Add(recipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecipe", new { id = recipe.RecipeId }, recipe);
        }

        // DELETE: api/recipes/5
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
