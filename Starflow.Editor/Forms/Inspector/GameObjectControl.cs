using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Starflow.Editor.UI.Components;

namespace Starflow.Editor.Inspectr
{
    public partial class GameObjectControl : UserControl
    {
        public GameObject gameObject;

        public GameObjectControl()
        {
            InitializeComponent();

            Init();
        }

        public void Init()
        {
            Vector2 pos = new Vector2();
            pos.label.Text = "Position";
            pos.posX.KeyPress += delegate
            {
                gameObject.transform.position.X = float.Parse(pos.posX.Text);
            };
            flowLayout.Controls.Add(pos);
        }

        private void ValidateFloat(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
