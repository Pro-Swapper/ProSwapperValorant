namespace ProSwapperValorant.Buddies
{
    partial class GunSelect
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
            this.gunlistPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // gunlistPanel
            // 
            this.gunlistPanel.AutoScroll = true;
            this.gunlistPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunlistPanel.Location = new System.Drawing.Point(0, 0);
            this.gunlistPanel.Name = "gunlistPanel";
            this.gunlistPanel.Size = new System.Drawing.Size(980, 711);
            this.gunlistPanel.TabIndex = 0;
            // 
            // GunSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Controls.Add(this.gunlistPanel);
            this.Name = "GunSelect";
            this.Size = new System.Drawing.Size(980, 711);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel gunlistPanel;
    }
}
