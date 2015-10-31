namespace EliteMMO.Scripted.Views
{
    using System.Windows.Forms;
    using API;
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
                
            }
        }
    }
}
