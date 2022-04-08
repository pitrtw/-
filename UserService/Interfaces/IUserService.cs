using System.Collections.Generic;
using Service.Models;

namespace Service.Interfaces
{
    public interface IUserService
    {
        List<UserInfo> GetAllUserInfo();

        UserInfo GetUserInfo(ulong id);

        bool AddUserInfo(UserInfo userInfo);

        bool UpdateUserInfo(UpdateUserInfo updateUserInfo);

        bool DeleteUserInfo(ulong id);
    }
}
