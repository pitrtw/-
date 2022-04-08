using System.Collections.Generic;
using System.Threading.Tasks;
using Service.Models;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserInfo>> GetAllUserInfoAsync();

        Task<UserInfo> GetUserInfoAsync(ulong id);

        Task<bool> AddUserInfoAsync(UserInfo userInfo);

        Task<bool> UpdateUserInfoAsync(UpdateUserInfo updateUserInfo);

        Task<bool> DeleteUserInfoAsync(ulong id);
    }
}
