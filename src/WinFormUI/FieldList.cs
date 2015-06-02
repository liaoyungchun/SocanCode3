using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Codes;

namespace SocanCode
{
    public class FieldList
    {
        public static List<Model.Field> AllRowList;

        public static List<Model.Field> GetListByTableName(string TableName)
        {
            List<Model.Field> l = new List<Model.Field>();
            foreach (Model.Field model in AllRowList)
            {
                if (model.TableName == TableName)
                    l.Add(model);
            }
            return l;
        }

        public static List<Model.Field> GetList(DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            List<Model.Field> l = new List<Model.Field>();
            foreach (DataRow r in dt.Rows)
            {
                Model.Field model = GetField(r);
                l.Add(model);
            }
            return l;
        }

        public static List<Model.Table> GetTableList(DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            List<Model.Table> lTable = new List<Model.Table>();
            foreach (DataRow r in dt.Rows)
            {
                Model.Field model = GetField(r);
                foreach (Model.Table modelTable in lTable)
                {
                    if (model.TableName == modelTable.Fields[0].TableName)
                        modelTable.Fields.Add(model);
                    else
                    {
                        Model.Table newTable = new Model.Table();
                        newTable.Name = model.TableName;
                        newTable.Fields.Add(model);
                    }
                }
                //lTable.Add(model);
            }
            return lTable;
        }

        private static Model.Field GetField(DataRow r)
        {
            Model.Field model = new Model.Field();
            model.AllowNull = SqlHelper.GetBool(r["AllowNull"]);
            model.DecimalDigits = SqlHelper.GetInt(r["DecimalDigits"]);
            model.DefaultValue = SqlHelper.GetString(r["DefaultValue"]);
            model.FieldDescn = SqlHelper.GetString(r["FieldDescn"]);
            model.FieldLength = SqlHelper.GetInt(r["FieldLength"]);
            model.FieldName = SqlHelper.GetString(r["FieldName"]);
            model.FieldNumber = SqlHelper.GetInt(r["FieldNumber"]);
            model.FieldSize = SqlHelper.GetInt(r["FieldSize"]);
            model.FieldType = CodeHelper.GetRowDBType(r["FieldType"].ToString());
            model.IsIdentifier = SqlHelper.GetBool(r["IsIdentifier"]);
            model.IsKeyField = SqlHelper.GetBool(r["IsKeyField"]);
            model.TableName = SqlHelper.GetString(r["TableName"]);
            return model;
        }
    }
}
