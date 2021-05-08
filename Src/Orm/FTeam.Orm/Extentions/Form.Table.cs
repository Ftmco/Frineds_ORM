using FTeam.Orm.Models;
using System;
using System.Threading.Tasks;

namespace FTeam.Orm.Extentions
{
    public static partial class Form
    {
        #region :: Table :: 

        /// <summary>
        /// Try Get <see cref="TableInfoResult"/>
        /// </summary>
        /// <param name="dbConnectionInfo">Data Base Connection Info <see cref="DbConnectionInfo"/></param>
        /// <param name="tableName">Sql Table Name</param>
        /// <param name="tableType">C# Table Type </param>
        /// <returns><see cref="TableInfoResult"/></returns>
        public static TableInfoResult TryTable(this DbConnectionInfo dbConnectionInfo, string tableName, Type tableType)
           => _tableInfo.TryGetTableInfo(dbConnectionInfo, tableName, tableType);

        /// <summary>
        /// Get <see cref="TableInfoResult"/>
        /// </summary>
        /// <param name="dbConnectionInfo">Data Base Connection Info <see cref="DbConnectionInfo"/></param>
        /// <param name="tableName">Sql Table Name</param>
        /// <param name="tableType">C# Table Type </param>
        /// <returns><see cref="TableInfoResult"/></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static TableInfoResult Table(this DbConnectionInfo dbConnectionInfo, string tableName, Type tableType)
          => _tableInfo.GetTableInfo(dbConnectionInfo, tableName, tableType);

        /// <summary>
        /// Try Get <see cref="TableInfoResult"/>
        /// Use 'await'
        /// </summary>
        /// <param name="dbConnectionInfo">Data Base Connection Info <see cref="DbConnectionInfo"/></param>
        /// <param name="tableName">Sql Table Name</param>
        /// <param name="tableType">C# Table Type </param>
        /// <returns><see cref="TableInfoResult"/></returns>
        public static async Task<TableInfoResult> TryTableAsync(this DbConnectionInfo dbConnectionInfo, string tableName, Type tableType)
            => await Task.FromResult(await _tableInfo.TryGetTableInfoAsync(dbConnectionInfo, tableName, tableType));

        /// <summary>
        /// Get <see cref="TableInfoResult"/>
        /// Use 'await'
        /// </summary>
        /// <param name="dbConnectionInfo">Data Base Connection Info <see cref="DbConnectionInfo"/></param>
        /// <param name="tableName">Sql Table Name</param>
        /// <param name="tableType">C# Table Type </param>
        /// <returns><see cref="TableInfoResult"/></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static async Task<TableInfoResult> TableAsync(this DbConnectionInfo dbConnectionInfo, string tableName, Type tableType)
          => await Task.FromResult(await _tableInfo.GetTableInfoAsync(dbConnectionInfo, tableName, tableType));

        #endregion
    }
}
