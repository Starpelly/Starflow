namespace Starflow.Editor
{
    partial class EditorWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTabs = new System.Windows.Forms.TabControl();
            this.sceneView = new System.Windows.Forms.TabPage();
            this.drawTest1 = new Starflow.Editor.DrawTest();
            this.assetBrowserTab = new System.Windows.Forms.TabControl();
            this.assetBrowserPage = new System.Windows.Forms.TabPage();
            this.assetTree = new System.Windows.Forms.TreeView();
            this.assetBrowserSprites = new System.Windows.Forms.ImageList(this.components);
            this.hierarchyTab = new System.Windows.Forms.TabControl();
            this.hierarchyPage = new System.Windows.Forms.TabPage();
            this.hierarchyTree = new System.Windows.Forms.TreeView();
            this.inspectorControl = new System.Windows.Forms.TabControl();
            this.inspectorTab = new System.Windows.Forms.TabPage();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.playButton = new System.Windows.Forms.ToolStripButton();
            this.playfromstartButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buildButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.infoButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.mainTabs.SuspendLayout();
            this.sceneView.SuspendLayout();
            this.assetBrowserTab.SuspendLayout();
            this.assetBrowserPage.SuspendLayout();
            this.hierarchyTab.SuspendLayout();
            this.hierarchyPage.SuspendLayout();
            this.inspectorControl.SuspendLayout();
            this.toolStrip.SuspendLayout();
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
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(183, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator4,
            this.deleteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(104, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
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
            this.mainTabs.Location = new System.Drawing.Point(207, 71);
            this.mainTabs.Name = "mainTabs";
            this.mainTabs.SelectedIndex = 0;
            this.mainTabs.Size = new System.Drawing.Size(839, 598);
            this.mainTabs.TabIndex = 1;
            // 
            // sceneView
            // 
            this.sceneView.Controls.Add(this.drawTest1);
            this.sceneView.Location = new System.Drawing.Point(4, 22);
            this.sceneView.Name = "sceneView";
            this.sceneView.Padding = new System.Windows.Forms.Padding(3);
            this.sceneView.Size = new System.Drawing.Size(831, 572);
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
            this.drawTest1.Size = new System.Drawing.Size(825, 566);
            this.drawTest1.TabIndex = 0;
            this.drawTest1.Text = "drawTest1";
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
            this.assetBrowserPage.Controls.Add(this.assetTree);
            this.assetBrowserPage.Location = new System.Drawing.Point(4, 22);
            this.assetBrowserPage.Name = "assetBrowserPage";
            this.assetBrowserPage.Padding = new System.Windows.Forms.Padding(3);
            this.assetBrowserPage.Size = new System.Drawing.Size(181, 215);
            this.assetBrowserPage.TabIndex = 0;
            this.assetBrowserPage.Text = "Asset Browser";
            this.assetBrowserPage.UseVisualStyleBackColor = true;
            // 
            // assetTree
            // 
            this.assetTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.assetTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assetTree.ImageIndex = 0;
            this.assetTree.ImageList = this.assetBrowserSprites;
            this.assetTree.Location = new System.Drawing.Point(3, 3);
            this.assetTree.Name = "assetTree";
            this.assetTree.SelectedImageIndex = 0;
            this.assetTree.Size = new System.Drawing.Size(175, 209);
            this.assetTree.TabIndex = 0;
            // 
            // assetBrowserSprites
            // 
            this.assetBrowserSprites.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("assetBrowserSprites.ImageStream")));
            this.assetBrowserSprites.TransparentColor = System.Drawing.Color.Transparent;
            this.assetBrowserSprites.Images.SetKeyName(0, "folder_open.png");
            this.assetBrowserSprites.Images.SetKeyName(1, "file_csharp.png");
            this.assetBrowserSprites.Images.SetKeyName(2, "image.png");
            // 
            // hierarchyTab
            // 
            this.hierarchyTab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.hierarchyTab.Controls.Add(this.hierarchyPage);
            this.hierarchyTab.Location = new System.Drawing.Point(12, 71);
            this.hierarchyTab.Name = "hierarchyTab";
            this.hierarchyTab.SelectedIndex = 0;
            this.hierarchyTab.Size = new System.Drawing.Size(182, 351);
            this.hierarchyTab.TabIndex = 3;
            // 
            // hierarchyPage
            // 
            this.hierarchyPage.Controls.Add(this.hierarchyTree);
            this.hierarchyPage.Location = new System.Drawing.Point(4, 22);
            this.hierarchyPage.Name = "hierarchyPage";
            this.hierarchyPage.Padding = new System.Windows.Forms.Padding(3);
            this.hierarchyPage.Size = new System.Drawing.Size(174, 325);
            this.hierarchyPage.TabIndex = 0;
            this.hierarchyPage.Text = "Hierarchy";
            this.hierarchyPage.UseVisualStyleBackColor = true;
            // 
            // hierarchyTree
            // 
            this.hierarchyTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hierarchyTree.Location = new System.Drawing.Point(3, 3);
            this.hierarchyTree.Name = "hierarchyTree";
            this.hierarchyTree.Size = new System.Drawing.Size(168, 319);
            this.hierarchyTree.TabIndex = 0;
            // 
            // inspectorControl
            // 
            this.inspectorControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inspectorControl.Controls.Add(this.inspectorTab);
            this.inspectorControl.Location = new System.Drawing.Point(1048, 71);
            this.inspectorControl.Name = "inspectorControl";
            this.inspectorControl.SelectedIndex = 0;
            this.inspectorControl.Size = new System.Drawing.Size(204, 594);
            this.inspectorControl.TabIndex = 4;
            // 
            // inspectorTab
            // 
            this.inspectorTab.Location = new System.Drawing.Point(4, 22);
            this.inspectorTab.Name = "inspectorTab";
            this.inspectorTab.Padding = new System.Windows.Forms.Padding(3);
            this.inspectorTab.Size = new System.Drawing.Size(196, 568);
            this.inspectorTab.TabIndex = 0;
            this.inspectorTab.Text = "Inspector";
            this.inspectorTab.UseVisualStyleBackColor = true;
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playButton,
            this.playfromstartButton,
            this.toolStripSeparator1,
            this.buildButton,
            this.toolStripSeparator2,
            this.infoButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1264, 44);
            this.toolStrip.TabIndex = 5;
            this.toolStrip.Text = "toolStrip";
            // 
            // playButton
            // 
            this.playButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.playButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.Image = ((System.Drawing.Image)(resources.GetObject("playButton.Image")));
            this.playButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.playButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.playButton.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.playButton.Name = "playButton";
            this.playButton.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.playButton.Size = new System.Drawing.Size(38, 41);
            this.playButton.Text = "Play";
            // 
            // playfromstartButton
            // 
            this.playfromstartButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.playfromstartButton.Image = ((System.Drawing.Image)(resources.GetObject("playfromstartButton.Image")));
            this.playfromstartButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.playfromstartButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.playfromstartButton.Name = "playfromstartButton";
            this.playfromstartButton.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.playfromstartButton.Size = new System.Drawing.Size(38, 41);
            this.playfromstartButton.Text = "Play from Start";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 44);
            // 
            // buildButton
            // 
            this.buildButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buildButton.Image = ((System.Drawing.Image)(resources.GetObject("buildButton.Image")));
            this.buildButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buildButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buildButton.Name = "buildButton";
            this.buildButton.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.buildButton.Size = new System.Drawing.Size(42, 41);
            this.buildButton.Text = "Build";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 44);
            // 
            // infoButton
            // 
            this.infoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.infoButton.Image = ((System.Drawing.Image)(resources.GetObject("infoButton.Image")));
            this.infoButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.infoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.infoButton.Name = "infoButton";
            this.infoButton.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.infoButton.Size = new System.Drawing.Size(42, 41);
            this.infoButton.Text = "Info";
            // 
            // EditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.inspectorControl);
            this.Controls.Add(this.hierarchyTab);
            this.Controls.Add(this.assetBrowserTab);
            this.Controls.Add(this.mainTabs);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(653, 508);
            this.Name = "EditorWindow";
            this.Text = "Starflow SDK";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainTabs.ResumeLayout(false);
            this.sceneView.ResumeLayout(false);
            this.assetBrowserTab.ResumeLayout(false);
            this.assetBrowserPage.ResumeLayout(false);
            this.hierarchyTab.ResumeLayout(false);
            this.hierarchyPage.ResumeLayout(false);
            this.inspectorControl.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
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
        private System.Windows.Forms.TreeView assetTree;
        private System.Windows.Forms.TabControl hierarchyTab;
        private System.Windows.Forms.TabPage hierarchyPage;
        private System.Windows.Forms.TabPage sceneView;
        private DrawTest drawTest1;
        private System.Windows.Forms.TabControl inspectorControl;
        private System.Windows.Forms.TabPage inspectorTab;
        private System.Windows.Forms.ImageList assetBrowserSprites;
        private System.Windows.Forms.TreeView hierarchyTree;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton playButton;
        private System.Windows.Forms.ToolStripButton playfromstartButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buildButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton infoButton;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

