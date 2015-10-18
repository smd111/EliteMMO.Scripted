namespace EliteMMO.Scripted.Views
{
    using System;
    using System.Windows.Forms;
    using System.Threading;
    using System.Linq;
    using API;
    using Embedded;
    using System.IO;

    public partial class ScriptFarmDNC : UserControl
    {
        public ScriptFarmDNC(EliteAPI core)
        {
            InitializeComponent();
            api = core;
        }

        #region Thread - DNC
        private void BgwScriptDncDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            const double scanInterval = 0.1;

            while (botRunning && !bgw_script_dnc.CancellationPending)
            {
                if (isCasting) continue;
                if (DeathWarp.Checked && (PlayerInfo.Status == 2 || PlayerInfo.Status == 3))
                    PlayerDead();

                if (followplayer.Checked && PlayerInfo.Status == 0)
                    FollowTarget();

                if (assist.Checked && PlayerInfo.Status == 0)
                    CheckPlayerAssist();

                if (aggro.Checked && PlayerInfo.Status == 0 && !isPulled)
                    DetectAggro();

                if (PlayerInfo.Status == 0 && !isPulled && SelectedTargets.Items.Count != 0)
                    FindTarget();

                while (PlayerInfo.Status == 1 && botRunning && TargetInfo.ID > 0)
                {
                    isPulled = true;

                    if (naviMove)
                        naviMove = false;

                    if (ignoreTarget.Count > 0)
                        ignoreTarget.Clear();

                    #region Check Target Distance
                    if (mobdist.Checked)
                    {
                        if (TargetInfo.Distance >= (float)KeepTargetRange.Value && TargetInfo.HPP > 1)
                        {
                            isMoving = true;
                            while (TargetMoving() && PlayerInfo.Status == 1 && botRunning)
                            {
                                Thread.Sleep(TimeSpan.FromSeconds(0.1));
                            }

                            while (TargetInfo.Distance >= (float)KeepTargetRange.Value &&
                                   TargetInfo.HPP > 1 && PlayerInfo.Status == 1 && botRunning)
                            {
                                api.AutoFollow.SetAutoFollowCoords(TargetInfo.X - PlayerInfo.X,
                                                                   TargetInfo.Y - PlayerInfo.Y,
                                                                   TargetInfo.Z - PlayerInfo.Z);

                                api.AutoFollow.IsAutoFollowing = true;
                                Thread.Sleep(TimeSpan.FromSeconds(0.1));

                                if (TargetInfo.ID == 0 || TargetInfo.ID == PlayerInfo.ServerID)
                                    break;
                            }
                            api.AutoFollow.IsAutoFollowing = false;
                            isMoving = false;

                        }
                        if (TargetInfo.Distance < 2 && TargetInfo.HPP > 1 &&
                            PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                        {
                            while (TargetInfo.Distance < 2 && TargetInfo.HPP > 1 &&
                                   PlayerInfo.Status == 1)
                            {
                                api.ThirdParty.KeyPress(API.Keys.NUMPAD2);
                            }
                        }
                    }
                    #endregion

                    if (!TargetInfo.IsFacingTarget(PlayerInfo.X, PlayerInfo.Z, PlayerInfo.H, TargetInfo.X, TargetInfo.Z) &&
                        facetarget.Checked && TargetInfo.HPP > 1)
                        TargetInfo.FaceTarget(TargetInfo.X, TargetInfo.Z);

                    ninjaShadows();

                    #region Check Hate Control
                    if (tank.Checked && selectedHateControl.Text != "" &&
                        PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                    {
                        if (selectedHateControl.Text == @"Animated Flourish" &&
                           (PlayerInfo.HasBuff(381) ||
                            PlayerInfo.HasBuff(382) ||
                            PlayerInfo.HasBuff(383) ||
                            PlayerInfo.HasBuff(384) ||
                            PlayerInfo.HasBuff(385) ||
                            PlayerInfo.HasBuff(588)) &&
                            Recast.GetAbilityRecast(221) == 0)
                        {
                            if (TargetInfo.HPP >= numericUpDown7.Value &&
                                TargetInfo.HPP <= numericUpDown6.Value &&
                                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                            {
                                api.ThirdParty.SendString("/ja \"Animated Flourish\" <t>");
                                Thread.Sleep(TimeSpan.FromSeconds(2.0));
                            }
                        }
                        if (selectedHateControl.Text == @"Provoke" &&
                            Recast.GetAbilityRecast(5) == 0)
                        {
                            if (TargetInfo.HPP >= numericUpDown7.Value &&
                                TargetInfo.HPP <= numericUpDown6.Value &&
                                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                            {
                                api.ThirdParty.SendString("/ja \"Provoke\" <t>");
                                Thread.Sleep(TimeSpan.FromSeconds(2.0));
                            }
                        }
                        if (selectedHateControl.Text == @"Flash" && PlayerInfo.MPP >= 25 &&
                            Recast.GetAbilityRecast(112) == 0)
                        {
                            if (TargetInfo.HPP >= numericUpDown7.Value &&
                                TargetInfo.HPP <= numericUpDown6.Value &&
                                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                            {
                                api.ThirdParty.SendString("/ma \"Flash\" <t>");
                                Thread.Sleep(TimeSpan.FromSeconds(2.0));
                            }
                        }
                    }
                    #endregion

                    HealingWaltz();
                    CuringWaltzSelf();

                    Sambas();
                    Steps();

                    #region Check AutoRange Attack
                    if (autoRangeAttack.Checked && TargetInfo.ID > 0)
                    {
                        api.ThirdParty.SendString(textBox7.Text);

                        var delay = DateTime.Now.AddSeconds((double)autoRangeDelay.Value);

                        while (DateTime.Now < delay)
                        {
                            if (PlayerInfo.Status == 0)
                                break;

                            TargetInfo.FaceTarget(TargetInfo.X, TargetInfo.Z);
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        }
                    }
                    #endregion
                    #region Check Use Food
                    if (usefood.Checked)
                    {
                        var foodname = textBox8.Text;

                        if (!PlayerInfo.HasBuff(251) && foodname != "" &&
                            ItemQuantityByName(foodname) > 0)
                        {
                            api.ThirdParty.SendString("/item \"" + foodname + "\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(10.0));
                        }
                    }
                    #endregion

                    PlayerJA();
                    PlayerWS();
                    PlayerMA();

                    if (PlayerInfo.HasBuff(381) ||
                        PlayerInfo.HasBuff(382) ||
                        PlayerInfo.HasBuff(383) ||
                        PlayerInfo.HasBuff(384) ||
                        PlayerInfo.HasBuff(385) ||
                        PlayerInfo.HasBuff(588))
                    {
                        if (userevfloValue.Value > 0 ||
                            usebldfloValue.Value > 0 ||
                            usewldfloValue.Value > 0 ||
                            useclmfloValue.Value > 0 ||
                            usestkfloValue.Value > 0 ||
                            useterfloValue.Value > 0)
                        {
                            if (TargetInfo.ID > 0)
                                UseFlourish();
                        }
                    }

                    Thread.Sleep(TimeSpan.FromSeconds(0.1));
                }

                #region check: scan delay & idle

                if (usenav.Checked && api.AutoFollow.IsAutoFollowing && !naviMove)
                    api.AutoFollow.IsAutoFollowing = false;


                if (ScanDelay.Checked && !naviMove)
                {
                    Thread.Sleep(TimeSpan.FromSeconds((double)numericUpDown38.Value));
                }
                else if (!ScanDelay.Checked)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(scanInterval));
                }

                if (PlayerInfo.Status == 0 && isPulled)
                {
                    isPulled = false;

                    if (aggro.Checked && PlayerInfo.Status == 0) DetectAggro();

                    if (PlayerInfo.Status == 0 && ((HealHP.Checked && PlayerInfo.HPP <= healHPcount.Value) ||
                        (HealMP.Checked && PlayerInfo.MPP <= healMPcount.Value)))
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        if ((PlayerInfo.MainJob == 15 || PlayerInfo.SubJob == 15) && PetInfo.ID > 0)
                        {
                            if (SMNPetNames.Contains(PetInfo.Name))
                            {
                                api.ThirdParty.SendString("/pet \"Release\" <me>");
                                Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            }
                        }
                        api.ThirdParty.SendString("/heal on");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        TargetInfo.SetTarget(0);

                    }
                    if (PlayerInfo.Status == 0 && !isPulled) FindTarget();
                }


                if (usenav.Checked && !naviMove && PlayerInfo.Status == 0)
                {
                    if (TargetInfo.ID > 0)
                        TargetInfo.SetTarget(0);
                    
                    naviMove = true;
                }

                while (PlayerInfo.Status == 33)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(0.1));
                    if (PlayerInfo.HPP == 100 && PlayerInfo.MPP == 100)
                    {
                        api.ThirdParty.SendString("/heal off");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                }
                #endregion
            }
        }
        #endregion
        #region Thread - PET
        private void BgwScriptPetDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (botRunning && !bgw_script_pet.CancellationPending)
            {

                if (PetInfo.Name != null) pInfo();
                #region pet: BST
                if (PlayerInfo.MainJob == 9 || PlayerInfo.SubJob == 9)
                {
                    if (juguse.Checked && PetInfo.ID == 0 && jugpet.Text != "" &&
                        ItemQuantityByName(jugpet.Text) > 0)
                    {
                        #region Ammo/Ranged Slot
                        var rangedSlot = InventoryItems.Items.FirstOrDefault(x => x.Key == api.Inventory.GetEquippedItem(2).Id.ToString()).Value;
                        var ammoSlot = InventoryItems.Items.FirstOrDefault(x => x.Key == api.Inventory.GetEquippedItem(3).Id.ToString()).Value;
                        #endregion

                        if (Recast.GetAbilityRecast(94) == 0)
                        {
                            WindowInfo.SendText("/equip Ammo \"" + jugpet.Text + "\"");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            WindowInfo.SendText("/ja \"Bestial Loyalty\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(2.0));
                        }
                        else if (Recast.GetAbilityRecast(104) == 0 && Recast.GetAbilityRecast(94) != 0)
                        {
                            WindowInfo.SendText("/equip Ammo \"" + jugpet.Text + "\"");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            WindowInfo.SendText("/ja \"Call Beast\" <me>");
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

                    if (petfooduse.Checked && ItemQuantityByName(usedpetfood.Text) > 0 &&
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

                    if (PetJA.Items.Count == 0 && PetInfo.ID != 0)
                        BSTGetJA();

                    if (PetInfo.ID > 0 && PetJA.Items.Count > 0 && PetInfo.Status == 1 && 
                        PetInfo.TPP > 1000 && TargetInfo.ID > 0)
                    {
                        PetReadyJA();
                    }
                }
                #endregion
                #region pet: DRG
                if (PlayerInfo.MainJob == 14 || PlayerInfo.SubJob == 14)
                {
                    if (PetInfo.ID == 0 && CallWyvern.Checked &&
                        Recast.GetAbilityRecast(163) == 0)
                    {
                        WindowInfo.SendText("/ja \"Call Wyvern\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(2.0));
                    }

                    if (WyvernJA.Items.Count == 0)
                        WyvernGetJA();

                    if (PetInfo.ID > 0 && WyvernJA.Items.Count > 0 &&
                        PlayerInfo.Status == 1 && !string.IsNullOrEmpty(TargetInfo.Name))
                    {
                        WyvernUseJA();
                    }
                }
                #endregion;
                if (PlayerInfo.MainJob == 15 || PlayerInfo.SubJob == 15 && SMNSelect.SelectedItem.ToString() != "") SMNUseJA();
                Thread.Sleep(TimeSpan.FromSeconds(0.1));
            }
        }
        #endregion
        #region Thread - NAV
        private void BgwScriptNavDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (botRunning && !bgw_script_nav.CancellationPending)
            {
                if (naviMove && usenav.Checked && selectedNavi.Text != "" && PlayerInfo.Status == 0 &&
                   (!PlayerInfo.HasBuff(10) || !PlayerInfo.HasBuff(11) || !PlayerInfo.HasBuff(0)))
                {
                    if (Circular.Checked)
                    {
                        var closestWayPoint = FindClosestWayPoint();
                        if (runReverse.Checked)
                        {
                            closestWayPoint--;
                        }
                        else
                        {
                            closestWayPoint++;
                        }
                        if (closestWayPoint >= navPathX.Count())
                        {
                            closestWayPoint = 0;
                        }

                        api.AutoFollow.SetAutoFollowCoords((float)navPathX[closestWayPoint] - PlayerInfo.X,
                                                        0, (float)navPathZ[closestWayPoint] - PlayerInfo.Z);

                        api.AutoFollow.IsAutoFollowing = true;
                    }
                    else if (Linear.Checked)
                    {
                       if (runReverse.Enabled)
                       {
                          runReverse.Enabled = false;
                          runReverse.Checked = false;
                       }

                       var closestWayPoint = FindClosestWayPoint();
                       if (closestWayPoint != -1)
                       {
                          if (!runReverse.Checked)
                          {
                             closestWayPoint++;
                             if (closestWayPoint >= navPathX.Count())
                             {
                                closestWayPoint -= 2;
                                runReverse.Checked = true;
                             }

                             api.AutoFollow.SetAutoFollowCoords((float)navPathX[closestWayPoint] - PlayerInfo.X,
                                                     0, (float)navPathZ[closestWayPoint] - PlayerInfo.Z);

                             api.AutoFollow.IsAutoFollowing = true;
                          }
                          else
                          {
                             closestWayPoint--;
                             if (closestWayPoint < 0)
                             {
                                closestWayPoint = 1;
                                runReverse.Checked = false;
                             }

                             api.AutoFollow.SetAutoFollowCoords((float)navPathX[closestWayPoint] - PlayerInfo.X,
                                                     0, (float)navPathZ[closestWayPoint] - PlayerInfo.Z);

                             api.AutoFollow.IsAutoFollowing = true;
                          }
                       }
                    }
                }
                else if (usenav.Checked && api.AutoFollow.IsAutoFollowing && !isMoving)
                {
                    api.AutoFollow.IsAutoFollowing = false;
                }

                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
        }
        #endregion
        #region Thread - SCH Charges
        private void BgwScriptSCHChargesDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (botRunning && !bgw_script_sch.CancellationPending)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.1));
                if (PlayerInfo.MainJob == 20 && PlayerInfo.MainJobLevel >= 90)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(48));
                    SchCharges++;
                    if (SchCharges > 5) SchCharges = 5;
                }
                else if (PlayerInfo.MainJob == 20 && PlayerInfo.MainJobLevel >= 70)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(60));
                    SchCharges++;
                    if (SchCharges > 4) SchCharges = 4;
                }
                else if (PlayerInfo.MainJob == 20 && PlayerInfo.MainJobLevel >= 50)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(80));
                    SchCharges++;
                    if (SchCharges > 3) SchCharges = 3;
                }
                else if ((PlayerInfo.MainJob == 20 && PlayerInfo.MainJobLevel >= 30) || (PlayerInfo.SubJob == 20 && PlayerInfo.SubJobLevel >= 30))
                {
                    Thread.Sleep(TimeSpan.FromSeconds(120));
                    SchCharges++;
                    if (SchCharges > 2) SchCharges = 2;
                }
                else if  ((PlayerInfo.MainJob == 20 && PlayerInfo.MainJobLevel >= 1) || (PlayerInfo.SubJob == 20 && PlayerInfo.SubJobLevel >= 1))
                {
                    Thread.Sleep(TimeSpan.FromSeconds(240));
                    SchCharges++;
                    if (SchCharges > 1) SchCharges = 1;
                }
            }
        }
        #endregion
        #region Thread - Chat Watch
        private void BgwScriptchatWatchDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (botRunning && !bgw_script_chat.CancellationPending && staggerstopJA.Checked)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.1));
                var line = api.Chat.GetNextChatLine();
                if (PlayerInfo.Status == 1)
                {
                    if (!string.IsNullOrEmpty(line?.Text) && 
                    line.Text.Contains(String.Format("{0}'s attack staggers the fiend!", PlayerInfo.Name))) MonStagered = true;
                    //else if (!string.IsNullOrEmpty(line?.Text) && line.Text.Contains("")) MonStagered = false;
                }
                else MonStagered = false;
            }
            MonStagered = false;
        }
        #endregion

        /* private void bgw_script_npc_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        } */
        #region Display Controle
        private void playerJA_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = playerJA.SelectedItem.ToString();
            int index = playerJA.FindString(curItem);
            bool state = (playerJA.GetItemCheckState(index).ToString() == "Checked" ? true : false);
            if (curItem == "Benediction") BenedictionHPPuse.Enabled = state;
            else if (curItem == "Proboscis Shower") MONhpCount.Enabled = state;
            else if (curItem == "Catharsis") MONhpCount.Enabled = state;
            else if (curItem == "Plenilune Embrace") MONhpCount.Enabled = state;
            else if (curItem == "Wild Carrot") MONhpCount.Enabled = state;
            else if (curItem == "Pollen") MONhpCount.Enabled = state;
            else if (curItem == "Magic Fruit") MONhpCount.Enabled = state;
            else if (curItem == "Healing Breeze") MONhpCount.Enabled = state;
            else if (curItem == "Proboscis") MONmpCount.Enabled = state;
            else if (curItem == "Vivacious Pulse")
            {
                VivaciousPulse.Enabled = state;
                VivaciousPulseHP.Enabled = state;
            }
            else if (curItem == "Convert")
            {
                ConvertHP.Enabled = state;
                ConvertMP.Enabled = state;
                ConvertHPP.Enabled = state;
                ConvertMPP.Enabled = state;
            }
        }

        private void playerMA_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = playerMA.SelectedItem.ToString();
            int index = playerMA.FindString(curItem);
            bool state = (playerMA.GetItemCheckState(index).ToString() == "Checked" ? true : false);
            if (curItem == "Cure") Curecount.Enabled = state;
            else if (curItem == "Cure II") CureIIcount.Enabled = state;
            else if (curItem == "Cure III") CureIIIcount.Enabled = state;
            else if (curItem == "Cure IV") CureIVcount.Enabled = state;
            else if (curItem == "Cure V") CureVcount.Enabled = state;
            else if (curItem == "Cure VI") CureVIcount.Enabled = state;
            else if (curItem == "Cura") Curacount.Enabled = state;
            else if (curItem == "Cura II") CuraIIcount.Enabled = state;
            else if (curItem == "Cura III") CuraIIIcount.Enabled = state;
            else if (curItem == "Full Cure") FullCurecount.Enabled = state;
            else if (curItem == "Drain") DrainIcount.Enabled = state;
            else if (curItem == "Drain II") DrainIIcount.Enabled = state;
            else if (curItem == "Drain III") DrainIIIcount.Enabled = state;
            else if (curItem == "Aspir") AspirIcount.Enabled = state;
            else if (curItem == "Aspir II") AspirIIcount.Enabled = state;
            else if (curItem == "Aspir III") AspirIIIcount.Enabled = state;
            else if (curItem == "Pollen") Pollencount.Enabled = state;
            else if (curItem == "Magic Fruit") MagicFruitcount.Enabled = state;
            else if (curItem == "Healing Breeze") HealingBreezecount.Enabled = state;
            else if (curItem == "Plenilune Embrace") PleniluneEmbracecount.Enabled = state;
            else if (curItem == "White Wind") WhiteWindcount.Enabled = state;
            else if (curItem == "Restoral") Restoralcount.Enabled = state;
            else if (curItem == "Exuviation") Exuviationcount.Enabled = state;
            else if (curItem == "Wild Carrot") WildCarrotcount.Enabled = state;
        }
        #endregion

        private void SMNSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            SMNGetJA();
            if (SMNSelect.SelectedItem.ToString().Contains("Spirit"))
            {
                SMNHealTEXT1.Enabled = true;
                SMNHealTEXT1.Text = "Elemental Siphon at MP%";
                SMNHealTEXT2.Enabled = false;
                SMNHealTEXT2.Text = "(Not Needed)";
                SMNHPPset1.Enabled = true;
                SMNHPPset2.Enabled = false;
                SMNpetTPUSEtext.Enabled = false;
                SMNpetTPUSEset.Enabled = false;
            }
            else if ((string)SMNSelect.SelectedItem == "Carbuncle")
            {
                SMNHealTEXT1.Enabled = true;
                SMNHealTEXT1.Text = "Healing Ruby HPP%";
                SMNHealTEXT2.Enabled = true;
                SMNHealTEXT2.Text = "Healing Ruby II HPP%";
                SMNHPPset1.Enabled = true;
                SMNHPPset2.Enabled = true;
                SMNpetTPUSEtext.Enabled = true;
                SMNpetTPUSEset.Enabled = true;
            }
            else if ((string)SMNSelect.SelectedItem == "Leviathan")
            {
                SMNHealTEXT1.Enabled = true;
                SMNHealTEXT1.Text = "Spring Water HPP%";
                SMNHealTEXT2.Enabled = false;
                SMNHealTEXT2.Text = "(Not Needed)";
                SMNHPPset1.Enabled = true;
                SMNHPPset2.Enabled = false;
                SMNpetTPUSEtext.Enabled = true;
                SMNpetTPUSEset.Enabled = true;
            }
            else if ((string)SMNSelect.SelectedItem == "Garuda")
            {
                SMNHealTEXT1.Enabled = true;
                SMNHealTEXT1.Text = "Whispering Wind HPP%";
                SMNHealTEXT2.Enabled = false;
                SMNHealTEXT2.Text = "(Not Needed)";
                SMNHPPset1.Enabled = true;
                SMNHPPset2.Enabled = false;
                SMNpetTPUSEtext.Enabled = true;
                SMNpetTPUSEset.Enabled = true;
            }
            else
            {
                SMNHealTEXT1.Enabled = false;
                SMNHealTEXT1.Text = "(Not Needed)";
                SMNHealTEXT2.Enabled = false;
                SMNHealTEXT2.Text = "(Not Needed)";
                SMNHPPset1.Enabled = false;
                SMNHPPset2.Enabled = false;
                SMNpetTPUSEtext.Enabled = true;
                SMNpetTPUSEset.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveConfig();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updatenav();
            loadConfig();
            updatenav();
            CharacterUpdate(false);
        }
    }
}
