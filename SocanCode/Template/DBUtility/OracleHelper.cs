//------------------------------------------------------------------------------
// 创建标识: Copyright (C) 2007 Socansoft.com 版权所有
// 创建描述: SocanCode代码生成器自动创建
//
// 功能描述: 数据库操作基类
//
// 修改标识:
// 修改描述:
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Collections;
using System.Data.OracleClient;
using System.Diagnostics;

namespace DBUtility
{
    /// <summary>
    /// 数据访问基础类(基于Oracle)
    /// </summary>
    public abstract class OracleHelper
    {
        public delegate void CatchException(string connectionString, Hashtable SQLStringList, Exception e);
        /// <summary>
        /// 当发生异常的时候，系统的处理方法。
        /// 可以是抛出异常，也可以写入日志。
        /// 注意第二个参数是Hashtable型。
        /// 其健保存着SQL语句，值保存着参数（可为空）
        /// </summary>
        public static event CatchException OnCatchException;

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="tblName">表名</param>
        /// <param name="fldName">字段名</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">第几页</param>
        /// <param name="fldSort">排序字段</param>
        /// <param name="sort">升序/降序</param>
        /// <param name="strCondition">条件(不需要where)</param>
        /// <param name="pageCount">页数</param>
        /// <param name="count">记录条数</param>
        /// <param name="strSql">SQL语句</param>
        /// <returns></returns>
        public static DataSet PageList(string connectionString, string tblName, int pageSize,
            int pageIndex, string fldSort, bool sort, string condition, out int count)
        {
            string sql = PageHelper.GetPagerSQL(condition, pageSize, pageIndex, fldSort, tblName, sort);
            count = GetCount(connectionString, tblName, condition);
            return Query(connectionString, sql);
        }

        #region 执行简单SQL语句
        /// <summary>
        /// 获取表数据行数
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="tblName">表名</param>
        /// <returns>返回数据行数</returns>
        public static int GetCount(string connectionString, string tblName, string condition)
        {
            StringBuilder sql = new StringBuilder(string.Format("select count(*) from {0}", tblName));
            if (!string.IsNullOrEmpty(condition))
            {
                sql.Append(string.Format(" where {0}", condition));
            }
            DataSet ds = Query(connectionString, sql.ToString());
            if (ds.Tables[0].Rows[0][0] != null)
            {
                return int.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 获取表某个字段的最大值
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static int GetMaxID(string connectionString, string FieldName, string TableName)
        {
            string strSql = "select max(" + FieldName + ") from " + TableName;
            DataSet ds = Query(connectionString, strSql);
            if (ds.Tables[0].Rows[0][0] != DBNull.Value)
                return int.Parse(ds.Tables[0].Rows[0][0].ToString());
            else
                return 0;
        }

        /// <summary>
        ///  检测一个记录是否存在(OracleParameter语句方式)
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static bool Exists(string connectionString, string strSql, params OracleParameter[] cmdParms)
        {
            DataSet ds = Query(connectionString, strSql, cmdParms);
            return int.Parse(ds.Tables[0].Rows[0][0].ToString()) > 0;
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string connectionString, string SQLString)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (OracleException e)
                    {
                        connection.Close();
                        if (OnCatchException != null)
                        {
                            OnCatchException(connectionString, ListHelper.GetStringList(SQLString), e);
                        }
                        return 0;
                    }
                }
            }
        }

        /// <summary>
        /// 执行SQL语句，返回记录的个数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteCountSql(string connectionString, string SQLString)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        OracleDataReader dr = cmd.ExecuteReader();
                        dr.Read();
                        int count = int.Parse(dr[0].ToString());
                        return count;
                    }
                    catch (OracleException e)
                    {
                        connection.Close();
                        if (OnCatchException != null)
                        {
                            OnCatchException(connectionString, ListHelper.GetStringList(SQLString), e);
                        }
                        return 0;
                    }
                }
            }
        }

        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string connectionString, string SQLString, string content)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                OracleCommand cmd = new OracleCommand(SQLString, connection);
                OracleParameter myParameter = new OracleParameter("@content", OracleType.NVarChar);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (OracleException e)
                {
                    if (OnCatchException != null)
                    {
                        OnCatchException(connectionString, ListHelper.GetStringList(SQLString), e);
                    }
                    return 0;
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSqlInsertImg(string connectionString, string SQLString, byte[] fs)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand(SQLString, connection))
                {
                    OracleParameter myParameter = new OracleParameter("@fs", OracleType.BFile);
                    myParameter.Value = fs;
                    cmd.Parameters.Add(myParameter);
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (OracleException e)
                    {
                        connection.Close();
                        if (OnCatchException != null)
                        {
                            OnCatchException(connectionString, ListHelper.GetStringList(SQLString), e);
                        }
                        return 0;
                    }
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string connectionString, string SQLString)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (OracleException e)
                    {
                        connection.Close();
                        if (OnCatchException != null)
                        {
                            OnCatchException(connectionString, ListHelper.GetStringList(SQLString), e);
                        }
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回OracleDataReader
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>OracleDataReader</returns>
        public static OracleDataReader ExecuteReader(string connectionString, string SQLString)
        {
            OracleConnection connection = new OracleConnection(connectionString);
            OracleCommand cmd = new OracleCommand(SQLString, connection);
            try
            {
                connection.Open();
                OracleDataReader myReader = cmd.ExecuteReader();
                return myReader;
            }
            catch (OracleException e)
            {
                cmd.Dispose();
                connection.Close();
                if (OnCatchException != null)
                {
                    OnCatchException(connectionString, ListHelper.GetStringList(SQLString), e);
                }
                return null;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string connectionString, string SQLString)
        {
            if (SQLString != null && SQLString.Trim() != "")
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        connection.Open();
                        OracleDataAdapter command = new OracleDataAdapter(SQLString, connection);
                        command.Fill(ds, "ds");
                    }
                    catch (OracleException e)
                    {
                        if (OnCatchException != null)
                        {
                            OnCatchException(connectionString, ListHelper.GetStringList(SQLString), e);
                        }
                    }
                    return ds;
                }
            }
            else
            {
                return null;
            }
        }
        #endregion 执行简单SQL语句

        #region 执行带参数的SQL语句
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string connectionString, string SQLString, params OracleParameter[] cmdParms)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (OracleException e)
                    {
                        if (OnCatchException != null)
                        {
                            OnCatchException(connectionString, ListHelper.GetStringList(SQLString, cmdParms), e);
                        }
                        return 0;
                    }
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的OracleParameter[]）</param>
        public static bool ExecuteSqlTran(string connectionString, Hashtable SQLStringList)
        {
            bool IsSuccess = false;
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleTransaction trans = conn.BeginTransaction())
                {
                    OracleCommand cmd = new OracleCommand();
                    try
                    {
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            OracleParameter[] cmdParms = (OracleParameter[])myDE.Value;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                        IsSuccess = true;
                    }
                    catch (OracleException e)
                    {
                        trans.Rollback();
                        if (OnCatchException != null)
                        {
                            OnCatchException(connectionString, SQLStringList, e);
                        }
                    }
                }
                return IsSuccess;
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>	
        public static bool ExecuteSqlTran(string connectionString, List<string> SQLStringList)
        {
            bool IsSuccess = false;
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleTransaction trans = conn.BeginTransaction())
                {
                    OracleCommand cmd = new OracleCommand();
                    try
                    {
                        foreach (string SQL in SQLStringList)
                        {
                            string cmdText = SQL;
                            PrepareCommand(cmd, conn, trans, cmdText, null);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                        IsSuccess = true;
                    }
                    catch (OracleException e)
                    {
                        trans.Rollback();
                        if (OnCatchException != null)
                        {
                            OnCatchException(connectionString, ListHelper.GetStringList(SQLStringList), e);
                        }
                    }
                }
                return IsSuccess;
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string connectionString, string SQLString, params OracleParameter[] cmdParms)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (OracleException e)
                    {
                        if (OnCatchException != null)
                        {
                            OnCatchException(connectionString, ListHelper.GetStringList(SQLString, cmdParms), e);
                        }
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回OracleDataReader
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>OracleDataReader</returns>
        public static OracleDataReader ExecuteReader(string connectionString, string SQLString, params OracleParameter[] cmdParms)
        {
            OracleConnection connection = new OracleConnection(connectionString);
            OracleCommand cmd = new OracleCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                OracleDataReader myReader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (OracleException e)
            {
                if (OnCatchException != null)
                {
                    OnCatchException(connectionString, ListHelper.GetStringList(SQLString, cmdParms), e);
                }
                return null;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string connectionString, string SQLString, params OracleParameter[] cmdParms)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                    using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        try
                        {
                            da.Fill(ds, "ds");
                            cmd.Parameters.Clear();
                        }
                        catch (OracleException e)
                        {
                            if (OnCatchException != null)
                            {
                                OnCatchException(connectionString, ListHelper.GetStringList(SQLString, cmdParms), e);
                            }
                        }
                        return ds;
                    }
                }
            }
        }

        private static void PrepareCommand(OracleCommand cmd, OracleConnection conn, OracleTransaction trans, string cmdText, OracleParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;
            if (cmdParms != null)
            {
                foreach (OracleParameter parm in cmdParms)
                {
                    if (parm.OracleType == OracleType.DateTime)
                    {
                        if ((DateTime)parm.Value == DateTime.MinValue)
                            parm.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parm);
                }
            }
        }
        #endregion 执行带参数的SQL语句

        #region 存储过程操作
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>OracleDataReader</returns>
        public static OracleDataReader RunProcedure(string connectionString, string storedProcName, IDataParameter[] parameters)
        {
            OracleConnection connection = new OracleConnection(connectionString);
            OracleDataReader returnReader;
            connection.Open();
            OracleCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;
            returnReader = command.ExecuteReader();
            return returnReader;
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string connectionString, string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                OracleDataAdapter sqlDA = new OracleDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }

        /// <summary>
        /// 构建 OracleCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>OracleCommand</returns>
        private static OracleCommand BuildQueryCommand(OracleConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            OracleCommand command = new OracleCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            if (parameters != null)
            {
                foreach (OracleParameter parameter in parameters)
                {
                    if (parameter.OracleType == OracleType.DateTime)
                    {
                        if ((DateTime)parameter.Value == DateTime.MinValue)
                            parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }
            return command;
        }

        /// <summary>
        /// 执行存储过程，返回Return值		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public static int RunProcedure(string connectionString, string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                int result;
                connection.Open();
                OracleCommand command = BuildIntCommand(connection, storedProcName, parameters);
                rowsAffected = command.ExecuteNonQuery();
                result = (int)command.Parameters["ReturnValue"].Value;
                connection.Close();
                return result;
            }
        }

        /// <summary>
        /// 创建 OracleCommand 对象实例(用来返回一个整数值)	
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>OracleCommand 对象实例</returns>
        private static OracleCommand BuildIntCommand(OracleConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            OracleCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new OracleParameter("ReturnValue",
                OracleType.Int32, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }
        #endregion 存储过程操作

        #region 构造语句常用类
        /// <summary>
        /// 构造输入参数
        /// </summary>
        /// <param name="ParamName">参数名</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <param name="Value">参数值</param>
        /// <returns>返回构造的参数</returns>
        public static OracleParameter MakeInParam(string ParamName, OracleType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        public static OracleParameter MakeInParam(string ParamName, OracleType DbType, object Value)
        {
            return MakeParam(ParamName, DbType, 0, ParameterDirection.Input, Value);
        }

        /// <summary>
        /// 构造输出参数
        /// </summary>
        /// <param name="ParamName">参数名</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <param name="Value">参数值</param>
        /// <returns>返回构造的参数</returns>
        public static OracleParameter MakeOutParam(string ParamName, OracleType DbType, int Size)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
        }

        /// <summary>
        /// 构造存储过程参数
        /// </summary>
        /// <param name="ParamName">参数名</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <param name="Value">参数值</param>
        /// <returns>返回构造的参数</returns>
        public static OracleParameter MakeParam(string ParamName, OracleType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            OracleParameter param;

            if (Size > 0)
                param = new OracleParameter(ParamName, DbType, Size);
            else
                param = new OracleParameter(ParamName, DbType);

            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;

            return param;
        }
        #endregion 构造语句常用类
    }
}