           #region RNG JA
            if (PlayerInfo.MainJob == 11)
            {
                if (PlayerInfo.MainJobLevel >= 10 &&
                    !playerJA.Items.Contains("Scavenge - (Ranger)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Scavenge - (Ranger)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 1 &&
                    !playerJA.Items.Contains("Sharpshot - (Ranger)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Sharpshot - (Ranger)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 30 &&
                    !playerJA.Items.Contains("Barrage - (Ranger)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Barrage - (Ranger)",
                        "Sharpshot + Barrage - (Ranger)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 40 &&
                    !playerJA.Items.Contains("Shadowbind - (Ranger)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Shadowbind - (Ranger)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 45 &&
                    !playerJA.Items.Contains("Velocity Shot - (Ranger)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Velocity Shot - (Ranger)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 51 &&
                    !playerJA.Items.Contains("Unlimited Shot - (Ranger)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Unlimited Shot - (Ranger)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 75 && PlayerInfo.HasAbility(677) &&
                    !playerJA.Items.Contains("Stealth Shot - (Ranger)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Stealth Shot - (Ranger)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 75 && PlayerInfo.HasAbility(678) &&
                    !playerJA.Items.Contains("Flashy Shot - (Ranger)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Flashy Shot - (Ranger)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 79 &&
                    !playerJA.Items.Contains("Double Shot - (Ranger)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Double Shot - (Ranger)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 87 &&
                    !playerJA.Items.Contains("Bounty Shot - (Ranger)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Bounty Shot - (Ranger)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 95 &&
                    !playerJA.Items.Contains("Decoy Shot - (Ranger)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Decoy Shot - (Ranger)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 96 &&
                    !playerJA.Items.Contains("Overkill - (Ranger)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Overkill - (Ranger)",
                    });
                }
            }
            #endregion
            #region SAM JA
            if (PlayerInfo.MainJob == 12)
            {
                if (PlayerInfo.MainJobLevel >= 5 &&
                    !playerJA.Items.Contains("Warding Circle - (Samurai)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Warding Circle - (Samurai)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 15 &&
                    !playerJA.Items.Contains("Third Eye - (Samurai)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Third Eye - (Samurai)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 25 &&
                    !playerJA.Items.Contains("Hasso - (Samurai)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Hasso - (Samurai)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 30 &&
                    !playerJA.Items.Contains("Meditate - (Samurai)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Meditate - (Samurai)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 35 &&
                    !playerJA.Items.Contains("Seigan - (Samurai)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Seigan - (Samurai)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 40 &&
                    !playerJA.Items.Contains("Sekkanoki - (Samurai)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Sekkanoki - (Samurai)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 65 &&
                    !playerJA.Items.Contains("Konzen-ittai - (Samurai)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Konzen-ittai - (Samurai)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 75 && PlayerInfo.HasAbility(680) &&
                    !playerJA.Items.Contains("Blade Bash - (Samurai)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Blade Bash - (Samurai)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 75 && PlayerInfo.HasAbility(679) &&
                    !playerJA.Items.Contains("Shikikoyo - (Samurai)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Shikikoyo - (Samurai)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 77 &&
                    !playerJA.Items.Contains("Sengikori - (Samurai)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Sengikori - (Samurai)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 87 &&
                    !playerJA.Items.Contains("Hamanoha - (Samurai)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Hamanoha - (Samurai)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 95 &&
                    !playerJA.Items.Contains("Hagakure - (Samurai)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Hagakure - (Samurai)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 96 &&
                    !playerJA.Items.Contains("Yaegasumi - (Samurai)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Yaegasumi - (Samurai)",
                    });
                }
            }
            #endregion
            #region NIN JA
            if (PlayerInfo.MainJob == 13)
            {
                if (PlayerInfo.MainJobLevel >= 40 &&
                    !playerJA.Items.Contains("Yonin - (Ninja)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Yonin - (Ninja)",
                        "Innin - (Ninja)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 75 && PlayerInfo.HasAbility(683) &&
                    !playerJA.Items.Contains("Sange - (Ninja)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Sange - (Ninja)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 77 && 
                    !playerJA.Items.Contains("Futae - (Ninja"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Futae - (Ninja)"
                    });
                }
                if (PlayerInfo.MainJobLevel >= 88 && PlayerInfo.HasSpell(510) &&
                    !playerJA.Items.Contains("Migawari: Ichi - (Ninja)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Migawari: Ichi - (Ninja)"
                    });
                }
                if (PlayerInfo.MainJobLevel >= 85 && PlayerInfo.HasSpell(507) &&
                    !playerJA.Items.Contains("Myoshu: Ichi - (Ninja)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Myoshu: Ichi - (Ninja)"
                    });
                }
                if (PlayerInfo.MainJobLevel >= 93 && PlayerInfo.HasSpell(509) &&
                    !playerJA.Items.Contains("Kakka: Ichi - (Ninja)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Kakka: Ichi - (Ninja)"
                    });
                }
                if (PlayerInfo.MainJobLevel >= 95 && 
                    !playerJA.Items.Contains("Issekigan - (Ninja)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Issekigan - (Ninja)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 96 &&
                    !playerJA.Items.Contains("Mikage - (Ninja)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Mikage - (Ninja)",
                    });
                }
            }
            #endregion
            #region DRG JA
            if (PlayerInfo.MainJob == 14)
            {
                if (PlayerInfo.MainJobLevel >= 5 &&
                    !playerJA.Items.Contains("Ancient Circle - (Dragoon)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Ancient Circle - (Dragoon)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 10 &&
                    !playerJA.Items.Contains("Jump - (Dragoon)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Jump - (Dragoon)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 35 &&
                    !playerJA.Items.Contains("High Jump - (Dragoon)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "High Jump - (Dragoon)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 50 &&
                    !playerJA.Items.Contains("Super Jump - (Dragoon)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Super Jump - (Dragoon)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 75 && PlayerInfo.HasAbility(682) &&
                    !playerJA.Items.Contains("Angon - (Dragoon)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Angon - (Dragoon)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 77 &&
                    !playerJA.Items.Contains("Spirit Jump - (Dragoon)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Spirit Jump - (Dragoon)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 85 &&
                    !playerJA.Items.Contains("Soul Jump - (Dragoon)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Soul Jump - (Dragoon)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 87 &&
                    !playerJA.Items.Contains("Dragon Breaker - (Dragoon)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Dragon Breaker - (Dragoon)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 96 &&
                    !playerJA.Items.Contains("Fly High - (Dragoon)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Fly High - (Dragoon)",
                    });
                }
            }
            #endregion
            #region COR JA
            if (PlayerInfo.MainJob == 17)
            {
                if (PlayerInfo.MainJobLevel >= 5 &&
                    !playerJA.Items.Contains("Phantom Roll - (Corsair)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Phantom Roll - (Corsair)",
                        "Double-Up",
                    });
                }
                /*if (PlayerInfo.MainJobLevel >= 40 &&
                    !checkedListBox1.Items.Contains("Quick Draw - (Corsair)"))
                {
                    checkedListBox1.Items.AddRange(new object[]
                    {
                        "Quick Draw - (Corsair)",
                        "Dark Shot - (Corsair)",
                        "Earth Shot - (Corsair)",
                        "Ice Shot - (Corsair)",
                        "Water Shot - (Corsair)",
                        "Wind Shot - (Corsair)",
                        "Fire Shot - (Corsair)",
                        "Thunder Shot - (Corsair)",
                        "Light Shot - (Corsair)",
                    });
                }*/
                if (PlayerInfo.MainJobLevel >= 50 &&
                    !playerJA.Items.Contains("Random Deal - (Corsair)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Random Deal - (Corsair)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 75 && PlayerInfo.HasAbility(689) &&
                    !playerJA.Items.Contains("Snake Eye - (Corsair)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Snake Eye - (Corsair)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 75 && PlayerInfo.HasAbility(690) &&
                    !playerJA.Items.Contains("Fold - (Corsair)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Fold - (Corsair)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 87 &&
                    !playerJA.Items.Contains("Triple Shot - (Corsair)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Triple Shot - (Corsair)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 96 &&
                    !playerJA.Items.Contains("Cutting Cards - (Corsair)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Cutting Cards - (Corsair)",
                    });
                }
            }
            #endregion
            #region DNC JA
            if (PlayerInfo.MainJob == 19)
            {
                if (PlayerInfo.MainJobLevel >= 25 && 
                    !playerJA.Items.Contains("Spectral Jig - (DNC)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Spectral Jig - (DNC)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 75 && PlayerInfo.HasAbility(749) &&
                    !playerJA.Items.Contains("Saber Dance - (DNC)"))
                {
                    playerJA.Items.AddRange(new object[] 
                    {
           	            "Saber Dance - (DNC)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 75 && PlayerInfo.HasAbility(750) &&
                    !playerJA.Items.Contains("Fan Dance - (DNC)"))
                {
                    playerJA.Items.AddRange(new object[] 
                    {
                        "Fan Dance - (DNC)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 75 && PlayerInfo.HasAbility(751) &&
                    !playerJA.Items.Contains("No Foot Rise - (DNC)"))
                {
                    playerJA.Items.AddRange(new object[] 
                    {
			            "No Foot Rise - (DNC)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 77 && 
                    !playerJA.Items.Contains("Presto - (DNC)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Presto - (DNC)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 96 &&
                    !playerJA.Items.Contains("Grand Pas - (DNC)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Grand Pas - (DNC)",
                    });
                }
            }
            #endregion
            #region RUN JA
            if (PlayerInfo.MainJob == 22)
            {
                if (PlayerInfo.MainJobLevel >= 5 &&
                    !playerJA.Items.Contains("Ignis - (Rune Fencer)"))
                {
                    playerJA.Items.AddRange(new object[] 
                    {
				        "Ignis - (Rune Fencer)",
				        "Gelus - (Rune Fencer)",
				        "Flabra - (Rune Fencer)",
				        "Tellus - (Rune Fencer)",
				        "Sulpor - (Rune Fencer)",
				        "Unda - (Rune Fencer)",
				        "Lux - (Rune Fencer)",
				        "Tenebrae - (Rune Fencer)",
			        });
                }
                if (PlayerInfo.MainJobLevel >= 10 &&
                    !playerJA.Items.Contains("Ward: Vallation - (Rune Fencer)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Ward: Vallation - (Rune Fencer)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 20 &&
                    !playerJA.Items.Contains("Effusion: Lunge - (Rune Fencer)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Effusion: Lunge - (Rune Fencer)",
                        "Swordplay - (Rune Fencer)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 40 &&
                    !playerJA.Items.Contains("Ward: Pflug - (Rune Fencer)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Ward: Pflug - (Rune Fencer)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 50 &&
                    !playerJA.Items.Contains("Ward: Valiance - (Rune Fencer)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Ward: Valiance - (Rune Fencer)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 60 &&
                    !playerJA.Items.Contains("Embolden - (Rune Fencer)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Embolden - (Rune Fencer)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 70 &&
                    !playerJA.Items.Contains("Effusion: Gambit - (Rune Fencer)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Effusion: Gambit - (Rune Fencer)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 75 && PlayerInfo.HasAbility(888) &&
                    !playerJA.Items.Contains("Battuta - (Rune Fencer)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Battuta - (Rune Fencer)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 75 && PlayerInfo.HasAbility(887) &&
                    !playerJA.Items.Contains("Rayke - (Rune Fencer)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Rayke - (Rune Fencer)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 85 &&
                    !playerJA.Items.Contains("Ward: Liement - (Rune Fencer)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Ward: Liement - (Rune Fencer)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 88 &&
                    !playerJA.Items.Contains("Crusade - (Rune Fencer)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Crusade - (Rune Fencer)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 95 &&
                    !playerJA.Items.Contains("One for All - (Rune Fencer)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "One for All - (Rune Fencer)",
                    });
                }
                if (PlayerInfo.MainJobLevel >= 96 &&
                    !playerJA.Items.Contains("Odyllic Subterfuge - (Rune Fencer)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Odyllic Subterfuge - (Rune Fencer)",
                    });
                }
            }
            #endregion

            #endregion
            #region load SJ (sub job)
            
            #region WAR JA
            if (PlayerInfo.SubJob == 1)
            {
                if (PlayerInfo.SubJobLevel >= 15 &&
                    !playerJA.Items.Contains("Berserk - (Warrior)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Berserk - (Warrior)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 25 &&
                    !playerJA.Items.Contains("Defender - (Warrior)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Defender - (Warrior)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 35 &&
                    !playerJA.Items.Contains("Warcry - (Warrior)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Warcry - (Warrior)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 45 &&
                    !playerJA.Items.Contains("Aggressor - (Warrior)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Aggressor - (Warrior)",
                    });
                }
            }
            #endregion
            #region MNK JA
            if (PlayerInfo.SubJob == 2)
            {
                if (PlayerInfo.SubJobLevel >= 5 &&
                    !playerJA.Items.Contains("Boost - (Monk)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Boost - (Monk)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 15 &&
                    !playerJA.Items.Contains("Dodge - (Monk)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Dodge - (Monk)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 25 &&
                    !playerJA.Items.Contains("Focus - (Monk)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Focus - (Monk)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 35 &&
                    !playerJA.Items.Contains("Chakra - (Monk)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Chakra - (Monk)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 41 &&
                    !playerJA.Items.Contains("Chi Blast - (Monk)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Chi Blast - (Monk)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 45 &&
                    !playerJA.Items.Contains("Counterstance - (Monk)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Counterstance - (Monk)",
                    });
                }
            }
            #endregion
            #region THF JA
            if (PlayerInfo.SubJob == 6)
            {
                if (PlayerInfo.SubJobLevel >= 5 &&
                    !playerJA.Items.Contains("Steal - (Thief)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Steal - (Thief)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 35 &&
                    !playerJA.Items.Contains("Mug - (Thief)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Mug - (Thief)",
                    });
                }
            }
            #endregion
            #region PLD JA
            if (PlayerInfo.SubJob == 7)
            {
                if (PlayerInfo.SubJobLevel >= 5 &&
                    !playerJA.Items.Contains("Holy Circle - (Paladin)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Holy Circle - (Paladin)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 15 &&
                    !playerJA.Items.Contains("Shield Bash - (Paladin)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Shield Bash - (Paladin)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 30 &&
                    !playerJA.Items.Contains("Sentinel - (Paladin)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Sentinel - (Paladin)",
                    });
                }
            }
            #endregion
            #region DRK JA
            if (PlayerInfo.SubJob == 8)
            {
                if (PlayerInfo.SubJobLevel >= 5 &&
                    !playerJA.Items.Contains("Arcane Circle - (Dark Knight)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Arcane Circle - (Dark Knight)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 15 &&
                    !playerJA.Items.Contains("Last Resort - (Dark Knight)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Last Resort - (Dark Knight)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 20 &&
                    !playerJA.Items.Contains("Weapon Bash - (Dark Knight)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Weapon Bash - (Dark Knight)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 30 &&
                    !playerJA.Items.Contains("Soul Eater - (Dark Knight)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Soul Eater - (Dark Knight)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 43 && PlayerInfo.HasSpell(266) &&
                    !playerJA.Items.Contains("Absorb-STR - (Dark Knight)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Absorb-STR - (Dark Knight)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 41 && PlayerInfo.HasSpell(267) &&
                    !playerJA.Items.Contains("Absorb-DEX - (Dark Knight)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Absorb-DEX - (Dark Knight)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 35 && PlayerInfo.HasSpell(268) &&
                    !playerJA.Items.Contains("Absorb-VIT - (Dark Knight)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Absorb-VIT - (Dark Knight)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 37 && PlayerInfo.HasSpell(269) &&
                    !playerJA.Items.Contains("Absorb-AGI - (Dark Knight)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Absorb-AGI - (Dark Knight)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 39 && PlayerInfo.HasSpell(270) &&
                    !playerJA.Items.Contains("Absorb-INT - (Dark Knight)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Absorb-INT - (Dark Knight)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 31 && PlayerInfo.HasSpell(271) &&
                    !playerJA.Items.Contains("Absorb-MND - (Dark Knight)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Absorb-MND - (Dark Knight)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 33 && PlayerInfo.HasSpell(272) &&
                    !playerJA.Items.Contains("Absorb-CHR - (Dark Knight)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Absorb-CHR - (Dark Knight)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 45 && PlayerInfo.HasSpell(275) &&
                    !playerJA.Items.Contains("Absorb-TP - (Dark Knight)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Absorb-TP - (Dark Knight)",
                    });
                }
            }
            #endregion
            #region BST JA
            if (PlayerInfo.SubJob == 9)
                BSTGetJA();
            #endregion
            #region RNG JA
            if (PlayerInfo.SubJob == 11)
            {
                if (PlayerInfo.SubJobLevel >= 10 &&
                    !playerJA.Items.Contains("Scavenge - (Ranger)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Scavenge - (Ranger)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 1 &&
                    !playerJA.Items.Contains("Sharpshot - (Ranger)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Sharpshot - (Ranger)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 30 &&
                    !playerJA.Items.Contains("Barrage - (Ranger)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Barrage - (Ranger)",
                        "Sharpshot + Barrage - (Ranger)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 40 &&
                    !playerJA.Items.Contains("Shadowbind - (Ranger)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Shadowbind - (Ranger)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 45 &&
                    !playerJA.Items.Contains("Velocity Shot - (Ranger)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Velocity Shot - (Ranger)",
                    });
                }
            }
            #endregion
            #region SAM JA
            if (PlayerInfo.SubJob == 12)
            {
                if (PlayerInfo.SubJobLevel >= 5 &&
                    !playerJA.Items.Contains("Warding Circle - (Samurai)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Warding Circle - (Samurai)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 15 &&
                    !playerJA.Items.Contains("Third Eye - (Samurai)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Third Eye - (Samurai)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 25 &&
                    !playerJA.Items.Contains("Hasso - (Samurai)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Hasso - (Samurai)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 30 &&
                    !playerJA.Items.Contains("Meditate - (Samurai)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Meditate - (Samurai)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 35 &&
                    !playerJA.Items.Contains("Seigan - (Samurai)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Seigan - (Samurai)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 40 &&
                    !playerJA.Items.Contains("Sekkanoki - (Samurai)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Sekkanoki - (Samurai)",
                    });
                }
            }
            #endregion
            #region NIN JA
            if (PlayerInfo.SubJob == 13)
            {
                if (PlayerInfo.SubJobLevel >= 40 &&
                    !playerJA.Items.Contains("Yonin - (Ninja)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Yonin - (Ninja)",
                        "Innin - (Ninja)",
                    });
                }
            }
            #endregion
            #region DRG JA
            if (PlayerInfo.SubJob == 14)
            {
                if (PlayerInfo.SubJobLevel >= 5 &&
                    !playerJA.Items.Contains("Ancient Circle - (Dragoon)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Ancient Circle - (Dragoon)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 10 &&
                    !playerJA.Items.Contains("Jump - (Dragoon)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Jump - (Dragoon)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 35 &&
                    !playerJA.Items.Contains("High Jump - (Dragoon)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "High Jump - (Dragoon)",
                    });
                }
            }
            #endregion
            #region COR JA
            if (PlayerInfo.SubJob == 17)
            {
                if (PlayerInfo.SubJobLevel >= 5 &&
                    !playerJA.Items.Contains("Phantom Roll - (Corsair)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Phantom Roll - (Corsair)",
                        "Double-Up",
                    });
                }
            }
            #endregion
            #region DNC JA
            if (PlayerInfo.SubJob == 19)
            {
                if (PlayerInfo.SubJobLevel >= 25 && 
                    !playerJA.Items.Contains("Spectral Jig - (DNC)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Spectral Jig - (DNC)",
                    });
                }
            }
            #endregion
            #region RUN JA
            if (PlayerInfo.SubJob == 22)
            {
                if (PlayerInfo.SubJobLevel >= 5 &&
                    !playerJA.Items.Contains("Ignis - (Rune Fencer)"))
                {
                    playerJA.Items.AddRange(new object[] 
                    {
				        "Ignis - (Rune Fencer)",
				        "Gelus - (Rune Fencer)",
				        "Flabra - (Rune Fencer)",
				        "Tellus - (Rune Fencer)",
				        "Sulpor - (Rune Fencer)",
				        "Unda - (Rune Fencer)",
				        "Lux - (Rune Fencer)",
				        "Tenebrae - (Rune Fencer)",
			        });
                }
                if (PlayerInfo.SubJobLevel >= 10 &&
                    !playerJA.Items.Contains("Ward: Vallation - (Rune Fencer)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Ward: Vallation - (Rune Fencer)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 20 &&
                    !playerJA.Items.Contains("Effusion: Lunge - (Rune Fencer)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Effusion: Lunge - (Rune Fencer)",
                        "Swordplay - (Rune Fencer)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 40 &&
                    !playerJA.Items.Contains("Ward: Pflug - (Rune Fencer)"))
                {
                    playerJA.Items.AddRange(new object[]
                    {
                        "Ward: Pflug - (Rune Fencer)",
                    });
                }
            }
            #endregion

            #endregion
            
            
            
        #region JA: Job Abilities (use)

        private void PlayerJA()
        {
            if (!botRunning || PlayerInfo.Status != 1 || naviMove || PlayerInfo.HasBuff(16))
                return;

            var ja = (from object itemChecked in playerJA.CheckedItems
                      select itemChecked.ToString()).ToList();

            #region WAR JA
            if (ja.Contains("Mighty Strikes [1HR] - (Warrior)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(44) && Recast.GetAbilityRecast(0) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
                api.ThirdParty.SendString("/ja \"Mighty Strikes\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Berserk - (Warrior)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(56) && Recast.GetAbilityRecast(1) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
                api.ThirdParty.SendString("/ja \"Berserk\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Defender - (Warrior)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(57) && Recast.GetAbilityRecast(3) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Defender\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Warcry - (Warrior)") && !PlayerInfo.HasBuff(16) && !PlayerInfo.HasBuff(460) &&
                !PlayerInfo.HasBuff(68) && Recast.GetAbilityRecast(2) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Warcry\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Retaliation - (Warrior)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(405) && Recast.GetAbilityRecast(8) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Retaliation\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Aggressor - (Warrior)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(58) && Recast.GetAbilityRecast(4) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Aggressor\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Warrior's Charge - (Warrior)") && !PlayerInfo.HasBuff(16) && !PlayerInfo.HasBuff(490) &&
                !PlayerInfo.HasBuff(340) && Recast.GetAbilityRecast(6) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Warrior's Charge\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Tomahawk - (Warrior)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(7) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Tomahawk\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Restraint - (Warrior)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(435) && Recast.GetAbilityRecast(9) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Restraint\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Blood Rage - (Warrior)") && !PlayerInfo.HasBuff(16) && !PlayerInfo.HasBuff(68) &&
                !PlayerInfo.HasBuff(460) && Recast.GetAbilityRecast(11) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Blood Rage\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Brazen Rush [1HR] - (Warrior)") && !PlayerInfo.HasBuff(16) && !PlayerInfo.HasBuff(340) &&
                !PlayerInfo.HasBuff(490) && Recast.GetAbilityRecast(254) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Brazen Rush\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region MNK JA
            if (ja.Contains("Hundred Fists [1HR] - (Monk)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(46) && Recast.GetAbilityRecast(0) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Hundred Fists\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Boost - (Monk)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(45) && Recast.GetAbilityRecast(16) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Boost\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Dodge - (Monk)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(60) && Recast.GetAbilityRecast(14) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Dodge\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Focus - (Monk)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(59) && Recast.GetAbilityRecast(13) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Focus\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Chi Blast - (Monk)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(18) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Chi Blast\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Chakra - (Monk)") && !PlayerInfo.HasBuff(16) &&
                PlayerInfo.HPP <= 90 && Recast.GetAbilityRecast(15) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Chakra\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Counterstance - (Monk)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(61) && Recast.GetAbilityRecast(17) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Counterstance\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Footwork - (Monk)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(406) && Recast.GetAbilityRecast(21) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Footwork\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Mantra - (Monk)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(19) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Mantra\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Formless Strikes - (Monk)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(341) && Recast.GetAbilityRecast(20) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Formless Strikes\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Perfect Counter - (Monk)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(436) && Recast.GetAbilityRecast(22) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Perfect Counter\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Impetus - (Monk)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(461) && Recast.GetAbilityRecast(31) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Impetus\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Inner Strength [1HR] - (Monk)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(491) && Recast.GetAbilityRecast(254) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Inner Strength\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region WHM JA
            if (ja.Contains("Benediction [1HR] - (White Mage)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(46) && Recast.GetAbilityRecast(0) == 0 && PlayerInfo.HPP <= 25 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Benediction\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Afflatus Solace - (White Mage)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(417) && Recast.GetAbilityRecast(29) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Afflatus Solace\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Afflatus Misery - (White Mage)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(418) && Recast.GetAbilityRecast(30) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Afflatus Misery\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Sacrosanctity - (White Mage)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(477) && Recast.GetAbilityRecast(33) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Sacrosanctity\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Asylum [1HR] - (White Mage)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(492) && Recast.GetAbilityRecast(254) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Asylum\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            /* #region BLM JA
            #endregion */
            #region RDM JA
            if (ja.Contains("Composure - (Red Mage)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(419) && Recast.GetAbilityRecast(50) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Composure\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region THF JA
            if (ja.Contains("Mug - (Thief)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(65) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Mug\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Feint - (Thief)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(68) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Feint\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Assassin's Charge - (Thief)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(67) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Assassin's Charge\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Conspirator - (Thief)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(40) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Conspirator\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Bully - (Thief)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(240) == 0 && TargetInfo.HPP > 10 && 
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Bully\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Bully + Sneak Attack - (Thief)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(64) == 0 &&
                Recast.GetAbilityRecast(240) == 0 &&
                TargetInfo.HPP > 10 && PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Bully\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
                api.ThirdParty.SendString("/ja \"Sneak Attack\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Despoil - (Thief)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(61) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Despoil\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Steal - (Thief)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(61) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Steal\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Larceny - (Thief)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(254) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Larceny\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region PLD JA
            if (ja.Contains("Holy Circle - (Paladin)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(74) && Recast.GetAbilityRecast(74) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Holy Circle\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Shield Bash - (Paladin)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(73) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Shield Bash\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Sentinel - (Paladin)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(62) && Recast.GetAbilityRecast(75) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Sentinel\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Rampart - (Paladin)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(77) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Rampart\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Fealty - (Paladin)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(344) && Recast.GetAbilityRecast(78) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Fealty\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Chivalry TP > 100% - (Paladin)") && !PlayerInfo.HasBuff(16) &&
                PlayerInfo.TP >= 1000 && Recast.GetAbilityRecast(79) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Chivalry\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Chivalry TP > 200% - (Paladin)") && !PlayerInfo.HasBuff(16) &&
                PlayerInfo.TP >= 2000 && Recast.GetAbilityRecast(79) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Chivalry\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Chivalry TP > 300% - (Paladin)") && !PlayerInfo.HasBuff(16) &&
                PlayerInfo.TP >= 3000 && Recast.GetAbilityRecast(79) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Chivalry\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Divine Emblem - (Paladin)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(438) && Recast.GetAbilityRecast(80) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Divine Emblem\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Palisade - (Paladin)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(478) && Recast.GetAbilityRecast(42) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Palisade\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Phalanx - (Paladin)") && !PlayerInfo.HasBuff(16) && PlayerInfo.MPP > 21 &&
                !PlayerInfo.HasBuff(116) && Recast.GetSpellRecast(106) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ma \"Phalanx\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(11.0));
            }
            if (ja.Contains("Enlight - (Paladin)") && !PlayerInfo.HasBuff(16) && PlayerInfo.MPP > 24 &&
                !PlayerInfo.HasBuff(274) && Recast.GetSpellRecast(310) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ma \"Enlight\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(14.0));
            }
            if (ja.Contains("Enlight II - (Paladin)") && !PlayerInfo.HasBuff(16) && PlayerInfo.MPP > 36 &&
                !PlayerInfo.HasBuff(274) && Recast.GetSpellRecast(855) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ma \"Enlight II\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(14.0));
            }
            if (ja.Contains("Reprisal - (Paladin)") && !PlayerInfo.HasBuff(16) && PlayerInfo.MPP > 24 &&
                !PlayerInfo.HasBuff(403) && Recast.GetSpellRecast(97) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ma \"Reprisal\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(6.0));
            }
            if (ja.Contains("Crusade - (Paladin)") && !PlayerInfo.HasBuff(16) && PlayerInfo.MPP > 18 &&
                !PlayerInfo.HasBuff(289) && Recast.GetSpellRecast(476) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ma \"Crusade\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(12.0));
            }
            if (ja.Contains("Intervene - (Paladin)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetSpellRecast(476) == 0 && PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ma \"Intervene\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region DRK JA
            if (ja.Contains("Arcane Circle - (Dark Knight)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(75) && Recast.GetAbilityRecast(86) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Arcane Circle\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Last Resort - (Dark Knight)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(64) && Recast.GetAbilityRecast(87) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Last Resort\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Weapon Bash - (Dark Knight)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(88) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Weapon Bash\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Souleater - (Dark Knight)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(63) && Recast.GetAbilityRecast(85) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Souleater\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Dark Seal - (Dark Knight)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(345) && Recast.GetAbilityRecast(89) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Dark Seal\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Diabolic Eye - (Dark Knight)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(346) && Recast.GetAbilityRecast(90) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Diabolic Eye\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Nether Void - (Dark Knight)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(439) && Recast.GetAbilityRecast(91) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Nether Void\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Arcane Crest - (Dark Knight)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(91) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Arcane Crest\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Scarlet Delirium - (Dark Knight)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(479) && Recast.GetAbilityRecast(44) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Scarlet Delirium\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Absorb-MND - (Dark Knight)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(85) && Recast.GetSpellRecast(271) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0 && PlayerInfo.MPP > 33)
            {
                api.ThirdParty.SendString("/ma \"Absorb-MND\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(4.0));
            }
            if (ja.Contains("Absorb-CHR - (Dark Knight)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(86) && Recast.GetSpellRecast(272) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0 && PlayerInfo.MPP > 33)
            {
                api.ThirdParty.SendString("/ma \"Absorb-CHR\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(4.0));
            }
            if (ja.Contains("Absorb-VIT - (Dark Knight)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(82) && Recast.GetSpellRecast(268) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0 && PlayerInfo.MPP > 33)
            {
                api.ThirdParty.SendString("/ma \"Absorb-VIT\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(4.0));
            }
            if (ja.Contains("Absorb-AGI - (Dark Knight)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(83) && Recast.GetSpellRecast(269) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0 && PlayerInfo.MPP > 33)
            {
                api.ThirdParty.SendString("/ma \"Absorb-AGI\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(4.0));
            }
            if (ja.Contains("Absorb-INT - (Dark Knight)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(84) && Recast.GetSpellRecast(270) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0 && PlayerInfo.MPP > 33)
            {
                api.ThirdParty.SendString("/ma \"Absorb-INT\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(4.0));
            }
            if (ja.Contains("Absorb-DEX - (Dark Knight)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(81) && Recast.GetSpellRecast(267) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0 && PlayerInfo.MPP > 33)
            {
                api.ThirdParty.SendString("/ma \"Absorb-DEX\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(4.0));
            }
            if (ja.Contains("Absorb-STR - (Dark Knight)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(80) && Recast.GetSpellRecast(266) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0 && PlayerInfo.MPP > 33)
            {
                api.ThirdParty.SendString("/ma \"Absorb-STR\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(4.0));
            }
            if (ja.Contains("Absorb-TP - (Dark Knight)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetSpellRecast(275) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0 && PlayerInfo.MPP > 33)
            {
                api.ThirdParty.SendString("/ma \"Absorb-TP\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(4.0));
            }
            if (ja.Contains("Absorb-ACC - (Dark Knight)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(90) && Recast.GetSpellRecast(242) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0 && PlayerInfo.MPP > 33)
            {
                api.ThirdParty.SendString("/ma \"Absorb-ACC\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(4.0));
            }
            if (ja.Contains("Absorb-Attri - (Dark Knight)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetSpellRecast(243) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0 && PlayerInfo.MPP > 33)
            {
                api.ThirdParty.SendString("/ma \"Absorb-Attri\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(4.0));
            }
            if (ja.Contains("Dread Spikes - (Dark Knight)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(173) && Recast.GetSpellRecast(277) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0 && PlayerInfo.MPP > 78)
            {
                api.ThirdParty.SendString("/ma \"Dread Spikes\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(8.0));
            }
            if (ja.Contains("Soul Enslavement - (Dark Knight)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(497) && Recast.GetAbilityRecast(254) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Soul Enslavement\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region RNG JA
            if (ja.Contains("Scavenge - (Ranger)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(121) == 0 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Scavenge\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Sharpshot - (Ranger)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(72) && Recast.GetAbilityRecast(124) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Sharpshot\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Barrage - (Ranger)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(73) && Recast.GetAbilityRecast(125) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Barrage\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Sharpshot + Barrage - (Ranger)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(73) && Recast.GetAbilityRecast(125) == 0 &&
                !PlayerInfo.HasBuff(72) && Recast.GetAbilityRecast(124) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Sharpshot\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
                api.ThirdParty.SendString("/ja \"Barrage\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Shadowbind - (Ranger)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(122) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Shadowbind\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Velocity Shot - (Ranger)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(371) && Recast.GetAbilityRecast(129) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Velocity Shot\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Unlimited Shot - (Ranger)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(115) && Recast.GetAbilityRecast(126) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Unlimited Shot\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Flashy Shot - (Ranger)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(351) && Recast.GetAbilityRecast(128) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Flashy Shot\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Stealth Shot - (Ranger)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(350) && Recast.GetAbilityRecast(127) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Stealth Shot\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Double Shot - (Ranger)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(433) && Recast.GetAbilityRecast(126) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Double Shot\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Bounty Shot - (Ranger)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(51) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Bounty Shot\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Decoy Shot - (Ranger)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(482) && Recast.GetAbilityRecast(52) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Decoy Shot\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Overkill - (Ranger)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(500) && Recast.GetAbilityRecast(254) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Overkill\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region SAM JA
            if (ja.Contains("Warding Circle - (Samurai)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(117) && Recast.GetAbilityRecast(135) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Warding Circle\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Third Eye - (Samurai)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(67) && Recast.GetAbilityRecast(133) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Third Eye\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Hasso - (Samurai)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(353) && Recast.GetAbilityRecast(138) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Hasso\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Meditate - (Samurai)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(134) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Meditate\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Seigan - (Samurai)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(354) && Recast.GetAbilityRecast(139) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Seigan\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Sekkanoki - (Samurai)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(408) && Recast.GetAbilityRecast(140) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Sekkanoki\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Blade Bash - (Samurai)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(137) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Blade Bash\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Shikikoyo - (Samurai)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(136) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Shikikoyo\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Hamanoha - (Samurai)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(465) && Recast.GetAbilityRecast(53) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Hamanoha\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Yaegasumi - (Samurai)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(501) && Recast.GetAbilityRecast(254) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Yaegasumi\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region NIN JA
            if (ja.Contains("Yonin - (Ninja)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(420) && Recast.GetAbilityRecast(146) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Yonin\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Innin - (Ninja)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(421) && Recast.GetAbilityRecast(147) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Innin\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Sange - (Ninja)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(352) && Recast.GetAbilityRecast(145) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Sange\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Futae - (Ninja)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(441) && Recast.GetAbilityRecast(148) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Futae\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Issekigan - (Ninja)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(484) && Recast.GetAbilityRecast(57) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {

                api.ThirdParty.SendString("/ja \"Issekigan\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Myoshu: Ichi - (Ninja)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(290) && Recast.GetAbilityRecast(507) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Myoshu: Ichi\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(4.5));
            }
            if (ja.Contains("Migawari: Ichi - (Ninja)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(471) && Recast.GetAbilityRecast(510) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Migawari: Ichi\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
            }
            if (ja.Contains("Kakka: Ichi - (Ninja)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(227) && Recast.GetAbilityRecast(509) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Kakka: Ichi\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(4.5));
            }
            if (ja.Contains("Mikage - (Ninja)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(502) && Recast.GetAbilityRecast(254) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Mikage\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region DRG JA
            if (ja.Contains("Ancient Circle - (Dragoon)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(118) && Recast.GetAbilityRecast(157) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Ancient Circle\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Jump - (Dragoon)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(158) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Jump\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("High Jump - (Dragoon)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(159) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"High Jump\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Super Jump - (Dragoon)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(160) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Super Jump\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Angon - (Dragoon)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(165) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Angon\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Spirit Jump - (Dragoon)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(158) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Spirit Jump\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Soul Jump - (Dragoon)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(159) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Soul Jump\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Dragon Breaker - (Dragoon)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(58) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Dragon Breaker\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Fly High - (Dragoon)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(254) == 0 && !PlayerInfo.HasBuff(503) &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Fly High\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region COR JA
            if (ja.Contains("Phantom Roll - (Corsair)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(193) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Phantom Roll\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Double-Up - (Corsair)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(194) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Double-Up\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Random Deal - (Corsair)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(196) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Random Deal\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Snake Eye - (Corsair)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(357) && Recast.GetAbilityRecast(197) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Snake Eye\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Fold - (Corsair)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(198) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Fold\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Triple Shot - (Corsair)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(467) && Recast.GetAbilityRecast(84) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Triple Shot\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Cutting Cards - (Corsair)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(254) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Cutting Cards\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region DNC JA
            if (ja.Contains("Saber Dance - (DNC)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(410) && Recast.GetAbilityRecast(219) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Saber Dance\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Fan Dance - (DNC)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(411) && Recast.GetAbilityRecast(224) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Fan Dance\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Presto - (DNC)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(442) && Recast.GetAbilityRecast(236) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Presto\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
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
            if (ja.Contains("Grand Pas - (DNC)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(507) && Recast.GetAbilityRecast(254) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Grand Pas\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region RUN JA
            if (ja.Contains("Ignis - (Rune Fencer)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(523) && Recast.GetAbilityRecast(10) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Ignis\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Gelus - (Rune Fencer)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(524) && Recast.GetAbilityRecast(10) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Gelus\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Flabra - (Rune Fencer)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(525) && Recast.GetAbilityRecast(10) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Flabra\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Tellus - (Rune Fencer)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(526) && Recast.GetAbilityRecast(10) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Tellus\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Sulpor - (Rune Fencer)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(527) && Recast.GetAbilityRecast(10) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Sulpor\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Unda - (Rune Fencer)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(528) && Recast.GetAbilityRecast(10) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Unda\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Lux - (Rune Fencer)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(529) && Recast.GetAbilityRecast(10) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Lux\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Tenebrae - (Rune Fencer)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(530) && Recast.GetAbilityRecast(10) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Tenebrae\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Vallation - (Rune Fencer)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(531) && Recast.GetAbilityRecast(23) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Vallation\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            else if (ja.Contains("Valiance - (Rune Fencer)") && PlayerInfo.HasBuff(531) == false &&
                     Recast.GetAbilityRecast(113) == 0 && PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Valiance\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Pflug - (Rune Fencer)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(533) && Recast.GetAbilityRecast(59) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Pflug\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Valiance - (Rune Fencer)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(535) &&
                !PlayerInfo.HasBuff(531) &&
                Recast.GetAbilityRecast(113) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Valiance\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Liement - (Rune Fencer)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(537) && Recast.GetAbilityRecast(117) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Liement\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Lunge - (Rune Fencer)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(25) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Lunge\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Gambit - (Rune Fencer)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(116) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Gambit\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Swordplay - (Rune Fencer)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(532) && Recast.GetAbilityRecast(24) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Swordplay\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Embolden - (Rune Fencer)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(534) && Recast.GetAbilityRecast(72) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Embolden\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Battuta - (Rune Fencer)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(570) && Recast.GetAbilityRecast(120) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Battuta\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Rayke - (Rune Fencer)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(119) == 0 && PlayerInfo.Status == 1 &&
                TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"Rayke\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("One For All - (Rune Fencer)") && !PlayerInfo.HasBuff(16) &&
                !PlayerInfo.HasBuff(538) && Recast.GetAbilityRecast(118) == 0 &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                api.ThirdParty.SendString("/ja \"One For All\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
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

        }
        #endregion
        
        
        #region Methods: PET

        #region PET: BST
        
        #region JA: BST (get/set)
        private void BSTGetJA()
        {
            if (PetReady.Items.Count > 0)
                PetReady.Items.Clear();

            if (PetJA.Items.Count > 0)
                PetJA.Items.Clear();

            if (PetInfo.ID != 0)
                pInfo();

            if (PetInfo.Name != null && PetInfo.ID != 0)
            {
                switch (PetInfo.Name)
                {
                    #region Familiar: Frog
                    case "Slippery Silas":
                        break;
                    #endregion
                    #region Familiar: Rabbit
                    case "Hare Familiar":
                    case "Lucky Lulush":
                    case "Keeneared Steffi":
                    case "Droopy Dortwin":
                        if (!PetJA.Items.Contains("Whirl Claws"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Whirl Claws",
                        });
                        }
                        if (!PetJA.Items.Contains("Dust Cloud"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Dust Cloud",
                        });
                        }
                        if (!PetJA.Items.Contains("Foot Kick"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Foot Kick",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Sheep
                    case "Sheep Familiar":
                    case "Nursery Nazuna":
                    case "Rhyming Shizuna":
                    case "Lullaby Melodia":
                        if (!PetJA.Items.Contains("Sheep Song"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Sheep Song",
                        });
                        }
                        if (!PetJA.Items.Contains("Sheep Charge"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Sheep Charge",
                        });
                        }
                        if (!PetJA.Items.Contains("Lamb Chop"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Lamb Chop",
                        });
                        }
                        if (!PetJA.Items.Contains("Rage"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Rage",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Mandragora
                    case "Flowerpot Bill":
                    case "Flowerpot Ben":
                    case "Homunculus":
                    case "Sharpwit Hermes":
                        if (!PetJA.Items.Contains("Head Butt"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Head Butt",
                        });
                        }
                        if (!PetJA.Items.Contains("Scream"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Scream",
                        });
                        }
                        if (!PetJA.Items.Contains("Dream Flower"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Dream Flower",
                        });
                        }
                        if (!PetJA.Items.Contains("Wild Oats"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Wild Oats",
                        });
                        }
                        if (!PetJA.Items.Contains("Leaf Dagger"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Leaf Dagger",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Tiger
                    case "Tiger Familiar":
                    case "Saber Siravarde":
                    case "Gorefang Hobs":
                    case "Blackbeard Randy":
                        if (!PetJA.Items.Contains("Claw Cyclone"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Claw Cyclone",
                        });
                        }
                        if (!PetJA.Items.Contains("Razor Fang"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Razor Fang",
                        });
                        }
                        if (!PetJA.Items.Contains("Roar"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Roar",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Flytrap
                    case "Flytrap Familiar":
                    case "Voracious Audrey":
                    case "Presto Julio":
                        if (!PetJA.Items.Contains("Gloeosuccus"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Gloeosuccus",
                        });
                        }
                        if (!PetJA.Items.Contains("Palsy Pollen"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Palsy Pollen",
                        });
                        }
                        if (!PetJA.Items.Contains("Soporific"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Soporific",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Lizard
                    case "Lizard Familiar":
                    case "Coldblood Como":
                    case "Audacious Anna":
                    case "Warlike Patrick":
                        if (!PetJA.Items.Contains("Blockhead"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Blockhead",
                        });
                        }
                        if (!PetJA.Items.Contains("Secretion"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Secretion",
                        });
                        }
                        if (!PetJA.Items.Contains("Baleful Gaze"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Baleful Gaze",
                        });
                        }
                        if (!PetJA.Items.Contains("Fireball"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Fireball",
                        });
                        }
                        if (!PetJA.Items.Contains("Tail Blow"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Tail Blow",
                        });
                        }
                        if (!PetJA.Items.Contains("Plague Breath"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Plague Breath",
                        });
                        }
                        if (!PetJA.Items.Contains("Brain Crush"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Brain Crush",
                        });
                        }
                        if (!PetJA.Items.Contains("Infrasonics"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Infrasonics",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Fly
                    case "Mayfly Familiar":
                    case "Shellbuster Orob":
                    case "Mailbuster Cetas":
                    case "Headbreaker Ken":
                        if (!PetJA.Items.Contains("Cursed Sphere"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Cursed Sphere",
                        });
                        }
                        if (!PetJA.Items.Contains("Venom"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Venom",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Eft
                    case "Eft Familiar":
                    case "Ambusher Allie":
                    case "Bugeyed Broncha":
                        if (!PetJA.Items.Contains("Geist Wall"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Geist Wall",
                        });
                        }
                        if (!PetJA.Items.Contains("Toxic Spit"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Toxic Spit",
                        });
                        }
                        if (!PetJA.Items.Contains("Numbing Noise"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Numbing Noise",
                        });
                        }
                        if (!PetJA.Items.Contains("Nimble Snap"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Nimble Snap",
                        });
                        }
                        if (!PetJA.Items.Contains("Cyclotail"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Cyclotail",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Beetle
                    case "Beetle Familiar":
                    case "Panzer Galahad":
                    case "Hurler Percival":
                        if (!PetJA.Items.Contains("Spoil"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Spoil",
                        });
                        }
                        if (!PetJA.Items.Contains("Rhino Guard"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Rhino Guard",
                        });
                        }
                        if (!PetJA.Items.Contains("Rhino Attack"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Rhino Attack",
                        });
                        }
                        if (!PetJA.Items.Contains("Power Attack"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Power Attack",
                        });
                        }
                        if (!PetJA.Items.Contains("Hi-Freq Field"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Hi-Freq Field",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Antlion
                    case "Antlion Familiar":
                    case "Chopsuey Chucky":
                        if (!PetJA.Items.Contains("Sandpit"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Sandpit",
                        });
                        }
                        if (!PetJA.Items.Contains("Sandblast"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Sandblast",
                        });
                        }
                        if (!PetJA.Items.Contains("Venom Spray"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Venom Spray",
                        });
                        }
                        if (!PetJA.Items.Contains("Mandibular Bite"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Mandibular Bite",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Crab
                    case "Crab Familiar":
                    case "Courier Carrie":
                    case "Sunburst Malfik":
                    case "Herald Henry":
                        if (!PetJA.Items.Contains("Metallic Body"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Metallic Body",
                        });
                        }
                        if (!PetJA.Items.Contains("Bubble Shower"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Bubble Shower",
                        });
                        }
                        if (!PetJA.Items.Contains("Bubble Curtain"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Bubble Curtain",
                        });
                        }
                        if (!PetJA.Items.Contains("Scissor Guard"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Scissor Guard",
                        });
                        }
                        if (!PetJA.Items.Contains("Big Scissors"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Big Scissors",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Diremite
                    case "Mite Familiar":
                    case "Lifedrinker Lars":
                        if (!PetJA.Items.Contains("Grapple"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Grapple",
                        });
                        }
                        if (!PetJA.Items.Contains("Spinning Top"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Spinning Top",
                        });
                        }
                        if (!PetJA.Items.Contains("Double Claw"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Double Claw",
                        });
                        }
                        if (!PetJA.Items.Contains("Filamented Hold"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Filamented Hold",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Funguar
                    case "Funguar Familiar":
                    case "Discreet Louise":
                    case "Brainy Waluis":
                        if (!PetJA.Items.Contains("Frog Kick"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Frog Kick",
                        });
                        }
                        if (!PetJA.Items.Contains("Queasyshroom"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Queasyshroom",
                        });
                        }
                        if (!PetJA.Items.Contains("Silence Gas"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Silence Gas",
                        });
                        }
                        if (!PetJA.Items.Contains("Numbshroom"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Numbshroom",
                        });
                        }
                        if (!PetJA.Items.Contains("Spore"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Spore",
                        });
                        }
                        if (!PetJA.Items.Contains("Dark Spore"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Dark Spore",
                        });
                        }
                        if (!PetJA.Items.Contains("Shakeshroom"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Shakeshroom",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Sabotender
                    case "Amigo Sabotender":
                        if (!PetJA.Items.Contains("1000 Needles"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "1000 Needles",
                        });
                        }
                        if (!PetJA.Items.Contains("Needleshot"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Needleshot",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Coeurl
                    case "Crafty Clyvonne":
                        if (!PetJA.Items.Contains("Chaotic Eye"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Chaotic Eye",
                        });
                        }
                        if (!PetJA.Items.Contains("Blaster"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Blaster",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Raptor
                    case "Swift Sieghard":
                        if (!PetJA.Items.Contains("Scythe Tail"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Scythe Tail",
                        });
                        }
                        if (!PetJA.Items.Contains("Ripper Fang"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Ripper Fang",
                        });
                        }
                        if (!PetJA.Items.Contains("Chomp Rush"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Chomp Rush",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Pugils
                    case "Turbid Toloi":
                    case "Amiable Roche":
                        if (!PetJA.Items.Contains("Intimidate"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Intimidate",
                        });
                        }
                        if (!PetJA.Items.Contains("Recoil Dive"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Recoil Dive",
                        });
                        }
                        if (!PetJA.Items.Contains("Water Wall"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Water Wall",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Ladybug
                    case "Dipper Yuly":
                    case "Threestar Lynn":
                        if (!PetJA.Items.Contains("Sudden Lunge"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Sudden Lunge",
                        });
                        }
                        if (!PetJA.Items.Contains("Spiral Spin"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Spiral Spin",
                        });
                        }
                        if (!PetJA.Items.Contains("Noisome Powder"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Noisome Powder",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Lycopodium
                    case "Flowerpot Merle":
                    case "Sharpwi\"t\" Hermes":
                        if (!PetJA.Items.Contains("Head Butt"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Head Butt",
                        });
                        }
                        if (!PetJA.Items.Contains("Scream"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Scream",
                        });
                        }
                        if (!PetJA.Items.Contains("Wild Oats"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Wild Oats",
                        });
                        }
                        if (!PetJA.Items.Contains("Leaf Dagger"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Leaf Dagger",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Apkallu
                    case "Dapper Mac":
                        if (!PetJA.Items.Contains("Wing Slap"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Wing Slap",
                        });
                        }
                        if (!PetJA.Items.Contains("Beak Lunge"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Beak Lunge",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Leech
                    case "Fatso Fargann":
                        if (!PetJA.Items.Contains("Suction"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Suction",
                        });
                        }
                        if (!PetJA.Items.Contains("Drainkiss"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Drainkiss",
                        });
                        }
                        if (!PetJA.Items.Contains("Acid Mist"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Acid Mist",
                        });
                        }
                        if (!PetJA.Items.Contains("TP Drainkiss"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "TP Drainkiss",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Hippogryph
                    case "Faithful Falcorr":
                        if (!PetJA.Items.Contains("Back Heel"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Back Heel",
                        });
                        }
                        if (!PetJA.Items.Contains("Jettatura"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Jettatura",
                        });
                        }
                        if (!PetJA.Items.Contains("Choke Breath"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Choke Breath",
                        });
                        }
                        if (!PetJA.Items.Contains("Fantod"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Fantod",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Lynx
                    case "Bloodclaw Shasra":
                        if (!PetJA.Items.Contains("Chaotic Eye"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Chaotic Eye",
                        });
                        }
                        if (!PetJA.Items.Contains("Blaster"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Blaster",
                        });
                        }
                        if (!PetJA.Items.Contains("Charged Whisker"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Charged Whisker",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Slug
                    case "Gooey Gerard":
                    case "Generous Arthur":
                        if (!PetJA.Items.Contains("Purulent Ooze"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Purulent Ooze",
                        });
                        }
                        if (!PetJA.Items.Contains("Corrosive Ooze"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Corrosive Ooze",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Adamantoise
                    case "Crude Raphie":
                        if (!PetJA.Items.Contains("Tortoise Stomp"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Tortoise Stomp",
                        });
                        }
                        if (!PetJA.Items.Contains("Harden Shell"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Harden Shell",
                        });
                        }
                        if (!PetJA.Items.Contains("Aqua Breath"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Aqua Breath",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Chapuli
                    case "Scissorleg Xerin":
                        if (!PetJA.Items.Contains("Sensilla Blades"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Sensilla Blades",
                        });
                        }
                        if (!PetJA.Items.Contains("Tegmina Buffet"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Tegmina Buffet",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Tulfaires
                    case "Attentive Ibuki":
                        if (!PetJA.Items.Contains("Molting Plumage"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Molting Plumage",
                        });
                        }
                        if (!PetJA.Items.Contains("Swooping Frenzy"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Swooping Frenzy",
                        });
                        }
                        if (!PetJA.Items.Contains("Pentapeck"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Pentapeck",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Raaz
                    case "Caring Kiyomaro":
                        if (!PetJA.Items.Contains("Sweeping Gouge"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Sweeping Gouge",
                        });
                        }
                        if (!PetJA.Items.Contains("Zealous Snort"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Zealous Snort",
                        });
                        }
                        break;
                    #endregion
                    #region Familiar: Snapweed
                    case "Redolent Candi":
                    case "Alluring Honey":
                        if (!PetJA.Items.Contains("Tickling Tendrils"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Tickling Tendrils",
                        });
                        }
                        if (!PetJA.Items.Contains("Stink Bomb"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Stink Bomb",
                        });
                        }
                        if (!PetJA.Items.Contains("Nectarous Deluge"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Nectarous Deluge",
                        });
                        }
                        if (!PetJA.Items.Contains("Nepenthic Plunge"))
                        {
                            PetJA.Items.AddRange(new object[]
                        {
                            "Nepenthic Plunge",
                        });
                        }
                        break;
                    #endregion
                }
            }

            #region BST: Pet Ready

            #region Load MJ (main job)
            if (PlayerInfo.MainJobLevel >= 25 && 
                !PetReady.Items.Contains("Sic - (BST)"))
            {
                PetReady.Items.AddRange(new object[]
                {
                    "Sic - (BST)",
                });
            }
            if (PlayerInfo.MainJobLevel >= 45 && 
                !PetReady.Items.Contains("Snarl - (BST)"))
            {
                PetReady.Items.AddRange(new object[]
                {
                    "Snarl - (BST)",
                });
            }
            if (PlayerInfo.MainJobLevel >= 75 && PlayerInfo.HasAbility(162) &&
                !PetReady.Items.Contains("Killer Instinct - (BST)"))
            {
                PetReady.Items.AddRange(new object[]
                {
                    "Killer Instinct - (BST)",
                });
            }
            if (PlayerInfo.MainJobLevel >= 75 && PlayerInfo.HasAbility(161) &&
                !PetReady.Items.Contains("Feral Howl - (BST)"))
            {
                PetReady.Items.AddRange(new object[]
                {
                    "Feral Howl - (BST)",
                });
            }
            if (PlayerInfo.MainJobLevel >= 83 && 
                !PetReady.Items.Contains("Spur - (BST)"))
            {
                PetReady.Items.AddRange(new object[]
                {
                    "Spur - (BST)",
                });
            }
            if (PlayerInfo.MainJobLevel >= 93 && 
                !PetReady.Items.Contains("Run Wild - (BST)"))
            {
                PetReady.Items.AddRange(new object[]
                {
                    "Run Wild - (BST)",
                });
            }
            if (PlayerInfo.MainJobLevel >= 96 &&
                !PetReady.Items.Contains("Unleash - (BST)"))
            {
                PetReady.Items.AddRange(new object[]
                {
                    "Unleash - (BST)",
                });
            }
            #endregion
            #region Load SJ (sub job)
            if (PlayerInfo.SubJob == 9)
            {
                if (PlayerInfo.SubJobLevel >= 25 &&
                    !PetReady.Items.Contains("Sic - (BST)"))
                {
                    PetReady.Items.AddRange(new object[]
                    {
                        "Sic - (BST)",
                    });
                }
                if (PlayerInfo.SubJobLevel >= 45 &&
                    !PetReady.Items.Contains("Snarl - (BST)"))
                {
                    PetReady.Items.AddRange(new object[]
                    {
                        "Snarl - (BST)",
                    });
                }
            }
            #endregion

            #endregion
        }
        public void pInfo()
        {
            label20.Text = "Pets Name: " + PetInfo.Name;
            label21.Text = @"Pet ID: " + PetInfo.ID;
            label22.Text = @"Pets HP%: " + PetInfo.HPP;
            label23.Text = @"Pets TP%: " + PetInfo.TPP;
        }

        #endregion
        #region JA: BST (use)
        private void PetReadyJA()
        {
            if (PlayerInfo.Status == 0 || !botRunning || TargetInfo.ID == 0)
                return;

            #region BST JA
            var bstja = (from object itemChecked in PetReady.CheckedItems
                         select itemChecked.ToString()).ToList();

            if (bstja.Contains("Sic - (BST)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(102) == 0)
            {
                api.ThirdParty.SendString("/pet \"Sic\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
            }
            if (bstja.Contains("Snarl - (BST)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(107) == 0)
            {
                api.ThirdParty.SendString("/pet \"Snarl\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
            }
            if (bstja.Contains("Spur - (BST)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(45) == 0)
            {
                api.ThirdParty.SendString("/pet \"Spur\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
            }
            if (bstja.Contains("Feral Howl - (BST)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(105) == 0)
            {
                api.ThirdParty.SendString("/pet \"Feral Howl\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
            }
            if (bstja.Contains("Killer Instinct - (BST)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(106) == 0)
            {
                api.ThirdParty.SendString("/pet \"Killer Instinct\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
            }
            if (bstja.Contains("Run Wild - (BST)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(46) == 0)
            {
                api.ThirdParty.SendString("/pet \"Run Wild\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (bstja.Contains("Unleash - (BST)") && !PlayerInfo.HasBuff(16) &&
                Recast.GetAbilityRecast(254) == 0 && !PlayerInfo.HasBuff(498))
            {
                api.ThirdParty.SendString("/pet \"Unleash\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region PET JA

            if (Recast.GetAbilityRecast(102) != 0)
                return;

            var petja = (from object itemChecked in PetJA.CheckedItems
                         select itemChecked.ToString()).ToList();

            #region Familiar: Rabbit
            if (PetInfo.Name == "Hare Familiar" ||
                PetInfo.Name == "Keeneared Steffi" ||
                PetInfo.Name == "Lucky Lulush" ||
                PetInfo.Name == "Droopy Dortwin")
            {
                if (petja.Contains("Wild Carrot"))
                {
                    api.ThirdParty.SendString("/pet \"Wild Carrot\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Whirl Claws"))
                {
                    api.ThirdParty.SendString("/pet \"Whirl Claws\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Dust Cloud"))
                {
                    api.ThirdParty.SendString("/pet \"Dust Cloud\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Foot Kick"))
                {
                    api.ThirdParty.SendString("/pet \"Foot Kick\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Sheep
            if (PetInfo.Name == "Sheep Familiar" ||
                PetInfo.Name == "Lullaby Melodia" ||
                PetInfo.Name == "Nursery Nazuna" ||
                PetInfo.Name == "Rhyming Shizuna")
            {
                if (petja.Contains("Lamb Chop"))
                {
                    api.ThirdParty.SendString("/pet \"Lamb Chop\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Rage"))
                {
                    api.ThirdParty.SendString("/pet \"Rage\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Sheep Charge"))
                {
                    api.ThirdParty.SendString("/pet \"Sheep Charge\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Sheep Song"))
                {
                    api.ThirdParty.SendString("/pet \"Sheep Song\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Mandragora
            if (PetInfo.Name == "Flowerpot Bill" ||
                PetInfo.Name == "Flowerpot Ben" ||
                PetInfo.Name == "Homunculus" ||
                PetInfo.Name == "Flowerpot Merle" ||
                PetInfo.Name == "Sharpwit Hermes")
            {
                if (petja.Contains("Head Butt"))
                {
                    api.ThirdParty.SendString("/pet \"Head Butt\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Scream"))
                {
                    api.ThirdParty.SendString("/pet \"Scream\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Dream Flower"))
                {
                    api.ThirdParty.SendString("/pet \"Dream Flower\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Wild Oats"))
                {
                    api.ThirdParty.SendString("/pet \"Wild Oats\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Leaf Dagger"))
                {
                    api.ThirdParty.SendString("/pet \"Leaf Dagger\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Tiger
            if (PetInfo.Name == "Tiger Familiar" ||
                PetInfo.Name == "Saber Siravarde" ||
                PetInfo.Name == "Gorefang Hobs" ||
                PetInfo.Name == "Blackbeard Randy")
            {
                if (petja.Contains("Claw Cyclone"))
                {
                    api.ThirdParty.SendString("/pet \"Claw Cyclone\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Razor Fang"))
                {
                    api.ThirdParty.SendString("/pet \"Razor Fang\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Roar"))
                {
                    api.ThirdParty.SendString("/pet \"Roar\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Flytrap
            if (PetInfo.Name == "Flytrap Familiar" ||
                PetInfo.Name == "Voracious Audrey" ||
                PetInfo.Name == "Presto Julio")
            {
                if (petja.Contains("Gloeosuccus"))
                {
                    api.ThirdParty.SendString("/pet \"Gloeosuccus\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Palsy Pollen"))
                {
                    api.ThirdParty.SendString("/pet \"Palsy Pollen\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Soporific"))
                {
                    api.ThirdParty.SendString("/pet \"Soporific\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Lizard
            if (PetInfo.Name == "Lizard Familiar" ||
                PetInfo.Name == "Coldblood Como" ||
                PetInfo.Name == "Audacious Anna" ||
                PetInfo.Name == "Warlike Patrick")
            {
                if (petja.Contains("Blockhead"))
                {
                    api.ThirdParty.SendString("/pet \"Blockhead\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Secretion"))
                {
                    api.ThirdParty.SendString("/pet \"Secretion\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Baleful Gaze"))
                {
                    api.ThirdParty.SendString("/pet \"Baleful Gaze\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Fireball"))
                {
                    api.ThirdParty.SendString("/pet \"Fireball\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Tail Blow"))
                {
                    api.ThirdParty.SendString("/pet \"Tail Blow\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Plague Breath"))
                {
                    api.ThirdParty.SendString("/pet \"Plague Breath\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Brain Crush"))
                {
                    api.ThirdParty.SendString("/pet \"Brain Crush\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Infrasonics"))
                {
                    api.ThirdParty.SendString("/pet \"Infrasonics\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Fly
            if (PetInfo.Name == "Mayfly Familiar" ||
                PetInfo.Name == "Shellbuster Orob" ||
                PetInfo.Name == "Mailbuster Cetas" ||
                PetInfo.Name == "Headbreaker Ken")
            {
                if (petja.Contains("Cursed Sphere"))
                {
                    api.ThirdParty.SendString("/pet \"Cursed Sphere\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Venom"))
                {
                    api.ThirdParty.SendString("/pet \"Venom\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Eft
            if (PetInfo.Name == "Eft Familiar" ||
                PetInfo.Name == "Ambusher Allie" ||
                PetInfo.Name == "Bugeyed Broncha")
            {
                if (petja.Contains("Geist Wall"))
                {
                    api.ThirdParty.SendString("/pet \"Geist Wall\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Toxic Spit"))
                {
                    api.ThirdParty.SendString("/pet \"Toxic Spit\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Numbing Noise"))
                {
                    api.ThirdParty.SendString("/pet \"Numbing Noise\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Nimble Snap"))
                {
                    api.ThirdParty.SendString("/pet \"Nimble Snap\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Cyclotail"))
                {
                    api.ThirdParty.SendString("/pet \"Cyclotail\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Beetle
            if (PetInfo.Name == "Beetle Familiar" ||
                PetInfo.Name == "Panzer Galahad" ||
                PetInfo.Name == "Hurler Percival")
            {
                if (petja.Contains("Spoil"))
                {
                    api.ThirdParty.SendString("/pet \"Spoil\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Rhino Guard"))
                {
                    api.ThirdParty.SendString("/pet \"Rhino Guard\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Rhino Attack"))
                {
                    api.ThirdParty.SendString("/pet \"Rhino Attack\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Power Attack"))
                {
                    api.ThirdParty.SendString("/pet \"Power Attack\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Hi-Freq Field"))
                {
                    api.ThirdParty.SendString("/pet \"Hi-Freq Field\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Antlion
            if (PetInfo.Name == "Antlion Familiar" ||
                PetInfo.Name == "Chopsuey Chucky")
            {
                if (petja.Contains("Sandpit"))
                {
                    api.ThirdParty.SendString("/pet \"Sandpit\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Sandblast"))
                {
                    api.ThirdParty.SendString("/pet \"Sandblast\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Venom Spray"))
                {
                    api.ThirdParty.SendString("/pet \"Venom Spray\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Mandibular Bite"))
                {
                    api.ThirdParty.SendString("/pet \"Mandibular Bite\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Crab

            if (PetInfo.Name == "Crab Familiar" ||
                PetInfo.Name == "Courier Carrie" ||
                PetInfo.Name == "Sunburst Malfik" ||
                PetInfo.Name == "Herald Henry")
            {
                if (petja.Contains("Metallic Body"))
                {
                    api.ThirdParty.SendString("/pet \"Metallic Body\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Bubble Shower"))
                {
                    api.ThirdParty.SendString("/pet \"Bubble Shower\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Bubble Curtain"))
                {
                    api.ThirdParty.SendString("/pet \"Bubble Curtain\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Scissor Guard"))
                {
                    api.ThirdParty.SendString("/pet \"Scissor Guard\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Big Scissors"))
                {
                    api.ThirdParty.SendString("/pet \"Big Scissors\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Diremite
            if (PetInfo.Name == "Mite Familiar" ||
                PetInfo.Name == "Lifedrinker Lars")
            {
                if (petja.Contains("Grapple"))
                {
                    api.ThirdParty.SendString("/pet \"Grapple\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Spinning Top"))
                {
                    api.ThirdParty.SendString("/pet \"Spinning Top\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Double Claw"))
                {
                    api.ThirdParty.SendString("/pet \"Double Claw\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Filamented Hold"))
                {
                    api.ThirdParty.SendString("/pet \"Filamented Hold\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Funguar
            if (PetInfo.Name == "Funguar Familiar" ||
                PetInfo.Name == "Discreet Louise" ||
                PetInfo.Name == "Brainy Waluis")
            {
                if (petja.Contains("Frog Kick"))
                {
                    api.ThirdParty.SendString("/pet \"Frog Kick\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Queasyshroom"))
                {
                    api.ThirdParty.SendString("/pet \"Queasyshroom\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Silence Gas"))
                {
                    api.ThirdParty.SendString("/pet \"Silence Gas\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Numbshroom"))
                {
                    api.ThirdParty.SendString("/pet \"Numbshroom\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Spore"))
                {
                    api.ThirdParty.SendString("/pet \"Spore\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Dark Spore"))
                {
                    api.ThirdParty.SendString("/pet \"Dark Spore\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Shakeshroom"))
                {
                    api.ThirdParty.SendString("/pet \"Shakeshroom\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Sabotender
            if (PetInfo.Name == "Amigo Sabotender")
            {
                if (petja.Contains("1000 Needles"))
                {
                    api.ThirdParty.SendString("/pet \"1000 Needles\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Needleshot"))
                {
                    api.ThirdParty.SendString("/pet \"Needleshot\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Coeurl/Linx
            if (PetInfo.Name == "Crafty Clyvonne" ||
                PetInfo.Name == "Bloodclaw Shasra")
            {
                if (petja.Contains("Chaotic Eye"))
                {
                    api.ThirdParty.SendString("/pet \"Chaotic Eye\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Blaster"))
                {
                    api.ThirdParty.SendString("/pet \"Blaster\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Charged Whisker"))
                {
                    api.ThirdParty.SendString("/pet \"Charged Whisker\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Raptor
            if (PetInfo.Name == "Swift Sieghard")
            {
                if (petja.Contains("Scythe Tail"))
                {
                    api.ThirdParty.SendString("/pet \"Scythe Tail\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Ripper Fang"))
                {
                    api.ThirdParty.SendString("/pet \"Ripper Fang\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Chomp Rush"))
                {
                    api.ThirdParty.SendString("/pet \"Chomp Rush\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Pugils
            if (PetInfo.Name == "Turbid Toloi" ||
                PetInfo.Name == "Amiable Roche")
            {
                if (petja.Contains("Intimidate"))
                {
                    api.ThirdParty.SendString("/pet \"Intimidate\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Recoil Dive"))
                {
                    api.ThirdParty.SendString("/pet \"Recoil Dive\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Water Wall"))
                {
                    api.ThirdParty.SendString("/pet \"Water Wall\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Ladybug
            if (PetInfo.Name == "Dipper Yuly" ||
                PetInfo.Name == "Threestar Lynn")
            {
                if (petja.Contains("Sudden Lunge"))
                {
                    api.ThirdParty.SendString("/pet \"Sudden Lunge\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Spiral Spin"))
                {
                    api.ThirdParty.SendString("/pet \"Spiral Spin\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Noisome Powder"))
                {
                    api.ThirdParty.SendString("/pet \"Noisome Powder\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Apkallu
            if (PetInfo.Name == "Dapper Mac")
            {
                if (petja.Contains("Wing Slap"))
                {
                    api.ThirdParty.SendString("/pet \"Wing Slap\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Beak Lunge"))
                {
                    api.ThirdParty.SendString("/pet \"Beak Lunge\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Leech
            if (PetInfo.Name == "Fatso Fargann")
            {
                if (petja.Contains("Suction"))
                {
                    api.ThirdParty.SendString("/pet \"Suction\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Drainkiss"))
                {
                    api.ThirdParty.SendString("/pet \"Drainkiss\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Acid Mist"))
                {
                    api.ThirdParty.SendString("/pet \"Acid Mist\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("TP Drainkiss"))
                {
                    api.ThirdParty.SendString("/pet \"TP Drainkiss\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Hippogryph
            if (PetInfo.Name == "Faithful Falcorr")
            {
                if (petja.Contains("Back Heel"))
                {
                    api.ThirdParty.SendString("/pet \"Back Heel\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Jettatura"))
                {
                    api.ThirdParty.SendString("/pet \"Jettatura\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Choke Breath"))
                {
                    api.ThirdParty.SendString("/pet \"Choke Breath\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Fantod"))
                {
                    api.ThirdParty.SendString("/pet \"Fantod\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Slug
            if (PetInfo.Name == "Gooey Gerard" ||
                PetInfo.Name == "Generous Arthur")
            {
                if (petja.Contains("Purulent Ooze"))
                {
                    api.ThirdParty.SendString("/pet \"Purulent Ooze\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Corrosive Ooze"))
                {
                    api.ThirdParty.SendString("/pet \"Corrosive Ooze\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Adamantoise
            if (PetInfo.Name == "Crude Raphie")
            {
                if (petja.Contains("Tortoise Stomp"))
                {
                    api.ThirdParty.SendString("/pet \"Tortoise Stomp\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Harden Shell"))
                {
                    api.ThirdParty.SendString("/pet \"Harden Shell\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Aqua Breath"))
                {
                    api.ThirdParty.SendString("/pet \"Aqua Breath\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Chapuli
            if (PetInfo.Name == "Scissorleg Xerin")
            {
                if (petja.Contains("Sensilla Blades"))
                {
                    api.ThirdParty.SendString("/pet \"Sensilla Blades\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Tegmina Buffet"))
                {
                    api.ThirdParty.SendString("/pet \"Tegmina Buffet\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Tulfaires
            if (PetInfo.Name == "Attentive Ibuki")
            {
                if (petja.Contains("Molting Plumage"))
                {
                    api.ThirdParty.SendString("/pet \"Molting Plumage\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Swooping Frenzy"))
                {
                    api.ThirdParty.SendString("/pet \"Swooping Frenzy\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Pentapeck"))
                {
                    api.ThirdParty.SendString("/pet \"Pentapeck\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Raaz
            if (PetInfo.Name == "Caring Kiyomaro")
            {
                if (petja.Contains("Sweeping Gouge"))
                {
                    api.ThirdParty.SendString("/pet \"Sweeping Gouge\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Zealous Snort"))
                {
                    api.ThirdParty.SendString("/pet \"Zealous Snort\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region Familiar: Snapweed
            if (PetInfo.Name == "")
            {
                if (petja.Contains("Tickling Tendrils"))
                {
                    api.ThirdParty.SendString("/pet \"Tickling Tendrils\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Stink Bomb"))
                {
                    api.ThirdParty.SendString("/pet \"Stink Bomb\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Nectarous Deluge"))
                {
                    api.ThirdParty.SendString("/pet \"Nectarous Deluge\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Nepenthic Plunge"))
                {
                    api.ThirdParty.SendString("/pet \"Nepenthic Plunge\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion

            #endregion
        }
        #endregion

        #endregion
        #region PET: DRG

        #region JA: DRG (get/set)
        private void WyvernGetJA()
        {
            if (WyvernJA.Items.Count > 0)
                WyvernJA.Items.Clear();

            if (PlayerInfo.MainJob != 14 || PlayerInfo.SubJob != 14)
                return;

            #region JA: DRG
            if ((PlayerInfo.MainJobLevel >= 25 || PlayerInfo.SubJobLevel >= 25) && 
                 !WyvernJA.Items.Contains("Spirit Link - (Dragoon)"))
            {
                WyvernJA.Items.AddRange(new object[]
                {
                    "Spirit Link - (Dragoon)",
                });
            }
            if (PlayerInfo.MainJobLevel >= 75 && PlayerInfo.HasAbility(169) &&
                !WyvernJA.Items.Contains("Deep Breathing - (Dragoon)"))
            {
                WyvernJA.Items.AddRange(new object[]
                {
                    "Deep Breathing - (Dragoon)",
                });
            }
            if (PlayerInfo.MainJobLevel >= 90 && 
                !WyvernJA.Items.Contains("Smiting Breath - (Dragoon)"))
            {
                WyvernJA.Items.AddRange(new object[]
                {
                    "Smiting Breath - (Dragoon)",
                    "Restoring Breath - (Dragoon)",
                });
            }
            if (PlayerInfo.MainJobLevel >= 95 && 
                !WyvernJA.Items.Contains("Steady Wing - (Dragoon)"))
            {
                WyvernJA.Items.AddRange(new object[]
                {
                    "Steady Wing - (Dragoon)",
                });
            }
            #endregion
        }

        #endregion
        #region JA: DRG (use)
        private void WyvernUseJA()
        {
            var petja = (from object itemChecked in WyvernJA.CheckedItems
                         select itemChecked.ToString()).ToList();

            if (petja.Count == 0 || PlayerInfo.Status == 0 || !PlayerInfo.HasBuff(16))
                return;

            if (petja.Contains("Restoring Breath - (Dragoon)") && PlayerInfo.Status == 1 &&
                PlayerInfo.HPP <= RestoringBreathHP.Value && Recast.GetAbilityRecast(239) == 0)
            {
                if (petja.Contains("Deep Breathing - (Dragoon)") && !PlayerInfo.HasBuff(16) &&
                    Recast.GetAbilityRecast(164) == 0 && TargetInfo.ID > 0)
                {
                    api.ThirdParty.SendString("/ja \"Deep Breathing\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    api.ThirdParty.SendString("/pet \"Restoring Breath\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                else if (Recast.GetAbilityRecast(239) == 0)
                {
                    api.ThirdParty.SendString("/pet \"Restoring Breath\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }

            if (petja.Contains("Steady Wing - (Dragoon)") && PlayerInfo.Status == 1 &&
                PetInfo.HPP < DragonPetHP.Value && !PlayerInfo.HasBuff(16) && Recast.GetAbilityRecast(70) == 0)
            {
                api.ThirdParty.SendString("/pet \"Steady Wing\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }

            if (petja.Contains("Spirit Link - (Dragoon)") && PlayerInfo.Status == 1 &&
                PetInfo.HPP < WyvernSpirit.Value && PlayerInfo.HPP > PlayerSpirit.Value &&
                Recast.GetAbilityRecast(162) == 0 && !PlayerInfo.HasBuff(16))
            {
                api.ThirdParty.SendString("/ja \"Spirit Link\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }

            if (petja.Contains("Smiting Breath - (Dragoon)") && PlayerInfo.Status == 1 &&
                TargetInfo.HPP > BreathMIN.Value && TargetInfo.HPP <= BreathMAX.Value &&
                Recast.GetAbilityRecast(238) == 0 && !PlayerInfo.HasBuff(16))
            {
                if (petja.Contains("Deep Breathing - (Dragoon)") && !PlayerInfo.HasBuff(16) &&
                    Recast.GetAbilityRecast(164) == 0 && TargetInfo.ID > 0)
                {
                    api.ThirdParty.SendString("/ja \"Deep Breathing\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));

                    if (TargetInfo.ID > 0 && TargetInfo.HPP > BreathMIN.Value)
                        api.ThirdParty.SendString("/pet \"Smiting Breath\" <t>");

                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                else if (Recast.GetAbilityRecast(238) == 0)
                {
                    if (TargetInfo.ID > 0 && TargetInfo.HPP > BreathMIN.Value)
                        api.ThirdParty.SendString("/pet \"Smiting Breath\" <t>");

                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }

            if (petja.Contains("Deep Breathing - (Dragoon)") && PlayerInfo.Status == 1 &&
                Recast.GetAbilityRecast(164) == 0 && !PlayerInfo.HasBuff(16))
            {
                api.ThirdParty.SendString("/ja \"Deep Breathing\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
        }
        #endregion

        #endregion

        #endregion