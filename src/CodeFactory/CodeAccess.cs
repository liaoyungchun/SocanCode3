using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CodeUtility;

namespace CodeFactory
{
    public class CodeAccess
    {
        public static void CreateUserControl(List<Model.Table> tables, Model.CodeStyle style, string path)
        {
            Directory.CreateDirectory(path);
            foreach (Model.Table table in tables)
            {
                string filePath = path + "\\" + style.DotAfterNamespace.Replace(".", "") + table.Name + "ListControl.ascx";
                CodeHelper.WriteUTF8File(filePath, Codes.UserControlCode.GetUserControlCode(table, style));

                string filePath1 = path + "\\" + style.DotAfterNamespace.Replace(".", "") + table.Name + "ListControl.ascx.cs";
                CodeHelper.WriteUTF8File(filePath1, Codes.UserControlCode.GetWebUserControlCsCode(table, style));
            }
        }

        public static void CreateDALFactoryFile(List<Model.Table> tables, Model.CodeStyle style, string path)
        {
            string filePath = path + "\\DataAccess.cs";
            string fileCode = Codes.DALFactoryCode.GetDALFactoryCode(tables, style);
            CodeHelper.WriteUTF8File(filePath, fileCode);
        }

        public static void CreateDALFile(Model.Database.DatabaseType dbType, List<Model.Table> tables, Model.CodeStyle style, string path)
        {
            foreach (Model.Table table in tables)
            {
                string filePath = path + "\\" + style.AfterNamespaceDot + table.Name + ".cs";
                CodeHelper.WriteUTF8File(filePath, Codes.DALCode.GetDALCode(dbType, table, style));
            }
            CodeHelper.WriteUTF8File(path + "\\" + style.AfterNamespaceDot + "Config.cs", Codes.DALCode.GetDALConfigCode(dbType, style));
        }

        public static void CreateIDALFile(List<Model.Table> tables, Model.CodeStyle style, string path)
        {
            foreach (Model.Table table in tables)
            {
                string filePath = path + "\\" + style.AfterNamespaceDot + "I" + table.Name + ".cs";
                CodeHelper.WriteUTF8File(filePath, Codes.IDALCode.GetIDALCode(table, style));
            }
        }

        public static void CreateModelFile(List<Model.Table> tables, Model.CodeStyle style, string path)
        {
            foreach (Model.Table table in tables)
            {
                string filePath = path + "\\" + style.AfterNamespaceDot + table.Name + ".cs";
                CodeHelper.WriteUTF8File(filePath, Codes.ModelCode.GetModelCode(table, style));
            }
            if (style.CacheFrame != Model.CodeStyle.CacheFrames.None)
            {
                CodeHelper.WriteUTF8File(path + "\\PageData.cs", Codes.ModelCode.GetPageDataCode(style));
            }
        }

        public static void CreateBLLFile(Model.Database.DatabaseType dbType, List<Model.Table> tables, Model.CodeStyle style, string path)
        {
            foreach (Model.Table table in tables)
            {
                List<Model.Field> l = table.Fields;
                string filePath = path + "\\" + style.AfterNamespaceDot + table.Name + ".cs";
                CodeHelper.WriteUTF8File(filePath, Codes.BLLCode.GetBLLCode(dbType, table, style));
            }
            if (style.CacheFrame != Model.CodeStyle.CacheFrames.None)
            {
                CodeHelper.WriteUTF8File(path + "\\Caches.cs", Codes.BLLCode.GetCachesCode(style));
            }
        }

        public static void CreateICacheDependencyFile(Model.CodeStyle style, string path)
        {
            CodeHelper.WriteUTF8File(path + "\\ICacheDependency.cs", Codes.ICacheDependencyCode.GetICacheDependencyCode(style));
        }

        public static void CreateTableCacheDependencyFile(string dbName, List<Model.Table> tables, Model.CodeStyle style, string path)
        {
            CodeHelper.WriteUTF8File(path + "\\TableDependency.cs", Codes.TableCacheDependencyCode.GetTableDependencyCode(dbName, style));
            foreach (Model.Table table in tables)
            {
                CodeHelper.WriteUTF8File(path + "\\" + style.AfterNamespaceDot + table.Name + ".cs", Codes.TableCacheDependencyCode.GetTableCacheDependencyCode(dbName, table, style));
            }
        }

        public static void CreateCacheDependencyFactoryFile(List<Model.Table> tables, Model.CodeStyle style, string path)
        {
            CodeHelper.WriteUTF8File(path + "\\DependencyAccess.cs", Codes.CacheDependencyFactoryCode.GetDependencyAccessCode(tables, style));
            CodeHelper.WriteUTF8File(path + "\\DependencyFacade.cs", Codes.CacheDependencyFactoryCode.GetDependencyFacadeCode(tables, style));
        }

        public static void CreateSpFile(List<Model.Table> tables, string path)
        {
            StringBuilder code = new StringBuilder();
            foreach (Model.Table table in tables)
            {
                code.Append(Codes.Sp.GetSpCode(table));
            }
            CodeHelper.WriteUTF8File(path + "\\StoreProcedures.sql", code.ToString());
        }
    }
}
