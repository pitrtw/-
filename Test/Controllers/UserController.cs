using Microsoft.AspNetCore.Mvc;
using Test.Controllers.Models.Request.User;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("all");
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] ulong id)
        {
            return Ok(id);
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddUser req)
        {
            return Ok(req);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update( [FromRoute] ulong id, [FromBody] UpdateUser req)
        {
            return Ok(new {
                id,
                req
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] ulong id)
        {
            return Ok(id);
        }
    }
}
