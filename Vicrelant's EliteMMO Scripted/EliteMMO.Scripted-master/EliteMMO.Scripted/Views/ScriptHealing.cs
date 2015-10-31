namespace EliteMMO.Scripted.Views
{
    using System.Windows.Forms;
    using API;
    public partial class ScriptHealing : UserControl
    {
        public ScriptHealing(EliteAPI core)
        {
            InitializeComponent();
            api = core;
        }
    }
}
