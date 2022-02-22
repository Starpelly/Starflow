using ICSharpCode.AvalonEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using WPFControls;

namespace Starflow.Editor
{
    public partial class CodeEditor : UserControl
    {
        public CodeEditor()
        {
            InitializeComponent();
            editor = new AvalonEditControl();
            elementHost.Child = editor;
        }

        private AvalonEditControl editor;
        public bool isModified { get; set; }
        private TabPage tab { get; set; }
        public string filePath;

        public void Open(string path)
        {
            filePath = path;
            string fileStr = path;

            tab = new TabPage(System.IO.Path.GetFileName(fileStr));

            editor.TextEditor.Text = File.ReadAllText(fileStr);
            editor.TextEditor.ShowLineNumbers = true;
            TextEditorOptions options = new TextEditorOptions();
            editor.TextEditor.Options = options;
            options.HighlightCurrentLine = true;
            options.EnableHyperlinks = true;

            editor.TextEditor.TextChanged += TextEditor_TextChanged;

            this.Dock = DockStyle.Fill;
            tab.Controls.Add(this);
            EditorWindow.Instance.MainTabs.Controls.Add(tab);
        }

        public bool DoSave()
        {
            if (string.IsNullOrEmpty(filePath))
                return DoSaveAs();
            else
            {
                try
                {
                    SaveFile();
                    SetModifiedFlag(false);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().Name);
                    return false;
                }
            }
        }

        private bool DoSaveAs()
        {
            return false;
            /*saveFileDialog.FileName = editor.FileName;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    editor.SaveFile(saveFileDialog.FileName);
                    editor.Parent.Text = Path.GetFileName(editor.FileName);
                    SetModifiedFlag(editor, false);

                    // The syntax highlighting strategy doesn't change
                    // automatically, so do it manually.
                    editor.Document.HighlightingStrategy =
                        HighlightingStrategyFactory.CreateHighlightingStrategyForFile(editor.FileName);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().Name);
                }
            }
            return false;*/
        }

        private void SaveFile()
        {
            File.WriteAllText(filePath, editor.TextEditor.Text);
        }

        private void TextEditor_TextChanged(object sender, System.EventArgs e)
        {
            SetModifiedFlag(true);
        }

        private bool IsModified()
        {
            return isModified;
        }
        private void SetModifiedFlag(bool flag)
        {
            if (IsModified() != flag)
            {
                var p = tab;
                if (IsModified())
                {
                    p.Text = p.Text.Substring(0, p.Text.Length - 1);
                    isModified = false;
                }
                else
                {
                    p.Text += "*";
                    isModified = true;
                }
            }
        }
    }
}
