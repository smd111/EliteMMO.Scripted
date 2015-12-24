                        //{745, new {name="Sublimation",t=""}},--special ability
                        //{751, new {name="No Foot Rise",t=""}},----special ability
                        //{896, new {name="Contradance",t=""}},--waltz
                        
                        
            var NFRchecked = (playerJA.GetItemCheckState(playerJA.FindString("No Foot Rise")).ToString() == "Checked" ? true : false);
                        
                        
            #region Still to do
            if (ja.Contains("No Foot Rise - (DNC)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(223) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                if (!PlayerInfo.HasBuff(385))
                {
                    api.ThirdParty.SendString("/ja \"No Foot Rise\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            if (ja.Contains("Crusade - (Rune Fencer)") && !PlayerInfo.HasBuff(16) && PlayerInfo.MPP > 18 &&
                !PlayerInfo.HasBuff(289) && Recast.GetSpellRecast(476) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ma \"Crusade\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(10.0));
            }
            if (ja.Contains("Odyllic Subterfuge - (Rune Fencer)") && !PlayerInfo.HasBuff(16) &&
                PlayerInfo.MPP > 18 && Recast.GetSpellRecast(476) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Odyllic Subterfuge\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            
            
            
  
          
//{"Esuna", new{}},
//{"Erase", new {buffh=}},
{"Animating Wail", new {B=}},--
{"Regeneration", new {B=}},--
{"White Wind", new {B=}},
{"Nat. Meditation", new {B=}},
{"Pyric Bulwark", new {B=}},
{"Carcharian Verve", new {B=}},
/*{"Indi-Regen", new {I=0,B=539}},
{"Indi-Poison", new {I=0}},
{"Indi-Refresh", new {I=0,B=541}},
{"Indi-Haste", new {I=0,B=580}},
{"Indi-STR", new {I=0,B=542}},
{"Indi-DEX", new {I=0,B=543}},
{"Indi-VIT", new {I=0,B=544}},
{"Indi-AGI", new {I=0,B=545}},
{"Indi-INT", new {I=0,B=546}},
{"Indi-MND", new {I=0,B=547}},
{"Indi-CHR", new {I=0,B=548}},
{"Indi-Fury", new {I=0,B=549}},
{"Indi-Barrier", new {I=0,B=550}},
{"Indi-Acumen", new {I=0,B=551}},
{"Indi-Fend", new {I=0,B=552}},
{"Indi-Precision", new {I=0,B=553}},
{"Indi-Voidance", new {I=0,B=554}},
{"Indi-Focus", new {I=0,B=555}},
{"Indi-Attunement", new {I=0,B=556}},
{"Indi-Wilt", new {I=0}},
{"Indi-Frailty", new {I=0}},
{"Indi-Fade", new {I=0}},
{"Indi-Malaise", new {I=0}},
{"Indi-Slip", new {I=0}},
{"Indi-Torpor", new {I=0}},
{"Indi-Vex", new {I=0}},
{"Indi-Languor", new {I=0}},
{"Indi-Slow", new {I=0}},
{"Indi-Paralysis", new {I=0}},
{"Indi-Gravity", new {I=0}},*/