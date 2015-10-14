namespace EliteMMO.Scripted.Views
{
    using System;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Xml.Linq;
    using System.Xml;
    using System.Collections;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Security.Policy;
    using API;
    using Embedded;
    using System.Text.RegularExpressions;

    partial class ScriptFarmDNC
    {
        private static EliteAPI api;

        List<WayPoint> route = new List<WayPoint>();

        public double DistanceTolerance { get; set; }

        public bool botRunning = false;
        public bool naviMove = false;
        public bool datsName = false;
        public bool isPulled = false;
        public bool isMoving = false;
        public bool isCasting = false;

        public float SetEntityX = 0;
        public float SetEntityY = 0;
        public int SchCharges;
        public bool MonStagered = false;
        public int mainJOB = 0;
        public int subJOB = 0;

        public string FFXIPath = "";

        public float idleX;
        public float idleY;

        public double[] navPathX = new double[1];
        public double[] navPathZ = new double[1];

        //public static Dictionary<double, double> route = new Dictionary<double, double>();

        public List<int> partyIDs = new List<int>();
        public List<int> ignoreTarget = new List<int>();

        public static List<string> DebugLog = new List<string>();

        public static Dictionary<string, string> items = new Dictionary<string, string>();
        public Dictionary<string, string> wantedID = new Dictionary<string, string>();
        public Dictionary<string, string> wantedNM = new Dictionary<string, string>();

        #region notWanted<list>
        public List<string> notWanted = new List<string>(new string[]
        {
            "",
            "???",
            "Casket",
            "Treasure Chest",
            "Treasure Casket",
            "Treasure Coffer",
            "Mog-Tablet",
            "Logging Point",
            "Mining Point",
            "Harvesting Point",
            "Field Manual",
            "Moogle",
            "VCSCrate",
            "EFFECTER",
            "Gate Sentry",
            "Mogball-Local",
            "CermetHeadstone",
            "Sign post",
            "Stone Monument",
            "Overturned Soil",
            "Riftworn Pyxis",
            "Achieve Master",
            "_3t0","01","02","03","04","05","06","07",
            "08","09","10","11","12","13","14","15",
            "akaA","akaE","akaF","akaG","akaH","akaI",
            "akaJ","d01","d02","d03","d04","ex01","ex02",
            "ex03","ex04","ex05","ex06","ex07","ex08",
            "gold 01","gold 02","Irin 01","Irin 02",
            "Irin 03",
            "1","2","3","4","5","6","7","8","9","10",
            "A","B","C","D","E","F","G","H","I","J",
            "K","L","M","N","O","P","Q","R","S","T",
            "U","V","W","X","Y","Z",
            "Tsonga-Hoponga, W.W.",
            "Voidwatch Officer",
            "Spare Two",
            "Spare Zero",
            "Ramblix",
            "Planar Rift",
            "Goblin Footprint",
            "Chocobo",
            "Home Point #1",
            "Home Point #2",
            "Home Point #3",
            "Home Point #4",
            "Home Point #5",
            "FXTEST",
            "Anguenet",
            "Beugungel",
            "Chuaie",
            "Cofisephe",
            "Coupulie",
            "Felourie",
            "Guilloud",
            "Lourdaude",
            "Ratoulle",
            "sdoor_s",
            "sdoor_t",
            "sdoor_u",
            "ship",
            "Gniyah Mischatt",
            "Khots Chalahko",
            "Test Actor",
            "Fheli Lapatzuo",
            "Mep Nhapopoluko",
            "Tswe Panipahr",
            "Noih Tahparawh",
            "Toh Zonikki",
            "Rhalo Davigoh",
            "Pohka Chichiyowahl",
            "??? Warmachine",
            "Affi","Dremi",
            "Eschan Portal #1",
            "Eschan Portal #2",
            "Eschan Portal #3",
            "Eschan Portal #4",
            "Eschan Portal #5",
            "Eschan Portal #6",
            "Eschan Portal #7",
            "Eschan Portal #8",
            "Eschan Portal #9",
            "Eschan Portal #10",
            "Eschan Portal #11",
            "Eschan Portal #12",
            "Eschan Portal #13",
            "Eschan Portal #14",
            "Eschan Portal #15"
        });
        #endregion

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
            this.checkZone = new System.Windows.Forms.CheckBox();
            this.StopFullInventory = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.firstPersonView = new System.Windows.Forms.CheckBox();
            this.runReverse = new System.Windows.Forms.CheckBox();
            this.Linear = new System.Windows.Forms.RadioButton();
            this.Circular = new System.Windows.Forms.RadioButton();
            this.selectedNavi = new System.Windows.Forms.ComboBox();
            this.GetSetNavi = new System.Windows.Forms.MenuStrip();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usenav = new System.Windows.Forms.CheckBox();
            this.StartStopScript = new System.Windows.Forms.MenuStrip();
            this.startScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateJobToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dncControl = new System.Windows.Forms.TabControl();
            this.targets = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.ZoneTargets = new System.Windows.Forms.MenuStrip();
            this.NameListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.TargetList = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.GetSetTargets = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selecttargets = new System.Windows.Forms.GroupBox();
            this.SelectedTargets = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.combat = new System.Windows.Forms.TabPage();
            this.CombatSettingsTabs = new System.Windows.Forms.TabControl();
            this.Options1MainTab = new System.Windows.Forms.TabPage();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown7 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.selectedHateControl = new System.Windows.Forms.ComboBox();
            this.tank = new System.Windows.Forms.CheckBox();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.amname = new System.Windows.Forms.ComboBox();
            this.AfterMathTier = new System.Windows.Forms.NumericUpDown();
            this.wsam = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.numericUpDown40 = new System.Windows.Forms.NumericUpDown();
            this.ws = new System.Windows.Forms.CheckBox();
            this.numericUpDown24 = new System.Windows.Forms.NumericUpDown();
            this.label29 = new System.Windows.Forms.Label();
            this.numericUpDown22 = new System.Windows.Forms.NumericUpDown();
            this.label28 = new System.Windows.Forms.Label();
            this.numericUpDown23 = new System.Windows.Forms.NumericUpDown();
            this.label27 = new System.Windows.Forms.Label();
            this.Options2MainTab = new System.Windows.Forms.TabPage();
            this.numericUpDown38 = new System.Windows.Forms.NumericUpDown();
            this.aggroRange = new System.Windows.Forms.NumericUpDown();
            this.ScanDelay = new System.Windows.Forms.CheckBox();
            this.KeepTargetRange = new System.Windows.Forms.NumericUpDown();
            this.assistDist = new System.Windows.Forms.NumericUpDown();
            this.followDist = new System.Windows.Forms.NumericUpDown();
            this.partyAssist = new System.Windows.Forms.CheckBox();
            this.facetarget = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.assist = new System.Windows.Forms.CheckBox();
            this.followplayer = new System.Windows.Forms.CheckBox();
            this.followName = new System.Windows.Forms.TextBox();
            this.useshadows = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.assistplayer = new System.Windows.Forms.TextBox();
            this.aggro = new System.Windows.Forms.CheckBox();
            this.mobdist = new System.Windows.Forms.CheckBox();
            this.Options3MainTab = new System.Windows.Forms.TabPage();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.SignetStaff = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.useStaff = new System.Windows.Forms.CheckBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.healMPcount = new System.Windows.Forms.NumericUpDown();
            this.usefood = new System.Windows.Forms.CheckBox();
            this.HealMP = new System.Windows.Forms.CheckBox();
            this.healHPcount = new System.Windows.Forms.NumericUpDown();
            this.RecordIdleLocation = new System.Windows.Forms.Button();
            this.WeakLocation = new System.Windows.Forms.CheckBox();
            this.HealHP = new System.Windows.Forms.CheckBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.IdleLocation = new System.Windows.Forms.CheckBox();
            this.label35 = new System.Windows.Forms.Label();
            this.Options4MainTab = new System.Windows.Forms.TabPage();
            this.DropBox = new System.Windows.Forms.GroupBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.label42 = new System.Windows.Forms.Label();
            this.autoRangeDelay = new System.Windows.Forms.NumericUpDown();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.rangeaggro = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.autoRangeAttack = new System.Windows.Forms.CheckBox();
            this.OptionsJAMainTab = new System.Windows.Forms.TabPage();
            this.JAtabselect = new System.Windows.Forms.TabControl();
            this.selectPage = new System.Windows.Forms.TabPage();
            this.playerJA = new System.Windows.Forms.CheckedListBox();
            this.GetSetJA = new System.Windows.Forms.MenuStrip();
            this.loadJAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearJAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WHMpage = new System.Windows.Forms.TabPage();
            this.benedictiongroupBox = new System.Windows.Forms.GroupBox();
            this.BenedictionHPPuse = new System.Windows.Forms.NumericUpDown();
            this.benedictiontext = new System.Windows.Forms.Label();
            this.RDMpage = new System.Windows.Forms.TabPage();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.ConvertHPP = new System.Windows.Forms.NumericUpDown();
            this.ConvertMPP = new System.Windows.Forms.NumericUpDown();
            this.ConvertMP = new System.Windows.Forms.CheckBox();
            this.ConvertHP = new System.Windows.Forms.CheckBox();
            this.convertmptext = new System.Windows.Forms.Label();
            this.converthptext = new System.Windows.Forms.Label();
            this.SCHpage = new System.Windows.Forms.TabPage();
            this.Sublimationcount = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.RUNpage = new System.Windows.Forms.TabPage();
            this.VivaciousPulseHP = new System.Windows.Forms.NumericUpDown();
            this.VivaciousPulse = new System.Windows.Forms.CheckBox();
            this.MONpage = new System.Windows.Forms.TabPage();
            this.MONmpCount = new System.Windows.Forms.NumericUpDown();
            this.MONhpCount = new System.Windows.Forms.NumericUpDown();
            this.monmptext = new System.Windows.Forms.Label();
            this.monhptext = new System.Windows.Forms.Label();
            this.Dynamispage = new System.Windows.Forms.TabPage();
            this.Dynatxt = new System.Windows.Forms.Label();
            this.staggerstopJA = new System.Windows.Forms.CheckBox();
            this.OptionsMAMainTab = new System.Windows.Forms.TabPage();
            this.MAtabs = new System.Windows.Forms.TabControl();
            this.MASelectPage = new System.Windows.Forms.TabPage();
            this.playerMA = new System.Windows.Forms.CheckedListBox();
            this.GetSetMA = new System.Windows.Forms.MenuStrip();
            this.loadMAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CureConfigPage = new System.Windows.Forms.TabPage();
            this.CuraIIcount = new System.Windows.Forms.NumericUpDown();
            this.label55 = new System.Windows.Forms.Label();
            this.CuraIIIcount = new System.Windows.Forms.NumericUpDown();
            this.label53 = new System.Windows.Forms.Label();
            this.Curacount = new System.Windows.Forms.NumericUpDown();
            this.label54 = new System.Windows.Forms.Label();
            this.FullCurecount = new System.Windows.Forms.NumericUpDown();
            this.label52 = new System.Windows.Forms.Label();
            this.CureVIcount = new System.Windows.Forms.NumericUpDown();
            this.label45 = new System.Windows.Forms.Label();
            this.CureVcount = new System.Windows.Forms.NumericUpDown();
            this.CureIVcount = new System.Windows.Forms.NumericUpDown();
            this.CureIIIcount = new System.Windows.Forms.NumericUpDown();
            this.CureIIcount = new System.Windows.Forms.NumericUpDown();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Curecount = new System.Windows.Forms.NumericUpDown();
            this.DrainAspirpage = new System.Windows.Forms.TabPage();
            this.Aspirgroup = new System.Windows.Forms.GroupBox();
            this.AspirIIIcount = new System.Windows.Forms.NumericUpDown();
            this.AspirIIcount = new System.Windows.Forms.NumericUpDown();
            this.AspirIIItext = new System.Windows.Forms.Label();
            this.AspirItext = new System.Windows.Forms.Label();
            this.AspirIItext = new System.Windows.Forms.Label();
            this.AspirIcount = new System.Windows.Forms.NumericUpDown();
            this.Draingroup = new System.Windows.Forms.GroupBox();
            this.DrainIItext = new System.Windows.Forms.Label();
            this.DrainIcount = new System.Windows.Forms.NumericUpDown();
            this.DrainItext = new System.Windows.Forms.Label();
            this.DrainIIItext = new System.Windows.Forms.Label();
            this.DrainIIIcount = new System.Windows.Forms.NumericUpDown();
            this.DrainIIcount = new System.Windows.Forms.NumericUpDown();
            this.BLUCurespage = new System.Windows.Forms.TabPage();
            this.MagicFruitcount = new System.Windows.Forms.NumericUpDown();
            this.Pollencount = new System.Windows.Forms.NumericUpDown();
            this.HealingBreezecount = new System.Windows.Forms.NumericUpDown();
            this.PleniluneEmbracecount = new System.Windows.Forms.NumericUpDown();
            this.Restoralcount = new System.Windows.Forms.NumericUpDown();
            this.WhiteWindcount = new System.Windows.Forms.NumericUpDown();
            this.Exuviationcount = new System.Windows.Forms.NumericUpDown();
            this.WildCarrotcount = new System.Windows.Forms.NumericUpDown();
            this.PleniluneEmbracetext = new System.Windows.Forms.Label();
            this.MagicFruittext = new System.Windows.Forms.Label();
            this.HealingBreezetext = new System.Windows.Forms.Label();
            this.Pollentext = new System.Windows.Forms.Label();
            this.WhiteWindtext = new System.Windows.Forms.Label();
            this.Restoraltext = new System.Windows.Forms.Label();
            this.Exuviationtext = new System.Windows.Forms.Label();
            this.WildCarrottext = new System.Windows.Forms.Label();
            this.MAconfigpage = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.MAreverse = new System.Windows.Forms.CheckBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.delaytext = new System.Windows.Forms.Label();
            this.pullDelay = new System.Windows.Forms.NumericUpDown();
            this.AutoLock = new System.Windows.Forms.CheckBox();
            this.numericUpDown39 = new System.Windows.Forms.NumericUpDown();
            this.mobheightdist = new System.Windows.Forms.CheckBox();
            this.runTarget = new System.Windows.Forms.CheckBox();
            this.runPullDistance = new System.Windows.Forms.CheckBox();
            this.mobsearchdisttext = new System.Windows.Forms.Label();
            this.targetSearchDist = new System.Windows.Forms.NumericUpDown();
            this.pullTolorance = new System.Windows.Forms.NumericUpDown();
            this.pulltolorancetext = new System.Windows.Forms.Label();
            this.numericUpDown21 = new System.Windows.Forms.NumericUpDown();
            this.pulldistance = new System.Windows.Forms.Label();
            this.pullCommand = new System.Windows.Forms.TextBox();
            this.pullcommandtext = new System.Windows.Forms.Label();
            this.dancer = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.noSamba = new System.Windows.Forms.RadioButton();
            this.usedrainiii = new System.Windows.Forms.RadioButton();
            this.usehaste = new System.Windows.Forms.RadioButton();
            this.useaspirii = new System.Windows.Forms.RadioButton();
            this.useaspir = new System.Windows.Forms.RadioButton();
            this.usedrainii = new System.Windows.Forms.RadioButton();
            this.usedrain = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.stopstepsat = new System.Windows.Forms.CheckBox();
            this.stopstepscount = new System.Windows.Forms.NumericUpDown();
            this.stopstepsathptext = new System.Windows.Forms.Label();
            this.usefeatherstepValue = new System.Windows.Forms.NumericUpDown();
            this.usestutterstepValue = new System.Windows.Forms.NumericUpDown();
            this.useboxstepValue = new System.Windows.Forms.NumericUpDown();
            this.StepsHPValue = new System.Windows.Forms.NumericUpDown();
            this.usequickstepValue = new System.Windows.Forms.NumericUpDown();
            this.StepsHP = new System.Windows.Forms.CheckBox();
            this.NoSteps = new System.Windows.Forms.RadioButton();
            this.usequickstep = new System.Windows.Forms.RadioButton();
            this.useboxstep = new System.Windows.Forms.RadioButton();
            this.usestutterstep = new System.Windows.Forms.RadioButton();
            this.usefeatherstep = new System.Windows.Forms.RadioButton();
            this.tabPage15 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.HealingWaltzItems = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.usecurevValue = new System.Windows.Forms.NumericUpDown();
            this.usecureivValue = new System.Windows.Forms.NumericUpDown();
            this.usecureiiiValue = new System.Windows.Forms.NumericUpDown();
            this.usecureiiValue = new System.Windows.Forms.NumericUpDown();
            this.usecureValue = new System.Windows.Forms.NumericUpDown();
            this.usecurev = new System.Windows.Forms.CheckBox();
            this.usecureiv = new System.Windows.Forms.CheckBox();
            this.usecureiii = new System.Windows.Forms.CheckBox();
            this.usecureii = new System.Windows.Forms.CheckBox();
            this.usecure = new System.Windows.Forms.CheckBox();
            this.tabPage16 = new System.Windows.Forms.TabPage();
            this.addplayertext = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.numericUpDown27 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown28 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown29 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown32 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown33 = new System.Windows.Forms.NumericUpDown();
            this.ptusecurev = new System.Windows.Forms.CheckBox();
            this.ptusecureiv = new System.Windows.Forms.CheckBox();
            this.ptusecureiii = new System.Windows.Forms.CheckBox();
            this.ptusecureii = new System.Windows.Forms.CheckBox();
            this.ptusecure = new System.Windows.Forms.CheckBox();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.GetSetParty = new System.Windows.Forms.MenuStrip();
            this.loadPartyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearPartyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView4 = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label15 = new System.Windows.Forms.Label();
            this.flourish = new System.Windows.Forms.TabPage();
            this.flourishesiiigroup = new System.Windows.Forms.GroupBox();
            this.useclmfloValue = new System.Windows.Forms.NumericUpDown();
            this.usestkfloValue = new System.Windows.Forms.NumericUpDown();
            this.useterfloValue = new System.Windows.Forms.NumericUpDown();
            this.usestkflo = new System.Windows.Forms.RadioButton();
            this.useclmflo = new System.Windows.Forms.RadioButton();
            this.useterflo = new System.Windows.Forms.RadioButton();
            this.label40 = new System.Windows.Forms.Label();
            this.finsishingmovetext = new System.Windows.Forms.Label();
            this.FlourishTPValue = new System.Windows.Forms.NumericUpDown();
            this.flourishesiigroup = new System.Windows.Forms.GroupBox();
            this.usewldfloValue = new System.Windows.Forms.NumericUpDown();
            this.usebldfloValue = new System.Windows.Forms.NumericUpDown();
            this.userevfloValue = new System.Windows.Forms.NumericUpDown();
            this.usewldflo = new System.Windows.Forms.RadioButton();
            this.usebldflo = new System.Windows.Forms.RadioButton();
            this.userevflo = new System.Windows.Forms.RadioButton();
            this.FlourishTP = new System.Windows.Forms.CheckBox();
            this.flourishesigroup = new System.Windows.Forms.GroupBox();
            this.numericUpDown34 = new System.Windows.Forms.NumericUpDown();
            this.usedesflo = new System.Windows.Forms.RadioButton();
            this.pets = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.petControl = new System.Windows.Forms.TabControl();
            this.bstpettab = new System.Windows.Forms.TabPage();
            this.usepetja = new System.Windows.Forms.GroupBox();
            this.PetJA = new System.Windows.Forms.CheckedListBox();
            this.bstpetrdygroup = new System.Windows.Forms.GroupBox();
            this.PetReady = new System.Windows.Forms.CheckedListBox();
            this.usedpetfood = new System.Windows.Forms.ComboBox();
            this.jugpet = new System.Windows.Forms.ComboBox();
            this.juguse = new System.Windows.Forms.CheckBox();
            this.pethppfood = new System.Windows.Forms.NumericUpDown();
            this.pethptext = new System.Windows.Forms.Label();
            this.petfooduse = new System.Windows.Forms.CheckBox();
            this.autoengage = new System.Windows.Forms.CheckBox();
            this.drgpettab = new System.Windows.Forms.TabPage();
            this.DragonPetHP = new System.Windows.Forms.NumericUpDown();
            this.drgsteadywingtext = new System.Windows.Forms.Label();
            this.CallWyvern = new System.Windows.Forms.CheckBox();
            this.drgspirtlinkgroup = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.PlayerSpirit = new System.Windows.Forms.NumericUpDown();
            this.WyvernSpirit = new System.Windows.Forms.NumericUpDown();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.BreathMAX = new System.Windows.Forms.NumericUpDown();
            this.label48 = new System.Windows.Forms.Label();
            this.BreathMIN = new System.Windows.Forms.NumericUpDown();
            this.drgwyvernbreathptext = new System.Windows.Forms.Label();
            this.drgrestoringbreathgroup = new System.Windows.Forms.GroupBox();
            this.RestoringBreathHP = new System.Windows.Forms.NumericUpDown();
            this.label50 = new System.Windows.Forms.Label();
            this.drgjagroup = new System.Windows.Forms.GroupBox();
            this.WyvernJA = new System.Windows.Forms.CheckedListBox();
            this.smnpettab = new System.Windows.Forms.TabPage();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.puppettab = new System.Windows.Forms.TabPage();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.geopettab = new System.Windows.Forms.TabPage();
            this.bgw_script_dnc = new System.ComponentModel.BackgroundWorker();
            this.bgw_script_nav = new System.ComponentModel.BackgroundWorker();
            this.bgw_script_sch = new System.ComponentModel.BackgroundWorker();
            this.bgw_script_chat = new System.ComponentModel.BackgroundWorker();
            this.bgw_script_pet = new System.ComponentModel.BackgroundWorker();
            this.bgw_script_npc = new System.ComponentModel.BackgroundWorker();
            this.bgw_script_scn = new System.ComponentModel.BackgroundWorker();
            this.DeathWarp = new System.Windows.Forms.CheckBox();
            this.groupBox8.SuspendLayout();
            this.GetSetNavi.SuspendLayout();
            this.StartStopScript.SuspendLayout();
            this.dncControl.SuspendLayout();
            this.targets.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.ZoneTargets.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.GetSetTargets.SuspendLayout();
            this.selecttargets.SuspendLayout();
            this.combat.SuspendLayout();
            this.CombatSettingsTabs.SuspendLayout();
            this.Options1MainTab.SuspendLayout();
            this.groupBox23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).BeginInit();
            this.groupBox20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AfterMathTier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown23)).BeginInit();
            this.Options2MainTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aggroRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeepTargetRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assistDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.followDist)).BeginInit();
            this.Options3MainTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.healMPcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.healHPcount)).BeginInit();
            this.Options4MainTab.SuspendLayout();
            this.DropBox.SuspendLayout();
            this.groupBox15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoRangeDelay)).BeginInit();
            this.OptionsJAMainTab.SuspendLayout();
            this.JAtabselect.SuspendLayout();
            this.selectPage.SuspendLayout();
            this.GetSetJA.SuspendLayout();
            this.WHMpage.SuspendLayout();
            this.benedictiongroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BenedictionHPPuse)).BeginInit();
            this.RDMpage.SuspendLayout();
            this.groupBox18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConvertHPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConvertMPP)).BeginInit();
            this.SCHpage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sublimationcount)).BeginInit();
            this.RUNpage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VivaciousPulseHP)).BeginInit();
            this.MONpage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MONmpCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MONhpCount)).BeginInit();
            this.Dynamispage.SuspendLayout();
            this.OptionsMAMainTab.SuspendLayout();
            this.MAtabs.SuspendLayout();
            this.MASelectPage.SuspendLayout();
            this.GetSetMA.SuspendLayout();
            this.CureConfigPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CuraIIcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CuraIIIcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Curacount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FullCurecount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureVIcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureVcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureIVcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureIIIcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureIIcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Curecount)).BeginInit();
            this.DrainAspirpage.SuspendLayout();
            this.Aspirgroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AspirIIIcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AspirIIcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AspirIcount)).BeginInit();
            this.Draingroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrainIcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrainIIIcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrainIIcount)).BeginInit();
            this.BLUCurespage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MagicFruitcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pollencount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealingBreezecount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PleniluneEmbracecount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Restoralcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WhiteWindcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exuviationcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WildCarrotcount)).BeginInit();
            this.MAconfigpage.SuspendLayout();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pullDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetSearchDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pullTolorance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown21)).BeginInit();
            this.dancer.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stopstepscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usefeatherstepValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usestutterstepValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.useboxstepValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepsHPValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usequickstepValue)).BeginInit();
            this.tabPage15.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usecurevValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usecureivValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usecureiiiValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usecureiiValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usecureValue)).BeginInit();
            this.tabPage16.SuspendLayout();
            this.groupBox21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown33)).BeginInit();
            this.groupBox22.SuspendLayout();
            this.GetSetParty.SuspendLayout();
            this.flourish.SuspendLayout();
            this.flourishesiiigroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.useclmfloValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usestkfloValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.useterfloValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlourishTPValue)).BeginInit();
            this.flourishesiigroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usewldfloValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usebldfloValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userevfloValue)).BeginInit();
            this.flourishesigroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown34)).BeginInit();
            this.pets.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.petControl.SuspendLayout();
            this.bstpettab.SuspendLayout();
            this.usepetja.SuspendLayout();
            this.bstpetrdygroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pethppfood)).BeginInit();
            this.drgpettab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DragonPetHP)).BeginInit();
            this.drgspirtlinkgroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerSpirit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WyvernSpirit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BreathMAX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BreathMIN)).BeginInit();
            this.drgrestoringbreathgroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RestoringBreathHP)).BeginInit();
            this.drgjagroup.SuspendLayout();
            this.smnpettab.SuspendLayout();
            this.puppettab.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkZone
            // 
            this.checkZone.AutoSize = true;
            this.checkZone.Location = new System.Drawing.Point(617, 236);
            this.checkZone.Name = "checkZone";
            this.checkZone.Size = new System.Drawing.Size(91, 17);
            this.checkZone.TabIndex = 51;
            this.checkZone.Text = "Stop on Zone";
            this.checkZone.UseVisualStyleBackColor = true;
            // 
            // StopFullInventory
            // 
            this.StopFullInventory.AutoSize = true;
            this.StopFullInventory.Location = new System.Drawing.Point(463, 219);
            this.StopFullInventory.Name = "StopFullInventory";
            this.StopFullInventory.Size = new System.Drawing.Size(129, 17);
            this.StopFullInventory.TabIndex = 50;
            this.StopFullInventory.Text = "Stop on Full Inventory";
            this.StopFullInventory.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.comboBox3);
            this.groupBox8.Controls.Add(this.firstPersonView);
            this.groupBox8.Controls.Add(this.runReverse);
            this.groupBox8.Controls.Add(this.Linear);
            this.groupBox8.Controls.Add(this.Circular);
            this.groupBox8.Controls.Add(this.selectedNavi);
            this.groupBox8.Controls.Add(this.GetSetNavi);
            this.groupBox8.Enabled = false;
            this.groupBox8.Location = new System.Drawing.Point(463, 250);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(253, 128);
            this.groupBox8.TabIndex = 49;
            this.groupBox8.TabStop = false;
            // 
            // comboBox3
            // 
            this.comboBox3.Enabled = false;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(7, 42);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(238, 21);
            this.comboBox3.TabIndex = 34;
            // 
            // firstPersonView
            // 
            this.firstPersonView.AutoSize = true;
            this.firstPersonView.Enabled = false;
            this.firstPersonView.Location = new System.Drawing.Point(128, 68);
            this.firstPersonView.Name = "firstPersonView";
            this.firstPersonView.Size = new System.Drawing.Size(122, 17);
            this.firstPersonView.TabIndex = 33;
            this.firstPersonView.Text = "use first person view";
            this.firstPersonView.UseVisualStyleBackColor = true;
            // 
            // runReverse
            // 
            this.runReverse.AutoSize = true;
            this.runReverse.Enabled = false;
            this.runReverse.Location = new System.Drawing.Point(128, 84);
            this.runReverse.Name = "runReverse";
            this.runReverse.Size = new System.Drawing.Size(79, 17);
            this.runReverse.TabIndex = 32;
            this.runReverse.Text = "run reverse";
            this.runReverse.UseVisualStyleBackColor = true;
            // 
            // Linear
            // 
            this.Linear.AutoSize = true;
            this.Linear.Location = new System.Drawing.Point(7, 84);
            this.Linear.Name = "Linear";
            this.Linear.Size = new System.Drawing.Size(79, 17);
            this.Linear.TabIndex = 31;
            this.Linear.Text = "Linear Path";
            this.Linear.UseVisualStyleBackColor = true;
            // 
            // Circular
            // 
            this.Circular.AutoSize = true;
            this.Circular.Checked = true;
            this.Circular.Location = new System.Drawing.Point(7, 68);
            this.Circular.Name = "Circular";
            this.Circular.Size = new System.Drawing.Size(85, 17);
            this.Circular.TabIndex = 30;
            this.Circular.TabStop = true;
            this.Circular.Text = "Circular Path";
            this.Circular.UseVisualStyleBackColor = true;
            // 
            // selectedNavi
            // 
            this.selectedNavi.FormattingEnabled = true;
            this.selectedNavi.Location = new System.Drawing.Point(7, 19);
            this.selectedNavi.Name = "selectedNavi";
            this.selectedNavi.Size = new System.Drawing.Size(238, 21);
            this.selectedNavi.TabIndex = 29;
            this.selectedNavi.SelectedIndexChanged += new System.EventHandler(this.SelectedNaviSelectedIndexChanged);
            // 
            // GetSetNavi
            // 
            this.GetSetNavi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GetSetNavi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.GetSetNavi.Location = new System.Drawing.Point(3, 101);
            this.GetSetNavi.Name = "GetSetNavi";
            this.GetSetNavi.Size = new System.Drawing.Size(247, 24);
            this.GetSetNavi.TabIndex = 0;
            this.GetSetNavi.Text = "GetSetNavi";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(132, 20);
            this.refreshToolStripMenuItem.Text = "refresh navigation list";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItemClick);
            // 
            // usenav
            // 
            this.usenav.AutoSize = true;
            this.usenav.Location = new System.Drawing.Point(463, 236);
            this.usenav.Name = "usenav";
            this.usenav.Size = new System.Drawing.Size(118, 17);
            this.usenav.TabIndex = 48;
            this.usenav.Text = "Use Navigation File";
            this.usenav.UseVisualStyleBackColor = true;
            this.usenav.CheckedChanged += new System.EventHandler(this.UsenavCheckedChanged);
            // 
            // StartStopScript
            // 
            this.StartStopScript.Dock = System.Windows.Forms.DockStyle.None;
            this.StartStopScript.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startScriptToolStripMenuItem,
            this.stopScriptToolStripMenuItem,
            this.updateJobToolStripMenuItem});
            this.StartStopScript.Location = new System.Drawing.Point(470, 383);
            this.StartStopScript.Name = "StartStopScript";
            this.StartStopScript.Size = new System.Drawing.Size(238, 24);
            this.StartStopScript.TabIndex = 47;
            this.StartStopScript.Text = "StartStopScript";
            // 
            // startScriptToolStripMenuItem
            // 
            this.startScriptToolStripMenuItem.Name = "startScriptToolStripMenuItem";
            this.startScriptToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.startScriptToolStripMenuItem.Text = "Start Script";
            this.startScriptToolStripMenuItem.Click += new System.EventHandler(this.ToolStartClick);
            // 
            // stopScriptToolStripMenuItem
            // 
            this.stopScriptToolStripMenuItem.Enabled = false;
            this.stopScriptToolStripMenuItem.Name = "stopScriptToolStripMenuItem";
            this.stopScriptToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.stopScriptToolStripMenuItem.Text = "Stop Script";
            this.stopScriptToolStripMenuItem.Click += new System.EventHandler(this.ToolStopClick);
            // 
            // updateJobToolStripMenuItem
            // 
            this.updateJobToolStripMenuItem.Name = "updateJobToolStripMenuItem";
            this.updateJobToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.updateJobToolStripMenuItem.Text = "Update Job";
            this.updateJobToolStripMenuItem.Click += new System.EventHandler(this.UpdateJobToolStripMenuItemClick);
            // 
            // dncControl
            // 
            this.dncControl.Controls.Add(this.targets);
            this.dncControl.Controls.Add(this.combat);
            this.dncControl.Controls.Add(this.dancer);
            this.dncControl.Controls.Add(this.flourish);
            this.dncControl.Controls.Add(this.pets);
            this.dncControl.Location = new System.Drawing.Point(10, 30);
            this.dncControl.Name = "dncControl";
            this.dncControl.SelectedIndex = 0;
            this.dncControl.Size = new System.Drawing.Size(447, 377);
            this.dncControl.TabIndex = 46;
            // 
            // targets
            // 
            this.targets.Controls.Add(this.groupBox9);
            this.targets.Controls.Add(this.groupBox11);
            this.targets.Controls.Add(this.groupBox12);
            this.targets.Controls.Add(this.selecttargets);
            this.targets.Location = new System.Drawing.Point(4, 22);
            this.targets.Name = "targets";
            this.targets.Padding = new System.Windows.Forms.Padding(3);
            this.targets.Size = new System.Drawing.Size(439, 351);
            this.targets.TabIndex = 6;
            this.targets.Text = "Farm/Targets";
            this.targets.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.ZoneTargets);
            this.groupBox9.Location = new System.Drawing.Point(224, 292);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(200, 49);
            this.groupBox9.TabIndex = 10;
            this.groupBox9.TabStop = false;
            // 
            // ZoneTargets
            // 
            this.ZoneTargets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NameListToolStripMenuItem,
            this.iDToolStripMenuItem});
            this.ZoneTargets.Location = new System.Drawing.Point(3, 16);
            this.ZoneTargets.Name = "ZoneTargets";
            this.ZoneTargets.Size = new System.Drawing.Size(194, 24);
            this.ZoneTargets.TabIndex = 0;
            this.ZoneTargets.Text = "ZoneTargets";
            // 
            // NameListToolStripMenuItem
            // 
            this.NameListToolStripMenuItem.Name = "NameListToolStripMenuItem";
            this.NameListToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.NameListToolStripMenuItem.Text = "Name";
            this.NameListToolStripMenuItem.Click += new System.EventHandler(this.NameListToolStripMenuItem_Click);
            // 
            // iDToolStripMenuItem
            // 
            this.iDToolStripMenuItem.Name = "iDToolStripMenuItem";
            this.iDToolStripMenuItem.Size = new System.Drawing.Size(30, 20);
            this.iDToolStripMenuItem.Text = "ID";
            this.iDToolStripMenuItem.Click += new System.EventHandler(this.IdToolStripMenuItemClick);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.TargetList);
            this.groupBox11.Location = new System.Drawing.Point(224, 10);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(201, 276);
            this.groupBox11.TabIndex = 9;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Target List";
            // 
            // TargetList
            // 
            this.TargetList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TargetList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.TargetList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TargetList.FullRowSelect = true;
            this.TargetList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.TargetList.Location = new System.Drawing.Point(3, 16);
            this.TargetList.Name = "TargetList";
            this.TargetList.Size = new System.Drawing.Size(195, 257);
            this.TargetList.TabIndex = 1;
            this.TargetList.UseCompatibleStateImageBehavior = false;
            this.TargetList.View = System.Windows.Forms.View.Details;
            this.TargetList.DoubleClick += new System.EventHandler(this.ListView2DoubleClick);
            this.TargetList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ListView2KeyPress);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID";
            this.columnHeader3.Width = 35;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Name";
            this.columnHeader4.Width = 140;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.GetSetTargets);
            this.groupBox12.Location = new System.Drawing.Point(12, 292);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(200, 49);
            this.groupBox12.TabIndex = 8;
            this.groupBox12.TabStop = false;
            // 
            // GetSetTargets
            // 
            this.GetSetTargets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.GetSetTargets.Location = new System.Drawing.Point(3, 16);
            this.GetSetTargets.Name = "GetSetTargets";
            this.GetSetTargets.Size = new System.Drawing.Size(194, 24);
            this.GetSetTargets.TabIndex = 0;
            this.GetSetTargets.Text = "GetSetTargets";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItemClick);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.ClearToolStripMenuItemClick);
            // 
            // selecttargets
            // 
            this.selecttargets.Controls.Add(this.SelectedTargets);
            this.selecttargets.Location = new System.Drawing.Point(12, 10);
            this.selecttargets.Name = "selecttargets";
            this.selecttargets.Size = new System.Drawing.Size(201, 276);
            this.selecttargets.TabIndex = 7;
            this.selecttargets.TabStop = false;
            this.selecttargets.Text = "Selected Targets";
            // 
            // SelectedTargets
            // 
            this.SelectedTargets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SelectedTargets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.SelectedTargets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectedTargets.FullRowSelect = true;
            this.SelectedTargets.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.SelectedTargets.Location = new System.Drawing.Point(3, 16);
            this.SelectedTargets.Name = "SelectedTargets";
            this.SelectedTargets.Size = new System.Drawing.Size(195, 257);
            this.SelectedTargets.TabIndex = 0;
            this.SelectedTargets.UseCompatibleStateImageBehavior = false;
            this.SelectedTargets.View = System.Windows.Forms.View.Details;
            this.SelectedTargets.DoubleClick += new System.EventHandler(this.ListView1DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 35;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 140;
            // 
            // combat
            // 
            this.combat.Controls.Add(this.CombatSettingsTabs);
            this.combat.Controls.Add(this.groupBox14);
            this.combat.Location = new System.Drawing.Point(4, 22);
            this.combat.Name = "combat";
            this.combat.Padding = new System.Windows.Forms.Padding(3);
            this.combat.Size = new System.Drawing.Size(439, 351);
            this.combat.TabIndex = 7;
            this.combat.Text = "Combat Settings";
            this.combat.UseVisualStyleBackColor = true;
            // 
            // CombatSettingsTabs
            // 
            this.CombatSettingsTabs.Controls.Add(this.Options1MainTab);
            this.CombatSettingsTabs.Controls.Add(this.Options2MainTab);
            this.CombatSettingsTabs.Controls.Add(this.Options3MainTab);
            this.CombatSettingsTabs.Controls.Add(this.Options4MainTab);
            this.CombatSettingsTabs.Controls.Add(this.OptionsJAMainTab);
            this.CombatSettingsTabs.Controls.Add(this.OptionsMAMainTab);
            this.CombatSettingsTabs.Location = new System.Drawing.Point(45, 127);
            this.CombatSettingsTabs.Name = "CombatSettingsTabs";
            this.CombatSettingsTabs.SelectedIndex = 0;
            this.CombatSettingsTabs.Size = new System.Drawing.Size(335, 216);
            this.CombatSettingsTabs.TabIndex = 22;
            // 
            // Options1MainTab
            // 
            this.Options1MainTab.Controls.Add(this.groupBox23);
            this.Options1MainTab.Controls.Add(this.groupBox20);
            this.Options1MainTab.Location = new System.Drawing.Point(4, 22);
            this.Options1MainTab.Name = "Options1MainTab";
            this.Options1MainTab.Padding = new System.Windows.Forms.Padding(3);
            this.Options1MainTab.Size = new System.Drawing.Size(327, 190);
            this.Options1MainTab.TabIndex = 6;
            this.Options1MainTab.Text = "Options 1";
            this.Options1MainTab.UseVisualStyleBackColor = true;
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.numericUpDown6);
            this.groupBox23.Controls.Add(this.numericUpDown7);
            this.groupBox23.Controls.Add(this.label4);
            this.groupBox23.Controls.Add(this.label5);
            this.groupBox23.Controls.Add(this.label6);
            this.groupBox23.Controls.Add(this.selectedHateControl);
            this.groupBox23.Controls.Add(this.tank);
            this.groupBox23.Location = new System.Drawing.Point(7, 116);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(314, 68);
            this.groupBox23.TabIndex = 1;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Hate Control";
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown6.Location = new System.Drawing.Point(207, 39);
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown6.TabIndex = 108;
            this.numericUpDown6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown6.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDown7
            // 
            this.numericUpDown7.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown7.Location = new System.Drawing.Point(125, 39);
            this.numericUpDown7.Name = "numericUpDown7";
            this.numericUpDown7.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown7.TabIndex = 107;
            this.numericUpDown7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown7.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 106;
            this.label4.Text = "Mob HP% to Tank";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(257, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 110;
            this.label5.Text = "MAX";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(175, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 109;
            this.label6.Text = "MIN";
            // 
            // selectedHateControl
            // 
            this.selectedHateControl.Enabled = false;
            this.selectedHateControl.FormattingEnabled = true;
            this.selectedHateControl.Location = new System.Drawing.Point(125, 16);
            this.selectedHateControl.Name = "selectedHateControl";
            this.selectedHateControl.Size = new System.Drawing.Size(176, 21);
            this.selectedHateControl.TabIndex = 105;
            // 
            // tank
            // 
            this.tank.AutoSize = true;
            this.tank.Location = new System.Drawing.Point(18, 17);
            this.tank.Name = "tank";
            this.tank.Size = new System.Drawing.Size(73, 17);
            this.tank.TabIndex = 104;
            this.tank.Text = "Tank with";
            this.tank.UseVisualStyleBackColor = true;
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.amname);
            this.groupBox20.Controls.Add(this.AfterMathTier);
            this.groupBox20.Controls.Add(this.wsam);
            this.groupBox20.Controls.Add(this.checkBox6);
            this.groupBox20.Controls.Add(this.comboBox2);
            this.groupBox20.Controls.Add(this.label39);
            this.groupBox20.Controls.Add(this.numericUpDown40);
            this.groupBox20.Controls.Add(this.ws);
            this.groupBox20.Controls.Add(this.numericUpDown24);
            this.groupBox20.Controls.Add(this.label29);
            this.groupBox20.Controls.Add(this.numericUpDown22);
            this.groupBox20.Controls.Add(this.label28);
            this.groupBox20.Controls.Add(this.numericUpDown23);
            this.groupBox20.Controls.Add(this.label27);
            this.groupBox20.Location = new System.Drawing.Point(6, 6);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(315, 109);
            this.groupBox20.TabIndex = 0;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Weapon Skills";
            // 
            // amname
            // 
            this.amname.AutoCompleteCustomSource.AddRange(new string[] {
            "Cloudsplitter",
            "Ukko\'s Fury",
            "Dagan",
            "Rudra\'s Storm",
            "Victory Smite",
            "Blade: Hi",
            "Tachi: Fudo",
            "Camlann\'s Torment",
            "Quietus",
            "Myrkr",
            "Chant du Cygne",
            "Torcleaver",
            "Jishnu\'s Radiance",
            "Wildfire",
            "Final Heaven",
            "Mercy Stroke",
            "Knights of Round",
            "Scourge",
            "Onslaught",
            "Metatron Torment",
            "Catastrophe",
            "Geirskogul",
            "Blade: Metsu",
            "Tachi: Kaiten",
            "Randgrith",
            "Gate of Tartarus",
            "Coronach",
            "Namas Arrow",
            "King\'s Justice",
            "Ascetic\'s Fury",
            "Mystic Boon",
            "Vidohunir",
            "Death Blossom",
            "Mandalic Stab",
            "Atonement",
            "Insurgency",
            "Primal Rend",
            "Mordant Rime",
            "Trueflight",
            "Tachi: Rana",
            "Blade: Kamu",
            "Drakesbane",
            "Garland of Bliss",
            "Expiacion",
            "Leaden Salute",
            "Stringing Pummel",
            "Pyrrhic Kleos",
            "Omniscience"});
            this.amname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.amname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.amname.FormattingEnabled = true;
            this.amname.Location = new System.Drawing.Point(188, 38);
            this.amname.Name = "amname";
            this.amname.Size = new System.Drawing.Size(112, 21);
            this.amname.Sorted = true;
            this.amname.TabIndex = 109;
            // 
            // AfterMathTier
            // 
            this.AfterMathTier.Location = new System.Drawing.Point(124, 37);
            this.AfterMathTier.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.AfterMathTier.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AfterMathTier.Name = "AfterMathTier";
            this.AfterMathTier.Size = new System.Drawing.Size(44, 20);
            this.AfterMathTier.TabIndex = 108;
            this.AfterMathTier.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AfterMathTier.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // wsam
            // 
            this.wsam.AutoSize = true;
            this.wsam.Location = new System.Drawing.Point(17, 40);
            this.wsam.Name = "wsam";
            this.wsam.Size = new System.Drawing.Size(97, 17);
            this.wsam.TabIndex = 105;
            this.wsam.Text = "Use TP w/ AM";
            this.wsam.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(17, 62);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(89, 17);
            this.checkBox6.TabIndex = 104;
            this.checkBox6.Text = "WS Distance";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.AutoCompleteCustomSource.AddRange(new string[] {
            "Combo",
            "Shoulder Tackle",
            "One Inch Punch",
            "Backhand Blow",
            "Raging Fists",
            "Spinning Attack",
            "Howling Fist",
            "Dragon Kick",
            "Asuran Fists",
            "Final Heaven",
            "Ascetic\'s Fury",
            "Stringing Pummel",
            "Tornado Kick",
            "Victory Smite",
            "Shijin Spiral",
            "Wasp Sting",
            "Gust Slash",
            "Shadow Stitch",
            "Viper Bite",
            "Cyclone",
            "Energy Steal",
            "Energy Drain",
            "Dancing Edge",
            "Shark Bite",
            "Evisceration",
            "Mercy Stroke",
            "Mandalic Stab",
            "Mordant Rime",
            "Pyrrhic Kleos",
            "Aeolian Edge",
            "Rudra\'s Storm",
            "Exenterator",
            "Fast Blade",
            "Burning Blade",
            "Red Lotus Blade",
            "Flat Blade",
            "Shining Blade",
            "Seraph Blade",
            "Circle Blade",
            "Spirits Within",
            "Vorpal Blade",
            "Swift Blade",
            "Savage Blade",
            "Knights of Round",
            "Death Blossom",
            "Atonement",
            "Expiacion",
            "Sanguine Blade",
            "Chant du Cygne",
            "Requiescat",
            "Hard Slash",
            "Power Slash",
            "Frostbite",
            "Freezebite",
            "Shockwave",
            "Crescent Moon",
            "Sickle Moon",
            "Spinning Slash",
            "Ground Strike",
            "Scourge",
            "Herculean Slash",
            "Torcleaver",
            "Resolution",
            "Raging Axe",
            "Smash Axe",
            "Gale Axe",
            "Avalanche Axe",
            "Spinning Axe",
            "Rampage",
            "Calamity",
            "Mistral Axe",
            "Decimation",
            "Onslaught",
            "Primal Rend",
            "Bora Axe",
            "Cloudsplitter",
            "Ruinator",
            "Shield Break",
            "Iron Tempest",
            "Sturmwind",
            "Armor Break",
            "Keen Edge",
            "Weapon Break",
            "Raging Rush",
            "Full Break",
            "Steel Cyclone",
            "Metatron Torment",
            "King\'s Justice",
            "Fell Cleave",
            "Ukko\'s Fury",
            "Upheaval",
            "Slice",
            "Dark Harvest",
            "Shadow of Death",
            "Nightmare Scythe",
            "Spinning Scythe",
            "Vorpal Scythe",
            "Guillotine",
            "Cross Reaper",
            "Spiral Hell",
            "Catastrophe",
            "Insurgency",
            "Infernal Scythe",
            "Quietus",
            "Entropy",
            "Double Thrust",
            "Thunder Thrust",
            "Raiden Thrust",
            "Leg Sweep",
            "Penta Thrust",
            "Vorpal Thrust",
            "Skewer",
            "Wheeling Thrust",
            "Impulse Drive",
            "Geirskogul",
            "Drakesbane",
            "Sonic Thrust",
            "Camlann\'s Torment",
            "Stardiver",
            "Blade: Rin",
            "Blade: Retsu",
            "Blade: Teki",
            "Blade: To",
            "Blade: Chi",
            "Blade: Ei",
            "Blade: Jin",
            "Blade: Ten",
            "Blade: Ku",
            "Blade: Metsu",
            "Blade: Kamu",
            "Blade: Yu",
            "Blade: Hi",
            "Blade: Shun",
            "Tachi: Enpi",
            "Tachi: Hobaku",
            "Tachi: Goten",
            "Tachi: Kagero",
            "Tachi: Jinpu",
            "Tachi: Koki",
            "Tachi: Yukikaze",
            "Tachi: Gekko",
            "Tachi: Kasha",
            "Tachi: Kaiten",
            "Tachi: Rana",
            "Tachi: Ageha",
            "Tachi: Fudo",
            "Tachi: Shoha",
            "Shining Strike",
            "Seraph Strike",
            "Brainshaker",
            "Starlight",
            "Moonlight",
            "Skullbreaker",
            "True Strike",
            "Judgment",
            "Hexa Strike",
            "Black Halo",
            "Randgrith",
            "Mystic Boon",
            "Flash Nova",
            "Dagan",
            "Realmrazer",
            "Heavy Swing",
            "Rock Crusher",
            "Earth Crusher",
            "Starburst",
            "Sunburst",
            "Shell Crusher",
            "Full Swing",
            "Spirit Taker",
            "Retribution",
            "Gates of Tartarus",
            "Vidohunir",
            "Garland of Bliss",
            "Omniscience",
            "Cataclysm",
            "Myrkr",
            "Shattersoul",
            "Flaming Arrow",
            "Piercing Arrow",
            "Dulling Arrow",
            "Sidewinder",
            "Blast Arrow",
            "Arching Arrow",
            "Empyreal Arrow",
            "Namas Arrow",
            "Refulgent Arrow",
            "Jishnu\'s Radiance",
            "Apex Arrow",
            "Hot Shot",
            "Split Shot",
            "Sniper Shot",
            "Slug Shot",
            "Blast Shot",
            "Heavy Shot",
            "Detonator",
            "Coronach",
            "Trueflight",
            "Leaden Salute",
            "Numbing Shot",
            "Wildfire",
            "Last Stand",
            "Slapstick",
            "Arcuballista",
            "String Clipper",
            "Chimera Ripper",
            "Knockout",
            "Magic Mortar",
            "Daze",
            "Armor Piercer",
            "Cannibal Blade",
            "Bone Crusher"});
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(188, 15);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(112, 21);
            this.comboBox2.Sorted = true;
            this.comboBox2.TabIndex = 102;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(171, 19);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(15, 13);
            this.label39.TabIndex = 101;
            this.label39.Text = "%";
            // 
            // numericUpDown40
            // 
            this.numericUpDown40.DecimalPlaces = 1;
            this.numericUpDown40.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.numericUpDown40.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown40.Location = new System.Drawing.Point(124, 59);
            this.numericUpDown40.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown40.Name = "numericUpDown40";
            this.numericUpDown40.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown40.TabIndex = 103;
            this.numericUpDown40.TabStop = false;
            this.numericUpDown40.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown40.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ws
            // 
            this.ws.AutoSize = true;
            this.ws.Location = new System.Drawing.Point(17, 18);
            this.ws.Name = "ws";
            this.ws.Size = new System.Drawing.Size(62, 17);
            this.ws.TabIndex = 94;
            this.ws.Text = "Use TP";
            this.ws.UseVisualStyleBackColor = true;
            // 
            // numericUpDown24
            // 
            this.numericUpDown24.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown24.Location = new System.Drawing.Point(124, 15);
            this.numericUpDown24.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDown24.Name = "numericUpDown24";
            this.numericUpDown24.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown24.TabIndex = 95;
            this.numericUpDown24.TabStop = false;
            this.numericUpDown24.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown24.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(174, 85);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(27, 13);
            this.label29.TabIndex = 99;
            this.label29.Text = "MIN";
            // 
            // numericUpDown22
            // 
            this.numericUpDown22.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown22.Location = new System.Drawing.Point(206, 81);
            this.numericUpDown22.Name = "numericUpDown22";
            this.numericUpDown22.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown22.TabIndex = 98;
            this.numericUpDown22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown22.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(256, 85);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(30, 13);
            this.label28.TabIndex = 100;
            this.label28.Text = "MAX";
            // 
            // numericUpDown23
            // 
            this.numericUpDown23.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown23.Location = new System.Drawing.Point(124, 81);
            this.numericUpDown23.Name = "numericUpDown23";
            this.numericUpDown23.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown23.TabIndex = 97;
            this.numericUpDown23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown23.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(14, 85);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(87, 13);
            this.label27.TabIndex = 96;
            this.label27.Text = "Mob HP% to WS";
            // 
            // Options2MainTab
            // 
            this.Options2MainTab.Controls.Add(this.numericUpDown38);
            this.Options2MainTab.Controls.Add(this.aggroRange);
            this.Options2MainTab.Controls.Add(this.ScanDelay);
            this.Options2MainTab.Controls.Add(this.KeepTargetRange);
            this.Options2MainTab.Controls.Add(this.assistDist);
            this.Options2MainTab.Controls.Add(this.followDist);
            this.Options2MainTab.Controls.Add(this.partyAssist);
            this.Options2MainTab.Controls.Add(this.facetarget);
            this.Options2MainTab.Controls.Add(this.label12);
            this.Options2MainTab.Controls.Add(this.assist);
            this.Options2MainTab.Controls.Add(this.followplayer);
            this.Options2MainTab.Controls.Add(this.followName);
            this.Options2MainTab.Controls.Add(this.useshadows);
            this.Options2MainTab.Controls.Add(this.label11);
            this.Options2MainTab.Controls.Add(this.assistplayer);
            this.Options2MainTab.Controls.Add(this.aggro);
            this.Options2MainTab.Controls.Add(this.mobdist);
            this.Options2MainTab.Location = new System.Drawing.Point(4, 22);
            this.Options2MainTab.Name = "Options2MainTab";
            this.Options2MainTab.Padding = new System.Windows.Forms.Padding(3);
            this.Options2MainTab.Size = new System.Drawing.Size(327, 190);
            this.Options2MainTab.TabIndex = 1;
            this.Options2MainTab.Text = "Options 2";
            this.Options2MainTab.UseVisualStyleBackColor = true;
            // 
            // numericUpDown38
            // 
            this.numericUpDown38.DecimalPlaces = 1;
            this.numericUpDown38.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown38.Location = new System.Drawing.Point(238, 155);
            this.numericUpDown38.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown38.Name = "numericUpDown38";
            this.numericUpDown38.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown38.TabIndex = 92;
            this.numericUpDown38.TabStop = false;
            this.numericUpDown38.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown38.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // aggroRange
            // 
            this.aggroRange.DecimalPlaces = 1;
            this.aggroRange.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.aggroRange.Location = new System.Drawing.Point(238, 109);
            this.aggroRange.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.aggroRange.Name = "aggroRange";
            this.aggroRange.Size = new System.Drawing.Size(44, 20);
            this.aggroRange.TabIndex = 107;
            this.aggroRange.TabStop = false;
            this.aggroRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.aggroRange.Value = new decimal(new int[] {
            85,
            0,
            0,
            65536});
            // 
            // ScanDelay
            // 
            this.ScanDelay.AutoSize = true;
            this.ScanDelay.Location = new System.Drawing.Point(45, 157);
            this.ScanDelay.Name = "ScanDelay";
            this.ScanDelay.Size = new System.Drawing.Size(125, 17);
            this.ScanDelay.TabIndex = 90;
            this.ScanDelay.Text = "Delay between mobs";
            this.ScanDelay.UseVisualStyleBackColor = true;
            // 
            // KeepTargetRange
            // 
            this.KeepTargetRange.DecimalPlaces = 1;
            this.KeepTargetRange.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.KeepTargetRange.Location = new System.Drawing.Point(238, 132);
            this.KeepTargetRange.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.KeepTargetRange.Name = "KeepTargetRange";
            this.KeepTargetRange.Size = new System.Drawing.Size(44, 20);
            this.KeepTargetRange.TabIndex = 106;
            this.KeepTargetRange.TabStop = false;
            this.KeepTargetRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.KeepTargetRange.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // assistDist
            // 
            this.assistDist.DecimalPlaces = 1;
            this.assistDist.Enabled = false;
            this.assistDist.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.assistDist.Location = new System.Drawing.Point(238, 42);
            this.assistDist.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.assistDist.Name = "assistDist";
            this.assistDist.Size = new System.Drawing.Size(44, 20);
            this.assistDist.TabIndex = 105;
            this.assistDist.TabStop = false;
            this.assistDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.assistDist.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // followDist
            // 
            this.followDist.DecimalPlaces = 1;
            this.followDist.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.followDist.Location = new System.Drawing.Point(238, 16);
            this.followDist.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.followDist.Name = "followDist";
            this.followDist.Size = new System.Drawing.Size(44, 20);
            this.followDist.TabIndex = 104;
            this.followDist.TabStop = false;
            this.followDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.followDist.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // partyAssist
            // 
            this.partyAssist.AutoSize = true;
            this.partyAssist.Location = new System.Drawing.Point(45, 66);
            this.partyAssist.Name = "partyAssist";
            this.partyAssist.Size = new System.Drawing.Size(229, 17);
            this.partyAssist.TabIndex = 103;
            this.partyAssist.Text = "Assist Party Members (uses assist distance)";
            this.partyAssist.UseVisualStyleBackColor = true;
            // 
            // facetarget
            // 
            this.facetarget.AutoSize = true;
            this.facetarget.Location = new System.Drawing.Point(152, 88);
            this.facetarget.Name = "facetarget";
            this.facetarget.Size = new System.Drawing.Size(120, 17);
            this.facetarget.TabIndex = 96;
            this.facetarget.Text = "Keep Facing Target";
            this.facetarget.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(207, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 13);
            this.label12.TabIndex = 101;
            this.label12.Text = "Dist";
            // 
            // assist
            // 
            this.assist.AutoSize = true;
            this.assist.Location = new System.Drawing.Point(45, 44);
            this.assist.Name = "assist";
            this.assist.Size = new System.Drawing.Size(53, 17);
            this.assist.TabIndex = 100;
            this.assist.Text = "Assist";
            this.assist.UseVisualStyleBackColor = true;
            this.assist.CheckedChanged += new System.EventHandler(this.AssistCheckedChanged);
            // 
            // followplayer
            // 
            this.followplayer.AutoSize = true;
            this.followplayer.Location = new System.Drawing.Point(45, 18);
            this.followplayer.Name = "followplayer";
            this.followplayer.Size = new System.Drawing.Size(56, 17);
            this.followplayer.TabIndex = 95;
            this.followplayer.Text = "Follow";
            this.followplayer.UseVisualStyleBackColor = true;
            // 
            // followName
            // 
            this.followName.Location = new System.Drawing.Point(101, 16);
            this.followName.Name = "followName";
            this.followName.Size = new System.Drawing.Size(100, 20);
            this.followName.TabIndex = 97;
            // 
            // useshadows
            // 
            this.useshadows.AutoSize = true;
            this.useshadows.Location = new System.Drawing.Point(45, 88);
            this.useshadows.Name = "useshadows";
            this.useshadows.Size = new System.Drawing.Size(92, 17);
            this.useshadows.TabIndex = 94;
            this.useshadows.Text = "Use Shadows";
            this.useshadows.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(207, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 13);
            this.label11.TabIndex = 98;
            this.label11.Text = "Dist";
            // 
            // assistplayer
            // 
            this.assistplayer.Location = new System.Drawing.Point(101, 42);
            this.assistplayer.Name = "assistplayer";
            this.assistplayer.Size = new System.Drawing.Size(100, 20);
            this.assistplayer.TabIndex = 99;
            // 
            // aggro
            // 
            this.aggro.AutoSize = true;
            this.aggro.Location = new System.Drawing.Point(45, 111);
            this.aggro.Name = "aggro";
            this.aggro.Size = new System.Drawing.Size(171, 17);
            this.aggro.TabIndex = 91;
            this.aggro.Text = "Aggro Detection + Auto Attack";
            this.aggro.UseVisualStyleBackColor = true;
            // 
            // mobdist
            // 
            this.mobdist.AutoSize = true;
            this.mobdist.Location = new System.Drawing.Point(45, 134);
            this.mobdist.Name = "mobdist";
            this.mobdist.Size = new System.Drawing.Size(151, 17);
            this.mobdist.TabIndex = 93;
            this.mobdist.Text = "Keep Within Melee Range";
            this.mobdist.UseVisualStyleBackColor = true;
            // 
            // Options3MainTab
            // 
            this.Options3MainTab.Controls.Add(this.comboBox4);
            this.Options3MainTab.Controls.Add(this.SignetStaff);
            this.Options3MainTab.Controls.Add(this.label7);
            this.Options3MainTab.Controls.Add(this.label3);
            this.Options3MainTab.Controls.Add(this.useStaff);
            this.Options3MainTab.Controls.Add(this.textBox8);
            this.Options3MainTab.Controls.Add(this.healMPcount);
            this.Options3MainTab.Controls.Add(this.usefood);
            this.Options3MainTab.Controls.Add(this.HealMP);
            this.Options3MainTab.Controls.Add(this.healHPcount);
            this.Options3MainTab.Controls.Add(this.RecordIdleLocation);
            this.Options3MainTab.Controls.Add(this.WeakLocation);
            this.Options3MainTab.Controls.Add(this.HealHP);
            this.Options3MainTab.Controls.Add(this.textBox6);
            this.Options3MainTab.Controls.Add(this.IdleLocation);
            this.Options3MainTab.Controls.Add(this.label35);
            this.Options3MainTab.Location = new System.Drawing.Point(4, 22);
            this.Options3MainTab.Name = "Options3MainTab";
            this.Options3MainTab.Padding = new System.Windows.Forms.Padding(3);
            this.Options3MainTab.Size = new System.Drawing.Size(327, 190);
            this.Options3MainTab.TabIndex = 0;
            this.Options3MainTab.Text = "Options 3";
            this.Options3MainTab.UseVisualStyleBackColor = true;
            // 
            // comboBox4
            // 
            this.comboBox4.Enabled = false;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "Federation Signet Staff",
            "Kingdom Signet Staff",
            "Republic Signet Staff"});
            this.comboBox4.Location = new System.Drawing.Point(167, 137);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(152, 21);
            this.comboBox4.TabIndex = 18;
            // 
            // SignetStaff
            // 
            this.SignetStaff.Enabled = false;
            this.SignetStaff.FormattingEnabled = true;
            this.SignetStaff.Items.AddRange(new object[] {
            "Federation Signet Staff",
            "Kingdom Signet Staff",
            "Republic Signet Staff"});
            this.SignetStaff.Location = new System.Drawing.Point(167, 160);
            this.SignetStaff.Name = "SignetStaff";
            this.SignetStaff.Size = new System.Drawing.Size(152, 21);
            this.SignetStaff.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(174, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 68;
            this.label7.Text = "%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 67;
            this.label3.Text = "%";
            // 
            // useStaff
            // 
            this.useStaff.AutoSize = true;
            this.useStaff.Enabled = false;
            this.useStaff.Location = new System.Drawing.Point(6, 163);
            this.useStaff.Name = "useStaff";
            this.useStaff.Size = new System.Drawing.Size(103, 17);
            this.useStaff.TabIndex = 16;
            this.useStaff.Text = "Use Signet Staff";
            this.useStaff.UseVisualStyleBackColor = true;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(128, 33);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(176, 20);
            this.textBox8.TabIndex = 66;
            this.textBox8.TabStop = false;
            // 
            // healMPcount
            // 
            this.healMPcount.Location = new System.Drawing.Point(128, 77);
            this.healMPcount.Name = "healMPcount";
            this.healMPcount.Size = new System.Drawing.Size(44, 20);
            this.healMPcount.TabIndex = 64;
            this.healMPcount.TabStop = false;
            this.healMPcount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.healMPcount.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // usefood
            // 
            this.usefood.AutoSize = true;
            this.usefood.Location = new System.Drawing.Point(21, 35);
            this.usefood.Name = "usefood";
            this.usefood.Size = new System.Drawing.Size(72, 17);
            this.usefood.TabIndex = 65;
            this.usefood.TabStop = false;
            this.usefood.Text = "Use Food";
            this.usefood.UseVisualStyleBackColor = true;
            // 
            // HealMP
            // 
            this.HealMP.AutoSize = true;
            this.HealMP.Location = new System.Drawing.Point(21, 80);
            this.HealMP.Name = "HealMP";
            this.HealMP.Size = new System.Drawing.Size(67, 17);
            this.HealMP.TabIndex = 63;
            this.HealMP.TabStop = false;
            this.HealMP.Text = "Heal MP";
            this.HealMP.UseVisualStyleBackColor = true;
            // 
            // healHPcount
            // 
            this.healHPcount.Location = new System.Drawing.Point(128, 55);
            this.healHPcount.Name = "healHPcount";
            this.healHPcount.Size = new System.Drawing.Size(44, 20);
            this.healHPcount.TabIndex = 62;
            this.healHPcount.TabStop = false;
            this.healHPcount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.healHPcount.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // RecordIdleLocation
            // 
            this.RecordIdleLocation.Location = new System.Drawing.Point(167, 115);
            this.RecordIdleLocation.Name = "RecordIdleLocation";
            this.RecordIdleLocation.Size = new System.Drawing.Size(152, 21);
            this.RecordIdleLocation.TabIndex = 14;
            this.RecordIdleLocation.Text = "record location";
            this.RecordIdleLocation.UseVisualStyleBackColor = true;
            // 
            // WeakLocation
            // 
            this.WeakLocation.AutoSize = true;
            this.WeakLocation.Enabled = false;
            this.WeakLocation.Location = new System.Drawing.Point(6, 140);
            this.WeakLocation.Name = "WeakLocation";
            this.WeakLocation.Size = new System.Drawing.Size(119, 17);
            this.WeakLocation.TabIndex = 11;
            this.WeakLocation.Text = "Weakened location";
            this.WeakLocation.UseVisualStyleBackColor = true;
            // 
            // HealHP
            // 
            this.HealHP.AutoSize = true;
            this.HealHP.Location = new System.Drawing.Point(21, 58);
            this.HealHP.Name = "HealHP";
            this.HealHP.Size = new System.Drawing.Size(66, 17);
            this.HealHP.TabIndex = 61;
            this.HealHP.TabStop = false;
            this.HealHP.Text = "Heal HP";
            this.HealHP.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(128, 10);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(176, 20);
            this.textBox6.TabIndex = 60;
            this.textBox6.TabStop = false;
            // 
            // IdleLocation
            // 
            this.IdleLocation.AutoSize = true;
            this.IdleLocation.Enabled = false;
            this.IdleLocation.Location = new System.Drawing.Point(6, 117);
            this.IdleLocation.Name = "IdleLocation";
            this.IdleLocation.Size = new System.Drawing.Size(113, 17);
            this.IdleLocation.TabIndex = 12;
            this.IdleLocation.Text = "Idle return location";
            this.IdleLocation.UseVisualStyleBackColor = true;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(18, 12);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(99, 13);
            this.label35.TabIndex = 59;
            this.label35.Text = "On Heal Equip Item";
            // 
            // Options4MainTab
            // 
            this.Options4MainTab.Controls.Add(this.DropBox);
            this.Options4MainTab.Controls.Add(this.groupBox15);
            this.Options4MainTab.Location = new System.Drawing.Point(4, 22);
            this.Options4MainTab.Name = "Options4MainTab";
            this.Options4MainTab.Padding = new System.Windows.Forms.Padding(3);
            this.Options4MainTab.Size = new System.Drawing.Size(327, 190);
            this.Options4MainTab.TabIndex = 5;
            this.Options4MainTab.Text = "Options 4";
            this.Options4MainTab.UseVisualStyleBackColor = true;
            // 
            // DropBox
            // 
            this.DropBox.Controls.Add(this.comboBox7);
            this.DropBox.Controls.Add(this.comboBox6);
            this.DropBox.Controls.Add(this.checkBox3);
            this.DropBox.Controls.Add(this.checkBox2);
            this.DropBox.Location = new System.Drawing.Point(7, 118);
            this.DropBox.Name = "DropBox";
            this.DropBox.Size = new System.Drawing.Size(313, 66);
            this.DropBox.TabIndex = 16;
            this.DropBox.TabStop = false;
            this.DropBox.Text = "Drop Item";
            this.DropBox.Visible = false;
            // 
            // comboBox7
            // 
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(137, 38);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(153, 21);
            this.comboBox7.TabIndex = 11;
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(137, 14);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(153, 21);
            this.comboBox6.TabIndex = 10;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(23, 40);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(67, 17);
            this.checkBox3.TabIndex = 9;
            this.checkBox3.Text = "Treasury";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(23, 17);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(76, 17);
            this.checkBox2.TabIndex = 8;
            this.checkBox2.Text = "Lootwhore";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.label42);
            this.groupBox15.Controls.Add(this.autoRangeDelay);
            this.groupBox15.Controls.Add(this.textBox7);
            this.groupBox15.Controls.Add(this.rangeaggro);
            this.groupBox15.Controls.Add(this.comboBox1);
            this.groupBox15.Controls.Add(this.checkBox4);
            this.groupBox15.Controls.Add(this.autoRangeAttack);
            this.groupBox15.Location = new System.Drawing.Point(7, 7);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(313, 90);
            this.groupBox15.TabIndex = 15;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "ammo / ranged options";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(144, 65);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(37, 13);
            this.label42.TabIndex = 57;
            this.label42.Text = "Delay:";
            // 
            // autoRangeDelay
            // 
            this.autoRangeDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.autoRangeDelay.DecimalPlaces = 1;
            this.autoRangeDelay.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.autoRangeDelay.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.autoRangeDelay.Location = new System.Drawing.Point(182, 62);
            this.autoRangeDelay.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.autoRangeDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.autoRangeDelay.Name = "autoRangeDelay";
            this.autoRangeDelay.Size = new System.Drawing.Size(44, 20);
            this.autoRangeDelay.TabIndex = 56;
            this.autoRangeDelay.TabStop = false;
            this.autoRangeDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.autoRangeDelay.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(23, 62);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(120, 20);
            this.textBox7.TabIndex = 48;
            this.textBox7.Text = "/ra <t>";
            // 
            // rangeaggro
            // 
            this.rangeaggro.AutoSize = true;
            this.rangeaggro.Location = new System.Drawing.Point(161, 42);
            this.rangeaggro.Name = "rangeaggro";
            this.rangeaggro.Size = new System.Drawing.Size(118, 17);
            this.rangeaggro.TabIndex = 47;
            this.rangeaggro.Text = "Range Aggro-Mobs";
            this.rangeaggro.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(137, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(153, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Enabled = false;
            this.checkBox4.Location = new System.Drawing.Point(23, 20);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(108, 17);
            this.checkBox4.TabIndex = 2;
            this.checkBox4.Text = "Auto equip ammo";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // autoRangeAttack
            // 
            this.autoRangeAttack.AutoSize = true;
            this.autoRangeAttack.Location = new System.Drawing.Point(23, 42);
            this.autoRangeAttack.Name = "autoRangeAttack";
            this.autoRangeAttack.Size = new System.Drawing.Size(123, 17);
            this.autoRangeAttack.TabIndex = 46;
            this.autoRangeAttack.Text = "Auto (Range Attack)";
            this.autoRangeAttack.UseVisualStyleBackColor = true;
            // 
            // OptionsJAMainTab
            // 
            this.OptionsJAMainTab.Controls.Add(this.JAtabselect);
            this.OptionsJAMainTab.Location = new System.Drawing.Point(4, 22);
            this.OptionsJAMainTab.Name = "OptionsJAMainTab";
            this.OptionsJAMainTab.Padding = new System.Windows.Forms.Padding(3);
            this.OptionsJAMainTab.Size = new System.Drawing.Size(327, 190);
            this.OptionsJAMainTab.TabIndex = 4;
            this.OptionsJAMainTab.Text = "JA\'s";
            this.OptionsJAMainTab.UseVisualStyleBackColor = true;
            // 
            // JAtabselect
            // 
            this.JAtabselect.Controls.Add(this.selectPage);
            this.JAtabselect.Controls.Add(this.WHMpage);
            this.JAtabselect.Controls.Add(this.RDMpage);
            this.JAtabselect.Controls.Add(this.SCHpage);
            this.JAtabselect.Controls.Add(this.RUNpage);
            this.JAtabselect.Controls.Add(this.MONpage);
            this.JAtabselect.Controls.Add(this.Dynamispage);
            this.JAtabselect.Location = new System.Drawing.Point(4, 3);
            this.JAtabselect.Name = "JAtabselect";
            this.JAtabselect.SelectedIndex = 0;
            this.JAtabselect.Size = new System.Drawing.Size(320, 186);
            this.JAtabselect.TabIndex = 0;
            // 
            // selectPage
            // 
            this.selectPage.Controls.Add(this.playerJA);
            this.selectPage.Controls.Add(this.GetSetJA);
            this.selectPage.Location = new System.Drawing.Point(4, 22);
            this.selectPage.Name = "selectPage";
            this.selectPage.Padding = new System.Windows.Forms.Padding(3);
            this.selectPage.Size = new System.Drawing.Size(312, 160);
            this.selectPage.TabIndex = 0;
            this.selectPage.Text = "Select";
            this.selectPage.UseVisualStyleBackColor = true;
            // 
            // playerJA
            // 
            this.playerJA.CheckOnClick = true;
            this.playerJA.FormattingEnabled = true;
            this.playerJA.Location = new System.Drawing.Point(52, 9);
            this.playerJA.Name = "playerJA";
            this.playerJA.Size = new System.Drawing.Size(213, 109);
            this.playerJA.TabIndex = 13;
            this.playerJA.SelectedIndexChanged += new System.EventHandler(this.playerJA_SelectedIndexChanged);
            // 
            // GetSetJA
            // 
            this.GetSetJA.Dock = System.Windows.Forms.DockStyle.None;
            this.GetSetJA.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadJAsToolStripMenuItem,
            this.clearJAsToolStripMenuItem});
            this.GetSetJA.Location = new System.Drawing.Point(73, 130);
            this.GetSetJA.Name = "GetSetJA";
            this.GetSetJA.Size = new System.Drawing.Size(145, 24);
            this.GetSetJA.TabIndex = 11;
            this.GetSetJA.Text = "GetSetJA";
            // 
            // loadJAsToolStripMenuItem
            // 
            this.loadJAsToolStripMenuItem.Name = "loadJAsToolStripMenuItem";
            this.loadJAsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.loadJAsToolStripMenuItem.Text = "Load JA\'s";
            this.loadJAsToolStripMenuItem.Click += new System.EventHandler(this.LoadJA_Click);
            // 
            // clearJAsToolStripMenuItem
            // 
            this.clearJAsToolStripMenuItem.Name = "clearJAsToolStripMenuItem";
            this.clearJAsToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.clearJAsToolStripMenuItem.Text = "Clear JA\'s";
            this.clearJAsToolStripMenuItem.Click += new System.EventHandler(this.ClearJA_Click);
            // 
            // WHMpage
            // 
            this.WHMpage.Controls.Add(this.benedictiongroupBox);
            this.WHMpage.Location = new System.Drawing.Point(4, 22);
            this.WHMpage.Name = "WHMpage";
            this.WHMpage.Padding = new System.Windows.Forms.Padding(3);
            this.WHMpage.Size = new System.Drawing.Size(312, 160);
            this.WHMpage.TabIndex = 1;
            this.WHMpage.Text = "WHM";
            this.WHMpage.UseVisualStyleBackColor = true;
            // 
            // benedictiongroupBox
            // 
            this.benedictiongroupBox.Controls.Add(this.BenedictionHPPuse);
            this.benedictiongroupBox.Controls.Add(this.benedictiontext);
            this.benedictiongroupBox.Location = new System.Drawing.Point(7, 7);
            this.benedictiongroupBox.Name = "benedictiongroupBox";
            this.benedictiongroupBox.Size = new System.Drawing.Size(91, 40);
            this.benedictiongroupBox.TabIndex = 0;
            this.benedictiongroupBox.TabStop = false;
            this.benedictiongroupBox.Text = "Benediction";
            // 
            // BenedictionHPPuse
            // 
            this.BenedictionHPPuse.Enabled = false;
            this.BenedictionHPPuse.Location = new System.Drawing.Point(41, 14);
            this.BenedictionHPPuse.Name = "BenedictionHPPuse";
            this.BenedictionHPPuse.Size = new System.Drawing.Size(44, 20);
            this.BenedictionHPPuse.TabIndex = 1;
            // 
            // benedictiontext
            // 
            this.benedictiontext.AutoSize = true;
            this.benedictiontext.Location = new System.Drawing.Point(3, 16);
            this.benedictiontext.Name = "benedictiontext";
            this.benedictiontext.Size = new System.Drawing.Size(33, 13);
            this.benedictiontext.TabIndex = 0;
            this.benedictiontext.Text = "HP %";
            // 
            // RDMpage
            // 
            this.RDMpage.Controls.Add(this.groupBox18);
            this.RDMpage.Location = new System.Drawing.Point(4, 22);
            this.RDMpage.Name = "RDMpage";
            this.RDMpage.Padding = new System.Windows.Forms.Padding(3);
            this.RDMpage.Size = new System.Drawing.Size(312, 160);
            this.RDMpage.TabIndex = 2;
            this.RDMpage.Text = "RDM";
            this.RDMpage.UseVisualStyleBackColor = true;
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.ConvertHPP);
            this.groupBox18.Controls.Add(this.ConvertMPP);
            this.groupBox18.Controls.Add(this.ConvertMP);
            this.groupBox18.Controls.Add(this.ConvertHP);
            this.groupBox18.Controls.Add(this.convertmptext);
            this.groupBox18.Controls.Add(this.converthptext);
            this.groupBox18.Location = new System.Drawing.Point(7, 9);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(167, 69);
            this.groupBox18.TabIndex = 0;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Convert";
            // 
            // ConvertHPP
            // 
            this.ConvertHPP.Enabled = false;
            this.ConvertHPP.Location = new System.Drawing.Point(111, 18);
            this.ConvertHPP.Name = "ConvertHPP";
            this.ConvertHPP.Size = new System.Drawing.Size(44, 20);
            this.ConvertHPP.TabIndex = 5;
            this.ConvertHPP.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // ConvertMPP
            // 
            this.ConvertMPP.Enabled = false;
            this.ConvertMPP.Location = new System.Drawing.Point(111, 40);
            this.ConvertMPP.Name = "ConvertMPP";
            this.ConvertMPP.Size = new System.Drawing.Size(44, 20);
            this.ConvertMPP.TabIndex = 4;
            this.ConvertMPP.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // ConvertMP
            // 
            this.ConvertMP.AutoSize = true;
            this.ConvertMP.Enabled = false;
            this.ConvertMP.Location = new System.Drawing.Point(6, 43);
            this.ConvertMP.Name = "ConvertMP";
            this.ConvertMP.Size = new System.Drawing.Size(60, 17);
            this.ConvertMP.TabIndex = 3;
            this.ConvertMP.Text = "For MP";
            this.ConvertMP.UseVisualStyleBackColor = true;
            // 
            // ConvertHP
            // 
            this.ConvertHP.AutoSize = true;
            this.ConvertHP.Enabled = false;
            this.ConvertHP.Location = new System.Drawing.Point(6, 19);
            this.ConvertHP.Name = "ConvertHP";
            this.ConvertHP.Size = new System.Drawing.Size(59, 17);
            this.ConvertHP.TabIndex = 2;
            this.ConvertHP.Text = "For HP";
            this.ConvertHP.UseVisualStyleBackColor = true;
            // 
            // convertmptext
            // 
            this.convertmptext.AutoSize = true;
            this.convertmptext.Location = new System.Drawing.Point(72, 42);
            this.convertmptext.Name = "convertmptext";
            this.convertmptext.Size = new System.Drawing.Size(34, 13);
            this.convertmptext.TabIndex = 1;
            this.convertmptext.Text = "MP %";
            // 
            // converthptext
            // 
            this.converthptext.AutoSize = true;
            this.converthptext.Location = new System.Drawing.Point(72, 20);
            this.converthptext.Name = "converthptext";
            this.converthptext.Size = new System.Drawing.Size(33, 13);
            this.converthptext.TabIndex = 0;
            this.converthptext.Text = "HP %";
            // 
            // SCHpage
            // 
            this.SCHpage.Controls.Add(this.Sublimationcount);
            this.SCHpage.Controls.Add(this.label8);
            this.SCHpage.Location = new System.Drawing.Point(4, 22);
            this.SCHpage.Name = "SCHpage";
            this.SCHpage.Padding = new System.Windows.Forms.Padding(3);
            this.SCHpage.Size = new System.Drawing.Size(312, 160);
            this.SCHpage.TabIndex = 6;
            this.SCHpage.Text = "SCH";
            this.SCHpage.UseVisualStyleBackColor = true;
            // 
            // Sublimationcount
            // 
            this.Sublimationcount.Enabled = false;
            this.Sublimationcount.Location = new System.Drawing.Point(98, 8);
            this.Sublimationcount.Name = "Sublimationcount";
            this.Sublimationcount.Size = new System.Drawing.Size(44, 20);
            this.Sublimationcount.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Sublimation @MP";
            // 
            // RUNpage
            // 
            this.RUNpage.Controls.Add(this.VivaciousPulseHP);
            this.RUNpage.Controls.Add(this.VivaciousPulse);
            this.RUNpage.Location = new System.Drawing.Point(4, 22);
            this.RUNpage.Name = "RUNpage";
            this.RUNpage.Padding = new System.Windows.Forms.Padding(3);
            this.RUNpage.Size = new System.Drawing.Size(312, 160);
            this.RUNpage.TabIndex = 3;
            this.RUNpage.Text = "RUN";
            this.RUNpage.UseVisualStyleBackColor = true;
            // 
            // VivaciousPulseHP
            // 
            this.VivaciousPulseHP.Enabled = false;
            this.VivaciousPulseHP.Location = new System.Drawing.Point(148, 8);
            this.VivaciousPulseHP.Name = "VivaciousPulseHP";
            this.VivaciousPulseHP.Size = new System.Drawing.Size(44, 20);
            this.VivaciousPulseHP.TabIndex = 6;
            // 
            // VivaciousPulse
            // 
            this.VivaciousPulse.AutoSize = true;
            this.VivaciousPulse.Enabled = false;
            this.VivaciousPulse.Location = new System.Drawing.Point(7, 9);
            this.VivaciousPulse.Name = "VivaciousPulse";
            this.VivaciousPulse.Size = new System.Drawing.Size(144, 17);
            this.VivaciousPulse.TabIndex = 0;
            this.VivaciousPulse.Text = "Vivacious Pulse @ HP %";
            this.VivaciousPulse.UseVisualStyleBackColor = true;
            // 
            // MONpage
            // 
            this.MONpage.Controls.Add(this.MONmpCount);
            this.MONpage.Controls.Add(this.MONhpCount);
            this.MONpage.Controls.Add(this.monmptext);
            this.MONpage.Controls.Add(this.monhptext);
            this.MONpage.Location = new System.Drawing.Point(4, 22);
            this.MONpage.Name = "MONpage";
            this.MONpage.Padding = new System.Windows.Forms.Padding(3);
            this.MONpage.Size = new System.Drawing.Size(312, 160);
            this.MONpage.TabIndex = 4;
            this.MONpage.Text = "MON";
            this.MONpage.UseVisualStyleBackColor = true;
            // 
            // MONmpCount
            // 
            this.MONmpCount.Enabled = false;
            this.MONmpCount.Location = new System.Drawing.Point(46, 30);
            this.MONmpCount.Name = "MONmpCount";
            this.MONmpCount.Size = new System.Drawing.Size(44, 20);
            this.MONmpCount.TabIndex = 7;
            this.MONmpCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // MONhpCount
            // 
            this.MONhpCount.Enabled = false;
            this.MONhpCount.Location = new System.Drawing.Point(46, 6);
            this.MONhpCount.Name = "MONhpCount";
            this.MONhpCount.Size = new System.Drawing.Size(44, 20);
            this.MONhpCount.TabIndex = 6;
            this.MONhpCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // monmptext
            // 
            this.monmptext.AutoSize = true;
            this.monmptext.Location = new System.Drawing.Point(7, 32);
            this.monmptext.Name = "monmptext";
            this.monmptext.Size = new System.Drawing.Size(34, 13);
            this.monmptext.TabIndex = 1;
            this.monmptext.Text = "MP %";
            // 
            // monhptext
            // 
            this.monhptext.AutoSize = true;
            this.monhptext.Location = new System.Drawing.Point(7, 9);
            this.monhptext.Name = "monhptext";
            this.monhptext.Size = new System.Drawing.Size(33, 13);
            this.monhptext.TabIndex = 0;
            this.monhptext.Text = "HP %";
            // 
            // Dynamispage
            // 
            this.Dynamispage.Controls.Add(this.Dynatxt);
            this.Dynamispage.Controls.Add(this.staggerstopJA);
            this.Dynamispage.Location = new System.Drawing.Point(4, 22);
            this.Dynamispage.Name = "Dynamispage";
            this.Dynamispage.Padding = new System.Windows.Forms.Padding(3);
            this.Dynamispage.Size = new System.Drawing.Size(312, 160);
            this.Dynamispage.TabIndex = 5;
            this.Dynamispage.Text = "Dynamis";
            this.Dynamispage.UseVisualStyleBackColor = true;
            // 
            // Dynatxt
            // 
            this.Dynatxt.AutoSize = true;
            this.Dynatxt.Location = new System.Drawing.Point(12, 45);
            this.Dynatxt.Name = "Dynatxt";
            this.Dynatxt.Size = new System.Drawing.Size(288, 13);
            this.Dynatxt.TabIndex = 2;
            this.Dynatxt.Text = "This will stop all JA\'s when a mob is !Staggered! in Dynamis.";
            // 
            // staggerstopJA
            // 
            this.staggerstopJA.AutoSize = true;
            this.staggerstopJA.Location = new System.Drawing.Point(77, 23);
            this.staggerstopJA.Name = "staggerstopJA";
            this.staggerstopJA.Size = new System.Drawing.Size(153, 17);
            this.staggerstopJA.TabIndex = 1;
            this.staggerstopJA.Text = "Stop Ja\'s When Staggered";
            this.staggerstopJA.UseVisualStyleBackColor = true;
            // 
            // OptionsMAMainTab
            // 
            this.OptionsMAMainTab.Controls.Add(this.MAtabs);
            this.OptionsMAMainTab.Location = new System.Drawing.Point(4, 22);
            this.OptionsMAMainTab.Name = "OptionsMAMainTab";
            this.OptionsMAMainTab.Padding = new System.Windows.Forms.Padding(3);
            this.OptionsMAMainTab.Size = new System.Drawing.Size(327, 190);
            this.OptionsMAMainTab.TabIndex = 7;
            this.OptionsMAMainTab.Text = "MA\'s";
            this.OptionsMAMainTab.UseVisualStyleBackColor = true;
            // 
            // MAtabs
            // 
            this.MAtabs.Controls.Add(this.MASelectPage);
            this.MAtabs.Controls.Add(this.CureConfigPage);
            this.MAtabs.Controls.Add(this.DrainAspirpage);
            this.MAtabs.Controls.Add(this.BLUCurespage);
            this.MAtabs.Controls.Add(this.MAconfigpage);
            this.MAtabs.Location = new System.Drawing.Point(7, 7);
            this.MAtabs.Name = "MAtabs";
            this.MAtabs.SelectedIndex = 0;
            this.MAtabs.Size = new System.Drawing.Size(314, 177);
            this.MAtabs.TabIndex = 0;
            // 
            // MASelectPage
            // 
            this.MASelectPage.Controls.Add(this.playerMA);
            this.MASelectPage.Controls.Add(this.GetSetMA);
            this.MASelectPage.Location = new System.Drawing.Point(4, 22);
            this.MASelectPage.Name = "MASelectPage";
            this.MASelectPage.Padding = new System.Windows.Forms.Padding(3);
            this.MASelectPage.Size = new System.Drawing.Size(306, 151);
            this.MASelectPage.TabIndex = 0;
            this.MASelectPage.Text = "Select";
            this.MASelectPage.UseVisualStyleBackColor = true;
            // 
            // playerMA
            // 
            this.playerMA.CheckOnClick = true;
            this.playerMA.FormattingEnabled = true;
            this.playerMA.Location = new System.Drawing.Point(47, 11);
            this.playerMA.Name = "playerMA";
            this.playerMA.Size = new System.Drawing.Size(213, 94);
            this.playerMA.TabIndex = 5;
            this.playerMA.SelectedIndexChanged += new System.EventHandler(this.playerMA_SelectedIndexChanged);
            // 
            // GetSetMA
            // 
            this.GetSetMA.Dock = System.Windows.Forms.DockStyle.None;
            this.GetSetMA.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMAsToolStripMenuItem,
            this.clearMAsToolStripMenuItem});
            this.GetSetMA.Location = new System.Drawing.Point(69, 121);
            this.GetSetMA.Name = "GetSetMA";
            this.GetSetMA.Size = new System.Drawing.Size(159, 24);
            this.GetSetMA.TabIndex = 16;
            this.GetSetMA.Text = "GetSetMA";
            // 
            // loadMAsToolStripMenuItem
            // 
            this.loadMAsToolStripMenuItem.Name = "loadMAsToolStripMenuItem";
            this.loadMAsToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.loadMAsToolStripMenuItem.Text = "Load MA\'s";
            this.loadMAsToolStripMenuItem.Click += new System.EventHandler(this.LoadMA_Click);
            // 
            // clearMAsToolStripMenuItem
            // 
            this.clearMAsToolStripMenuItem.Name = "clearMAsToolStripMenuItem";
            this.clearMAsToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.clearMAsToolStripMenuItem.Text = "Clear MA\'s";
            this.clearMAsToolStripMenuItem.Click += new System.EventHandler(this.ClearMA_Click);
            // 
            // CureConfigPage
            // 
            this.CureConfigPage.Controls.Add(this.CuraIIcount);
            this.CureConfigPage.Controls.Add(this.label55);
            this.CureConfigPage.Controls.Add(this.CuraIIIcount);
            this.CureConfigPage.Controls.Add(this.label53);
            this.CureConfigPage.Controls.Add(this.Curacount);
            this.CureConfigPage.Controls.Add(this.label54);
            this.CureConfigPage.Controls.Add(this.FullCurecount);
            this.CureConfigPage.Controls.Add(this.label52);
            this.CureConfigPage.Controls.Add(this.CureVIcount);
            this.CureConfigPage.Controls.Add(this.label45);
            this.CureConfigPage.Controls.Add(this.CureVcount);
            this.CureConfigPage.Controls.Add(this.CureIVcount);
            this.CureConfigPage.Controls.Add(this.CureIIIcount);
            this.CureConfigPage.Controls.Add(this.CureIIcount);
            this.CureConfigPage.Controls.Add(this.label44);
            this.CureConfigPage.Controls.Add(this.label43);
            this.CureConfigPage.Controls.Add(this.label9);
            this.CureConfigPage.Controls.Add(this.label2);
            this.CureConfigPage.Controls.Add(this.label1);
            this.CureConfigPage.Controls.Add(this.Curecount);
            this.CureConfigPage.Location = new System.Drawing.Point(4, 22);
            this.CureConfigPage.Name = "CureConfigPage";
            this.CureConfigPage.Padding = new System.Windows.Forms.Padding(3);
            this.CureConfigPage.Size = new System.Drawing.Size(306, 151);
            this.CureConfigPage.TabIndex = 1;
            this.CureConfigPage.Text = "Cure";
            this.CureConfigPage.UseVisualStyleBackColor = true;
            // 
            // CuraIIcount
            // 
            this.CuraIIcount.Enabled = false;
            this.CuraIIcount.Location = new System.Drawing.Point(75, 110);
            this.CuraIIcount.Name = "CuraIIcount";
            this.CuraIIcount.Size = new System.Drawing.Size(44, 20);
            this.CuraIIcount.TabIndex = 19;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(26, 112);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(46, 13);
            this.label55.TabIndex = 18;
            this.label55.Text = "CuraII %";
            // 
            // CuraIIIcount
            // 
            this.CuraIIIcount.Enabled = false;
            this.CuraIIIcount.Location = new System.Drawing.Point(226, 87);
            this.CuraIIIcount.Name = "CuraIIIcount";
            this.CuraIIIcount.Size = new System.Drawing.Size(44, 20);
            this.CuraIIIcount.TabIndex = 17;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(177, 87);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(49, 13);
            this.label53.TabIndex = 16;
            this.label53.Text = "CuraIII %";
            // 
            // Curacount
            // 
            this.Curacount.Enabled = false;
            this.Curacount.Location = new System.Drawing.Point(75, 88);
            this.Curacount.Name = "Curacount";
            this.Curacount.Size = new System.Drawing.Size(44, 20);
            this.Curacount.TabIndex = 15;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(26, 90);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(49, 13);
            this.label54.TabIndex = 14;
            this.label54.Text = "Cura    %";
            // 
            // FullCurecount
            // 
            this.FullCurecount.Enabled = false;
            this.FullCurecount.Location = new System.Drawing.Point(226, 113);
            this.FullCurecount.Name = "FullCurecount";
            this.FullCurecount.Size = new System.Drawing.Size(44, 20);
            this.FullCurecount.TabIndex = 13;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(167, 115);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(59, 13);
            this.label52.TabIndex = 12;
            this.label52.Text = "Full Cure %";
            // 
            // CureVIcount
            // 
            this.CureVIcount.Enabled = false;
            this.CureVIcount.Location = new System.Drawing.Point(226, 61);
            this.CureVIcount.Name = "CureVIcount";
            this.CureVIcount.Size = new System.Drawing.Size(44, 20);
            this.CureVIcount.TabIndex = 11;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(177, 61);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(50, 13);
            this.label45.TabIndex = 10;
            this.label45.Text = "CureVI %";
            // 
            // CureVcount
            // 
            this.CureVcount.Enabled = false;
            this.CureVcount.Location = new System.Drawing.Point(226, 39);
            this.CureVcount.Name = "CureVcount";
            this.CureVcount.Size = new System.Drawing.Size(44, 20);
            this.CureVcount.TabIndex = 9;
            // 
            // CureIVcount
            // 
            this.CureIVcount.Enabled = false;
            this.CureIVcount.Location = new System.Drawing.Point(226, 17);
            this.CureIVcount.Name = "CureIVcount";
            this.CureIVcount.Size = new System.Drawing.Size(44, 20);
            this.CureIVcount.TabIndex = 8;
            // 
            // CureIIIcount
            // 
            this.CureIIIcount.Enabled = false;
            this.CureIIIcount.Location = new System.Drawing.Point(75, 62);
            this.CureIIIcount.Name = "CureIIIcount";
            this.CureIIIcount.Size = new System.Drawing.Size(44, 20);
            this.CureIIIcount.TabIndex = 7;
            // 
            // CureIIcount
            // 
            this.CureIIcount.Enabled = false;
            this.CureIIcount.Location = new System.Drawing.Point(75, 40);
            this.CureIIcount.Name = "CureIIcount";
            this.CureIIcount.Size = new System.Drawing.Size(44, 20);
            this.CureIIcount.TabIndex = 6;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(177, 39);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(50, 13);
            this.label44.TabIndex = 5;
            this.label44.Text = "CureV  %";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(177, 19);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(50, 13);
            this.label43.TabIndex = 4;
            this.label43.Text = "CureIV %";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "CureIII %";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CureII  %";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cure    %";
            // 
            // Curecount
            // 
            this.Curecount.Enabled = false;
            this.Curecount.Location = new System.Drawing.Point(75, 18);
            this.Curecount.Name = "Curecount";
            this.Curecount.Size = new System.Drawing.Size(44, 20);
            this.Curecount.TabIndex = 0;
            // 
            // DrainAspirpage
            // 
            this.DrainAspirpage.Controls.Add(this.Aspirgroup);
            this.DrainAspirpage.Controls.Add(this.Draingroup);
            this.DrainAspirpage.Location = new System.Drawing.Point(4, 22);
            this.DrainAspirpage.Name = "DrainAspirpage";
            this.DrainAspirpage.Padding = new System.Windows.Forms.Padding(3);
            this.DrainAspirpage.Size = new System.Drawing.Size(306, 151);
            this.DrainAspirpage.TabIndex = 2;
            this.DrainAspirpage.Text = "Drain/Aspir";
            this.DrainAspirpage.UseVisualStyleBackColor = true;
            // 
            // Aspirgroup
            // 
            this.Aspirgroup.Controls.Add(this.AspirIIIcount);
            this.Aspirgroup.Controls.Add(this.AspirIIcount);
            this.Aspirgroup.Controls.Add(this.AspirIIItext);
            this.Aspirgroup.Controls.Add(this.AspirItext);
            this.Aspirgroup.Controls.Add(this.AspirIItext);
            this.Aspirgroup.Controls.Add(this.AspirIcount);
            this.Aspirgroup.Location = new System.Drawing.Point(154, 7);
            this.Aspirgroup.Name = "Aspirgroup";
            this.Aspirgroup.Size = new System.Drawing.Size(139, 138);
            this.Aspirgroup.TabIndex = 1;
            this.Aspirgroup.TabStop = false;
            this.Aspirgroup.Text = "Aspir";
            // 
            // AspirIIIcount
            // 
            this.AspirIIIcount.Enabled = false;
            this.AspirIIIcount.Location = new System.Drawing.Point(78, 94);
            this.AspirIIIcount.Name = "AspirIIIcount";
            this.AspirIIIcount.Size = new System.Drawing.Size(41, 20);
            this.AspirIIIcount.TabIndex = 64;
            // 
            // AspirIIcount
            // 
            this.AspirIIcount.Enabled = false;
            this.AspirIIcount.Location = new System.Drawing.Point(78, 56);
            this.AspirIIcount.Name = "AspirIIcount";
            this.AspirIIcount.Size = new System.Drawing.Size(41, 20);
            this.AspirIIcount.TabIndex = 62;
            // 
            // AspirIIItext
            // 
            this.AspirIIItext.AutoSize = true;
            this.AspirIIItext.Location = new System.Drawing.Point(26, 94);
            this.AspirIIItext.Name = "AspirIIItext";
            this.AspirIIItext.Size = new System.Drawing.Size(27, 13);
            this.AspirIIItext.TabIndex = 63;
            this.AspirIIItext.Text = "III %";
            // 
            // AspirItext
            // 
            this.AspirItext.AutoSize = true;
            this.AspirItext.Location = new System.Drawing.Point(26, 21);
            this.AspirItext.Name = "AspirItext";
            this.AspirItext.Size = new System.Drawing.Size(27, 13);
            this.AspirItext.TabIndex = 57;
            this.AspirItext.Text = "I   %";
            // 
            // AspirIItext
            // 
            this.AspirIItext.AutoSize = true;
            this.AspirIItext.Location = new System.Drawing.Point(26, 56);
            this.AspirIItext.Name = "AspirIItext";
            this.AspirIItext.Size = new System.Drawing.Size(27, 13);
            this.AspirIItext.TabIndex = 58;
            this.AspirIItext.Text = "II  %";
            // 
            // AspirIcount
            // 
            this.AspirIcount.Enabled = false;
            this.AspirIcount.Location = new System.Drawing.Point(78, 19);
            this.AspirIcount.Name = "AspirIcount";
            this.AspirIcount.Size = new System.Drawing.Size(41, 20);
            this.AspirIcount.TabIndex = 61;
            // 
            // Draingroup
            // 
            this.Draingroup.Controls.Add(this.DrainIItext);
            this.Draingroup.Controls.Add(this.DrainIcount);
            this.Draingroup.Controls.Add(this.DrainItext);
            this.Draingroup.Controls.Add(this.DrainIIItext);
            this.Draingroup.Controls.Add(this.DrainIIIcount);
            this.Draingroup.Controls.Add(this.DrainIIcount);
            this.Draingroup.Location = new System.Drawing.Point(9, 7);
            this.Draingroup.Name = "Draingroup";
            this.Draingroup.Size = new System.Drawing.Size(139, 138);
            this.Draingroup.TabIndex = 0;
            this.Draingroup.TabStop = false;
            this.Draingroup.Text = "Drain";
            // 
            // DrainIItext
            // 
            this.DrainIItext.AutoSize = true;
            this.DrainIItext.Location = new System.Drawing.Point(17, 58);
            this.DrainIItext.Name = "DrainIItext";
            this.DrainIItext.Size = new System.Drawing.Size(27, 13);
            this.DrainIItext.TabIndex = 55;
            this.DrainIItext.Text = "II  %";
            // 
            // DrainIcount
            // 
            this.DrainIcount.Enabled = false;
            this.DrainIcount.Location = new System.Drawing.Point(69, 19);
            this.DrainIcount.Name = "DrainIcount";
            this.DrainIcount.Size = new System.Drawing.Size(41, 20);
            this.DrainIcount.TabIndex = 53;
            // 
            // DrainItext
            // 
            this.DrainItext.AutoSize = true;
            this.DrainItext.Location = new System.Drawing.Point(17, 21);
            this.DrainItext.Name = "DrainItext";
            this.DrainItext.Size = new System.Drawing.Size(27, 13);
            this.DrainItext.TabIndex = 54;
            this.DrainItext.Text = "I   %";
            // 
            // DrainIIItext
            // 
            this.DrainIIItext.AutoSize = true;
            this.DrainIIItext.Location = new System.Drawing.Point(17, 94);
            this.DrainIIItext.Name = "DrainIIItext";
            this.DrainIIItext.Size = new System.Drawing.Size(27, 13);
            this.DrainIIItext.TabIndex = 56;
            this.DrainIIItext.Text = "III %";
            // 
            // DrainIIIcount
            // 
            this.DrainIIIcount.Enabled = false;
            this.DrainIIIcount.Location = new System.Drawing.Point(69, 92);
            this.DrainIIIcount.Name = "DrainIIIcount";
            this.DrainIIIcount.Size = new System.Drawing.Size(41, 20);
            this.DrainIIIcount.TabIndex = 60;
            // 
            // DrainIIcount
            // 
            this.DrainIIcount.Enabled = false;
            this.DrainIIcount.Location = new System.Drawing.Point(69, 56);
            this.DrainIIcount.Name = "DrainIIcount";
            this.DrainIIcount.Size = new System.Drawing.Size(41, 20);
            this.DrainIIcount.TabIndex = 59;
            // 
            // BLUCurespage
            // 
            this.BLUCurespage.Controls.Add(this.MagicFruitcount);
            this.BLUCurespage.Controls.Add(this.Pollencount);
            this.BLUCurespage.Controls.Add(this.HealingBreezecount);
            this.BLUCurespage.Controls.Add(this.PleniluneEmbracecount);
            this.BLUCurespage.Controls.Add(this.Restoralcount);
            this.BLUCurespage.Controls.Add(this.WhiteWindcount);
            this.BLUCurespage.Controls.Add(this.Exuviationcount);
            this.BLUCurespage.Controls.Add(this.WildCarrotcount);
            this.BLUCurespage.Controls.Add(this.PleniluneEmbracetext);
            this.BLUCurespage.Controls.Add(this.MagicFruittext);
            this.BLUCurespage.Controls.Add(this.HealingBreezetext);
            this.BLUCurespage.Controls.Add(this.Pollentext);
            this.BLUCurespage.Controls.Add(this.WhiteWindtext);
            this.BLUCurespage.Controls.Add(this.Restoraltext);
            this.BLUCurespage.Controls.Add(this.Exuviationtext);
            this.BLUCurespage.Controls.Add(this.WildCarrottext);
            this.BLUCurespage.Location = new System.Drawing.Point(4, 22);
            this.BLUCurespage.Name = "BLUCurespage";
            this.BLUCurespage.Padding = new System.Windows.Forms.Padding(3);
            this.BLUCurespage.Size = new System.Drawing.Size(306, 151);
            this.BLUCurespage.TabIndex = 3;
            this.BLUCurespage.Text = "BLU Cures";
            this.BLUCurespage.UseVisualStyleBackColor = true;
            // 
            // MagicFruitcount
            // 
            this.MagicFruitcount.Enabled = false;
            this.MagicFruitcount.Location = new System.Drawing.Point(120, 46);
            this.MagicFruitcount.Name = "MagicFruitcount";
            this.MagicFruitcount.Size = new System.Drawing.Size(44, 20);
            this.MagicFruitcount.TabIndex = 15;
            // 
            // Pollencount
            // 
            this.Pollencount.Enabled = false;
            this.Pollencount.Location = new System.Drawing.Point(120, 13);
            this.Pollencount.Name = "Pollencount";
            this.Pollencount.Size = new System.Drawing.Size(44, 20);
            this.Pollencount.TabIndex = 14;
            // 
            // HealingBreezecount
            // 
            this.HealingBreezecount.Enabled = false;
            this.HealingBreezecount.Location = new System.Drawing.Point(120, 79);
            this.HealingBreezecount.Name = "HealingBreezecount";
            this.HealingBreezecount.Size = new System.Drawing.Size(44, 20);
            this.HealingBreezecount.TabIndex = 13;
            // 
            // PleniluneEmbracecount
            // 
            this.PleniluneEmbracecount.Enabled = false;
            this.PleniluneEmbracecount.Location = new System.Drawing.Point(120, 112);
            this.PleniluneEmbracecount.Name = "PleniluneEmbracecount";
            this.PleniluneEmbracecount.Size = new System.Drawing.Size(44, 20);
            this.PleniluneEmbracecount.TabIndex = 12;
            // 
            // Restoralcount
            // 
            this.Restoralcount.Enabled = false;
            this.Restoralcount.Location = new System.Drawing.Point(249, 46);
            this.Restoralcount.Name = "Restoralcount";
            this.Restoralcount.Size = new System.Drawing.Size(44, 20);
            this.Restoralcount.TabIndex = 11;
            // 
            // WhiteWindcount
            // 
            this.WhiteWindcount.Enabled = false;
            this.WhiteWindcount.Location = new System.Drawing.Point(249, 13);
            this.WhiteWindcount.Name = "WhiteWindcount";
            this.WhiteWindcount.Size = new System.Drawing.Size(44, 20);
            this.WhiteWindcount.TabIndex = 10;
            // 
            // Exuviationcount
            // 
            this.Exuviationcount.Enabled = false;
            this.Exuviationcount.Location = new System.Drawing.Point(249, 79);
            this.Exuviationcount.Name = "Exuviationcount";
            this.Exuviationcount.Size = new System.Drawing.Size(44, 20);
            this.Exuviationcount.TabIndex = 9;
            // 
            // WildCarrotcount
            // 
            this.WildCarrotcount.Enabled = false;
            this.WildCarrotcount.Location = new System.Drawing.Point(249, 112);
            this.WildCarrotcount.Name = "WildCarrotcount";
            this.WildCarrotcount.Size = new System.Drawing.Size(44, 20);
            this.WildCarrotcount.TabIndex = 8;
            // 
            // PleniluneEmbracetext
            // 
            this.PleniluneEmbracetext.AutoSize = true;
            this.PleniluneEmbracetext.Location = new System.Drawing.Point(5, 114);
            this.PleniluneEmbracetext.Name = "PleniluneEmbracetext";
            this.PleniluneEmbracetext.Size = new System.Drawing.Size(109, 13);
            this.PleniluneEmbracetext.TabIndex = 5;
            this.PleniluneEmbracetext.Text = "Plenilune Embrace @";
            // 
            // MagicFruittext
            // 
            this.MagicFruittext.AutoSize = true;
            this.MagicFruittext.Location = new System.Drawing.Point(41, 48);
            this.MagicFruittext.Name = "MagicFruittext";
            this.MagicFruittext.Size = new System.Drawing.Size(73, 13);
            this.MagicFruittext.TabIndex = 3;
            this.MagicFruittext.Text = "Magic Fruit @";
            // 
            // HealingBreezetext
            // 
            this.HealingBreezetext.AutoSize = true;
            this.HealingBreezetext.Location = new System.Drawing.Point(21, 81);
            this.HealingBreezetext.Name = "HealingBreezetext";
            this.HealingBreezetext.Size = new System.Drawing.Size(93, 13);
            this.HealingBreezetext.TabIndex = 2;
            this.HealingBreezetext.Text = "Healing Breeze @";
            // 
            // Pollentext
            // 
            this.Pollentext.AutoSize = true;
            this.Pollentext.Location = new System.Drawing.Point(64, 15);
            this.Pollentext.Name = "Pollentext";
            this.Pollentext.Size = new System.Drawing.Size(50, 13);
            this.Pollentext.TabIndex = 0;
            this.Pollentext.Text = "Pollen @";
            // 
            // WhiteWindtext
            // 
            this.WhiteWindtext.AutoSize = true;
            this.WhiteWindtext.Location = new System.Drawing.Point(166, 15);
            this.WhiteWindtext.Name = "WhiteWindtext";
            this.WhiteWindtext.Size = new System.Drawing.Size(77, 13);
            this.WhiteWindtext.TabIndex = 6;
            this.WhiteWindtext.Text = "White Wind @";
            // 
            // Restoraltext
            // 
            this.Restoraltext.AutoSize = true;
            this.Restoraltext.Location = new System.Drawing.Point(183, 48);
            this.Restoraltext.Name = "Restoraltext";
            this.Restoraltext.Size = new System.Drawing.Size(60, 13);
            this.Restoraltext.TabIndex = 7;
            this.Restoraltext.Text = "Restoral @";
            // 
            // Exuviationtext
            // 
            this.Exuviationtext.AutoSize = true;
            this.Exuviationtext.Location = new System.Drawing.Point(173, 81);
            this.Exuviationtext.Name = "Exuviationtext";
            this.Exuviationtext.Size = new System.Drawing.Size(70, 13);
            this.Exuviationtext.TabIndex = 4;
            this.Exuviationtext.Text = "Exuviation @";
            // 
            // WildCarrottext
            // 
            this.WildCarrottext.AutoSize = true;
            this.WildCarrottext.Location = new System.Drawing.Point(173, 114);
            this.WildCarrottext.Name = "WildCarrottext";
            this.WildCarrottext.Size = new System.Drawing.Size(73, 13);
            this.WildCarrottext.TabIndex = 1;
            this.WildCarrottext.Text = "Wild Carrot @";
            // 
            // MAconfigpage
            // 
            this.MAconfigpage.Controls.Add(this.label13);
            this.MAconfigpage.Controls.Add(this.label10);
            this.MAconfigpage.Controls.Add(this.MAreverse);
            this.MAconfigpage.Location = new System.Drawing.Point(4, 22);
            this.MAconfigpage.Name = "MAconfigpage";
            this.MAconfigpage.Padding = new System.Windows.Forms.Padding(3);
            this.MAconfigpage.Size = new System.Drawing.Size(306, 151);
            this.MAconfigpage.TabIndex = 4;
            this.MAconfigpage.Text = "MAconfig";
            this.MAconfigpage.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(62, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(183, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "of the way its listed on the Select tab.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(54, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(199, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "This will cause all magic to run in reverse";
            // 
            // MAreverse
            // 
            this.MAreverse.AutoSize = true;
            this.MAreverse.Location = new System.Drawing.Point(90, 16);
            this.MAreverse.Name = "MAreverse";
            this.MAreverse.Size = new System.Drawing.Size(126, 17);
            this.MAreverse.TabIndex = 0;
            this.MAreverse.Text = "Run magin in reverse";
            this.MAreverse.UseVisualStyleBackColor = true;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.delaytext);
            this.groupBox14.Controls.Add(this.pullDelay);
            this.groupBox14.Controls.Add(this.AutoLock);
            this.groupBox14.Controls.Add(this.numericUpDown39);
            this.groupBox14.Controls.Add(this.mobheightdist);
            this.groupBox14.Controls.Add(this.runTarget);
            this.groupBox14.Controls.Add(this.runPullDistance);
            this.groupBox14.Controls.Add(this.mobsearchdisttext);
            this.groupBox14.Controls.Add(this.targetSearchDist);
            this.groupBox14.Controls.Add(this.pullTolorance);
            this.groupBox14.Controls.Add(this.pulltolorancetext);
            this.groupBox14.Controls.Add(this.numericUpDown21);
            this.groupBox14.Controls.Add(this.pulldistance);
            this.groupBox14.Controls.Add(this.pullCommand);
            this.groupBox14.Controls.Add(this.pullcommandtext);
            this.groupBox14.Location = new System.Drawing.Point(45, 6);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(335, 119);
            this.groupBox14.TabIndex = 21;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Pull Options";
            // 
            // delaytext
            // 
            this.delaytext.AutoSize = true;
            this.delaytext.Location = new System.Drawing.Point(244, 20);
            this.delaytext.Name = "delaytext";
            this.delaytext.Size = new System.Drawing.Size(37, 13);
            this.delaytext.TabIndex = 55;
            this.delaytext.Text = "Delay:";
            // 
            // pullDelay
            // 
            this.pullDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pullDelay.DecimalPlaces = 1;
            this.pullDelay.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.pullDelay.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.pullDelay.Location = new System.Drawing.Point(282, 17);
            this.pullDelay.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.pullDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pullDelay.Name = "pullDelay";
            this.pullDelay.Size = new System.Drawing.Size(44, 20);
            this.pullDelay.TabIndex = 54;
            this.pullDelay.TabStop = false;
            this.pullDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pullDelay.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // AutoLock
            // 
            this.AutoLock.AutoSize = true;
            this.AutoLock.Location = new System.Drawing.Point(172, 77);
            this.AutoLock.Name = "AutoLock";
            this.AutoLock.Size = new System.Drawing.Size(109, 17);
            this.AutoLock.TabIndex = 53;
            this.AutoLock.Text = "Auto-Lock Target";
            this.AutoLock.UseVisualStyleBackColor = true;
            // 
            // numericUpDown39
            // 
            this.numericUpDown39.DecimalPlaces = 1;
            this.numericUpDown39.Enabled = false;
            this.numericUpDown39.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.numericUpDown39.Location = new System.Drawing.Point(282, 91);
            this.numericUpDown39.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown39.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown39.Name = "numericUpDown39";
            this.numericUpDown39.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown39.TabIndex = 52;
            this.numericUpDown39.TabStop = false;
            this.numericUpDown39.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown39.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // mobheightdist
            // 
            this.mobheightdist.AutoSize = true;
            this.mobheightdist.Enabled = false;
            this.mobheightdist.Location = new System.Drawing.Point(172, 93);
            this.mobheightdist.Name = "mobheightdist";
            this.mobheightdist.Size = new System.Drawing.Size(105, 17);
            this.mobheightdist.TabIndex = 51;
            this.mobheightdist.Text = "Mob Height Dist.";
            this.mobheightdist.UseVisualStyleBackColor = true;
            // 
            // runTarget
            // 
            this.runTarget.AutoSize = true;
            this.runTarget.Location = new System.Drawing.Point(172, 61);
            this.runTarget.Name = "runTarget";
            this.runTarget.Size = new System.Drawing.Size(155, 17);
            this.runTarget.TabIndex = 50;
            this.runTarget.Text = "Run to Target (after pulling)";
            this.runTarget.UseVisualStyleBackColor = true;
            // 
            // runPullDistance
            // 
            this.runPullDistance.AutoSize = true;
            this.runPullDistance.Location = new System.Drawing.Point(172, 45);
            this.runPullDistance.Name = "runPullDistance";
            this.runPullDistance.Size = new System.Drawing.Size(123, 17);
            this.runPullDistance.TabIndex = 49;
            this.runPullDistance.Text = "Run to Pull Distance";
            this.runPullDistance.UseVisualStyleBackColor = true;
            // 
            // mobsearchdisttext
            // 
            this.mobsearchdisttext.AutoSize = true;
            this.mobsearchdisttext.Location = new System.Drawing.Point(21, 93);
            this.mobsearchdisttext.Name = "mobsearchdisttext";
            this.mobsearchdisttext.Size = new System.Drawing.Size(89, 13);
            this.mobsearchdisttext.TabIndex = 48;
            this.mobsearchdisttext.Text = "Mob Search Dist.";
            // 
            // targetSearchDist
            // 
            this.targetSearchDist.DecimalPlaces = 1;
            this.targetSearchDist.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.targetSearchDist.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.targetSearchDist.Location = new System.Drawing.Point(110, 90);
            this.targetSearchDist.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.targetSearchDist.Name = "targetSearchDist";
            this.targetSearchDist.Size = new System.Drawing.Size(44, 20);
            this.targetSearchDist.TabIndex = 47;
            this.targetSearchDist.TabStop = false;
            this.targetSearchDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.targetSearchDist.Value = new decimal(new int[] {
            245,
            0,
            0,
            65536});
            // 
            // pullTolorance
            // 
            this.pullTolorance.DecimalPlaces = 1;
            this.pullTolorance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.pullTolorance.Location = new System.Drawing.Point(110, 68);
            this.pullTolorance.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.pullTolorance.Name = "pullTolorance";
            this.pullTolorance.Size = new System.Drawing.Size(44, 20);
            this.pullTolorance.TabIndex = 43;
            this.pullTolorance.TabStop = false;
            this.pullTolorance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pullTolorance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pulltolorancetext
            // 
            this.pulltolorancetext.AutoSize = true;
            this.pulltolorancetext.Location = new System.Drawing.Point(21, 70);
            this.pulltolorancetext.Name = "pulltolorancetext";
            this.pulltolorancetext.Size = new System.Drawing.Size(75, 13);
            this.pulltolorancetext.TabIndex = 10;
            this.pulltolorancetext.Text = "Pull Tolorance";
            // 
            // numericUpDown21
            // 
            this.numericUpDown21.DecimalPlaces = 1;
            this.numericUpDown21.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown21.Location = new System.Drawing.Point(110, 45);
            this.numericUpDown21.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown21.Name = "numericUpDown21";
            this.numericUpDown21.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown21.TabIndex = 9;
            this.numericUpDown21.TabStop = false;
            this.numericUpDown21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown21.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // pulldistance
            // 
            this.pulldistance.AutoSize = true;
            this.pulldistance.Location = new System.Drawing.Point(21, 48);
            this.pulldistance.Name = "pulldistance";
            this.pulldistance.Size = new System.Drawing.Size(69, 13);
            this.pulldistance.TabIndex = 8;
            this.pulldistance.Text = "Pull Distance";
            // 
            // pullCommand
            // 
            this.pullCommand.Location = new System.Drawing.Point(110, 17);
            this.pullCommand.Name = "pullCommand";
            this.pullCommand.Size = new System.Drawing.Size(132, 20);
            this.pullCommand.TabIndex = 7;
            this.pullCommand.TabStop = false;
            this.pullCommand.Text = "/ra <t>";
            // 
            // pullcommandtext
            // 
            this.pullcommandtext.AutoSize = true;
            this.pullcommandtext.Location = new System.Drawing.Point(21, 20);
            this.pullcommandtext.Name = "pullcommandtext";
            this.pullcommandtext.Size = new System.Drawing.Size(74, 13);
            this.pullcommandtext.TabIndex = 6;
            this.pullcommandtext.Text = "Pull Command";
            // 
            // dancer
            // 
            this.dancer.Controls.Add(this.tabControl3);
            this.dancer.Controls.Add(this.label15);
            this.dancer.Location = new System.Drawing.Point(4, 22);
            this.dancer.Name = "dancer";
            this.dancer.Padding = new System.Windows.Forms.Padding(3);
            this.dancer.Size = new System.Drawing.Size(439, 351);
            this.dancer.TabIndex = 0;
            this.dancer.Text = "Sambas/Steps/Waltz";
            this.dancer.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage14);
            this.tabControl3.Controls.Add(this.tabPage15);
            this.tabControl3.Controls.Add(this.tabPage16);
            this.tabControl3.Location = new System.Drawing.Point(7, 82);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(426, 263);
            this.tabControl3.TabIndex = 8;
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.groupBox1);
            this.tabPage14.Controls.Add(this.groupBox3);
            this.tabPage14.Location = new System.Drawing.Point(4, 22);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage14.Size = new System.Drawing.Size(418, 237);
            this.tabPage14.TabIndex = 0;
            this.tabPage14.Text = "Sambas/Steps";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.noSamba);
            this.groupBox1.Controls.Add(this.usedrainiii);
            this.groupBox1.Controls.Add(this.usehaste);
            this.groupBox1.Controls.Add(this.useaspirii);
            this.groupBox1.Controls.Add(this.useaspir);
            this.groupBox1.Controls.Add(this.usedrainii);
            this.groupBox1.Controls.Add(this.usedrain);
            this.groupBox1.Location = new System.Drawing.Point(16, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 165);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Samba\'s";
            // 
            // noSamba
            // 
            this.noSamba.AutoSize = true;
            this.noSamba.Enabled = false;
            this.noSamba.Location = new System.Drawing.Point(19, 138);
            this.noSamba.Name = "noSamba";
            this.noSamba.Size = new System.Drawing.Size(108, 17);
            this.noSamba.TabIndex = 4;
            this.noSamba.TabStop = true;
            this.noSamba.Text = "Don\'t Use Samba";
            this.noSamba.UseVisualStyleBackColor = true;
            // 
            // usedrainiii
            // 
            this.usedrainiii.AutoSize = true;
            this.usedrainiii.Enabled = false;
            this.usedrainiii.Location = new System.Drawing.Point(19, 58);
            this.usedrainiii.Name = "usedrainiii";
            this.usedrainiii.Size = new System.Drawing.Size(98, 17);
            this.usedrainiii.TabIndex = 2;
            this.usedrainiii.TabStop = true;
            this.usedrainiii.Text = "Drain Samba III";
            this.usedrainiii.UseVisualStyleBackColor = true;
            // 
            // usehaste
            // 
            this.usehaste.AutoSize = true;
            this.usehaste.Enabled = false;
            this.usehaste.Location = new System.Drawing.Point(19, 118);
            this.usehaste.Name = "usehaste";
            this.usehaste.Size = new System.Drawing.Size(89, 17);
            this.usehaste.TabIndex = 4;
            this.usehaste.TabStop = true;
            this.usehaste.Text = "Haste Samba";
            this.usehaste.UseVisualStyleBackColor = true;
            // 
            // useaspirii
            // 
            this.useaspirii.AutoSize = true;
            this.useaspirii.Enabled = false;
            this.useaspirii.Location = new System.Drawing.Point(19, 98);
            this.useaspirii.Name = "useaspirii";
            this.useaspirii.Size = new System.Drawing.Size(93, 17);
            this.useaspirii.TabIndex = 3;
            this.useaspirii.TabStop = true;
            this.useaspirii.Text = "Aspir Samba II";
            this.useaspirii.UseVisualStyleBackColor = true;
            // 
            // useaspir
            // 
            this.useaspir.AutoSize = true;
            this.useaspir.Enabled = false;
            this.useaspir.Location = new System.Drawing.Point(19, 78);
            this.useaspir.Name = "useaspir";
            this.useaspir.Size = new System.Drawing.Size(84, 17);
            this.useaspir.TabIndex = 2;
            this.useaspir.TabStop = true;
            this.useaspir.Text = "Aspir Samba";
            this.useaspir.UseVisualStyleBackColor = true;
            // 
            // usedrainii
            // 
            this.usedrainii.AutoSize = true;
            this.usedrainii.Enabled = false;
            this.usedrainii.Location = new System.Drawing.Point(19, 38);
            this.usedrainii.Name = "usedrainii";
            this.usedrainii.Size = new System.Drawing.Size(95, 17);
            this.usedrainii.TabIndex = 1;
            this.usedrainii.TabStop = true;
            this.usedrainii.Text = "Drain Samba II";
            this.usedrainii.UseVisualStyleBackColor = true;
            // 
            // usedrain
            // 
            this.usedrain.AutoSize = true;
            this.usedrain.Enabled = false;
            this.usedrain.Location = new System.Drawing.Point(19, 18);
            this.usedrain.Name = "usedrain";
            this.usedrain.Size = new System.Drawing.Size(86, 17);
            this.usedrain.TabIndex = 0;
            this.usedrain.TabStop = true;
            this.usedrain.Text = "Drain Samba";
            this.usedrain.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.stopstepsat);
            this.groupBox3.Controls.Add(this.stopstepscount);
            this.groupBox3.Controls.Add(this.stopstepsathptext);
            this.groupBox3.Controls.Add(this.usefeatherstepValue);
            this.groupBox3.Controls.Add(this.usestutterstepValue);
            this.groupBox3.Controls.Add(this.useboxstepValue);
            this.groupBox3.Controls.Add(this.StepsHPValue);
            this.groupBox3.Controls.Add(this.usequickstepValue);
            this.groupBox3.Controls.Add(this.StepsHP);
            this.groupBox3.Controls.Add(this.NoSteps);
            this.groupBox3.Controls.Add(this.usequickstep);
            this.groupBox3.Controls.Add(this.useboxstep);
            this.groupBox3.Controls.Add(this.usestutterstep);
            this.groupBox3.Controls.Add(this.usefeatherstep);
            this.groupBox3.Location = new System.Drawing.Point(212, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(190, 182);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Steps";
            // 
            // stopstepsat
            // 
            this.stopstepsat.AutoSize = true;
            this.stopstepsat.Enabled = false;
            this.stopstepsat.Location = new System.Drawing.Point(14, 24);
            this.stopstepsat.Name = "stopstepsat";
            this.stopstepsat.Size = new System.Drawing.Size(88, 17);
            this.stopstepsat.TabIndex = 17;
            this.stopstepsat.Text = "Stop Steps #";
            this.stopstepsat.UseVisualStyleBackColor = true;
            // 
            // stopstepscount
            // 
            this.stopstepscount.Enabled = false;
            this.stopstepscount.Location = new System.Drawing.Point(130, 23);
            this.stopstepscount.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.stopstepscount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stopstepscount.Name = "stopstepscount";
            this.stopstepscount.Size = new System.Drawing.Size(34, 20);
            this.stopstepscount.TabIndex = 16;
            this.stopstepscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.stopstepscount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // stopstepsathptext
            // 
            this.stopstepsathptext.AutoSize = true;
            this.stopstepsathptext.Enabled = false;
            this.stopstepsathptext.Location = new System.Drawing.Point(154, 157);
            this.stopstepsathptext.Name = "stopstepsathptext";
            this.stopstepsathptext.Size = new System.Drawing.Size(30, 13);
            this.stopstepsathptext.TabIndex = 10;
            this.stopstepsathptext.Text = "HP%";
            // 
            // usefeatherstepValue
            // 
            this.usefeatherstepValue.Enabled = false;
            this.usefeatherstepValue.Location = new System.Drawing.Point(130, 111);
            this.usefeatherstepValue.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.usefeatherstepValue.Name = "usefeatherstepValue";
            this.usefeatherstepValue.Size = new System.Drawing.Size(34, 20);
            this.usefeatherstepValue.TabIndex = 14;
            this.usefeatherstepValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // usestutterstepValue
            // 
            this.usestutterstepValue.Enabled = false;
            this.usestutterstepValue.Location = new System.Drawing.Point(130, 89);
            this.usestutterstepValue.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.usestutterstepValue.Name = "usestutterstepValue";
            this.usestutterstepValue.Size = new System.Drawing.Size(34, 20);
            this.usestutterstepValue.TabIndex = 13;
            this.usestutterstepValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // useboxstepValue
            // 
            this.useboxstepValue.Enabled = false;
            this.useboxstepValue.Location = new System.Drawing.Point(130, 67);
            this.useboxstepValue.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.useboxstepValue.Name = "useboxstepValue";
            this.useboxstepValue.Size = new System.Drawing.Size(34, 20);
            this.useboxstepValue.TabIndex = 12;
            this.useboxstepValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StepsHPValue
            // 
            this.StepsHPValue.Enabled = false;
            this.StepsHPValue.Location = new System.Drawing.Point(114, 155);
            this.StepsHPValue.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.StepsHPValue.Name = "StepsHPValue";
            this.StepsHPValue.Size = new System.Drawing.Size(34, 20);
            this.StepsHPValue.TabIndex = 9;
            this.StepsHPValue.TabStop = false;
            this.StepsHPValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StepsHPValue.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // usequickstepValue
            // 
            this.usequickstepValue.Enabled = false;
            this.usequickstepValue.Location = new System.Drawing.Point(130, 45);
            this.usequickstepValue.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.usequickstepValue.Name = "usequickstepValue";
            this.usequickstepValue.Size = new System.Drawing.Size(34, 20);
            this.usequickstepValue.TabIndex = 11;
            this.usequickstepValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StepsHP
            // 
            this.StepsHP.AutoSize = true;
            this.StepsHP.Enabled = false;
            this.StepsHP.Location = new System.Drawing.Point(6, 158);
            this.StepsHP.Name = "StepsHP";
            this.StepsHP.Size = new System.Drawing.Size(112, 17);
            this.StepsHP.TabIndex = 8;
            this.StepsHP.Text = "Don\'t Use Steps <";
            this.StepsHP.UseVisualStyleBackColor = true;
            // 
            // NoSteps
            // 
            this.NoSteps.AutoSize = true;
            this.NoSteps.Enabled = false;
            this.NoSteps.Location = new System.Drawing.Point(14, 135);
            this.NoSteps.Name = "NoSteps";
            this.NoSteps.Size = new System.Drawing.Size(102, 17);
            this.NoSteps.TabIndex = 10;
            this.NoSteps.TabStop = true;
            this.NoSteps.Text = "Don\'t Use Steps";
            this.NoSteps.UseVisualStyleBackColor = true;
            // 
            // usequickstep
            // 
            this.usequickstep.AutoSize = true;
            this.usequickstep.Enabled = false;
            this.usequickstep.Location = new System.Drawing.Point(14, 42);
            this.usequickstep.Name = "usequickstep";
            this.usequickstep.Size = new System.Drawing.Size(75, 17);
            this.usequickstep.TabIndex = 2;
            this.usequickstep.TabStop = true;
            this.usequickstep.Text = "QuickStep";
            this.usequickstep.UseVisualStyleBackColor = true;
            // 
            // useboxstep
            // 
            this.useboxstep.AutoSize = true;
            this.useboxstep.Enabled = false;
            this.useboxstep.Location = new System.Drawing.Point(14, 67);
            this.useboxstep.Name = "useboxstep";
            this.useboxstep.Size = new System.Drawing.Size(65, 17);
            this.useboxstep.TabIndex = 3;
            this.useboxstep.TabStop = true;
            this.useboxstep.Text = "BoxStep";
            this.useboxstep.UseVisualStyleBackColor = true;
            // 
            // usestutterstep
            // 
            this.usestutterstep.AutoSize = true;
            this.usestutterstep.Enabled = false;
            this.usestutterstep.Location = new System.Drawing.Point(14, 89);
            this.usestutterstep.Name = "usestutterstep";
            this.usestutterstep.Size = new System.Drawing.Size(78, 17);
            this.usestutterstep.TabIndex = 4;
            this.usestutterstep.TabStop = true;
            this.usestutterstep.Text = "StutterStep";
            this.usestutterstep.UseVisualStyleBackColor = true;
            // 
            // usefeatherstep
            // 
            this.usefeatherstep.AutoSize = true;
            this.usefeatherstep.Enabled = false;
            this.usefeatherstep.Location = new System.Drawing.Point(14, 111);
            this.usefeatherstep.Name = "usefeatherstep";
            this.usefeatherstep.Size = new System.Drawing.Size(83, 17);
            this.usefeatherstep.TabIndex = 5;
            this.usefeatherstep.TabStop = true;
            this.usefeatherstep.Text = "FeatherStep";
            this.usefeatherstep.UseVisualStyleBackColor = true;
            // 
            // tabPage15
            // 
            this.tabPage15.Controls.Add(this.groupBox7);
            this.tabPage15.Controls.Add(this.groupBox2);
            this.tabPage15.Location = new System.Drawing.Point(4, 22);
            this.tabPage15.Name = "tabPage15";
            this.tabPage15.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage15.Size = new System.Drawing.Size(418, 237);
            this.tabPage15.TabIndex = 1;
            this.tabPage15.Text = "Waltz";
            this.tabPage15.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.checkBox1);
            this.groupBox7.Controls.Add(this.HealingWaltzItems);
            this.groupBox7.Enabled = false;
            this.groupBox7.Location = new System.Drawing.Point(212, 35);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(190, 167);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Healing Waltz";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 145);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(125, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Select/Deselect ALL";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
            // 
            // HealingWaltzItems
            // 
            this.HealingWaltzItems.FormattingEnabled = true;
            this.HealingWaltzItems.Items.AddRange(new object[] {
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
            "Slow",
            "STR Down",
            "TP Down",
            "VIT Down"});
            this.HealingWaltzItems.Location = new System.Drawing.Point(6, 18);
            this.HealingWaltzItems.Name = "HealingWaltzItems";
            this.HealingWaltzItems.Size = new System.Drawing.Size(178, 124);
            this.HealingWaltzItems.Sorted = true;
            this.HealingWaltzItems.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label32);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.usecurevValue);
            this.groupBox2.Controls.Add(this.usecureivValue);
            this.groupBox2.Controls.Add(this.usecureiiiValue);
            this.groupBox2.Controls.Add(this.usecureiiValue);
            this.groupBox2.Controls.Add(this.usecureValue);
            this.groupBox2.Controls.Add(this.usecurev);
            this.groupBox2.Controls.Add(this.usecureiv);
            this.groupBox2.Controls.Add(this.usecureiii);
            this.groupBox2.Controls.Add(this.usecureii);
            this.groupBox2.Controls.Add(this.usecure);
            this.groupBox2.Location = new System.Drawing.Point(16, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(190, 167);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Curing Waltz";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(166, 123);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(15, 13);
            this.label32.TabIndex = 61;
            this.label32.Text = "%";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(166, 101);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(15, 13);
            this.label31.TabIndex = 60;
            this.label31.Text = "%";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(166, 77);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(15, 13);
            this.label30.TabIndex = 59;
            this.label30.Text = "%";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(166, 55);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(15, 13);
            this.label25.TabIndex = 59;
            this.label25.Text = "%";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(166, 32);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(15, 13);
            this.label17.TabIndex = 58;
            this.label17.Text = "%";
            // 
            // usecurevValue
            // 
            this.usecurevValue.Enabled = false;
            this.usecurevValue.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.usecurevValue.Location = new System.Drawing.Point(122, 120);
            this.usecurevValue.Name = "usecurevValue";
            this.usecurevValue.Size = new System.Drawing.Size(41, 20);
            this.usecurevValue.TabIndex = 9;
            this.usecurevValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // usecureivValue
            // 
            this.usecureivValue.Enabled = false;
            this.usecureivValue.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.usecureivValue.Location = new System.Drawing.Point(122, 97);
            this.usecureivValue.Name = "usecureivValue";
            this.usecureivValue.Size = new System.Drawing.Size(41, 20);
            this.usecureivValue.TabIndex = 8;
            this.usecureivValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // usecureiiiValue
            // 
            this.usecureiiiValue.Enabled = false;
            this.usecureiiiValue.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.usecureiiiValue.Location = new System.Drawing.Point(122, 74);
            this.usecureiiiValue.Name = "usecureiiiValue";
            this.usecureiiiValue.Size = new System.Drawing.Size(41, 20);
            this.usecureiiiValue.TabIndex = 7;
            this.usecureiiiValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // usecureiiValue
            // 
            this.usecureiiValue.Enabled = false;
            this.usecureiiValue.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.usecureiiValue.Location = new System.Drawing.Point(122, 51);
            this.usecureiiValue.Name = "usecureiiValue";
            this.usecureiiValue.Size = new System.Drawing.Size(41, 20);
            this.usecureiiValue.TabIndex = 6;
            this.usecureiiValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // usecureValue
            // 
            this.usecureValue.Enabled = false;
            this.usecureValue.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.usecureValue.Location = new System.Drawing.Point(122, 28);
            this.usecureValue.Name = "usecureValue";
            this.usecureValue.Size = new System.Drawing.Size(41, 20);
            this.usecureValue.TabIndex = 5;
            this.usecureValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // usecurev
            // 
            this.usecurev.AutoSize = true;
            this.usecurev.Enabled = false;
            this.usecurev.Location = new System.Drawing.Point(15, 121);
            this.usecurev.Name = "usecurev";
            this.usecurev.Size = new System.Drawing.Size(96, 17);
            this.usecurev.TabIndex = 4;
            this.usecurev.Text = "Curing Waltz V";
            this.usecurev.UseVisualStyleBackColor = true;
            // 
            // usecureiv
            // 
            this.usecureiv.AutoSize = true;
            this.usecureiv.Enabled = false;
            this.usecureiv.Location = new System.Drawing.Point(15, 98);
            this.usecureiv.Name = "usecureiv";
            this.usecureiv.Size = new System.Drawing.Size(99, 17);
            this.usecureiv.TabIndex = 3;
            this.usecureiv.Text = "Curing Waltz IV";
            this.usecureiv.UseVisualStyleBackColor = true;
            // 
            // usecureiii
            // 
            this.usecureiii.AutoSize = true;
            this.usecureiii.Enabled = false;
            this.usecureiii.Location = new System.Drawing.Point(15, 75);
            this.usecureiii.Name = "usecureiii";
            this.usecureiii.Size = new System.Drawing.Size(98, 17);
            this.usecureiii.TabIndex = 2;
            this.usecureiii.Text = "Curing Waltz III";
            this.usecureiii.UseVisualStyleBackColor = true;
            // 
            // usecureii
            // 
            this.usecureii.AutoSize = true;
            this.usecureii.Enabled = false;
            this.usecureii.Location = new System.Drawing.Point(15, 52);
            this.usecureii.Name = "usecureii";
            this.usecureii.Size = new System.Drawing.Size(95, 17);
            this.usecureii.TabIndex = 1;
            this.usecureii.Text = "Curing Waltz II";
            this.usecureii.UseVisualStyleBackColor = true;
            // 
            // usecure
            // 
            this.usecure.AutoSize = true;
            this.usecure.Enabled = false;
            this.usecure.Location = new System.Drawing.Point(15, 29);
            this.usecure.Name = "usecure";
            this.usecure.Size = new System.Drawing.Size(92, 17);
            this.usecure.TabIndex = 0;
            this.usecure.Text = "Curing Waltz I";
            this.usecure.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.usecure.UseVisualStyleBackColor = true;
            // 
            // tabPage16
            // 
            this.tabPage16.Controls.Add(this.addplayertext);
            this.tabPage16.Controls.Add(this.textBox2);
            this.tabPage16.Controls.Add(this.groupBox21);
            this.tabPage16.Controls.Add(this.groupBox22);
            this.tabPage16.Controls.Add(this.listView4);
            this.tabPage16.Location = new System.Drawing.Point(4, 22);
            this.tabPage16.Name = "tabPage16";
            this.tabPage16.Size = new System.Drawing.Size(418, 237);
            this.tabPage16.TabIndex = 2;
            this.tabPage16.Text = "Party Waltz";
            this.tabPage16.UseVisualStyleBackColor = true;
            // 
            // addplayertext
            // 
            this.addplayertext.AutoSize = true;
            this.addplayertext.Enabled = false;
            this.addplayertext.Location = new System.Drawing.Point(207, 177);
            this.addplayertext.Name = "addplayertext";
            this.addplayertext.Size = new System.Drawing.Size(58, 13);
            this.addplayertext.TabIndex = 17;
            this.addplayertext.Text = "Add Player";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(274, 174);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(135, 20);
            this.textBox2.TabIndex = 16;
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.label38);
            this.groupBox21.Controls.Add(this.label37);
            this.groupBox21.Controls.Add(this.label36);
            this.groupBox21.Controls.Add(this.label34);
            this.groupBox21.Controls.Add(this.label33);
            this.groupBox21.Controls.Add(this.numericUpDown27);
            this.groupBox21.Controls.Add(this.numericUpDown28);
            this.groupBox21.Controls.Add(this.numericUpDown29);
            this.groupBox21.Controls.Add(this.numericUpDown32);
            this.groupBox21.Controls.Add(this.numericUpDown33);
            this.groupBox21.Controls.Add(this.ptusecurev);
            this.groupBox21.Controls.Add(this.ptusecureiv);
            this.groupBox21.Controls.Add(this.ptusecureiii);
            this.groupBox21.Controls.Add(this.ptusecureii);
            this.groupBox21.Controls.Add(this.ptusecure);
            this.groupBox21.Location = new System.Drawing.Point(10, 20);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(190, 152);
            this.groupBox21.TabIndex = 14;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Curing Waltz";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(163, 116);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(15, 13);
            this.label38.TabIndex = 74;
            this.label38.Text = "%";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(163, 93);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(15, 13);
            this.label37.TabIndex = 77;
            this.label37.Text = "%";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(163, 70);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(15, 13);
            this.label36.TabIndex = 76;
            this.label36.Text = "%";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(163, 47);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(15, 13);
            this.label34.TabIndex = 75;
            this.label34.Text = "%";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(163, 24);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(15, 13);
            this.label33.TabIndex = 73;
            this.label33.Text = "%";
            // 
            // numericUpDown27
            // 
            this.numericUpDown27.Enabled = false;
            this.numericUpDown27.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown27.Location = new System.Drawing.Point(119, 112);
            this.numericUpDown27.Name = "numericUpDown27";
            this.numericUpDown27.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown27.TabIndex = 72;
            this.numericUpDown27.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown28
            // 
            this.numericUpDown28.Enabled = false;
            this.numericUpDown28.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown28.Location = new System.Drawing.Point(119, 89);
            this.numericUpDown28.Name = "numericUpDown28";
            this.numericUpDown28.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown28.TabIndex = 71;
            this.numericUpDown28.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown29
            // 
            this.numericUpDown29.Enabled = false;
            this.numericUpDown29.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown29.Location = new System.Drawing.Point(119, 66);
            this.numericUpDown29.Name = "numericUpDown29";
            this.numericUpDown29.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown29.TabIndex = 70;
            this.numericUpDown29.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown32
            // 
            this.numericUpDown32.Enabled = false;
            this.numericUpDown32.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown32.Location = new System.Drawing.Point(119, 43);
            this.numericUpDown32.Name = "numericUpDown32";
            this.numericUpDown32.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown32.TabIndex = 69;
            this.numericUpDown32.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown33
            // 
            this.numericUpDown33.Enabled = false;
            this.numericUpDown33.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown33.Location = new System.Drawing.Point(119, 20);
            this.numericUpDown33.Name = "numericUpDown33";
            this.numericUpDown33.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown33.TabIndex = 68;
            this.numericUpDown33.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ptusecurev
            // 
            this.ptusecurev.AutoSize = true;
            this.ptusecurev.Enabled = false;
            this.ptusecurev.Location = new System.Drawing.Point(12, 113);
            this.ptusecurev.Name = "ptusecurev";
            this.ptusecurev.Size = new System.Drawing.Size(96, 17);
            this.ptusecurev.TabIndex = 67;
            this.ptusecurev.Text = "Curing Waltz V";
            this.ptusecurev.UseVisualStyleBackColor = true;
            // 
            // ptusecureiv
            // 
            this.ptusecureiv.AutoSize = true;
            this.ptusecureiv.Enabled = false;
            this.ptusecureiv.Location = new System.Drawing.Point(12, 90);
            this.ptusecureiv.Name = "ptusecureiv";
            this.ptusecureiv.Size = new System.Drawing.Size(99, 17);
            this.ptusecureiv.TabIndex = 66;
            this.ptusecureiv.Text = "Curing Waltz IV";
            this.ptusecureiv.UseVisualStyleBackColor = true;
            // 
            // ptusecureiii
            // 
            this.ptusecureiii.AutoSize = true;
            this.ptusecureiii.Enabled = false;
            this.ptusecureiii.Location = new System.Drawing.Point(12, 67);
            this.ptusecureiii.Name = "ptusecureiii";
            this.ptusecureiii.Size = new System.Drawing.Size(98, 17);
            this.ptusecureiii.TabIndex = 65;
            this.ptusecureiii.Text = "Curing Waltz III";
            this.ptusecureiii.UseVisualStyleBackColor = true;
            // 
            // ptusecureii
            // 
            this.ptusecureii.AutoSize = true;
            this.ptusecureii.Enabled = false;
            this.ptusecureii.Location = new System.Drawing.Point(12, 44);
            this.ptusecureii.Name = "ptusecureii";
            this.ptusecureii.Size = new System.Drawing.Size(95, 17);
            this.ptusecureii.TabIndex = 64;
            this.ptusecureii.Text = "Curing Waltz II";
            this.ptusecureii.UseVisualStyleBackColor = true;
            // 
            // ptusecure
            // 
            this.ptusecure.AutoSize = true;
            this.ptusecure.Enabled = false;
            this.ptusecure.Location = new System.Drawing.Point(12, 21);
            this.ptusecure.Name = "ptusecure";
            this.ptusecure.Size = new System.Drawing.Size(92, 17);
            this.ptusecure.TabIndex = 63;
            this.ptusecure.Text = "Curing Waltz I";
            this.ptusecure.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ptusecure.UseVisualStyleBackColor = true;
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.GetSetParty);
            this.groupBox22.Location = new System.Drawing.Point(206, 192);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(203, 38);
            this.groupBox22.TabIndex = 13;
            this.groupBox22.TabStop = false;
            // 
            // GetSetParty
            // 
            this.GetSetParty.Dock = System.Windows.Forms.DockStyle.None;
            this.GetSetParty.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadPartyToolStripMenuItem,
            this.clearPartyToolStripMenuItem});
            this.GetSetParty.Location = new System.Drawing.Point(20, 10);
            this.GetSetParty.Name = "GetSetParty";
            this.GetSetParty.Size = new System.Drawing.Size(159, 24);
            this.GetSetParty.TabIndex = 0;
            this.GetSetParty.Text = "GetSetParty";
            // 
            // loadPartyToolStripMenuItem
            // 
            this.loadPartyToolStripMenuItem.Name = "loadPartyToolStripMenuItem";
            this.loadPartyToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.loadPartyToolStripMenuItem.Text = "Load Party";
            // 
            // clearPartyToolStripMenuItem
            // 
            this.clearPartyToolStripMenuItem.Name = "clearPartyToolStripMenuItem";
            this.clearPartyToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.clearPartyToolStripMenuItem.Text = "Clear Party";
            // 
            // listView4
            // 
            this.listView4.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9});
            this.listView4.FullRowSelect = true;
            this.listView4.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView4.Location = new System.Drawing.Point(206, 27);
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(203, 142);
            this.listView4.TabIndex = 12;
            this.listView4.UseCompatibleStateImageBehavior = false;
            this.listView4.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "name";
            this.columnHeader8.Width = 110;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "hp";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 206);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(0, 13);
            this.label15.TabIndex = 7;
            // 
            // flourish
            // 
            this.flourish.Controls.Add(this.flourishesiiigroup);
            this.flourish.Controls.Add(this.label40);
            this.flourish.Controls.Add(this.finsishingmovetext);
            this.flourish.Controls.Add(this.FlourishTPValue);
            this.flourish.Controls.Add(this.flourishesiigroup);
            this.flourish.Controls.Add(this.FlourishTP);
            this.flourish.Controls.Add(this.flourishesigroup);
            this.flourish.Location = new System.Drawing.Point(4, 22);
            this.flourish.Name = "flourish";
            this.flourish.Padding = new System.Windows.Forms.Padding(3);
            this.flourish.Size = new System.Drawing.Size(439, 351);
            this.flourish.TabIndex = 2;
            this.flourish.Text = "Flourishes";
            this.flourish.UseVisualStyleBackColor = true;
            // 
            // flourishesiiigroup
            // 
            this.flourishesiiigroup.Controls.Add(this.useclmfloValue);
            this.flourishesiiigroup.Controls.Add(this.usestkfloValue);
            this.flourishesiiigroup.Controls.Add(this.useterfloValue);
            this.flourishesiiigroup.Controls.Add(this.usestkflo);
            this.flourishesiiigroup.Controls.Add(this.useclmflo);
            this.flourishesiiigroup.Controls.Add(this.useterflo);
            this.flourishesiiigroup.Location = new System.Drawing.Point(26, 207);
            this.flourishesiiigroup.Name = "flourishesiiigroup";
            this.flourishesiiigroup.Size = new System.Drawing.Size(383, 71);
            this.flourishesiiigroup.TabIndex = 3;
            this.flourishesiiigroup.TabStop = false;
            this.flourishesiiigroup.Text = "Flourishes III";
            // 
            // useclmfloValue
            // 
            this.useclmfloValue.Enabled = false;
            this.useclmfloValue.Location = new System.Drawing.Point(139, 19);
            this.useclmfloValue.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.useclmfloValue.Name = "useclmfloValue";
            this.useclmfloValue.Size = new System.Drawing.Size(31, 20);
            this.useclmfloValue.TabIndex = 21;
            this.useclmfloValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // usestkfloValue
            // 
            this.usestkfloValue.Enabled = false;
            this.usestkfloValue.Location = new System.Drawing.Point(139, 42);
            this.usestkfloValue.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.usestkfloValue.Name = "usestkfloValue";
            this.usestkfloValue.Size = new System.Drawing.Size(31, 20);
            this.usestkfloValue.TabIndex = 22;
            this.usestkfloValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // useterfloValue
            // 
            this.useterfloValue.Enabled = false;
            this.useterfloValue.Location = new System.Drawing.Point(328, 43);
            this.useterfloValue.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.useterfloValue.Name = "useterfloValue";
            this.useterfloValue.Size = new System.Drawing.Size(31, 20);
            this.useterfloValue.TabIndex = 23;
            this.useterfloValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // usestkflo
            // 
            this.usestkflo.AutoSize = true;
            this.usestkflo.Enabled = false;
            this.usestkflo.Location = new System.Drawing.Point(25, 43);
            this.usestkflo.Name = "usestkflo";
            this.usestkflo.Size = new System.Drawing.Size(99, 17);
            this.usestkflo.TabIndex = 20;
            this.usestkflo.TabStop = true;
            this.usestkflo.Text = "Striking Flourish";
            this.usestkflo.UseVisualStyleBackColor = true;
            // 
            // useclmflo
            // 
            this.useclmflo.AutoSize = true;
            this.useclmflo.Enabled = false;
            this.useclmflo.Location = new System.Drawing.Point(25, 19);
            this.useclmflo.Name = "useclmflo";
            this.useclmflo.Size = new System.Drawing.Size(100, 17);
            this.useclmflo.TabIndex = 18;
            this.useclmflo.TabStop = true;
            this.useclmflo.Text = "Climatic Flourish";
            this.useclmflo.UseVisualStyleBackColor = true;
            // 
            // useterflo
            // 
            this.useterflo.AutoSize = true;
            this.useterflo.Enabled = false;
            this.useterflo.Location = new System.Drawing.Point(214, 42);
            this.useterflo.Name = "useterflo";
            this.useterflo.Size = new System.Drawing.Size(100, 17);
            this.useterflo.TabIndex = 19;
            this.useterflo.TabStop = true;
            this.useterflo.Text = "Ternary Flourish";
            this.useterflo.UseVisualStyleBackColor = true;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(186, 301);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(15, 13);
            this.label40.TabIndex = 64;
            this.label40.Text = "%";
            // 
            // finsishingmovetext
            // 
            this.finsishingmovetext.AutoSize = true;
            this.finsishingmovetext.Location = new System.Drawing.Point(23, 280);
            this.finsishingmovetext.Name = "finsishingmovetext";
            this.finsishingmovetext.Size = new System.Drawing.Size(197, 13);
            this.finsishingmovetext.TabIndex = 2;
            this.finsishingmovetext.Text = "Finishing Moves Required / 0 = disabled";
            // 
            // FlourishTPValue
            // 
            this.FlourishTPValue.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.FlourishTPValue.Location = new System.Drawing.Point(140, 297);
            this.FlourishTPValue.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.FlourishTPValue.Name = "FlourishTPValue";
            this.FlourishTPValue.Size = new System.Drawing.Size(44, 20);
            this.FlourishTPValue.TabIndex = 63;
            this.FlourishTPValue.TabStop = false;
            this.FlourishTPValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FlourishTPValue.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // flourishesiigroup
            // 
            this.flourishesiigroup.Controls.Add(this.usewldfloValue);
            this.flourishesiigroup.Controls.Add(this.usebldfloValue);
            this.flourishesiigroup.Controls.Add(this.userevfloValue);
            this.flourishesiigroup.Controls.Add(this.usewldflo);
            this.flourishesiigroup.Controls.Add(this.usebldflo);
            this.flourishesiigroup.Controls.Add(this.userevflo);
            this.flourishesiigroup.Location = new System.Drawing.Point(26, 131);
            this.flourishesiigroup.Name = "flourishesiigroup";
            this.flourishesiigroup.Size = new System.Drawing.Size(383, 70);
            this.flourishesiigroup.TabIndex = 1;
            this.flourishesiigroup.TabStop = false;
            this.flourishesiigroup.Text = "Flourishes II";
            // 
            // usewldfloValue
            // 
            this.usewldfloValue.Enabled = false;
            this.usewldfloValue.Location = new System.Drawing.Point(328, 38);
            this.usewldfloValue.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.usewldfloValue.Name = "usewldfloValue";
            this.usewldfloValue.Size = new System.Drawing.Size(31, 20);
            this.usewldfloValue.TabIndex = 21;
            this.usewldfloValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // usebldfloValue
            // 
            this.usebldfloValue.Enabled = false;
            this.usebldfloValue.Location = new System.Drawing.Point(139, 39);
            this.usebldfloValue.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.usebldfloValue.Name = "usebldfloValue";
            this.usebldfloValue.Size = new System.Drawing.Size(31, 20);
            this.usebldfloValue.TabIndex = 20;
            this.usebldfloValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // userevfloValue
            // 
            this.userevfloValue.Enabled = false;
            this.userevfloValue.Location = new System.Drawing.Point(139, 16);
            this.userevfloValue.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.userevfloValue.Name = "userevfloValue";
            this.userevfloValue.Size = new System.Drawing.Size(31, 20);
            this.userevfloValue.TabIndex = 19;
            this.userevfloValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // usewldflo
            // 
            this.usewldflo.AutoSize = true;
            this.usewldflo.Enabled = false;
            this.usewldflo.Location = new System.Drawing.Point(214, 39);
            this.usewldflo.Name = "usewldflo";
            this.usewldflo.Size = new System.Drawing.Size(85, 17);
            this.usewldflo.TabIndex = 18;
            this.usewldflo.TabStop = true;
            this.usewldflo.Text = "Wild Flourish";
            this.usewldflo.UseVisualStyleBackColor = true;
            // 
            // usebldflo
            // 
            this.usebldflo.AutoSize = true;
            this.usebldflo.Enabled = false;
            this.usebldflo.Location = new System.Drawing.Point(25, 39);
            this.usebldflo.Name = "usebldflo";
            this.usebldflo.Size = new System.Drawing.Size(101, 17);
            this.usebldflo.TabIndex = 17;
            this.usebldflo.TabStop = true;
            this.usebldflo.Text = "Building Flourish";
            this.usebldflo.UseVisualStyleBackColor = true;
            // 
            // userevflo
            // 
            this.userevflo.AutoSize = true;
            this.userevflo.Enabled = false;
            this.userevflo.Location = new System.Drawing.Point(25, 16);
            this.userevflo.Name = "userevflo";
            this.userevflo.Size = new System.Drawing.Size(104, 17);
            this.userevflo.TabIndex = 16;
            this.userevflo.TabStop = true;
            this.userevflo.Text = "Reverse Flourish";
            this.userevflo.UseVisualStyleBackColor = true;
            // 
            // FlourishTP
            // 
            this.FlourishTP.AutoSize = true;
            this.FlourishTP.Location = new System.Drawing.Point(26, 300);
            this.FlourishTP.Name = "FlourishTP";
            this.FlourishTP.Size = new System.Drawing.Size(109, 17);
            this.FlourishTP.TabIndex = 1;
            this.FlourishTP.Text = "Flourish under TP";
            this.FlourishTP.UseVisualStyleBackColor = true;
            // 
            // flourishesigroup
            // 
            this.flourishesigroup.Controls.Add(this.numericUpDown34);
            this.flourishesigroup.Controls.Add(this.usedesflo);
            this.flourishesigroup.Location = new System.Drawing.Point(26, 40);
            this.flourishesigroup.Name = "flourishesigroup";
            this.flourishesigroup.Size = new System.Drawing.Size(383, 76);
            this.flourishesigroup.TabIndex = 0;
            this.flourishesigroup.TabStop = false;
            this.flourishesigroup.Text = "Flourishes I";
            // 
            // numericUpDown34
            // 
            this.numericUpDown34.Enabled = false;
            this.numericUpDown34.Location = new System.Drawing.Point(139, 16);
            this.numericUpDown34.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDown34.Name = "numericUpDown34";
            this.numericUpDown34.Size = new System.Drawing.Size(31, 20);
            this.numericUpDown34.TabIndex = 26;
            this.numericUpDown34.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // usedesflo
            // 
            this.usedesflo.AutoSize = true;
            this.usedesflo.Enabled = false;
            this.usedesflo.Location = new System.Drawing.Point(25, 17);
            this.usedesflo.Name = "usedesflo";
            this.usedesflo.Size = new System.Drawing.Size(113, 17);
            this.usedesflo.TabIndex = 23;
            this.usedesflo.TabStop = true;
            this.usedesflo.Text = "Desperate Flourish";
            this.usedesflo.UseVisualStyleBackColor = true;
            // 
            // pets
            // 
            this.pets.Controls.Add(this.groupBox10);
            this.pets.Location = new System.Drawing.Point(4, 22);
            this.pets.Name = "pets";
            this.pets.Padding = new System.Windows.Forms.Padding(3);
            this.pets.Size = new System.Drawing.Size(439, 351);
            this.pets.TabIndex = 4;
            this.pets.Text = "Pets";
            this.pets.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.groupBox19);
            this.groupBox10.Controls.Add(this.petControl);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox10.Location = new System.Drawing.Point(3, 3);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(433, 345);
            this.groupBox10.TabIndex = 1;
            this.groupBox10.TabStop = false;
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.label23);
            this.groupBox19.Controls.Add(this.label22);
            this.groupBox19.Controls.Add(this.label21);
            this.groupBox19.Controls.Add(this.label20);
            this.groupBox19.Location = new System.Drawing.Point(6, 10);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(421, 50);
            this.groupBox19.TabIndex = 39;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Pet Information";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(241, 29);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(59, 13);
            this.label23.TabIndex = 9;
            this.label23.Text = "Pets TP%: ";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(240, 16);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(60, 13);
            this.label22.TabIndex = 8;
            this.label22.Text = "Pets HP%: ";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(37, 29);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(43, 13);
            this.label21.TabIndex = 7;
            this.label21.Text = "Pet ID: ";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(15, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 13);
            this.label20.TabIndex = 6;
            this.label20.Text = "Pets Name: ";
            // 
            // petControl
            // 
            this.petControl.Controls.Add(this.bstpettab);
            this.petControl.Controls.Add(this.drgpettab);
            this.petControl.Controls.Add(this.smnpettab);
            this.petControl.Controls.Add(this.puppettab);
            this.petControl.Controls.Add(this.geopettab);
            this.petControl.Location = new System.Drawing.Point(6, 66);
            this.petControl.Name = "petControl";
            this.petControl.SelectedIndex = 0;
            this.petControl.Size = new System.Drawing.Size(423, 273);
            this.petControl.TabIndex = 38;
            // 
            // bstpettab
            // 
            this.bstpettab.Controls.Add(this.usepetja);
            this.bstpettab.Controls.Add(this.bstpetrdygroup);
            this.bstpettab.Controls.Add(this.usedpetfood);
            this.bstpettab.Controls.Add(this.jugpet);
            this.bstpettab.Controls.Add(this.juguse);
            this.bstpettab.Controls.Add(this.pethppfood);
            this.bstpettab.Controls.Add(this.pethptext);
            this.bstpettab.Controls.Add(this.petfooduse);
            this.bstpettab.Controls.Add(this.autoengage);
            this.bstpettab.Location = new System.Drawing.Point(4, 22);
            this.bstpettab.Name = "bstpettab";
            this.bstpettab.Padding = new System.Windows.Forms.Padding(3);
            this.bstpettab.Size = new System.Drawing.Size(415, 247);
            this.bstpettab.TabIndex = 0;
            this.bstpettab.Text = "BST";
            this.bstpettab.UseVisualStyleBackColor = true;
            // 
            // usepetja
            // 
            this.usepetja.Controls.Add(this.PetJA);
            this.usepetja.Location = new System.Drawing.Point(220, 129);
            this.usepetja.Name = "usepetja";
            this.usepetja.Size = new System.Drawing.Size(176, 112);
            this.usepetja.TabIndex = 12;
            this.usepetja.TabStop = false;
            this.usepetja.Text = "Pet JA";
            // 
            // PetJA
            // 
            this.PetJA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PetJA.CheckOnClick = true;
            this.PetJA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PetJA.FormattingEnabled = true;
            this.PetJA.Location = new System.Drawing.Point(3, 16);
            this.PetJA.Name = "PetJA";
            this.PetJA.Size = new System.Drawing.Size(170, 93);
            this.PetJA.TabIndex = 0;
            // 
            // bstpetrdygroup
            // 
            this.bstpetrdygroup.Controls.Add(this.PetReady);
            this.bstpetrdygroup.Location = new System.Drawing.Point(14, 129);
            this.bstpetrdygroup.Name = "bstpetrdygroup";
            this.bstpetrdygroup.Size = new System.Drawing.Size(176, 112);
            this.bstpetrdygroup.TabIndex = 19;
            this.bstpetrdygroup.TabStop = false;
            this.bstpetrdygroup.Text = "Pet Ready";
            // 
            // PetReady
            // 
            this.PetReady.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PetReady.CheckOnClick = true;
            this.PetReady.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PetReady.FormattingEnabled = true;
            this.PetReady.Location = new System.Drawing.Point(3, 16);
            this.PetReady.Name = "PetReady";
            this.PetReady.Size = new System.Drawing.Size(170, 93);
            this.PetReady.TabIndex = 1;
            // 
            // usedpetfood
            // 
            this.usedpetfood.AutoCompleteCustomSource.AddRange(new string[] {
            "Pet Food Alpha Biscuit",
            "Pet Food Beta Biscuit",
            "Pet Food Gamma Biscuit",
            "Pet Food Delta Biscuit",
            "Pet Food Epsilon Biscuit",
            "Pet Food Zeta Biscuit",
            "Pet Food Eta Biscuit",
            "Pet Food Theta Biscuit"});
            this.usedpetfood.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.usedpetfood.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.usedpetfood.FormattingEnabled = true;
            this.usedpetfood.Location = new System.Drawing.Point(92, 35);
            this.usedpetfood.Name = "usedpetfood";
            this.usedpetfood.Size = new System.Drawing.Size(180, 21);
            this.usedpetfood.TabIndex = 14;
            // 
            // jugpet
            // 
            this.jugpet.AutoCompleteCustomSource.AddRange(new string[] {
            "Wormy Broth",
            "Carrot Broth",
            "Herbal Broth",
            "Humus",
            "Meat Broth",
            "Grasshopper Broth",
            "Carrion Broth",
            "Bug Broth",
            "Mole Broth",
            "Tree Sap",
            "Antica Broth",
            "Fish Broth",
            "Blood Broth",
            "Famous Carrot Broth",
            "Singing Herbal Broth",
            "Rich Humus",
            "Warm Meat Broth",
            "Seedbed Soil",
            "Quadav Bug Broth",
            "Cold Carrion Broth",
            "Fish Oil Broth",
            "Alchemist Water",
            "Noisy Grasshopper Broth",
            "Lively Mole Broth",
            "Scarlet Sap",
            "Clear Blood Broth",
            "Fragrant Antica Broth",
            "Sun Water",
            "Dancing Herbal Broth",
            "Cunning Brain Broth",
            "Chirping Grasshopper Broth",
            "Mellow Bird Broth",
            "Goblin Bug Broth",
            "Bubbling Carrion Broth",
            "Auroral Broth",
            "Lucky Carrot Broth",
            "Wool Grease",
            "Vermihumus",
            "Briny Broth",
            "Deepbed Soil",
            "Curdled Plasma Broth",
            "Lucky Broth",
            "Savage Mole Broth",
            "Razor Brain Broth",
            "Burning Carrion Broth",
            "Cloudy Wheat Broth",
            "Shadowy Broth",
            "Swirling Broth",
            "Shimmering Broth",
            "Spicy Broth",
            "Salubrious Broth",
            "Translucent Broth",
            "Fizzy Broth",
            "Wispy Broth",
            "Saline Broth",
            "Meaty Broth",
            "Blackwater Broth",
            "Pale Sap",
            "Crumbly Soil",
            "Airy Broth",
            "Muddy Broth",
            "Dire Broth",
            "Electrified Broth",
            "Bug-Ridden Broth"});
            this.jugpet.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.jugpet.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.jugpet.FormattingEnabled = true;
            this.jugpet.Location = new System.Drawing.Point(92, 12);
            this.jugpet.Name = "jugpet";
            this.jugpet.Size = new System.Drawing.Size(180, 21);
            this.jugpet.TabIndex = 13;
            // 
            // juguse
            // 
            this.juguse.AutoSize = true;
            this.juguse.Location = new System.Drawing.Point(17, 14);
            this.juguse.Name = "juguse";
            this.juguse.Size = new System.Drawing.Size(71, 17);
            this.juguse.TabIndex = 1;
            this.juguse.Text = "Auto Jug:";
            this.juguse.UseVisualStyleBackColor = true;
            // 
            // pethppfood
            // 
            this.pethppfood.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.pethppfood.Location = new System.Drawing.Point(360, 35);
            this.pethppfood.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.pethppfood.Name = "pethppfood";
            this.pethppfood.Size = new System.Drawing.Size(39, 20);
            this.pethppfood.TabIndex = 10;
            this.pethppfood.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pethppfood.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // pethptext
            // 
            this.pethptext.AutoSize = true;
            this.pethptext.Location = new System.Drawing.Point(287, 38);
            this.pethptext.Name = "pethptext";
            this.pethptext.Size = new System.Drawing.Size(72, 13);
            this.pethptext.TabIndex = 5;
            this.pethptext.Text = "<= Pets HP% ";
            // 
            // petfooduse
            // 
            this.petfooduse.AutoSize = true;
            this.petfooduse.Location = new System.Drawing.Point(17, 37);
            this.petfooduse.Name = "petfooduse";
            this.petfooduse.Size = new System.Drawing.Size(72, 17);
            this.petfooduse.TabIndex = 1;
            this.petfooduse.Text = "Pet Food:";
            this.petfooduse.UseVisualStyleBackColor = true;
            // 
            // autoengage
            // 
            this.autoengage.AutoSize = true;
            this.autoengage.Location = new System.Drawing.Point(290, 14);
            this.autoengage.Name = "autoengage";
            this.autoengage.Size = new System.Drawing.Size(107, 17);
            this.autoengage.TabIndex = 1;
            this.autoengage.Text = "Auto Engage Pet";
            this.autoengage.UseVisualStyleBackColor = true;
            // 
            // drgpettab
            // 
            this.drgpettab.Controls.Add(this.DragonPetHP);
            this.drgpettab.Controls.Add(this.drgsteadywingtext);
            this.drgpettab.Controls.Add(this.CallWyvern);
            this.drgpettab.Controls.Add(this.drgspirtlinkgroup);
            this.drgpettab.Controls.Add(this.label47);
            this.drgpettab.Controls.Add(this.BreathMAX);
            this.drgpettab.Controls.Add(this.label48);
            this.drgpettab.Controls.Add(this.BreathMIN);
            this.drgpettab.Controls.Add(this.drgwyvernbreathptext);
            this.drgpettab.Controls.Add(this.drgrestoringbreathgroup);
            this.drgpettab.Controls.Add(this.drgjagroup);
            this.drgpettab.Location = new System.Drawing.Point(4, 22);
            this.drgpettab.Name = "drgpettab";
            this.drgpettab.Padding = new System.Windows.Forms.Padding(3);
            this.drgpettab.Size = new System.Drawing.Size(415, 247);
            this.drgpettab.TabIndex = 3;
            this.drgpettab.Text = "DRG";
            this.drgpettab.UseVisualStyleBackColor = true;
            // 
            // DragonPetHP
            // 
            this.DragonPetHP.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.DragonPetHP.Location = new System.Drawing.Point(332, 142);
            this.DragonPetHP.Name = "DragonPetHP";
            this.DragonPetHP.Size = new System.Drawing.Size(44, 20);
            this.DragonPetHP.TabIndex = 118;
            this.DragonPetHP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // drgsteadywingtext
            // 
            this.drgsteadywingtext.AutoSize = true;
            this.drgsteadywingtext.Location = new System.Drawing.Point(216, 146);
            this.drgsteadywingtext.Name = "drgsteadywingtext";
            this.drgsteadywingtext.Size = new System.Drawing.Size(108, 13);
            this.drgsteadywingtext.TabIndex = 110;
            this.drgsteadywingtext.Text = "Steady Wing @ HP%";
            // 
            // CallWyvern
            // 
            this.CallWyvern.AutoSize = true;
            this.CallWyvern.Location = new System.Drawing.Point(199, 14);
            this.CallWyvern.Name = "CallWyvern";
            this.CallWyvern.Size = new System.Drawing.Size(108, 17);
            this.CallWyvern.TabIndex = 109;
            this.CallWyvern.Text = "Auto-Call Wyvern";
            this.CallWyvern.UseVisualStyleBackColor = true;
            // 
            // drgspirtlinkgroup
            // 
            this.drgspirtlinkgroup.Controls.Add(this.label16);
            this.drgspirtlinkgroup.Controls.Add(this.PlayerSpirit);
            this.drgspirtlinkgroup.Controls.Add(this.WyvernSpirit);
            this.drgspirtlinkgroup.Controls.Add(this.label46);
            this.drgspirtlinkgroup.Location = new System.Drawing.Point(17, 8);
            this.drgspirtlinkgroup.Name = "drgspirtlinkgroup";
            this.drgspirtlinkgroup.Size = new System.Drawing.Size(176, 70);
            this.drgspirtlinkgroup.TabIndex = 108;
            this.drgspirtlinkgroup.TabStop = false;
            this.drgspirtlinkgroup.Text = "Spirit Link";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(113, 13);
            this.label16.TabIndex = 26;
            this.label16.Text = "Use @ Wyvern\'s HP%";
            // 
            // PlayerSpirit
            // 
            this.PlayerSpirit.Location = new System.Drawing.Point(124, 39);
            this.PlayerSpirit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PlayerSpirit.Name = "PlayerSpirit";
            this.PlayerSpirit.Size = new System.Drawing.Size(44, 20);
            this.PlayerSpirit.TabIndex = 29;
            this.PlayerSpirit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PlayerSpirit.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // WyvernSpirit
            // 
            this.WyvernSpirit.Location = new System.Drawing.Point(124, 16);
            this.WyvernSpirit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WyvernSpirit.Name = "WyvernSpirit";
            this.WyvernSpirit.Size = new System.Drawing.Size(44, 20);
            this.WyvernSpirit.TabIndex = 27;
            this.WyvernSpirit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WyvernSpirit.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(40, 43);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(81, 13);
            this.label46.TabIndex = 28;
            this.label46.Text = "Player min HP%";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(269, 113);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(27, 13);
            this.label47.TabIndex = 104;
            this.label47.Text = "MIN";
            // 
            // BreathMAX
            // 
            this.BreathMAX.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.BreathMAX.Location = new System.Drawing.Point(301, 109);
            this.BreathMAX.Name = "BreathMAX";
            this.BreathMAX.Size = new System.Drawing.Size(44, 20);
            this.BreathMAX.TabIndex = 103;
            this.BreathMAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BreathMAX.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(351, 113);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(30, 13);
            this.label48.TabIndex = 105;
            this.label48.Text = "MAX";
            // 
            // BreathMIN
            // 
            this.BreathMIN.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.BreathMIN.Location = new System.Drawing.Point(219, 109);
            this.BreathMIN.Name = "BreathMIN";
            this.BreathMIN.Size = new System.Drawing.Size(44, 20);
            this.BreathMIN.TabIndex = 102;
            this.BreathMIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BreathMIN.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // drgwyvernbreathptext
            // 
            this.drgwyvernbreathptext.AutoSize = true;
            this.drgwyvernbreathptext.Location = new System.Drawing.Point(216, 93);
            this.drgwyvernbreathptext.Name = "drgwyvernbreathptext";
            this.drgwyvernbreathptext.Size = new System.Drawing.Size(160, 13);
            this.drgwyvernbreathptext.TabIndex = 101;
            this.drgwyvernbreathptext.Text = "Mob HP% to use Wyvern Breath";
            // 
            // drgrestoringbreathgroup
            // 
            this.drgrestoringbreathgroup.Controls.Add(this.RestoringBreathHP);
            this.drgrestoringbreathgroup.Controls.Add(this.label50);
            this.drgrestoringbreathgroup.Location = new System.Drawing.Point(199, 34);
            this.drgrestoringbreathgroup.Name = "drgrestoringbreathgroup";
            this.drgrestoringbreathgroup.Size = new System.Drawing.Size(200, 44);
            this.drgrestoringbreathgroup.TabIndex = 18;
            this.drgrestoringbreathgroup.TabStop = false;
            this.drgrestoringbreathgroup.Text = "Restoring Breath";
            // 
            // RestoringBreathHP
            // 
            this.RestoringBreathHP.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.RestoringBreathHP.Location = new System.Drawing.Point(117, 15);
            this.RestoringBreathHP.Name = "RestoringBreathHP";
            this.RestoringBreathHP.Size = new System.Drawing.Size(44, 20);
            this.RestoringBreathHP.TabIndex = 117;
            this.RestoringBreathHP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(39, 19);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(66, 13);
            this.label50.TabIndex = 116;
            this.label50.Text = "Use @ HP%";
            // 
            // drgjagroup
            // 
            this.drgjagroup.Controls.Add(this.WyvernJA);
            this.drgjagroup.Location = new System.Drawing.Point(17, 81);
            this.drgjagroup.Name = "drgjagroup";
            this.drgjagroup.Size = new System.Drawing.Size(176, 159);
            this.drgjagroup.TabIndex = 13;
            this.drgjagroup.TabStop = false;
            this.drgjagroup.Text = "Pet JA";
            // 
            // WyvernJA
            // 
            this.WyvernJA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WyvernJA.CheckOnClick = true;
            this.WyvernJA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WyvernJA.FormattingEnabled = true;
            this.WyvernJA.Location = new System.Drawing.Point(3, 16);
            this.WyvernJA.Name = "WyvernJA";
            this.WyvernJA.Size = new System.Drawing.Size(170, 140);
            this.WyvernJA.TabIndex = 1;
            // 
            // smnpettab
            // 
            this.smnpettab.Controls.Add(this.checkBox7);
            this.smnpettab.Location = new System.Drawing.Point(4, 22);
            this.smnpettab.Name = "smnpettab";
            this.smnpettab.Size = new System.Drawing.Size(415, 247);
            this.smnpettab.TabIndex = 2;
            this.smnpettab.Text = "SMN";
            this.smnpettab.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(126, 130);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(107, 17);
            this.checkBox7.TabIndex = 2;
            this.checkBox7.Text = "Auto Engage Pet";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // puppettab
            // 
            this.puppettab.Controls.Add(this.checkBox8);
            this.puppettab.Location = new System.Drawing.Point(4, 22);
            this.puppettab.Name = "puppettab";
            this.puppettab.Padding = new System.Windows.Forms.Padding(3);
            this.puppettab.Size = new System.Drawing.Size(415, 247);
            this.puppettab.TabIndex = 1;
            this.puppettab.Text = "PUP";
            this.puppettab.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(140, 128);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(107, 17);
            this.checkBox8.TabIndex = 3;
            this.checkBox8.Text = "Auto Engage Pet";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // geopettab
            // 
            this.geopettab.Location = new System.Drawing.Point(4, 22);
            this.geopettab.Name = "geopettab";
            this.geopettab.Padding = new System.Windows.Forms.Padding(3);
            this.geopettab.Size = new System.Drawing.Size(415, 247);
            this.geopettab.TabIndex = 4;
            this.geopettab.Text = "GEO";
            this.geopettab.UseVisualStyleBackColor = true;
            // 
            // bgw_script_dnc
            // 
            this.bgw_script_dnc.WorkerReportsProgress = true;
            this.bgw_script_dnc.WorkerSupportsCancellation = true;
            this.bgw_script_dnc.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwScriptDncDoWork);
            // 
            // bgw_script_nav
            // 
            this.bgw_script_nav.WorkerReportsProgress = true;
            this.bgw_script_nav.WorkerSupportsCancellation = true;
            this.bgw_script_nav.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwScriptNavDoWork);
            // 
            // bgw_script_sch
            // 
            this.bgw_script_sch.WorkerReportsProgress = true;
            this.bgw_script_sch.WorkerSupportsCancellation = true;
            this.bgw_script_sch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwScriptSCHChargesDoWork);
            // 
            // bgw_script_chat
            // 
            this.bgw_script_chat.WorkerReportsProgress = true;
            this.bgw_script_chat.WorkerSupportsCancellation = true;
            this.bgw_script_chat.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwScriptchatWatchDoWork);
            // 
            // bgw_script_pet
            // 
            this.bgw_script_pet.WorkerReportsProgress = true;
            this.bgw_script_pet.WorkerSupportsCancellation = true;
            this.bgw_script_pet.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwScriptPetDoWork);
            // 
            // DeathWarp
            // 
            this.DeathWarp.AutoSize = true;
            this.DeathWarp.Location = new System.Drawing.Point(617, 219);
            this.DeathWarp.Name = "DeathWarp";
            this.DeathWarp.Size = new System.Drawing.Size(99, 17);
            this.DeathWarp.TabIndex = 52;
            this.DeathWarp.Text = "Warp on Death";
            this.DeathWarp.UseVisualStyleBackColor = true;
            // 
            // ScriptFarmDNC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DeathWarp);
            this.Controls.Add(this.checkZone);
            this.Controls.Add(this.StopFullInventory);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.usenav);
            this.Controls.Add(this.StartStopScript);
            this.Controls.Add(this.dncControl);
            this.Name = "ScriptFarmDNC";
            this.Size = new System.Drawing.Size(727, 418);
            this.Load += new System.EventHandler(this.ScriptFarmDncLoad);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.GetSetNavi.ResumeLayout(false);
            this.GetSetNavi.PerformLayout();
            this.StartStopScript.ResumeLayout(false);
            this.StartStopScript.PerformLayout();
            this.dncControl.ResumeLayout(false);
            this.targets.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ZoneTargets.ResumeLayout(false);
            this.ZoneTargets.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.GetSetTargets.ResumeLayout(false);
            this.GetSetTargets.PerformLayout();
            this.selecttargets.ResumeLayout(false);
            this.combat.ResumeLayout(false);
            this.CombatSettingsTabs.ResumeLayout(false);
            this.Options1MainTab.ResumeLayout(false);
            this.groupBox23.ResumeLayout(false);
            this.groupBox23.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).EndInit();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AfterMathTier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown23)).EndInit();
            this.Options2MainTab.ResumeLayout(false);
            this.Options2MainTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aggroRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeepTargetRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assistDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.followDist)).EndInit();
            this.Options3MainTab.ResumeLayout(false);
            this.Options3MainTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.healMPcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.healHPcount)).EndInit();
            this.Options4MainTab.ResumeLayout(false);
            this.DropBox.ResumeLayout(false);
            this.DropBox.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoRangeDelay)).EndInit();
            this.OptionsJAMainTab.ResumeLayout(false);
            this.JAtabselect.ResumeLayout(false);
            this.selectPage.ResumeLayout(false);
            this.selectPage.PerformLayout();
            this.GetSetJA.ResumeLayout(false);
            this.GetSetJA.PerformLayout();
            this.WHMpage.ResumeLayout(false);
            this.benedictiongroupBox.ResumeLayout(false);
            this.benedictiongroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BenedictionHPPuse)).EndInit();
            this.RDMpage.ResumeLayout(false);
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConvertHPP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConvertMPP)).EndInit();
            this.SCHpage.ResumeLayout(false);
            this.SCHpage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sublimationcount)).EndInit();
            this.RUNpage.ResumeLayout(false);
            this.RUNpage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VivaciousPulseHP)).EndInit();
            this.MONpage.ResumeLayout(false);
            this.MONpage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MONmpCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MONhpCount)).EndInit();
            this.Dynamispage.ResumeLayout(false);
            this.Dynamispage.PerformLayout();
            this.OptionsMAMainTab.ResumeLayout(false);
            this.MAtabs.ResumeLayout(false);
            this.MASelectPage.ResumeLayout(false);
            this.MASelectPage.PerformLayout();
            this.GetSetMA.ResumeLayout(false);
            this.GetSetMA.PerformLayout();
            this.CureConfigPage.ResumeLayout(false);
            this.CureConfigPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CuraIIcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CuraIIIcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Curacount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FullCurecount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureVIcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureVcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureIVcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureIIIcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureIIcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Curecount)).EndInit();
            this.DrainAspirpage.ResumeLayout(false);
            this.Aspirgroup.ResumeLayout(false);
            this.Aspirgroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AspirIIIcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AspirIIcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AspirIcount)).EndInit();
            this.Draingroup.ResumeLayout(false);
            this.Draingroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrainIcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrainIIIcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrainIIcount)).EndInit();
            this.BLUCurespage.ResumeLayout(false);
            this.BLUCurespage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MagicFruitcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pollencount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealingBreezecount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PleniluneEmbracecount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Restoralcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WhiteWindcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exuviationcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WildCarrotcount)).EndInit();
            this.MAconfigpage.ResumeLayout(false);
            this.MAconfigpage.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pullDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetSearchDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pullTolorance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown21)).EndInit();
            this.dancer.ResumeLayout(false);
            this.dancer.PerformLayout();
            this.tabControl3.ResumeLayout(false);
            this.tabPage14.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stopstepscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usefeatherstepValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usestutterstepValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.useboxstepValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepsHPValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usequickstepValue)).EndInit();
            this.tabPage15.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usecurevValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usecureivValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usecureiiiValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usecureiiValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usecureValue)).EndInit();
            this.tabPage16.ResumeLayout(false);
            this.tabPage16.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown33)).EndInit();
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.GetSetParty.ResumeLayout(false);
            this.GetSetParty.PerformLayout();
            this.flourish.ResumeLayout(false);
            this.flourish.PerformLayout();
            this.flourishesiiigroup.ResumeLayout(false);
            this.flourishesiiigroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.useclmfloValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usestkfloValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.useterfloValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlourishTPValue)).EndInit();
            this.flourishesiigroup.ResumeLayout(false);
            this.flourishesiigroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usewldfloValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usebldfloValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userevfloValue)).EndInit();
            this.flourishesigroup.ResumeLayout(false);
            this.flourishesigroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown34)).EndInit();
            this.pets.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.petControl.ResumeLayout(false);
            this.bstpettab.ResumeLayout(false);
            this.bstpettab.PerformLayout();
            this.usepetja.ResumeLayout(false);
            this.bstpetrdygroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pethppfood)).EndInit();
            this.drgpettab.ResumeLayout(false);
            this.drgpettab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DragonPetHP)).EndInit();
            this.drgspirtlinkgroup.ResumeLayout(false);
            this.drgspirtlinkgroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerSpirit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WyvernSpirit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BreathMAX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BreathMIN)).EndInit();
            this.drgrestoringbreathgroup.ResumeLayout(false);
            this.drgrestoringbreathgroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RestoringBreathHP)).EndInit();
            this.drgjagroup.ResumeLayout(false);
            this.smnpettab.ResumeLayout(false);
            this.smnpettab.PerformLayout();
            this.puppettab.ResumeLayout(false);
            this.puppettab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox checkZone;
        public System.Windows.Forms.CheckBox StopFullInventory;
        public System.Windows.Forms.GroupBox groupBox8;
        public System.Windows.Forms.CheckBox firstPersonView;
        public System.Windows.Forms.CheckBox runReverse;
        public System.Windows.Forms.RadioButton Linear;
        public System.Windows.Forms.RadioButton Circular;
        public System.Windows.Forms.ComboBox selectedNavi;
        public System.Windows.Forms.MenuStrip GetSetNavi;
        public System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        public System.Windows.Forms.CheckBox usenav;
        public System.Windows.Forms.MenuStrip StartStopScript;
        public System.Windows.Forms.ToolStripMenuItem startScriptToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem stopScriptToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem updateJobToolStripMenuItem;
        public System.Windows.Forms.TabControl dncControl;
        public System.Windows.Forms.TabPage targets;
        public System.Windows.Forms.GroupBox groupBox9;
        public System.Windows.Forms.MenuStrip ZoneTargets;
        public System.Windows.Forms.ToolStripMenuItem NameListToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem iDToolStripMenuItem;
        public System.Windows.Forms.GroupBox groupBox11;
        public System.Windows.Forms.ListView TargetList;
        public System.Windows.Forms.ColumnHeader columnHeader3;
        public System.Windows.Forms.ColumnHeader columnHeader4;
        public System.Windows.Forms.GroupBox groupBox12;
        public System.Windows.Forms.MenuStrip GetSetTargets;
        public System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        public System.Windows.Forms.GroupBox selecttargets;
        public System.Windows.Forms.ListView SelectedTargets;
        public System.Windows.Forms.ColumnHeader columnHeader1;
        public System.Windows.Forms.ColumnHeader columnHeader2;
        public System.Windows.Forms.TabPage combat;
        public System.Windows.Forms.TabControl CombatSettingsTabs;
        public System.Windows.Forms.TabPage Options1MainTab;
        public System.Windows.Forms.GroupBox groupBox23;
        public System.Windows.Forms.NumericUpDown numericUpDown6;
        public System.Windows.Forms.NumericUpDown numericUpDown7;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox selectedHateControl;
        public System.Windows.Forms.CheckBox tank;
        public System.Windows.Forms.GroupBox groupBox20;
        public System.Windows.Forms.ComboBox amname;
        public System.Windows.Forms.NumericUpDown AfterMathTier;
        public System.Windows.Forms.CheckBox wsam;
        public System.Windows.Forms.CheckBox checkBox6;
        public System.Windows.Forms.ComboBox comboBox2;
        public System.Windows.Forms.Label label39;
        public System.Windows.Forms.NumericUpDown numericUpDown40;
        public System.Windows.Forms.CheckBox ws;
        public System.Windows.Forms.NumericUpDown numericUpDown24;
        public System.Windows.Forms.Label label29;
        public System.Windows.Forms.NumericUpDown numericUpDown22;
        public System.Windows.Forms.Label label28;
        public System.Windows.Forms.NumericUpDown numericUpDown23;
        public System.Windows.Forms.Label label27;
        public System.Windows.Forms.TabPage Options2MainTab;
        public System.Windows.Forms.NumericUpDown numericUpDown38;
        public System.Windows.Forms.NumericUpDown aggroRange;
        public System.Windows.Forms.CheckBox ScanDelay;
        public System.Windows.Forms.NumericUpDown KeepTargetRange;
        public System.Windows.Forms.NumericUpDown assistDist;
        public System.Windows.Forms.NumericUpDown followDist;
        public System.Windows.Forms.CheckBox partyAssist;
        public System.Windows.Forms.CheckBox facetarget;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.CheckBox assist;
        public System.Windows.Forms.CheckBox followplayer;
        public System.Windows.Forms.TextBox followName;
        public System.Windows.Forms.CheckBox useshadows;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox assistplayer;
        public System.Windows.Forms.CheckBox aggro;
        public System.Windows.Forms.CheckBox mobdist;
        public System.Windows.Forms.TabPage Options3MainTab;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBox8;
        public System.Windows.Forms.NumericUpDown healMPcount;
        public System.Windows.Forms.CheckBox usefood;
        public System.Windows.Forms.CheckBox HealMP;
        public System.Windows.Forms.NumericUpDown healHPcount;
        public System.Windows.Forms.CheckBox HealHP;
        public System.Windows.Forms.TextBox textBox6;
        public System.Windows.Forms.Label label35;
        public System.Windows.Forms.TabPage Options4MainTab;
        public System.Windows.Forms.ComboBox comboBox4;
        public System.Windows.Forms.ComboBox SignetStaff;
        public System.Windows.Forms.CheckBox useStaff;
        public System.Windows.Forms.GroupBox groupBox15;
        public System.Windows.Forms.Label label42;
        public System.Windows.Forms.NumericUpDown autoRangeDelay;
        public System.Windows.Forms.TextBox textBox7;
        public System.Windows.Forms.CheckBox rangeaggro;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.CheckBox checkBox4;
        public System.Windows.Forms.CheckBox autoRangeAttack;
        public System.Windows.Forms.Button RecordIdleLocation;
        public System.Windows.Forms.CheckBox IdleLocation;
        public System.Windows.Forms.CheckBox WeakLocation;
        public System.Windows.Forms.TabPage OptionsJAMainTab;
        public System.Windows.Forms.CheckedListBox playerJA;
        public System.Windows.Forms.MenuStrip GetSetJA;
        public System.Windows.Forms.ToolStripMenuItem loadJAsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem clearJAsToolStripMenuItem;
        public System.Windows.Forms.GroupBox groupBox14;
        public System.Windows.Forms.Label delaytext;
        public System.Windows.Forms.NumericUpDown pullDelay;
        public System.Windows.Forms.CheckBox AutoLock;
        public System.Windows.Forms.NumericUpDown numericUpDown39;
        public System.Windows.Forms.CheckBox mobheightdist;
        public System.Windows.Forms.CheckBox runTarget;
        public System.Windows.Forms.CheckBox runPullDistance;
        public System.Windows.Forms.Label mobsearchdisttext;
        public System.Windows.Forms.NumericUpDown targetSearchDist;
        public System.Windows.Forms.NumericUpDown pullTolorance;
        public System.Windows.Forms.Label pulltolorancetext;
        public System.Windows.Forms.NumericUpDown numericUpDown21;
        public System.Windows.Forms.Label pulldistance;
        public System.Windows.Forms.TextBox pullCommand;
        public System.Windows.Forms.Label pullcommandtext;
        public System.Windows.Forms.TabPage dancer;
        public System.Windows.Forms.TabControl tabControl3;
        public System.Windows.Forms.TabPage tabPage14;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton noSamba;
        public System.Windows.Forms.RadioButton usedrainiii;
        public System.Windows.Forms.RadioButton usehaste;
        public System.Windows.Forms.RadioButton useaspirii;
        public System.Windows.Forms.RadioButton useaspir;
        public System.Windows.Forms.RadioButton usedrainii;
        public System.Windows.Forms.RadioButton usedrain;
        public System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Label stopstepsathptext;
        public System.Windows.Forms.NumericUpDown usefeatherstepValue;
        public System.Windows.Forms.NumericUpDown usestutterstepValue;
        public System.Windows.Forms.NumericUpDown useboxstepValue;
        public System.Windows.Forms.NumericUpDown StepsHPValue;
        public System.Windows.Forms.NumericUpDown usequickstepValue;
        public System.Windows.Forms.CheckBox StepsHP;
        public System.Windows.Forms.RadioButton NoSteps;
        public System.Windows.Forms.RadioButton usequickstep;
        public System.Windows.Forms.RadioButton useboxstep;
        public System.Windows.Forms.RadioButton usestutterstep;
        public System.Windows.Forms.RadioButton usefeatherstep;
        public System.Windows.Forms.TabPage tabPage15;
        public System.Windows.Forms.GroupBox groupBox7;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.CheckedListBox HealingWaltzItems;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Label label32;
        public System.Windows.Forms.Label label31;
        public System.Windows.Forms.Label label30;
        public System.Windows.Forms.Label label25;
        public System.Windows.Forms.Label label17;
        public System.Windows.Forms.NumericUpDown usecurevValue;
        public System.Windows.Forms.NumericUpDown usecureivValue;
        public System.Windows.Forms.NumericUpDown usecureiiiValue;
        public System.Windows.Forms.NumericUpDown usecureiiValue;
        public System.Windows.Forms.NumericUpDown usecureValue;
        public System.Windows.Forms.CheckBox usecurev;
        public System.Windows.Forms.CheckBox usecureiv;
        public System.Windows.Forms.CheckBox usecureiii;
        public System.Windows.Forms.CheckBox usecureii;
        public System.Windows.Forms.CheckBox usecure;
        public System.Windows.Forms.TabPage tabPage16;
        public System.Windows.Forms.Label addplayertext;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.GroupBox groupBox21;
        public System.Windows.Forms.Label label38;
        public System.Windows.Forms.Label label37;
        public System.Windows.Forms.Label label36;
        public System.Windows.Forms.Label label34;
        public System.Windows.Forms.Label label33;
        public System.Windows.Forms.NumericUpDown numericUpDown27;
        public System.Windows.Forms.NumericUpDown numericUpDown28;
        public System.Windows.Forms.NumericUpDown numericUpDown29;
        public System.Windows.Forms.NumericUpDown numericUpDown32;
        public System.Windows.Forms.NumericUpDown numericUpDown33;
        public System.Windows.Forms.CheckBox ptusecurev;
        public System.Windows.Forms.CheckBox ptusecureiv;
        public System.Windows.Forms.CheckBox ptusecureiii;
        public System.Windows.Forms.CheckBox ptusecureii;
        public System.Windows.Forms.CheckBox ptusecure;
        public System.Windows.Forms.GroupBox groupBox22;
        public System.Windows.Forms.MenuStrip GetSetParty;
        public System.Windows.Forms.ToolStripMenuItem loadPartyToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem clearPartyToolStripMenuItem;
        public System.Windows.Forms.ListView listView4;
        public System.Windows.Forms.ColumnHeader columnHeader8;
        public System.Windows.Forms.ColumnHeader columnHeader9;
        public System.Windows.Forms.Label label15;
        public System.Windows.Forms.TabPage flourish;
        public System.Windows.Forms.GroupBox flourishesiiigroup;
        public System.Windows.Forms.NumericUpDown useclmfloValue;
        public System.Windows.Forms.NumericUpDown usestkfloValue;
        public System.Windows.Forms.NumericUpDown useterfloValue;
        public System.Windows.Forms.RadioButton usestkflo;
        public System.Windows.Forms.RadioButton useclmflo;
        public System.Windows.Forms.RadioButton useterflo;
        public System.Windows.Forms.Label label40;
        public System.Windows.Forms.Label finsishingmovetext;
        public System.Windows.Forms.NumericUpDown FlourishTPValue;
        public System.Windows.Forms.GroupBox flourishesiigroup;
        public System.Windows.Forms.NumericUpDown usewldfloValue;
        public System.Windows.Forms.NumericUpDown usebldfloValue;
        public System.Windows.Forms.NumericUpDown userevfloValue;
        public System.Windows.Forms.RadioButton usewldflo;
        public System.Windows.Forms.RadioButton usebldflo;
        public System.Windows.Forms.RadioButton userevflo;
        public System.Windows.Forms.CheckBox FlourishTP;
        public System.Windows.Forms.GroupBox flourishesigroup;
        public System.Windows.Forms.NumericUpDown numericUpDown34;
        public System.Windows.Forms.RadioButton usedesflo;
        public System.Windows.Forms.TabPage pets;
        public System.Windows.Forms.GroupBox groupBox10;
        public System.Windows.Forms.GroupBox groupBox19;
        public System.Windows.Forms.TabControl petControl;
        public System.Windows.Forms.TabPage bstpettab;
        public System.Windows.Forms.GroupBox usepetja;
        public System.Windows.Forms.CheckedListBox PetJA;
        public System.Windows.Forms.GroupBox bstpetrdygroup;
        public System.Windows.Forms.CheckedListBox PetReady;
        public System.Windows.Forms.ComboBox usedpetfood;
        public System.Windows.Forms.ComboBox jugpet;
        public System.Windows.Forms.CheckBox juguse;
        public System.Windows.Forms.NumericUpDown pethppfood;
        public System.Windows.Forms.Label pethptext;
        public System.Windows.Forms.CheckBox petfooduse;
        public System.Windows.Forms.CheckBox autoengage;
        public System.Windows.Forms.TabPage drgpettab;
        public System.Windows.Forms.NumericUpDown DragonPetHP;
        public System.Windows.Forms.Label drgsteadywingtext;
        public System.Windows.Forms.CheckBox CallWyvern;
        public System.Windows.Forms.GroupBox drgspirtlinkgroup;
        public System.Windows.Forms.Label label16;
        public System.Windows.Forms.NumericUpDown PlayerSpirit;
        public System.Windows.Forms.NumericUpDown WyvernSpirit;
        public System.Windows.Forms.Label label46;
        public System.Windows.Forms.Label label47;
        public System.Windows.Forms.NumericUpDown BreathMAX;
        public System.Windows.Forms.Label label48;
        public System.Windows.Forms.NumericUpDown BreathMIN;
        public System.Windows.Forms.Label drgwyvernbreathptext;
        public System.Windows.Forms.GroupBox drgrestoringbreathgroup;
        public System.Windows.Forms.NumericUpDown RestoringBreathHP;
        public System.Windows.Forms.Label label50;
        public System.Windows.Forms.GroupBox drgjagroup;
        public System.Windows.Forms.CheckedListBox WyvernJA;
        public System.Windows.Forms.TabPage smnpettab;
        public System.Windows.Forms.TabPage puppettab;
        public System.ComponentModel.BackgroundWorker bgw_script_dnc;
        public System.ComponentModel.BackgroundWorker bgw_script_nav;
        public System.ComponentModel.BackgroundWorker bgw_script_sch;
        public System.ComponentModel.BackgroundWorker bgw_script_chat;
        public System.ComponentModel.BackgroundWorker bgw_script_pet;
        public System.ComponentModel.BackgroundWorker bgw_script_npc;
        public System.ComponentModel.BackgroundWorker bgw_script_scn;
        public System.Windows.Forms.GroupBox DropBox;
        public System.Windows.Forms.ComboBox comboBox3;
        public System.Windows.Forms.ComboBox comboBox7;
        public System.Windows.Forms.ComboBox comboBox6;
        public System.Windows.Forms.CheckBox checkBox3;
        public System.Windows.Forms.CheckBox checkBox2;
        public System.Windows.Forms.Label label23;
        public System.Windows.Forms.Label label22;
        public System.Windows.Forms.Label label21;
        public System.Windows.Forms.Label label20;
        public System.Windows.Forms.CheckBox DeathWarp;
        public NumericUpDown stopstepscount;
        public CheckBox checkBox7;
        public CheckBox checkBox8;
        public CheckBox stopstepsat;
        private TabPage OptionsMAMainTab;
        private TabControl MAtabs;
        private TabPage MASelectPage;
        private TabPage CureConfigPage;
        public CheckedListBox playerMA;
        public MenuStrip GetSetMA;
        public ToolStripMenuItem loadMAsToolStripMenuItem;
        public ToolStripMenuItem clearMAsToolStripMenuItem;
        private Label label44;
        private Label label43;
        private Label label9;
        private Label label2;
        private Label label1;
        private NumericUpDown Curecount;
        private NumericUpDown CureVcount;
        private NumericUpDown CureIVcount;
        private NumericUpDown CureIIIcount;
        private NumericUpDown CureIIcount;
        private NumericUpDown CureVIcount;
        private Label label45;
        private NumericUpDown FullCurecount;
        private Label label52;
        private NumericUpDown CuraIIcount;
        private Label label55;
        private NumericUpDown CuraIIIcount;
        private Label label53;
        private NumericUpDown Curacount;
        private Label label54;
        private TabControl JAtabselect;
        private TabPage selectPage;
        private TabPage WHMpage;
        private GroupBox benedictiongroupBox;
        private NumericUpDown BenedictionHPPuse;
        private Label benedictiontext;
        private TabPage RDMpage;
        private GroupBox groupBox18;
        private NumericUpDown ConvertHPP;
        private NumericUpDown ConvertMPP;
        private CheckBox ConvertMP;
        private CheckBox ConvertHP;
        private Label convertmptext;
        private Label converthptext;
        private TabPage RUNpage;
        private TabPage MONpage;
        private NumericUpDown MONmpCount;
        private NumericUpDown MONhpCount;
        private Label monmptext;
        private Label monhptext;
        private CheckBox VivaciousPulse;
        private NumericUpDown VivaciousPulseHP;
        private TabPage Dynamispage;
        private Label Dynatxt;
        private CheckBox staggerstopJA;
        private TabPage geopettab;
        private TabPage SCHpage;
        private NumericUpDown Sublimationcount;
        private Label label8;
        private TabPage DrainAspirpage;
        private GroupBox Aspirgroup;
        private NumericUpDown AspirIIIcount;
        private NumericUpDown AspirIIcount;
        private Label AspirIIItext;
        private Label AspirItext;
        private Label AspirIItext;
        private NumericUpDown AspirIcount;
        private GroupBox Draingroup;
        private Label DrainIItext;
        private NumericUpDown DrainIcount;
        private Label DrainItext;
        private Label DrainIIItext;
        private NumericUpDown DrainIIIcount;
        private NumericUpDown DrainIIcount;
        private TabPage BLUCurespage;
        private NumericUpDown MagicFruitcount;
        private NumericUpDown Pollencount;
        private NumericUpDown HealingBreezecount;
        private NumericUpDown PleniluneEmbracecount;
        private NumericUpDown Restoralcount;
        private NumericUpDown WhiteWindcount;
        private NumericUpDown Exuviationcount;
        private NumericUpDown WildCarrotcount;
        private Label PleniluneEmbracetext;
        private Label MagicFruittext;
        private Label HealingBreezetext;
        private Label Pollentext;
        private Label WhiteWindtext;
        private Label Restoraltext;
        private Label Exuviationtext;
        private Label WildCarrottext;

        #region Methods: Start/Stop/Load

        private void ScriptFarmDncLoad(object sender, EventArgs e)
        {
            dncControl.SelectTab("combat");
            PopulateTargetLists("ID");
            CharacterUpdate();

            if (PetInfo.Name != null)
                pInfo();

            LoadJA_Click(null, null);
            LoadMA_Click(null, null);

            PopulateItems();
            //MessageBox.Show(ItemQuantityByName("Blind Bolt").ToString());
        }

        private void UpdateJobToolStripMenuItemClick(object sender, EventArgs e)
        {
            CharacterUpdate();

            if (PetInfo.Name != null)
                pInfo();
        }

        private void ToolStartClick(object sender, EventArgs e)
        {
            botRunning = true;

            startScriptToolStripMenuItem.Enabled = false;
            stopScriptToolStripMenuItem.Enabled = true;

            if (!bgw_script_dnc.IsBusy)
                bgw_script_dnc.RunWorkerAsync();

            if (!bgw_script_pet.IsBusy)
                bgw_script_pet.RunWorkerAsync();

            if (!bgw_script_nav.IsBusy)
                bgw_script_nav.RunWorkerAsync();

            if (!bgw_script_chat.IsBusy)
                bgw_script_chat.RunWorkerAsync();
        }

        private void ToolStopClick(object sender, EventArgs e)
        {
            botRunning = false;

            if (usenav.Checked && naviMove)
                naviMove = false;

            if (api.AutoFollow.IsAutoFollowing)
                api.AutoFollow.IsAutoFollowing = false;

            Thread.Sleep(TimeSpan.FromSeconds(0.3));

            startScriptToolStripMenuItem.Enabled = true;
            stopScriptToolStripMenuItem.Enabled = false;

            bgw_script_dnc.CancelAsync();
            bgw_script_pet.CancelAsync();
            bgw_script_nav.CancelAsync();
            bgw_script_chat.CancelAsync();
        }

        private void PlayerDead()
        {
            ToolStopClick(null, null);
            Thread.Sleep(TimeSpan.FromSeconds(1.0));

            WindowInfo.KeyPress(API.Keys.NUMPADENTER);
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
            WindowInfo.KeyPress(API.Keys.RIGHT);
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
            WindowInfo.KeyPress(API.Keys.NUMPADENTER);
        }

        private void LoadJA_Click(object sender, EventArgs e)
        {
            if (playerJA.Items.Count > 0)
                playerJA.Items.Clear();

            #region Ability list
            List<uint> abilitylist = new List<uint>(new uint[] {528, 529, 530, 531, 532, 533, 534, 535, 536, 537, 538, 539, 540, 541, 542,
            543, 544, 545, 546, 548, 549, 550, 551, 552, 553, 554, 555, 556, 557, 558, 559, 560, 561, 562, 563, 564, 565, 566, 567, 568,
            569, 570, 571, 572, 573, 574, 575, 576, 577, 578, 579, 580, 581, 582, 583, 584, 585, 586, 587, 588, 589, 590, 591, 592, 593,
            594, 595, 596, 597, 598, 599, 600, 601, 602, 603, 604, 605, 606, 607, 608, 610, 611, 612, 613, 614, 615, 616, 617, 618, 619,
            620, 621, 622, 623, 624, 625, 626, 627, 628, 629, 630, 631, 632, 633, 634, 635, 636, 637, 638, 639, 640, 641, 642, 643, 644,
            645, 647, 648, 649, 650, 651, 652, 653, 654, 655, 656, 657, 658, 659, 660, 661, 662, 663, 664, 665, 666, 667, 668, 669, 670,
            671, 672, 673, 674, 675, 676, 677, 678, 679, 680, 681, 682, 683, 684, 685, 686, 687, 688, 689, 690, 691, 692, 693, 708, 709,
            722, 723, 724, 726, 727, 728, 729, 730, 731, 732, 733, 734, 735, 736, 737, 738, 739, 740, 741, 742, 744, 745, 746, 747, 748,
            749, 750, 751, 752, 753, 754, 755, 756, 757, 758, 759, 760, 761, 762, 763, 764, 765, 766, 767, 768, 769, 770, 771, 772, 773,
            777, 778, 779, 781, 782, 783, 784, 785, 786, 787, 788, 789, 790, 791, 792, 793, 794, 795, 796, 797, 798, 799, 800, 803,
            804, 805, 807, 808, 809, 810, 813, 814, 815, 816, 817, 821, 822, 828, 829, 830, 831, 832, 833, 834, 835,
            836, 837, 838, 839, 840, 841, 842, 843, 844, 845, 846, 847, 848, 849, 850, 851, 852, 853, 854, 855, 856, 857, 858, 859, 860,
            861, 862, 863, 864, 865, 866, 867, 868, 869, 870, 871, 872, 873, 874, 875, 876, 877, 878, 879, 880, 881, 882, 883, 884, 885,
            886, 887, 888, 889, 890, 891, 892, 893, 894, 895, 896, 897, 898, 899, 900, 901, 902, 903, 904,});
            #endregion

            if (PlayerInfo.MainJob == 9)
                BSTGetJA();
            else
            {
                for (uint i = 528; i <= 2227; i++)
                {
                    if (PlayerInfo.HasAbility(i))
                    {
                        var ability = api.Resources.GetAbility(i);

                        if (i >= 1024 && PlayerInfo.MainJob != 23) continue;
                        else if (i >= 1024 && PlayerInfo.MainJob == 23)
                        {
                            playerJA.Items.Add(ability.Name);
                            continue;
                        }
                        else if (!abilitylist.Contains(ability.ID)) continue;
                        else if (i == 735)
                        {
                            var job = 0;
                            if (PlayerInfo.MainJob == 20) job = PlayerInfo.MainJobLevel;
                            if (PlayerInfo.SubJob == 20) job = PlayerInfo.SubJobLevel;
                            if (!playerJA.Items.Contains("Addendum: White") && job >= 10) playerJA.Items.Add("Addendum: White");
                            if (!playerJA.Items.Contains("Penury") && job >= 10) playerJA.Items.Add("Penury");
                            if (!playerJA.Items.Contains("Celerity") && job >= 25) playerJA.Items.Add("Celerity");
                            if (!playerJA.Items.Contains("Accession") && job >= 40) playerJA.Items.Add("Accession");
                            if (!playerJA.Items.Contains("Rapture") && job >= 55) playerJA.Items.Add("Rapture");
                            if (!playerJA.Items.Contains("Altruism") && job >= 75) playerJA.Items.Add("Altruism");
                            if (!playerJA.Items.Contains("Tranquility") && job >= 75) playerJA.Items.Add("Tranquility");
                            if (!playerJA.Items.Contains("Perpetuance") && job >= 87) playerJA.Items.Add("Perpetuance");
                            if (!playerJA.Items.Contains("Parsimony") && job >= 10) playerJA.Items.Add("Parsimony");
                            if (!playerJA.Items.Contains("Alacrity") && job >= 25) playerJA.Items.Add("Alacrity");
                            if (!playerJA.Items.Contains("Addendum: Black") && job >= 30) playerJA.Items.Add("Addendum: Black");
                            if (!playerJA.Items.Contains("Manifestation") && job >= 40) playerJA.Items.Add("Manifestation");
                            if (!playerJA.Items.Contains("Ebullience") && job >= 55) playerJA.Items.Add("Ebullience");
                            if (!playerJA.Items.Contains("Focalization") && job >= 75) playerJA.Items.Add("Focalization");
                            if (!playerJA.Items.Contains("Equanimity") && job >= 75) playerJA.Items.Add("Equanimity");
                            if (!playerJA.Items.Contains("Immanence") && job >= 87) playerJA.Items.Add("Immanence");
                        }
                        else if (i == 670)
                        {
                            var job = 0;
                            if (PlayerInfo.MainJob == 7) job = PlayerInfo.MainJobLevel;
                            if (PlayerInfo.SubJob == 7) job = PlayerInfo.SubJobLevel;
                            if (!playerJA.Items.Contains("Chivalry TP > 1000") && job >= 75) playerJA.Items.Add("Chivalry TP > 1000");
                            if (!playerJA.Items.Contains("Chivalry TP > 2000") && job >= 75) playerJA.Items.Add("Chivalry TP > 2000");
                            if (!playerJA.Items.Contains("Chivalry TP > 3000") && job >= 75) playerJA.Items.Add("Chivalry TP > 3000");
                        }
                        else if (!playerJA.Items.Contains(ability.Name))
                        {
                            playerJA.Items.Add(ability.Name);
                        }
                    }
                }
                if (playerJA.Items.Contains("Sharpshot") && playerJA.Items.Contains("Barrage")) playerJA.Items.Add("Sharpshot + Barrage");
                if (PlayerInfo.MainJob != 20 && PlayerInfo.SubJob != 20) bgw_script_sch.CancelAsync();
                else bgw_script_sch.RunWorkerAsync();
            }
        }

        private void ClearJA_Click(object sender, EventArgs e)
        {
            playerJA.Items.Clear();
            PetReady.Items.Clear();
            PetJA.Items.Clear();
            WyvernJA.Items.Clear();

            label20.Text = "Pets Name:";
            label21.Text = @"Pet ID:";
            label22.Text = @"Pets HP%:";
            label23.Text = @"Pets TP%:";
        }

        private void LoadMA_Click(object sender, EventArgs e)
        {
            if (playerMA.Items.Count > 0)
                playerMA.Items.Clear();

            #region Skip MA List
            List<uint> skipSpellList = new List<uint>(new uint[] {12, 13, 81, 82, 83, 120, 121, 122, 123, 124, 136, 137, 138, 139, 140, 241, 260, 261, 262,
            263, 264, 265, 494, 512, 514, 516, 518, 520, 523, 525, 526, 528, 546, 550, 552, 553, 556, 558, 559, 562, 566, 568, 571, 580, 583, 586, 590, 600,
            601, 602, 607, 609, 619, 624, 625, 627, 630, 635, 639, 729, 730, 731, 732, 733, 734,735, 754, 755, 756, 757, 758, 759, 760, 761, 762, 763, 764,
            765, 766, 767, 992, 993, 994, 995, 996, 997, 998, 999, 1000, 1001, 1002, 1003, 1017, 1018, 1019, 1020, 1021, 1022, 1023, 7, 8, 9, 10, 11, 308, 309,
            318, 353, 354, 355, 465,
            #region smn
            288, 289, 290, 291, 292, 293, 294, 295, 296, 297, 298, 299, 300, 301, 302, 303, 304, 305, 306, 307, 847,
            #endregion
            #region geo
            769, 787, 788, 789, 790, 791, 792, 793, 794, 795, 796, 797, 798, 799, 800, 801, 802, 803, 804, 805, 806, 807, 808, 809, 810, 811, 812, 813, 814,
            815, 816, 817, 818, 819, 820, 821, 822, 823, 824, 825, 826, 827,
            #endregion
            #region trust
            896, 897, 898, 899, 900, 901, 902, 903, 904, 905, 906, 907, 908, 909, 910, 911, 912, 913, 914, 915, 916, 917, 918, 919, 920, 921, 922, 923,
            924, 925, 926, 927, 928, 929, 930, 931, 932, 933, 934, 935, 936, 937, 938, 939, 940, 941, 942, 943, 944, 945, 946, 947, 948, 949, 950, 951,
            952, 953, 954, 955, 956, 957, 958, 959, 960, 961, 962, 963, 964, 965, 966, 967, 968, 969, 970, 971, 972, 973, 974, 975, 976, 977, 978, 979,
            980, 981, 982, 983, 984, 985, 986, 987, 988, 989, 990, 991, 1004, 1005, 1006, 1007, 1008, 1009, 1010, 1011, 1012, 1013, 1014, 1015, 1016,
            #endregion
            });
            #endregion

            #region load MJ MA(main job)
            for (uint mm = 1; mm <= 895; mm++)
            {
                var spellm = api.Resources.GetSpell(mm);
                if (spellm == null || skipSpellList.Contains(mm)) continue;
                else if (PlayerInfo.HasSpell(mm) &&
                    PlayerInfo.MainJobLevel >= spellm?.RequiredLevel?[PlayerInfo.MainJob] &&
                    spellm?.RequiredLevel?[PlayerInfo.MainJob] != -1 &&
                    !playerMA.Items.Contains(spellm.Name))
                {
                    playerMA.Items.Add(spellm.Name);
                }
            }
            #endregion
            #region load SJ MA(sub job)
            for (uint sm = 1; sm <= 895; sm++)
            {
                var spells = api.Resources.GetSpell(sm);
                if (spells == null) { }
                else if (skipSpellList.Contains(sm)) { }
                else if (PlayerInfo.HasSpell(sm) &&
                        PlayerInfo.SubJobLevel >= spells?.RequiredLevel?[PlayerInfo.SubJob] &&
                        spells?.RequiredLevel?[PlayerInfo.SubJob] != -1 &&
                        !playerMA.Items.Contains(spells.Name))
                {
                    playerMA.Items.Add(spells.Name);
                }
            }
            #endregion
        }

        private void ClearMA_Click(object sender, EventArgs e)
        {
            playerMA.Items.Clear();
        }

        public void CharacterUpdate()
        {
            this.JAtabselect.Controls.Remove(this.WHMpage);
            this.JAtabselect.Controls.Remove(this.RDMpage);
            this.JAtabselect.Controls.Remove(this.SCHpage);
            this.JAtabselect.Controls.Remove(this.RUNpage);
            this.JAtabselect.Controls.Remove(this.MONpage);
            this.JAtabselect.Controls.Remove(this.Dynamispage);
            if (PlayerInfo.MainJob == 3 || PlayerInfo.SubJob == 3) this.JAtabselect.Controls.Add(this.WHMpage);
            if (PlayerInfo.MainJob == 5 || PlayerInfo.SubJob == 5) this.JAtabselect.Controls.Add(this.RDMpage);
            if (PlayerInfo.MainJob == 20 || PlayerInfo.SubJob == 20) this.JAtabselect.Controls.Add(this.SCHpage);
            if (PlayerInfo.MainJob == 22 || PlayerInfo.SubJob == 22) this.JAtabselect.Controls.Add(this.RUNpage);
            if (PlayerInfo.MainJob == 23 || PlayerInfo.SubJob == 23) this.JAtabselect.Controls.Add(this.MONpage);
            this.JAtabselect.Controls.Add(this.Dynamispage);
            List<int> MAjobs = new List<int>(new int[] {3,4,5,7,8,10,13,15,16,20,21,22});
            if (MAjobs.Contains(PlayerInfo.MainJob) || MAjobs.Contains(PlayerInfo.SubJob))
            {
                this.MAtabs.Controls.Remove(this.CureConfigPage);
                this.MAtabs.Controls.Remove(this.DrainAspirpage);
                this.MAtabs.Controls.Remove(this.MAconfigpage);
                this.MAtabs.Controls.Remove(this.BLUCurespage);
                this.CombatSettingsTabs.Controls.Remove(this.OptionsMAMainTab);
                List<int> Curejobs = new List<int>(new int[] {3,5,7,20});
                if  (Curejobs.Contains(PlayerInfo.MainJob) || Curejobs.Contains(PlayerInfo.SubJob)) this.MAtabs.Controls.Add(this.CureConfigPage);
                List<int> Drainjobs = new List<int>(new int[] {4,8,20,21});
                if  (Drainjobs.Contains(PlayerInfo.MainJob) || Drainjobs.Contains(PlayerInfo.SubJob)) this.MAtabs.Controls.Add(this.DrainAspirpage);
                if  (PlayerInfo.MainJob == 16 || PlayerInfo.SubJob == 16) this.MAtabs.Controls.Add(this.BLUCurespage);
                this.MAtabs.Controls.Add(this.MAconfigpage);
                this.CombatSettingsTabs.Controls.Add(this.OptionsMAMainTab);
            }
            else this.CombatSettingsTabs.Controls.Remove(this.OptionsMAMainTab);
            if (PlayerInfo.MainJob == 19 || PlayerInfo.SubJob == 19)
            {
                this.dncControl.Controls.Remove(this.dancer);
                this.dncControl.Controls.Remove(this.flourish);
                this.dncControl.Controls.Add(this.dancer);
                this.dncControl.Controls.Add(this.flourish);
                Dictionary<string, uint> DNCenable = new Dictionary<string, uint>()
                {
                    {"usedrain", 5},{"usecure", 15},{"usecureValue", 15},{"numericUpDown33", 15},{"ptusecure", 15},{"usequickstep", 20},{"usequickstepValue", 20},
                    {"StepsHP", 20},{"StepsHPValue", 20},{"stopstepsathptext", 20},{"NoSteps", 20},{"stopstepsat", 20},{"useaspir", 25},
                    {"useboxstep", 30},{"useboxstepValue", 30},{"usecureii", 30},{"usecureiiValue", 30},{"ptusecureii", 30},{"numericUpDown32", 30},{"usedesflo", 30},
                    {"numericUpDown34", 30},{"usedrainii", 35},{"groupBox7", 35},{"usestutterstep", 40},{"usestutterstepValue", 40},{"userevflo", 40},
                    {"userevfloValue", 40},{"usehaste", 45},{"usecureiii", 45},{"usecureiiiValue", 45},{"ptusecureiii", 45},{"numericUpDown29", 45},{"usebldflo", 50},
                    {"usebldfloValue", 50},{"useaspirii", 60},{"usewldflo", 60},{"usewldfloValue", 60},{"usedrainiii", 65},{"usecureiv", 70},{"usecureivValue", 70},
                    {"ptusecureiv", 70},{"numericUpDown28", 70},{"useclmflo", 80},{"useclmfloValue", 80},{"usefeatherstep", 83},{"usefeatherstepValue", 83},
                    {"usecurev", 87},{"usecurevValue", 87},{"ptusecurev", 87},{"numericUpDown27", 87},{"usestkflo", 89},{"usestkfloValue", 89},{"useterflo", 93},
                    {"useterfloValue", 93},
                };
                foreach (KeyValuePair<string, uint> kvp in DNCenable)
                {
                    Control c = this.Controls.Find(kvp.Key, true).Single();
                    if (c == null) continue;
                    if ((PlayerInfo.MainJob == 19 && kvp.Value <= PlayerInfo.MainJobLevel) ||
                        (PlayerInfo.SubJob == 19 && kvp.Value <= PlayerInfo.SubJobLevel))
                        c.Enabled = true;
                    else c.Enabled = false;
                }
            }
            else
            {
                this.dncControl.Controls.Remove(this.dancer);
                this.dncControl.Controls.Remove(this.flourish);
            }
            List<int> PETjobs = new List<int>(new int[] { 9, 14, 15, 18, 21 });
            if (PETjobs.Contains(PlayerInfo.MainJob) || PETjobs.Contains(PlayerInfo.SubJob))
            {
                this.petControl.Controls.Remove(this.bstpettab);
                this.petControl.Controls.Remove(this.drgpettab);
                this.petControl.Controls.Remove(this.smnpettab);
                this.petControl.Controls.Remove(this.puppettab);
                this.petControl.Controls.Remove(this.geopettab);
                this.dncControl.Controls.Remove(this.pets);
                if (PlayerInfo.MainJob == 9 || PlayerInfo.SubJob == 9) this.petControl.Controls.Add(this.bstpettab);
                if (PlayerInfo.MainJob == 14 || PlayerInfo.SubJob == 14) this.petControl.Controls.Add(this.drgpettab);
                if (PlayerInfo.MainJob == 15 || PlayerInfo.SubJob == 15) this.petControl.Controls.Add(this.smnpettab);
                if (PlayerInfo.MainJob == 18 || PlayerInfo.SubJob == 18) this.petControl.Controls.Add(this.puppettab);
                if (PlayerInfo.MainJob == 21 || PlayerInfo.SubJob == 21) this.petControl.Controls.Add(this.geopettab);
                this.dncControl.Controls.Add(this.pets);
            }
            else this.dncControl.Controls.Remove(this.pets);

            ClearJA_Click(null, null);
            LoadJA_Click(null, null);
            ClearMA_Click(null, null);
            LoadMA_Click(null, null);
        }

        #endregion
        #region Methods: Save/Load Config
        public void saveConfig()
        {
            var members = api.Party.GetPartyMembers().Where(p => p.Active != 0).ToList();

            if (!partyAssist.Checked || members.Count < 2)
                return;
        }

        #region config: save/load (player)
        #endregion
        #region config: save/load (target)
        #endregion
        #region config: save/load (navi)
        #endregion

        #endregion

        #region Methods: Assist (Player/Party)
        public void CheckPartyAssist()
        {
            var members = api.Party.GetPartyMembers().Where(p => p.Active != 0).ToList();

            if (!partyAssist.Checked || members.Count < 2)
                return;
        }

        public void CheckPartyIDs()
        {
            var members = api.Party.GetPartyMembers().Where(p => p.Active != 0).ToList();

            if (partyIDs.Count == members.Count)
                return;

            partyIDs.Clear();
            for (var x = 0; x < members.Count; x++)
            {
                var pID = members.SingleOrDefault(m => m.ID == x);

                if (!partyIDs.Contains((int)pID.ID))
                    partyIDs.Add((int)pID.ID);
            }
        }

        public void CheckPlayerAssist()
        {
            if (!assist.Checked || string.IsNullOrEmpty(assistplayer.Text))
                return;

            var members = api.Party.GetPartyMembers().Where(p => p.Active != 0).ToList();

            if (PlayerInfo.Status == 0)
            {
                var member = members.SingleOrDefault(m => m.Name == assistplayer.Text);
                var assisted = api.Entity.GetEntity((int)member.ID);

                if (assisted.Status == 1 && assisted.Distance <= (float)assistDist.Value)
                {
                    WindowInfo.SendText("/assist " + assistplayer.Text);
                    Thread.Sleep(TimeSpan.FromSeconds(0.5));

                    Thread.Sleep(TimeSpan.FromSeconds(0.3));
                    WindowInfo.SendText("/attack <t>");
                    Thread.Sleep(TimeSpan.FromSeconds(5.0));
                }
            }
        }
        private void AssistCheckedChanged(object sender, EventArgs e)
        {
            assistDist.Enabled = assist.Checked;
        }
        #endregion

        #region Methods: DNC

        #region JA: Curing Waltz

        #region CuringWaltzParty
        #endregion
        #region CuringWaltzSelf
        private void CuringWaltzSelf()
        {
            if (!usecurev.Checked && !usecureiv.Checked && !usecureiii.Checked && !usecureii.Checked && !usecure.Checked &&
               (PlayerInfo.Status != 1 || !botRunning || PlayerInfo.HasBuff(16)))
                return;

            if (usecurev.Checked && TargetInfo.ID > 0 && Recast.GetAbilityRecast(217) == 0 &&
                PlayerInfo.HPP <= usecurevValue.Value && PlayerInfo.TP > 800)
            {
                api.ThirdParty.SendString("/ja \"Curing Waltz V\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
            }
            else if (usecureiv.Checked && TargetInfo.ID > 0 && Recast.GetAbilityRecast(217) == 0 &&
                     PlayerInfo.HPP <= usecureivValue.Value && PlayerInfo.TP > 650)
            {
                api.ThirdParty.SendString("/ja \"Curing Waltz IV\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
            }
            else if (usecureiii.Checked && Recast.GetAbilityRecast(217) == 0 && PlayerInfo.TP > 500 &&
                     PlayerInfo.HPP <= usecureiiiValue.Value && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Curing Waltz III\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
            }
            else if (usecureii.Checked && TargetInfo.ID > 0 && Recast.GetAbilityRecast(217) == 0 &&
                     PlayerInfo.HPP <= usecureiiValue.Value && PlayerInfo.TP > 350)
            {
                api.ThirdParty.SendString("/ja \"Curing Waltz II\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
            }
            else if (usecure.Checked && TargetInfo.ID > 0 && Recast.GetAbilityRecast(217) == 0 &&
                     PlayerInfo.HPP <= usecureValue.Value && PlayerInfo.TP > 200)
            {
                api.ThirdParty.SendString("/ja \"Curing Waltz\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
            }
        }

        #endregion

        #endregion
        #region JA: Healing Waltz
        private void HealingWaltz()
        {
            var hw = (from object itemChecked in HealingWaltzItems.CheckedItems
                      select itemChecked.ToString()).ToList();

            if (hw.Count == 0) return;

            if (Recast.GetAbilityRecast(215) != 0 || PlayerInfo.Status != 1 || !botRunning ||
                PlayerInfo.HasBuff(16) || PlayerInfo.TP < 200)
                return;

            #region CheckBuffs

            if (PlayerInfo.HasBuff(4) && hw.Contains("Paralyze")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(3) && hw.Contains("Poison")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(5) && hw.Contains("Blind")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(11) && hw.Contains("Bind")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(9) && hw.Contains("Curse")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(13) && hw.Contains("Slow")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(6) && hw.Contains("Silence")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(31) && hw.Contains("Plague")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(8) && hw.Contains("Disease")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(30) && hw.Contains("Bane")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(135) && hw.Contains("Bio")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(128) && hw.Contains("Burn")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(130) && hw.Contains("Choke")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(131) && hw.Contains("Rasp")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(133) && hw.Contains("Drown")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(129) && hw.Contains("Frost")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(132) && hw.Contains("Shock")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(134) && hw.Contains("Dia")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(136) && hw.Contains("STR Down")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(137) && hw.Contains("DEX Down")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(138) && hw.Contains("VIT Down")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(139) && hw.Contains("AGI Down")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(141) && hw.Contains("MND Down")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(142) && hw.Contains("CHR Down")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(174) && hw.Contains("MACC Down")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(148) && hw.Contains("EVA Down")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(149) && hw.Contains("DEF Down")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(147) && hw.Contains("ATT Down")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(146) && hw.Contains("ACC Down")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(404) && hw.Contains("MEVA Down")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(175) && hw.Contains("MATT Down")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(167) && hw.Contains("MDEF Down")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(144) && hw.Contains("HP Down")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(145) && hw.Contains("MP Down")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(189) && hw.Contains("TP Down")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(140) && hw.Contains("INT Down")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(186) && hw.Contains("Helix")) { CastHealingWatz(); }
            if (PlayerInfo.HasBuff(12) && hw.Contains("Gravity")) { CastHealingWatz(); }

            #endregion
        }
        private void CastHealingWatz()
        {
            api.ThirdParty.SendString("/ja \"Healing Waltz\" <me>");
            Thread.Sleep(TimeSpan.FromSeconds(2.0));
        }
        private void CheckBox1CheckedChanged(object sender, EventArgs e)
        {
            #region Select/Deselect All (Healing Walz)
            if (checkBox1.Checked)
            {
                for (var i = 0; i < HealingWaltzItems.Items.Count; i++)
                {
                    HealingWaltzItems.SetItemChecked(i, true);
                }
            }
            else
            {
                for (var i = 0; i < HealingWaltzItems.Items.Count; i++)
                {
                    HealingWaltzItems.SetItemChecked(i, false);
                }
            }
            #endregion
        }
        #endregion
        #region JA: Drain/Aspir/Haste Samba
        private void Sambas()
        {
            if (!usedrain.Checked && !usedrainii.Checked && !usedrainiii.Checked && !useaspir.Checked && !useaspirii.Checked && !usehaste.Checked &&
               (PlayerInfo.Status != 1 || !botRunning || PlayerInfo.HasBuff(16) || PlayerInfo.HasBuff(411)))
                return;

            if (usedrain.Checked && (TargetInfo.ID > 0 && TargetInfo.ID != PlayerInfo.ServerID) &&
                !PlayerInfo.HasBuff(368) && Recast.GetAbilityRecast(216) == 0 && PlayerInfo.TP > 100)
            {
                api.ThirdParty.SendString("/ja \"Drain Samba\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
            }
            else if (usedrainii.Checked && (TargetInfo.ID > 0 && TargetInfo.ID != PlayerInfo.ServerID) &&
                     !PlayerInfo.HasBuff(368) && Recast.GetAbilityRecast(216) == 0 && PlayerInfo.TP > 250)
            {
                api.ThirdParty.SendString("/ja \"Drain Samba II\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
            }
            else if (usedrainiii.Checked && (TargetInfo.ID > 0 && TargetInfo.ID != PlayerInfo.ServerID) &&
                     !PlayerInfo.HasBuff(368) && Recast.GetAbilityRecast(216) == 0 && PlayerInfo.TP > 300)
            {
                api.ThirdParty.SendString("/ja \"Drain Samba III\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
            }
            else if (useaspir.Checked && (TargetInfo.ID > 0 && TargetInfo.ID != PlayerInfo.ServerID) &&
                     !PlayerInfo.HasBuff(369) && Recast.GetAbilityRecast(216) == 0 && PlayerInfo.TP > 100)
            {
                api.ThirdParty.SendString("/ja \"Aspir Samba\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
            }
            else if (useaspirii.Checked && (TargetInfo.ID > 0 && TargetInfo.ID != PlayerInfo.ServerID) &&
                     !PlayerInfo.HasBuff(369) && Recast.GetAbilityRecast(216) == 0 && PlayerInfo.TP > 250)
            {
                api.ThirdParty.SendString("/ja \"Aspir Samba II\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
            }
            else if (usehaste.Checked && (TargetInfo.ID > 0 && TargetInfo.ID != PlayerInfo.ServerID) &&
                     !PlayerInfo.HasBuff(370) && Recast.GetAbilityRecast(216) == 0 && PlayerInfo.TP > 350)
            {
                api.ThirdParty.SendString("/ja \"Haste Samba\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
            }
        }
        #endregion
        #region JA: Flourishe (I,II,III)
        private void UseFlourish()
        {
            if (!botRunning || PlayerInfo.Status != 1 || PlayerInfo.HasBuff(16))
                return; ;

            if (MonStagered && staggerstopJA.Checked) return;

            var retVal = 0;

            if (PlayerInfo.HasBuff(381)) { retVal = 1; }
            else if (PlayerInfo.HasBuff(382)) { retVal = 2; }
            else if (PlayerInfo.HasBuff(383)) { retVal = 3; }
            else if (PlayerInfo.HasBuff(384)) { retVal = 4; }
            else if (PlayerInfo.HasBuff(385)) { retVal = 5; }
            else if (PlayerInfo.HasBuff(588)) { retVal = 6; }


            if (PlayerInfo.Status == 1 && (TargetInfo.ID > 0 && TargetInfo.ID != PlayerInfo.ServerID) &&
                Recast.GetAbilityRecast(222) == 0 && Recast.GetAbilityRecast(226) == 0)
            {
                if (!FlourishTP.Checked || (FlourishTP.Checked && PlayerInfo.TP > FlourishTPValue.Value))
                {
                    if (userevflo.Checked && (userevfloValue.Value == retVal || userevfloValue.Value == 7))
                    {
                        api.ThirdParty.SendString("/ja \"Reverse Flourish\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    else if (usebldflo.Checked && (usebldfloValue.Value == retVal || usebldfloValue.Value == 7))
                    {
                        api.ThirdParty.SendString("/ja \"Building Flourish\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    else if (usewldflo.Checked && (usewldfloValue.Value == retVal || usewldfloValue.Value == 7))
                    {
                        api.ThirdParty.SendString("/ja \"Wild Flourish\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    else if (useclmflo.Checked && (useclmfloValue.Value == retVal || useclmfloValue.Value == 7))
                    {
                        api.ThirdParty.SendString("/ja \"Climactic Flourish\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    else if (usestkflo.Checked && (usestkfloValue.Value == retVal || usestkfloValue.Value == 7))
                    {
                        api.ThirdParty.SendString("/ja \"Striking Flourish\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    else if (useterflo.Checked && (useterfloValue.Value == retVal || useterfloValue.Value == 7))
                    {
                        api.ThirdParty.SendString("/ja \"Ternary Flourish\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                }
            }
        }
        #endregion
        #region JA: Steps
        private void Steps()
        {
            if (!usequickstep.Checked && !useboxstep.Checked && !usestutterstep.Checked && !usefeatherstep.Checked &&
               (!botRunning || NoSteps.Checked || PlayerInfo.Status == 0 || Recast.GetAbilityRecast(220) != 0 || PlayerInfo.HasBuff(588) || PlayerInfo.HasBuff(16)))
                return;

            if (StepsHP.Checked && PlayerInfo.HPP < StepsHPValue.Value)
                return;

            if (MonStagered && staggerstopJA.Checked) return;

            var retVal = 0;

            if (PlayerInfo.HasBuff(381)) { retVal = 1; }
            else if (PlayerInfo.HasBuff(382)) { retVal = 2; }
            else if (PlayerInfo.HasBuff(383)) { retVal = 3; }
            else if (PlayerInfo.HasBuff(384)) { retVal = 4; }
            else if (PlayerInfo.HasBuff(385)) { retVal = 5; }
            else if (PlayerInfo.HasBuff(588)) { retVal = 6; }

            if (stopstepsat.Checked && retVal >= stopstepscount.Value) return;

            if (usequickstep.Checked && (TargetInfo.ID > 0 && TargetInfo.ID != PlayerInfo.ServerID) &&
                !PlayerInfo.HasBuff(588) && Recast.GetAbilityRecast(220) == 0)
            {
                api.ThirdParty.SendString("/ja \"Quickstep\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
            }
            else if (useboxstep.Checked && (TargetInfo.ID > 0 && TargetInfo.ID != PlayerInfo.ServerID) &&
                     !PlayerInfo.HasBuff(588) && Recast.GetAbilityRecast(220) == 0)
            {
                api.ThirdParty.SendString("/ja \"Box Step\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
            }
            else if (usestutterstep.Checked && (TargetInfo.ID > 0 && TargetInfo.ID != PlayerInfo.ServerID) &&
                     !PlayerInfo.HasBuff(588) && Recast.GetAbilityRecast(220) == 0)
            {
                api.ThirdParty.SendString("/ja \"Stutter Step\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
            }
            else if (usefeatherstep.Checked && (TargetInfo.ID > 0 && TargetInfo.ID != PlayerInfo.ServerID) &&
                     !PlayerInfo.HasBuff(588) && Recast.GetAbilityRecast(220) == 0)
            {
                api.ThirdParty.SendString("/ja \"Feather Step\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
            }
        }
        #endregion

        #region JA: Job Abilities (use)

        private void PlayerJA()
        {

            if (!botRunning || PlayerInfo.Status != 1 || naviMove || PlayerInfo.HasBuff(16)) return;

            var ja = (from object itemChecked in playerJA.CheckedItems select itemChecked.ToString()).ToList();
            if (ja.Count == 0) return;
            if (MonStagered && staggerstopJA.Checked) return;

            Dictionary<uint, dynamic> jacontrol = new Dictionary<uint, dynamic>()
            {
                    #region JA 
                    {528, new {}}, {529, new {}}, {530, new {}}, {533, new {}}, {534, new {}}, {535, new {}}, {538, new {}}, {540, new {}}, {543, new {b1=56}},
                    {544, new {b1=68,b2=460}}, {545, new {b1=57}}, {546, new {b1=58}}, {548, new {b1=59}}, {549, new {b1=60}}, {550, new {hp=90}},
                    {551, new {b1=45}}, {552, new {b1=61}}, {553, new {}}, {556, new {}}, {557, new {}}, {558, new {}}, {559, new {b1=74}}, {560, new {b1=62}},
                    {561, new {b1=63}}, {562, new {b1=75}}, {563, new {b1=64}}, {568, new {}}, {569, new {}}, {570, new {}}, {571, new {b1=172}},
                    {572, new {b1=73}}, {574, new {b1=67}}, {575, new {name="Meditate"}}, {576, new {b1=117}}, {577, new {b1=118}}, {578, new {}},
                    {579, new {}}, {580, new {}}, {588, new {b1=87}}, {589, new {}}, {594, new {}}, {595, new {}}, {598, new {b1=115}}, {604, new {}},
                    {605, new {}}, {606, new {b1=164}}, {607, new {b1=165}}, {608, new {}}, {610, new {b1=310,b2=309}}, {611, new {b1=311,b2=309}},
                    {612, new {b1=312,b2=309}}, {613, new {b1=313,b2=309}}, {614, new {b1=314,b2=309}}, {615, new {b1=315,b2=309}}, {616, new {b1=316,b2=309}},
                    {617, new {b1=317,b2=309}}, {618, new {b1=318,b2=309}}, {619, new {b1=319,b2=309}}, {620, new {b1=320,b2=309}}, {621, new {b1=321,b2=309}},
                    {622, new {b1=322,b2=309}}, {623, new {b1=323,b2=309}}, {624, new {b1=324,b2=309}}, {625, new {b1=325,b2=309}}, {626, new {b1=326,b2=309}},
                    {627, new {b1=327,b2=309}}, {628, new {b1=328,b2=309}}, {629, new {b1=329,b2=309}}, {630, new {b1=330,b2=309}}, {631, new {b1=331,b2=309}},
                    {632, new {b1=332,b2=309}}, {633, new {b1=333,b2=309}}, {634, new {b1=334,b2=309}}, {635, new {b3=308}},{637, new {item="Fire Card"}},
                    {638, new {item="Ice Card"}},{639, new {item="Wind Card"}},{640, new {item="Earth Card"}},{641, new {item="Thunder Card"}},
                    {642, new {item="Water Card"}},{643, new {item="Light Card"}},{644, new {item="Dark Card"}},{645, new {}}, {661, new {b1=340,b2=490}},
                    {662, new {}}, {663, new {b1=19}}, {664, new {b1=341}}, {667, new {b1=342}}, {668, new {b1=343}},{669, new {b1=344}}, {672, new {b1=346}},
                    {673, new {}}, {677, new {b1=350}}, {678, new {b1=351}}, {680, new {}}, {682, new {}},{683, new {b1=352}}, {685, new {b1=353}},
                    {686, new {b1=354}}, {689, new {b1=357}}, {690, new {b3=309}}, {693, new {b1=376}},{708, new {b1=71}}, {736, new {b1=371}}, {738, new {b1=405}},
                    {739, new {b1=406}}, {740, new {}}, {749, new {b1=410}}, {750, new {b1=411}},{757, new {b1=417}}, {758, new {b1=418}}, {759, new {b1=419}},
                    {760, new {b1=420}}, {761, new {nuff1=421}}, {764, new {b1=435}},{765, new {b1=436}}, {769, new {b1=433}}, {772, new {}}, {773, new {b1=442}},
                    {777, new {}}, {779, new {b1=460,b2=68}}, {781, new {b1=461}},{783, new {b1=477}}, {784, new {}}, {788, new {b1=462}}, {789, new {}},
                    {790, new {b1=478}}, {791, new {}}, {792, new {b1=479}}, {797, new {}},{798, new {b1=482}}, {799, new {b1=465}}, {803, new {b1=484}},
                    {804, new {}}, {805, new {}}, {813, new {b1=467}}, {814, new {b1=335,b2=309}},{815, new {b1=336,b2=309}}, {816, new {b1=337,b2=309}},
                    {817, new {b1=338,b2=309}}, {833, new {thp=10}}, {835, new {b1=490,b2=340}},{836, new {b1=491}}, {837, new {b1=492}}, {840, new {}},
                    {841, new {}}, {842, new {b1=497}}, {845, new {b1=500}}, {846, new {b1=501}},{847, new {b1=502}}, {848, new {b1=503}}, {851, new {}},
                    {853, new {b1=507}}, {856, new {}}, {868, new {}}, {870, new {b1=523}},{871, new {b1=524}}, {872, new {b1=525}}, {873, new {b1=526}},
                    {874, new {b1=527}}, {875, new {b1=528}}, {876, new {b1=529}},{877, new {b1=530}}, {878, new {b1=531}}, {879, new {b1=532}}, {880, new {}},
                    {881, new {b1=533}}, {883, new {b1=535}}, {884, new {}},{895, new {}}, {885, new {b1=537}}, {886, new {b1=538}}, {887, new {}},
                    {888, new {b1=570}}, {890, new {}}, {901, new {b1=599}},{902, new {b1=339,b2=309}}, {903, new {b1=600,b2=309}}, {904, new {b1=601}},
                    #endregion
                    #region monJA control
                    {1247, new {hp=75}}, {1818, new {hp=75}}, {1825, new {hp=75}},{1850, new {hp=75}}, {1856, new {hp=75}}, {1929, new {hp=75}}, {2059, new {hp=75}},
                    {2088, new {mp=75}}, {2090, new {hp=75}}, {2113, new {hp=75}}, {2114, new {hp=75}},
                    #endregion
            };

            foreach (string J in ja)
            {
                var useAbility = false;
                var ability = api.Resources.GetAbility(J);
                var targ = ((ability.ValidTargets & (1 << 0)) != 0 ? "<me>" : "<t>");
                if (ability == null)
                {
                    if (ability.Name == "Chivalry TP > 1000" && !PlayerInfo.HasBuff(16) &&
                        PlayerInfo.TP >= 1000 && Recast.GetAbilityRecast(79) == 0 &&
                        PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                    {
                        api.ThirdParty.SendString("/ja \"Chivalry\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    else if (ability.Name == "Chivalry TP > 2000" && !PlayerInfo.HasBuff(16) &&
                        PlayerInfo.TP >= 2000 && Recast.GetAbilityRecast(79) == 0 &&
                        PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                    {
                        api.ThirdParty.SendString("/ja \"Chivalry\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    else if (ability.Name == "Chivalry TP > 3000" && !PlayerInfo.HasBuff(16) &&
                        PlayerInfo.TP >= 3000 && Recast.GetAbilityRecast(79) == 0 &&
                        PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                    {
                        api.ThirdParty.SendString("/ja \"Chivalry\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    else if (ability.Name == "Sharpshot + Barrage" && !PlayerInfo.HasBuff(16) &&
                        !PlayerInfo.HasBuff(73) && Recast.GetAbilityRecast(125) == 0 &&
                        !PlayerInfo.HasBuff(72) && Recast.GetAbilityRecast(124) == 0 &&
                        PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                    {
                        api.ThirdParty.SendString("/ja \"Sharpshot\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        api.ThirdParty.SendString("/ja \"Barrage\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                }
                else if (ability.ID >= 1024 && PlayerInfo.MainJob == 23)
                {
                    if (!PlayerInfo.HasBuff(16) && Recast.GetAbilityRecast(ability.TimerID) == 0 &&
                         PlayerInfo.Status == 1 && TargetInfo.ID > 0 && ability.TP <= PlayerInfo.TP)
                    {
                        if (jacontrol[ability.ID].ToString().Contains("mp"))
                        {
                            if (PlayerInfo.MPP <= MONmpCount.Value) useAbility = true;
                        }
                        else if (jacontrol[ability.ID].ToString().Contains("hp"))
                        {
                            if (PlayerInfo.HPP <= MONhpCount.Value) useAbility = true;
                        }
                        else useAbility = true;
                    }
                }
                else if (!jacontrol.ContainsKey(ability.ID)) continue;
                else if (!PlayerInfo.HasBuff(16) && Recast.GetAbilityRecast(ability.TimerID) == 0 &&
                         PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                {
                    if (ability.Name == "Benediction" && PlayerInfo.HPP <= BenedictionHPPuse.Value) useAbility = true;
                    else if (ability.Name == "Convert")
                    {
                        if (ConvertHP.Checked && ConvertHPP.Value >= PlayerInfo.HPP && ConvertMPP.Value <= PlayerInfo.MPP) useAbility = true;
                        else if (ConvertMP.Checked && ConvertHPP.Value <= PlayerInfo.HPP && ConvertMPP.Value >= PlayerInfo.MPP) useAbility = true;
                    }
                    else if (ability.Name == "Sublimation")
                    {
                        if (!PlayerInfo.HasBuff(187) && !PlayerInfo.HasBuff(188)) useAbility = true;
                        else if (PlayerInfo.HasBuff(188) && PlayerInfo.HPP <= Sublimationcount.Value) useAbility = true;
                    }
                    else if (ability.Name == "Vivacious Pulse" && PlayerInfo.HPP <= VivaciousPulseHP.Value && Recast.GetAbilityRecast(242) == 0) useAbility = true;
                    else if (ability.Name == "Shikikoyo" && !PlayerInfo.HasBuff(16) && Recast.GetAbilityRecast(136) == 0) useAbility = true;
                    else if (jacontrol[ability.ID].ToString().Contains("item ="))
                    {
                        if (ItemQuantityByName(jacontrol[ability.ID].item) > 0 || ItemQuantityByName("Trump Card") > 0) useAbility = true;
                    }
                    else if (jacontrol[ability.ID].ToString().Contains("b2 ="))
                    {
                        if (!PlayerInfo.HasBuff((short)jacontrol[ability.ID].b1) && !PlayerInfo.HasBuff((short)jacontrol[ability.ID].b2)) useAbility = true;
                    }
                    else if (jacontrol[ability.ID].ToString().Contains("b1 ="))
                    {
                        if (!PlayerInfo.HasBuff((short)jacontrol[ability.ID].b1)) useAbility = true;
                    }
                    else if (jacontrol[ability.ID].ToString().Contains("b3 ="))
                    {
                        if (!PlayerInfo.HasBuff((short)jacontrol[ability.ID].b3)) useAbility = true;
                    }
                    else if (jacontrol[ability.ID].ToString().Contains("hp ="))
                    {
                        if (PlayerInfo.HPP <= jacontrol[ability.ID].hp) useAbility = true;
                    }
                    else if (jacontrol[ability.ID].ToString().Contains("thp ="))
                    {
                        if (TargetInfo.HPP <= jacontrol[ability.ID].thp) useAbility = true;
                    }
                    else useAbility = true;
                }
                if (useAbility)
                {
                    var JAType = "/ja";
                    if (ability.ID >= 1024) JAType = "/ms";
                    api.ThirdParty.SendString(String.Format("{0} \"{1}\" {2}", JAType, ability.Name, targ));
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
        }

        #region JA: NIN (shadows)
        private void ninjaShadows()
        {
            if (!useshadows.Checked)
                return;

            #region Check Items
            if (ItemQuantityByName("Shihei") == 0 || ItemQuantityByName("Shikanofuda") == 0)
            {
                if (ItemQuantityByName("Toolbag (Shihe)") > 0)
                {
                    api.ThirdParty.SendString("/item \"Toolbag (Shihe)\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(3.0));
                }
                else if (ItemQuantityByName("Toolbag (Shikanofuda)") > 0)
                {
                    api.ThirdParty.SendString("/item \"Toolbag (Shikanofuda)\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(3.0));
                }
            }
            #endregion

            if (PlayerInfo.HasBuff(66) || !PlayerInfo.HasBuff(16))
            {
                if (Recast.GetAbilityRecast(340) == 0)
                {
                    api.ThirdParty.SendString("/ma \"Utsusemi: San\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(3.0));
                }
                else if (Recast.GetAbilityRecast(339) == 0 &&
                         !PlayerInfo.HasBuff(446))
                {
                    api.ThirdParty.SendString("/ma \"Utsusemi: Ni\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(3.0));
                }
                else if (Recast.GetAbilityRecast(338) == 0 &&
                         !PlayerInfo.HasBuff(444) &&
                         !PlayerInfo.HasBuff(445))
                {
                    api.ThirdParty.SendString("/ma \"Utsusemi: Ichi\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(2.0));

                    api.ThirdParty.SendString("// cancel 66");
                    Thread.Sleep(TimeSpan.FromSeconds(3.0));
                }
            }
        }
        #endregion

        #endregion

        #region JA: Magic (use)
        private void PlayerMA()
        {
            var ma = (from object itemChecked in playerMA.CheckedItems select itemChecked.ToString()).ToList();
            if (ma.Count == 0) return;
            Dictionary<uint, dynamic> macontrol = new Dictionary<uint, dynamic>()
            {
                {14, new {H=3}},{15, new {H=4}},{16, new {H=5}},{17, new {H=6}},{18, new {H=7}},{19, new {H=8}},{20, new {H=9}},
                {53, new {B=36}},{54, new {B=37}},{55, new {B=39}},{57, new {B=33}},{60, new {B=100}},{61, new {B=101}},{62, new {B=102}},
                {63, new {B=103}},{64, new {B=104}},{65, new {B=105}},{66, new {B=100}},{67, new {B=101}},{68, new {B=102}},{69, new {B=103}},
                {70, new {B=104}},{71, new {B=105}},{72, new {B=106}},{73, new {B=107}},{74, new {B=108}},{75, new {B=109}},{76, new {B=110}},
                {77, new {B=111}},{78, new {B=112}},{84, new {B=286}},{85, new {B=286}},{86, new {B=106}},{87, new {B=107}},{88, new {B=108}},
                {89, new {B=109}},{90, new {B=110}},{91, new {B=111}},{92, new {B=112}},{96, new {B=275}},{97, new {B=403}},{99, new {W=8}},
                {100, new {B=94}},{101, new {B=95}},{102, new {B=96}},{103, new {B=97}},{104, new {B=98}},{105, new {B=99}},{106, new {B=116}},
                {107, new {B=116}},{113, new {W=6}},{114, new {W=10}},{115, new {W=4}},{116, new {W=12}},{117, new {W=14}},
                {118, new {W=18}},{119, new {W=16}},{242, new {B=90}},{249, new {B=34}},{250, new {B=35}},{251, new {B=38}},
                {266, new {B=119}},{267, new {B=120}},{268, new {B=121}},{269, new {B=122}},{270, new {B=123}},{271, new {B=124}},
                {272, new {B=125}},{277, new {B=173}},{287, new {B=407}},{310, new {B=274}},{311, new {B=288}},{312, new {B=277}},
                {313, new {B=278}},{314, new {B=279}},{315, new {B=280}},{316, new {B=281}},{317, new {B=282}},{358, new {B=33}},
                {378, new {B=195}},{379, new {B=195}},{380, new {B=195}},{381, new {B=195}},{382, new {B=195}},{383, new {B=195}},
                {384, new {B=195}},{385, new {B=195}},{386, new {B=196}},{387, new {B=196}},{388, new {B=196}},{389, new {B=197}},
                {390, new {B=197}},{391, new {B=197}},{392, new {B=197}},{393, new {B=197}},{394, new {B=198}},{395, new {B=198}},
                {396, new {B=198}},{397, new {B=198}},{398, new {B=198}},{399, new {B=199}},{400, new {B=199}},{401, new {B=200}},
                {402, new {B=200}},{403, new {B=201}},{404, new {B=201}},{405, new {B=202}},{406, new {B=203}},{407, new {B=204}},
                {408, new {B=205}},{409, new {B=206}},{410, new {B=206}},{411, new {B=206}},{412, new {B=207}},{413, new {B=208}},
                {414, new {B=209}},{415, new {B=210}},{416, new {B=211}},{417, new {B=212}},{418, new {B=213}},{419, new {B=214}},
                {420, new {B=214}},{423, new {B=194}},{424, new {B=215}},{425, new {B=215}},{426, new {B=215}},{427, new {B=215}},
                {428, new {B=215}},{429, new {B=215}},{430, new {B=215}},{431, new {B=215}},{432, new {B=215}},{433, new {B=215}},
                {434, new {B=215}},{435, new {B=215}},{436, new {B=215}},{437, new {B=215}},{438, new {B=216}},{439, new {B=216}},
                {440, new {B=216}},{441, new {B=216}},{442, new {B=216}},{443, new {B=216}},{444, new {B=216}},{445, new {B=216}},
                {446, new {B=216}},{447, new {B=216}},{448, new {B=216}},{449, new {B=216}},{450, new {B=216}},{451, new {B=216}},
                {452, new {B=216}},{453, new {B=216}},{464, new {B=218}},{468, new {B=220}},{469, new {B=221}},{470, new {B=222}},
                {476, new {B=289}},{478, new {B=228}},{479, new {B=119}},{480, new {B=120}},{481, new {B=121}},{482, new {B=122}},
                {483, new {B=123}},{484, new {B=124}},{485, new {B=125}},{486, new {B=119}},{487, new {B=120}},{488, new {B=121}},
                {489, new {B=122}},{490, new {B=123}},{491, new {B=124}},{492, new {B=125}},{493, new {B=432}},{495, new {B=170}},
                {505, new {B=289}},{506, new {B=291}},{507, new {B=290}},{509, new {B=227}},{510, new {B=471}},{511, new {B=33}},
                {517, new {B=37}},{530, new {B=33}},{538, new {B=190}},{547, new {B=93}},{613, new {B=93}},{615, new {B=38}},
                {636, new {B=90,b=92}},{655, new {B=91}},{662, new {B=43}},{668, new {B=152}},{679, new {B=36}},{696, new {B=486}},
                {737, new {B=93}},{750, new {B=604}},{840, new {B=568}},{845, new {B=581}},{846, new {B=581}},{855, new {B=274}},
                {856, new {B=288}},{857, new {B=9}},{858, new {B=7}},{859, new {B=11}},{860, new {B=5}},{861, new {B=13}},{862, new {B=15}},
                {863, new {B=19}},{864, new {B=17}},{879, new {B=597}},{895, new {B=432}},{768, new {I=0,B=539}},{769, new {I=0}},
                {770, new {I=0,B=541}},{771, new {I=0,B=580}},{772, new {I=0,B=542}},{773, new {I=0,B=543}},{774, new {I=0,B=544}},
                {775, new {I=0,B=545}},{776, new {I=0,B=546}},{777, new {I=0,B=547}},{778, new {I=0,B=548}},{779, new {I=0,B=549}},
                {780, new {I=0,B=550}},{781, new {I=0,B=551}},{782, new {I=0,B=552}},{783, new {I=0,B=553}},{784, new {I=0,B=554}},
                {785, new {I=0,B=555}},{786, new {I=0,B=556}},{787, new {I=0}},{788, new {I=0}},{789, new {I=0}},{790, new {I=0}},
                {791, new {I=0}},{792, new {I=0}},{793, new {I=0}},{794, new {I=0}},{795, new {I=0}},{796, new {I=0}},{797, new {I=0}},
                };
            
            if (MAreverse.Checked) ma.Reverse();
            foreach (string M in ma)
            {
                if (PlayerInfo.Status != 1) break;
                bool castSpell = false;
                var magic = api.Resources.GetSpell(M);
                var targ = ((magic.ValidTargets & (1 << 0)) != 0 ? "<me>" : "<t>");
                if (!MAautoJA(magic.Name) || PlayerInfo.HasBuff(6)) continue;
                if (PlayerInfo.MP < magic.MP && (!PlayerInfo.HasBuff(47) || !PlayerInfo.HasBuff(229))) continue;
                List<string> Handledspells = new List<string>(new string[] {"Protect","Protect II","Protect III","Protect IV","Protect V","Protectra",
                "Protectra II","Protectra III","Protectra IV","Protectra V","Shell","Shell II","Shell III","Shell IV","Shell V","Shellra","Shellra II",
                "Shellra III","Shellra IV","Shellra V","Regen","Regen II","Regen III","Regen IV","Regen V","Refresh","Refresh II","Refresh III","Reraise",
                "Reraise II","Reraise III","Reraise IV","Cure","Cure II","Cure III","Cure IV","Cure V","Cure VI","Cura","Cura II","Cura III","Full Cure",
                "Drain","Drain II","Drain III","Aspir","Aspir II","Aspir III","Pollen","Magic Fruit","Healing Breeze","Plenilune Embrace","White Wind",
                "Restoral","Exuviation","Wild Carrot"});
                if (Handledspells.Contains(magic.Name))
                { 
                    if (magic.Name.Contains("Protect") && !PlayerInfo.HasBuff(40) && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name.Contains("Shell") && !PlayerInfo.HasBuff(41) && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name.Contains("Regen") && !PlayerInfo.HasBuff(42) && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name.Contains("Refresh") && !PlayerInfo.HasBuff(43) && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name.Contains("Reraise") && !PlayerInfo.HasBuff(113) && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name == "Cure" && Curecount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name == "Cure II" && CureIIcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name == "Cure III" && CureIIIcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name == "Cure IV" && CureIVcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name == "Cure V" && CureVcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name == "Cure VI" && CureVIcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name == "Cura" && Curacount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name == "Cura II" && CuraIIcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name == "Cura III" && CuraIIIcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name == "Full Cure" && FullCurecount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name == "Drain" && DrainIcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name == "Drain II" && DrainIIcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name == "Drain III" && DrainIIIcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name == "Aspir" && AspirIcount.Value >= PlayerInfo.MPP && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name == "Aspir II" && AspirIIcount.Value >= PlayerInfo.MPP && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name == "Aspir III" && AspirIIIcount.Value >= PlayerInfo.MPP && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name == "Pollen" && Pollencount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name == "Magic Fruit" && MagicFruitcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name == "Healing Breeze" && HealingBreezecount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name == "Plenilune Embrace" && PleniluneEmbracecount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name == "White Wind" && WhiteWindcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name == "Restoral" && Restoralcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name == "Exuviation" && Exuviationcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    else if (magic.Name == "Wild Carrot" && WildCarrotcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                }
                else
                {
                    if (macontrol.ContainsKey(magic.ID))
                    {
                        if (macontrol[magic.ID].ToString().Contains("I =") && Recast.GetSpellRecast(magic.Recast) == 0)
                        {
                            if (!macontrol[magic.ID].ToString().Contains("B =")) continue;
                            else if (!PlayerInfo.HasBuff((short)macontrol[magic.ID].B)) castSpell = true;
                        }
                        else if (macontrol[magic.ID].ToString().Contains("b =") && Recast.GetSpellRecast(magic.Recast) == 0)
                        {
                            if (!PlayerInfo.HasBuff((short)macontrol[magic.ID].B) && !PlayerInfo.HasBuff((short)macontrol[magic.ID].b)) castSpell = true;
                        }
                        else if (macontrol[magic.ID].ToString().Contains("H =") && Recast.GetSpellRecast(magic.Recast) == 0)
                        {
                            if (PlayerInfo.HasBuff((short)macontrol[magic.ID].H)) castSpell = true;
                        }
                        else if (macontrol[magic.ID].ToString().Contains("B =") && Recast.GetSpellRecast(magic.Recast) == 0)
                        {
                            if (!PlayerInfo.HasBuff((short)macontrol[magic.ID].B)) castSpell = true;
                        }
                        else if (macontrol[magic.ID].ToString().Contains("W =") && Recast.GetSpellRecast(magic.Recast) == 0)
                        {
                            if (macontrol[magic.ID].W == api.Weather.CurrentWeather) castSpell = true;
                        }
                    }
                    else
                    {
                        if (Recast.GetSpellRecast(magic.Recast) == 0) castSpell = true;
                    }
                }
                if (castSpell)
                {
                    api.ThirdParty.SendString(String.Format("/ma \"{0}\" {1}", magic.Name, targ));
                    Casting();
                }
            }
        }
        
        private bool MAautoJA(string M)
        {
            var ja = (from object itemChecked in playerJA.CheckedItems select itemChecked.ToString()).ToList();
            var magic = api.Resources.GetSpell(M);
            #region BLK MAJA
            if (PlayerInfo.MP < magic.MP && !PlayerInfo.HasBuff(47) && !PlayerInfo.HasBuff(229))
            {
                if (ja.Contains("Manafont") && Recast.GetAbilityRecast(0) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Manafont\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                else if (ja.Contains("Manawell") && Recast.GetAbilityRecast(35) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Manawell\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                else return false;
            }
            if (ja.Contains("Elemental Seal") && !PlayerInfo.HasBuff(79) && Recast.GetAbilityRecast(38) == 0)
            {
                api.ThirdParty.SendString("/ja \"Elemental Seal\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Cascade") && !PlayerInfo.HasBuff(598) && magic.Skill == 36 && Recast.GetAbilityRecast(12) == 0)
            {
                api.ThirdParty.SendString("/ja \"Cascade\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Subtle Sorcery") && !PlayerInfo.HasBuff(493) && magic.Skill == 36 && Recast.GetAbilityRecast(254) == 0)
            {
                api.ThirdParty.SendString("/ja \"Subtle Sorcery\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region WHM MAJA
            List<string> DivineSealList = new List<string>(new string[] {"Cure", "Cure II", "Cure III", "Cure IV", "Cure V", "Cure VI", "Full Cure", "Pollen",
            "Healing Breeze", "Wild Carrot", "Magic Fruit", "Exuviation", "Plenilune Embrace", "White Wind", "Restoral", "Poisona", "Paralyna", "Blindna",
            "Silena", "Cursna", "Stona", "Erase", "Cura", "Cura II", "Cura III"});
            
            if (DivineSealList.Contains(magic.Name) && ja.Contains("Divine Seal") && !PlayerInfo.HasBuff(78))
            {
                if (Recast.GetAbilityRecast(26) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Divine Seal\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            List<string> DivineCaressList = new List<string>(new string[] {"Poisona", "Paralyna", "Blindna", "Silena", "Cursna", "Stona"});
            
            if (DivineCaressList.Contains(magic.Name) && ja.Contains("Divine Caress") && !PlayerInfo.HasBuff(453))
            {
                if (Recast.GetAbilityRecast(32) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Divine Caress\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region RDM MAJA
            if (ja.Contains("Chainspell") && !PlayerInfo.HasBuff(48) && Recast.GetAbilityRecast(0) == 0)
            {
                api.ThirdParty.SendString("/ja \"Chainspell\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Saboteur") && !PlayerInfo.HasBuff(454) && magic.Skill == 35 && Recast.GetAbilityRecast(36) == 0)
            {
                api.ThirdParty.SendString("/ja \"Saboteur\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Spontaneity") && !PlayerInfo.HasBuff(230) && !PlayerInfo.HasBuff(48) && Recast.GetAbilityRecast(37) == 0)
            {
                api.ThirdParty.SendString("/ja \"Spontaneity\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Stymie") && !PlayerInfo.HasBuff(494) && magic.Skill == 35 && Recast.GetAbilityRecast(254) == 0)
            {
                api.ThirdParty.SendString("/ja \"Stymie\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region PLD MAJA
            if (ja.Contains("Divine Emblem") && !PlayerInfo.HasBuff(438) && magic.Skill == 32 && Recast.GetAbilityRecast(80) == 0)
            {
                api.ThirdParty.SendString("/ja \"Divine Emblem\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region DRK MAJA
            if (ja.Contains("Dark Seal") && !PlayerInfo.HasBuff(345) && magic.Skill == 37 && Recast.GetAbilityRecast(89) == 0)
            {
                api.ThirdParty.SendString("/ja \"Dark Seal\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            List<string> NetherVoidList = new List<string>(new string[] {"Absorb-MND", "Absorb-CHR", "Absorb-VIT", "Absorb-AGI", "Absorb-INT", "Absorb-DEX",
            "Absorb-STR", "Absorb-TP", "Absorb-ACC", "Absorb-Attri", "Drain", "Drain II", "Aspir", "Aspir II"});
            if (NetherVoidList.Contains(magic.Name) && ja.Contains("Nether Void") && !PlayerInfo.HasBuff(439) && Recast.GetAbilityRecast(91) == 0)
            {
                api.ThirdParty.SendString("/ja \"Nether Void\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region NIN MAJA
            List<string> FutaeList = new List<string>(new string[] {"Katon", "Hyoton", "Huton", "Doton", "Raiton", "Suiton", "Kurayami", "Hojo"});
            if (FutaeList.Contains(Regex.Replace(magic.Name, ":.*", "")) && ja.Contains("Futae") &&
            !PlayerInfo.HasBuff(441) && Recast.GetAbilityRecast(148) == 0)
            {
                api.ThirdParty.SendString("/ja \"Futae\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region BLU MAJA
            List<string> UnbridledLearningList = new List<string>(new string[] {"Harden Shell", "Thunderbolt", "Absolute Terror", "Gates of Hades", "Tourbillion",
            "Pyric Bulwark", "Bilgestorm", "Bloodrake", "Droning Whirlwind", "Carcharian Verve", "Blistering Roar", "Mighty Guard", "Cruel Joke", "Cesspool",
            "Tearing Gust"});
            if (UnbridledLearningList.Contains(magic.Name) && !PlayerInfo.HasBuff(485) && !PlayerInfo.HasBuff(505))
            {
                if (ja.Contains("Unbridled Learning") && Recast.GetAbilityRecast(81) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Unbridled Learning\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                else if (ja.Contains("Unbridled Wisdom") && Recast.GetAbilityRecast(254) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Unbridled Wisdom\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region BRD MAJA
            if (magic.Skill == 41 || magic.Skill == 42)
            {
                if (ja.Contains("Soul Voice") && !PlayerInfo.HasBuff(52) && Recast.GetAbilityRecast(0) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Soul Voice\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Pianissimo") && !PlayerInfo.HasBuff(409) && Recast.GetAbilityRecast(112) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Pianissimo\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Nightingale") && !PlayerInfo.HasBuff(347) && Recast.GetAbilityRecast(109) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Nightingale\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Troubadour") && !PlayerInfo.HasBuff(348) && Recast.GetAbilityRecast(110) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Troubadour\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Tenuto") && !PlayerInfo.HasBuff(455) && Recast.GetAbilityRecast(47) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Tenuto\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Marcato") && !PlayerInfo.HasBuff(231) && Recast.GetAbilityRecast(48) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Marcato\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Clarion Call") && !PlayerInfo.HasBuff(499) && Recast.GetAbilityRecast(254) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Clarion Call\" <me>");
                }
            }
            #endregion
            #region SCH MAJA
            if (PlayerInfo.MainJob == 20 || PlayerInfo.SubJob == 20)
            {
                List<string> TabulaRasa = new List<string>(new string[] {"Embrava", "Kaustra"});
                List<string> AddendumWhite = new List<string>(new string[] {"Poisona","Paralyna","Blindna","Silena","Cursna","Reraise","Erase","Viruna","Stona",
                "Raise II","Reraise II","Raise III","Reraise III"});
                List<string> AddendumBlack = new List<string>(new string[] {"Sleep","Dispel","Sleep II","Stone IV","Water IV","Aero IV","Fire IV","Blizzard IV",
                "Thunder IV","Stone V","Water V","Aero V","Break","Fire V","Blizzard V","Thunder V"});
                if (ja.Contains("Tabula Rasa") && !PlayerInfo.HasBuff(377) && Recast.GetAbilityRecast(0) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Tabula Rasa\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Light Arts") && magic.MagicType == 1 && !PlayerInfo.HasBuff(358) && Recast.GetAbilityRecast(228) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Light Arts\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Dark Arts") && magic.MagicType == 2 && !PlayerInfo.HasBuff(359) && Recast.GetAbilityRecast(228) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Dark Arts\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Enlightenment") && !PlayerInfo.HasBuff(359) && !PlayerInfo.HasBuff(359) &&
                    !PlayerInfo.HasBuff(416) && Recast.GetAbilityRecast(235) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Enlightenment\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                /* if (magic.Name.Contains("helix") && ja.Contains("Modus Veritas") && !PlayerInfo.HasBuff(416) && Recast.GetAbilityRecast(235) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Modus Veritas\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                } */
                if (SchCharges >= 1 || PlayerInfo.HasBuff(377))
                {   
                    if (magic.MagicType == 1 && PlayerInfo.HasBuff(358))
                    {
                        #region SCH White MA Stragems
                        if (SchCharges >= 1 && AddendumWhite.Contains(magic.Name) && ja.Contains("Addendum: White") &&
                            !PlayerInfo.HasBuff(401))
                        {
                            api.ThirdParty.SendString("/ja \"Addendum: White\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        else if (AddendumWhite.Contains(magic.Name)) return false;
                        if (SchCharges >= 1 && ja.Contains("Penury") && !PlayerInfo.HasBuff(360))
                        {
                            api.ThirdParty.SendString("/ja \"Penury\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        if (SchCharges >= 1 && ja.Contains("Celerity") && !PlayerInfo.HasBuff(362))
                        {
                            api.ThirdParty.SendString("/ja \"Celerity\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        if (SchCharges >= 1 && ja.Contains("Accession") && !PlayerInfo.HasBuff(366) &&
                            Recast.GetAbilityRecast(231) == 0 && (magic.Skill == 33 || magic.Skill == 34))
                        {
                            api.ThirdParty.SendString("/ja \"Accession\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        if (SchCharges >= 1 && ja.Contains("Rapture") && !PlayerInfo.HasBuff(364))
                        {
                            api.ThirdParty.SendString("/ja \"Rapture\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        if (SchCharges >= 2 && ja.Contains("Altruism") && !PlayerInfo.HasBuff(412))
                        {
                            api.ThirdParty.SendString("/ja \"Altruism\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 2;
                        }
                        if (SchCharges >= 1 && ja.Contains("Tranquility") && !PlayerInfo.HasBuff(414))
                        {
                            api.ThirdParty.SendString("/ja \"Tranquility\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        if (SchCharges >= 1 && ja.Contains("Perpetuance") && !PlayerInfo.HasBuff(469))
                        {
                            api.ThirdParty.SendString("/ja \"Perpetuance\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        #endregion
                    }
                    else if (magic.MagicType == 2 && PlayerInfo.HasBuff(359))
                    {
                        #region SCH Black MA Stragems
                        if (SchCharges >= 1 && AddendumBlack.Contains(magic.Name) && ja.Contains("Addendum: Black") &&
                            !PlayerInfo.HasBuff(402))
                        {
                            api.ThirdParty.SendString("/ja \"Addendum: Black\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        else if (AddendumBlack.Contains(magic.Name)) return false;
                        if (SchCharges >= 1 && ja.Contains("Parsimony") && !PlayerInfo.HasBuff(361))
                        {
                            api.ThirdParty.SendString("/ja \"Parsimony\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        if (SchCharges >= 1 && ja.Contains("Alacrity") && !PlayerInfo.HasBuff(363))
                        {
                            api.ThirdParty.SendString("/ja \"Alacrity\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        if (SchCharges >= 1 && ja.Contains("Manifestation") && !PlayerInfo.HasBuff(367) &&
                            Recast.GetAbilityRecast(231) == 0 && magic.Skill == 35)
                        {
                            api.ThirdParty.SendString("/ja \"Manifestation\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        if (SchCharges >= 1 && ja.Contains("Ebullience") && !PlayerInfo.HasBuff(365))
                        {
                            api.ThirdParty.SendString("/ja \"Ebullience\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        if (SchCharges >= 1 && ja.Contains("Focalization") && !PlayerInfo.HasBuff(412))
                        {
                            api.ThirdParty.SendString("/ja \"Focalization\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        if (SchCharges >= 1 && ja.Contains("Equanimity") && !PlayerInfo.HasBuff(415))
                        {
                            api.ThirdParty.SendString("/ja \"Equanimity\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        if (SchCharges >= 1 && ja.Contains("Immanence") && !PlayerInfo.HasBuff(470))
                        {
                            api.ThirdParty.SendString("/ja \"Immanence\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        #endregion
                    }
                }
                if (AddendumWhite.Contains(magic.Name) && !PlayerInfo.HasBuff(401) && !PlayerInfo.HasBuff(377)) return false;
                if (AddendumBlack.Contains(magic.Name) && !PlayerInfo.HasBuff(402) && !PlayerInfo.HasBuff(377)) return false;
            }
            #endregion
            #region GEO MAJA
            if (ja.Contains("Bolster") && magic.Skill == 44 && !PlayerInfo.HasBuff(513) &&
                Recast.GetAbilityRecast(0) == 0)
            {
                api.ThirdParty.SendString("/ja \"Bolster\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Collimated Fervor") && !PlayerInfo.HasBuff(517) && Recast.GetAbilityRecast(245) == 0)
            {
                api.ThirdParty.SendString("/ja \"Collimated Fervor\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Theurgic Focus") && magic.Skill == 36 && !PlayerInfo.HasBuff(519) &&
                Recast.GetAbilityRecast(249) == 0)
            {
                api.ThirdParty.SendString("/ja \"Theurgic Focus\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Widened Compass") && magic.Skill == 44 && !PlayerInfo.HasBuff(508) &&
                Recast.GetAbilityRecast(130) == 0)
            {
                api.ThirdParty.SendString("/ja \"Widened Compass\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region RUN MAJA
            if (ja.Contains("Embolden") && magic.Skill == 34 && !PlayerInfo.HasBuff(534) &&
                Recast.GetAbilityRecast(72) == 0)
            {
                api.ThirdParty.SendString("/ja \"Embolden\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
             return true;
        }

        private void Casting()
        {
            isCasting = true;
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
            var count = 0;
            float lastPercent = 0;
            while (api.CastBar.Percent < 100)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.1));
                if (lastPercent != api.CastBar.Percent)
                {
                    count = 0;
                    lastPercent = api.CastBar.Percent;
                }
                else if (count == 10)
                {
                    break;
                }
                else
                {
                    count++;
                    lastPercent = api.CastBar.Percent;
                }
            }
            isCasting = false;
            Thread.Sleep(TimeSpan.FromSeconds(2.0));
        }
        #endregion

        #region WS: WeaponSkill (use)
        private void PlayerWS()
        {
            if (!botRunning || PlayerInfo.Status == 0 || TargetInfo.ID == 0)
                return;

            var wsname = comboBox2.Text;

            if (wsam.Checked && amname.Text != "")
            {

                if (AfterMathTier.Value == 1 && PlayerInfo.TP >= 1000 &&
                   (TargetInfo.HPP >= numericUpDown23.Value &&
                    TargetInfo.HPP <= numericUpDown22.Value) &&
                    PlayerInfo.Status == 1 && TargetInfo.ID > 0 &&
                    !PlayerInfo.HasBuff(270))
                {
                    api.ThirdParty.SendString("/ws \"" + amname.Text + "\" <t>");
                    Thread.Sleep(TimeSpan.FromSeconds(4.0));
                }
                else if (AfterMathTier.Value == 2 && PlayerInfo.TP >= 2000 &&
                        (TargetInfo.HPP >= numericUpDown23.Value &&
                         TargetInfo.HPP <= numericUpDown22.Value) &&
                         PlayerInfo.Status == 1 && TargetInfo.ID > 0 &&
                         !PlayerInfo.HasBuff(271))
                {
                    api.ThirdParty.SendString("/ws \"" + amname.Text + "\" <t>");
                    Thread.Sleep(TimeSpan.FromSeconds(4.0));
                }
                else if (AfterMathTier.Value == 3 && PlayerInfo.TP >= 3000 &&
                        (TargetInfo.HPP >= numericUpDown23.Value &&
                         TargetInfo.HPP <= numericUpDown22.Value) &&
                         PlayerInfo.Status == 1 && TargetInfo.ID > 0 &&
                         !PlayerInfo.HasBuff(272))
                {
                    api.ThirdParty.SendString("/ws \"" + amname.Text + "\" <t>");
                    Thread.Sleep(TimeSpan.FromSeconds(4.0));
                }
            }

            if (ws.Checked && !wsam.Checked && PlayerInfo.Status == 1)
            {
                if (api.Player.GetPlayerInfo().MainJob == 12 || api.Player.GetPlayerInfo().SubJob == 12)
                {
                    var ja = (from object itemChecked in playerJA.CheckedItems
                              select itemChecked.ToString()).ToList();

                    if (ja.Contains("Konzen-ittai") && !PlayerInfo.HasBuff(16) &&
                        Recast.GetAbilityRecast(140) == 0 &&
                        TargetInfo.ID > 0)
                    {
                        api.ThirdParty.SendString("/ja \"Konzen-ittai\" <t>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    if (ja.Contains("Hagakure") && !PlayerInfo.HasBuff(16) &&
                        !PlayerInfo.HasBuff(483) && Recast.GetAbilityRecast(54) == 0 &&
                        PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                    {
                        api.ThirdParty.SendString("/ja \"Hagakure\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    if (ja.Contains("Sengikori") && !PlayerInfo.HasBuff(16) &&
                        !PlayerInfo.HasBuff(440) && Recast.GetAbilityRecast(141) == 0 &&
                        PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                    {
                        api.ThirdParty.SendString("/ja \"Sengikori\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                }
                if (PlayerInfo.TP >= numericUpDown24.Value &&
                    TargetInfo.HPP >= numericUpDown23.Value &&
                    TargetInfo.HPP <= numericUpDown22.Value &&
                    PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                {
                    api.ThirdParty.SendString("/ws \"" + wsname + "\" <t>");
                    Thread.Sleep(TimeSpan.FromSeconds(4.0));
                }
            }

            if (ws.Checked && wsam.Checked &&
               (PlayerInfo.TP >= numericUpDown24.Value &&
                TargetInfo.HPP >= numericUpDown23.Value &&
                TargetInfo.HPP <= numericUpDown22.Value) &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                if (PlayerInfo.HasBuff(270) || PlayerInfo.HasBuff(271) ||
                    PlayerInfo.HasBuff(272) || PlayerInfo.HasBuff(273))
                {
                    api.ThirdParty.SendString("/ws \"" + wsname + "\" <t>");
                    Thread.Sleep(TimeSpan.FromSeconds(4.0));
                }
            }
            else if (ws.Checked && wsam.Checked && amname.Text == "" && PlayerInfo.Status == 1)
            {
                if (PlayerInfo.TP >= numericUpDown24.Value &&
                    TargetInfo.HPP >= numericUpDown23.Value &&
                    TargetInfo.HPP <= numericUpDown22.Value &&
                    PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                {
                    api.ThirdParty.SendString("/ws \"" + wsname + "\" <t>");
                    Thread.Sleep(TimeSpan.FromSeconds(4.0));
                }
            }
        }
        #endregion

        #endregion
        #region Methods: PET

        #region PET: BST

        #region JA: BST (get/set)
        private void BSTGetJA()
        {
            if (PetReady.Items.Count > 0)
                PetReady.Items.Clear();

            if (PetJA.Items.Count > 0)
                PetJA.Items.Clear();

            if (PetInfo.ID != 0)
                pInfo();

            if (PetInfo.Name != null && PetInfo.ID != 0)
            {
                switch (PetInfo.Name)
                {
                    #region Familiar: Frog
                    case "Slippery Silas":
                        break;
                    #endregion
                    #region Familiar: Rabbit
                    case "Hare Familiar":
                    case "Lucky Lulush":
                    case "Keeneared Steffi":
                    case "Droopy Dortwin":
                        if (!PetJA.Items.Contains("Whirl Claws"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Whirl Claws",
                        });
                        }
                        if (!PetJA.Items.Contains("Dust Cloud"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Dust Cloud",
                        });
                        }
                        if (!PetJA.Items.Contains("Foot Kick"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Foot Kick",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Sheep
                    case "Sheep Familiar":
                    case "Nursery Nazuna":
                    case "Rhyming Shizuna":
                    case "Lullaby Melodia":
                        if (!PetJA.Items.Contains("Sheep Song"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Sheep Song",
                        });
                        }
                        if (!PetJA.Items.Contains("Sheep Charge"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Sheep Charge",
                        });
                        }
                        if (!PetJA.Items.Contains("Lamb Chop"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Lamb Chop",
                        });
                        }
                        if (!PetJA.Items.Contains("Rage"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Rage",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Mandragora
                    case "Flowerpot Bill":
                    case "Flowerpot Ben":
                    case "Homunculus":
                    case "Sharpwit Hermes":
                        if (!PetJA.Items.Contains("Head Butt"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Head Butt",
                        });
                        }
                        if (!PetJA.Items.Contains("Scream"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Scream",
                        });
                        }
                        if (!PetJA.Items.Contains("Dream Flower"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Dream Flower",
                        });
                        }
                        if (!PetJA.Items.Contains("Wild Oats"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Wild Oats",
                        });
                        }
                        if (!PetJA.Items.Contains("Leaf Dagger"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Leaf Dagger",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Tiger
                    case "Tiger Familiar":
                    case "Saber Siravarde":
                    case "Gorefang Hobs":
                    case "Blackbeard Randy":
                        if (!PetJA.Items.Contains("Claw Cyclone"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Claw Cyclone",
                        });
                        }
                        if (!PetJA.Items.Contains("Razor Fang"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Razor Fang",
                        });
                        }
                        if (!PetJA.Items.Contains("Roar"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Roar",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Flytrap
                    case "Flytrap Familiar":
                    case "Voracious Audrey":
                    case "Presto Julio":
                        if (!PetJA.Items.Contains("Gloeosuccus"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Gloeosuccus",
                        });
                        }
                        if (!PetJA.Items.Contains("Palsy Pollen"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Palsy Pollen",
                        });
                        }
                        if (!PetJA.Items.Contains("Soporific"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Soporific",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Lizard
                    case "Lizard Familiar":
                    case "Coldblood Como":
                    case "Audacious Anna":
                    case "Warlike Patrick":
                        if (!PetJA.Items.Contains("Blockhead"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Blockhead",
                        });
                        }
                        if (!PetJA.Items.Contains("Secretion"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Secretion",
                        });
                        }
                        if (!PetJA.Items.Contains("Baleful Gaze"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Baleful Gaze",
                        });
                        }
                        if (!PetJA.Items.Contains("Fireball"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Fireball",
                        });
                        }
                        if (!PetJA.Items.Contains("Tail Blow"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Tail Blow",
                        });
                        }
                        if (!PetJA.Items.Contains("Plague Breath"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Plague Breath",
                        });
                        }
                        if (!PetJA.Items.Contains("Brain Crush"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Brain Crush",
                        });
                        }
                        if (!PetJA.Items.Contains("Infrasonics"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Infrasonics",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Fly
                    case "Mayfly Familiar":
                    case "Shellbuster Orob":
                    case "Mailbuster Cetas":
                    case "Headbreaker Ken":
                        if (!PetJA.Items.Contains("Cursed Sphere"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Cursed Sphere",
                        });
                        }
                        if (!PetJA.Items.Contains("Venom"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Venom",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Eft
                    case "Eft Familiar":
                    case "Ambusher Allie":
                    case "Bugeyed Broncha":
                        if (!PetJA.Items.Contains("Geist Wall"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Geist Wall",
                        });
                        }
                        if (!PetJA.Items.Contains("Toxic Spit"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Toxic Spit",
                        });
                        }
                        if (!PetJA.Items.Contains("Numbing Noise"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Numbing Noise",
                        });
                        }
                        if (!PetJA.Items.Contains("Nimble Snap"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Nimble Snap",
                        });
                        }
                        if (!PetJA.Items.Contains("Cyclotail"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Cyclotail",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Beetle
                    case "Beetle Familiar":
                    case "Panzer Galahad":
                    case "Hurler Percival":
                        if (!PetJA.Items.Contains("Spoil"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Spoil",
                        });
                        }
                        if (!PetJA.Items.Contains("Rhino Guard"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Rhino Guard",
                        });
                        }
                        if (!PetJA.Items.Contains("Rhino Attack"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Rhino Attack",
                        });
                        }
                        if (!PetJA.Items.Contains("Power Attack"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Power Attack",
                        });
                        }
                        if (!PetJA.Items.Contains("Hi-Freq Field"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Hi-Freq Field",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Antlion
                    case "Antlion Familiar":
                    case "Chopsuey Chucky":
                        if (!PetJA.Items.Contains("Sandpit"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Sandpit",
                        });
                        }
                        if (!PetJA.Items.Contains("Sandblast"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Sandblast",
                        });
                        }
                        if (!PetJA.Items.Contains("Venom Spray"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Venom Spray",
                        });
                        }
                        if (!PetJA.Items.Contains("Mandibular Bite"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Mandibular Bite",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Crab
                    case "Crab Familiar":
                    case "Courier Carrie":
                    case "Sunburst Malfik":
                    case "Herald Henry":
                        if (!PetJA.Items.Contains("Metallic Body"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Metallic Body",
                        });
                        }
                        if (!PetJA.Items.Contains("Bubble Shower"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Bubble Shower",
                        });
                        }
                        if (!PetJA.Items.Contains("Bubble Curtain"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Bubble Curtain",
                        });
                        }
                        if (!PetJA.Items.Contains("Scissor Guard"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Scissor Guard",
                        });
                        }
                        if (!PetJA.Items.Contains("Big Scissors"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Big Scissors",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Diremite
                    case "Mite Familiar":
                    case "Lifedrinker Lars":
                        if (!PetJA.Items.Contains("Grapple"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Grapple",
                        });
                        }
                        if (!PetJA.Items.Contains("Spinning Top"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Spinning Top",
                        });
                        }
                        if (!PetJA.Items.Contains("Double Claw"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Double Claw",
                        });
                        }
                        if (!PetJA.Items.Contains("Filamented Hold"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Filamented Hold",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Funguar
                    case "Funguar Familiar":
                    case "Discreet Louise":
                    case "Brainy Waluis":
                        if (!PetJA.Items.Contains("Frog Kick"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Frog Kick",
                        });
                        }
                        if (!PetJA.Items.Contains("Queasyshroom"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Queasyshroom",
                        });
                        }
                        if (!PetJA.Items.Contains("Silence Gas"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Silence Gas",
                        });
                        }
                        if (!PetJA.Items.Contains("Numbshroom"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Numbshroom",
                        });
                        }
                        if (!PetJA.Items.Contains("Spore"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Spore",
                        });
                        }
                        if (!PetJA.Items.Contains("Dark Spore"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Dark Spore",
                        });
                        }
                        if (!PetJA.Items.Contains("Shakeshroom"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Shakeshroom",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Sabotender
                    case "Amigo Sabotender":
                        if (!PetJA.Items.Contains("1000 Needles"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "1000 Needles",
                        });
                        }
                        if (!PetJA.Items.Contains("Needleshot"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Needleshot",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Coeurl
                    case "Crafty Clyvonne":
                        if (!PetJA.Items.Contains("Chaotic Eye"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Chaotic Eye",
                        });
                        }
                        if (!PetJA.Items.Contains("Blaster"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Blaster",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Raptor
                    case "Swift Sieghard":
                        if (!PetJA.Items.Contains("Scythe Tail"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Scythe Tail",
                        });
                        }
                        if (!PetJA.Items.Contains("Ripper Fang"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Ripper Fang",
                        });
                        }
                        if (!PetJA.Items.Contains("Chomp Rush"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Chomp Rush",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Pugils
                    case "Turbid Toloi":
                    case "Amiable Roche":
                        if (!PetJA.Items.Contains("Intimidate"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Intimidate",
                        });
                        }
                        if (!PetJA.Items.Contains("Recoil Dive"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Recoil Dive",
                        });
                        }
                        if (!PetJA.Items.Contains("Water Wall"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Water Wall",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Ladybug
                    case "Dipper Yuly":
                    case "Threestar Lynn":
                        if (!PetJA.Items.Contains("Sudden Lunge"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Sudden Lunge",
                        });
                        }
                        if (!PetJA.Items.Contains("Spiral Spin"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Spiral Spin",
                        });
                        }
                        if (!PetJA.Items.Contains("Noisome Powder"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Noisome Powder",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Lycopodium
                    case "Flowerpot Merle":
                    case "Sharpwi\"t\" Hermes":
                        if (!PetJA.Items.Contains("Head Butt"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Head Butt",
                        });
                        }
                        if (!PetJA.Items.Contains("Scream"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Scream",
                        });
                        }
                        if (!PetJA.Items.Contains("Wild Oats"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Wild Oats",
                        });
                        }
                        if (!PetJA.Items.Contains("Leaf Dagger"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Leaf Dagger",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Apkallu
                    case "Dapper Mac":
                        if (!PetJA.Items.Contains("Wing Slap"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Wing Slap",
                        });
                        }
                        if (!PetJA.Items.Contains("Beak Lunge"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Beak Lunge",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Leech
                    case "Fatso Fargann":
                        if (!PetJA.Items.Contains("Suction"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Suction",
                        });
                        }
                        if (!PetJA.Items.Contains("Drainkiss"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Drainkiss",
                        });
                        }
                        if (!PetJA.Items.Contains("Acid Mist"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Acid Mist",
                        });
                        }
                        if (!PetJA.Items.Contains("TP Drainkiss"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "TP Drainkiss",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Hippogryph
                    case "Faithful Falcorr":
                        if (!PetJA.Items.Contains("Back Heel"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Back Heel",
                        });
                        }
                        if (!PetJA.Items.Contains("Jettatura"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Jettatura",
                        });
                        }
                        if (!PetJA.Items.Contains("Choke Breath"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Choke Breath",
                        });
                        }
                        if (!PetJA.Items.Contains("Fantod"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Fantod",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Lynx
                    case "Bloodclaw Shasra":
                        if (!PetJA.Items.Contains("Chaotic Eye"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Chaotic Eye",
                        });
                        }
                        if (!PetJA.Items.Contains("Blaster"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Blaster",
                        });
                        }
                        if (!PetJA.Items.Contains("Charged Whisker"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Charged Whisker",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Slug
                    case "Gooey Gerard":
                    case "Generous Arthur":
                        if (!PetJA.Items.Contains("Purulent Ooze"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Purulent Ooze",
                        });
                        }
                        if (!PetJA.Items.Contains("Corrosive Ooze"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Corrosive Ooze",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Adamantoise
                    case "Crude Raphie":
                        if (!PetJA.Items.Contains("Tortoise Stomp"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Tortoise Stomp",
                        });
                        }
                        if (!PetJA.Items.Contains("Harden Shell"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Harden Shell",
                        });
                        }
                        if (!PetJA.Items.Contains("Aqua Breath"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Aqua Breath",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Chapuli
                    case "Scissorleg Xerin":
                        if (!PetJA.Items.Contains("Sensilla Blades"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Sensilla Blades",
                        });
                        }
                        if (!PetJA.Items.Contains("Tegmina Buffet"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Tegmina Buffet",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Tulfaires
                    case "Attentive Ibuki":
                        if (!PetJA.Items.Contains("Molting Plumage"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Molting Plumage",
                        });
                        }
                        if (!PetJA.Items.Contains("Swooping Frenzy"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Swooping Frenzy",
                        });
                        }
                        if (!PetJA.Items.Contains("Pentapeck"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Pentapeck",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Raaz
                    case "Caring Kiyomaro":
                        if (!PetJA.Items.Contains("Sweeping Gouge"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Sweeping Gouge",
                        });
                        }
                        if (!PetJA.Items.Contains("Zealous Snort"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Zealous Snort",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Snapweed
                    case "Redolent Candi":
                    case "Alluring Honey":
                        if (!PetJA.Items.Contains("Tickling Tendrils"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Tickling Tendrils",
                        });
                        }
                        if (!PetJA.Items.Contains("Stink Bomb"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Stink Bomb",
                        });
                        }
                        if (!PetJA.Items.Contains("Nectarous Deluge"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Nectarous Deluge",
                        });
                        }
                        if (!PetJA.Items.Contains("Nepenthic Plunge"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Nepenthic Plunge",
                        });
                        }
                        break;
                        #endregion
                }
            }

            #region BST: Pet Ready

            #region Load MJ (main job)
            if (PlayerInfo.MainJobLevel >= 25 &&
                !PetReady.Items.Contains("Sic - (BST)"))
            {
                PetReady.Items.AddRange(new object[]
                {
                    "Sic - (BST)",
                });
            }
            if (PlayerInfo.MainJobLevel >= 45 &&
                !PetReady.Items.Contains("Snarl - (BST)"))
            {
                PetReady.Items.AddRange(new object[]
                {
                    "Snarl - (BST)",
                });
            }
            if (PlayerInfo.MainJobLevel >= 75 && PlayerInfo.HasAbility(162) &&
                !PetReady.Items.Contains("Killer Instinct - (BST)"))
            {
                PetReady.Items.AddRange(new object[]
                {
                    "Killer Instinct - (BST)",
                });
            }
            if (PlayerInfo.MainJobLevel >= 75 && PlayerInfo.HasAbility(161) &&
                !PetReady.Items.Contains("Feral Howl - (BST)"))
            {
                PetReady.Items.AddRange(new object[]
                {
                    "Feral Howl - (BST)",
                });
            }
            if (PlayerInfo.MainJobLevel >= 83 &&
                !PetReady.Items.Contains("Spur - (BST)"))
            {
                PetReady.Items.AddRange(new object[]
                {
                    "Spur - (BST)",
                });
            }
            if (PlayerInfo.MainJobLevel >= 93 &&
                !PetReady.Items.Contains("Run Wild - (BST)"))
            {
                PetReady.Items.AddRange(new object[]
                {
                    "Run Wild - (BST)",
                });
            }
            if (PlayerInfo.MainJobLevel >= 96 &&
                !PetReady.Items.Contains("Unleash - (BST)"))
            {
                PetReady.Items.AddRange(new object[]
                {
                    "Unleash - (BST)",
                });
            }
            #endregion
            #region Load SJ (sub job)
            if (api.Player.GetPlayerInfo().SubJob == 9)
            {
                if (PlayerInfo.SubJobLevel >= 25 &&
                    !PetReady.Items.Contains("Sic - (BST)"))
                {
                    PetReady.Items.AddRange(new object[]
                    {
                        "Sic - (BST)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 45 &&
                    !PetReady.Items.Contains("Snarl - (BST)"))
                {
                    PetReady.Items.AddRange(new object[]
                    {
                        "Snarl - (BST)",
                    });
                }
            }
            #endregion

            #endregion
        }
        public void pInfo()
        {
            label20.Text = "Pets Name: " + PetInfo.Name;
            label21.Text = @"Pet ID: " + PetInfo.ID;
            label22.Text = @"Pets HP%: " + PetInfo.HPP;
            label23.Text = @"Pets TP%: " + PetInfo.TPP;
        }

        #endregion
        #region JA: BST (use)
        private void PetReadyJA()
        {
            if (PlayerInfo.Status == 0 || !botRunning || TargetInfo.ID == 0)
                return;

            #region BST JA
            var bstja = (from object itemChecked in PetReady.CheckedItems
                         select itemChecked.ToString()).ToList();

            if (bstja.Contains("Sic - (BST)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(102) == 0)
            {
                api.ThirdParty.SendString("/pet \"Sic\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
            }
            if (bstja.Contains("Snarl - (BST)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(107) == 0)
            {
                api.ThirdParty.SendString("/pet \"Snarl\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
            }
            if (bstja.Contains("Spur - (BST)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(45) == 0)
            {
                api.ThirdParty.SendString("/pet \"Spur\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
            }
            if (bstja.Contains("Feral Howl - (BST)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(105) == 0)
            {
                api.ThirdParty.SendString("/pet \"Feral Howl\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
            }
            if (bstja.Contains("Killer Instinct - (BST)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(106) == 0)
            {
                api.ThirdParty.SendString("/pet \"Killer Instinct\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
            }
            if (bstja.Contains("Run Wild - (BST)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(46) == 0)
            {
                api.ThirdParty.SendString("/pet \"Run Wild\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (bstja.Contains("Unleash - (BST)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(254) == 0 && !PlayerInfo.HasBuff(498))
            {
                api.ThirdParty.SendString("/pet \"Unleash\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region PET JA

            if (Recast.GetAbilityRecast(102) != 0)
                return;

            var petja = (from object itemChecked in PetJA.CheckedItems
                         select itemChecked.ToString()).ToList();

            #region Familiar: Rabbit
            if (PetInfo.Name == "Hare Familiar" ||
                PetInfo.Name == "Keeneared Steffi" ||
                PetInfo.Name == "Lucky Lulush" ||
                PetInfo.Name == "Droopy Dortwin")
            {
                if (petja.Contains("Wild Carrot"))
                {
                    api.ThirdParty.SendString("/pet \"Wild Carrot\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Whirl Claws"))
                {
                    api.ThirdParty.SendString("/pet \"Whirl Claws\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Dust Cloud"))
                {
                    api.ThirdParty.SendString("/pet \"Dust Cloud\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Foot Kick"))
                {
                    api.ThirdParty.SendString("/pet \"Foot Kick\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Sheep
            if (PetInfo.Name == "Sheep Familiar" ||
                PetInfo.Name == "Lullaby Melodia" ||
                PetInfo.Name == "Nursery Nazuna" ||
                PetInfo.Name == "Rhyming Shizuna")
            {
                if (petja.Contains("Lamb Chop"))
                {
                    api.ThirdParty.SendString("/pet \"Lamb Chop\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Rage"))
                {
                    api.ThirdParty.SendString("/pet \"Rage\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Sheep Charge"))
                {
                    api.ThirdParty.SendString("/pet \"Sheep Charge\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Sheep Song"))
                {
                    api.ThirdParty.SendString("/pet \"Sheep Song\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Mandragora
            if (PetInfo.Name == "Flowerpot Bill" ||
                PetInfo.Name == "Flowerpot Ben" ||
                PetInfo.Name == "Homunculus" ||
                PetInfo.Name == "Flowerpot Merle" ||
                PetInfo.Name == "Sharpwit Hermes")
            {
                if (petja.Contains("Head Butt"))
                {
                    api.ThirdParty.SendString("/pet \"Head Butt\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Scream"))
                {
                    api.ThirdParty.SendString("/pet \"Scream\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Dream Flower"))
                {
                    api.ThirdParty.SendString("/pet \"Dream Flower\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Wild Oats"))
                {
                    api.ThirdParty.SendString("/pet \"Wild Oats\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Leaf Dagger"))
                {
                    api.ThirdParty.SendString("/pet \"Leaf Dagger\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Tiger
            if (PetInfo.Name == "Tiger Familiar" ||
                PetInfo.Name == "Saber Siravarde" ||
                PetInfo.Name == "Gorefang Hobs" ||
                PetInfo.Name == "Blackbeard Randy")
            {
                if (petja.Contains("Claw Cyclone"))
                {
                    api.ThirdParty.SendString("/pet \"Claw Cyclone\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Razor Fang"))
                {
                    api.ThirdParty.SendString("/pet \"Razor Fang\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Roar"))
                {
                    api.ThirdParty.SendString("/pet \"Roar\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Flytrap
            if (PetInfo.Name == "Flytrap Familiar" ||
                PetInfo.Name == "Voracious Audrey" ||
                PetInfo.Name == "Presto Julio")
            {
                if (petja.Contains("Gloeosuccus"))
                {
                    api.ThirdParty.SendString("/pet \"Gloeosuccus\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Palsy Pollen"))
                {
                    api.ThirdParty.SendString("/pet \"Palsy Pollen\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Soporific"))
                {
                    api.ThirdParty.SendString("/pet \"Soporific\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Lizard
            if (PetInfo.Name == "Lizard Familiar" ||
                PetInfo.Name == "Coldblood Como" ||
                PetInfo.Name == "Audacious Anna" ||
                PetInfo.Name == "Warlike Patrick")
            {
                if (petja.Contains("Blockhead"))
                {
                    api.ThirdParty.SendString("/pet \"Blockhead\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Secretion"))
                {
                    api.ThirdParty.SendString("/pet \"Secretion\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Baleful Gaze"))
                {
                    api.ThirdParty.SendString("/pet \"Baleful Gaze\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Fireball"))
                {
                    api.ThirdParty.SendString("/pet \"Fireball\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Tail Blow"))
                {
                    api.ThirdParty.SendString("/pet \"Tail Blow\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Plague Breath"))
                {
                    api.ThirdParty.SendString("/pet \"Plague Breath\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Brain Crush"))
                {
                    api.ThirdParty.SendString("/pet \"Brain Crush\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Infrasonics"))
                {
                    api.ThirdParty.SendString("/pet \"Infrasonics\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Fly
            if (PetInfo.Name == "Mayfly Familiar" ||
                PetInfo.Name == "Shellbuster Orob" ||
                PetInfo.Name == "Mailbuster Cetas" ||
                PetInfo.Name == "Headbreaker Ken")
            {
                if (petja.Contains("Cursed Sphere"))
                {
                    api.ThirdParty.SendString("/pet \"Cursed Sphere\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Venom"))
                {
                    api.ThirdParty.SendString("/pet \"Venom\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Eft
            if (PetInfo.Name == "Eft Familiar" ||
                PetInfo.Name == "Ambusher Allie" ||
                PetInfo.Name == "Bugeyed Broncha")
            {
                if (petja.Contains("Geist Wall"))
                {
                    api.ThirdParty.SendString("/pet \"Geist Wall\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Toxic Spit"))
                {
                    api.ThirdParty.SendString("/pet \"Toxic Spit\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Numbing Noise"))
                {
                    api.ThirdParty.SendString("/pet \"Numbing Noise\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Nimble Snap"))
                {
                    api.ThirdParty.SendString("/pet \"Nimble Snap\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Cyclotail"))
                {
                    api.ThirdParty.SendString("/pet \"Cyclotail\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Beetle
            if (PetInfo.Name == "Beetle Familiar" ||
                PetInfo.Name == "Panzer Galahad" ||
                PetInfo.Name == "Hurler Percival")
            {
                if (petja.Contains("Spoil"))
                {
                    api.ThirdParty.SendString("/pet \"Spoil\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Rhino Guard"))
                {
                    api.ThirdParty.SendString("/pet \"Rhino Guard\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Rhino Attack"))
                {
                    api.ThirdParty.SendString("/pet \"Rhino Attack\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Power Attack"))
                {
                    api.ThirdParty.SendString("/pet \"Power Attack\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Hi-Freq Field"))
                {
                    api.ThirdParty.SendString("/pet \"Hi-Freq Field\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Antlion
            if (PetInfo.Name == "Antlion Familiar" ||
                PetInfo.Name == "Chopsuey Chucky")
            {
                if (petja.Contains("Sandpit"))
                {
                    api.ThirdParty.SendString("/pet \"Sandpit\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Sandblast"))
                {
                    api.ThirdParty.SendString("/pet \"Sandblast\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Venom Spray"))
                {
                    api.ThirdParty.SendString("/pet \"Venom Spray\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Mandibular Bite"))
                {
                    api.ThirdParty.SendString("/pet \"Mandibular Bite\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Crab

            if (PetInfo.Name == "Crab Familiar" ||
                PetInfo.Name == "Courier Carrie" ||
                PetInfo.Name == "Sunburst Malfik" ||
                PetInfo.Name == "Herald Henry")
            {
                if (petja.Contains("Metallic Body"))
                {
                    api.ThirdParty.SendString("/pet \"Metallic Body\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Bubble Shower"))
                {
                    api.ThirdParty.SendString("/pet \"Bubble Shower\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Bubble Curtain"))
                {
                    api.ThirdParty.SendString("/pet \"Bubble Curtain\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Scissor Guard"))
                {
                    api.ThirdParty.SendString("/pet \"Scissor Guard\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Big Scissors"))
                {
                    api.ThirdParty.SendString("/pet \"Big Scissors\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Diremite
            if (PetInfo.Name == "Mite Familiar" ||
                PetInfo.Name == "Lifedrinker Lars")
            {
                if (petja.Contains("Grapple"))
                {
                    api.ThirdParty.SendString("/pet \"Grapple\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Spinning Top"))
                {
                    api.ThirdParty.SendString("/pet \"Spinning Top\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Double Claw"))
                {
                    api.ThirdParty.SendString("/pet \"Double Claw\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Filamented Hold"))
                {
                    api.ThirdParty.SendString("/pet \"Filamented Hold\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Funguar
            if (PetInfo.Name == "Funguar Familiar" ||
                PetInfo.Name == "Discreet Louise" ||
                PetInfo.Name == "Brainy Waluis")
            {
                if (petja.Contains("Frog Kick"))
                {
                    api.ThirdParty.SendString("/pet \"Frog Kick\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Queasyshroom"))
                {
                    api.ThirdParty.SendString("/pet \"Queasyshroom\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Silence Gas"))
                {
                    api.ThirdParty.SendString("/pet \"Silence Gas\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Numbshroom"))
                {
                    api.ThirdParty.SendString("/pet \"Numbshroom\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Spore"))
                {
                    api.ThirdParty.SendString("/pet \"Spore\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Dark Spore"))
                {
                    api.ThirdParty.SendString("/pet \"Dark Spore\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Shakeshroom"))
                {
                    api.ThirdParty.SendString("/pet \"Shakeshroom\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Sabotender
            if (PetInfo.Name == "Amigo Sabotender")
            {
                if (petja.Contains("1000 Needles"))
                {
                    api.ThirdParty.SendString("/pet \"1000 Needles\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Needleshot"))
                {
                    api.ThirdParty.SendString("/pet \"Needleshot\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Coeurl/Linx
            if (PetInfo.Name == "Crafty Clyvonne" ||
                PetInfo.Name == "Bloodclaw Shasra")
            {
                if (petja.Contains("Chaotic Eye"))
                {
                    api.ThirdParty.SendString("/pet \"Chaotic Eye\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Blaster"))
                {
                    api.ThirdParty.SendString("/pet \"Blaster\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Charged Whisker"))
                {
                    api.ThirdParty.SendString("/pet \"Charged Whisker\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Raptor
            if (PetInfo.Name == "Swift Sieghard")
            {
                if (petja.Contains("Scythe Tail"))
                {
                    api.ThirdParty.SendString("/pet \"Scythe Tail\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Ripper Fang"))
                {
                    api.ThirdParty.SendString("/pet \"Ripper Fang\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Chomp Rush"))
                {
                    api.ThirdParty.SendString("/pet \"Chomp Rush\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Pugils
            if (PetInfo.Name == "Turbid Toloi" ||
                PetInfo.Name == "Amiable Roche")
            {
                if (petja.Contains("Intimidate"))
                {
                    api.ThirdParty.SendString("/pet \"Intimidate\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Recoil Dive"))
                {
                    api.ThirdParty.SendString("/pet \"Recoil Dive\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Water Wall"))
                {
                    api.ThirdParty.SendString("/pet \"Water Wall\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Ladybug
            if (PetInfo.Name == "Dipper Yuly" ||
                PetInfo.Name == "Threestar Lynn")
            {
                if (petja.Contains("Sudden Lunge"))
                {
                    api.ThirdParty.SendString("/pet \"Sudden Lunge\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Spiral Spin"))
                {
                    api.ThirdParty.SendString("/pet \"Spiral Spin\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Noisome Powder"))
                {
                    api.ThirdParty.SendString("/pet \"Noisome Powder\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Apkallu
            if (PetInfo.Name == "Dapper Mac")
            {
                if (petja.Contains("Wing Slap"))
                {
                    api.ThirdParty.SendString("/pet \"Wing Slap\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Beak Lunge"))
                {
                    api.ThirdParty.SendString("/pet \"Beak Lunge\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Leech
            if (PetInfo.Name == "Fatso Fargann")
            {
                if (petja.Contains("Suction"))
                {
                    api.ThirdParty.SendString("/pet \"Suction\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Drainkiss"))
                {
                    api.ThirdParty.SendString("/pet \"Drainkiss\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Acid Mist"))
                {
                    api.ThirdParty.SendString("/pet \"Acid Mist\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("TP Drainkiss"))
                {
                    api.ThirdParty.SendString("/pet \"TP Drainkiss\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Hippogryph
            if (PetInfo.Name == "Faithful Falcorr")
            {
                if (petja.Contains("Back Heel"))
                {
                    api.ThirdParty.SendString("/pet \"Back Heel\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Jettatura"))
                {
                    api.ThirdParty.SendString("/pet \"Jettatura\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Choke Breath"))
                {
                    api.ThirdParty.SendString("/pet \"Choke Breath\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Fantod"))
                {
                    api.ThirdParty.SendString("/pet \"Fantod\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Slug
            if (PetInfo.Name == "Gooey Gerard" ||
                PetInfo.Name == "Generous Arthur")
            {
                if (petja.Contains("Purulent Ooze"))
                {
                    api.ThirdParty.SendString("/pet \"Purulent Ooze\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Corrosive Ooze"))
                {
                    api.ThirdParty.SendString("/pet \"Corrosive Ooze\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Adamantoise
            if (PetInfo.Name == "Crude Raphie")
            {
                if (petja.Contains("Tortoise Stomp"))
                {
                    api.ThirdParty.SendString("/pet \"Tortoise Stomp\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Harden Shell"))
                {
                    api.ThirdParty.SendString("/pet \"Harden Shell\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Aqua Breath"))
                {
                    api.ThirdParty.SendString("/pet \"Aqua Breath\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Chapuli
            if (PetInfo.Name == "Scissorleg Xerin")
            {
                if (petja.Contains("Sensilla Blades"))
                {
                    api.ThirdParty.SendString("/pet \"Sensilla Blades\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Tegmina Buffet"))
                {
                    api.ThirdParty.SendString("/pet \"Tegmina Buffet\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Tulfaires
            if (PetInfo.Name == "Attentive Ibuki")
            {
                if (petja.Contains("Molting Plumage"))
                {
                    api.ThirdParty.SendString("/pet \"Molting Plumage\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Swooping Frenzy"))
                {
                    api.ThirdParty.SendString("/pet \"Swooping Frenzy\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Pentapeck"))
                {
                    api.ThirdParty.SendString("/pet \"Pentapeck\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Raaz
            if (PetInfo.Name == "Caring Kiyomaro")
            {
                if (petja.Contains("Sweeping Gouge"))
                {
                    api.ThirdParty.SendString("/pet \"Sweeping Gouge\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Zealous Snort"))
                {
                    api.ThirdParty.SendString("/pet \"Zealous Snort\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Snapweed
            if (PetInfo.Name == "")
            {
                if (petja.Contains("Tickling Tendrils"))
                {
                    api.ThirdParty.SendString("/pet \"Tickling Tendrils\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Stink Bomb"))
                {
                    api.ThirdParty.SendString("/pet \"Stink Bomb\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Nectarous Deluge"))
                {
                    api.ThirdParty.SendString("/pet \"Nectarous Deluge\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Nepenthic Plunge"))
                {
                    api.ThirdParty.SendString("/pet \"Nepenthic Plunge\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion

            #endregion
        }
        #endregion

        #endregion
        #region PET: DRG

        #region JA: DRG (get/set)
        private void WyvernGetJA()
        {
            if (WyvernJA.Items.Count > 0)
                WyvernJA.Items.Clear();

            if (PlayerInfo.MainJob != 14 && PlayerInfo.SubJob != 14) return;

            #region JA: DRG
            if ((PlayerInfo.MainJobLevel >= 25 || PlayerInfo.SubJobLevel >= 25) && !WyvernJA.Items.Contains("Spirit Link")) WyvernJA.Items.Add("Spirit Link");
            if (PlayerInfo.MainJobLevel >= 75 && PlayerInfo.HasAbility(169) && !WyvernJA.Items.Contains("Deep Breathing")) WyvernJA.Items.Add("Deep Breathing");
            if (PlayerInfo.MainJobLevel >= 95 && !WyvernJA.Items.Contains("Steady Wing")) WyvernJA.Items.Add("Steady Wing");
            if (PlayerInfo.MainJobLevel >= 90 && !WyvernJA.Items.Contains("Smiting Breath - (Dragoon)"))
            {
                 WyvernJA.Items.Add("Smiting Breath");
                 WyvernJA.Items.Add("Restoring Breath");
            }
            #endregion
            api.ThirdParty.SendString(String.Format("/echo {0}", WyvernJA.Items.Count));
        }

        #endregion
        #region JA: DRG (use)
        private void WyvernUseJA()
        {
            var petja = (from object itemChecked in WyvernJA.CheckedItems select itemChecked.ToString()).ToList();

            if (petja.Count == 0 || PlayerInfo.Status == 0 || !PlayerInfo.HasBuff(16)) return;

            if (petja.Contains("Restoring Breath") && PlayerInfo.Status == 1 &&
                PlayerInfo.HPP <= RestoringBreathHP.Value && Recast.GetAbilityRecast(239) == 0)
            {
                if (petja.Contains("Deep Breathing") && !PlayerInfo.HasBuff(16) &&
                    Recast.GetAbilityRecast(164) == 0 && TargetInfo.ID > 0)
                {
                    api.ThirdParty.SendString("/ja \"Deep Breathing\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    api.ThirdParty.SendString("/pet \"Restoring Breath\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                else if (Recast.GetAbilityRecast(239) == 0)
                {
                    api.ThirdParty.SendString("/pet \"Restoring Breath\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }

            if (petja.Contains("Steady Wing") && PlayerInfo.Status == 1 &&
                PetInfo.HPP < DragonPetHP.Value && !PlayerInfo.HasBuff(16) && Recast.GetAbilityRecast(70) == 0)
            {
                api.ThirdParty.SendString("/pet \"Steady Wing\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }

            if (petja.Contains("Spirit Link") && PlayerInfo.Status == 1 &&
                PetInfo.HPP < WyvernSpirit.Value && PlayerInfo.HPP > PlayerSpirit.Value &&
                Recast.GetAbilityRecast(162) == 0 && !PlayerInfo.HasBuff(16))
            {
                api.ThirdParty.SendString("/ja \"Spirit Link\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }

            if (petja.Contains("Smiting Breath") && PlayerInfo.Status == 1 &&
                TargetInfo.HPP > BreathMIN.Value && TargetInfo.HPP <= BreathMAX.Value &&
                Recast.GetAbilityRecast(238) == 0 && !PlayerInfo.HasBuff(16))
            {
                if (petja.Contains("Deep Breathing") && !PlayerInfo.HasBuff(16) &&
                    Recast.GetAbilityRecast(164) == 0 && TargetInfo.ID > 0)
                {
                    api.ThirdParty.SendString("/ja \"Deep Breathing\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));

                    if (TargetInfo.ID > 0 && TargetInfo.HPP > BreathMIN.Value)
                        api.ThirdParty.SendString("/pet \"Smiting Breath\" <t>");

                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                else if (Recast.GetAbilityRecast(238) == 0)
                {
                    if (TargetInfo.ID > 0 && TargetInfo.HPP > BreathMIN.Value)
                        api.ThirdParty.SendString("/pet \"Smiting Breath\" <t>");

                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }

            if (petja.Contains("Deep Breathing - (Dragoon)") && PlayerInfo.Status == 1 &&
                Recast.GetAbilityRecast(164) == 0 && !PlayerInfo.HasBuff(16))
            {
                api.ThirdParty.SendString("/ja \"Deep Breathing\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
        }
        #endregion

        #endregion

        #endregion
        #region Methods: FRM

        #region Farming: save/load target list
        private void LoadToolStripMenuItemClick(object sender, EventArgs e)
        {
            var dats = new Dictionary<string, string>();

            var openFile = new OpenFileDialog();
            openFile.Filter = @"mob files (*.xml)|*.xml";
            openFile.InitialDirectory = Application.StartupPath + @"\\Plugins\\scripted_data";
            openFile.Title = @"select a mob list file";

            switch (openFile.ShowDialog())
            {
                case DialogResult.OK:
                    var doc = XDocument.Load(openFile.FileName);
                    if (doc.Root == null)
                        return;
                    foreach (var xml in doc.Root.Elements())
                    {
                        dats.Add(xml.Attribute("id").Value, xml.Attribute("name").Value);
                    }
                    SelectedTargets.Items.Clear();
                    foreach (var entry in dats.OrderBy(key => key.Value))
                    {
                        SelectedTargets.Items.Add(entry.Key).SubItems.Add(entry.Value);
                    }
                    break;
            }
        }
        private void SaveToolStripMenuItemClick(object sender, EventArgs e)
        {
            var dats = new Dictionary<string, string>();

            var saveFile = new SaveFileDialog();
            saveFile.Filter = @"mob files (*.xml)|*.xml";
            saveFile.InitialDirectory = Application.StartupPath + @"\\Plugins\\scripted_data";
            saveFile.Title = @"save mob list file";

            switch (saveFile.ShowDialog())
            {
                case DialogResult.OK:
                    {
                        if (SelectedTargets.Items.Count <= 0) return;

                        var file = saveFile.FileName;
                        var xdoc = new XmlDocument();

                        var declaration = xdoc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
                        var comment = xdoc.CreateComment("This is an XML Generated File");
                        var root = xdoc.CreateElement("saved");

                        xdoc.AppendChild(declaration);
                        xdoc.AppendChild(comment);
                        xdoc.AppendChild(root);

                        foreach (ListViewItem item in SelectedTargets.Items)
                        {
                            var entry = xdoc.CreateElement("entry");
                            var id = xdoc.CreateAttribute("id");
                            var name = xdoc.CreateAttribute("name");

                            id.Value = item.Text;
                            name.Value = item.SubItems[1].Text;

                            entry.Attributes.Append(id);
                            entry.Attributes.Append(name);
                            root.AppendChild(entry);

                        }
                        xdoc.Save(file);
                    }
                    break;
            }
        }
        #endregion
        #region Farming: populate target list
        private void PopulateTargetLists(string idType)
        {
            wantedID.Clear();
            wantedNM.Clear();

            #region zone array
            var dats = new Dictionary<string, string>
            {
                {"1", "\\ROM3\\2\\111.DAT"},
                {"2", "\\ROM3\\2\\112.DAT"},
                {"3", "\\ROM3\\2\\113.DAT"},
                {"4", "\\ROM3\\2\\114.DAT"},
                {"5", "\\ROM3\\2\\115.DAT"},
                {"6", "\\ROM3\\2\\116.DAT"},
                {"7", "\\ROM3\\2\\117.DAT"},
                {"8", "\\ROM3\\2\\118.DAT"},
                {"9", "\\ROM3\\2\\119.DAT"},
                {"A", "\\ROM3\\2\\120.DAT"},
                {"B", "\\ROM3\\2\\121.DAT"},
                {"C", "\\ROM3\\2\\122.DAT"},
                {"D", "\\ROM3\\2\\123.DAT"},
                {"E", "\\ROM3\\2\\124.DAT"},
                {"F", "\\ROM\\25\\80.DAT"},
                {"10", "\\ROM3\\2\\126.DAT"},
                {"11", "\\ROM3\\2\\127.DAT"},
                {"12", "\\ROM3\\3\\0.DAT"},
                {"13", "\\ROM3\\3\\1.DAT"},
                {"14", "\\ROM3\\3\\2.DAT"},
                {"15", "\\ROM3\\3\\3.DAT"},
                {"16", "\\ROM3\\3\\4.DAT"},
                {"17", "\\ROM3\\3\\5.DAT"},
                {"18", "\\ROM3\\3\\6.DAT"},
                {"19", "\\ROM3\\3\\7.DAT"},
                {"1A", "\\ROM3\\3\\8.DAT"},
                {"1B", "\\ROM3\\3\\9.DAT"},
                {"1C", "\\ROM3\\3\\10.DAT"},
                {"1D", "\\ROM3\\3\\11.DAT"},
                {"1E", "\\ROM3\\3\\12.DAT"},
                {"1F", "\\ROM3\\3\\13.DAT"},
                {"20", "\\ROM3\\3\\14.DAT"},
                {"21", "\\ROM3\\3\\15.DAT"},
                {"22", "\\ROM3\\3\\16.DAT"},
                {"23", "\\ROM3\\3\\17.DAT"},
                {"24", "\\ROM3\\3\\18.DAT"},
                {"25", "\\ROM3\\3\\19.DAT"},
                {"26", "\\ROM3\\3\\20.DAT"},
                {"27", "\\ROM3\\3\\21.DAT"},
                {"28", "\\ROM3\\3\\22.DAT"},
                {"29", "\\ROM3\\3\\23.DAT"},
                {"2A", "\\ROM3\\3\\24.DAT"},
                {"2B", "\\ROM3\\3\\25.DAT"},
                {"2C", "\\ROM3\\3\\26.DAT"},
                {"2D", "\\ROM\\25\\110.DAT"},
                {"2E", "\\ROM4\\1\\45.DAT"},
                {"2F", "\\ROM4\\1\\46.DAT"},
                {"30", "\\ROM4\\1\\47.DAT"},
                {"31", "\\ROM4\\1\\48.DAT"},
                {"32", "\\ROM4\\1\\49.DAT"},
                {"33", "\\ROM4\\1\\50.DAT"},
                {"34", "\\ROM4\\1\\51.DAT"},
                {"35", "\\ROM4\\1\\52.DAT"},
                {"36", "\\ROM4\\1\\53.DAT"},
                {"37", "\\ROM4\\1\\54.DAT"},
                {"38", "\\ROM4\\1\\55.DAT"},
                {"39", "\\ROM4\\1\\56.DAT"},
                {"3A", "\\ROM4\\1\\57.DAT"},
                {"3B", "\\ROM4\\1\\58.DAT"},
                {"3C", "\\ROM4\\1\\59.DAT"},
                {"3D", "\\ROM4\\1\\60.DAT"},
                {"3E", "\\ROM4\\1\\61.DAT"},
                {"3F", "\\ROM4\\1\\62.DAT"},
                {"40", "\\ROM4\\1\\63.DAT"},
                {"41", "\\ROM4\\1\\64.DAT"},
                {"42", "\\ROM4\\1\\65.DAT"},
                {"43", "\\ROM4\\1\\66.DAT"},
                {"44", "\\ROM4\\1\\67.DAT"},
                {"45", "\\ROM4\\1\\68.DAT"},
                {"46", "\\ROM4\\1\\69.DAT"},
                {"47", "\\ROM4\\1\\70.DAT"},
                {"48", "\\ROM4\\1\\71.DAT"},
                {"49", "\\ROM4\\1\\72.DAT"},
                {"4A", "\\ROM4\\1\\73.DAT"},
                {"4B", "\\ROM4\\1\\74.DAT"},
                {"4C", "\\ROM4\\1\\75.DAT"},
                {"4D", "\\ROM4\\1\\76.DAT"},
                {"4E", "\\ROM4\\1\\77.DAT"},
                {"4F", "\\ROM4\\1\\78.DAT"},
                {"50", "\\ROM\\26\\17.DAT"},
                {"51", "\\ROM\\26\\18.DAT"},
                {"52", "\\ROM\\26\\19.DAT"},
                {"53", "\\ROM\\26\\20.DAT"},
                {"54", "\\ROM\\26\\21.DAT"},
                {"55", "\\ROM\\26\\22.DAT"},
                {"56", "\\ROM\\26\\23.DAT"},
                {"57", "\\ROM\\26\\24.DAT"},
                {"58", "\\ROM\\26\\25.DAT"},
                {"59", "\\ROM\\26\\26.DAT"},
                {"5A", "\\ROM\\26\\27.DAT"},
                {"5B", "\\ROM\\26\\28.DAT"},
                {"5C", "\\ROM\\26\\29.DAT"},
                {"5D", "\\ROM\\26\\30.DAT"},
                {"5E", "\\ROM\\26\\31.DAT"},
                {"5F", "\\ROM\\26\\32.DAT"},
                {"60", "\\ROM\\26\\33.DAT"},
                {"61", "\\ROM\\26\\34.DAT"},
                {"62", "\\ROM\\26\\35.DAT"},
                {"63", "\\ROM\\26\\36.DAT"},
                {"64", "\\ROM\\26\\37.DAT"},
                {"65", "\\ROM\\26\\38.DAT"},
                {"66", "\\ROM\\26\\39.DAT"},
                {"67", "\\ROM\\26\\40.DAT"},
                {"68", "\\ROM\\26\\41.DAT"},
                {"69", "\\ROM\\26\\42.DAT"},
                {"6A", "\\ROM\\26\\43.DAT"},
                {"6B", "\\ROM\\26\\44.DAT"},
                {"6C", "\\ROM\\26\\45.DAT"},
                {"6D", "\\ROM\\26\\46.DAT"},
                {"6E", "\\ROM\\26\\47.DAT"},
                {"6F", "\\ROM\\26\\48.DAT"},
                {"70", "\\ROM\\26\\49.DAT"},
                {"71", "\\ROM2\\13\\95.DAT"},
                {"72", "\\ROM2\\13\\96.DAT"},
                {"73", "\\ROM\\26\\52.DAT"},
                {"74", "\\ROM\\26\\53.DAT"},
                {"75", "\\ROM\\26\\54.DAT"},
                {"76", "\\ROM\\26\\55.DAT"},
                {"77", "\\ROM\\26\\56.DAT"},
                {"78", "\\ROM\\26\\57.DAT"},
                {"79", "\\ROM2\\13\\97.DAT"},
                {"7A", "\\ROM2\\13\\98.DAT"},
                {"7B", "\\ROM2\\13\\98.DAT"},
                {"7C", "\\ROM2\\13\\100.DAT"},
                {"7D", "\\ROM2\\13\\101.DAT"},
                {"7E", "\\ROM\\26\\63.DAT"},
                {"7F", "\\ROM\\26\\64.DAT"},
                {"80", "\\ROM2\\13\\102.DAT"},
                {"81", "\\ROM\\26\\66.DAT"},
                {"82", "\\ROM2\\13\\103.DAT"},
                {"83", "\\ROM\\26\\68.DAT"},
                {"84", "\\ROM\\26\\69.DAT"},
                {"86", "\\ROM2\\13\\104.DAT"},
                {"87", "\\ROM2\\13\\105.DAT"},
                {"88", "\\ROM\\26\\73.DAT"},
                {"89", "\\ROM\\26\\74.DAT"},
                {"8A", "\\ROM\\26\\75.DAT"},
                {"8B", "\\ROM\\26\\76.DAT"},
                {"8C", "\\ROM\\26\\77.DAT"},
                {"8D", "\\ROM\\26\\78.DAT"},
                {"8E", "\\ROM\\26\\79.DAT"},
                {"8F", "\\ROM\\26\\80.DAT"},
                {"90", "\\ROM\\26\\81.DAT"},
                {"91", "\\ROM\\26\\82.DAT"},
                {"92", "\\ROM\\26\\83.DAT"},
                {"93", "\\ROM\\26\\84.DAT"},
                {"94", "\\ROM\\26\\85.DAT"},
                {"95", "\\ROM\\26\\86.DAT"},
                {"96", "\\ROM\\26\\87.DAT"},
                {"97", "\\ROM\\26\\88.DAT"},
                {"98", "\\ROM\\26\\89.DAT"},
                {"99", "\\ROM2\\13\\106.DAT"},
                {"9A", "\\ROM2\\13\\107.DAT"},
                {"9B", "\\ROM\\26\\92.DAT"},
                {"9C", "\\ROM\\26\\93.DAT"},
                {"9D", "\\ROM\\26\\94.DAT"},
                {"9E", "\\ROM\\26\\95.DAT"},
                {"9F", "\\ROM2\\13\\108.DAT"},
                {"A0", "\\ROM2\\13\\109.DAT"},
                {"A1", "\\ROM\\26\\98.DAT"},
                {"A2", "\\ROM\\26\\99.DAT"},
                {"A3", "\\ROM2\\13\\110.DAT"},
                {"A4", "\\ROM\\26\\101.DAT"},
                {"A5", "\\ROM\\26\\102.DAT"},
                {"A6", "\\ROM\\26\\103.DAT"},
                {"A7", "\\ROM\\26\\104.DAT"},
                {"A8", "\\ROM2\\13\\111.DAT"},
                {"A9", "\\ROM\\26\\106.DAT"},
                {"AA", "\\ROM2\\13\\112.DAT"},
                {"AB", "\\ROM\\26\\108.DAT"},
                {"AC", "\\ROM\\26\\109.DAT"},
                {"AD", "\\ROM2\\13\\113.DAT"},
                {"AE", "\\ROM2\\13\\114.DAT"},
                {"AF", "\\ROM\\26\\112.DAT"},
                {"B0", "\\ROM2\\13\\115.DAT"},
                {"B1", "\\ROM2\\13\\116.DAT"},
                {"B2", "\\ROM2\\13\\117.DAT"},
                {"B3", "\\ROM2\\13\\118.DAT"},
                {"B4", "\\ROM2\\13\\119.DAT"},
                {"B5", "\\ROM2\\13\\120.DAT"},
                {"B6", "\\ROM\\26\\119.DAT"},
                {"B7", "\\ROM\\26\\120.DAT"},
                {"B8", "\\ROM\\26\\121.DAT"},
                {"B9", "\\ROM2\\13\\121.DAT"},
                {"BA", "\\ROM2\\13\\122.DAT"},
                {"BB", "\\ROM2\\13\\123.DAT"},
                {"BC", "\\ROM2\\13\\124.DAT"},
                {"BE", "\\ROM\\26\\127.DAT"},
                {"BF", "\\ROM\\27\\0.DAT"},
                {"C0", "\\ROM\\27\\1.DAT"},
                {"C1", "\\ROM\\27\\2.DAT"},
                {"C2", "\\ROM\\27\\3.DAT"},
                {"C3", "\\ROM\\27\\4.DAT"},
                {"C4", "\\ROM\\27\\5.DAT"},
                {"C5", "\\ROM\\27\\6.DAT"},
                {"C6", "\\ROM\\27\\7.DAT"},
                {"C8", "\\ROM\\27\\9.DAT"},
                {"C9", "\\ROM2\\13\\125.DAT"},
                {"CA", "\\ROM2\\13\\126.DAT"},
                {"CB", "\\ROM2\\13\\127.DAT"},
                {"CC", "\\ROM\\27\\13.DAT"},
                {"CD", "\\ROM2\\14\\0.DAT"},
                {"CE", "\\ROM\\27\\13.DAT"},
                {"CF", "\\ROM2\\14\\1.DAT"},
                {"D0", "\\ROM2\\14\\2.DAT"},
                {"D1", "\\ROM2\\14\\3.DAT"},
                {"D3", "\\ROM2\\14\\4.DAT"},
                {"D4", "\\ROM2\\14\\5.DAT"},
                {"D5", "\\ROM2\\14\\6.DAT"},
                {"D6", "\\ROM\\27\\15.DAT"},
                {"D7", "\\ROM\\27\\24.DAT"},
                {"D8", "\\ROM\\27\\25.DAT"},
                {"D9", "\\ROM\\27\\26.DAT"},
                {"DA", "\\ROM\\27\\27.DAT"},
                {"DC", "\\ROM\\27\\29.DAT"},
                {"DD", "\\ROM\\27\\30.DAT"},
                {"DF", "\\ROM\\27\\32.DAT"},
                {"E0", "\\ROM\\27\\33.DAT"},
                {"E1", "\\ROM\\27\\34.DAT"},
                {"E2", "\\ROM2\\14\\7.DAT"},
                {"E3", "\\ROM\\27\\36.DAT"},
                {"E4", "\\ROM\\27\\37.DAT"},
                {"E6", "\\ROM\\27\\39.DAT"},
                {"E7", "\\ROM\\27\\40.DAT"},
                {"E8", "\\ROM\\27\\41.DAT"},
                {"E9", "\\ROM\\27\\42.DAT"},
                {"EA", "\\ROM\\27\\43.DAT"},
                {"EB", "\\ROM\\27\\44.DAT"},
                {"EC", "\\ROM\\27\\45.DAT"},
                {"ED", "\\ROM\\27\\46.DAT"},
                {"EE", "\\ROM\\27\\47.DAT"},
                {"EF", "\\ROM\\27\\48.DAT"},
                {"F0", "\\ROM\\27\\49.DAT"},
                {"F1", "\\ROM\\27\\50.DAT"},
                {"F2", "\\ROM\\27\\51.DAT"},
                {"F3", "\\ROM\\27\\52.DAT"},
                {"F4", "\\ROM\\27\\53.DAT"},
                {"F5", "\\ROM\\27\\54.DAT"},
                {"F6", "\\ROM\\27\\55.DAT"},
                {"F7", "\\ROM2\\14\\8.DAT"},
                {"F8", "\\ROM\\27\\57.DAT"},
                {"F9", "\\ROM\\27\\58.DAT"},
                {"FA", "\\ROM2\\14\\9.DAT"},
                {"FB", "\\ROM2\\14\\10.DAT"},
                {"FC", "\\ROM2\\14\\11.DAT"},
                {"FD", "\\ROM\\27\\62.DAT"},
                {"FE", "\\ROM\\27\\63.DAT"},
                {"FF", "\\ROM\\27\\64.DAT"},
                {"100", "\\ROM9\\6\\45.DAT"},
                {"101", "\\ROM9\\6\\46.DAT"},
                {"102", "\\ROM9\\6\\47.DAT"},
                {"103", "\\ROM9\\6\\48.DAT"},
                {"104", "\\ROM9\\6\\49.DAT"},
                {"105", "\\ROM9\\6\\50.DAT"},
                {"106", "\\ROM9\\6\\51.DAT"},
                {"107", "\\ROM9\\6\\52.DAT"},
                {"108", "\\ROM9\\6\\53.DAT"},
                {"109", "\\ROM9\\6\\54.DAT"},
                {"10A", "\\ROM9\\6\\55.DAT"},
                {"10B", "\\ROM9\\6\\56.DAT"},
                {"10C", "\\ROM9\\6\\57.DAT"},
                {"10D", "\\ROM9\\6\\58.DAT"},
                {"10E", "\\ROM9\\6\\59.DAT"},
                {"10F", "\\ROM9\\6\\60.DAT"},
                {"110", "\\ROM9\\6\\61.DAT"},
                {"111", "\\ROM9\\6\\62.DAT"},
                {"112", "\\ROM9\\6\\63.DAT"},
                {"113", "\\ROM9\\6\\64.DAT"},
                {"114", "\\ROM9\\6\\65.DAT"},
                {"115", "\\ROM9\\6\\66.DAT"},
                {"116", "\\ROM9\\6\\67.DAT"},
                {"117", "\\ROM9\\6\\68.DAT"},
                {"118", "\\ROM9\\6\\69.DAT"},
                {"11B", "\\ROM9\\6\\72.DAT"},
                {"11C", "\\ROM9\\6\\73.DAT"},
                {"120", "\\ROM\\332\\109.DAT"},
                {"121", "\\ROM\\337\\66.DAT"},
            };
            #endregion
            #region variables
            var zone = api.Player.ZoneId;
            var hexs = zone.ToString("X");
            var path = "";
            var xloc = "";

            var list = new ArrayList();
            var tb = new byte[32];
            #endregion

            if (FFXIPath == "")
            {
                foreach (var pm in from p in Process.GetProcessesByName("pol") from ProcessModule pm in p.Modules where pm.ModuleName.ToLower() == "ffximain.dll" select pm)
                {
                    xloc = pm.FileName.Remove(pm.FileName.Length - 13);
                }
                FFXIPath = xloc;

                dats.TryGetValue(hexs, out path);
                xloc = xloc + path;
            }
            else
            {
                dats.TryGetValue(hexs, out path);
                xloc = FFXIPath + path;
            }

            var myStream = new FileStream(xloc, FileMode.Open, FileAccess.Read);

            var size = (int)myStream.Length;
            var buffer = new byte[size];

            int num;
            var sum = 0;
            while ((num = myStream.Read(buffer, sum, size - sum)) > 0)
                sum += num;

            #region populate targets
            for (var x = 0; x < buffer.Length; x = x + 32)
            {
                Buffer.BlockCopy(buffer, x, tb, 0, 32);

                path = Encoding.ASCII.GetString(tb);
                var strg = path.Substring(0, 28);
                var tmp1 = strg;
                var tmp2 = tmp1.Replace(char.ConvertFromUtf32(0), null);

                var exist = list.Contains(tmp2);
                var empty = (tmp2.Length == 0);
                var mobid = tb[28] + ((tb[29] & 15) << 8);
                var waste = notWanted.Contains(tmp2);

                if (!(empty) && x != 0 && !(exist) && !(waste))
                {
                    wantedID.Add(string.Format("{0:X}", mobid), tmp2);
                    if (!wantedNM.ContainsValue(tmp2))
                    {
                        wantedNM.Add(string.Format("{0:X}", mobid), tmp2);
                    }
                }
            }
            #endregion
        }
        private void IdToolStripMenuItemClick(object sender, EventArgs e)
        {
            datsName = false;

            SelectedTargets.Items.Clear();
            TargetList.Items.Clear();

            SelectedTargets.Columns[0].Width = 35;
            TargetList.Columns[0].Width = 35;

            PopulateTargetLists("ID");

            foreach (var entry in wantedID.OrderBy(key => key.Value))
            {
                TargetList.Items.Add(entry.Key).SubItems.Add(entry.Value);
            }
        }
        private void NameListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            datsName = true;
            SelectedTargets.Items.Clear();
            TargetList.Items.Clear();

            SelectedTargets.Columns[0].Width = 0;
            TargetList.Columns[0].Width = 0;

            PopulateTargetLists("NAME");

            foreach (var entry in wantedNM.OrderBy(key => key.Value))
            {
                TargetList.Items.Add(entry.Key).SubItems.Add(entry.Value);
            }
        }
        private void ClearToolStripMenuItemClick(object sender, EventArgs e)
        {
            SelectedTargets.Items.Clear();
        }
        private void ListView2DoubleClick(object sender, EventArgs e)
        {
            if (TargetList.Items.Count <= 0) return;

            var list = new ArrayList();

            if (SelectedTargets.Items.Count < 0) return;

            if (SelectedTargets.Items.Count == 0)
            {
                SelectedTargets.Items.Add(TargetList.FocusedItem.Text).SubItems.Add(TargetList.FocusedItem.SubItems[1].Text);
                list.Add(TargetList.FocusedItem.Text);
            }
            foreach (var item in SelectedTargets.Items.Cast<ListViewItem>().Where(item => !list.Contains(item.Text)))
            {
                list.Add(item.Text);
            }
            if (!list.Contains(TargetList.FocusedItem.Text))
            {
                SelectedTargets.Items.Add(TargetList.FocusedItem.Text).SubItems.Add(TargetList.FocusedItem.SubItems[1].Text);
            }
            var dats = SelectedTargets.Items.Cast<ListViewItem>().ToDictionary(item => item.Text, item => item.SubItems[1].Text);

            SelectedTargets.Items.Clear();
            foreach (var entry in dats.OrderBy(key => key.Value))
            {
                SelectedTargets.Items.Add(entry.Key).SubItems.Add(entry.Value);
            }
        }
        private void ListView1DoubleClick(object sender, EventArgs e)
        {
            if (SelectedTargets.SelectedItems.Count <= 0) return;

            foreach (ListViewItem selected in SelectedTargets.SelectedItems)
            {
                SelectedTargets.Items.Remove(selected);
            }
        }
        private void ListView2KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                SelectedTargets.Items.AddRange((from ListViewItem item in TargetList.SelectedItems
                                                select (ListViewItem)item.Clone()).ToArray());
            }
        }
        #endregion

        #region Function: TargetMoving
        public bool TargetMoving()
        {
            if (TargetInfo.ID <= 0 || TargetInfo.HPP == 0)
                return false;

            var targetLastDistance = TargetInfo.Distance;
            Thread.Sleep(TimeSpan.FromSeconds(1.0));
            var targetCurrentDistance = TargetInfo.Distance;

            if (targetLastDistance == targetCurrentDistance)
                return false;

            return true;
        }
        #endregion

        #region Function: Detect/Attack Aggro

        private void DetectAggro()
        {
            if (!aggro.Checked || PlayerInfo.Status == 1 || isPulled)
                return;

            var searchID = (float)aggroRange.Value;
            var targetID = -1;

            for (var x = 0; x < 2048; x++)
            {
                if (PlayerInfo.Status == 1)
                    return;

                var entity = api.Entity.GetEntity(x);

                if (entity.WarpPointer == 0 || entity.HealthPercent == 0 || entity.TargetID <= 0 ||
                    entity.SpawnFlags != 16)
                    continue;

                if (wantedNM.ContainsValue(entity.Name) && searchID > entity.Distance && entity.Status == 1)
                {
                    searchID = entity.Distance;
                    targetID = (int)entity.TargetID;
                }
            }

            if (targetID == -1)
                return;

            var wanted = api.Entity.GetEntity(targetID);

            if (wanted.ClaimID != 0 || wanted.HealthPercent == 0 ||
                targetID <= 0 || wanted.SpawnFlags != 16) return;

            if (isMoving)
                isMoving = false;

            if (usenav.Checked && naviMove)
                naviMove = false;

            api.AutoFollow.IsAutoFollowing = false;

            if (TargetInfo.ID != targetID)
            {
                TargetInfo.SetTarget(targetID);

                TargetInfo.FaceTarget(TargetInfo.X, TargetInfo.Z);
                Thread.Sleep(TimeSpan.FromSeconds(0.4));
            }

            if (!TargetMoving() || !(wanted.Distance > (float)aggroRange.Value))
            {
                if (wanted.ClaimID == 0 && wanted.HealthPercent != 0 && wanted.TargetID > 0)
                {
                    if (rangeaggro.Checked && pullCommand.Text != "" &&
                        wanted.HealthPercent != 0 && wanted.TargetID > 0)
                    {
                        api.ThirdParty.SendString(pullCommand.Text);

                        var delay = DateTime.Now.AddSeconds((double)pullDelay.Value);

                        while (DateTime.Now < delay)
                        {
                            TargetInfo.FaceTarget(TargetInfo.X, TargetInfo.Z);
                            Thread.Sleep(TimeSpan.FromSeconds(0.1));
                        }
                    }

                    if (!TargetInfo.LockedOn && AutoLock.Checked)
                        api.ThirdParty.SendString("/lockon <t>");

                    if (wanted.ClaimID == PlayerInfo.ServerID ||
                        wanted.ClaimID == 0 && wanted.TargetID > 0)
                    {
                        api.ThirdParty.SendString("/attack <t>");
                        Thread.Sleep(TimeSpan.FromSeconds(4.0));

                        if (PlayerInfo.Status == 0)
                        {
                            api.ThirdParty.SendString("/attack <t>");
                            Thread.Sleep(TimeSpan.FromSeconds(4.0));
                        }
                    }

                }
            }

            if (api.Target.GetTargetInfo().TargetId > 0 && PlayerInfo.Status == 0 &&
                wanted.Distance > (float)aggroRange.Value)
            {
                if (usenav.Checked)
                    naviMove = true;

                api.Target.SetTarget(0);
            }

            if (PlayerInfo.Status == 0 && wanted.ClaimID != api.Player.ServerId)
            {
                api.Target.SetTarget(0);

                if (usenav.Checked)
                    naviMove = true;
            }
        }

        #endregion
        #region Function: Get/Set Target

        public void FindTarget()
        {
            if (SelectedTargets.Items.Count == 0 || PlayerInfo.Status == 1 || isPulled)
                return;

            float searchID = 999;
            var targetID = -1;

            for (var x = 0; x < 2048; x++)
            {
                var entity = api.Entity.GetEntity(x);

                if (entity.WarpPointer == 0 || entity.HealthPercent == 0 || entity.TargetID <= 0 ||
                    entity.SpawnFlags != 16 || entity.ClaimID != 0 || ignoreTarget.Contains((int)entity.TargetID)) continue;

                foreach (ListViewItem item in SelectedTargets.Items)
                {
                    if (item.SubItems[1].Text.Contains(entity.Name) && SelectedTargets.Columns[0].Width == 0 ||
                        (item.Text.Contains(entity.TargetID.ToString("X")) && SelectedTargets.Columns[0].Width == 35))
                    {
                        if (entity.HealthPercent != 0 && entity.Distance <= (float)targetSearchDist.Value)
                        {
                            if (searchID > entity.Distance &&
                                entity.Distance > (float)pullTolorance.Value &&
                                entity.ClaimID == 0 && entity.HealthPercent != 0 &&
                                entity.SpawnFlags == 16)
                            {
                                searchID = entity.Distance;
                                targetID = Convert.ToInt32(entity.TargetID);
                            }
                        }
                    }
                }
            }

            if (targetID == -1)
                return;

            if (isMoving)
                isMoving = false;

            if (usenav.Checked && naviMove)
                naviMove = false;

            while (api.AutoFollow.IsAutoFollowing)
            {
                if (api.AutoFollow.IsAutoFollowing)
                    api.AutoFollow.IsAutoFollowing = false;
            }

            Thread.Sleep(TimeSpan.FromSeconds(0.5));

            var target = api.Entity.GetEntity(targetID);

            if (target.ClaimID != 0 || target.HealthPercent == 0)
                return;

            TargetInfo.SetTarget(targetID);
            Thread.Sleep(TimeSpan.FromSeconds(0.3));

            TargetInfo.FaceTarget(target.X, target.Z);
            Thread.Sleep(TimeSpan.FromSeconds(0.4));

            if (!TargetInfo.LockedOn && AutoLock.Checked)
                WindowInfo.SendText("/lockon <t>");

            if (runPullDistance.Checked && target.TargetID != PlayerInfo.ServerID && target.TargetID != 0)
                TargetDist(1, (int)target.TargetID);

            if (target.ClaimID == 0 && target.HealthPercent != 0 && target.TargetID > 0 &&
                target.Distance <= (float)targetSearchDist.Value && pullCommand.Text != "" &&
                target.Distance > 5)
            {
                var nullCount = 0;
                while (Math.Truncate(target.Distance) <= Math.Truncate((float)targetSearchDist.Value) &&
                       target.ClaimID == 0)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(0.5));
                    WindowInfo.SendText(pullCommand.Text);

                    var delay = DateTime.Now.AddSeconds((double)pullDelay.Value);
                    while (DateTime.Now < delay)
                    {
                        TargetInfo.FaceTarget(TargetInfo.X, TargetInfo.Z);
                        Thread.Sleep(TimeSpan.FromSeconds(0.1));

                        if (target.Distance > (float)targetSearchDist.Value &&
                            target.ClaimID == PlayerInfo.ServerID)
                            break;
                    }
                    nullCount = nullCount + 1;

                    if (nullCount >= 3)
                    {
                        ignoreTarget.Add(TargetInfo.ID);
                        break;
                    }

                    Thread.Sleep(TimeSpan.FromSeconds(0.5));
                }
            }
            else if (target.ClaimID == 0 && target.HealthPercent != 0 && target.TargetID > 0 &&
                     target.Distance <= (float)targetSearchDist.Value && pullCommand.Text == "")
            {
                if (runTarget.Checked && target.TargetID != PlayerInfo.ServerID && target.TargetID != 0)
                    TargetDist(2, (int)target.TargetID);

                TargetInfo.Attack();

                return;
            }
            else if (target.Distance <= 5)
            {
                TargetInfo.Attack();
                return;
            }

            Thread.Sleep(TimeSpan.FromSeconds(0.5));

            if (runTarget.Checked && target.TargetID != PlayerInfo.ServerID && target.TargetID != 0)
                TargetDist(2, (int)target.TargetID);

            if (PlayerInfo.Status == 0 && target.ClaimID == PlayerInfo.ServerID &&
                !ignoreTarget.Contains(TargetInfo.ID))
            {
                TargetInfo.Attack();
            }

            if (PlayerInfo.Status == 0 && target.ClaimID != api.Player.ServerId)
            {
                TargetInfo.SetTarget(0);

                if (usenav.Checked && !naviMove)
                    naviMove = true;
            }
        }

        #endregion

        #endregion
        #region Methods: NAV
        public int FindClosestWayPoint()
        {
            var maxRange = 50.0;
            var outRange = -1;

            for (int i = 0; i < navPathX.Count(); i++)
            {
                var x = Math.Pow(PlayerInfo.X - navPathX[i], 2.0);
                var z = Math.Pow(PlayerInfo.Z - navPathZ[i], 2.0);

                var dist = Math.Sqrt(x + z);
                if (dist < maxRange)
                {
                    maxRange = dist;
                    outRange = i;
                }
            }

            return outRange;
        }
        public void FollowTarget()
        {
            if (!botRunning || !followplayer.Checked || followName.Text == "")
                return;

            var followID = TargetInfo.GetTargetIdByName(followName.Text);
            if (followID == -1)
                return;

            var followed = api.Entity.GetEntity(Convert.ToInt32(followID));

            if (followed.Distance >= (float)followDist.Value && followed.Status == 0)
            {
                if (TargetInfo.ID != followed.TargetID)
                    TargetInfo.SetTarget(followID);

                if (AutoLock.Checked && !TargetInfo.LockedOn)
                    api.ThirdParty.SendString("/lockon <t>");

                isMoving = true;
                while (Math.Truncate(followed.Distance) >= (float)followDist.Value)
                {
                    api.AutoFollow.SetAutoFollowCoords(TargetInfo.X - PlayerInfo.X,
                                                       TargetInfo.Y - PlayerInfo.Y,
                                                       TargetInfo.Z - PlayerInfo.Z);

                    api.AutoFollow.IsAutoFollowing = true;

                    Thread.Sleep(TimeSpan.FromSeconds(0.1));
                }
                api.AutoFollow.IsAutoFollowing = false;
                isMoving = false;
            }
        }
        public void TargetDist(int ID, int TargetID)
        {
            if (TargetID == 0)
                return;

            var entity = api.Entity.GetEntity(TargetID);
            var search = 0;

            if (runPullDistance.Checked && ID == 1 && TargetInfo.ID > 0)
            {
                isMoving = true;
                while (Math.Truncate(entity.Distance) >= (float)numericUpDown21.Value && entity.ClaimID == 0)
                {
                    api.AutoFollow.SetAutoFollowCoords(TargetInfo.X - PlayerInfo.X,
                                                       TargetInfo.Y - PlayerInfo.Y,
                                                       TargetInfo.Z - PlayerInfo.Z);

                    api.AutoFollow.IsAutoFollowing = true;
                    Thread.Sleep(TimeSpan.FromSeconds(0.1));

                    if (TargetInfo.ID == 0 || TargetInfo.ID == PlayerInfo.ServerID)
                        break;

                    if (Math.Abs(entity.Distance - search) < 1)
                    {
                        api.AutoFollow.IsAutoFollowing = false;
                        isMoving = false;
                    }
                }
                api.AutoFollow.IsAutoFollowing = false;
                isMoving = false;
            }
            else if (runTarget.Checked && ID == 2 && TargetInfo.ID > 0)
            {
                var dist = Math.Round(api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).Distance, 1);
                var last = Math.Round(api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).Distance, 1);

                var move = true;
                var time = 15;

                isMoving = true;
                while (Math.Truncate(entity.Distance) >= (float)KeepTargetRange.Value && entity.ClaimID == 0)
                {
                    api.AutoFollow.SetAutoFollowCoords(TargetInfo.X - PlayerInfo.X,
                                                       TargetInfo.Y - PlayerInfo.Y,
                                                       TargetInfo.Z - PlayerInfo.Z);

                    api.AutoFollow.IsAutoFollowing = true;
                    Thread.Sleep(TimeSpan.FromSeconds(0.1));

                    if (TargetInfo.ID == 0 || TargetInfo.ID == PlayerInfo.ServerID)
                        break;

                    dist = Math.Round(api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).Distance, 1);

                    if (Math.Abs(last - dist) < 0.1)
                    {
                        if (move)
                        {
                            move = false;

                            if (time != 15)
                                time = time + 10;

                            for (var x = 0; x < 15; x++)
                            {
                                WindowInfo.KeyPress(API.Keys.NUMPAD2);
                                x++;
                            }
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            for (var x = 0; x < time; x++)
                            {
                                WindowInfo.KeyPress(API.Keys.NUMPAD6);
                                x++;
                            }
                        }
                        else if (!move)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));

                            move = true;
                            if (time == 15)
                                time = time + 10;
                            else
                                time = time + 10;

                            for (var x = 0; x < 15; x++)
                            {
                                WindowInfo.KeyPress(API.Keys.NUMPAD2);
                                x++;
                            }
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            for (var x = 0; x < time; x++)
                            {
                                WindowInfo.KeyPress(API.Keys.NUMPAD4);
                                x++;
                            }
                        }
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    last = Math.Round(api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).Distance, 1);
                }
                api.AutoFollow.IsAutoFollowing = false;
                isMoving = false;
            }

            if (api.AutoFollow.IsAutoFollowing)
                api.AutoFollow.IsAutoFollowing = false;
        }

        public bool isStuck()
        {
            if (TargetInfo.ID <= 0 || TargetInfo.HPP == 0)
                return false;

            var targetLastDistance = TargetInfo.Distance;
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
            var targetCurrentDistance = TargetInfo.Distance;

            if (Math.Abs(targetLastDistance - targetCurrentDistance) < 1)
                return false;

            return true;
        }

        public void ReturnIdleLocation()
        {
            var dist = Math.Truncate(Math.Sqrt(Math.Pow((idleX - PlayerInfo.X), 2) +
                                               Math.Pow((idleY - PlayerInfo.Y), 2)));

            if (IdleLocation.Checked && dist > 1 && PlayerInfo.Status == 0)
            {
                while (dist > 1 && PlayerInfo.Status == 0)
                {
                    dist = Math.Truncate(Math.Sqrt(Math.Pow((idleX - PlayerInfo.X), 2) +
                                                       Math.Pow((idleY - PlayerInfo.Y), 2)));

                    api.AutoFollow.SetAutoFollowCoords(TargetInfo.X - PlayerInfo.X,
                                                       TargetInfo.Y - PlayerInfo.Y,
                                                       TargetInfo.Z - PlayerInfo.Z);

                    api.AutoFollow.IsAutoFollowing = true;
                    Thread.Sleep(TimeSpan.FromSeconds(0.1));
                }
                if (api.AutoFollow.IsAutoFollowing)
                    api.AutoFollow.IsAutoFollowing = false;
            }
        }

        public void OpenNavi(string path)
        {
            var file = new FileInfo(path);
            var ipos = 0;

            using (var sr = file.OpenText())
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var items = line.Split(':');
                    if (items[0] == "WAYPOINT")
                    {
                        Array.Resize(ref navPathX, ipos + 1);
                        Array.Resize(ref navPathZ, ipos + 1);
                        navPathX[ipos] = double.Parse(items[1]);
                        navPathZ[ipos] = double.Parse(items[2]);

                        ipos++;
                    }
                }
            }
        }

        public void OpenRoute(string path)
        {
            var file = new FileInfo(path);
            var ipos = 0;

            using (var sr = file.OpenText())
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var items = line.Split(':');
                    if (items[0] == "WAYPOINT")
                    {
                        navPathX[ipos] = double.Parse(items[1]);
                        navPathZ[ipos] = double.Parse(items[2]);

                        ipos++;
                    }
                }
            }
        }

        private void UsenavCheckedChanged(object sender, EventArgs e)
        {
            if (usenav.Checked)
            {
                groupBox8.Enabled = true;
                runReverse.Enabled = true;

                var path = string.Format("{0}\\Nav\\", Application.StartupPath);

                foreach (var file in Directory.GetFiles(path, "*.xin"))
                {
                    selectedNavi.Items.Add(new FileInfo(file).Name);
                }
            }
            else
            {
                api.AutoFollow.IsAutoFollowing = false;
                naviMove = false;

                selectedNavi.Items.Clear();

                groupBox8.Enabled = false;
                runReverse.Enabled = false;
            }
        }
        private void RefreshToolStripMenuItemClick(object sender, EventArgs e)
        {
            selectedNavi.Items.Clear();

            var path = string.Format("{0}\\Nav\\", Application.StartupPath);
            foreach (var file in Directory.GetFiles(path, "*.xin"))
            {
                selectedNavi.Items.Add(new FileInfo(file).Name);
            }
        }
        private void SelectedNaviSelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedNavi.Text == "") return;

            var path = string.Format("{0}\\Nav\\", Application.StartupPath);
            var navi = new FileInfo(path + selectedNavi.Text);

            if (navi.Exists)
            {
                OpenNavi(navi.ToString());
                OpenRoute(navi.ToString());
            }
        }
        #endregion        

        #region Methods: NAV (new)

        public class WayPoint
        {
            public Zone Zone { get; set; }

            public float X { get; set; }

            public float Y { get; set; }

            public float Z { get; set; }
        }

        public double DistanceTo(int id)
        {
            var entity = api.Entity.GetEntity(id);
            return DistanceTo(entity.X, entity.Y, entity.Z);
        }

        public double DistanceTo(double x, double z) => Math.Abs(x) < .00001 && Math.Abs(z) < .00001 ? 0 : DistanceTo(x, api.Player.Y, z);

        public double DistanceTo(double x, double y, double z) => Math.Sqrt(Math.Pow(api.Player.X - x, 2) +
                                                                            Math.Pow(api.Player.Y - y, 2) +
                                                                            Math.Pow(z - api.Player.Z, 2));

        public int GetIndexOfClosestPoint(int start = 0)
        {
            var distance = double.MaxValue;
            var index = 0;

            for (var i = start; i < route.Count; ++i)
            {
                //if ((Zone)api.Player.ZoneId != route[i].Zone)
                //{
                //    continue;
                //}

                var d = DistanceTo(route[i].X, route[i].Z);
                if (d < distance)
                {
                    distance = d;
                    index = i;
                }
            }

            return distance < 25 ? index : -1;
        }

        #endregion
        #region Methods: EliteMMO

        #region class: PlayerInfo
        public static class PlayerInfo
        {
            public static int Status => (int)api.Entity.GetLocalPlayer().Status;
            public static string Name => api.Party.GetPartyMembers().First().Name;
            public static int HPP => api.Party.GetPartyMembers().First().CurrentHPP;
            public static int MPP => api.Party.GetPartyMembers().First().CurrentMPP;
            public static uint HP => api.Party.GetPartyMembers().First().CurrentHP;
            public static uint MP => api.Party.GetPartyMembers().First().CurrentMP;
            public static int TP => (int)api.Party.GetPartyMembers().First().CurrentTP;
            public static int MainJob => api.Player.GetPlayerInfo().MainJob;
            public static int MainJobLevel => api.Player.GetPlayerInfo().MainJobLevel;
            public static int SubJob => api.Player.GetPlayerInfo().SubJob;
            public static int SubJobLevel => api.Player.GetPlayerInfo().SubJobLevel;
            public static bool HasBuff(short id) => api.Player.GetPlayerInfo().Buffs.Any(b => b == id);
            public static bool HasAbility(uint id) => api.Player.HasAbility(id);
            public static bool HasSpell(uint id) => api.Player.HasSpell(id);
            public static bool HasWeaponSkill(uint id) => api.Player.HasWeaponSkill(id);
            public static int ServerID => (int)api.Entity.GetLocalPlayer().ServerID;
            public static int TargetID => (int)api.Entity.GetLocalPlayer().TargetID;
            public static float X => api.Entity.GetLocalPlayer().X;
            public static float Y => api.Entity.GetLocalPlayer().Y;
            public static float Z => api.Entity.GetLocalPlayer().Z;
            public static float H => api.Entity.GetLocalPlayer().H;
            /* public static string Indi
            {
                get
                {
                    Byte[] bytes = BitConverter.GetBytes(api.Party.GetPartyMembers().First().ID);
                    string pidstr = BitConverter.ToString(bytes);
                    pidstr = System.Text.RegularExpressions.Regex.Replace(pidstr, "-", "");
                    var hppstr = api.Party.GetPartyMembers().First().CurrentHPP.ToString("X2");
                    //MainWindow.PID 
                    var mask = "37??????????????????????????????????????????????????????????????????????" + pidstr + "????" + hppstr;
                    //var x = SigScan.FindPattern()
                    return mask;
                }
            } */
        }
        #endregion
        #region class: TargetInfo
        public static class TargetInfo
        {
            public static void Attack()
            {
                var count = 0;

                while (PlayerInfo.Status == 0)
                {
                    WindowInfo.SendText("/attack <t>");
                    Thread.Sleep(TimeSpan.FromSeconds(3.0));

                    if (PlayerInfo.Status == 1 || count == 2)
                        break;

                    count = count + 1;
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            public static string Name => api.Entity.GetEntity((int) api.Target.GetTargetInfo().TargetIndex).Name;
            public static int ID => (int) api.Entity.GetEntity((int) api.Target.GetTargetInfo().TargetIndex).TargetID;
            public static int HPP => api.Entity.GetEntity((int) api.Target.GetTargetInfo().TargetIndex).HealthPercent;
            public static double Distance => Math.Truncate((10 * api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).Distance) / 10);
            public static bool LockedOn => api.Target.GetTargetInfo().LockedOn;
            public static float X => api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).X;
            public static float Y => api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).Y;
            public static float Z => api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).Z;
            public static float H => api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).H;
            public static void SetTarget(int ID) => api.Target.SetTarget(ID);
            public static int GetTargetIdByName(string name)
            {
                for (var x = 0; x < 2048; x++)
                {
                    var ID = api.Entity.GetEntity(x);

                    if (ID.Name != null && ID.Name.ToLower().Equals(name.ToLower()))
                        return (int) ID.TargetID;
                }
                return -1;
            }
            public static void FaceTarget(float x, float z)
            {
                if (TargetInfo.ID == PlayerInfo.ServerID || TargetInfo.ID == 0)
                    return;

                var p = api.Entity.GetLocalPlayer();
                var angle = (byte)(Math.Atan((z - p.Z) / (x - p.X)) * -(128.0f / Math.PI));

                if (p.X > x)
                    angle += 128;

                var radian = (((float)angle) / 255) * 2 * Math.PI;
                api.Entity.SetEntityHPosition(api.Entity.LocalPlayerIndex, (float)radian);
            }
            public static bool IsFacingTarget(float x1, float z1, float h1, float x2, float z2)
            {
                var angle = GetDifferenceAngle(x1, z1, x2, z2);
                var rotation = ((h1 / (2 * 3.14159265359f)) * 255);
                return Math.Abs((angle - rotation) + -128.0f) < 20;
            }
            private static float GetDifferenceAngle(float x1, float z1, float x2, float z2)
            {
                var angle = Math.Atan((z2 - z1) / (x2 - x1));
                angle *= -(128.0f / 3.14159265359f);
                return (float) (x2 > x1 ? angle + 128 : angle);
            }
        }
        #endregion
        #region class: RecastInfo
        public static class Recast
        {
            public static int GetSpellRecast(int id) => api.Recast.GetSpellRecast(id);
            public static int GetAbilityRecast(int id)
            {
                var IDs = api.Recast.GetAbilityIds();
                for (var x = 0; x < IDs.Count; x++)
                {
                    if (IDs[x] == id)
                        return api.Recast.GetAbilityRecast(x);
                }
                return 0;
            }
        }
        #endregion
        #region class: WindowInfo
        public static class WindowInfo
        {
            public static void SendText(string text) => api.ThirdParty.SendString(text);
            public static void KeyPress(API.Keys key) => api.ThirdParty.KeyPress(key);
            public static void KeyUp(API.Keys key) => api.ThirdParty.KeyUp(key);
            public static void KeyDown(API.Keys key) => api.ThirdParty.KeyDown(key);
        }
        #endregion

        #region class: PartyInfo
        public static class PartyInfo
        {
            public static int Count => api.Party.GetPartyMembers().Count;
        }
        #endregion
        #region class: PetInfo
        public static class PetInfo
        {
            public static string Name
            {
                get
                {
                    var p = api.Entity.GetEntity(api.Entity.GetLocalPlayer().PetIndex).Name;

                    return p != null
                        ? System.Text.RegularExpressions.Regex.Replace(
                            api.Entity.GetEntity(api.Entity.GetLocalPlayer().PetIndex).Name, "([A-Z])", " $1",
                            System.Text.RegularExpressions.RegexOptions.Compiled).Trim()
                        : null;
                }
            }

            public static int ID
            {
                get
                {
                    var p = api.Entity.GetEntity(api.Entity.GetLocalPlayer().PetIndex).ServerID;
                    return (int)api.Entity.GetEntity(api.Entity.GetLocalPlayer().PetIndex).ServerID;
                }
            }

            public static int HPP => api.Entity.GetEntity(api.Entity.GetLocalPlayer().PetIndex).HealthPercent;
            public static int TPP => (int) api.Entity.GetEntity(api.Entity.GetLocalPlayer().PetIndex).PetTP;
            public static int Status => (int) api.Entity.GetEntity(api.Entity.GetLocalPlayer().PetIndex).Status;
        }
        #endregion

        #region class: Inventory

        public static int ItemQuantityByName(string name)
        {
            var count = api.Inventory.GetContainerMaxCount(0);
            var itemc = 0;

            if (items.ContainsValue(name) == false)
                return -1;

            var ID = items.FirstOrDefault(x => x.Value == name).Key;

            for (var x = 0; x < count; x++)
            {
                var item = api.Inventory.GetContainerItem(0, x);

                if (item.Id == Convert.ToInt32(ID))
                {
                    itemc = itemc + (int) item.Count;
                }
            }
            return itemc;
        }

        public static void PopulateItems()
        {
            items.Clear();

            for (var x = 0; x < 32767; x++)
            {
                var i = api.Resources.GetItem((uint)x);

                if (!string.IsNullOrEmpty(i?.Name))
                    items.Add(i.ItemID.ToString(), i.Name);
            }
        }

        #endregion

        #endregion

        private TabPage MAconfigpage;
        private CheckBox MAreverse;
        private Label label13;
        private Label label10;
    }
}
