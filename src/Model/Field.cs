using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public enum DataType
    {
        intType,
        bitType,
        uniqueidentifierType,
        datetimeType,
        MoneyType,
        ntextType,
        nvarcharType,
        varcharType,
        bigintType,
        binaryType,
        charType,
        decimalType,
        floatType,
        imageType,
        ncharType,
        numericType,
        realType,
        smalldatetimeType,
        smallintType,
        smallmoneyType,
        sql_variantType,
        textType,
        timestampType,
        tinyintType,
        varbinaryType,
        xmlType
    }

    public class Field
    {
        private string _name;
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _fieldnumber;
        /// <summary>
        /// 字段序列
        /// </summary>
        public int FieldNumber
        {
            get { return _fieldnumber; }
            set { _fieldnumber = value; }
        }

        private string _fieldname;
        /// <summary>
        /// 字段名
        /// </summary>
        public string FieldName
        {
            get { return _fieldname; }
            set { _fieldname = value; }
        }

        private bool _isidentifier;
        /// <summary>
        /// 是否是标识
        /// </summary>
        public bool IsIdentifier
        {
            get { return _isidentifier; }
            set { _isidentifier = value; }
        }

        private bool _iskeyfield;
        /// <summary>
        /// 是否是主键
        /// </summary>
        public bool IsKeyField
        {
            get { return _iskeyfield; }
            set { _iskeyfield = value; }
        }

        private DataType _fieldtype;
        /// <summary>
        /// 数据类型
        /// </summary>
        public DataType FieldType
        {
            get { return _fieldtype; }
        }

        public void SetFieldType(string sqlType)
        {
            switch (sqlType)
            {
                case "bit":
                    _fieldtype = DataType.bitType;
                    break;
                case "datetime":
                    _fieldtype = DataType.datetimeType;
                    break;
                case "int":
                    _fieldtype = DataType.intType;
                    break;
                case "ntext":
                    _fieldtype = DataType.ntextType;
                    break;
                case "uniqueidentifier":
                    _fieldtype = DataType.uniqueidentifierType;
                    break;
                case "money":
                    _fieldtype = DataType.MoneyType;
                    break;
                case "bigint":
                    _fieldtype = DataType.bigintType;
                    break;
                case "binary":
                    _fieldtype = DataType.binaryType;
                    break;
                case "char":
                    _fieldtype = DataType.charType;
                    break;
                case "decimal":
                    _fieldtype = DataType.decimalType;
                    break;
                case "float":
                    _fieldtype = DataType.floatType;
                    break;
                case "image":
                    _fieldtype = DataType.imageType;
                    break;
                case "nchar":
                    _fieldtype = DataType.ncharType;
                    break;
                case "numeric":
                    _fieldtype = DataType.numericType;
                    break;
                case "real":
                    _fieldtype = DataType.realType;
                    break;
                case "smalldatetime":
                    _fieldtype = DataType.smalldatetimeType;
                    break;
                case "smallint":
                    _fieldtype = DataType.smallintType;
                    break;
                case "smallmoney":
                    _fieldtype = DataType.smallmoneyType;
                    break;
                case "sql_variant":
                    _fieldtype = DataType.sql_variantType;
                    break;
                case "text":
                    _fieldtype = DataType.textType;
                    break;
                case "timestamp":
                    _fieldtype = DataType.timestampType;
                    break;
                case "tinyint":
                    _fieldtype = DataType.tinyintType;
                    break;
                case "varbinary":
                    _fieldtype = DataType.varbinaryType;
                    break;
                case "xml":
                    _fieldtype = DataType.xmlType;
                    break;
                case "varchar":
                    _fieldtype = DataType.varcharType;
                    break;
                default:
                    _fieldtype = DataType.nvarcharType;
                    break;
            }
        }

        public void SetFieldType(int sqlType)
        {
            switch (sqlType)
            {
                case 11:
                    _fieldtype = DataType.bitType;
                    break;
                case 135:
                    _fieldtype = DataType.datetimeType;
                    break;
                case 7:
                    _fieldtype = DataType.datetimeType;
                    break;
                case 3:
                    _fieldtype = DataType.intType;
                    break;
                case 72:
                    _fieldtype = DataType.uniqueidentifierType;
                    break;
                case 6:
                    _fieldtype = DataType.MoneyType;
                    break;
                case 20:
                    _fieldtype = DataType.bigintType;
                    break;
                case 128:
                    _fieldtype = DataType.varbinaryType;
                    break;
                case 116:
                    _fieldtype = DataType.decimalType;
                    break;
                case 5:
                    _fieldtype = DataType.floatType;
                    break;
                case 4:
                    _fieldtype = DataType.realType;
                    break;
                case 2:
                    _fieldtype = DataType.smallintType;
                    break;
                case 12:
                    _fieldtype = DataType.sql_variantType;
                    break;
                case 17:
                    _fieldtype = DataType.tinyintType;
                    break;
                case 129:
                    _fieldtype = DataType.textType;
                    break;
                default:
                    _fieldtype = DataType.ntextType;
                    break;
            }
        }

        /// <summary>
        /// 数据类型字符串
        /// </summary>
        public string SQLTypeString
        {
            get
            {
                switch (_fieldtype)
                {
                    case DataType.bitType:
                        return "bit";
                    case DataType.datetimeType:
                        return "datetime";
                    case DataType.intType:
                        return "int";
                    case DataType.ntextType:
                        return "ntext";
                    case DataType.uniqueidentifierType:
                        return "uniqueidentifier";
                    case DataType.MoneyType:
                        return "money";
                    case DataType.bigintType:
                        return "bigint";
                    case DataType.binaryType:
                        return "binary";
                    case DataType.charType:
                        return "char";
                    case DataType.decimalType:
                        return "decimal";
                    case DataType.floatType:
                        return "float";
                    case DataType.imageType:
                        return "image";
                    case DataType.ncharType:
                        return "nchar";
                    case DataType.numericType:
                        return "numeric";
                    case DataType.realType:
                        return "real";
                    case DataType.smalldatetimeType:
                        return "smalldatetime";
                    case DataType.smallintType:
                        return "smallint";
                    case DataType.smallmoneyType:
                        return "smallmoney";
                    case DataType.sql_variantType:
                        return "sql_variant";
                    case DataType.textType:
                        return "text";
                    case DataType.timestampType:
                        return "timestamp";
                    case DataType.tinyintType:
                        return "tinyint";
                    case DataType.varbinaryType:
                        return "varbinary";
                    case DataType.xmlType:
                        return "xml";
                    case DataType.varcharType:
                        return "varchar";
                    default:
                        return "nvarchar";
                }
            }
        }

        private int _fieldsize;
        /// <summary>
        /// 占用字节数
        /// </summary>
        public int FieldSize
        {
            get { return _fieldsize; }
            set { _fieldsize = value; }
        }

        private int _fieldlength;
        /// <summary>
        /// 长度
        /// </summary>
        public int FieldLength
        {
            get { return _fieldlength; }
            set { _fieldlength = value; }
        }

        private bool _allownull;
        /// <summary>
        /// 是否允许空
        /// </summary>
        public bool AllowNull
        {
            get { return _allownull; }
            set { _allownull = value; }
        }

        private string _defaultvalue;
        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue
        {
            get { return _defaultvalue; }
            set { _defaultvalue = value; }
        }

        private string _fielddescn;
        /// <summary>
        /// 字段说明
        /// </summary>
        public string FieldDescn
        {
            get { return _fielddescn; }
            set { _fielddescn = value; }
        }

    }
}
