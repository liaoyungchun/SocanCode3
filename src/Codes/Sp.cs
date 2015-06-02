using System;
using System.Collections.Generic;
using System.Text;

namespace Codes
{
    public class Sp
    {
        /// <summary>
        /// �����洢����
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static string GetSpCode(Model.Table table)
        {
            bool hasIdentityField;
            Model.Field keyField = CodeUtility.CodeHelper.GetKeyField(table, out hasIdentityField);

            StringBuilder code = new StringBuilder();

            #region ����һ����¼
            code.AppendLine("if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_" + table.Name + "_Add]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)");
            code.AppendLine("drop procedure [dbo].[sp_" + table.Name + "_Add]");
            code.AppendLine("GO");
            code.Append(CommonCode.GetSQLCopyrightCode("����һ����¼"));
            code.AppendLine("CREATE PROCEDURE sp_" + table.Name + "_Add");

            foreach (Model.Field field in table.Fields)
            {
                if (!field.IsIdentifier && string.IsNullOrEmpty(field.DefaultValue))
                {
                    if (DBUtility.SqlHelper.IsCharClassType(field))
                    {
                        code.Append("    @" + field.FieldName + " " + field.SQLTypeString + "(" + field.FieldLength.ToString() + ")");
                    }
                    else
                    {
                        code.Append("    @" + field.FieldName + " " + field.SQLTypeString);
                    }

                    code.Append(",\r\n");
                }
            }
            code.Remove(code.ToString().LastIndexOf(","), 1);

            code.AppendLine("AS");
            code.AppendLine("");
            code.AppendLine("INSERT INTO [" + table.Name + "](");

            foreach (Model.Field field in table.Fields)
            {
                if (!field.IsIdentifier && (field == keyField || string.IsNullOrEmpty(field.DefaultValue)))
                {
                    code.AppendLine("    [" + field.FieldName + "],");
                }
            }
            code.Remove(code.ToString().LastIndexOf(","), 1);

            code.AppendLine(")VALUES(");

            foreach (Model.Field field in table.Fields)
            {
                if (!field.IsIdentifier && (field == keyField || string.IsNullOrEmpty(field.DefaultValue)))
                {
                    code.AppendLine("    @" + field.FieldName + ",");
                }
            }
            code.Remove(code.ToString().LastIndexOf(","), 1);

            code.AppendLine(")");

            code.AppendLine("GO");
            #endregion

            code.AppendLine("");

            #region �޸�һ����¼
            code.AppendLine("if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_" + table.Name + "_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)");
            code.AppendLine("drop procedure [dbo].[sp_" + table.Name + "_Update]");
            code.AppendLine("GO");
            code.Append(CommonCode.GetSQLCopyrightCode("�޸�һ����¼"));
            code.AppendLine("CREATE PROCEDURE [sp_" + table.Name + "_Update]");

            foreach (Model.Field field in table.Fields)
            {
                if (DBUtility.SqlHelper.IsCharClassType(field))
                {
                    code.AppendLine("    @" + field.FieldName + " " + field.SQLTypeString + "(" + field.FieldLength.ToString() + "),");
                }
                else
                {
                    code.AppendLine("    @" + field.FieldName + " " + field.SQLTypeString + ",");
                }
            }
            code.Remove(code.ToString().LastIndexOf(","), 1);

            code.AppendLine("AS");
            code.AppendLine("");
            code.AppendLine("UPDATE [" + table.Name + "]");
            code.AppendLine("SET");

            foreach (Model.Field field in table.Fields)
            {
                if (field != keyField)
                {
                    code.AppendLine("    [" + field.FieldName + "]=@" + field.FieldName + ",");
                }
            }
            code.Remove(code.ToString().LastIndexOf(","), 1);

            code.AppendLine("WHERE");
            code.AppendLine("    [" + keyField.FieldName + "]=@" + keyField.FieldName);
            code.AppendLine("");
            code.AppendLine("GO");
            #endregion

            code.AppendLine("");

            #region ɾ��һ����¼
            code.AppendLine("if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_" + table.Name + "_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)");
            code.AppendLine("drop procedure [dbo].[sp_" + table.Name + "_Delete]");
            code.AppendLine("GO");
            code.Append(CommonCode.GetSQLCopyrightCode("ɾ��һ����¼"));
            code.AppendLine("CREATE PROCEDURE sp_" + table.Name + "_Delete");
            if (DBUtility.SqlHelper.IsCharClassType(keyField))
            {
                code.AppendLine("    @" + keyField.FieldName + " " + keyField.SQLTypeString + "(" + keyField.FieldLength.ToString() + ")");
            }
            else
            {
                code.AppendLine("    @" + keyField.FieldName + " " + keyField.SQLTypeString);
            }
            code.AppendLine("AS");
            code.AppendLine("");
            code.AppendLine("DELETE " + table.Name);
            code.AppendLine("WHERE ");
            code.AppendLine("    [" + keyField.FieldName + "] = @" + keyField.FieldName);
            code.AppendLine("");
            code.AppendLine("GO");
            #endregion

            code.AppendLine("");

            if (hasIdentityField)
            {
                #region �õ����ID
                code.AppendLine("if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_" + table.Name + "_GetMaxId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)");
                code.AppendLine("drop procedure [dbo].[sp_" + table.Name + "_GetMaxId]");
                code.AppendLine("GO");
                code.Append(CommonCode.GetSQLCopyrightCode("�õ����ID"));
                code.AppendLine("CREATE PROCEDURE sp_" + table.Name + "_GetMaxId");
                code.AppendLine("AS");
                code.AppendLine("");
                code.AppendLine("DECLARE @TempID int");
                code.AppendLine("SELECT @TempID = max([" + keyField.FieldName + "]) FROM " + table.Name);
                code.AppendLine("IF @TempID IS NULL");
                code.AppendLine("    RETURN 0");
                code.AppendLine("ELSE");
                code.AppendLine("    RETURN @TempID");
                code.AppendLine("");
                code.AppendLine("GO");
                #endregion

                code.AppendLine("");
            }

            #region �Ƿ��Ѿ�����
            code.AppendLine("if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_" + table.Name + "_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)");
            code.AppendLine("drop procedure [dbo].[sp_" + table.Name + "_Exists]");
            code.AppendLine("GO");
            code.Append(CommonCode.GetSQLCopyrightCode("�Ƿ��Ѿ�����"));
            code.AppendLine("CREATE PROCEDURE sp_" + table.Name + "_Exists");
            if (DBUtility.SqlHelper.IsCharClassType(keyField))
            {
                code.AppendLine("    @" + keyField.FieldName + " " + keyField.SQLTypeString + "(" + keyField.FieldLength.ToString() + ")");
            }
            else
            {
                code.AppendLine("    @" + keyField.FieldName + " " + keyField.SQLTypeString);
            }
            code.AppendLine("AS");
            code.AppendLine("");
            code.AppendLine("DECLARE @TempID int");
            code.AppendLine("SELECT @TempID = count(1) FROM " + table.Name + " WHERE [" + keyField.FieldName + "] = @" + keyField.FieldName + "");
            code.AppendLine("IF @TempID = 0");
            code.AppendLine("    RETURN 0");
            code.AppendLine("ELSE");
            code.AppendLine("    RETURN 1");
            code.AppendLine("");
            code.AppendLine("GO");
            #endregion

            code.AppendLine("");

            #region �õ�һ��ʵ��
            code.AppendLine("if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_" + table.Name + "_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)");
            code.AppendLine("drop procedure [dbo].[sp_" + table.Name + "_GetModel]");
            code.AppendLine("GO");
            code.AppendLine(CommonCode.GetSQLCopyrightCode("�õ�һ��ʵ��"));
            code.AppendLine("CREATE PROCEDURE sp_" + table.Name + "_GetModel");
            if (DBUtility.SqlHelper.IsCharClassType(keyField))
            {
                code.AppendLine("    @" + keyField.FieldName + " " + keyField.SQLTypeString + "(" + keyField.FieldLength.ToString() + ")");
            }
            else
            {
                code.AppendLine("    @" + keyField.FieldName + " " + keyField.SQLTypeString);
            }
            code.AppendLine("AS");
            code.AppendLine("");

            code.AppendLine("SELECT");
            foreach (Model.Field field in table.Fields)
            {
                code.AppendLine("    " + field.FieldName + ",");
            }
            code.Remove(code.ToString().LastIndexOf(","), 1);
            code.AppendLine("FROM");
            code.AppendLine("    " + table.Name);
            code.AppendLine("WHERE");
            code.AppendLine("    [" + keyField.FieldName + "] = @" + keyField.FieldName + "");

            code.AppendLine("");
            code.AppendLine("GO");
            #endregion

            code.AppendLine("");

            #region �õ�����ʵ��
            code.AppendLine("if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_" + table.Name + "_GetAllList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)");
            code.AppendLine("drop procedure [dbo].[sp_" + table.Name + "_GetAllList]");
            code.AppendLine("GO");
            code.AppendLine(CommonCode.GetSQLCopyrightCode("�õ�����ʵ��"));
            code.AppendLine("CREATE PROCEDURE sp_" + table.Name + "_GetAllList");
            code.AppendLine("AS");
            code.AppendLine("");

            code.AppendLine("SELECT");
            foreach (Model.Field field in table.Fields)
            {
                code.AppendLine("    " + field.FieldName + ",");
            }
            code.Remove(code.ToString().LastIndexOf(","), 1);
            code.AppendLine("FROM");
            code.AppendLine("    " + table.Name);

            code.AppendLine("");
            code.AppendLine("GO");
            #endregion

            return code.ToString();
        }
    }
}
