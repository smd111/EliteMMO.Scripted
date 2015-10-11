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
{"Animating Wail", new {buff=}},--
{"Regeneration", new {buff=}},--
{"White Wind", new {buff=}},
{"Nat. Meditation", new {buff=}},
{"Pyric Bulwark", new {buff=}},
{"Carcharian Verve", new {buff=}},
/*{"Indi-Regen", new {indi=,buff=539}},
{"Indi-Poison", new {indi=}},
{"Indi-Refresh", new {indi=,buff=541}},
{"Indi-Haste", new {indi=,buff=580}},
{"Indi-STR", new {indi=,buff=542}},
{"Indi-DEX", new {indi=,buff=543}},
{"Indi-VIT", new {indi=,buff=544}},
{"Indi-AGI", new {indi=,buff=545}},
{"Indi-INT", new {indi=,buff=546}},
{"Indi-MND", new {indi=,buff=547}},
{"Indi-CHR", new {indi=,buff=548}},
{"Indi-Fury", new {indi=,buff=549}},
{"Indi-Barrier", new {indi=,buff=550}},
{"Indi-Acumen", new {indi=,buff=551}},
{"Indi-Fend", new {indi=,buff=552}},
{"Indi-Precision", new {indi=,buff=553}},
{"Indi-Voidance", new {indi=,buff=554}},
{"Indi-Focus", new {indi=,buff=555}},
{"Indi-Attunement", new {indi=,buff=556}},
{"Indi-Wilt", new {indi=}},
{"Indi-Frailty", new {indi=}},
{"Indi-Fade", new {indi=}},
{"Indi-Malaise", new {indi=}},
{"Indi-Slip", new {indi=}},
{"Indi-Torpor", new {indi=}},
{"Indi-Vex", new {indi=}},
{"Indi-Languor", new {indi=}},
{"Indi-Slow", new {indi=}},
{"Indi-Paralysis", new {indi=}},
{"Indi-Gravity", new {indi=}},*/