using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Codes
{
    public class TableCacheDependencyCode
    {
        public static string GetTableCacheDependencyCode(string dbName, Model.Table table, Model.CodeStyle style)
        {
            return CommonCode.GetCSharpCopyrightCode() + CodeUtility.CodeHelper.ReadFromTemplate(System.Windows.Forms.Application.StartupPath + "\\TableCacheDependency\\TableCacheDependency.template", dbName, table, null, style);
        }

        public static string GetTableDependencyCode(string dbName, Model.CodeStyle style)
        {
            return CommonCode.GetCSharpCopyrightCode() + CodeUtility.CodeHelper.ReadFromTemplate(System.Windows.Forms.Application.StartupPath + "\\TableCacheDependency\\TableDependency.template", dbName, null, null, style);
        }
    }
}
