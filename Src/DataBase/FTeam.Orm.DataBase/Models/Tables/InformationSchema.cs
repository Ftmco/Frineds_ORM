using System.Collections.Generic;

namespace FTeam.Orm.DataBase.Models.Tables
{

    /// <summary>
    /// Table Information Schema
    /// </summary>
    public record InformationSchema
    {
        /// <summary>
        /// Table Catalog (Data Base Name)
        /// </summary>
        public string TableCatalog { get; set; }

        /// <summary>
        /// Table Schema
        /// </summary>
        public string TableSchema { get; set; }

        /// <summary>
        /// Table Name
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// Table Colums
        /// </summary>
        public IEnumerable<TableColumnInfo> TableColumnInfos { get; set; }
    }
}
