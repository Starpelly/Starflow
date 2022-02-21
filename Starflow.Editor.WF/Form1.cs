using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

namespace Starflow.Editor.WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string file = @"C:\Dev\Starflow\Sandbox\TestBehaviour.cs";
            var tab = new TabPage(System.IO.Path.GetFileName(file));
            var editor = new TextEditorControl();
            editor.Dock = System.Windows.Forms.DockStyle.Fill;
            tab.Controls.Add(editor);
            mainTabs.Controls.Add(tab);
            editor.LoadFile(file);

			editor.Document.FoldingManager.FoldingStrategy = new RegionFoldingStrategy();
			editor.Document.FoldingManager.UpdateFoldings(null, null);
		}
    }

	/// <summary>
	/// The class to generate the foldings, it implements ICSharpCode.TextEditor.Document.IFoldingStrategy
	/// </summary>
	public class RegionFoldingStrategy : IFoldingStrategy
	{
		/// <summary>
		/// Generates the foldings for our document.
		/// </summary>
		/// <param name="document">The current document.</param>
		/// <param name="fileName">The filename of the document.</param>
		/// <param name="parseInformation">Extra parse information, not used in this sample.</param>
		/// <returns>A list of FoldMarkers.</returns>
		public List<FoldMarker> GenerateFoldMarkers(IDocument document, string fileName, object parseInformation)
		{
			List<FoldMarker> list = new List<FoldMarker>();

			Stack<int> startLines = new Stack<int>();

			// Create foldmarkers for the whole document, enumerate through every line.
			for (int i = 0; i < document.TotalNumberOfLines; i++)
			{
				var seg = document.GetLineSegment(i);
				int offs, end = document.TextLength;
				char c;
				for (offs = seg.Offset; offs < end && ((c = document.GetCharAt(offs)) == ' ' || c == '\t'); offs++)
				{ }
				if (offs == end)
					break;
				int spaceCount = offs - seg.Offset;

				// now offs points to the first non-whitespace char on the line
				if (document.GetCharAt(offs) == '#')
				{
					string text = document.GetText(offs, seg.Length - spaceCount);
					if (text.StartsWith("#region"))
						startLines.Push(i);
					if (text.StartsWith("#endregion") && startLines.Count > 0)
					{
						// Add a new FoldMarker to the list.
						int start = startLines.Pop();
						list.Add(new FoldMarker(document, start,
							document.GetLineSegment(start).Length,
							i, spaceCount + "#endregion".Length));
					}
				}
			}

			return list;
		}
	}
}
