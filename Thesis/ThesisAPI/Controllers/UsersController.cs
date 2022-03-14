using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThesisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/user
        [HttpGet]
        public JsonResult Get()
        {
            var result = new Result();

            result.status = 200;
            result.message = "Usuario OK";

            return new JsonResult(result);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public JsonResult Post([FromBody] InsertUserDto user)
        {
            Result result = new Result();

            result.status = 200;
            result.message = "";

            return new JsonResult(result);
        }
        [HttpPost("Validate")]
        public JsonResult ValidarUsuario([FromBody] UserDto user)
        {


            Result result = new Result();

            result.status = 200;
            result.message = "";

            return new JsonResult(result);
        }

    }
}
