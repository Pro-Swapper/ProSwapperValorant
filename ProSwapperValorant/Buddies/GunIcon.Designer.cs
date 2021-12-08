namespace ProSwapperValorant.Buddies
{
    partial class GunIcon
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
            this.label1 = new System.Windows.Forms.Label();
            this.GunPictureBox = new System.Windows.Forms.PictureBox();
            this.BuddyPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GunPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuddyPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(3, 110);
            this.label1.MaximumSize = new System.Drawing.Size(316, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Gun Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.GunPictureBox_Click);
            // 
            // GunPictureBox
            // 
            this.GunPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GunPictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.GunPictureBox.Location = new System.Drawing.Point(0, 0);
            this.GunPictureBox.Name = "GunPictureBox";
            this.GunPictureBox.Size = new System.Drawing.Size(174, 107);
            this.GunPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.GunPictureBox.TabIndex = 5;
            this.GunPictureBox.TabStop = false;
            this.GunPictureBox.Click += new System.EventHandler(this.GunPictureBox_Click);
            // 
            // BuddyPictureBox
            // 
            this.BuddyPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BuddyPictureBox.Location = new System.Drawing.Point(0, 70);
            this.BuddyPictureBox.Name = "BuddyPictureBox";
            this.BuddyPictureBox.Size = new System.Drawing.Size(75, 37);
            this.BuddyPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BuddyPictureBox.TabIndex = 7;
            this.BuddyPictureBox.TabStop = false;
            this.BuddyPictureBox.Click += new System.EventHandler(this.GunPictureBox_Click);
            // 
            // GunIcon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Controls.Add(this.BuddyPictureBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GunPictureBox);
            this.Name = "GunIcon";
            this.Size = new System.Drawing.Size(174, 131);
            ((System.ComponentModel.ISupportInitialize)(this.GunPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuddyPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox GunPictureBox;
        private System.Windows.Forms.PictureBox BuddyPictureBox;
    }
}
