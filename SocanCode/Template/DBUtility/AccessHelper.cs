//------------------------------------------------------------------------------
// ������ʶ: Copyright (C) 2007 Socansoft.com ��Ȩ����
// ��������: SocanCode�����������Զ�����
//
// ��������: ���ݿ��������
//
// �޸ı�ʶ:
// �޸�����:
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Collections;
using System.Data.OleDb;
using System.Diagnostics;

namespace DBUtility
{
    /// <summary>
    /// ���ݷ��ʻ�����(����Access)
    /// </summary>
    public abstract class AccessHelper
    {
        public delegate void CatchException(string connectionString, Hashtable SQLStringList, Exception e);
        /// <summary>
        /// �������쳣��ʱ��ϵͳ�Ĵ�������
        /// �������׳��쳣��Ҳ����д����־��
        /// ע��ڶ���������Hashtable�͡�
        /// �佡������SQL��䣬ֵ�����Ų�������Ϊ�գ�
        /// </summary>
        public static event CatchException OnCatchException;

        /// <summary>
        /// ��ҳ��ȡ����
        /// </summary>
        /// <param name="connectionString">�����ַ���</param>
        /// <param name="tblName">����</param>
        /// <param name="fldName">�ֶ���</param>
        /// <param name="pageSize">ҳ��С</param>
        /// <param name="pageIndex">�ڼ�ҳ</param>
        /// <param name="fldSort">�����ֶ�</param>
        /// <param name="sort">����/����</param>
        /// <param name="strCondition">����(����Ҫwhere)</param>
        /// <param name="pageCount">ҳ��</param>
        /// <param name="count">��¼����</param>
        /// <param name="strSql">SQL���</param>
        /// <returns></returns>
        public static DataSet PageList(string connectionString, string tblName, int pageSize,
            int pageIndex, string fldSort, bool sort, string condition, out int count)
        {
            string sql = PageHelper.GetPagerSQL(condition, pageSize, pageIndex, fldSort, tblName, sort);
            count = GetCount(connectionString, tblName, condition);
            return Query(connectionString, sql);
        }

        #region ִ�м�SQL���
        /// <summary>
        /// ��ȡ����������
        /// </summary>
        /// <param name="connectionString">�����ַ���</param>
        /// <param name="tblName">����</param>
        /// <returns>������������</returns>
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
        /// ��ȡ��ĳ���ֶε����ֵ
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
        ///  ���һ����¼�Ƿ����(OleDbParameter��䷽ʽ)
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static bool Exists(string connectionString, string strSql, params OleDbParameter[] cmdParms)
        {
            DataSet ds = Query(connectionString, strSql, cmdParms);
            return int.Parse(ds.Tables[0].Rows[0][0].ToString()) > 0;
        }

        /// <summary>
        /// ִ��SQL��䣬����Ӱ��ļ�¼��
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public static int ExecuteSql(string connectionString, string SQLString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (OleDbException e)
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
        /// ִ��SQL��䣬���ؼ�¼�ĸ���
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public static int ExecuteCountSql(string connectionString, string SQLString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        OleDbDataReader dr = cmd.ExecuteReader();
                        dr.Read();
                        int count = int.Parse(dr[0].ToString());
                        return count;
                    }
                    catch (OleDbException e)
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
        /// ִ�д�һ���洢���̲����ĵ�SQL��䡣
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <param name="content">��������,����һ���ֶ��Ǹ�ʽ���ӵ����£���������ţ�����ͨ�������ʽ���</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public static int ExecuteSql(string connectionString, string SQLString, string content)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand(SQLString, connection);
                OleDbParameter myParameter = new OleDbParameter("@content", OleDbType.WChar);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (OleDbException e)
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
        /// �����ݿ������ͼ���ʽ���ֶ�(������������Ƶ���һ��ʵ��)
        /// </summary>
        /// <param name="strSQL">SQL���</param>
        /// <param name="fs">ͼ���ֽ�,���ݿ���ֶ�����Ϊimage�����</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public static int ExecuteSqlInsertImg(string connectionString, string SQLString, byte[] fs)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
                {
                    OleDbParameter myParameter = new OleDbParameter("@fs", OleDbType.Binary);
                    myParameter.Value = fs;
                    cmd.Parameters.Add(myParameter);
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (OleDbException e)
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
        /// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
        /// </summary>
        /// <param name="SQLString">�����ѯ������</param>
        /// <returns>��ѯ�����object��</returns>
        public static object GetSingle(string connectionString, string SQLString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
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
                    catch (OleDbException e)
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
        /// ִ�в�ѯ��䣬����OleDbDataReader
        /// </summary>
        /// <param name="strSQL">��ѯ���</param>
        /// <returns>OleDbDataReader</returns>
        public static OleDbDataReader ExecuteReader(string connectionString, string SQLString)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand(SQLString, connection);
            try
            {
                connection.Open();
                OleDbDataReader myReader = cmd.ExecuteReader();
                return myReader;
            }
            catch (OleDbException e)
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
        /// ִ�в�ѯ��䣬����DataSet
        /// </summary>
        /// <param name="SQLString">��ѯ���</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string connectionString, string SQLString)
        {
            if (SQLString != null && SQLString.Trim() != "")
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        connection.Open();
                        OleDbDataAdapter command = new OleDbDataAdapter(SQLString, connection);
                        command.Fill(ds, "ds");
                    }
                    catch (OleDbException e)
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
        #endregion ִ�м�SQL���

        #region ִ�д�������SQL���
        /// <summary>
        /// ִ��SQL��䣬����Ӱ��ļ�¼��
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public static int ExecuteSql(string connectionString, string SQLString, params OleDbParameter[] cmdParms)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (OleDbException e)
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
        /// ִ�ж���SQL��䣬ʵ�����ݿ�����
        /// </summary>
        /// <param name="SQLStringList">SQL���Ĺ�ϣ��keyΪsql��䣬value�Ǹ�����OleDbParameter[]��</param>
        public static bool ExecuteSqlTran(string connectionString, Hashtable SQLStringList)
        {
            bool IsSuccess = false;
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbTransaction trans = conn.BeginTransaction())
                {
                    OleDbCommand cmd = new OleDbCommand();
                    try
                    {
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            OleDbParameter[] cmdParms = (OleDbParameter[])myDE.Value;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                        IsSuccess = true;
                    }
                    catch (OleDbException e)
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
        /// ִ�ж���SQL��䣬ʵ�����ݿ�����
        /// </summary>
        /// <param name="SQLStringList">����SQL���</param>	
        public static bool ExecuteSqlTran(string connectionString, List<string> SQLStringList)
        {
            bool IsSuccess = false;
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbTransaction trans = conn.BeginTransaction())
                {
                    OleDbCommand cmd = new OleDbCommand();
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
                    catch (OleDbException e)
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
        /// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
        /// </summary>
        /// <param name="SQLString">�����ѯ������</param>
        /// <returns>��ѯ�����object��</returns>
        public static object GetSingle(string connectionString, string SQLString, params OleDbParameter[] cmdParms)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
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
                    catch (OleDbException e)
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
        /// ִ�в�ѯ��䣬����OleDbDataReader
        /// </summary>
        /// <param name="strSQL">��ѯ���</param>
        /// <returns>OleDbDataReader</returns>
        public static OleDbDataReader ExecuteReader(string connectionString, string SQLString, params OleDbParameter[] cmdParms)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                OleDbDataReader myReader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (OleDbException e)
            {
                if (OnCatchException != null)
                {
                    OnCatchException(connectionString, ListHelper.GetStringList(SQLString, cmdParms), e);
                }
                return null;
            }
        }

        /// <summary>
        /// ִ�в�ѯ��䣬����DataSet
        /// </summary>
        /// <param name="SQLString">��ѯ���</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string connectionString, string SQLString, params OleDbParameter[] cmdParms)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        try
                        {
                            da.Fill(ds, "ds");
                            cmd.Parameters.Clear();
                        }
                        catch (OleDbException e)
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

        private static void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, string cmdText, OleDbParameter[] cmdParms)
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
                foreach (OleDbParameter parm in cmdParms)
                {
                    if (parm.OleDbType == OleDbType.Date)
                    {
                        if ((DateTime)parm.Value == DateTime.MinValue)
                            parm.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parm);
                }
            }
        }
        #endregion ִ�д�������SQL���

        #region �洢���̲���
        /// <summary>
        /// ִ�д洢����
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>OleDbDataReader</returns>
        public static OleDbDataReader RunProcedure(string connectionString, string storedProcName, IDataParameter[] parameters)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbDataReader returnReader;
            connection.Open();
            OleDbCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;
            returnReader = command.ExecuteReader();
            return returnReader;
        }

        /// <summary>
        /// ִ�д洢����
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <param name="tableName">DataSet����еı���</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string connectionString, string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                OleDbDataAdapter sqlDA = new OleDbDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }

        /// <summary>
        /// ���� OleDbCommand ����(��������һ���������������һ������ֵ)
        /// </summary>
        /// <param name="connection">���ݿ�����</param>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>OleDbCommand</returns>
        private static OleDbCommand BuildQueryCommand(OleDbConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            OleDbCommand command = new OleDbCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            if (parameters != null)
            {
                foreach (OleDbParameter parameter in parameters)
                {
                    if (parameter.OleDbType == OleDbType.Date)
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
        /// ִ�д洢���̣�����Returnֵ		
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <param name="rowsAffected">Ӱ�������</param>
        /// <returns></returns>
        public static int RunProcedure(string connectionString, string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                int result;
                connection.Open();
                OleDbCommand command = BuildIntCommand(connection, storedProcName, parameters);
                rowsAffected = command.ExecuteNonQuery();
                result = (int)command.Parameters["ReturnValue"].Value;
                connection.Close();
                return result;
            }
        }

        /// <summary>
        /// ���� OleDbCommand ����ʵ��(��������һ������ֵ)	
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>OleDbCommand ����ʵ��</returns>
        private static OleDbCommand BuildIntCommand(OleDbConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            OleDbCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new OleDbParameter("ReturnValue",
                OleDbType.Integer, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }
        #endregion �洢���̲���

        #region ������䳣����
        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="ParamName">������</param>
        /// <param name="DbType">��������</param>
        /// <param name="Size">������С</param>
        /// <param name="Value">����ֵ</param>
        /// <returns>���ع���Ĳ���</returns>
        public static OleDbParameter MakeInParam(string ParamName, OleDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        public static OleDbParameter MakeInParam(string ParamName, OleDbType DbType, object Value)
        {
            return MakeParam(ParamName, DbType, 0, ParameterDirection.Input, Value);
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="ParamName">������</param>
        /// <param name="DbType">��������</param>
        /// <param name="Size">������С</param>
        /// <param name="Value">����ֵ</param>
        /// <returns>���ع���Ĳ���</returns>
        public static OleDbParameter MakeOutParam(string ParamName, OleDbType DbType, int Size)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
        }

        /// <summary>
        /// ����洢���̲���
        /// </summary>
        /// <param name="ParamName">������</param>
        /// <param name="DbType">��������</param>
        /// <param name="Size">������С</param>
        /// <param name="Value">����ֵ</param>
        /// <returns>���ع���Ĳ���</returns>
        public static OleDbParameter MakeParam(string ParamName, OleDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            OleDbParameter param;

            if (Size > 0)
                param = new OleDbParameter(ParamName, DbType, Size);
            else
                param = new OleDbParameter(ParamName, DbType);

            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;

            return param;
        }
        #endregion ������䳣����
    }
}