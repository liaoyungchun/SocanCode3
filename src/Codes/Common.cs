using System;
using System.Collections.Generic;
using System.Text;

namespace Codes
{
    public class CommonCode
    {
        /// <summary>
        /// C#��Ȩ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static string GetCSharpCopyrightCode()
        {
            StringBuilder code = new StringBuilder();
            code.AppendLine("//------------------------------------------------------------------------------");
            code.AppendLine("// ������ʶ: Copyright (C) " + DateTime.Today.Year + " Socansoft.com ��Ȩ����");
            code.AppendLine("// ��������: SocanCode�����������Զ������� " + DateTime.Now.ToString());
            code.AppendLine("//");
            code.AppendLine("// ��������: ");
            code.AppendLine("//");
            code.AppendLine("// �޸ı�ʶ: ");
            code.AppendLine("// �޸�����: ");
            code.AppendLine("//------------------------------------------------------------------------------");
            code.AppendLine("");
            return code.ToString();
        }

        /// <summary>
        /// Html��Ȩ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static string GetHtmlCopyrightCode()
        {
            StringBuilder code = new StringBuilder();
            code.AppendLine("<%-------------------------------------------------------------------------------");
            code.AppendLine(" ������ʶ: Copyright (C) " + DateTime.Today.Year + " Socansoft.com ��Ȩ����");
            code.AppendLine(" ��������: SocanCode�����������Զ������� " + DateTime.Now.ToString());
            code.AppendLine("");
            code.AppendLine(" ��������: ");
            code.AppendLine("");
            code.AppendLine(" �޸ı�ʶ: ");
            code.AppendLine(" �޸�����: ");
            code.AppendLine("--------------------------------------------------------------------------------%>");
            code.AppendLine("");
            return code.ToString();
        }

        /// <summary>
        /// SQL��Ȩ��Ϣ
        /// </summary>
        /// <param name="table">��</param>
        /// <param name="function">��������</param>
        /// <returns></returns>
        public static string GetSQLCopyrightCode(string function)
        {
            StringBuilder code = new StringBuilder();
            code.AppendLine("-----------------------------------------------");
            code.AppendLine("--Copyright (C) " + DateTime.Today.Year + " Socansoft.com ��Ȩ����");
            code.AppendLine("--˵����" + function);
            code.AppendLine("--ʱ�䣺" + DateTime.Now.ToString());
            code.AppendLine("-----------------------------------------------");
            return code.ToString();
        }
    }
}
