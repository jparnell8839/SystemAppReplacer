namespace SystemAppReplacer
{
    partial class formHowTo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formHowTo));
            this.webHowTo = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webHowTo
            // 
            this.webHowTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webHowTo.Location = new System.Drawing.Point(0, 0);
            this.webHowTo.MinimumSize = new System.Drawing.Size(20, 20);
            this.webHowTo.Name = "webHowTo";
            this.webHowTo.Size = new System.Drawing.Size(800, 450);
            this.webHowTo.TabIndex = 0;
            // 
            // formHowTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.webHowTo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "formHowTo";
            this.ShowInTaskbar = false;
            this.Text = "How to Use";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formHowTo_FormClosed);
            this.Load += new System.EventHandler(this.formHowTo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webHowTo;
    }
}