
        private void MAautoJA(string M)
        {
            var ma = (from object itemChecked in playerMA.CheckedItems
                      select itemChecked.ToString()).ToList();
                
            if (MAreverse.Checked) ma.Reverse();
            foreach (string M in ma)
            {
                Dictionary<string, dynamic> macontrol = new Dictionary<string, dynamic>()
                {
                };
                var magic = api.Resources.GetSpell(M);
                var targ = ((magic.ValidTargets & (1 << 0)) != 0 ? "<me>" : "<t>");
                        
                if (!MAautoJA(magic.Nane)) continue;
                if (PlayerInfo.MP < magic.MP && (!PlayerInfo.HasBuff(47) || !PlayerInfo.HasBuff(229))) continue;
                        
                if (magic.Name.contains("Protect") && !PlayerInfo.HasBuff(40) &&
                    Recast.GetSpellRecast(magic.TimerID) == 0)
                {
                    api.ThirdParty.SendString(String.Format("/ma \"{0}\" {1}", magic.Name, targ);
                    Casting();
                }
                else if (magic.Name.contains("Shell") && !PlayerInfo.HasBuff(41) &&
                        Recast.GetSpellRecast(magic.TimerID) == 0)
                {
                    api.ThirdParty.SendString(String.Format("/ma \"{0}\" {1}", magic.Name, targ);
                    Casting();
                }
                else if (magic.Name.contains("Regen") && !PlayerInfo.HasBuff(42) &&
                    Recast.GetSpellRecast(magic.TimerID) == 0)
                {
                    api.ThirdParty.SendString(String.Format("/ma \"{0}\" {1}", magic.Name, targ);
                    Casting();
                }
                else if (magic.Name.contains("Refresh") && !PlayerInfo.HasBuff(43) &&
                    Recast.GetSpellRecast(magic.TimerID) == 0)
                {
                    api.ThirdParty.SendString(String.Format("/ma \"{0}\" {1}", magic.Name, targ);
                    Casting();
                }
                else if (magic.Name.contains("Reraise") && !PlayerInfo.HasBuff(113) &&
                    Recast.GetSpellRecast(magic.TimerID) == 0)
                {
                    api.ThirdParty.SendString(String.Format("/ma \"{0}\" {1}", magic.Name, targ);
                    Casting();
                }
                else if (magic.Name == "Cure" && Curecount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0))
                {
                    api.ThirdParty.SendString(String.Format("/ma \"{0}\" {1}", magic.Name, targ);
                    Casting();
                }
                else if (magic.Name == "Cure II" && CureIIcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0)
                {
                    api.ThirdParty.SendString(String.Format("/ma \"{0}\" {1}", magic.Name, targ);
                    Casting();
                }
                else if (magic.Name == "Cure III" && CureIIIcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0)
                {
                    api.ThirdParty.SendString(String.Format("/ma \"{0}\" {1}", magic.Name, targ);
                    Casting();
                }
                else if (magic.Name == "Cure IV" && CureIVcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0)
                {
                    api.ThirdParty.SendString(String.Format("/ma \"{0}\" {1}", magic.Name, targ);
                    Casting();
                }
                else if (magic.Name == "Cure V" && CureVcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0)
                {
                    api.ThirdParty.SendString(String.Format("/ma \"{0}\" {1}", magic.Name, targ);
                    Casting();
                }
                else if (magic.Name == "Cure VI" && CureVIcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0)
                {
                    api.ThirdParty.SendString(String.Format("/ma \"{0}\" {1}", magic.Name, targ);
                    Casting();
                }
                else if (magic.Name == "Cura" && Curacount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0)
                {
                    api.ThirdParty.SendString(String.Format("/ma \"{0}\" {1}", magic.Name, targ);
                    Casting();
                }
                else if (magic.Name == "Cura II" && CuraIIcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0)
                {
                    api.ThirdParty.SendString(String.Format("/ma \"{0}\" {1}", magic.Name, targ);
                    Casting();
                }
                else if (magic.Name == "Cura III" && CuraIIIcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0)
                {
                    api.ThirdParty.SendString(String.Format("/ma \"{0}\" {1}", magic.Name, targ);
                    Casting();
                }
                else if (magic.Name == "Full Cure" && FullCurecount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0)
                {
                    api.ThirdParty.SendString(String.Format("/ma \"{0}\" {1}", magic.Name, targ);
                    Casting();
                }
                else
                {
                    if (macontrol[ability.ID].ToString().Contains("buff"))
                    {
                        if (!PlayerInfo.HasBuff((short)macontrol[ability.ID].buff) && Recast.GetSpellRecast(magic.TimerID) == 0))
                        {
                            api.ThirdParty.SendString(String.Format("/ma \"{0}\" {1}", ability.Name, targ));
                            Casting();
                        }
                    }
                    else if (macontrol[ability.ID].ToString().Contains("buffh") && Recast.GetSpellRecast(magic.TimerID) == 0))
                    {
                        if (PlayerInfo.HasBuff((short)macontrol[ability.ID].buffh))
                        {
                            api.ThirdParty.SendString(String.Format("/ma \"{0}\" {1}", ability.Name, targ));
                            Casting();
                        }
                    }
                    else
                    {
                        if (Recast.GetSpellRecast(magic.TimerID) == 0))
                        {
                            api.ThirdParty.SendString(String.Format("/ma \"{0}\" {1}", magic.Name, targ);
                            Casting();
                        }
                    }
                }
            }
        }