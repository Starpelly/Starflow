namespace Starflow.Editor
{
    partial class AssetBrowser
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TabControl tabControl1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssetBrowser));
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.assetTree = new System.Windows.Forms.TreeView();
            this.assetBrowserSprites = new System.Windows.Forms.ImageList(this.components);
            tabControl1 = new System.Windows.Forms.TabControl();
            tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(this.tabPage1);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(189, 241);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.assetTree);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(181, 215);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Asset Browser";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // assetTree
            // 
            this.assetTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.assetTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assetTree.HideSelection = false;
            this.assetTree.ImageIndex = 0;
            this.assetTree.ImageList = this.assetBrowserSprites;
            this.assetTree.Location = new System.Drawing.Point(3, 3);
            this.assetTree.Name = "assetTree";
            this.assetTree.SelectedImageIndex = 0;
            this.assetTree.ShowLines = false;
            this.assetTree.ShowPlusMinus = false;
            this.assetTree.ShowRootLines = false;
            this.assetTree.Size = new System.Drawing.Size(175, 209);
            this.assetTree.TabIndex = 0;
            this.assetTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.assetTree_NodeMouseDoubleClick);
            // 
            // assetBrowserSprites
            // 
            this.assetBrowserSprites.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("assetBrowserSprites.ImageStream")));
            this.assetBrowserSprites.TransparentColor = System.Drawing.Color.Transparent;
            this.assetBrowserSprites.Images.SetKeyName(0, "folder_open.png");
            this.assetBrowserSprites.Images.SetKeyName(1, "file_csharp.png");
            this.assetBrowserSprites.Images.SetKeyName(2, "image.png");
            // 
            // AssetBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(tabControl1);
            this.Name = "AssetBrowser";
            this.Size = new System.Drawing.Size(189, 241);
            tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TreeView assetTree;
        private System.Windows.Forms.ImageList assetBrowserSprites;
    }
}
