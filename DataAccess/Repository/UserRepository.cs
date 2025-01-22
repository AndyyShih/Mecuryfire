using Common.Enums;
using Dapper;
using DataAccess.DTOs;
using DataAccess.Extensions;
using DataAccess.IRepository;
using System.Security.Cryptography;

namespace DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        private readonly SqlHelper _sqlHelper;

        public UserRepository(IDbConnectionFactory connectionFactory, SqlHelper sqlHelper)
        {
            _connectionFactory = connectionFactory;
            _sqlHelper = sqlHelper;
        }

        /// <summary>
        /// 新增使用者
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<int> InsertUserAsync(InsertUserDto input)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync(DatabaseSource.Mecuryfire);

            //產生新的SID
            var newSid = await _sqlHelper.GetNewSIDAsync("MyOffice_ACPD");

            var sql = @"INSERT INTO MyOffice_ACPD  (         
                        ACPD_SID, ACPD_Cname, ACPD_Ename, ACPD_Sname,
                        ACPD_Email, ACPD_Status, ACPD_Stop, ACPD_StopMemo,
                        ACPD_LoginID, ACPD_LoginPWD, ACPD_Memo, ACPD_NowDateTime,
                        ACPD_NowID, ACPD_UPDDateTime, ACPD_UPDID
                        )              
                        VALUES (
                        @SID, @CName, @EName, @SName,
                        @Email, @Status, @Stop, @StopMemo,
                        @LoginID, @LoginPWD, @Memo, GETDATE(),
                        @NowID, GETDATE(), @NowID
                        )";

            var parameters = new
            {
                SID = newSid,
                CName = input.CName,
                EName = input.EName,
                SName = input.SName,
                Email = input.Email,
                Status = input.Status,
                Stop = input.Stop,
                StopMemo = input.StopMemo,
                LoginID = input.LoginID,
                LoginPWD = input.LoginPWD,
                Memo = input.Memo,
                NowID = input.NowID
            };

            var result = await connection.ExecuteAsync(sql, parameters);

            //紀錄動作
            var groupID = Guid.NewGuid();
            await _sqlHelper.LogActionAsync(0, "usp_AddLog", groupID,"Create",$"{{\"UserID\":\"{newSid}\",\"UserName\":\"{input.CName}\"}}");

            return result;
        }
    }
}
