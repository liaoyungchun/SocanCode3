using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Codes
{
    public class ICacheDependencyCode
    {
        public static string GetICacheDependencyCode(Model.CodeStyle style)
        {
            return CommonCode.GetCSharpCopyrightCode() + CodeUtility.CodeHelper.ReadFromTemplate(System.Windows.Forms.Application.StartupPath + "\\ICacheDependency\\ICacheDependency.template", null, null, null, style);
        }
    }
}
