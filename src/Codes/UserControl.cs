using System;
using System.Collections.Generic;
using System.Text;
using CodeUtility;

namespace Codes
{
    public partial class UserControlCode
    {
        /// <summary>
        /// 生成Web用户控件后台代码
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public static string GetWebUserControlCsCode(Model.Table table, Model.CodeStyle style)
        {
            List<Model.Field> l = table.Fields;
            bool HasIdentifierRow;
            Model.Field IdentifierRow = CodeHelper.GetKeyField(table, out HasIdentifierRow);

            StringBuilder code = new StringBuilder(CommonCode.GetCSharpCopyrightCode());
            code.AppendLine("using System;");
            code.AppendLine("using System.Data;");
            code.AppendLine("using System.Configuration;");
            code.AppendLine("using System.Collections;");
            code.AppendLine("using System.Web;");
            code.AppendLine("using System.Web.Security;");
            code.AppendLine("using System.Web.UI;");
            code.AppendLine("using System.Web.UI.WebControls;");
            code.AppendLine("using System.Web.UI.WebControls.WebParts;");
            code.AppendLine("using System.Web.UI.HtmlControls;");
            code.AppendLine("using System.Collections.Generic;");
            code.AppendLine("");
            code.AppendLine("public partial class Controls_" + style.DotAfterNamespace.Replace(".", "") + table.Name + "ListControl : System.Web.UI.UserControl");
            code.AppendLine("{");
            code.AppendLine("    public event RepeaterCommandEventHandler ItemCommand;");
            code.AppendLine("    public List<" + CodeUtility.TypeConverter.DataTypeToCSharpTypeString(IdentifierRow.FieldType) + "> Selected");
            code.AppendLine("    {");
            code.AppendLine("        get");
            code.AppendLine("        {");
            code.AppendLine("            List<" + CodeUtility.TypeConverter.DataTypeToCSharpTypeString(IdentifierRow.FieldType) + "> l = new List<" + CodeUtility.TypeConverter.DataTypeToCSharpTypeString(IdentifierRow.FieldType) + ">();");
            code.AppendLine("            foreach (RepeaterItem item in rpt" + table.Name + ".Items)");
            code.AppendLine("            {");
            code.AppendLine("                CheckBox cb = item.FindControl(\"chkChoose\") as CheckBox;");
            code.AppendLine("                if (cb != null && cb.Checked)");
            code.AppendLine("                {");
            code.AppendLine("                    HiddenField fld = item.FindControl(\"hf" + table.Name + "\") as HiddenField;");
            code.AppendLine("                    if (fld != null)");
            code.AppendLine("                    {");

            if (IdentifierRow.FieldType == Model.DataType.uniqueidentifierType)
                code.AppendLine("                        Guid id = new Guid(fld.Value);");
            else if (IdentifierRow.FieldType == Model.DataType.bigintType || IdentifierRow.FieldType == Model.DataType.intType || IdentifierRow.FieldType == Model.DataType.smallintType || IdentifierRow.FieldType == Model.DataType.tinyintType)
                code.AppendLine("                        int id = Convert.ToInt32(fld.Value);");
            else
                code.AppendLine("                        string id = fld.Value;");

            code.AppendLine("                        l.Add(id);");
            code.AppendLine("                    }");
            code.AppendLine("                }");
            code.AppendLine("            }");
            code.AppendLine("            return l;");
            code.AppendLine("        }");
            code.AppendLine("    }");
            code.AppendLine("");

            code.AppendLine("    protected void Page_Load(object sender, EventArgs e)");
            code.AppendLine("    {");
            code.AppendLine("    }");
            code.AppendLine("");

            code.AppendLine("    public void Bind(List<" + CodeHelper.GetModelClass(table, style) + "> l)");
            code.AppendLine("    {");
            code.AppendLine("        rpt" + table.Name + ".DataSource = l;");
            code.AppendLine("        rpt" + table.Name + ".DataBind();");
            code.AppendLine("    }");
            code.AppendLine("");

            code.AppendLine("    protected void rpt" + table.Name + "_ItemCommand(object source, RepeaterCommandEventArgs e)");
            code.AppendLine("    {");
            code.AppendLine("        if (ItemCommand != null)");
            code.AppendLine("            ItemCommand(source, e);");
            code.AppendLine("    }");
            code.AppendLine("}");

            return code.ToString();
        }

        /// <summary>
        /// 生成Web用户控件
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public static string GetUserControlCode(Model.Table table, Model.CodeStyle style)
        {
            List<Model.Field> l = table.Fields;
            bool HasIdentifierRow;
            Model.Field IdentifierRow = CodeHelper.GetKeyField(table, out HasIdentifierRow);

            StringBuilder code = new StringBuilder(CommonCode.GetHtmlCopyrightCode());
            code.AppendLine("<%@ Control Language=\"C#\" AutoEventWireup=\"true\" CodeFile=\"" + style.DotAfterNamespace.Replace(".", "") + table.Name + "ListControl.ascx.cs\"");
            code.AppendLine("    Inherits=\"Controls_" + style.DotAfterNamespace.Replace(".", "") + table.Name + "ListControl\" %>");
            code.AppendLine("<asp:Repeater ID=\"rpt" + table.Name + "\" runat=\"server\" OnItemCommand=\"rpt" + table.Name + "_ItemCommand\">");
            code.AppendLine("    <HeaderTemplate>");
            code.AppendLine("        <table id=\"" + table.Name + "List\" style=\"width: 100%;\">");
            code.AppendLine("            <tr>");
            int i = 0;
            foreach (Model.Field r in l)
            {
                if (r != IdentifierRow)
                {
                    if (i < l.Count - 1)
                        code.AppendLine("                <td style=\"text-align: left;\">");
                    else
                        code.AppendLine("                <td style=\"text-align: right;\">");

                    if (i == 0)
                        code.AppendLine("                    <input id=\"chkChooseAll" + table.Name + "\" type=\"checkbox\" onclick=\"ChooseAll('" + table.Name + "List','chkChooseAll" + table.Name + "')\" />");
                    code.AppendLine("                    " + r.FieldDescn + "");
                    code.AppendLine("                </td>");
                    i++;
                }
            }
            code.AppendLine("            </tr>");
            code.AppendLine("    </HeaderTemplate>");
            code.AppendLine("    <ItemTemplate>");
            code.AppendLine("        <tr onmouseover=\"Fuscous(this)\" onmouseout=\"Undertone(this)\">");
            i = 0;
            foreach (Model.Field r in l)
            {
                if (r != IdentifierRow)
                {
                    if (i < l.Count - 1)
                        code.AppendLine("            <td style=\"text-align: left;\">");
                    else
                        code.AppendLine("            <td style=\"text-align: right;\">");

                    if (i == 0)
                    {
                        code.AppendLine("                <asp:CheckBox ID=\"chkChoose\" runat=\"server\" /><asp:HiddenField ID=\"hf" + table.Name + "\"");
                        code.AppendLine("                    runat=\"server\" Value='<%# Eval(\"" + IdentifierRow.FieldName + "\") %>' />");
                    }
                    code.AppendLine("                <%# Eval(\"" + r.FieldName + "\") %>");
                    code.AppendLine("            </td>");
                    i++;
                }
            }
            code.AppendLine("        </tr>");
            code.AppendLine("    </ItemTemplate>");
            code.AppendLine("    <FooterTemplate>");
            code.AppendLine("        </table>");
            code.AppendLine("    </FooterTemplate>");
            code.AppendLine("</asp:Repeater>");

            return code.ToString();
        }
    }
}
