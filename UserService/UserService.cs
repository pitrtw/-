using System.Collections.Generic;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class UserService: IUserService
    {
        public UserService()
        {
        }

        public bool AddUserInfo(UserInfo userInfo)
        {
            return true;
        }

        public bool DeleteUserInfo(ulong id)
        {
            return true;
        }

        public List<UserInfo> GetAllUserInfo()
        {
            var list = new List<UserInfo> { new UserInfo
                {
                    Name = "FakeTest",
                    Age = 123
                }
            };

            return list;
        }

        public UserInfo GetUserInfo(ulong id)
        {
            return new UserInfo {
                Name = "FakeTest",
                Age = 123
            };
        }

        public bool UpdateUserInfo(UpdateUserInfo updateUserInfo)
        {
            return true;
        }
    }
}
