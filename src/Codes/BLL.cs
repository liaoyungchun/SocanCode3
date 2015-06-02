using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CodeUtility;

namespace Codes
{
    public partial class BLLCode
    {
        /// <summary>
        /// 生成BLL业务逻辑层
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public static string GetBLLCode(Model.Database.DatabaseType dbType, Model.Table table, Model.CodeStyle style)
        {
            List<Model.Field> l = table.Fields;
            bool HasIdentifierRow;
            Model.Field IdentifierRow = CodeHelper.GetKeyField(table, out HasIdentifierRow);

            StringBuilder code = new StringBuilder(CommonCode.GetCSharpCopyrightCode());
            code.AppendLine("using System;");
            code.AppendLine("using System.Data;");

            if (style.CodeFrame == Model.CodeStyle.CodeFrames.Factory)
            {
                code.AppendLine("using DALFactory;");
            }

            code.AppendLine("using " + style.BeforeNamespaceDot + "Model" + style.DotAfterNamespace + ";");

            code.AppendLine("using System.Collections.Generic;");
            code.AppendLine("using System.Text;");
            code.AppendLine("using System.Web;");
            code.AppendLine("using System.Web.Caching;");
            code.AppendLine("");
            code.AppendLine("namespace " + style.BeforeNamespaceDot + "BLL" + style.DotAfterNamespace);
            code.AppendLine("{");
            code.AppendLine("    /// <summary>");
            code.AppendLine("    /// 业务逻辑类 " + table.Name);
            code.AppendLine("    /// </summary>");
            if (style.CacheFrame == Model.CodeStyle.CacheFrames.None)
                code.AppendLine("    public class " + table.Name);
            else
                code.AppendLine("    public class " + table.Name + " : RemoveCaches");

            code.AppendLine("    {");

            if (style.CodeFrame == Model.CodeStyle.CodeFrames.Factory)
                code.AppendLine("        private readonly " + style.BeforeNamespaceDot + "IDAL" + style.DotAfterNamespace + "." + "I" + table.Name + " dal = DataAccess.Create" + style.DotAfterNamespace.Replace(".", "") + table.Name + "();");
            else
            {
                if (dbType == Model.Database.DatabaseType.Access)
                {
                    code.AppendLine("        private readonly " + style.BeforeNamespaceDot + "AccessDAL" + style.DotAfterNamespace + "." + table.Name + " dal = new " + style.BeforeNamespaceDot + "AccessDAL" + style.DotAfterNamespace + "." + table.Name + "();");
                }
                else
                {
                    code.AppendLine("        private readonly " + style.BeforeNamespaceDot + "SQLServerDAL" + style.DotAfterNamespace + "." + table.Name + " dal = new " + style.BeforeNamespaceDot + "SQLServerDAL" + style.DotAfterNamespace + "." + table.Name + "();");
                }
            }

            code.AppendLine("        public " + table.Name + "()");
            if (style.CacheFrame != Model.CodeStyle.CacheFrames.None)
                code.AppendLine("            : base(\"" + style.AfterNamespaceLine + table.Name + "_\")");

            code.AppendLine("        { }");
            code.AppendLine("");

            switch (style.CacheFrame)
            {
                case Model.CodeStyle.CacheFrames.None:
                    code.Append(CodeUtility.CodeHelper.ReadFromTemplate(System.Windows.Forms.Application.StartupPath + "\\BLL\\None.template", null, table, IdentifierRow, style));
                    break;
                case Model.CodeStyle.CacheFrames.Cache:
                    code.Append(CodeUtility.CodeHelper.ReadFromTemplate(System.Windows.Forms.Application.StartupPath + "\\BLL\\Cache.template", null, table, IdentifierRow, style));
                    break;
                case Model.CodeStyle.CacheFrames.AggregateDependency:
                    code.Append(CodeUtility.CodeHelper.ReadFromTemplate(System.Windows.Forms.Application.StartupPath + "\\BLL\\AggregateDependency.template", null, table, IdentifierRow, style));
                    break;
                default:
                    break;
            }
            code.AppendLine("    }");
            code.AppendLine("}");

            return code.ToString();
        }

        /// <summary>
        /// Caches.cs文件的代码
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public static string GetCachesCode(Model.CodeStyle style)
        {
            return CodeHelper.ReadFromTemplate(System.Windows.Forms.Application.StartupPath + "\\BLL\\Caches.template", null, null, null, style);
        }
    }
}
