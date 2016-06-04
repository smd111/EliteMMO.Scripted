namespace EliteMMO.Scripted.Views
{
    using API;
    using System.Linq;
    using System.Windows.Forms;
    using System.Text.RegularExpressions;
    using System;
    partial class ScriptSkillup
    {
        private EliteAPI api;
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
            this.playerMA = new System.Windows.Forms.CheckedListBox();
            this.GetSetMA = new System.Windows.Forms.MenuStrip();
            this.loadMAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runSkillupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GetSetMA.SuspendLayout();
            this.SuspendLayout();
            // 
            // playerMA
            // 
            this.playerMA.CheckOnClick = true;
            this.playerMA.FormattingEnabled = true;
            this.playerMA.Location = new System.Drawing.Point(10, 25);
            this.playerMA.Name = "playerMA";
            this.playerMA.Size = new System.Drawing.Size(213, 409);
            this.playerMA.TabIndex = 17;
            // 
            // GetSetMA
            // 
            this.GetSetMA.Dock = System.Windows.Forms.DockStyle.None;
            this.GetSetMA.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMAsToolStripMenuItem,
            this.runSkillupToolStripMenuItem});
            this.GetSetMA.Location = new System.Drawing.Point(30, 437);
            this.GetSetMA.Name = "GetSetMA";
            this.GetSetMA.Size = new System.Drawing.Size(258, 24);
            this.GetSetMA.TabIndex = 18;
            this.GetSetMA.Text = "GetSetMA";
            // 
            // loadMAsToolStripMenuItem
            // 
            this.loadMAsToolStripMenuItem.Name = "loadMAsToolStripMenuItem";
            this.loadMAsToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.loadMAsToolStripMenuItem.Text = "Load MA\'s";
            this.loadMAsToolStripMenuItem.Click += new System.EventHandler(this.loadMAsToolStripMenuItem_Click);
            // 
            // runSkillupToolStripMenuItem
            // 
            this.runSkillupToolStripMenuItem.Name = "runSkillupToolStripMenuItem";
            this.runSkillupToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.runSkillupToolStripMenuItem.Text = "Run Skill-up";
            // 
            // ScriptSkillup
            // 
            this.Controls.Add(this.playerMA);
            this.Controls.Add(this.GetSetMA);
            this.Name = "ScriptSkillup";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 7, 25);
            this.Size = new System.Drawing.Size(236, 476);
            this.GetSetMA.ResumeLayout(false);
            this.GetSetMA.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        public CheckedListBox playerMA;
        public MenuStrip GetSetMA;
        public ToolStripMenuItem loadMAsToolStripMenuItem;
        public ToolStripMenuItem runSkillupToolStripMenuItem;
    }
}

