Abyssea - Konschtat  ROM/23/80
Abyssea - Tahrongi   ROM/23/110
Abyssea - La Theine  ROM/24/69
Abyssea - Attohwa    ROM/25/24
Abyssea - Misareaux  ROM/25/25
Abyssea - Vunkerl    ROM/25/26
Abyssea - Altepa     ROM/25/27
Abyssea - Uleguerand ROM/25/62
Abyssea - Grauberg   ROM/25/63

≺Set Color #5≻Visitant Light Intensity≺Set Color #1≻

[request] please add a way to read from dats in lua

@z16 

please add a dats reader to lua


zone_to_dat_for_offset_table = {
    ["Abyssea - Konschtat"] = "ROM/23/80",
    ["Abyssea - Tahrongi"] = "ROM/23/110",
    ["Abyssea - La Theine"] = "ROM/24/69",
    ["Abyssea - Attohwa"] = "ROM/25/24",
    ["Abyssea - Misareaux"] = "ROM/25/25",
    ["Abyssea - Vunkerl"] = "ROM/25/26",
    ["Abyssea - Altepa"] = "ROM/25/27",
    ["Abyssea - Uleguerand"] = "ROM/25/62",
    ["Abyssea - Grauberg"] = "ROM/25/63",
    }
find_string = "≺Set Color #5≻Visitant Light Intensity≺Set Color #1≻"
        
        offset = find_offset(zone_name),
        pearl_ebon_gold_silvery = 0,
        azure_ruby_amber = 1,
        visitant_status_update = 9,
        visitant_status_wears_off = 10,
        visitant_status_extend = 12,
        visitant_status_gain = 45,
        pearlescent_light = 183,
        golden_light = 184,
        silvery_light = 185,
        ebon_light = 186,
        azure_light = 187,
        ruby_light = 188,
        amber_light = 189,
        
function find_offset(zone_name)
    local dat = read_dat(zone_to_dat_for_offset_table[name])
    for id,str in ipairs(dat) do
        if str == find_string then
            return id
        end
    end

end