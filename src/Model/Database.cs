using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;

namespace Model
{
    public class Database
    {
        public enum DatabaseType
        {
            Access,
            Sql2000,
            Sql2005
        }

        /// <summary>
        /// 取得数据库要引用的命名空间,如：System.Data.SqlClient
        /// </summary>
        public static string GetUsing(DatabaseType type)
        {
            switch (type)
            {
                case DatabaseType.Access:
                    return "System.Data.OleDb";
                case DatabaseType.Sql2000:
                case DatabaseType.Sql2005:
                    return "System.Data.SqlClient";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// 得到DAL的命名空间，如：SQLServerDAL
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetDALNamespace(DatabaseType type)
        {
            switch (type)
            {
                case DatabaseType.Access:
                    return "AccessDAL";
                case DatabaseType.Sql2000:
                case DatabaseType.Sql2005:
                    return "SQLServerDAL";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// 得到DBUtility中要使用的类，如：SqlHelper
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetHelperClass(DatabaseType type)
        {
            switch (type)
            {
                case Model.Database.DatabaseType.Access:
                    return "DBUtility.AccessHelper";
                case Model.Database.DatabaseType.Sql2000:
                case Model.Database.DatabaseType.Sql2005:
                    return "DBUtility.SqlHelper";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// 得到参数类型，如：SqlParameter
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetParameterType(DatabaseType type)
        {
            switch (type)
            {
                case Model.Database.DatabaseType.Access:
                    return "OleDbParameter";
                case Model.Database.DatabaseType.Sql2000:
                case Model.Database.DatabaseType.Sql2005:
                    return "SqlParameter";
                default:
                    return "DbParameter";
            }
        }


        #region 成员变量
        private string _connectionstring;
        private bool _connected;
        private DatabaseType _type;
        private List<Model.Table> _tables = new List<Table>();
        private List<string> _storeprocedures = new List<string>();
        private List<string> _views = new List<string>();

        /// <summary>
        /// 数据库连接参数
        /// </summary>
        public string ConnectionString
        {
            get { return _connectionstring; }
            set { _connectionstring = value; }
        }

        /// <summary>
        /// 数据库名或文件路径
        /// </summary>
        public string DatabaseName
        {
            get
            {
                if (_type == DatabaseType.Access)
                {
                    OleDbConnection conn = new OleDbConnection(_connectionstring);
                    return conn.DataSource;
                }
                else
                {
                    SqlConnection conn = new SqlConnection(_connectionstring);
                    return conn.Database;
                }
            }
        }

        /// <summary>
        /// 是否连接成功
        /// </summary>
        public bool Connected
        {
            get { return _connected; }
            set { _connected = value; }
        }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public DatabaseType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// 所有表
        /// </summary>
        public List<Model.Table> Tables
        {
            get { return _tables; }
            set { _tables = value; }
        }

        /// <summary>
        /// 所有存储过程名
        /// </summary>
        public List<string> StoreProcedures
        {
            get { return _storeprocedures; }
            set { _storeprocedures = value; }
        }

        /// <summary>
        /// 所有视图名
        /// </summary>
        public List<string> Views
        {
            get { return _views; }
            set { _views = value; }
        }
        #endregion
    }
}
