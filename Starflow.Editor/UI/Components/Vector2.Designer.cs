namespace Starflow.Editor.UI.Components
{
    partial class Vector2
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
            this.label = new System.Windows.Forms.Label();
            this.posY = new System.Windows.Forms.TextBox();
            this.posX = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(3, 3);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(37, 18);
            this.label.TabIndex = 0;
            this.label.Text = "Vec2";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // posY
            // 
            this.posY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.posY.Location = new System.Drawing.Point(201, 3);
            this.posY.Name = "posY";
            this.posY.Size = new System.Drawing.Size(106, 20);
            this.posY.TabIndex = 1;
            this.posY.Text = "0.00";
            // 
            // posX
            // 
            this.posX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.posX.Location = new System.Drawing.Point(89, 3);
            this.posX.Name = "posX";
            this.posX.Size = new System.Drawing.Size(106, 20);
            this.posX.TabIndex = 2;
            this.posX.Text = "0.00";
            // 
            // Vector2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.posX);
            this.Controls.Add(this.posY);
            this.Controls.Add(this.label);
            this.Name = "Vector2";
            this.Size = new System.Drawing.Size(310, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label;
        public System.Windows.Forms.TextBox posY;
        public System.Windows.Forms.TextBox posX;
    }
}
