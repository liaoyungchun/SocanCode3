using System;
using System.Collections.Generic;
using System.Text;
using CodeUtility;

namespace Codes
{
    public partial class DALCode
    {
        /// <summary>
        /// 生成DAL数据层
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public static string GetDALCode(Model.Database.DatabaseType type, Model.Table table, Model.CodeStyle style)
        {
            List<Model.Field> fields = table.Fields;
            bool hasIdentifierRow;
            Model.Field keyRow = CodeUtility.CodeHelper.GetKeyField(table, out hasIdentifierRow);

            StringBuilder code = new StringBuilder(CommonCode.GetCSharpCopyrightCode());
            code.AppendLine("using System;");
            code.AppendLine("using System.Data;");
            code.AppendLine("using System.Text;");
            code.AppendLine("using " + Model.Database.GetUsing(type) + ";");


            if (style.CodeFrame == Model.CodeStyle.CodeFrames.Factory)
                code.AppendLine("using " + style.BeforeNamespaceDot + "IDAL" + style.DotAfterNamespace + ";");

            code.AppendLine("using System.Collections;");
            code.AppendLine("using System.Collections.Generic;");
            code.AppendLine("");

            code.AppendLine("namespace " + style.BeforeNamespaceDot + Model.Database.GetDALNamespace(type) + style.DotAfterNamespace);

            code.AppendLine("{");
            code.AppendLine("    /// <summary>");
            code.AppendLine("    /// 数据访问类 " + table.Name);
            code.AppendLine("    /// </summary>");

            if (style.CodeFrame == Model.CodeStyle.CodeFrames.Factory)
                code.AppendLine("    public class " + table.Name + " : I" + table.Name);
            else
                code.AppendLine("    public class " + table.Name);

            code.AppendLine("    {");
            code.AppendLine("        public " + table.Name + "()");
            code.AppendLine("        { }");
            code.AppendLine("");

            code.AppendLine("        #region  成员方法");

            #region 增加一条数据
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 增加一条数据");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        public int Add(" + CodeHelper.GetModelClass(table, style) + " model)");
            code.AppendLine("        {");

            //没有标识列的情况下，要手动得到主键的值
            if (!hasIdentifierRow)
            {
                if (DBUtility.SqlHelper.IsIntClassType(keyRow))
                    code.AppendLine("            model." + keyRow.FieldName + " = GetMaxId() + 1;");
                if (keyRow.FieldType == Model.DataType.uniqueidentifierType)
                    code.AppendLine("            model." + keyRow.FieldName + " = Guid.NewGuid();");
            }

            switch (style.DALFrame)
            {
                case Model.CodeStyle.DALFrames.SQL:
                    code.AppendLine("            StringBuilder strSql = new StringBuilder();");
                    code.AppendLine("            strSql.Append(\"insert into " + table.Name + "(\");");
                    code.Append("            strSql.Append(\"");
                    foreach (Model.Field field in fields)
                    {
                        //把非标识且无默认值的字段排成如下格式：Id,Name,Value
                        if (!field.IsIdentifier && (field == keyRow || string.IsNullOrEmpty(field.DefaultValue)))
                            code.Append(field.FieldName + ",");
                    }
                    code.Remove(code.Length - 1, 1); //删除最后一个逗号
                    code.Append(")\");\n");
                    code.AppendLine("            strSql.Append(\" values (\");");
                    code.Append("            strSql.Append(\"");
                    foreach (Model.Field model in fields)
                    {
                        //把非标识且无默认值的字段排成如下格式：@Id,@Name,@Value
                        if (!model.IsIdentifier && (model == keyRow || string.IsNullOrEmpty(model.DefaultValue)))
                            code.Append("@" + model.FieldName + ",");
                    }
                    code.Remove(code.Length - 1, 1);
                    code.Append(")\");\n");
                    break;
                case Model.CodeStyle.DALFrames.SP:
                    code.AppendLine("            int rowsAffected;");
                    break;
                default:
                    break;
            }

            code.AppendLine("            " + Model.Database.GetParameterType(type) + "[] parameters = {");

            foreach (Model.Field field in fields)
            {
                if (!field.IsIdentifier && (field == keyRow || string.IsNullOrEmpty(field.DefaultValue)))
                {
                    if (!DBUtility.SqlHelper.IsCharClassType(field))
                    {
                        code.AppendLine("                    new " + Model.Database.GetParameterType(type) + "(\"@" + field.FieldName + "\", " + CodeUtility.TypeConverter.DataTypeToSQLTypeString(field.FieldType, field.FieldSize) + "),");
                    }
                    else
                    {
                        code.AppendLine("                    new " + Model.Database.GetParameterType(type) + "(\"@" + field.FieldName + "\", " + CodeUtility.TypeConverter.DataTypeToSQLTypeString(field.FieldType, field.FieldSize) + "," + field.FieldLength + "),");
                    }
                }
            }
            code.Remove(code.Length - 3, 1); //删除最后一个逗号
            code.AppendLine("            };");

            int i = 0;
            foreach (Model.Field field in fields)
            {
                if (!field.IsIdentifier && (field == keyRow || string.IsNullOrEmpty(field.DefaultValue)))
                {
                    if (field.AllowNull)
                    {
                        if (field.FieldType == Model.DataType.uniqueidentifierType && string.IsNullOrEmpty(field.DefaultValue))
                        {
                            code.AppendLine("");
                            code.AppendLine("            if (model." + field.FieldName + " != Guid.Empty)");
                            code.AppendLine("                parameters[" + i.ToString() + "].Value = model." + field.FieldName + ";");
                            code.AppendLine("            else");
                            code.AppendLine("                parameters[" + i.ToString() + "].Value = DBNull.Value;");
                            code.AppendLine("");
                        }
                        else if (DBUtility.SqlHelper.IsDataTimeClassType(field))
                        {
                            code.AppendLine("");
                            code.AppendLine("            if (model." + field.FieldName + " != DateTime.MinValue)");
                            code.AppendLine("                parameters[" + i.ToString() + "].Value = model." + field.FieldName + ";");
                            code.AppendLine("            else");
                            code.AppendLine("                parameters[" + i.ToString() + "].Value = DBNull.Value;");
                            code.AppendLine("");
                        }
                        else if (DBUtility.SqlHelper.IsStringClassType(field))
                        {
                            code.AppendLine("");
                            code.AppendLine("            if (model." + field.FieldName + " != null)");
                            code.AppendLine("                parameters[" + i.ToString() + "].Value = model." + field.FieldName + ";");
                            code.AppendLine("            else");
                            code.AppendLine("                parameters[" + i.ToString() + "].Value = DBNull.Value;");
                            code.AppendLine("");
                        }
                        else
                            code.AppendLine("            parameters[" + i.ToString() + "].Value = model." + field.FieldName + ";");
                    }
                    else
                        code.AppendLine("            parameters[" + i.ToString() + "].Value = model." + field.FieldName + ";");
                    i++;
                }
            }

            switch (style.DALFrame)
            {
                case Model.CodeStyle.DALFrames.SQL:
                    code.AppendLine("            return " + Model.Database.GetHelperClass(type) + ".ExecuteSql(" + style.ConnVariable + ", strSql.ToString(), parameters);");
                    break;
                case Model.CodeStyle.DALFrames.SP:
                    code.AppendLine("            " + Model.Database.GetHelperClass(type) + ".RunProcedure(" + style.ConnVariable + ", \"sp_" + table.Name + "_Add\", parameters, out rowsAffected);");
                    code.AppendLine("");
                    code.AppendLine("            return rowsAffected > 0;");
                    break;
                default:
                    break;
            }
            code.AppendLine("        }");
            #endregion

            code.AppendLine("");

            #region 更新一条数据
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 更新一条数据");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        public bool Update(" + CodeHelper.GetModelClass(table, style) + " model)");
            code.AppendLine("        {");

            switch (style.DALFrame)
            {
                case Model.CodeStyle.DALFrames.SQL:
                    code.AppendLine("            StringBuilder strSql = new StringBuilder();");
                    code.AppendLine("            strSql.Append(\"update " + table.Name + " set \");");
                    foreach (Model.Field model in fields)
                    {
                        if (model != keyRow)
                            code.AppendLine("            strSql.Append(\"" + model.FieldName + "=@" + model.FieldName + ",\");");
                    }
                    code.Remove(code.Length - 6, 1);

                    code.AppendLine("            strSql.Append(\" where " + keyRow.FieldName + "=@" + keyRow.FieldName + "\");");
                    break;
                case Model.CodeStyle.DALFrames.SP:
                    code.AppendLine("            int rowsAffected;");
                    break;
                default:
                    break;
            }

            code.AppendLine("            " + Model.Database.GetParameterType(type) + "[] parameters = {");
            foreach (Model.Field field in fields)
            {
                //不是标识列的放在前面
                if (!field.IsIdentifier)
                {
                    if (!DBUtility.SqlHelper.IsCharClassType(field))
                    {
                        code.AppendLine("                    new " + Model.Database.GetParameterType(type) + "(\"@" + field.FieldName + "\", " + CodeUtility.TypeConverter.DataTypeToSQLTypeString(field.FieldType, field.FieldSize) + "),");
                    }
                    else
                    {
                        code.AppendLine("                    new " + Model.Database.GetParameterType(type) + "(\"@" + field.FieldName + "\", " + CodeUtility.TypeConverter.DataTypeToSQLTypeString(field.FieldType, field.FieldSize) + "," + field.FieldLength + "),");
                    }
                }
            }
            foreach (Model.Field field in fields)
            {
                //标识列放在后面
                if (field.IsIdentifier)
                {
                    if (!DBUtility.SqlHelper.IsCharClassType(field))
                    {
                        code.AppendLine("                    new " + Model.Database.GetParameterType(type) + "(\"@" + field.FieldName + "\", " + CodeUtility.TypeConverter.DataTypeToSQLTypeString(field.FieldType, field.FieldSize) + "),");
                    }
                    else
                    {
                        code.AppendLine("                    new " + Model.Database.GetParameterType(type) + "(\"@" + field.FieldName + "\", " + CodeUtility.TypeConverter.DataTypeToSQLTypeString(field.FieldType, field.FieldSize) + "," + field.FieldLength + "),");
                    }
                }
            }
            code.Remove(code.Length - 3, 1); //删除最后一个逗号，并把换行取消
            code.AppendLine("            };");

            i = 0;
            foreach (Model.Field model in fields)
            {
                //不是标识列放在前面
                if (!model.IsIdentifier)
                {
                    if (model.AllowNull && string.IsNullOrEmpty(model.DefaultValue))
                    {
                        if (model.FieldType == Model.DataType.uniqueidentifierType)
                        {
                            code.AppendLine("");
                            code.AppendLine("            if (model." + model.FieldName + " != Guid.Empty)");
                            code.AppendLine("                parameters[" + i.ToString() + "].Value = model." + model.FieldName + ";");
                            code.AppendLine("            else");
                            code.AppendLine("                parameters[" + i.ToString() + "].Value = DBNull.Value;");
                            code.AppendLine("");
                        }
                        else if (model.FieldType == Model.DataType.datetimeType || model.FieldType == Model.DataType.smalldatetimeType)
                        {
                            code.AppendLine("");
                            code.AppendLine("            if (model." + model.FieldName + " != DateTime.MinValue)");
                            code.AppendLine("                parameters[" + i.ToString() + "].Value = model." + model.FieldName + ";");
                            code.AppendLine("            else");
                            code.AppendLine("                parameters[" + i.ToString() + "].Value = DBNull.Value;");
                            code.AppendLine("");
                        }
                        else if (model.FieldType == Model.DataType.charType || model.FieldType == Model.DataType.ncharType || model.FieldType == Model.DataType.ntextType || model.FieldType == Model.DataType.nvarcharType || model.FieldType == Model.DataType.textType || model.FieldType == Model.DataType.varcharType)
                        {
                            code.AppendLine("");
                            code.AppendLine("            if (model." + model.FieldName + " != null)");
                            code.AppendLine("                parameters[" + i.ToString() + "].Value = model." + model.FieldName + ";");
                            code.AppendLine("            else");
                            code.AppendLine("                parameters[" + i.ToString() + "].Value = DBNull.Value;");
                            code.AppendLine("");
                        }
                        else
                            code.AppendLine("            parameters[" + i.ToString() + "].Value = model." + model.FieldName + ";");
                    }
                    else
                        code.AppendLine("            parameters[" + i.ToString() + "].Value = model." + model.FieldName + ";");
                    i++;
                }
            }
            foreach (Model.Field model in fields)
            {
                //标识列放在后面
                if (model.IsIdentifier)
                {
                    if (model.AllowNull && string.IsNullOrEmpty(model.DefaultValue))
                    {
                        if (model.FieldType == Model.DataType.uniqueidentifierType)
                        {
                            code.AppendLine("");
                            code.AppendLine("            if (model." + model.FieldName + " != Guid.Empty)");
                            code.AppendLine("                parameters[" + i.ToString() + "].Value = model." + model.FieldName + ";");
                            code.AppendLine("            else");
                            code.AppendLine("                parameters[" + i.ToString() + "].Value = DBNull.Value;");
                            code.AppendLine("");
                        }
                        else if (model.FieldType == Model.DataType.datetimeType || model.FieldType == Model.DataType.smalldatetimeType)
                        {
                            code.AppendLine("");
                            code.AppendLine("            if (model." + model.FieldName + " != DateTime.MinValue)");
                            code.AppendLine("                parameters[" + i.ToString() + "].Value = model." + model.FieldName + ";");
                            code.AppendLine("            else");
                            code.AppendLine("                parameters[" + i.ToString() + "].Value = DBNull.Value;");
                            code.AppendLine("");
                        }
                        else if (model.FieldType == Model.DataType.charType || model.FieldType == Model.DataType.ncharType || model.FieldType == Model.DataType.ntextType || model.FieldType == Model.DataType.nvarcharType || model.FieldType == Model.DataType.textType || model.FieldType == Model.DataType.varcharType)
                        {
                            code.AppendLine("");
                            code.AppendLine("            if (model." + model.FieldName + " != null)");
                            code.AppendLine("                parameters[" + i.ToString() + "].Value = model." + model.FieldName + ";");
                            code.AppendLine("            else");
                            code.AppendLine("                parameters[" + i.ToString() + "].Value = DBNull.Value;");
                            code.AppendLine("");
                        }
                        else
                            code.AppendLine("            parameters[" + i.ToString() + "].Value = model." + model.FieldName + ";");
                    }
                    else
                        code.AppendLine("            parameters[" + i.ToString() + "].Value = model." + model.FieldName + ";");
                    i++;
                }
            }
            code.AppendLine("");

            switch (style.DALFrame)
            {
                case Model.CodeStyle.DALFrames.SQL:
                    code.AppendLine("            return " + Model.Database.GetHelperClass(type) + ".ExecuteSql(" + style.ConnVariable + ", strSql.ToString(), parameters) > 0;");
                    break;
                case Model.CodeStyle.DALFrames.SP:
                    code.AppendLine("            " + Model.Database.GetHelperClass(type) + ".RunProcedure(" + style.ConnVariable + ", \"sp_" + table.Name + "_Update\", parameters, out rowsAffected);");
                    code.AppendLine("            return rowsAffected > 0;");
                    break;
                default:
                    break;
            }
            code.AppendLine("        }");
            #endregion

            code.AppendLine("");

            #region 删除一条数据
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 删除一条数据");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        public bool Delete(" + CodeUtility.TypeConverter.DataTypeToCSharpTypeString(keyRow.FieldType) + " " + keyRow.FieldName + ")");
            code.AppendLine("        {");
            switch (style.DALFrame)
            {
                case Model.CodeStyle.DALFrames.SQL:
                    code.AppendLine("            StringBuilder strSql = new StringBuilder();");
                    code.AppendLine("            strSql.Append(\"delete " + table.Name + " \");");
                    code.AppendLine("            strSql.Append(\" where " + keyRow.FieldName + "=@" + keyRow.FieldName + "\");");
                    break;
                case Model.CodeStyle.DALFrames.SP:
                    code.AppendLine("            int rowsAffected;");
                    break;
                default:
                    break;
            }

            code.AppendLine("            " + Model.Database.GetParameterType(type) + "[] parameters = {");
            if (!DBUtility.SqlHelper.IsCharClassType(keyRow))
            {
                code.AppendLine("                    new " + Model.Database.GetParameterType(type) + "(\"@" + keyRow.FieldName + "\", " + CodeUtility.TypeConverter.DataTypeToSQLTypeString(keyRow.FieldType, keyRow.FieldSize) + ")};");
            }
            else
            {
                code.AppendLine("                    new " + Model.Database.GetParameterType(type) + "(\"@" + keyRow.FieldName + "\", " + CodeUtility.TypeConverter.DataTypeToSQLTypeString(keyRow.FieldType, keyRow.FieldSize) + "," + keyRow.FieldLength + ")};");
            }
            code.AppendLine("            parameters[0].Value = " + keyRow.FieldName + ";");
            code.AppendLine("");

            switch (style.DALFrame)
            {
                case Model.CodeStyle.DALFrames.SQL:
                    code.AppendLine("            return " + Model.Database.GetHelperClass(type) + ".ExecuteSql(" + style.ConnVariable + ", strSql.ToString(), parameters) > 0;");
                    break;
                case Model.CodeStyle.DALFrames.SP:
                    code.AppendLine("            " + Model.Database.GetHelperClass(type) + ".RunProcedure(" + style.ConnVariable + ", \"sp_" + table.Name + "_Delete\", parameters, out rowsAffected);");
                    code.AppendLine("            return rowsAffected > 0;");
                    break;
                default:
                    break;
            }
            code.AppendLine("        }");
            #endregion

            code.AppendLine("");

            if (DBUtility.SqlHelper.IsIntClassType(keyRow))
            {
                #region 得到最大ID
                code.AppendLine("        /// <summary>");
                code.AppendLine("        /// 得到最大ID");
                code.AppendLine("        /// </summary>");
                code.AppendLine("        public int GetMaxId()");
                code.AppendLine("        {");
                switch (style.DALFrame)
                {
                    case Model.CodeStyle.DALFrames.SQL:
                        code.AppendLine("            return " + Model.Database.GetHelperClass(type) + ".GetMaxID(" + style.ConnVariable + ", \"" + keyRow.FieldName + "\", \"" + table.Name + "\");");
                        break;
                    case Model.CodeStyle.DALFrames.SP:
                        code.AppendLine("            int rowsAffected;");
                        code.AppendLine("            " + Model.Database.GetParameterType(type) + "[] parameters ={ };");
                        code.AppendLine("            return " + Model.Database.GetHelperClass(type) + ".RunProcedure(" + style.ConnVariable + ", \"sp_" + table.Name + "_GetMaxId\", parameters, out rowsAffected);");
                        break;
                    default:
                        break;
                }
                code.AppendLine("        }");
                #endregion
                code.AppendLine("");
            }

            #region 是否存在该记录
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 是否存在该记录");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        public bool Exists(" + CodeUtility.TypeConverter.DataTypeToCSharpTypeString(keyRow.FieldType) + " " + keyRow.FieldName + ")");
            code.AppendLine("        {");
            switch (style.DALFrame)
            {
                case Model.CodeStyle.DALFrames.SQL:
                    code.AppendLine("            StringBuilder strSql = new StringBuilder();");
                    code.AppendLine("            strSql.Append(\"select count(1) from " + table.Name + "\");");
                    code.AppendLine("            strSql.Append(\" where " + keyRow.FieldName + "= @" + keyRow.FieldName + "\");");
                    break;
                case Model.CodeStyle.DALFrames.SP:
                    code.AppendLine("            int rowsAffected;");
                    break;
                default:
                    break;
            }
            code.AppendLine("            " + Model.Database.GetParameterType(type) + "[] parameters = {");
            if (!DBUtility.SqlHelper.IsCharClassType(keyRow))
            {
                code.AppendLine("                    new " + Model.Database.GetParameterType(type) + "(\"@" + keyRow.FieldName + "\", " + CodeUtility.TypeConverter.DataTypeToSQLTypeString(keyRow.FieldType, keyRow.FieldSize) + ")};");
            }
            else
            {
                code.AppendLine("                    new " + Model.Database.GetParameterType(type) + "(\"@" + keyRow.FieldName + "\", " + CodeUtility.TypeConverter.DataTypeToSQLTypeString(keyRow.FieldType, keyRow.FieldSize) + "," + keyRow.FieldLength + ")};");
            }
            code.AppendLine("            parameters[0].Value = " + keyRow.FieldName + ";");
            switch (style.DALFrame)
            {
                case Model.CodeStyle.DALFrames.SQL:
                    code.AppendLine("            return " + Model.Database.GetHelperClass(type) + ".Exists(" + style.ConnVariable + ", strSql.ToString(), parameters);");
                    break;
                case Model.CodeStyle.DALFrames.SP:
                    code.AppendLine("            return " + Model.Database.GetHelperClass(type) + ".RunProcedure(" + style.ConnVariable + ", \"sp_" + table.Name + "_Exists\", parameters, out rowsAffected) == 1;");
                    break;
                default:
                    break;
            }
            code.AppendLine("        }");
            #endregion

            code.AppendLine("");

            #region 得到一个对象实体
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 得到一个对象实体");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        public " + CodeHelper.GetModelClass(table, style) + " GetModel(" + CodeUtility.TypeConverter.DataTypeToCSharpTypeString(keyRow.FieldType) + " " + keyRow.FieldName + ")");
            code.AppendLine("        {");
            if (style.DALFrame == Model.CodeStyle.DALFrames.SQL)
            {
                code.AppendLine("            StringBuilder strSql = new StringBuilder();");
                code.AppendLine("            strSql.Append(\"select * from " + table.Name + " \");");
                code.AppendLine("            strSql.Append(\" where " + keyRow.FieldName + "=@" + keyRow.FieldName + "\");");
            }

            code.AppendLine("            " + Model.Database.GetParameterType(type) + "[] parameters = {");
            if (!DBUtility.SqlHelper.IsCharClassType(keyRow))
            {
                code.AppendLine("                    new " + Model.Database.GetParameterType(type) + "(\"@" + keyRow.FieldName + "\", " + CodeUtility.TypeConverter.DataTypeToSQLTypeString(keyRow.FieldType, keyRow.FieldSize) + ")};");
            }
            else
            {
                code.AppendLine("                    new " + Model.Database.GetParameterType(type) + "(\"@" + keyRow.FieldName + "\", " + CodeUtility.TypeConverter.DataTypeToSQLTypeString(keyRow.FieldType, keyRow.FieldSize) + "," + keyRow.FieldLength + ")};");
            }
            code.AppendLine("            parameters[0].Value = " + keyRow.FieldName + ";");

            switch (style.DALFrame)
            {
                case Model.CodeStyle.DALFrames.SQL:
                    code.AppendLine("            DataSet ds = " + Model.Database.GetHelperClass(type) + ".Query(" + style.ConnVariable + ", strSql.ToString(), parameters);");
                    break;
                case Model.CodeStyle.DALFrames.SP:
                    code.AppendLine("            DataSet ds = " + Model.Database.GetHelperClass(type) + ".RunProcedure(" + style.ConnVariable + ", \"sp_" + table.Name + "_GetModel\", parameters, \"ds\");");
                    break;
                default:
                    break;
            }
            code.AppendLine("            if (ds.Tables[0].Rows.Count > 0)");
            code.AppendLine("            {");
            code.AppendLine("                DataRow r = ds.Tables[0].Rows[0];");
            code.AppendLine("                return GetModel(r);");
            code.AppendLine("            }");
            code.AppendLine("            else");
            code.AppendLine("            {");
            code.AppendLine("                return null;");
            code.AppendLine("            }");
            code.AppendLine("        }");
            #endregion

            code.AppendLine("");

            switch (style.DALFrame)
            {
                case Model.CodeStyle.DALFrames.SQL:
                    #region Sql获取泛型数据列表
                    code.AppendLine("        /// <summary>");
                    code.AppendLine("        /// 获取泛型数据列表");
                    code.AppendLine("        /// </summary>");
                    code.AppendLine("        public List<" + CodeHelper.GetModelClass(table, style) + "> GetList()");
                    code.AppendLine("        {");
                    code.AppendLine("            StringBuilder strSql = new StringBuilder(\"select * from " + table.Name + "\");");
                    code.AppendLine("            DataSet ds = " + Model.Database.GetHelperClass(type) + ".Query(" + style.ConnVariable + ", strSql.ToString());");

                    code.AppendLine("            return GetList(ds);");
                    code.AppendLine("        }");
                    #endregion

                    code.AppendLine("");
                    break;
                case Model.CodeStyle.DALFrames.SP:
                    #region 存储过程获取泛型数据列表
                    code.AppendLine("        /// <summary>");
                    code.AppendLine("        /// 获取泛型数据列表");
                    code.AppendLine("        /// </summary>");
                    code.AppendLine("        public List<" + CodeHelper.GetModelClass(table, style) + "> GetList()");
                    code.AppendLine("        {");
                    code.AppendLine("            " + Model.Database.GetParameterType(type) + "[] parameters ={ };");
                    code.AppendLine("            DataSet ds = " + Model.Database.GetHelperClass(type) + ".RunProcedure(" + style.ConnVariable + ", \"sp_" + table.Name + "_GetAllList\", parameters, \"ds\");");
                    code.AppendLine("            return GetList(ds);");
                    code.AppendLine("        }");
                    #endregion

                    code.AppendLine("");
                    break;
                default:
                    break;
            }

            #region 分页获取泛型数据列表
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 分页获取泛型数据列表");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        public List<" + CodeHelper.GetModelClass(table, style) + "> GetList(int pageSize, int pageIndex, string fldSort, bool sort, string strCondition, out int count)");
            code.AppendLine("        {");
            code.AppendLine("            DataSet ds = " + Model.Database.GetHelperClass(type) + ".PageList(" + style.ConnVariable + ", \"" + table.Name + "\", pageSize, pageIndex, fldSort, sort, strCondition, out count);");
            code.AppendLine("            return GetList(ds);");
            code.AppendLine("        }");
            #endregion

            code.AppendLine("        #endregion");
            code.AppendLine("");

            #region 由一行数据得到一个实体
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 由一行数据得到一个实体");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        private " + CodeHelper.GetModelClass(table, style) + " GetModel(DataRow r)");
            code.AppendLine("        {");
            code.AppendLine("            " + CodeHelper.GetModelClass(table, style) + " model = new " + CodeHelper.GetModelClass(table, style) + "();");
            foreach (Model.Field model in fields)
            {
                code.AppendLine("            model." + model.FieldName + " = DBUtility.ObjectHelper." + CodeUtility.TypeConverter.DataTypeToCSharpMethod(model.FieldType) + "(r[\"" + model.FieldName + "\"]);");
            }
            code.AppendLine("            return model;");
            code.AppendLine("        }");
            #endregion

            code.AppendLine("");

            #region 由数据集得到泛型数据列表
            code.AppendLine("        /// <summary>");
            code.AppendLine("        /// 由数据集得到泛型数据列表");
            code.AppendLine("        /// </summary>");
            code.AppendLine("        private List<" + CodeHelper.GetModelClass(table, style) + "> GetList(DataSet ds)");
            code.AppendLine("        {");
            code.AppendLine("            List<" + CodeHelper.GetModelClass(table, style) + "> l = new List<" + CodeHelper.GetModelClass(table, style) + ">();");
            code.AppendLine("            foreach (DataRow r in ds.Tables[0].Rows)");
            code.AppendLine("            {");
            code.AppendLine("                l.Add(GetModel(r));");
            code.AppendLine("            }");
            code.AppendLine("            return l;");
            code.AppendLine("        }");
            #endregion

            code.AppendLine("    }");
            code.AppendLine("}");

            return code.ToString();
        }

        public static string GetDALConfigCode(Model.Database.DatabaseType type, Model.CodeStyle style)
        {
            StringBuilder code = new StringBuilder();
            code.AppendLine("using System;");
            code.AppendLine("using System.Collections.Generic;");
            code.AppendLine("using System.Text;");
            code.AppendLine("using System.Configuration;");
            code.AppendLine();
            code.AppendLine("namespace " + style.BeforeNamespaceDot + Model.Database.GetDALNamespace(type) + style.DotAfterNamespace);
            code.AppendLine("{");
            code.AppendLine("    public class Config");
            code.AppendLine("    {");
            code.AppendLine("        public static string Connection = ConfigurationManager.ConnectionStrings[\"ConnectionString\"].ConnectionString;");
            code.AppendLine("    }");
            code.AppendLine("}");
            return code.ToString();
        }
    }
}
