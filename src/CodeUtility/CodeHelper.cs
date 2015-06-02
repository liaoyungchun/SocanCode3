using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace CodeUtility
{
    public class CodeHelper
    {
        #region 读写文件
        public static void WriteUTF8File(string path, string content)
        {
            StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8);
            sw.Write(content);
            sw.Close();
        }

        public static void WriteFile(string path, string content)
        {
            StreamWriter sw = new StreamWriter(path, false, Encoding.Default);
            sw.Write(content);
            sw.Close();
        }

        public static string ReadFile(string path)
        {
            StreamReader sr = new StreamReader(path);
            string str = sr.ReadToEnd();
            sr.Close();
            return str;
        }
        #endregion

        /// <summary>
        /// 运行命令行
        /// </summary>
        /// <param name="cmd"></param>
        public static void RunCommand(string cmd)
        {
            string tempPath = Environment.GetEnvironmentVariable("TEMP");
            string fileName = tempPath + "\\" + Guid.NewGuid().ToString("N") + ".bat";
            CodeUtility.CodeHelper.WriteFile(fileName, cmd.ToString());
            Process.Start(fileName);
        }

        public static string ReadFromTemplate(string file, string dbName, Model.Table table, Model.Field IdentifierRow, Model.CodeStyle style)
        {
            string code = ReadFile(file);
            if (dbName != null)
            {
                code = code.Replace("$DBName$", dbName);
            }
            if (table != null)
            {
                code = code.Replace("$TableName$", table.Name);
            }
            if (IdentifierRow != null)
            {
                code = code.Replace("$IdType$", TypeConverter.DataTypeToCSharpTypeString(IdentifierRow.FieldType));
                code = code.Replace("$IdName$", IdentifierRow.FieldName);
                code = code.Replace("$NullValue$", GetNullValueString(IdentifierRow));
            }
            if (style != null)
            {
                code = code.Replace("$BeforeNamespaceDot$", style.BeforeNamespaceDot);
                code = code.Replace("$BeforeNamespace$", style.BeforeNamespace);
                code = code.Replace("$DotAfterNamespace$", style.DotAfterNamespace);
                code = code.Replace("$AfterNamespace$", style.AfterNamespace);
            }
            return code;
        }

        public static string GetNullValueString(Model.Field field)
        {
            if (DBUtility.SqlHelper.IsIntClassType(field))
                return "0";
            else if (DBUtility.SqlHelper.IsDataTimeClassType(field))
                return "DateTime.MinValue";
            else if (field.FieldType == Model.DataType.uniqueidentifierType)
                return "Guid.Empty";
            else
                return "null";
        }

        /// <summary>
        /// 取得主键
        /// </summary>
        public static Model.Field GetKeyField(Model.Table table, out bool HasIdentifierField)
        {
            List<Model.Field> l = table.Fields;
            Model.Field IdentifierRow = null;
            HasIdentifierField = false;
            foreach (Model.Field model in l)
            {
                if (model.IsIdentifier)
                {
                    IdentifierRow = model;
                    HasIdentifierField = true;
                    break;
                }
            }
            if (IdentifierRow == null)
            {
                foreach (Model.Field model in l)
                {
                    if (model.IsKeyField)
                    {
                        IdentifierRow = model;
                        break;
                    }
                }
            }
            if (IdentifierRow == null)
            {
                IdentifierRow = l[0];
            }
            return IdentifierRow;
        }

        /// <summary>
        /// 得到“BeforeNamespace.Model.AfterNamespace.TableName”字符串
        /// </summary>
        /// <param name="table"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public static string GetModelClass(Model.Table table, Model.CodeStyle style)
        {
            return style.BeforeNamespaceDot + "Model" + style.DotAfterNamespace + "." + table.Name;
        }
    }
}
