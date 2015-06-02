using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Model;

namespace CodeUtility
{
    public class TypeConverter
    {
        public static string DataTypeToCSharpTypeString(Model.DataType type)
        {
            switch (type)
            {
                case DataType.intType:
                    return "int";
                case DataType.bitType:
                    return "bool";
                case DataType.uniqueidentifierType:
                    return "Guid";
                case DataType.datetimeType:
                    return "DateTime";
                case DataType.MoneyType:
                    return "decimal";
                case DataType.bigintType:
                    return "int";
                case DataType.binaryType:
                    return "byte[]";
                case DataType.decimalType:
                    return "decimal";
                case DataType.floatType:
                    return "decimal";
                case DataType.imageType:
                    return "byte[]";
                case DataType.numericType:
                    return "decimal";
                case DataType.realType:
                    return "decimal";
                case DataType.smalldatetimeType:
                    return "DateTime";
                case DataType.smallintType:
                    return "int";
                case DataType.smallmoneyType:
                    return "decimal";
                case DataType.tinyintType:
                    return "byte";
                case DataType.varbinaryType:
                    return "byte[]";
                default:
                    return "string";
            }
        }

        public static string DataTypeToSQLTypeString(Model.DataType type, int FieldSize)
        {
            switch (type)
            {
                case DataType.intType:
                    return "SqlDbType.Int";
                case DataType.bitType:
                    return "SqlDbType.Bit";
                case DataType.uniqueidentifierType:
                    return "SqlDbType.UniqueIdentifier";
                case DataType.datetimeType:
                    return "SqlDbType.DateTime";
                case DataType.MoneyType:
                    return "SqlDbType.Money";
                case DataType.ntextType:
                    return "SqlDbType.NText";
                case DataType.nvarcharType:
                    return "SqlDbType.NVarChar";
                case DataType.varcharType:
                    return "SqlDbType.VarChar";
                case DataType.bigintType:
                    return "SqlDbType.BigInt";
                case DataType.binaryType:
                    return "SqlDbType.Binary";
                case DataType.charType:
                    return "SqlDbType.Char";
                case DataType.decimalType:
                    return "SqlDbType.Decimal";
                case DataType.floatType:
                    return "SqlDbType.Float";
                case DataType.imageType:
                    return "SqlDbType.Image";
                case DataType.ncharType:
                    return "SqlDbType.NChar";
                case DataType.numericType:
                    return "SqlDbType.Decimal";
                case DataType.realType:
                    return "SqlDbType.Real";
                case DataType.smalldatetimeType:
                    return "SqlDbType.SmallDateTime";
                case DataType.smallintType:
                    return "SqlDbType.SmallInt";
                case DataType.smallmoneyType:
                    return "SqlDbType.SmallMoney";
                case DataType.sql_variantType:
                    return "SqlDbType.VarChar";
                case DataType.textType:
                    return "SqlDbType.Text";
                case DataType.timestampType:
                    return "SqlDbType.Timestamp";
                case DataType.tinyintType:
                    return "SqlDbType.TinyInt";
                case DataType.varbinaryType:
                    return "SqlDbType.VarBinary";
                case DataType.xmlType:
                    return "SqlDbType.Xml";
                default:
                    return "SqlDbType.NVarChar";
            }
        }

        public static string DataTypeToAccessTypeString(Model.DataType type, int FieldSize)
        {
            switch (type)
            {
                case DataType.intType:
                    return "OleDbType.Integer";
                case DataType.bitType:
                    return "OleDbType.Boolean";
                case DataType.uniqueidentifierType:
                    return "OleDbType.Guid";
                case DataType.datetimeType:
                    return "OleDbType.Date";
                case DataType.MoneyType:
                    return "OleDbType.Numeric";
                case DataType.ntextType:
                    return "OleDbType.LongVarWChar";
                case DataType.nvarcharType:
                    return "OleDbType.VarWChar";
                case DataType.varcharType:
                    return "OleDbType.VarChar";
                case DataType.bigintType:
                    return "OleDbType.Integer";
                case DataType.binaryType:
                    return "OleDbType.LongVarBinary";
                case DataType.charType:
                    return "OleDbType.VarChar";
                case DataType.decimalType:
                    return "OleDbType.Decimal";
                case DataType.floatType:
                    return "OleDbType.Numeric";
                case DataType.imageType:
                    return "OleDbType.Binary";
                case DataType.ncharType:
                    return "OleDbType.VarWChar";
                case DataType.numericType:
                    return "OleDbType.Numeric";
                case DataType.realType:
                    return "OleDbType.Numeric";
                case DataType.smalldatetimeType:
                    return "OleDbType.DBDate";
                case DataType.smallintType:
                    return "OleDbType.SmallInt";
                case DataType.smallmoneyType:
                    return "OleDbType.Numeric";
                case DataType.sql_variantType:
                    return "OleDbType.VarChar";
                case DataType.textType:
                    return "OleDbType.LongVarChar";
                case DataType.timestampType:
                    return "OleDbType.DBTimeStamp";
                case DataType.tinyintType:
                    return "OleDbType.TinyInt";
                case DataType.varbinaryType:
                    return "OleDbType.VarBinary";
                case DataType.xmlType:
                    return "OleDbType.LongVarWChar";
                default:
                    return "OleDbType.LongVarWChar";
            }
        }

        public static string DataTypeToCSharpMethod(Model.DataType type)
        {
            switch (type)
            {
                case DataType.intType:
                    return "GetInt";
                case DataType.bitType:
                    return "GetBool";
                case DataType.uniqueidentifierType:
                    return "GetGuid";
                case DataType.datetimeType:
                    return "GetDateTime";
                case DataType.MoneyType:
                    return "GetDecimal";
                case DataType.bigintType:
                    return "GetInt";
                case DataType.decimalType:
                    return "GetDecimal";
                case DataType.floatType:
                    return "GetDecimal";
                case DataType.numericType:
                    return "GetDecimal";
                case DataType.realType:
                    return "GetDecimal";
                case DataType.smalldatetimeType:
                    return "GetDateTime";
                case DataType.smallintType:
                    return "GetInt";
                case DataType.smallmoneyType:
                    return "GetDecimal";
                case DataType.tinyintType:
                    return "Getbyte";
                case DataType.binaryType:
                    return "GetByte";
                case DataType.imageType:
                    return "GetByte";
                case DataType.varbinaryType:
                    return "GetByte";
                default:
                    return "GetString";
            }
        }
    }
}
