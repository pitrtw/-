using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;
using Test.Controllers.Models.Request.User;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;

        }


        [HttpGet]
        public IActionResult Get()
        {
            var result = _userService.GetAllUserInfo();

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] ulong id)
        {
            var result = _userService.GetUserInfo(id);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddUser req)
        {
            var userInfo = new UserInfo
            {
                Name = req.Name,
                Age = req.Age
            };

            var result = _userService.AddUserInfo(userInfo);

            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update( [FromRoute] ulong id, [FromBody] UpdateUser req)
        {
            var updateUserInfo = new UpdateUserInfo
            {
                Id = id,
                Name = req.Name,
                Age = req.Age
            };

            var result = _userService.UpdateUserInfo(updateUserInfo);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] ulong id)
        {
            var result = _userService.DeleteUserInfo(id);

            return Ok(result);
        }
    }
}
