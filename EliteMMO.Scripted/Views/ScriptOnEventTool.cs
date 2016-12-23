namespace EliteMMO.Scripted.Views
{
    using API;
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Windows.Forms;
    public partial class ScriptOnEventTool : UserControl
    {
        public ScriptOnEventTool(EliteAPI core)
        {
            InitializeComponent();
            api = core;
        }
        private void BgwScriptEventsDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (botRunning || !bgw_script_events.CancellationPending)
            {
                var onEvent = (from object itemChecked in Events.CheckedItems
                               select itemChecked.ToString()).ToList();

                if (Events.Items.Count == 0 || onEvent.Count == 0)
                    continue;
                var line = api.Chat.GetNextChatLine();
                if (string.IsNullOrEmpty(line?.Text)) continue;
                foreach (int a in Events.CheckedIndices)
                {
                    var b = Events.Items[a];
                    var chat = b.SubItems[0].Text;
                    var action = b.SubItems[1].Text;
                    var chattype = b.SubItems[2].Text;
                    var regex = bool.Parse(b.SubItems[3].Text);
                    if (string.IsNullOrEmpty(action)) continue;
                    if (regex)
                    {
                        if (Regex.IsMatch(line.Text, chat))
                        {
                            triggeredline = line.Text;
                            if (action.Contains("SetTarget"))
                                ScriptFarmDNC.TargetInfo.SetTarget(int.Parse(action.Replace("SetTarget;", "")));
                            else api.ThirdParty.SendString(action);
                        }
                    }
                    else
                    {
                        if (line.Text.ToLower().Contains(chat.ToLower()))
                        {
                            triggeredline = line.Text;
                            if (action.Contains("SetTarget"))
                                ScriptFarmDNC.TargetInfo.SetTarget(int.Parse(action.Replace("SetTarget;", "")));
                            else api.ThirdParty.SendString(action);
                        }
                    }
                }
                Thread.Sleep(TimeSpan.FromSeconds(0.1));
            }
        }
        private void addSettarget_Click(object sender, EventArgs e)
        {
            if (MainWindow.TESTMODE && MainWindow.STATUS.Contains(@":: Final Fantasy Not Found ::"))
            {
                eCommand.Text = $"SetTarget;{"test"}";
            }
            else
                eCommand.Text = $"SetTarget;{ScriptFarmDNC.TargetInfo.ID}";
        }
    }
}
