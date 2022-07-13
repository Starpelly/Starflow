namespace StarflowEditor.Forms
{
    partial class CodeEditor
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scintilla = new ScintillaNET.Scintilla();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(726, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // scintilla
            // 
            this.scintilla.AutoCMaxHeight = 9;
            this.scintilla.BiDirectionality = ScintillaNET.BiDirectionalDisplayType.Disabled;
            this.scintilla.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.scintilla.CaretLineBackColor = System.Drawing.Color.Black;
            this.scintilla.CaretLineVisible = true;
            this.scintilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scintilla.LexerName = null;
            this.scintilla.Location = new System.Drawing.Point(0, 24);
            this.scintilla.Name = "scintilla";
            this.scintilla.ScrollWidth = 49;
            this.scintilla.Size = new System.Drawing.Size(726, 436);
            this.scintilla.TabIndents = true;
            this.scintilla.TabIndex = 1;
            this.scintilla.UseRightToLeftReadingLayout = false;
            this.scintilla.WrapMode = ScintillaNET.WrapMode.None;
            // 
            // CodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scintilla);
            this.Controls.Add(this.menuStrip1);
            this.Name = "CodeEditor";
            this.Size = new System.Drawing.Size(726, 460);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ScintillaNET.Scintilla scintilla;
    }
}
