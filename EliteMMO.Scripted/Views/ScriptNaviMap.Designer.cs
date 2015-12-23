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

        public double[] navPathX = new double[1];
        public double[] navPathZ = new double[1];
        public double[] navPathY = new double[1];
        public bool[] navPathfirst = new bool[1];
        public string[] navPathdoor = new string[1];
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
            this.removeNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.menuStrip5 = new System.Windows.Forms.MenuStrip();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConvertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgw_navi = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.firstPersonView = new System.Windows.Forms.CheckBox();
            this.StuckWatch = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NodeDist = new System.Windows.Forms.NumericUpDown();
            this.runReverse = new System.Windows.Forms.CheckBox();
            this.Linear = new System.Windows.Forms.RadioButton();
            this.Circular = new System.Windows.Forms.RadioButton();
            this.WayPoints = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.FirstPerson = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AddNode = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.EnableForceSave = new System.Windows.Forms.CheckBox();
            this.ForceLinear = new System.Windows.Forms.RadioButton();
            this.ForceCircular = new System.Windows.Forms.RadioButton();
            this.groupBox9.SuspendLayout();
            this.menuStrip4.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.menuStrip5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NodeDist)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.menuStrip4);
            this.groupBox9.Location = new System.Drawing.Point(10, 208);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(422, 51);
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
            this.RecordToolStripMenuItem,
            this.removeNodeToolStripMenuItem});
            this.menuStrip4.Location = new System.Drawing.Point(3, 16);
            this.menuStrip4.Name = "menuStrip4";
            this.menuStrip4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip4.Size = new System.Drawing.Size(416, 24);
            this.menuStrip4.Stretch = false;
            this.menuStrip4.TabIndex = 0;
            this.menuStrip4.Text = "menuStrip4";
            // 
            // PlayToolStripMenuItem
            // 
            this.PlayToolStripMenuItem.Name = "PlayToolStripMenuItem";
            this.PlayToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.PlayToolStripMenuItem.Text = "Play";
            this.PlayToolStripMenuItem.Click += new System.EventHandler(this.PlayToolStripMenuItem_Click);
            // 
            // PauseToolStripMenuItem
            // 
            this.PauseToolStripMenuItem.Enabled = false;
            this.PauseToolStripMenuItem.Name = "PauseToolStripMenuItem";
            this.PauseToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.PauseToolStripMenuItem.Text = "Pause";
            this.PauseToolStripMenuItem.Click += new System.EventHandler(this.PauseToolStripMenuItem_Click);
            // 
            // ResumeToolStripMenuItem
            // 
            this.ResumeToolStripMenuItem.Enabled = false;
            this.ResumeToolStripMenuItem.Name = "ResumeToolStripMenuItem";
            this.ResumeToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.ResumeToolStripMenuItem.Text = "Resume";
            this.ResumeToolStripMenuItem.Click += new System.EventHandler(this.ResumeToolStripMenuItem_Click);
            // 
            // StopToolStripMenuItem
            // 
            this.StopToolStripMenuItem.Enabled = false;
            this.StopToolStripMenuItem.Name = "StopToolStripMenuItem";
            this.StopToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.StopToolStripMenuItem.Text = "Stop";
            this.StopToolStripMenuItem.Click += new System.EventHandler(this.StopToolStripMenuItem_Click);
            // 
            // ClearToolStripMenuItem
            // 
            this.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem";
            this.ClearToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.ClearToolStripMenuItem.Text = "Clear";
            this.ClearToolStripMenuItem.Click += new System.EventHandler(this.ClearToolStripMenuItem_Click);
            // 
            // RecordToolStripMenuItem
            // 
            this.RecordToolStripMenuItem.Name = "RecordToolStripMenuItem";
            this.RecordToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.RecordToolStripMenuItem.Text = "Record";
            this.RecordToolStripMenuItem.Click += new System.EventHandler(this.RecordToolStripMenuItemClick);
            // 
            // removeNodeToolStripMenuItem
            // 
            this.removeNodeToolStripMenuItem.Name = "removeNodeToolStripMenuItem";
            this.removeNodeToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.removeNodeToolStripMenuItem.Text = "Remove Node(s)";
            this.removeNodeToolStripMenuItem.Click += new System.EventHandler(this.removeNodeToolStripMenuItem_Click);
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
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.SaveToolStripMenuItem.Text = "Save";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // RefreshToolStripMenuItem
            // 
            this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            this.RefreshToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.RefreshToolStripMenuItem.Text = "Refresh";
            this.RefreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // ConvertToolStripMenuItem
            // 
            this.ConvertToolStripMenuItem.Name = "ConvertToolStripMenuItem";
            this.ConvertToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.ConvertToolStripMenuItem.Text = "Convert";
            this.ConvertToolStripMenuItem.Click += new System.EventHandler(this.ConvertToolStripMenuItem_Click);
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
            this.runReverse.Location = new System.Drawing.Point(115, 13);
            this.runReverse.Name = "runReverse";
            this.runReverse.Size = new System.Drawing.Size(89, 17);
            this.runReverse.TabIndex = 35;
            this.runReverse.Text = "Run Reverse";
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
            this.WayPoints.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.WayPoints.Size = new System.Drawing.Size(422, 173);
            this.WayPoints.TabIndex = 14;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // FirstPerson
            // 
            this.FirstPerson.Location = new System.Drawing.Point(41, 60);
            this.FirstPerson.Name = "FirstPerson";
            this.FirstPerson.Size = new System.Drawing.Size(42, 23);
            this.FirstPerson.TabIndex = 15;
            this.FirstPerson.Text = "Set";
            this.FirstPerson.UseVisualStyleBackColor = true;
            this.FirstPerson.Click += new System.EventHandler(this.First_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Set selected node(s)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "to use first person";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Door_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "To add a door in your ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "nav file target the";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "door and click add.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "view click set.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AddNode);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.FirstPerson);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(441, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(124, 205);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Extra Commands";
            // 
            // AddNode
            // 
            this.AddNode.Location = new System.Drawing.Point(25, 170);
            this.AddNode.Name = "AddNode";
            this.AddNode.Size = new System.Drawing.Size(75, 23);
            this.AddNode.TabIndex = 24;
            this.AddNode.Text = "Add node";
            this.AddNode.UseVisualStyleBackColor = true;
            this.AddNode.Click += new System.EventHandler(this.AddNode_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Add new node.";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.EnableForceSave);
            this.groupBox3.Controls.Add(this.ForceLinear);
            this.groupBox3.Controls.Add(this.ForceCircular);
            this.groupBox3.Location = new System.Drawing.Point(441, 265);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(106, 74);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Save Force";
            // 
            // EnableForceSave
            // 
            this.EnableForceSave.AutoSize = true;
            this.EnableForceSave.Location = new System.Drawing.Point(6, 18);
            this.EnableForceSave.Name = "EnableForceSave";
            this.EnableForceSave.Size = new System.Drawing.Size(59, 17);
            this.EnableForceSave.TabIndex = 2;
            this.EnableForceSave.Text = "Enable";
            this.EnableForceSave.UseVisualStyleBackColor = true;
            this.EnableForceSave.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ForceLinear
            // 
            this.ForceLinear.AutoSize = true;
            this.ForceLinear.Enabled = false;
            this.ForceLinear.Location = new System.Drawing.Point(6, 51);
            this.ForceLinear.Name = "ForceLinear";
            this.ForceLinear.Size = new System.Drawing.Size(84, 17);
            this.ForceLinear.TabIndex = 1;
            this.ForceLinear.Text = "Force Linear";
            this.ForceLinear.UseVisualStyleBackColor = true;
            // 
            // ForceCircular
            // 
            this.ForceCircular.AutoSize = true;
            this.ForceCircular.Checked = true;
            this.ForceCircular.Enabled = false;
            this.ForceCircular.Location = new System.Drawing.Point(6, 33);
            this.ForceCircular.Name = "ForceCircular";
            this.ForceCircular.Size = new System.Drawing.Size(90, 17);
            this.ForceCircular.TabIndex = 0;
            this.ForceCircular.TabStop = true;
            this.ForceCircular.Text = "Force Circular";
            this.ForceCircular.UseVisualStyleBackColor = true;
            // 
            // ScriptNaviMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.WayPoints);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox9);
            this.Name = "ScriptNaviMap";
            this.Size = new System.Drawing.Size(568, 349);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
            if (WayPoints.Items.Count > 0)
                WayPoints.Items.Clear();
            comboBox2.SelectedText = "";

            if (isRecording)
                WayPoints.Items.Add($"WAYPOINT:{PlayerInfo.X}:{PlayerInfo.Z}:{PlayerInfo.Y}");
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

            WayPoints.Items.Add($"WAYPOINT:{PlayerInfo.X}:{PlayerInfo.Z}:{PlayerInfo.Y}");

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
            WayPoints.SelectedIndices.Clear();
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
        public static class TargetInfo
        {
            public static int ID => (int)api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).TargetID;
            public static void SetTarget(int ID) => api.Target.SetTarget(ID);
            public static bool LockedOn => api.Target.GetTargetInfo().LockedOn;
            public static double Distance => Math.Truncate((10 * api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).Distance) / 10);
        }

        private System.Windows.Forms.CheckBox firstPersonView;
        private System.Windows.Forms.Button FirstPerson;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem removeNodeToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox EnableForceSave;
        private System.Windows.Forms.RadioButton ForceLinear;
        private System.Windows.Forms.RadioButton ForceCircular;
        private System.Windows.Forms.Button AddNode;
        private System.Windows.Forms.Label label8;
    }
}
