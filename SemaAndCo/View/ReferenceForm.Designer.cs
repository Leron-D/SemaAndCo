namespace SemaAndCo.View
{
    partial class ReferenceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReferenceForm));
            this.referenceWebBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // referenceWebBrowser
            // 
            this.referenceWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.referenceWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.referenceWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.referenceWebBrowser.Name = "referenceWebBrowser";
            this.referenceWebBrowser.Size = new System.Drawing.Size(830, 490);
            this.referenceWebBrowser.TabIndex = 0;
            // 
            // ReferenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(830, 490);
            this.Controls.Add(this.referenceWebBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(846, 529);
            this.MinimumSize = new System.Drawing.Size(846, 529);
            this.Name = "ReferenceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справка о программе";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser referenceWebBrowser;
    }
}