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

using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

using Newtonsoft.Json;

namespace Starflow.Editor
{
    public partial class EditorWindow : Form
    {
		public Scene currentEditorScene;
		public static EditorWindow Instance;

		public EditorWindow()
        {
			InitializeComponent();
			Instance = this;

			Scene debugScene = JsonConvert.DeserializeObject<Scene>(File.ReadAllText(EditorProperties.ProjectLocation + @"\TestScene.starflow"));
			currentEditorScene = debugScene;

			for (int i = 0; i < debugScene.gameObjects.Count; i++)
            {
				hierarchyTree.Nodes.Add(debugScene.gameObjects[i].name);
            }

            string fileStr = $@"{EditorProperties.ProjectLocation}\TestBehaviour.cs";
            var tab = new TabPage(System.IO.Path.GetFileName(fileStr));
            var editor = new TextEditorControl();
            editor.Dock = System.Windows.Forms.DockStyle.Fill;
            tab.Controls.Add(editor);
            mainTabs.Controls.Add(tab);
            editor.LoadFile(fileStr);

			editor.Document.FoldingManager.FoldingStrategy = new RegionFoldingStrategy();
			editor.Document.FoldingManager.UpdateFoldings(null, null);

			TreeNode spritesNode = assetTree.Nodes.Add("Sprites");
			TreeNode scriptsNode = assetTree.Nodes.Add("Scripts");
			TreeNode soundsNode = assetTree.Nodes.Add("Sounds");
			TreeNode fontsNode = assetTree.Nodes.Add("Fonts");
			TreeNode scenesNode = assetTree.Nodes.Add("Scenes");

			string[] files = Directory.GetFiles(EditorProperties.ProjectLocation, "*", SearchOption.AllDirectories);
			foreach (var file in files)
			{
				var relative = GetRelativePath(EditorProperties.ProjectLocation, file).Replace("\\", "/");

				bool cont = false;
				for (int i = 0; i < EditorProperties.ExcludeFiles.Length; i++)
				{
					if (relative.Contains(EditorProperties.ExcludeFiles[i]))
					{
						cont = true;
					}
				}
				if (cont) continue;

				string fileName = Path.GetFileName(file);
				switch (Path.GetExtension(file))
                {
					case ".cs":
					case ".json":
					case ".txt":
						TreeNode scriptNode = new TreeNode(fileName);
						scriptNode.ImageIndex = 1;
						scriptsNode.Nodes.Add(scriptNode);
						break;
					case ".png":
					case ".jpg":
					case ".bmp":
						TreeNode spriteNode = new TreeNode(fileName);
						spritesNode.Nodes.Add(spriteNode);
						break;
					case ".starflow":
						scenesNode.Nodes.Add(new TreeNode(fileName));
						break;
					case ".ogg":
					case ".mp3":
					case ".wav":
						soundsNode.Nodes.Add(new TreeNode(fileName));
						break;
					case ".ttf":
					case ".otf":
						fontsNode.Nodes.Add(new TreeNode(fileName));
						break;
                }
			}
		}

		private string GetRelativePath(string relativeTo, string path)
		{
			if (!relativeTo.EndsWith(Path.DirectorySeparatorChar.ToString()))
				relativeTo += Path.DirectorySeparatorChar;
			return path.Replace(relativeTo, "");
		}

        #region Events
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Application.Exit();
        }
        #endregion
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
