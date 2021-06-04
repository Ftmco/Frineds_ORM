using FTeam.Orm.DataBase.Tables;
using FTeam.Orm.DataBase.Tables.Services;

namespace FTeam.Orm.Extentions
{
    public static partial class Form
    {
        #region --:: Dependencies ::--

        /// <summary>
        /// Table Get Services
        /// </summary>
        private static readonly ITableGetRules _tableGet = new TableGetServices();

        /// <summary>
        /// Table Delete Services
        /// </summary>
        private static readonly ITableDeleteRules _tableDelete = new TableDeleteServices();

        /// <summary>
        /// Table Update Services
        /// </summary>
        private static readonly ITableUpdateRules _tableUpdate = new TableUpdateServices();

        /// <summary>
        /// Table Insert Services
        /// </summary>
        private static readonly ITableInsertRules _tableInsert = new TableInsertServices();

        /// <summary>
        /// Table Information Schema Services
        /// </summary>
        private static readonly ITableInfoRules _tableInfo = new TableInfoServices();

        /// <summary>
        /// Table Get With Pagination Services 
        /// </summary>
        private static readonly ITablePaginationRules _tablePagination = new TablePaginationServices();

        /// <summary>
        /// Table Rows Count Services
        /// </summary>
        private static ITableCountRules _tableCount = new TableCountServices();

        #endregion
    }
}
