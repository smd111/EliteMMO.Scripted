namespace EliteMMO.Scripted.Views
{
    using API;
    using System;
    using System.Linq;
    using System.Threading;
    partial class ScriptNaviMap
    {
        private static EliteAPI api;
        public bool isRunning = false;
        public bool isRecording = false;
        public bool isPlaying = false;
        public bool isPaused = false;
        public float lastX = -300;
        public float lastY = -300;
        public float lastZ = -300;

        public double[] navPathX = new double[1];
        public double[] navPathZ = new double[1];
        public double[] navPathY = new double[1];
        //public double[] navPathfirst = new double[1];
        //public double[] navPathstuck = new double[1];
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
            this.components = new System.ComponentModel.Container();
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
            this.StuckWatch = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NodeDist = new System.Windows.Forms.NumericUpDown();
            this.runReverse = new System.Windows.Forms.CheckBox();
            this.Linear = new System.Windows.Forms.RadioButton();
            this.Circular = new System.Windows.Forms.RadioButton();
            this.WayPoints = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.firstPersonView = new System.Windows.Forms.CheckBox();
            this.groupBox9.SuspendLayout();
            this.menuStrip4.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.menuStrip5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NodeDist)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.menuStrip4);
            this.groupBox9.Location = new System.Drawing.Point(10, 208);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(425, 51);
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
            this.menuStrip4.Size = new System.Drawing.Size(419, 24);
            this.menuStrip4.Stretch = false;
            this.menuStrip4.TabIndex = 0;
            this.menuStrip4.Text = "menuStrip4";
            // 
            // PlayToolStripMenuItem
            // 
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
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
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
            this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            this.RefreshToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.RefreshToolStripMenuItem.Text = "refresh";
            this.RefreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
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
            this.groupBox1.Controls.Add(this.firstPersonView);
            this.groupBox1.Controls.Add(this.StuckWatch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.NodeDist);
            this.groupBox1.Controls.Add(this.runReverse);
            this.groupBox1.Controls.Add(this.Linear);
            this.groupBox1.Controls.Add(this.Circular);
            this.groupBox1.Location = new System.Drawing.Point(225, 265);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 74);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // StuckWatch
            // 
            this.StuckWatch.AutoSize = true;
            this.StuckWatch.Location = new System.Drawing.Point(16, 52);
            this.StuckWatch.Name = "StuckWatch";
            this.StuckWatch.Size = new System.Drawing.Size(89, 17);
            this.StuckWatch.TabIndex = 38;
            this.StuckWatch.Text = "Stuck Watch";
            this.StuckWatch.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Node Dist.";
            // 
            // NodeDist
            // 
            this.NodeDist.Location = new System.Drawing.Point(159, 30);
            this.NodeDist.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NodeDist.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NodeDist.Name = "NodeDist";
            this.NodeDist.Size = new System.Drawing.Size(37, 20);
            this.NodeDist.TabIndex = 36;
            this.NodeDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NodeDist.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // runReverse
            // 
            this.runReverse.AutoSize = true;
            this.runReverse.Location = new System.Drawing.Point(122, 13);
            this.runReverse.Name = "runReverse";
            this.runReverse.Size = new System.Drawing.Size(79, 17);
            this.runReverse.TabIndex = 35;
            this.runReverse.Text = "run reverse";
            this.runReverse.UseVisualStyleBackColor = true;
            // 
            // Linear
            // 
            this.Linear.AutoSize = true;
            this.Linear.Location = new System.Drawing.Point(16, 29);
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
            this.Circular.Location = new System.Drawing.Point(16, 12);
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
            this.WayPoints.Size = new System.Drawing.Size(425, 173);
            this.WayPoints.TabIndex = 14;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // firstPersonView
            // 
            this.firstPersonView.AutoSize = true;
            this.firstPersonView.Location = new System.Drawing.Point(115, 52);
            this.firstPersonView.Name = "firstPersonView";
            this.firstPersonView.Size = new System.Drawing.Size(81, 17);
            this.firstPersonView.TabIndex = 39;
            this.firstPersonView.Text = "First Person";
            this.firstPersonView.UseVisualStyleBackColor = true;
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
            this.Size = new System.Drawing.Size(445, 349);
            this.Load += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.NodeDist)).EndInit();
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
            isPlaying = true;
            isPaused = false;

            ClearToolStripMenuItem.Enabled = false;
            if (PlayToolStripMenuItem.Enabled == true)
                PlayToolStripMenuItem.Enabled = false;

            if (RecordToolStripMenuItem.Enabled == true)
                RecordToolStripMenuItem.Enabled = false;

            if (PauseToolStripMenuItem.Enabled == false)
                PauseToolStripMenuItem.Enabled = true;

            if (StopToolStripMenuItem.Enabled == false)
                StopToolStripMenuItem.Enabled = true;

            if (!bgw_navi.IsBusy)
                bgw_navi.RunWorkerAsync();
        }

        private void PauseToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            isPaused = true;

            if (StopToolStripMenuItem.Enabled == false)
                StopToolStripMenuItem.Enabled = true;

            if (PauseToolStripMenuItem.Enabled == true)
                PauseToolStripMenuItem.Enabled = false;

            if (ResumeToolStripMenuItem.Enabled == false)
                ResumeToolStripMenuItem.Enabled = true;

            api.AutoFollow.IsAutoFollowing = false;
        }

        private void ResumeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            isPaused = false;

            if (StopToolStripMenuItem.Enabled == false)
                StopToolStripMenuItem.Enabled = true;

            if (ResumeToolStripMenuItem.Enabled == true)
                ResumeToolStripMenuItem.Enabled = false;

            if (PauseToolStripMenuItem.Enabled == false)
                PauseToolStripMenuItem.Enabled = true;

            api.AutoFollow.IsAutoFollowing = false;
        }

        private void StopToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            isRunning = false;
            isRecording = false;
            isPlaying = false;

            if (PlayToolStripMenuItem.Enabled == false)
                PlayToolStripMenuItem.Enabled = true;

            RecordToolStripMenuItem.Enabled = true;
            
            PauseToolStripMenuItem.Enabled = false;

            ResumeToolStripMenuItem.Enabled = false;

            if (StopToolStripMenuItem.Enabled == true)
                StopToolStripMenuItem.Enabled = false;

            if (ClearToolStripMenuItem.Enabled == false)
                ClearToolStripMenuItem.Enabled = true;

            api.AutoFollow.IsAutoFollowing = false;
            bgw_navi.CancelAsync();
        }

        private void ClearToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            lastX = -300;
            lastY = -300;
            lastZ = -300;

            if (WayPoints.Items.Count > 0)
                WayPoints.Items.Clear();
            comboBox2.SelectedText = "";
        }

        private void RecordToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            isRunning = true;
            isRecording = true;
            if (comboBox2.SelectedText != "")
            {
                WayPoints.Items.Clear();
                comboBox2.SelectedText = "";
            }

            if (ClearToolStripMenuItem.Enabled == false)
                ClearToolStripMenuItem.Enabled = true;

            if (RecordToolStripMenuItem.Enabled == true)
                RecordToolStripMenuItem.Enabled = false;

            if (StopToolStripMenuItem.Enabled == false)
                StopToolStripMenuItem.Enabled = true;

            if (!bgw_navi.IsBusy)
                bgw_navi.RunWorkerAsync();
        }
        public bool isStuck(int a)
        {
            if (!api.AutoFollow.IsAutoFollowing || isPaused) return false;
            var x = PlayerInfo.X;
            var z = PlayerInfo.Z;
            var LDistance = api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).Distance;
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
            var CDistance = api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).Distance;
            var Dchange = (Math.Pow(x - PlayerInfo.X, 2) + Math.Pow(z - PlayerInfo.Z, 2));
            if (Math.Abs(Dchange) < 1)
                return true;

            return false;
        }
        public int FindClosestWayPoint()
        {
            var maxRange = 50.0;
            var outRange = -1;
            for (int i = 0; i < navPathX.Count(); i++)
            {
                var x = Math.Pow(PlayerInfo.X - navPathX[i], 2.0);
                var z = Math.Pow(PlayerInfo.Z - navPathZ[i], 2.0);
                var y = Math.Pow(PlayerInfo.Y - navPathY[i], 2.0);
                var dist = (navPathY[i] == 0 ? Math.Sqrt(x + z) : Math.Sqrt(x + z + y));
                if (dist < maxRange)
                {
                    maxRange = dist;
                    outRange = i;
                }
            }
            WayPoints.SelectedIndex = outRange;
            return outRange;
        }

        private System.Windows.Forms.ListBox WayPoints;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NodeDist;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.CheckBox StuckWatch;
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
        public double GetAngleFromPlayer(double x, double z)
        {
            var angleInDegrees = (Math.Atan2(PlayerInfo.Z - z,
                PlayerInfo.X - x) * 180 / Math.PI) * -1;
            return (Math.Floor(angleInDegrees * (10 ^ 0) + 0.5) / (10 ^ 0));
        }

        private System.Windows.Forms.CheckBox firstPersonView;
    }
}
