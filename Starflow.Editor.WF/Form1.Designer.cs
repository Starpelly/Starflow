namespace Starflow.Editor.WF
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node0");
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTabs = new System.Windows.Forms.TabControl();
            this.assetBrowserTab = new System.Windows.Forms.TabControl();
            this.assetBrowserPage = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.hierarchyTab = new System.Windows.Forms.TabControl();
            this.hierarchyPage = new System.Windows.Forms.TabPage();
            this.sceneView = new System.Windows.Forms.TabPage();
            this.drawTest1 = new Starflow.Editor.WF.DrawTest();
            this.inspectorControl = new System.Windows.Forms.TabControl();
            this.inspectorTab = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.mainTabs.SuspendLayout();
            this.assetBrowserTab.SuspendLayout();
            this.assetBrowserPage.SuspendLayout();
            this.hierarchyTab.SuspendLayout();
            this.sceneView.SuspendLayout();
            this.inspectorControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // mainTabs
            // 
            this.mainTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabs.Controls.Add(this.sceneView);
            this.mainTabs.Location = new System.Drawing.Point(207, 27);
            this.mainTabs.Name = "mainTabs";
            this.mainTabs.SelectedIndex = 0;
            this.mainTabs.Size = new System.Drawing.Size(867, 642);
            this.mainTabs.TabIndex = 1;
            // 
            // assetBrowserTab
            // 
            this.assetBrowserTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.assetBrowserTab.Controls.Add(this.assetBrowserPage);
            this.assetBrowserTab.Location = new System.Drawing.Point(12, 428);
            this.assetBrowserTab.Name = "assetBrowserTab";
            this.assetBrowserTab.SelectedIndex = 0;
            this.assetBrowserTab.Size = new System.Drawing.Size(189, 241);
            this.assetBrowserTab.TabIndex = 2;
            // 
            // assetBrowserPage
            // 
            this.assetBrowserPage.Controls.Add(this.treeView1);
            this.assetBrowserPage.Location = new System.Drawing.Point(4, 22);
            this.assetBrowserPage.Name = "assetBrowserPage";
            this.assetBrowserPage.Padding = new System.Windows.Forms.Padding(3);
            this.assetBrowserPage.Size = new System.Drawing.Size(181, 215);
            this.assetBrowserPage.TabIndex = 0;
            this.assetBrowserPage.Text = "Asset Browser";
            this.assetBrowserPage.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            treeNode3.Name = "Node0";
            treeNode3.Text = "Node0";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.treeView1.Size = new System.Drawing.Size(175, 209);
            this.treeView1.TabIndex = 0;
            // 
            // hierarchyTab
            // 
            this.hierarchyTab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.hierarchyTab.Controls.Add(this.hierarchyPage);
            this.hierarchyTab.Location = new System.Drawing.Point(12, 27);
            this.hierarchyTab.Name = "hierarchyTab";
            this.hierarchyTab.SelectedIndex = 0;
            this.hierarchyTab.Size = new System.Drawing.Size(182, 395);
            this.hierarchyTab.TabIndex = 3;
            // 
            // hierarchyPage
            // 
            this.hierarchyPage.Location = new System.Drawing.Point(4, 22);
            this.hierarchyPage.Name = "hierarchyPage";
            this.hierarchyPage.Padding = new System.Windows.Forms.Padding(3);
            this.hierarchyPage.Size = new System.Drawing.Size(174, 369);
            this.hierarchyPage.TabIndex = 0;
            this.hierarchyPage.Text = "Hierarchy";
            this.hierarchyPage.UseVisualStyleBackColor = true;
            // 
            // sceneView
            // 
            this.sceneView.Controls.Add(this.drawTest1);
            this.sceneView.Location = new System.Drawing.Point(4, 22);
            this.sceneView.Name = "sceneView";
            this.sceneView.Padding = new System.Windows.Forms.Padding(3);
            this.sceneView.Size = new System.Drawing.Size(859, 616);
            this.sceneView.TabIndex = 0;
            this.sceneView.Text = "Scene";
            this.sceneView.UseVisualStyleBackColor = true;
            // 
            // drawTest1
            // 
            this.drawTest1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawTest1.Location = new System.Drawing.Point(3, 3);
            this.drawTest1.MouseHoverUpdatesOnly = false;
            this.drawTest1.Name = "drawTest1";
            this.drawTest1.Size = new System.Drawing.Size(853, 610);
            this.drawTest1.TabIndex = 0;
            this.drawTest1.Text = "drawTest1";
            // 
            // inspectorControl
            // 
            this.inspectorControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inspectorControl.Controls.Add(this.inspectorTab);
            this.inspectorControl.Location = new System.Drawing.Point(1080, 49);
            this.inspectorControl.Name = "inspectorControl";
            this.inspectorControl.SelectedIndex = 0;
            this.inspectorControl.Size = new System.Drawing.Size(172, 616);
            this.inspectorControl.TabIndex = 4;
            // 
            // inspectorTab
            // 
            this.inspectorTab.Location = new System.Drawing.Point(4, 22);
            this.inspectorTab.Name = "inspectorTab";
            this.inspectorTab.Padding = new System.Windows.Forms.Padding(3);
            this.inspectorTab.Size = new System.Drawing.Size(164, 590);
            this.inspectorTab.TabIndex = 0;
            this.inspectorTab.Text = "Inspector";
            this.inspectorTab.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.inspectorControl);
            this.Controls.Add(this.hierarchyTab);
            this.Controls.Add(this.assetBrowserTab);
            this.Controls.Add(this.mainTabs);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(653, 508);
            this.Name = "Form1";
            this.Text = "Starflow SDK";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainTabs.ResumeLayout(false);
            this.assetBrowserTab.ResumeLayout(false);
            this.assetBrowserPage.ResumeLayout(false);
            this.hierarchyTab.ResumeLayout(false);
            this.sceneView.ResumeLayout(false);
            this.inspectorControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TabControl mainTabs;
        private System.Windows.Forms.TabControl assetBrowserTab;
        private System.Windows.Forms.TabPage assetBrowserPage;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl hierarchyTab;
        private System.Windows.Forms.TabPage hierarchyPage;
        private System.Windows.Forms.TabPage sceneView;
        private DrawTest drawTest1;
        private System.Windows.Forms.TabControl inspectorControl;
        private System.Windows.Forms.TabPage inspectorTab;
    }
}

