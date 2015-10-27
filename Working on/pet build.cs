
        #region PET: GEO
        #region JA: GEO (get/set)
        private void GEOGetJA()
        {
            for (uint G = 798; G <= 827; G++)
            {
                if (PlayerInfo.HasSpell(G))
                {
                    var magic = api.Resources.GetSpell(G);
                    GEOselect.List.Add(magic.Name);
                }
            }
            if (GEOJA.Items.Count > 0) GEOJA.Items.Clear();
            if (PlayerInfo.MainJob != 21 && PlayerInfo.SubJob != 21) return;
            List<uint> GEOabil = new List<uint>(new uint[] {222,223});
            foreach (uint Ga in GEOabil)
            {
                if (PlayerInfo.HasSpell(Ga))
                {
                    var ability = api.Resources.GetAbility(Ga);
                    GEOJA.list.Add(ability.Name);
                }
            }
        }
        #endregion
        #region JA: GEO (use)
        private void GEOUseJA()
        {
            var petja = (from object itemChecked in GEOJA.CheckedItems select itemChecked.ToString()).ToList();
            if (petja.Count == 0 || PlayerInfo.Status == 0 || PlayerInfo.HasBuff(16)) return;
        }
        #endregion
        #endregion