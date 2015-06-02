using System;
using System.Collections.Generic;
using System.Text;
using CodeUtility;

namespace Codes
{
    public partial class DALFactoryCode
    {
        /// <summary>
        /// 创建反射工厂类
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public static string GetDALFactoryCode(List<Model.Table> lstTables, Model.CodeStyle style)
        {
            StringBuilder code = new StringBuilder(CommonCode.GetCSharpCopyrightCode());
            code.AppendLine("using System;");
            code.AppendLine("using System.Configuration;");
            code.AppendLine("using System.Collections.Generic;");
            code.AppendLine("using System.Text;");
            code.AppendLine("using System.Reflection;");
            code.AppendLine("using " + style.BeforeNamespaceDot + "IDAL" + style.DotAfterNamespace + ";");
            code.AppendLine("");
            code.AppendLine("namespace DALFactory");
            code.AppendLine("{");
            code.AppendLine("    public class DataAccess");
            code.AppendLine("    {");
            code.AppendLine("        private static readonly string path = ConfigurationManager.AppSettings[\"WebDAL\"];");
            foreach (Model.Table table in lstTables)
            {
                code.AppendLine("");
                code.AppendLine("        public static I" + table.Name + " Create" + style.AfterNamespace + table.Name + "()");
                code.AppendLine("        {");
                code.AppendLine("            string className = path + \"." + style.AfterNamespaceDot + table.Name + "\";");
                code.AppendLine("            return (I" + table.Name + ")Assembly.Load(path).CreateInstance(className);");
                code.AppendLine("        }");
            }
            code.AppendLine("    }");
            code.AppendLine("}");

            return code.ToString();
        }
    }
}
