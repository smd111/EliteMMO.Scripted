                var ma = (from object itemChecked in playerMA.CheckedItems
                          select itemChecked.ToString()).ToList();
            
                foreach (string M in ma)
                {
                    var magic = api.Resources.GetSpell(M);
                    
                    if (M.contains("Protect") && !PlayerInfo.HasBuff(40) && Recast.GetSpellRecast(magic.TimerID) == 0)
                    {
                        api.ThirdParty.SendString("/ma \"Absorb-MND\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(4.0));
                    }
                }
 
        MAautoJA(M, ja);
        private void MAautoJA(string M, List<string> ja)
        {
            #region BLK MAJA
            if (PlayerInfo.MP < magic.MP && !PlayerInfo.HasBuff(47) && !PlayerInfo.HasBuff(229))
            {
                if (ja.Contains("Manafont") && Recast.GetAbilityRecast(0) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Manafont\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                else if (ja.Contains("Manawell") && Recast.GetAbilityRecast(35) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Manawell\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            if (ja.Contains("Elemental Seal") && !PlayerInfo.HasBuff(79) && Recast.GetAbilityRecast(38) == 0)
            {
                api.ThirdParty.SendString("/ja \"Elemental Seal\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Cascade") && !PlayerInfo.HasBuff(598) && magic.Skill == 36 && Recast.GetAbilityRecast(12) == 0)
            {
                api.ThirdParty.SendString("/ja \"Cascade\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Subtle Sorcery") && !PlayerInfo.HasBuff(493) && magic.Skill == 36 && Recast.GetAbilityRecast(254) == 0)
            {
                api.ThirdParty.SendString("/ja \"Subtle Sorcery\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region WHM MAJA
            List<string> DivineSealList = new List<string>(new string[] {"Cure", "Cure II", "Cure III", "Cure IV", "Cure V", "Cure VI", "Full Cure", "Pollen",
            "Healing Breeze", "Wild Carrot", "Magic Fruit", "Exuviation", "Plenilune Embrace", "White Wind", "Restoral", "Poisona", "Paralyna", "Blindna",
            "Silena", "Cursna", "Stona", "Erase", "Cura", "Cura II", "Cura III"});
            
            if (DivineSealList.Contains(M) && ja.Contains("Divine Seal") && !PlayerInfo.HasBuff(78))
            {
                if (Recast.GetAbilityRecast(26) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Divine Seal\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            List<string> DivineCaressList = new List<string>(new string[] {"Poisona", "Paralyna", "Blindna", "Silena", "Cursna", "Stona"});
            
            if (DivineCaressList.Contains(M) && ja.Contains("Divine Caress") && !PlayerInfo.HasBuff(453))
            {
                if (Recast.GetAbilityRecast(32) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Divine Caress\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region RDM MAJA
            if (ja.Contains("Chainspell") && !PlayerInfo.HasBuff(48) && Recast.GetAbilityRecast(0) == 0)
            {
                api.ThirdParty.SendString("/ja \"Chainspell\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Saboteur") && !PlayerInfo.HasBuff(454) && magic.Skill == 35 && Recast.GetAbilityRecast(36) == 0)
            {
                api.ThirdParty.SendString("/ja \"Saboteur\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Spontaneity") && !PlayerInfo.HasBuff(230) && !PlayerInfo.HasBuff(48) && Recast.GetAbilityRecast(37) == 0)
            {
                api.ThirdParty.SendString("/ja \"Spontaneity\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Stymie") && !PlayerInfo.HasBuff(494) && magic.Skill == 35 && Recast.GetAbilityRecast(254) == 0)
            {
                api.ThirdParty.SendString("/ja \"Stymie\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region PLD MAJA
            if (ja.Contains("Divine Emblem") && !PlayerInfo.HasBuff(438) && magic.Skill == 32 && Recast.GetAbilityRecast(80) == 0)
            {
                api.ThirdParty.SendString("/ja \"Divine Emblem\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region DRK MAJA
            if (ja.Contains("Dark Seal") && !PlayerInfo.HasBuff(345) && magic.Skill == 37 && Recast.GetAbilityRecast(89) == 0)
            {
                api.ThirdParty.SendString("/ja \"Dark Seal\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            List<string> NetherVoidList = new List<string>(new string[] {"Absorb-MND", "Absorb-CHR", "Absorb-VIT", "Absorb-AGI", "Absorb-INT", "Absorb-DEX",
            "Absorb-STR", "Absorb-TP", "Absorb-ACC", "Absorb-Attri", "Drain", "Drain II", "Aspir", "Aspir II"});
            if (NetherVoidList.Contains(M) && ja.Contains("Nether Void") && !PlayerInfo.HasBuff(439) && Recast.GetAbilityRecast(91) == 0)
            {
                api.ThirdParty.SendString("/ja \"Nether Void\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region NIN MAJA
            List<string> FutaeList = new List<string>(new string[] {"Katon", "Hyoton", "Huton", "Doton", "Raiton", "Suiton", "Kurayami", "Hojo"});
            if (magic.Skill == 39 && FutaeList.Contains(Regex.Replace(M, ":.*", "")) && ja.Contains("Futae") &&
            !PlayerInfo.HasBuff(441) && Recast.GetAbilityRecast(148) == 0)
            {
                api.ThirdParty.SendString("/ja \"Futae\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region BLU MAJA
            var magic = api.Resources.GetSpell(M)
            List<string> UnbridledLearningList = new List<string>(new string[] {"Harden Shell", "Thunderbolt", "Absolute Terror", "Gates of Hades", "Tourbillion",
            "Pyric Bulwark", "Bilgestorm", "Bloodrake", "Droning Whirlwind", "Carcharian Verve", "Blistering Roar", "Mighty Guard", "Cruel Joke", "Cesspool",
            "Tearing Gust"});
            if (UnbridledLearningList.Contains(M) && !PlayerInfo.HasBuff(485) && !PlayerInfo.HasBuff(505))
            {
                if (ja.Contains("Unbridled Learning") && Recast.GetAbilityRecast(81) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Unbridled Learning\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                else if (ja.Contains("Unbridled Wisdom") && Recast.GetAbilityRecast(254) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Unbridled Wisdom\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region SCH MAJA
            #endregion
            #region GEO MAJA
            #endregion
            #region RUN MAJA
            #endregion
        }