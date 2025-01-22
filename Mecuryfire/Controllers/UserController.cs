using BusinessRule.Interfaces;
using Common.Enums;
using DataAccess.DTOs;
using DataAccess.Models.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Mecuryfire.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 新增使用者
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertUser")]
        public async Task<ApiResponse> InsertUserAsync(InsertUserDto input)
        {
            var result = await _userService.InsertUserAsync(input);

            if (result == 0)
            {
                return ApiResponseFactory.CreateErrorResult(ErrorCode.ERROR_SQLSERVER_UPDATE_FAILED);
            }
            else
            {
                return ApiResponseFactory.CreateSuccessResult();
            }
        }

    }
}
