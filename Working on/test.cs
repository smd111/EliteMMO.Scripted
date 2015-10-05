
                    
                Dictionary<string, dynamic> jacontrol = new Dictionary<string, dynamic>
                {
                        #region JA control
                        //buff1 = buff given, buff2 = buff to ability to not use with, hp = player hpp to use below, thp = target hpp to use above
                        {528, new {buff1=44,t=""}}, {529, new {buff1=46,t=""}},
                        {533, new {name="Perfect Dodge",t=""}},
                        {534, new {name="Invincible",t=""}},
                        {535, new {name="Blood Weapon",t=""}},
                        {537, new {name="Soul Voice",t=""}},
                        {538, new {t=""}},
                        {539, new {name="Meikyo Shisui",t=""}},
                        {540, new {name="Mijin Gakure",t=""}},
                        {541, new {name="Spirit Surge",t=""}},
                        {542, new {name="Astral Flow",t=""}},
                        {543, new {buff1=56,t=""}}, {544, new {buff1=68,buff2=460,t=""}}, {545, new {buff1=57,t=""}}, {546, new {buff1=58,t=""}}, {548, new {buff1=59,t=""}}, {549, new {buff1=60,t=""}}, {550, new {hp=90,t=""}}, {551, new {buff1=45,t=""}}, {552, new {buff1=61,t=""}}, {553, new {t=""}},
                        {554, new {name="Flee",t=""}},
                        {555, new {name="Hide",t=""}},
                        {556, new {name="Sneak Attack",t=""}},
                        {557, new {t=""}}, {558, new {t=""}}, {559, new {buff1=74,t=""}}, {560, new {buff1=62,t=""}}, {561, new {buff1=63,t=""}}, {562, new {buff1=75,t=""}}, {563, new {buff1=64,t=""}},
                        {568, new {name="Scavenge",t=""}},
                        {569, new {t=""}},
                        {570, new {name="Camouflage",t=""}},
                        {571, new {buff1=172,t=""}}, {572, new {buff1=73,t=""}}, {574, new {buff1=67,t=""}}, {575, new {name="Meditate",t=""}}, {576, new {buff1=117,t=""}},
                        {577, new {name="Ancient Circle",t=""}},
                        {578, new {name="Jump",t=""}},
                        {579, new {name="High Jump",t=""}},
                        {580, new {name="Super Jump",t=""}},
                        {581, new {name="Fight",t=""}},
                        {582, new {name="Heel",t=""}},
                        {583, new {name="Leave",t=""}},
                        {584, new {name="Sic",t=""}},
                        {585, new {name="Stay",t=""}},
                        {588, new {name="Trick Attack",t=""}},
                        {589, new {t=""}},
                        {591, new {name="Cover",t=""}},
                        {593, new {name="Enrage",t=""}},
                        {594, new {t=""}},
                        //{595, new {name="Convert",t=""}},
                        {596, new {name="Accomplice",t=""}},
                        {598, new {buff1=115,t=""}},
                        {599, new {name="Dismiss",t=""}},
                        {600, new {name="Assault",t=""}},
                        {601, new {name="Retreat",t=""}},
                        {602, new {name="Release",t=""}},
                        {603, new {name="Blood Pact: Rage",t=""}},
                        {604, new {name="Rampart",t=""}},
                        {605, new {name="Azure Lore",t=""}},
                        {606, new {name="Chain Affinity",t=""}},
                        {607, new {name="Burst Affinity",t=""}},
                        {608, new {name="Wild Card",t=""}},
                        {609, new {name="Phantom Roll",t=""}},
                        {610, new {name="Fighter's Roll",t=""}},
                        {611, new {name="Monk's Roll",t=""}},
                        {612, new {name="Healer's Roll",t=""}},
                        {613, new {name="Wizard's Roll",t=""}},
                        {614, new {name="Warlock's Roll",t=""}},
                        {615, new {name="Rogue's Roll",t=""}},
                        {616, new {name="Gallant's Roll",t=""}},
                        {617, new {name="Chaos Roll",t=""}},
                        {618, new {name="Beast Roll",t=""}},
                        {619, new {name="Choral Roll",t=""}},
                        {620, new {name="Hunter's Roll",t=""}},
                        {621, new {name="Samurai Roll",t=""}},
                        {622, new {name="Ninja Roll",t=""}},
                        {623, new {name="Drachen Roll",t=""}},
                        {624, new {name="Evoker's Roll",t=""}},
                        {625, new {name="Magus's Roll",t=""}},
                        {626, new {name="Corsair's Roll",t=""}},
                        {627, new {name="Puppet Roll",t=""}},
                        {628, new {name="Dancer's Roll",t=""}},
                        {629, new {name="Scholar's Roll",t=""}},
                        {630, new {name="Bolter's Roll",t=""}},
                        {631, new {name="Caster's Roll",t=""}},
                        {632, new {name="Courser's Roll",t=""}},
                        {633, new {name="Blitzer's Roll",t=""}},
                        {634, new {name="Tactician's Roll",t=""}},
                        {635, new {name="Double-Up",t=""}},
                        {636, new {name="Quick Draw",t=""}},
                        {637, new {name="Fire Shot",t=""}},
                        {638, new {name="Ice Shot",t=""}},
                        {639, new {name="Wind Shot",t=""}},
                        {640, new {name="Earth Shot",t=""}},
                        {641, new {name="Thunder Shot",t=""}},
                        {642, new {name="Water Shot",t=""}},
                        {643, new {name="Light Shot",t=""}},
                        {644, new {name="Dark Shot",t=""}},
                        {645, new {name="Random Deal",t=""}},
                        {661, new {buff1=340,buff2=490,t=""}}, {662, new {t=""}}, {663, new {buff1=19,t=""}}, {664, new {buff1=341,t=""}},
                        {665, new {name="Martyr",t=""}},
                        {666, new {name="Devotion",t=""}},
                        {667, new {name="Assassin's Charge",t=""}},
                        {668, new {name="Feint",t=""}},
                        {669, new {buff1=344,t=""}}, {672, new {buff1=346,t=""}}, {673, new {t=""}},
                        {675, new {name="Nightingale",t=""}},
                        {676, new {name="Troubadour",t=""}},
                        {677, new {buff1=350,t=""}}, {678, new {buff1=351,t=""}}, {680, new {t=""}},
                        {682, new {name="Angon",t=""}},
                        {683, new {name="Sange",t=""}},
                        {684, new {name="Blood Pact: Ward",t=""}},
                        {685, new {buff1=353,t=""}}, {686, new {buff1=354,t=""}},
                        {687, new {name="Convergence",t=""}},
                        {688, new {name="Diffusion",t=""}},
                        {689, new {name="Snake Eye",t=""}},
                        {690, new {name="Fold",t=""}},
                        {693, new {name="Trance",t=""}},
                        {708, new {name="Spectral Jig",t=""}},
                        {709, new {name="Chocobo Jig",t=""}},
                        {722, new {name="Tabula Rasa",t=""}},
                        {723, new {name="Light Arts",t=""}},
                        {724, new {name="Dark Arts",t=""}},
                        {726, new {name="Modus Veritas",t=""}},
                        {736, new {buff1=371,t=""}},
                        {737, new {name="Snarl",t=""}},
                        {738, new {buff1=405,t=""}}, {739, new {buff1=406,t=""}}, {740, new {t=""}},
                        {741, new {name="Pianissimo",t=""}},
                        {744, new {name="Elemental Siphon",t=""}},
                        {745, new {name="Sublimation",t=""}},
                        {748, new {name="Collaborator",t=""}},
                        {749, new {name="Saber Dance",t=""}},
                        {750, new {name="Fan Dance",t=""}},
                        {751, new {name="No Foot Rise",t=""}},
                        {756, new {name="Enlightenment",t=""}},
                        {757, new {buff1=417,t=""}}, {758, new {buff1=418,t=""}}, {759, new {buff1=419,t=""}},
                        {760, new {name="Yonin",t=""}},
                        {761, new {name="Innin",t=""}},
                        {762, new {name="Avatar's Favor",t=""}},
                        {763, new {name="Ready",t=""}},
                        {764, new {buff1=435,t=""}}, {765, new {buff1=436,t=""}},
                        {766, new {name="Mana Wall",t=""}},
                        {769, new {buff1=433,t=""}},
                        {770, new {name="Sengikori",t=""}},
                        {772, new {name="Spirit Jump",t=""}},
                        {773, new {name="Presto",t=""}},
                        {777, new {name="Libra",t=""}},
                        {779, new {buff1=460,buff2=68,t=""}}, {781, new {buff1=461,t=""}}, {783, new {buff1=477,t=""}}, {784, new {t=""}},
                        {788, new {name="Conspirator",t=""}},
                        {789, new {t=""}}, {790, new {buff1=478,t=""}}, {791, new {t=""}}, {792, new {buff1=479,t=""}},
                        {793, new {name="Spur",t=""}},
                        {795, new {name="Tenuto",t=""}},
                        {796, new {name="Marcato",t=""}},
                        {797, new {t=""}}, {798, new {buff1=482,t=""}}, {799, new {buff1=465,t=""}},
                        {800, new {name="Hagakure",t=""}},
                        {803, new {name="Issekigan",t=""}},
                        {804, new {name="Dragon Breaker",t=""}},
                        {805, new {name="Soul Jump",t=""}},
                        {807, new {name="Steady Wing",t=""}},
                        {808, new {name="Mana Cede",t=""}},
                        {809, new {name="Efflux",t=""}},
                        {813, new {name="Triple Shot",t=""}},
                        {814, new {name="Allies' Roll",t=""}},
                        {815, new {name="Miser's Roll",t=""}},
                        {816, new {name="Companion's Roll",t=""}},
                        {817, new {name="Avenger's Roll",t=""}},
                        {833, new {thp=10,t=""}}, {835, new {buff1=490,buff2=340,t=""}}, {836, new {buff1=491,t=""}}, {837, new {buff1=492,t=""}},
                        {840, new {t=""}}, {841, new {t=""}},
                        {842, new {name="Soul Enslavement",t=""}},
                        {844, new {name="Clarion Call",t=""}},
                        {845, new {buff1=500,t=""}}, {846, new {buff1=501,t=""}},
                        {847, new {name="Mikage",t=""}},
                        {848, new {name="Fly High",t=""}},
                        {849, new {name="Astral Conduit",t=""}},
                        {851, new {name="Cutting Cards",t=""}},
                        {853, new {name="Grand Pas",t=""}},
                        {854, new {name="Caper Emissarius",t=""}},
                        {855, new {name="Bolster",t=""}},
                        {856, new {name="Swipe",t=""}},
                        {860, new {name="Collimated Fervor",t=""}},
                        {864, new {name="Theurgic Focus",t=""}},
                        {865, new {name="Concentric Pulse",t=""}},
                        {866, new {name="Mending Halation",t=""}},
                        {867, new {name="Radial Arcana",t=""}},
                        {868, new {name="Elemental Sforzo",t=""}},
                        {870, new {name="Ignis",t=""}},
                        {871, new {name="Gelus",t=""}},
                        {872, new {name="Flabra",t=""}},
                        {873, new {name="Tellus",t=""}},
                        {874, new {name="Sulpor",t=""}},
                        {875, new {name="Unda",t=""}},
                        {876, new {name="Lux",t=""}},
                        {877, new {name="Tenebrae",t=""}},
                        {878, new {name="Vallation",t=""}},
                        {879, new {name="Swordplay",t=""}},
                        {880, new {name="Lunge",t=""}},
                        {881, new {name="Pflug",t=""}},
                        {882, new {name="Embolden",t=""}},
                        {883, new {name="Valiance",t=""}},
                        {884, new {name="Gambit",t=""}},
                        {885, new {name="Liement",t=""}},
                        {886, new {name="One for All",t=""}},
                        {887, new {name="Rayke",t=""}},
                        {888, new {name="Battuta",t=""}},
                        {889, new {name="Widened Compass",t=""}},
                        {890, new {name="Odyllic Subterfuge",t=""}},
                        {893, new {name="Chocobo Jig II",t=""}},
                        {894, new {name="Relinquish",t=""}},
                        {895, new {name="Vivacious Pulse",t=""}},
                        {896, new {name="Contradance",t=""}},
                        {897, new {name="Apogee",t=""}},
                        {898, new {name="Entrust",t=""}},
                        {901, new {name="Consume Mana",t=""}},
                        {902, new {name="Naturalist's Roll",t=""}},
                        {903, new {name="Runeist's Roll",t=""}},
                        {904, new {name="Crooked Cards",t=""}},
                        #endregion
                        #region monJA control
                        {1024, new {t=""}}, {1025, new {t=""}}, {1026, new {t=""}}, {1027, new {t=""}}, {1028, new {t=""}}, {1029, new {t=""}},
                        {1030, new {t=""}}, {1031, new {t=""}}, {1032, new {t=""}}, {1033, new {t=""}}, {1034, new {t=""}}, {1035, new {t=""}},
                        {1036, new {t=""}}, {1037, new {t=""}}, {1038, new {t=""}}, {1039, new {t=""}}, {1040, new {t=""}}, {1041, new {t=""}},
                        {1042, new {t=""}}, {1043, new {t=""}}, {1044, new {t=""}}, {1045, new {t=""}}, {1046, new {t=""}}, {1048, new {t=""}},
                        {1049, new {t=""}}, {1050, new {t=""}}, {1051, new {t=""}}, {1056, new {t=""}}, {1057, new {t=""}}, {1058, new {t=""}},
                        {1059, new {t=""}}, {1060, new {t=""}}, {1061, new {t=""}}, {1062, new {t=""}}, {1063, new {t=""}}, {1064, new {t=""}},
                        {1065, new {t=""}}, {1066, new {t=""}}, {1072, new {t=""}}, {1073, new {t=""}}, {1074, new {t=""}}, {1075, new {t=""}},
                        {1076, new {t=""}}, {1077, new {t=""}}, {1078, new {t=""}}, {1079, new {t=""}}, {1080, new {t=""}}, {1081, new {t=""}},
                        {1082, new {t=""}}, {1088, new {t=""}}, {1089, new {t=""}}, {1090, new {t=""}}, {1091, new {t=""}}, {1092, new {t=""}},
                        {1093, new {t=""}}, {1094, new {t=""}}, {1095, new {t=""}}, {1096, new {t=""}}, {1097, new {t=""}}, {1098, new {t=""}},
                        {1104, new {t=""}}, {1105, new {t=""}}, {1106, new {t=""}}, {1107, new {t=""}}, {1108, new {t=""}}, {1109, new {t=""}},
                        {1110, new {t=""}}, {1111, new {t=""}}, {1112, new {t=""}}, {1113, new {t=""}}, {1114, new {t=""}}, {1120, new {t=""}},
                        {1121, new {t=""}}, {1122, new {t=""}}, {1123, new {t=""}}, {1124, new {t=""}}, {1125, new {t=""}}, {1126, new {t=""}},
                        {1127, new {t=""}}, {1128, new {t=""}}, {1129, new {t=""}}, {1130, new {t=""}}, {1136, new {t=""}}, {1137, new {t=""}},
                        {1138, new {t=""}}, {1139, new {t=""}}, {1140, new {t=""}}, {1141, new {t=""}}, {1142, new {t=""}}, {1143, new {t=""}},
                        {1144, new {t=""}}, {1145, new {t=""}}, {1146, new {t=""}}, {1151, new {t=""}}, {1152, new {t=""}}, {1153, new {t=""}},
                        {1154, new {t=""}}, {1155, new {t=""}}, {1156, new {t=""}}, {1157, new {t=""}}, {1158, new {t=""}}, {1159, new {t=""}},
                        {1160, new {t=""}}, {1161, new {t=""}}, {1162, new {t=""}}, {1163, new {t=""}}, {1164, new {t=""}}, {1165, new {t=""}},
                        {1166, new {t=""}}, {1168, new {t=""}}, {1169, new {t=""}}, {1170, new {t=""}}, {1171, new {t=""}}, {1172, new {t=""}},
                        {1173, new {t=""}}, {1174, new {t=""}}, {1175, new {t=""}}, {1176, new {t=""}}, {1177, new {t=""}}, {1178, new {t=""}},
                        {1179, new {t=""}}, {1180, new {t=""}}, {1181, new {t=""}}, {1182, new {t=""}}, {1183, new {t=""}}, {1184, new {t=""}},
                        {1185, new {t=""}}, {1186, new {t=""}}, {1187, new {t=""}}, {1188, new {t=""}}, {1189, new {t=""}}, {1190, new {t=""}},
                        {1191, new {t=""}}, {1192, new {t=""}}, {1193, new {t=""}}, {1194, new {t=""}}, {1195, new {t=""}}, {1196, new {t=""}},
                        {1197, new {t=""}}, {1198, new {t=""}}, {1199, new {t=""}}, {1200, new {t=""}}, {1201, new {t=""}}, {1202, new {t=""}},
                        {1203, new {t=""}}, {1204, new {t=""}}, {1205, new {t=""}}, {1206, new {t=""}}, {1207, new {t=""}}, {1208, new {t=""}},
                        {1209, new {t=""}}, {1210, new {t=""}}, {1211, new {t=""}}, {1212, new {t=""}}, {1213, new {t=""}}, {1214, new {t=""}},
                        {1215, new {t=""}}, {1216, new {t=""}}, {1217, new {t=""}}, {1218, new {t=""}}, {1219, new {t=""}}, {1220, new {t=""}},
                        {1221, new {t=""}}, {1222, new {t=""}}, {1223, new {t=""}}, {1224, new {t=""}}, {1225, new {t=""}}, {1226, new {t=""}},
                        {1227, new {t=""}}, {1228, new {t=""}}, {1229, new {t=""}}, {1230, new {t=""}}, {1231, new {t=""}}, {1232, new {t=""}},
                        {1233, new {t=""}}, {1234, new {t=""}}, {1235, new {t=""}}, {1236, new {t=""}}, {1237, new {t=""}}, {1238, new {t=""}},
                        {1239, new {t=""}}, {1240, new {t=""}}, {1241, new {t=""}}, {1242, new {t=""}}, {1243, new {t=""}}, {1244, new {t=""}},
                        {1245, new {t=""}}, {1246, new {t=""}}, {1247, new {hp=75,t=""}}, {1248, new {t=""}}, {1249, new {t=""}}, {1250, new {t=""}},
                        {1252, new {t=""}}, {1253, new {t=""}}, {1255, new {t=""}}, {1256, new {t=""}}, {1257, new {t=""}}, {1258, new {t=""}},
                        {1259, new {t=""}}, {1260, new {t=""}}, {1261, new {t=""}}, {1262, new {t=""}}, {1263, new {t=""}}, {1264, new {t=""}},
                        {1265, new {t=""}}, {1266, new {t=""}}, {1267, new {t=""}}, {1268, new {t=""}}, {1269, new {t=""}}, {1270, new {t=""}},
                        {1271, new {t=""}}, {1272, new {t=""}}, {1273, new {t=""}}, {1274, new {t=""}}, {1275, new {t=""}}, {1276, new {t=""}},
                        {1277, new {t=""}}, {1278, new {t=""}}, {1279, new {t=""}}, {1280, new {t=""}}, {1281, new {t=""}}, {1282, new {t=""}},
                        {1283, new {t=""}}, {1284, new {t=""}}, {1285, new {t=""}}, {1286, new {t=""}}, {1287, new {t=""}}, {1288, new {t=""}},
                        {1289, new {t=""}}, {1290, new {t=""}}, {1291, new {t=""}}, {1292, new {t=""}}, {1293, new {t=""}}, {1294, new {t=""}},
                        {1793, new {t=""}}, {1794, new {t=""}}, {1795, new {t=""}}, {1796, new {t=""}}, {1797, new {t=""}}, {1798, new {t=""}},
                        {1799, new {t=""}}, {1800, new {t=""}}, {1801, new {t=""}}, {1802, new {t=""}}, {1803, new {t=""}}, {1804, new {t=""}},
                        {1805, new {t=""}}, {1806, new {t=""}}, {1807, new {t=""}}, {1808, new {t=""}}, {1809, new {t=""}}, {1810, new {t=""}},
                        {1811, new {t=""}}, {1812, new {t=""}}, {1813, new {t=""}}, {1814, new {t=""}}, {1815, new {t=""}}, {1816, new {t=""}},
                        {1817, new {t=""}}, {1818, new {hp=75,t=""}}, {1819, new {t=""}}, {1820, new {t=""}}, {1821, new {t=""}}, {1822, new {t=""}},
                        {1823, new {t=""}}, {1824, new {t=""}}, {1825, new {hp=75,t=""}}, {1826, new {t=""}}, {1827, new {t=""}}, {1828, new {t=""}},
                        {1829, new {t=""}}, {1830, new {t=""}}, {1831, new {t=""}}, {1832, new {t=""}}, {1833, new {t=""}}, {1834, new {t=""}},
                        {1835, new {t=""}}, {1836, new {t=""}}, {1837, new {t=""}}, {1838, new {t=""}}, {1839, new {t=""}}, {1840, new {t=""}},
                        {1841, new {t=""}}, {1842, new {t=""}}, {1843, new {t=""}}, {1844, new {t=""}}, {1845, new {t=""}}, {1846, new {t=""}},
                        {1847, new {t=""}}, {1848, new {t=""}}, {1849, new {t=""}}, {1850, new {hp=75,t=""}}, {1851, new {t=""}}, {1852, new {t=""}},
                        {1853, new {t=""}}, {1854, new {t=""}}, {1855, new {t=""}}, {1856, new {hp=75,t=""}}, {1857, new {t=""}}, {1858, new {t=""}},
                        {1859, new {t=""}}, {1860, new {t=""}}, {1861, new {t=""}}, {1862, new {t=""}}, {1863, new {t=""}}, {1864, new {t=""}},
                        {1865, new {t=""}}, {1866, new {t=""}}, {1867, new {t=""}}, {1868, new {t=""}}, {1869, new {t=""}}, {1870, new {t=""}},
                        {1871, new {t=""}}, {1872, new {t=""}}, {1873, new {t=""}}, {1874, new {t=""}}, {1875, new {t=""}}, {1876, new {t=""}},
                        {1877, new {t=""}}, {1878, new {t=""}}, {1879, new {t=""}}, {1880, new {t=""}}, {1881, new {t=""}}, {1882, new {t=""}},
                        {1883, new {t=""}}, {1884, new {t=""}}, {1885, new {t=""}}, {1886, new {t=""}}, {1887, new {t=""}}, {1888, new {t=""}},
                        {1889, new {t=""}}, {1890, new {t=""}}, {1891, new {t=""}}, {1892, new {t=""}}, {1893, new {t=""}}, {1894, new {t=""}},
                        {1895, new {t=""}}, {1896, new {t=""}}, {1897, new {t=""}}, {1898, new {t=""}}, {1899, new {t=""}}, {1900, new {t=""}},
                        {1901, new {t=""}}, {1902, new {t=""}}, {1903, new {t=""}}, {1904, new {t=""}}, {1905, new {t=""}}, {1906, new {t=""}},
                        {1907, new {t=""}}, {1908, new {t=""}}, {1909, new {t=""}}, {1910, new {t=""}}, {1911, new {t=""}}, {1912, new {t=""}},
                        {1913, new {t=""}}, {1914, new {t=""}}, {1915, new {t=""}}, {1916, new {t=""}}, {1917, new {t=""}}, {1918, new {t=""}},
                        {1919, new {t=""}}, {1920, new {t=""}}, {1921, new {t=""}}, {1922, new {t=""}}, {1923, new {t=""}}, {1924, new {t=""}},
                        {1925, new {t=""}}, {1926, new {t=""}}, {1927, new {t=""}}, {1928, new {t=""}}, {1929, new {hp=75,t=""}}, {1930, new {t=""}},
                        {1931, new {t=""}}, {1932, new {t=""}}, {1933, new {t=""}}, {1934, new {t=""}}, {1935, new {t=""}}, {1936, new {t=""}},
                        {1937, new {t=""}}, {1938, new {t=""}}, {1939, new {t=""}}, {1940, new {t=""}}, {1941, new {t=""}}, {1942, new {t=""}},
                        {1943, new {t=""}}, {1944, new {t=""}}, {1945, new {t=""}}, {1946, new {t=""}}, {1947, new {t=""}}, {1948, new {t=""}},
                        {1949, new {t=""}}, {1950, new {t=""}}, {1951, new {t=""}}, {1952, new {t=""}}, {1953, new {t=""}}, {1954, new {t=""}},
                        {1955, new {t=""}}, {1956, new {t=""}}, {1957, new {t=""}}, {1958, new {t=""}}, {1959, new {t=""}}, {1960, new {t=""}},
                        {1961, new {t=""}}, {1962, new {t=""}}, {1963, new {t=""}}, {1964, new {t=""}}, {1965, new {t=""}}, {1966, new {t=""}},
                        {1967, new {t=""}}, {1968, new {t=""}}, {1969, new {t=""}}, {1970, new {t=""}}, {1971, new {t=""}}, {1972, new {t=""}},
                        {1973, new {t=""}}, {1974, new {t=""}}, {1975, new {t=""}}, {1976, new {t=""}}, {1977, new {t=""}}, {1978, new {t=""}},
                        {1979, new {t=""}}, {1980, new {t=""}}, {1981, new {t=""}}, {1982, new {t=""}}, {1983, new {t=""}}, {1984, new {t=""}},
                        {1985, new {t=""}}, {1986, new {t=""}}, {1987, new {t=""}}, {1988, new {t=""}}, {1989, new {t=""}}, {1990, new {t=""}},
                        {1991, new {t=""}}, {1992, new {t=""}}, {1993, new {t=""}}, {1994, new {t=""}}, {1995, new {t=""}}, {1996, new {t=""}},
                        {1997, new {t=""}}, {1998, new {t=""}}, {1999, new {t=""}}, {2000, new {t=""}}, {2001, new {t=""}}, {2002, new {t=""}},
                        {2003, new {t=""}}, {2004, new {t=""}}, {2005, new {t=""}}, {2006, new {t=""}}, {2007, new {t=""}}, {2008, new {t=""}},
                        {2009, new {t=""}}, {2010, new {t=""}}, {2011, new {t=""}}, {2012, new {t=""}}, {2013, new {t=""}}, {2014, new {t=""}},
                        {2015, new {t=""}}, {2016, new {t=""}}, {2017, new {t=""}}, {2018, new {t=""}}, {2019, new {t=""}}, {2020, new {t=""}},
                        {2021, new {t=""}}, {2022, new {t=""}}, {2023, new {t=""}}, {2024, new {t=""}}, {2025, new {t=""}}, {2026, new {t=""}},
                        {2027, new {t=""}}, {2028, new {t=""}}, {2029, new {t=""}}, {2030, new {t=""}}, {2031, new {t=""}}, {2032, new {t=""}},
                        {2033, new {t=""}}, {2034, new {t=""}}, {2035, new {t=""}}, {2036, new {t=""}}, {2037, new {t=""}}, {2038, new {t=""}},
                        {2039, new {t=""}}, {2040, new {t=""}}, {2041, new {t=""}}, {2042, new {t=""}}, {2043, new {t=""}}, {2044, new {t=""}},
                        {2045, new {t=""}}, {2046, new {t=""}}, {2047, new {t=""}}, {2048, new {t=""}}, {2049, new {t=""}}, {2050, new {t=""}},
                        {2051, new {t=""}}, {2052, new {t=""}}, {2053, new {t=""}}, {2054, new {t=""}}, {2055, new {t=""}}, {2056, new {t=""}},
                        {2057, new {t=""}}, {2058, new {t=""}}, {2059, new {hp=75,t=""}}, {2060, new {t=""}}, {2061, new {t=""}}, {2062, new {t=""}},
                        {2063, new {t=""}}, {2064, new {t=""}}, {2065, new {t=""}}, {2066, new {t=""}}, {2067, new {t=""}}, {2068, new {t=""}},
                        {2069, new {t=""}}, {2070, new {t=""}}, {2071, new {t=""}}, {2072, new {t=""}}, {2073, new {t=""}}, {2074, new {t=""}},
                        {2075, new {t=""}}, {2076, new {t=""}}, {2077, new {t=""}}, {2078, new {t=""}}, {2079, new {t=""}}, {2080, new {t=""}},
                        {2081, new {t=""}}, {2082, new {t=""}}, {2083, new {t=""}}, {2084, new {t=""}}, {2085, new {t=""}}, {2086, new {t=""}},
                        {2087, new {t=""}}, {2088, new {mp=75,t=""}}, {2089, new {t=""}}, {2090, new {hp=75,t=""}}, {2091, new {t=""}}, {2092, new {t=""}},
                        {2093, new {t=""}}, {2094, new {t=""}}, {2095, new {t=""}}, {2096, new {t=""}}, {2097, new {t=""}}, {2098, new {t=""}},
                        {2099, new {t=""}}, {2100, new {t=""}}, {2101, new {t=""}}, {2102, new {t=""}}, {2103, new {t=""}}, {2104, new {t=""}},
                        {2105, new {t=""}}, {2106, new {t=""}}, {2107, new {t=""}}, {2108, new {t=""}}, {2109, new {t=""}}, {2110, new {t=""}},
                        {2111, new {t=""}}, {2112, new {t=""}}, {2113, new {hp=75,t=""}}, {2114, new {hp=75,t=""}}, {2115, new {t=""}}, {2116, new {t=""}},
                        {2117, new {t=""}}, {2118, new {t=""}}, {2119, new {t=""}}, {2120, new {t=""}}, {2121, new {t=""}}, {2122, new {t=""}},
                        {2123, new {t=""}}, {2124, new {t=""}}, {2125, new {t=""}}, {2126, new {t=""}}, {2127, new {t=""}}, {2128, new {t=""}},
                        {2129, new {t=""}}, {2130, new {t=""}}, {2131, new {t=""}}, {2132, new {t=""}}, {2133, new {t=""}}, {2134, new {t=""}},
                        {2135, new {t=""}}, {2136, new {t=""}}, {2137, new {t=""}}, {2138, new {t=""}}, {2139, new {t=""}}, {2140, new {t=""}},
                        {2141, new {t=""}}, {2142, new {t=""}}, {2143, new {t=""}}, {2144, new {t=""}}, {2145, new {t=""}}, {2146, new {t=""}},
                        {2147, new {t=""}}, {2148, new {t=""}}, {2149, new {t=""}}, {2150, new {t=""}}, {2151, new {t=""}}, {2152, new {t=""}},
                        {2153, new {t=""}}, {2154, new {t=""}}, {2155, new {t=""}}, {2156, new {t=""}}, {2157, new {t=""}}, {2158, new {t=""}},
                        {2159, new {t=""}}, {2160, new {t=""}}, {2161, new {t=""}}, {2162, new {t=""}}, {2163, new {t=""}}, {2164, new {t=""}},
                        {2165, new {t=""}}, {2166, new {t=""}}, {2167, new {t=""}}, {2168, new {t=""}}, {2169, new {t=""}}, {2170, new {t=""}},
                        {2171, new {t=""}}, {2172, new {t=""}}, {2173, new {t=""}}, {2174, new {t=""}}, {2175, new {t=""}}, {2176, new {t=""}},
                        {2177, new {t=""}}, {2178, new {t=""}}, {2179, new {t=""}}, {2180, new {t=""}}, {2181, new {t=""}}, {2182, new {t=""}},
                        {2183, new {t=""}}, {2184, new {t=""}}, {2185, new {t=""}}, {2186, new {t=""}}, {2187, new {t=""}}, {2188, new {t=""}},
                        {2189, new {t=""}}, {2190, new {t=""}}, {2191, new {t=""}}, {2192, new {t=""}}, {2193, new {t=""}}, {2194, new {t=""}},
                        {2195, new {t=""}}, {2196, new {t=""}}, {2197, new {t=""}}, {2198, new {t=""}}, {2199, new {t=""}}, {2200, new {t=""}},
                        {2201, new {t=""}}, {2202, new {t=""}}, {2203, new {t=""}}, {2204, new {t=""}}, {2205, new {t=""}}, {2206, new {t=""}},
                        {2207, new {t=""}}, {2208, new {t=""}}, {2209, new {t=""}}, {2210, new {t=""}}, {2211, new {t=""}}, {2212, new {t=""}},
                        {2213, new {t=""}}, {2214, new {t=""}}, {2215, new {t=""}}, {2216, new {t=""}}, {2217, new {t=""}}, {2218, new {t=""}},
                        {2219, new {t=""}}, {2220, new {t=""}}, {2221, new {t=""}}, {2222, new {t=""}}, {2223, new {t=""}}, {2224, new {t=""}},
                        {2225, new {t=""}}, {2226, new {t=""}}, {2227, new {n="n"}}
                       #endregion
                };
                   
                foreach (string J in ja)
                {
                    var ability = api.Resources.GetAbility(J);
                    if (ability == null)
                    {
                        if (J == "Chivalry TP > 1000" && !PlayerInfo.HasBuff(16) &&
                            PlayerInfo.TP >= 1000 && Recast.GetAbilityRecast(79) == 0 &&
                            PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                        {
                            api.ThirdParty.SendString("/ja \"Chivalry\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        }
                        else if (J == "Chivalry TP > 2000" && !PlayerInfo.HasBuff(16) &&
                            PlayerInfo.TP >= 2000 && Recast.GetAbilityRecast(79) == 0 &&
                            PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                        {
                            api.ThirdParty.SendString("/ja \"Chivalry\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        }
                        else if (J == "Chivalry TP > 3000" && !PlayerInfo.HasBuff(16) &&
                            PlayerInfo.TP >= 3000 && Recast.GetAbilityRecast(79) == 0 &&
                            PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                        {
                            api.ThirdParty.SendString("/ja \"Chivalry\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        }
                        else if (J == "Sharpshot + Barrage" && !PlayerInfo.HasBuff(16) &&
                            !PlayerInfo.HasBuff(73) && Recast.GetAbilityRecast(125) == 0 &&
                            !PlayerInfo.HasBuff(72) && Recast.GetAbilityRecast(124) == 0 &&
                            PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                        {
                            api.ThirdParty.SendString("/ja \"Sharpshot\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            api.ThirdParty.SendString("/ja \"Barrage\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        }
                        /* else if (J == "Shikikoyo - (Samurai)" && !PlayerInfo.HasBuff(16) &&
                            Recast.GetAbilityRecast(136) == 0 && PlayerInfo.Status == 1 &&
                            TargetInfo.ID > 0)
                        {
                            api.ThirdParty.SendString("/ja \"Shikikoyo\" <t>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        } */
                    }
                    else if (ability.ID >= 1024 && PlayerInfo.MainJob == 23)
                    {
                        if (!PlayerInfo.HasBuff(16) && Recast.GetAbilityRecast(ability.TimerID) == 0 &&
                             PlayerInfo.Status == 1 && TargetInfo.ID > 0 && ability.TP <= PlayerInfo.TP)
                        {
                            if (jacontrol[ability.ID].hp != null)
                            {
                                if (PlayerInfo.HPP <= MONhpCount.Value)
                                {
                                    api.ThirdParty.SendString(String.Format("/echo /ja \"{0}\" {1}", J, ((ability.ValidTargets & (1 << 0)) != 0 ? "<me>" : "<t>"));
                                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                                }
                            }
                            else
                            {
                                api.ThirdParty.SendString(String.Format("/ja \"{0}\" <t>", J);
                                Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            }
                        }
                    }
                    else if (jacontrol[ability.ID] == null) {}
                    else if (!PlayerInfo.HasBuff(16) && Recast.GetAbilityRecast(ability.TimerID) == 0 &&
                             PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                    {
                        if (J == "Benediction" && PlayerInfo.HPP <= BenedictionHPPuse)
                        {
                            api.ThirdParty.SendString("/ja \"Benediction\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        }
                        else if (jacontrol[ability.ID].buff2 != null && !PlayerInfo.HasBuff(jacontrol[ability.ID].buff1) &&
                            !PlayerInfo.HasBuff(jacontrol[ability.ID].buff2))
                        {
                        }
                        else if (jacontrol[ability.ID].buff1 != null)
                        {
                            if (!PlayerInfo.HasBuff(jacontrol[ability.ID].buff1))
                            {
                                api.ThirdParty.SendString(String.Format("/ja \"{0}\" {1}", J, ((ability.ValidTargets & (1 << 0)) != 0 ? "<me>" : "<t>"));
                                Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            }
                        }
                        else if (jacontrol[ability.ID].hp != null)
                        {
                            if (PlayerInfo.HPP <= jacontrol[ability.ID].hp)
                            {
                                api.ThirdParty.SendString(String.Format("/ja \"{0}\" {1}", J, ((ability.ValidTargets & (1 << 0)) != 0 ? "<me>" : "<t>"));
                                Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            }
                        }
                        else if (jacontrol[ability.ID].thp != null)
                        {
                            if (TargetInfo.HPP <= jacontrol[ability.ID].thp)
                            {
                                api.ThirdParty.SendString(String.Format("/ja \"{0}\" {1}", J, ((ability.ValidTargets & (1 << 0)) != 0 ? "<me>" : "<t>"));
                                Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            }
                        }
                        else
                        {
                            api.ThirdParty.SendString(String.Format("/ja \"{0}\" {1}", J, ((ability.ValidTargets & (1 << 0)) != 0 ? "<me>" : "<t>"));
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        }
                    }
                    
                }