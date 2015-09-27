namespace EliteMMO.Scripted.Views
{
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Linq;
    using System.Drawing;
    using API;
    public partial class MainWindow : Form
    {
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
            #endregion

            x1 = new ScriptFarmDNC(api);
            x2 = new ScriptHealing(api);
            x3 = new ScriptNaviMap(api);
            x4 = new ScriptOnEventTool(api);
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
            x2.Hide();
            x1.Show();
            #endregion

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
            x1.Hide();
            x2.Show();
            #endregion

            refreshCharactersToolStripMenuItem.Enabled = false;

            x1.Dock = DockStyle.Fill;
            Controls.Add(x2);
            Size = new Size(650, 442);
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
            x1.Hide();
            #endregion

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

        private void OnEventToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            //if (xStatusLabel.Text == @":: Final Fantasy Not Found ::") return;

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
            x4.Show();
            #endregion

            refreshCharactersToolStripMenuItem.Enabled = false;

            x4.Dock = DockStyle.Fill;
            Controls.Add(x4);
            Size = new Size(482, 488);
        }

        private void label3_Click(object sender, System.EventArgs e)
        {

        }
    }
}
