using System;
using System.Collections.Generic;
using System.Text;

namespace Codes
{
    public class CommonCode
    {
        /// <summary>
        /// C#版权信息
        /// </summary>
        /// <returns></returns>
        public static string GetCSharpCopyrightCode()
        {
            StringBuilder code = new StringBuilder();
            code.AppendLine("//------------------------------------------------------------------------------");
            code.AppendLine("// 创建标识: Copyright (C) " + DateTime.Today.Year + " Socansoft.com 版权所有");
            code.AppendLine("// 创建描述: SocanCode代码生成器自动创建于 " + DateTime.Now.ToString());
            code.AppendLine("//");
            code.AppendLine("// 功能描述: ");
            code.AppendLine("//");
            code.AppendLine("// 修改标识: ");
            code.AppendLine("// 修改描述: ");
            code.AppendLine("//------------------------------------------------------------------------------");
            code.AppendLine("");
            return code.ToString();
        }

        /// <summary>
        /// Html版权信息
        /// </summary>
        /// <returns></returns>
        public static string GetHtmlCopyrightCode()
        {
            StringBuilder code = new StringBuilder();
            code.AppendLine("<%-------------------------------------------------------------------------------");
            code.AppendLine(" 创建标识: Copyright (C) " + DateTime.Today.Year + " Socansoft.com 版权所有");
            code.AppendLine(" 创建描述: SocanCode代码生成器自动创建于 " + DateTime.Now.ToString());
            code.AppendLine("");
            code.AppendLine(" 功能描述: ");
            code.AppendLine("");
            code.AppendLine(" 修改标识: ");
            code.AppendLine(" 修改描述: ");
            code.AppendLine("--------------------------------------------------------------------------------%>");
            code.AppendLine("");
            return code.ToString();
        }

        /// <summary>
        /// SQL版权信息
        /// </summary>
        /// <param name="table">表</param>
        /// <param name="function">功能描述</param>
        /// <returns></returns>
        public static string GetSQLCopyrightCode(string function)
        {
            StringBuilder code = new StringBuilder();
            code.AppendLine("-----------------------------------------------");
            code.AppendLine("--Copyright (C) " + DateTime.Today.Year + " Socansoft.com 版权所有");
            code.AppendLine("--说明：" + function);
            code.AppendLine("--时间：" + DateTime.Now.ToString());
            code.AppendLine("-----------------------------------------------");
            return code.ToString();
        }
    }
}
