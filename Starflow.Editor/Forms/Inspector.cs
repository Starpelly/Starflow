using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Starflow.Editor.Inspectr;

namespace Starflow.Editor
{
    public partial class Inspector : UserControl
    {
        public static Inspector instance { get; set; }

        GameObjectControl gameObjectControl;

        public Inspector()
        {
            instance = this;
            InitializeComponent();
        }

        public void OnGameObjectSelect()
        {
            tabPage.Controls.Clear();

            gameObjectControl = new GameObjectControl();
            tabPage.Controls.Add(gameObjectControl);

            GameObject gameObject = EditorWindow.Instance.currentEditorScene.activeGameObject;
            if (gameObject != null)
            {
                gameObjectControl.name.Text = gameObject.name;
                gameObjectControl.enabled.Checked = gameObject.enabled;
                gameObjectControl.gameObject = gameObject;
                gameObjectControl.Init();
            }
        }
    }
}
