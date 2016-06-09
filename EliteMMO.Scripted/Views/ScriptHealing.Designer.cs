namespace EliteMMO.Scripted.Views
{
    using API;
    partial class ScriptHealing
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Right);
            this.HealingSupport = new System.Windows.Forms.TabControl();
            this.CC = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown7 = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDown15 = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SB = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.checkBox23 = new System.Windows.Forms.CheckBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.checkBox22 = new System.Windows.Forms.CheckBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.checkBox21 = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.checkedListBox4 = new System.Windows.Forms.CheckedListBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.numericUpDown17 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown18 = new System.Windows.Forms.NumericUpDown();
            this.checkBox52 = new System.Windows.Forms.CheckBox();
            this.checkBox53 = new System.Windows.Forms.CheckBox();
            this.numericUpDown11 = new System.Windows.Forms.NumericUpDown();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.numericUpDown10 = new System.Windows.Forms.NumericUpDown();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.numericUpDown9 = new System.Windows.Forms.NumericUpDown();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.numericUpDown8 = new System.Windows.Forms.NumericUpDown();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.checkedListBox5 = new System.Windows.Forms.CheckedListBox();
            this.menuStrip4 = new System.Windows.Forms.MenuStrip();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.numericUpDown16 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown14 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown13 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown12 = new System.Windows.Forms.NumericUpDown();
            this.checkBox20 = new System.Windows.Forms.CheckBox();
            this.checkBox19 = new System.Windows.Forms.CheckBox();
            this.checkBox18 = new System.Windows.Forms.CheckBox();
            this.checkBox17 = new System.Windows.Forms.CheckBox();
            this.JA = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadJAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearJAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.startScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateJobToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.OffensiveMagic = new System.Windows.Forms.CheckedListBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.addPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPartyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgw_script_cure = new System.ComponentModel.BackgroundWorker();
            this.HealingSupport.SuspendLayout();
            this.CC.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SB.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.menuStrip4.SuspendLayout();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown12)).BeginInit();
            this.JA.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.menuStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // HealingSupport
            // 
            this.HealingSupport.Controls.Add(this.CC);
            this.HealingSupport.Controls.Add(this.SB);
            this.HealingSupport.Controls.Add(this.tabPage2);
            this.HealingSupport.Controls.Add(this.tabPage1);
            this.HealingSupport.Controls.Add(this.JA);
            this.HealingSupport.Location = new System.Drawing.Point(10, 30);
            this.HealingSupport.Name = "HealingSupport";
            this.HealingSupport.SelectedIndex = 0;
            this.HealingSupport.Size = new System.Drawing.Size(362, 352);
            this.HealingSupport.TabIndex = 4;
            // 
            // CC
            // 
            this.CC.Controls.Add(this.groupBox3);
            this.CC.Controls.Add(this.groupBox2);
            this.CC.Controls.Add(this.groupBox1);
            this.CC.Location = new System.Drawing.Point(4, 22);
            this.CC.Name = "CC";
            this.CC.Padding = new System.Windows.Forms.Padding(3);
            this.CC.Size = new System.Drawing.Size(354, 326);
            this.CC.TabIndex = 0;
            this.CC.Text = "Cure/Convert";
            this.CC.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.checkBox10);
            this.groupBox3.Controls.Add(this.checkBox9);
            this.groupBox3.Controls.Add(this.checkBox8);
            this.groupBox3.Location = new System.Drawing.Point(10, 219);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(332, 98);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Self Preservation";
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Location = new System.Drawing.Point(150, 66);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(173, 20);
            this.textBox4.TabIndex = 5;
            this.textBox4.TabStop = false;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Location = new System.Drawing.Point(150, 42);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(173, 20);
            this.textBox3.TabIndex = 4;
            this.textBox3.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Location = new System.Drawing.Point(150, 18);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(173, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.TabStop = false;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(6, 68);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(129, 17);
            this.checkBox10.TabIndex = 2;
            this.checkBox10.TabStop = false;
            this.checkBox10.Text = "On Silenced Use Item";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(6, 44);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(134, 17);
            this.checkBox9.TabIndex = 1;
            this.checkBox9.TabStop = false;
            this.checkBox9.Text = "On Paralyzed Use Item";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(6, 20);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(132, 17);
            this.checkBox8.TabIndex = 0;
            this.checkBox8.TabStop = false;
            this.checkBox8.Text = "On Poisoned Use Item";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.checkBox7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.numericUpDown7);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(160, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(182, 208);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Convert";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 160);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(164, 15);
            this.progressBar1.TabIndex = 6;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Enabled = false;
            this.checkBox7.Location = new System.Drawing.Point(118, 183);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(63, 17);
            this.checkBox7.TabIndex = 5;
            this.checkBox7.TabStop = false;
            this.checkBox7.Text = "Convert";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(60, 184);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "MP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(50, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "%";
            // 
            // numericUpDown7
            // 
            this.numericUpDown7.Enabled = false;
            this.numericUpDown7.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown7.Location = new System.Drawing.Point(9, 180);
            this.numericUpDown7.Name = "numericUpDown7";
            this.numericUpDown7.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown7.TabIndex = 2;
            this.numericUpDown7.TabStop = false;
            this.numericUpDown7.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(9, 43);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(164, 112);
            this.textBox1.TabIndex = 1;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "/ja \"Divine Seal\" <me>\r\n/wait 5\r\n/ja \"Convert\" <me>\r\n/wait 1\r\n/ma \"Cure VI\" <me>";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Convert Commands";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.numericUpDown15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDown6);
            this.groupBox1.Controls.Add(this.numericUpDown5);
            this.groupBox1.Controls.Add(this.numericUpDown4);
            this.groupBox1.Controls.Add(this.numericUpDown3);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.checkBox6);
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 208);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cures";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(118, 184);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "ms";
            // 
            // numericUpDown15
            // 
            this.numericUpDown15.Enabled = false;
            this.numericUpDown15.Location = new System.Drawing.Point(77, 180);
            this.numericUpDown15.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown15.Name = "numericUpDown15";
            this.numericUpDown15.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown15.TabIndex = 19;
            this.numericUpDown15.TabStop = false;
            this.numericUpDown15.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 183);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 18;
            this.label14.Text = "Cast Delay";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(118, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(118, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "%";
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Enabled = false;
            this.numericUpDown6.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown6.Location = new System.Drawing.Point(77, 146);
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown6.TabIndex = 11;
            this.numericUpDown6.TabStop = false;
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Enabled = false;
            this.numericUpDown5.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown5.Location = new System.Drawing.Point(77, 121);
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown5.TabIndex = 10;
            this.numericUpDown5.TabStop = false;
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Enabled = false;
            this.numericUpDown4.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown4.Location = new System.Drawing.Point(77, 96);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown4.TabIndex = 9;
            this.numericUpDown4.TabStop = false;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Enabled = false;
            this.numericUpDown3.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown3.Location = new System.Drawing.Point(77, 71);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown3.TabIndex = 8;
            this.numericUpDown3.TabStop = false;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Enabled = false;
            this.numericUpDown2.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown2.Location = new System.Drawing.Point(77, 46);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown2.TabIndex = 7;
            this.numericUpDown2.TabStop = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(77, 21);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.TabStop = false;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Enabled = false;
            this.checkBox6.Location = new System.Drawing.Point(6, 148);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(61, 17);
            this.checkBox6.TabIndex = 5;
            this.checkBox6.TabStop = false;
            this.checkBox6.Text = "Cure VI";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Enabled = false;
            this.checkBox5.Location = new System.Drawing.Point(6, 123);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(58, 17);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.TabStop = false;
            this.checkBox5.Text = "Cure V";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Enabled = false;
            this.checkBox4.Location = new System.Drawing.Point(6, 98);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(61, 17);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.TabStop = false;
            this.checkBox4.Text = "Cure IV";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Enabled = false;
            this.checkBox3.Location = new System.Drawing.Point(6, 73);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(60, 17);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.TabStop = false;
            this.checkBox3.Text = "Cure III";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(6, 48);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(57, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.TabStop = false;
            this.checkBox2.Text = "Cure II";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(6, 23);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(54, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "Cure I";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // SB
            // 
            this.SB.Controls.Add(this.groupBox6);
            this.SB.Controls.Add(this.groupBox5);
            this.SB.Location = new System.Drawing.Point(4, 22);
            this.SB.Name = "SB";
            this.SB.Padding = new System.Windows.Forms.Padding(3);
            this.SB.Size = new System.Drawing.Size(354, 326);
            this.SB.TabIndex = 1;
            this.SB.Text = "Self/Party Buffs";
            this.SB.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.checkBox23);
            this.groupBox6.Controls.Add(this.textBox8);
            this.groupBox6.Controls.Add(this.checkBox22);
            this.groupBox6.Controls.Add(this.textBox7);
            this.groupBox6.Controls.Add(this.checkBox21);
            this.groupBox6.Location = new System.Drawing.Point(10, 232);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(333, 88);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Other";
            // 
            // checkBox23
            // 
            this.checkBox23.AutoSize = true;
            this.checkBox23.Location = new System.Drawing.Point(10, 65);
            this.checkBox23.Name = "checkBox23";
            this.checkBox23.Size = new System.Drawing.Size(125, 17);
            this.checkBox23.TabIndex = 4;
            this.checkBox23.TabStop = false;
            this.checkBox23.Text = "Auto Heal When Idle";
            this.checkBox23.UseVisualStyleBackColor = true;
            // 
            // textBox8
            // 
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox8.Location = new System.Drawing.Point(134, 40);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(188, 20);
            this.textBox8.TabIndex = 3;
            this.textBox8.TabStop = false;
            // 
            // checkBox22
            // 
            this.checkBox22.AutoSize = true;
            this.checkBox22.Location = new System.Drawing.Point(10, 40);
            this.checkBox22.Name = "checkBox22";
            this.checkBox22.Size = new System.Drawing.Size(72, 17);
            this.checkBox22.TabIndex = 2;
            this.checkBox22.TabStop = false;
            this.checkBox22.Text = "Use Food";
            this.checkBox22.UseVisualStyleBackColor = true;
            // 
            // textBox7
            // 
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox7.Location = new System.Drawing.Point(134, 18);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(188, 20);
            this.textBox7.TabIndex = 1;
            this.textBox7.TabStop = false;
            // 
            // checkBox21
            // 
            this.checkBox21.AutoSize = true;
            this.checkBox21.Location = new System.Drawing.Point(10, 19);
            this.checkBox21.Name = "checkBox21";
            this.checkBox21.Size = new System.Drawing.Size(118, 17);
            this.checkBox21.TabIndex = 0;
            this.checkBox21.TabStop = false;
            this.checkBox21.Text = "On Heal Equip Item";
            this.checkBox21.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox10);
            this.groupBox5.Controls.Add(this.groupBox7);
            this.groupBox5.Controls.Add(this.numericUpDown17);
            this.groupBox5.Controls.Add(this.numericUpDown18);
            this.groupBox5.Controls.Add(this.checkBox52);
            this.groupBox5.Controls.Add(this.checkBox53);
            this.groupBox5.Controls.Add(this.numericUpDown11);
            this.groupBox5.Controls.Add(this.checkBox14);
            this.groupBox5.Controls.Add(this.numericUpDown10);
            this.groupBox5.Controls.Add(this.checkBox13);
            this.groupBox5.Controls.Add(this.numericUpDown9);
            this.groupBox5.Controls.Add(this.checkBox12);
            this.groupBox5.Controls.Add(this.numericUpDown8);
            this.groupBox5.Controls.Add(this.checkBox11);
            this.groupBox5.Location = new System.Drawing.Point(10, 10);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(333, 220);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Self/Party Buffs";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.checkBox15);
            this.groupBox10.Controls.Add(this.checkedListBox4);
            this.groupBox10.Location = new System.Drawing.Point(175, 102);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(152, 110);
            this.groupBox10.TabIndex = 29;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Remove Effects";
            // 
            // checkBox15
            // 
            this.checkBox15.AutoSize = true;
            this.checkBox15.Location = new System.Drawing.Point(6, 145);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(125, 17);
            this.checkBox15.TabIndex = 1;
            this.checkBox15.Text = "Select/Deselect ALL";
            this.checkBox15.UseVisualStyleBackColor = false;
            // 
            // checkedListBox4
            // 
            this.checkedListBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox4.FormattingEnabled = true;
            this.checkedListBox4.Items.AddRange(new object[] {
            "ACC Down",
            "AGI Down",
            "ATT Down",
            "Bane",
            "Bind",
            "Bio",
            "Blind",
            "Burn",
            "Choke",
            "CHR Down",
            "Curse",
            "DEF Down",
            "DEX Down",
            "Dia",
            "Disease",
            "Drown",
            "EVA Down",
            "Frost",
            "Gravity",
            "Helix",
            "HP Down",
            "INT Down",
            "MACC Down",
            "MATT Down",
            "MDEF Down",
            "MEVA Down",
            "MND Down",
            "MP Down",
            "Paralyze",
            "Plague",
            "Poison",
            "Rasp",
            "Shock",
            "Silence",
            "Sleep (wake up)",
            "Slow",
            "STR Down",
            "TP Down",
            "VIT Down"});
            this.checkedListBox4.Location = new System.Drawing.Point(3, 16);
            this.checkedListBox4.Name = "checkedListBox4";
            this.checkedListBox4.Size = new System.Drawing.Size(146, 91);
            this.checkedListBox4.Sorted = true;
            this.checkedListBox4.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.checkedListBox2);
            this.groupBox7.Location = new System.Drawing.Point(6, 102);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(152, 110);
            this.groupBox7.TabIndex = 28;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Self Buffs";
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Items.AddRange(new object[] {
            "A. Solace",
            "Aquaveil",
            "Blink",
            "Composure",
            "Haste",
            "Stoneskin"});
            this.checkedListBox2.Location = new System.Drawing.Point(3, 16);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(146, 91);
            this.checkedListBox2.Sorted = true;
            this.checkedListBox2.TabIndex = 0;
            // 
            // numericUpDown17
            // 
            this.numericUpDown17.Enabled = false;
            this.numericUpDown17.Location = new System.Drawing.Point(284, 46);
            this.numericUpDown17.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown17.Name = "numericUpDown17";
            this.numericUpDown17.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown17.TabIndex = 18;
            this.numericUpDown17.TabStop = false;
            // 
            // numericUpDown18
            // 
            this.numericUpDown18.Enabled = false;
            this.numericUpDown18.Location = new System.Drawing.Point(284, 21);
            this.numericUpDown18.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown18.Name = "numericUpDown18";
            this.numericUpDown18.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown18.TabIndex = 17;
            this.numericUpDown18.TabStop = false;
            // 
            // checkBox52
            // 
            this.checkBox52.AutoSize = true;
            this.checkBox52.Enabled = false;
            this.checkBox52.Location = new System.Drawing.Point(214, 48);
            this.checkBox52.Name = "checkBox52";
            this.checkBox52.Size = new System.Drawing.Size(58, 17);
            this.checkBox52.TabIndex = 15;
            this.checkBox52.TabStop = false;
            this.checkBox52.Text = "Shellra";
            this.checkBox52.UseVisualStyleBackColor = true;
            // 
            // checkBox53
            // 
            this.checkBox53.AutoSize = true;
            this.checkBox53.Enabled = false;
            this.checkBox53.Location = new System.Drawing.Point(214, 22);
            this.checkBox53.Name = "checkBox53";
            this.checkBox53.Size = new System.Drawing.Size(69, 17);
            this.checkBox53.TabIndex = 14;
            this.checkBox53.TabStop = false;
            this.checkBox53.Text = "Protectra";
            this.checkBox53.UseVisualStyleBackColor = true;
            // 
            // numericUpDown11
            // 
            this.numericUpDown11.Enabled = false;
            this.numericUpDown11.Location = new System.Drawing.Point(284, 71);
            this.numericUpDown11.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown11.Name = "numericUpDown11";
            this.numericUpDown11.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown11.TabIndex = 7;
            this.numericUpDown11.TabStop = false;
            // 
            // checkBox14
            // 
            this.checkBox14.AutoSize = true;
            this.checkBox14.Enabled = false;
            this.checkBox14.Location = new System.Drawing.Point(214, 73);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(63, 17);
            this.checkBox14.TabIndex = 6;
            this.checkBox14.TabStop = false;
            this.checkBox14.Text = "Refresh";
            this.checkBox14.UseVisualStyleBackColor = true;
            // 
            // numericUpDown10
            // 
            this.numericUpDown10.Enabled = false;
            this.numericUpDown10.Location = new System.Drawing.Point(77, 46);
            this.numericUpDown10.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown10.Name = "numericUpDown10";
            this.numericUpDown10.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown10.TabIndex = 5;
            this.numericUpDown10.TabStop = false;
            // 
            // checkBox13
            // 
            this.checkBox13.AutoSize = true;
            this.checkBox13.Enabled = false;
            this.checkBox13.Location = new System.Drawing.Point(10, 48);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(62, 17);
            this.checkBox13.TabIndex = 4;
            this.checkBox13.TabStop = false;
            this.checkBox13.Text = "Reraise";
            this.checkBox13.UseVisualStyleBackColor = true;
            // 
            // numericUpDown9
            // 
            this.numericUpDown9.Enabled = false;
            this.numericUpDown9.Location = new System.Drawing.Point(77, 71);
            this.numericUpDown9.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown9.Name = "numericUpDown9";
            this.numericUpDown9.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown9.TabIndex = 3;
            this.numericUpDown9.TabStop = false;
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Enabled = false;
            this.checkBox12.Location = new System.Drawing.Point(10, 73);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(58, 17);
            this.checkBox12.TabIndex = 2;
            this.checkBox12.TabStop = false;
            this.checkBox12.Text = "Regen";
            this.checkBox12.UseVisualStyleBackColor = true;
            // 
            // numericUpDown8
            // 
            this.numericUpDown8.Enabled = false;
            this.numericUpDown8.Location = new System.Drawing.Point(77, 21);
            this.numericUpDown8.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown8.Name = "numericUpDown8";
            this.numericUpDown8.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown8.TabIndex = 1;
            this.numericUpDown8.TabStop = false;
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Enabled = false;
            this.checkBox11.Location = new System.Drawing.Point(10, 22);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(64, 17);
            this.checkBox11.TabIndex = 0;
            this.checkBox11.TabStop = false;
            this.checkBox11.Text = "Phalanx";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(354, 326);
            this.tabPage2.TabIndex = 5;
            this.tabPage2.Text = "SCH";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox12);
            this.tabPage1.Controls.Add(this.groupBox11);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(354, 326);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "BRD";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.checkedListBox5);
            this.groupBox12.Controls.Add(this.menuStrip4);
            this.groupBox12.Location = new System.Drawing.Point(14, 90);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(326, 222);
            this.groupBox12.TabIndex = 1;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Bard Songs";
            // 
            // checkedListBox5
            // 
            this.checkedListBox5.FormattingEnabled = true;
            this.checkedListBox5.Location = new System.Drawing.Point(85, 16);
            this.checkedListBox5.Name = "checkedListBox5";
            this.checkedListBox5.Size = new System.Drawing.Size(156, 169);
            this.checkedListBox5.TabIndex = 1;
            // 
            // menuStrip4
            // 
            this.menuStrip4.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.menuStrip4.Location = new System.Drawing.Point(114, 192);
            this.menuStrip4.Name = "menuStrip4";
            this.menuStrip4.Size = new System.Drawing.Size(99, 24);
            this.menuStrip4.TabIndex = 2;
            this.menuStrip4.Text = "menuStrip4";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.clearToolStripMenuItem.Text = "Clear";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.numericUpDown16);
            this.groupBox11.Controls.Add(this.numericUpDown14);
            this.groupBox11.Controls.Add(this.numericUpDown13);
            this.groupBox11.Controls.Add(this.numericUpDown12);
            this.groupBox11.Controls.Add(this.checkBox20);
            this.groupBox11.Controls.Add(this.checkBox19);
            this.groupBox11.Controls.Add(this.checkBox18);
            this.groupBox11.Controls.Add(this.checkBox17);
            this.groupBox11.Location = new System.Drawing.Point(14, 10);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(326, 73);
            this.groupBox11.TabIndex = 0;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Bard Songs";
            // 
            // numericUpDown16
            // 
            this.numericUpDown16.Enabled = false;
            this.numericUpDown16.Location = new System.Drawing.Point(278, 41);
            this.numericUpDown16.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown16.Name = "numericUpDown16";
            this.numericUpDown16.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown16.TabIndex = 7;
            this.numericUpDown16.TabStop = false;
            // 
            // numericUpDown14
            // 
            this.numericUpDown14.Enabled = false;
            this.numericUpDown14.Location = new System.Drawing.Point(278, 17);
            this.numericUpDown14.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown14.Name = "numericUpDown14";
            this.numericUpDown14.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown14.TabIndex = 6;
            this.numericUpDown14.TabStop = false;
            // 
            // numericUpDown13
            // 
            this.numericUpDown13.Enabled = false;
            this.numericUpDown13.Location = new System.Drawing.Point(108, 42);
            this.numericUpDown13.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown13.Name = "numericUpDown13";
            this.numericUpDown13.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown13.TabIndex = 5;
            this.numericUpDown13.TabStop = false;
            // 
            // numericUpDown12
            // 
            this.numericUpDown12.Enabled = false;
            this.numericUpDown12.Location = new System.Drawing.Point(108, 18);
            this.numericUpDown12.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown12.Name = "numericUpDown12";
            this.numericUpDown12.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown12.TabIndex = 4;
            this.numericUpDown12.TabStop = false;
            // 
            // checkBox20
            // 
            this.checkBox20.AutoSize = true;
            this.checkBox20.Location = new System.Drawing.Point(178, 44);
            this.checkBox20.Name = "checkBox20";
            this.checkBox20.Size = new System.Drawing.Size(95, 17);
            this.checkBox20.TabIndex = 3;
            this.checkBox20.Text = "Knight\'s Minne";
            this.checkBox20.UseVisualStyleBackColor = true;
            // 
            // checkBox19
            // 
            this.checkBox19.AutoSize = true;
            this.checkBox19.Location = new System.Drawing.Point(178, 20);
            this.checkBox19.Name = "checkBox19";
            this.checkBox19.Size = new System.Drawing.Size(85, 17);
            this.checkBox19.TabIndex = 2;
            this.checkBox19.Text = "Valor Minuet";
            this.checkBox19.UseVisualStyleBackColor = true;
            // 
            // checkBox18
            // 
            this.checkBox18.AutoSize = true;
            this.checkBox18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox18.Location = new System.Drawing.Point(10, 44);
            this.checkBox18.Name = "checkBox18";
            this.checkBox18.Size = new System.Drawing.Size(90, 17);
            this.checkBox18.TabIndex = 1;
            this.checkBox18.Text = "Army\'s Paeon";
            this.checkBox18.UseVisualStyleBackColor = true;
            // 
            // checkBox17
            // 
            this.checkBox17.AutoSize = true;
            this.checkBox17.Location = new System.Drawing.Point(10, 20);
            this.checkBox17.Name = "checkBox17";
            this.checkBox17.Size = new System.Drawing.Size(92, 17);
            this.checkBox17.TabIndex = 0;
            this.checkBox17.Text = "Mage\'s Ballad";
            this.checkBox17.UseVisualStyleBackColor = true;
            // 
            // JA
            // 
            this.JA.Controls.Add(this.menuStrip1);
            this.JA.Controls.Add(this.groupBox9);
            this.JA.Location = new System.Drawing.Point(4, 22);
            this.JA.Name = "JA";
            this.JA.Padding = new System.Windows.Forms.Padding(3);
            this.JA.Size = new System.Drawing.Size(354, 326);
            this.JA.TabIndex = 3;
            this.JA.Text = "JA\'s";
            this.JA.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadJAsToolStripMenuItem,
            this.clearJAsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(106, 289);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(145, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadJAsToolStripMenuItem
            // 
            this.loadJAsToolStripMenuItem.Name = "loadJAsToolStripMenuItem";
            this.loadJAsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.loadJAsToolStripMenuItem.Text = "Load JA\'s";
            // 
            // clearJAsToolStripMenuItem
            // 
            this.clearJAsToolStripMenuItem.Name = "clearJAsToolStripMenuItem";
            this.clearJAsToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.clearJAsToolStripMenuItem.Text = "Clear JA\'s";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.checkedListBox1);
            this.groupBox9.Location = new System.Drawing.Point(7, 10);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(340, 276);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Job Abilities";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(80, 19);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(184, 244);
            this.checkedListBox1.TabIndex = 0;
            // 
            // menuStrip2
            // 
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startScriptToolStripMenuItem,
            this.stopScriptToolStripMenuItem,
            this.updateJobToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(380, 358);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(238, 24);
            this.menuStrip2.TabIndex = 14;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // startScriptToolStripMenuItem
            // 
            this.startScriptToolStripMenuItem.Name = "startScriptToolStripMenuItem";
            this.startScriptToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.startScriptToolStripMenuItem.Text = "Start Script";
            // 
            // stopScriptToolStripMenuItem
            // 
            this.stopScriptToolStripMenuItem.Enabled = false;
            this.stopScriptToolStripMenuItem.Name = "stopScriptToolStripMenuItem";
            this.stopScriptToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.stopScriptToolStripMenuItem.Text = "Stop Script";
            // 
            // updateJobToolStripMenuItem
            // 
            this.updateJobToolStripMenuItem.Name = "updateJobToolStripMenuItem";
            this.updateJobToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.updateJobToolStripMenuItem.Text = "Update Job";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox16);
            this.groupBox4.Controls.Add(this.groupBox8);
            this.groupBox4.Controls.Add(this.listView1);
            this.groupBox4.Controls.Add(this.textBox6);
            this.groupBox4.Controls.Add(this.menuStrip3);
            this.groupBox4.Location = new System.Drawing.Point(378, 30);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(252, 323);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Options";
            // 
            // checkBox16
            // 
            this.checkBox16.AutoSize = true;
            this.checkBox16.Location = new System.Drawing.Point(172, 202);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(72, 17);
            this.checkBox16.TabIndex = 17;
            this.checkBox16.Text = "auto raise";
            this.checkBox16.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.OffensiveMagic);
            this.groupBox8.Location = new System.Drawing.Point(8, 224);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(236, 93);
            this.groupBox8.TabIndex = 15;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Offensive Magic";
            // 
            // OffensiveMagic
            // 
            this.OffensiveMagic.BackColor = System.Drawing.SystemColors.Control;
            this.OffensiveMagic.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OffensiveMagic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OffensiveMagic.FormattingEnabled = true;
            this.OffensiveMagic.Location = new System.Drawing.Point(3, 16);
            this.OffensiveMagic.Name = "OffensiveMagic";
            this.OffensiveMagic.Size = new System.Drawing.Size(230, 74);
            this.OffensiveMagic.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colStatus});
            this.listView1.FullRowSelect = true;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "listViewGroup1";
            listViewGroup2.Header = "ListViewGroup";
            listViewGroup2.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            listViewGroup2.Name = "listViewGroup2";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.Location = new System.Drawing.Point(8, 16);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(236, 156);
            this.listView1.TabIndex = 14;
            this.listView1.TabStop = false;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "player";
            this.colName.Width = 168;
            // 
            // colStatus
            // 
            this.colStatus.Text = "HP %";
            this.colStatus.Width = 54;
            // 
            // textBox6
            // 
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(8, 177);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(236, 20);
            this.textBox6.TabIndex = 11;
            this.textBox6.TabStop = false;
            // 
            // menuStrip3
            // 
            this.menuStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPlayerToolStripMenuItem,
            this.addPartyToolStripMenuItem});
            this.menuStrip3.Location = new System.Drawing.Point(2, 197);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Size = new System.Drawing.Size(151, 24);
            this.menuStrip3.TabIndex = 16;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // addPlayerToolStripMenuItem
            // 
            this.addPlayerToolStripMenuItem.Name = "addPlayerToolStripMenuItem";
            this.addPlayerToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.addPlayerToolStripMenuItem.Text = "add player";
            // 
            // addPartyToolStripMenuItem
            // 
            this.addPartyToolStripMenuItem.Name = "addPartyToolStripMenuItem";
            this.addPartyToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.addPartyToolStripMenuItem.Text = "add party";
            // 
            // bgw_script_cure
            // 
            this.bgw_script_cure.WorkerReportsProgress = true;
            this.bgw_script_cure.WorkerSupportsCancellation = true;
            // 
            // ScriptHealing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.HealingSupport);
            this.Name = "ScriptHealing";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 5, 25);
            this.Size = new System.Drawing.Size(638, 410);
            this.HealingSupport.ResumeLayout(false);
            this.CC.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.SB.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.menuStrip4.ResumeLayout(false);
            this.menuStrip4.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown12)).EndInit();
            this.JA.ResumeLayout(false);
            this.JA.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public System.Windows.Forms.TabControl HealingSupport;
        public System.Windows.Forms.TabPage CC;
        public System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.TextBox textBox4;
        public System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.CheckBox checkBox10;
        public System.Windows.Forms.CheckBox checkBox9;
        public System.Windows.Forms.CheckBox checkBox8;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.CheckBox checkBox7;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.NumericUpDown numericUpDown7;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.NumericUpDown numericUpDown15;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown numericUpDown6;
        public System.Windows.Forms.NumericUpDown numericUpDown5;
        public System.Windows.Forms.NumericUpDown numericUpDown4;
        public System.Windows.Forms.NumericUpDown numericUpDown3;
        public System.Windows.Forms.NumericUpDown numericUpDown2;
        public System.Windows.Forms.NumericUpDown numericUpDown1;
        public System.Windows.Forms.CheckBox checkBox6;
        public System.Windows.Forms.CheckBox checkBox5;
        public System.Windows.Forms.CheckBox checkBox4;
        public System.Windows.Forms.CheckBox checkBox3;
        public System.Windows.Forms.CheckBox checkBox2;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.TabPage SB;
        public System.Windows.Forms.GroupBox groupBox6;
        public System.Windows.Forms.CheckBox checkBox23;
        public System.Windows.Forms.TextBox textBox8;
        public System.Windows.Forms.CheckBox checkBox22;
        public System.Windows.Forms.TextBox textBox7;
        public System.Windows.Forms.CheckBox checkBox21;
        public System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.GroupBox groupBox10;
        public System.Windows.Forms.CheckBox checkBox15;
        public System.Windows.Forms.CheckedListBox checkedListBox4;
        public System.Windows.Forms.GroupBox groupBox7;
        public System.Windows.Forms.CheckedListBox checkedListBox2;
        public System.Windows.Forms.NumericUpDown numericUpDown17;
        public System.Windows.Forms.NumericUpDown numericUpDown18;
        public System.Windows.Forms.CheckBox checkBox52;
        public System.Windows.Forms.CheckBox checkBox53;
        public System.Windows.Forms.NumericUpDown numericUpDown11;
        public System.Windows.Forms.CheckBox checkBox14;
        public System.Windows.Forms.NumericUpDown numericUpDown10;
        public System.Windows.Forms.CheckBox checkBox13;
        public System.Windows.Forms.NumericUpDown numericUpDown9;
        public System.Windows.Forms.CheckBox checkBox12;
        public System.Windows.Forms.NumericUpDown numericUpDown8;
        public System.Windows.Forms.CheckBox checkBox11;
        public System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.GroupBox groupBox12;
        public System.Windows.Forms.CheckedListBox checkedListBox5;
        public System.Windows.Forms.MenuStrip menuStrip4;
        public System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        public System.Windows.Forms.GroupBox groupBox11;
        public System.Windows.Forms.NumericUpDown numericUpDown16;
        public System.Windows.Forms.NumericUpDown numericUpDown14;
        public System.Windows.Forms.NumericUpDown numericUpDown13;
        public System.Windows.Forms.NumericUpDown numericUpDown12;
        public System.Windows.Forms.CheckBox checkBox20;
        public System.Windows.Forms.CheckBox checkBox19;
        public System.Windows.Forms.CheckBox checkBox18;
        public System.Windows.Forms.CheckBox checkBox17;
        public System.Windows.Forms.TabPage JA;
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem loadJAsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem clearJAsToolStripMenuItem;
        public System.Windows.Forms.GroupBox groupBox9;
        public System.Windows.Forms.CheckedListBox checkedListBox1;
        public System.Windows.Forms.MenuStrip menuStrip2;
        public System.Windows.Forms.ToolStripMenuItem startScriptToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem stopScriptToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem updateJobToolStripMenuItem;
        public System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.CheckBox checkBox16;
        public System.Windows.Forms.GroupBox groupBox8;
        public System.Windows.Forms.CheckedListBox OffensiveMagic;
        public System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.ColumnHeader colName;
        public System.Windows.Forms.ColumnHeader colStatus;
        public System.Windows.Forms.TextBox textBox6;
        public System.Windows.Forms.MenuStrip menuStrip3;
        public System.Windows.Forms.ToolStripMenuItem addPlayerToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem addPartyToolStripMenuItem;
        public System.ComponentModel.BackgroundWorker bgw_script_cure;
        #endregion

    }
}
