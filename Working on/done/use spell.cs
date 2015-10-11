        #region JA: Job Abilities (use)
        private void PlayerMA()
        {
            var ma = (from object itemChecked in playerMA.CheckedItems
                      select itemChecked.ToString()).ToList();
                
            Dictionary<uint, dynamic> macontrol = new Dictionary<uint, dynamic>()
            {
                {14, new {buffh=3}},{15, new {buffh=4}},{16, new {buffh=5}},{17, new {buffh=6}},{18, new {buffh=7}},{19, new {buffh=8}},{20, new {buffh=9}},
                {53, new {buff=36}},{54, new {buff=37}},{55, new {buff=39}},{57, new {buff=33}},{60, new {buff=100}},{61, new {buff=101}},{62, new {buff=102}},
                {63, new {buff=103}},{64, new {buff=104}},{65, new {buff=105}},{66, new {buff=100}},{67, new {buff=101}},{68, new {buff=102}},{69, new {buff=103}},
                {70, new {buff=104}},{71, new {buff=105}},{72, new {buff=106}},{73, new {buff=107}},{74, new {buff=108}},{75, new {buff=109}},{76, new {buff=110}},
                {77, new {buff=111}},{78, new {buff=112}},{84, new {buff=286}},{85, new {buff=286}},{86, new {buff=106}},{87, new {buff=107}},{88, new {buff=108}},
                {89, new {buff=109}},{90, new {buff=110}},{91, new {buff=111}},{92, new {buff=112}},{96, new {buff=275}},{97, new {buff=403}},{99, new {weather=8}},
                {100, new {buff=94}},{101, new {buff=95}},{102, new {buff=96}},{103, new {buff=97}},{104, new {buff=98}},{105, new {buff=99}},{106, new {buff=116}},
                {107, new {buff=116}},{113, new {weather=6}},{114, new {weather=10}},{115, new {weather=4}},{116, new {weather=12}},{117, new {weather=14}},
                {118, new {weather=18}},{119, new {weather=16}},{242, new {buff=90}},{249, new {buff=34}},{250, new {buff=35}},{251, new {buff=38}},
                {266, new {buff=119}},{267, new {buff=120}},{268, new {buff=121}},{269, new {buff=122}},{270, new {buff=123}},{271, new {buff=124}},
                {272, new {buff=125}},{277, new {buff=173}},{287, new {buff=407}},{310, new {buff=274}},{311, new {buff=288}},{312, new {buff=277}},
                {313, new {buff=278}},{314, new {buff=279}},{315, new {buff=280}},{316, new {buff=281}},{317, new {buff=282}},{358, new {buff=33}},
                {378, new {buff=195}},{379, new {buff=195}},{380, new {buff=195}},{381, new {buff=195}},{382, new {buff=195}},{383, new {buff=195}},
                {384, new {buff=195}},{385, new {buff=195}},{386, new {buff=196}},{387, new {buff=196}},{388, new {buff=196}},{389, new {buff=197}},
                {390, new {buff=197}},{391, new {buff=197}},{392, new {buff=197}},{393, new {buff=197}},{394, new {buff=198}},{395, new {buff=198}},
                {396, new {buff=198}},{397, new {buff=198}},{398, new {buff=198}},{399, new {buff=199}},{400, new {buff=199}},{401, new {buff=200}},
                {402, new {buff=200}},{403, new {buff=201}},{404, new {buff=201}},{405, new {buff=202}},{406, new {buff=203}},{407, new {buff=204}},
                {408, new {buff=205}},{409, new {buff=206}},{410, new {buff=206}},{411, new {buff=206}},{412, new {buff=207}},{413, new {buff=208}},
                {414, new {buff=209}},{415, new {buff=210}},{416, new {buff=211}},{417, new {buff=212}},{418, new {buff=213}},{419, new {buff=214}},
                {420, new {buff=214}},{423, new {buff=194}},{424, new {buff=215}},{425, new {buff=215}},{426, new {buff=215}},{427, new {buff=215}},
                {428, new {buff=215}},{429, new {buff=215}},{430, new {buff=215}},{431, new {buff=215}},{432, new {buff=215}},{433, new {buff=215}},
                {434, new {buff=215}},{435, new {buff=215}},{436, new {buff=215}},{437, new {buff=215}},{438, new {buff=216}},{439, new {buff=216}},
                {440, new {buff=216}},{441, new {buff=216}},{442, new {buff=216}},{443, new {buff=216}},{444, new {buff=216}},{445, new {buff=216}},
                {446, new {buff=216}},{447, new {buff=216}},{448, new {buff=216}},{449, new {buff=216}},{450, new {buff=216}},{451, new {buff=216}},
                {452, new {buff=216}},{453, new {buff=216}},{464, new {buff=218}},{468, new {buff=220}},{469, new {buff=221}},{470, new {buff=222}},
                {476, new {buff=289}},{478, new {buff=228}},{479, new {buff=119}},{480, new {buff=120}},{481, new {buff=121}},{482, new {buff=122}},
                {483, new {buff=123}},{484, new {buff=124}},{485, new {buff=125}},{486, new {buff=119}},{487, new {buff=120}},{488, new {buff=121}},
                {489, new {buff=122}},{490, new {buff=123}},{491, new {buff=124}},{492, new {buff=125}},{493, new {buff=432}},{495, new {buff=170}},
                {505, new {buff=289}},{506, new {buff=291}},{507, new {buff=290}},{509, new {buff=227}},{510, new {buff=471}},{511, new {buff=33}},
                {517, new {buff=37}},{530, new {buff=33}},{538, new {buff=190}},{547, new {buff=93}},{613, new {buff=93}},{615, new {buff=38}},
                {636, new {buff=90,buff2=92}},{655, new {buff=91}},{662, new {buff=43}},{668, new {buff=152}},{679, new {buff=36}},{696, new {buff=486}},
                {737, new {buff=93}},{750, new {buff=604}},{840, new {buff=568}},{845, new {buff=581}},{846, new {buff=581}},{855, new {buff=274}},
                {856, new {buff=288}},{857, new {buff=9}},{858, new {buff=7}},{859, new {buff=11}},{860, new {buff=5}},{861, new {buff=13}},{862, new {buff=15}},
                {863, new {buff=19}},{864, new {buff=17}},{879, new {buff=597}},{895, new {buff=432}},
                };
            
            if (MAreverse.Checked) ma.Reverse();
            foreach (string M in ma)
            {
                
                var castSpell = false
                var magic = api.Resources.GetSpell(M);
                var targ = ((magic.ValidTargets & (1 << 0)) != 0 ? "<me>" : "<t>");
                        
                if (!MAautoJA(magic.Name) || PlayerInfo.HasBuff(6)) continue;
                if (PlayerInfo.MP < magic.MP && (!PlayerInfo.HasBuff(47) || !PlayerInfo.HasBuff(229))) continue;
                if (magic.Name.contains("Protect") && !PlayerInfo.HasBuff(40) && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name.contains("Shell") && !PlayerInfo.HasBuff(41) && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name.contains("Regen") && !PlayerInfo.HasBuff(42) && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name.contains("Refresh") && !PlayerInfo.HasBuff(43) && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name.contains("Reraise") && !PlayerInfo.HasBuff(113) && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name == "Cure" && Curecount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0)) castSpell = true;
                else if (magic.Name == "Cure II" && CureIIcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name == "Cure III" && CureIIIcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name == "Cure IV" && CureIVcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name == "Cure V" && CureVcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name == "Cure VI" && CureVIcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name == "Cura" && Curacount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name == "Cura II" && CuraIIcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name == "Cura III" && CuraIIIcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name == "Full Cure" && FullCurecount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name == "Drain" && DrainIcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name == "Drain II" && DrainIIcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name == "Drain III" && DrainIIIcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name == "Aspir" && AspirIcount.Value >= PlayerInfo.MPP && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name == "Aspir II" && AspirIIcount.Value >= PlayerInfo.MPP && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name == "Aspir III" && AspirIIIcount.Value >= PlayerInfo.MPP && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name == "Pollen" && Pollencount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name == "Magic Fruit" && MagicFruitcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name == "Healing Breeze" && HealingBreezecount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name == "Plenilune Embrace" && PleniluneEmbracecount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name == "White Wind" && WhiteWindcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name == "Restoral" && Restoralcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name == "Exuviation" && Exuviationcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else if (magic.Name == "Wild Carrot" && WildCarrotcount.Value >= PlayerInfo.HPP && Recast.GetSpellRecast(magic.TimerID) == 0) castSpell = true;
                else
                {
                    if (macontrol[ability.ID].ToString().Contains("indi") && Recast.GetSpellRecast(magic.TimerID) == 0))
                    {
                        if (!macontrol[ability.ID].ToString().Contains("buff")) continue;
                        else if (!PlayerInfo.HasBuff((short)macontrol[ability.ID].buff)) castSpell = true;
                    }
                    else if (macontrol[ability.ID].ToString().Contains("buff2") && Recast.GetSpellRecast(magic.TimerID) == 0))
                    {
                        if (!PlayerInfo.HasBuff((short)macontrol[ability.ID].buff) && !PlayerInfo.HasBuff((short)macontrol[ability.ID].buff2)) castSpell = true;
                    }
                    else if (macontrol[ability.ID].ToString().Contains("buff") && Recast.GetSpellRecast(magic.TimerID) == 0))
                    {
                        if (!PlayerInfo.HasBuff((short)macontrol[ability.ID].buff)) castSpell = true;
                    }
                    else if (macontrol[ability.ID].ToString().Contains("buffh") && Recast.GetSpellRecast(magic.TimerID) == 0))
                    {
                        if (PlayerInfo.HasBuff((short)macontrol[ability.ID].buffh)) castSpell = true;
                    }
                    else if (macontrol[ability.ID].ToString().Contains("weather") && Recast.GetSpellRecast(magic.TimerID) == 0))
                    {
                        if (macontrol[ability.ID].weather == api.Weather.GetCurrentWeather()) castSpell = true;
                    }
                    else
                    {
                        if (Recast.GetSpellRecast(magic.TimerID) == 0)) castSpell = true;
                    }
                }
                if (castSpell)
                {
                    api.ThirdParty.SendString(String.Format("/ma \"{0}\" {1}", magic.Name, targ);
                    Casting();
                }
            }
        }
        
        private bool MAautoJA(string M)
        {
            var ja = (from object itemChecked in playerJA.CheckedItems select itemChecked.ToString()).ToList();
            var magic = api.Resources.GetSpell(M);
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
                else return false;
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
            
            if (DivineSealList.Contains(magic.Name) && ja.Contains("Divine Seal") && !PlayerInfo.HasBuff(78))
            {
                if (Recast.GetAbilityRecast(26) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Divine Seal\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            List<string> DivineCaressList = new List<string>(new string[] {"Poisona", "Paralyna", "Blindna", "Silena", "Cursna", "Stona"});
            
            if (DivineCaressList.Contains(magic.Name) && ja.Contains("Divine Caress") && !PlayerInfo.HasBuff(453))
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
            if (NetherVoidList.Contains(magic.Name) && ja.Contains("Nether Void") && !PlayerInfo.HasBuff(439) && Recast.GetAbilityRecast(91) == 0)
            {
                api.ThirdParty.SendString("/ja \"Nether Void\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region NIN MAJA
            List<string> FutaeList = new List<string>(new string[] {"Katon", "Hyoton", "Huton", "Doton", "Raiton", "Suiton", "Kurayami", "Hojo"});
            if (FutaeList.Contains(Regex.Replace(magic.Name, ":.*", "")) && ja.Contains("Futae") &&
            !PlayerInfo.HasBuff(441) && Recast.GetAbilityRecast(148) == 0)
            {
                api.ThirdParty.SendString("/ja \"Futae\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region BLU MAJA
            var magic = api.Resources.GetSpell(magic.Name)
            List<string> UnbridledLearningList = new List<string>(new string[] {"Harden Shell", "Thunderbolt", "Absolute Terror", "Gates of Hades", "Tourbillion",
            "Pyric Bulwark", "Bilgestorm", "Bloodrake", "Droning Whirlwind", "Carcharian Verve", "Blistering Roar", "Mighty Guard", "Cruel Joke", "Cesspool",
            "Tearing Gust"});
            if (UnbridledLearningList.Contains(magic.Name) && !PlayerInfo.HasBuff(485) && !PlayerInfo.HasBuff(505))
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
            #region BRD MAJA
            if (magic.Skill == 41 || magic.Skill == 42)
            {
                if (ja.Contains("Soul Voice") && !PlayerInfo.HasBuff(52) && Recast.GetAbilityRecast(0) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Soul Voice\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Pianissimo") && !PlayerInfo.HasBuff(409) && Recast.GetAbilityRecast(112) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Pianissimo\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Nightingale") && !PlayerInfo.HasBuff(347) && Recast.GetAbilityRecast(109) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Nightingale\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Troubadour") && !PlayerInfo.HasBuff(348) && Recast.GetAbilityRecast(110) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Troubadour\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Tenuto") && !PlayerInfo.HasBuff(455) && Recast.GetAbilityRecast(47) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Tenuto\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Marcato") && !PlayerInfo.HasBuff(231) && Recast.GetAbilityRecast(48) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Marcato\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Clarion Call") && !PlayerInfo.HasBuff(499) && Recast.GetAbilityRecast(254) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Clarion Call\" <me>");
                }
            }
            #endregion
            #region SCH MAJA
            List<string> TabulaRasa = new List<string>(new string[] {"Embrava", "Kaustra"});
            List<string> AddendumWhite = new List<string>(new string[] {"Poisona","Paralyna","Blindna","Silena","Cursna","Reraise","Erase","Viruna","Stona",
            "Raise II","Reraise II","Raise III","Reraise III"});
            List<string> AddendumBlack = new List<string>(new string[] {"Sleep","Dispel","Sleep II","Stone IV","Water IV","Aero IV","Fire IV","Blizzard IV",
            "Thunder IV","Stone V","Water V","Aero V","Break","Fire V","Blizzard V","Thunder V"});
            if (ja.Contains("Tabula Rasa") && !PlayerInfo.HasBuff(377) && Recast.GetAbilityRecast(0) == 0)
            {
                api.ThirdParty.SendString("/ja \"Tabula Rasa\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Light Arts") && magic.MagicType == 1 && !PlayerInfo.HasBuff(358) && Recast.GetAbilityRecast(228) == 0)
            {
                api.ThirdParty.SendString("/ja \"Light Arts\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Dark Arts") && magic.MagicType == 2 && !PlayerInfo.HasBuff(359) && Recast.GetAbilityRecast(228) == 0)
            {
                api.ThirdParty.SendString("/ja \"Dark Arts\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Enlightenment") && !PlayerInfo.HasBuff(359) && !PlayerInfo.HasBuff(359) &&
                !PlayerInfo.HasBuff(416) && Recast.GetAbilityRecast(235) == 0)
            {
                api.ThirdParty.SendString("/ja \"Enlightenment\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            /* if (magic.Name.Contains("helix") && ja.Contains("Modus Veritas") && !PlayerInfo.HasBuff(416) && Recast.GetAbilityRecast(235) == 0)
            {
                api.ThirdParty.SendString("/ja \"Modus Veritas\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            } */
            if (SchCharges >= 1 || PlayerInfo.HasBuff(377))
            {   
                if (magic.MagicType == 1 && PlayerInfo.HasBuff(358))
                {
                    #region SCH White MA Stragems
                    if (SchCharges >= 1 && AddendumWhite.Contains(magic.Name) && ja.Contains("Addendum: White") &&
                        !PlayerInfo.HasBuff(401))
                    {
                        api.ThirdParty.SendString("/ja \"Addendum: White\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                    }
                    else if (AddendumWhite.Contains(magic.Name)) return false;
                    if (SchCharges >= 1 && ja.Contains("Penury") && !PlayerInfo.HasBuff(360))
                    {
                        api.ThirdParty.SendString("/ja \"Penury\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                    }
                    if (SchCharges >= 1 && ja.Contains("Celerity") && !PlayerInfo.HasBuff(362))
                    {
                        api.ThirdParty.SendString("/ja \"Celerity\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                    }
                    if (SchCharges >= 1 && ja.Contains("Accession") && !PlayerInfo.HasBuff(366) &&
                        Recast.GetAbilityRecast(231) == 0 && (magic.Skill == 33 || magic.Skill == 34))
                    {
                        api.ThirdParty.SendString("/ja \"Accession\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                    }
                    if (SchCharges >= 1 && ja.Contains("Rapture") && !PlayerInfo.HasBuff(364))
                    {
                        api.ThirdParty.SendString("/ja \"Rapture\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                    }
                    if (SchCharges >= 2 && ja.Contains("Altruism") && !PlayerInfo.HasBuff(412))
                    {
                        api.ThirdParty.SendString("/ja \"Altruism\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        if (!PlayerInfo.HasBuff(377)) SchCharges -= 2;
                    }
                    if (SchCharges >= 1 && ja.Contains("Tranquility") && !PlayerInfo.HasBuff(414))
                    {
                        api.ThirdParty.SendString("/ja \"Tranquility\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                    }
                    if (SchCharges >= 1 && ja.Contains("Perpetuance") && !PlayerInfo.HasBuff(469))
                    {
                        api.ThirdParty.SendString("/ja \"Perpetuance\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                    }
                    #endregion
                }
                else if (magic.MagicType == 2 && PlayerInfo.HasBuff(359))
                {
                    #region SCH Black MA Stragems
                    if (SchCharges >= 1 && AddendumBlack.Contains(magic.Name) && ja.Contains("Addendum: Black") &&
                        !PlayerInfo.HasBuff(402))
                    {
                        api.ThirdParty.SendString("/ja \"Addendum: Black\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                    }
                    else if (AddendumBlack.Contains(magic.Name)) return false;
                    if (SchCharges >= 1 && ja.Contains("Parsimony") && !PlayerInfo.HasBuff(361))
                    {
                        api.ThirdParty.SendString("/ja \"Parsimony\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                    }
                    if (SchCharges >= 1 && ja.Contains("Alacrity") && !PlayerInfo.HasBuff(363))
                    {
                        api.ThirdParty.SendString("/ja \"Alacrity\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                    }
                    if (SchCharges >= 1 && ja.Contains("Manifestation") && !PlayerInfo.HasBuff(367) &&
                        Recast.GetAbilityRecast(231) == 0 && magic.Skill == 35)
                    {
                        api.ThirdParty.SendString("/ja \"Manifestation\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                    }
                    if (SchCharges >= 1 && ja.Contains("Ebullience") && !PlayerInfo.HasBuff(365))
                    {
                        api.ThirdParty.SendString("/ja \"Ebullience\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                    }
                    if (SchCharges >= 1 && ja.Contains("Focalization") && !PlayerInfo.HasBuff(412))
                    {
                        api.ThirdParty.SendString("/ja \"Focalization\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                    }
                    if (SchCharges >= 1 && ja.Contains("Equanimity") && !PlayerInfo.HasBuff(415))
                    {
                        api.ThirdParty.SendString("/ja \"Equanimity\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                    }
                    if (SchCharges >= 1 && ja.Contains("Immanence") && !PlayerInfo.HasBuff(470))
                    {
                        api.ThirdParty.SendString("/ja \"Immanence\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                    }
                    #endregion
                }
            }
            if (AddendumWhite.Contains(magic.Name) && !PlayerInfo.HasBuff(401) && !PlayerInfo.HasBuff(377)) return false;
            if (AddendumBlack.Contains(magic.Name) && !PlayerInfo.HasBuff(402) && !PlayerInfo.HasBuff(377)) return false;
            #endregion
            #region GEO MAJA
            if (ja.Contains("Bolster") && magic.Skill == 44 && !PlayerInfo.HasBuff(513) &&
                Recast.GetAbilityRecast(0) == 0))
            {
                api.ThirdParty.SendString("/ja \"Bolster\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Collimated Fervor") && !PlayerInfo.HasBuff(517) && Recast.GetAbilityRecast(245) == 0))
            {
                api.ThirdParty.SendString("/ja \"Collimated Fervor\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Theurgic Focus") && magic.Skill == 36 && !PlayerInfo.HasBuff(519) &&
                Recast.GetAbilityRecast(249) == 0))
            {
                api.ThirdParty.SendString("/ja \"Theurgic Focus\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Widened Compass") && magic.Skill == 44 && !PlayerInfo.HasBuff(508) &&
                Recast.GetAbilityRecast(130) == 0))
            {
                api.ThirdParty.SendString("/ja \"Widened Compass\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region RUN MAJA
            if (ja.Contains("Embolden") && magic.Skill == 34 && !PlayerInfo.HasBuff(534) &&
                Recast.GetAbilityRecast(72) == 0))
            {
                api.ThirdParty.SendString("/ja \"Embolden\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
             return true;
        }

        private void Casting()
        {
            var Casting = true
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
            var count = 0;
            var lastPercent = 0;
            while (api.CastBar.Percent < 100)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.1));
                if (lastPercent != api.CastBar.Percent)
                {
                    count = 0;
                    lastPercent = api.CastBar.Percent;
                    api.ThirdParty.SendString(String.Format("/echo casting 1 {0} {1}", count, lastPercent));
                }
                else if (count == 10)
                {
                    api.ThirdParty.SendString("/echo break is casting");
                    break;
                }
                else
                {
                    count++
                    lastPercent = api.CastBar.Percent;
                    api.ThirdParty.SendString(String.Format("/echo casting 2 {0} {1}", count, lastPercent));
                }
            }
            Casting = false
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
        }
        #endregion