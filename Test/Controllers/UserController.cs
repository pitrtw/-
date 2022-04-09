using System.Linq;
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

        // 取得全部使用者
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _userService.GetAllUserInfoAsync();
            if (result == null || !result.Any())
            {
                return NotFound("無任何資料");
            }

            return Ok(result);
        }

        // 取得指定使用者
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] ulong id)
        {
            var result = await _userService.GetUserInfoAsync(id);
            if (result == null)
            {
                return NotFound("查無該使用者資料");
            }

            return Ok(result);
        }

        // 新增使用者
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

        // 更新指定使用者
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

        // 刪除指定使用者
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] ulong id)
        {
            var result = await _userService.DeleteUserInfoAsync(id);

            return Ok(result);
        }
    }
}
