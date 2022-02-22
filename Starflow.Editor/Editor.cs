using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Microsoft.Build.Evaluation;
using Microsoft.Extensions.Logging;
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
		public TabControl MainTabs;

		public EditorWindow()
        {
			InitializeComponent();
			Instance = this;

			MainTabs = mainTabs;

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
				}
			}
			currentEditorScene.gameObjects = gameObjects;
			var stringJson = JsonConvert.SerializeObject(currentEditorScene, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Objects });
			// File.WriteAllText(EditorProperties.ProjectLocation + @"\TestScene.starflow", stringJson);

			Init();
		}

		private void Init()
        {
			new CodeEditor().Open($@"{EditorProperties.ProjectLocation}\TestBehaviour.cs");
			new CodeEditor().Open($@"{EditorProperties.ProjectLocation}\Program.cs");

			hierarchy.Init();
		}

        #region Events
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Application.Exit();
        }
		private void playButton_Click(object sender, EventArgs e)
		{
			// who knew that it would be this easy to write viruses
			string projLoc = EditorProperties.ProjectLocation + @"\Sandbox.csproj";
			Process cmd = new Process();
			cmd.StartInfo.FileName = "cmd.exe";
			cmd.StartInfo.RedirectStandardInput = true;
			cmd.StartInfo.RedirectStandardOutput = true;
			cmd.StartInfo.CreateNoWindow = true;
			cmd.StartInfo.UseShellExecute = false;
			cmd.Start();

			cmd.StandardInput.WriteLine($"dotnet.exe build {projLoc}");
			Debug.Log(cmd.StandardOutput.ToString());
			cmd.StandardInput.WriteLine($"cd {EditorProperties.ProjectLocation}");
			cmd.StandardInput.WriteLine($"dotnet.exe run");
			cmd.StandardInput.Flush();
			cmd.StandardInput.Close();
			cmd.WaitForExit();
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// it's obviously gonna get more complex as time goes on
			CodeEditor editor = ActiveEditor;
			if (editor != null)
				editor.DoSave();
		}
		#endregion

		private void mainTabs_DrawItem(object sender, DrawItemEventArgs e)
        {
			e.Graphics.DrawString(this.mainTabs.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
			e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
			e.DrawFocusRectangle();
			
		}

		private CodeEditor ActiveEditor
		{
			get
			{
				if (MainTabs.TabPages.Count == 0) return null;
				return MainTabs.SelectedTab.Controls.OfType<CodeEditor>().FirstOrDefault();
			}
		}
	}
}
