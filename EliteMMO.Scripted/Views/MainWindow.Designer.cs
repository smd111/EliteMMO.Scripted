namespace EliteMMO.Scripted.Views
{
    using API;
    using System.Windows.Forms;
    partial class MainWindow
    {
        private EliteAPI api;
        public static bool TESTMODE = true;
        private readonly UserControl x1;
        private readonly UserControl x2;
        private readonly UserControl x3;
        private readonly UserControl x4;
        private readonly UserControl x5;
        public static string STATUS = "";
        public string TopMostDisplay = "Main";
        public static string windowername = "Windower";
        public string dlllocation = "";
        public bool hudactive = false;
        public bool extenderactive = false;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.xmenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshCharactersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.farmDNCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.healingSupportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skillupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.synergyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buySellTradeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navigationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.questsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.melyonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shamiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sparksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zaldonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stayOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToSysTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableMaintenanceModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fAQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xstatus = new System.Windows.Forms.StatusStrip();
            this.xStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.header2 = new System.Windows.Forms.Label();
            this.header1 = new System.Windows.Forms.Label();
            this.xpic = new System.Windows.Forms.PictureBox();
            this.EliteMMO_PROC = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.header5 = new System.Windows.Forms.Label();
            this.header3 = new System.Windows.Forms.Label();
            this.header4 = new System.Windows.Forms.Label();
            this.xmenu.SuspendLayout();
            this.xstatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpic)).BeginInit();
            this.SuspendLayout();
            // 
            // xmenu
            // 
            this.xmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.xmenu.Location = new System.Drawing.Point(0, 0);
            this.xmenu.Name = "xmenu";
            this.xmenu.Size = new System.Drawing.Size(366, 24);
            this.xmenu.TabIndex = 2;
            this.xmenu.Text = "xmenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadSettingsToolStripMenuItem,
            this.saveSettingsToolStripMenuItem,
            this.resetSettingsToolStripMenuItem,
            this.refreshCharactersToolStripMenuItem,
            this.closeExitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadSettingsToolStripMenuItem
            // 
            this.loadSettingsToolStripMenuItem.Enabled = false;
            this.loadSettingsToolStripMenuItem.Name = "loadSettingsToolStripMenuItem";
            this.loadSettingsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.loadSettingsToolStripMenuItem.Text = "Load Settings";
            this.loadSettingsToolStripMenuItem.Click += new System.EventHandler(this.loadSettingsToolStripMenuItem_Click);
            // 
            // saveSettingsToolStripMenuItem
            // 
            this.saveSettingsToolStripMenuItem.Enabled = false;
            this.saveSettingsToolStripMenuItem.Name = "saveSettingsToolStripMenuItem";
            this.saveSettingsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.saveSettingsToolStripMenuItem.Text = "Save Settings";
            this.saveSettingsToolStripMenuItem.Click += new System.EventHandler(this.saveSettingsToolStripMenuItem_Click);
            // 
            // resetSettingsToolStripMenuItem
            // 
            this.resetSettingsToolStripMenuItem.Enabled = false;
            this.resetSettingsToolStripMenuItem.Name = "resetSettingsToolStripMenuItem";
            this.resetSettingsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.resetSettingsToolStripMenuItem.Text = "Reset Settings";
            // 
            // refreshCharactersToolStripMenuItem
            // 
            this.refreshCharactersToolStripMenuItem.Name = "refreshCharactersToolStripMenuItem";
            this.refreshCharactersToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.refreshCharactersToolStripMenuItem.Text = "Refresh Characters";
            this.refreshCharactersToolStripMenuItem.Click += new System.EventHandler(this.RefreshCharactersToolStripMenuItemClick);
            // 
            // closeExitToolStripMenuItem
            // 
            this.closeExitToolStripMenuItem.Name = "closeExitToolStripMenuItem";
            this.closeExitToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.closeExitToolStripMenuItem.Text = "Close/Exit";
            this.closeExitToolStripMenuItem.Click += new System.EventHandler(this.CloseExitToolStripMenuItemClick);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scriptsToolStripMenuItem,
            this.questsToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.releasToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // scriptsToolStripMenuItem
            // 
            this.scriptsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.farmDNCToolStripMenuItem,
            this.healingSupportToolStripMenuItem,
            this.skillupToolStripMenuItem,
            this.synergyToolStripMenuItem,
            this.buySellTradeToolStripMenuItem,
            this.navigationToolStripMenuItem,
            this.onEventToolStripMenuItem});
            this.scriptsToolStripMenuItem.Name = "scriptsToolStripMenuItem";
            this.scriptsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.scriptsToolStripMenuItem.Text = "Scripts";
            // 
            // farmDNCToolStripMenuItem
            // 
            this.farmDNCToolStripMenuItem.Name = "farmDNCToolStripMenuItem";
            this.farmDNCToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.farmDNCToolStripMenuItem.Text = "Farm";
            this.farmDNCToolStripMenuItem.Click += new System.EventHandler(this.FarmDncToolStripMenuItemClick);
            // 
            // healingSupportToolStripMenuItem
            // 
            this.healingSupportToolStripMenuItem.Enabled = false;
            this.healingSupportToolStripMenuItem.Name = "healingSupportToolStripMenuItem";
            this.healingSupportToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.healingSupportToolStripMenuItem.Text = "Healing Support";
            this.healingSupportToolStripMenuItem.Visible = false;
            this.healingSupportToolStripMenuItem.Click += new System.EventHandler(this.HealingSupportToolStripMenuItemClick);
            // 
            // skillupToolStripMenuItem
            // 
            this.skillupToolStripMenuItem.Enabled = false;
            this.skillupToolStripMenuItem.Name = "skillupToolStripMenuItem";
            this.skillupToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.skillupToolStripMenuItem.Text = "Skillup";
            this.skillupToolStripMenuItem.Visible = false;
            this.skillupToolStripMenuItem.Click += new System.EventHandler(this.skillupToolStripMenuItem_Click);
            // 
            // synergyToolStripMenuItem
            // 
            this.synergyToolStripMenuItem.Enabled = false;
            this.synergyToolStripMenuItem.Name = "synergyToolStripMenuItem";
            this.synergyToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.synergyToolStripMenuItem.Text = "Synergy";
            this.synergyToolStripMenuItem.Visible = false;
            // 
            // buySellTradeToolStripMenuItem
            // 
            this.buySellTradeToolStripMenuItem.Enabled = false;
            this.buySellTradeToolStripMenuItem.Name = "buySellTradeToolStripMenuItem";
            this.buySellTradeToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.buySellTradeToolStripMenuItem.Text = "Buy/Sell/Trade";
            this.buySellTradeToolStripMenuItem.Visible = false;
            // 
            // navigationToolStripMenuItem
            // 
            this.navigationToolStripMenuItem.Name = "navigationToolStripMenuItem";
            this.navigationToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.navigationToolStripMenuItem.Text = "Navigation";
            this.navigationToolStripMenuItem.Click += new System.EventHandler(this.navigationToolStripMenuItem_Click);
            // 
            // onEventToolStripMenuItem
            // 
            this.onEventToolStripMenuItem.Name = "onEventToolStripMenuItem";
            this.onEventToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.onEventToolStripMenuItem.Text = "On Event Tool";
            this.onEventToolStripMenuItem.Click += new System.EventHandler(this.OnEventToolStripMenuItemClick);
            // 
            // questsToolStripMenuItem
            // 
            this.questsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.melyonToolStripMenuItem,
            this.shamiToolStripMenuItem,
            this.sparksToolStripMenuItem,
            this.zaldonToolStripMenuItem});
            this.questsToolStripMenuItem.Enabled = false;
            this.questsToolStripMenuItem.Name = "questsToolStripMenuItem";
            this.questsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.questsToolStripMenuItem.Text = "Quests";
            this.questsToolStripMenuItem.Visible = false;
            // 
            // melyonToolStripMenuItem
            // 
            this.melyonToolStripMenuItem.Name = "melyonToolStripMenuItem";
            this.melyonToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.melyonToolStripMenuItem.Text = "Melyon";
            // 
            // shamiToolStripMenuItem
            // 
            this.shamiToolStripMenuItem.Name = "shamiToolStripMenuItem";
            this.shamiToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.shamiToolStripMenuItem.Text = "Shami";
            // 
            // sparksToolStripMenuItem
            // 
            this.sparksToolStripMenuItem.Name = "sparksToolStripMenuItem";
            this.sparksToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.sparksToolStripMenuItem.Text = "Sparks";
            // 
            // zaldonToolStripMenuItem
            // 
            this.zaldonToolStripMenuItem.Name = "zaldonToolStripMenuItem";
            this.zaldonToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.zaldonToolStripMenuItem.Text = "Zaldon";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stayOnTopToolStripMenuItem,
            this.minimizeToSysTrayToolStripMenuItem,
            this.enableMaintenanceModeToolStripMenuItem});
            this.optionsToolStripMenuItem.Enabled = false;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Visible = false;
            // 
            // stayOnTopToolStripMenuItem
            // 
            this.stayOnTopToolStripMenuItem.Name = "stayOnTopToolStripMenuItem";
            this.stayOnTopToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stayOnTopToolStripMenuItem.Text = "Stay on Top";
            // 
            // minimizeToSysTrayToolStripMenuItem
            // 
            this.minimizeToSysTrayToolStripMenuItem.Name = "minimizeToSysTrayToolStripMenuItem";
            this.minimizeToSysTrayToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.minimizeToSysTrayToolStripMenuItem.Text = "Minimize to SysTray";
            // 
            // enableMaintenanceModeToolStripMenuItem
            // 
            this.enableMaintenanceModeToolStripMenuItem.Name = "enableMaintenanceModeToolStripMenuItem";
            this.enableMaintenanceModeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.enableMaintenanceModeToolStripMenuItem.Text = "Maintenance Mode";
            // 
            // releasToolStripMenuItem
            // 
            this.releasToolStripMenuItem.Enabled = false;
            this.releasToolStripMenuItem.Name = "releasToolStripMenuItem";
            this.releasToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.releasToolStripMenuItem.Text = "Release Controles";
            this.releasToolStripMenuItem.Visible = false;
            this.releasToolStripMenuItem.Click += new System.EventHandler(this.releasToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fAQToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.manualToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // fAQToolStripMenuItem
            // 
            this.fAQToolStripMenuItem.Enabled = false;
            this.fAQToolStripMenuItem.Name = "fAQToolStripMenuItem";
            this.fAQToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.fAQToolStripMenuItem.Text = "FAQ";
            this.fAQToolStripMenuItem.Visible = false;
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.manualToolStripMenuItem.Text = "Manual";
            this.manualToolStripMenuItem.Click += new System.EventHandler(this.manualToolStripMenuItem_Click);
            // 
            // xstatus
            // 
            this.xstatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xStatusLabel});
            this.xstatus.Location = new System.Drawing.Point(0, 187);
            this.xstatus.Name = "xstatus";
            this.xstatus.Size = new System.Drawing.Size(366, 22);
            this.xstatus.TabIndex = 3;
            this.xstatus.Text = "xstatus";
            // 
            // xStatusLabel
            // 
            this.xStatusLabel.Name = "xStatusLabel";
            this.xStatusLabel.Size = new System.Drawing.Size(72, 17);
            this.xStatusLabel.Text = "xStatusLabel";
            this.xStatusLabel.TextChanged += new System.EventHandler(this.xStatusLabel_Changed);
            // 
            // header2
            // 
            this.header2.AutoSize = true;
            this.header2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header2.Location = new System.Drawing.Point(251, 50);
            this.header2.Name = "header2";
            this.header2.Size = new System.Drawing.Size(107, 14);
            this.header2.TabIndex = 12;
            this.header2.Text = "by cmalo/vicrelant";
            // 
            // header1
            // 
            this.header1.AutoSize = true;
            this.header1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header1.Location = new System.Drawing.Point(170, 32);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(170, 20);
            this.header1.TabIndex = 11;
            this.header1.Text = "Scripted (c) 2014/2015";
            // 
            // xpic
            // 
            this.xpic.Image = global::EliteMMO.Scripted.Properties.Resources.xeyes_1_128x128x32;
            this.xpic.Location = new System.Drawing.Point(0, 18);
            this.xpic.Name = "xpic";
            this.xpic.Size = new System.Drawing.Size(366, 163);
            this.xpic.TabIndex = 4;
            this.xpic.TabStop = false;
            // 
            // EliteMMO_PROC
            // 
            this.EliteMMO_PROC.FormattingEnabled = true;
            this.EliteMMO_PROC.Location = new System.Drawing.Point(11, 160);
            this.EliteMMO_PROC.Name = "EliteMMO_PROC";
            this.EliteMMO_PROC.Size = new System.Drawing.Size(136, 21);
            this.EliteMMO_PROC.TabIndex = 14;
            this.EliteMMO_PROC.TabStop = false;
            this.EliteMMO_PROC.SelectedIndexChanged += new System.EventHandler(this.EliteMmoProcSelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "select process";
            // 
            // header5
            // 
            this.header5.AutoSize = true;
            this.header5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header5.Location = new System.Drawing.Point(162, 160);
            this.header5.Name = "header5";
            this.header5.Size = new System.Drawing.Size(180, 14);
            this.header5.TabIndex = 18;
            this.header5.Text = "Made open source on 9/25/2015";
            // 
            // header3
            // 
            this.header3.AutoSize = true;
            this.header3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header3.Location = new System.Drawing.Point(230, 64);
            this.header3.Name = "header3";
            this.header3.Size = new System.Drawing.Size(70, 14);
            this.header3.TabIndex = 19;
            this.header3.Text = "Modified by";
            // 
            // header4
            // 
            this.header4.AutoSize = true;
            this.header4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header4.Location = new System.Drawing.Point(251, 78);
            this.header4.Name = "header4";
            this.header4.Size = new System.Drawing.Size(49, 14);
            this.header4.TabIndex = 20;
            this.header4.Text = "SMD111";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 209);
            this.Controls.Add(this.header5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EliteMMO_PROC);
            this.Controls.Add(this.header1);
            this.Controls.Add(this.xstatus);
            this.Controls.Add(this.xmenu);
            this.Controls.Add(this.header4);
            this.Controls.Add(this.header2);
            this.Controls.Add(this.header3);
            this.Controls.Add(this.xpic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Scripted OSS v1.0 Final";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.xmenu.ResumeLayout(false);
            this.xmenu.PerformLayout();
            this.xstatus.ResumeLayout(false);
            this.xstatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.MenuStrip xmenu;
        public System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem loadSettingsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem saveSettingsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem resetSettingsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem closeExitToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem scriptsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem farmDNCToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem healingSupportToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem skillupToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem synergyToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem buySellTradeToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem questsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem melyonToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem shamiToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem sparksToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem zaldonToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem stayOnTopToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem fAQToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        public System.Windows.Forms.StatusStrip xstatus;
        public System.Windows.Forms.ToolStripStatusLabel xStatusLabel;
        public System.Windows.Forms.PictureBox xpic;
        public System.Windows.Forms.Label header2;
        public System.Windows.Forms.Label header1;
        public System.Windows.Forms.ComboBox EliteMMO_PROC;
        public System.Windows.Forms.ToolStripMenuItem refreshCharactersToolStripMenuItem;
        public System.Windows.Forms.Label label1;
        public ToolStripMenuItem minimizeToSysTrayToolStripMenuItem;
        public ToolStripMenuItem enableMaintenanceModeToolStripMenuItem;
        public ToolStripMenuItem navigationToolStripMenuItem;
        private ToolStripMenuItem onEventToolStripMenuItem;
        public Label header5;
        public Label header3;
        public Label header4;
        private ToolStripMenuItem manualToolStripMenuItem;
        private ToolStripMenuItem releasToolStripMenuItem;
    }
}