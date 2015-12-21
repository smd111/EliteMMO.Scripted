namespace EliteMMO.Scripted.Views
{
    using System.Windows.Forms;
    using API;
    using System.Threading;
    using System;
    using System.IO;
    using System.Linq;
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
                    var distance = (Math.Sqrt(Math.Pow(Math.Abs(PlayerInfo.X - lastX), 2) + Math.Pow(Math.Abs(PlayerInfo.Y - lastY), 2) + Math.Pow(Math.Abs(PlayerInfo.Z - lastZ), 2)));
                    if (distance > (double)NodeDist.Value)
                    {
                        lastX = PlayerInfo.X;
                        lastY = PlayerInfo.Y;
                        lastZ = PlayerInfo.Z;
                        WayPoints.Items.Add(string.Format("WAYPOINT:{0}:{1}:{2}", PlayerInfo.X, PlayerInfo.Z, PlayerInfo.Y));
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

                            api.AutoFollow.SetAutoFollowCoords((float)navPathX[closestWayPoint] - PlayerInfo.X,
                              (navPathY[closestWayPoint] != 0 ? (float)navPathY[closestWayPoint] : 0),
                              (float)navPathZ[closestWayPoint] - PlayerInfo.Z);

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

                                    api.AutoFollow.SetAutoFollowCoords((float)navPathX[closestWayPoint] - PlayerInfo.X,
                                      (navPathY[closestWayPoint] != 0 ? (float)navPathY[closestWayPoint] : 0),
                                      (float)navPathZ[closestWayPoint] - PlayerInfo.Z);

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

                                    api.AutoFollow.SetAutoFollowCoords((float)navPathX[closestWayPoint] - PlayerInfo.X,
                                      (navPathY[closestWayPoint] != 0 ? (float)navPathY[closestWayPoint] : 0),
                                      (float)navPathZ[closestWayPoint] - PlayerInfo.Z);

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
                    if (comboBox2.Text != "" && api.AutoFollow.IsAutoFollowing && !isPaused && isStuck(0))
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
            saveFile.Filter = @"nav file (*.xin)|*.xin";
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
                        navPathX[ipos] = double.Parse(items[1]);
                        navPathZ[ipos] = double.Parse(items[2]);
                        navPathY[ipos] = ((items.Length == 3) ? 0 : double.Parse(items[3]));

                        ipos++;
                    }
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "") return;
            if (comboBox2.Text.Contains("(Linear)")) Linear.Checked = true;
            else if (comboBox2.Text.Contains("(Circular)")) Circular.Checked = true;
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
    }
}
