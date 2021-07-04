
namespace PPPK_Proj
{
    partial class HTMLViewer
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
            this.wbServis = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbServis
            // 
            this.wbServis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbServis.Location = new System.Drawing.Point(0, 0);
            this.wbServis.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbServis.Name = "wbServis";
            this.wbServis.Size = new System.Drawing.Size(835, 575);
            this.wbServis.TabIndex = 0;
            // 
            // HTMLViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 575);
            this.Controls.Add(this.wbServis);
            this.Name = "HTMLViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HTMLViewer";
            this.Load += new System.EventHandler(this.HTMLViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbServis;
    }
}