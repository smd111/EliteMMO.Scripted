namespace EliteMMO.Scripted.Views
{
    using API;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;
    public partial class ScriptNaviMap : UserControl
    {
        public ScriptNaviMap(EliteAPI core)
        {
            InitializeComponent();
            api = core;
        }
        private void BgwNaviDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int count = 0;
            float dir = -90;
            while (isRunning || !bgw_navi.CancellationPending)
            {
                if (isRecording)
                {
                    var last = (string)WayPoints.Items[WayPoints.Items.Count - 1];
                    var items = last.Split(':');
                    var distance = (Math.Sqrt(Math.Pow(Math.Abs(ScriptFarmDNC.PlayerInfo.X - float.Parse(items[1])), 2) + Math.Pow(Math.Abs(ScriptFarmDNC.PlayerInfo.Y - float.Parse(items[3])), 2) + Math.Pow(Math.Abs(ScriptFarmDNC.PlayerInfo.Z - float.Parse(items[2])), 2)));
                    if (distance > (double)NodeDist.Value)
                    {
                        if (ScriptFarmDNC.PlayerInfo.X == 0 && ScriptFarmDNC.PlayerInfo.Y == 0 && ScriptFarmDNC.PlayerInfo.Z == 0)
                        {
                            WayPoints.Items.Add($"WAYPOINT:{ScriptFarmDNC.PlayerInfo.X}:{ScriptFarmDNC.PlayerInfo.Z}:{ScriptFarmDNC.PlayerInfo.Y}:Zoning;{lastH}");
                        }
                        else
                        {
                            lastH = ScriptFarmDNC.PlayerInfo.H;
                            WayPoints.Items.Add($"WAYPOINT:{ScriptFarmDNC.PlayerInfo.X}:{ScriptFarmDNC.PlayerInfo.Z}:{ScriptFarmDNC.PlayerInfo.Y}");
                        }
                    }
                }
                if (isPlaying)
                {
                    if (comboBox2.Text != "" && ScriptFarmDNC.PlayerInfo.Status == 0 && !isPaused)
                    {
                        var closestWayPoint = FindClosestWayPoint();
                        if (runReverse.Checked)
                        {
                            closestWayPoint--;
                            if (closestWayPoint < 0)
                            {
                                if(StopAtEnd.Checked)
                                    StopToolStripMenuItem_Click(null, null);
                                else if (Linear.Checked)
                                {
                                    closestWayPoint = 1;
                                    runReverse.Checked = false;
                                }
                                else
                                {
                                    closestWayPoint = (navPathX.Count() - 1);
                                }
                            }
                        }
                        else
                        {
                            closestWayPoint++;
                            if (closestWayPoint >= navPathX.Count())
                            {
                                if (StopAtEnd.Checked)
                                    StopToolStripMenuItem_Click(null, null);
                                else if (Linear.Checked)
                                {
                                    closestWayPoint -= 2;
                                    runReverse.Checked = true;
                                }
                                else
                                {
                                    closestWayPoint = 0;
                                }
                            }
                        }
                        if (firstPersonView.Checked || navPathfirst[closestWayPoint])
                        {
                            if (api.Player.ViewMode != 1)
                                api.Player.ViewMode = 1;
                            api.AutoFollow.IsAutoFollowing = false;
                            api.Entity.GetLocalPlayer().H = (float)((Math.PI / 180) *
                                (ScriptFarmDNC.PlayerInfo.GetAngleFrom(navPathX[closestWayPoint], navPathZ[closestWayPoint]) - 180));
                        }
                        else if (api.Player.ViewMode == 1)
                            api.Player.ViewMode = 0;

                        api.AutoFollow.SetAutoFollowCoords((float)navPathX[closestWayPoint] - ScriptFarmDNC.PlayerInfo.X,
                          ((navPathY[closestWayPoint] == 0) ? 0 : (float)navPathY[closestWayPoint] - ScriptFarmDNC.PlayerInfo.Y),
                          (float)navPathZ[closestWayPoint] - ScriptFarmDNC.PlayerInfo.Z);

                        //if (navPathpause[closestWayPoint].Contains("Pause"))
                        //{
                        //    //Do Nothing
                        //    //var items = navPathpause[closestWayPoint].Split(';');
                        //    //Thread.Sleep(TimeSpan.FromSeconds(int.Parse(items[1])));
                        //}
                        if (navPathdoor[closestWayPoint].Contains("Door"))
                        {
                            CheckDoor(closestWayPoint);
                        }

                        if (navPathzone[closestWayPoint].Contains("Zoning"))
                        {
                            api.AutoFollow.IsAutoFollowing = false;
                            var items = navPathzone[closestWayPoint].Split(';');
                            api.Player.ViewMode = 1;
                            if (runReverse.Checked)
                                api.Entity.GetLocalPlayer().H = (float)(double.Parse(items[1])+Math.PI);
                            else
                                api.Entity.GetLocalPlayer().H = float.Parse(items[1]);
                            api.ThirdParty.KeyDown(API.Keys.NUMPAD8);
                            Thread.Sleep(TimeSpan.FromSeconds(8));
                            api.ThirdParty.KeyUp(API.Keys.NUMPAD8);

                        }
                        else lastcommandtarget = "";

                        api.AutoFollow.IsAutoFollowing = true;
                    }

                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    if (StuckWatch.Checked && comboBox2.Text != "" && api.AutoFollow.IsAutoFollowing && !isPaused && isStuck(0))
                    {
                        api.AutoFollow.IsAutoFollowing = false;
                        api.Player.H = ScriptFarmDNC.PlayerInfo.H + (float)((Math.PI / 180) * dir);
                        api.ThirdParty.KeyDown(API.Keys.NUMPAD8);
                        Thread.Sleep(TimeSpan.FromSeconds(2));
                        api.ThirdParty.KeyUp(API.Keys.NUMPAD8);
                        count++;
                        if (count == 5)
                        {
                            dir = (dir == -90 ? 90 : -90);
                            count = 0;
                        }
                    }
                    if (SpectralJig.Checked && !ScriptFarmDNC.PlayerInfo.HasBuff(69))
                    {
                        api.AutoFollow.IsAutoFollowing = false;
                        api.ThirdParty.SendString("/ja \"Spectral Jig\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                        api.AutoFollow.IsAutoFollowing = true;
                    }
                }

                Thread.Sleep(TimeSpan.FromSeconds(0.1));
            }
        }
        public void CheckDoor(int navid)
        {
            var items = navPathdoor[navid].Split(';');
            if (lastcommandtarget != items[1])
            {
                api.AutoFollow.IsAutoFollowing = false;
                OpenDoor = true;
                ScriptFarmDNC.TargetInfo.SetTarget(int.Parse(items[1]));
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                api.ThirdParty.SendString("/lockon <t>");
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                while (ScriptFarmDNC.TargetInfo.Distance > 4)
                {
                    api.ThirdParty.KeyDown(API.Keys.NUMPAD8);
                    Thread.Sleep(TimeSpan.FromSeconds(0.1));
                }

                api.ThirdParty.KeyUp(API.Keys.NUMPAD8);
                while (ScriptFarmDNC.TargetInfo.ID == int.Parse(items[1]))
                {
                    api.ThirdParty.KeyPress(API.Keys.NUMPADENTER);
                    Thread.Sleep(TimeSpan.FromSeconds(0.5));
                }
                lastcommandtarget = items[1];
                OpenDoor = false;
            }
        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool exists = System.IO.Directory.Exists(Application.StartupPath + @"\nav");
            if (!exists) System.IO.Directory.CreateDirectory(Application.StartupPath + @"\nav");
            var saveFile = new SaveFileDialog();
            if (EnableForceSave.Checked)
            {
                if (ForceCircular.Checked)
                    saveFile.Filter = @"nav file (*.xin)|*.Circular.xin";
                if (ForceLinear.Checked)
                    saveFile.Filter = @"nav file (*.xin)|*.Linear.xin";
                saveFile.SupportMultiDottedExtensions = true;
            }
            else saveFile.Filter = @"nav file (*.xin)|*.xin";
            saveFile.InitialDirectory = Application.StartupPath + @"\nav";
            saveFile.Title = @"Save your nav file";
            switch (saveFile.ShowDialog())
            {
                case DialogResult.OK:
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(saveFile.FileName))
                    {
                        foreach (string waypoint in WayPoints.Items)
                        {
                            file.WriteLine(waypoint);
                        }
                    }
                    break;
            }
        }
        public void OpenNavi(string path)
        {
            var file = new FileInfo(path);
            var ipos = 0;

            if (WayPoints.Items.Count > 0)
                WayPoints.Items.Clear();
            using (var sr = file.OpenText())
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    WayPoints.Items.Add(line);
                    var items = line.Split(':');
                    if (items[0] == "WAYPOINT")
                    {
                        Array.Resize(ref navPathX, ipos + 1);
                        Array.Resize(ref navPathZ, ipos + 1);
                        Array.Resize(ref navPathY, ipos + 1);
                        Array.Resize(ref navPathfirst, ipos + 1);
                        Array.Resize(ref navPathdoor, ipos + 1);
                        Array.Resize(ref navPathzone, ipos + 1);
                        Array.Resize(ref navPathpause, ipos + 1);
                        navPathX[ipos] = double.Parse(items[1]);
                        navPathZ[ipos] = double.Parse(items[2]);
                        navPathY[ipos] = ((items.Length == 3) ? 0 : double.Parse(items[3]));
                        navPathfirst[ipos] = false;
                        navPathdoor[ipos] = "";
                        navPathzone[ipos] = "";
                        navPathpause[ipos] = "";
                        if (items.Length > 4)
                        {
                            for (int i = 4; i <= (items.Length -1); i++)
                            {
                                if (items[i] == "First")
                                    navPathfirst[ipos] = true;
                                if (items[i].Contains("Door"))
                                    navPathdoor[ipos] = items[i];
                                if (items[i].Contains("Zoning"))
                                    navPathzone[ipos] = items[i];
                                //if (items[i].Contains("Pause"))
                                //    navPathpause[ipos] = items[i];
                            }
                        }

                        ipos++;
                    }
                }
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "") return;
            if (comboBox2.Text.Contains(".Linear.")) Linear.Checked = true;
            else if (comboBox2.Text.Contains(".Circular.")) Circular.Checked = true;
            var path = string.Format("{0}\\Nav\\", Application.StartupPath);
            var navi = new FileInfo(path + comboBox2.Text);

            if (navi.Exists)
            {
                OpenNavi(navi.ToString());
            }
        }
        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            var path = string.Format("{0}\\Nav\\", Application.StartupPath);
            foreach (var file in Directory.GetFiles(path, "*.xin"))
            {
                if (!comboBox2.Items.Contains(new FileInfo(file).Name)) comboBox2.Items.Add(new FileInfo(file).Name);
            }
        }
        private void First_Click(object sender, EventArgs e)
        {
            if (WayPoints.SelectedIndex == -1) return;
            var run = true;
            while (WayPoints.SelectedIndices.Count >= 1 && run)
            {
                for (var x = 0; x < WayPoints.SelectedIndices.Count; x++)
                {
                    var index = WayPoints.SelectedIndices[x];
                    var old = (string)WayPoints.Items[index];
                    if (old.Split(':').Length < 4)
                    {
                        MessageBox.Show("Can't add First Person Command to old nav Files.\nPlease convert first.");
                        run = false;
                        break;
                    }
                    WayPoints.Items.RemoveAt(index);
                    WayPoints.Items.Insert(index, old + ":First");

                }
            }
        }
        private void ConvertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WayPoints.Items.Count > 3)
            {
                MessageBox.Show("This nav file does not need to be converted.");
                return;
            }
            for (int i = 0; i <= (WayPoints.Items.Count - 1); i++)
            {
                var old = WayPoints.Items[i];
                WayPoints.Items.RemoveAt(i);
                WayPoints.Items.Insert(i, old + ":0");
            } 
        }
        private void Door_Click(object sender, EventArgs e)
        {
            var index = WayPoints.SelectedIndex;
            if (index == -1)
            {
                if (MainWindow.TESTMODE && MainWindow.STATUS.Contains(@":: Final Fantasy Not Found ::"))
                {
                    WayPoints.Items.Add($"WAYPOINT:{0}:{0}:{0}:Door;{"test"}");
                }
                else
                    WayPoints.Items.Add($"WAYPOINT:{ScriptFarmDNC.PlayerInfo.X}:{ScriptFarmDNC.PlayerInfo.Z}:{ScriptFarmDNC.PlayerInfo.Y}:Door;{ScriptFarmDNC.TargetInfo.ID}");
            }
            else
            {
                var old = (string)WayPoints.Items[index];
                if (old.Split(':').Length < 4)
                {
                    MessageBox.Show("Can't add Door Command to old nav Files.\nPlease convert first.");
                    return;
                }
                WayPoints.Items.RemoveAt(index);
                WayPoints.Items.Insert(index, old + $":Door;{ScriptFarmDNC.TargetInfo.ID}");
            }
        }
        private void removeNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WayPoints.SelectedIndex == -1)
                WayPoints.Items.RemoveAt(WayPoints.Items.Count - 1);
            else
            {
                while (WayPoints.SelectedIndices.Count >= 1)
                {
                    for (var x = 0; x < WayPoints.SelectedIndices.Count; x++)
                    {
                        var index = WayPoints.SelectedIndices[x];
                        WayPoints.Items.RemoveAt(index);

                    }
                }
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ForceCircular.Enabled = EnableForceSave.Checked;
            ForceLinear.Enabled = EnableForceSave.Checked;
        }
        private void AddNode_Click(object sender, EventArgs e)
        {
            if (MainWindow.TESTMODE && MainWindow.STATUS.Contains(@":: Final Fantasy Not Found ::"))
            {
                WayPoints.Items.Add($"WAYPOINT:{0}:{0}:{0}");
            }
            else
                WayPoints.Items.Add($"WAYPOINT:{ScriptFarmDNC.PlayerInfo.X}:{ScriptFarmDNC.PlayerInfo.Z}:{ScriptFarmDNC.PlayerInfo.Y}");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var index = WayPoints.SelectedIndex;
            if (index == -1)
                if (MainWindow.TESTMODE && MainWindow.STATUS == @":: Final Fantasy Not Found ::")
                {
                    WayPoints.Items.Add($"WAYPOINT:{0}:{0}:{0}:Pause;{"TEST"}");
                }
                else
                    WayPoints.Items.Add($"WAYPOINT:{ScriptFarmDNC.PlayerInfo.X}:{ScriptFarmDNC.PlayerInfo.Z}:{ScriptFarmDNC.PlayerInfo.Y}:Pause;{Pauseseconds.Value}");
            else
            {
                var old = (string)WayPoints.Items[index];
                if (old.Split(':').Length < 4)
                {
                    MessageBox.Show("Can't add Door Command to old nav Files.\nPlease convert first.");
                    return;
                }
                WayPoints.Items.RemoveAt(index);
                WayPoints.Items.Insert(index, old + $":Pause;{Pauseseconds.Value}");
            }
        }
    }
}
