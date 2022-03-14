using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThesisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PotentiostatsController : ControllerBase
    {
        // GET: api/<PotentiostatsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PotentiostatsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PotentiostatsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PotentiostatsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PotentiostatsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
