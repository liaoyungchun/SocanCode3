using System;
using System.Collections.Generic;
using System.Text;

namespace Codes
{
    public class CacheDependencyFactoryCode
    {
        public static string GetDependencyAccessCode(List<Model.Table> tables, Model.CodeStyle style)
        {
            StringBuilder code = new StringBuilder();
            code.AppendLine("using System;");
            code.AppendLine("using System.Collections.Generic;");
            code.AppendLine("using System.Text;");
            code.AppendLine("using System.Web.Caching;");
            code.AppendLine("using System.Configuration;");
            code.AppendLine("using System.Reflection;");
            code.AppendLine("using " + style.BeforeNamespaceDot + "ICacheDependency;");
            code.AppendLine("");
            code.AppendLine("namespace " + style.BeforeNamespaceDot + "CacheDependencyFactory");
            code.AppendLine("{");
            code.AppendLine("    public class DependencyAccess");
            code.AppendLine("    {");
            foreach (Model.Table table in tables)
            {
                code.AppendLine("        public static ISocansoftCacheDependency Create" + style.AfterNamespace + table.Name + "Dependency()");
                code.AppendLine("        {");
                code.AppendLine("            return LoadInstance(\"" + style.AfterNamespaceDot + table.Name + "\");");
                code.AppendLine("        }");
                code.AppendLine("");
            }
            code.AppendLine("        private static ISocansoftCacheDependency LoadInstance(string className)");
            code.AppendLine("        {");
            code.AppendLine("            string path = ConfigurationManager.AppSettings[\"CacheDependencyAssembly\"];");
            code.AppendLine("            string fullQualifiedClass = path + \".\" + className;");
            code.AppendLine("            return (ISocansoftCacheDependency)Assembly.Load(path).CreateInstance(fullQualifiedClass);");
            code.AppendLine("        }");
            code.AppendLine("    }");
            code.AppendLine("}");
            return CommonCode.GetCSharpCopyrightCode() + code.ToString();
        }

        public static string GetDependencyFacadeCode(List<Model.Table> tables, Model.CodeStyle style)
        {
            StringBuilder code = new StringBuilder();
            code.AppendLine("using System;");
            code.AppendLine("using System.Collections.Generic;");
            code.AppendLine("using System.Text;");
            code.AppendLine("using System.Configuration;");
            code.AppendLine("using System.Web.Caching;");
            code.AppendLine("");

            code.AppendLine("namespace " + style.BeforeNamespaceDot + "CacheDependencyFactory");
            code.AppendLine("{");
            code.AppendLine("    public class DependencyFacade");
            code.AppendLine("    {");
            code.AppendLine("        private static readonly string path = ConfigurationManager.AppSettings[\"CacheDependencyAssembly\"];");
            foreach (Model.Table table in tables)
            {
                code.AppendLine("");
                code.AppendLine("        public static AggregateCacheDependency Get" + style.AfterNamespace + table.Name + "CacheDependency()");
                code.AppendLine("        {");
                code.AppendLine("            if (!string.IsNullOrEmpty(path))");
                code.AppendLine("                return DependencyAccess.Create" + style.AfterNamespace + table.Name + "Dependency().GetDependency();");
                code.AppendLine("            else");
                code.AppendLine("                return null;");
                code.AppendLine("        }");
            }
            code.AppendLine("    }");
            code.AppendLine("}");
            code.AppendLine("");
            code.AppendLine("");
            return CommonCode.GetCSharpCopyrightCode() + code.ToString();
        }
    }
}
