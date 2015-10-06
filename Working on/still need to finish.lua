                        //{687, new {name="Convergence",t=""}},--ma skill
                        //{688, new {name="Diffusion",t=""}},--ma skill
                        //{722, new {name="Tabula Rasa",t=""}},--ma skill
                        //{723, new {name="Light Arts",t=""}},--ma skill
                        //{724, new {name="Dark Arts",t=""}},--ma skill
                        //{726, new {name="Modus Veritas",t=""}},--ma skill
                        //{741, new {name="Pianissimo",t=""}},--ma skill
                        //{745, new {name="Sublimation",t=""}},--special ability
                        //{751, new {name="No Foot Rise",t=""}},----special ability
                        //{756, new {name="Enlightenment",t=""}},--ma skill
                        //{770, new {name="Sengikori",t=""}},---ws skill
                        //{795, new {name="Tenuto",t=""}},--ma skill
                        //{796, new {name="Marcato",t=""}},--ma skill
                        //{800, new {name="Hagakure",t=""}},---ws skill
                        //{809, new {name="Efflux",t=""}},--ma skill
                        //{855, new {name="Bolster",t=""}},--ma skill
                        //{860, new {name="Collimated Fervor",t=""}},--ma skill
                        //{864, new {name="Theurgic Focus",t=""}},--ma skill
                        //{895, new {name="Vivacious Pulse",t=""}}, hp restore
                        //{896, new {name="Contradance",t=""}},--waltz
                        //{889, new {name="Widened Compass",t=""}},--ma skill
                        //{898, new {name="Entrust",t=""}},--ma skill
                        
                        
                        
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