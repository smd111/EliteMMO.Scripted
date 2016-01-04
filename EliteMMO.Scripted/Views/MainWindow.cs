namespace EliteMMO.Scripted.Views
{
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Linq;
    using System.Drawing;
    using API;
    using System.IO;
    using System.Net;
    using System;
    using System.Text.RegularExpressions;
    public partial class MainWindow : Form
    {
        ScriptFarmDNC farmbot;
        ScriptNaviMap navbot;
        public MainWindow(EliteAPI core)
        {
            InitializeComponent();
            api = core;
            Text = $"Scripted - (open source ßeta v{Application.ProductVersion})";
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
            #endregion

            farmbot = new ScriptFarmDNC(api);
            x1 = farmbot;
            x2 = new ScriptHealing(api);
            navbot = new ScriptNaviMap(api);
            x3 = navbot;
            x4 = new ScriptOnEventTool(api);

            string apidll = FileVersionInfo.GetVersionInfo(Application.StartupPath + @"\EliteAPI.dll").FileVersion;
            string mmodll = FileVersionInfo.GetVersionInfo(Application.StartupPath + @"\EliteMMO.API.dll").FileVersion;
            string appexe = FileVersionInfo.GetVersionInfo(Application.StartupPath + @"\Scripted.exe").FileVersion;
            string message = "";
            if (GetStringFromUrl("http://ext.elitemmonetwork.com/downloads/eliteapi/index.php?v") != apidll) message = message + "\nEliteAPI.dll";
            if (GetStringFromUrl("http://ext.elitemmonetwork.com/downloads/elitemmo_api/index.php?v") != mmodll) message = message + "\nEliteMMO.API.dll";
            if (Regex.Replace(GetStringFromUrl("https://raw.githubusercontent.com/smd111/EliteMMO.Scripted/master/EliteMMO.Scripted/ScriptedVer.txt"), @"\t|\n|\r", "") != appexe) message = message + "\nScripted";

            DialogResult result;
            if (message != "") result = MessageBox.Show("Update Files:" + message, "Update Files", MessageBoxButtons.YesNo);
            else result = DialogResult.No;
            if (result == DialogResult.Yes)
            {
                string updateexe = FileVersionInfo.GetVersionInfo(Application.StartupPath + @"\Updater.exe").FileVersion;
                if (GetStringFromUrl("https://raw.githubusercontent.com/smd111/EliteMMO.Scripted/master/Scriptedupdater/UpdaterVer.txt").Replace("\n", "") != updateexe)
                {
                    WebClient Client = new WebClient();
                    Client.DownloadFile("http://github.com/smd111/EliteMMO.Scripted/blob/master/Scriptedupdater/bin/Release/Updater.exe?raw=true", Application.StartupPath + @"\Updater.exe");
                    Client.Dispose();
                }
                Process.Start(Application.StartupPath + @"\Updater.exe");
                Environment.Exit(0);
            }
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
                api.Reinitialize(dats.Id);
                xStatusLabel.Text = @":: " + api.Entity.GetLocalPlayer().Name + @" ::";
            }
        }

        private void FarmDncToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            if (xStatusLabel.Text == @":: Final Fantasy Not Found ::") return;


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
            x1.Show();
            loadSettingsToolStripMenuItem.Enabled = true;
            saveSettingsToolStripMenuItem.Enabled = true;
            #endregion

            TopMostDisplay = "FarmBot";
            refreshCharactersToolStripMenuItem.Enabled = false;

            x1.Dock = DockStyle.Fill;
            Controls.Add(x1);
            Size = new Size(734, 468);
        }

        private void HealingSupportToolStripMenuItemClick(object sender, System.EventArgs e)
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

            x4.Hide();
            x3.Hide();
            x1.Hide();
            x2.Show();
            loadSettingsToolStripMenuItem.Enabled = false;
            saveSettingsToolStripMenuItem.Enabled = false;
            #endregion

            TopMostDisplay = "HealingBot";
            refreshCharactersToolStripMenuItem.Enabled = false;

            x1.Dock = DockStyle.Fill;
            Controls.Add(x2);
            Size = new Size(474, 435);
        }

        private void AboutToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            #region show/hide objects
            xpic.Show();
            header1.Show();
            header2.Show();
            header3.Show();
            header4.Show();
            header5.Show();
            label1.Show();
            //button1.Show();
            EliteMMO_PROC.Show();

            x4.Hide();
            x3.Hide();
            x2.Hide();
            x1.Hide();
            loadSettingsToolStripMenuItem.Enabled = false;
            saveSettingsToolStripMenuItem.Enabled = false;
            #endregion

            TopMostDisplay = "About";
            refreshCharactersToolStripMenuItem.Enabled = true;

            Size = new Size(372, 237);
        }

        private void CloseExitToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void navigationToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (xStatusLabel.Text == @":: Final Fantasy Not Found ::") return;

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
            x3.Show();
            loadSettingsToolStripMenuItem.Enabled = false;
            saveSettingsToolStripMenuItem.Enabled = false;
            #endregion

            TopMostDisplay = "NavBot";
            refreshCharactersToolStripMenuItem.Enabled = false;

            x3.Dock = DockStyle.Fill;
            Controls.Add(x3);
            Size = new Size(575, 400);
            if (farmbot.botRunning) farmbot.stopScriptToolStripMenuItem.PerformClick();
        }

        private void OnEventToolStripMenuItemClick(object sender, EventArgs e)
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
            x4.Show();
            loadSettingsToolStripMenuItem.Enabled = false;
            saveSettingsToolStripMenuItem.Enabled = false;
            #endregion

            TopMostDisplay = "OnEventBot";
            refreshCharactersToolStripMenuItem.Enabled = false;

            x4.Dock = DockStyle.Fill;
            Controls.Add(x4);
            Size = new Size(482, 488);
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
    }
}
