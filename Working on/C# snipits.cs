api.ThirdParty.SendString(String.Format("/echo {0}", kvp.Key));
api.ThirdParty.SendString("/echo here");
api.ThirdParty.SendString($"/echo {var}");
api.Player.HasKeyItem(id);
Thread.Sleep(TimeSpan.FromSeconds(0.1));
var ability = api.Resources.GetAbility(i)
var magic = api.Resources.GetSpell();
List<string> Targets = new List<string>(new string[] {"test","test2"});
Dictionary<string, bool> mobs = new Dictionary<string, bool>() { {"Aa Nawu the Thunderblade", true},{"Aa Xalmo the Savage", true},}
(rule? true : false);

if (magic.ValidTargets == 157) Targets.Add("Corpse");
else
{
   if (magic.ValidTargets & (1 << 0)) Targets.Add("Self")
   if (magic.ValidTargets & (1 << 1)) Targets.Add("Player")
   if (magic.ValidTargets & (1 << 2)) Targets.Add("Party")
   if (magic.ValidTargets & (1 << 3)) Targets.Add("Ally")
   if (magic.ValidTargets & (1 << 4)) Targets.Add("NPC")
   if (magic.ValidTargets & (1 << 5)) Targets.Add("Enemy")
   if (magic.ValidTargets & (1 << 6)) Targets.Add("Object")
}

mklink /J "C:\Users\Steven\Desktop\Apps\scripted\settings" "C:\Users\Steven\Documents\GitHub\EliteMMO.Scripted\EliteMMO.Scripted\bin\Release\settings"

((Reivemode.Checked && PlayerInfo.HasBuff(511))? false : wanted.ClaimID != 0)