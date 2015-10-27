api.ThirdParty.SendString(String.Format("/echo {0}", kvp.Key));
api.ThirdParty.SendString("/echo here");
api.Player.HasKeyItem(id);
var ability = api.Resources.GetAbility(i)
var magic = api.Resources.GetSpell();
List<string> Targets = new List<string>(new string[] {"test","test2"});

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