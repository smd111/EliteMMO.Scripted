namespace EliteMMO.Scripted.Views
{
    using API;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using System.Xml;
    public partial class MainWindow : Form
    {
        public static ScriptFarmDNC farmbot;
        public static ScriptNaviMap navbot;
        public static ScriptOnEventTool oneventbot;
        public static ScriptSkillup skillupbot;

        [DllImport("kernel32")]
        static extern bool CreateSymbolicLink(string lpSymlinkFileName, string lpTargetFileName, SymbolicLink dwFlags);
        enum SymbolicLink
        {
            File = 0,
            Directory = 1,
        }
        public MainWindow(EliteAPI core)
        {
            InitializeComponent();
            api = core;
            #region Final Fantasy XI [POL]
            var data = Process.GetProcessesByName("pol");

            if (data.Count() != 0)
            {
                var proc = Process.GetProcessesByName("pol").First().Id;
                api = new EliteAPI(proc);

                foreach (var dats in data)
                {
                    EliteMMO_PROC?.Items.Add(dats.MainWindowTitle);
                }

                if (EliteMMO_PROC != null)
                    EliteMMO_PROC.SelectedIndex = 0;

                xStatusLabel.Text = @":: " + api.Entity.GetLocalPlayer().Name + @" ::";
            }
            else
            {
                xStatusLabel.Text = @":: Final Fantasy Not Found ::";
            }
            if (TESTMODE)
                xStatusLabel.Text = xStatusLabel.Text + @"- TEST MODE ENABLED";
            #endregion

            farmbot = new ScriptFarmDNC(api);
            x1 = farmbot;
            x2 = new ScriptHealing(api);
            navbot = new ScriptNaviMap(api);
            x3 = navbot;
            oneventbot = new ScriptOnEventTool(api);
            x4 = oneventbot;
            skillupbot = new ScriptSkillup(api);
            x5 = skillupbot;

            string apidll = "";
            string mmodll = "";
            if (File.Exists(Application.StartupPath + @"\EliteAPI.dll"))
                apidll = (FileVersionInfo.GetVersionInfo(Application.StartupPath + @"\EliteAPI.dll").FileVersion ?? "");
            if (File.Exists(Application.StartupPath + @"\EliteMMO.API.dll"))
                mmodll = (FileVersionInfo.GetVersionInfo(Application.StartupPath + @"\EliteMMO.API.dll").FileVersion ?? "");
            string memmo = "";
            if (apidll == "" || GetStringFromUrl("http://ext.elitemmonetwork.com/downloads/eliteapi/index.php?v") != apidll)
            {
                memmo = "\nEliteAPI.dll";
            }
            if (mmodll == "" || GetStringFromUrl("http://ext.elitemmonetwork.com/downloads/elitemmo_api/index.php?v") != mmodll)
            {
                memmo = "\nEliteMMO.API.dll";
            }
            if (memmo != "")
                MessageBox.Show("You Need To Update" + memmo + "\nThen Restart Scripted", "!UPDATE NEEDED!");
            var symbolicLink = "";
            if (windowername == "Ashita")
                symbolicLink = dlllocation + @"\Scripts\Addons\ScriptedExtender";
            else if (windowername == "Windower")
                symbolicLink = dlllocation + @"\addons\ScriptedExtender";
            if (symbolicLink != "" && !System.IO.Directory.Exists(symbolicLink))
                CreateSymbolicLink(symbolicLink, Application.StartupPath + @"\ScriptedExtender", SymbolicLink.Directory);
            if (TESTMODE)
                farmbot.enableTestmode();
        }
        private string GetStringFromUrl(string location)
        {
            WebRequest request = WebRequest.Create(location);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            return responseFromServer;
        }
        private void RefreshCharactersToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            var data = Process.GetProcessesByName("pol");
            var node = EliteMMO_PROC.SelectedIndex;

            if (data.Count() <= EliteMMO_PROC.Items.Count && data.Count() >= EliteMMO_PROC.Items.Count) return;

            var count = data.Count();
            if (count != 0)
            {
                //EliteMMO_PROC.Items.Clear();
                foreach (var dats in data.Where(dats => EliteMMO_PROC.Contains(new Control(dats.MainWindowTitle)) == false))
                {
                    EliteMMO_PROC.Items.Add(dats.MainWindowTitle);
                }
                EliteMMO_PROC.SelectedIndex = node;
            }
            else
            {
                if (EliteMMO_PROC.Items.Count != 0)
                    EliteMMO_PROC.Items.Clear();
            }
        }
        private void EliteMmoProcSelectedIndexChanged(object sender, System.EventArgs e)
        {
            var data = Process.GetProcessesByName("pol");

            if (!data.Any()) return;

            foreach (var dats in data.Where(dats => EliteMMO_PROC.Text == dats.MainWindowTitle))
            {
                bool initialized = api.Reinitialize(dats.Id);
                xStatusLabel.Text = @":: " + api.Entity.GetLocalPlayer().Name + @" ::";
                if (TESTMODE)
                    xStatusLabel.Text = xStatusLabel.Text+@"- TEST MODE ENABLED";
                if (initialized)
                {
                    for (int i = 0; i < dats.Modules.Count; i++)
                    {
                        if (dats.Modules[i].FileName.Contains("Ashita.dll"))
                        {
                            windowername = "Ashita";
                            dlllocation = dats.Modules[i].FileName.Replace(@"\Ashita.dll", "");
                        }
                        else if (dats.Modules[i].FileName.Contains("Hook.dll"))
                        {
                            windowername = "Windower";
                            dlllocation = dats.Modules[i].FileName.Replace(@"\Hook.dll", "");
                        }
                    }
                }
            }
        }
        private void FarmDncToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            if (xStatusLabel.Text.Contains(@":: Final Fantasy Not Found ::")) return;


            if (navbot.isRunning)
            {   
                string message = "The NavBot is currently running are\nyou sure you want to swith to the\nFarmBot?\n\nThis will stop your nav from runnind.";
                string caption = "Switching to NavBot";
                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    navbot.StopToolStripMenuItem.PerformClick();
                }
                else
                    return;

            }

            //if (InventoryItems.items.Count == 0)
            //    InventoryItems.PopulateItems();

            #region show/hide objects
            xpic.Hide();
            header1.Hide();
            header2.Hide();
            header3.Hide();
            header4.Hide();
            header5.Hide();
            label1.Hide();
            //button1.Hide();
            EliteMMO_PROC.Hide();

            x4.Hide();
            x3.Hide();
            x2.Hide();
            x5.Hide();
            x1.Show();
            loadSettingsToolStripMenuItem.Enabled = true;
            saveSettingsToolStripMenuItem.Enabled = true;
            #endregion

            TopMostDisplay = "FarmBot"; ;
            farmbot.currentbot = "FarmBot";
            refreshCharactersToolStripMenuItem.Enabled = false;
            
            x1.AutoSize = true;
            x1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            x1.Dock = DockStyle.Fill;
            Controls.Add(x1);
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Dock = DockStyle.Fill;
            if (!farmbot.bgw_script_disp.IsBusy)
                farmbot.bgw_script_disp.RunWorkerAsync();
            if (windowername == "Ashita")
            {
                api.ThirdParty.SendString("/addon load ScriptedExtender");
                extenderactive = true;
            }
            else if (windowername == "Windower")
            {
                api.ThirdParty.SendString("//lua load ScriptedExtender");
                extenderactive = true;
            }
            /*api.ThirdParty.SetText("ScriptedHUD", "Scripted:FarmBot");
            api.ThirdParty.FlushCommands();*/
        }
        private void HealingSupportToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            if (xStatusLabel.Text.Contains(@":: Final Fantasy Not Found ::") && !TESTMODE) return;

            #region show/hide objects
            xpic.Hide();
            header1.Hide();
            header2.Hide();
            header3.Hide();
            header4.Hide();
            header5.Hide();
            label1.Hide();
            //button1.Hide();
            EliteMMO_PROC.Hide();

            x4.Hide();
            x3.Hide();
            x1.Hide();
            x5.Hide();
            x2.Show();
            loadSettingsToolStripMenuItem.Enabled = false;
            saveSettingsToolStripMenuItem.Enabled = false;
            #endregion

            TopMostDisplay = "HealingBot";
            farmbot.currentbot = "HealingBot";
            refreshCharactersToolStripMenuItem.Enabled = false;

            x2.AutoSize = true;
            x2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            x2.Dock = DockStyle.Fill;
            Controls.Add(x2);
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            /*api.ThirdParty.SetText("ScriptedHUD", "Scripted:HealingBot");
            api.ThirdParty.FlushCommands();*/
        }
        private void AboutToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            MessageBox.Show("A Farming/Navigaion/On-event bot\nCreated by: Cmalo/vicrelant\nUpdated by: SMD111\nFor use on FFXI\nRequires: Windower or Ashita\n\nPlease read the Manual for more info.","About");
        }
        private void CloseExitToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            close();
        }
        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            close();
        }
        private void navigationToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (xStatusLabel.Text.Contains(@":: Final Fantasy Not Found ::") && !TESTMODE) return;

            if (farmbot.botRunning)
            {
                string message = "The FarmBot is currently running\nare you sure you want to swith\nto the NavBot?\n\nThis will stop the farmbot.";
                string caption = "Switching to FarmBot";
                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    farmbot.stopScriptToolStripMenuItem.PerformClick();
                }
                else
                    return;

            }
            #region show/hide objects
            xpic.Hide();
            header1.Hide();
            header2.Hide();
            header3.Hide();
            header4.Hide();
            header5.Hide();
            label1.Hide();
            //button1.Hide();
            EliteMMO_PROC.Hide();

            x2.Hide();
            x1.Hide();
            x4.Hide();
            x5.Hide();
            x3.Show();
            loadSettingsToolStripMenuItem.Enabled = false;
            saveSettingsToolStripMenuItem.Enabled = false;
            #endregion

            TopMostDisplay = "NavBot";
            farmbot.currentbot = "NavBot";
            refreshCharactersToolStripMenuItem.Enabled = false;
            
            x3.AutoSize = true;
            x3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            x3.Dock = DockStyle.Fill;
            Controls.Add(x3);
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            if (farmbot.botRunning) farmbot.stopScriptToolStripMenuItem.PerformClick();
            //if (farmbot.bgw_script_disp.IsBusy) farmbot.bgw_script_disp.CancelAsync();
            /*api.ThirdParty.SetText("ScriptedHUD", "Scripted:NavBot");
            api.ThirdParty.FlushCommands();*/
        }
        private void OnEventToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (xStatusLabel.Text.Contains(@":: Final Fantasy Not Found ::") && !TESTMODE) return;

            #region show/hide objects
            xpic.Hide();
            header1.Hide();
            header2.Hide();
            header3.Hide();
            header4.Hide();
            header5.Hide();
            label1.Hide();
            //button1.Hide();
            EliteMMO_PROC.Hide();

            x2.Hide();
            x1.Hide();
            x3.Hide();
            x4.Show();
            x5.Hide();
            loadSettingsToolStripMenuItem.Enabled = false;
            saveSettingsToolStripMenuItem.Enabled = false;
            #endregion

            TopMostDisplay = "OnEventBot";
            farmbot.currentbot = "OnEventBot";
            refreshCharactersToolStripMenuItem.Enabled = false;
            
            x4.AutoSize = true;
            x4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            x4.Dock = DockStyle.Fill;
            Controls.Add(x4);
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            /*api.ThirdParty.SetText("ScriptedHUD", "Scripted:OnEventBot");
            api.ThirdParty.FlushCommands();*/
        }
        private void saveSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TopMostDisplay == "FarmBot")
                farmbot.SaveFarmSettings();
        }
        private void loadSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TopMostDisplay == "FarmBot")
                farmbot.LoadFarmSettings();
        }
        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + @"\Scripted Manual.pdf");
        }
        private void close()
        {
            if (farmbot.hudshow)
            {
                api.ThirdParty.DeleteTextObject("ScriptedHUD");
                api.ThirdParty.FlushCommands();
            }
            if (farmbot.bgw_script_disp.IsBusy)
                farmbot.bgw_script_disp.CancelAsync();
            if (extenderactive)
            {
                if (windowername == "Ashita")
                    api.ThirdParty.SendString("/addon unload ScriptedExtender");
                else if (windowername == "Windower")
                    api.ThirdParty.SendString("//lua unload ScriptedExtender");
            }
            Application.Exit();
        }
        private void skillupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (xStatusLabel.Text == @":: Final Fantasy Not Found ::") return;

            #region show/hide objects
            xpic.Hide();
            header1.Hide();
            header2.Hide();
            header3.Hide();
            header4.Hide();
            header5.Hide();
            label1.Hide();
            //button1.Hide();
            EliteMMO_PROC.Hide();

            x2.Hide();
            x1.Hide();
            x3.Hide();
            x4.Hide();
            x5.Show();
            loadSettingsToolStripMenuItem.Enabled = false;
            saveSettingsToolStripMenuItem.Enabled = false;
            #endregion

            TopMostDisplay = "SkillUp";
            farmbot.currentbot = "SkillUp";
            refreshCharactersToolStripMenuItem.Enabled = false;

            x5.AutoSize = true;
            x5.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            x5.Dock = DockStyle.Fill;
            Controls.Add(x5);
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            /*api.ThirdParty.SetText("ScriptedHUD", "Scripted:SkillUpBot");
            api.ThirdParty.FlushCommands();*/
        }
        private void releasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            api.ThirdParty.KeyUp(API.Keys.NUMPAD8);
            api.ThirdParty.KeyUp(API.Keys.RETURN);
            api.ThirdParty.KeyUp(API.Keys.NUMPAD2);
            api.ThirdParty.KeyUp(API.Keys.NUMPADENTER);
            api.ThirdParty.KeyUp(API.Keys.NUMPAD6);
            api.ThirdParty.KeyUp(API.Keys.NUMPAD4);
            api.ThirdParty.KeyUp(API.Keys.RIGHT);
            api.AutoFollow.IsAutoFollowing = false;
        }

        private void xStatusLabel_Changed(object sender, EventArgs e)
        {
            STATUS = xStatusLabel.Text;
        }
    }
}
