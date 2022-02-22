using System.Windows.Forms;

namespace Starflow.Editor
{
    public partial class Hierarchy : UserControl
    {
        public Hierarchy()
        {
            InitializeComponent();
        }

        public void Init()
        {
            for (int i = 0; i < EditorWindow.Instance.currentEditorScene.gameObjects.Count; i++)
            {
                hierarchyTree.Nodes.Add(EditorWindow.Instance.currentEditorScene.gameObjects[i].name);
            }
        }
    }
}
