using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CodeUtility
{
    public class SpInfo
    {
        public static string GetSpInfo(Model.Database database, string storeProcedureName)
        {
            StringBuilder code = new StringBuilder();
            SqlParameter[] parameters ={ 
                new SqlParameter("@objname",SqlDbType.NVarChar)
            };
            parameters[0].Value = storeProcedureName;
            DataSet ds = DBUtility.SqlHelper.RunProcedure(database.ConnectionString, "sp_helptext", parameters, "ds");
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                code.Append(r[0].ToString());
            }
            return code.ToString();
        }
    }
}
