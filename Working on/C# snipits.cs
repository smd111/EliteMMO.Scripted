api.ThirdParty.SendString(String.Format("/echo {0}", kvp.Key));

List<uint> skipablis = new List<int>(new uint[] { 2, 3, 5 });


            this.loadMAsToolStripMenuItem.Click += new System.EventHandler(this.LoadMA_Click);
            
            this.clearMAsToolStripMenuItem.Click += new System.EventHandler(this.ClearMA_Click);
            
            ClearMA_Click(null, null);
            LoadMA_Click(null, null);
            
            
        public class IAbility
        {
            public ushort ID;
            public byte Type;
            public byte ListIconID;
            public ushort Unknown;
            public ushort MP;
            public ushort TimerID;
            public ushort ValidTargets;
            public byte TP;
            public byte Category;
 
            [MarshalAs(UnmanagedType.LPStr)]
            public string Name;
 
            [MarshalAs(UnmanagedType.LPStr)]
            public string Description;
        }
                List<string> skipabil = new List<string>(new int[] { "none", "none"});
                for (int i = 1; i <= 4351; i++)
                {
                    if (PlayerInfo.HasAbility(i))
                    {
                        var ability = api.Resources.GetAbility(i)
                        if (skipabil.contains(ability.name)) { }
                        else if (i >= 1024 && PlayerInfo.MainJob != 23) { }
                        else if (!playerJA.Items.Contains(ability.name))
                        {
                            playerJA.Items.Add(ability.name);
                        }
                    }
                }


                spells.Skill = 36 = Elemental Magic
                
                (byte magic.ValidTargets & (1 << 0)) != 0 ? "<me>" : "<t>"