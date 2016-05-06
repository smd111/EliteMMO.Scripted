
                #region pet: BST
                if (PlayerInfo.MainJob == 9 || PlayerInfo.SubJob == 9)
                {
                    if (juguse.Checked && PetInfo.ID == 0 && jugpet.Text != "" &&
                        Inventory.ItemQuantityByName(jugpet.Text) > 0)
                    {
                        #region Ammo/Ranged Slot
                        var rangedSlot = InventoryItems.Items.FirstOrDefault(x => x.Key == api.Inventory.GetEquippedItem(2).Id.ToString()).Value;
                        var ammoSlot = InventoryItems.Items.FirstOrDefault(x => x.Key == api.Inventory.GetEquippedItem(3).Id.ToString()).Value;
                        #endregion
                        var call = ""
                        if (Recast.GetAbilityRecast(94) == 0)
                            call = "Bestial Loyalty";
                        else if (Recast.GetAbilityRecast(104) == 0 && Recast.GetAbilityRecast(94) != 0)
                            call = "Call Beast";
                        
                        if (call != "")
                        {
                            WindowInfo.SendText($"/equip Ammo \"{jugpet.Text}\"");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            WindowInfo.SendText($"/ja \"{call}\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(2.0));
                        }

                        #region Re-Equip Ammo/Ranged
                        if (ammoSlot != null && ammoSlot != jugpet.Text)
                        {
                            WindowInfo.SendText("/equip Ammo \"" + ammoSlot + "\"");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        }
                        else if (rangedSlot != null)
                        {
                            WindowInfo.SendText("/equip Range \"" + rangedSlot + "\"");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        }
                        #endregion

                        if (TargetInfo.ID > 0 && TargetInfo.ID != PlayerInfo.ServerID && !TargetInfo.LockedOn)
                            WindowInfo.SendText("/lockon <t>");
                    }

                    if (PetInfo.ID > 0 && autoengage.Checked &&
                        PlayerInfo.Status == 1 && PetInfo.Status == 0 &&
                        TargetInfo.ID > 0)
                    {
                        WindowInfo.SendText("/ja \"Fight\" <t>");
                        Thread.Sleep(TimeSpan.FromSeconds(4.0));
                    }

                    if (petfooduse.Checked && Inventory.ItemQuantityByName(usedpetfood.Text) > 0 &&
                        PetInfo.ID > 0 && usedpetfood.Text != "" && PetInfo.HPP < pethppfood.Value &&
                        Recast.GetAbilityRecast(103) == 0)
                    {
                        #region Ammo/Ranged Slot
                        var rangedSlot = InventoryItems.Items.FirstOrDefault(x => x.Key == api.Inventory.GetEquippedItem(2).Id.ToString()).Value;
                        var ammoSlot = InventoryItems.Items.FirstOrDefault(x => x.Key == api.Inventory.GetEquippedItem(3).Id.ToString()).Value;
                        #endregion

                        WindowInfo.SendText("/equip Ammo \"" + usedpetfood.Text + "\"");
                        Thread.Sleep(TimeSpan.FromSeconds(2.0));
                        WindowInfo.SendText("/ja \"Reward\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(2.0));

                        #region Re-Equip Ammo/Ranged
                        if (ammoSlot != null && ammoSlot != usedpetfood.Text)
                        {
                            WindowInfo.SendText("/equip Ammo \"" + ammoSlot + "\"");
                            Thread.Sleep(TimeSpan.FromSeconds(2.0));
                        }
                        else if (rangedSlot != null)
                        {
                            WindowInfo.SendText("/equip Range \"" + rangedSlot + "\"");
                            Thread.Sleep(TimeSpan.FromSeconds(2.0));
                        }
                        #endregion
                    }

                    if (PetInfo.ID > 0 && PetJA.Items.Count > 0 && PetInfo.Status == 1 && 
                        PetInfo.TPP > 1000 && TargetInfo.ID > 0)
                    {
                        PetReadyJA();
                    }
                }
                #endregion


        #region JA: BST (get/set)
        private void BSTGetJA()
        {
            if (PetReady.Items.Count > 0) PetReady.Items.Clear();

            if (PetJA.Items.Count > 0)  PetJA.Items.Clear();

            if (PetInfo.ID != 0) pInfo();

            if (PetInfo.Name != null && PetInfo.ID != 0)
            {
                switch (PetInfo.Name)
                {
                    #region Familiar: Acuex
                    case "Acuex Familiar":
                    case "Fluffy Bredo":
                        break;
                    #endregion
                    #region Familiar: Adamantoise
                    case "Crude Raphie":
                        if (!PetJA.Items.Contains("Tortoise Stomp")) PetJA.Items.Add("Tortoise Stomp");
                        if (!PetJA.Items.Contains("Harden Shell")) PetJA.Items.Add("Harden Shell");
                        if (!PetJA.Items.Contains("Aqua Breath")) PetJA.Items.Add("Aqua Breath");
                        break;
                    #endregion
                    #region Familiar: Antlion
                    case "Antlion Familiar":
                    case "Cursed Annabelle":
                    case "Chopsuey Chucky":
                        if (!PetJA.Items.Contains("Sandpit")) PetJA.Items.Add("Sandpit");
                        if (!PetJA.Items.Contains("Sandblast")) PetJA.Items.Add("Sandblast");
                        if (!PetJA.Items.Contains("Venom Spray")) PetJA.Items.Add("Venom Spray");
                        if (!PetJA.Items.Contains("Mandibular Bite")) PetJA.Items.Add("Mandibular Bite");
                        break;
                    #endregion
                    #region Familiar: Apkallu
                    case "Surging Storm":
                    case "Submerged Iyo":
                    case "Dapper Mac":
                        if (!PetJA.Items.Contains("Wing Slap")) PetJA.Items.Add("Wing Slap");
                        if (!PetJA.Items.Contains("Beak Lunge")) PetJA.Items.Add("Beak Lunge");
                        break;
                    #endregion
                    #region Familiar: Beetle
                    case "Beetle Familiar":
                    case "Panzer Galahad":
                    case "Hurler Percival":
                        if (!PetJA.Items.Contains("Spoil")) PetJA.Items.Add("Spoil");
                        if (!PetJA.Items.Contains("Rhino Guard")) PetJA.Items.Add("Rhino Guard");
                        if (!PetJA.Items.Contains("Rhino Attack")) PetJA.Items.Add("Rhino Attack");
                        if (!PetJA.Items.Contains("Power Attack")) PetJA.Items.Add("Power Attack");
                        if (!PetJA.Items.Contains("Hi-Freq Field")) PetJA.Items.Add("Hi-Freq Field");
                        break;
                    #endregion
                    #region Familiar: Chapuli
                    case "Bouncing Bertha":
                    case "Scissorleg Xerin":
                        if (!PetJA.Items.Contains("Sensilla Blades")) PetJA.Items.Add("Sensilla Blades");
                        if (!PetJA.Items.Contains("Tegmina Buffet")) PetJA.Items.Add("Tegmina Buffet");
                        break;
                    #endregion
                    #region Familiar: Coeurl
                    case "Crafty Clyvonne":
                        if (!PetJA.Items.Contains("Chaotic Eye")) PetJA.Items.Add("Chaotic Eye");
                        if (!PetJA.Items.Contains("Blaster")) PetJA.Items.Add("Blaster");
                        break;
                    #endregion
                    #region Familiar: Colibri
                    case "Colibri Familiar":
                    case "Choral Leera":
                        break;
                    #endregion
                    #region Familiar: Crab
                    case "Crab Familiar":
                    case "Courier Carrie":
                    case "Sunburst Malfik":
                    case "Herald Henry":
                    case "Aged Angus":
                        if (!PetJA.Items.Contains("Metallic Body")) PetJA.Items.Add("Metallic Body");
                        if (!PetJA.Items.Contains("Bubble Shower")) PetJA.Items.Add("Bubble Shower");
                        if (!PetJA.Items.Contains("Bubble Curtain")) PetJA.Items.Add("Bubble Curtain");
                        if (!PetJA.Items.Contains("Scissor Guard")) PetJA.Items.Add("Scissor Guard");
                        if (!PetJA.Items.Contains("Big Scissors")) PetJA.Items.Add("Big Scissors");
                        break;
                    #endregion
                    #region Familiar: Diremite
                    case "Anklebiter Jedd":
                    case "Diremite Familiar":
                    case "Lifedrinker Lars":
                        if (!PetJA.Items.Contains("Grapple")) PetJA.Items.Add("Grapple");
                        if (!PetJA.Items.Contains("Spinning Top")) PetJA.Items.Add("Spinning Top");
                        if (!PetJA.Items.Contains("Double Claw")) PetJA.Items.Add("Double Claw");
                        if (!PetJA.Items.Contains("Filamented Hold")) PetJA.Items.Add("Filamented Hold");
                        break;
                    #endregion
                    #region Familiar: Eft
                    case "Eft Familiar":
                    case "Ambusher Allie":
                    case "Bugeyed Broncha":
                    case "Suspicious Alice":
                        if (!PetJA.Items.Contains("Geist Wall")) PetJA.Items.Add("Geist Wall");
                        if (!PetJA.Items.Contains("Toxic Spit")) PetJA.Items.Add("Toxic Spit");
                        if (!PetJA.Items.Contains("Numbing Noise")) PetJA.Items.Add("Numbing Noise");
                        if (!PetJA.Items.Contains("Nimble Snap")) PetJA.Items.Add("Nimble Snap");
                        if (!PetJA.Items.Contains("Cyclotail")) PetJA.Items.Add("Cyclotail");
                        break;
                    #endregion
                    #region Familiar: Fly
                    case "Mayfly Familiar":
                    case "Shellbuster Orob":
                    case "Mailbuster Cetas":
                    case "Headbreaker Ken":
                        if (!PetJA.Items.Contains("Cursed Sphere")) PetJA.Items.Add("Cursed Sphere");
                        if (!PetJA.Items.Contains("Venom")) PetJA.Items.Add("Venom");
                        break;
                    #endregion
                    #region Familiar: Flytrap
                    case "Flytrap Familiar":
                    case "Voracious Audrey":
                    case "Presto Julio":
                        if (!PetJA.Items.Contains("Gloeosuccus")) PetJA.Items.Add("Gloeosuccus");
                        if (!PetJA.Items.Contains("Palsy Pollen")) PetJA.Items.Add("Palsy Pollen");
                        if (!PetJA.Items.Contains("Soporific")) PetJA.Items.Add("Soporific");
                        break;
                    #endregion
                    #region Familiar: Funguar
                    case "Funguar Familiar":
                    case "Discreet Louise":
                    case "Brainy Waluis":
                        if (!PetJA.Items.Contains("Frog Kick")) PetJA.Items.Add("Frog Kick");
                        if (!PetJA.Items.Contains("Queasyshroom")) PetJA.Items.Add("Queasyshroom");
                        if (!PetJA.Items.Contains("Silence Gas")) PetJA.Items.Add("Silence Gas");
                        if (!PetJA.Items.Contains("Numbshroom")) PetJA.Items.Add("Numbshroom");
                        if (!PetJA.Items.Contains("Spore")) PetJA.Items.Add("Spore");
                        if (!PetJA.Items.Contains("Dark Spore")) PetJA.Items.Add("Dark Spore");
                        if (!PetJA.Items.Contains("Shakeshroom")) PetJA.Items.Add("Shakeshroom");
                        break;
                    #endregion
                    #region Familiar: Hippogryph
                    case "Faithful Falcorr":
                        if (!PetJA.Items.Contains("Back Heel")) PetJA.Items.Add("Back Heel");
                        if (!PetJA.Items.Contains("Jettatura")) PetJA.Items.Add("Jettatura");
                        if (!PetJA.Items.Contains("Choke Breath")) PetJA.Items.Add("Choke Breath");
                        if (!PetJA.Items.Contains("Fantod")) PetJA.Items.Add("Fantod");
                        break;
                    #endregion
                    #region Familiar: Ladybug
                    case "Dipper Yuly":
                    case "Threestar Lynn":
                        if (!PetJA.Items.Contains("Sudden Lunge")) PetJA.Items.Add("Sudden Lunge");
                        if (!PetJA.Items.Contains("Spiral Spin")) PetJA.Items.Add("Spiral Spin");
                        if (!PetJA.Items.Contains("Noisome Powder")) PetJA.Items.Add("Noisome Powder");
                        break;
                    #endregion
                    #region Familiar: Leech
                    case "Fatso Fargann":
                        if (!PetJA.Items.Contains("Suction")) PetJA.Items.Add("Suction");
                        if (!PetJA.Items.Contains("Drainkiss")) PetJA.Items.Add("Drainkiss");
                        if (!PetJA.Items.Contains("Acid Mist")) PetJA.Items.Add("Acid Mist");
                        if (!PetJA.Items.Contains("TP Drainkiss")) PetJA.Items.Add("TP Drainkiss");
                        break;
                    #endregion
                    #region Familiar: Lizard
                    case "Lizard Familiar":
                    case "Coldblood Como":
                    case "Audacious Anna":
                    case "Warlike Patrick":
                        if (!PetJA.Items.Contains("Blockhead")) PetJA.Items.Add("Blockhead");
                        if (!PetJA.Items.Contains("Secretion")) PetJA.Items.Add("Secretion");
                        if (!PetJA.Items.Contains("Baleful Gaze")) PetJA.Items.Add("Baleful Gaze");
                        if (!PetJA.Items.Contains("Fireball")) PetJA.Items.Add("Fireball");
                        if (!PetJA.Items.Contains("Tail Blow")) PetJA.Items.Add("Tail Blow");
                        if (!PetJA.Items.Contains("Plague Breath")) PetJA.Items.Add("Plague Breath");
                        if (!PetJA.Items.Contains("Brain Crush")) PetJA.Items.Add("Brain Crush");
                        if (!PetJA.Items.Contains("Infrasonics")) PetJA.Items.Add("Infrasonics");
                        break;
                    #endregion
                    #region Familiar: Lycopodium
                    case "Flowerpot Merle":
                        if (!PetJA.Items.Contains("Head Butt")) PetJA.Items.Add("Head Butt");
                        if (!PetJA.Items.Contains("Scream")) PetJA.Items.Add("Scream");
                        if (!PetJA.Items.Contains("Wild Oats")) PetJA.Items.Add("Wild Oats");
                        if (!PetJA.Items.Contains("Leaf Dagger")) PetJA.Items.Add("Leaf Dagger");
                        break;
                    #endregion
                    #region Familiar: Lynx
                    case "Bloodclaw Shasra":
                        if (!PetJA.Items.Contains("Chaotic Eye")) PetJA.Items.Add("Chaotic Eye");
                        if (!PetJA.Items.Contains("Blaster")) PetJA.Items.Add("Blaster");
                        if (!PetJA.Items.Contains("Charged Whisker")) PetJA.Items.Add("Charged Whisker");
                        break;
                    #endregion
                    #region Familiar: Mandragora
                    case "Flowerpot Bill":
                    case "Flowerpot Ben":
                    case "Homunculus":
                    case "Sharpwit Hermes":
                        if (!PetJA.Items.Contains("Head Butt")) PetJA.Items.Add("Head Butt");
                        if (!PetJA.Items.Contains("Scream")) PetJA.Items.Add("Scream");
                        if (!PetJA.Items.Contains("Dream Flower")) PetJA.Items.Add("Dream Flower");
                        if (!PetJA.Items.Contains("Wild Oats")) PetJA.Items.Add("Wild Oats");
                        if (!PetJA.Items.Contains("Leaf Dagger")) PetJA.Items.Add("Leaf Dagger");
                        break;
                    #endregion
                    #region Familiar: Mosquito
                    case "Mosquito Familiar":
                    case "Left-Handed Yoko":
                        break;
                    #endregion
                    #region Familiar: Pugils
                    case "Turbid Toloi":
                    case "Amiable Roche":
                        if (!PetJA.Items.Contains("Intimidate")) PetJA.Items.Add("Intimidate");
                        if (!PetJA.Items.Contains("Recoil Dive")) PetJA.Items.Add("Recoil Dive");
                        if (!PetJA.Items.Contains("Water Wall")) PetJA.Items.Add("Water Wall");
                        break;
                    #endregion
                    #region Familiar: Raaz
                    case "Caring Kiyomaro":
                    case "Vivacious Vickie":
                        if (!PetJA.Items.Contains("Sweeping Gouge")) PetJA.Items.Add("Sweeping Gouge");
                        if (!PetJA.Items.Contains("Zealous Snort")) PetJA.Items.Add("Zealous Snort");
                        break;
                    #endregion
                    #region Familiar: Rabbit
                    case "Pondering Peter":
                    case "Hare Familiar":
                    case "Keeneared Steffi":
                    case "Droopy Dortwin":
                    case "Lucky Lulush":
                        if (!PetJA.Items.Contains("Whirl Claws")) PetJA.Items.Add("Whirl Claws");
                        if (!PetJA.Items.Contains("Dust Cloud")) PetJA.Items.Add("Dust Cloud");
                        if (!PetJA.Items.Contains("Foot Kick")) PetJA.Items.Add("Foot Kick");
                        if (!PetJA.Items.Contains("Wild Carrot")) PetJA.Items.Add("Wild Carrot");
                        break;
                    #endregion
                    #region Familiar: Raptor
                    case "Swift Sieghard":
                    case "Fleet Reinhard":
                        if (!PetJA.Items.Contains("Scythe Tail")) PetJA.Items.Add("Scythe Tail");
                        if (!PetJA.Items.Contains("Ripper Fang")) PetJA.Items.Add("Ripper Fang");
                        if (!PetJA.Items.Contains("Chomp Rush")) PetJA.Items.Add("Chomp Rush");
                        break;
                    #endregion
                    #region Familiar: Sabotender
                    case "Amigo Sabotender":
                        if (!PetJA.Items.Contains("1000 Needles")) PetJA.Items.Add("1000 Needles");
                        if (!PetJA.Items.Contains("Needleshot")) PetJA.Items.Add("Needleshot");
                        break;
                    #endregion
                    #region Familiar: Sheep
                    case "Sheep Familiar":
                    case "Nursery Nazuna":
                    case "Rhyming Shizuna":
                    case "Lullaby Melodia":
                        if (!PetJA.Items.Contains("Sheep Song")) PetJA.Items.Add("Sheep Song");
                        if (!PetJA.Items.Contains("Sheep Charge")) PetJA.Items.Add("Sheep Charge");
                        if (!PetJA.Items.Contains("Lamb Chop")) PetJA.Items.Add("Lamb Chop");
                        if (!PetJA.Items.Contains("Rage")) PetJA.Items.Add("Rage");
                        break;
                    #endregion
                    #region Familiar: Slug
                    case "Gooey Gerard":
                    case "Generous Arthur":
                        if (!PetJA.Items.Contains("Purulent Ooze")) PetJA.Items.Add("Purulent Ooze");
                        if (!PetJA.Items.Contains("Corrosive Ooze")) PetJA.Items.Add("Corrosive Ooze");
                        break;
                    #endregion
                    #region Familiar: Spider
                    case "Spider Familiar":
                    case "Gussy Hachirobe":
                        break;
                    #endregion
                    #region Familiar: Snapweed
                    case "Redolent Candi":
                    case "Alluring Honey":
                        if (!PetJA.Items.Contains("Tickling Tendrils")) PetJA.Items.Add("Tickling Tendrils");
                        if (!PetJA.Items.Contains("Stink Bomb")) PetJA.Items.Add("Stink Bomb");
                        if (!PetJA.Items.Contains("Nectarous Deluge")) PetJA.Items.Add("Nectarous Deluge");
                        if (!PetJA.Items.Contains("Nepenthic Plunge")) PetJA.Items.Add("Nepenthic Plunge");
                        break;
                    #endregion
                    #region Familiar: Tiger
                    case "Tiger Familiar":
                    case "Saber Siravarde":
                    case "Gorefang Hobs":
                    case "Blackbeard Randy":
                        if (!PetJA.Items.Contains("Claw Cyclone")) PetJA.Items.Add("Claw Cyclone");
                        if (!PetJA.Items.Contains("Razor Fang")) PetJA.Items.Add("Razor Fang");
                        if (!PetJA.Items.Contains("Roar")) PetJA.Items.Add("Roar");
                        break;
                    #endregion
                    #region Familiar: Toad
                    case "Slippery Silas":
                    case "Brave Hero Glenn":
                        break;
                    #endregion
                    #region Familiar: Tulfaires
                    case "Attentive Ibuki":
                    case "Swooping Zhivago":
                        if (!PetJA.Items.Contains("Molting Plumage")) PetJA.Items.Add("Molting Plumage");
                        if (!PetJA.Items.Contains("Swooping Frenzy")) PetJA.Items.Add("Swooping Frenzy");
                        if (!PetJA.Items.Contains("Pentapeck")) PetJA.Items.Add("Pentapeck");
                        break;
                    #endregion
                }
            }

            #region BST: Pet Ready
            var joblvl = 0;
            if (PlayerInfo.MainJob == 9) joblvl = PlayerInfo.MainJobLevel;
            else if (PlayerInfo.SubJob == 9) joblvl = PlayerInfo.SubJobLevel;
            if (joblvl >= 25 && !PetReady.Items.Contains("Sic")) PetReady.Items.Add("Sic");
            if (joblvl >= 45 && !PetReady.Items.Contains("Snarl")) PetReady.Items.Add("Snarl");
            if (joblvl >= 75 && PlayerInfo.HasAbility(162) && !PetReady.Items.Contains("Killer Instinct")) PetReady.Items.Add("Killer Instinct");
            if (joblvl >= 75 && PlayerInfo.HasAbility(161) && !PetReady.Items.Contains("Feral Howl")) PetReady.Items.Add("Feral Howl");
            if (joblvl >= 83 && !PetReady.Items.Contains("Spur")) PetReady.Items.Add("Spur");
            if (joblvl >= 93 && !PetReady.Items.Contains("Run Wild")) PetReady.Items.Add("Run Wild");
            if (joblvl >= 96 && !PetReady.Items.Contains("Unleash")) PetReady.Items.Add("Unleash");
            #endregion
        }
        public void pInfo()
        {
            label20.Text = "Pets Name: " + PetInfo.Name;
            label21.Text = @"Pet ID: " + PetInfo.ID;
            label22.Text = @"Pets HP%: " + PetInfo.HPP;
            label23.Text = @"Pets TP: " + PetInfo.TPP;
        }
        #endregion
        #region JA: BST (use)
        private void PetReadyJA()
        {
            if (PlayerInfo.Status == 0 || !botRunning || TargetInfo.ID == 0) return;

            #region BST JA
            var bstja = (from object itemChecked in PetReady.CheckedItems select itemChecked.ToString()).ToList();();

            foreach (string D in bstja)
            {
                if (PlayerInfo.Status == 0 || !botRunning || TargetInfo.ID == 0) break;
                var ability = api.Resources.GetAbility(D, 0);
                if (PlayerInfo.HasAbility(ability.ID) && Recast.GetAbilityRecast(102) == 0 && !PlayerInfo.HasBuff(16))
                {
                    api.ThirdParty.SendString("/pet \""+ability.Name[0]+"\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region PET JA
            var petja = (from object itemChecked in PetJA.CheckedItems select itemChecked.ToString()).ToList();
            if (petja.Count == 0) return;

            foreach (string P in petja)
            {
                if (PlayerInfo.Status == 0 || !botRunning || TargetInfo.ID == 0) break;
                var ability = api.Resources.GetAbility(P, 0);
                if (PlayerInfo.HasAbility(ability.ID) && Recast.GetAbilityRecast(102) == 0 && !PlayerInfo.HasBuff(16))
                {
                    api.ThirdParty.SendString("/pet \""+ability.Name[0]+"\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
        }
        #endregion