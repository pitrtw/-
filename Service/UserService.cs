using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models;
using Repository.Interface;
using Service.Interfaces;

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

            return result ?? null;
        }

        public async Task<bool> UpdateUserInfoAsync(UpdateUserInfo updateUserInfo)
        {
            var result = await _userRespostory.UpdateUserInfoAsync(updateUserInfo);

            return result;
        }
    }
}
