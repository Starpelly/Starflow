using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarflowEditor.Forms
{
    public partial class SpriteEditor : Form
    {
        public SpriteEditor()
        {
            InitializeComponent();
        }

        public void ShowImage(Image image)
        {
            pictureBox1.Image = image;
        }
    }
}
