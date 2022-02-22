using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Starflow.Editor
{
    public partial class AssetBrowser : UserControl
    {
        public AssetBrowser()
        {
            InitializeComponent();

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

        private void assetTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
			if (e.Node.Text.Contains(".cs"))
            {
				new CodeEditor().Open(EditorProperties.ProjectLocation + $@"\{e.Node.Text}");
            }
		}
    }
}
