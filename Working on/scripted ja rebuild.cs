
        private void PlayerJA()
        {
            if (!botRunning || PlayerInfo.Status != 1 || naviMove || PlayerInfo.HasBuff(16))
                return;

            var ja = (from object itemChecked in playerJA.CheckedItems
                      select itemChecked.ToString()).ToList();
            #region Still to 
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