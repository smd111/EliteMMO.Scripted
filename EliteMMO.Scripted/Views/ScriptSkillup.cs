namespace EliteMMO.Scripted.Views
{
    using System;
    using System.Windows.Forms;
    using API;
    public partial class ScriptSkillup : UserControl
    {
        public ScriptSkillup(EliteAPI core)
        {
            InitializeComponent();
            api = core;
        }
        private void loadMAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (playerMA.Items.Count > 0)
                playerMA.Items.Clear();
            #region load MJ MA(main job)
            for (uint mm = 1; mm <= 895; mm++)
            {
                var spellm = api.Resources.GetSpell(mm);
                if ((spellm.ValidTargets & (1 << 0)) == 0) continue;
                var spelllvlm = spellm.LevelRequired[ScriptFarmDNC.PlayerInfo.MainJob];
                if (spellm == null || ScriptFarmDNC.skipSpellList.ContainsKey(mm) || playerMA.Items.Contains(spellm.Name[0])) continue;
                if (spelllvlm != -1)
                {
                    if (ScriptFarmDNC.PlayerInfo.HasSpell(mm) && ScriptFarmDNC.PlayerInfo.MainJobLevel >= spelllvlm)
                    {
                        if (spellm.Skill == 43 && ScriptFarmDNC.PlayerInfo.MainJob == 16)
                        {
                            if (ScriptFarmDNC.UnbridledSpells.Contains(mm))
                                playerMA.Items.Add(spellm.Name[0]);
                            else if (ScriptFarmDNC.PlayerInfo.HasBlueMagicSpellSet((int)mm))
                                playerMA.Items.Add(spellm.Name[0]);
                        }
                        else if (spelllvlm <= 99)
                        {
                            playerMA.Items.Add(spellm.Name[0]);
                        }
                    }
                    else if (ScriptFarmDNC.PlayerInfo.MainJobLevel == 99 && ScriptFarmDNC.PlayerInfo.UsedJobPoints >= spelllvlm)
                        playerMA.Items.Add(spellm.Name[0]);
                }
            }
            #endregion
            #region load SJ MA(sub job)
            for (uint sm = 1; sm <= 895; sm++)
            {
                var spells = api.Resources.GetSpell(sm);
                if ((spells.ValidTargets & (1 << 0)) == 0) continue;
                var spelllvls = spells.LevelRequired[ScriptFarmDNC.PlayerInfo.SubJob];
                if (spells == null || ScriptFarmDNC.skipSpellList.ContainsKey(sm) || playerMA.Items.Contains(spells.Name[0])) continue;
                if (ScriptFarmDNC.PlayerInfo.HasSpell(sm) && ScriptFarmDNC.PlayerInfo.SubJobLevel >= spelllvls && spelllvls != -1)
                {
                    if (spells.Skill == 43 && ScriptFarmDNC.PlayerInfo.SubJob == 16)
                    {
                        if (ScriptFarmDNC.UnbridledSpells.Contains(sm))
                            playerMA.Items.Add(spells.Name[0]);
                        else if (ScriptFarmDNC.PlayerInfo.HasBlueMagicSpellSet((int)sm))
                            playerMA.Items.Add(spells.Name[0]);
                    }
                    else
                        playerMA.Items.Add(spells.Name[0]);
                }
            }
            #endregion
        }
    }
}
