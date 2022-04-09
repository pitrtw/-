using System.Collections.Generic;
using System.Data;
using Repository.Interface;
using Repository.Models;
using Dapper;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRespostory : IUserRespostory
    {

        private readonly IDbConnection _dbConnection = null;

        public UserRespostory(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> AddUserInfoAsync(UserInfo userInfo)
        {
            try
            {
                using var db = _dbConnection;
                var script = $"INSERT INTO `user`.`user_info` (`nickname`, `age`) VALUES (@nickname, @age);";
                var param = new
                {
                    nickname = userInfo.Nickname,
                    age = userInfo.Age
                };
                var affectedRows = await db.ExecuteAsync(script, param);

                var isSuccess = (affectedRows > 0);

                return isSuccess;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteUserInfoAsync(ulong id)
        {
            try
            {
                using var db = _dbConnection;
                var script = $"DELETE FROM `user`.`user_info` WHERE (`id` = @id);";
                var param = new
                {
                    id = id,
                };
                var affectedRows = await db.ExecuteAsync(script, param);

                var isSuccess = (affectedRows > 0);

                return isSuccess;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<UserInfo>> GetAllUserInfoAsync()
        {
            try
            {
                using var db = _dbConnection;
                var script = $"SELECT * FROM `user`.`user_info`;";
                var queryResult = await db.QueryAsync<UserInfo>(script);

                return queryResult;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserInfo> GetUserInfoAsync(ulong id)
        {
            try
            {
                using var db = _dbConnection;
                var script = $"SELECT * FROM `user`.`user_info` WHERE (`id` = @id);";
                var param = new
                {
                    id = id,
                };
                var queryResult = await db.QueryFirstOrDefaultAsync<UserInfo>(script, param);

                return queryResult;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateUserInfoAsync(UpdateUserInfo updateUserInfo)
        {
            try
            {
                using var db = _dbConnection;
                var script = $"UPDATE `user`.`user_info` SET `nickname` = @nickname, `age` = @age WHERE (`id` = @id);";
                var param = new
                {
                    id = updateUserInfo.Id,
                    nickname = updateUserInfo.Nickname,
                    age = updateUserInfo.Age
                };
                var affectedRows = await db.ExecuteAsync(script, param);

                var isSuccess = (affectedRows > 0);

                return isSuccess;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
