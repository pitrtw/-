using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Interface;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class UserService: IUserService
    {
        private readonly IUserRespostory _userRespostory = null;

        public UserService(IUserRespostory userRespostory)
        {
            _userRespostory = userRespostory;
        }

        public async Task<bool> AddUserInfoAsync(UserInfo userInfo)
        {
            var addUserInfo = new Repository.Models.UserInfo
            {
                Nickname = userInfo.Nickname,
                Age = userInfo.Age
            };

            var result = await _userRespostory.AddUserInfoAsync(addUserInfo);

            return result;
        }

        public async Task<bool> DeleteUserInfoAsync(ulong id)
        {
            var result = await _userRespostory.DeleteUserInfoAsync(id);

            return result;
        }

        public async Task<IEnumerable<UserInfo>> GetAllUserInfoAsync()
        {
            var result = await _userRespostory.GetAllUserInfoAsync();

            var rst = result.Select(x => new UserInfo { Nickname = x.Nickname, Age = x.Age});

            return rst;
        }

        public async Task<UserInfo> GetUserInfoAsync(ulong id)
        {
            var result = await _userRespostory.GetUserInfoAsync(id);

            return new UserInfo { Nickname = result.Nickname, Age = result.Age };
        }

        public async Task<bool> UpdateUserInfoAsync(UpdateUserInfo updateUserInfo)
        {
            var updateUser = new Repository.Models.UpdateUserInfo
            {
                Id = updateUserInfo.Id,
                Nickname = updateUserInfo.Nickname,
                Age = updateUserInfo.Age
            };

            var result = await _userRespostory.UpdateUserInfoAsync(updateUser);

            return result;
        }
    }
}
