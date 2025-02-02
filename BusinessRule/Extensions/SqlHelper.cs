﻿using Common.Enums;
using Dapper;
using DataAccess.Extensions;
using System.Data;

namespace BusinessRule.Extensions
{
    public class SqlHelper
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public SqlHelper(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <summary>
        /// 取得NewSID的預存程序
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public async Task<string> GetNewSIDAsync(string tableName)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync(DatabaseSource.Mecuryfire);

            var parameters = new DynamicParameters();
            parameters.Add("@TableName", tableName);
            parameters.Add("@ReturnSID", dbType: DbType.String, direction: ParameterDirection.Output, size: 20);

            await connection.ExecuteAsync("dbo.NewSID", parameters, commandType: CommandType.StoredProcedure);

            return parameters.Get<string>("@ReturnSID");
        }

        /// <summary>
        /// 紀錄Log的預存程序
        /// </summary>
        /// <param name="readID"></param>
        /// <param name="spName"></param>
        /// <param name="groupID"></param>
        /// <param name="exProgram"></param>
        /// <param name="actionJson"></param>
        /// <returns></returns>
        public async Task LogActionAsync(int readID, string spName, Guid groupID, string exProgram, string actionJson)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync(DatabaseSource.Mecuryfire);

            var parameters = new DynamicParameters();
            parameters.Add("@_InBox_ReadID", readID);
            parameters.Add("@_InBox_SPNAME", spName);
            parameters.Add("@_InBox_GroupID", groupID);
            parameters.Add("@_InBox_ExProgram", exProgram);
            parameters.Add("@_InBox_ActionJSON", actionJson);
            parameters.Add("@_OutBox_ReturnValues", dbType: DbType.String, direction: ParameterDirection.Output);

            await connection.ExecuteAsync("dbo.usp_AddLog", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
