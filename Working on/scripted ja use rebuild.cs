

            var ja = (from object itemChecked in playerJA.CheckedItems
                      select itemChecked.ToString()).ToList();

            Dictionary<string, dynamic> job = new Dictionary<string, dynamic>
            {
                #region WAR JA
                {"Mighty Strikes [1HR] - (Warrior)", new {recast=0,buff1=44,send="/ja \"Mighty Strikes\" <me>"}},
                {"Berserk - (Warrior)", new {recast=1,buff1=56,send="/ja \"Berserk\" <me>"}},
                {"Defender - (Warrior)", new {recast=3,buff1=57,send="/ja \"Defender\" <me>"}},
                {"Warcry - (Warrior)", new {recast=2,buff1=68,buff2=460,send="/ja \"Warcry\" <me>"}},
                {"Retaliation - (Warrior)", new {recast=8,buff1=405,send="/ja \"Retaliation\" <me>"}},
                {"Aggressor - (Warrior)", new {recast=4,buff1=58,send="/ja \"Aggressor\" <me>"}},
                {"Warrior's Charge - (Warrior)", new {recast=6,buff1=340,buff2=490,send="/ja \"Warrior's Charge\" <me>"}},
                {"Tomahawk - (Warrior)", new {recast=7,send="/ja \"Tomahawk\" <t>"}},
                {"Restraint - (Warrior)", new {recast=9,buff1=435,send="/ja \"Restraint\" <me>"}},
                {"Blood Rage - (Warrior)", new {recast=11,buff1=460,buff2=68,send="/ja \"Blood Rage\" <me>"}},
                {"Brazen Rush [1HR] - (Warrior)", new {recast=254,buff1=490,buff2=340,send="/ja \"Brazen Rush\" <me>"}},
                #endregion
                #region MNK JA
                {"", new {recast=0,buff1=0,send=""}},
                {"", new {recast=0,buff1=0,send=""}},
                {"", new {recast=0,buff1=0,send=""}},
                {"", new {recast=0,buff1=0,send=""}},
                {"", new {recast=0,buff1=0,send=""}},
                {"", new {recast=0,buff1=0,send=""}},
                {"", new {recast=0,buff1=0,send=""}},
                {"", new {recast=0,buff1=0,send=""}},
                {"", new {recast=0,buff1=0,send=""}},
                {"", new {recast=0,buff1=0,send=""}},
                {"", new {recast=0,buff1=0,send=""}},
                #endregion
            };

            foreach( KeyValuePair<string, dynamic> kvp in job )
            {
                if (kvp.Value.buff2 != null)
                {
                    if (ja.Contains(kvp.Key) && !PlayerInfo.HasBuff(16) && !PlayerInfo.HasBuff(kvp.Value.buff1) &&
                        !PlayerInfo.HasBuff(kvp.Value.buff2) && Recast.GetAbilityRecast(kvp.Value.recast) == 0 &&
                        PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                    {
                        api.ThirdParty.SendString(kvp.Value.send);
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                }
                else if (kvp.Value.buff1 != null)
                {
                    if (ja.Contains(kvp.Key) && !PlayerInfo.HasBuff(16) && !PlayerInfo.HasBuff(kvp.Value.buff1) &&
                        Recast.GetAbilityRecast(kvp.Value.recast) == 0 && PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                    {
                        api.ThirdParty.SendString(kvp.Value.send);
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                }
                else if (ja.Contains(kvp.Key) && !PlayerInfo.HasBuff(16) && Recast.GetAbilityRecast(kvp.Value.recast) == 0 &&
                         PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                {
                    api.ThirdParty.SendString(kvp.Value.send);
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }

            }
            
            