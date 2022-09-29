using Microsoft.AspNetCore.Mvc;


namespace S4_Back_End_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET api/Users/5
        [HttpGet]
        public IEnumerable<string> get()
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

        // GET api/Users/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"{id}";
        }

        // POST api/Users
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
