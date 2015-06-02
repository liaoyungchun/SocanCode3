using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CodeUtility;

namespace Codes
{
    public partial class ModelCode
    {
        /// <summary>
        /// 生成Model实体层代码
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public static string GetModelCode(Model.Table table, Model.CodeStyle style)
        {
            List<Model.Field> l = table.Fields;

            StringBuilder code = new StringBuilder(CommonCode.GetCSharpCopyrightCode());
            code.AppendLine("using System;");
            code.AppendLine("");
            code.AppendLine("namespace " + style.BeforeNamespaceDot + "Model" + style.DotAfterNamespace);
            code.AppendLine("{");
            code.AppendLine("    /// <summary>");
            code.AppendLine("    /// 实体类 " + table.Name);
            code.AppendLine("    /// </summary>");
            code.AppendLine("    public class " + table.Name);
            code.AppendLine("    {");

            #region 空构造函数
            code.AppendLine("        public " + table.Name + "()");
            code.AppendLine("        { }");
            #endregion

            code.AppendLine();

            #region 构造函数
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// " + "构造函数 " + table.Name);
            code.AppendLine("        /// </summary>");
            foreach (Model.Field field in table.Fields)
            {
                code.AppendLine("        /// <param name=\"" + FirstLower(field.FieldName) + "\">" + field.FieldDescn + "</param>");
            }
            code.Append("        public " + table.Name + "(");
            foreach (Model.Field field in table.Fields)
            {
                code.Append(CodeUtility.TypeConverter.DataTypeToCSharpTypeString(field.FieldType) + " " + FirstLower(field.FieldName) + ", "); //参数列表
            }
            code.Remove(code.Length - 2, 2);
            code.Append(")");
            code.AppendLine();
            code.AppendLine("        {");
            foreach (Model.Field field in table.Fields)
            {
                code.AppendLine("            _" + FirstLower(field.FieldName) + " = " + FirstLower(field.FieldName) + ";"); //赋值
            }
            code.AppendLine("        }");
            #endregion

            code.AppendLine();
            code.AppendLine("        #region Model");

            foreach (Model.Field model in l)
            {
                code.AppendLine("        private " + CodeUtility.TypeConverter.DataTypeToCSharpTypeString(model.FieldType) + " _" + FirstLower(model.FieldName) + ";");
            }

            foreach (Model.Field model in l)
            {
                code.AppendLine("        /// <summary>");
                code.AppendLine("        /// " + model.FieldDescn);
                code.AppendLine("        /// </summary>");
                code.AppendLine("        public " + CodeUtility.TypeConverter.DataTypeToCSharpTypeString(model.FieldType) + " " + model.FieldName);
                code.AppendLine("        {");
                code.AppendLine("            set { _" + FirstLower(model.FieldName) + " = value; }");
                code.AppendLine("            get { return _" + FirstLower(model.FieldName) + "; }");
                code.AppendLine("        }");
            }

            code.AppendLine("        #endregion Model");
            code.AppendLine("    }");
            code.AppendLine("}");

            return code.ToString();
        }

        private static string FirstLower(string str)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(str[0].ToString().ToLower());
            sb.Append(str.Remove(0, 1));
            return sb.ToString();
        }

        public static string GetPageDataCode(Model.CodeStyle style)
        {
            return CodeHelper.ReadFromTemplate(System.Windows.Forms.Application.StartupPath + "\\Model\\PageData.template", null, null, null, style);
        }

        public static string GetModelClass(Model.Table table, Model.CodeStyle style)
        {
            return style.BeforeNamespaceDot + "Model" + style.DotAfterNamespace + "." + table.Name;
        }
    }
}
