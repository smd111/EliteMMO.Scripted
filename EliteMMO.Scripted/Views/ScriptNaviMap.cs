namespace EliteMMO.Scripted.Views
{
    using System.Windows.Forms;
    using API;
    using System.Threading;
    using System;

    public partial class ScriptNaviMap : UserControl
    {
        public ScriptNaviMap(EliteAPI core)
        {
            InitializeComponent();
            api = core;
        }

        private void BgwNaviDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (isRunning || !bgw_navi.CancellationPending)
            {
                if (isRecording)
                {
                    var distance = (Math.Sqrt(Math.Pow(Math.Abs(PlayerInfo.X - lastX), 2) + Math.Pow(Math.Abs(PlayerInfo.Y - lastY), 2) + Math.Pow(Math.Abs(PlayerInfo.Z - lastZ), 2)));
                    if (distance > 5)
                    {
                        lastX = PlayerInfo.X;
                        lastY = PlayerInfo.Y;
                        lastZ = PlayerInfo.Z;
                        WayPoints.Items.Add(string.Format("WAYPOINT:{0}:{1}:{2}", PlayerInfo.X, PlayerInfo.Z, PlayerInfo.Y));
                    }
                }
                //if (isRecording)
                //{

                //}

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
    }
}
