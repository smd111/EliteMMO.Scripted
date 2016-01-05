namespace EliteMMO.Scripted.Views
{
    using System;
    using System.Windows.Forms;
    using System.Threading;
    using System.Linq;
    using API;
    using Embedded;
    using System.Collections.Generic;

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
                //TargetInfo.SetTarget(0);
                if (checkZone.Checked && startzone != api.Player.ZoneId) ToolStopClick(null, null);
                if (isCasting) continue;
                if (DeathWarp.Checked && (PlayerInfo.Status == 2 || PlayerInfo.Status == 3))
                    PlayerDead();

                if (followplayer.Checked && PlayerInfo.Status == 0)
                    FollowTarget();

                if ((assist.Checked || partyAssist.Checked) && PlayerInfo.Status == 0)
                    Assist();

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
                                        TargetInfo.Y - PlayerInfo.Y, TargetInfo.Z - PlayerInfo.Z);

                                api.AutoFollow.IsAutoFollowing = true;

                                Thread.Sleep(TimeSpan.FromSeconds(0.1));

                                if (TargetInfo.ID == 0 || TargetInfo.ID == PlayerInfo.ServerID)
                                    break;
                                if (mobStuckWatch.Checked && isStuck(1))
                                {
                                    var count = 0;
                                    while (isStuck(1))
                                    {
                                        if (TargetInfo.ID == 0 || TargetInfo.ID == PlayerInfo.ServerID)
                                            break;
                                        WindowInfo.KeyDown(LRKey);
                                        WindowInfo.KeyDown(API.Keys.NUMPAD8);
                                        Thread.Sleep(TimeSpan.FromSeconds(1));
                                        if (count == 5)
                                        {
                                            WindowInfo.KeyUp(LRKey);
                                            LRKey = (LRKey == API.Keys.NUMPAD4 ? API.Keys.NUMPAD6 : API.Keys.NUMPAD4);
                                            count = 0;
                                        }
                                        if (TargetInfo.Distance <= 2) break;
                                        count++;
                                    }
                                    WindowInfo.KeyUp(LRKey);
                                    WindowInfo.KeyUp(API.Keys.NUMPAD8);
                                }
                                else
                                {
                                    WindowInfo.KeyUp(LRKey);
                                    WindowInfo.KeyUp(API.Keys.NUMPAD8);
                                }
                            }
                            WindowInfo.KeyUp(LRKey);
                            WindowInfo.KeyUp(API.Keys.NUMPAD8);
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
                    WindowInfo.KeyUp(LRKey);
                    WindowInfo.KeyUp(API.Keys.NUMPAD8);

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
                                Thread.Sleep(TimeSpan.FromSeconds(1.0));
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
                                Thread.Sleep(TimeSpan.FromSeconds(1.0));
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
                                Casting();
                            }
                        }
                    }
                    #endregion

                    HealingWaltz();
                    if (usecurev.Checked || usecureiv.Checked || usecureiii.Checked || usecureii.Checked || usecure.Checked)
                        CuringWaltzSelf();
                    if (ptusecurev.Checked || ptusecureiv.Checked || ptusecureiii.Checked || ptusecureii.Checked || ptusecure.Checked)
                        CuringWaltzParty();
                    if ((usedrain.Checked || usedrainii.Checked || usedrainiii.Checked || useaspir.Checked || useaspirii.Checked ||
                        usehaste.Checked) && !noSamba.Checked)
                         Sambas();
                    if ((usequickstep.Checked || useboxstep.Checked || usestutterstep.Checked || usefeatherstep.Checked) &&
                        !NoSteps.Checked)
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
                        var name = foodName.Text;

                        if (!PlayerInfo.HasBuff(251) && name != "" &&
                            Inventory.ItemQuantityByName(name) > 0)
                        {
                            api.ThirdParty.SendString("/item \"" + name + "\" <me>");
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
                if (IdleLocation.Checked && PlayerInfo.Status == 0 && (TargetInfo.ID == 0 || TargetInfo.ID == PlayerInfo.TargetID))
                    ReturnIdleLocation();

                if (PlayerInfo.Status == 0 && isPulled)
                {
                    isPulled = false;

                    if (aggro.Checked && PlayerInfo.Status == 0) DetectAggro();

                    if (PlayerInfo.Status == 0 && ((HealHP.Checked && PlayerInfo.HPP <= healHPcount.Value) ||
                        (HealMP.Checked && PlayerInfo.MPP <= healMPcount.Value) ||
                        (healforAutomatonHP.Checked && PetInfo.HPP <= healforAutomatonHPset.Value) ||
                        (healforAutomatonMP.Checked && PetInfo.MPP <= healforAutomatonMPset.Value)))
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
                        SetTarget(0);

                    }
                    if (PlayerInfo.Status == 0 && !isPulled) FindTarget();
                }

                if ((TargetInfo.ID == 0 || TargetInfo.ID == PlayerInfo.TargetID) && PlayerInfo.Status == 0 && !naviMove)
                {
                    useTrust();
                    if (Recast.GetAbilityRecast(218) == 0 && UseJigs.Checked)
                    {
                        if (SpectralJig.Checked && !PlayerInfo.HasBuff(69)) api.ThirdParty.SendString("/ja \"Spectral Jig\" <me>");
                        else if (ChocoboJig.Checked) api.ThirdParty.SendString("/ja \"Chocobo Jig\" <me>");
                        else if (ChocoboJigII.Checked) api.ThirdParty.SendString("/ja \"Chocobo Jig II\" <me>");
                    }
                    SetTarget(0);
                }

                if (usenav.Checked && !naviMove && PlayerInfo.Status == 0)
                {
                    if (TargetInfo.ID > 0)
                        SetTarget(0);
                    
                    naviMove = true;
                }

                while (PlayerInfo.Status == 33 && (HealHP.Checked || HealHP.Checked))
                {
                    Thread.Sleep(TimeSpan.FromSeconds(0.1));
                    if (PlayerInfo.MainJob == 9 || PlayerInfo.SubJob == 9)
                    {
                        if (PlayerInfo.HPP == 100 && PlayerInfo.MPP == 100 && PetInfo.HPP == 100 && PetInfo.MPP == 100)
                        {
                            api.ThirdParty.SendString("/heal off");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        }
                    }
                    else if (PlayerInfo.HPP == 100 && PlayerInfo.MPP == 100)
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
                        Inventory.ItemQuantityByName(jugpet.Text) > 0)
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
                    if (PetInfo.ID > 0 && WyvernJA.Items.Count > 0 &&
                        PlayerInfo.Status == 1 && !string.IsNullOrEmpty(TargetInfo.Name))
                    {
                        WyvernUseJA();
                    }
                }
                #endregion;
                if (PlayerInfo.MainJob == 15 || PlayerInfo.SubJob == 15 && SMNSelect.SelectedItem.ToString() != "") SMNUseJA();
                if (PlayerInfo.MainJob == 18 || PlayerInfo.SubJob == 18) PUPUseJA();
                Thread.Sleep(TimeSpan.FromSeconds(0.1));
            }
        }
        #endregion
        #region Thread - NAV
        private void BgwScriptNavDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int count = 0;
            float dir = -45;
            while (botRunning && !bgw_script_nav.CancellationPending)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.1));
                if (isCasting) continue;
                if (Linear.Checked)
                {
                    runReverse.Enabled = false;
                }
                else runReverse.Enabled = true;

                if (naviMove && usenav.Checked && selectedNavi.Text != "" && PlayerInfo.Status == 0 &&
                   (!PlayerInfo.HasBuff(10) || !PlayerInfo.HasBuff(11) || !PlayerInfo.HasBuff(0)))
                {
                    if (checkZone.Checked && startzone != api.Player.ZoneId) ToolStopClick(null, null);
                    var closestWayPoint = FindClosestWayPoint();
                    if (runReverse.Checked)
                    {
                        closestWayPoint--;
                        if (closestWayPoint < 0)
                        {
                            if (Linear.Checked)
                            {
                                closestWayPoint = 1;
                                runReverse.Checked = false;
                            }
                            else
                            {
                                closestWayPoint = (navPathX.Count() - 1);
                            }
                        }
                    }
                    else
                    {
                        closestWayPoint++;
                        if (closestWayPoint >= navPathX.Count())
                        {
                            if (Linear.Checked)
                            {
                                closestWayPoint -= 2;
                                runReverse.Checked = true;
                            }
                            else
                            {
                                closestWayPoint = 0;
                            }
                        }
                    }
                    if (firstPersonView.Checked || navPathfirst[closestWayPoint])
                    {
                        if (api.Player.ViewMode != 1)
                            api.Player.ViewMode = 1;
                        api.AutoFollow.IsAutoFollowing = false;
                        api.Entity.GetLocalPlayer().H = (float)((Math.PI / 180) *
                            (PlayerInfo.GetAngleFrom(navPathX[closestWayPoint], navPathZ[closestWayPoint]) - 180));
                    }
                    else if (api.Player.ViewMode == 1)
                        api.Player.ViewMode = 0;

                    api.AutoFollow.SetAutoFollowCoords((float)navPathX[closestWayPoint] - PlayerInfo.X,
                      ((navPathY[closestWayPoint] == 0) ? 0 : (float)navPathY[closestWayPoint] - PlayerInfo.Y),
                      (float)navPathZ[closestWayPoint] - PlayerInfo.Z);

                    if (navPathdoor[closestWayPoint].Contains("Door"))
                    {
                        CheckDoor(closestWayPoint);
                    }
                    else lastcommandtarget = "";

                    api.AutoFollow.IsAutoFollowing = true;
                }
                else if (usenav.Checked && api.AutoFollow.IsAutoFollowing && !isMoving)
                {
                    api.AutoFollow.IsAutoFollowing = false;
                }

                Thread.Sleep(TimeSpan.FromSeconds(1.0));
                if (navStuckWatch.Checked && naviMove && usenav.Checked && selectedNavi.Text != "" &&
                    api.AutoFollow.IsAutoFollowing && isStuck(0))
                {
                    api.AutoFollow.IsAutoFollowing = false;
                    api.Entity.GetLocalPlayer().H = PlayerInfo.H + (float)((Math.PI / 180) * dir);
                    WindowInfo.KeyDown(API.Keys.NUMPAD8);
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    WindowInfo.KeyUp(API.Keys.NUMPAD8);
                    count++;
                    if (count == 4)
                    {
                        dir = (dir == -45 ? 45 : -45);
                        count = 0;
                    }
                }
            }
        }
        #endregion
        #region Thread - SCH Charges
        private void BgwScriptSCHChargesDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            DateTime last = DateTime.Now;
            while (botRunning && !bgw_script_sch.CancellationPending)
            {
                DateTime now = DateTime.Now;
                Dictionary<int, dynamic> SCHcharges = new Dictionary<int, dynamic>()
                {{ 90, new {time=48, charges=5}},{ 70, new {time=60, charges=4}},{ 50, new {time=80, charges=3}},
                 { 30, new {time=120, charges=2}},{ 1, new {time=240, charges=1}},};
                foreach (KeyValuePair<int, dynamic> kvp in SCHcharges)
                {
                    var lvl = 1;
                    if (PlayerInfo.MainJob == 20) lvl = PlayerInfo.MainJobLevel;
                    else if (PlayerInfo.SubJob == 20) lvl = PlayerInfo.SubJobLevel;
                    if (lvl >= kvp.Key && Math.Abs(now.Subtract(last).TotalSeconds) >= kvp.Value.time)
                    {
                        if (SchCharges < kvp.Value.charges)
                            SchCharges++;
                        last = now;
                        break;
                    }
                }

                Thread.Sleep(TimeSpan.FromSeconds(0.1));
            }
        }
        #endregion
        #region Thread - Display Update
        private void BgwScriptDisplayDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (botRunning && !bgw_script_disp.CancellationPending)
            {
                playerhp.Text = $"HP: {PlayerInfo.HP}/{PlayerInfo.MaxHP}";
                playermp.Text = $"MP: {PlayerInfo.MP}/{PlayerInfo.MaxMP}";
                playertp.Text = $"TP: {PlayerInfo.TP}";
                if (PlayerInfo.MainJobLevel == 99)
                    playerjobpoints.Text = $"Job Points: {PlayerInfo.UseableJobPoints}/500";
                if (PlayerInfo.MainJobLevel >= 75)
                    playermerits.Text = $"Merit Points: {PlayerInfo.MeritPoints}/75";
                curtarg.Text = $"Current Target: {TargetInfo.Name}";
                curtarghpp.Text = $"Target HP: {TargetInfo.HPP}%";
                curtime.Text = $"Current Game Time: {api.VanaTime.CurrentHour}:{api.VanaTime.CurrentMinute.ToString("00")}";
                if (Shutdownenable.Checked) shutdowntime();
                Thread.Sleep(TimeSpan.FromSeconds(0.1));
            }
        }
        #endregion
        #region Thread - Chat Watch
        private void BgwScriptchatWatchDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (botRunning && !bgw_script_chat.CancellationPending)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.1));
                if (PlayerInfo.Status == 1 && staggerstopJA.Checked)
                {
                    var line = api.Chat.GetNextChatLine();
                    if (!string.IsNullOrEmpty(line?.Text) &&
                    line.Text.Contains(String.Format("{0}'s attack staggers the fiend!", PlayerInfo.Name))) MonStagered = true;
                    else if (!string.IsNullOrEmpty(line?.Text) && line.Text.Contains("Auto-targeting the ")) MonStagered = false;
                }
                else MonStagered = false;
            }
            MonStagered = false;
        }
        #endregion

        #region Code Testing section
        private void Run_Test_Code(object sender, EventArgs e)
        {
            var magic = api.Resources.GetSpell("Monomi: Ichi", 0);
            api.ThirdParty.SendString($"/echo \"{magic.Skill}\"/{magic.MagicType}/{magic.Name[2]}");
            //foreach (var member in api.Party.GetPartyMembers().Where(p => p.Active != 0).ToList())
            //{
            //    int slot = member.MemberNumber;
            //    api.ThirdParty.SendString($"/echo \"{(slot > 5 ? (slot > 11 ? $"<a{((slot - 12) + 20)}>" : $"<a{((slot - 6) + 10)}>") : $"<p{slot}>")}\"");
            //}
        }
        #endregion
    }
}
