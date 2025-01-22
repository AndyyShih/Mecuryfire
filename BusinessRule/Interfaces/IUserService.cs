using DataAccess.DTOs;

namespace BusinessRule.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// 新增使用者
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<int> InsertUserAsync(InsertUserDto input);
    }
}
