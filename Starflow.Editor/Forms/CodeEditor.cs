using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using WPFControls;

using ICSharpCode.AvalonEdit;
namespace Starflow.Editor
{
    internal class CodeEditor
    {
        public static void Open(string path)
        {
            string fileStr = path;
            var tab = new TabPage(System.IO.Path.GetFileName(fileStr));

            var editor = new AvalonEditControl();
            var host = new ElementHost();
            host.Dock = DockStyle.Fill;
            host.Child = editor;

            editor.TextEditor.Text = File.ReadAllText(fileStr);
            editor.TextEditor.ShowLineNumbers = true;
            TextEditorOptions options = new TextEditorOptions();
            editor.TextEditor.Options = options;
            options.HighlightCurrentLine = true;
            options.EnableHyperlinks = true;

            tab.Controls.Add(host);
            EditorWindow.Instance.MainTabs.Controls.Add(tab);
        }
    }
}
