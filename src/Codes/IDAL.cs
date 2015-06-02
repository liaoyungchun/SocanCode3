using System;
using System.Collections.Generic;
using System.Text;
using CodeUtility;

namespace Codes
{
    public partial class IDALCode
    {
        /// <summary>
        /// ����IDAL�ӿڲ����
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public static string GetIDALCode(Model.Table table, Model.CodeStyle style)
        {
            List<Model.Field> l = table.Fields;
            bool HasIdentifierRow;
            Model.Field IdentifierRow = CodeHelper.GetKeyField(table, out HasIdentifierRow);

            StringBuilder code = new StringBuilder(CommonCode.GetCSharpCopyrightCode());
            code.AppendLine("using System;");
            code.AppendLine("using System.Data;");
            code.AppendLine("using System.Collections;");
            code.AppendLine("using System.Collections.Generic;");
            code.AppendLine("");
            code.AppendLine("namespace " + style.BeforeNamespaceDot + "IDAL" + style.DotAfterNamespace);
            code.AppendLine("{");
            code.AppendLine("    /// <summary>");
            code.AppendLine("    /// �ӿڲ� I" + table.Name + "");
            code.AppendLine("    /// </summary>");
            code.AppendLine("    public interface I" + table.Name + "");
            code.AppendLine("    {");
            code.AppendLine("        #region  ��Ա����");

            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// ����һ������");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        int Add(" + CodeHelper.GetModelClass(table, style) + " model);");
            code.AppendLine("");

            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// ����һ������");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        bool Update(" + CodeHelper.GetModelClass(table, style) + " model);");
            code.AppendLine("");

            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// ɾ��һ������");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        bool Delete(" + CodeUtility.TypeConverter.DataTypeToCSharpTypeString(IdentifierRow.FieldType) + " " + IdentifierRow.FieldName + ");");
            code.AppendLine("");

            if (IdentifierRow.FieldType == Model.DataType.intType || IdentifierRow.FieldType == Model.DataType.bigintType || IdentifierRow.FieldType == Model.DataType.smallintType || IdentifierRow.FieldType == Model.DataType.tinyintType)
            {
                code.AppendLine("        /// <summary>");
                code.AppendLine("        /// �õ����ID");
                code.AppendLine("        ///</summary>");
                code.AppendLine("        int GetMaxId();");
                code.AppendLine("");
            }

            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// �Ƿ���ڸü�¼");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        bool Exists(" + CodeUtility.TypeConverter.DataTypeToCSharpTypeString(IdentifierRow.FieldType) + " " + IdentifierRow.FieldName + ");");
            code.AppendLine("");

            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// �õ�һ������ʵ��");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        " + CodeHelper.GetModelClass(table, style) + " GetModel(" + CodeUtility.TypeConverter.DataTypeToCSharpTypeString(IdentifierRow.FieldType) + " " + IdentifierRow.FieldName + ");");
            code.AppendLine("");

            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// ��ȡ���������б�");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        List<" + CodeHelper.GetModelClass(table, style) + "> GetList();");
            code.AppendLine("");

            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// ��ҳ��ȡ���������б�");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        List<" + CodeHelper.GetModelClass(table, style) + "> GetList(int pageSize, int pageIndex, string fldSort, bool sort, string strCondition, out int counts);");

            code.AppendLine("        #endregion");
            code.AppendLine("    }");
            code.AppendLine("}");

            return code.ToString();
        }
    }
}
