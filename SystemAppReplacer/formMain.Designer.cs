namespace SystemAppReplacer
{
    partial class formMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.listboxReplaced = new System.Windows.Forms.ListBox();
            this.listboxReplacedWith = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuEnable = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuDisable = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtProgramToReplace = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelectReplace = new System.Windows.Forms.Button();
            this.btnSelectReplaceWith = new System.Windows.Forms.Button();
            this.txtReplaceItWith = new System.Windows.Forms.TextBox();
            this.txtArgs = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnReplaceIt = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(908, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.formMain_MouseUp);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportProfileToolStripMenuItem,
            this.importProfileToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.formMain_MouseUp);
            // 
            // exportProfileToolStripMenuItem
            // 
            this.exportProfileToolStripMenuItem.Enabled = false;
            this.exportProfileToolStripMenuItem.Name = "exportProfileToolStripMenuItem";
            this.exportProfileToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.exportProfileToolStripMenuItem.Text = "Export Profile - Coming Soon!";
            // 
            // importProfileToolStripMenuItem
            // 
            this.importProfileToolStripMenuItem.Enabled = false;
            this.importProfileToolStripMenuItem.Name = "importProfileToolStripMenuItem";
            this.importProfileToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.importProfileToolStripMenuItem.Text = "Import Profile - Coming Soon!";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToUseToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.formMain_MouseUp);
            // 
            // howToUseToolStripMenuItem
            // 
            this.howToUseToolStripMenuItem.Name = "howToUseToolStripMenuItem";
            this.howToUseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.howToUseToolStripMenuItem.Text = "How to Use";
            this.howToUseToolStripMenuItem.Click += new System.EventHandler(this.howToUseToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Replaced Programs:";
            // 
            // listboxReplaced
            // 
            this.listboxReplaced.FormattingEnabled = true;
            this.listboxReplaced.Location = new System.Drawing.Point(15, 40);
            this.listboxReplaced.Name = "listboxReplaced";
            this.listboxReplaced.Size = new System.Drawing.Size(130, 251);
            this.listboxReplaced.TabIndex = 2;
            this.listboxReplaced.SelectedIndexChanged += new System.EventHandler(this.listboxReplaced_SelectedIndexChanged);
            this.listboxReplaced.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listboxReplaced_MouseDown);
            // 
            // listboxReplacedWith
            // 
            this.listboxReplacedWith.FormattingEnabled = true;
            this.listboxReplacedWith.Location = new System.Drawing.Point(154, 40);
            this.listboxReplacedWith.Name = "listboxReplacedWith";
            this.listboxReplacedWith.Size = new System.Drawing.Size(130, 251);
            this.listboxReplacedWith.TabIndex = 4;
            this.listboxReplacedWith.SelectedIndexChanged += new System.EventHandler(this.listboxReplacedWith_SelectedIndexChanged);
            this.listboxReplacedWith.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listboxReplacedWith_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Replaced With:";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.Location = new System.Drawing.Point(355, 303);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(198, 12);
            this.lblCopyright.TabIndex = 8;
            this.lblCopyright.Text = "Copyright © 2020 jParnell - All Rights Reserved";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuEnable,
            this.toolStripMenuDisable,
            this.deleteEntryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(138, 70);
            // 
            // toolStripMenuEnable
            // 
            this.toolStripMenuEnable.Enabled = false;
            this.toolStripMenuEnable.Name = "toolStripMenuEnable";
            this.toolStripMenuEnable.Size = new System.Drawing.Size(137, 22);
            this.toolStripMenuEnable.Text = "Enable";
            this.toolStripMenuEnable.Click += new System.EventHandler(this.toolStripMenuEnable_Click);
            // 
            // toolStripMenuDisable
            // 
            this.toolStripMenuDisable.Enabled = false;
            this.toolStripMenuDisable.Name = "toolStripMenuDisable";
            this.toolStripMenuDisable.Size = new System.Drawing.Size(137, 22);
            this.toolStripMenuDisable.Text = "Disable";
            this.toolStripMenuDisable.Click += new System.EventHandler(this.toolStripMenuDisable_Click);
            // 
            // deleteEntryToolStripMenuItem
            // 
            this.deleteEntryToolStripMenuItem.Name = "deleteEntryToolStripMenuItem";
            this.deleteEntryToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.deleteEntryToolStripMenuItem.Text = "Delete Entry";
            this.deleteEntryToolStripMenuItem.Click += new System.EventHandler(this.deleteEntryToolStripMenuItem_Click);
            // 
            // txtProgramToReplace
            // 
            this.txtProgramToReplace.Location = new System.Drawing.Point(290, 40);
            this.txtProgramToReplace.Name = "txtProgramToReplace";
            this.txtProgramToReplace.Size = new System.Drawing.Size(517, 20);
            this.txtProgramToReplace.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(287, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Replace a new program:";
            // 
            // btnSelectReplace
            // 
            this.btnSelectReplace.Location = new System.Drawing.Point(813, 31);
            this.btnSelectReplace.Name = "btnSelectReplace";
            this.btnSelectReplace.Size = new System.Drawing.Size(82, 36);
            this.btnSelectReplace.TabIndex = 11;
            this.btnSelectReplace.Text = "Select App To Replace";
            this.btnSelectReplace.UseVisualStyleBackColor = true;
            this.btnSelectReplace.Click += new System.EventHandler(this.btnSelectReplace_Click);
            // 
            // btnSelectReplaceWith
            // 
            this.btnSelectReplaceWith.Location = new System.Drawing.Point(813, 74);
            this.btnSelectReplaceWith.Name = "btnSelectReplaceWith";
            this.btnSelectReplaceWith.Size = new System.Drawing.Size(82, 36);
            this.btnSelectReplaceWith.TabIndex = 13;
            this.btnSelectReplaceWith.Text = "Replace It With...";
            this.btnSelectReplaceWith.UseVisualStyleBackColor = true;
            this.btnSelectReplaceWith.Click += new System.EventHandler(this.btnSelectReplaceWith_Click);
            // 
            // txtReplaceItWith
            // 
            this.txtReplaceItWith.Location = new System.Drawing.Point(290, 83);
            this.txtReplaceItWith.Name = "txtReplaceItWith";
            this.txtReplaceItWith.Size = new System.Drawing.Size(517, 20);
            this.txtReplaceItWith.TabIndex = 12;
            // 
            // txtArgs
            // 
            this.txtArgs.Location = new System.Drawing.Point(290, 126);
            this.txtArgs.Name = "txtArgs";
            this.txtArgs.Size = new System.Drawing.Size(517, 20);
            this.txtArgs.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(319, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(256, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Arguments needed by the program you intend to use.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(319, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "See Help menu for more information.";
            // 
            // btnReplaceIt
            // 
            this.btnReplaceIt.Location = new System.Drawing.Point(479, 216);
            this.btnReplaceIt.Name = "btnReplaceIt";
            this.btnReplaceIt.Size = new System.Drawing.Size(82, 36);
            this.btnReplaceIt.TabIndex = 17;
            this.btnReplaceIt.Text = "Replace It!";
            this.btnReplaceIt.UseVisualStyleBackColor = true;
            this.btnReplaceIt.Click += new System.EventHandler(this.btnReplaceIt_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 324);
            this.Controls.Add(this.btnReplaceIt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtArgs);
            this.Controls.Add(this.btnSelectReplaceWith);
            this.Controls.Add(this.txtReplaceItWith);
            this.Controls.Add(this.btnSelectReplace);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtProgramToReplace);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.listboxReplacedWith);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listboxReplaced);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "formMain";
            this.Text = "System App Replacer";
            this.Load += new System.EventHandler(this.formMain_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.formMain_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToUseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listboxReplaced;
        private System.Windows.Forms.ListBox listboxReplacedWith;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuEnable;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuDisable;
        private System.Windows.Forms.ToolStripMenuItem deleteEntryToolStripMenuItem;
        private System.Windows.Forms.TextBox txtProgramToReplace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelectReplace;
        private System.Windows.Forms.Button btnSelectReplaceWith;
        private System.Windows.Forms.TextBox txtReplaceItWith;
        private System.Windows.Forms.TextBox txtArgs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnReplaceIt;
    }
}

