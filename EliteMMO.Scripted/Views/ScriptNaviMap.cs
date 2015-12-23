namespace EliteMMO.Scripted.Views
{
    using System.Windows.Forms;
    using API;
    using System.Threading;
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
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
            var lastcommandtarget = "";
            while (isRunning || !bgw_navi.CancellationPending)
            {
                if (isRecording)
                {
                    var last = (string)WayPoints.Items[WayPoints.Items.Count - 1];
                    var items = last.Split(':');
                    var distance = (Math.Sqrt(Math.Pow(Math.Abs(PlayerInfo.X - float.Parse(items[1])), 2) + Math.Pow(Math.Abs(PlayerInfo.Y - float.Parse(items[3])), 2) + Math.Pow(Math.Abs(PlayerInfo.Z - float.Parse(items[2])), 2)));
                    if (distance > (double)NodeDist.Value)
                    {
                        WayPoints.Items.Add($"WAYPOINT:{PlayerInfo.X}:{PlayerInfo.Z}:{PlayerInfo.Y}");
                    }
                }
                if (isPlaying)
                {
                    if (comboBox2.Text != "" && PlayerInfo.Status == 0 && !isPaused)
                    {
                        if (Circular.Checked)
                        {
                            var closestWayPoint = FindClosestWayPoint();
                            if (runReverse.Checked)
                            {
                                closestWayPoint--;
                            }
                            else
                            {
                                closestWayPoint++;
                            }
                            if (closestWayPoint >= navPathX.Count())
                            {
                                closestWayPoint = 0;
                            }

                            if (firstPersonView.Checked || navPathfirst[closestWayPoint])
                            {
                                if (api.Player.ViewMode != 1)
                                    api.Player.ViewMode = 1;
                                api.AutoFollow.IsAutoFollowing = false;
                                api.Entity.GetLocalPlayer().H = (float)((Math.PI / 180) *
                                    (GetAngleFromPlayer(navPathX[closestWayPoint], navPathZ[closestWayPoint]) - 180));
                            }
                            else if (api.Player.ViewMode == 1)
                                api.Player.ViewMode = 0;

                            api.AutoFollow.SetAutoFollowCoords((float)navPathX[closestWayPoint] - PlayerInfo.X,
                                  ((navPathY[closestWayPoint] == 0) ? 0 : (float)navPathY[closestWayPoint] - PlayerInfo.Y),
                                  (float)navPathZ[closestWayPoint] - PlayerInfo.Z);

                            if (navPathdoor[closestWayPoint].Contains("Door"))
                            {
                                var items = navPathdoor[closestWayPoint].Split(';');
                                if (lastcommandtarget != items[1])
                                {
                                    api.AutoFollow.IsAutoFollowing = false;
                                    TargetInfo.SetTarget(int.Parse(items[1]));
                                    Thread.Sleep(TimeSpan.FromSeconds(0.5));
                                    api.ThirdParty.SendString("/lockon <t>");
                                    Thread.Sleep(TimeSpan.FromSeconds(0.5));
                                    while (TargetInfo.Distance > 4)
                                    {
                                        api.ThirdParty.KeyDown(API.Keys.NUMPAD8);
                                        Thread.Sleep(TimeSpan.FromSeconds(0.1));
                                    }

                                    api.ThirdParty.KeyUp(API.Keys.NUMPAD8);
                                    while (TargetInfo.ID == int.Parse(items[1]))
                                    {
                                        api.ThirdParty.KeyPress(API.Keys.NUMPADENTER);
                                        Thread.Sleep(TimeSpan.FromSeconds(0.5));
                                    }
                                    lastcommandtarget = items[1];
                                }
                            }
                            else lastcommandtarget = "";

                            api.AutoFollow.IsAutoFollowing = true;
                        }
                        else if (Linear.Checked)
                        {
                            //if (runReverse.Enabled)
                            //{
                            //    runReverse.Enabled = false;
                            //    runReverse.Checked = false;
                            //}

                            var closestWayPoint = FindClosestWayPoint();
                            if (closestWayPoint != -1)
                            {
                                if (!runReverse.Checked)
                                {
                                    closestWayPoint++;
                                    if (closestWayPoint >= navPathX.Count())
                                    {
                                        closestWayPoint -= 2;
                                        runReverse.Checked = true;
                                    }

                                    if (firstPersonView.Checked || navPathfirst[closestWayPoint])
                                    {
                                        if (api.Player.ViewMode != 1)
                                            api.Player.ViewMode = 1;
                                        api.AutoFollow.IsAutoFollowing = false;
                                        api.Entity.GetLocalPlayer().H = (float)((Math.PI / 180) *
                                            (GetAngleFromPlayer(navPathX[closestWayPoint], navPathZ[closestWayPoint]) - 180));
                                    }
                                    else if (api.Player.ViewMode == 1)
                                        api.Player.ViewMode = 0;

                                    api.AutoFollow.SetAutoFollowCoords((float)navPathX[closestWayPoint] - PlayerInfo.X,
                                  ((navPathY[closestWayPoint] == 0) ? 0 : (float)navPathY[closestWayPoint] - PlayerInfo.Y),
                                  (float)navPathZ[closestWayPoint] - PlayerInfo.Z);

                                    if (navPathdoor[closestWayPoint].Contains("Door"))
                                    {
                                        var items = navPathdoor[closestWayPoint].Split(';');
                                        if (lastcommandtarget != items[1])
                                        {
                                            api.AutoFollow.IsAutoFollowing = false;
                                            TargetInfo.SetTarget(int.Parse(items[1]));
                                            Thread.Sleep(TimeSpan.FromSeconds(0.5));
                                            api.ThirdParty.SendString("/lockon <t>");
                                            Thread.Sleep(TimeSpan.FromSeconds(0.5));
                                            while (TargetInfo.Distance > 4)
                                            {
                                                api.ThirdParty.KeyDown(API.Keys.NUMPAD8);
                                                Thread.Sleep(TimeSpan.FromSeconds(0.1));
                                            }

                                            api.ThirdParty.KeyUp(API.Keys.NUMPAD8);
                                            while (TargetInfo.ID == int.Parse(items[1]))
                                            {
                                                api.ThirdParty.KeyPress(API.Keys.NUMPADENTER);
                                                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                                            }
                                            lastcommandtarget = items[1];
                                        }
                                    }
                                    else lastcommandtarget = "";

                                    api.AutoFollow.IsAutoFollowing = true;
                                }
                                else
                                {
                                    closestWayPoint--;
                                    if (closestWayPoint < 0)
                                    {
                                        closestWayPoint = 1;
                                        runReverse.Checked = false;
                                    }

                                    if (firstPersonView.Checked || navPathfirst[closestWayPoint])
                                    {
                                        if (api.Player.ViewMode != 1)
                                            api.Player.ViewMode = 1;
                                        api.AutoFollow.IsAutoFollowing = false;
                                        api.Entity.GetLocalPlayer().H = (float)((Math.PI / 180) *
                                            (GetAngleFromPlayer(navPathX[closestWayPoint], navPathZ[closestWayPoint]) - 180));
                                    }
                                    else if (api.Player.ViewMode == 1)
                                        api.Player.ViewMode = 0;

                                    api.AutoFollow.SetAutoFollowCoords((float)navPathX[closestWayPoint] - PlayerInfo.X,
                                  ((navPathY[closestWayPoint] == 0) ? 0 : (float)navPathY[closestWayPoint] - PlayerInfo.Y),
                                  (float)navPathZ[closestWayPoint] - PlayerInfo.Z);

                                    if (navPathdoor[closestWayPoint].Contains("Door"))
                                    {
                                        var items = navPathdoor[closestWayPoint].Split(';');
                                        if (lastcommandtarget != items[1])
                                        {
                                            api.AutoFollow.IsAutoFollowing = false;
                                            TargetInfo.SetTarget(int.Parse(items[1]));
                                            Thread.Sleep(TimeSpan.FromSeconds(0.5));
                                            api.ThirdParty.SendString("/lockon <t>");
                                            Thread.Sleep(TimeSpan.FromSeconds(0.5));
                                            while (TargetInfo.Distance > 4)
                                            {
                                                api.ThirdParty.KeyDown(API.Keys.NUMPAD8);
                                                Thread.Sleep(TimeSpan.FromSeconds(0.1));
                                            }

                                            api.ThirdParty.KeyUp(API.Keys.NUMPAD8);
                                            while (TargetInfo.ID == int.Parse(items[1]))
                                            {
                                                api.ThirdParty.KeyPress(API.Keys.NUMPADENTER);
                                                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                                            }
                                            lastcommandtarget = items[1];
                                        }
                                    }
                                    else lastcommandtarget = "";

                                    api.AutoFollow.IsAutoFollowing = true;
                                }
                            }
                        }
                    }
                    else if (api.AutoFollow.IsAutoFollowing)
                    {
                        api.AutoFollow.IsAutoFollowing = false;
                    }

                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    if (StuckWatch.Checked && comboBox2.Text != "" && api.AutoFollow.IsAutoFollowing && !isPaused && isStuck(0))
                    {
                        api.AutoFollow.IsAutoFollowing = false;
                        api.Player.H = PlayerInfo.H + (float)((Math.PI / 180) * dir);
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
                }

                Thread.Sleep(TimeSpan.FromSeconds(0.1));
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
                        navPathX[ipos] = double.Parse(items[1]);
                        navPathZ[ipos] = double.Parse(items[2]);
                        navPathY[ipos] = ((items.Length == 3) ? 0 : double.Parse(items[3]));
                        navPathfirst[ipos] = false;
                        navPathdoor[ipos] = "";
                        if (items.Length > 4)
                        {
                            for (int i = 4; i <= (items.Length -1); i++)
                            {
                                if (items[i] == "First")
                                    navPathfirst[ipos] = true;
                                if (items[i].Contains("Door"))
                                    navPathdoor[ipos] = items[i];
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
                WayPoints.Items.Add($"WAYPOINT:{PlayerInfo.X}:{PlayerInfo.Z}:{PlayerInfo.Y}:Door;{TargetInfo.ID}");
            else
            {
                var old = (string)WayPoints.Items[index];
                if (old.Split(':').Length < 4)
                {
                    MessageBox.Show("Can't add Door Command to old nav Files.\nPlease convert first.");
                    return;
                }
                WayPoints.Items.RemoveAt(index);
                WayPoints.Items.Insert(index, old + $":Door;{TargetInfo.ID}");
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
            WayPoints.Items.Add($"WAYPOINT:{PlayerInfo.X}:{PlayerInfo.Z}:{PlayerInfo.Y}");
        }
    }
}
