using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SocanCode
{
    public partial class FormHtmlToJs : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public FormHtmlToJs()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            string str = txtHtml.Text;
            str = str.Replace("\"", "\\\"");
            str = str.Replace("\'", "\\\'");
            str = str.Replace("\\", "\\\\");

            txtJavascript.Text = "<script type=\"text/javascript\">\r\n\tdocument.write('" + str + "');\r\n</script>";
        }
    }
}