using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CodeUtility
{
    public class CommandHelper
    {
        public static string RuntimePath = RuntimeEnvironment.GetRuntimeDirectory();
        public static void EnableDatabaseForSqlCacheDependency(Model.Database model)
        {
            StringBuilder cmd = new StringBuilder();
            cmd.AppendLine("@echo off");
            cmd.AppendLine(RuntimePath + "aspnet_regsql.exe -C \"" + model.ConnectionString + "\" -ed");
            cmd.AppendLine("PAUSE");
            CodeUtility.CodeHelper.RunCommand(cmd.ToString());
        }

        public static void DisableDatabaseForSqlCacheDependency(Model.Database model)
        {
            StringBuilder cmd = new StringBuilder();
            cmd.AppendLine("@echo off");
            cmd.AppendLine(RuntimePath + "aspnet_regsql.exe -C \"" + model.ConnectionString + "\" -dd");
            cmd.AppendLine("PAUSE");
            CodeUtility.CodeHelper.RunCommand(cmd.ToString());
        }

        public static void EnableAllTablesForSqlCacheDependency(Model.Database model)
        {
            StringBuilder cmd = new StringBuilder();
            cmd.AppendLine("@echo off");
            foreach (Model.Table table in model.Tables)
            {
                cmd.AppendLine(RuntimePath + "aspnet_regsql.exe -C \"" + model.ConnectionString + "\" -t " + table.Name + " -et");
            }
            cmd.AppendLine("PAUSE");
            CodeUtility.CodeHelper.RunCommand(cmd.ToString());
        }

        public static void DisableAllTablesForSqlCacheDependency(Model.Database model)
        {
            StringBuilder cmd = new StringBuilder();
            cmd.AppendLine("@echo off");
            foreach (Model.Table table in model.Tables)
            {
                cmd.AppendLine(RuntimePath + "aspnet_regsql.exe -C \"" + model.ConnectionString + "\" -t " + table.Name + " -dt");
            }
            cmd.AppendLine("PAUSE");
            CodeUtility.CodeHelper.RunCommand(cmd.ToString());
        }

        public static void EnableTableForSqlCacheDependency(Model.Database model, Model.Table table)
        {
            StringBuilder cmd = new StringBuilder();
            cmd.AppendLine("@echo off");
            cmd.AppendLine(RuntimePath + "aspnet_regsql.exe -C \"" + model.ConnectionString + "\" -t " + table.Name + " -et");
            cmd.AppendLine("PAUSE");
            CodeUtility.CodeHelper.RunCommand(cmd.ToString());
        }

        public static void DisableTableForSqlCacheDependency(Model.Database model, Model.Table table)
        {
            StringBuilder cmd = new StringBuilder();
            cmd.AppendLine("@echo off");
            cmd.AppendLine(RuntimePath + "aspnet_regsql.exe -C \"" + model.ConnectionString + "\" -t " + table.Name + " -dt");
            cmd.AppendLine("PAUSE");
            CodeUtility.CodeHelper.RunCommand(cmd.ToString());
        }
    }
}
