namespace FTeam.Orm.DataBase.Models.Tables
{

    /// <summary>
    /// Table Column Information
    /// </summary>
    public record TableColumnInfo
    {
        /// <summary>
        /// Column Name
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// Ordinal Position
        /// </summary>
        public string OrdinalPosition { get; set; }

        /// <summary>
        /// Default Value
        /// </summary>
        public string ColumnDefault { get; set; }

        /// <summary>
        /// Is Nullable
        /// </summary>
        public string IsNullable { get; set; }

        /// <summary>
        /// Data Type
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// Max Length
        /// </summary>
        public string CharacterMaximumLength { get; set; }

        /// <summary>
        /// Character Octet Length
        /// </summary>
        public string CharacterOctetLength { get; set; }

        /// <summary>
        /// Numeric Precision
        /// </summary>
        public string NumericPrecision { get; set; }

        /// <summary>
        /// Numeric Precision Adix
        /// </summary>
        public string NumericPrecisionAdix { get; set; }

        /// <summary>
        /// Numric Scale
        /// </summary>
        public string NumericScale { get; set; }

        /// <summary>
        /// Date Time Precision
        /// </summary>
        public string DateTimePrecision { get; set; }

        /// <summary>
        /// Character Set Catalog
        /// </summary>
        public string CharacterSetCatalog { get; set; }

        /// <summary>
        /// Character SetSchema
        /// </summary>
        public string CharacterSetSchema { get; set; }

        /// <summary>
        /// Character Set Name
        /// </summary>
        public string CharacterSetName { get; set; }

        /// <summary>
        /// Collation Catalog
        /// </summary>
        public string CollationCatalog { get; set; }

        /// <summary>
        /// Collation Schema
        /// </summary>
        public string CollationSchema { get; set; }

        /// <summary>
        /// Collation Name
        /// </summary>
        public string CollationName { get; set; }

        /// <summary>
        /// Domain Catalog
        /// </summary>
        public string DomainCatalog { get; set; }

        /// <summary>
        /// Domain Schema
        /// </summary>
        public string DomainSchema { get; set; }

        /// <summary>
        /// Domain Name
        /// </summary>
        public string DomainName { get; set; }
    }
}