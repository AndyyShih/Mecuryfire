using DataAccess.DTOs;

namespace DataAccess.IRepository
{
    public interface IUserRepository
    {
        /// <summary>
        /// 新增使用者
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<int> InsertUserAsync(InsertUserDto input);
    }
}
