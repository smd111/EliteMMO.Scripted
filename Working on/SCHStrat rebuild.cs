
        public static Dictionary<string, dynamic> SCHStratigems = new Dictionary<string, dynamic>()
        {
            {"White", new Dictionary<string, dynamic>()
                {
                    {"Penury", new {Buff=360,S1=0}},{"Celerity", new {Buff=362,S1=0}},{"Accession", new {Buff=366,S1=33,S2=34}},{"Rapture", new {Buff=364,S1=33,S2=32}},
                    {"Altruism", new {Buff=412,S1=0}},{"Tranquility", new {Buff=414,S1=0}},{"Perpetuance", new {Buff=469,S1=34,S2=34}},
                }
            },
            {"Black", new Dictionary<string, dynamic>()
                {
                    {"Parsimony", new {Buff=361,S1=0}},{"Alacrity", new {Buff=363,S1=0}},{"Manifestation", new {Buff=367,S1=35,S2=37}},{"Ebullience", new {Buff=365,S1=0}},
                    {"Focalization", new {Buff=413,S1=0}},{"Equanimity", new {Buff=415,S1=0}},{"Immanence", new {Buff=470,S1=36,S2=36}},
                }
            },
        }
        
                        if (SchCharges >= 1)
                        {
                            if (AddendumWhite.Contains(magic.Name[0]) && ja.Contains("Addendum: White") &&
                                !PlayerInfo.HasBuff(401))
                            {
                                api.ThirdParty.SendString("/ja \"Addendum: White\" <me>");
                                Thread.Sleep(TimeSpan.FromSeconds(1.0));
                                if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                            }
                            elseif (AddendumBlack.Contains(magic.Name[0]) && ja.Contains("Addendum: Black") &&
                                !PlayerInfo.HasBuff(402))
                            {
                                api.ThirdParty.SendString("/ja \"Addendum: Black\" <me>");
                                Thread.Sleep(TimeSpan.FromSeconds(1.0));
                                if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                            }
                            else if (AddendumBlack.Contains(magic.Name[0]) && !PlayerInfo.HasBuff(402)) return false;
                            else if (AddendumWhite.Contains(magic.Name[0]) && !PlayerInfo.HasBuff(401)) return false;
                        }
                        var schtype = "";
                        if (magic.MagicType == 1) schtype = "White";
                        if (magic.MagicType == 2) schtype = "Black";
                        if (schtype != "")
                        {
                            foreach (KeyValuePair<string, uint> kvp in SCHStratigems["White"])
                            {
                                if (ja.Contains(kvp.Key) && SchCharges >= 1 && !PlayerInfo.HasBuff(kvp.Value.Buff))
                                {
                                    if (kvp.Value.S1 != 0 && (magic.Skill != kvp.Value.S1 || magic.Skill != kvp.Value.S2)) continue;
                                    api.ThirdParty.SendString($"/ja \"{kvp.Key}\" <me>");
                                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                                    if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                                    if (SchCharges == 0) break;
                                }
                            }
                        }