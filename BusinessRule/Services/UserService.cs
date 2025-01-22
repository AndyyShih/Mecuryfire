using BusinessRule.Interfaces;
using DataAccess.DTOs;
using DataAccess.IRepository;

namespace BusinessRule.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 新增使用者
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<int> InsertUserAsync(InsertUserDto input)
        {
            var result = await _userRepository.InsertUserAsync(input);

            return result;
        }
    }
}
