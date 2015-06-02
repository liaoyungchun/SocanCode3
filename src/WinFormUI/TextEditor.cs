using System;
using System.Collections.Generic;
using System.Text;
using ICSharpCode.TextEditor.Document;

namespace SocanCode
{
    public class TextEditor
    {
        /// <summary>
        /// �����ı�����ʽ
        /// </summary>
        /// <param name="textbox">�ı�������</param>
        /// <param name="language">����:"ASP3/XHTML","BAT","Boo","Coco","C++.NET","C#","HTML",
        /// "Java","JavaScript","PHP","TeX","VBNET","XML","TSQL"</param>
        public static void SetStyle(ICSharpCode.TextEditor.TextEditorControl textbox, string language)
        {
            textbox.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy(language);
            textbox.Encoding = System.Text.Encoding.Default;
        }
    }
}
