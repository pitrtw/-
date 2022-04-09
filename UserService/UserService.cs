using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Interface;
using Service.Interfaces;
using Common.Models;

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
            var result = await _userRespostory.AddUserInfoAsync(userInfo);

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

            return result;
        }

        public async Task<UserInfo> GetUserInfoAsync(ulong id)
        {
            var result = await _userRespostory.GetUserInfoAsync(id);
            if (result == null)
            {
                return null;
            }

            return new UserInfo { Id = result.Id, Nickname = result.Nickname, Age = result.Age };
        }

        public async Task<bool> UpdateUserInfoAsync(UpdateUserInfo updateUserInfo)
        {
            var result = await _userRespostory.UpdateUserInfoAsync(updateUserInfo);

            return result;
        }
    }
}
