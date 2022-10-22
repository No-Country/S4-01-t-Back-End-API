using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S4_Back_End_API.Data;
using S4_Back_End_API.Models;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace S4_Back_End_API.Controllers
{
    [Route("api/swipe")]
    [ApiController]
    public class SwipeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SwipeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/swipe
        [HttpGet]
        //public async Task<IEnumerable<Recipe>> Get() => await _context.Recipes.ToArrayAsync(); 
        public async Task<ActionResult<List<Recipe>>> Get()//(int currentUserId)
        {
            try
            {
                var recipes = await _context.Recipe_DietType
                    //.Include(r => r.AppUser)
                    .Include(r => r.Ingredients)
                    .Include(r => r.Recipe_DietTypes)
                    .Include(r => r.Recipe_User_Likes)
                    .Include(r => r.Recipe_User_Matches)
                    .ToListAsync();

                if (recipes.Any())
                {
                    foreach (var re in recipes)
                    {
                        re.TotalLikes = re.Recipe_User_Likes.Count;
                    }
                }
                //var recipePreview = new List<Recipe>();
                //var rece = new Recipe();
                //var dt = new List<String>();
                //foreach (var r in recipes)
                //{
                //    rece.RecipeId = r.RecipeId;
                //    rece.RecipeTitle = r.RecipeTitle; 
                //    rece.PreparationTime = r.PreparationTime;
                //    rece.RecipePicturePath = r.RecipePicturePath;
                //    rece.TotalLikes = r.TotalLikes;
                //    rece.AppUserId = r.AppUserId;
                //    foreach (var rdt in r.Recipe_DietTypes)
                //    {
                //        dt.Add(rdt.DietType.DietTypeDescription);
                //    }
                //    rece.Recipe_DietTypes = dt;
                //    recipePreview.Add(rece);
                //}

                //return StatusCode(StatusCodes.Status200OK, recipePreview);
                return StatusCode(StatusCodes.Status200OK, recipes);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/swipe/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/swipe
        [HttpPost]
        public void Post([FromBody] string value)
        {
            value = value.Trim();
        }

        // PUT api/<swipe>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<swipe>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
