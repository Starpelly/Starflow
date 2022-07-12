using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starflow.Editor.Forms
{
    public partial class FileTreeNode : TreeNode
    {
        public int UID;
        public string realFilePath;

        public FileTreeNode(string nodeName) : base(nodeName)
        {
        }

        public void RemoveIt()
        {
            base.Remove();
        }
    }
}
