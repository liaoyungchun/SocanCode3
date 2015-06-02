using System;
using System.Collections.Generic;
using System.Text;
using DBUtility;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace CodeUtility
{
    public class DatabaseInfo
    {
        /// <summary>
        /// 获取数据库信息
        /// </summary>
        /// <param name="database"></param>
        public static void GetDatabaseInfo(Model.Database database)
        {
            if (database.Type == Model.Database.DatabaseType.Access)
            {
                #region ACCESS获取表结构
                try
                {
                    DataTable dtAllTable = GetDbSchema(database.ConnectionString, OleDbSchemaGuid.Tables, new object[] { null, null, null, "table" });
                    foreach (DataRow rt in dtAllTable.Rows)
                    {
                        Model.Table tb = new Model.Table();
                        tb.Name = rt["TABLE_NAME"].ToString();
                        DataTable dtColumns = GetDbSchema(database.ConnectionString, OleDbSchemaGuid.Columns, new object[] { null, null, tb.Name });
                        foreach (DataRow rc in dtColumns.Rows)
                        {
                            tb.Fields.Add(GetAccessField(database.ConnectionString, tb.Name, rc));
                        }
                        database.Tables.Add(tb);
                    }

                    DataTable dtAllView = GetDbSchema(database.ConnectionString, OleDbSchemaGuid.Views, null);
                    foreach (DataRow rv in dtAllView.Rows)
                    {
                        database.Views.Add(rv["TABLE_NAME"].ToString());
                    }

                    DataTable dtAllStoreProcedure = GetDbSchema(database.ConnectionString, OleDbSchemaGuid.Procedures, null);
                    foreach (DataRow rsp in dtAllStoreProcedure.Rows)
                    {
                        database.StoreProcedures.Add(rsp["PROCEDURE_NAME"].ToString());
                    }
                    database.Connected = true;
                }
                catch
                {
                    database.Connected = false;
                }

                #endregion
            }
            else
            {
                #region SQLServer获取表结构
                SqlConnection connection = new SqlConnection();
                try
                {
                    connection.ConnectionString = database.ConnectionString;
                    connection.Open();

                    string strSql = GetSqlString.GetTables(database.Type);
                    DataSet ds = SqlHelper.Query(database.ConnectionString, strSql);
                    database.Tables = GetSQLTableList(ds);

                    strSql = GetSqlString.GetViews();
                    ds = SqlHelper.Query(database.ConnectionString, strSql);
                    database.Views = GetSQLViewList(ds);

                    strSql = GetSqlString.GetStoreProcedures();
                    ds = SqlHelper.Query(database.ConnectionString, strSql);
                    database.StoreProcedures = GetSQLStoreProcedureList(ds);
                    database.Connected = true;
                }
                catch
                {
                    database.Connected = false;
                }
                finally
                {
                    connection.Close();
                }
                #endregion
            }
        }

        #region ACCESS获取表结构相关方法
        private static Model.Field GetAccessField(string connectionString, string tbName, DataRow r)
        {
            Model.Field model = new Model.Field();
            model.AllowNull = CommonHelper.GetBool(r["IS_NULLABLE"]);
            model.DefaultValue = CommonHelper.GetString(r["COLUMN_DEFAULT"]);
            model.FieldDescn = CommonHelper.GetString(r["DESCRIPTION"]);
            model.FieldLength = CommonHelper.GetInt(r["CHARACTER_MAXIMUM_LENGTH"]);
            model.FieldName = CommonHelper.GetString(r["COLUMN_NAME"]);
            model.FieldNumber = CommonHelper.GetInt(r["ORDINAL_POSITION"]);
            model.FieldSize = CommonHelper.GetInt(r["CHARACTER_OCTET_LENGTH"]);
            model.SetFieldType(Convert.ToInt32(r["DATA_TYPE"]));

            DataTable dtPrimanyKey = GetDbSchema(connectionString, OleDbSchemaGuid.Primary_Keys, null);
            foreach (DataRow rp in dtPrimanyKey.Rows)
            {
                if (rp[2].ToString() == tbName && rp[3].ToString() == model.FieldName)
                {
                    model.IsKeyField = true;
                    model.IsIdentifier = true; //由于无法获取标识，这里把主键就当成标识
                }
            }

            model.TableName = CommonHelper.GetString(r["TABLE_NAME"]);
            return model;
        }
        private static DataTable GetDbSchema(string connString, Guid schema, object[] restrictions)
        {
            OleDbConnection myConn = new OleDbConnection(connString);
            myConn.Open();
            DataTable table1 = myConn.GetOleDbSchemaTable(schema, restrictions);
            myConn.Close();
            return table1;
        }
        #endregion

        #region SQLServer获取表结构相关方法
        #region 由数据集获取表的泛型集合
        private static List<Model.Table> GetSQLTableList(DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            List<Model.Table> lTable = new List<Model.Table>();
            foreach (DataRow r in dt.Rows)
            {
                Model.Field model = GetSQLField(r);
                bool hasTable = false;
                foreach (Model.Table modelTable in lTable)
                {
                    if (model.TableName == modelTable.Fields[0].TableName)
                    {
                        modelTable.Fields.Add(model);
                        hasTable = true;
                        break;
                    }
                }
                if (!hasTable)
                {
                    Model.Table newTable = new Model.Table();
                    newTable.Name = model.TableName;
                    List<Model.Field> lFields = new List<Model.Field>();
                    lFields.Add(model);
                    newTable.Fields = lFields;
                    lTable.Add(newTable);
                }
            }
            return lTable;
        }
        private static Model.Field GetSQLField(DataRow r)
        {
            Model.Field model = new Model.Field();
            model.AllowNull = CommonHelper.GetBool(r["AllowNull"]);
            model.DefaultValue = CommonHelper.GetString(r["DefaultValue"]);
            model.FieldDescn = CommonHelper.GetString(r["FieldDescn"]);
            model.FieldLength = CommonHelper.GetInt(r["FieldLength"]);
            model.FieldName = CommonHelper.GetString(r["FieldName"]);
            model.FieldNumber = CommonHelper.GetInt(r["FieldNumber"]);
            model.FieldSize = CommonHelper.GetInt(r["FieldSize"]);
            model.SetFieldType(r["FieldType"].ToString());
            model.IsIdentifier = CommonHelper.GetBool(r["IsIdentifier"]);
            model.IsKeyField = CommonHelper.GetBool(r["IsKeyField"]);
            model.TableName = CommonHelper.GetString(r["TableName"]);
            return model;
        }
        #endregion

        /// <summary>
        /// 获取所有视图集合
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        private static List<string> GetSQLViewList(DataSet ds)
        {
            List<string> storeViews = new List<string>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                storeViews.Add(r[0].ToString());
            }
            return storeViews;
        }

        /// <summary>
        /// 获取所有存储过程集合
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        private static List<string> GetSQLStoreProcedureList(DataSet ds)
        {
            List<string> storeProcedures = new List<string>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                storeProcedures.Add(r[0].ToString());
            }
            return storeProcedures;
        }
        #endregion
    }
}
