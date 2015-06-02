using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Data.OleDb;

namespace DBUtility
{
    /// <summary>
    /// 数据访问基础类(基于SQLServer)
    /// </summary>
    public class GetSqlString
    {
        public static string GetTables(Model.Database.DatabaseType type)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT d.name N'TableName',a.colorder N'FieldNumber',a.name N'FieldName', ");
            strSql.Append("(case when COLUMNPROPERTY( a.id,a.name,'IsIdentity')=1 then '1'else '0' end) N'IsIdentifier',");
            strSql.Append("(case when (SELECT count(*) ");
            strSql.Append(" FROM sysobjects WHERE (name in (SELECT name FROM sysindexes ");
            strSql.Append(" WHERE (id = a.id) AND (indid in (SELECT indid FROM sysindexkeys");
            strSql.Append(" WHERE (id = a.id) AND (colid in (SELECT colid FROM syscolumns");
            strSql.Append(" WHERE (id = a.id) AND (name = a.name))))))) AND (xtype = 'PK'))>0 ");
            strSql.Append(" then '1' else '0' end) N'IsKeyField', b.name N'FieldType',a.length N'FieldSize', ");
            strSql.Append(" COLUMNPROPERTY(a.id,a.name,'PRECISION') as N'FieldLength', ");
            strSql.Append(" isnull(COLUMNPROPERTY(a.id,a.name,'Scale'),0) as N'DecimalDigits', ");
            strSql.Append(" (case when a.isnullable=1 then '1'else '0' end) N'AllowNull', isnull(e.text,'') N'DefaultValue', ");
            strSql.Append(" isnull(g.[value],'') AS N'FieldDescn' ");
            strSql.Append(" FROM syscolumns a left join systypes b on a.xtype=b.xusertype inner join sysobjects d ");
            strSql.Append(" on a.id=d.id and d.xtype='U' and d.name<>'dtproperties' left join syscomments e on a.cdefault=e.id ");

            if (type == Model.Database.DatabaseType.Sql2005)
            {
                strSql.Append(" left join sys.extended_properties g on a.id=g.major_id AND a.colid = g.minor_id order by object_name(a.id),a.colorder");
            }
            else
            {
                strSql.Append(" left join sysproperties g on a.id=g.id AND a.colid = g.smallid order by object_name(a.id),a.colorder ");
            }
            return strSql.ToString();
        }

        public static string GetStoreProcedures()
        {
            return "select distinct(name) from sysobjects where type='p' ";
        }

        public static string GetViews()
        {
            return "select distinct(name) from sysobjects where type='v' ";
        }
    }
}
