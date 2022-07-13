using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarflowEditor.Forms
{
    public static class OpenForm
    {
        public static SpriteEditor OpenSpriteEditor(this MainForm mainForm, string image)
        {
            var spriteEditor = new SpriteEditor();
            spriteEditor.Icon = mainForm.Icon;
            spriteEditor.Show();
            spriteEditor.ShowImage(Image.FromFile(image));
            return spriteEditor;
        }

        public static InfoForm OpenInfo(this MainForm mainForm)
        {
            var info = new InfoForm();
            info.Icon = mainForm.Icon;
            info.Show();
            return info;
        }
    }
}
