using System.Threading.Tasks;
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
        public async Task<IActionResult> Get()
        {
            var result = await _userService.GetAllUserInfoAsync();

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] ulong id)
        {
            var result = await _userService.GetUserInfoAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AddUser req)
        {
            var userInfo = new UserInfo
            {
                Nickname = req.Nickname,
                Age = req.Age
            };

            var result = await _userService.AddUserInfoAsync(userInfo);

            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update( [FromRoute] ulong id, [FromBody] UpdateUser req)
        {
            var updateUserInfo = new UpdateUserInfo
            {
                Id = id,
                Nickname = req.Nickname,
                Age = req.Age
            };

            var result = await _userService.UpdateUserInfoAsync(updateUserInfo);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] ulong id)
        {
            var result = await _userService.DeleteUserInfoAsync(id);

            return Ok(result);
        }
    }
}
