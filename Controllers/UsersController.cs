using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S4_Back_End_API.Data;

namespace S4_Back_End_API.Controllers
{
    [Route("api/user")]
    [ApiController]
    // [Authorize]
    public class AppUserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AppUserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/users
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value 1", "value 2" };
        }

        #region GetUsers
        //GET: api/Users
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        #endregion

        // GET api/users/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"{id}";
        }

        // POST api/users
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
