using Newtonsoft.Json;
using ScintillaNET;
using StarflowEditor.Core.Data;
using StarflowEditor.Forms;
using StarflowEditor.Utils;
using System.Diagnostics;

namespace StarflowEditor
{
    public partial class MainForm : Form
    {
        public Project CurrentProject;
        private string projectPath = @"C:\Dev\Starflow\Sandbox";
        private string projectFile = "sandbox.starflow";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadProject();
        }

        public void LoadProject()
        {
            Project project = new Project();
            project.Name = "Sandbox";
            project.Folders.Add(new Project.Folder("scenes", "Scenes"));
            project.Folders.Add(new Project.Folder("scripts", "Scripts"));
            project.Folders.Add(new Project.Folder("sprites", "Sprites"));
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(project);
            File.WriteAllText($@"C:\Dev\Starflow\Sandbox\sandbox.starflow", json);


            projectPath = @"C:\Dev\Starflow\Sandbox";
            projectFile = "sandbox.starflow";
            CurrentProject = JsonConvert.DeserializeObject<Project>(File.ReadAllText($@"{projectPath}\{projectFile}"));

            ListDirectory();
            this.Text = $"Starflow Software Development Kit - {CurrentProject.Name}";
        }

        private void ListDirectory()
        {
            assetBrowser.Nodes.Clear();
            assetBrowser.ImageList = imageList;

            for (int i = 0; i < CurrentProject.Folders.Count; i++)
            {
                var folder = CurrentProject.Folders[i];
                var directoryInfo = new DirectoryInfo($@"{projectPath}\{folder.Name}");
                FileTreeNode folderNode = new FileTreeNode(folder.Name);
                imageList.Images.Add(DefaultIcons.FolderLarge);
                folderNode.ImageIndex = imageList.Images.Count - 1;
                folderNode.SelectedImageIndex = imageList.Images.Count - 1;

                // foreach (var directory in directoryInfo.GetDirectories())
                foreach (var file in directoryInfo.GetFiles())
                {
                    var node = new FileTreeNode(file.Name);
                    if (Extensions.ImageExtensions.Contains(file.Extension.ToUpperInvariant()))
                    {
                        imageList.Images.Add(Image.FromFile(file.FullName));
                    }
                    else
                    {
                        imageList.Images.Add(Icon.ExtractAssociatedIcon(file.FullName));
                    }
                    node.ImageIndex = imageList.Images.Count - 1;
                    node.SelectedImageIndex = imageList.Images.Count - 1;
                    node.realFilePath = file.FullName;
                    folderNode.Nodes.Add(node);
                }

                assetBrowser.Nodes.Add(folderNode);
            }
        }

        private void assetBrowser_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string nodeName = ((FileTreeNode)e.Node).realFilePath;
            if (nodeName == null) return;
            if (Extensions.ImageExtensions.Contains(Path.GetExtension(nodeName).ToUpperInvariant()))
            {
                Console.WriteLine("A");
                this.OpenSpriteEditor($@"{projectPath}\sprites\{Path.GetFileName(nodeName)}");
            }
            else if (Extensions.CodeExtensions.Contains(Path.GetExtension(nodeName).ToUpperInvariant()))
            {
                /*new Process
                {
                    StartInfo = new ProcessStartInfo(nodeName)
                    {
                        UseShellExecute = true
                    }
                }.Start();
                */
                OpenTab(nodeName);
            }
        }

        public void OpenTab(string file)
        {
            TabPage tab = new TabPage();
            tab.Text = Path.GetFileName(file);
            var codeEditor = new CodeEditor(file);
            codeEditor.Dock = DockStyle.Fill;
            tab.Controls.Add(codeEditor);

            TabsHolder.TabPages.Add(tab);
        }

        private void assetBrowser_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
        }

        private void playTestButton_Click(object sender, EventArgs e)
        {
            new Thread(() => RunGame()).Start();

            // game.StartingScene = TestScene();

            /*Starflow.Data.Scene dataScene = new Starflow.Data.Scene();
            dataScene.GameObjects = game.StartingScene.gameObjects;
            File.WriteAllText(projectPath + @"\scenes\" + "scene.scene", JsonConvert.SerializeObject(dataScene));*/
            // JsonConvert.DeserializeObject<Starflow.Data.Scene>(File.ReadAllText(projectPath + @"\scenes\" + "scene.scene")).ToScene();
        }

        private void RunGame()
        {
            try
            {
                var game = new Starflow.GameRuntime();
                Starflow.Data.Scene dataScene = new Starflow.Data.Scene();
                dataScene.GameObjects = TestScene().gameObjects;
                File.WriteAllText(projectPath + @"\scenes\" + "scene.scene", JsonConvert.SerializeObject(dataScene));
                var loadedScene = JsonConvert.DeserializeObject<Starflow.Data.Scene>(File.ReadAllText(projectPath + @"\scenes\" + "scene.scene")).ToScene();
                game.StartingScene = loadedScene;
                game.ApplicationTitle = $"SSDK - [{CurrentProject.Name}] (Play Test)";
                using (game)
                    game.Run();
            }
            catch (Exception ex)
            {
                if (!(ex is ThreadAbortException))
                {
                    //Do exception handling.
                }
            }
        }

        private Starflow.Scene TestScene()
        {
            var scene = new Starflow.Scene();
            scene.gameObjects = new List<Starflow.GameObject>();
            Starflow.GameObject gameObject = new Starflow.GameObject();
            gameObject.AddComponent<Sandbox.TestMonoBehaviour>();
            gameObject.transform.position = new Microsoft.Xna.Framework.Vector2(640, 360);

            scene.gameObjects.Add(gameObject);

            return scene;
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            OpenForm.OpenInfo(this);
        }
    }
}