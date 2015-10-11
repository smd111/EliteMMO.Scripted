
        private void PlayerJA()
        {

            if (!botRunning || PlayerInfo.Status != 1 || naviMove || PlayerInfo.HasBuff(16))
                return;

            var ja = (from object itemChecked in playerJA.CheckedItems
                    select itemChecked.ToString()).ToList();

            if (MonStagered) return;

            Dictionary<uint, dynamic> jacontrol = new Dictionary<uint, dynamic>()
            {
                    #region JA 
                    {528, new {}}, {529, new {}}, {530, new {}}, {533, new {}}, {534, new {}}, {535, new {}}, {538, new {}}, {540, new {}}, {543, new {b1=56}},
                    {544, new {b1=68,b2=460}}, {545, new {b1=57}}, {546, new {b1=58}}, {548, new {b1=59}}, {549, new {b1=60}}, {550, new {hp=90}},
                    {551, new {b1=45}}, {552, new {b1=61}}, {553, new {}}, {556, new {}}, {557, new {}}, {558, new {}}, {559, new {b1=74}}, {560, new {b1=62}},
                    {561, new {b1=63}}, {562, new {b1=75}}, {563, new {b1=64}}, {568, new {}}, {569, new {}}, {570, new {}}, {571, new {b1=172}},
                    {572, new {b1=73}}, {574, new {b1=67}}, {575, new {name="Meditate"}}, {576, new {b1=117}}, {577, new {b1=118}}, {578, new {}},
                    {579, new {}}, {580, new {}}, {588, new {b1=87}}, {589, new {}}, {594, new {}}, {595, new {}}, {598, new {b1=115}}, {604, new {}},
                    {605, new {}}, {606, new {b1=164}}, {607, new {b1=165}}, {608, new {}}, {610, new {b1=310,b2=309}}, {611, new {b1=311,b2=309}},
                    {612, new {b1=312,b2=309}}, {613, new {b1=313,b2=309}}, {614, new {b1=314,b2=309}}, {615, new {b1=315,b2=309}}, {616, new {b1=316,b2=309}},
                    {617, new {b1=317,b2=309}}, {618, new {b1=318,b2=309}}, {619, new {b1=319,b2=309}}, {620, new {b1=320,b2=309}}, {621, new {b1=321,b2=309}},
                    {622, new {b1=322,b2=309}}, {623, new {b1=323,b2=309}}, {624, new {b1=324,b2=309}}, {625, new {b1=325,b2=309}}, {626, new {b1=326,b2=309}},
                    {627, new {b1=327,b2=309}}, {628, new {b1=328,b2=309}}, {629, new {b1=329,b2=309}}, {630, new {b1=330,b2=309}}, {631, new {b1=331,b2=309}},
                    {632, new {b1=332,b2=309}}, {633, new {b1=333,b2=309}}, {634, new {b1=334,b2=309}}, {635, new {b3=308}}, {636, new {name="Quick Draw"}},
                    {637, new {name="Fire Shot"}}, {638, new {name="Ice Shot"}}, {639, new {name="Wind Shot"}}, {640, new {name="Earth Shot"}},
                    {641, new {name="Thunder Shot"}}, {642, new {name="Water Shot"}}, {643, new {name="Light Shot"}}, {644, new {name="Dark Shot"}},
                    {645, new {}}, {661, new {b1=340,b2=490}}, {662, new {}}, {663, new {b1=19}}, {664, new {b1=341}}, {667, new {b1=342}}, {668, new {b1=343}},
                    {669, new {b1=344}}, {672, new {b1=346}}, {673, new {}}, {677, new {b1=350}}, {678, new {b1=351}}, {680, new {}}, {682, new {}},
                    {683, new {b1=352}}, {685, new {b1=353}}, {686, new {b1=354}}, {689, new {b1=357}}, {690, new {b3=309}}, {693, new {b1=376}},
                    {708, new {b1=71}}, {736, new {b1=371}}, {738, new {b1=405}}, {739, new {b1=406}}, {740, new {}}, {749, new {b1=410}}, {750, new {b1=411}},
                    {757, new {b1=417}}, {758, new {b1=418}}, {759, new {b1=419}}, {760, new {b1=420}}, {761, new {nuff1=421}}, {764, new {b1=435}},
                    {765, new {b1=436}}, {769, new {b1=433}}, {772, new {}}, {773, new {b1=442}}, {777, new {}}, {779, new {b1=460,b2=68}}, {781, new {b1=461}},
                    {783, new {b1=477}}, {784, new {}}, {788, new {b1=462}}, {789, new {}}, {790, new {b1=478}}, {791, new {}}, {792, new {b1=479}}, {797, new {}},
                    {798, new {b1=482}}, {799, new {b1=465}}, {803, new {b1=484}}, {804, new {}}, {805, new {}}, {813, new {b1=467}}, {814, new {b1=335,b2=309}},
                    {815, new {b1=336,b2=309}}, {816, new {b1=337,b2=309}}, {817, new {b1=338,b2=309}}, {833, new {thp=10}}, {835, new {b1=490,b2=340}},
                    {836, new {b1=491}}, {837, new {b1=492}}, {840, new {}}, {841, new {}}, {842, new {b1=497}}, {845, new {b1=500}}, {846, new {b1=501}},
                    {847, new {b1=502}}, {848, new {b1=503}}, {851, new {}}, {853, new {b1=507}}, {856, new {}}, {868, new {}}, {870, new {b1=523}},
                    {871, new {b1=524}}, {872, new {b1=525}}, {873, new {b1=526}}, {874, new {b1=527}}, {875, new {b1=528}}, {876, new {b1=529}},
                    {877, new {b1=530}}, {878, new {b1=531}}, {879, new {b1=532}}, {880, new {}}, {881, new {b1=533}}, {883, new {b1=535}}, {884, new {}},
                    {895, new {}}, {885, new {b1=537}}, {886, new {b1=538}}, {887, new {}}, {888, new {b1=570}}, {890, new {}}, {901, new {b1=599}},
                    {902, new {b1=339,b2=309}}, {903, new {b1=600,b2=309}}, {904, new {b1=601}},
                    #endregion
                    #region monJA control
                    {1247, new {hp=75}}, {1818, new {hp=75}}, {1825, new {hp=75}},{1850, new {hp=75}}, {1856, new {hp=75}}, {1929, new {hp=75}}, {2059, new {hp=75}},
                    {2088, new {mp=75}}, {2090, new {hp=75}}, {2113, new {hp=75}}, {2114, new {hp=75}},
                   #endregion
            };
               
            foreach (string J in ja)
            {
                var ability = api.Resources.GetAbility(J);
                var targ = ((ability.ValidTargets & (1 << 0)) != 0 ? "<me>" : "<t>");
                if (ability == null)
                {
                    if (ability.Name == "Chivalry TP > 1000" && !PlayerInfo.HasBuff(16) &&
                        PlayerInfo.TP >= 1000 && Recast.GetAbilityRecast(79) == 0 &&
                        PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                    {
                        api.ThirdParty.SendString("/ja \"Chivalry\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    else if (ability.Name == "Chivalry TP > 2000" && !PlayerInfo.HasBuff(16) &&
                        PlayerInfo.TP >= 2000 && Recast.GetAbilityRecast(79) == 0 &&
                        PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                    {
                        api.ThirdParty.SendString("/ja \"Chivalry\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    else if (ability.Name == "Chivalry TP > 3000" && !PlayerInfo.HasBuff(16) &&
                        PlayerInfo.TP >= 3000 && Recast.GetAbilityRecast(79) == 0 &&
                        PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                    {
                        api.ThirdParty.SendString("/ja \"Chivalry\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    else if (ability.Name == "Sharpshot + Barrage" && !PlayerInfo.HasBuff(16) &&
                        !PlayerInfo.HasBuff(73) && Recast.GetAbilityRecast(125) == 0 &&
                        !PlayerInfo.HasBuff(72) && Recast.GetAbilityRecast(124) == 0 &&
                        PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                    {
                        api.ThirdParty.SendString("/ja \"Sharpshot\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        api.ThirdParty.SendString("/ja \"Barrage\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                }
                else if (ability.ID >= 1024 && PlayerInfo.MainJob == 23)
                {
                    if (!PlayerInfo.HasBuff(16) && Recast.GetAbilityRecast(ability.TimerID) == 0 &&
                         PlayerInfo.Status == 1 && TargetInfo.ID > 0 && ability.TP <= PlayerInfo.TP)
                    {
                        if (jacontrol[ability.ID].ToString().Contains("mp"))
                        {
                            if (PlayerInfo.MPP <= MONmpCount.Value)
                            {
                                api.ThirdParty.SendString(String.Format("/ms \"{0}\" {1}", ability.Name, targ));
                                Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            }
                        }
                        else if (jacontrol[ability.ID].ToString().Contains("hp"))
                        {
                            if (PlayerInfo.HPP <= MONhpCount.Value)
                            {
                                api.ThirdParty.SendString(String.Format("/ms \"{0}\" {1}", ability.Name, targ));
                                Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            }
                        }
                        else
                        {
                            api.ThirdParty.SendString(String.Format("/ms \"{0}\" {1}", ability.Name, targ));
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        }
                    }
                }
                else if (!jacontrol.ContainsKey(ability.ID)) continue;
                else if (!PlayerInfo.HasBuff(16) && Recast.GetAbilityRecast(ability.TimerID) == 0 &&
                         PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                {
                    if (ability.Name == "Benediction" && PlayerInfo.HPP <= BenedictionHPPuse.Value)
                    {
                        api.ThirdParty.SendString("/ja \"Benediction\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    else if (ability.Name == "Convert")
                    {
                        if (ConvertHP.Checked && ConvertHPP.Value >= PlayerInfo.HPP && ConvertMPP.Value <= PlayerInfo.MPP)
                        {
                            api.ThirdParty.SendString("/ja \"Convert\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        }
                        else if (ConvertMP.Checked && ConvertHPP.Value <= PlayerInfo.HPP && ConvertMPP.Value >= PlayerInfo.MPP)
                        {
                            api.ThirdParty.SendString("/ja \"Convert\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        }
                    }
                    else if (ability.Name == "Vivacious Pulse" && PlayerInfo.HPP <= VivaciousPulseHP.Value &&
                        Recast.GetAbilityRecast(136) == 0 && PlayerInfo.Status == 1 &&
                        TargetInfo.ID > 0)
                    {
                        api.ThirdParty.SendString("/ja \"Vivacious Pulse\" <t>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    else if (ability.Name == "Shikikoyo - (Samurai)" && !PlayerInfo.HasBuff(16) &&
                        Recast.GetAbilityRecast(136) == 0 && PlayerInfo.Status == 1 &&
                        TargetInfo.ID > 0)
                    {
                        api.ThirdParty.SendString("/ja \"Shikikoyo\" <t>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    else if (jacontrol[ability.ID].ToString().Contains("b2"))
                    {
                        if (!PlayerInfo.HasBuff((short)jacontrol[ability.ID].b1) &&
                        !PlayerInfo.HasBuff((short)jacontrol[ability.ID].b2))
                        {
                            api.ThirdParty.SendString(String.Format("/ja \"{0}\" {1}", ability.Name, targ));
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        }
                    }
                    else if (jacontrol[ability.ID].ToString().Contains("b1"))
                    {
                        if (!PlayerInfo.HasBuff((short)jacontrol[ability.ID].b1))
                        {
                            api.ThirdParty.SendString(String.Format("/ja \"{0}\" {1}", ability.Name, targ));
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        }
                    }
                    else if (jacontrol[ability.ID].ToString().Contains("b3"))
                    {
                        if (!PlayerInfo.HasBuff((short)jacontrol[ability.ID].b3))
                        {
                            api.ThirdParty.SendString(String.Format("/ja \"{0}\" {1}", ability.Name, targ));
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        }
                    }
                    else if (jacontrol[ability.ID].ToString().Contains("hp"))
                    {
                        if (PlayerInfo.HPP <= jacontrol[ability.ID].hp)
                        {
                            api.ThirdParty.SendString(String.Format("/ja \"{0}\" {1}", ability.Name, targ));
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        }
                    }
                    else if (jacontrol[ability.ID].ToString().Contains("thp"))
                    {
                        if (TargetInfo.HPP <= jacontrol[ability.ID].thp)
                        {
                            api.ThirdParty.SendString(String.Format("/ja \"{0}\" {1}", ability.Name, targ));
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        }
                    }
                    else
                    {
                        api.ThirdParty.SendString(String.Format("/ja \"{0}\" {1}", ability.Name, targ));
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                }
            }
        }