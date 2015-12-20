namespace EliteMMO.Scripted.Views
{
    using API;
    partial class ScriptNaviMap
    {
        private static EliteAPI api;
        public bool isRunning = false;
        public bool isRecording = false;
        public float lastX = -300;
        public float lastY = -300;
        public float lastZ = -300;
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
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.menuStrip4 = new System.Windows.Forms.MenuStrip();
            this.PlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.menuStrip5 = new System.Windows.Forms.MenuStrip();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConvertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgw_navi = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.runReverse = new System.Windows.Forms.CheckBox();
            this.Linear = new System.Windows.Forms.RadioButton();
            this.Circular = new System.Windows.Forms.RadioButton();
            this.WayPoints = new System.Windows.Forms.ListBox();
            this.groupBox9.SuspendLayout();
            this.menuStrip4.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.menuStrip5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.menuStrip4);
            this.groupBox9.Location = new System.Drawing.Point(10, 211);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(407, 49);
            this.groupBox9.TabIndex = 11;
            this.groupBox9.TabStop = false;
            // 
            // menuStrip4
            // 
            this.menuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlayToolStripMenuItem,
            this.PauseToolStripMenuItem,
            this.ResumeToolStripMenuItem,
            this.StopToolStripMenuItem,
            this.ClearToolStripMenuItem,
            this.RecordToolStripMenuItem});
            this.menuStrip4.Location = new System.Drawing.Point(3, 16);
            this.menuStrip4.Name = "menuStrip4";
            this.menuStrip4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip4.Size = new System.Drawing.Size(401, 24);
            this.menuStrip4.Stretch = false;
            this.menuStrip4.TabIndex = 0;
            this.menuStrip4.Text = "menuStrip4";
            // 
            // PlayToolStripMenuItem
            // 
            this.PlayToolStripMenuItem.Enabled = false;
            this.PlayToolStripMenuItem.Name = "PlayToolStripMenuItem";
            this.PlayToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.PlayToolStripMenuItem.Text = "play";
            this.PlayToolStripMenuItem.Click += new System.EventHandler(this.PlayToolStripMenuItem_Click);
            // 
            // PauseToolStripMenuItem
            // 
            this.PauseToolStripMenuItem.Enabled = false;
            this.PauseToolStripMenuItem.Name = "PauseToolStripMenuItem";
            this.PauseToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.PauseToolStripMenuItem.Text = "pause";
            this.PauseToolStripMenuItem.Click += new System.EventHandler(this.PauseToolStripMenuItem_Click);
            // 
            // ResumeToolStripMenuItem
            // 
            this.ResumeToolStripMenuItem.Enabled = false;
            this.ResumeToolStripMenuItem.Name = "ResumeToolStripMenuItem";
            this.ResumeToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.ResumeToolStripMenuItem.Text = "resume";
            this.ResumeToolStripMenuItem.Click += new System.EventHandler(this.ResumeToolStripMenuItem_Click);
            // 
            // StopToolStripMenuItem
            // 
            this.StopToolStripMenuItem.Enabled = false;
            this.StopToolStripMenuItem.Name = "StopToolStripMenuItem";
            this.StopToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.StopToolStripMenuItem.Text = "stop";
            this.StopToolStripMenuItem.Click += new System.EventHandler(this.StopToolStripMenuItem_Click);
            // 
            // ClearToolStripMenuItem
            // 
            this.ClearToolStripMenuItem.Enabled = false;
            this.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem";
            this.ClearToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.ClearToolStripMenuItem.Text = "clear";
            this.ClearToolStripMenuItem.Click += new System.EventHandler(this.ClearToolStripMenuItem_Click);
            // 
            // RecordToolStripMenuItem
            // 
            this.RecordToolStripMenuItem.Name = "RecordToolStripMenuItem";
            this.RecordToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.RecordToolStripMenuItem.Text = "record";
            this.RecordToolStripMenuItem.Click += new System.EventHandler(this.RecordToolStripMenuItemClick);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.comboBox2);
            this.groupBox10.Controls.Add(this.menuStrip5);
            this.groupBox10.Location = new System.Drawing.Point(10, 265);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(208, 74);
            this.groupBox10.TabIndex = 12;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Load Navigation";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(7, 18);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(194, 21);
            this.comboBox2.TabIndex = 7;
            // 
            // menuStrip5
            // 
            this.menuStrip5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveToolStripMenuItem,
            this.RefreshToolStripMenuItem,
            this.ConvertToolStripMenuItem});
            this.menuStrip5.Location = new System.Drawing.Point(3, 47);
            this.menuStrip5.Name = "menuStrip5";
            this.menuStrip5.Size = new System.Drawing.Size(202, 24);
            this.menuStrip5.TabIndex = 8;
            this.menuStrip5.Text = "menuStrip5";
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.SaveToolStripMenuItem.Text = "save";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // RefreshToolStripMenuItem
            // 
            this.RefreshToolStripMenuItem.Enabled = false;
            this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            this.RefreshToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.RefreshToolStripMenuItem.Text = "refresh";
            // 
            // ConvertToolStripMenuItem
            // 
            this.ConvertToolStripMenuItem.Enabled = false;
            this.ConvertToolStripMenuItem.Name = "ConvertToolStripMenuItem";
            this.ConvertToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.ConvertToolStripMenuItem.Text = "convert";
            // 
            // bgw_navi
            // 
            this.bgw_navi.WorkerReportsProgress = true;
            this.bgw_navi.WorkerSupportsCancellation = true;
            this.bgw_navi.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwNaviDoWork);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.runReverse);
            this.groupBox1.Controls.Add(this.Linear);
            this.groupBox1.Controls.Add(this.Circular);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(225, 265);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 74);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // runReverse
            // 
            this.runReverse.AutoSize = true;
            this.runReverse.Enabled = false;
            this.runReverse.Location = new System.Drawing.Point(107, 22);
            this.runReverse.Name = "runReverse";
            this.runReverse.Size = new System.Drawing.Size(79, 17);
            this.runReverse.TabIndex = 35;
            this.runReverse.Text = "run reverse";
            this.runReverse.UseVisualStyleBackColor = true;
            // 
            // Linear
            // 
            this.Linear.AutoSize = true;
            this.Linear.Location = new System.Drawing.Point(12, 40);
            this.Linear.Name = "Linear";
            this.Linear.Size = new System.Drawing.Size(79, 17);
            this.Linear.TabIndex = 34;
            this.Linear.Text = "Linear Path";
            this.Linear.UseVisualStyleBackColor = true;
            // 
            // Circular
            // 
            this.Circular.AutoSize = true;
            this.Circular.Checked = true;
            this.Circular.Location = new System.Drawing.Point(12, 22);
            this.Circular.Name = "Circular";
            this.Circular.Size = new System.Drawing.Size(85, 17);
            this.Circular.TabIndex = 33;
            this.Circular.TabStop = true;
            this.Circular.Text = "Circular Path";
            this.Circular.UseVisualStyleBackColor = true;
            // 
            // WayPoints
            // 
            this.WayPoints.FormattingEnabled = true;
            this.WayPoints.Location = new System.Drawing.Point(10, 29);
            this.WayPoints.Name = "WayPoints";
            this.WayPoints.Size = new System.Drawing.Size(407, 173);
            this.WayPoints.TabIndex = 14;
            // 
            // ScriptNaviMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WayPoints);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox9);
            this.Name = "ScriptNaviMap";
            this.Size = new System.Drawing.Size(429, 349);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.menuStrip4.ResumeLayout(false);
            this.menuStrip4.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.menuStrip5.ResumeLayout(false);
            this.menuStrip5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.GroupBox groupBox9;
        public System.Windows.Forms.MenuStrip menuStrip4;
        public System.Windows.Forms.ToolStripMenuItem PlayToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem PauseToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ResumeToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem StopToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ClearToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem RecordToolStripMenuItem;
        public System.Windows.Forms.GroupBox groupBox10;
        public System.Windows.Forms.ComboBox comboBox2;
        public System.Windows.Forms.MenuStrip menuStrip5;
        public System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem RefreshToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ConvertToolStripMenuItem;
        public System.ComponentModel.BackgroundWorker bgw_navi;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.CheckBox runReverse;
        public System.Windows.Forms.RadioButton Linear;
        public System.Windows.Forms.RadioButton Circular;

        #region PlayToolStrip
        private void PlayToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            isRunning = true;
            isRecording = false;

            if (PlayToolStripMenuItem.Enabled == true)
                PlayToolStripMenuItem.Enabled = false;

            if (RecordToolStripMenuItem.Enabled == true)
                RecordToolStripMenuItem.Enabled = false;

            if (PauseToolStripMenuItem.Enabled == false)
                PauseToolStripMenuItem.Enabled = true;

            if (StopToolStripMenuItem.Enabled == false)
                StopToolStripMenuItem.Enabled = true;
        }

        private void PauseToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            isRunning = false;
            isRecording = false;

            if (StopToolStripMenuItem.Enabled == false)
                StopToolStripMenuItem.Enabled = true;

            if (ResumeToolStripMenuItem.Enabled == false)
                ResumeToolStripMenuItem.Enabled = true;
        }

        private void ResumeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            isRunning = true;
            isRecording = true;

            if (StopToolStripMenuItem.Enabled == false)
                StopToolStripMenuItem.Enabled = true;

            if (PauseToolStripMenuItem.Enabled == false)
                PauseToolStripMenuItem.Enabled = true;
        }

        private void StopToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            isRunning = false;
            isRecording = false;

            //if (PlayToolStripMenuItem.Enabled == false)
            //    PlayToolStripMenuItem.Enabled = true;

            if (RecordToolStripMenuItem.Enabled == false)
                RecordToolStripMenuItem.Enabled = true;

            //if (PauseToolStripMenuItem.Enabled == true)
            //    PauseToolStripMenuItem.Enabled = false;

            if (StopToolStripMenuItem.Enabled == true)
                StopToolStripMenuItem.Enabled = false;

            bgw_navi.CancelAsync();
        }

        private void ClearToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (WayPoints.Items.Count > 0)
                WayPoints.Items.Clear();
        }

        private void RecordToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            isRunning = true;
            isRecording = true;

            if (ClearToolStripMenuItem.Enabled == false)
                ClearToolStripMenuItem.Enabled = true;

            if (RecordToolStripMenuItem.Enabled == true)
                RecordToolStripMenuItem.Enabled = false;

            if (StopToolStripMenuItem.Enabled == false)
                StopToolStripMenuItem.Enabled = true;
            if (!bgw_navi.IsBusy)
                bgw_navi.RunWorkerAsync();
        }

        private System.Windows.Forms.ListBox WayPoints;
        #endregion

        #region class: PlayerInfo
        public static class PlayerInfo
        {
            public static int Status => (int)api.Entity.GetLocalPlayer().Status;
            public static int TargetID => (int)api.Entity.GetLocalPlayer().TargetID;
            public static float X => api.Entity.GetLocalPlayer().X;
            public static float Y => api.Entity.GetLocalPlayer().Y;
            public static float Z => api.Entity.GetLocalPlayer().Z;
            public static float H => api.Entity.GetLocalPlayer().H;
        }
        #endregion
    }
}
