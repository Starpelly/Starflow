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
using Newtonsoft.Json;
using WPFControls;

namespace Starflow.Editor
{
	// todo: Loading and saving scenes, (TYPES are not serialized)
	// some inspector code
	// general cleaning up
	// read a bible
	// parenting objects
	// proper icons and structure for the asset browser
    public partial class EditorWindow : Form
    {
		public Scene currentEditorScene;
		public static EditorWindow Instance;

		public EditorWindow()
        {
			InitializeComponent();
			Instance = this;

			// currentEditorScene = JsonConvert.DeserializeObject<Scene>(File.ReadAllText(EditorProperties.ProjectLocation + @"\TestScene.starflow"));

			currentEditorScene = new Scene();
			currentEditorScene.name = "te";
			System.Collections.Generic.List<GameObject> gameObjects = new System.Collections.Generic.List<GameObject>();
			for (int i = 0; i < 120; i++)
			{
				gameObjects.Add(new GameObject($"Test{i}"));
				if (i == 0)
				{
					gameObjects[0].AddComponent<SpriteRenderer>();
					gameObjects[0].AddComponent<Sandbox.TestBehaviour>();
				}
			}
			currentEditorScene.gameObjects = gameObjects;
			var stringJson = JsonConvert.SerializeObject(currentEditorScene, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Objects });
			// File.WriteAllText(EditorProperties.ProjectLocation + @"\TestScene.starflow", stringJson);

			for (int i = 0; i < currentEditorScene.gameObjects.Count; i++)
            {
				hierarchyTree.Nodes.Add(currentEditorScene.gameObjects[i].name);
            }

            string fileStr = $@"{EditorProperties.ProjectLocation}\TestBehaviour.cs";
            var tab = new TabPage(System.IO.Path.GetFileName(fileStr));

			var editor = new AvalonEditControl();
			var host = new ElementHost();
			host.Dock = DockStyle.Fill;
			host.Child = editor;

			editor.TextEditor.Text = File.ReadAllText(fileStr);
			editor.TextEditor.ShowLineNumbers = true;

			tab.Controls.Add(host);
			mainTabs.Controls.Add(tab);

			TreeNode animationsNode = assetTree.Nodes.Add("Animations");
			TreeNode audioNode = assetTree.Nodes.Add("Audio");
			TreeNode fontsNode = assetTree.Nodes.Add("Fonts");
			TreeNode scenesNode = assetTree.Nodes.Add("Scenes");
			TreeNode scriptsNode = assetTree.Nodes.Add("Scripts");
			TreeNode spritesNode = assetTree.Nodes.Add("Sprites");

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
						audioNode.Nodes.Add(new TreeNode(fileName));
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
}
