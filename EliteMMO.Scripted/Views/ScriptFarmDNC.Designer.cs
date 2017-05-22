namespace EliteMMO.Scripted.Views
{
    using API;
    using FormSerialisation;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Linq;
    partial class ScriptFarmDNC
    {
        private static EliteAPI api;
        #region Variables
        #region Variables: (Controle/System)
        public static List<string> DebugLog = new List<string>();
        public string FFXIPath = "";
        public bool botRunning = false;
        public bool naviMove = false;
        public bool datsName = false;
        public bool isPulled = false;
        public bool isMoving = false;
        public bool isCasting = false;
        public bool isLoading = false;
        public string PreHealMain = "";
        public string PreHealSub = "";
        public string targeting = "Auto";
        public string currentbot = "FarmBot";
        public string LastFunction = "";
        public bool hudshow = false;
        #endregion
        #region Variables: (NAV)
        public bool OpenDoor = false;
        public string lastcommandtarget = "";
        public static float idleX = float.NaN;
        public static float idleY = float.NaN;
        public static float idleZ = float.NaN;
        public double[] navPathX = new double[1];
        public double[] navPathZ = new double[1];
        public double[] navPathY = new double[1];
        public bool[] navPathfirst = new bool[1];
        public string[] navPathdoor = new string[1];
        public string[] navPathpause = new string[1];
        //public string[] navPathdoor = new int[1];
        //public string[] navPathpause = new double[1];
        //public string[] navPathForceHeal = new bool[1];
        //public bool beenpaused = false;
        //List<WayPoint> route = new List<WayPoint>();
        #endregion
        #region Variables: (Dyna)
        public static bool NoneProc = false;
        public bool MonStagered = false;
        #endregion
        #region Variables: (Job)
        public List<string> SMNPetNames = new List<string>(new string[] {"Carbuncle","Fenrir","Ifrit","Titan","Leviathan","Garuda","Shiva","Ramuh",
                             "Diabolos","Cait Sith","Fire Spirit","Ice Spirit","Air Spirit","Earth Spirit","Thunder Spirit","Water Spirit","Light Spirit",
                             "Dark Spirit"});
        public int SchCharges = 0;
        public int mainJOB = 0;
        public int subJOB = 0;
        #endregion
        #region Variables: (Other)
        public int startzone;
        public float SetEntityX = 0;
        public float SetEntityY = 0;
        public int indi = 0;
        public Dictionary<string, dynamic> IndiDic = new Dictionary<string, dynamic>(){{"Active", false},{"Size", 0},{"Enemy", false},{"Element", 0}};
        public List<int> partyIDs = new List<int>();
        public List<int> ignoreTarget = new List<int>();
        public Dictionary<string, string> wantedID = new Dictionary<string, string>();
        public Dictionary<string, string> wantedNM = new Dictionary<string, string>();
        public static List<string> Statuses = new List<string>(new string[] {"Idle","Engaged","Dead","Engaged dead","Event","Chocobo","Resting","Locked","Fishing fighting",
            "Fishing caught","Fishing broken rod","Fishing broken line","Fishing caught monster","Fishing lost catch","Crafting","Sitting","Kneeling","Fishing",
            "Fishing fighting center","Fishing fighting right","Fishing fighting left","Fishing rod in water","Fishing fish on hook","Fishing caught fish",
            "Fishing rod break","Fishing line break","Fishing monster catch","Fishing no catch or lost","Sitchair 0","Sitchair 1","Sitchair 2","Sitchair 3","Sitchair 4",
            "Sitchair 5","Sitchair 6","Sitchair 7","Sitchair 8","Sitchair 9","Sitchair 10","Sitchair 11","Sitchair 12","Mount"});
        #endregion
        #region dyna mob proc data
        public static Dictionary<string, dynamic> DynaMobProc = new Dictionary<string, dynamic>()
        {
            {"Morning", new Dictionary<string, dynamic>()
                {
                    {"JA", new List<string>(new string[]
                    {"Kindred Thief","Kindred Beastmaster","Kindred Monk","Kindred Ninja","Kindred Ranger","Duke Gomory","Marquis Andras","Marquis Gamygyn",
                    "Count Raum","Marquis Cimeries","Marquis Caim","Baron Avnas","Hydra Thief","Hydra Beastmaster","Hydra Monk","Hydra Ninja","Hydra Ranger",
                    "Vanguard Backstabber","Vanguard Grappler","Vanguard Hawker","Vanguard Pillager","Vanguard Predator","Voidstreaker Butchnotch",
                    "Steelshank Kratzvatz","Vanguard Beasttender","Vanguard Kusa","Vanguard Mason","Vanguard Militant","Vanguard Purloiner",
                    "Ko'Dho Cannonball","Vanguard Assassin","Vanguard Liberator","Vanguard Ogresoother","Vanguard Salvager","Vanguard Sentinel",
                    "Wuu Qoho the Razorclaw","Tee Zaksa the Ceaseless","Vanguard Ambusher","Vanguard Hitman","Vanguard Pathfinder","Vanguard Pit",
                    "Vanguard Welldigger","Bandrix Rockjaw","Lurklox Dhalmelneck","Trailblix Goatmug","Kikklix Longlegs","Snypestix Eaglebeak",
                    "Jabkix Pigeonpecs","Blazox Boneybod","Bootrix Jaggedelbow","Mobpix Mucousmouth","Prowlox Barrelbelly","Slystix Megapeepers",
                    "Feralox Honeylips","Bordox Kittyback","Droprix Granitepalms","Routsix Rubbertendon","Slinkix Trufflesniff","Swypestix Tigershins",
                    "Nightmare Crawler","Nightmare Raven","Nightmare Uragnite","Nightmare Fly","Nightmare Flytrap","Nightmare Funguar","Nightmare Gaylas",
                    "Nightmare Kraken","Nightmare Roc","Nightmare Hornet","Nightmare Bugard","Woodnix Shrillwhistle","Hamfist Gukhbuk","Lyncean Juwgneg",
                    "Va'Rhu Bodysnatcher","Doo Peku the Fleetfoot","Nant'ina","Antaeus"})
                    },
                    {"MA", new List<string>(new string[]
                    {"Kindred White Mage","Kindred Bard","Kindred Summoner","Kindred Black Mage","Kindred Red Mage","Duke Berith","Marquis Decarabia",
                    "Prince Seere","Marquis Orias","Marquis Nebiros","Duke Haures","Hydra White Mage","Hydra Bard","Hydra Summoner","Hydra Black Mage",
                    "Hydra Red Mage","Vanguard Amputator","Vanguard Bugler","Vanguard Dollmaster","Vanguard Mesmerizer","Vanguard Vexer","Soulsender Fugbrag",
                    "Reapertongue Gadgquok","Battlechoir Gitchfotch","Vanguard Constable","Vanguard Minstrel","Vanguard Protector","Vanguard Thaumaturge",
                    "Vanguard Undertaker","Gi'Pha Manameister","Gu'Nhi Noondozer","Ra'Gho Darkfount","Va'Zhe Pummelsong","Vanguard Chanter",
                    "Vanguard Oracle","Vanguard Prelate","Vanguard Priest","Vanguard Visionary","Loo Hepe the Eyepiercer","Xoo Kaza the Solemn",
                    "Haa Pevi the Stentorian","Xuu Bhoqa the Enigma","Fuu Tzapo the Blessed","Naa Yixo the Stillrage","Vanguard Alchemist",
                    "Vanguard Enchanter","Vanguard Maestro","Vanguard Necromancer","Vanguard Shaman","Elixmix Hooknose","Gabblox Magpietongue",
                    "Hermitrix Toothrot","Humnox Drumbelly","Morgmox Moldnoggin","Mortilox Wartpaws","Distilix Stickytoes","Jabbrox Grannyguise",
                    "Quicktrix Hexhands","Wilywox Tenderpalm","Ascetox Ratgums","Brewnix Bittypupils","Gibberox Pimplebeak","Morblox Stubthumbs",
                    "Whistrix Toadthroat","Nightmare Bunny","Nightmare Eft","Nightmare Mandragora","Nightmare Hippogryph","Nightmare Sabotender",
                    "Nightmare Sheep","Nightmare Snoll","Nightmare Stirge","Nightmare Weapon","Nightmare Makara","Nightmare Cluster","Gosspix Blabblerlips",
                    "Flamecaller Zoeqdoq","Gi'Bhe Fleshfeaster","Ree Nata the Melomanic","Baa Dava the Bibliophage","Aitvaras"})
                    },
                    {"WS", new List<string>(new string[]
                    {"Kindred Paladin","Kindred Warrior","Kindred Samurai","Kindred Dragoon","Kindred Dark Knight","Count Zaebos","Duke Scox","Marquis Sabnak",
                    "King Zagan","Count Haagenti","Hydra Paladin","Hydra Warrior","Hydra Samurai","Hydra Dragoon","Hydra Dark Knight","Vanguard Footsoldier",
                    "Vanguard Gutslasher","Vanguard Impaler","Vanguard Neckchopper","Vanguard Trooper","Wyrmgnasher Bjakdek","Bladerunner Rokgevok",
                    "Bloodfist Voshgrosh","Spellspear Djokvukk","Vanguard Defender","Vanguard Drakekeeper","Vanguard Hatamoto","Vanguard Vigilante",
                    "Vanguard Vindicator","Ze'Vho Fallsplitter","Zo'Pha Forgesoul","Bu'Bho Truesteel","Vanguard Exemplar","Vanguard Inciter",
                    "Vanguard Partisan","Vanguard Persecutor","Vanguard Skirmisher","Maa Febi the Steadfast","Muu Febi the Steadfast","Vanguard Armorer",
                    "Vanguard Dragontamer","Vanguard Ronin","Vanguard Smithy","Buffrix Eargone","Cloktix Longnail","Sparkspox Sweatbrow","Ticktox Beadyeyes",
                    "Tufflix Loglimbs","Wyrmwix Snakespecs","Karashix Swollenskull","Smeltix Thickhide","Wasabix Callusdigit","Anvilix Sootwrists",
                    "Scruffix Shaggychest","Tymexox Ninefingers","Scourquix Scaleskin","Draklix Scalecrust","Moltenox Stubthumbs","Ruffbix Jumbolobes",
                    "Shisox Widebrow","Tocktix Thinlids","Nightmare Crab","Nightmare Dhalmel","Nightmare Scorpion","Nightmare Goobbue","Nightmare Manticore",
                    "Nightmare Treant","Nightmare Diremite","Nightmare Tiger","Nightmare Raptor","Nightmare Leech","Nightmare Worm","Shamblix Rottenheart",
                    "Elvaansticker Bxafraff","Qu'Pho Bloodspiller","Te'Zha Ironclad","Koo Rahi the Levinblade","Barong","Alklha","Stihi","Fairy Ring",
                    "Stcemqestcint","Stringes","Suttung"})
                    }
                }
            },
            {"Noon", new Dictionary<string, dynamic>()
                {
                    {"JA", new List<string>(new string[]
                    {"Kindred Thief","Kindred Beastmaster","Kindred Monk","Kindred Ninja","Kindred Ranger","Duke Gomory","Marquis Andras","Marquis Gamygyn",
                    "Count Raum","Marquis Cimeries","Marquis Caim","Baron Avnas","Hydra Thief","Hydra Beastmaster","Hydra Monk","Hydra Ninja","Hydra Ranger",
                    "Vanguard Backstabber","Vanguard Grappler","Vanguard Hawker","Vanguard Pillager","Vanguard Predator","Voidstreaker Butchnotch",
                    "Steelshank Kratzvatz","Vanguard Beasttender","Vanguard Kusa","Vanguard Mason","Vanguard Militant","Vanguard Purloiner",
                    "Ko'Dho Cannonball","Vanguard Assassin","Vanguard Liberator","Vanguard Ogresoother","Vanguard Salvager","Vanguard Sentinel",
                    "Wuu Qoho the Razorclaw","Tee Zaksa the Ceaseless","Vanguard Ambusher","Vanguard Hitman","Vanguard Pathfinder","Vanguard Pit",
                    "Vanguard Welldigger","Bandrix Rockjaw","Lurklox Dhalmelneck","Trailblix Goatmug","Kikklix Longlegs","Snypestix Eaglebeak",
                    "Jabkix Pigeonpecs","Blazox Boneybod","Bootrix Jaggedelbow","Mobpix Mucousmouth","Prowlox Barrelbelly","Slystix Megapeepers",
                    "Feralox Honeylips","Bordox Kittyback","Droprix Granitepalms","Routsix Rubbertendon","Slinkix Trufflesniff","Swypestix Tigershins",
                    "Nightmare Bunny","Nightmare Eft","Nightmare Mandragora","Nightmare Hippogryph","Nightmare Sabotender","Nightmare Sheep","Nightmare Snoll",
                    "Nightmare Stirge","Nightmare Weapon","Nightmare Makara","Nightmare Cluster","Woodnix Shrillwhistle","Hamfist Gukhbuk","Lyncean Juwgneg",
                    "Va'Rhu Bodysnatcher","Doo Peku the Fleetfoot","Nant'ina","Antaeus"})
                    },
                    {"MA", new List<string>(new string[]
                    {"Kindred White Mage","Kindred Bard","Kindred Summoner","Kindred Black Mage","Kindred Red Mage","Duke Berith","Marquis Decarabia",
                    "Prince Seere","Marquis Orias","Marquis Nebiros","Duke Haures","Hydra White Mage","Hydra Bard","Hydra Summoner","Hydra Black Mage",
                    "Hydra Red Mage","Vanguard Amputator","Vanguard Bugler","Vanguard Dollmaster","Vanguard Mesmerizer","Vanguard Vexer","Soulsender Fugbrag",
                    "Reapertongue Gadgquok","Battlechoir Gitchfotch","Vanguard Constable","Vanguard Minstrel","Vanguard Protector","Vanguard Thaumaturge",
                    "Vanguard Undertaker","Gi'Pha Manameister","Gu'Nhi Noondozer","Ra'Gho Darkfount","Va'Zhe Pummelsong","Vanguard Chanter","Vanguard Oracle",
                    "Vanguard Prelate","Vanguard Priest","Vanguard Visionary","Loo Hepe the Eyepiercer","Xoo Kaza the Solemn","Haa Pevi the Stentorian",
                    "Xuu Bhoqa the Enigma","Fuu Tzapo the Blessed","Naa Yixo the Stillrage","Vanguard Alchemist","Vanguard Enchanter","Vanguard Maestro",
                    "Vanguard Necromancer","Vanguard Shaman","Elixmix Hooknose","Gabblox Magpietongue","Hermitrix Toothrot","Humnox Drumbelly",
                    "Morgmox Moldnoggin","Mortilox Wartpaws","Distilix Stickytoes","Jabbrox Grannyguise","Quicktrix Hexhands","Wilywox Tenderpalm",
                    "Ascetox Ratgums","Brewnix Bittypupils","Gibberox Pimplebeak","Morblox Stubthumbs","Whistrix Toadthroat","Nightmare Crab",
                    "Nightmare Dhalmel","Nightmare Scorpion","Nightmare Goobbue","Nightmare Manticore","Nightmare Treant","Nightmare Diremite",
                    "Nightmare Tiger","Nightmare Raptor","Nightmare Leech","Nightmare Worm" ,"Gosspix Blabblerlips","Flamecaller Zoeqdoq",
                    "Gi'Bhe Fleshfeaster","Ree Nata the Melomanic","Baa Dava the Bibliophage","Aitvaras"})
                    },
                    {"WS", new List<string>(new string[]
                    {"Kindred Paladin","Kindred Warrior","Kindred Samurai","Kindred Dragoon","Kindred Dark Knight","Count Zaebos","Duke Scox","Marquis Sabnak",
                    "King Zagan","Count Haagenti","Hydra Paladin","Hydra Warrior","Hydra Samurai","Hydra Dragoon","Hydra Dark Knight","Vanguard Footsoldier",
                    "Vanguard Gutslasher","Vanguard Impaler","Vanguard Neckchopper","Vanguard Trooper","Wyrmgnasher Bjakdek","Bladerunner Rokgevok",
                    "Bloodfist Voshgrosh","Spellspear Djokvukk","Vanguard Defender","Vanguard Drakekeeper","Vanguard Hatamoto","Vanguard Vigilante",
                    "Vanguard Vindicator","Ze'Vho Fallsplitter","Zo'Pha Forgesoul","Bu'Bho Truesteel","Vanguard Exemplar","Vanguard Inciter",
                    "Vanguard Partisan","Vanguard Persecutor","Vanguard Skirmisher","Maa Febi the Steadfast","Muu Febi the Steadfast","Vanguard Armorer",
                    "Vanguard Dragontamer","Vanguard Ronin","Vanguard Smithy","Buffrix Eargone","Cloktix Longnail","Sparkspox Sweatbrow","Ticktox Beadyeyes",
                    "Tufflix Loglimbs","Wyrmwix Snakespecs","Karashix Swollenskull","Smeltix Thickhide","Wasabix Callusdigit","Anvilix Sootwrists",
                    "Scruffix Shaggychest","Tymexox Ninefingers","Scourquix Scaleskin","Draklix Scalecrust","Moltenox Stubthumbs","Ruffbix Jumbolobes",
                    "Shisox Widebrow","Tocktix Thinlids","Nightmare Crawler","Nightmare Raven","Nightmare Uragnite","Nightmare Fly","Nightmare Flytrap",
                    "Nightmare Funguar","Nightmare Gaylas","Nightmare Kraken","Nightmare Roc","Nightmare Hornet","Nightmare Bugard","Shamblix Rottenheart",
                    "Elvaansticker Bxafraff","Qu'Pho Bloodspiller","Te'Zha Ironclad","Koo Rahi the Levinblade","Barong","Alklha","Stihi","Fairy Ring",
                    "Stcemqestcint","Stringes","Suttung"})
                    }
                }
            },
            {"Night", new Dictionary<string, dynamic>()
                {
                    {"JA", new List<string>(new string[]
                    {"Kindred Thief","Kindred Beastmaster","Kindred Monk","Kindred Ninja","Kindred Ranger","Duke Gomory","Marquis Andras","Marquis Gamygyn",
                    "Count Raum","Marquis Cimeries","Marquis Caim","Baron Avnas","Hydra Thief","Hydra Beastmaster","Hydra Monk","Hydra Ninja","Hydra Ranger",
                    "Vanguard Backstabber","Vanguard Grappler","Vanguard Hawker","Vanguard Pillager","Vanguard Predator","Voidstreaker Butchnotch",
                    "Steelshank Kratzvatz","Vanguard Beasttender","Vanguard Kusa","Vanguard Mason","Vanguard Militant","Vanguard Purloiner",
                    "Ko'Dho Cannonball","Vanguard Assassin","Vanguard Liberator","Vanguard Ogresoother","Vanguard Salvager","Vanguard Sentinel",
                    "Wuu Qoho the Razorclaw","Tee Zaksa the Ceaseless","Vanguard Ambusher","Vanguard Hitman","Vanguard Pathfinder","Vanguard Pit",
                    "Vanguard Welldigger","Bandrix Rockjaw","Lurklox Dhalmelneck","Trailblix Goatmug","Kikklix Longlegs","Snypestix Eaglebeak",
                    "Jabkix Pigeonpecs","Blazox Boneybod","Bootrix Jaggedelbow","Mobpix Mucousmouth","Prowlox Barrelbelly","Slystix Megapeepers",
                    "Feralox Honeylips","Bordox Kittyback","Droprix Granitepalms","Routsix Rubbertendon","Slinkix Trufflesniff","Swypestix Tigershins",
                    "Nightmare Crab","Nightmare Dhalmel","Nightmare Scorpion","Nightmare Goobbue","Nightmare Manticore","Nightmare Treant",
                    "Nightmare Diremite","Nightmare Tiger","Nightmare Raptor","Nightmare Leech","Nightmare Worm","Woodnix Shrillwhistle","Hamfist Gukhbuk",
                    "Lyncean Juwgneg","Va'Rhu Bodysnatcher","Doo Peku the Fleetfoot","Nant'ina","Antaeus"})
                    },
                    {"MA", new List<string>(new string[]
                    {"Kindred White Mage","Kindred Bard","Kindred Summoner","Kindred Black Mage","Kindred Red Mage","Duke Berith","Marquis Decarabia",
                    "Prince Seere","Marquis Orias","Marquis Nebiros","Duke Haures","Hydra White Mage","Hydra Bard","Hydra Summoner","Hydra Black Mage",
                    "Hydra Red Mage","Vanguard Amputator","Vanguard Bugler","Vanguard Dollmaster","Vanguard Mesmerizer","Vanguard Vexer","Soulsender Fugbrag",
                    "Reapertongue Gadgquok","Battlechoir Gitchfotch","Vanguard Constable","Vanguard Minstrel","Vanguard Protector","Vanguard Thaumaturge",
                    "Vanguard Undertaker","Gi'Pha Manameister","Gu'Nhi Noondozer","Ra'Gho Darkfount","Va'Zhe Pummelsong","Vanguard Chanter","Vanguard Oracle",
                    "Vanguard Prelate","Vanguard Priest","Vanguard Visionary","Loo Hepe the Eyepiercer","Xoo Kaza the Solemn","Haa Pevi the Stentorian",
                    "Xuu Bhoqa the Enigma","Fuu Tzapo the Blessed","Naa Yixo the Stillrage","Vanguard Alchemist","Vanguard Enchanter","Vanguard Maestro",
                    "Vanguard Necromancer","Vanguard Shaman","Elixmix Hooknose","Gabblox Magpietongue","Hermitrix Toothrot","Humnox Drumbelly",
                    "Morgmox Moldnoggin","Mortilox Wartpaws","Distilix Stickytoes","Jabbrox Grannyguise","Quicktrix Hexhands","Wilywox Tenderpalm",
                    "Ascetox Ratgums","Brewnix Bittypupils","Gibberox Pimplebeak","Morblox Stubthumbs","Whistrix Toadthroat","Nightmare Crawler",
                    "Nightmare Raven","Nightmare Uragnite","Nightmare Fly","Nightmare Flytrap","Nightmare Funguar","Nightmare Gaylas","Nightmare Kraken",
                    "Nightmare Roc","Nightmare Hornet","Nightmare Bugard","Gosspix Blabblerlips","Flamecaller Zoeqdoq","Gi'Bhe Fleshfeaster",
                    "Ree Nata the Melomanic","Baa Dava the Bibliophage","Aitvaras"})
                    },
                    {"WS", new List<string>(new string[]
                    {"Kindred Paladin","Kindred Warrior","Kindred Samurai","Kindred Dragoon","Kindred Dark Knight","Count Zaebos","Duke Scox","Marquis Sabnak",
                    "King Zagan","Count Haagenti","Hydra Paladin","Hydra Warrior","Hydra Samurai","Hydra Dragoon","Hydra Dark Knight","Vanguard Footsoldier",
                    "Vanguard Gutslasher","Vanguard Impaler","Vanguard Neckchopper","Vanguard Trooper","Wyrmgnasher Bjakdek","Bladerunner Rokgevok",
                    "Bloodfist Voshgrosh","Spellspear Djokvukk","Vanguard Defender","Vanguard Drakekeeper","Vanguard Hatamoto","Vanguard Vigilante",
                    "Vanguard Vindicator","Ze'Vho Fallsplitter","Zo'Pha Forgesoul","Bu'Bho Truesteel","Vanguard Exemplar","Vanguard Inciter",
                    "Vanguard Partisan","Vanguard Persecutor","Vanguard Skirmisher","Maa Febi the Steadfast","Muu Febi the Steadfast","Vanguard Armorer",
                    "Vanguard Dragontamer","Vanguard Ronin","Vanguard Smithy","Buffrix Eargone","Cloktix Longnail","Sparkspox Sweatbrow","Ticktox Beadyeyes",
                    "Tufflix Loglimbs","Wyrmwix Snakespecs","Karashix Swollenskull","Smeltix Thickhide","Wasabix Callusdigit","Anvilix Sootwrists",
                    "Scruffix Shaggychest","Tymexox Ninefingers","Scourquix Scaleskin","Draklix Scalecrust","Moltenox Stubthumbs","Ruffbix Jumbolobes",
                    "Shisox Widebrow","Tocktix Thinlids","Nightmare Bunny","Nightmare Eft","Nightmare Mandragora","Nightmare Hippogryph",
                    "Nightmare Sabotender","Nightmare Sheep","Nightmare Snoll","Nightmare Stirge","Nightmare Weapon","Nightmare Makara","Nightmare Cluster",
                    "Shamblix Rottenheart","Elvaansticker Bxafraff","Qu'Pho Bloodspiller","Te'Zha Ironclad","Koo Rahi the Levinblade","Barong","Alklha",
                    "Stihi","Fairy Ring","Stcemqestcint","Stringes","Suttung"})
                    }
                }
            }
        };
        public static List<string> NoProcDynaMobs = new List<string>(new string[] {"Animated Claymore","Animated Dagger","Animated Great Axe","Animated Gun","Animated Hammer",
            "Animated Horn","Animated Kunai","Animated Knuckles","Animated Longbow","Animated Longsword","Animated Scythe","Animated Shield","Animated Spear",
            "Animated Staff","Animated Tabar","Animated Tachi","Fire Pukis","Petro Pukis","Poison Pukis","Wind Pukis","Kindred's Vouivre","Kindred's Wyvern",
            "Kindred's Avatar","Vanguard Eye","Prototype Eye","Nebiros's Avatar","Haagenti's Avatar","Caim's Vouivre","Andras's Vouivre","Adamantking Effigy",
            "Avatar Icon","Goblin Replica","Serjeant Tombstone","Zagan's Wyvern","Hydra's Hound","Hydra's Wyvern","Hydra's Avatar","Rearguard Eye",
            "Adamantking Effigy","Adamantking Image","Avatar Icon","Avatar Idol","Effigy Prototype","Goblin Replica","Goblin Statue","Icon Prototype",
            "Manifest Icon","Manifest Icon","Prototype Eye","Serjeant Tombstone","Statue Prototype","Tombstone Prototype","Vanguard Eye","Vanguard's Avatar",
            "Vanguard's Avatar","Vanguard's Avatar","Vanguard's Avatar","Vanguard's Crow","Vanguard's Hecteyes","Vanguard's Scorpion","Vanguard's Slime",
            "Vanguard's Wyvern","Vanguard's Wyvern","Vanguard's Wyvern","Vanguard's Wyvern","Warchief Tombstone"});
        #endregion
        #region ninja tools
        public static Dictionary<string, List<string>> nintools = new Dictionary<string, List<string>>() {
            {"Monomi", new List<string>(new string[]{ "Sanjaku-Tenugui", "Toolbag (Sanja)", "Shikanofuda", "Toolbag (Shika)"})},
            {"Aisha", new List<string>(new string[]{ "Soshi", "Toolbag (Soshi)", "Chonofuda", "Toolbag (Cho)"})},
            {"Katon", new List<string>(new string[]{ "Uchitake", "Toolbag (Uchi)", "Inoshishinofuda", "Toolbag (Ino)"})},
            {"Hyoton", new List<string>(new string[]{ "Tsurara", "Toolbag (Tsura)", "Inoshishinofuda", "Toolbag (Ino)"})},
            {"Huton", new List<string>(new string[]{ "Kawahori-Ogi", "Toolbag (Kawa)", "Inoshishinofuda", "Toolbag (Ino)"})},
            {"Doton", new List<string>(new string[]{ "Makibishi", "Toolbag (Maki)", "Inoshishinofuda", "Toolbag (Ino)"})},
            {"Raiton", new List<string>(new string[]{ "Hiraishin", "Toolbag (Hira)", "Inoshishinofuda", "Toolbag (Ino)"})},
            {"Suiton", new List<string>(new string[]{ "Mizu-Deppo", "Toolbag (Mizu)", "Inoshishinofuda", "Toolbag (Ino)"})},
            {"Jubaku", new List<string>(new string[]{ "Jusatsu", "Toolbag (Jusa)", "Chonofuda", "Toolbag (Cho)"})},
            {"Hojo", new List<string>(new string[]{ "Kaginawa", "Toolbag (Kagi)", "Chonofuda", "Toolbag (Cho)"})},
            {"Kurayami", new List<string>(new string[]{ "Sairui-Ran", "Toolbag (Sai)", "Chonofuda", "Toolbag (Cho)"})},
            {"Dokumori", new List<string>(new string[]{ "Kodoku", "Toolbag (Kodo)", "Chonofuda", "Toolbag (Cho)"})},
            {"Tonko", new List<string>(new string[]{ "Shinobi-Tabi", "Toolbag (Shino)", "Shikanofuda", "Toolbag (Shika)"})},
            {"Gekka", new List<string>(new string[]{ "Ranka", "Toolbag (Ranka)", "Shikanofuda", "Toolbag (Shika)"})},
            {"Yain", new List<string>(new string[]{ "Furusumi", "Toolbag (Furu)", "Shikanofuda", "Toolbag (Shika)"})},
            {"Myoshu", new List<string>(new string[]{ "Kabenro", "Toolbg. (Kaben)", "Shikanofuda", "Toolbag (Shika)"})},
            {"Yurin", new List<string>(new string[]{ "Jinko", "Toolbag (Jinko)", "Chonofuda", "Toolbag (Cho)"})},
            {"Kakka", new List<string>(new string[]{ "Ryuno", "Toolbag (Ryuno)", "Shikanofuda", "Toolbag (Shika)"})},
            {"Migawari", new List<string>(new string[]{ "Mokujin", "Toolbag (Moku)", "Shikanofuda", "Toolbag (Shika)"})},
            {"Utsusemi", new List<string>(new string[]{ "Shihei", "Toolbag (Shihe)", "Shikanofuda", "Toolbag (Shika)"})},
            };
        #endregion
        #region Magic Control
        #region Skip MA List
        public static Dictionary<uint, dynamic> skipSpellList = new Dictionary<uint, dynamic> {{12, true},{13, true},{81, true},{82, true},{83, true},{120, true},{121, true},
                {122, true},{123, true},{124, true},{136, true},{137, true},{138, true},{139, true},{140, true},{241, true},{260, true},{261, true},{262, true},{263, true},
                {264, true},{265, true},{494, true},{512, true},{514, true},{516, true},{518, true},{520, true},{523, true},{525, true},{526, true},{528, true},{546, true},
                {550, true},{552, true},{553, true},{556, true},{558, true},{559, true},{562, true},{566, true},{568, true},{571, true},{580, true},{583, true},{586, true},
                {600, true},{601, true},{602, true},{607, true},{609, true},{619, true},{624, true},{625, true},{627, true},{630, true},{635, true},{639, true},
                {729, true},{730, true},{731, true},{732, true},{733, true},{734, true},{735, true},{754, true},{755, true},{756, true},{757, true},{758, true},{759, true},
                {760, true},{761, true},{762, true},{763, true},{764, true},{765, true},{766, true},{767, true},{992, true},{993, true},{994, true},{995, true},{996, true},
                {997, true},{998, true},{999, true},{1000, true},{1001, true},{1002, true},{1003, true},{1017, true},{1018, true},{1019, true},{1020, true},{1021, true},
                {1022, true},{1023, true},{308, true},{309, true},{318, true},{353, true},{354, true},{355, true},{465, true},
                #region smn
                {288, true},{289, true},{290, true},{291, true},{292, true},{293, true},{294, true},{295, true},{296, true},{297, true},{298, true},{299, true},{300, true},
                {301, true},{302, true},{303, true},{304, true},{305, true},{306, true},{307, true},{847, true},
                #endregion
                #region nin
                {338, true},{339, true},{340, true},
                #endregion
                #region geo
                {798, true},{799, true},{800, true},{801, true},{802, true},{803, true},{804, true},{805, true},{806, true},{807, true},{808, true},{809, true},{810, true},
                {811, true},{812, true},{813, true},{814, true},{815, true},{816, true},{817, true},{818, true},{819, true},{820, true},{821, true},{822, true},{823, true},
                {824, true},{825, true},{826, true},{827, true},
                #endregion
                #region trust
                {896, true},{897, true},{898, true},{899, true},{900, true},{901, true},{902, true},{903, true},{904, true},{905, true},{906, true},{907, true},{908, true},
                {909, true},{910, true},{911, true},{912, true},{913, true},{914, true},{915, true},{916, true},{917, true},{918, true},{919, true},{920, true},{921, true},
                {922, true},{923, true},{924, true},{925, true},{926, true},{927, true},{928, true},{929, true},{930, true},{931, true},{932, true},{933, true},{934, true},
                {935, true},{936, true},{937, true},{938, true},{939, true},{940, true},{941, true},{942, true},{943, true},{944, true},{945, true},{946, true},{947, true},
                {948, true},{949, true},{950, true},{951, true},{952, true},{953, true},{954, true},{955, true},{956, true},{957, true},{958, true},{959, true},{960, true},
                {961, true},{962, true},{963, true},{964, true},{965, true},{966, true},{967, true},{968, true},{969, true},{970, true},{971, true},{972, true},{973, true},
                {974, true},{975, true},{976, true},{977, true},{978, true},{979, true},{980, true},{981, true},{982, true},{983, true},{984, true},{985, true},{986, true},
                {987, true},{988, true},{989, true},{990, true},{991, true},{1004, true},{1005, true},{1006, true},{1007, true},{1008, true},{1009, true},{1010, true},
                {1011, true},{1012, true},{1013, true},{1014, true},{1015, true},{1016, true}
                #endregion
            };
        #endregion
        public static List<uint> UnbridledSpells = new List<uint>(new uint[] { 736, 737, 738, 739, 740, 741, 742, 743, 744, 745, 746, 747, 748, 749, 750, 751, 752, 753 });
        public static List<string> Handledspells = new List<string>(new string[] {"Protect","Protect II","Protect III","Protect IV","Protect V","Protectra",
                "Protectra II","Protectra III","Protectra IV","Protectra V","Shell","Shell II","Shell III","Shell IV","Shell V","Shellra","Shellra II",
                "Shellra III","Shellra IV","Shellra V","Regen","Regen II","Regen III","Regen IV","Regen V","Refresh","Refresh II","Refresh III","Reraise",
                "Reraise II","Reraise III","Reraise IV","Cure","Cure II","Cure III","Cure IV","Cure V","Cure VI","Cura","Cura II","Cura III","Full Cure",
                "Drain","Drain II","Drain III","Aspir","Aspir II","Aspir III","Pollen","Magic Fruit","Healing Breeze","Plenilune Embrace","White Wind",
                "Restoral","Exuviation","Wild Carrot","Cureaga","Cureaga II","Cureaga III","Cureaga IV","Cureaga V"});
        public static Dictionary<uint, dynamic> macontrol = new Dictionary<uint, dynamic>()
            {
                {14, new {H=3}},{15, new {H=4}},{16, new {H=5}},{17, new {H=6}},{18, new {H=7}},{19, new {H=8}},{20, new {H=9}},
                {53, new {B=36}},{54, new {B=37}},{55, new {B=39}},{57, new {B=33}},{60, new {B=100}},{61, new {B=101}},{62, new {B=102}},
                {63, new {B=103}},{64, new {B=104}},{65, new {B=105}},{66, new {B=100}},{67, new {B=101}},{68, new {B=102}},{69, new {B=103}},
                {70, new {B=104}},{71, new {B=105}},{72, new {B=106}},{73, new {B=107}},{74, new {B=108}},{75, new {B=109}},{76, new {B=110}},
                {77, new {B=111}},{78, new {B=112}},{84, new {B=286}},{85, new {B=286}},{86, new {B=106}},{87, new {B=107}},{88, new {B=108}},
                {89, new {B=109}},{90, new {B=110}},{91, new {B=111}},{92, new {B=112}},{96, new {B=275}},{97, new {B=403}},{99, new {B=181}},
                {100, new {B=94}},{101, new {B=95}},{102, new {B=96}},{103, new {B=97}},{104, new {B=98}},{105, new {B=99}},{106, new {B=116}},
                {107, new {B=116}},{113, new {B=183}},{114, new {B=180}},{115, new {B=178}},{116, new {B=179}},{117, new {B=182}},
                {118, new {B=185}},{119, new {B=184}},{242, new {B=90}},{249, new {B=34}},{250, new {B=35}},{251, new {B=38}},
                {266, new {B=119}},{267, new {B=120}},{268, new {B=121}},{269, new {B=122}},{270, new {B=123}},{271, new {B=124}},
                {272, new {B=125}},{277, new {B=173}},{287, new {B=407}},{310, new {B=274}},{311, new {B=288}},{312, new {B=277}},
                {313, new {B=278}},{314, new {B=279}},{315, new {B=280}},{316, new {B=281}},{317, new {B=282}},{358, new {B=33}},
                {378, new {B=195}},{379, new {B=195}},{380, new {B=195}},{381, new {B=195}},{382, new {B=195}},{383, new {B=195}},
                {384, new {B=195}},{385, new {B=195}},{386, new {B=196}},{387, new {B=196}},{388, new {B=196}},{389, new {B=197}},
                {390, new {B=197}},{391, new {B=197}},{392, new {B=197}},{393, new {B=197}},{394, new {B=198}},{395, new {B=198}},
                {396, new {B=198}},{397, new {B=198}},{398, new {B=198}},{399, new {B=199}},{400, new {B=199}},{401, new {B=200}},
                {402, new {B=200}},{403, new {B=201}},{404, new {B=201}},{405, new {B=202}},{406, new {B=203}},{407, new {B=204}},
                {408, new {B=205}},{409, new {B=206}},{410, new {B=206}},{411, new {B=206}},{412, new {B=207}},{413, new {B=208}},
                {414, new {B=209}},{415, new {B=210}},{416, new {B=211}},{417, new {B=212}},{418, new {B=213}},{419, new {B=214}},
                {420, new {B=214}},{423, new {B=194}},{424, new {B=215}},{425, new {B=215}},{426, new {B=215}},{427, new {B=215}},
                {428, new {B=215}},{429, new {B=215}},{430, new {B=215}},{431, new {B=215}},{432, new {B=215}},{433, new {B=215}},
                {434, new {B=215}},{435, new {B=215}},{436, new {B=215}},{437, new {B=215}},{438, new {B=216}},{439, new {B=216}},
                {440, new {B=216}},{441, new {B=216}},{442, new {B=216}},{443, new {B=216}},{444, new {B=216}},{445, new {B=216}},
                {446, new {B=216}},{447, new {B=216}},{448, new {B=216}},{449, new {B=216}},{450, new {B=216}},{451, new {B=216}},
                {452, new {B=216}},{453, new {B=216}},{464, new {B=218}},{468, new {B=220}},{469, new {B=221}},{470, new {B=222}},
                {476, new {B=289}},{478, new {B=228}},{479, new {B=119}},{480, new {B=120}},{481, new {B=121}},{482, new {B=122}},
                {483, new {B=123}},{484, new {B=124}},{485, new {B=125}},{486, new {B=119}},{487, new {B=120}},{488, new {B=121}},
                {489, new {B=122}},{490, new {B=123}},{491, new {B=124}},{492, new {B=125}},{493, new {B=432}},{495, new {B=170}},
                {505, new {B=289}},{506, new {B=291}},{507, new {B=290}},{509, new {B=227}},{510, new {B=471}},{511, new {B=33}},
                {517, new {B=37}},{530, new {B=33}},{538, new {B=190}},{547, new {B=93}},{613, new {B=93}},{615, new {B=38}},
                {636, new {B=90,b=92}},{655, new {B=91}},{662, new {B=43}},{668, new {B=152}},{679, new {B=36}},{696, new {B=486}},
                {737, new {B=93}},{750, new {B=604}},{840, new {B=568}},{845, new {B=581}},{846, new {B=581}},{855, new {B=274}},
                {856, new {B=288}},{857, new {B=592}},{858, new {B=594}},{859, new {B=591}},{860, new {B=589}},{861, new {B=590}},{862, new {B=593}},
                {863, new {B=596}},{864, new {B=595}},{879, new {B=597}},{895, new {B=432}},{768, new {I=86,P=0,B=539}},{769, new {I=93,E=0}},
                {770, new {I=86,P=0,B=541}},{771, new {I=82,P=0,B=580}},{772, new {I=80,P=0,B=542}},{773, new {I=84,P=0,B=543}},
                {774, new {I=83,P=0,B=544}},{775, new {I=82,P=0,B=545}},{776, new {I=81,P=0,B=546}},{777, new {I=85,P=0,B=547}},
                {778, new {I=86,P=0,B=548}},{779, new {I=80,P=0,B=549}},{780, new {I=83,P=0,B=550}},{781, new {I=81,P=0,B=551}},
                {782, new {I=85,P=0,B=552}},{783, new {I=84,P=0,B=553}},{784, new {I=82,P=0,B=554}},{785, new {I=87,P=0,B=555}},
                {786, new {I=86,P=0,B=556}},{787, new {I=93,E=0}},{788, new {I=90,E=0}},{789, new {I=88,E=0}},{790, new {I=92,E=0}},
                {791, new {I=91,E=0}},{792, new {I=89,E=0}},{793, new {I=94,E=0}},{794, new {I=95,E=0}},{795, new {I=91,E=0}},
                {796, new {I=89,E=0}},{797, new {I=90,E=0}},{700, new {B=91}},{661, new {B=33}},{664, new {B=42}},{710, new {B=33}},
                {685, new {B=116}},{674, new {B=45}},};
        public static Dictionary<int, dynamic> SCHcharges = new Dictionary<int, dynamic>()
            {{90, new {time=48,charges=5}},{70, new {time=60,charges=4}},{50, new {time=80,charges=3}},{30, new {time=120,charges=2}},{1, new {time=240,charges=1}},};
        #endregion
        #region Ability Control
        public static List<string> HandledAbils = new List<string>(new string[] {"Manafont","Manawell","Elemental Seal","Cascade","Subtle Sorcery","Divine Seal",
        "Divine Caress","Chainspell","Saboteur","Spontaneity","Stymie","Divine Emblem","Dark Seal","Nether Void","Futae","Unbridled Learning","Unbridled Wisdom",
        "Soul Voice","Pianissimo","Nightingale","Troubadour","Tenuto","Marcato","Clarion Call","Tabula Rasa","Light Arts","Dark Arts","Enlightenment","Modus Veritas",
        "Addendum: White","Penury","Celerity","Accession","Rapture","Altruism","Tranquility","Perpetuance","Addendum: Black","Parsimony","Alacrity","Manifestation",
        "Ebullience","Focalization","Equanimity","Immanence","Bolster","Collimated Fervor","Theurgic Focus","Widened Compass","Embolden","Sekkanoki","Sekkanoki",
        "Hagakure","Sengikori","Konzen-ittai"});
        public static Dictionary<uint, dynamic> jacontrol = new Dictionary<uint, dynamic>()
            {
                    #region JA 
                    {528, new {}}, {529, new {}}, {530, new {}}, {533, new {}}, {534, new {}}, {535, new {}}, {538, new {}}, {540, new {}}, {543, new {b1=56}},
                    {544, new {b1=68,b2=460}}, {545, new {b1=57}}, {546, new {b1=58}}, {548, new {b1=59}}, {549, new {b1=60}}, {550, new {hp=90}},
                    {551, new {b1=45}}, {552, new {b1=61}}, {553, new {}}, {556, new {}}, {557, new {}}, {558, new {}}, {559, new {b1=74}}, {560, new {b1=62}},
                    {561, new {b1=63}}, {562, new {b1=75}}, {563, new {b1=64}}, {568, new {}}, {569, new {}}, {570, new {}}, {571, new {b1=172}},
                    {572, new {b1=73}}, {574, new {b1=67}}, {575, new {name="Meditate"}}, {576, new {b1=117}}, {577, new {b1=118}}, {578, new {}},
                    {579, new {}}, {580, new {}}, {588, new {b1=87}}, {589, new {}}, {594, new {}}, {595, new {}}, {598, new {b1=115}}, {604, new {}},
                    {605, new {}}, {608, new {}}, {610, new {b1=310,b2=309}}, {611, new {b1=311,b2=309}},
                    {612, new {b1=312,b2=309}}, {613, new {b1=313,b2=309}}, {614, new {b1=314,b2=309}}, {615, new {b1=315,b2=309}}, {616, new {b1=316,b2=309}},
                    {617, new {b1=317,b2=309}}, {618, new {b1=318,b2=309}}, {619, new {b1=319,b2=309}}, {620, new {b1=320,b2=309}}, {621, new {b1=321,b2=309}},
                    {622, new {b1=322,b2=309}}, {623, new {b1=323,b2=309}}, {624, new {b1=324,b2=309}}, {625, new {b1=325,b2=309}}, {626, new {b1=326,b2=309}},
                    {627, new {b1=327,b2=309}}, {628, new {b1=328,b2=309}}, {629, new {b1=329,b2=309}}, {630, new {b1=330,b2=309}}, {631, new {b1=331,b2=309}},
                    {632, new {b1=332,b2=309}}, {633, new {b1=333,b2=309}}, {634, new {b1=334,b2=309}}, {635, new {b1=308}},{637, new {item="Fire Card"}},
                    {638, new {item="Ice Card"}},{639, new {item="Wind Card"}},{640, new {item="Earth Card"}},{641, new {item="Thunder Card"}},
                    {642, new {item="Water Card"}},{643, new {item="Light Card"}},{644, new {item="Dark Card"}},{645, new {}}, {661, new {b1=340,b2=490}},
                    {662, new {}}, {663, new {b1=19}}, {664, new {b1=341}}, {667, new {b1=342}}, {668, new {b1=343}},{669, new {b1=344}}, {672, new {b1=346}},
                    {673, new {}}, {677, new {b1=350}}, {678, new {b1=351}}, {680, new {}}, {682, new {}},{683, new {b1=352}}, {685, new {b1=353}},
                    {686, new {b1=354}}, {689, new {b1=357}}, {690, new {b1=309}}, {693, new {b1=376}},{708, new {b1=71}}, {736, new {b1=371}}, {738, new {b1=405}},
                    {739, new {b1=406}}, {740, new {}}, {749, new {b1=410}}, {750, new {b1=411}},{757, new {b1=417}}, {758, new {b1=418}}, {759, new {b1=419}},
                    {760, new {b1=420}}, {761, new {nuff1=421}}, {764, new {b1=435}},{765, new {b1=436}}, {769, new {b1=433}}, {772, new {}}, {773, new {b1=442}},
                    {777, new {}}, {779, new {b1=460,b2=68}}, {781, new {b1=461}},{783, new {b1=477}}, {784, new {}}, {788, new {b1=462}}, {789, new {}},
                    {790, new {b1=478}}, {791, new {}}, {792, new {b1=479}}, {797, new {}},{798, new {b1=482}}, {799, new {b1=465}}, {803, new {b1=484}},
                    {804, new {}}, {805, new {}}, {813, new {b1=467}}, {814, new {b1=335,b2=309}},{815, new {b1=336,b2=309}}, {816, new {b1=337,b2=309}},
                    {817, new {b1=338,b2=309}}, {833, new {hpt=10}}, {835, new {b1=490,b2=340}},{836, new {b1=491}}, {837, new {b1=492}}, {840, new {}},
                    {841, new {}}, {842, new {b1=497}}, {845, new {b1=500}}, {846, new {b1=501}},{847, new {b1=502}}, {848, new {b1=503}}, {851, new {}},
                    {853, new {b1=507}}, {856, new {}}, {868, new {}}, {870, new {b1=523}},{871, new {b1=524}}, {872, new {b1=525}}, {873, new {b1=526}},
                    {874, new {b1=527}}, {875, new {b1=528}}, {876, new {b1=529}},{877, new {b1=530}}, {878, new {b1=531,b2=535}}, {879, new {b1=532}}, {880, new {}},
                    {881, new {b1=533}}, {883, new {b1=535,b2=531}}, {884, new {}},{895, new {}}, {885, new {b1=537}}, {886, new {b1=538}}, {887, new {}},
                    {888, new {b1=570}}, {890, new {}}, {901, new {b1=599}},{902, new {b1=339,b2=309}}, {903, new {b1=600,b2=309}}, {904, new {b1=601}},
                    #endregion
                    #region monJA control
                    {1247, new {hp=75}}, {1818, new {hp=75}}, {1825, new {hp=75}},{1850, new {hp=75}}, {1856, new {hp=75}}, {1929, new {hp=75}}, {2059, new {hp=75}},
                    {2088, new {mp=75}}, {2090, new {hp=75}}, {2113, new {hp=75}}, {2114, new {hp=75}},
                    #endregion
            };
        #endregion
        #region zone array
        public static Dictionary<string, string> dats = new Dictionary<string, string>()
        {   {"1", "\\ROM3\\2\\111.DAT"},{"2", "\\ROM3\\2\\112.DAT"},{"3", "\\ROM3\\2\\113.DAT"},{"4", "\\ROM3\\2\\114.DAT"},
            {"5", "\\ROM3\\2\\115.DAT"},{"6", "\\ROM3\\2\\116.DAT"},{"7", "\\ROM3\\2\\117.DAT"},{"8", "\\ROM3\\2\\118.DAT"},
            {"9", "\\ROM3\\2\\119.DAT"},{"A", "\\ROM3\\2\\120.DAT"},{"B", "\\ROM3\\2\\121.DAT"},{"C", "\\ROM3\\2\\122.DAT"},
            {"D", "\\ROM3\\2\\123.DAT"},{"E", "\\ROM3\\2\\124.DAT"},{"F", "\\ROM\\25\\80.DAT"},{"10", "\\ROM3\\2\\126.DAT"},
            {"11", "\\ROM3\\2\\127.DAT"},{"12", "\\ROM3\\3\\0.DAT"},{"13", "\\ROM3\\3\\1.DAT"},{"14", "\\ROM3\\3\\2.DAT"},
            {"15", "\\ROM3\\3\\3.DAT"}, {"16", "\\ROM3\\3\\4.DAT"},{"17", "\\ROM3\\3\\5.DAT"},{"18", "\\ROM3\\3\\6.DAT"},
            {"19", "\\ROM3\\3\\7.DAT"},{"1A", "\\ROM3\\3\\8.DAT"},{"1B", "\\ROM3\\3\\9.DAT"},{"1C", "\\ROM3\\3\\10.DAT"},
            {"1D", "\\ROM3\\3\\11.DAT"},{"1E", "\\ROM3\\3\\12.DAT"},{"1F", "\\ROM3\\3\\13.DAT"},{"20", "\\ROM3\\3\\14.DAT"},
            {"21", "\\ROM3\\3\\15.DAT"},{"22", "\\ROM3\\3\\16.DAT"},{"23", "\\ROM3\\3\\17.DAT"},{"24", "\\ROM3\\3\\18.DAT"},
            {"25", "\\ROM3\\3\\19.DAT"},{"26", "\\ROM3\\3\\20.DAT"},{"27", "\\ROM3\\3\\21.DAT"},{"28", "\\ROM3\\3\\22.DAT"},
            {"29", "\\ROM3\\3\\23.DAT"},{"2A", "\\ROM3\\3\\24.DAT"},{"2B", "\\ROM3\\3\\25.DAT"},{"2C", "\\ROM3\\3\\26.DAT"},
            {"2D", "\\ROM\\25\\110.DAT"},{"2E", "\\ROM4\\1\\45.DAT"},{"2F", "\\ROM4\\1\\46.DAT"},{"30", "\\ROM4\\1\\47.DAT"},
            {"31", "\\ROM4\\1\\48.DAT"},{"32", "\\ROM4\\1\\49.DAT"},{"33", "\\ROM4\\1\\50.DAT"},{"34", "\\ROM4\\1\\51.DAT"},
            {"35", "\\ROM4\\1\\52.DAT"},{"36", "\\ROM4\\1\\53.DAT"},{"37", "\\ROM4\\1\\54.DAT"},{"38", "\\ROM4\\1\\55.DAT"},
            {"39", "\\ROM4\\1\\56.DAT"},{"3A", "\\ROM4\\1\\57.DAT"},{"3B", "\\ROM4\\1\\58.DAT"},{"3C", "\\ROM4\\1\\59.DAT"},
            {"3D", "\\ROM4\\1\\60.DAT"},{"3E", "\\ROM4\\1\\61.DAT"},{"3F", "\\ROM4\\1\\62.DAT"},{"40", "\\ROM4\\1\\63.DAT"},
            {"41", "\\ROM4\\1\\64.DAT"},{"42", "\\ROM4\\1\\65.DAT"},{"43", "\\ROM4\\1\\66.DAT"},{"44", "\\ROM4\\1\\67.DAT"},
            {"45", "\\ROM4\\1\\68.DAT"},{"46", "\\ROM4\\1\\69.DAT"},{"47", "\\ROM4\\1\\70.DAT"},{"48", "\\ROM4\\1\\71.DAT"},
            {"49", "\\ROM4\\1\\72.DAT"},{"4A", "\\ROM4\\1\\73.DAT"}, {"4B", "\\ROM4\\1\\74.DAT"},{"4C", "\\ROM4\\1\\75.DAT"},
            {"4D", "\\ROM4\\1\\76.DAT"},{"4E", "\\ROM4\\1\\77.DAT"},{"4F", "\\ROM4\\1\\78.DAT"},{"50", "\\ROM\\26\\17.DAT"},
            {"51", "\\ROM\\26\\18.DAT"},{"52", "\\ROM\\26\\19.DAT"},{"53", "\\ROM\\26\\20.DAT"},{"54", "\\ROM\\26\\21.DAT"},
            {"55", "\\ROM\\26\\22.DAT"},{"56", "\\ROM\\26\\23.DAT"},{"57", "\\ROM\\26\\24.DAT"},{"58", "\\ROM\\26\\25.DAT"},
            {"59", "\\ROM\\26\\26.DAT"},{"5A", "\\ROM\\26\\27.DAT"},{"5B", "\\ROM\\26\\28.DAT"},{"5C", "\\ROM\\26\\29.DAT"},
            {"5D", "\\ROM\\26\\30.DAT"},{"5E", "\\ROM\\26\\31.DAT"},{"5F", "\\ROM\\26\\32.DAT"},{"60", "\\ROM\\26\\33.DAT"},
            {"61", "\\ROM\\26\\34.DAT"},{"62", "\\ROM\\26\\35.DAT"},{"63", "\\ROM\\26\\36.DAT"},{"64", "\\ROM\\26\\37.DAT"},
            {"65", "\\ROM\\26\\38.DAT"},{"66", "\\ROM\\26\\39.DAT"},{"67", "\\ROM\\26\\40.DAT"},{"68", "\\ROM\\26\\41.DAT"},
            {"69", "\\ROM\\26\\42.DAT"},{"6A", "\\ROM\\26\\43.DAT"},{"6B", "\\ROM\\26\\44.DAT"},{"6C", "\\ROM\\26\\45.DAT"},
            {"6D", "\\ROM\\26\\46.DAT"},{"6E", "\\ROM\\26\\47.DAT"},{"6F", "\\ROM\\26\\48.DAT"},{"70", "\\ROM\\26\\49.DAT"},
            {"71", "\\ROM2\\13\\95.DAT"},{"72", "\\ROM2\\13\\96.DAT"},{"73", "\\ROM\\26\\52.DAT"},{"74", "\\ROM\\26\\53.DAT"},
            {"75", "\\ROM\\26\\54.DAT"},{"76", "\\ROM\\26\\55.DAT"},{"77", "\\ROM\\26\\56.DAT"},{"78", "\\ROM\\26\\57.DAT"},
            {"79", "\\ROM2\\13\\97.DAT"},{"7A", "\\ROM2\\13\\98.DAT"},{"7B", "\\ROM2\\13\\99.DAT"},{"7C", "\\ROM2\\13\\100.DAT"},
            {"7D", "\\ROM2\\13\\101.DAT"},{"7E", "\\ROM\\26\\63.DAT"},{"7F", "\\ROM\\26\\64.DAT"},{"80", "\\ROM2\\13\\102.DAT"},
            {"81", "\\ROM\\26\\66.DAT"},{"82", "\\ROM2\\13\\103.DAT"},{"83", "\\ROM\\26\\68.DAT"},{"84", "\\ROM\\26\\69.DAT"},
            {"86", "\\ROM2\\13\\104.DAT"},{"87", "\\ROM2\\13\\105.DAT"},{"88", "\\ROM\\26\\73.DAT"},{"89", "\\ROM\\26\\74.DAT"},
            {"8A", "\\ROM\\26\\75.DAT"},{"8B", "\\ROM\\26\\76.DAT"},{"8C", "\\ROM\\26\\77.DAT"},{"8D", "\\ROM\\26\\78.DAT"},
            {"8E", "\\ROM\\26\\79.DAT"},{"8F", "\\ROM\\26\\80.DAT"},{"90", "\\ROM\\26\\81.DAT"},{"91", "\\ROM\\26\\82.DAT"},
            {"92", "\\ROM\\26\\83.DAT"},{"93", "\\ROM\\26\\84.DAT"},{"94", "\\ROM\\26\\85.DAT"},{"95", "\\ROM\\26\\86.DAT"},
            {"96", "\\ROM\\26\\87.DAT"},{"97", "\\ROM\\26\\88.DAT"},{"98", "\\ROM\\26\\89.DAT"},{"99", "\\ROM2\\13\\106.DAT"},
            {"9A", "\\ROM2\\13\\107.DAT"},{"9B", "\\ROM\\26\\92.DAT"},{"9C", "\\ROM\\26\\93.DAT"},{"9D", "\\ROM\\26\\94.DAT"},
            {"9E", "\\ROM\\26\\95.DAT"},{"9F", "\\ROM2\\13\\108.DAT"},{"A0", "\\ROM2\\13\\109.DAT"},{"A1", "\\ROM\\26\\98.DAT"},
            {"A2", "\\ROM\\26\\99.DAT"},{"A3", "\\ROM2\\13\\110.DAT"},{"A4", "\\ROM\\26\\101.DAT"},{"A5", "\\ROM\\26\\102.DAT"},
            {"A6", "\\ROM\\26\\103.DAT"},{"A7", "\\ROM\\26\\104.DAT"},{"A8", "\\ROM2\\13\\111.DAT"},{"A9", "\\ROM\\26\\106.DAT"},
            {"AA", "\\ROM2\\13\\112.DAT"},{"AB", "\\ROM\\26\\108.DAT"},{"AC", "\\ROM\\26\\109.DAT"},{"AD", "\\ROM2\\13\\113.DAT"},
            {"AE", "\\ROM2\\13\\114.DAT"},{"AF", "\\ROM\\26\\112.DAT"},{"B0", "\\ROM2\\13\\115.DAT"},{"B1", "\\ROM2\\13\\116.DAT"},
            {"B2", "\\ROM2\\13\\117.DAT"},{"B3", "\\ROM2\\13\\118.DAT"},{"B4", "\\ROM2\\13\\119.DAT"},{"B5", "\\ROM2\\13\\120.DAT"},
            {"B6", "\\ROM\\26\\119.DAT"},{"B7", "\\ROM\\26\\120.DAT"},{"B8", "\\ROM\\26\\121.DAT"},{"B9", "\\ROM2\\13\\121.DAT"},
            {"BA", "\\ROM2\\13\\122.DAT"},{"BB", "\\ROM2\\13\\123.DAT"},{"BC", "\\ROM2\\13\\124.DAT"},{"BE", "\\ROM\\26\\127.DAT"},
            {"BF", "\\ROM\\27\\0.DAT"},{"C0", "\\ROM\\27\\1.DAT"},{"C1", "\\ROM\\27\\2.DAT"},{"C2", "\\ROM\\27\\3.DAT"},
            {"C3", "\\ROM\\27\\4.DAT"},{"C4", "\\ROM\\27\\5.DAT"},{"C5", "\\ROM\\27\\6.DAT"},{"C6", "\\ROM\\27\\7.DAT"},
            {"C8", "\\ROM\\27\\9.DAT"},{"C9", "\\ROM2\\13\\125.DAT"},{"CA", "\\ROM2\\13\\126.DAT"},{"CB", "\\ROM2\\13\\127.DAT"},
            {"CC", "\\ROM\\27\\13.DAT"},{"CD", "\\ROM2\\14\\0.DAT"},{"CE", "\\ROM\\27\\13.DAT"},{"CF", "\\ROM2\\14\\1.DAT"},
            {"D0", "\\ROM2\\14\\2.DAT"},{"D1", "\\ROM2\\14\\3.DAT"},{"D3", "\\ROM2\\14\\4.DAT"},{"D4", "\\ROM2\\14\\5.DAT"},
            {"D5", "\\ROM2\\14\\6.DAT"},{"D6", "\\ROM\\27\\15.DAT"},{"D7", "\\ROM\\27\\24.DAT"},{"D8", "\\ROM\\27\\25.DAT"},
            {"D9", "\\ROM\\27\\26.DAT"},{"DA", "\\ROM\\27\\27.DAT"},{"DC", "\\ROM\\27\\29.DAT"},{"DD", "\\ROM\\27\\30.DAT"},
            {"DF", "\\ROM\\27\\32.DAT"},{"E0", "\\ROM\\27\\33.DAT"},{"E1", "\\ROM\\27\\34.DAT"},{"E2", "\\ROM2\\14\\7.DAT"},
            {"E3", "\\ROM\\27\\36.DAT"},{"E4", "\\ROM\\27\\37.DAT"},{"E6", "\\ROM\\27\\39.DAT"},{"E7", "\\ROM\\27\\40.DAT"},
            {"E8", "\\ROM\\27\\41.DAT"},{"E9", "\\ROM\\27\\42.DAT"},{"EA", "\\ROM\\27\\43.DAT"},{"EB", "\\ROM\\27\\44.DAT"},
            {"EC", "\\ROM\\27\\45.DAT"},{"ED", "\\ROM\\27\\46.DAT"},{"EE", "\\ROM\\27\\47.DAT"},{"EF", "\\ROM\\27\\48.DAT"},
            {"F0", "\\ROM\\27\\49.DAT"},{"F1", "\\ROM\\27\\50.DAT"},{"F2", "\\ROM\\27\\51.DAT"},{"F3", "\\ROM\\27\\52.DAT"},
            {"F4", "\\ROM\\27\\53.DAT"},{"F5", "\\ROM\\27\\54.DAT"},{"F6", "\\ROM\\27\\55.DAT"},{"F7", "\\ROM2\\14\\8.DAT"},
            {"F8", "\\ROM\\27\\57.DAT"},{"F9", "\\ROM\\27\\58.DAT"},{"FA", "\\ROM2\\14\\9.DAT"},{"FB", "\\ROM2\\14\\10.DAT"},
            {"FC", "\\ROM2\\14\\11.DAT"},{"FD", "\\ROM\\27\\62.DAT"},{"FE", "\\ROM\\27\\63.DAT"},{"FF", "\\ROM\\27\\64.DAT"},
            {"100", "\\ROM9\\6\\45.DAT"},{"101", "\\ROM9\\6\\46.DAT"},{"102", "\\ROM9\\6\\47.DAT"},{"103", "\\ROM9\\6\\48.DAT"},
            {"104", "\\ROM9\\6\\49.DAT"},{"105", "\\ROM9\\6\\50.DAT"},{"106", "\\ROM9\\6\\51.DAT"},{"107", "\\ROM9\\6\\52.DAT"},
            {"108", "\\ROM9\\6\\53.DAT"},{"109", "\\ROM9\\6\\54.DAT"},{"10A", "\\ROM9\\6\\55.DAT"},{"10B", "\\ROM9\\6\\56.DAT"},
            {"10C", "\\ROM9\\6\\57.DAT"},{"10D", "\\ROM9\\6\\58.DAT"},{"10E", "\\ROM9\\6\\59.DAT"},{"10F", "\\ROM9\\6\\60.DAT"},
            {"110", "\\ROM9\\6\\61.DAT"},{"111", "\\ROM9\\6\\62.DAT"},{"112", "\\ROM9\\6\\63.DAT"},{"113", "\\ROM9\\6\\64.DAT"},
            {"114", "\\ROM9\\6\\65.DAT"},{"115", "\\ROM9\\6\\66.DAT"},{"116", "\\ROM9\\6\\67.DAT"},{"117", "\\ROM9\\6\\68.DAT"},
            {"118", "\\ROM9\\6\\69.DAT"},{"11B", "\\ROM9\\6\\72.DAT"},{"11C", "\\ROM9\\6\\73.DAT"},{"120", "\\ROM\\332\\109.DAT"},
            {"121", "\\ROM\\337\\66.DAT"},{"123", "\\ROM\\342\\94.DAT"},
            };
        #endregion
        #region Job id to string Long/Short
        public static Dictionary<int, dynamic> JobNames = new Dictionary<int, dynamic>()
        {
            {1, new{Long = "Warrior",Short="WAR"}},{2, new{Long = "Monk",Short="MNK"}},{3, new{Long = "White Mage",Short="WHM"}},
            {4, new{Long = "Black Mage",Short="BLM"}},{5, new{Long = "Red Mage",Short="RDM"}},{6, new{Long = "Thief",Short="THF"}},
            {7, new{Long = "Paladin",Short="PLD"}},{8, new{Long = "Dark Knight",Short="DRK"}},{9, new{Long = "Beastmaster",Short="BST"}},
            {10, new{Long = "Bard",Short="BRD"}},{11, new{Long = "Ranger",Short="RNG"}},{12, new{Long = "Samurai",Short="SAM"}},
            {13, new{Long = "Ninja",Short="NIN"}},{14, new{Long = "Dragoon",Short="DRG"}},{15, new{Long = "Summoner",Short="SMN"}},
            {16, new{Long = "Blue Mage",Short="BLU"}},{17, new{Long = "Corsair",Short="COR"}},{18, new{Long = "Puppetmaster",Short="PUP"}},
            {19, new{Long = "Dancer",Short="DNC"}},{20, new{Long = "Scholar",Short="SCHH"}},{21, new{Long = "Geomancer",Short="GEO"}},
            {22, new{Long = "Rune Fencer",Short="RUN"}},{23, new{Long = "Monipulator",Short="MON"}},};
        #endregion
        #region notWanted<list>
        public List<string> notWanted = new List<string>(new string[]
        {
            "","Casket","Treasure Chest","Treasure Casket","Treasure Coffer","Mog-Tablet","Logging Point","Mining Point","Harvesting Point","Field Manual","Moogle",
            "VCSCrate","Gate Sentry","Mogball-Local","CermetHeadstone","Sign post","Stone Monument","Overturned Soil","Riftworn Pyxis","Achieve Master","Irin 01",
            "Irin 02","Irin 03","Tsonga-Hoponga, W.W.","Voidwatch Officer","Spare Two","Spare Zero","Ramblix","Planar Rift","Goblin Footprint","Chocobo","Anguenet",
            "Beugungel","Chuaie","Cofisephe","Coupulie","Felourie","Guilloud","Lourdaude","Ratoulle","Gniyah Mischatt","Khots Chalahko","Test Actor","Fheli Lapatzuo",
            "Mep Nhapopoluko","Tswe Panipahr","Noih Tahparawh","Toh Zonikki","Rhalo Davigoh","Pohka Chichiyowahl","??? Warmachine","Affi","Dremi","Waypoint",
            "Unity Master","Station Worker","Station Administrator","Novalmauge","Chumia","Wooden Door","Cell Door","Couchatorage","Sewer Lid","Brugaire","Jurgenclaus",
            "GoalPoint","Grounds Tome","Geomantic Reservoir","Survival Guide","Linkshell Concierge","Chat Manual","Ethereal Junction","Tatenashi Armor",
            "Hizamaru Armor","Ubuginu Armor","Hachiryu Armor","Omodaka Armor","Chigoe","Pyracmon","Wraith Bat","Astral Box","Slime","She-Slime",
            "Metal Slime","Hugemaw Harold","Elated Ovis","Smiling Ovis","Estatic Ovis","Playful Ovis","Mirthful Cat","Andelain","Croteillard","Rayochindot",
            "Cheval River","Signpost","Cavernous Maw","Carbuncle","Talking Doll","Field Parchment","Magivore Ternion","Stampeding Bison","Smile Helper","Debug",
            "Slabble","Elevator Lever","Ramblix","Etched Rock","Resume Point","Dimensional Portal","Mystic Retriever","Disjoined One","Tenzen","Lion","Prishe",
            "Nashmeira","Lilisette","Arciela","Aldo","Maat","Zeid","Volker","Trion","Curilla","Shantotto","Ajido-Marujido","Star Sibyl","Semih Lafihna","Gilgamesh",
            "Ovjang","Mnejing","Luzaf","Ulmia","Iroha","Shiftrix","Register of Deeds","Emblazoned Reliquary","Temprix","Emporox"
        });
        #endregion
        #endregion
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        public static bool GetBit(int b, int bitNumber)
        {
            BitArray ba = new BitArray(new int[] { b });
            return ba.Get(bitNumber);
        }
        public void IntToIndiStat(int number)
        {
            var binary = string.Empty;
            while (number > 0)
            {
                binary = (number & 1) + binary;
                number = number >> 1;
            }
            binary = binary.PadLeft(8, '0');
            IndiDic.Clear();
            IndiDic.Add("Active", Convert.ToBoolean(Convert.ToInt16(binary.Substring(1, 1))));
            IndiDic.Add("Size", Convert.ToInt32(binary.Substring(2, 2), 2));
            IndiDic.Add("Enemy", Convert.ToBoolean(Convert.ToInt16(binary.Substring(4, 1))));
            IndiDic.Add("Element", Convert.ToInt32(binary.Substring(5, 3), 2));
        }
        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkZone = new System.Windows.Forms.CheckBox();
            this.StopFullInventory = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.firstPersonView = new System.Windows.Forms.CheckBox();
            this.runReverse = new System.Windows.Forms.CheckBox();
            this.Linear = new System.Windows.Forms.RadioButton();
            this.Circular = new System.Windows.Forms.RadioButton();
            this.selectedNavi = new System.Windows.Forms.ComboBox();
            this.GetSetNavi = new System.Windows.Forms.MenuStrip();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navStuckWatch = new System.Windows.Forms.CheckBox();
            this.usenav = new System.Windows.Forms.CheckBox();
            this.StartStopScript = new System.Windows.Forms.MenuStrip();
            this.startScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateJobToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dncControl = new System.Windows.Forms.TabControl();
            this.targets = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.ZoneTargets = new System.Windows.Forms.MenuStrip();
            this.NameListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.TargetList = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.GetSetTargets = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selecttargets = new System.Windows.Forms.GroupBox();
            this.SelectedTargets = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.combat = new System.Windows.Forms.TabPage();
            this.CombatSettingsTabs = new System.Windows.Forms.TabControl();
            this.Options1MainTab = new System.Windows.Forms.TabPage();
            this.HateControlgroup = new System.Windows.Forms.GroupBox();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown7 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.selectedHateControl = new System.Windows.Forms.ComboBox();
            this.tank = new System.Windows.Forms.CheckBox();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.amname = new System.Windows.Forms.ComboBox();
            this.AfterMathTier = new System.Windows.Forms.NumericUpDown();
            this.wsam = new System.Windows.Forms.CheckBox();
            this.WSDistance = new System.Windows.Forms.CheckBox();
            this.selectedWS = new System.Windows.Forms.ComboBox();
            this.WSDistanceset = new System.Windows.Forms.NumericUpDown();
            this.ws = new System.Windows.Forms.CheckBox();
            this.WStp = new System.Windows.Forms.NumericUpDown();
            this.label29 = new System.Windows.Forms.Label();
            this.TragetHPPtop = new System.Windows.Forms.NumericUpDown();
            this.label28 = new System.Windows.Forms.Label();
            this.TragetHPPbottom = new System.Windows.Forms.NumericUpDown();
            this.label27 = new System.Windows.Forms.Label();
            this.Options2MainTab = new System.Windows.Forms.TabPage();
            this.numericUpDown38 = new System.Windows.Forms.NumericUpDown();
            this.aggroRange = new System.Windows.Forms.NumericUpDown();
            this.ScanDelay = new System.Windows.Forms.CheckBox();
            this.KeepTargetRange = new System.Windows.Forms.NumericUpDown();
            this.assistDist = new System.Windows.Forms.NumericUpDown();
            this.followDist = new System.Windows.Forms.NumericUpDown();
            this.partyAssist = new System.Windows.Forms.CheckBox();
            this.facetarget = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.assist = new System.Windows.Forms.CheckBox();
            this.followplayer = new System.Windows.Forms.CheckBox();
            this.followName = new System.Windows.Forms.TextBox();
            this.useshadows = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.assistplayer = new System.Windows.Forms.TextBox();
            this.aggro = new System.Windows.Forms.CheckBox();
            this.mobdist = new System.Windows.Forms.CheckBox();
            this.Options3MainTab = new System.Windows.Forms.TabPage();
            this.fullheal = new System.Windows.Forms.CheckBox();
            this.verifyfood = new System.Windows.Forms.Button();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.SignetStaff = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.useStaff = new System.Windows.Forms.CheckBox();
            this.foodName = new System.Windows.Forms.TextBox();
            this.healMPcount = new System.Windows.Forms.NumericUpDown();
            this.usefood = new System.Windows.Forms.CheckBox();
            this.HealMP = new System.Windows.Forms.CheckBox();
            this.healHPcount = new System.Windows.Forms.NumericUpDown();
            this.RecordIdleLocation = new System.Windows.Forms.Button();
            this.WeakLocation = new System.Windows.Forms.CheckBox();
            this.HealHP = new System.Windows.Forms.CheckBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.IdleLocation = new System.Windows.Forms.CheckBox();
            this.label35 = new System.Windows.Forms.Label();
            this.Options4MainTab = new System.Windows.Forms.TabPage();
            this.NotinBattle = new System.Windows.Forms.GroupBox();
            this.UseJigs = new System.Windows.Forms.CheckBox();
            this.ChocoboJigII = new System.Windows.Forms.RadioButton();
            this.ChocoboJig = new System.Windows.Forms.RadioButton();
            this.SpectralJig = new System.Windows.Forms.RadioButton();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.label42 = new System.Windows.Forms.Label();
            this.autoRangeDelay = new System.Windows.Forms.NumericUpDown();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.rangeaggro = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.autoRangeAttack = new System.Windows.Forms.CheckBox();
            this.selectapp = new System.Windows.Forms.TabPage();
            this.shutdowngroup = new System.Windows.Forms.GroupBox();
            this.label82 = new System.Windows.Forms.Label();
            this.shutdowndate = new System.Windows.Forms.DateTimePicker();
            this.selectedapp = new System.Windows.Forms.ComboBox();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.twentyfourHour = new System.Windows.Forms.RadioButton();
            this.twelveHour = new System.Windows.Forms.RadioButton();
            this.Shutdownenable = new System.Windows.Forms.CheckBox();
            this.ManualTargMode = new System.Windows.Forms.CheckBox();
            this.EnableDynamis = new System.Windows.Forms.CheckBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.label65 = new System.Windows.Forms.Label();
            this.StuckDistance = new System.Windows.Forms.NumericUpDown();
            this.mobStuckWatch = new System.Windows.Forms.CheckBox();
            this.OptionsJAMainTab = new System.Windows.Forms.TabPage();
            this.JAtabselect = new System.Windows.Forms.TabControl();
            this.selectPage = new System.Windows.Forms.TabPage();
            this.playerJA = new System.Windows.Forms.CheckedListBox();
            this.GetSetJA = new System.Windows.Forms.MenuStrip();
            this.loadJAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearJAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WHMpage = new System.Windows.Forms.TabPage();
            this.benedictiongroupBox = new System.Windows.Forms.GroupBox();
            this.BenedictionHPPuse = new System.Windows.Forms.NumericUpDown();
            this.benedictiontext = new System.Windows.Forms.Label();
            this.RDMpage = new System.Windows.Forms.TabPage();
            this.Convertgroup = new System.Windows.Forms.GroupBox();
            this.ConvertHPP = new System.Windows.Forms.NumericUpDown();
            this.ConvertMPP = new System.Windows.Forms.NumericUpDown();
            this.ConvertMP = new System.Windows.Forms.RadioButton();
            this.ConvertHP = new System.Windows.Forms.RadioButton();
            this.convertmptext = new System.Windows.Forms.Label();
            this.converthptext = new System.Windows.Forms.Label();
            this.samPage = new System.Windows.Forms.TabPage();
            this.label58 = new System.Windows.Forms.Label();
            this.sekkanokiWs = new System.Windows.Forms.ComboBox();
            this.SCHpage = new System.Windows.Forms.TabPage();
            this.Sublimationcount = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.RUNpage = new System.Windows.Forms.TabPage();
            this.VivaciousPulseHP = new System.Windows.Forms.NumericUpDown();
            this.VivaciousPulse = new System.Windows.Forms.CheckBox();
            this.MONpage = new System.Windows.Forms.TabPage();
            this.MONmpCount = new System.Windows.Forms.NumericUpDown();
            this.MONhpCount = new System.Windows.Forms.NumericUpDown();
            this.monmptext = new System.Windows.Forms.Label();
            this.monhptext = new System.Windows.Forms.Label();
            this.OptionsMAMainTab = new System.Windows.Forms.TabPage();
            this.MAtabs = new System.Windows.Forms.TabControl();
            this.MASelectPage = new System.Windows.Forms.TabPage();
            this.playerMA = new System.Windows.Forms.CheckedListBox();
            this.GetSetMA = new System.Windows.Forms.MenuStrip();
            this.loadMAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CureConfigPage = new System.Windows.Forms.TabPage();
            this.CuraIIcount = new System.Windows.Forms.NumericUpDown();
            this.Curacount = new System.Windows.Forms.NumericUpDown();
            this.CureIIIcount = new System.Windows.Forms.NumericUpDown();
            this.CureIIcount = new System.Windows.Forms.NumericUpDown();
            this.Curecount = new System.Windows.Forms.NumericUpDown();
            this.CuraIIIcount = new System.Windows.Forms.NumericUpDown();
            this.FullCurecount = new System.Windows.Forms.NumericUpDown();
            this.CureVIcount = new System.Windows.Forms.NumericUpDown();
            this.CureVcount = new System.Windows.Forms.NumericUpDown();
            this.CureIVcount = new System.Windows.Forms.NumericUpDown();
            this.label55 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PartyCurepage = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ptCure = new System.Windows.Forms.CheckBox();
            this.FullCureptcount = new System.Windows.Forms.NumericUpDown();
            this.label80 = new System.Windows.Forms.Label();
            this.CureVIptcount = new System.Windows.Forms.NumericUpDown();
            this.label74 = new System.Windows.Forms.Label();
            this.CureVptcount = new System.Windows.Forms.NumericUpDown();
            this.CureIVptcount = new System.Windows.Forms.NumericUpDown();
            this.CureIIIptcount = new System.Windows.Forms.NumericUpDown();
            this.label75 = new System.Windows.Forms.Label();
            this.CureIIptcount = new System.Windows.Forms.NumericUpDown();
            this.label66 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.Cureptcount = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CurePTlist = new System.Windows.Forms.CheckedListBox();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Cureagapage = new System.Windows.Forms.TabPage();
            this.label39 = new System.Windows.Forms.Label();
            this.CuragaVcount = new System.Windows.Forms.NumericUpDown();
            this.CuragaIVcount = new System.Windows.Forms.NumericUpDown();
            this.CuragaIIIcount = new System.Windows.Forms.NumericUpDown();
            this.CuragaIIcount = new System.Windows.Forms.NumericUpDown();
            this.label69 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.Curagacount = new System.Windows.Forms.NumericUpDown();
            this.DrainAspirpage = new System.Windows.Forms.TabPage();
            this.Aspirgroup = new System.Windows.Forms.GroupBox();
            this.AspirIIIcount = new System.Windows.Forms.NumericUpDown();
            this.AspirIIcount = new System.Windows.Forms.NumericUpDown();
            this.AspirIIItext = new System.Windows.Forms.Label();
            this.AspirItext = new System.Windows.Forms.Label();
            this.AspirIItext = new System.Windows.Forms.Label();
            this.Aspircount = new System.Windows.Forms.NumericUpDown();
            this.Draingroup = new System.Windows.Forms.GroupBox();
            this.DrainIItext = new System.Windows.Forms.Label();
            this.Draincount = new System.Windows.Forms.NumericUpDown();
            this.DrainItext = new System.Windows.Forms.Label();
            this.DrainIIItext = new System.Windows.Forms.Label();
            this.DrainIIIcount = new System.Windows.Forms.NumericUpDown();
            this.DrainIIcount = new System.Windows.Forms.NumericUpDown();
            this.BLUCurespage = new System.Windows.Forms.TabPage();
            this.MagicFruitcount = new System.Windows.Forms.NumericUpDown();
            this.Pollencount = new System.Windows.Forms.NumericUpDown();
            this.HealingBreezecount = new System.Windows.Forms.NumericUpDown();
            this.PleniluneEmbracecount = new System.Windows.Forms.NumericUpDown();
            this.Restoralcount = new System.Windows.Forms.NumericUpDown();
            this.WhiteWindcount = new System.Windows.Forms.NumericUpDown();
            this.Exuviationcount = new System.Windows.Forms.NumericUpDown();
            this.WildCarrotcount = new System.Windows.Forms.NumericUpDown();
            this.PleniluneEmbracetext = new System.Windows.Forms.Label();
            this.MagicFruittext = new System.Windows.Forms.Label();
            this.HealingBreezetext = new System.Windows.Forms.Label();
            this.Pollentext = new System.Windows.Forms.Label();
            this.WhiteWindtext = new System.Windows.Forms.Label();
            this.Restoraltext = new System.Windows.Forms.Label();
            this.Exuviationtext = new System.Windows.Forms.Label();
            this.WildCarrottext = new System.Windows.Forms.Label();
            this.MAconfigpage = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.MAreverse = new System.Windows.Forms.CheckBox();
            this.Dynamispage = new System.Windows.Forms.TabPage();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.NoneProcuse = new System.Windows.Forms.CheckBox();
            this.DynaProccontrole = new System.Windows.Forms.CheckBox();
            this.label59 = new System.Windows.Forms.Label();
            this.Dynatxt = new System.Windows.Forms.Label();
            this.staggerstopJA = new System.Windows.Forms.CheckBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.delaytext = new System.Windows.Forms.Label();
            this.pullDelay = new System.Windows.Forms.NumericUpDown();
            this.AutoLock = new System.Windows.Forms.CheckBox();
            this.mobheightdistValue = new System.Windows.Forms.NumericUpDown();
            this.mobheightdist = new System.Windows.Forms.CheckBox();
            this.runTarget = new System.Windows.Forms.CheckBox();
            this.runPullDistance = new System.Windows.Forms.CheckBox();
            this.mobsearchdisttext = new System.Windows.Forms.Label();
            this.targetSearchDist = new System.Windows.Forms.NumericUpDown();
            this.pullTolorance = new System.Windows.Forms.NumericUpDown();
            this.pulltolorancetext = new System.Windows.Forms.Label();
            this.numericUpDown21 = new System.Windows.Forms.NumericUpDown();
            this.pulldistance = new System.Windows.Forms.Label();
            this.pullCommand = new System.Windows.Forms.TextBox();
            this.pullcommandtext = new System.Windows.Forms.Label();
            this.dancer = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.noSamba = new System.Windows.Forms.RadioButton();
            this.usedrainiii = new System.Windows.Forms.RadioButton();
            this.usehaste = new System.Windows.Forms.RadioButton();
            this.useaspirii = new System.Windows.Forms.RadioButton();
            this.useaspir = new System.Windows.Forms.RadioButton();
            this.usedrainii = new System.Windows.Forms.RadioButton();
            this.usedrain = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.stopstepsat = new System.Windows.Forms.CheckBox();
            this.stopstepscount = new System.Windows.Forms.NumericUpDown();
            this.stopstepsathptext = new System.Windows.Forms.Label();
            this.usefeatherstepValue = new System.Windows.Forms.NumericUpDown();
            this.usestutterstepValue = new System.Windows.Forms.NumericUpDown();
            this.useboxstepValue = new System.Windows.Forms.NumericUpDown();
            this.StepsHPValue = new System.Windows.Forms.NumericUpDown();
            this.usequickstepValue = new System.Windows.Forms.NumericUpDown();
            this.StepsHP = new System.Windows.Forms.CheckBox();
            this.NoSteps = new System.Windows.Forms.RadioButton();
            this.usequickstep = new System.Windows.Forms.RadioButton();
            this.useboxstep = new System.Windows.Forms.RadioButton();
            this.usestutterstep = new System.Windows.Forms.RadioButton();
            this.usefeatherstep = new System.Windows.Forms.RadioButton();
            this.tabPage15 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.HWSelectDeselectALL = new System.Windows.Forms.CheckBox();
            this.HealingWaltzItems = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.usecurevValue = new System.Windows.Forms.NumericUpDown();
            this.usecureivValue = new System.Windows.Forms.NumericUpDown();
            this.usecureiiiValue = new System.Windows.Forms.NumericUpDown();
            this.usecureiiValue = new System.Windows.Forms.NumericUpDown();
            this.usecureValue = new System.Windows.Forms.NumericUpDown();
            this.usecurev = new System.Windows.Forms.CheckBox();
            this.usecureiv = new System.Windows.Forms.CheckBox();
            this.usecureiii = new System.Windows.Forms.CheckBox();
            this.usecureii = new System.Windows.Forms.CheckBox();
            this.usecure = new System.Windows.Forms.CheckBox();
            this.tabPage16 = new System.Windows.Forms.TabPage();
            this.PartyWaltsList = new System.Windows.Forms.CheckedListBox();
            this.addplayertext = new System.Windows.Forms.Label();
            this.WaltzPTadd = new System.Windows.Forms.TextBox();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.numericUpDown27 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown28 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown29 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown32 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown33 = new System.Windows.Forms.NumericUpDown();
            this.ptusecurev = new System.Windows.Forms.CheckBox();
            this.ptusecureiv = new System.Windows.Forms.CheckBox();
            this.ptusecureiii = new System.Windows.Forms.CheckBox();
            this.ptusecureii = new System.Windows.Forms.CheckBox();
            this.ptusecure = new System.Windows.Forms.CheckBox();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.GetSetParty = new System.Windows.Forms.MenuStrip();
            this.loadPartyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearPartyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label15 = new System.Windows.Forms.Label();
            this.flourish = new System.Windows.Forms.TabPage();
            this.flourishesiiigroup = new System.Windows.Forms.GroupBox();
            this.useclmfloValue = new System.Windows.Forms.NumericUpDown();
            this.usestkfloValue = new System.Windows.Forms.NumericUpDown();
            this.useterfloValue = new System.Windows.Forms.NumericUpDown();
            this.usestkflo = new System.Windows.Forms.RadioButton();
            this.useclmflo = new System.Windows.Forms.RadioButton();
            this.useterflo = new System.Windows.Forms.RadioButton();
            this.finsishingmovetext = new System.Windows.Forms.Label();
            this.FlourishTPValue = new System.Windows.Forms.NumericUpDown();
            this.flourishesiigroup = new System.Windows.Forms.GroupBox();
            this.usewldfloValue = new System.Windows.Forms.NumericUpDown();
            this.usebldfloValue = new System.Windows.Forms.NumericUpDown();
            this.userevfloValue = new System.Windows.Forms.NumericUpDown();
            this.usewldflo = new System.Windows.Forms.RadioButton();
            this.usebldflo = new System.Windows.Forms.RadioButton();
            this.userevflo = new System.Windows.Forms.RadioButton();
            this.FlourishTP = new System.Windows.Forms.CheckBox();
            this.flourishesigroup = new System.Windows.Forms.GroupBox();
            this.useviofloValue = new System.Windows.Forms.NumericUpDown();
            this.usevioflo = new System.Windows.Forms.RadioButton();
            this.usedesfloValue = new System.Windows.Forms.NumericUpDown();
            this.usedesflo = new System.Windows.Forms.RadioButton();
            this.pets = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.petControl = new System.Windows.Forms.TabControl();
            this.bstpettab = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.BstJATP = new System.Windows.Forms.NumericUpDown();
            this.usepetja = new System.Windows.Forms.GroupBox();
            this.PetJA = new System.Windows.Forms.CheckedListBox();
            this.bstpetrdygroup = new System.Windows.Forms.GroupBox();
            this.PetReady = new System.Windows.Forms.CheckedListBox();
            this.usedpetfood = new System.Windows.Forms.ComboBox();
            this.jugpet = new System.Windows.Forms.ComboBox();
            this.juguse = new System.Windows.Forms.CheckBox();
            this.pethppfood = new System.Windows.Forms.NumericUpDown();
            this.pethptext = new System.Windows.Forms.Label();
            this.petfooduse = new System.Windows.Forms.CheckBox();
            this.autoengage = new System.Windows.Forms.CheckBox();
            this.drgpettab = new System.Windows.Forms.TabPage();
            this.DragonPetHP = new System.Windows.Forms.NumericUpDown();
            this.drgsteadywingtext = new System.Windows.Forms.Label();
            this.CallWyvern = new System.Windows.Forms.CheckBox();
            this.drgspirtlinkgroup = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.PlayerSpirit = new System.Windows.Forms.NumericUpDown();
            this.WyvernSpirit = new System.Windows.Forms.NumericUpDown();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.BreathMAX = new System.Windows.Forms.NumericUpDown();
            this.label48 = new System.Windows.Forms.Label();
            this.BreathMIN = new System.Windows.Forms.NumericUpDown();
            this.drgwyvernbreathptext = new System.Windows.Forms.Label();
            this.drgrestoringbreathgroup = new System.Windows.Forms.GroupBox();
            this.RestoringBreathHP = new System.Windows.Forms.NumericUpDown();
            this.label50 = new System.Windows.Forms.Label();
            this.drgjagroup = new System.Windows.Forms.GroupBox();
            this.WyvernJA = new System.Windows.Forms.CheckedListBox();
            this.smnpettab = new System.Windows.Forms.TabPage();
            this.autoengageAvatar = new System.Windows.Forms.CheckBox();
            this.ManaCedegroup = new System.Windows.Forms.GroupBox();
            this.ManaCedePETTPtext = new System.Windows.Forms.Label();
            this.ManaCedeTPset = new System.Windows.Forms.NumericUpDown();
            this.ManaCedePMPPtext = new System.Windows.Forms.Label();
            this.ManaCedeMPPset = new System.Windows.Forms.NumericUpDown();
            this.Apogeetext = new System.Windows.Forms.Label();
            this.ApogeeMPPset = new System.Windows.Forms.NumericUpDown();
            this.SMNpetMPUSEtext = new System.Windows.Forms.Label();
            this.SMNpetMPUSEset = new System.Windows.Forms.NumericUpDown();
            this.SMNHPPset1 = new System.Windows.Forms.NumericUpDown();
            this.SMNHPPset2 = new System.Windows.Forms.NumericUpDown();
            this.SMNHealTEXT2 = new System.Windows.Forms.Label();
            this.SMNHealTEXT1 = new System.Windows.Forms.Label();
            this.SMNpetTPUSEtext = new System.Windows.Forms.Label();
            this.SMNpetTPUSEset = new System.Windows.Forms.NumericUpDown();
            this.SMNJAgroup = new System.Windows.Forms.GroupBox();
            this.SMNJA = new System.Windows.Forms.CheckedListBox();
            this.SelectSMNtext = new System.Windows.Forms.Label();
            this.SMNSelect = new System.Windows.Forms.ComboBox();
            this.SMNAbilitysgroup = new System.Windows.Forms.GroupBox();
            this.SMNAbilityList = new System.Windows.Forms.CheckedListBox();
            this.puppettab = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.PUPAbilitypage = new System.Windows.Forms.TabPage();
            this.Maneuversgroup = new System.Windows.Forms.GroupBox();
            this.Maneuver3select = new System.Windows.Forms.ComboBox();
            this.Maneuver2select = new System.Windows.Forms.ComboBox();
            this.Maneuver1set = new System.Windows.Forms.NumericUpDown();
            this.Maneuver2set = new System.Windows.Forms.NumericUpDown();
            this.Maneuver3set = new System.Windows.Forms.NumericUpDown();
            this.Maneuver1select = new System.Windows.Forms.ComboBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.healforAutomatonMP = new System.Windows.Forms.CheckBox();
            this.healforAutomatonHP = new System.Windows.Forms.CheckBox();
            this.healforAutomatonMPset = new System.Windows.Forms.NumericUpDown();
            this.healforAutomatonHPset = new System.Windows.Forms.NumericUpDown();
            this.AutoCallPUP = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.PUPJA = new System.Windows.Forms.CheckedListBox();
            this.PUPautoengage = new System.Windows.Forms.CheckBox();
            this.PUPOtherpage = new System.Windows.Forms.TabPage();
            this.Ventriloquygroup = new System.Windows.Forms.GroupBox();
            this.VentriloquyPet = new System.Windows.Forms.RadioButton();
            this.VentriloquyPlayer = new System.Windows.Forms.RadioButton();
            this.Repairgroup = new System.Windows.Forms.GroupBox();
            this.Repairselect = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.Repairset = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.TacticalSwitchgroup = new System.Windows.Forms.GroupBox();
            this.TSPET = new System.Windows.Forms.RadioButton();
            this.TSPlayer = new System.Windows.Forms.RadioButton();
            this.TSPetTPset = new System.Windows.Forms.NumericUpDown();
            this.TSPlayerTPset = new System.Windows.Forms.NumericUpDown();
            this.label26 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.RoleReversalgroup = new System.Windows.Forms.GroupBox();
            this.RRPET = new System.Windows.Forms.RadioButton();
            this.RRPlayer = new System.Windows.Forms.RadioButton();
            this.RRPetHPPset = new System.Windows.Forms.NumericUpDown();
            this.RRPlayerHPPset = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.geopettab = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label40 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.GEOJA = new System.Windows.Forms.CheckedListBox();
            this.trustControl = new System.Windows.Forms.TabPage();
            this.label63 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.selectedtrusts = new System.Windows.Forms.Label();
            this.maxtrustslabel = new System.Windows.Forms.Label();
            this.Trusts = new System.Windows.Forms.CheckedListBox();
            this.trustmenuStrip = new System.Windows.Forms.MenuStrip();
            this.trustMenureset = new System.Windows.Forms.ToolStripMenuItem();
            this.hudpage = new System.Windows.Forms.TabPage();
            this.hudinfobutton = new System.Windows.Forms.Button();
            this.advhudtext = new System.Windows.Forms.Label();
            this.hudtext = new System.Windows.Forms.TextBox();
            this.hudY = new System.Windows.Forms.NumericUpDown();
            this.hudYlabel = new System.Windows.Forms.Label();
            this.hudX = new System.Windows.Forms.NumericUpDown();
            this.hudXlabel = new System.Windows.Forms.Label();
            this.showHUD = new System.Windows.Forms.CheckBox();
            this.numericUpDown8 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown9 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown10 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.bgw_script_dnc = new System.ComponentModel.BackgroundWorker();
            this.bgw_script_nav = new System.ComponentModel.BackgroundWorker();
            this.bgw_script_sch = new System.ComponentModel.BackgroundWorker();
            this.bgw_script_disp = new System.ComponentModel.BackgroundWorker();
            this.bgw_script_chat = new System.ComponentModel.BackgroundWorker();
            this.bgw_script_pet = new System.ComponentModel.BackgroundWorker();
            this.bgw_script_npc = new System.ComponentModel.BackgroundWorker();
            this.bgw_script_scn = new System.ComponentModel.BackgroundWorker();
            this.DeathWarp = new System.Windows.Forms.CheckBox();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.playerjobpoints = new System.Windows.Forms.Label();
            this.playermerits = new System.Windows.Forms.Label();
            this.Runtest = new System.Windows.Forms.Button();
            this.playertp = new System.Windows.Forms.Label();
            this.playermp = new System.Windows.Forms.Label();
            this.playerhp = new System.Windows.Forms.Label();
            this.curtime = new System.Windows.Forms.Label();
            this.curtarghpp = new System.Windows.Forms.Label();
            this.curtarg = new System.Windows.Forms.Label();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.curtargid = new System.Windows.Forms.Label();
            this.Shrinkbutton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.IdleLocationDist = new System.Windows.Forms.NumericUpDown();
            this.groupBox8.SuspendLayout();
            this.GetSetNavi.SuspendLayout();
            this.StartStopScript.SuspendLayout();
            this.dncControl.SuspendLayout();
            this.targets.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.ZoneTargets.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.GetSetTargets.SuspendLayout();
            this.selecttargets.SuspendLayout();
            this.combat.SuspendLayout();
            this.CombatSettingsTabs.SuspendLayout();
            this.Options1MainTab.SuspendLayout();
            this.HateControlgroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).BeginInit();
            this.groupBox20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AfterMathTier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WSDistanceset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WStp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TragetHPPtop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TragetHPPbottom)).BeginInit();
            this.Options2MainTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aggroRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeepTargetRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assistDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.followDist)).BeginInit();
            this.Options3MainTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.healMPcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.healHPcount)).BeginInit();
            this.Options4MainTab.SuspendLayout();
            this.NotinBattle.SuspendLayout();
            this.groupBox15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoRangeDelay)).BeginInit();
            this.selectapp.SuspendLayout();
            this.shutdowngroup.SuspendLayout();
            this.groupBox25.SuspendLayout();
            this.groupBox16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StuckDistance)).BeginInit();
            this.OptionsJAMainTab.SuspendLayout();
            this.JAtabselect.SuspendLayout();
            this.selectPage.SuspendLayout();
            this.GetSetJA.SuspendLayout();
            this.WHMpage.SuspendLayout();
            this.benedictiongroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BenedictionHPPuse)).BeginInit();
            this.RDMpage.SuspendLayout();
            this.Convertgroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConvertHPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConvertMPP)).BeginInit();
            this.samPage.SuspendLayout();
            this.SCHpage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sublimationcount)).BeginInit();
            this.RUNpage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VivaciousPulseHP)).BeginInit();
            this.MONpage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MONmpCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MONhpCount)).BeginInit();
            this.OptionsMAMainTab.SuspendLayout();
            this.MAtabs.SuspendLayout();
            this.MASelectPage.SuspendLayout();
            this.GetSetMA.SuspendLayout();
            this.CureConfigPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CuraIIcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Curacount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureIIIcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureIIcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Curecount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CuraIIIcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FullCurecount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureVIcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureVcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureIVcount)).BeginInit();
            this.PartyCurepage.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FullCureptcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureVIptcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureVptcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureIVptcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureIIIptcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureIIptcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cureptcount)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.Cureagapage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CuragaVcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CuragaIVcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CuragaIIIcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CuragaIIcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Curagacount)).BeginInit();
            this.DrainAspirpage.SuspendLayout();
            this.Aspirgroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AspirIIIcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AspirIIcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Aspircount)).BeginInit();
            this.Draingroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Draincount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrainIIIcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrainIIcount)).BeginInit();
            this.BLUCurespage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MagicFruitcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pollencount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealingBreezecount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PleniluneEmbracecount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Restoralcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WhiteWindcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exuviationcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WildCarrotcount)).BeginInit();
            this.MAconfigpage.SuspendLayout();
            this.Dynamispage.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pullDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobheightdistValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetSearchDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pullTolorance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown21)).BeginInit();
            this.dancer.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stopstepscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usefeatherstepValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usestutterstepValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.useboxstepValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepsHPValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usequickstepValue)).BeginInit();
            this.tabPage15.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usecurevValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usecureivValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usecureiiiValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usecureiiValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usecureValue)).BeginInit();
            this.tabPage16.SuspendLayout();
            this.groupBox21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown33)).BeginInit();
            this.groupBox22.SuspendLayout();
            this.GetSetParty.SuspendLayout();
            this.flourish.SuspendLayout();
            this.flourishesiiigroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.useclmfloValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usestkfloValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.useterfloValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlourishTPValue)).BeginInit();
            this.flourishesiigroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usewldfloValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usebldfloValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userevfloValue)).BeginInit();
            this.flourishesigroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.useviofloValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usedesfloValue)).BeginInit();
            this.pets.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.petControl.SuspendLayout();
            this.bstpettab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BstJATP)).BeginInit();
            this.usepetja.SuspendLayout();
            this.bstpetrdygroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pethppfood)).BeginInit();
            this.drgpettab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DragonPetHP)).BeginInit();
            this.drgspirtlinkgroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerSpirit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WyvernSpirit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BreathMAX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BreathMIN)).BeginInit();
            this.drgrestoringbreathgroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RestoringBreathHP)).BeginInit();
            this.drgjagroup.SuspendLayout();
            this.smnpettab.SuspendLayout();
            this.ManaCedegroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ManaCedeTPset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManaCedeMPPset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApogeeMPPset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SMNpetMPUSEset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SMNHPPset1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SMNHPPset2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SMNpetTPUSEset)).BeginInit();
            this.SMNJAgroup.SuspendLayout();
            this.SMNAbilitysgroup.SuspendLayout();
            this.puppettab.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.PUPAbilitypage.SuspendLayout();
            this.Maneuversgroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Maneuver1set)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maneuver2set)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maneuver3set)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.healforAutomatonMPset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.healforAutomatonHPset)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.PUPOtherpage.SuspendLayout();
            this.Ventriloquygroup.SuspendLayout();
            this.Repairgroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Repairset)).BeginInit();
            this.TacticalSwitchgroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TSPetTPset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TSPlayerTPset)).BeginInit();
            this.RoleReversalgroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RRPetHPPset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RRPlayerHPPset)).BeginInit();
            this.geopettab.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.trustControl.SuspendLayout();
            this.trustmenuStrip.SuspendLayout();
            this.hudpage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hudY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hudX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox18.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IdleLocationDist)).BeginInit();
            this.SuspendLayout();
            // 
            // checkZone
            // 
            this.checkZone.AutoSize = true;
            this.checkZone.Checked = true;
            this.checkZone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkZone.Location = new System.Drawing.Point(167, 205);
            this.checkZone.Name = "checkZone";
            this.checkZone.Size = new System.Drawing.Size(91, 17);
            this.checkZone.TabIndex = 51;
            this.checkZone.Text = "Stop on Zone";
            this.checkZone.UseVisualStyleBackColor = true;
            // 
            // StopFullInventory
            // 
            this.StopFullInventory.AutoSize = true;
            this.StopFullInventory.Location = new System.Drawing.Point(13, 188);
            this.StopFullInventory.Name = "StopFullInventory";
            this.StopFullInventory.Size = new System.Drawing.Size(129, 17);
            this.StopFullInventory.TabIndex = 50;
            this.StopFullInventory.Text = "Stop on Full Inventory";
            this.StopFullInventory.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.comboBox3);
            this.groupBox8.Controls.Add(this.firstPersonView);
            this.groupBox8.Controls.Add(this.runReverse);
            this.groupBox8.Controls.Add(this.Linear);
            this.groupBox8.Controls.Add(this.Circular);
            this.groupBox8.Controls.Add(this.selectedNavi);
            this.groupBox8.Controls.Add(this.GetSetNavi);
            this.groupBox8.Enabled = false;
            this.groupBox8.Location = new System.Drawing.Point(13, 219);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(253, 128);
            this.groupBox8.TabIndex = 49;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Nav Control";
            // 
            // comboBox3
            // 
            this.comboBox3.Enabled = false;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(7, 42);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(238, 21);
            this.comboBox3.TabIndex = 34;
            // 
            // firstPersonView
            // 
            this.firstPersonView.AutoSize = true;
            this.firstPersonView.Location = new System.Drawing.Point(128, 68);
            this.firstPersonView.Name = "firstPersonView";
            this.firstPersonView.Size = new System.Drawing.Size(103, 17);
            this.firstPersonView.TabIndex = 33;
            this.firstPersonView.Text = "Use First Person";
            this.firstPersonView.UseVisualStyleBackColor = true;
            // 
            // runReverse
            // 
            this.runReverse.AutoSize = true;
            this.runReverse.Enabled = false;
            this.runReverse.Location = new System.Drawing.Point(128, 84);
            this.runReverse.Name = "runReverse";
            this.runReverse.Size = new System.Drawing.Size(89, 17);
            this.runReverse.TabIndex = 32;
            this.runReverse.Text = "Run Reverse";
            this.runReverse.UseVisualStyleBackColor = true;
            // 
            // Linear
            // 
            this.Linear.AutoSize = true;
            this.Linear.Location = new System.Drawing.Point(7, 84);
            this.Linear.Name = "Linear";
            this.Linear.Size = new System.Drawing.Size(79, 17);
            this.Linear.TabIndex = 31;
            this.Linear.Text = "Linear Path";
            this.Linear.UseVisualStyleBackColor = true;
            // 
            // Circular
            // 
            this.Circular.AutoSize = true;
            this.Circular.Checked = true;
            this.Circular.Location = new System.Drawing.Point(7, 68);
            this.Circular.Name = "Circular";
            this.Circular.Size = new System.Drawing.Size(85, 17);
            this.Circular.TabIndex = 30;
            this.Circular.TabStop = true;
            this.Circular.Text = "Circular Path";
            this.Circular.UseVisualStyleBackColor = true;
            // 
            // selectedNavi
            // 
            this.selectedNavi.FormattingEnabled = true;
            this.selectedNavi.Location = new System.Drawing.Point(7, 19);
            this.selectedNavi.Name = "selectedNavi";
            this.selectedNavi.Size = new System.Drawing.Size(238, 21);
            this.selectedNavi.TabIndex = 29;
            this.selectedNavi.TextChanged += new System.EventHandler(this.SelectedNaviSelectedIndexChanged);
            // 
            // GetSetNavi
            // 
            this.GetSetNavi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GetSetNavi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.GetSetNavi.Location = new System.Drawing.Point(3, 101);
            this.GetSetNavi.Name = "GetSetNavi";
            this.GetSetNavi.Size = new System.Drawing.Size(247, 24);
            this.GetSetNavi.TabIndex = 0;
            this.GetSetNavi.Text = "GetSetNavi";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(132, 20);
            this.refreshToolStripMenuItem.Text = "refresh navigation list";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItemClick);
            // 
            // navStuckWatch
            // 
            this.navStuckWatch.AutoSize = true;
            this.navStuckWatch.Location = new System.Drawing.Point(13, 48);
            this.navStuckWatch.Name = "navStuckWatch";
            this.navStuckWatch.Size = new System.Drawing.Size(48, 17);
            this.navStuckWatch.TabIndex = 35;
            this.navStuckWatch.Text = "NAV";
            this.navStuckWatch.UseVisualStyleBackColor = true;
            // 
            // usenav
            // 
            this.usenav.AutoSize = true;
            this.usenav.Location = new System.Drawing.Point(13, 205);
            this.usenav.Name = "usenav";
            this.usenav.Size = new System.Drawing.Size(118, 17);
            this.usenav.TabIndex = 48;
            this.usenav.Text = "Use Navigation File";
            this.usenav.UseVisualStyleBackColor = true;
            this.usenav.CheckedChanged += new System.EventHandler(this.UsenavCheckedChanged);
            // 
            // StartStopScript
            // 
            this.StartStopScript.Dock = System.Windows.Forms.DockStyle.None;
            this.StartStopScript.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startScriptToolStripMenuItem,
            this.stopScriptToolStripMenuItem,
            this.updateJobToolStripMenuItem});
            this.StartStopScript.Location = new System.Drawing.Point(20, 351);
            this.StartStopScript.Name = "StartStopScript";
            this.StartStopScript.Size = new System.Drawing.Size(238, 24);
            this.StartStopScript.TabIndex = 47;
            this.StartStopScript.Text = "StartStopScript";
            // 
            // startScriptToolStripMenuItem
            // 
            this.startScriptToolStripMenuItem.Name = "startScriptToolStripMenuItem";
            this.startScriptToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.startScriptToolStripMenuItem.Text = "Start Script";
            this.startScriptToolStripMenuItem.Click += new System.EventHandler(this.ToolStartClick);
            // 
            // stopScriptToolStripMenuItem
            // 
            this.stopScriptToolStripMenuItem.Enabled = false;
            this.stopScriptToolStripMenuItem.Name = "stopScriptToolStripMenuItem";
            this.stopScriptToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.stopScriptToolStripMenuItem.Text = "Stop Script";
            this.stopScriptToolStripMenuItem.Click += new System.EventHandler(this.ToolStopClick);
            // 
            // updateJobToolStripMenuItem
            // 
            this.updateJobToolStripMenuItem.Name = "updateJobToolStripMenuItem";
            this.updateJobToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.updateJobToolStripMenuItem.Text = "Update Job";
            this.updateJobToolStripMenuItem.Click += new System.EventHandler(this.UpdateJobToolStripMenuItemClick);
            // 
            // dncControl
            // 
            this.dncControl.Controls.Add(this.targets);
            this.dncControl.Controls.Add(this.combat);
            this.dncControl.Controls.Add(this.dancer);
            this.dncControl.Controls.Add(this.flourish);
            this.dncControl.Controls.Add(this.pets);
            this.dncControl.Controls.Add(this.trustControl);
            this.dncControl.Controls.Add(this.hudpage);
            this.dncControl.Location = new System.Drawing.Point(10, 25);
            this.dncControl.Name = "dncControl";
            this.dncControl.SelectedIndex = 0;
            this.dncControl.Size = new System.Drawing.Size(447, 387);
            this.dncControl.TabIndex = 46;
            // 
            // targets
            // 
            this.targets.Controls.Add(this.groupBox9);
            this.targets.Controls.Add(this.groupBox11);
            this.targets.Controls.Add(this.groupBox12);
            this.targets.Controls.Add(this.selecttargets);
            this.targets.Location = new System.Drawing.Point(4, 22);
            this.targets.Name = "targets";
            this.targets.Padding = new System.Windows.Forms.Padding(3);
            this.targets.Size = new System.Drawing.Size(439, 361);
            this.targets.TabIndex = 6;
            this.targets.Text = "Farm/Targets";
            this.targets.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.ZoneTargets);
            this.groupBox9.Location = new System.Drawing.Point(224, 292);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(200, 49);
            this.groupBox9.TabIndex = 10;
            this.groupBox9.TabStop = false;
            // 
            // ZoneTargets
            // 
            this.ZoneTargets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NameListToolStripMenuItem,
            this.iDToolStripMenuItem});
            this.ZoneTargets.Location = new System.Drawing.Point(3, 16);
            this.ZoneTargets.Name = "ZoneTargets";
            this.ZoneTargets.Size = new System.Drawing.Size(194, 24);
            this.ZoneTargets.TabIndex = 0;
            this.ZoneTargets.Text = "ZoneTargets";
            // 
            // NameListToolStripMenuItem
            // 
            this.NameListToolStripMenuItem.Name = "NameListToolStripMenuItem";
            this.NameListToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.NameListToolStripMenuItem.Text = "Name";
            this.NameListToolStripMenuItem.Click += new System.EventHandler(this.NameListToolStripMenuItem_Click);
            // 
            // iDToolStripMenuItem
            // 
            this.iDToolStripMenuItem.Name = "iDToolStripMenuItem";
            this.iDToolStripMenuItem.Size = new System.Drawing.Size(30, 20);
            this.iDToolStripMenuItem.Text = "ID";
            this.iDToolStripMenuItem.Click += new System.EventHandler(this.IdToolStripMenuItemClick);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.TargetList);
            this.groupBox11.Location = new System.Drawing.Point(224, 10);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(201, 276);
            this.groupBox11.TabIndex = 9;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Target List";
            // 
            // TargetList
            // 
            this.TargetList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TargetList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.TargetList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TargetList.FullRowSelect = true;
            this.TargetList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.TargetList.Location = new System.Drawing.Point(3, 16);
            this.TargetList.Name = "TargetList";
            this.TargetList.Size = new System.Drawing.Size(195, 257);
            this.TargetList.TabIndex = 1;
            this.TargetList.UseCompatibleStateImageBehavior = false;
            this.TargetList.View = System.Windows.Forms.View.Details;
            this.TargetList.DoubleClick += new System.EventHandler(this.ListView2DoubleClick);
            this.TargetList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ListView2KeyPress);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID";
            this.columnHeader3.Width = 35;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Name";
            this.columnHeader4.Width = 140;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.GetSetTargets);
            this.groupBox12.Location = new System.Drawing.Point(12, 292);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(200, 49);
            this.groupBox12.TabIndex = 8;
            this.groupBox12.TabStop = false;
            // 
            // GetSetTargets
            // 
            this.GetSetTargets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.GetSetTargets.Location = new System.Drawing.Point(3, 16);
            this.GetSetTargets.Name = "GetSetTargets";
            this.GetSetTargets.Size = new System.Drawing.Size(194, 24);
            this.GetSetTargets.TabIndex = 0;
            this.GetSetTargets.Text = "GetSetTargets";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItemClick);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.ClearToolStripMenuItemClick);
            // 
            // selecttargets
            // 
            this.selecttargets.Controls.Add(this.SelectedTargets);
            this.selecttargets.Location = new System.Drawing.Point(12, 10);
            this.selecttargets.Name = "selecttargets";
            this.selecttargets.Size = new System.Drawing.Size(201, 276);
            this.selecttargets.TabIndex = 7;
            this.selecttargets.TabStop = false;
            this.selecttargets.Text = "Selected Targets";
            // 
            // SelectedTargets
            // 
            this.SelectedTargets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SelectedTargets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.SelectedTargets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectedTargets.FullRowSelect = true;
            this.SelectedTargets.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.SelectedTargets.Location = new System.Drawing.Point(3, 16);
            this.SelectedTargets.Name = "SelectedTargets";
            this.SelectedTargets.Size = new System.Drawing.Size(195, 257);
            this.SelectedTargets.TabIndex = 0;
            this.SelectedTargets.UseCompatibleStateImageBehavior = false;
            this.SelectedTargets.View = System.Windows.Forms.View.Details;
            this.SelectedTargets.DoubleClick += new System.EventHandler(this.ListView1DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 35;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 140;
            // 
            // combat
            // 
            this.combat.Controls.Add(this.CombatSettingsTabs);
            this.combat.Controls.Add(this.groupBox14);
            this.combat.Location = new System.Drawing.Point(4, 22);
            this.combat.Name = "combat";
            this.combat.Padding = new System.Windows.Forms.Padding(3);
            this.combat.Size = new System.Drawing.Size(439, 361);
            this.combat.TabIndex = 7;
            this.combat.Text = "Combat Settings";
            this.combat.UseVisualStyleBackColor = true;
            // 
            // CombatSettingsTabs
            // 
            this.CombatSettingsTabs.Controls.Add(this.Options1MainTab);
            this.CombatSettingsTabs.Controls.Add(this.Options2MainTab);
            this.CombatSettingsTabs.Controls.Add(this.Options3MainTab);
            this.CombatSettingsTabs.Controls.Add(this.Options4MainTab);
            this.CombatSettingsTabs.Controls.Add(this.selectapp);
            this.CombatSettingsTabs.Controls.Add(this.OptionsJAMainTab);
            this.CombatSettingsTabs.Controls.Add(this.OptionsMAMainTab);
            this.CombatSettingsTabs.Controls.Add(this.Dynamispage);
            this.CombatSettingsTabs.Location = new System.Drawing.Point(6, 132);
            this.CombatSettingsTabs.Name = "CombatSettingsTabs";
            this.CombatSettingsTabs.SelectedIndex = 0;
            this.CombatSettingsTabs.Size = new System.Drawing.Size(427, 223);
            this.CombatSettingsTabs.TabIndex = 22;
            // 
            // Options1MainTab
            // 
            this.Options1MainTab.Controls.Add(this.HateControlgroup);
            this.Options1MainTab.Controls.Add(this.groupBox20);
            this.Options1MainTab.Location = new System.Drawing.Point(4, 22);
            this.Options1MainTab.Name = "Options1MainTab";
            this.Options1MainTab.Padding = new System.Windows.Forms.Padding(3);
            this.Options1MainTab.Size = new System.Drawing.Size(419, 197);
            this.Options1MainTab.TabIndex = 6;
            this.Options1MainTab.Text = "Options 1";
            this.Options1MainTab.UseVisualStyleBackColor = true;
            // 
            // HateControlgroup
            // 
            this.HateControlgroup.Controls.Add(this.numericUpDown6);
            this.HateControlgroup.Controls.Add(this.numericUpDown7);
            this.HateControlgroup.Controls.Add(this.label4);
            this.HateControlgroup.Controls.Add(this.label5);
            this.HateControlgroup.Controls.Add(this.label6);
            this.HateControlgroup.Controls.Add(this.selectedHateControl);
            this.HateControlgroup.Controls.Add(this.tank);
            this.HateControlgroup.Location = new System.Drawing.Point(53, 116);
            this.HateControlgroup.Name = "HateControlgroup";
            this.HateControlgroup.Size = new System.Drawing.Size(314, 68);
            this.HateControlgroup.TabIndex = 1;
            this.HateControlgroup.TabStop = false;
            this.HateControlgroup.Text = "Hate Control";
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown6.Location = new System.Drawing.Point(207, 39);
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown6.TabIndex = 108;
            this.numericUpDown6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown6.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDown7
            // 
            this.numericUpDown7.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown7.Location = new System.Drawing.Point(125, 39);
            this.numericUpDown7.Name = "numericUpDown7";
            this.numericUpDown7.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown7.TabIndex = 107;
            this.numericUpDown7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown7.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 106;
            this.label4.Text = "Mob HP% to Tank";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(257, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 110;
            this.label5.Text = "MAX";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(175, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 109;
            this.label6.Text = "MIN";
            // 
            // selectedHateControl
            // 
            this.selectedHateControl.FormattingEnabled = true;
            this.selectedHateControl.Location = new System.Drawing.Point(125, 16);
            this.selectedHateControl.Name = "selectedHateControl";
            this.selectedHateControl.Size = new System.Drawing.Size(176, 21);
            this.selectedHateControl.TabIndex = 105;
            // 
            // tank
            // 
            this.tank.AutoSize = true;
            this.tank.Location = new System.Drawing.Point(18, 17);
            this.tank.Name = "tank";
            this.tank.Size = new System.Drawing.Size(73, 17);
            this.tank.TabIndex = 104;
            this.tank.Text = "Tank with";
            this.tank.UseVisualStyleBackColor = true;
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.amname);
            this.groupBox20.Controls.Add(this.AfterMathTier);
            this.groupBox20.Controls.Add(this.wsam);
            this.groupBox20.Controls.Add(this.WSDistance);
            this.groupBox20.Controls.Add(this.selectedWS);
            this.groupBox20.Controls.Add(this.WSDistanceset);
            this.groupBox20.Controls.Add(this.ws);
            this.groupBox20.Controls.Add(this.WStp);
            this.groupBox20.Controls.Add(this.label29);
            this.groupBox20.Controls.Add(this.TragetHPPtop);
            this.groupBox20.Controls.Add(this.label28);
            this.groupBox20.Controls.Add(this.TragetHPPbottom);
            this.groupBox20.Controls.Add(this.label27);
            this.groupBox20.Location = new System.Drawing.Point(52, 6);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(315, 109);
            this.groupBox20.TabIndex = 0;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Weapon Skills";
            // 
            // amname
            // 
            this.amname.AutoCompleteCustomSource.AddRange(new string[] {
            "Cloudsplitter",
            "Ukko\'s Fury",
            "Dagan",
            "Rudra\'s Storm",
            "Victory Smite",
            "Blade: Hi",
            "Tachi: Fudo",
            "Camlann\'s Torment",
            "Quietus",
            "Myrkr",
            "Chant du Cygne",
            "Torcleaver",
            "Jishnu\'s Radiance",
            "Wildfire",
            "Final Heaven",
            "Mercy Stroke",
            "Knights of Round",
            "Scourge",
            "Onslaught",
            "Metatron Torment",
            "Catastrophe",
            "Geirskogul",
            "Blade: Metsu",
            "Tachi: Kaiten",
            "Randgrith",
            "Gate of Tartarus",
            "Coronach",
            "Namas Arrow",
            "King\'s Justice",
            "Ascetic\'s Fury",
            "Mystic Boon",
            "Vidohunir",
            "Death Blossom",
            "Mandalic Stab",
            "Atonement",
            "Insurgency",
            "Primal Rend",
            "Mordant Rime",
            "Trueflight",
            "Tachi: Rana",
            "Blade: Kamu",
            "Drakesbane",
            "Garland of Bliss",
            "Expiacion",
            "Leaden Salute",
            "Stringing Pummel",
            "Pyrrhic Kleos",
            "Omniscience"});
            this.amname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.amname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.amname.FormattingEnabled = true;
            this.amname.Location = new System.Drawing.Point(188, 38);
            this.amname.Name = "amname";
            this.amname.Size = new System.Drawing.Size(112, 21);
            this.amname.Sorted = true;
            this.amname.TabIndex = 109;
            // 
            // AfterMathTier
            // 
            this.AfterMathTier.Location = new System.Drawing.Point(124, 37);
            this.AfterMathTier.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.AfterMathTier.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AfterMathTier.Name = "AfterMathTier";
            this.AfterMathTier.Size = new System.Drawing.Size(44, 20);
            this.AfterMathTier.TabIndex = 108;
            this.AfterMathTier.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AfterMathTier.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // wsam
            // 
            this.wsam.AutoSize = true;
            this.wsam.Location = new System.Drawing.Point(17, 40);
            this.wsam.Name = "wsam";
            this.wsam.Size = new System.Drawing.Size(97, 17);
            this.wsam.TabIndex = 105;
            this.wsam.Text = "Use TP w/ AM";
            this.wsam.UseVisualStyleBackColor = true;
            // 
            // WSDistance
            // 
            this.WSDistance.AutoSize = true;
            this.WSDistance.Location = new System.Drawing.Point(17, 62);
            this.WSDistance.Name = "WSDistance";
            this.WSDistance.Size = new System.Drawing.Size(89, 17);
            this.WSDistance.TabIndex = 104;
            this.WSDistance.Text = "WS Distance";
            this.WSDistance.UseVisualStyleBackColor = true;
            // 
            // selectedWS
            // 
            this.selectedWS.AutoCompleteCustomSource.AddRange(new string[] {
            "Combo",
            "Shoulder Tackle",
            "One Inch Punch",
            "Backhand Blow",
            "Raging Fists",
            "Spinning Attack",
            "Howling Fist",
            "Dragon Kick",
            "Asuran Fists",
            "Final Heaven",
            "Ascetic\'s Fury",
            "Stringing Pummel",
            "Tornado Kick",
            "Victory Smite",
            "Shijin Spiral",
            "Wasp Sting",
            "Gust Slash",
            "Shadow Stitch",
            "Viper Bite",
            "Cyclone",
            "Energy Steal",
            "Energy Drain",
            "Dancing Edge",
            "Shark Bite",
            "Evisceration",
            "Mercy Stroke",
            "Mandalic Stab",
            "Mordant Rime",
            "Pyrrhic Kleos",
            "Aeolian Edge",
            "Rudra\'s Storm",
            "Exenterator",
            "Fast Blade",
            "Burning Blade",
            "Red Lotus Blade",
            "Flat Blade",
            "Shining Blade",
            "Seraph Blade",
            "Circle Blade",
            "Spirits Within",
            "Vorpal Blade",
            "Swift Blade",
            "Savage Blade",
            "Knights of Round",
            "Death Blossom",
            "Atonement",
            "Expiacion",
            "Sanguine Blade",
            "Chant du Cygne",
            "Requiescat",
            "Hard Slash",
            "Power Slash",
            "Frostbite",
            "Freezebite",
            "Shockwave",
            "Crescent Moon",
            "Sickle Moon",
            "Spinning Slash",
            "Ground Strike",
            "Scourge",
            "Herculean Slash",
            "Torcleaver",
            "Resolution",
            "Raging Axe",
            "Smash Axe",
            "Gale Axe",
            "Avalanche Axe",
            "Spinning Axe",
            "Rampage",
            "Calamity",
            "Mistral Axe",
            "Decimation",
            "Onslaught",
            "Primal Rend",
            "Bora Axe",
            "Cloudsplitter",
            "Ruinator",
            "Shield Break",
            "Iron Tempest",
            "Sturmwind",
            "Armor Break",
            "Keen Edge",
            "Weapon Break",
            "Raging Rush",
            "Full Break",
            "Steel Cyclone",
            "Metatron Torment",
            "King\'s Justice",
            "Fell Cleave",
            "Ukko\'s Fury",
            "Upheaval",
            "Slice",
            "Dark Harvest",
            "Shadow of Death",
            "Nightmare Scythe",
            "Spinning Scythe",
            "Vorpal Scythe",
            "Guillotine",
            "Cross Reaper",
            "Spiral Hell",
            "Catastrophe",
            "Insurgency",
            "Infernal Scythe",
            "Quietus",
            "Entropy",
            "Double Thrust",
            "Thunder Thrust",
            "Raiden Thrust",
            "Leg Sweep",
            "Penta Thrust",
            "Vorpal Thrust",
            "Skewer",
            "Wheeling Thrust",
            "Impulse Drive",
            "Geirskogul",
            "Drakesbane",
            "Sonic Thrust",
            "Camlann\'s Torment",
            "Stardiver",
            "Blade: Rin",
            "Blade: Retsu",
            "Blade: Teki",
            "Blade: To",
            "Blade: Chi",
            "Blade: Ei",
            "Blade: Jin",
            "Blade: Ten",
            "Blade: Ku",
            "Blade: Metsu",
            "Blade: Kamu",
            "Blade: Yu",
            "Blade: Hi",
            "Blade: Shun",
            "Tachi: Enpi",
            "Tachi: Hobaku",
            "Tachi: Goten",
            "Tachi: Kagero",
            "Tachi: Jinpu",
            "Tachi: Koki",
            "Tachi: Yukikaze",
            "Tachi: Gekko",
            "Tachi: Kasha",
            "Tachi: Kaiten",
            "Tachi: Rana",
            "Tachi: Ageha",
            "Tachi: Fudo",
            "Tachi: Shoha",
            "Shining Strike",
            "Seraph Strike",
            "Brainshaker",
            "Starlight",
            "Moonlight",
            "Skullbreaker",
            "True Strike",
            "Judgment",
            "Hexa Strike",
            "Black Halo",
            "Randgrith",
            "Mystic Boon",
            "Flash Nova",
            "Dagan",
            "Realmrazer",
            "Heavy Swing",
            "Rock Crusher",
            "Earth Crusher",
            "Starburst",
            "Sunburst",
            "Shell Crusher",
            "Full Swing",
            "Spirit Taker",
            "Retribution",
            "Gates of Tartarus",
            "Vidohunir",
            "Garland of Bliss",
            "Omniscience",
            "Cataclysm",
            "Myrkr",
            "Shattersoul",
            "Flaming Arrow",
            "Piercing Arrow",
            "Dulling Arrow",
            "Sidewinder",
            "Blast Arrow",
            "Arching Arrow",
            "Empyreal Arrow",
            "Namas Arrow",
            "Refulgent Arrow",
            "Jishnu\'s Radiance",
            "Apex Arrow",
            "Hot Shot",
            "Split Shot",
            "Sniper Shot",
            "Slug Shot",
            "Blast Shot",
            "Heavy Shot",
            "Detonator",
            "Coronach",
            "Trueflight",
            "Leaden Salute",
            "Numbing Shot",
            "Wildfire",
            "Last Stand",
            "Slapstick",
            "Arcuballista",
            "String Clipper",
            "Chimera Ripper",
            "Knockout",
            "Magic Mortar",
            "Daze",
            "Armor Piercer",
            "Cannibal Blade",
            "Bone Crusher",
            "Dimidiation"});
            this.selectedWS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.selectedWS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.selectedWS.FormattingEnabled = true;
            this.selectedWS.Location = new System.Drawing.Point(188, 15);
            this.selectedWS.Name = "selectedWS";
            this.selectedWS.Size = new System.Drawing.Size(112, 21);
            this.selectedWS.Sorted = true;
            this.selectedWS.TabIndex = 102;
            // 
            // WSDistanceset
            // 
            this.WSDistanceset.DecimalPlaces = 1;
            this.WSDistanceset.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.WSDistanceset.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.WSDistanceset.Location = new System.Drawing.Point(124, 59);
            this.WSDistanceset.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.WSDistanceset.Name = "WSDistanceset";
            this.WSDistanceset.Size = new System.Drawing.Size(44, 20);
            this.WSDistanceset.TabIndex = 103;
            this.WSDistanceset.TabStop = false;
            this.WSDistanceset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WSDistanceset.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ws
            // 
            this.ws.AutoSize = true;
            this.ws.Location = new System.Drawing.Point(17, 18);
            this.ws.Name = "ws";
            this.ws.Size = new System.Drawing.Size(62, 17);
            this.ws.TabIndex = 94;
            this.ws.Text = "Use TP";
            this.ws.UseVisualStyleBackColor = true;
            // 
            // WStp
            // 
            this.WStp.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.WStp.Location = new System.Drawing.Point(124, 15);
            this.WStp.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.WStp.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.WStp.Name = "WStp";
            this.WStp.Size = new System.Drawing.Size(44, 20);
            this.WStp.TabIndex = 95;
            this.WStp.TabStop = false;
            this.WStp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WStp.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(174, 85);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(27, 13);
            this.label29.TabIndex = 99;
            this.label29.Text = "MIN";
            // 
            // TragetHPPtop
            // 
            this.TragetHPPtop.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.TragetHPPtop.Location = new System.Drawing.Point(206, 81);
            this.TragetHPPtop.Name = "TragetHPPtop";
            this.TragetHPPtop.Size = new System.Drawing.Size(44, 20);
            this.TragetHPPtop.TabIndex = 98;
            this.TragetHPPtop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TragetHPPtop.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(256, 85);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(30, 13);
            this.label28.TabIndex = 100;
            this.label28.Text = "MAX";
            // 
            // TragetHPPbottom
            // 
            this.TragetHPPbottom.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.TragetHPPbottom.Location = new System.Drawing.Point(124, 81);
            this.TragetHPPbottom.Name = "TragetHPPbottom";
            this.TragetHPPbottom.Size = new System.Drawing.Size(44, 20);
            this.TragetHPPbottom.TabIndex = 97;
            this.TragetHPPbottom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TragetHPPbottom.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(14, 85);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(87, 13);
            this.label27.TabIndex = 96;
            this.label27.Text = "Mob HP% to WS";
            // 
            // Options2MainTab
            // 
            this.Options2MainTab.Controls.Add(this.numericUpDown38);
            this.Options2MainTab.Controls.Add(this.aggroRange);
            this.Options2MainTab.Controls.Add(this.ScanDelay);
            this.Options2MainTab.Controls.Add(this.KeepTargetRange);
            this.Options2MainTab.Controls.Add(this.assistDist);
            this.Options2MainTab.Controls.Add(this.followDist);
            this.Options2MainTab.Controls.Add(this.partyAssist);
            this.Options2MainTab.Controls.Add(this.facetarget);
            this.Options2MainTab.Controls.Add(this.label12);
            this.Options2MainTab.Controls.Add(this.assist);
            this.Options2MainTab.Controls.Add(this.followplayer);
            this.Options2MainTab.Controls.Add(this.followName);
            this.Options2MainTab.Controls.Add(this.useshadows);
            this.Options2MainTab.Controls.Add(this.label11);
            this.Options2MainTab.Controls.Add(this.assistplayer);
            this.Options2MainTab.Controls.Add(this.aggro);
            this.Options2MainTab.Controls.Add(this.mobdist);
            this.Options2MainTab.Location = new System.Drawing.Point(4, 22);
            this.Options2MainTab.Name = "Options2MainTab";
            this.Options2MainTab.Padding = new System.Windows.Forms.Padding(3);
            this.Options2MainTab.Size = new System.Drawing.Size(419, 197);
            this.Options2MainTab.TabIndex = 1;
            this.Options2MainTab.Text = "Options 2";
            this.Options2MainTab.UseVisualStyleBackColor = true;
            // 
            // numericUpDown38
            // 
            this.numericUpDown38.DecimalPlaces = 1;
            this.numericUpDown38.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown38.Location = new System.Drawing.Point(281, 155);
            this.numericUpDown38.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown38.Name = "numericUpDown38";
            this.numericUpDown38.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown38.TabIndex = 92;
            this.numericUpDown38.TabStop = false;
            this.numericUpDown38.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown38.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // aggroRange
            // 
            this.aggroRange.DecimalPlaces = 1;
            this.aggroRange.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.aggroRange.Location = new System.Drawing.Point(281, 109);
            this.aggroRange.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.aggroRange.Name = "aggroRange";
            this.aggroRange.Size = new System.Drawing.Size(44, 20);
            this.aggroRange.TabIndex = 107;
            this.aggroRange.TabStop = false;
            this.aggroRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.aggroRange.Value = new decimal(new int[] {
            85,
            0,
            0,
            65536});
            // 
            // ScanDelay
            // 
            this.ScanDelay.AutoSize = true;
            this.ScanDelay.Location = new System.Drawing.Point(88, 157);
            this.ScanDelay.Name = "ScanDelay";
            this.ScanDelay.Size = new System.Drawing.Size(125, 17);
            this.ScanDelay.TabIndex = 90;
            this.ScanDelay.Text = "Delay between mobs";
            this.ScanDelay.UseVisualStyleBackColor = true;
            // 
            // KeepTargetRange
            // 
            this.KeepTargetRange.DecimalPlaces = 1;
            this.KeepTargetRange.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.KeepTargetRange.Location = new System.Drawing.Point(281, 132);
            this.KeepTargetRange.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.KeepTargetRange.Name = "KeepTargetRange";
            this.KeepTargetRange.Size = new System.Drawing.Size(44, 20);
            this.KeepTargetRange.TabIndex = 106;
            this.KeepTargetRange.TabStop = false;
            this.KeepTargetRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.KeepTargetRange.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // assistDist
            // 
            this.assistDist.DecimalPlaces = 1;
            this.assistDist.Enabled = false;
            this.assistDist.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.assistDist.Location = new System.Drawing.Point(281, 42);
            this.assistDist.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.assistDist.Name = "assistDist";
            this.assistDist.Size = new System.Drawing.Size(44, 20);
            this.assistDist.TabIndex = 105;
            this.assistDist.TabStop = false;
            this.assistDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.assistDist.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // followDist
            // 
            this.followDist.DecimalPlaces = 1;
            this.followDist.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.followDist.Location = new System.Drawing.Point(281, 16);
            this.followDist.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.followDist.Name = "followDist";
            this.followDist.Size = new System.Drawing.Size(44, 20);
            this.followDist.TabIndex = 104;
            this.followDist.TabStop = false;
            this.followDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.followDist.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // partyAssist
            // 
            this.partyAssist.AutoSize = true;
            this.partyAssist.Location = new System.Drawing.Point(88, 66);
            this.partyAssist.Name = "partyAssist";
            this.partyAssist.Size = new System.Drawing.Size(243, 17);
            this.partyAssist.TabIndex = 103;
            this.partyAssist.Text = "Assist All Party Members (uses assist distance)";
            this.partyAssist.UseVisualStyleBackColor = true;
            this.partyAssist.CheckedChanged += new System.EventHandler(this.partyAssist_CheckedChanged);
            // 
            // facetarget
            // 
            this.facetarget.AutoSize = true;
            this.facetarget.Location = new System.Drawing.Point(195, 88);
            this.facetarget.Name = "facetarget";
            this.facetarget.Size = new System.Drawing.Size(120, 17);
            this.facetarget.TabIndex = 96;
            this.facetarget.Text = "Keep Facing Target";
            this.facetarget.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(250, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 13);
            this.label12.TabIndex = 101;
            this.label12.Text = "Dist";
            // 
            // assist
            // 
            this.assist.AutoSize = true;
            this.assist.Location = new System.Drawing.Point(88, 44);
            this.assist.Name = "assist";
            this.assist.Size = new System.Drawing.Size(53, 17);
            this.assist.TabIndex = 100;
            this.assist.Text = "Assist";
            this.assist.UseVisualStyleBackColor = true;
            this.assist.CheckedChanged += new System.EventHandler(this.AssistCheckedChanged);
            // 
            // followplayer
            // 
            this.followplayer.AutoSize = true;
            this.followplayer.Location = new System.Drawing.Point(88, 18);
            this.followplayer.Name = "followplayer";
            this.followplayer.Size = new System.Drawing.Size(56, 17);
            this.followplayer.TabIndex = 95;
            this.followplayer.Text = "Follow";
            this.followplayer.UseVisualStyleBackColor = true;
            // 
            // followName
            // 
            this.followName.Location = new System.Drawing.Point(144, 16);
            this.followName.Name = "followName";
            this.followName.Size = new System.Drawing.Size(100, 20);
            this.followName.TabIndex = 97;
            // 
            // useshadows
            // 
            this.useshadows.AutoSize = true;
            this.useshadows.Location = new System.Drawing.Point(88, 88);
            this.useshadows.Name = "useshadows";
            this.useshadows.Size = new System.Drawing.Size(92, 17);
            this.useshadows.TabIndex = 94;
            this.useshadows.Text = "Use Shadows";
            this.useshadows.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(250, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 13);
            this.label11.TabIndex = 98;
            this.label11.Text = "Dist";
            // 
            // assistplayer
            // 
            this.assistplayer.Location = new System.Drawing.Point(144, 42);
            this.assistplayer.Name = "assistplayer";
            this.assistplayer.Size = new System.Drawing.Size(100, 20);
            this.assistplayer.TabIndex = 99;
            // 
            // aggro
            // 
            this.aggro.AutoSize = true;
            this.aggro.Location = new System.Drawing.Point(88, 111);
            this.aggro.Name = "aggro";
            this.aggro.Size = new System.Drawing.Size(171, 17);
            this.aggro.TabIndex = 91;
            this.aggro.Text = "Aggro Detection + Auto Attack";
            this.aggro.UseVisualStyleBackColor = true;
            // 
            // mobdist
            // 
            this.mobdist.AutoSize = true;
            this.mobdist.Location = new System.Drawing.Point(88, 134);
            this.mobdist.Name = "mobdist";
            this.mobdist.Size = new System.Drawing.Size(151, 17);
            this.mobdist.TabIndex = 93;
            this.mobdist.Text = "Keep Within Melee Range";
            this.mobdist.UseVisualStyleBackColor = true;
            // 
            // Options3MainTab
            // 
            this.Options3MainTab.Controls.Add(this.IdleLocationDist);
            this.Options3MainTab.Controls.Add(this.fullheal);
            this.Options3MainTab.Controls.Add(this.verifyfood);
            this.Options3MainTab.Controls.Add(this.comboBox4);
            this.Options3MainTab.Controls.Add(this.SignetStaff);
            this.Options3MainTab.Controls.Add(this.label7);
            this.Options3MainTab.Controls.Add(this.label3);
            this.Options3MainTab.Controls.Add(this.useStaff);
            this.Options3MainTab.Controls.Add(this.foodName);
            this.Options3MainTab.Controls.Add(this.healMPcount);
            this.Options3MainTab.Controls.Add(this.usefood);
            this.Options3MainTab.Controls.Add(this.HealMP);
            this.Options3MainTab.Controls.Add(this.healHPcount);
            this.Options3MainTab.Controls.Add(this.RecordIdleLocation);
            this.Options3MainTab.Controls.Add(this.WeakLocation);
            this.Options3MainTab.Controls.Add(this.HealHP);
            this.Options3MainTab.Controls.Add(this.textBox6);
            this.Options3MainTab.Controls.Add(this.IdleLocation);
            this.Options3MainTab.Controls.Add(this.label35);
            this.Options3MainTab.Location = new System.Drawing.Point(4, 22);
            this.Options3MainTab.Name = "Options3MainTab";
            this.Options3MainTab.Padding = new System.Windows.Forms.Padding(3);
            this.Options3MainTab.Size = new System.Drawing.Size(419, 197);
            this.Options3MainTab.TabIndex = 0;
            this.Options3MainTab.Text = "Options 3";
            this.Options3MainTab.UseVisualStyleBackColor = true;
            // 
            // fullheal
            // 
            this.fullheal.AutoSize = true;
            this.fullheal.Checked = true;
            this.fullheal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fullheal.Location = new System.Drawing.Point(240, 69);
            this.fullheal.Name = "fullheal";
            this.fullheal.Size = new System.Drawing.Size(103, 17);
            this.fullheal.TabIndex = 70;
            this.fullheal.TabStop = false;
            this.fullheal.Text = "Full Heal (Mode)";
            this.fullheal.UseVisualStyleBackColor = true;
            // 
            // verifyfood
            // 
            this.verifyfood.Location = new System.Drawing.Point(332, 33);
            this.verifyfood.Name = "verifyfood";
            this.verifyfood.Size = new System.Drawing.Size(20, 20);
            this.verifyfood.TabIndex = 69;
            this.verifyfood.Text = "V";
            this.verifyfood.UseVisualStyleBackColor = true;
            this.verifyfood.Click += new System.EventHandler(this.verifyfood_Click);
            // 
            // comboBox4
            // 
            this.comboBox4.Enabled = false;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "Federation Signet Staff",
            "Kingdom Signet Staff",
            "Republic Signet Staff"});
            this.comboBox4.Location = new System.Drawing.Point(214, 137);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(152, 21);
            this.comboBox4.TabIndex = 18;
            // 
            // SignetStaff
            // 
            this.SignetStaff.Enabled = false;
            this.SignetStaff.FormattingEnabled = true;
            this.SignetStaff.Items.AddRange(new object[] {
            "Federation Signet Staff",
            "Kingdom Signet Staff",
            "Republic Signet Staff"});
            this.SignetStaff.Location = new System.Drawing.Point(214, 160);
            this.SignetStaff.Name = "SignetStaff";
            this.SignetStaff.Size = new System.Drawing.Size(152, 21);
            this.SignetStaff.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(221, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 68;
            this.label7.Text = "%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 67;
            this.label3.Text = "%";
            // 
            // useStaff
            // 
            this.useStaff.AutoSize = true;
            this.useStaff.Enabled = false;
            this.useStaff.Location = new System.Drawing.Point(53, 163);
            this.useStaff.Name = "useStaff";
            this.useStaff.Size = new System.Drawing.Size(103, 17);
            this.useStaff.TabIndex = 16;
            this.useStaff.Text = "Use Signet Staff";
            this.useStaff.UseVisualStyleBackColor = true;
            // 
            // foodName
            // 
            this.foodName.Location = new System.Drawing.Point(175, 33);
            this.foodName.Name = "foodName";
            this.foodName.Size = new System.Drawing.Size(156, 20);
            this.foodName.TabIndex = 66;
            this.foodName.TabStop = false;
            // 
            // healMPcount
            // 
            this.healMPcount.Location = new System.Drawing.Point(175, 77);
            this.healMPcount.Name = "healMPcount";
            this.healMPcount.Size = new System.Drawing.Size(44, 20);
            this.healMPcount.TabIndex = 64;
            this.healMPcount.TabStop = false;
            this.healMPcount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.healMPcount.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // usefood
            // 
            this.usefood.AutoSize = true;
            this.usefood.Location = new System.Drawing.Point(68, 35);
            this.usefood.Name = "usefood";
            this.usefood.Size = new System.Drawing.Size(72, 17);
            this.usefood.TabIndex = 65;
            this.usefood.TabStop = false;
            this.usefood.Text = "Use Food";
            this.usefood.UseVisualStyleBackColor = true;
            // 
            // HealMP
            // 
            this.HealMP.AutoSize = true;
            this.HealMP.Location = new System.Drawing.Point(68, 80);
            this.HealMP.Name = "HealMP";
            this.HealMP.Size = new System.Drawing.Size(67, 17);
            this.HealMP.TabIndex = 63;
            this.HealMP.TabStop = false;
            this.HealMP.Text = "Heal MP";
            this.HealMP.UseVisualStyleBackColor = true;
            // 
            // healHPcount
            // 
            this.healHPcount.Location = new System.Drawing.Point(175, 55);
            this.healHPcount.Name = "healHPcount";
            this.healHPcount.Size = new System.Drawing.Size(44, 20);
            this.healHPcount.TabIndex = 62;
            this.healHPcount.TabStop = false;
            this.healHPcount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.healHPcount.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // RecordIdleLocation
            // 
            this.RecordIdleLocation.Location = new System.Drawing.Point(226, 115);
            this.RecordIdleLocation.Name = "RecordIdleLocation";
            this.RecordIdleLocation.Size = new System.Drawing.Size(152, 21);
            this.RecordIdleLocation.TabIndex = 14;
            this.RecordIdleLocation.Text = "Record Location";
            this.RecordIdleLocation.UseVisualStyleBackColor = true;
            this.RecordIdleLocation.Click += new System.EventHandler(this.RecordIdleLocation_Click);
            // 
            // WeakLocation
            // 
            this.WeakLocation.AutoSize = true;
            this.WeakLocation.Enabled = false;
            this.WeakLocation.Location = new System.Drawing.Point(53, 140);
            this.WeakLocation.Name = "WeakLocation";
            this.WeakLocation.Size = new System.Drawing.Size(119, 17);
            this.WeakLocation.TabIndex = 11;
            this.WeakLocation.Text = "Weakened location";
            this.WeakLocation.UseVisualStyleBackColor = true;
            // 
            // HealHP
            // 
            this.HealHP.AutoSize = true;
            this.HealHP.Location = new System.Drawing.Point(68, 58);
            this.HealHP.Name = "HealHP";
            this.HealHP.Size = new System.Drawing.Size(66, 17);
            this.HealHP.TabIndex = 61;
            this.HealHP.TabStop = false;
            this.HealHP.Text = "Heal HP";
            this.HealHP.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(175, 10);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(176, 20);
            this.textBox6.TabIndex = 60;
            this.textBox6.TabStop = false;
            // 
            // IdleLocation
            // 
            this.IdleLocation.AutoSize = true;
            this.IdleLocation.Location = new System.Drawing.Point(40, 118);
            this.IdleLocation.Name = "IdleLocation";
            this.IdleLocation.Size = new System.Drawing.Size(140, 17);
            this.IdleLocation.TabIndex = 12;
            this.IdleLocation.Text = "Idle return location  Dist:";
            this.IdleLocation.UseVisualStyleBackColor = true;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(65, 12);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(99, 13);
            this.label35.TabIndex = 59;
            this.label35.Text = "On Heal Equip Item";
            // 
            // Options4MainTab
            // 
            this.Options4MainTab.Controls.Add(this.NotinBattle);
            this.Options4MainTab.Controls.Add(this.groupBox15);
            this.Options4MainTab.Location = new System.Drawing.Point(4, 22);
            this.Options4MainTab.Name = "Options4MainTab";
            this.Options4MainTab.Padding = new System.Windows.Forms.Padding(3);
            this.Options4MainTab.Size = new System.Drawing.Size(419, 197);
            this.Options4MainTab.TabIndex = 5;
            this.Options4MainTab.Text = "Options 4";
            this.Options4MainTab.UseVisualStyleBackColor = true;
            // 
            // NotinBattle
            // 
            this.NotinBattle.Controls.Add(this.UseJigs);
            this.NotinBattle.Controls.Add(this.ChocoboJigII);
            this.NotinBattle.Controls.Add(this.ChocoboJig);
            this.NotinBattle.Controls.Add(this.SpectralJig);
            this.NotinBattle.Location = new System.Drawing.Point(53, 118);
            this.NotinBattle.Name = "NotinBattle";
            this.NotinBattle.Size = new System.Drawing.Size(313, 59);
            this.NotinBattle.TabIndex = 16;
            this.NotinBattle.TabStop = false;
            this.NotinBattle.Text = "When not in battle";
            // 
            // UseJigs
            // 
            this.UseJigs.AutoSize = true;
            this.UseJigs.Location = new System.Drawing.Point(22, 19);
            this.UseJigs.Name = "UseJigs";
            this.UseJigs.Size = new System.Drawing.Size(66, 17);
            this.UseJigs.TabIndex = 3;
            this.UseJigs.Text = "Use Jigs";
            this.UseJigs.UseVisualStyleBackColor = true;
            // 
            // ChocoboJigII
            // 
            this.ChocoboJigII.AutoSize = true;
            this.ChocoboJigII.Enabled = false;
            this.ChocoboJigII.Location = new System.Drawing.Point(198, 34);
            this.ChocoboJigII.Name = "ChocoboJigII";
            this.ChocoboJigII.Size = new System.Drawing.Size(93, 17);
            this.ChocoboJigII.TabIndex = 2;
            this.ChocoboJigII.TabStop = true;
            this.ChocoboJigII.Text = "Chocobo Jig II";
            this.ChocoboJigII.UseVisualStyleBackColor = true;
            // 
            // ChocoboJig
            // 
            this.ChocoboJig.AutoSize = true;
            this.ChocoboJig.Enabled = false;
            this.ChocoboJig.Location = new System.Drawing.Point(108, 34);
            this.ChocoboJig.Name = "ChocoboJig";
            this.ChocoboJig.Size = new System.Drawing.Size(84, 17);
            this.ChocoboJig.TabIndex = 1;
            this.ChocoboJig.TabStop = true;
            this.ChocoboJig.Text = "Chocobo Jig";
            this.ChocoboJig.UseVisualStyleBackColor = true;
            // 
            // SpectralJig
            // 
            this.SpectralJig.AutoSize = true;
            this.SpectralJig.Enabled = false;
            this.SpectralJig.Location = new System.Drawing.Point(22, 34);
            this.SpectralJig.Name = "SpectralJig";
            this.SpectralJig.Size = new System.Drawing.Size(80, 17);
            this.SpectralJig.TabIndex = 0;
            this.SpectralJig.TabStop = true;
            this.SpectralJig.Text = "Spectral Jig";
            this.SpectralJig.UseVisualStyleBackColor = true;
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.label42);
            this.groupBox15.Controls.Add(this.autoRangeDelay);
            this.groupBox15.Controls.Add(this.textBox7);
            this.groupBox15.Controls.Add(this.rangeaggro);
            this.groupBox15.Controls.Add(this.comboBox1);
            this.groupBox15.Controls.Add(this.checkBox4);
            this.groupBox15.Controls.Add(this.autoRangeAttack);
            this.groupBox15.Location = new System.Drawing.Point(53, 14);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(313, 90);
            this.groupBox15.TabIndex = 15;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "ammo / ranged options";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(144, 65);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(37, 13);
            this.label42.TabIndex = 57;
            this.label42.Text = "Delay:";
            // 
            // autoRangeDelay
            // 
            this.autoRangeDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.autoRangeDelay.DecimalPlaces = 1;
            this.autoRangeDelay.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.autoRangeDelay.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.autoRangeDelay.Location = new System.Drawing.Point(182, 62);
            this.autoRangeDelay.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.autoRangeDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.autoRangeDelay.Name = "autoRangeDelay";
            this.autoRangeDelay.Size = new System.Drawing.Size(44, 20);
            this.autoRangeDelay.TabIndex = 56;
            this.autoRangeDelay.TabStop = false;
            this.autoRangeDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.autoRangeDelay.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(23, 62);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(120, 20);
            this.textBox7.TabIndex = 48;
            this.textBox7.Text = "/ra <t>";
            // 
            // rangeaggro
            // 
            this.rangeaggro.AutoSize = true;
            this.rangeaggro.Location = new System.Drawing.Point(161, 42);
            this.rangeaggro.Name = "rangeaggro";
            this.rangeaggro.Size = new System.Drawing.Size(118, 17);
            this.rangeaggro.TabIndex = 47;
            this.rangeaggro.Text = "Range Aggro-Mobs";
            this.rangeaggro.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(137, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(153, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Enabled = false;
            this.checkBox4.Location = new System.Drawing.Point(23, 20);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(108, 17);
            this.checkBox4.TabIndex = 2;
            this.checkBox4.Text = "Auto equip ammo";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // autoRangeAttack
            // 
            this.autoRangeAttack.AutoSize = true;
            this.autoRangeAttack.Location = new System.Drawing.Point(23, 42);
            this.autoRangeAttack.Name = "autoRangeAttack";
            this.autoRangeAttack.Size = new System.Drawing.Size(123, 17);
            this.autoRangeAttack.TabIndex = 46;
            this.autoRangeAttack.Text = "Auto (Range Attack)";
            this.autoRangeAttack.UseVisualStyleBackColor = true;
            // 
            // selectapp
            // 
            this.selectapp.Controls.Add(this.shutdowngroup);
            this.selectapp.Controls.Add(this.ManualTargMode);
            this.selectapp.Controls.Add(this.EnableDynamis);
            this.selectapp.Controls.Add(this.groupBox16);
            this.selectapp.Location = new System.Drawing.Point(4, 22);
            this.selectapp.Name = "selectapp";
            this.selectapp.Padding = new System.Windows.Forms.Padding(3);
            this.selectapp.Size = new System.Drawing.Size(419, 197);
            this.selectapp.TabIndex = 8;
            this.selectapp.Text = "Options 5";
            this.selectapp.UseVisualStyleBackColor = true;
            // 
            // shutdowngroup
            // 
            this.shutdowngroup.Controls.Add(this.label82);
            this.shutdowngroup.Controls.Add(this.shutdowndate);
            this.shutdowngroup.Controls.Add(this.selectedapp);
            this.shutdowngroup.Controls.Add(this.groupBox25);
            this.shutdowngroup.Controls.Add(this.Shutdownenable);
            this.shutdowngroup.Location = new System.Drawing.Point(42, 111);
            this.shutdowngroup.Name = "shutdowngroup";
            this.shutdowngroup.Size = new System.Drawing.Size(334, 80);
            this.shutdowngroup.TabIndex = 3;
            this.shutdowngroup.TabStop = false;
            this.shutdowngroup.Text = "Shutdown @";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(27, 16);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(281, 13);
            this.label82.TabIndex = 7;
            this.label82.Text = "This will automaticaly kill FFXI and Scripted at the set time.";
            // 
            // shutdowndate
            // 
            this.shutdowndate.CustomFormat = "M/d/yyyy hh:mm:ss tt";
            this.shutdowndate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.shutdowndate.Location = new System.Drawing.Point(172, 56);
            this.shutdowndate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.shutdowndate.MinDate = new System.DateTime(2016, 6, 1, 0, 0, 0, 0);
            this.shutdowndate.Name = "shutdowndate";
            this.shutdowndate.ShowUpDown = true;
            this.shutdowndate.Size = new System.Drawing.Size(153, 20);
            this.shutdowndate.TabIndex = 11;
            this.shutdowndate.Value = new System.DateTime(2016, 6, 1, 16, 18, 1, 0);
            // 
            // selectedapp
            // 
            this.selectedapp.AutoCompleteCustomSource.AddRange(new string[] {
            "Scripted Only",
            "Windower + Scripted",
            "Ashita + Scripted"});
            this.selectedapp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.selectedapp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.selectedapp.FormattingEnabled = true;
            this.selectedapp.Items.AddRange(new object[] {
            "Scripted Only",
            "Windowing App + Scripted"});
            this.selectedapp.Location = new System.Drawing.Point(7, 56);
            this.selectedapp.Name = "selectedapp";
            this.selectedapp.Size = new System.Drawing.Size(118, 21);
            this.selectedapp.TabIndex = 10;
            this.selectedapp.Text = "Scripted Only";
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.twentyfourHour);
            this.groupBox25.Controls.Add(this.twelveHour);
            this.groupBox25.Location = new System.Drawing.Point(197, 26);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(128, 25);
            this.groupBox25.TabIndex = 9;
            this.groupBox25.TabStop = false;
            // 
            // twentyfourHour
            // 
            this.twentyfourHour.AutoSize = true;
            this.twentyfourHour.Location = new System.Drawing.Point(6, 7);
            this.twentyfourHour.Name = "twentyfourHour";
            this.twentyfourHour.Size = new System.Drawing.Size(56, 17);
            this.twentyfourHour.TabIndex = 5;
            this.twentyfourHour.Text = "24 HR";
            this.twentyfourHour.UseVisualStyleBackColor = true;
            // 
            // twelveHour
            // 
            this.twelveHour.AutoSize = true;
            this.twelveHour.Checked = true;
            this.twelveHour.Location = new System.Drawing.Point(68, 7);
            this.twelveHour.Name = "twelveHour";
            this.twelveHour.Size = new System.Drawing.Size(56, 17);
            this.twelveHour.TabIndex = 6;
            this.twelveHour.TabStop = true;
            this.twelveHour.Text = "12 HR";
            this.twelveHour.UseVisualStyleBackColor = true;
            this.twelveHour.CheckedChanged += new System.EventHandler(this.twelveHour_CheckedChanged);
            // 
            // Shutdownenable
            // 
            this.Shutdownenable.AutoSize = true;
            this.Shutdownenable.Location = new System.Drawing.Point(7, 34);
            this.Shutdownenable.Name = "Shutdownenable";
            this.Shutdownenable.Size = new System.Drawing.Size(175, 17);
            this.Shutdownenable.TabIndex = 4;
            this.Shutdownenable.Text = "Enable (After you set your time.)";
            this.Shutdownenable.UseVisualStyleBackColor = true;
            // 
            // ManualTargMode
            // 
            this.ManualTargMode.AutoSize = true;
            this.ManualTargMode.Location = new System.Drawing.Point(224, 59);
            this.ManualTargMode.Name = "ManualTargMode";
            this.ManualTargMode.Size = new System.Drawing.Size(139, 17);
            this.ManualTargMode.TabIndex = 2;
            this.ManualTargMode.Text = "Manual Targeting Mode";
            this.ManualTargMode.UseVisualStyleBackColor = true;
            this.ManualTargMode.CheckedChanged += new System.EventHandler(this.ManualTargMode_CheckedChanged);
            // 
            // EnableDynamis
            // 
            this.EnableDynamis.AutoSize = true;
            this.EnableDynamis.Location = new System.Drawing.Point(224, 29);
            this.EnableDynamis.Name = "EnableDynamis";
            this.EnableDynamis.Size = new System.Drawing.Size(143, 17);
            this.EnableDynamis.TabIndex = 1;
            this.EnableDynamis.Text = "Enable Dynamis Controls";
            this.EnableDynamis.UseVisualStyleBackColor = true;
            this.EnableDynamis.CheckedChanged += new System.EventHandler(this.EnableDynamis_CheckedChanged);
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.label65);
            this.groupBox16.Controls.Add(this.StuckDistance);
            this.groupBox16.Controls.Add(this.navStuckWatch);
            this.groupBox16.Controls.Add(this.mobStuckWatch);
            this.groupBox16.Location = new System.Drawing.Point(31, 14);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(176, 82);
            this.groupBox16.TabIndex = 0;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Stuck Watch";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(76, 49);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(49, 13);
            this.label65.TabIndex = 37;
            this.label65.Text = "Distance";
            // 
            // StuckDistance
            // 
            this.StuckDistance.Location = new System.Drawing.Point(131, 47);
            this.StuckDistance.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.StuckDistance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.StuckDistance.Name = "StuckDistance";
            this.StuckDistance.Size = new System.Drawing.Size(30, 20);
            this.StuckDistance.TabIndex = 36;
            this.StuckDistance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // mobStuckWatch
            // 
            this.mobStuckWatch.AutoSize = true;
            this.mobStuckWatch.Location = new System.Drawing.Point(13, 25);
            this.mobStuckWatch.Name = "mobStuckWatch";
            this.mobStuckWatch.Size = new System.Drawing.Size(115, 17);
            this.mobStuckWatch.TabIndex = 17;
            this.mobStuckWatch.Text = "Running After Mob";
            this.mobStuckWatch.UseVisualStyleBackColor = true;
            // 
            // OptionsJAMainTab
            // 
            this.OptionsJAMainTab.Controls.Add(this.JAtabselect);
            this.OptionsJAMainTab.Location = new System.Drawing.Point(4, 22);
            this.OptionsJAMainTab.Name = "OptionsJAMainTab";
            this.OptionsJAMainTab.Padding = new System.Windows.Forms.Padding(3);
            this.OptionsJAMainTab.Size = new System.Drawing.Size(419, 197);
            this.OptionsJAMainTab.TabIndex = 4;
            this.OptionsJAMainTab.Text = "JA\'s";
            this.OptionsJAMainTab.UseVisualStyleBackColor = true;
            // 
            // JAtabselect
            // 
            this.JAtabselect.Controls.Add(this.selectPage);
            this.JAtabselect.Controls.Add(this.WHMpage);
            this.JAtabselect.Controls.Add(this.RDMpage);
            this.JAtabselect.Controls.Add(this.samPage);
            this.JAtabselect.Controls.Add(this.SCHpage);
            this.JAtabselect.Controls.Add(this.RUNpage);
            this.JAtabselect.Controls.Add(this.MONpage);
            this.JAtabselect.Location = new System.Drawing.Point(6, 5);
            this.JAtabselect.Name = "JAtabselect";
            this.JAtabselect.SelectedIndex = 0;
            this.JAtabselect.Size = new System.Drawing.Size(410, 186);
            this.JAtabselect.TabIndex = 0;
            // 
            // selectPage
            // 
            this.selectPage.Controls.Add(this.playerJA);
            this.selectPage.Controls.Add(this.GetSetJA);
            this.selectPage.Location = new System.Drawing.Point(4, 22);
            this.selectPage.Name = "selectPage";
            this.selectPage.Padding = new System.Windows.Forms.Padding(3);
            this.selectPage.Size = new System.Drawing.Size(402, 160);
            this.selectPage.TabIndex = 0;
            this.selectPage.Text = "Select";
            this.selectPage.UseVisualStyleBackColor = true;
            // 
            // playerJA
            // 
            this.playerJA.CheckOnClick = true;
            this.playerJA.FormattingEnabled = true;
            this.playerJA.Location = new System.Drawing.Point(95, 6);
            this.playerJA.Name = "playerJA";
            this.playerJA.Size = new System.Drawing.Size(213, 109);
            this.playerJA.TabIndex = 13;
            this.playerJA.SelectedIndexChanged += new System.EventHandler(this.playerJA_SelectedIndexChanged);
            // 
            // GetSetJA
            // 
            this.GetSetJA.Dock = System.Windows.Forms.DockStyle.None;
            this.GetSetJA.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadJAsToolStripMenuItem,
            this.clearJAsToolStripMenuItem});
            this.GetSetJA.Location = new System.Drawing.Point(116, 130);
            this.GetSetJA.Name = "GetSetJA";
            this.GetSetJA.Size = new System.Drawing.Size(145, 24);
            this.GetSetJA.TabIndex = 11;
            this.GetSetJA.Text = "GetSetJA";
            // 
            // loadJAsToolStripMenuItem
            // 
            this.loadJAsToolStripMenuItem.Name = "loadJAsToolStripMenuItem";
            this.loadJAsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.loadJAsToolStripMenuItem.Text = "Load JA\'s";
            this.loadJAsToolStripMenuItem.Click += new System.EventHandler(this.LoadJA_Click);
            // 
            // clearJAsToolStripMenuItem
            // 
            this.clearJAsToolStripMenuItem.Name = "clearJAsToolStripMenuItem";
            this.clearJAsToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.clearJAsToolStripMenuItem.Text = "Clear JA\'s";
            this.clearJAsToolStripMenuItem.Click += new System.EventHandler(this.ClearJA_Click);
            // 
            // WHMpage
            // 
            this.WHMpage.Controls.Add(this.benedictiongroupBox);
            this.WHMpage.Location = new System.Drawing.Point(4, 22);
            this.WHMpage.Name = "WHMpage";
            this.WHMpage.Padding = new System.Windows.Forms.Padding(3);
            this.WHMpage.Size = new System.Drawing.Size(402, 160);
            this.WHMpage.TabIndex = 1;
            this.WHMpage.Text = "WHM";
            this.WHMpage.UseVisualStyleBackColor = true;
            // 
            // benedictiongroupBox
            // 
            this.benedictiongroupBox.Controls.Add(this.BenedictionHPPuse);
            this.benedictiongroupBox.Controls.Add(this.benedictiontext);
            this.benedictiongroupBox.Location = new System.Drawing.Point(7, 7);
            this.benedictiongroupBox.Name = "benedictiongroupBox";
            this.benedictiongroupBox.Size = new System.Drawing.Size(91, 40);
            this.benedictiongroupBox.TabIndex = 0;
            this.benedictiongroupBox.TabStop = false;
            this.benedictiongroupBox.Text = "Benediction";
            // 
            // BenedictionHPPuse
            // 
            this.BenedictionHPPuse.Enabled = false;
            this.BenedictionHPPuse.Location = new System.Drawing.Point(41, 14);
            this.BenedictionHPPuse.Name = "BenedictionHPPuse";
            this.BenedictionHPPuse.Size = new System.Drawing.Size(44, 20);
            this.BenedictionHPPuse.TabIndex = 1;
            // 
            // benedictiontext
            // 
            this.benedictiontext.AutoSize = true;
            this.benedictiontext.Location = new System.Drawing.Point(3, 16);
            this.benedictiontext.Name = "benedictiontext";
            this.benedictiontext.Size = new System.Drawing.Size(33, 13);
            this.benedictiontext.TabIndex = 0;
            this.benedictiontext.Text = "HP %";
            // 
            // RDMpage
            // 
            this.RDMpage.Controls.Add(this.Convertgroup);
            this.RDMpage.Location = new System.Drawing.Point(4, 22);
            this.RDMpage.Name = "RDMpage";
            this.RDMpage.Padding = new System.Windows.Forms.Padding(3);
            this.RDMpage.Size = new System.Drawing.Size(402, 160);
            this.RDMpage.TabIndex = 2;
            this.RDMpage.Text = "RDM";
            this.RDMpage.UseVisualStyleBackColor = true;
            // 
            // Convertgroup
            // 
            this.Convertgroup.Controls.Add(this.ConvertHPP);
            this.Convertgroup.Controls.Add(this.ConvertMPP);
            this.Convertgroup.Controls.Add(this.ConvertMP);
            this.Convertgroup.Controls.Add(this.ConvertHP);
            this.Convertgroup.Controls.Add(this.convertmptext);
            this.Convertgroup.Controls.Add(this.converthptext);
            this.Convertgroup.Enabled = false;
            this.Convertgroup.Location = new System.Drawing.Point(7, 9);
            this.Convertgroup.Name = "Convertgroup";
            this.Convertgroup.Size = new System.Drawing.Size(167, 69);
            this.Convertgroup.TabIndex = 0;
            this.Convertgroup.TabStop = false;
            this.Convertgroup.Text = "Convert";
            // 
            // ConvertHPP
            // 
            this.ConvertHPP.Location = new System.Drawing.Point(111, 18);
            this.ConvertHPP.Name = "ConvertHPP";
            this.ConvertHPP.Size = new System.Drawing.Size(44, 20);
            this.ConvertHPP.TabIndex = 5;
            this.ConvertHPP.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // ConvertMPP
            // 
            this.ConvertMPP.Location = new System.Drawing.Point(111, 40);
            this.ConvertMPP.Name = "ConvertMPP";
            this.ConvertMPP.Size = new System.Drawing.Size(44, 20);
            this.ConvertMPP.TabIndex = 4;
            this.ConvertMPP.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // ConvertMP
            // 
            this.ConvertMP.AutoSize = true;
            this.ConvertMP.Location = new System.Drawing.Point(6, 43);
            this.ConvertMP.Name = "ConvertMP";
            this.ConvertMP.Size = new System.Drawing.Size(59, 17);
            this.ConvertMP.TabIndex = 3;
            this.ConvertMP.Text = "For MP";
            this.ConvertMP.UseVisualStyleBackColor = true;
            // 
            // ConvertHP
            // 
            this.ConvertHP.AutoSize = true;
            this.ConvertHP.Location = new System.Drawing.Point(6, 19);
            this.ConvertHP.Name = "ConvertHP";
            this.ConvertHP.Size = new System.Drawing.Size(58, 17);
            this.ConvertHP.TabIndex = 2;
            this.ConvertHP.Text = "For HP";
            this.ConvertHP.UseVisualStyleBackColor = true;
            // 
            // convertmptext
            // 
            this.convertmptext.AutoSize = true;
            this.convertmptext.Location = new System.Drawing.Point(72, 42);
            this.convertmptext.Name = "convertmptext";
            this.convertmptext.Size = new System.Drawing.Size(34, 13);
            this.convertmptext.TabIndex = 1;
            this.convertmptext.Text = "MP %";
            // 
            // converthptext
            // 
            this.converthptext.AutoSize = true;
            this.converthptext.Location = new System.Drawing.Point(72, 20);
            this.converthptext.Name = "converthptext";
            this.converthptext.Size = new System.Drawing.Size(33, 13);
            this.converthptext.TabIndex = 0;
            this.converthptext.Text = "HP %";
            // 
            // samPage
            // 
            this.samPage.Controls.Add(this.label58);
            this.samPage.Controls.Add(this.sekkanokiWs);
            this.samPage.Location = new System.Drawing.Point(4, 22);
            this.samPage.Name = "samPage";
            this.samPage.Padding = new System.Windows.Forms.Padding(3);
            this.samPage.Size = new System.Drawing.Size(402, 160);
            this.samPage.TabIndex = 7;
            this.samPage.Text = "SAM";
            this.samPage.UseVisualStyleBackColor = true;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(40, 15);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(146, 13);
            this.label58.TabIndex = 104;
            this.label58.Text = "Sekkanoki First Weapon Skill";
            // 
            // sekkanokiWs
            // 
            this.sekkanokiWs.AutoCompleteCustomSource.AddRange(new string[] {
            "Combo",
            "Shoulder Tackle",
            "One Inch Punch",
            "Backhand Blow",
            "Raging Fists",
            "Spinning Attack",
            "Howling Fist",
            "Dragon Kick",
            "Asuran Fists",
            "Final Heaven",
            "Ascetic\'s Fury",
            "Stringing Pummel",
            "Tornado Kick",
            "Victory Smite",
            "Shijin Spiral",
            "Wasp Sting",
            "Gust Slash",
            "Shadow Stitch",
            "Viper Bite",
            "Cyclone",
            "Energy Steal",
            "Energy Drain",
            "Dancing Edge",
            "Shark Bite",
            "Evisceration",
            "Mercy Stroke",
            "Mandalic Stab",
            "Mordant Rime",
            "Pyrrhic Kleos",
            "Aeolian Edge",
            "Rudra\'s Storm",
            "Exenterator",
            "Fast Blade",
            "Burning Blade",
            "Red Lotus Blade",
            "Flat Blade",
            "Shining Blade",
            "Seraph Blade",
            "Circle Blade",
            "Spirits Within",
            "Vorpal Blade",
            "Swift Blade",
            "Savage Blade",
            "Knights of Round",
            "Death Blossom",
            "Atonement",
            "Expiacion",
            "Sanguine Blade",
            "Chant du Cygne",
            "Requiescat",
            "Hard Slash",
            "Power Slash",
            "Frostbite",
            "Freezebite",
            "Shockwave",
            "Crescent Moon",
            "Sickle Moon",
            "Spinning Slash",
            "Ground Strike",
            "Scourge",
            "Herculean Slash",
            "Torcleaver",
            "Resolution",
            "Raging Axe",
            "Smash Axe",
            "Gale Axe",
            "Avalanche Axe",
            "Spinning Axe",
            "Rampage",
            "Calamity",
            "Mistral Axe",
            "Decimation",
            "Onslaught",
            "Primal Rend",
            "Bora Axe",
            "Cloudsplitter",
            "Ruinator",
            "Shield Break",
            "Iron Tempest",
            "Sturmwind",
            "Armor Break",
            "Keen Edge",
            "Weapon Break",
            "Raging Rush",
            "Full Break",
            "Steel Cyclone",
            "Metatron Torment",
            "King\'s Justice",
            "Fell Cleave",
            "Ukko\'s Fury",
            "Upheaval",
            "Slice",
            "Dark Harvest",
            "Shadow of Death",
            "Nightmare Scythe",
            "Spinning Scythe",
            "Vorpal Scythe",
            "Guillotine",
            "Cross Reaper",
            "Spiral Hell",
            "Catastrophe",
            "Insurgency",
            "Infernal Scythe",
            "Quietus",
            "Entropy",
            "Double Thrust",
            "Thunder Thrust",
            "Raiden Thrust",
            "Leg Sweep",
            "Penta Thrust",
            "Vorpal Thrust",
            "Skewer",
            "Wheeling Thrust",
            "Impulse Drive",
            "Geirskogul",
            "Drakesbane",
            "Sonic Thrust",
            "Camlann\'s Torment",
            "Stardiver",
            "Blade: Rin",
            "Blade: Retsu",
            "Blade: Teki",
            "Blade: To",
            "Blade: Chi",
            "Blade: Ei",
            "Blade: Jin",
            "Blade: Ten",
            "Blade: Ku",
            "Blade: Metsu",
            "Blade: Kamu",
            "Blade: Yu",
            "Blade: Hi",
            "Blade: Shun",
            "Tachi: Enpi",
            "Tachi: Hobaku",
            "Tachi: Goten",
            "Tachi: Kagero",
            "Tachi: Jinpu",
            "Tachi: Koki",
            "Tachi: Yukikaze",
            "Tachi: Gekko",
            "Tachi: Kasha",
            "Tachi: Kaiten",
            "Tachi: Rana",
            "Tachi: Ageha",
            "Tachi: Fudo",
            "Tachi: Shoha",
            "Shining Strike",
            "Seraph Strike",
            "Brainshaker",
            "Starlight",
            "Moonlight",
            "Skullbreaker",
            "True Strike",
            "Judgment",
            "Hexa Strike",
            "Black Halo",
            "Randgrith",
            "Mystic Boon",
            "Flash Nova",
            "Dagan",
            "Realmrazer",
            "Heavy Swing",
            "Rock Crusher",
            "Earth Crusher",
            "Starburst",
            "Sunburst",
            "Shell Crusher",
            "Full Swing",
            "Spirit Taker",
            "Retribution",
            "Gates of Tartarus",
            "Vidohunir",
            "Garland of Bliss",
            "Omniscience",
            "Cataclysm",
            "Myrkr",
            "Shattersoul",
            "Flaming Arrow",
            "Piercing Arrow",
            "Dulling Arrow",
            "Sidewinder",
            "Blast Arrow",
            "Arching Arrow",
            "Empyreal Arrow",
            "Namas Arrow",
            "Refulgent Arrow",
            "Jishnu\'s Radiance",
            "Apex Arrow",
            "Hot Shot",
            "Split Shot",
            "Sniper Shot",
            "Slug Shot",
            "Blast Shot",
            "Heavy Shot",
            "Detonator",
            "Coronach",
            "Trueflight",
            "Leaden Salute",
            "Numbing Shot",
            "Wildfire",
            "Last Stand",
            "Slapstick",
            "Arcuballista",
            "String Clipper",
            "Chimera Ripper",
            "Knockout",
            "Magic Mortar",
            "Daze",
            "Armor Piercer",
            "Cannibal Blade",
            "Bone Crusher",
            "Dimidiation"});
            this.sekkanokiWs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.sekkanokiWs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.sekkanokiWs.FormattingEnabled = true;
            this.sekkanokiWs.Location = new System.Drawing.Point(188, 12);
            this.sekkanokiWs.Name = "sekkanokiWs";
            this.sekkanokiWs.Size = new System.Drawing.Size(112, 21);
            this.sekkanokiWs.Sorted = true;
            this.sekkanokiWs.TabIndex = 103;
            // 
            // SCHpage
            // 
            this.SCHpage.Controls.Add(this.Sublimationcount);
            this.SCHpage.Controls.Add(this.label8);
            this.SCHpage.Location = new System.Drawing.Point(4, 22);
            this.SCHpage.Name = "SCHpage";
            this.SCHpage.Padding = new System.Windows.Forms.Padding(3);
            this.SCHpage.Size = new System.Drawing.Size(402, 160);
            this.SCHpage.TabIndex = 6;
            this.SCHpage.Text = "SCH";
            this.SCHpage.UseVisualStyleBackColor = true;
            // 
            // Sublimationcount
            // 
            this.Sublimationcount.Enabled = false;
            this.Sublimationcount.Location = new System.Drawing.Point(98, 8);
            this.Sublimationcount.Name = "Sublimationcount";
            this.Sublimationcount.Size = new System.Drawing.Size(44, 20);
            this.Sublimationcount.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Sublimation @MP";
            // 
            // RUNpage
            // 
            this.RUNpage.Controls.Add(this.VivaciousPulseHP);
            this.RUNpage.Controls.Add(this.VivaciousPulse);
            this.RUNpage.Location = new System.Drawing.Point(4, 22);
            this.RUNpage.Name = "RUNpage";
            this.RUNpage.Padding = new System.Windows.Forms.Padding(3);
            this.RUNpage.Size = new System.Drawing.Size(402, 160);
            this.RUNpage.TabIndex = 3;
            this.RUNpage.Text = "RUN";
            this.RUNpage.UseVisualStyleBackColor = true;
            // 
            // VivaciousPulseHP
            // 
            this.VivaciousPulseHP.Enabled = false;
            this.VivaciousPulseHP.Location = new System.Drawing.Point(148, 8);
            this.VivaciousPulseHP.Name = "VivaciousPulseHP";
            this.VivaciousPulseHP.Size = new System.Drawing.Size(44, 20);
            this.VivaciousPulseHP.TabIndex = 6;
            // 
            // VivaciousPulse
            // 
            this.VivaciousPulse.AutoSize = true;
            this.VivaciousPulse.Enabled = false;
            this.VivaciousPulse.Location = new System.Drawing.Point(7, 9);
            this.VivaciousPulse.Name = "VivaciousPulse";
            this.VivaciousPulse.Size = new System.Drawing.Size(144, 17);
            this.VivaciousPulse.TabIndex = 0;
            this.VivaciousPulse.Text = "Vivacious Pulse @ HP %";
            this.VivaciousPulse.UseVisualStyleBackColor = true;
            // 
            // MONpage
            // 
            this.MONpage.Controls.Add(this.MONmpCount);
            this.MONpage.Controls.Add(this.MONhpCount);
            this.MONpage.Controls.Add(this.monmptext);
            this.MONpage.Controls.Add(this.monhptext);
            this.MONpage.Location = new System.Drawing.Point(4, 22);
            this.MONpage.Name = "MONpage";
            this.MONpage.Padding = new System.Windows.Forms.Padding(3);
            this.MONpage.Size = new System.Drawing.Size(402, 160);
            this.MONpage.TabIndex = 4;
            this.MONpage.Text = "MON";
            this.MONpage.UseVisualStyleBackColor = true;
            // 
            // MONmpCount
            // 
            this.MONmpCount.Enabled = false;
            this.MONmpCount.Location = new System.Drawing.Point(46, 30);
            this.MONmpCount.Name = "MONmpCount";
            this.MONmpCount.Size = new System.Drawing.Size(44, 20);
            this.MONmpCount.TabIndex = 7;
            this.MONmpCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // MONhpCount
            // 
            this.MONhpCount.Enabled = false;
            this.MONhpCount.Location = new System.Drawing.Point(46, 6);
            this.MONhpCount.Name = "MONhpCount";
            this.MONhpCount.Size = new System.Drawing.Size(44, 20);
            this.MONhpCount.TabIndex = 6;
            this.MONhpCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // monmptext
            // 
            this.monmptext.AutoSize = true;
            this.monmptext.Location = new System.Drawing.Point(7, 32);
            this.monmptext.Name = "monmptext";
            this.monmptext.Size = new System.Drawing.Size(34, 13);
            this.monmptext.TabIndex = 1;
            this.monmptext.Text = "MP %";
            // 
            // monhptext
            // 
            this.monhptext.AutoSize = true;
            this.monhptext.Location = new System.Drawing.Point(7, 9);
            this.monhptext.Name = "monhptext";
            this.monhptext.Size = new System.Drawing.Size(33, 13);
            this.monhptext.TabIndex = 0;
            this.monhptext.Text = "HP %";
            // 
            // OptionsMAMainTab
            // 
            this.OptionsMAMainTab.Controls.Add(this.MAtabs);
            this.OptionsMAMainTab.Location = new System.Drawing.Point(4, 22);
            this.OptionsMAMainTab.Name = "OptionsMAMainTab";
            this.OptionsMAMainTab.Padding = new System.Windows.Forms.Padding(3);
            this.OptionsMAMainTab.Size = new System.Drawing.Size(419, 197);
            this.OptionsMAMainTab.TabIndex = 7;
            this.OptionsMAMainTab.Text = "MA\'s";
            this.OptionsMAMainTab.UseVisualStyleBackColor = true;
            // 
            // MAtabs
            // 
            this.MAtabs.Controls.Add(this.MASelectPage);
            this.MAtabs.Controls.Add(this.CureConfigPage);
            this.MAtabs.Controls.Add(this.PartyCurepage);
            this.MAtabs.Controls.Add(this.Cureagapage);
            this.MAtabs.Controls.Add(this.DrainAspirpage);
            this.MAtabs.Controls.Add(this.BLUCurespage);
            this.MAtabs.Controls.Add(this.MAconfigpage);
            this.MAtabs.Location = new System.Drawing.Point(6, 6);
            this.MAtabs.Name = "MAtabs";
            this.MAtabs.SelectedIndex = 0;
            this.MAtabs.Size = new System.Drawing.Size(410, 184);
            this.MAtabs.TabIndex = 0;
            // 
            // MASelectPage
            // 
            this.MASelectPage.Controls.Add(this.playerMA);
            this.MASelectPage.Controls.Add(this.GetSetMA);
            this.MASelectPage.Location = new System.Drawing.Point(4, 22);
            this.MASelectPage.Name = "MASelectPage";
            this.MASelectPage.Padding = new System.Windows.Forms.Padding(3);
            this.MASelectPage.Size = new System.Drawing.Size(402, 158);
            this.MASelectPage.TabIndex = 0;
            this.MASelectPage.Text = "Select";
            this.MASelectPage.UseVisualStyleBackColor = true;
            // 
            // playerMA
            // 
            this.playerMA.CheckOnClick = true;
            this.playerMA.FormattingEnabled = true;
            this.playerMA.Location = new System.Drawing.Point(95, 7);
            this.playerMA.Name = "playerMA";
            this.playerMA.Size = new System.Drawing.Size(213, 109);
            this.playerMA.TabIndex = 5;
            this.playerMA.SelectedIndexChanged += new System.EventHandler(this.playerMA_SelectedIndexChanged);
            // 
            // GetSetMA
            // 
            this.GetSetMA.Dock = System.Windows.Forms.DockStyle.None;
            this.GetSetMA.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMAsToolStripMenuItem,
            this.clearMAsToolStripMenuItem});
            this.GetSetMA.Location = new System.Drawing.Point(117, 127);
            this.GetSetMA.Name = "GetSetMA";
            this.GetSetMA.Size = new System.Drawing.Size(159, 24);
            this.GetSetMA.TabIndex = 16;
            this.GetSetMA.Text = "GetSetMA";
            // 
            // loadMAsToolStripMenuItem
            // 
            this.loadMAsToolStripMenuItem.Name = "loadMAsToolStripMenuItem";
            this.loadMAsToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.loadMAsToolStripMenuItem.Text = "Load MA\'s";
            this.loadMAsToolStripMenuItem.Click += new System.EventHandler(this.LoadMA_Click);
            // 
            // clearMAsToolStripMenuItem
            // 
            this.clearMAsToolStripMenuItem.Name = "clearMAsToolStripMenuItem";
            this.clearMAsToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.clearMAsToolStripMenuItem.Text = "Clear MA\'s";
            this.clearMAsToolStripMenuItem.Click += new System.EventHandler(this.ClearMA_Click);
            // 
            // CureConfigPage
            // 
            this.CureConfigPage.Controls.Add(this.CuraIIcount);
            this.CureConfigPage.Controls.Add(this.Curacount);
            this.CureConfigPage.Controls.Add(this.CureIIIcount);
            this.CureConfigPage.Controls.Add(this.CureIIcount);
            this.CureConfigPage.Controls.Add(this.Curecount);
            this.CureConfigPage.Controls.Add(this.CuraIIIcount);
            this.CureConfigPage.Controls.Add(this.FullCurecount);
            this.CureConfigPage.Controls.Add(this.CureVIcount);
            this.CureConfigPage.Controls.Add(this.CureVcount);
            this.CureConfigPage.Controls.Add(this.CureIVcount);
            this.CureConfigPage.Controls.Add(this.label55);
            this.CureConfigPage.Controls.Add(this.label53);
            this.CureConfigPage.Controls.Add(this.label54);
            this.CureConfigPage.Controls.Add(this.label52);
            this.CureConfigPage.Controls.Add(this.label45);
            this.CureConfigPage.Controls.Add(this.label44);
            this.CureConfigPage.Controls.Add(this.label43);
            this.CureConfigPage.Controls.Add(this.label9);
            this.CureConfigPage.Controls.Add(this.label2);
            this.CureConfigPage.Controls.Add(this.label1);
            this.CureConfigPage.Location = new System.Drawing.Point(4, 22);
            this.CureConfigPage.Name = "CureConfigPage";
            this.CureConfigPage.Padding = new System.Windows.Forms.Padding(3);
            this.CureConfigPage.Size = new System.Drawing.Size(402, 158);
            this.CureConfigPage.TabIndex = 1;
            this.CureConfigPage.Text = "Cure";
            this.CureConfigPage.UseVisualStyleBackColor = true;
            // 
            // CuraIIcount
            // 
            this.CuraIIcount.Enabled = false;
            this.CuraIIcount.Location = new System.Drawing.Point(128, 114);
            this.CuraIIcount.Name = "CuraIIcount";
            this.CuraIIcount.Size = new System.Drawing.Size(44, 20);
            this.CuraIIcount.TabIndex = 19;
            // 
            // Curacount
            // 
            this.Curacount.Enabled = false;
            this.Curacount.Location = new System.Drawing.Point(128, 92);
            this.Curacount.Name = "Curacount";
            this.Curacount.Size = new System.Drawing.Size(44, 20);
            this.Curacount.TabIndex = 15;
            // 
            // CureIIIcount
            // 
            this.CureIIIcount.Enabled = false;
            this.CureIIIcount.Location = new System.Drawing.Point(128, 66);
            this.CureIIIcount.Name = "CureIIIcount";
            this.CureIIIcount.Size = new System.Drawing.Size(44, 20);
            this.CureIIIcount.TabIndex = 7;
            // 
            // CureIIcount
            // 
            this.CureIIcount.Enabled = false;
            this.CureIIcount.Location = new System.Drawing.Point(128, 44);
            this.CureIIcount.Name = "CureIIcount";
            this.CureIIcount.Size = new System.Drawing.Size(44, 20);
            this.CureIIcount.TabIndex = 6;
            // 
            // Curecount
            // 
            this.Curecount.Enabled = false;
            this.Curecount.Location = new System.Drawing.Point(128, 22);
            this.Curecount.Name = "Curecount";
            this.Curecount.Size = new System.Drawing.Size(44, 20);
            this.Curecount.TabIndex = 0;
            // 
            // CuraIIIcount
            // 
            this.CuraIIIcount.Enabled = false;
            this.CuraIIIcount.Location = new System.Drawing.Point(279, 91);
            this.CuraIIIcount.Name = "CuraIIIcount";
            this.CuraIIIcount.Size = new System.Drawing.Size(44, 20);
            this.CuraIIIcount.TabIndex = 17;
            // 
            // FullCurecount
            // 
            this.FullCurecount.Enabled = false;
            this.FullCurecount.Location = new System.Drawing.Point(279, 117);
            this.FullCurecount.Name = "FullCurecount";
            this.FullCurecount.Size = new System.Drawing.Size(44, 20);
            this.FullCurecount.TabIndex = 13;
            // 
            // CureVIcount
            // 
            this.CureVIcount.Enabled = false;
            this.CureVIcount.Location = new System.Drawing.Point(279, 65);
            this.CureVIcount.Name = "CureVIcount";
            this.CureVIcount.Size = new System.Drawing.Size(44, 20);
            this.CureVIcount.TabIndex = 11;
            // 
            // CureVcount
            // 
            this.CureVcount.Enabled = false;
            this.CureVcount.Location = new System.Drawing.Point(279, 43);
            this.CureVcount.Name = "CureVcount";
            this.CureVcount.Size = new System.Drawing.Size(44, 20);
            this.CureVcount.TabIndex = 9;
            // 
            // CureIVcount
            // 
            this.CureIVcount.Enabled = false;
            this.CureIVcount.Location = new System.Drawing.Point(279, 21);
            this.CureIVcount.Name = "CureIVcount";
            this.CureIVcount.Size = new System.Drawing.Size(44, 20);
            this.CureIVcount.TabIndex = 8;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(79, 116);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(49, 13);
            this.label55.TabIndex = 18;
            this.label55.Text = "CuraII  %";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(230, 91);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(49, 13);
            this.label53.TabIndex = 16;
            this.label53.Text = "CuraIII %";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(79, 94);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(49, 13);
            this.label54.TabIndex = 14;
            this.label54.Text = "Cura    %";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(220, 119);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(59, 13);
            this.label52.TabIndex = 12;
            this.label52.Text = "Full Cure %";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(230, 65);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(50, 13);
            this.label45.TabIndex = 10;
            this.label45.Text = "CureVI %";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(230, 43);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(50, 13);
            this.label44.TabIndex = 5;
            this.label44.Text = "CureV  %";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(230, 23);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(50, 13);
            this.label43.TabIndex = 4;
            this.label43.Text = "CureIV %";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(79, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "CureIII %";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CureII  %";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cure    %";
            // 
            // PartyCurepage
            // 
            this.PartyCurepage.Controls.Add(this.tabControl2);
            this.PartyCurepage.Location = new System.Drawing.Point(4, 22);
            this.PartyCurepage.Name = "PartyCurepage";
            this.PartyCurepage.Padding = new System.Windows.Forms.Padding(3);
            this.PartyCurepage.Size = new System.Drawing.Size(402, 158);
            this.PartyCurepage.TabIndex = 5;
            this.PartyCurepage.Text = "Party Cure";
            this.PartyCurepage.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Location = new System.Drawing.Point(2, 5);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(397, 149);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ptCure);
            this.tabPage1.Controls.Add(this.FullCureptcount);
            this.tabPage1.Controls.Add(this.label80);
            this.tabPage1.Controls.Add(this.CureVIptcount);
            this.tabPage1.Controls.Add(this.label74);
            this.tabPage1.Controls.Add(this.CureVptcount);
            this.tabPage1.Controls.Add(this.CureIVptcount);
            this.tabPage1.Controls.Add(this.CureIIIptcount);
            this.tabPage1.Controls.Add(this.label75);
            this.tabPage1.Controls.Add(this.CureIIptcount);
            this.tabPage1.Controls.Add(this.label66);
            this.tabPage1.Controls.Add(this.label76);
            this.tabPage1.Controls.Add(this.label67);
            this.tabPage1.Controls.Add(this.label68);
            this.tabPage1.Controls.Add(this.Cureptcount);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(389, 123);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cure";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ptCure
            // 
            this.ptCure.AutoSize = true;
            this.ptCure.Location = new System.Drawing.Point(40, 16);
            this.ptCure.Name = "ptCure";
            this.ptCure.Size = new System.Drawing.Size(59, 17);
            this.ptCure.TabIndex = 28;
            this.ptCure.Text = "Enable";
            this.ptCure.UseVisualStyleBackColor = true;
            // 
            // FullCureptcount
            // 
            this.FullCureptcount.Enabled = false;
            this.FullCureptcount.Location = new System.Drawing.Point(284, 93);
            this.FullCureptcount.Name = "FullCureptcount";
            this.FullCureptcount.Size = new System.Drawing.Size(44, 20);
            this.FullCureptcount.TabIndex = 25;
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(227, 95);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(59, 13);
            this.label80.TabIndex = 24;
            this.label80.Text = "Full Cure %";
            // 
            // CureVIptcount
            // 
            this.CureVIptcount.Enabled = false;
            this.CureVIptcount.Location = new System.Drawing.Point(169, 93);
            this.CureVIptcount.Name = "CureVIptcount";
            this.CureVIptcount.Size = new System.Drawing.Size(44, 20);
            this.CureVIptcount.TabIndex = 19;
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(120, 95);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(50, 13);
            this.label74.TabIndex = 18;
            this.label74.Text = "CureVI %";
            // 
            // CureVptcount
            // 
            this.CureVptcount.Enabled = false;
            this.CureVptcount.Location = new System.Drawing.Point(169, 72);
            this.CureVptcount.Name = "CureVptcount";
            this.CureVptcount.Size = new System.Drawing.Size(44, 20);
            this.CureVptcount.TabIndex = 17;
            // 
            // CureIVptcount
            // 
            this.CureIVptcount.Enabled = false;
            this.CureIVptcount.Location = new System.Drawing.Point(169, 51);
            this.CureIVptcount.Name = "CureIVptcount";
            this.CureIVptcount.Size = new System.Drawing.Size(44, 20);
            this.CureIVptcount.TabIndex = 16;
            // 
            // CureIIIptcount
            // 
            this.CureIIIptcount.Enabled = false;
            this.CureIIIptcount.Location = new System.Drawing.Point(55, 93);
            this.CureIIIptcount.Name = "CureIIIptcount";
            this.CureIIIptcount.Size = new System.Drawing.Size(44, 20);
            this.CureIIIptcount.TabIndex = 13;
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(120, 74);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(50, 13);
            this.label75.TabIndex = 15;
            this.label75.Text = "CureV  %";
            // 
            // CureIIptcount
            // 
            this.CureIIptcount.Enabled = false;
            this.CureIIptcount.Location = new System.Drawing.Point(55, 72);
            this.CureIIptcount.Name = "CureIIptcount";
            this.CureIIptcount.Size = new System.Drawing.Size(44, 20);
            this.CureIIptcount.TabIndex = 12;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(6, 95);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(49, 13);
            this.label66.TabIndex = 11;
            this.label66.Text = "CureIII %";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(120, 53);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(50, 13);
            this.label76.TabIndex = 14;
            this.label76.Text = "CureIV %";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(6, 74);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(49, 13);
            this.label67.TabIndex = 10;
            this.label67.Text = "CureII  %";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(6, 53);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(49, 13);
            this.label68.TabIndex = 9;
            this.label68.Text = "Cure    %";
            // 
            // Cureptcount
            // 
            this.Cureptcount.Enabled = false;
            this.Cureptcount.Location = new System.Drawing.Point(55, 51);
            this.Cureptcount.Name = "Cureptcount";
            this.Cureptcount.Size = new System.Drawing.Size(44, 20);
            this.Cureptcount.TabIndex = 8;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.CurePTlist);
            this.tabPage2.Controls.Add(this.groupBox17);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(389, 123);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Party Members";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // CurePTlist
            // 
            this.CurePTlist.CheckOnClick = true;
            this.CurePTlist.FormattingEnabled = true;
            this.CurePTlist.Location = new System.Drawing.Point(93, 4);
            this.CurePTlist.Name = "CurePTlist";
            this.CurePTlist.Size = new System.Drawing.Size(203, 79);
            this.CurePTlist.Sorted = true;
            this.CurePTlist.TabIndex = 22;
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.menuStrip1);
            this.groupBox17.Location = new System.Drawing.Point(93, 84);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(203, 34);
            this.groupBox17.TabIndex = 19;
            this.groupBox17.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(20, 10);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(159, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(75, 20);
            this.toolStripMenuItem1.Text = "Load Party";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(76, 20);
            this.toolStripMenuItem2.Text = "Clear Party";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // Cureagapage
            // 
            this.Cureagapage.Controls.Add(this.label39);
            this.Cureagapage.Controls.Add(this.CuragaVcount);
            this.Cureagapage.Controls.Add(this.CuragaIVcount);
            this.Cureagapage.Controls.Add(this.CuragaIIIcount);
            this.Cureagapage.Controls.Add(this.CuragaIIcount);
            this.Cureagapage.Controls.Add(this.label69);
            this.Cureagapage.Controls.Add(this.label70);
            this.Cureagapage.Controls.Add(this.label71);
            this.Cureagapage.Controls.Add(this.label72);
            this.Cureagapage.Controls.Add(this.label73);
            this.Cureagapage.Controls.Add(this.Curagacount);
            this.Cureagapage.Location = new System.Drawing.Point(4, 22);
            this.Cureagapage.Name = "Cureagapage";
            this.Cureagapage.Padding = new System.Windows.Forms.Padding(3);
            this.Cureagapage.Size = new System.Drawing.Size(402, 158);
            this.Cureagapage.TabIndex = 6;
            this.Cureagapage.Text = "Curaga";
            this.Cureagapage.UseVisualStyleBackColor = true;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(90, 12);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(223, 13);
            this.label39.TabIndex = 30;
            this.label39.Text = "This works on the average HP% of your party.";
            // 
            // CuragaVcount
            // 
            this.CuragaVcount.Enabled = false;
            this.CuragaVcount.Location = new System.Drawing.Point(214, 96);
            this.CuragaVcount.Name = "CuragaVcount";
            this.CuragaVcount.Size = new System.Drawing.Size(44, 20);
            this.CuragaVcount.TabIndex = 29;
            // 
            // CuragaIVcount
            // 
            this.CuragaIVcount.Enabled = false;
            this.CuragaIVcount.Location = new System.Drawing.Point(307, 68);
            this.CuragaIVcount.Name = "CuragaIVcount";
            this.CuragaIVcount.Size = new System.Drawing.Size(44, 20);
            this.CuragaIVcount.TabIndex = 28;
            // 
            // CuragaIIIcount
            // 
            this.CuragaIIIcount.Enabled = false;
            this.CuragaIIIcount.Location = new System.Drawing.Point(122, 68);
            this.CuragaIIIcount.Name = "CuragaIIIcount";
            this.CuragaIIIcount.Size = new System.Drawing.Size(44, 20);
            this.CuragaIIIcount.TabIndex = 27;
            // 
            // CuragaIIcount
            // 
            this.CuragaIIcount.Enabled = false;
            this.CuragaIIcount.Location = new System.Drawing.Point(307, 32);
            this.CuragaIIcount.Name = "CuragaIIcount";
            this.CuragaIIcount.Size = new System.Drawing.Size(44, 20);
            this.CuragaIIcount.TabIndex = 26;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(148, 98);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(62, 13);
            this.label69.TabIndex = 25;
            this.label69.Text = "Curaga V %";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(237, 70);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(65, 13);
            this.label70.TabIndex = 24;
            this.label70.Text = "Curaga IV %";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(52, 70);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(64, 13);
            this.label71.TabIndex = 23;
            this.label71.Text = "Curaga III %";
            this.label71.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(237, 34);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(64, 13);
            this.label72.TabIndex = 22;
            this.label72.Text = "Curaga II  %";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(52, 34);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(64, 13);
            this.label73.TabIndex = 21;
            this.label73.Text = "Curaga     %";
            this.label73.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Curagacount
            // 
            this.Curagacount.Enabled = false;
            this.Curagacount.Location = new System.Drawing.Point(122, 32);
            this.Curagacount.Name = "Curagacount";
            this.Curagacount.Size = new System.Drawing.Size(44, 20);
            this.Curagacount.TabIndex = 20;
            // 
            // DrainAspirpage
            // 
            this.DrainAspirpage.Controls.Add(this.Aspirgroup);
            this.DrainAspirpage.Controls.Add(this.Draingroup);
            this.DrainAspirpage.Location = new System.Drawing.Point(4, 22);
            this.DrainAspirpage.Name = "DrainAspirpage";
            this.DrainAspirpage.Padding = new System.Windows.Forms.Padding(3);
            this.DrainAspirpage.Size = new System.Drawing.Size(402, 158);
            this.DrainAspirpage.TabIndex = 2;
            this.DrainAspirpage.Text = "Drain/Aspir";
            this.DrainAspirpage.UseVisualStyleBackColor = true;
            // 
            // Aspirgroup
            // 
            this.Aspirgroup.Controls.Add(this.AspirIIIcount);
            this.Aspirgroup.Controls.Add(this.AspirIIcount);
            this.Aspirgroup.Controls.Add(this.AspirIIItext);
            this.Aspirgroup.Controls.Add(this.AspirItext);
            this.Aspirgroup.Controls.Add(this.AspirIItext);
            this.Aspirgroup.Controls.Add(this.Aspircount);
            this.Aspirgroup.Location = new System.Drawing.Point(204, 10);
            this.Aspirgroup.Name = "Aspirgroup";
            this.Aspirgroup.Size = new System.Drawing.Size(139, 138);
            this.Aspirgroup.TabIndex = 1;
            this.Aspirgroup.TabStop = false;
            this.Aspirgroup.Text = "Aspir";
            // 
            // AspirIIIcount
            // 
            this.AspirIIIcount.Enabled = false;
            this.AspirIIIcount.Location = new System.Drawing.Point(78, 94);
            this.AspirIIIcount.Name = "AspirIIIcount";
            this.AspirIIIcount.Size = new System.Drawing.Size(41, 20);
            this.AspirIIIcount.TabIndex = 64;
            // 
            // AspirIIcount
            // 
            this.AspirIIcount.Enabled = false;
            this.AspirIIcount.Location = new System.Drawing.Point(78, 56);
            this.AspirIIcount.Name = "AspirIIcount";
            this.AspirIIcount.Size = new System.Drawing.Size(41, 20);
            this.AspirIIcount.TabIndex = 62;
            // 
            // AspirIIItext
            // 
            this.AspirIIItext.AutoSize = true;
            this.AspirIIItext.Location = new System.Drawing.Point(26, 94);
            this.AspirIIItext.Name = "AspirIIItext";
            this.AspirIIItext.Size = new System.Drawing.Size(27, 13);
            this.AspirIIItext.TabIndex = 63;
            this.AspirIIItext.Text = "III %";
            // 
            // AspirItext
            // 
            this.AspirItext.AutoSize = true;
            this.AspirItext.Location = new System.Drawing.Point(26, 21);
            this.AspirItext.Name = "AspirItext";
            this.AspirItext.Size = new System.Drawing.Size(27, 13);
            this.AspirItext.TabIndex = 57;
            this.AspirItext.Text = "I   %";
            // 
            // AspirIItext
            // 
            this.AspirIItext.AutoSize = true;
            this.AspirIItext.Location = new System.Drawing.Point(26, 56);
            this.AspirIItext.Name = "AspirIItext";
            this.AspirIItext.Size = new System.Drawing.Size(27, 13);
            this.AspirIItext.TabIndex = 58;
            this.AspirIItext.Text = "II  %";
            // 
            // Aspircount
            // 
            this.Aspircount.Enabled = false;
            this.Aspircount.Location = new System.Drawing.Point(78, 19);
            this.Aspircount.Name = "Aspircount";
            this.Aspircount.Size = new System.Drawing.Size(41, 20);
            this.Aspircount.TabIndex = 61;
            // 
            // Draingroup
            // 
            this.Draingroup.Controls.Add(this.DrainIItext);
            this.Draingroup.Controls.Add(this.Draincount);
            this.Draingroup.Controls.Add(this.DrainItext);
            this.Draingroup.Controls.Add(this.DrainIIItext);
            this.Draingroup.Controls.Add(this.DrainIIIcount);
            this.Draingroup.Controls.Add(this.DrainIIcount);
            this.Draingroup.Location = new System.Drawing.Point(59, 10);
            this.Draingroup.Name = "Draingroup";
            this.Draingroup.Size = new System.Drawing.Size(139, 138);
            this.Draingroup.TabIndex = 0;
            this.Draingroup.TabStop = false;
            this.Draingroup.Text = "Drain";
            // 
            // DrainIItext
            // 
            this.DrainIItext.AutoSize = true;
            this.DrainIItext.Location = new System.Drawing.Point(17, 58);
            this.DrainIItext.Name = "DrainIItext";
            this.DrainIItext.Size = new System.Drawing.Size(27, 13);
            this.DrainIItext.TabIndex = 55;
            this.DrainIItext.Text = "II  %";
            // 
            // Draincount
            // 
            this.Draincount.Enabled = false;
            this.Draincount.Location = new System.Drawing.Point(69, 19);
            this.Draincount.Name = "Draincount";
            this.Draincount.Size = new System.Drawing.Size(41, 20);
            this.Draincount.TabIndex = 53;
            // 
            // DrainItext
            // 
            this.DrainItext.AutoSize = true;
            this.DrainItext.Location = new System.Drawing.Point(17, 21);
            this.DrainItext.Name = "DrainItext";
            this.DrainItext.Size = new System.Drawing.Size(27, 13);
            this.DrainItext.TabIndex = 54;
            this.DrainItext.Text = "I   %";
            // 
            // DrainIIItext
            // 
            this.DrainIIItext.AutoSize = true;
            this.DrainIIItext.Location = new System.Drawing.Point(17, 94);
            this.DrainIIItext.Name = "DrainIIItext";
            this.DrainIIItext.Size = new System.Drawing.Size(27, 13);
            this.DrainIIItext.TabIndex = 56;
            this.DrainIIItext.Text = "III %";
            // 
            // DrainIIIcount
            // 
            this.DrainIIIcount.Enabled = false;
            this.DrainIIIcount.Location = new System.Drawing.Point(69, 92);
            this.DrainIIIcount.Name = "DrainIIIcount";
            this.DrainIIIcount.Size = new System.Drawing.Size(41, 20);
            this.DrainIIIcount.TabIndex = 60;
            // 
            // DrainIIcount
            // 
            this.DrainIIcount.Enabled = false;
            this.DrainIIcount.Location = new System.Drawing.Point(69, 56);
            this.DrainIIcount.Name = "DrainIIcount";
            this.DrainIIcount.Size = new System.Drawing.Size(41, 20);
            this.DrainIIcount.TabIndex = 59;
            // 
            // BLUCurespage
            // 
            this.BLUCurespage.Controls.Add(this.MagicFruitcount);
            this.BLUCurespage.Controls.Add(this.Pollencount);
            this.BLUCurespage.Controls.Add(this.HealingBreezecount);
            this.BLUCurespage.Controls.Add(this.PleniluneEmbracecount);
            this.BLUCurespage.Controls.Add(this.Restoralcount);
            this.BLUCurespage.Controls.Add(this.WhiteWindcount);
            this.BLUCurespage.Controls.Add(this.Exuviationcount);
            this.BLUCurespage.Controls.Add(this.WildCarrotcount);
            this.BLUCurespage.Controls.Add(this.PleniluneEmbracetext);
            this.BLUCurespage.Controls.Add(this.MagicFruittext);
            this.BLUCurespage.Controls.Add(this.HealingBreezetext);
            this.BLUCurespage.Controls.Add(this.Pollentext);
            this.BLUCurespage.Controls.Add(this.WhiteWindtext);
            this.BLUCurespage.Controls.Add(this.Restoraltext);
            this.BLUCurespage.Controls.Add(this.Exuviationtext);
            this.BLUCurespage.Controls.Add(this.WildCarrottext);
            this.BLUCurespage.Location = new System.Drawing.Point(4, 22);
            this.BLUCurespage.Name = "BLUCurespage";
            this.BLUCurespage.Padding = new System.Windows.Forms.Padding(3);
            this.BLUCurespage.Size = new System.Drawing.Size(402, 158);
            this.BLUCurespage.TabIndex = 3;
            this.BLUCurespage.Text = "BLU Cures";
            this.BLUCurespage.UseVisualStyleBackColor = true;
            // 
            // MagicFruitcount
            // 
            this.MagicFruitcount.Enabled = false;
            this.MagicFruitcount.Location = new System.Drawing.Point(172, 53);
            this.MagicFruitcount.Name = "MagicFruitcount";
            this.MagicFruitcount.Size = new System.Drawing.Size(44, 20);
            this.MagicFruitcount.TabIndex = 15;
            // 
            // Pollencount
            // 
            this.Pollencount.Enabled = false;
            this.Pollencount.Location = new System.Drawing.Point(172, 20);
            this.Pollencount.Name = "Pollencount";
            this.Pollencount.Size = new System.Drawing.Size(44, 20);
            this.Pollencount.TabIndex = 14;
            // 
            // HealingBreezecount
            // 
            this.HealingBreezecount.Enabled = false;
            this.HealingBreezecount.Location = new System.Drawing.Point(172, 86);
            this.HealingBreezecount.Name = "HealingBreezecount";
            this.HealingBreezecount.Size = new System.Drawing.Size(44, 20);
            this.HealingBreezecount.TabIndex = 13;
            // 
            // PleniluneEmbracecount
            // 
            this.PleniluneEmbracecount.Enabled = false;
            this.PleniluneEmbracecount.Location = new System.Drawing.Point(172, 119);
            this.PleniluneEmbracecount.Name = "PleniluneEmbracecount";
            this.PleniluneEmbracecount.Size = new System.Drawing.Size(44, 20);
            this.PleniluneEmbracecount.TabIndex = 12;
            // 
            // Restoralcount
            // 
            this.Restoralcount.Enabled = false;
            this.Restoralcount.Location = new System.Drawing.Point(301, 53);
            this.Restoralcount.Name = "Restoralcount";
            this.Restoralcount.Size = new System.Drawing.Size(44, 20);
            this.Restoralcount.TabIndex = 11;
            // 
            // WhiteWindcount
            // 
            this.WhiteWindcount.Enabled = false;
            this.WhiteWindcount.Location = new System.Drawing.Point(301, 20);
            this.WhiteWindcount.Name = "WhiteWindcount";
            this.WhiteWindcount.Size = new System.Drawing.Size(44, 20);
            this.WhiteWindcount.TabIndex = 10;
            // 
            // Exuviationcount
            // 
            this.Exuviationcount.Enabled = false;
            this.Exuviationcount.Location = new System.Drawing.Point(301, 86);
            this.Exuviationcount.Name = "Exuviationcount";
            this.Exuviationcount.Size = new System.Drawing.Size(44, 20);
            this.Exuviationcount.TabIndex = 9;
            // 
            // WildCarrotcount
            // 
            this.WildCarrotcount.Enabled = false;
            this.WildCarrotcount.Location = new System.Drawing.Point(301, 119);
            this.WildCarrotcount.Name = "WildCarrotcount";
            this.WildCarrotcount.Size = new System.Drawing.Size(44, 20);
            this.WildCarrotcount.TabIndex = 8;
            // 
            // PleniluneEmbracetext
            // 
            this.PleniluneEmbracetext.AutoSize = true;
            this.PleniluneEmbracetext.Location = new System.Drawing.Point(57, 121);
            this.PleniluneEmbracetext.Name = "PleniluneEmbracetext";
            this.PleniluneEmbracetext.Size = new System.Drawing.Size(109, 13);
            this.PleniluneEmbracetext.TabIndex = 5;
            this.PleniluneEmbracetext.Text = "Plenilune Embrace @";
            // 
            // MagicFruittext
            // 
            this.MagicFruittext.AutoSize = true;
            this.MagicFruittext.Location = new System.Drawing.Point(93, 55);
            this.MagicFruittext.Name = "MagicFruittext";
            this.MagicFruittext.Size = new System.Drawing.Size(73, 13);
            this.MagicFruittext.TabIndex = 3;
            this.MagicFruittext.Text = "Magic Fruit @";
            // 
            // HealingBreezetext
            // 
            this.HealingBreezetext.AutoSize = true;
            this.HealingBreezetext.Location = new System.Drawing.Point(73, 88);
            this.HealingBreezetext.Name = "HealingBreezetext";
            this.HealingBreezetext.Size = new System.Drawing.Size(93, 13);
            this.HealingBreezetext.TabIndex = 2;
            this.HealingBreezetext.Text = "Healing Breeze @";
            // 
            // Pollentext
            // 
            this.Pollentext.AutoSize = true;
            this.Pollentext.Location = new System.Drawing.Point(116, 22);
            this.Pollentext.Name = "Pollentext";
            this.Pollentext.Size = new System.Drawing.Size(50, 13);
            this.Pollentext.TabIndex = 0;
            this.Pollentext.Text = "Pollen @";
            // 
            // WhiteWindtext
            // 
            this.WhiteWindtext.AutoSize = true;
            this.WhiteWindtext.Location = new System.Drawing.Point(218, 22);
            this.WhiteWindtext.Name = "WhiteWindtext";
            this.WhiteWindtext.Size = new System.Drawing.Size(77, 13);
            this.WhiteWindtext.TabIndex = 6;
            this.WhiteWindtext.Text = "White Wind @";
            // 
            // Restoraltext
            // 
            this.Restoraltext.AutoSize = true;
            this.Restoraltext.Location = new System.Drawing.Point(235, 55);
            this.Restoraltext.Name = "Restoraltext";
            this.Restoraltext.Size = new System.Drawing.Size(60, 13);
            this.Restoraltext.TabIndex = 7;
            this.Restoraltext.Text = "Restoral @";
            // 
            // Exuviationtext
            // 
            this.Exuviationtext.AutoSize = true;
            this.Exuviationtext.Location = new System.Drawing.Point(225, 88);
            this.Exuviationtext.Name = "Exuviationtext";
            this.Exuviationtext.Size = new System.Drawing.Size(70, 13);
            this.Exuviationtext.TabIndex = 4;
            this.Exuviationtext.Text = "Exuviation @";
            // 
            // WildCarrottext
            // 
            this.WildCarrottext.AutoSize = true;
            this.WildCarrottext.Location = new System.Drawing.Point(225, 121);
            this.WildCarrottext.Name = "WildCarrottext";
            this.WildCarrottext.Size = new System.Drawing.Size(73, 13);
            this.WildCarrottext.TabIndex = 1;
            this.WildCarrottext.Text = "Wild Carrot @";
            // 
            // MAconfigpage
            // 
            this.MAconfigpage.Controls.Add(this.label10);
            this.MAconfigpage.Controls.Add(this.MAreverse);
            this.MAconfigpage.Location = new System.Drawing.Point(4, 22);
            this.MAconfigpage.Name = "MAconfigpage";
            this.MAconfigpage.Padding = new System.Windows.Forms.Padding(3);
            this.MAconfigpage.Size = new System.Drawing.Size(402, 158);
            this.MAconfigpage.TabIndex = 4;
            this.MAconfigpage.Text = "MAconfig";
            this.MAconfigpage.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(102, 75);
            this.label10.MaximumSize = new System.Drawing.Size(200, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(199, 26);
            this.label10.TabIndex = 1;
            this.label10.Text = "This will cause all magic to run in reverse of the way its listed on the Select t" +
    "ab.";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MAreverse
            // 
            this.MAreverse.AutoSize = true;
            this.MAreverse.Location = new System.Drawing.Point(138, 52);
            this.MAreverse.Name = "MAreverse";
            this.MAreverse.Size = new System.Drawing.Size(126, 17);
            this.MAreverse.TabIndex = 0;
            this.MAreverse.Text = "Run magin in reverse";
            this.MAreverse.UseVisualStyleBackColor = true;
            // 
            // Dynamispage
            // 
            this.Dynamispage.Controls.Add(this.groupBox13);
            this.Dynamispage.Controls.Add(this.Dynatxt);
            this.Dynamispage.Controls.Add(this.staggerstopJA);
            this.Dynamispage.Location = new System.Drawing.Point(4, 22);
            this.Dynamispage.Name = "Dynamispage";
            this.Dynamispage.Padding = new System.Windows.Forms.Padding(3);
            this.Dynamispage.Size = new System.Drawing.Size(419, 197);
            this.Dynamispage.TabIndex = 5;
            this.Dynamispage.Text = "Dynamis";
            this.Dynamispage.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.NoneProcuse);
            this.groupBox13.Controls.Add(this.DynaProccontrole);
            this.groupBox13.Controls.Add(this.label59);
            this.groupBox13.Location = new System.Drawing.Point(60, 52);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(299, 102);
            this.groupBox13.TabIndex = 3;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Proc Control";
            // 
            // NoneProcuse
            // 
            this.NoneProcuse.AutoSize = true;
            this.NoneProcuse.Enabled = false;
            this.NoneProcuse.Location = new System.Drawing.Point(43, 79);
            this.NoneProcuse.Name = "NoneProcuse";
            this.NoneProcuse.Size = new System.Drawing.Size(213, 17);
            this.NoneProcuse.TabIndex = 6;
            this.NoneProcuse.Text = "Use Proc Skills on none Procable Mobs";
            this.NoneProcuse.UseVisualStyleBackColor = true;
            this.NoneProcuse.CheckedChanged += new System.EventHandler(this.NoneProcuse_CheckedChanged);
            // 
            // DynaProccontrole
            // 
            this.DynaProccontrole.AutoSize = true;
            this.DynaProccontrole.Location = new System.Drawing.Point(59, 20);
            this.DynaProccontrole.Name = "DynaProccontrole";
            this.DynaProccontrole.Size = new System.Drawing.Size(181, 17);
            this.DynaProccontrole.TabIndex = 3;
            this.DynaProccontrole.Text = "WS/JA/MA Stop Based On Mob";
            this.DynaProccontrole.UseVisualStyleBackColor = true;
            this.DynaProccontrole.CheckedChanged += new System.EventHandler(this.DynaProccontrole_CheckedChanged);
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(23, 40);
            this.label59.MaximumSize = new System.Drawing.Size(253, 0);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(253, 26);
            this.label59.TabIndex = 4;
            this.label59.Text = "This will force you to not use non proc skills if it wont proc the current traget" +
    ".";
            this.label59.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Dynatxt
            // 
            this.Dynatxt.AutoSize = true;
            this.Dynatxt.Location = new System.Drawing.Point(65, 36);
            this.Dynatxt.Name = "Dynatxt";
            this.Dynatxt.Size = new System.Drawing.Size(288, 13);
            this.Dynatxt.TabIndex = 2;
            this.Dynatxt.Text = "This will stop all JA\'s when a mob is !Staggered! in Dynamis.";
            // 
            // staggerstopJA
            // 
            this.staggerstopJA.AutoSize = true;
            this.staggerstopJA.Location = new System.Drawing.Point(133, 14);
            this.staggerstopJA.Name = "staggerstopJA";
            this.staggerstopJA.Size = new System.Drawing.Size(153, 17);
            this.staggerstopJA.TabIndex = 1;
            this.staggerstopJA.Text = "Stop Ja\'s When Staggered";
            this.staggerstopJA.UseVisualStyleBackColor = true;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.delaytext);
            this.groupBox14.Controls.Add(this.pullDelay);
            this.groupBox14.Controls.Add(this.AutoLock);
            this.groupBox14.Controls.Add(this.mobheightdistValue);
            this.groupBox14.Controls.Add(this.mobheightdist);
            this.groupBox14.Controls.Add(this.runTarget);
            this.groupBox14.Controls.Add(this.runPullDistance);
            this.groupBox14.Controls.Add(this.mobsearchdisttext);
            this.groupBox14.Controls.Add(this.targetSearchDist);
            this.groupBox14.Controls.Add(this.pullTolorance);
            this.groupBox14.Controls.Add(this.pulltolorancetext);
            this.groupBox14.Controls.Add(this.numericUpDown21);
            this.groupBox14.Controls.Add(this.pulldistance);
            this.groupBox14.Controls.Add(this.pullCommand);
            this.groupBox14.Controls.Add(this.pullcommandtext);
            this.groupBox14.Location = new System.Drawing.Point(45, 6);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(335, 119);
            this.groupBox14.TabIndex = 21;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Pull Options";
            // 
            // delaytext
            // 
            this.delaytext.AutoSize = true;
            this.delaytext.Location = new System.Drawing.Point(244, 20);
            this.delaytext.Name = "delaytext";
            this.delaytext.Size = new System.Drawing.Size(37, 13);
            this.delaytext.TabIndex = 55;
            this.delaytext.Text = "Delay:";
            // 
            // pullDelay
            // 
            this.pullDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pullDelay.DecimalPlaces = 1;
            this.pullDelay.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.pullDelay.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.pullDelay.Location = new System.Drawing.Point(282, 17);
            this.pullDelay.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.pullDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pullDelay.Name = "pullDelay";
            this.pullDelay.Size = new System.Drawing.Size(44, 20);
            this.pullDelay.TabIndex = 54;
            this.pullDelay.TabStop = false;
            this.pullDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pullDelay.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // AutoLock
            // 
            this.AutoLock.AutoSize = true;
            this.AutoLock.Location = new System.Drawing.Point(172, 77);
            this.AutoLock.Name = "AutoLock";
            this.AutoLock.Size = new System.Drawing.Size(109, 17);
            this.AutoLock.TabIndex = 53;
            this.AutoLock.Text = "Auto-Lock Target";
            this.AutoLock.UseVisualStyleBackColor = true;
            // 
            // mobheightdistValue
            // 
            this.mobheightdistValue.DecimalPlaces = 1;
            this.mobheightdistValue.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.mobheightdistValue.Location = new System.Drawing.Point(282, 91);
            this.mobheightdistValue.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.mobheightdistValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mobheightdistValue.Name = "mobheightdistValue";
            this.mobheightdistValue.Size = new System.Drawing.Size(44, 20);
            this.mobheightdistValue.TabIndex = 52;
            this.mobheightdistValue.TabStop = false;
            this.mobheightdistValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mobheightdistValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // mobheightdist
            // 
            this.mobheightdist.AutoSize = true;
            this.mobheightdist.Location = new System.Drawing.Point(172, 93);
            this.mobheightdist.Name = "mobheightdist";
            this.mobheightdist.Size = new System.Drawing.Size(105, 17);
            this.mobheightdist.TabIndex = 51;
            this.mobheightdist.Text = "Mob Height Dist.";
            this.mobheightdist.UseVisualStyleBackColor = true;
            // 
            // runTarget
            // 
            this.runTarget.AutoSize = true;
            this.runTarget.Location = new System.Drawing.Point(172, 61);
            this.runTarget.Name = "runTarget";
            this.runTarget.Size = new System.Drawing.Size(155, 17);
            this.runTarget.TabIndex = 50;
            this.runTarget.Text = "Run to Target (after pulling)";
            this.runTarget.UseVisualStyleBackColor = true;
            // 
            // runPullDistance
            // 
            this.runPullDistance.AutoSize = true;
            this.runPullDistance.Location = new System.Drawing.Point(172, 45);
            this.runPullDistance.Name = "runPullDistance";
            this.runPullDistance.Size = new System.Drawing.Size(123, 17);
            this.runPullDistance.TabIndex = 49;
            this.runPullDistance.Text = "Run to Pull Distance";
            this.runPullDistance.UseVisualStyleBackColor = true;
            // 
            // mobsearchdisttext
            // 
            this.mobsearchdisttext.AutoSize = true;
            this.mobsearchdisttext.Location = new System.Drawing.Point(21, 93);
            this.mobsearchdisttext.Name = "mobsearchdisttext";
            this.mobsearchdisttext.Size = new System.Drawing.Size(89, 13);
            this.mobsearchdisttext.TabIndex = 48;
            this.mobsearchdisttext.Text = "Mob Search Dist.";
            // 
            // targetSearchDist
            // 
            this.targetSearchDist.DecimalPlaces = 1;
            this.targetSearchDist.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.targetSearchDist.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.targetSearchDist.Location = new System.Drawing.Point(110, 90);
            this.targetSearchDist.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.targetSearchDist.Name = "targetSearchDist";
            this.targetSearchDist.Size = new System.Drawing.Size(44, 20);
            this.targetSearchDist.TabIndex = 47;
            this.targetSearchDist.TabStop = false;
            this.targetSearchDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.targetSearchDist.Value = new decimal(new int[] {
            245,
            0,
            0,
            65536});
            // 
            // pullTolorance
            // 
            this.pullTolorance.DecimalPlaces = 1;
            this.pullTolorance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.pullTolorance.Location = new System.Drawing.Point(110, 68);
            this.pullTolorance.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.pullTolorance.Name = "pullTolorance";
            this.pullTolorance.Size = new System.Drawing.Size(44, 20);
            this.pullTolorance.TabIndex = 43;
            this.pullTolorance.TabStop = false;
            this.pullTolorance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pullTolorance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pulltolorancetext
            // 
            this.pulltolorancetext.AutoSize = true;
            this.pulltolorancetext.Location = new System.Drawing.Point(21, 70);
            this.pulltolorancetext.Name = "pulltolorancetext";
            this.pulltolorancetext.Size = new System.Drawing.Size(75, 13);
            this.pulltolorancetext.TabIndex = 10;
            this.pulltolorancetext.Text = "Pull Tolorance";
            // 
            // numericUpDown21
            // 
            this.numericUpDown21.DecimalPlaces = 1;
            this.numericUpDown21.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown21.Location = new System.Drawing.Point(110, 45);
            this.numericUpDown21.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown21.Name = "numericUpDown21";
            this.numericUpDown21.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown21.TabIndex = 9;
            this.numericUpDown21.TabStop = false;
            this.numericUpDown21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown21.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // pulldistance
            // 
            this.pulldistance.AutoSize = true;
            this.pulldistance.Location = new System.Drawing.Point(21, 48);
            this.pulldistance.Name = "pulldistance";
            this.pulldistance.Size = new System.Drawing.Size(69, 13);
            this.pulldistance.TabIndex = 8;
            this.pulldistance.Text = "Pull Distance";
            // 
            // pullCommand
            // 
            this.pullCommand.Location = new System.Drawing.Point(110, 19);
            this.pullCommand.Name = "pullCommand";
            this.pullCommand.Size = new System.Drawing.Size(132, 20);
            this.pullCommand.TabIndex = 7;
            this.pullCommand.TabStop = false;
            this.pullCommand.Text = "/ra <t>";
            // 
            // pullcommandtext
            // 
            this.pullcommandtext.AutoSize = true;
            this.pullcommandtext.Location = new System.Drawing.Point(21, 20);
            this.pullcommandtext.Name = "pullcommandtext";
            this.pullcommandtext.Size = new System.Drawing.Size(74, 13);
            this.pullcommandtext.TabIndex = 6;
            this.pullcommandtext.Text = "Pull Command";
            // 
            // dancer
            // 
            this.dancer.Controls.Add(this.tabControl3);
            this.dancer.Controls.Add(this.label15);
            this.dancer.Location = new System.Drawing.Point(4, 22);
            this.dancer.Name = "dancer";
            this.dancer.Padding = new System.Windows.Forms.Padding(3);
            this.dancer.Size = new System.Drawing.Size(439, 361);
            this.dancer.TabIndex = 0;
            this.dancer.Text = "Sambas/Steps/Waltz";
            this.dancer.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage14);
            this.tabControl3.Controls.Add(this.tabPage15);
            this.tabControl3.Controls.Add(this.tabPage16);
            this.tabControl3.Location = new System.Drawing.Point(7, 82);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(426, 263);
            this.tabControl3.TabIndex = 8;
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.groupBox1);
            this.tabPage14.Controls.Add(this.groupBox3);
            this.tabPage14.Location = new System.Drawing.Point(4, 22);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage14.Size = new System.Drawing.Size(418, 237);
            this.tabPage14.TabIndex = 0;
            this.tabPage14.Text = "Sambas/Steps";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.noSamba);
            this.groupBox1.Controls.Add(this.usedrainiii);
            this.groupBox1.Controls.Add(this.usehaste);
            this.groupBox1.Controls.Add(this.useaspirii);
            this.groupBox1.Controls.Add(this.useaspir);
            this.groupBox1.Controls.Add(this.usedrainii);
            this.groupBox1.Controls.Add(this.usedrain);
            this.groupBox1.Location = new System.Drawing.Point(16, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 165);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Samba\'s";
            // 
            // noSamba
            // 
            this.noSamba.AutoSize = true;
            this.noSamba.Enabled = false;
            this.noSamba.Location = new System.Drawing.Point(19, 138);
            this.noSamba.Name = "noSamba";
            this.noSamba.Size = new System.Drawing.Size(108, 17);
            this.noSamba.TabIndex = 4;
            this.noSamba.TabStop = true;
            this.noSamba.Text = "Don\'t Use Samba";
            this.noSamba.UseVisualStyleBackColor = true;
            // 
            // usedrainiii
            // 
            this.usedrainiii.AutoSize = true;
            this.usedrainiii.Enabled = false;
            this.usedrainiii.Location = new System.Drawing.Point(19, 58);
            this.usedrainiii.Name = "usedrainiii";
            this.usedrainiii.Size = new System.Drawing.Size(98, 17);
            this.usedrainiii.TabIndex = 2;
            this.usedrainiii.TabStop = true;
            this.usedrainiii.Text = "Drain Samba III";
            this.usedrainiii.UseVisualStyleBackColor = true;
            // 
            // usehaste
            // 
            this.usehaste.AutoSize = true;
            this.usehaste.Enabled = false;
            this.usehaste.Location = new System.Drawing.Point(19, 118);
            this.usehaste.Name = "usehaste";
            this.usehaste.Size = new System.Drawing.Size(89, 17);
            this.usehaste.TabIndex = 4;
            this.usehaste.TabStop = true;
            this.usehaste.Text = "Haste Samba";
            this.usehaste.UseVisualStyleBackColor = true;
            // 
            // useaspirii
            // 
            this.useaspirii.AutoSize = true;
            this.useaspirii.Enabled = false;
            this.useaspirii.Location = new System.Drawing.Point(19, 98);
            this.useaspirii.Name = "useaspirii";
            this.useaspirii.Size = new System.Drawing.Size(93, 17);
            this.useaspirii.TabIndex = 3;
            this.useaspirii.TabStop = true;
            this.useaspirii.Text = "Aspir Samba II";
            this.useaspirii.UseVisualStyleBackColor = true;
            // 
            // useaspir
            // 
            this.useaspir.AutoSize = true;
            this.useaspir.Enabled = false;
            this.useaspir.Location = new System.Drawing.Point(19, 78);
            this.useaspir.Name = "useaspir";
            this.useaspir.Size = new System.Drawing.Size(84, 17);
            this.useaspir.TabIndex = 2;
            this.useaspir.TabStop = true;
            this.useaspir.Text = "Aspir Samba";
            this.useaspir.UseVisualStyleBackColor = true;
            // 
            // usedrainii
            // 
            this.usedrainii.AutoSize = true;
            this.usedrainii.Enabled = false;
            this.usedrainii.Location = new System.Drawing.Point(19, 38);
            this.usedrainii.Name = "usedrainii";
            this.usedrainii.Size = new System.Drawing.Size(95, 17);
            this.usedrainii.TabIndex = 1;
            this.usedrainii.TabStop = true;
            this.usedrainii.Text = "Drain Samba II";
            this.usedrainii.UseVisualStyleBackColor = true;
            // 
            // usedrain
            // 
            this.usedrain.AutoSize = true;
            this.usedrain.Enabled = false;
            this.usedrain.Location = new System.Drawing.Point(19, 18);
            this.usedrain.Name = "usedrain";
            this.usedrain.Size = new System.Drawing.Size(86, 17);
            this.usedrain.TabIndex = 0;
            this.usedrain.TabStop = true;
            this.usedrain.Text = "Drain Samba";
            this.usedrain.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.stopstepsat);
            this.groupBox3.Controls.Add(this.stopstepscount);
            this.groupBox3.Controls.Add(this.stopstepsathptext);
            this.groupBox3.Controls.Add(this.usefeatherstepValue);
            this.groupBox3.Controls.Add(this.usestutterstepValue);
            this.groupBox3.Controls.Add(this.useboxstepValue);
            this.groupBox3.Controls.Add(this.StepsHPValue);
            this.groupBox3.Controls.Add(this.usequickstepValue);
            this.groupBox3.Controls.Add(this.StepsHP);
            this.groupBox3.Controls.Add(this.NoSteps);
            this.groupBox3.Controls.Add(this.usequickstep);
            this.groupBox3.Controls.Add(this.useboxstep);
            this.groupBox3.Controls.Add(this.usestutterstep);
            this.groupBox3.Controls.Add(this.usefeatherstep);
            this.groupBox3.Location = new System.Drawing.Point(212, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(190, 182);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Steps";
            // 
            // stopstepsat
            // 
            this.stopstepsat.AutoSize = true;
            this.stopstepsat.Enabled = false;
            this.stopstepsat.Location = new System.Drawing.Point(14, 24);
            this.stopstepsat.Name = "stopstepsat";
            this.stopstepsat.Size = new System.Drawing.Size(88, 17);
            this.stopstepsat.TabIndex = 17;
            this.stopstepsat.Text = "Stop Steps #";
            this.stopstepsat.UseVisualStyleBackColor = true;
            // 
            // stopstepscount
            // 
            this.stopstepscount.Enabled = false;
            this.stopstepscount.Location = new System.Drawing.Point(130, 23);
            this.stopstepscount.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.stopstepscount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stopstepscount.Name = "stopstepscount";
            this.stopstepscount.Size = new System.Drawing.Size(34, 20);
            this.stopstepscount.TabIndex = 16;
            this.stopstepscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.stopstepscount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // stopstepsathptext
            // 
            this.stopstepsathptext.AutoSize = true;
            this.stopstepsathptext.Enabled = false;
            this.stopstepsathptext.Location = new System.Drawing.Point(154, 157);
            this.stopstepsathptext.Name = "stopstepsathptext";
            this.stopstepsathptext.Size = new System.Drawing.Size(30, 13);
            this.stopstepsathptext.TabIndex = 10;
            this.stopstepsathptext.Text = "HP%";
            // 
            // usefeatherstepValue
            // 
            this.usefeatherstepValue.Enabled = false;
            this.usefeatherstepValue.Location = new System.Drawing.Point(130, 111);
            this.usefeatherstepValue.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.usefeatherstepValue.Name = "usefeatherstepValue";
            this.usefeatherstepValue.Size = new System.Drawing.Size(34, 20);
            this.usefeatherstepValue.TabIndex = 14;
            this.usefeatherstepValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // usestutterstepValue
            // 
            this.usestutterstepValue.Enabled = false;
            this.usestutterstepValue.Location = new System.Drawing.Point(130, 89);
            this.usestutterstepValue.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.usestutterstepValue.Name = "usestutterstepValue";
            this.usestutterstepValue.Size = new System.Drawing.Size(34, 20);
            this.usestutterstepValue.TabIndex = 13;
            this.usestutterstepValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // useboxstepValue
            // 
            this.useboxstepValue.Enabled = false;
            this.useboxstepValue.Location = new System.Drawing.Point(130, 67);
            this.useboxstepValue.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.useboxstepValue.Name = "useboxstepValue";
            this.useboxstepValue.Size = new System.Drawing.Size(34, 20);
            this.useboxstepValue.TabIndex = 12;
            this.useboxstepValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StepsHPValue
            // 
            this.StepsHPValue.Enabled = false;
            this.StepsHPValue.Location = new System.Drawing.Point(114, 155);
            this.StepsHPValue.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.StepsHPValue.Name = "StepsHPValue";
            this.StepsHPValue.Size = new System.Drawing.Size(34, 20);
            this.StepsHPValue.TabIndex = 9;
            this.StepsHPValue.TabStop = false;
            this.StepsHPValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StepsHPValue.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // usequickstepValue
            // 
            this.usequickstepValue.Enabled = false;
            this.usequickstepValue.Location = new System.Drawing.Point(130, 45);
            this.usequickstepValue.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.usequickstepValue.Name = "usequickstepValue";
            this.usequickstepValue.Size = new System.Drawing.Size(34, 20);
            this.usequickstepValue.TabIndex = 11;
            this.usequickstepValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StepsHP
            // 
            this.StepsHP.AutoSize = true;
            this.StepsHP.Enabled = false;
            this.StepsHP.Location = new System.Drawing.Point(6, 158);
            this.StepsHP.Name = "StepsHP";
            this.StepsHP.Size = new System.Drawing.Size(112, 17);
            this.StepsHP.TabIndex = 8;
            this.StepsHP.Text = "Don\'t Use Steps <";
            this.StepsHP.UseVisualStyleBackColor = true;
            // 
            // NoSteps
            // 
            this.NoSteps.AutoSize = true;
            this.NoSteps.Enabled = false;
            this.NoSteps.Location = new System.Drawing.Point(14, 135);
            this.NoSteps.Name = "NoSteps";
            this.NoSteps.Size = new System.Drawing.Size(102, 17);
            this.NoSteps.TabIndex = 10;
            this.NoSteps.TabStop = true;
            this.NoSteps.Text = "Don\'t Use Steps";
            this.NoSteps.UseVisualStyleBackColor = true;
            // 
            // usequickstep
            // 
            this.usequickstep.AutoSize = true;
            this.usequickstep.Enabled = false;
            this.usequickstep.Location = new System.Drawing.Point(14, 42);
            this.usequickstep.Name = "usequickstep";
            this.usequickstep.Size = new System.Drawing.Size(75, 17);
            this.usequickstep.TabIndex = 2;
            this.usequickstep.TabStop = true;
            this.usequickstep.Text = "QuickStep";
            this.usequickstep.UseVisualStyleBackColor = true;
            // 
            // useboxstep
            // 
            this.useboxstep.AutoSize = true;
            this.useboxstep.Enabled = false;
            this.useboxstep.Location = new System.Drawing.Point(14, 67);
            this.useboxstep.Name = "useboxstep";
            this.useboxstep.Size = new System.Drawing.Size(65, 17);
            this.useboxstep.TabIndex = 3;
            this.useboxstep.TabStop = true;
            this.useboxstep.Text = "BoxStep";
            this.useboxstep.UseVisualStyleBackColor = true;
            // 
            // usestutterstep
            // 
            this.usestutterstep.AutoSize = true;
            this.usestutterstep.Enabled = false;
            this.usestutterstep.Location = new System.Drawing.Point(14, 89);
            this.usestutterstep.Name = "usestutterstep";
            this.usestutterstep.Size = new System.Drawing.Size(78, 17);
            this.usestutterstep.TabIndex = 4;
            this.usestutterstep.TabStop = true;
            this.usestutterstep.Text = "StutterStep";
            this.usestutterstep.UseVisualStyleBackColor = true;
            // 
            // usefeatherstep
            // 
            this.usefeatherstep.AutoSize = true;
            this.usefeatherstep.Enabled = false;
            this.usefeatherstep.Location = new System.Drawing.Point(14, 111);
            this.usefeatherstep.Name = "usefeatherstep";
            this.usefeatherstep.Size = new System.Drawing.Size(83, 17);
            this.usefeatherstep.TabIndex = 5;
            this.usefeatherstep.TabStop = true;
            this.usefeatherstep.Text = "FeatherStep";
            this.usefeatherstep.UseVisualStyleBackColor = true;
            // 
            // tabPage15
            // 
            this.tabPage15.Controls.Add(this.groupBox7);
            this.tabPage15.Controls.Add(this.groupBox2);
            this.tabPage15.Location = new System.Drawing.Point(4, 22);
            this.tabPage15.Name = "tabPage15";
            this.tabPage15.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage15.Size = new System.Drawing.Size(418, 237);
            this.tabPage15.TabIndex = 1;
            this.tabPage15.Text = "Waltz";
            this.tabPage15.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.HWSelectDeselectALL);
            this.groupBox7.Controls.Add(this.HealingWaltzItems);
            this.groupBox7.Enabled = false;
            this.groupBox7.Location = new System.Drawing.Point(212, 35);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(190, 167);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Healing Waltz";
            // 
            // HWSelectDeselectALL
            // 
            this.HWSelectDeselectALL.AutoSize = true;
            this.HWSelectDeselectALL.Location = new System.Drawing.Point(6, 145);
            this.HWSelectDeselectALL.Name = "HWSelectDeselectALL";
            this.HWSelectDeselectALL.Size = new System.Drawing.Size(125, 17);
            this.HWSelectDeselectALL.TabIndex = 1;
            this.HWSelectDeselectALL.Text = "Select/Deselect ALL";
            this.HWSelectDeselectALL.UseVisualStyleBackColor = false;
            this.HWSelectDeselectALL.CheckedChanged += new System.EventHandler(this.HWSelectDeselectALLCheckedChanged);
            // 
            // HealingWaltzItems
            // 
            this.HealingWaltzItems.FormattingEnabled = true;
            this.HealingWaltzItems.Items.AddRange(new object[] {
            "ACC Down",
            "AGI Down",
            "ATT Down",
            "Bane",
            "Bind",
            "Bio",
            "Blind",
            "Burn",
            "Choke",
            "CHR Down",
            "Curse",
            "DEF Down",
            "DEX Down",
            "Dia",
            "Disease",
            "Drown",
            "EVA Down",
            "Frost",
            "Gravity",
            "Helix",
            "HP Down",
            "INT Down",
            "MACC Down",
            "MATT Down",
            "MDEF Down",
            "MEVA Down",
            "MND Down",
            "MP Down",
            "Paralyze",
            "Plague",
            "Poison",
            "Rasp",
            "Shock",
            "Silence",
            "Slow",
            "STR Down",
            "TP Down",
            "VIT Down"});
            this.HealingWaltzItems.Location = new System.Drawing.Point(6, 18);
            this.HealingWaltzItems.Name = "HealingWaltzItems";
            this.HealingWaltzItems.Size = new System.Drawing.Size(178, 124);
            this.HealingWaltzItems.Sorted = true;
            this.HealingWaltzItems.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label32);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.usecurevValue);
            this.groupBox2.Controls.Add(this.usecureivValue);
            this.groupBox2.Controls.Add(this.usecureiiiValue);
            this.groupBox2.Controls.Add(this.usecureiiValue);
            this.groupBox2.Controls.Add(this.usecureValue);
            this.groupBox2.Controls.Add(this.usecurev);
            this.groupBox2.Controls.Add(this.usecureiv);
            this.groupBox2.Controls.Add(this.usecureiii);
            this.groupBox2.Controls.Add(this.usecureii);
            this.groupBox2.Controls.Add(this.usecure);
            this.groupBox2.Location = new System.Drawing.Point(16, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(190, 167);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Curing Waltz";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(166, 123);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(15, 13);
            this.label32.TabIndex = 61;
            this.label32.Text = "%";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(166, 101);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(15, 13);
            this.label31.TabIndex = 60;
            this.label31.Text = "%";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(166, 77);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(15, 13);
            this.label30.TabIndex = 59;
            this.label30.Text = "%";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(166, 55);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(15, 13);
            this.label25.TabIndex = 59;
            this.label25.Text = "%";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(166, 32);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(15, 13);
            this.label17.TabIndex = 58;
            this.label17.Text = "%";
            // 
            // usecurevValue
            // 
            this.usecurevValue.Enabled = false;
            this.usecurevValue.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.usecurevValue.Location = new System.Drawing.Point(122, 120);
            this.usecurevValue.Name = "usecurevValue";
            this.usecurevValue.Size = new System.Drawing.Size(41, 20);
            this.usecurevValue.TabIndex = 9;
            this.usecurevValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // usecureivValue
            // 
            this.usecureivValue.Enabled = false;
            this.usecureivValue.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.usecureivValue.Location = new System.Drawing.Point(122, 97);
            this.usecureivValue.Name = "usecureivValue";
            this.usecureivValue.Size = new System.Drawing.Size(41, 20);
            this.usecureivValue.TabIndex = 8;
            this.usecureivValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // usecureiiiValue
            // 
            this.usecureiiiValue.Enabled = false;
            this.usecureiiiValue.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.usecureiiiValue.Location = new System.Drawing.Point(122, 74);
            this.usecureiiiValue.Name = "usecureiiiValue";
            this.usecureiiiValue.Size = new System.Drawing.Size(41, 20);
            this.usecureiiiValue.TabIndex = 7;
            this.usecureiiiValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // usecureiiValue
            // 
            this.usecureiiValue.Enabled = false;
            this.usecureiiValue.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.usecureiiValue.Location = new System.Drawing.Point(122, 51);
            this.usecureiiValue.Name = "usecureiiValue";
            this.usecureiiValue.Size = new System.Drawing.Size(41, 20);
            this.usecureiiValue.TabIndex = 6;
            this.usecureiiValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // usecureValue
            // 
            this.usecureValue.Enabled = false;
            this.usecureValue.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.usecureValue.Location = new System.Drawing.Point(122, 28);
            this.usecureValue.Name = "usecureValue";
            this.usecureValue.Size = new System.Drawing.Size(41, 20);
            this.usecureValue.TabIndex = 5;
            this.usecureValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // usecurev
            // 
            this.usecurev.AutoSize = true;
            this.usecurev.Enabled = false;
            this.usecurev.Location = new System.Drawing.Point(15, 121);
            this.usecurev.Name = "usecurev";
            this.usecurev.Size = new System.Drawing.Size(96, 17);
            this.usecurev.TabIndex = 4;
            this.usecurev.Text = "Curing Waltz V";
            this.usecurev.UseVisualStyleBackColor = true;
            // 
            // usecureiv
            // 
            this.usecureiv.AutoSize = true;
            this.usecureiv.Enabled = false;
            this.usecureiv.Location = new System.Drawing.Point(15, 98);
            this.usecureiv.Name = "usecureiv";
            this.usecureiv.Size = new System.Drawing.Size(99, 17);
            this.usecureiv.TabIndex = 3;
            this.usecureiv.Text = "Curing Waltz IV";
            this.usecureiv.UseVisualStyleBackColor = true;
            // 
            // usecureiii
            // 
            this.usecureiii.AutoSize = true;
            this.usecureiii.Enabled = false;
            this.usecureiii.Location = new System.Drawing.Point(15, 75);
            this.usecureiii.Name = "usecureiii";
            this.usecureiii.Size = new System.Drawing.Size(98, 17);
            this.usecureiii.TabIndex = 2;
            this.usecureiii.Text = "Curing Waltz III";
            this.usecureiii.UseVisualStyleBackColor = true;
            // 
            // usecureii
            // 
            this.usecureii.AutoSize = true;
            this.usecureii.Enabled = false;
            this.usecureii.Location = new System.Drawing.Point(15, 52);
            this.usecureii.Name = "usecureii";
            this.usecureii.Size = new System.Drawing.Size(95, 17);
            this.usecureii.TabIndex = 1;
            this.usecureii.Text = "Curing Waltz II";
            this.usecureii.UseVisualStyleBackColor = true;
            // 
            // usecure
            // 
            this.usecure.AutoSize = true;
            this.usecure.Enabled = false;
            this.usecure.Location = new System.Drawing.Point(15, 29);
            this.usecure.Name = "usecure";
            this.usecure.Size = new System.Drawing.Size(92, 17);
            this.usecure.TabIndex = 0;
            this.usecure.Text = "Curing Waltz I";
            this.usecure.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.usecure.UseVisualStyleBackColor = true;
            // 
            // tabPage16
            // 
            this.tabPage16.Controls.Add(this.PartyWaltsList);
            this.tabPage16.Controls.Add(this.addplayertext);
            this.tabPage16.Controls.Add(this.WaltzPTadd);
            this.tabPage16.Controls.Add(this.groupBox21);
            this.tabPage16.Controls.Add(this.groupBox22);
            this.tabPage16.Location = new System.Drawing.Point(4, 22);
            this.tabPage16.Name = "tabPage16";
            this.tabPage16.Size = new System.Drawing.Size(418, 237);
            this.tabPage16.TabIndex = 2;
            this.tabPage16.Text = "Party Waltz";
            this.tabPage16.UseVisualStyleBackColor = true;
            // 
            // PartyWaltsList
            // 
            this.PartyWaltsList.CheckOnClick = true;
            this.PartyWaltsList.FormattingEnabled = true;
            this.PartyWaltsList.Location = new System.Drawing.Point(210, 27);
            this.PartyWaltsList.Name = "PartyWaltsList";
            this.PartyWaltsList.Size = new System.Drawing.Size(199, 139);
            this.PartyWaltsList.Sorted = true;
            this.PartyWaltsList.TabIndex = 18;
            // 
            // addplayertext
            // 
            this.addplayertext.AutoSize = true;
            this.addplayertext.Location = new System.Drawing.Point(207, 177);
            this.addplayertext.Name = "addplayertext";
            this.addplayertext.Size = new System.Drawing.Size(58, 13);
            this.addplayertext.TabIndex = 17;
            this.addplayertext.Text = "Add Player";
            this.addplayertext.Click += new System.EventHandler(this.addplayertext_Click);
            // 
            // WaltzPTadd
            // 
            this.WaltzPTadd.Location = new System.Drawing.Point(274, 174);
            this.WaltzPTadd.Name = "WaltzPTadd";
            this.WaltzPTadd.Size = new System.Drawing.Size(135, 20);
            this.WaltzPTadd.TabIndex = 16;
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.label38);
            this.groupBox21.Controls.Add(this.label37);
            this.groupBox21.Controls.Add(this.label36);
            this.groupBox21.Controls.Add(this.label34);
            this.groupBox21.Controls.Add(this.label33);
            this.groupBox21.Controls.Add(this.numericUpDown27);
            this.groupBox21.Controls.Add(this.numericUpDown28);
            this.groupBox21.Controls.Add(this.numericUpDown29);
            this.groupBox21.Controls.Add(this.numericUpDown32);
            this.groupBox21.Controls.Add(this.numericUpDown33);
            this.groupBox21.Controls.Add(this.ptusecurev);
            this.groupBox21.Controls.Add(this.ptusecureiv);
            this.groupBox21.Controls.Add(this.ptusecureiii);
            this.groupBox21.Controls.Add(this.ptusecureii);
            this.groupBox21.Controls.Add(this.ptusecure);
            this.groupBox21.Location = new System.Drawing.Point(10, 20);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(190, 152);
            this.groupBox21.TabIndex = 14;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Curing Waltz";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(163, 116);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(15, 13);
            this.label38.TabIndex = 74;
            this.label38.Text = "%";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(163, 93);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(15, 13);
            this.label37.TabIndex = 77;
            this.label37.Text = "%";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(163, 70);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(15, 13);
            this.label36.TabIndex = 76;
            this.label36.Text = "%";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(163, 47);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(15, 13);
            this.label34.TabIndex = 75;
            this.label34.Text = "%";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(163, 24);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(15, 13);
            this.label33.TabIndex = 73;
            this.label33.Text = "%";
            // 
            // numericUpDown27
            // 
            this.numericUpDown27.Enabled = false;
            this.numericUpDown27.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown27.Location = new System.Drawing.Point(119, 112);
            this.numericUpDown27.Name = "numericUpDown27";
            this.numericUpDown27.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown27.TabIndex = 72;
            this.numericUpDown27.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown28
            // 
            this.numericUpDown28.Enabled = false;
            this.numericUpDown28.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown28.Location = new System.Drawing.Point(119, 89);
            this.numericUpDown28.Name = "numericUpDown28";
            this.numericUpDown28.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown28.TabIndex = 71;
            this.numericUpDown28.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown29
            // 
            this.numericUpDown29.Enabled = false;
            this.numericUpDown29.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown29.Location = new System.Drawing.Point(119, 66);
            this.numericUpDown29.Name = "numericUpDown29";
            this.numericUpDown29.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown29.TabIndex = 70;
            this.numericUpDown29.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown32
            // 
            this.numericUpDown32.Enabled = false;
            this.numericUpDown32.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown32.Location = new System.Drawing.Point(119, 43);
            this.numericUpDown32.Name = "numericUpDown32";
            this.numericUpDown32.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown32.TabIndex = 69;
            this.numericUpDown32.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown33
            // 
            this.numericUpDown33.Enabled = false;
            this.numericUpDown33.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown33.Location = new System.Drawing.Point(119, 20);
            this.numericUpDown33.Name = "numericUpDown33";
            this.numericUpDown33.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown33.TabIndex = 68;
            this.numericUpDown33.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ptusecurev
            // 
            this.ptusecurev.AutoSize = true;
            this.ptusecurev.Enabled = false;
            this.ptusecurev.Location = new System.Drawing.Point(12, 113);
            this.ptusecurev.Name = "ptusecurev";
            this.ptusecurev.Size = new System.Drawing.Size(96, 17);
            this.ptusecurev.TabIndex = 67;
            this.ptusecurev.Text = "Curing Waltz V";
            this.ptusecurev.UseVisualStyleBackColor = true;
            // 
            // ptusecureiv
            // 
            this.ptusecureiv.AutoSize = true;
            this.ptusecureiv.Enabled = false;
            this.ptusecureiv.Location = new System.Drawing.Point(12, 90);
            this.ptusecureiv.Name = "ptusecureiv";
            this.ptusecureiv.Size = new System.Drawing.Size(99, 17);
            this.ptusecureiv.TabIndex = 66;
            this.ptusecureiv.Text = "Curing Waltz IV";
            this.ptusecureiv.UseVisualStyleBackColor = true;
            // 
            // ptusecureiii
            // 
            this.ptusecureiii.AutoSize = true;
            this.ptusecureiii.Enabled = false;
            this.ptusecureiii.Location = new System.Drawing.Point(12, 67);
            this.ptusecureiii.Name = "ptusecureiii";
            this.ptusecureiii.Size = new System.Drawing.Size(98, 17);
            this.ptusecureiii.TabIndex = 65;
            this.ptusecureiii.Text = "Curing Waltz III";
            this.ptusecureiii.UseVisualStyleBackColor = true;
            // 
            // ptusecureii
            // 
            this.ptusecureii.AutoSize = true;
            this.ptusecureii.Enabled = false;
            this.ptusecureii.Location = new System.Drawing.Point(12, 44);
            this.ptusecureii.Name = "ptusecureii";
            this.ptusecureii.Size = new System.Drawing.Size(95, 17);
            this.ptusecureii.TabIndex = 64;
            this.ptusecureii.Text = "Curing Waltz II";
            this.ptusecureii.UseVisualStyleBackColor = true;
            // 
            // ptusecure
            // 
            this.ptusecure.AutoSize = true;
            this.ptusecure.Enabled = false;
            this.ptusecure.Location = new System.Drawing.Point(12, 21);
            this.ptusecure.Name = "ptusecure";
            this.ptusecure.Size = new System.Drawing.Size(92, 17);
            this.ptusecure.TabIndex = 63;
            this.ptusecure.Text = "Curing Waltz I";
            this.ptusecure.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ptusecure.UseVisualStyleBackColor = true;
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.GetSetParty);
            this.groupBox22.Location = new System.Drawing.Point(206, 192);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(203, 38);
            this.groupBox22.TabIndex = 13;
            this.groupBox22.TabStop = false;
            // 
            // GetSetParty
            // 
            this.GetSetParty.Dock = System.Windows.Forms.DockStyle.None;
            this.GetSetParty.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadPartyToolStripMenuItem,
            this.clearPartyToolStripMenuItem});
            this.GetSetParty.Location = new System.Drawing.Point(20, 10);
            this.GetSetParty.Name = "GetSetParty";
            this.GetSetParty.Size = new System.Drawing.Size(159, 24);
            this.GetSetParty.TabIndex = 0;
            this.GetSetParty.Text = "GetSetParty";
            // 
            // loadPartyToolStripMenuItem
            // 
            this.loadPartyToolStripMenuItem.Name = "loadPartyToolStripMenuItem";
            this.loadPartyToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.loadPartyToolStripMenuItem.Text = "Load Party";
            this.loadPartyToolStripMenuItem.Click += new System.EventHandler(this.loadPartyToolStripMenuItem_Click);
            // 
            // clearPartyToolStripMenuItem
            // 
            this.clearPartyToolStripMenuItem.Name = "clearPartyToolStripMenuItem";
            this.clearPartyToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.clearPartyToolStripMenuItem.Text = "Clear Party";
            this.clearPartyToolStripMenuItem.Click += new System.EventHandler(this.clearPartyToolStripMenuItem_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 206);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(0, 13);
            this.label15.TabIndex = 7;
            // 
            // flourish
            // 
            this.flourish.Controls.Add(this.flourishesiiigroup);
            this.flourish.Controls.Add(this.finsishingmovetext);
            this.flourish.Controls.Add(this.FlourishTPValue);
            this.flourish.Controls.Add(this.flourishesiigroup);
            this.flourish.Controls.Add(this.FlourishTP);
            this.flourish.Controls.Add(this.flourishesigroup);
            this.flourish.Location = new System.Drawing.Point(4, 22);
            this.flourish.Name = "flourish";
            this.flourish.Padding = new System.Windows.Forms.Padding(3);
            this.flourish.Size = new System.Drawing.Size(439, 361);
            this.flourish.TabIndex = 2;
            this.flourish.Text = "Flourishes";
            this.flourish.UseVisualStyleBackColor = true;
            // 
            // flourishesiiigroup
            // 
            this.flourishesiiigroup.Controls.Add(this.useclmfloValue);
            this.flourishesiiigroup.Controls.Add(this.usestkfloValue);
            this.flourishesiiigroup.Controls.Add(this.useterfloValue);
            this.flourishesiiigroup.Controls.Add(this.usestkflo);
            this.flourishesiiigroup.Controls.Add(this.useclmflo);
            this.flourishesiiigroup.Controls.Add(this.useterflo);
            this.flourishesiiigroup.Location = new System.Drawing.Point(29, 203);
            this.flourishesiiigroup.Name = "flourishesiiigroup";
            this.flourishesiiigroup.Size = new System.Drawing.Size(383, 71);
            this.flourishesiiigroup.TabIndex = 3;
            this.flourishesiiigroup.TabStop = false;
            this.flourishesiiigroup.Text = "Flourishes III";
            // 
            // useclmfloValue
            // 
            this.useclmfloValue.Enabled = false;
            this.useclmfloValue.Location = new System.Drawing.Point(139, 19);
            this.useclmfloValue.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.useclmfloValue.Name = "useclmfloValue";
            this.useclmfloValue.Size = new System.Drawing.Size(31, 20);
            this.useclmfloValue.TabIndex = 21;
            this.useclmfloValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // usestkfloValue
            // 
            this.usestkfloValue.Enabled = false;
            this.usestkfloValue.Location = new System.Drawing.Point(139, 42);
            this.usestkfloValue.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.usestkfloValue.Name = "usestkfloValue";
            this.usestkfloValue.Size = new System.Drawing.Size(31, 20);
            this.usestkfloValue.TabIndex = 22;
            this.usestkfloValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // useterfloValue
            // 
            this.useterfloValue.Enabled = false;
            this.useterfloValue.Location = new System.Drawing.Point(328, 43);
            this.useterfloValue.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.useterfloValue.Name = "useterfloValue";
            this.useterfloValue.Size = new System.Drawing.Size(31, 20);
            this.useterfloValue.TabIndex = 23;
            this.useterfloValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // usestkflo
            // 
            this.usestkflo.AutoSize = true;
            this.usestkflo.Enabled = false;
            this.usestkflo.Location = new System.Drawing.Point(25, 43);
            this.usestkflo.Name = "usestkflo";
            this.usestkflo.Size = new System.Drawing.Size(99, 17);
            this.usestkflo.TabIndex = 20;
            this.usestkflo.TabStop = true;
            this.usestkflo.Text = "Striking Flourish";
            this.usestkflo.UseVisualStyleBackColor = true;
            // 
            // useclmflo
            // 
            this.useclmflo.AutoSize = true;
            this.useclmflo.Enabled = false;
            this.useclmflo.Location = new System.Drawing.Point(25, 19);
            this.useclmflo.Name = "useclmflo";
            this.useclmflo.Size = new System.Drawing.Size(100, 17);
            this.useclmflo.TabIndex = 18;
            this.useclmflo.TabStop = true;
            this.useclmflo.Text = "Climatic Flourish";
            this.useclmflo.UseVisualStyleBackColor = true;
            // 
            // useterflo
            // 
            this.useterflo.AutoSize = true;
            this.useterflo.Enabled = false;
            this.useterflo.Location = new System.Drawing.Point(214, 42);
            this.useterflo.Name = "useterflo";
            this.useterflo.Size = new System.Drawing.Size(100, 17);
            this.useterflo.TabIndex = 19;
            this.useterflo.TabStop = true;
            this.useterflo.Text = "Ternary Flourish";
            this.useterflo.UseVisualStyleBackColor = true;
            // 
            // finsishingmovetext
            // 
            this.finsishingmovetext.AutoSize = true;
            this.finsishingmovetext.Location = new System.Drawing.Point(26, 277);
            this.finsishingmovetext.Name = "finsishingmovetext";
            this.finsishingmovetext.Size = new System.Drawing.Size(197, 13);
            this.finsishingmovetext.TabIndex = 2;
            this.finsishingmovetext.Text = "Finishing Moves Required / 0 = disabled";
            // 
            // FlourishTPValue
            // 
            this.FlourishTPValue.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.FlourishTPValue.Location = new System.Drawing.Point(143, 294);
            this.FlourishTPValue.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.FlourishTPValue.Name = "FlourishTPValue";
            this.FlourishTPValue.Size = new System.Drawing.Size(44, 20);
            this.FlourishTPValue.TabIndex = 63;
            this.FlourishTPValue.TabStop = false;
            this.FlourishTPValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FlourishTPValue.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // flourishesiigroup
            // 
            this.flourishesiigroup.Controls.Add(this.usewldfloValue);
            this.flourishesiigroup.Controls.Add(this.usebldfloValue);
            this.flourishesiigroup.Controls.Add(this.userevfloValue);
            this.flourishesiigroup.Controls.Add(this.usewldflo);
            this.flourishesiigroup.Controls.Add(this.usebldflo);
            this.flourishesiigroup.Controls.Add(this.userevflo);
            this.flourishesiigroup.Location = new System.Drawing.Point(29, 120);
            this.flourishesiigroup.Name = "flourishesiigroup";
            this.flourishesiigroup.Size = new System.Drawing.Size(383, 70);
            this.flourishesiigroup.TabIndex = 1;
            this.flourishesiigroup.TabStop = false;
            this.flourishesiigroup.Text = "Flourishes II";
            // 
            // usewldfloValue
            // 
            this.usewldfloValue.Enabled = false;
            this.usewldfloValue.Location = new System.Drawing.Point(328, 38);
            this.usewldfloValue.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.usewldfloValue.Name = "usewldfloValue";
            this.usewldfloValue.Size = new System.Drawing.Size(31, 20);
            this.usewldfloValue.TabIndex = 21;
            this.usewldfloValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // usebldfloValue
            // 
            this.usebldfloValue.Enabled = false;
            this.usebldfloValue.Location = new System.Drawing.Point(139, 39);
            this.usebldfloValue.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.usebldfloValue.Name = "usebldfloValue";
            this.usebldfloValue.Size = new System.Drawing.Size(31, 20);
            this.usebldfloValue.TabIndex = 20;
            this.usebldfloValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // userevfloValue
            // 
            this.userevfloValue.Enabled = false;
            this.userevfloValue.Location = new System.Drawing.Point(139, 16);
            this.userevfloValue.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.userevfloValue.Name = "userevfloValue";
            this.userevfloValue.Size = new System.Drawing.Size(31, 20);
            this.userevfloValue.TabIndex = 19;
            this.userevfloValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // usewldflo
            // 
            this.usewldflo.AutoSize = true;
            this.usewldflo.Enabled = false;
            this.usewldflo.Location = new System.Drawing.Point(214, 39);
            this.usewldflo.Name = "usewldflo";
            this.usewldflo.Size = new System.Drawing.Size(85, 17);
            this.usewldflo.TabIndex = 18;
            this.usewldflo.TabStop = true;
            this.usewldflo.Text = "Wild Flourish";
            this.usewldflo.UseVisualStyleBackColor = true;
            // 
            // usebldflo
            // 
            this.usebldflo.AutoSize = true;
            this.usebldflo.Enabled = false;
            this.usebldflo.Location = new System.Drawing.Point(25, 39);
            this.usebldflo.Name = "usebldflo";
            this.usebldflo.Size = new System.Drawing.Size(101, 17);
            this.usebldflo.TabIndex = 17;
            this.usebldflo.TabStop = true;
            this.usebldflo.Text = "Building Flourish";
            this.usebldflo.UseVisualStyleBackColor = true;
            // 
            // userevflo
            // 
            this.userevflo.AutoSize = true;
            this.userevflo.Enabled = false;
            this.userevflo.Location = new System.Drawing.Point(25, 16);
            this.userevflo.Name = "userevflo";
            this.userevflo.Size = new System.Drawing.Size(104, 17);
            this.userevflo.TabIndex = 16;
            this.userevflo.TabStop = true;
            this.userevflo.Text = "Reverse Flourish";
            this.userevflo.UseVisualStyleBackColor = true;
            // 
            // FlourishTP
            // 
            this.FlourishTP.AutoSize = true;
            this.FlourishTP.Location = new System.Drawing.Point(29, 297);
            this.FlourishTP.Name = "FlourishTP";
            this.FlourishTP.Size = new System.Drawing.Size(109, 17);
            this.FlourishTP.TabIndex = 1;
            this.FlourishTP.Text = "Flourish under TP";
            this.FlourishTP.UseVisualStyleBackColor = true;
            // 
            // flourishesigroup
            // 
            this.flourishesigroup.Controls.Add(this.useviofloValue);
            this.flourishesigroup.Controls.Add(this.usevioflo);
            this.flourishesigroup.Controls.Add(this.usedesfloValue);
            this.flourishesigroup.Controls.Add(this.usedesflo);
            this.flourishesigroup.Location = new System.Drawing.Point(29, 55);
            this.flourishesigroup.Name = "flourishesigroup";
            this.flourishesigroup.Size = new System.Drawing.Size(383, 52);
            this.flourishesigroup.TabIndex = 0;
            this.flourishesigroup.TabStop = false;
            this.flourishesigroup.Text = "Flourishes I";
            // 
            // useviofloValue
            // 
            this.useviofloValue.Enabled = false;
            this.useviofloValue.Location = new System.Drawing.Point(328, 19);
            this.useviofloValue.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.useviofloValue.Name = "useviofloValue";
            this.useviofloValue.Size = new System.Drawing.Size(31, 20);
            this.useviofloValue.TabIndex = 28;
            this.useviofloValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // usevioflo
            // 
            this.usevioflo.AutoSize = true;
            this.usevioflo.Enabled = false;
            this.usevioflo.Location = new System.Drawing.Point(209, 19);
            this.usevioflo.Name = "usevioflo";
            this.usevioflo.Size = new System.Drawing.Size(96, 17);
            this.usevioflo.TabIndex = 27;
            this.usevioflo.TabStop = true;
            this.usevioflo.Text = "Violent Flourish";
            this.usevioflo.UseVisualStyleBackColor = true;
            // 
            // usedesfloValue
            // 
            this.usedesfloValue.Enabled = false;
            this.usedesfloValue.Location = new System.Drawing.Point(139, 19);
            this.usedesfloValue.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.usedesfloValue.Name = "usedesfloValue";
            this.usedesfloValue.Size = new System.Drawing.Size(31, 20);
            this.usedesfloValue.TabIndex = 26;
            this.usedesfloValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // usedesflo
            // 
            this.usedesflo.AutoSize = true;
            this.usedesflo.Enabled = false;
            this.usedesflo.Location = new System.Drawing.Point(25, 19);
            this.usedesflo.Name = "usedesflo";
            this.usedesflo.Size = new System.Drawing.Size(113, 17);
            this.usedesflo.TabIndex = 23;
            this.usedesflo.TabStop = true;
            this.usedesflo.Text = "Desperate Flourish";
            this.usedesflo.UseVisualStyleBackColor = true;
            // 
            // pets
            // 
            this.pets.Controls.Add(this.groupBox10);
            this.pets.Location = new System.Drawing.Point(4, 22);
            this.pets.Name = "pets";
            this.pets.Padding = new System.Windows.Forms.Padding(3);
            this.pets.Size = new System.Drawing.Size(439, 361);
            this.pets.TabIndex = 4;
            this.pets.Text = "Pets";
            this.pets.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.groupBox19);
            this.groupBox10.Controls.Add(this.petControl);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox10.Location = new System.Drawing.Point(3, 3);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(433, 355);
            this.groupBox10.TabIndex = 1;
            this.groupBox10.TabStop = false;
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.label23);
            this.groupBox19.Controls.Add(this.label22);
            this.groupBox19.Controls.Add(this.label21);
            this.groupBox19.Controls.Add(this.label20);
            this.groupBox19.Location = new System.Drawing.Point(6, 10);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(421, 50);
            this.groupBox19.TabIndex = 39;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Pet Information";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(249, 29);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(51, 13);
            this.label23.TabIndex = 9;
            this.label23.Text = "Pets TP: ";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(240, 16);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(60, 13);
            this.label22.TabIndex = 8;
            this.label22.Text = "Pets HP%: ";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(37, 29);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(43, 13);
            this.label21.TabIndex = 7;
            this.label21.Text = "Pet ID: ";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(15, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 13);
            this.label20.TabIndex = 6;
            this.label20.Text = "Pets Name: ";
            // 
            // petControl
            // 
            this.petControl.Controls.Add(this.bstpettab);
            this.petControl.Controls.Add(this.drgpettab);
            this.petControl.Controls.Add(this.smnpettab);
            this.petControl.Controls.Add(this.puppettab);
            this.petControl.Controls.Add(this.geopettab);
            this.petControl.Location = new System.Drawing.Point(6, 66);
            this.petControl.Name = "petControl";
            this.petControl.SelectedIndex = 0;
            this.petControl.Size = new System.Drawing.Size(423, 273);
            this.petControl.TabIndex = 38;
            // 
            // bstpettab
            // 
            this.bstpettab.Controls.Add(this.label13);
            this.bstpettab.Controls.Add(this.BstJATP);
            this.bstpettab.Controls.Add(this.usepetja);
            this.bstpettab.Controls.Add(this.bstpetrdygroup);
            this.bstpettab.Controls.Add(this.usedpetfood);
            this.bstpettab.Controls.Add(this.jugpet);
            this.bstpettab.Controls.Add(this.juguse);
            this.bstpettab.Controls.Add(this.pethppfood);
            this.bstpettab.Controls.Add(this.pethptext);
            this.bstpettab.Controls.Add(this.petfooduse);
            this.bstpettab.Controls.Add(this.autoengage);
            this.bstpettab.Location = new System.Drawing.Point(4, 22);
            this.bstpettab.Name = "bstpettab";
            this.bstpettab.Padding = new System.Windows.Forms.Padding(3);
            this.bstpettab.Size = new System.Drawing.Size(415, 247);
            this.bstpettab.TabIndex = 0;
            this.bstpettab.Text = "BST";
            this.bstpettab.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(231, 105);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 13);
            this.label13.TabIndex = 97;
            this.label13.Text = "Bst Ability @ TP:";
            // 
            // BstJATP
            // 
            this.BstJATP.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.BstJATP.Location = new System.Drawing.Point(325, 103);
            this.BstJATP.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.BstJATP.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BstJATP.Name = "BstJATP";
            this.BstJATP.Size = new System.Drawing.Size(44, 20);
            this.BstJATP.TabIndex = 96;
            this.BstJATP.TabStop = false;
            this.BstJATP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BstJATP.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // usepetja
            // 
            this.usepetja.Controls.Add(this.PetJA);
            this.usepetja.Location = new System.Drawing.Point(17, 129);
            this.usepetja.Name = "usepetja";
            this.usepetja.Size = new System.Drawing.Size(176, 112);
            this.usepetja.TabIndex = 12;
            this.usepetja.TabStop = false;
            this.usepetja.Text = "Pet JA";
            // 
            // PetJA
            // 
            this.PetJA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PetJA.CheckOnClick = true;
            this.PetJA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PetJA.FormattingEnabled = true;
            this.PetJA.Location = new System.Drawing.Point(3, 16);
            this.PetJA.Name = "PetJA";
            this.PetJA.Size = new System.Drawing.Size(170, 93);
            this.PetJA.TabIndex = 0;
            // 
            // bstpetrdygroup
            // 
            this.bstpetrdygroup.Controls.Add(this.PetReady);
            this.bstpetrdygroup.Location = new System.Drawing.Point(223, 129);
            this.bstpetrdygroup.Name = "bstpetrdygroup";
            this.bstpetrdygroup.Size = new System.Drawing.Size(176, 112);
            this.bstpetrdygroup.TabIndex = 19;
            this.bstpetrdygroup.TabStop = false;
            this.bstpetrdygroup.Text = "Pet Ready";
            // 
            // PetReady
            // 
            this.PetReady.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PetReady.CheckOnClick = true;
            this.PetReady.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PetReady.FormattingEnabled = true;
            this.PetReady.Location = new System.Drawing.Point(3, 16);
            this.PetReady.Name = "PetReady";
            this.PetReady.Size = new System.Drawing.Size(170, 93);
            this.PetReady.TabIndex = 1;
            // 
            // usedpetfood
            // 
            this.usedpetfood.AutoCompleteCustomSource.AddRange(new string[] {
            "Pet Food Alpha",
            "Pet Food Beta",
            "Pet Food Gamma",
            "Pet Food Delta",
            "Pet Food Epsilon",
            "Pet Food Zeta",
            "Pet Food Eta",
            "Pet Food Theta"});
            this.usedpetfood.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.usedpetfood.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.usedpetfood.FormattingEnabled = true;
            this.usedpetfood.Location = new System.Drawing.Point(92, 35);
            this.usedpetfood.Name = "usedpetfood";
            this.usedpetfood.Size = new System.Drawing.Size(180, 21);
            this.usedpetfood.TabIndex = 14;
            // 
            // jugpet
            // 
            this.jugpet.AutoCompleteCustomSource.AddRange(new string[] {
            "Wormy Broth",
            "Carrot Broth",
            "Herbal Broth",
            "Humus",
            "Meat Broth",
            "Grasshopper Broth",
            "Carrion Broth",
            "Bug Broth",
            "Mole Broth",
            "Tree Sap",
            "Antica Broth",
            "Fish Broth",
            "Blood Broth",
            "Famous Carrot Broth",
            "Singing Herbal Broth",
            "Rich Humus",
            "Warm Meat Broth",
            "Seedbed Soil",
            "Quadav Bug Broth",
            "Cold Carrion Broth",
            "Fish Oil Broth",
            "Alchemist Water",
            "Noisy Grasshopper Broth",
            "Lively Mole Broth",
            "Scarlet Sap",
            "Clear Blood Broth",
            "Fragrant Antica Broth",
            "Sun Water",
            "Dancing Herbal Broth",
            "Cunning Brain Broth",
            "Chirping Grasshopper Broth",
            "Mellow Bird Broth",
            "Goblin Bug Broth",
            "Bubbling Carrion Broth",
            "Auroral Broth",
            "Lucky Carrot Broth",
            "Wool Grease",
            "Vermihumus",
            "Briny Broth",
            "Deepbed Soil",
            "Curdled Plasma Broth",
            "Lucky Broth",
            "Savage Mole Broth",
            "Razor Brain Broth",
            "Burning Carrion Broth",
            "Cloudy Wheat Broth",
            "Shadowy Broth",
            "Swirling Broth",
            "Shimmering Broth",
            "Spicy Broth",
            "Salubrious Broth",
            "Translucent Broth",
            "Fizzy Broth",
            "Wispy Broth",
            "Saline Broth",
            "Meaty Broth",
            "Blackwater Broth",
            "Pale Sap",
            "Crumbly Soil",
            "Airy Broth",
            "Muddy Broth",
            "Dire Broth",
            "Electrified Broth",
            "Bug-Ridden Broth"});
            this.jugpet.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.jugpet.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.jugpet.FormattingEnabled = true;
            this.jugpet.Location = new System.Drawing.Point(92, 12);
            this.jugpet.Name = "jugpet";
            this.jugpet.Size = new System.Drawing.Size(180, 21);
            this.jugpet.TabIndex = 13;
            // 
            // juguse
            // 
            this.juguse.AutoSize = true;
            this.juguse.Location = new System.Drawing.Point(17, 14);
            this.juguse.Name = "juguse";
            this.juguse.Size = new System.Drawing.Size(71, 17);
            this.juguse.TabIndex = 1;
            this.juguse.Text = "Auto Jug:";
            this.juguse.UseVisualStyleBackColor = true;
            // 
            // pethppfood
            // 
            this.pethppfood.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.pethppfood.Location = new System.Drawing.Point(360, 35);
            this.pethppfood.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.pethppfood.Name = "pethppfood";
            this.pethppfood.Size = new System.Drawing.Size(39, 20);
            this.pethppfood.TabIndex = 10;
            this.pethppfood.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pethppfood.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // pethptext
            // 
            this.pethptext.AutoSize = true;
            this.pethptext.Location = new System.Drawing.Point(287, 38);
            this.pethptext.Name = "pethptext";
            this.pethptext.Size = new System.Drawing.Size(72, 13);
            this.pethptext.TabIndex = 5;
            this.pethptext.Text = "<= Pets HP% ";
            // 
            // petfooduse
            // 
            this.petfooduse.AutoSize = true;
            this.petfooduse.Location = new System.Drawing.Point(17, 37);
            this.petfooduse.Name = "petfooduse";
            this.petfooduse.Size = new System.Drawing.Size(72, 17);
            this.petfooduse.TabIndex = 1;
            this.petfooduse.Text = "Pet Food:";
            this.petfooduse.UseVisualStyleBackColor = true;
            // 
            // autoengage
            // 
            this.autoengage.AutoSize = true;
            this.autoengage.Location = new System.Drawing.Point(290, 14);
            this.autoengage.Name = "autoengage";
            this.autoengage.Size = new System.Drawing.Size(107, 17);
            this.autoengage.TabIndex = 1;
            this.autoengage.Text = "Auto Engage Pet";
            this.autoengage.UseVisualStyleBackColor = true;
            // 
            // drgpettab
            // 
            this.drgpettab.Controls.Add(this.DragonPetHP);
            this.drgpettab.Controls.Add(this.drgsteadywingtext);
            this.drgpettab.Controls.Add(this.CallWyvern);
            this.drgpettab.Controls.Add(this.drgspirtlinkgroup);
            this.drgpettab.Controls.Add(this.label47);
            this.drgpettab.Controls.Add(this.BreathMAX);
            this.drgpettab.Controls.Add(this.label48);
            this.drgpettab.Controls.Add(this.BreathMIN);
            this.drgpettab.Controls.Add(this.drgwyvernbreathptext);
            this.drgpettab.Controls.Add(this.drgrestoringbreathgroup);
            this.drgpettab.Controls.Add(this.drgjagroup);
            this.drgpettab.Location = new System.Drawing.Point(4, 22);
            this.drgpettab.Name = "drgpettab";
            this.drgpettab.Padding = new System.Windows.Forms.Padding(3);
            this.drgpettab.Size = new System.Drawing.Size(415, 247);
            this.drgpettab.TabIndex = 3;
            this.drgpettab.Text = "DRG";
            this.drgpettab.UseVisualStyleBackColor = true;
            // 
            // DragonPetHP
            // 
            this.DragonPetHP.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.DragonPetHP.Location = new System.Drawing.Point(332, 142);
            this.DragonPetHP.Name = "DragonPetHP";
            this.DragonPetHP.Size = new System.Drawing.Size(44, 20);
            this.DragonPetHP.TabIndex = 118;
            this.DragonPetHP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // drgsteadywingtext
            // 
            this.drgsteadywingtext.AutoSize = true;
            this.drgsteadywingtext.Location = new System.Drawing.Point(216, 146);
            this.drgsteadywingtext.Name = "drgsteadywingtext";
            this.drgsteadywingtext.Size = new System.Drawing.Size(108, 13);
            this.drgsteadywingtext.TabIndex = 110;
            this.drgsteadywingtext.Text = "Steady Wing @ HP%";
            // 
            // CallWyvern
            // 
            this.CallWyvern.AutoSize = true;
            this.CallWyvern.Location = new System.Drawing.Point(199, 14);
            this.CallWyvern.Name = "CallWyvern";
            this.CallWyvern.Size = new System.Drawing.Size(108, 17);
            this.CallWyvern.TabIndex = 109;
            this.CallWyvern.Text = "Auto-Call Wyvern";
            this.CallWyvern.UseVisualStyleBackColor = true;
            // 
            // drgspirtlinkgroup
            // 
            this.drgspirtlinkgroup.Controls.Add(this.label16);
            this.drgspirtlinkgroup.Controls.Add(this.PlayerSpirit);
            this.drgspirtlinkgroup.Controls.Add(this.WyvernSpirit);
            this.drgspirtlinkgroup.Controls.Add(this.label46);
            this.drgspirtlinkgroup.Location = new System.Drawing.Point(17, 8);
            this.drgspirtlinkgroup.Name = "drgspirtlinkgroup";
            this.drgspirtlinkgroup.Size = new System.Drawing.Size(176, 70);
            this.drgspirtlinkgroup.TabIndex = 108;
            this.drgspirtlinkgroup.TabStop = false;
            this.drgspirtlinkgroup.Text = "Spirit Link";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(113, 13);
            this.label16.TabIndex = 26;
            this.label16.Text = "Use @ Wyvern\'s HP%";
            // 
            // PlayerSpirit
            // 
            this.PlayerSpirit.Location = new System.Drawing.Point(124, 39);
            this.PlayerSpirit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PlayerSpirit.Name = "PlayerSpirit";
            this.PlayerSpirit.Size = new System.Drawing.Size(44, 20);
            this.PlayerSpirit.TabIndex = 29;
            this.PlayerSpirit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PlayerSpirit.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // WyvernSpirit
            // 
            this.WyvernSpirit.Location = new System.Drawing.Point(124, 16);
            this.WyvernSpirit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WyvernSpirit.Name = "WyvernSpirit";
            this.WyvernSpirit.Size = new System.Drawing.Size(44, 20);
            this.WyvernSpirit.TabIndex = 27;
            this.WyvernSpirit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WyvernSpirit.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(40, 43);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(81, 13);
            this.label46.TabIndex = 28;
            this.label46.Text = "Player min HP%";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(269, 113);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(27, 13);
            this.label47.TabIndex = 104;
            this.label47.Text = "MIN";
            // 
            // BreathMAX
            // 
            this.BreathMAX.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.BreathMAX.Location = new System.Drawing.Point(301, 109);
            this.BreathMAX.Name = "BreathMAX";
            this.BreathMAX.Size = new System.Drawing.Size(44, 20);
            this.BreathMAX.TabIndex = 103;
            this.BreathMAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BreathMAX.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(351, 113);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(30, 13);
            this.label48.TabIndex = 105;
            this.label48.Text = "MAX";
            // 
            // BreathMIN
            // 
            this.BreathMIN.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.BreathMIN.Location = new System.Drawing.Point(219, 109);
            this.BreathMIN.Name = "BreathMIN";
            this.BreathMIN.Size = new System.Drawing.Size(44, 20);
            this.BreathMIN.TabIndex = 102;
            this.BreathMIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BreathMIN.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // drgwyvernbreathptext
            // 
            this.drgwyvernbreathptext.AutoSize = true;
            this.drgwyvernbreathptext.Location = new System.Drawing.Point(216, 93);
            this.drgwyvernbreathptext.Name = "drgwyvernbreathptext";
            this.drgwyvernbreathptext.Size = new System.Drawing.Size(160, 13);
            this.drgwyvernbreathptext.TabIndex = 101;
            this.drgwyvernbreathptext.Text = "Mob HP% to use Wyvern Breath";
            // 
            // drgrestoringbreathgroup
            // 
            this.drgrestoringbreathgroup.Controls.Add(this.RestoringBreathHP);
            this.drgrestoringbreathgroup.Controls.Add(this.label50);
            this.drgrestoringbreathgroup.Location = new System.Drawing.Point(199, 34);
            this.drgrestoringbreathgroup.Name = "drgrestoringbreathgroup";
            this.drgrestoringbreathgroup.Size = new System.Drawing.Size(200, 44);
            this.drgrestoringbreathgroup.TabIndex = 18;
            this.drgrestoringbreathgroup.TabStop = false;
            this.drgrestoringbreathgroup.Text = "Restoring Breath";
            // 
            // RestoringBreathHP
            // 
            this.RestoringBreathHP.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.RestoringBreathHP.Location = new System.Drawing.Point(117, 15);
            this.RestoringBreathHP.Name = "RestoringBreathHP";
            this.RestoringBreathHP.Size = new System.Drawing.Size(44, 20);
            this.RestoringBreathHP.TabIndex = 117;
            this.RestoringBreathHP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(39, 19);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(66, 13);
            this.label50.TabIndex = 116;
            this.label50.Text = "Use @ HP%";
            // 
            // drgjagroup
            // 
            this.drgjagroup.Controls.Add(this.WyvernJA);
            this.drgjagroup.Location = new System.Drawing.Point(17, 81);
            this.drgjagroup.Name = "drgjagroup";
            this.drgjagroup.Size = new System.Drawing.Size(176, 159);
            this.drgjagroup.TabIndex = 13;
            this.drgjagroup.TabStop = false;
            this.drgjagroup.Text = "Pet JA";
            // 
            // WyvernJA
            // 
            this.WyvernJA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WyvernJA.CheckOnClick = true;
            this.WyvernJA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WyvernJA.FormattingEnabled = true;
            this.WyvernJA.Location = new System.Drawing.Point(3, 16);
            this.WyvernJA.Name = "WyvernJA";
            this.WyvernJA.Size = new System.Drawing.Size(170, 140);
            this.WyvernJA.TabIndex = 1;
            // 
            // smnpettab
            // 
            this.smnpettab.Controls.Add(this.autoengageAvatar);
            this.smnpettab.Controls.Add(this.ManaCedegroup);
            this.smnpettab.Controls.Add(this.Apogeetext);
            this.smnpettab.Controls.Add(this.ApogeeMPPset);
            this.smnpettab.Controls.Add(this.SMNpetMPUSEtext);
            this.smnpettab.Controls.Add(this.SMNpetMPUSEset);
            this.smnpettab.Controls.Add(this.SMNHPPset1);
            this.smnpettab.Controls.Add(this.SMNHPPset2);
            this.smnpettab.Controls.Add(this.SMNHealTEXT2);
            this.smnpettab.Controls.Add(this.SMNHealTEXT1);
            this.smnpettab.Controls.Add(this.SMNpetTPUSEtext);
            this.smnpettab.Controls.Add(this.SMNpetTPUSEset);
            this.smnpettab.Controls.Add(this.SMNJAgroup);
            this.smnpettab.Controls.Add(this.SelectSMNtext);
            this.smnpettab.Controls.Add(this.SMNSelect);
            this.smnpettab.Controls.Add(this.SMNAbilitysgroup);
            this.smnpettab.Location = new System.Drawing.Point(4, 22);
            this.smnpettab.Name = "smnpettab";
            this.smnpettab.Size = new System.Drawing.Size(415, 247);
            this.smnpettab.TabIndex = 2;
            this.smnpettab.Text = "SMN";
            this.smnpettab.UseVisualStyleBackColor = true;
            // 
            // autoengageAvatar
            // 
            this.autoengageAvatar.AutoSize = true;
            this.autoengageAvatar.Location = new System.Drawing.Point(276, 6);
            this.autoengageAvatar.Name = "autoengageAvatar";
            this.autoengageAvatar.Size = new System.Drawing.Size(122, 17);
            this.autoengageAvatar.TabIndex = 29;
            this.autoengageAvatar.Text = "Auto Engage Avatar";
            this.autoengageAvatar.UseVisualStyleBackColor = true;
            // 
            // ManaCedegroup
            // 
            this.ManaCedegroup.Controls.Add(this.ManaCedePETTPtext);
            this.ManaCedegroup.Controls.Add(this.ManaCedeTPset);
            this.ManaCedegroup.Controls.Add(this.ManaCedePMPPtext);
            this.ManaCedegroup.Controls.Add(this.ManaCedeMPPset);
            this.ManaCedegroup.Location = new System.Drawing.Point(14, 30);
            this.ManaCedegroup.Name = "ManaCedegroup";
            this.ManaCedegroup.Size = new System.Drawing.Size(150, 69);
            this.ManaCedegroup.TabIndex = 28;
            this.ManaCedegroup.TabStop = false;
            this.ManaCedegroup.Text = "Mana Cede";
            // 
            // ManaCedePETTPtext
            // 
            this.ManaCedePETTPtext.AutoSize = true;
            this.ManaCedePETTPtext.Location = new System.Drawing.Point(35, 41);
            this.ManaCedePETTPtext.Name = "ManaCedePETTPtext";
            this.ManaCedePETTPtext.Size = new System.Drawing.Size(49, 13);
            this.ManaCedePETTPtext.TabIndex = 30;
            this.ManaCedePETTPtext.Text = "Pet TP <";
            // 
            // ManaCedeTPset
            // 
            this.ManaCedeTPset.Location = new System.Drawing.Point(90, 39);
            this.ManaCedeTPset.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.ManaCedeTPset.Name = "ManaCedeTPset";
            this.ManaCedeTPset.Size = new System.Drawing.Size(43, 20);
            this.ManaCedeTPset.TabIndex = 29;
            // 
            // ManaCedePMPPtext
            // 
            this.ManaCedePMPPtext.AutoSize = true;
            this.ManaCedePMPPtext.Location = new System.Drawing.Point(13, 16);
            this.ManaCedePMPPtext.Name = "ManaCedePMPPtext";
            this.ManaCedePMPPtext.Size = new System.Drawing.Size(72, 13);
            this.ManaCedePMPPtext.TabIndex = 30;
            this.ManaCedePMPPtext.Text = "Player MP% >";
            // 
            // ManaCedeMPPset
            // 
            this.ManaCedeMPPset.Location = new System.Drawing.Point(90, 14);
            this.ManaCedeMPPset.Name = "ManaCedeMPPset";
            this.ManaCedeMPPset.Size = new System.Drawing.Size(43, 20);
            this.ManaCedeMPPset.TabIndex = 29;
            // 
            // Apogeetext
            // 
            this.Apogeetext.AutoSize = true;
            this.Apogeetext.Location = new System.Drawing.Point(14, 107);
            this.Apogeetext.Name = "Apogeetext";
            this.Apogeetext.Size = new System.Drawing.Size(111, 13);
            this.Apogeetext.TabIndex = 27;
            this.Apogeetext.Text = "Apogee When MPP >";
            // 
            // ApogeeMPPset
            // 
            this.ApogeeMPPset.Location = new System.Drawing.Point(131, 105);
            this.ApogeeMPPset.Name = "ApogeeMPPset";
            this.ApogeeMPPset.Size = new System.Drawing.Size(43, 20);
            this.ApogeeMPPset.TabIndex = 26;
            // 
            // SMNpetMPUSEtext
            // 
            this.SMNpetMPUSEtext.AutoSize = true;
            this.SMNpetMPUSEtext.Location = new System.Drawing.Point(197, 82);
            this.SMNpetMPUSEtext.Name = "SMNpetMPUSEtext";
            this.SMNpetMPUSEtext.Size = new System.Drawing.Size(149, 13);
            this.SMNpetMPUSEtext.TabIndex = 25;
            this.SMNpetMPUSEtext.Text = "Don not call SMN below MP%";
            // 
            // SMNpetMPUSEset
            // 
            this.SMNpetMPUSEset.Location = new System.Drawing.Point(349, 80);
            this.SMNpetMPUSEset.Name = "SMNpetMPUSEset";
            this.SMNpetMPUSEset.Size = new System.Drawing.Size(43, 20);
            this.SMNpetMPUSEset.TabIndex = 24;
            this.SMNpetMPUSEset.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // SMNHPPset1
            // 
            this.SMNHPPset1.Enabled = false;
            this.SMNHPPset1.Location = new System.Drawing.Point(349, 30);
            this.SMNHPPset1.Name = "SMNHPPset1";
            this.SMNHPPset1.Size = new System.Drawing.Size(44, 20);
            this.SMNHPPset1.TabIndex = 21;
            // 
            // SMNHPPset2
            // 
            this.SMNHPPset2.Enabled = false;
            this.SMNHPPset2.Location = new System.Drawing.Point(349, 55);
            this.SMNHPPset2.Name = "SMNHPPset2";
            this.SMNHPPset2.Size = new System.Drawing.Size(44, 20);
            this.SMNHPPset2.TabIndex = 20;
            // 
            // SMNHealTEXT2
            // 
            this.SMNHealTEXT2.Enabled = false;
            this.SMNHealTEXT2.Location = new System.Drawing.Point(225, 57);
            this.SMNHealTEXT2.Name = "SMNHealTEXT2";
            this.SMNHealTEXT2.Size = new System.Drawing.Size(121, 18);
            this.SMNHealTEXT2.TabIndex = 19;
            this.SMNHealTEXT2.Text = "(Not Needed)";
            this.SMNHealTEXT2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SMNHealTEXT1
            // 
            this.SMNHealTEXT1.Enabled = false;
            this.SMNHealTEXT1.Location = new System.Drawing.Point(212, 32);
            this.SMNHealTEXT1.Name = "SMNHealTEXT1";
            this.SMNHealTEXT1.Size = new System.Drawing.Size(134, 20);
            this.SMNHealTEXT1.TabIndex = 18;
            this.SMNHealTEXT1.Text = "(Not Needed)";
            this.SMNHealTEXT1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SMNpetTPUSEtext
            // 
            this.SMNpetTPUSEtext.AutoSize = true;
            this.SMNpetTPUSEtext.Location = new System.Drawing.Point(209, 107);
            this.SMNpetTPUSEtext.Name = "SMNpetTPUSEtext";
            this.SMNpetTPUSEtext.Size = new System.Drawing.Size(134, 13);
            this.SMNpetTPUSEtext.TabIndex = 23;
            this.SMNpetTPUSEtext.Text = "Use Ward/Rage at Pet TP";
            // 
            // SMNpetTPUSEset
            // 
            this.SMNpetTPUSEset.Location = new System.Drawing.Point(349, 105);
            this.SMNpetTPUSEset.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.SMNpetTPUSEset.Name = "SMNpetTPUSEset";
            this.SMNpetTPUSEset.Size = new System.Drawing.Size(44, 20);
            this.SMNpetTPUSEset.TabIndex = 22;
            // 
            // SMNJAgroup
            // 
            this.SMNJAgroup.Controls.Add(this.SMNJA);
            this.SMNJAgroup.Location = new System.Drawing.Point(14, 131);
            this.SMNJAgroup.Name = "SMNJAgroup";
            this.SMNJAgroup.Size = new System.Drawing.Size(176, 100);
            this.SMNJAgroup.TabIndex = 17;
            this.SMNJAgroup.TabStop = false;
            this.SMNJAgroup.Text = "Pet JA";
            // 
            // SMNJA
            // 
            this.SMNJA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SMNJA.CheckOnClick = true;
            this.SMNJA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SMNJA.FormattingEnabled = true;
            this.SMNJA.Location = new System.Drawing.Point(3, 16);
            this.SMNJA.Name = "SMNJA";
            this.SMNJA.Size = new System.Drawing.Size(170, 81);
            this.SMNJA.TabIndex = 1;
            // 
            // SelectSMNtext
            // 
            this.SelectSMNtext.AutoSize = true;
            this.SelectSMNtext.Location = new System.Drawing.Point(11, 6);
            this.SelectSMNtext.Name = "SelectSMNtext";
            this.SelectSMNtext.Size = new System.Drawing.Size(64, 13);
            this.SelectSMNtext.TabIndex = 16;
            this.SelectSMNtext.Text = "Select SMN";
            // 
            // SMNSelect
            // 
            this.SMNSelect.FormattingEnabled = true;
            this.SMNSelect.Location = new System.Drawing.Point(81, 3);
            this.SMNSelect.Name = "SMNSelect";
            this.SMNSelect.Size = new System.Drawing.Size(121, 21);
            this.SMNSelect.TabIndex = 15;
            this.SMNSelect.SelectedIndexChanged += new System.EventHandler(this.SMNSelect_SelectedIndexChanged);
            // 
            // SMNAbilitysgroup
            // 
            this.SMNAbilitysgroup.Controls.Add(this.SMNAbilityList);
            this.SMNAbilitysgroup.Location = new System.Drawing.Point(225, 131);
            this.SMNAbilitysgroup.Name = "SMNAbilitysgroup";
            this.SMNAbilitysgroup.Size = new System.Drawing.Size(176, 104);
            this.SMNAbilitysgroup.TabIndex = 14;
            this.SMNAbilitysgroup.TabStop = false;
            this.SMNAbilitysgroup.Text = "SMN Abilitys";
            // 
            // SMNAbilityList
            // 
            this.SMNAbilityList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SMNAbilityList.CheckOnClick = true;
            this.SMNAbilityList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SMNAbilityList.FormattingEnabled = true;
            this.SMNAbilityList.Location = new System.Drawing.Point(3, 16);
            this.SMNAbilityList.Name = "SMNAbilityList";
            this.SMNAbilityList.Size = new System.Drawing.Size(170, 85);
            this.SMNAbilityList.TabIndex = 1;
            // 
            // puppettab
            // 
            this.puppettab.Controls.Add(this.tabControl1);
            this.puppettab.Location = new System.Drawing.Point(4, 22);
            this.puppettab.Name = "puppettab";
            this.puppettab.Padding = new System.Windows.Forms.Padding(3);
            this.puppettab.Size = new System.Drawing.Size(415, 247);
            this.puppettab.TabIndex = 1;
            this.puppettab.Text = "PUP";
            this.puppettab.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.PUPAbilitypage);
            this.tabControl1.Controls.Add(this.PUPOtherpage);
            this.tabControl1.Location = new System.Drawing.Point(6, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(403, 235);
            this.tabControl1.TabIndex = 36;
            // 
            // PUPAbilitypage
            // 
            this.PUPAbilitypage.Controls.Add(this.Maneuversgroup);
            this.PUPAbilitypage.Controls.Add(this.groupBox4);
            this.PUPAbilitypage.Controls.Add(this.AutoCallPUP);
            this.PUPAbilitypage.Controls.Add(this.groupBox5);
            this.PUPAbilitypage.Controls.Add(this.PUPautoengage);
            this.PUPAbilitypage.Location = new System.Drawing.Point(4, 22);
            this.PUPAbilitypage.Name = "PUPAbilitypage";
            this.PUPAbilitypage.Padding = new System.Windows.Forms.Padding(3);
            this.PUPAbilitypage.Size = new System.Drawing.Size(395, 209);
            this.PUPAbilitypage.TabIndex = 0;
            this.PUPAbilitypage.Text = "Ability\'s";
            this.PUPAbilitypage.UseVisualStyleBackColor = true;
            // 
            // Maneuversgroup
            // 
            this.Maneuversgroup.Controls.Add(this.Maneuver3select);
            this.Maneuversgroup.Controls.Add(this.Maneuver2select);
            this.Maneuversgroup.Controls.Add(this.Maneuver1set);
            this.Maneuversgroup.Controls.Add(this.Maneuver2set);
            this.Maneuversgroup.Controls.Add(this.Maneuver3set);
            this.Maneuversgroup.Controls.Add(this.Maneuver1select);
            this.Maneuversgroup.Controls.Add(this.label49);
            this.Maneuversgroup.Controls.Add(this.label56);
            this.Maneuversgroup.Controls.Add(this.label51);
            this.Maneuversgroup.Location = new System.Drawing.Point(172, 92);
            this.Maneuversgroup.Name = "Maneuversgroup";
            this.Maneuversgroup.Size = new System.Drawing.Size(214, 105);
            this.Maneuversgroup.TabIndex = 15;
            this.Maneuversgroup.TabStop = false;
            this.Maneuversgroup.Text = "Maneuver\'s";
            // 
            // Maneuver3select
            // 
            this.Maneuver3select.FormattingEnabled = true;
            this.Maneuver3select.Items.AddRange(new object[] {
            "Dark Maneuver",
            "Earth Maneuver",
            "Fire Maneuver",
            "Ice Maneuver",
            "Light Maneuver",
            "Thunder Maneuver",
            "Water Maneuver",
            "Wind Maneuver",
            "Not Selected"});
            this.Maneuver3select.Location = new System.Drawing.Point(10, 74);
            this.Maneuver3select.Name = "Maneuver3select";
            this.Maneuver3select.Size = new System.Drawing.Size(116, 21);
            this.Maneuver3select.TabIndex = 44;
            this.Maneuver3select.Text = "Not Selected";
            this.Maneuver3select.SelectedIndexChanged += new System.EventHandler(this.Maneuver3select_SelectedIndexChanged);
            // 
            // Maneuver2select
            // 
            this.Maneuver2select.FormattingEnabled = true;
            this.Maneuver2select.Items.AddRange(new object[] {
            "Dark Maneuver",
            "Earth Maneuver",
            "Fire Maneuver",
            "Ice Maneuver",
            "Light Maneuver",
            "Thunder Maneuver",
            "Water Maneuver",
            "Wind Maneuver",
            "Not Selected"});
            this.Maneuver2select.Location = new System.Drawing.Point(10, 47);
            this.Maneuver2select.Name = "Maneuver2select";
            this.Maneuver2select.Size = new System.Drawing.Size(116, 21);
            this.Maneuver2select.TabIndex = 43;
            this.Maneuver2select.Text = "Not Selected";
            this.Maneuver2select.SelectedIndexChanged += new System.EventHandler(this.Maneuver2select_SelectedIndexChanged);
            // 
            // Maneuver1set
            // 
            this.Maneuver1set.Enabled = false;
            this.Maneuver1set.Location = new System.Drawing.Point(176, 21);
            this.Maneuver1set.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.Maneuver1set.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Maneuver1set.Name = "Maneuver1set";
            this.Maneuver1set.Size = new System.Drawing.Size(28, 20);
            this.Maneuver1set.TabIndex = 36;
            this.Maneuver1set.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Maneuver2set
            // 
            this.Maneuver2set.Enabled = false;
            this.Maneuver2set.Location = new System.Drawing.Point(176, 48);
            this.Maneuver2set.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.Maneuver2set.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Maneuver2set.Name = "Maneuver2set";
            this.Maneuver2set.Size = new System.Drawing.Size(28, 20);
            this.Maneuver2set.TabIndex = 37;
            this.Maneuver2set.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Maneuver3set
            // 
            this.Maneuver3set.Enabled = false;
            this.Maneuver3set.Location = new System.Drawing.Point(176, 75);
            this.Maneuver3set.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.Maneuver3set.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Maneuver3set.Name = "Maneuver3set";
            this.Maneuver3set.Size = new System.Drawing.Size(28, 20);
            this.Maneuver3set.TabIndex = 38;
            this.Maneuver3set.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Maneuver1select
            // 
            this.Maneuver1select.FormattingEnabled = true;
            this.Maneuver1select.Items.AddRange(new object[] {
            "Dark Maneuver",
            "Earth Maneuver",
            "Fire Maneuver",
            "Ice Maneuver",
            "Light Maneuver",
            "Thunder Maneuver",
            "Water Maneuver",
            "Wind Maneuver",
            "Not Selected"});
            this.Maneuver1select.Location = new System.Drawing.Point(10, 20);
            this.Maneuver1select.Name = "Maneuver1select";
            this.Maneuver1select.Size = new System.Drawing.Size(116, 21);
            this.Maneuver1select.TabIndex = 42;
            this.Maneuver1select.Text = "Not Selected";
            this.Maneuver1select.SelectedIndexChanged += new System.EventHandler(this.Maneuver1select_SelectedIndexChanged);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(132, 50);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(38, 13);
            this.label49.TabIndex = 39;
            this.label49.Text = "Count:";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(132, 77);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(38, 13);
            this.label56.TabIndex = 41;
            this.label56.Text = "Count:";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(132, 23);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(38, 13);
            this.label51.TabIndex = 40;
            this.label51.Text = "Count:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.healforAutomatonMP);
            this.groupBox4.Controls.Add(this.healforAutomatonHP);
            this.groupBox4.Controls.Add(this.healforAutomatonMPset);
            this.groupBox4.Controls.Add(this.healforAutomatonHPset);
            this.groupBox4.Location = new System.Drawing.Point(259, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(127, 70);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Auto /Heal";
            // 
            // healforAutomatonMP
            // 
            this.healforAutomatonMP.AutoSize = true;
            this.healforAutomatonMP.Location = new System.Drawing.Point(9, 43);
            this.healforAutomatonMP.Name = "healforAutomatonMP";
            this.healforAutomatonMP.Size = new System.Drawing.Size(64, 17);
            this.healforAutomatonMP.TabIndex = 6;
            this.healforAutomatonMP.Text = "MP% @";
            this.healforAutomatonMP.UseVisualStyleBackColor = true;
            // 
            // healforAutomatonHP
            // 
            this.healforAutomatonHP.AutoSize = true;
            this.healforAutomatonHP.Location = new System.Drawing.Point(9, 20);
            this.healforAutomatonHP.Name = "healforAutomatonHP";
            this.healforAutomatonHP.Size = new System.Drawing.Size(63, 17);
            this.healforAutomatonHP.TabIndex = 5;
            this.healforAutomatonHP.Text = "HP% @";
            this.healforAutomatonHP.UseVisualStyleBackColor = true;
            // 
            // healforAutomatonMPset
            // 
            this.healforAutomatonMPset.Location = new System.Drawing.Point(77, 42);
            this.healforAutomatonMPset.Name = "healforAutomatonMPset";
            this.healforAutomatonMPset.Size = new System.Drawing.Size(38, 20);
            this.healforAutomatonMPset.TabIndex = 4;
            // 
            // healforAutomatonHPset
            // 
            this.healforAutomatonHPset.Location = new System.Drawing.Point(77, 19);
            this.healforAutomatonHPset.Name = "healforAutomatonHPset";
            this.healforAutomatonHPset.Size = new System.Drawing.Size(38, 20);
            this.healforAutomatonHPset.TabIndex = 3;
            // 
            // AutoCallPUP
            // 
            this.AutoCallPUP.AutoSize = true;
            this.AutoCallPUP.Location = new System.Drawing.Point(8, 6);
            this.AutoCallPUP.Name = "AutoCallPUP";
            this.AutoCallPUP.Size = new System.Drawing.Size(122, 17);
            this.AutoCallPUP.TabIndex = 15;
            this.AutoCallPUP.Text = "Auto Call Automaton";
            this.AutoCallPUP.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.PUPJA);
            this.groupBox5.Location = new System.Drawing.Point(8, 48);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(158, 152);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Pet JA";
            // 
            // PUPJA
            // 
            this.PUPJA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PUPJA.CheckOnClick = true;
            this.PUPJA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PUPJA.FormattingEnabled = true;
            this.PUPJA.Location = new System.Drawing.Point(3, 16);
            this.PUPJA.Name = "PUPJA";
            this.PUPJA.Size = new System.Drawing.Size(152, 133);
            this.PUPJA.TabIndex = 1;
            this.PUPJA.SelectedIndexChanged += new System.EventHandler(this.PUPJA_SelectedIndexChanged);
            // 
            // PUPautoengage
            // 
            this.PUPautoengage.AutoSize = true;
            this.PUPautoengage.Location = new System.Drawing.Point(8, 25);
            this.PUPautoengage.Name = "PUPautoengage";
            this.PUPautoengage.Size = new System.Drawing.Size(142, 17);
            this.PUPautoengage.TabIndex = 3;
            this.PUPautoengage.Text = "Auto Engage Automaton";
            this.PUPautoengage.UseVisualStyleBackColor = true;
            // 
            // PUPOtherpage
            // 
            this.PUPOtherpage.Controls.Add(this.Ventriloquygroup);
            this.PUPOtherpage.Controls.Add(this.Repairgroup);
            this.PUPOtherpage.Controls.Add(this.TacticalSwitchgroup);
            this.PUPOtherpage.Controls.Add(this.RoleReversalgroup);
            this.PUPOtherpage.Location = new System.Drawing.Point(4, 22);
            this.PUPOtherpage.Name = "PUPOtherpage";
            this.PUPOtherpage.Padding = new System.Windows.Forms.Padding(3);
            this.PUPOtherpage.Size = new System.Drawing.Size(395, 209);
            this.PUPOtherpage.TabIndex = 2;
            this.PUPOtherpage.Text = "Other";
            this.PUPOtherpage.UseVisualStyleBackColor = true;
            // 
            // Ventriloquygroup
            // 
            this.Ventriloquygroup.Controls.Add(this.VentriloquyPet);
            this.Ventriloquygroup.Controls.Add(this.VentriloquyPlayer);
            this.Ventriloquygroup.Enabled = false;
            this.Ventriloquygroup.Location = new System.Drawing.Point(226, 93);
            this.Ventriloquygroup.Name = "Ventriloquygroup";
            this.Ventriloquygroup.Size = new System.Drawing.Size(157, 66);
            this.Ventriloquygroup.TabIndex = 6;
            this.Ventriloquygroup.TabStop = false;
            this.Ventriloquygroup.Text = "Ventriloquy";
            // 
            // VentriloquyPet
            // 
            this.VentriloquyPet.AutoSize = true;
            this.VentriloquyPet.Location = new System.Drawing.Point(12, 42);
            this.VentriloquyPet.Name = "VentriloquyPet";
            this.VentriloquyPet.Size = new System.Drawing.Size(118, 17);
            this.VentriloquyPet.TabIndex = 1;
            this.VentriloquyPet.TabStop = true;
            this.VentriloquyPet.Text = "Keep Target on Pet";
            this.VentriloquyPet.UseVisualStyleBackColor = true;
            // 
            // VentriloquyPlayer
            // 
            this.VentriloquyPlayer.AutoSize = true;
            this.VentriloquyPlayer.Location = new System.Drawing.Point(12, 19);
            this.VentriloquyPlayer.Name = "VentriloquyPlayer";
            this.VentriloquyPlayer.Size = new System.Drawing.Size(131, 17);
            this.VentriloquyPlayer.TabIndex = 0;
            this.VentriloquyPlayer.TabStop = true;
            this.VentriloquyPlayer.Text = "Keep Target on Player";
            this.VentriloquyPlayer.UseVisualStyleBackColor = true;
            // 
            // Repairgroup
            // 
            this.Repairgroup.Controls.Add(this.Repairselect);
            this.Repairgroup.Controls.Add(this.label18);
            this.Repairgroup.Controls.Add(this.Repairset);
            this.Repairgroup.Controls.Add(this.label14);
            this.Repairgroup.Enabled = false;
            this.Repairgroup.Location = new System.Drawing.Point(226, 11);
            this.Repairgroup.Name = "Repairgroup";
            this.Repairgroup.Size = new System.Drawing.Size(163, 76);
            this.Repairgroup.TabIndex = 5;
            this.Repairgroup.TabStop = false;
            this.Repairgroup.Text = "Repair";
            // 
            // Repairselect
            // 
            this.Repairselect.FormattingEnabled = true;
            this.Repairselect.Items.AddRange(new object[] {
            "Automaton Oil",
            "Automat. Oil +1",
            "Automat. Oil +2",
            "Automat. Oil +3"});
            this.Repairselect.Location = new System.Drawing.Point(45, 19);
            this.Repairselect.Name = "Repairselect";
            this.Repairselect.Size = new System.Drawing.Size(112, 21);
            this.Repairselect.TabIndex = 35;
            this.Repairselect.Text = "Automaton Oil";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(9, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(32, 13);
            this.label18.TabIndex = 34;
            this.label18.Text = "With:";
            // 
            // Repairset
            // 
            this.Repairset.Location = new System.Drawing.Point(118, 46);
            this.Repairset.Name = "Repairset";
            this.Repairset.Size = new System.Drawing.Size(39, 20);
            this.Repairset.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(42, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "@ Pet HP% <";
            // 
            // TacticalSwitchgroup
            // 
            this.TacticalSwitchgroup.Controls.Add(this.TSPET);
            this.TacticalSwitchgroup.Controls.Add(this.TSPlayer);
            this.TacticalSwitchgroup.Controls.Add(this.TSPetTPset);
            this.TacticalSwitchgroup.Controls.Add(this.TSPlayerTPset);
            this.TacticalSwitchgroup.Controls.Add(this.label26);
            this.TacticalSwitchgroup.Controls.Add(this.label41);
            this.TacticalSwitchgroup.Enabled = false;
            this.TacticalSwitchgroup.Location = new System.Drawing.Point(8, 82);
            this.TacticalSwitchgroup.Name = "TacticalSwitchgroup";
            this.TacticalSwitchgroup.Size = new System.Drawing.Size(211, 66);
            this.TacticalSwitchgroup.TabIndex = 1;
            this.TacticalSwitchgroup.TabStop = false;
            this.TacticalSwitchgroup.Text = "Tactical Switch";
            // 
            // TSPET
            // 
            this.TSPET.AutoSize = true;
            this.TSPET.Location = new System.Drawing.Point(7, 41);
            this.TSPET.Name = "TSPET";
            this.TSPET.Size = new System.Drawing.Size(94, 17);
            this.TSPET.TabIndex = 5;
            this.TSPET.Text = "For Automaton";
            this.TSPET.UseVisualStyleBackColor = true;
            // 
            // TSPlayer
            // 
            this.TSPlayer.AutoSize = true;
            this.TSPlayer.Location = new System.Drawing.Point(7, 16);
            this.TSPlayer.Name = "TSPlayer";
            this.TSPlayer.Size = new System.Drawing.Size(72, 17);
            this.TSPlayer.TabIndex = 4;
            this.TSPlayer.Text = "For Player";
            this.TSPlayer.UseVisualStyleBackColor = true;
            // 
            // TSPetTPset
            // 
            this.TSPetTPset.Location = new System.Drawing.Point(159, 40);
            this.TSPetTPset.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.TSPetTPset.Name = "TSPetTPset";
            this.TSPetTPset.Size = new System.Drawing.Size(46, 20);
            this.TSPetTPset.TabIndex = 3;
            // 
            // TSPlayerTPset
            // 
            this.TSPlayerTPset.Location = new System.Drawing.Point(160, 14);
            this.TSPlayerTPset.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.TSPlayerTPset.Name = "TSPlayerTPset";
            this.TSPlayerTPset.Size = new System.Drawing.Size(45, 20);
            this.TSPlayerTPset.TabIndex = 2;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(113, 42);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(40, 13);
            this.label26.TabIndex = 1;
            this.label26.Text = "Pet TP";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(101, 16);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(53, 13);
            this.label41.TabIndex = 0;
            this.label41.Text = "Player TP";
            // 
            // RoleReversalgroup
            // 
            this.RoleReversalgroup.Controls.Add(this.RRPET);
            this.RoleReversalgroup.Controls.Add(this.RRPlayer);
            this.RoleReversalgroup.Controls.Add(this.RRPetHPPset);
            this.RoleReversalgroup.Controls.Add(this.RRPlayerHPPset);
            this.RoleReversalgroup.Controls.Add(this.label24);
            this.RoleReversalgroup.Controls.Add(this.label19);
            this.RoleReversalgroup.Enabled = false;
            this.RoleReversalgroup.Location = new System.Drawing.Point(8, 11);
            this.RoleReversalgroup.Name = "RoleReversalgroup";
            this.RoleReversalgroup.Size = new System.Drawing.Size(211, 65);
            this.RoleReversalgroup.TabIndex = 0;
            this.RoleReversalgroup.TabStop = false;
            this.RoleReversalgroup.Text = "Role Reversal";
            // 
            // RRPET
            // 
            this.RRPET.AutoSize = true;
            this.RRPET.Location = new System.Drawing.Point(7, 41);
            this.RRPET.Name = "RRPET";
            this.RRPET.Size = new System.Drawing.Size(94, 17);
            this.RRPET.TabIndex = 5;
            this.RRPET.Text = "For Automaton";
            this.RRPET.UseVisualStyleBackColor = true;
            // 
            // RRPlayer
            // 
            this.RRPlayer.AutoSize = true;
            this.RRPlayer.Location = new System.Drawing.Point(7, 16);
            this.RRPlayer.Name = "RRPlayer";
            this.RRPlayer.Size = new System.Drawing.Size(72, 17);
            this.RRPlayer.TabIndex = 4;
            this.RRPlayer.Text = "For Player";
            this.RRPlayer.UseVisualStyleBackColor = true;
            // 
            // RRPetHPPset
            // 
            this.RRPetHPPset.Location = new System.Drawing.Point(167, 40);
            this.RRPetHPPset.Name = "RRPetHPPset";
            this.RRPetHPPset.Size = new System.Drawing.Size(38, 20);
            this.RRPetHPPset.TabIndex = 3;
            // 
            // RRPlayerHPPset
            // 
            this.RRPlayerHPPset.Location = new System.Drawing.Point(167, 14);
            this.RRPlayerHPPset.Name = "RRPlayerHPPset";
            this.RRPlayerHPPset.Size = new System.Drawing.Size(38, 20);
            this.RRPlayerHPPset.TabIndex = 2;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(113, 42);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(49, 13);
            this.label24.TabIndex = 1;
            this.label24.Text = "Pet HP%";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(101, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(62, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Player HP%";
            // 
            // geopettab
            // 
            this.geopettab.Controls.Add(this.panel2);
            this.geopettab.Controls.Add(this.label57);
            this.geopettab.Controls.Add(this.comboBox5);
            this.geopettab.Controls.Add(this.groupBox6);
            this.geopettab.Location = new System.Drawing.Point(4, 22);
            this.geopettab.Name = "geopettab";
            this.geopettab.Padding = new System.Windows.Forms.Padding(3);
            this.geopettab.Size = new System.Drawing.Size(415, 247);
            this.geopettab.TabIndex = 4;
            this.geopettab.Text = "GEO";
            this.geopettab.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label40);
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(405, 237);
            this.panel2.TabIndex = 17;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Enabled = false;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label40.Location = new System.Drawing.Point(116, 106);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(173, 25);
            this.label40.TabIndex = 0;
            this.label40.Text = "Not Implemented";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(35, 10);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(41, 13);
            this.label57.TabIndex = 16;
            this.label57.Text = "label57";
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(103, 7);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(121, 21);
            this.comboBox5.TabIndex = 15;
            this.comboBox5.Text = "Test";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.GEOJA);
            this.groupBox6.Location = new System.Drawing.Point(14, 73);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(176, 159);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Pet JA";
            // 
            // GEOJA
            // 
            this.GEOJA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GEOJA.CheckOnClick = true;
            this.GEOJA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GEOJA.FormattingEnabled = true;
            this.GEOJA.Location = new System.Drawing.Point(3, 16);
            this.GEOJA.Name = "GEOJA";
            this.GEOJA.Size = new System.Drawing.Size(170, 140);
            this.GEOJA.TabIndex = 1;
            // 
            // trustControl
            // 
            this.trustControl.Controls.Add(this.label63);
            this.trustControl.Controls.Add(this.label61);
            this.trustControl.Controls.Add(this.selectedtrusts);
            this.trustControl.Controls.Add(this.maxtrustslabel);
            this.trustControl.Controls.Add(this.Trusts);
            this.trustControl.Controls.Add(this.trustmenuStrip);
            this.trustControl.Location = new System.Drawing.Point(4, 22);
            this.trustControl.Name = "trustControl";
            this.trustControl.Padding = new System.Windows.Forms.Padding(3);
            this.trustControl.Size = new System.Drawing.Size(439, 361);
            this.trustControl.TabIndex = 8;
            this.trustControl.Text = "Trust";
            this.trustControl.UseVisualStyleBackColor = true;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(230, 139);
            this.label63.MaximumSize = new System.Drawing.Size(181, 0);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(167, 26);
            this.label63.TabIndex = 18;
            this.label63.Text = "To be able to reselect Trusts click on the \"Reset Trusts\" button.";
            this.label63.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(227, 100);
            this.label61.MaximumSize = new System.Drawing.Size(184, 0);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(184, 26);
            this.label61.TabIndex = 16;
            this.label61.Text = "Once you hit your max Trust limit it will gray out the selection box.";
            this.label61.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // selectedtrusts
            // 
            this.selectedtrusts.AutoSize = true;
            this.selectedtrusts.Location = new System.Drawing.Point(273, 60);
            this.selectedtrusts.Name = "selectedtrusts";
            this.selectedtrusts.Size = new System.Drawing.Size(96, 13);
            this.selectedtrusts.TabIndex = 15;
            this.selectedtrusts.Text = "Selected Trusts : 0";
            // 
            // maxtrustslabel
            // 
            this.maxtrustslabel.AutoSize = true;
            this.maxtrustslabel.Location = new System.Drawing.Point(295, 23);
            this.maxtrustslabel.Name = "maxtrustslabel";
            this.maxtrustslabel.Size = new System.Drawing.Size(74, 13);
            this.maxtrustslabel.TabIndex = 14;
            this.maxtrustslabel.Text = "Max Trusts : 0";
            // 
            // Trusts
            // 
            this.Trusts.CheckOnClick = true;
            this.Trusts.FormattingEnabled = true;
            this.Trusts.Location = new System.Drawing.Point(26, 23);
            this.Trusts.Name = "Trusts";
            this.Trusts.Size = new System.Drawing.Size(164, 274);
            this.Trusts.TabIndex = 13;
            this.Trusts.SelectedIndexChanged += new System.EventHandler(this.Trusts_SelectedIndexChanged);
            // 
            // trustmenuStrip
            // 
            this.trustmenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.trustmenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trustMenureset});
            this.trustmenuStrip.Location = new System.Drawing.Point(56, 304);
            this.trustmenuStrip.Name = "trustmenuStrip";
            this.trustmenuStrip.Size = new System.Drawing.Size(90, 24);
            this.trustmenuStrip.TabIndex = 12;
            this.trustmenuStrip.Text = "trustmenuStrip";
            // 
            // trustMenureset
            // 
            this.trustMenureset.Name = "trustMenureset";
            this.trustMenureset.Size = new System.Drawing.Size(82, 20);
            this.trustMenureset.Text = "Reset Trusts";
            this.trustMenureset.Click += new System.EventHandler(this.trustMenureset_Click);
            // 
            // hudpage
            // 
            this.hudpage.Controls.Add(this.hudinfobutton);
            this.hudpage.Controls.Add(this.advhudtext);
            this.hudpage.Controls.Add(this.hudtext);
            this.hudpage.Controls.Add(this.hudY);
            this.hudpage.Controls.Add(this.hudYlabel);
            this.hudpage.Controls.Add(this.hudX);
            this.hudpage.Controls.Add(this.hudXlabel);
            this.hudpage.Controls.Add(this.showHUD);
            this.hudpage.Location = new System.Drawing.Point(4, 22);
            this.hudpage.Name = "hudpage";
            this.hudpage.Padding = new System.Windows.Forms.Padding(3);
            this.hudpage.Size = new System.Drawing.Size(439, 361);
            this.hudpage.TabIndex = 9;
            this.hudpage.Text = "In-Game HUD";
            this.hudpage.UseVisualStyleBackColor = true;
            // 
            // hudinfobutton
            // 
            this.hudinfobutton.Location = new System.Drawing.Point(343, 43);
            this.hudinfobutton.Name = "hudinfobutton";
            this.hudinfobutton.Size = new System.Drawing.Size(39, 20);
            this.hudinfobutton.TabIndex = 24;
            this.hudinfobutton.Text = "Info";
            this.hudinfobutton.UseVisualStyleBackColor = true;
            this.hudinfobutton.Click += new System.EventHandler(this.hudinfobutton_Click);
            // 
            // advhudtext
            // 
            this.advhudtext.AutoSize = true;
            this.advhudtext.Location = new System.Drawing.Point(57, 47);
            this.advhudtext.Name = "advhudtext";
            this.advhudtext.Size = new System.Drawing.Size(288, 13);
            this.advhudtext.TabIndex = 23;
            this.advhudtext.Text = "!ADV HUD (How you see it here is how it will be on screen)!";
            // 
            // hudtext
            // 
            this.hudtext.Location = new System.Drawing.Point(6, 66);
            this.hudtext.Multiline = true;
            this.hudtext.Name = "hudtext";
            this.hudtext.Size = new System.Drawing.Size(427, 287);
            this.hudtext.TabIndex = 22;
            this.hudtext.TabStop = false;
            this.hudtext.Text = "Scripted:{0}\r\nTargeting Mode: {1}\r\nHP: {7}/{8}\r\nMP: {10}/{11}\r\nTP: {13}\r\nCurrent " +
    "Target: {25}\r\nTarget HP: {27}%\r\nCurrent Game Time: {31}:{32}\r\nRunning: {30}\r\nInd" +
    "i- info: {35}\r\n\r\n";
            this.hudtext.WordWrap = false;
            // 
            // hudY
            // 
            this.hudY.Location = new System.Drawing.Point(354, 14);
            this.hudY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.hudY.Name = "hudY";
            this.hudY.Size = new System.Drawing.Size(46, 20);
            this.hudY.TabIndex = 21;
            this.hudY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hudYlabel
            // 
            this.hudYlabel.AutoSize = true;
            this.hudYlabel.Location = new System.Drawing.Point(337, 17);
            this.hudYlabel.Name = "hudYlabel";
            this.hudYlabel.Size = new System.Drawing.Size(17, 13);
            this.hudYlabel.TabIndex = 20;
            this.hudYlabel.Text = "Y:";
            // 
            // hudX
            // 
            this.hudX.Location = new System.Drawing.Point(285, 14);
            this.hudX.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.hudX.Name = "hudX";
            this.hudX.Size = new System.Drawing.Size(46, 20);
            this.hudX.TabIndex = 19;
            this.hudX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hudXlabel
            // 
            this.hudXlabel.AutoSize = true;
            this.hudXlabel.Location = new System.Drawing.Point(223, 16);
            this.hudXlabel.Name = "hudXlabel";
            this.hudXlabel.Size = new System.Drawing.Size(57, 13);
            this.hudXlabel.TabIndex = 18;
            this.hudXlabel.Text = "Position X:";
            // 
            // showHUD
            // 
            this.showHUD.AutoSize = true;
            this.showHUD.Location = new System.Drawing.Point(39, 15);
            this.showHUD.Name = "showHUD";
            this.showHUD.Size = new System.Drawing.Size(181, 17);
            this.showHUD.TabIndex = 17;
            this.showHUD.Text = "In-Game HUD (Fill for ADV HUD)";
            this.showHUD.ThreeState = true;
            this.showHUD.UseVisualStyleBackColor = true;
            this.showHUD.CheckedChanged += new System.EventHandler(this.showHUD_CheckedChanged);
            // 
            // numericUpDown8
            // 
            this.numericUpDown8.Location = new System.Drawing.Point(333, 137);
            this.numericUpDown8.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown8.Name = "numericUpDown8";
            this.numericUpDown8.Size = new System.Drawing.Size(28, 20);
            this.numericUpDown8.TabIndex = 31;
            // 
            // numericUpDown9
            // 
            this.numericUpDown9.Location = new System.Drawing.Point(333, 96);
            this.numericUpDown9.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown9.Name = "numericUpDown9";
            this.numericUpDown9.Size = new System.Drawing.Size(28, 20);
            this.numericUpDown9.TabIndex = 30;
            // 
            // numericUpDown10
            // 
            this.numericUpDown10.Location = new System.Drawing.Point(333, 55);
            this.numericUpDown10.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown10.Name = "numericUpDown10";
            this.numericUpDown10.Size = new System.Drawing.Size(28, 20);
            this.numericUpDown10.TabIndex = 29;
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Location = new System.Drawing.Point(333, 14);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(28, 20);
            this.numericUpDown5.TabIndex = 28;
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(139, 138);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(28, 20);
            this.numericUpDown4.TabIndex = 27;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(139, 96);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(28, 20);
            this.numericUpDown3.TabIndex = 26;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(139, 55);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(28, 20);
            this.numericUpDown2.TabIndex = 25;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(139, 14);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(28, 20);
            this.numericUpDown1.TabIndex = 24;
            // 
            // bgw_script_dnc
            // 
            this.bgw_script_dnc.WorkerReportsProgress = true;
            this.bgw_script_dnc.WorkerSupportsCancellation = true;
            this.bgw_script_dnc.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwScriptDncDoWork);
            // 
            // bgw_script_nav
            // 
            this.bgw_script_nav.WorkerReportsProgress = true;
            this.bgw_script_nav.WorkerSupportsCancellation = true;
            this.bgw_script_nav.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwScriptNavDoWork);
            // 
            // bgw_script_sch
            // 
            this.bgw_script_sch.WorkerReportsProgress = true;
            this.bgw_script_sch.WorkerSupportsCancellation = true;
            this.bgw_script_sch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwScriptSCHChargesDoWork);
            // 
            // bgw_script_disp
            // 
            this.bgw_script_disp.WorkerReportsProgress = true;
            this.bgw_script_disp.WorkerSupportsCancellation = true;
            this.bgw_script_disp.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwScriptDisplayDoWork);
            // 
            // bgw_script_chat
            // 
            this.bgw_script_chat.WorkerReportsProgress = true;
            this.bgw_script_chat.WorkerSupportsCancellation = true;
            this.bgw_script_chat.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwScriptchatWatchDoWork);
            // 
            // bgw_script_pet
            // 
            this.bgw_script_pet.WorkerReportsProgress = true;
            this.bgw_script_pet.WorkerSupportsCancellation = true;
            this.bgw_script_pet.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwScriptPetDoWork);
            // 
            // DeathWarp
            // 
            this.DeathWarp.AutoSize = true;
            this.DeathWarp.Location = new System.Drawing.Point(167, 188);
            this.DeathWarp.Name = "DeathWarp";
            this.DeathWarp.Size = new System.Drawing.Size(99, 17);
            this.DeathWarp.TabIndex = 52;
            this.DeathWarp.Text = "Warp on Death";
            this.DeathWarp.UseVisualStyleBackColor = true;
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.playerjobpoints);
            this.groupBox18.Controls.Add(this.playermerits);
            this.groupBox18.Controls.Add(this.Runtest);
            this.groupBox18.Controls.Add(this.playertp);
            this.groupBox18.Controls.Add(this.playermp);
            this.groupBox18.Controls.Add(this.playerhp);
            this.groupBox18.Location = new System.Drawing.Point(13, 3);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(253, 93);
            this.groupBox18.TabIndex = 53;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Player info";
            // 
            // playerjobpoints
            // 
            this.playerjobpoints.AutoSize = true;
            this.playerjobpoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerjobpoints.Location = new System.Drawing.Point(122, 73);
            this.playerjobpoints.Name = "playerjobpoints";
            this.playerjobpoints.Size = new System.Drawing.Size(109, 13);
            this.playerjobpoints.TabIndex = 8;
            this.playerjobpoints.Text = "Job Points: Cant Gain";
            // 
            // playermerits
            // 
            this.playermerits.AutoSize = true;
            this.playermerits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playermerits.Location = new System.Drawing.Point(6, 73);
            this.playermerits.Name = "playermerits";
            this.playermerits.Size = new System.Drawing.Size(115, 13);
            this.playermerits.TabIndex = 7;
            this.playermerits.Text = "Merit Points: Cant Gain";
            // 
            // Runtest
            // 
            this.Runtest.Enabled = false;
            this.Runtest.Location = new System.Drawing.Point(142, 25);
            this.Runtest.Name = "Runtest";
            this.Runtest.Size = new System.Drawing.Size(75, 23);
            this.Runtest.TabIndex = 6;
            this.Runtest.Text = "Run Test";
            this.Runtest.UseVisualStyleBackColor = true;
            this.Runtest.Visible = false;
            this.Runtest.Click += new System.EventHandler(this.Run_Test_Code);
            // 
            // playertp
            // 
            this.playertp.AutoSize = true;
            this.playertp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playertp.Location = new System.Drawing.Point(6, 54);
            this.playertp.Name = "playertp";
            this.playertp.Size = new System.Drawing.Size(33, 13);
            this.playertp.TabIndex = 2;
            this.playertp.Text = "TP: 0";
            // 
            // playermp
            // 
            this.playermp.AutoSize = true;
            this.playermp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playermp.Location = new System.Drawing.Point(6, 35);
            this.playermp.Name = "playermp";
            this.playermp.Size = new System.Drawing.Size(46, 13);
            this.playermp.TabIndex = 1;
            this.playermp.Text = "MP: 0/0";
            // 
            // playerhp
            // 
            this.playerhp.AutoSize = true;
            this.playerhp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerhp.Location = new System.Drawing.Point(6, 16);
            this.playerhp.Name = "playerhp";
            this.playerhp.Size = new System.Drawing.Size(45, 13);
            this.playerhp.TabIndex = 0;
            this.playerhp.Text = "HP: 0/0";
            // 
            // curtime
            // 
            this.curtime.AutoSize = true;
            this.curtime.Location = new System.Drawing.Point(61, 64);
            this.curtime.Name = "curtime";
            this.curtime.Size = new System.Drawing.Size(131, 13);
            this.curtime.TabIndex = 5;
            this.curtime.Text = "Current Game Time: 00:00";
            // 
            // curtarghpp
            // 
            this.curtarghpp.AutoSize = true;
            this.curtarghpp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curtarghpp.Location = new System.Drawing.Point(5, 48);
            this.curtarghpp.Name = "curtarghpp";
            this.curtarghpp.Size = new System.Drawing.Size(76, 13);
            this.curtarghpp.TabIndex = 4;
            this.curtarghpp.Text = "Target HP: 0%";
            // 
            // curtarg
            // 
            this.curtarg.AutoSize = true;
            this.curtarg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curtarg.Location = new System.Drawing.Point(5, 16);
            this.curtarg.Name = "curtarg";
            this.curtarg.Size = new System.Drawing.Size(78, 13);
            this.curtarg.TabIndex = 3;
            this.curtarg.Text = "Current Target:";
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.curtargid);
            this.groupBox23.Controls.Add(this.curtarg);
            this.groupBox23.Controls.Add(this.curtime);
            this.groupBox23.Controls.Add(this.curtarghpp);
            this.groupBox23.Location = new System.Drawing.Point(14, 101);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(252, 81);
            this.groupBox23.TabIndex = 54;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Other Info";
            // 
            // curtargid
            // 
            this.curtargid.AutoSize = true;
            this.curtargid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curtargid.Location = new System.Drawing.Point(5, 32);
            this.curtargid.Name = "curtargid";
            this.curtargid.Size = new System.Drawing.Size(21, 13);
            this.curtargid.TabIndex = 6;
            this.curtargid.Text = "ID:";
            // 
            // Shrinkbutton
            // 
            this.Shrinkbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Shrinkbutton.Location = new System.Drawing.Point(0, 129);
            this.Shrinkbutton.Name = "Shrinkbutton";
            this.Shrinkbutton.Size = new System.Drawing.Size(13, 40);
            this.Shrinkbutton.TabIndex = 55;
            this.Shrinkbutton.Text = "<<";
            this.Shrinkbutton.UseVisualStyleBackColor = true;
            this.Shrinkbutton.Click += new System.EventHandler(this.Shrinkbutton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox8);
            this.panel1.Controls.Add(this.groupBox18);
            this.panel1.Controls.Add(this.Shrinkbutton);
            this.panel1.Controls.Add(this.checkZone);
            this.panel1.Controls.Add(this.StartStopScript);
            this.panel1.Controls.Add(this.StopFullInventory);
            this.panel1.Controls.Add(this.groupBox23);
            this.panel1.Controls.Add(this.DeathWarp);
            this.panel1.Controls.Add(this.usenav);
            this.panel1.Location = new System.Drawing.Point(459, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 384);
            this.panel1.TabIndex = 57;
            // 
            // IdleLocationDist
            // 
            this.IdleLocationDist.Location = new System.Drawing.Point(176, 116);
            this.IdleLocationDist.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.IdleLocationDist.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IdleLocationDist.Name = "IdleLocationDist";
            this.IdleLocationDist.Size = new System.Drawing.Size(44, 20);
            this.IdleLocationDist.TabIndex = 71;
            this.IdleLocationDist.TabStop = false;
            this.IdleLocationDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IdleLocationDist.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ScriptFarmDNC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dncControl);
            this.Name = "ScriptFarmDNC";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 7, 25);
            this.Size = new System.Drawing.Size(739, 440);
            this.Load += new System.EventHandler(this.ScriptFarmDncLoad);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.GetSetNavi.ResumeLayout(false);
            this.GetSetNavi.PerformLayout();
            this.StartStopScript.ResumeLayout(false);
            this.StartStopScript.PerformLayout();
            this.dncControl.ResumeLayout(false);
            this.targets.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ZoneTargets.ResumeLayout(false);
            this.ZoneTargets.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.GetSetTargets.ResumeLayout(false);
            this.GetSetTargets.PerformLayout();
            this.selecttargets.ResumeLayout(false);
            this.combat.ResumeLayout(false);
            this.CombatSettingsTabs.ResumeLayout(false);
            this.Options1MainTab.ResumeLayout(false);
            this.HateControlgroup.ResumeLayout(false);
            this.HateControlgroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).EndInit();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AfterMathTier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WSDistanceset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WStp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TragetHPPtop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TragetHPPbottom)).EndInit();
            this.Options2MainTab.ResumeLayout(false);
            this.Options2MainTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aggroRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeepTargetRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assistDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.followDist)).EndInit();
            this.Options3MainTab.ResumeLayout(false);
            this.Options3MainTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.healMPcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.healHPcount)).EndInit();
            this.Options4MainTab.ResumeLayout(false);
            this.NotinBattle.ResumeLayout(false);
            this.NotinBattle.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoRangeDelay)).EndInit();
            this.selectapp.ResumeLayout(false);
            this.selectapp.PerformLayout();
            this.shutdowngroup.ResumeLayout(false);
            this.shutdowngroup.PerformLayout();
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StuckDistance)).EndInit();
            this.OptionsJAMainTab.ResumeLayout(false);
            this.JAtabselect.ResumeLayout(false);
            this.selectPage.ResumeLayout(false);
            this.selectPage.PerformLayout();
            this.GetSetJA.ResumeLayout(false);
            this.GetSetJA.PerformLayout();
            this.WHMpage.ResumeLayout(false);
            this.benedictiongroupBox.ResumeLayout(false);
            this.benedictiongroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BenedictionHPPuse)).EndInit();
            this.RDMpage.ResumeLayout(false);
            this.Convertgroup.ResumeLayout(false);
            this.Convertgroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConvertHPP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConvertMPP)).EndInit();
            this.samPage.ResumeLayout(false);
            this.samPage.PerformLayout();
            this.SCHpage.ResumeLayout(false);
            this.SCHpage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sublimationcount)).EndInit();
            this.RUNpage.ResumeLayout(false);
            this.RUNpage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VivaciousPulseHP)).EndInit();
            this.MONpage.ResumeLayout(false);
            this.MONpage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MONmpCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MONhpCount)).EndInit();
            this.OptionsMAMainTab.ResumeLayout(false);
            this.MAtabs.ResumeLayout(false);
            this.MASelectPage.ResumeLayout(false);
            this.MASelectPage.PerformLayout();
            this.GetSetMA.ResumeLayout(false);
            this.GetSetMA.PerformLayout();
            this.CureConfigPage.ResumeLayout(false);
            this.CureConfigPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CuraIIcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Curacount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureIIIcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureIIcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Curecount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CuraIIIcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FullCurecount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureVIcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureVcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureIVcount)).EndInit();
            this.PartyCurepage.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FullCureptcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureVIptcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureVptcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureIVptcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureIIIptcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CureIIptcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cureptcount)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Cureagapage.ResumeLayout(false);
            this.Cureagapage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CuragaVcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CuragaIVcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CuragaIIIcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CuragaIIcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Curagacount)).EndInit();
            this.DrainAspirpage.ResumeLayout(false);
            this.Aspirgroup.ResumeLayout(false);
            this.Aspirgroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AspirIIIcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AspirIIcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Aspircount)).EndInit();
            this.Draingroup.ResumeLayout(false);
            this.Draingroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Draincount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrainIIIcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrainIIcount)).EndInit();
            this.BLUCurespage.ResumeLayout(false);
            this.BLUCurespage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MagicFruitcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pollencount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealingBreezecount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PleniluneEmbracecount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Restoralcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WhiteWindcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exuviationcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WildCarrotcount)).EndInit();
            this.MAconfigpage.ResumeLayout(false);
            this.MAconfigpage.PerformLayout();
            this.Dynamispage.ResumeLayout(false);
            this.Dynamispage.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pullDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobheightdistValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetSearchDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pullTolorance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown21)).EndInit();
            this.dancer.ResumeLayout(false);
            this.dancer.PerformLayout();
            this.tabControl3.ResumeLayout(false);
            this.tabPage14.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stopstepscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usefeatherstepValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usestutterstepValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.useboxstepValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepsHPValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usequickstepValue)).EndInit();
            this.tabPage15.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usecurevValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usecureivValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usecureiiiValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usecureiiValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usecureValue)).EndInit();
            this.tabPage16.ResumeLayout(false);
            this.tabPage16.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown33)).EndInit();
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.GetSetParty.ResumeLayout(false);
            this.GetSetParty.PerformLayout();
            this.flourish.ResumeLayout(false);
            this.flourish.PerformLayout();
            this.flourishesiiigroup.ResumeLayout(false);
            this.flourishesiiigroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.useclmfloValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usestkfloValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.useterfloValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlourishTPValue)).EndInit();
            this.flourishesiigroup.ResumeLayout(false);
            this.flourishesiigroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usewldfloValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usebldfloValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userevfloValue)).EndInit();
            this.flourishesigroup.ResumeLayout(false);
            this.flourishesigroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.useviofloValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usedesfloValue)).EndInit();
            this.pets.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.petControl.ResumeLayout(false);
            this.bstpettab.ResumeLayout(false);
            this.bstpettab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BstJATP)).EndInit();
            this.usepetja.ResumeLayout(false);
            this.bstpetrdygroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pethppfood)).EndInit();
            this.drgpettab.ResumeLayout(false);
            this.drgpettab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DragonPetHP)).EndInit();
            this.drgspirtlinkgroup.ResumeLayout(false);
            this.drgspirtlinkgroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerSpirit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WyvernSpirit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BreathMAX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BreathMIN)).EndInit();
            this.drgrestoringbreathgroup.ResumeLayout(false);
            this.drgrestoringbreathgroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RestoringBreathHP)).EndInit();
            this.drgjagroup.ResumeLayout(false);
            this.smnpettab.ResumeLayout(false);
            this.smnpettab.PerformLayout();
            this.ManaCedegroup.ResumeLayout(false);
            this.ManaCedegroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ManaCedeTPset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManaCedeMPPset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApogeeMPPset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SMNpetMPUSEset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SMNHPPset1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SMNHPPset2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SMNpetTPUSEset)).EndInit();
            this.SMNJAgroup.ResumeLayout(false);
            this.SMNAbilitysgroup.ResumeLayout(false);
            this.puppettab.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.PUPAbilitypage.ResumeLayout(false);
            this.PUPAbilitypage.PerformLayout();
            this.Maneuversgroup.ResumeLayout(false);
            this.Maneuversgroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Maneuver1set)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maneuver2set)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maneuver3set)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.healforAutomatonMPset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.healforAutomatonHPset)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.PUPOtherpage.ResumeLayout(false);
            this.Ventriloquygroup.ResumeLayout(false);
            this.Ventriloquygroup.PerformLayout();
            this.Repairgroup.ResumeLayout(false);
            this.Repairgroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Repairset)).EndInit();
            this.TacticalSwitchgroup.ResumeLayout(false);
            this.TacticalSwitchgroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TSPetTPset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TSPlayerTPset)).EndInit();
            this.RoleReversalgroup.ResumeLayout(false);
            this.RoleReversalgroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RRPetHPPset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RRPlayerHPPset)).EndInit();
            this.geopettab.ResumeLayout(false);
            this.geopettab.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.trustControl.ResumeLayout(false);
            this.trustControl.PerformLayout();
            this.trustmenuStrip.ResumeLayout(false);
            this.trustmenuStrip.PerformLayout();
            this.hudpage.ResumeLayout(false);
            this.hudpage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hudY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hudX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox23.ResumeLayout(false);
            this.groupBox23.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IdleLocationDist)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        #region sysform
        public CheckBox checkZone;
        public CheckBox StopFullInventory;
        public GroupBox groupBox8;
        public CheckBox firstPersonView;
        public CheckBox runReverse;
        public RadioButton Linear;
        public RadioButton Circular;
        public ComboBox selectedNavi;
        public MenuStrip GetSetNavi;
        public ToolStripMenuItem refreshToolStripMenuItem;
        public CheckBox usenav;
        public MenuStrip StartStopScript;
        public ToolStripMenuItem startScriptToolStripMenuItem;
        public ToolStripMenuItem stopScriptToolStripMenuItem;
        public ToolStripMenuItem updateJobToolStripMenuItem;
        public TabControl dncControl;
        public TabPage targets;
        public GroupBox groupBox9;
        public MenuStrip ZoneTargets;
        public ToolStripMenuItem NameListToolStripMenuItem;
        public ToolStripMenuItem iDToolStripMenuItem;
        public GroupBox groupBox11;
        public ListView TargetList;
        public ColumnHeader columnHeader3;
        public ColumnHeader columnHeader4;
        public GroupBox groupBox12;
        public MenuStrip GetSetTargets;
        public ToolStripMenuItem saveToolStripMenuItem;
        public ToolStripMenuItem loadToolStripMenuItem;
        public ToolStripMenuItem clearToolStripMenuItem;
        public GroupBox selecttargets;
        public ListView SelectedTargets;
        public ColumnHeader columnHeader1;
        public ColumnHeader columnHeader2;
        public TabPage combat;
        public TabControl CombatSettingsTabs;
        public TabPage Options1MainTab;
        public GroupBox HateControlgroup;
        public NumericUpDown numericUpDown6;
        public NumericUpDown numericUpDown7;
        public Label label4;
        public Label label5;
        public Label label6;
        public ComboBox selectedHateControl;
        public CheckBox tank;
        public GroupBox groupBox20;
        public ComboBox amname;
        public NumericUpDown AfterMathTier;
        public CheckBox wsam;
        public CheckBox WSDistance;
        public ComboBox selectedWS;
        public NumericUpDown WSDistanceset;
        public CheckBox ws;
        public NumericUpDown WStp;
        public Label label29;
        public NumericUpDown TragetHPPtop;
        public Label label28;
        public NumericUpDown TragetHPPbottom;
        public Label label27;
        public TabPage Options2MainTab;
        public NumericUpDown numericUpDown38;
        public NumericUpDown aggroRange;
        public CheckBox ScanDelay;
        public NumericUpDown KeepTargetRange;
        public NumericUpDown assistDist;
        public NumericUpDown followDist;
        public CheckBox partyAssist;
        public CheckBox facetarget;
        public Label label12;
        public CheckBox assist;
        public CheckBox followplayer;
        public TextBox followName;
        public CheckBox useshadows;
        public Label label11;
        public TextBox assistplayer;
        public CheckBox aggro;
        public CheckBox mobdist;
        public TabPage Options3MainTab;
        public Label label7;
        public Label label3;
        public TextBox foodName;
        public NumericUpDown healMPcount;
        public CheckBox usefood;
        public CheckBox HealMP;
        public NumericUpDown healHPcount;
        public CheckBox HealHP;
        public TextBox textBox6;
        public Label label35;
        public TabPage Options4MainTab;
        public ComboBox comboBox4;
        public ComboBox SignetStaff;
        public CheckBox useStaff;
        public GroupBox groupBox15;
        public Label label42;
        public NumericUpDown autoRangeDelay;
        public TextBox textBox7;
        public CheckBox rangeaggro;
        public ComboBox comboBox1;
        public CheckBox checkBox4;
        public CheckBox autoRangeAttack;
        public Button RecordIdleLocation;
        public CheckBox IdleLocation;
        public CheckBox WeakLocation;
        public TabPage OptionsJAMainTab;
        public CheckedListBox playerJA;
        public MenuStrip GetSetJA;
        public ToolStripMenuItem loadJAsToolStripMenuItem;
        public ToolStripMenuItem clearJAsToolStripMenuItem;
        public GroupBox groupBox14;
        public Label delaytext;
        public NumericUpDown pullDelay;
        public CheckBox AutoLock;
        public CheckBox mobheightdist;
        public CheckBox runTarget;
        public CheckBox runPullDistance;
        public Label mobsearchdisttext;
        public NumericUpDown targetSearchDist;
        public NumericUpDown pullTolorance;
        public Label pulltolorancetext;
        public NumericUpDown numericUpDown21;
        public Label pulldistance;
        public TextBox pullCommand;
        public Label pullcommandtext;
        public TabPage dancer;
        public TabControl tabControl3;
        public TabPage tabPage14;
        public GroupBox groupBox1;
        public RadioButton noSamba;
        public RadioButton usedrainiii;
        public RadioButton usehaste;
        public RadioButton useaspirii;
        public RadioButton useaspir;
        public RadioButton usedrainii;
        public RadioButton usedrain;
        public GroupBox groupBox3;
        public Label stopstepsathptext;
        public NumericUpDown usefeatherstepValue;
        public NumericUpDown usestutterstepValue;
        public NumericUpDown useboxstepValue;
        public NumericUpDown StepsHPValue;
        public NumericUpDown usequickstepValue;
        public CheckBox StepsHP;
        public RadioButton NoSteps;
        public RadioButton usequickstep;
        public RadioButton useboxstep;
        public RadioButton usestutterstep;
        public RadioButton usefeatherstep;
        public TabPage tabPage15;
        public GroupBox groupBox7;
        public CheckBox HWSelectDeselectALL;
        public CheckedListBox HealingWaltzItems;
        public GroupBox groupBox2;
        public Label label32;
        public Label label31;
        public Label label30;
        public Label label25;
        public Label label17;
        public NumericUpDown usecurevValue;
        public NumericUpDown usecureivValue;
        public NumericUpDown usecureiiiValue;
        public NumericUpDown usecureiiValue;
        public NumericUpDown usecureValue;
        public CheckBox usecurev;
        public CheckBox usecureiv;
        public CheckBox usecureiii;
        public CheckBox usecureii;
        public CheckBox usecure;
        public TabPage tabPage16;
        public Label addplayertext;
        public TextBox WaltzPTadd;
        public GroupBox groupBox21;
        public Label label38;
        public Label label37;
        public Label label36;
        public Label label34;
        public Label label33;
        public NumericUpDown numericUpDown27;
        public NumericUpDown numericUpDown28;
        public NumericUpDown numericUpDown29;
        public NumericUpDown numericUpDown32;
        public NumericUpDown numericUpDown33;
        public CheckBox ptusecurev;
        public CheckBox ptusecureiv;
        public CheckBox ptusecureiii;
        public CheckBox ptusecureii;
        public CheckBox ptusecure;
        public GroupBox groupBox22;
        public MenuStrip GetSetParty;
        public ToolStripMenuItem loadPartyToolStripMenuItem;
        public ToolStripMenuItem clearPartyToolStripMenuItem;
        public Label label15;
        public TabPage flourish;
        public GroupBox flourishesiiigroup;
        public NumericUpDown useclmfloValue;
        public NumericUpDown usestkfloValue;
        public NumericUpDown useterfloValue;
        public RadioButton usestkflo;
        public RadioButton useclmflo;
        public RadioButton useterflo;
        public Label finsishingmovetext;
        public NumericUpDown FlourishTPValue;
        public GroupBox flourishesiigroup;
        public NumericUpDown usewldfloValue;
        public NumericUpDown usebldfloValue;
        public NumericUpDown userevfloValue;
        public RadioButton usewldflo;
        public RadioButton usebldflo;
        public RadioButton userevflo;
        public CheckBox FlourishTP;
        public GroupBox flourishesigroup;
        public NumericUpDown usedesfloValue;
        public RadioButton usedesflo;
        public TabPage pets;
        public GroupBox groupBox10;
        public GroupBox groupBox19;
        public TabControl petControl;
        public TabPage bstpettab;
        public GroupBox usepetja;
        public CheckedListBox PetJA;
        public GroupBox bstpetrdygroup;
        public CheckedListBox PetReady;
        public ComboBox usedpetfood;
        public ComboBox jugpet;
        public CheckBox juguse;
        public NumericUpDown pethppfood;
        public Label pethptext;
        public CheckBox petfooduse;
        public CheckBox autoengage;
        public TabPage drgpettab;
        public NumericUpDown DragonPetHP;
        public Label drgsteadywingtext;
        public CheckBox CallWyvern;
        public GroupBox drgspirtlinkgroup;
        public Label label16;
        public NumericUpDown PlayerSpirit;
        public NumericUpDown WyvernSpirit;
        public Label label46;
        public Label label47;
        public NumericUpDown BreathMAX;
        public Label label48;
        public NumericUpDown BreathMIN;
        public Label drgwyvernbreathptext;
        public GroupBox drgrestoringbreathgroup;
        public NumericUpDown RestoringBreathHP;
        public Label label50;
        public GroupBox drgjagroup;
        public CheckedListBox WyvernJA;
        public TabPage smnpettab;
        public TabPage puppettab;
        public System.ComponentModel.BackgroundWorker bgw_script_dnc;
        public System.ComponentModel.BackgroundWorker bgw_script_nav;
        public System.ComponentModel.BackgroundWorker bgw_script_sch;
        public System.ComponentModel.BackgroundWorker bgw_script_disp;
        public System.ComponentModel.BackgroundWorker bgw_script_chat;
        public System.ComponentModel.BackgroundWorker bgw_script_pet;
        public System.ComponentModel.BackgroundWorker bgw_script_npc;
        public System.ComponentModel.BackgroundWorker bgw_script_scn;
        public GroupBox NotinBattle;
        public ComboBox comboBox3;
        public Label label23;
        public Label label22;
        public Label label21;
        public Label label20;
        public CheckBox DeathWarp;
        public NumericUpDown stopstepscount;
        public CheckBox PUPautoengage;
        public CheckBox stopstepsat;
        private TabPage OptionsMAMainTab;
        private TabControl MAtabs;
        private TabPage MASelectPage;
        private TabPage CureConfigPage;
        public CheckedListBox playerMA;
        public MenuStrip GetSetMA;
        public ToolStripMenuItem loadMAsToolStripMenuItem;
        public ToolStripMenuItem clearMAsToolStripMenuItem;
        private Label label44;
        private Label label43;
        private Label label9;
        private Label label2;
        private Label label1;
        private NumericUpDown Curecount;
        private NumericUpDown CureVcount;
        private NumericUpDown CureIVcount;
        private NumericUpDown CureIIIcount;
        private NumericUpDown CureIIcount;
        private NumericUpDown CureVIcount;
        private Label label45;
        private NumericUpDown FullCurecount;
        private Label label52;
        private NumericUpDown CuraIIcount;
        private Label label55;
        private NumericUpDown CuraIIIcount;
        private Label label53;
        private NumericUpDown Curacount;
        private Label label54;
        private TabControl JAtabselect;
        private TabPage selectPage;
        private TabPage WHMpage;
        private GroupBox benedictiongroupBox;
        private NumericUpDown BenedictionHPPuse;
        private Label benedictiontext;
        private TabPage RDMpage;
        private GroupBox Convertgroup;
        private NumericUpDown ConvertHPP;
        private NumericUpDown ConvertMPP;
        private RadioButton ConvertMP;
        private RadioButton ConvertHP;
        private Label convertmptext;
        private Label converthptext;
        private TabPage RUNpage;
        private TabPage MONpage;
        private NumericUpDown MONmpCount;
        private NumericUpDown MONhpCount;
        private Label monmptext;
        private Label monhptext;
        private CheckBox VivaciousPulse;
        private NumericUpDown VivaciousPulseHP;
        private TabPage Dynamispage;
        private Label Dynatxt;
        private CheckBox staggerstopJA;
        private TabPage geopettab;
        private TabPage SCHpage;
        private NumericUpDown Sublimationcount;
        private Label label8;
        private TabPage DrainAspirpage;
        private GroupBox Aspirgroup;
        private NumericUpDown AspirIIIcount;
        private NumericUpDown AspirIIcount;
        private Label AspirIIItext;
        private Label AspirItext;
        private Label AspirIItext;
        private NumericUpDown Aspircount;
        private GroupBox Draingroup;
        private Label DrainIItext;
        private NumericUpDown Draincount;
        private Label DrainItext;
        private Label DrainIIItext;
        private NumericUpDown DrainIIIcount;
        private NumericUpDown DrainIIcount;
        private TabPage BLUCurespage;
        private NumericUpDown MagicFruitcount;
        private NumericUpDown Pollencount;
        private NumericUpDown HealingBreezecount;
        private NumericUpDown PleniluneEmbracecount;
        private NumericUpDown Restoralcount;
        private NumericUpDown WhiteWindcount;
        private NumericUpDown Exuviationcount;
        private NumericUpDown WildCarrotcount;
        private Label PleniluneEmbracetext;
        private Label MagicFruittext;
        private Label HealingBreezetext;
        private Label Pollentext;
        private Label WhiteWindtext;
        private Label Restoraltext;
        private Label Exuviationtext;
        private Label WildCarrottext;
        private TabPage MAconfigpage;
        private CheckBox MAreverse;
        private Label label10;
        public GroupBox SMNAbilitysgroup;
        public CheckedListBox SMNAbilityList;
        public GroupBox groupBox5;
        public CheckedListBox PUPJA;
        public GroupBox groupBox6;
        public CheckedListBox GEOJA;
        private ComboBox SMNSelect;
        private Label SelectSMNtext;
        public GroupBox SMNJAgroup;
        public CheckedListBox SMNJA;
        private NumericUpDown SMNHPPset1;
        private NumericUpDown SMNHPPset2;
        private Label SMNHealTEXT2;
        private Label SMNHealTEXT1;
        private Label SMNpetTPUSEtext;
        private NumericUpDown SMNpetTPUSEset;
        private GroupBox ManaCedegroup;
        private Label ManaCedePETTPtext;
        private NumericUpDown ManaCedeTPset;
        private Label ManaCedePMPPtext;
        private NumericUpDown ManaCedeMPPset;
        private Label Apogeetext;
        private NumericUpDown ApogeeMPPset;
        private Label SMNpetMPUSEtext;
        private NumericUpDown SMNpetMPUSEset;
        public CheckBox AutoCallPUP;
        private NumericUpDown numericUpDown8;
        private NumericUpDown numericUpDown9;
        private NumericUpDown numericUpDown10;
        private NumericUpDown numericUpDown5;
        private NumericUpDown numericUpDown4;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
        private ComboBox Repairselect;
        private Label label18;
        private Label label14;
        private NumericUpDown Repairset;
        private TabControl tabControl1;
        private TabPage PUPAbilitypage;
        private TabPage PUPOtherpage;
        private GroupBox RoleReversalgroup;
        private RadioButton RRPET;
        private RadioButton RRPlayer;
        private NumericUpDown RRPetHPPset;
        private NumericUpDown RRPlayerHPPset;
        private Label label24;
        private Label label19;
        private GroupBox TacticalSwitchgroup;
        private RadioButton TSPET;
        private RadioButton TSPlayer;
        private NumericUpDown TSPetTPset;
        private NumericUpDown TSPlayerTPset;
        private Label label26;
        private Label label41;
        private GroupBox groupBox4;
        private CheckBox healforAutomatonMP;
        private CheckBox healforAutomatonHP;
        private NumericUpDown healforAutomatonMPset;
        private NumericUpDown healforAutomatonHPset;
        private ComboBox Maneuver3select;
        private ComboBox Maneuver2select;
        private ComboBox Maneuver1select;
        private Label label56;
        private Label label51;
        private Label label49;
        private NumericUpDown Maneuver3set;
        private NumericUpDown Maneuver2set;
        private NumericUpDown Maneuver1set;
        private GroupBox Maneuversgroup;
        private GroupBox Repairgroup;
        private GroupBox Ventriloquygroup;
        private RadioButton VentriloquyPet;
        private RadioButton VentriloquyPlayer;
        private Label label57;
        private ComboBox comboBox5;
        public NumericUpDown useviofloValue;
        public RadioButton usevioflo;
        private NumericUpDown mobheightdistValue;
        private TabPage trustControl;
        public MenuStrip trustmenuStrip;
        public ToolStripMenuItem trustMenureset;
        private CheckedListBox Trusts;
        private Label selectedtrusts;
        private Label maxtrustslabel;
        private Button verifyfood;
        private TabPage samPage;
        public ComboBox sekkanokiWs;
        private Label label58;
        private RadioButton ChocoboJigII;
        private RadioButton ChocoboJig;
        private RadioButton SpectralJig;
        private CheckBox UseJigs;
        private Label label59;
        private CheckBox DynaProccontrole;
        private GroupBox groupBox13;
        private CheckBox NoneProcuse;
        private CheckBox navStuckWatch;
        private CheckBox mobStuckWatch;
        private Label label63;
        private Label label61;
        private TabPage selectapp;
        private CheckBox EnableDynamis;
        private GroupBox groupBox16;
        private Label label65;
        private NumericUpDown StuckDistance;
        private CheckBox ManualTargMode;
        private CheckedListBox PartyWaltsList;
        private TabPage PartyCurepage;
        private TabPage Cureagapage;
        private Label label39;
        private NumericUpDown CuragaVcount;
        private NumericUpDown CuragaIVcount;
        private NumericUpDown CuragaIIIcount;
        private NumericUpDown CuragaIIcount;
        private Label label69;
        private Label label70;
        private Label label71;
        private Label label72;
        private Label label73;
        private NumericUpDown Curagacount;
        private TabControl tabControl2;
        private TabPage tabPage1;
        private NumericUpDown CureVIptcount;
        private Label label74;
        private NumericUpDown CureVptcount;
        private NumericUpDown CureIVptcount;
        private Label label75;
        private Label label76;
        private NumericUpDown CureIIIptcount;
        private NumericUpDown CureIIptcount;
        private Label label66;
        private Label label67;
        private Label label68;
        private NumericUpDown Cureptcount;
        private TabPage tabPage2;
        private CheckedListBox CurePTlist;
        public GroupBox groupBox17;
        public MenuStrip menuStrip1;
        public ToolStripMenuItem toolStripMenuItem1;
        public ToolStripMenuItem toolStripMenuItem2;
        private NumericUpDown FullCureptcount;
        private Label label80;
        private CheckBox ptCure;
        private GroupBox groupBox18;
        private Label curtime;
        private Label curtarghpp;
        private Label curtarg;
        private Label playertp;
        private Label playermp;
        private Label playerhp;
        private GroupBox groupBox25;
        private RadioButton twentyfourHour;
        private RadioButton twelveHour;
        private Label label82;
        private CheckBox Shutdownenable;
        private GroupBox shutdowngroup;
        private ComboBox selectedapp;
        private DateTimePicker shutdowndate;
        public Button Runtest;
        private GroupBox groupBox23;
        private Label playerjobpoints;
        private Label playermerits;
        public NumericUpDown BstJATP;
        private Label label13;
        private Button Shrinkbutton;
        private Panel panel1;
        public CheckBox fullheal;
        private Label curtargid;
        private TabPage hudpage;
        private Label advhudtext;
        public TextBox hudtext;
        private NumericUpDown hudY;
        private Label hudYlabel;
        private NumericUpDown hudX;
        private Label hudXlabel;
        private CheckBox showHUD;
        #endregion
        #region Display: Controle
        private void hudinfobutton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To get specific varables use below.\n" +
                "{x} -- the command for the varables ware x is the one below\n" +
                "        0 = Current Bot Name\n" +
                "        1 = Targeting Mode\n" +
                "        2 = Player's Main Job\n" +
                "        3 = Player's Main Job Level\n" +
                "        4 = Player's Sub Job\n" +
                "        5 = Player's Sub Job Level\n" +
                "        6 = Player's Current Status\n" +
                "        7 = Player's Current HP\n" +
                "        8 = Player's Max HP\n" +
                "        9 = Player's Current HP%\n" +
                "        10 = Player's Current MP\n" +
                "        11 = Player's Max MP\n" +
                "        12 = Player's Current MP%\n" +
                "        13 = Player's Current TP\n" +
                "        14 = Player's Useable Job Points\n" +
                "        15 = Player's Capacity Points\n" +
                "        16 = Player's Merit Points\n" +
                "        17 = Pet's Name\n" +
                "        18 = Pet's ID\n" +
                "        19 = Pet's Current HP%\n" +
                "        20 = Pet's Current MP%\n" +
                "        21 = Pet's Current TP\n" +
                "        22 = Pet's Current Status\n" +
                "        23 = Party Member Count\n" +
                "        24 = Average Party HP%\n" +
                "        25 = Target's Name\n" +
                "        26 = Target's ID\n" +
                "        27 = Target's Current HP%\n" +
                "        28 = Distance To Target\n" +
                "        29 = Locked On Target\n" +
                "        30 = Farm Bot Running\n" +
                "        31 = In-Game Hour\n" +
                "        32 = In-Game Minute\n" +
                "        33 = OnEvent Last Chat Line Triggered On\n" +
                "        34 = Last Function Reached\n" +
                "        35 = Indi- Info\n" +
                "" +
                "Example:\n" +
                "    For players current hp/maxhp use: {7}/{8}\n", "In-Game HUD varables");
        }
        private void playerJA_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = playerJA.SelectedItem.ToString();
            int index = playerJA.FindString(curItem);
            bool state = (playerJA.GetItemCheckState(index).ToString() == "Checked" ? true : false);
            List<string> MONCure = new List<string>(new string[]
            {"Proboscis Shower","Catharsis","Plenilune Embrace","Wild Carrot","Pollen","Magic Fruit","Healing Breeze","Proboscis"});
            if (MONCure.Contains(curItem)) MONhpCount.Enabled = state;
            else if (curItem == "Benediction") BenedictionHPPuse.Enabled = state;
            else if (curItem == "Convert") Convertgroup.Enabled = state;
            else if (curItem == "Sublimation") Sublimationcount.Enabled = state;
            else if (curItem == "Vivacious Pulse")
            {
                VivaciousPulse.Enabled = state;
                VivaciousPulseHP.Enabled = state;
            }
        }
        private void playerMA_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = playerMA.SelectedItem.ToString();
            int index = playerMA.FindString(curItem);
            bool state = (playerMA.GetItemCheckState(index).ToString() == "Checked" ? true : false);
            Control c = Controls.Find(curItem.Replace(" ", "") + "count", true).SingleOrDefault();
            if (c == null) return;
            else c.Enabled = state;
            c = Controls.Find(curItem.Replace(" ", "") + "ptcount", true).SingleOrDefault();
            if (c == null) return;
            else c.Enabled = state;
        }
        private void SMNSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            var smnselected = SMNSelect.SelectedItem.ToString();
            Dictionary<string, dynamic> smnsetup = new Dictionary<string, dynamic>()
            {
                {"Carbuncle", new {TEXT1Enabled=true,TEXT2Enabled=true,SMNHPPset1=true,SMNHPPset2=true,SMNpetTPUSEtext=true,
                    SMNpetTPUSEset=true,TEXT2Text="Healing Ruby II HPP%",TEXT1Text="Healing Ruby HPP%"}},
                {"Leviathan", new {TEXT1Enabled=true,TEXT2Enabled=false,SMNHPPset1=true,SMNHPPset2=false,SMNpetTPUSEtext=true,
                    SMNpetTPUSEset=true,TEXT2Text="(Not Needed)",TEXT1Text="Spring Water HPP%"}},
                {"Garuda", new {TEXT1Enabled=true,TEXT2Enabled=false,SMNHPPset1=true,SMNHPPset2=false,SMNpetTPUSEtext=true,
                    SMNpetTPUSEset=true,TEXT2Text="(Not Needed)",TEXT1Text="Whispering Wind HPP%"}},
            };
            if (!isLoading) SMNGetJA();
            if (smnsetup.ContainsKey(smnselected))
            {
                SMNHealTEXT1.Enabled = smnsetup[(string)SMNSelect.SelectedItem].TEXT1Enabled;
                SMNHealTEXT1.Text = smnsetup[(string)SMNSelect.SelectedItem].TEXT1Text;
                SMNHealTEXT2.Enabled = smnsetup[(string)SMNSelect.SelectedItem].TEXT2Enabled;
                SMNHealTEXT2.Text = smnsetup[(string)SMNSelect.SelectedItem].TEXT2Text;
                SMNHPPset1.Enabled = smnsetup[(string)SMNSelect.SelectedItem].SMNHPPset1;
                SMNHPPset2.Enabled = smnsetup[(string)SMNSelect.SelectedItem].SMNHPPset2;
                SMNpetTPUSEtext.Enabled = smnsetup[(string)SMNSelect.SelectedItem].SMNpetTPUSEtext;
                SMNpetTPUSEset.Enabled = smnsetup[(string)SMNSelect.SelectedItem].SMNpetTPUSEset;
            }
            else if (smnselected.Contains("Spirit"))
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
        private void Maneuver1select_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)Maneuver1select.SelectedItem == "Not Selected") Maneuver1set.Enabled = false;
            else Maneuver1set.Enabled = true;
        }
        private void Maneuver2select_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)Maneuver2select.SelectedItem == "Not Selected") Maneuver2set.Enabled = false;
            else Maneuver2set.Enabled = true;
        }
        private void Maneuver3select_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)Maneuver3select.SelectedItem == "Not Selected") Maneuver3set.Enabled = false;
            else Maneuver3set.Enabled = true;
        }
        private void PUPJA_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = PUPJA.SelectedItem.ToString();
            int index = PUPJA.FindString(curItem);
            bool state = (PUPJA.GetItemCheckState(index).ToString() == "Checked" ? true : false);
            if (curItem == "Role Reversal") RoleReversalgroup.Enabled = state;
            else if (curItem == "Tactical Switch") TacticalSwitchgroup.Enabled = state;
            else if (curItem == "Repair") Repairgroup.Enabled = state;
            else if (curItem == "Ventriloquy") Ventriloquygroup.Enabled = state;
        }
        private void NoneProcuse_CheckedChanged(object sender, EventArgs e)
        {
            NoneProc = NoneProcuse.Checked;
        }
        private void DynaProccontrole_CheckedChanged(object sender, EventArgs e)
        {
            NoneProcuse.Enabled = DynaProccontrole.Checked;
        }
        private void EnableDynamis_CheckedChanged(object sender, EventArgs e)
        {
            if (EnableDynamis.Checked)
                this.CombatSettingsTabs.Controls.Add(this.Dynamispage);
            else
            {
                staggerstopJA.Checked = false;
                DynaProccontrole.Checked = false;
                NoneProcuse.Checked = false;
                this.CombatSettingsTabs.Controls.Remove(this.Dynamispage);
            }
        }
        private void ManualTargMode_CheckedChanged(object sender, EventArgs e)
        {
            if (ManualTargMode.Checked) usenav.Checked = false;
            usenav.Enabled = !ManualTargMode.Checked;
            targeting = (ManualTargMode.Checked ? "Manual" : "Auto");
        }
        private void verifyfood_Click(object sender, EventArgs e)
        {
            var itc = Inventory.ItemQuantityByName(foodName.Text);
            MessageBox.Show("Food : \"" + foodName.Text + "\" Count : " + itc);
        }
        private void UsenavCheckedChanged(object sender, EventArgs e)
        {
            navStuckWatch.Enabled = usenav.Checked;
            groupBox8.Enabled = usenav.Checked;
            runReverse.Enabled = usenav.Checked;
            if (usenav.Checked)
            {
                var path = string.Format("{0}\\Nav\\", Application.StartupPath);

                foreach (var file in Directory.GetFiles(path, "*.xin"))
                {
                    selectedNavi.Items.Add(new FileInfo(file).Name);
                }
            }
            else
            {
                navStuckWatch.Checked = false;
                api.AutoFollow.IsAutoFollowing = false;
                naviMove = false;

                selectedNavi.Items.Clear();
            }
        }
        private void AssistCheckedChanged(object sender, EventArgs e)
        {
            if (partyAssist.Checked)
                partyAssist.Checked = false;
            assistDist.Enabled = assist.Checked;
            if (usenav.Checked)
                usenav.Checked = false;
            usenav.Enabled = !assist.Checked;
            selectedNavi.Enabled = !assist.Checked;
        }
        private void partyAssist_CheckedChanged(object sender, EventArgs e)
        {
            if (assist.Checked)
                assist.Checked = false;
            assistDist.Enabled = partyAssist.Checked;
            if (usenav.Checked)
                usenav.Checked = false;
            usenav.Enabled = !partyAssist.Checked;
            selectedNavi.Enabled = !partyAssist.Checked;
        }
        private void IdToolStripMenuItemClick(object sender, EventArgs e)
        {
            datsName = false;

            SelectedTargets.Items.Clear();
            TargetList.Items.Clear();

            SelectedTargets.Columns[0].Width = 35;
            TargetList.Columns[0].Width = 35;

            PopulateTargetLists("ID");

            foreach (var entry in wantedID.OrderBy(key => key.Value))
            {
                TargetList.Items.Add(entry.Key).SubItems.Add(entry.Value);
            }
        }
        private void NameListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            datsName = true;
            SelectedTargets.Items.Clear();
            TargetList.Items.Clear();

            SelectedTargets.Columns[0].Width = 0;
            TargetList.Columns[0].Width = 0;

            PopulateTargetLists("NAME");

            foreach (var entry in wantedNM.OrderBy(key => key.Value))
            {
                TargetList.Items.Add(entry.Key).SubItems.Add(entry.Value);
            }
        }
        private void ClearToolStripMenuItemClick(object sender, EventArgs e)
        {
            SelectedTargets.Items.Clear();
        }
        private void ListView2DoubleClick(object sender, EventArgs e)
        {
            if (TargetList.Items.Count <= 0) return;

            var list = new ArrayList();

            if (SelectedTargets.Items.Count < 0) return;

            if (SelectedTargets.Items.Count == 0)
            {
                SelectedTargets.Items.Add(TargetList.FocusedItem.Text).SubItems.Add(TargetList.FocusedItem.SubItems[1].Text);
                list.Add(TargetList.FocusedItem.Text);
            }
            foreach (var item in SelectedTargets.Items.Cast<ListViewItem>().Where(item => !list.Contains(item.Text)))
            {
                list.Add(item.Text);
            }
            if (!list.Contains(TargetList.FocusedItem.Text))
            {
                SelectedTargets.Items.Add(TargetList.FocusedItem.Text).SubItems.Add(TargetList.FocusedItem.SubItems[1].Text);
            }
            var dats = SelectedTargets.Items.Cast<ListViewItem>().ToDictionary(item => item.Text, item => item.SubItems[1].Text);

            SelectedTargets.Items.Clear();
            foreach (var entry in dats.OrderBy(key => key.Value))
            {
                SelectedTargets.Items.Add(entry.Key).SubItems.Add(entry.Value);
            }
        }
        private void ListView1DoubleClick(object sender, EventArgs e)
        {
            if (SelectedTargets.SelectedItems.Count <= 0) return;

            foreach (ListViewItem selected in SelectedTargets.SelectedItems)
            {
                SelectedTargets.Items.Remove(selected);
            }
        }
        private void ListView2KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                SelectedTargets.Items.AddRange((from ListViewItem item in TargetList.SelectedItems
                                                select (ListViewItem)item.Clone()).ToArray());
            }
        }
        private void addplayertext_Click(object sender, EventArgs e)
        {
            if (!PartyWaltsList.Items.Contains(WaltzPTadd.Text))
                PartyWaltsList.Items.Add(WaltzPTadd.Text);
        }
        private void loadPartyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var members = api.Party.GetPartyMembers().Where(p => p.Active != 0).ToList();
            foreach (var member in members)
            {
                string name = member.Name.Replace(PlayerInfo.Name, "").Trim();
                if (!PartyWaltsList.Items.Contains(name) && name != "")
                    PartyWaltsList.Items.Add(name);
            }
        }
        private void clearPartyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PartyWaltsList.Items.Clear();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var members = api.Party.GetPartyMembers().Where(p => p.Active != 0).ToList();
            foreach (var member in members)
            {
                string name = member.Name.Replace(PlayerInfo.Name, "").Trim();
                if (!CurePTlist.Items.Contains(name) && name != "")
                    CurePTlist.Items.Add(name);
            }
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CurePTlist.Items.Clear();
        }
        private void twelveHour_CheckedChanged(object sender, EventArgs e)
        {
            if (twelveHour.Checked)
                shutdowndate.CustomFormat = "M/d/yyyy hh:mm:ss tt";
            else
                shutdowndate.CustomFormat = "M/d/yyyy HH:mm:ss";
        }
        private void Shrinkbutton_Click(object sender, EventArgs e)
        {
            panel1.Location = new Point((dncControl.Visible ? 10 : 459), 25);
            Shrinkbutton.Text = (dncControl.Visible ? ">>" : "<<");
            dncControl.Visible = !dncControl.Visible;
        }
        private void showHUD_CheckedChanged(object sender, EventArgs e)
        {
            if (showHUD.Checked)
            {
                api.ThirdParty.CreateTextObject("ScriptedHUD");
                api.ThirdParty.SetVisibility("ScriptedHUD", true);
                api.ThirdParty.SetFont("ScriptedHUD", "Arial", 10);
            }
            else
                api.ThirdParty.DeleteTextObject("ScriptedHUD");

            hudshow = showHUD.Checked;
            api.ThirdParty.FlushCommands();
        }
        #endregion
        #region Methods: Start/Stop/Load
        private void ScriptFarmDncLoad(object sender, EventArgs e)
        {
            dncControl.SelectTab("combat");
            PopulateTargetLists("ID");
            CharacterUpdate();
            if (PetInfo.Name != null)
                pInfo();
        }
        private void UpdateJobToolStripMenuItemClick(object sender, EventArgs e)
        {
            CharacterUpdate();
            if (PetInfo.Name != null)
                pInfo();
        }
        private void ToolStartClick(object sender, EventArgs e)
        {
            botRunning = true;
            startzone = api.Player.ZoneId;
            startScriptToolStripMenuItem.Enabled = false;
            stopScriptToolStripMenuItem.Enabled = true;
            if (!bgw_script_dnc.IsBusy)
                bgw_script_dnc.RunWorkerAsync();
            if (!bgw_script_pet.IsBusy)
                bgw_script_pet.RunWorkerAsync();
            if (!bgw_script_nav.IsBusy)
                bgw_script_nav.RunWorkerAsync();
            if (!bgw_script_chat.IsBusy)
                bgw_script_chat.RunWorkerAsync();
            if (PlayerInfo.MainJob == 20 || PlayerInfo.SubJob == 20)
            {
                if (!bgw_script_sch.IsBusy)
                    bgw_script_sch.RunWorkerAsync();
            }
            else
                bgw_script_sch.CancelAsync();
        }
        private void ToolStopClick(object sender, EventArgs e)
        {
            botRunning = false;
            if (usenav.Checked && naviMove)
                naviMove = false;
            if (api.AutoFollow.IsAutoFollowing)
                api.AutoFollow.IsAutoFollowing = false;
            Thread.Sleep(TimeSpan.FromSeconds(0.3));
            startScriptToolStripMenuItem.Enabled = true;
            stopScriptToolStripMenuItem.Enabled = false;
            bgw_script_dnc.CancelAsync();
            bgw_script_pet.CancelAsync();
            bgw_script_nav.CancelAsync();
            bgw_script_chat.CancelAsync();
            bgw_script_sch.CancelAsync();
        }
        private void PlayerDead()
        {
            ToolStopClick(null, null);
            Thread.Sleep(TimeSpan.FromSeconds(1.0));
            WindowInfo.KeyPress(API.Keys.NUMPADENTER);
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
            WindowInfo.KeyPress(API.Keys.RIGHT);
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
            WindowInfo.KeyPress(API.Keys.NUMPADENTER);
        }
        private void shutdowntime()
        {
            if (DateTime.Now.CompareTo(Convert.ToDateTime(shutdowndate.Text)) >= 0)
            {
                if (selectedapp.Text == "Windowing App + Scripted")
                {
                    if (MainWindow.windowername == "Windower")
                        api.ThirdParty.SendString("//terminate");
                    else if ((MainWindow.windowername == "Ashita"))
                        api.ThirdParty.SendString("/terminate");
                }
                Environment.Exit(0);
            }
        }
            #region Trust
        private void trustMenureset_Click(object sender, EventArgs e)
        {
            if (Trusts.Items.Count > 0)
                Trusts.Items.Clear();

            var trustcount = 0;
            if (api.Player.HasKeyItem(2497) || api.Player.HasKeyItem(2499) || api.Player.HasKeyItem(2501))
            {
                trustcount = 3;
                if (PlayerInfo.HasKeyItem(2887))
                    trustcount = 5;
                else if (PlayerInfo.HasKeyItem(2884))
                    trustcount = 4;
            }
            maxtrustslabel.Text = "Max Trusts : " + trustcount;
            selectedtrusts.Text = "Selected Trusts : 0";
            Trusts.Enabled = true;
            if (trustcount == 0)
            {
                Trusts.Enabled = false;
                return;
            }
            else Trusts.Enabled = true;

            for (uint i = 896; i <= 1023; i++)
            {
                var spellm = api.Resources.GetSpell(i);
                if (spellm == null) continue;
                else if (PlayerInfo.HasSpell(i) && !Trusts.Items.Contains(spellm.Name[0])) Trusts.Items.Add(spellm.Name[0]);
            }
        }
        private void Trusts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var trustcount = 0;
            if (api.Player.HasKeyItem(2497) || api.Player.HasKeyItem(2499) || api.Player.HasKeyItem(2501))
            {
                trustcount = 3;
                if (PlayerInfo.HasKeyItem(2887))
                    trustcount = 5;
                else if (PlayerInfo.HasKeyItem(2884))
                    trustcount = 4;
            }

            selectedtrusts.Text = "Selected Trusts : " + Trusts.CheckedItems.Count;

            if (Trusts.CheckedItems.Count == trustcount) Trusts.Enabled = false;
        }
        private void useTrust()
        {
            LastFunction = "useTrust";
            var trust = (from object itemChecked in Trusts.CheckedItems select itemChecked.ToString()).ToList();
            if (PartyInfo.Count(1) == 6 || trust.Count == 0) return;
            foreach (string T in trust)
            {
                isCasting = true;
                if (PartyInfo.Count(1) == 6 || PartyInfo.Count(2) > 0 || PartyInfo.Count(3) > 0) break;
                if (TargetInfo.ID != 0 ? TargetInfo.ID != PlayerInfo.TargetID : false) break;
                var trustname = T.Replace(" ", "").Replace("II", "").Replace("[S]", "").Replace("(UC)", "");
                if (PartyInfo.ContainsName(trustname)) continue;
                else
                {
                    api.ThirdParty.SendString("/ma \"" + T + "\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(0.1));
                    SetTarget(0);
                    Casting(true);
                    if (TargetInfo.ID == PlayerInfo.TargetID)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(0.1));
                        SetTarget(0);
                    }
                }
            }
            
            isCasting = false;
        }
            #endregion
        private void LoadJA_Click(object sender, EventArgs e)
        {
            if (playerJA.Items.Count > 0)
                playerJA.Items.Clear();
            #region Ability list
            Dictionary<uint, dynamic> abilitylist = new Dictionary<uint, dynamic>(){{528, true},{529, true},{530, true},{531, true},{532, true},{533, true},{534, true},
            {535, true},{536, true},{537, true},{538, true},{539, true},{540, true},{541, true},{543, true},{544, true},{545, true},{546, true},{548, true},{549, true},
            {550, true},{551, true},{552, true},{553, true},{554, true},{555, true},{556, true},{557, true},{558, true},{559, true},{560, true},{561, true},{562, true},
            {563, true},{564, true},{565, true},{566, true},{567, true},{568, true},{569, true},{570, true},{571, true},{572, true},{574, true},{575, true},{576, true},
            {577, true},{578, true},{579, true},{580, true},{581, true},{582, true},{583, true},{584, true},{585, true},{586, true},{587, true},{588, true},{589, true},
            {591, true},{593, true},{594, true},{595, true},{596, true},{598, true},{599, true},{600, true},{601, true},{602, true},{603, true},{604, true},{605, true},
            {606, true},{607, true},{608, true},{610, true},{611, true},{612, true},{613, true},{614, true},{615, true},{616, true},{617, true},{618, true},{619, true},
            {620, true},{621, true},{622, true},{623, true},{624, true},{625, true},{626, true},{627, true},{628, true},{629, true},{630, true},{631, true},{632, true},
            {633, true},{634, true},{635, true},{636, true},{637, true},{638, true},{639, true},{640, true},{641, true},{642, true},{643, true},{644, true},{645, true},
            {661, true},{662, true},{663, true},{664, true},{665, true},{666, true},{667, true},{668, true},{669, true},{670, true},{671, true},{672, true},{673, true},
            {674, true},{675, true},{676, true},{677, true},{678, true},{679, true},{680, true},{682, true},{683, true},{684, true},{685, true},{686, true},{687, true},
            {688, true},{689, true},{690, true},{693, true},{722, true},{723, true},{724, true},{726, true},{727, true},{728, true},{729, true},{730, true},{731, true},
            {732, true},{733, true},{734, true},{735, true},{736, true},{737, true},{738, true},{739, true},{740, true},{741, true},{742, true},{745, true},{746, true},
            {747, true},{748, true},{749, true},{750, true},{751, true},{752, true},{753, true},{754, true},{755, true},{756, true},{757, true},{758, true},{759, true},
            {760, true},{761, true},{762, true},{763, true},{764, true},{765, true},{766, true},{767, true},{768, true},{769, true},{770, true},{771, true},{772, true},
            {773, true},{777, true},{779, true},{781, true},{782, true},{783, true},{784, true},{785, true},{786, true},{787, true},{788, true},{789, true},{790, true},
            {791, true},{792, true},{793, true},{794, true},{795, true},{796, true},{797, true},{798, true},{799, true},{800, true},{803, true},{804, true},{805, true},
            {807, true},{809, true},{810, true},{813, true},{814, true},{815, true},{816, true},{817, true},{828, true},{829, true},{830, true},{831, true},{832, true},
            {833, true},{835, true},{836, true},{837, true},{838, true},{839, true},{840, true},{841, true},{842, true},{843, true},{844, true},{845, true},{846, true},
            {847, true},{848, true},{850, true},{851, true},{853, true},{854, true},{855, true},{856, true},{857, true},{858, true},{859, true},{860, true},{861, true},
            {862, true},{863, true},{864, true},{865, true},{866, true},{867, true},{868, true},{869, true},{870, true},{871, true},{872, true},{873, true},{874, true},
            {875, true},{876, true},{877, true},{878, true},{879, true},{880, true},{881, true},{882, true},{883, true},{884, true},{885, true},{886, true},{887, true},
            {888, true},{889, true},{890, true},{891, true},{892, true},{894, true},{895, true},{896, true},{898, true},{900, true},{901, true},{902, true},{903, true},
            {904, true}};
            #endregion
            var Recastids = api.Recast.GetAbilityIds();
            for (uint i = 528; i <= 2227; i++)
            {
                var ability = api.Resources.GetAbility(i);

                if (ability.ID >= 1023 && PlayerInfo.MainJob != 23) break;
                else if (!abilitylist.ContainsKey(ability.ID) || ability.Name[0] == "") continue;
                else if (Recastids.Contains((int)ability.TimerID) && PlayerInfo.HasAbility((uint)ability.ID))
                {
                    if (ability.ID >= 1023 && PlayerInfo.MainJob == 23)
                    {
                        playerJA.Items.Add(ability.Name[0]);
                        continue;
                    }
                    else if (ability.ID == 735)
                    {
                        var job = 0;
                        if (PlayerInfo.MainJob == 20) job = PlayerInfo.MainJobLevel;
                        if (PlayerInfo.SubJob == 20) job = PlayerInfo.SubJobLevel;
                        if (!playerJA.Items.Contains("Addendum: White") && job >= 10) playerJA.Items.Add("Addendum: White");
                        if (!playerJA.Items.Contains("Penury") && job >= 10) playerJA.Items.Add("Penury");
                        if (!playerJA.Items.Contains("Celerity") && job >= 25) playerJA.Items.Add("Celerity");
                        if (!playerJA.Items.Contains("Accession") && job >= 40) playerJA.Items.Add("Accession");
                        if (!playerJA.Items.Contains("Rapture") && job >= 55) playerJA.Items.Add("Rapture");
                        if (!playerJA.Items.Contains("Altruism") && job >= 75) playerJA.Items.Add("Altruism");
                        if (!playerJA.Items.Contains("Tranquility") && job >= 75) playerJA.Items.Add("Tranquility");
                        if (!playerJA.Items.Contains("Perpetuance") && job >= 87) playerJA.Items.Add("Perpetuance");
                        if (!playerJA.Items.Contains("Parsimony") && job >= 10) playerJA.Items.Add("Parsimony");
                        if (!playerJA.Items.Contains("Alacrity") && job >= 25) playerJA.Items.Add("Alacrity");
                        if (!playerJA.Items.Contains("Addendum: Black") && job >= 30) playerJA.Items.Add("Addendum: Black");
                        if (!playerJA.Items.Contains("Manifestation") && job >= 40) playerJA.Items.Add("Manifestation");
                        if (!playerJA.Items.Contains("Ebullience") && job >= 55) playerJA.Items.Add("Ebullience");
                        if (!playerJA.Items.Contains("Focalization") && job >= 75) playerJA.Items.Add("Focalization");
                        if (!playerJA.Items.Contains("Equanimity") && job >= 75) playerJA.Items.Add("Equanimity");
                        if (!playerJA.Items.Contains("Immanence") && job >= 87) playerJA.Items.Add("Immanence");
                    }
                    else if (ability.ID == 670)
                    {
                        var job = 0;
                        if (PlayerInfo.MainJob == 7) job = PlayerInfo.MainJobLevel;
                        if (PlayerInfo.SubJob == 7) job = PlayerInfo.SubJobLevel;
                        if (!playerJA.Items.Contains("Chivalry TP > 1000") && job >= 75) playerJA.Items.Add("Chivalry TP > 1000");
                        if (!playerJA.Items.Contains("Chivalry TP > 2000") && job >= 75) playerJA.Items.Add("Chivalry TP > 2000");
                        if (!playerJA.Items.Contains("Chivalry TP > 3000") && job >= 75) playerJA.Items.Add("Chivalry TP > 3000");
                    }
                    else if (!playerJA.Items.Contains(ability.Name[0]))
                    {
                        playerJA.Items.Add(ability.Name[0]);
                    }
                }
            }
            if (playerJA.Items.Contains("Sharpshot") && playerJA.Items.Contains("Barrage")) playerJA.Items.Add("Sharpshot + Barrage");
        }
        private void ClearJA_Click(object sender, EventArgs e)
        {
            playerJA.Items.Clear();
            label20.Text = "Pets Name:";
            label21.Text = @"Pet ID:";
            label22.Text = @"Pets HP%:";
            label23.Text = @"Pets TP:";
        }
        private void LoadMA_Click(object sender, EventArgs e)
        {
            if (playerMA.Items.Count > 0)
                playerMA.Items.Clear();
            for (uint mm = 1; mm <= 895; mm++)
            {
                Check_Set_Spells(mm, PlayerInfo.MainJobLevel, PlayerInfo.MainJob);
            }
            for (uint sm = 1; sm <= 895; sm++)
            {
                Check_Set_Spells(sm, PlayerInfo.SubJobLevel, PlayerInfo.SubJob);
            }
        }
        private void Check_Set_Spells(uint SpellID, int JobLvl, int Job)
        {
            var spell = api.Resources.GetSpell(SpellID);
            var spelllvl = spell.LevelRequired[Job];
            if (spell == null || skipSpellList.ContainsKey(spell.Index) || playerMA.Items.Contains(spell.Name[0])) return;
            if (spelllvl != -1)
            {
                if (PlayerInfo.HasSpell(spell.Index) && JobLvl >= spelllvl)
                {
                    if (spell.Skill == 43 && Job == 16)
                    {
                        if (UnbridledSpells.Contains(spell.Index))
                            playerMA.Items.Add(spell.Name[0]);
                        else if (PlayerInfo.HasBlueMagicSpellSet((int)spell.Index))
                            playerMA.Items.Add(spell.Name[0]);
                    }
                    else if (spelllvl <= 99)
                    {
                        playerMA.Items.Add(spell.Name[0]);
                    }
                }
                else if (JobLvl == 99 && PlayerInfo.UsedJobPoints >= spelllvl)
                    playerMA.Items.Add(spell.Name[0]);
            }
        }
        private void ClearMA_Click(object sender, EventArgs e)
        {
            playerMA.Items.Clear();
        }
        public void CharacterUpdate()
        {
            JAtabselect.Controls.Remove(WHMpage);
            JAtabselect.Controls.Remove(RDMpage);
            JAtabselect.Controls.Remove(SCHpage);
            JAtabselect.Controls.Remove(RUNpage);
            JAtabselect.Controls.Remove(MONpage);
            JAtabselect.Controls.Remove(samPage);
            petControl.Controls.Remove(bstpettab);
            petControl.Controls.Remove(drgpettab);
            petControl.Controls.Remove(smnpettab);
            petControl.Controls.Remove(puppettab);
            petControl.Controls.Remove(geopettab);
            MAtabs.Controls.Remove(CureConfigPage);
            MAtabs.Controls.Remove(PartyCurepage);
            MAtabs.Controls.Remove(Cureagapage);
            MAtabs.Controls.Remove(DrainAspirpage);
            MAtabs.Controls.Remove(MAconfigpage);
            MAtabs.Controls.Remove(BLUCurespage);
            CombatSettingsTabs.Controls.Remove(OptionsMAMainTab);
            CombatSettingsTabs.Controls.Remove(Dynamispage);
            dncControl.Controls.Remove(pets);
            dncControl.Controls.Remove(dancer);
            dncControl.Controls.Remove(flourish);
            dncControl.Controls.Remove(trustControl);
            dncControl.Controls.Remove(hudpage);
            #region JA Job Tabs Add
            if (PlayerInfo.MainJob == 3 || PlayerInfo.SubJob == 3) JAtabselect.Controls.Add(WHMpage);
            if (PlayerInfo.MainJob == 5 || PlayerInfo.SubJob == 5) JAtabselect.Controls.Add(RDMpage);
            if (PlayerInfo.MainJob == 12 || PlayerInfo.SubJob == 12) JAtabselect.Controls.Add(samPage);
            if (PlayerInfo.MainJob == 20 || PlayerInfo.SubJob == 20) JAtabselect.Controls.Add(SCHpage);
            if (PlayerInfo.MainJob == 22 || PlayerInfo.SubJob == 22) JAtabselect.Controls.Add(RUNpage);
            if (PlayerInfo.MainJob == 23 || PlayerInfo.SubJob == 23) JAtabselect.Controls.Add(MONpage);
            #endregion
            #region MA Tabs Add 
            List<int> MAjobs = new List<int>(new int[] {3,4,5,7,8,10,13,16,20,21,22});
            if (MAjobs.Contains(PlayerInfo.MainJob) || MAjobs.Contains(PlayerInfo.SubJob))
            {
                List<int> Curejobs = new List<int>(new int[] {3,5,7,20});
                if (Curejobs.Contains(PlayerInfo.MainJob) || Curejobs.Contains(PlayerInfo.SubJob))
                {
                    MAtabs.Controls.Add(CureConfigPage);
                    MAtabs.Controls.Add(PartyCurepage);
                }
                if (PlayerInfo.MainJob == 3 || PlayerInfo.SubJob == 3) MAtabs.Controls.Add(Cureagapage);
                List<int> Drainjobs = new List<int>(new int[] {4,8,20,21});
                if  (Drainjobs.Contains(PlayerInfo.MainJob) || Drainjobs.Contains(PlayerInfo.SubJob)) MAtabs.Controls.Add(DrainAspirpage);
                if  (PlayerInfo.MainJob == 16 || PlayerInfo.SubJob == 16) MAtabs.Controls.Add(BLUCurespage);
                MAtabs.Controls.Add(MAconfigpage);
                CombatSettingsTabs.Controls.Add(OptionsMAMainTab);
            }
            #endregion
            #region DNC Tab Setup
            if (PlayerInfo.MainJob == 19 || PlayerInfo.SubJob == 19)
            {
                dncControl.Controls.Add(dancer);
                dncControl.Controls.Add(flourish);
                Dictionary<string, uint> DNCenable = new Dictionary<string, uint>()
                {
                    {"noSamba", 1},{"usedrain", 5},{"usecure", 15},{"usecureValue", 15},{"numericUpDown33", 15},{"ptusecure", 15},{"usequickstep", 20},{"usequickstepValue", 20},
                    {"StepsHP", 20},{"StepsHPValue", 20},{"stopstepsathptext", 20},{"NoSteps", 20},{"stopstepsat", 20},{"stopstepscount", 20},/*{"useanifloValue", 20},
                    {"useaniflo", 20},*/{"useaspir", 25},{"useboxstep", 30},{"useboxstepValue", 30},{"usecureii", 30},{"usecureiiValue", 30},{"ptusecureii", 30},
                    {"numericUpDown32", 30},{"usedesflo", 30},{"usedesfloValue", 30},{"usedrainii", 35},{"groupBox7", 35},{"usestutterstep", 40},
                    {"usestutterstepValue", 40},{"userevflo", 40},{"userevfloValue", 40},{"usehaste", 45},{"usecureiii", 45},{"usecureiiiValue", 45},
                    {"ptusecureiii", 45},{"numericUpDown29", 45},{"useviofloValue", 45},{"usevioflo", 45},{"usebldflo", 50},{"usebldfloValue", 50},{"useaspirii", 60},
                    {"usewldflo", 60},{"usewldfloValue", 60},{"usedrainiii", 65},{"usecureiv", 70},{"usecureivValue", 70},{"ptusecureiv", 70},{"numericUpDown28", 70},
                    {"useclmflo", 80},{"useclmfloValue", 80},{"usefeatherstep", 83},{"usefeatherstepValue", 83},{"usecurev", 87},{"usecurevValue", 87},
                    {"ptusecurev", 87},{"numericUpDown27", 87},{"usestkflo", 89},{"usestkfloValue", 89},{"useterflo", 93},{"useterfloValue", 93},{"SpectralJig", 25},
                    { "ChocoboJig", 55},{"ChocoboJigII", 70},
                };
                foreach (KeyValuePair<string, uint> kvp in DNCenable)
                {
                    Control c = Controls.Find(kvp.Key, true).Single();
                    if (c == null) continue;
                    if ((PlayerInfo.MainJob == 19 && kvp.Value <= PlayerInfo.MainJobLevel) ||
                        (PlayerInfo.SubJob == 19 && kvp.Value <= PlayerInfo.SubJobLevel))
                        c.Enabled = true;
                    else c.Enabled = false;
                }
            }
            #endregion
            #region Pet Tabs Add
            List<int> PETjobs = new List<int>(new int[] { 9, 14, 15, 18, 21 });
            if (PETjobs.Contains(PlayerInfo.MainJob) || PETjobs.Contains(PlayerInfo.SubJob))
            {
                if (PlayerInfo.MainJob == 9 || PlayerInfo.SubJob == 9)
                {
                    petControl.Controls.Add(bstpettab);
                    BSTGetJA();
                }
                if (PlayerInfo.MainJob == 14 || PlayerInfo.SubJob == 14)
                {
                    petControl.Controls.Add(drgpettab);
                    WyvernGetJA();
                }
                if (PlayerInfo.MainJob == 15 || PlayerInfo.SubJob == 15) 
                {
                    petControl.Controls.Add(smnpettab);
                    Dictionary<string, uint> SMNAdd = new Dictionary<string, uint>()
                    {
                        {"Carbuncle", 296},{"Fenrir", 297},{"Ifrit", 298},{"Titan", 299},{"Leviathan", 300},{"Garuda", 301},{"Shiva", 302},{"Ramuh", 303},
                        {"Diabolos", 304},{"Cait Sith", 307},{"Fire Spirit", 288},{"Ice Spirit", 289},{"Air Spirit", 290},{"Earth Spirit", 291},
                        {"Thunder Spirit", 292},{"Water Spirit", 293},{"Light Spirit", 294},{"Dark Spirit", 295},
                    };
                    foreach (KeyValuePair<string, uint> kvp in SMNAdd)
                    {
                        if (PlayerInfo.HasSpell(kvp.Value) && !SMNSelect.Items.Contains(kvp.Key)) SMNSelect.Items.Add(kvp.Key);
                    }
                }
                if (PlayerInfo.MainJob == 18 || PlayerInfo.SubJob == 18 && !isLoading) 
                {
                    petControl.Controls.Add(puppettab);
                    PUPGetJA();
                }
                if (PlayerInfo.MainJob == 21 || PlayerInfo.SubJob == 21) 
                {
                    petControl.Controls.Add(geopettab);
                    //GEOGetJA()
                }
                dncControl.Controls.Add(pets);
            }
            dncControl.Controls.Add(trustControl);
            #endregion
            #region Hate Control Update
            if ((PlayerInfo.MainJob == 1 && PlayerInfo.MainJobLevel >= 5) || (PlayerInfo.SubJob == 1 && PlayerInfo.SubJobLevel >= 5))
                selectedHateControl.Items.Add("Provoke");
            if ((PlayerInfo.MainJob == 19 && PlayerInfo.MainJobLevel >= 20) || (PlayerInfo.SubJob == 19 && PlayerInfo.SubJobLevel >= 20))
                selectedHateControl.Items.Add("Animated Flourish");
            if ((PlayerInfo.MainJob == 7 && PlayerInfo.MainJobLevel >= 37) || (PlayerInfo.SubJob == 7 && PlayerInfo.SubJobLevel >= 37) ||
                (PlayerInfo.MainJob == 3 && PlayerInfo.MainJobLevel >= 45) || (PlayerInfo.SubJob == 3 && PlayerInfo.SubJobLevel >= 45) ||
                (PlayerInfo.MainJob == 22 && PlayerInfo.MainJobLevel >= 45) || (PlayerInfo.SubJob == 22 && PlayerInfo.SubJobLevel >= 45))
                selectedHateControl.Items.Add("Flash");
            #endregion
            dncControl.Controls.Add(hudpage);
            LoadJA_Click(null, null);
            LoadMA_Click(null, null);
            trustMenureset_Click(null, null);
        }
        #endregion
        #region Methods: Save/Load Config
            #region config: save/load (player)
        public void SaveFarmSettings()
        {
            bool exists = System.IO.Directory.Exists(Application.StartupPath + @"\settings");
            if (!exists) System.IO.Directory.CreateDirectory(Application.StartupPath + @"\settings");
            var saveFile = new SaveFileDialog();
            saveFile.Filter = @"settings file (*.xml)|*.xml";
            saveFile.InitialDirectory = Application.StartupPath + @"\settings";
            saveFile.FileName = JobNames[PlayerInfo.MainJob].Long.Replace(" ", "_") + "_"+ JobNames[PlayerInfo.SubJob].Long.Replace(" ", "_") + ".xml";
            saveFile.Title = @"Save your settings file";
            switch (saveFile.ShowDialog())
            {
                case DialogResult.OK:
                    FormSerialisor.Serialise(this, saveFile.FileName);
                    break;
            }
        }
        public void LoadFarmSettings()
        {
            isLoading = true;
            updatenav();
            var openFile = new OpenFileDialog();
            openFile.Filter = @"settings files (*.xml)|*.xml";
            openFile.InitialDirectory = Application.StartupPath + @"\settings";
            openFile.FileName = JobNames[PlayerInfo.MainJob].Long.Replace(" ", "_") + "_" + JobNames[PlayerInfo.SubJob].Long.Replace(" ", "_") + ".xml";
            openFile.Title = @"Load your settings file";
            switch (openFile.ShowDialog())
            {
                case DialogResult.OK:
                    FormSerialisor.Deserialise(this, openFile.FileName);
                    if (!float.IsNaN(idleX) || !float.IsNaN(idleY) || !float.IsNaN(idleZ))
                    {
                        RecordIdleLocation.Text = $"X:{idleX.ToString("00.###")}/Y:{idleY.ToString("00.###")}/Z:{idleZ.ToString("00.###")}";
                    }
                    break;
            }
            isLoading = false;
        }
            #endregion
            #region config: save/load (target)
        private void LoadToolStripMenuItemClick(object sender, EventArgs e)
        {
            var dats = new Dictionary<string, string>();

            bool exists = System.IO.Directory.Exists(Application.StartupPath + @"\mob lists");
            if (!exists) System.IO.Directory.CreateDirectory(Application.StartupPath + @"\mob lists");
            var openFile = new OpenFileDialog();
            openFile.Filter = @"mob files (*.xml)|*.xml";
            openFile.InitialDirectory = Application.StartupPath + @"\mob lists";
            openFile.Title = @"select a mob list file";

            switch (openFile.ShowDialog())
            {
                case DialogResult.OK:
                    var doc = XDocument.Load(openFile.FileName);
                    if (doc.Root == null)
                        return;
                    foreach (var xml in doc.Root.Elements())
                    {
                        dats.Add(xml.Attribute("id").Value, xml.Attribute("name").Value);
                    }
                    SelectedTargets.Items.Clear();
                    foreach (var entry in dats.OrderBy(key => key.Value))
                    {
                        SelectedTargets.Items.Add(entry.Key).SubItems.Add(entry.Value);
                    }
                    break;
            }
        }
        private void SaveToolStripMenuItemClick(object sender, EventArgs e)
        {
            var dats = new Dictionary<string, string>();

            var saveFile = new SaveFileDialog();
            saveFile.Filter = @"mob files (*.xml)|*.xml";
            saveFile.InitialDirectory = Application.StartupPath + @"\mob lists";
            saveFile.Title = @"save mob list file";

            switch (saveFile.ShowDialog())
            {
                case DialogResult.OK:
                    {
                        if (SelectedTargets.Items.Count <= 0) return;

                        var file = saveFile.FileName;
                        var xdoc = new XmlDocument();

                        var declaration = xdoc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
                        var comment = xdoc.CreateComment("This is an XML Generated File");
                        var root = xdoc.CreateElement("saved");

                        xdoc.AppendChild(declaration);
                        xdoc.AppendChild(comment);
                        xdoc.AppendChild(root);

                        foreach (ListViewItem item in SelectedTargets.Items)
                        {
                            var entry = xdoc.CreateElement("entry");
                            var id = xdoc.CreateAttribute("id");
                            var name = xdoc.CreateAttribute("name");

                            id.Value = item.Text;
                            name.Value = item.SubItems[1].Text;

                            entry.Attributes.Append(id);
                            entry.Attributes.Append(name);
                            root.AppendChild(entry);

                        }
                        xdoc.Save(file);
                    }
                    break;
            }
        }
        #endregion
        #endregion
        #region Methods: Assist (Player/Party)
        public void Assist()
        {
            LastFunction = "Assist";
            if (PlayerInfo.Status == 0)
            {
                var members = api.Party.GetPartyMembers().Where(p => p.Active != 0).ToList();
                if (members.Count < 2)
                    return;
                if (assist.Checked && assistplayer.Text != "")
                {
                    var member = members.SingleOrDefault(m => m.Name == assistplayer.Text);
                    var assisted = api.Entity.GetEntity(Convert.ToInt32(member.TargetIndex));
                    if (assisted.Status == 1)
                    {
                        RunAssist(assisted);
                    }
                }
                else if (partyAssist.Checked)
                {
                    foreach (var member in members)
                    {
                        var assisted = api.Entity.GetEntity(member.Index);
                        if (assisted.Status == 1)
                        {
                            bool assisting = RunAssist(assisted);
                            if (assisting)
                                break;
                        }
                    }
                }
            }
        }
        public bool RunAssist(EliteAPI.XiEntity assisted)
        {
            if (Math.Truncate(assisted.Distance) <= (float)assistDist.Value)
            {
                SetTarget((int)assisted.TargetID);
                Thread.Sleep(TimeSpan.FromSeconds(0.4));
                WindowInfo.SendText("/assist <t>");
                Thread.Sleep(TimeSpan.FromSeconds(2));
                while (PlayerInfo.Status == 0)
                {
                    if (assisted.Status == 0 || PlayerInfo.Status != 0)
                        break;
                    api.ThirdParty.SendString("/attack <t>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                //TargetInfo.Attack();
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
                return true;
            }
            return false;
        }
        public void CheckPartyIDs()
        {
            var members = api.Party.GetPartyMembers().Where(p => p.Active != 0).ToList();

            if (partyIDs.Count == members.Count)
                return;

            partyIDs.Clear();
            for (var x = 0; x < members.Count; x++)
            {
                var pID = members.SingleOrDefault(m => m.ID == x);

                if (!partyIDs.Contains((int)pID.ID))
                    partyIDs.Add((int)pID.ID);
            }
        }
        #endregion
        #region Methods: DNC
        #region JA: Curing Waltz
        #region JA: CuringWaltzParty
        public void CuringWaltzParty()
        {
            LastFunction = "CuringWaltzParty";
            if (!botRunning || PlayerInfo.Status != 1 || naviMove || PlayerInfo.HasBuff(16)) return;
            var partymembers = (from object itemChecked in PartyWaltsList.Items select itemChecked.ToString()).ToList();
            foreach(string member in partymembers)
            {
                var partymember = api.Party.GetPartyMembers().Find(p => p.Name == member);
                int slot = partymember.MemberNumber;
                var targ = (slot > 5 ? (slot > 11 ? $"<a{((slot - 12) + 20)}>" : $"<a{((slot - 6) + 10)}>") : $"<p{slot}>");
                if (Recast.GetAbilityRecast(217) != 0)
                    return;
                else if (ptusecurev.Checked && partymember.CurrentHPP <= numericUpDown27.Value && PlayerInfo.TP > 800)
                {
                    api.ThirdParty.SendString($"/ja \"Curing Waltz V\" {targ}");
                    break;
                }
                else if (ptusecureiv.Checked && partymember.CurrentHPP <= numericUpDown28.Value && PlayerInfo.TP > 650)
                {
                    api.ThirdParty.SendString($"/ja \"Curing Waltz IV\" {targ}");
                    break;
                }
                else if (ptusecureiii.Checked && partymember.CurrentHPP <= numericUpDown29.Value && PlayerInfo.TP > 500)
                {
                    api.ThirdParty.SendString($"/ja \"Curing Waltz III\" {targ}");
                    break;
                }
                else if (ptusecureii.Checked && partymember.CurrentHPP <= numericUpDown32.Value && PlayerInfo.TP > 350)
                {
                    api.ThirdParty.SendString($"/ja \"Curing Waltz II\" {targ}");
                    break;
                }
                else if (ptusecure.Checked && partymember.CurrentHPP <= numericUpDown33.Value && PlayerInfo.TP > 200)
                {
                    api.ThirdParty.SendString($"/ja \"Curing Waltz\" {targ}");
                    break;
                }
            }
            Thread.Sleep(TimeSpan.FromSeconds(2.0));
        }
        #endregion
        #region JA: CuringWaltzSelf
        private void CuringWaltzSelf()
        {
            LastFunction = "CuringWaltzSelf";
            if (!usecurev.Checked && !usecureiv.Checked && !usecureiii.Checked && !usecureii.Checked && !usecure.Checked &&
               (PlayerInfo.Status != 1 || !botRunning || PlayerInfo.HasBuff(16)))
                return;

            if (TargetInfo.ID > 0 && Recast.GetAbilityRecast(217) == 0)
            {
                if (usecurev.Checked && PlayerInfo.HPP <= usecurevValue.Value && PlayerInfo.TP > 800)
                {
                    api.ThirdParty.SendString("/ja \"Curing Waltz V\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(2.0));
                }
                else if (usecureiv.Checked && PlayerInfo.HPP <= usecureivValue.Value && PlayerInfo.TP > 650)
                {
                    api.ThirdParty.SendString("/ja \"Curing Waltz IV\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(2.0));
                }
                else if (usecureiii.Checked && PlayerInfo.HPP <= usecureiiiValue.Value && PlayerInfo.TP > 500)
                {
                    api.ThirdParty.SendString("/ja \"Curing Waltz III\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(2.0));
                }
                else if (usecureii.Checked && PlayerInfo.HPP <= usecureiiValue.Value && PlayerInfo.TP > 350)
                {
                    api.ThirdParty.SendString("/ja \"Curing Waltz II\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(2.0));
                }
                else if (usecure.Checked && PlayerInfo.HPP <= usecureValue.Value && PlayerInfo.TP > 200)
                {
                    api.ThirdParty.SendString("/ja \"Curing Waltz\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(2.0));
                }
            }
        }
        #endregion
        #endregion
        #region JA: Healing Waltz
        private void HealingWaltz()
        {
            LastFunction = "HealingWaltz";
            var hw = (from object itemChecked in HealingWaltzItems.CheckedItems
                      select itemChecked.ToString()).ToList();

            if (hw.Count == 0) return;

            if (Recast.GetAbilityRecast(215) != 0 || PlayerInfo.Status != 1 || !botRunning ||
                PlayerInfo.HasBuff(16) || PlayerInfo.TP < 200)
                return;

            #region CheckBuffs

            Dictionary<short, string> hwaltzbuff = new Dictionary<short, string>()
            {
                {4, "Paralyze"},{3, "Poison"},{5, "Blind"},{11, "Bind"},{9, "Curse"},{13, "Slow"},{6, "Silence"},{31, "Plague"},{8, "Disease"},{30, "Bane"},
                {135, "Bio"},{128, "Burn"},{130, "Choke"},{131, "Rasp"},{133, "Drown"},{129, "Frost"},{132, "Shock"},{134, "Dia"},{136, "STR Down"},{137, "DEX Down"},
                {138, "VIT Down"},{139, "AGI Down"},{141, "MND Down"},{142, "CHR Down"},{174, "MACC Down"},{148, "EVA Down"},{149, "DEF Down"},{147, "ATT Down"},
                {146, "ACC Down"},{404, "MEVA Down"},{175, "MATT Down"},{167, "MDEF Down"},{144, "HP Down"},{145, "MP Down"},{189, "TP Down"},{140, "INT Down"},
                {186, "Helix"},{12, "Gravity"},
            };
            foreach (KeyValuePair<short, string> kvp in hwaltzbuff)
            {
                if (PlayerInfo.HasBuff(kvp.Key) && hw.Contains(kvp.Value)) CastHealingWatz();
            }

            #endregion
        }
        private void CastHealingWatz()
        {
            api.ThirdParty.SendString("/ja \"Healing Waltz\" <me>");
            Thread.Sleep(TimeSpan.FromSeconds(2.0));
        }
        private void HWSelectDeselectALLCheckedChanged(object sender, EventArgs e)
        {
            #region Select/Deselect All (Healing Walz)
            if (HWSelectDeselectALL.Checked)
            {
                for (var i = 0; i < HealingWaltzItems.Items.Count; i++)
                {
                    HealingWaltzItems.SetItemChecked(i, true);
                }
            }
            else
            {
                for (var i = 0; i < HealingWaltzItems.Items.Count; i++)
                {
                    HealingWaltzItems.SetItemChecked(i, false);
                }
            }
            #endregion
        }
        #endregion
        #region JA: Drain/Aspir/Haste Samba
        private void Sambas()
        {
            LastFunction = "Sambas";
            if (!usedrain.Checked && !usedrainii.Checked && !usedrainiii.Checked && !useaspir.Checked && !useaspirii.Checked && !usehaste.Checked &&
               (PlayerInfo.Status != 1 || !botRunning || PlayerInfo.HasBuff(16) || PlayerInfo.HasBuff(411)))
                return;

            if (Recast.GetAbilityRecast(216) == 0 && (TargetInfo.ID > 0 && TargetInfo.ID != PlayerInfo.ServerID))
            {
                if (usedrain.Checked && !PlayerInfo.HasBuff(368) && PlayerInfo.TP > 100)
                {
                    api.ThirdParty.SendString("/ja \"Drain Samba\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(2.0));
                }
                else if (usedrainii.Checked && !PlayerInfo.HasBuff(368) && PlayerInfo.TP > 250)
                {
                    api.ThirdParty.SendString("/ja \"Drain Samba II\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(2.0));
                }
                else if (usedrainiii.Checked && !PlayerInfo.HasBuff(368) && PlayerInfo.TP > 300)
                {
                    api.ThirdParty.SendString("/ja \"Drain Samba III\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(2.0));
                }
                else if (useaspir.Checked && !PlayerInfo.HasBuff(369) && PlayerInfo.TP > 100)
                {
                    api.ThirdParty.SendString("/ja \"Aspir Samba\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(2.0));
                }
                else if (useaspirii.Checked && !PlayerInfo.HasBuff(369) && PlayerInfo.TP > 250)
                {
                    api.ThirdParty.SendString("/ja \"Aspir Samba II\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(2.0));
                }
                else if (usehaste.Checked && !PlayerInfo.HasBuff(370) && PlayerInfo.TP > 350)
                {
                    api.ThirdParty.SendString("/ja \"Haste Samba\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(2.0));
                }
            }
        }
        #endregion
        #region JA: Flourishe (I,II,III)
        private void UseFlourish()
        {
            LastFunction = "UseFlourish";
            if (!botRunning || PlayerInfo.Status != 1 || PlayerInfo.HasBuff(16))
                return; ;

            if (MonStagered && staggerstopJA.Checked) return;

            var retVal = PlayerInfo.GetFinishingMoves();

            if (retVal == 0)
                return;

            if (PlayerInfo.Status == 1 && (TargetInfo.ID > 0 && TargetInfo.ID != PlayerInfo.ServerID) &&
                Recast.GetAbilityRecast(221) == 0 && Recast.GetAbilityRecast(222) == 0 && Recast.GetAbilityRecast(226) == 0)
            {
                if (!FlourishTP.Checked || (FlourishTP.Checked && PlayerInfo.TP > FlourishTPValue.Value))
                {
                    if (userevflo.Checked && (userevfloValue.Value == retVal || userevfloValue.Value == 7))
                    {
                        api.ThirdParty.SendString("/ja \"Reverse Flourish\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    else if (usevioflo.Checked && (useviofloValue.Value == retVal || useviofloValue.Value == 7))
                    {
                        api.ThirdParty.SendString("/ja \"Violent Flourish\" <t>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    else if (usebldflo.Checked && (usebldfloValue.Value == retVal || usebldfloValue.Value == 7))
                    {
                        api.ThirdParty.SendString("/ja \"Building Flourish\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    else if (usedesflo.Checked && (usedesfloValue.Value == retVal || usedesfloValue.Value == 7))
                    {
                        api.ThirdParty.SendString("/ja \"Desperate Flourish\" <t>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    else if (usewldflo.Checked && (usewldfloValue.Value == retVal || usewldfloValue.Value == 7) && retVal >= 2)
                    {
                        api.ThirdParty.SendString("/ja \"Wild Flourish\" <t>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    else if (useclmflo.Checked && (useclmfloValue.Value == retVal || useclmfloValue.Value == 7))
                    {
                        api.ThirdParty.SendString("/ja \"Climactic Flourish\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    else if (usestkflo.Checked && (usestkfloValue.Value == retVal || usestkfloValue.Value == 7) && retVal >= 2)
                    {
                        api.ThirdParty.SendString("/ja \"Striking Flourish\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    else if (useterflo.Checked && (useterfloValue.Value == retVal || useterfloValue.Value == 7) && retVal >= 3)
                    {
                        api.ThirdParty.SendString("/ja \"Ternary Flourish\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                }
            }
        }
        #endregion
        #region JA: Steps
        private void Steps()
        {
            LastFunction = "Steps";
            if ((!usequickstep.Checked && !useboxstep.Checked && !usestutterstep.Checked && !usefeatherstep.Checked &&
               (!botRunning || NoSteps.Checked || PlayerInfo.Status == 0 || Recast.GetAbilityRecast(220) != 0 || PlayerInfo.HasBuff(16)) ||
               (PlayerInfo.TP < 100) || (StepsHP.Checked && PlayerInfo.HPP < StepsHPValue.Value) || MonStagered && staggerstopJA.Checked) ||
               (DynaProccontrole.Checked && !PlayerInfo.DynaStrike("JA", PlayerInfo.DynaTime(), TargetInfo.Name)))
               return;
               
            var retVal = PlayerInfo.GetFinishingMoves();

            if (stopstepsat.Checked && retVal >= stopstepscount.Value) return;

            if (Recast.GetAbilityRecast(220) == 0 && (TargetInfo.ID > 0 && TargetInfo.ID != PlayerInfo.ServerID))
            {
                if (usequickstep.Checked)
                {
                    api.ThirdParty.SendString("/ja \"Quickstep\" <t>");
                    Thread.Sleep(TimeSpan.FromSeconds(2.0));
                }
                else if (useboxstep.Checked)
                {
                    api.ThirdParty.SendString("/ja \"Box Step\" <t>");
                    Thread.Sleep(TimeSpan.FromSeconds(2.0));
                }
                else if (usestutterstep.Checked)
                {
                    api.ThirdParty.SendString("/ja \"Stutter Step\" <t>");
                    Thread.Sleep(TimeSpan.FromSeconds(2.0));
                }
                else if (usefeatherstep.Checked)
                {
                    api.ThirdParty.SendString("/ja \"Feather Step\" <t>");
                    Thread.Sleep(TimeSpan.FromSeconds(2.0));
                }                
            }
        }
        #endregion
        #region JA: Job Abilities (use)
        private void PlayerJA()
        {
            LastFunction = "PlayerJA";
            if (!botRunning || PlayerInfo.Status != 1 || naviMove || PlayerInfo.HasBuff(16)) return;
            var ja = (from object itemChecked in playerJA.CheckedItems select itemChecked.ToString()).ToList();
            if (ja.Count == 0) return;
            if (MonStagered && staggerstopJA.Checked) return;

            foreach (string J in ja)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.1));
                if (PlayerInfo.Status != 1 || bgw_script_disp.CancellationPending) break;
                var useAbility = false;
                var ability = api.Resources.GetAbility(J, 0);
                var targ = ((ability.ValidTargets & (1 << 0)) != 0 ? "<me>" : "<t>");
                if (HandledAbils.Contains(ability.Name[0])) continue;
                if (ability == null)
                {
                    if (J.Contains("Chivalry TP"))
                    {
                        var chivalry = J.Split(new string[] { "TP > " }, StringSplitOptions.RemoveEmptyEntries);
                        if (!PlayerInfo.HasBuff(16) &&  PlayerInfo.TP >= int.Parse(chivalry[1]) && Recast.GetAbilityRecast(79) == 0 &&
                            PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                        {
                            ability = api.Resources.GetAbility(chivalry[0], 0);
                            targ = "<me>";
                            useAbility = true;
                        }
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
                }
                else if (ability.ID >= 1024 && PlayerInfo.MainJob == 23)
                {
                    if (!PlayerInfo.HasBuff(16) && Recast.GetAbilityRecast(ability.TimerID) == 0 &&
                         PlayerInfo.Status == 1 && TargetInfo.ID > 0 && ability.TP <= PlayerInfo.TP)
                    {
                        if (jacontrol[ability.ID].ToString().Contains("mp ="))
                        {
                            if (PlayerInfo.MPP <= MONmpCount.Value) useAbility = true;
                        }
                        else if (jacontrol[ability.ID].ToString().Contains("hp ="))
                        {
                            if (PlayerInfo.HPP <= MONhpCount.Value) useAbility = true;
                        }
                        else useAbility = true;
                    }
                }
                else if (!jacontrol.ContainsKey(ability.ID)) continue;
                else if (!PlayerInfo.HasBuff(16) && Recast.GetAbilityRecast(ability.TimerID) == 0 &&
                         PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                {
                    if (ability.Name[0] == "Benediction" && PlayerInfo.HPP <= BenedictionHPPuse.Value) useAbility = true;
                    else if (ability.Name[0] == "Convert")
                    {
                        if (ConvertHP.Checked && ConvertHPP.Value >= PlayerInfo.HPP && ConvertMPP.Value <= PlayerInfo.MPP) useAbility = true;
                        else if (ConvertMP.Checked && ConvertHPP.Value <= PlayerInfo.HPP && ConvertMPP.Value >= PlayerInfo.MPP) useAbility = true;
                    }
                    else if (ability.Name[0] == "Sublimation")
                    {
                        if (!PlayerInfo.HasBuff(187) && !PlayerInfo.HasBuff(188)) useAbility = true;
                        else if (PlayerInfo.HasBuff(188) && PlayerInfo.MPP <= Sublimationcount.Value) useAbility = true;
                    }
                    else if (ability.Name[0] == "Vivacious Pulse" && PlayerInfo.HPP <= VivaciousPulseHP.Value && Recast.GetAbilityRecast(242) == 0) useAbility = true;
                    else if (ability.Name[0] == "Shikikoyo" && !PlayerInfo.HasBuff(16) && Recast.GetAbilityRecast(136) == 0) useAbility = true;
                    else if (jacontrol[ability.ID].ToString().Contains("item ="))
                    {
                        if (Inventory.ItemQuantityByName(jacontrol[ability.ID].item) > 0 || Inventory.ItemQuantityByName("Trump Card") > 0) useAbility = true;
                    }
                    else if (jacontrol[ability.ID].ToString().Contains("b2 ="))
                    {
                        if (!PlayerInfo.HasBuff((short)jacontrol[ability.ID].b1) && !PlayerInfo.HasBuff((short)jacontrol[ability.ID].b2)) useAbility = true;
                    }
                    else if (jacontrol[ability.ID].ToString().Contains("b1 ="))
                    {
                        if (!PlayerInfo.HasBuff((short)jacontrol[ability.ID].b1)) useAbility = true;
                    }
                    else if (jacontrol[ability.ID].ToString().Contains("hp ="))
                    {
                        if (PlayerInfo.HPP <= jacontrol[ability.ID].hp) useAbility = true;
                    }
                    else if (jacontrol[ability.ID].ToString().Contains("hpt ="))
                    {
                        if (TargetInfo.HPP <= jacontrol[ability.ID].hpt) useAbility = true;
                    }
                    else useAbility = true;
                }
                if (useAbility && DynaProccontrole.Checked && targ == "<t>" && !PlayerInfo.DynaStrike("JA", PlayerInfo.DynaTime(), TargetInfo.Name))
                    useAbility = false;
                if (PlayerInfo.Status != 1) break;
                if (useAbility)
                {
                    var JAType = (ability.ID >= 1024 ? "/ms" : "/ja");
                    api.ThirdParty.SendString($"{JAType} \"{ability.Name[0]}\" {targ}");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
        }
        #endregion
        #region JA: NIN (shadows)
        private void ninjaShadows()
        {
            LastFunction = "ninjaShadows";
            if (!useshadows.Checked || !NINtoolCheck("Utsusemi"))
                return;

            if (!PlayerInfo.HasBuff(16) && !PlayerInfo.HasBuff(444) && !PlayerInfo.HasBuff(445) && !PlayerInfo.HasBuff(446))
            {
                if (PlayerInfo.MainJob == 13 && PlayerInfo.UsedJobPoints >= 100 && PlayerInfo.HasSpell(340) && Recast.GetSpellRecast(340) == 0)
                {
                    api.ThirdParty.SendString("/ma \"Utsusemi: San\" <me>");
                    Casting();
                }
                else if (PlayerInfo.HasSpell(339) && Recast.GetSpellRecast(339) == 0)
                {
                    api.ThirdParty.SendString("/ma \"Utsusemi: Ni\" <me>");
                    Casting();
                }
                else if (PlayerInfo.HasSpell(338) && Recast.GetSpellRecast(338) == 0)
                {
                    if (PlayerInfo.HasBuff(66))
                    {
                        api.ThirdParty.SendString("//cancel 66");
                        Thread.Sleep(TimeSpan.FromSeconds(3.0));
                    }
                    api.ThirdParty.SendString("/ma \"Utsusemi: Ichi\" <me>");
                    Casting();
                }
            }
        }
        #endregion
        #region MA: Magic (use)
        private void PlayerMA()
        {
            LastFunction = "PlayerMA";
            var ma = (from object itemChecked in playerMA.CheckedItems select itemChecked.ToString()).ToList();
            if (ma.Count == 0) return;
            
            if (MAreverse.Checked) ma.Reverse();
            foreach (string M in ma)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.1));
                if (PlayerInfo.MPP == 0 || PlayerInfo.Status != 1 || bgw_script_disp.CancellationPending) break;
                bool castSpell = false;
                var magic = api.Resources.GetSpell(M, 0);
                var targ = (GetBit(magic.ValidTargets, 0) ? "<me>" : "<t>");
                if (Recast.GetSpellRecast((int)magic.Index) != 0 || !MAautoJA(magic.Name[0]) || PlayerInfo.HasBuff(6)) continue;
                if (PlayerInfo.MP < magic.MPCost && (!PlayerInfo.HasBuff(47) || !PlayerInfo.HasBuff(229))) continue;
                if (Handledspells.Contains(magic.Name[0]))
                {
                    if (magic.Name[0].Contains("Protect") && !PlayerInfo.HasBuff(40)) castSpell = true;
                    else if (magic.Name[0].Contains("Shell") && !PlayerInfo.HasBuff(41)) castSpell = true;
                    else if (magic.Name[0].Contains("Regen") && !PlayerInfo.HasBuff(42)) castSpell = true;
                    else if (magic.Name[0].Contains("Refresh") && !PlayerInfo.HasBuff(43)) castSpell = true;
                    else if (magic.Name[0].Contains("Reraise") && !PlayerInfo.HasBuff(113)) castSpell = true;
                    else if (magic.Name[0] == "Cure" && Curecount.Value >= PlayerInfo.HPP) castSpell = true;
                    else if (magic.Name[0] == "Cure II" && CureIIcount.Value >= PlayerInfo.HPP) castSpell = true;
                    else if (magic.Name[0] == "Cure III" && CureIIIcount.Value >= PlayerInfo.HPP) castSpell = true;
                    else if (magic.Name[0] == "Cure IV" && CureIVcount.Value >= PlayerInfo.HPP) castSpell = true;
                    else if (magic.Name[0] == "Cure V" && CureVcount.Value >= PlayerInfo.HPP) castSpell = true;
                    else if (magic.Name[0] == "Cure VI" && CureVIcount.Value >= PlayerInfo.HPP) castSpell = true;
                    else if (magic.Name[0] == "Cura" && Curacount.Value >= PlayerInfo.HPP) castSpell = true;
                    else if (magic.Name[0] == "Cura II" && CuraIIcount.Value >= PlayerInfo.HPP) castSpell = true;
                    else if (magic.Name[0] == "Cura III" && CuraIIIcount.Value >= PlayerInfo.HPP) castSpell = true;
                    else if (magic.Name[0] == "Full Cure" && FullCurecount.Value >= PlayerInfo.HPP) castSpell = true;
                    else if (magic.Name[0] == "Drain" && Draincount.Value >= PlayerInfo.HPP) castSpell = true;
                    else if (magic.Name[0] == "Drain II" && DrainIIcount.Value >= PlayerInfo.HPP) castSpell = true;
                    else if (magic.Name[0] == "Drain III" && DrainIIIcount.Value >= PlayerInfo.HPP) castSpell = true;
                    else if (magic.Name[0] == "Aspir" && Aspircount.Value >= PlayerInfo.MPP) castSpell = true;
                    else if (magic.Name[0] == "Aspir II" && AspirIIcount.Value >= PlayerInfo.MPP) castSpell = true;
                    else if (magic.Name[0] == "Aspir III" && AspirIIIcount.Value >= PlayerInfo.MPP) castSpell = true;
                    else if (magic.Name[0] == "Pollen" && Pollencount.Value >= PlayerInfo.HPP) castSpell = true;
                    else if (magic.Name[0] == "Magic Fruit" && MagicFruitcount.Value >= PlayerInfo.HPP) castSpell = true;
                    else if (magic.Name[0] == "Healing Breeze" && HealingBreezecount.Value >= PlayerInfo.HPP) castSpell = true;
                    else if (magic.Name[0] == "Plenilune Embrace" && PleniluneEmbracecount.Value >= PlayerInfo.HPP) castSpell = true;
                    else if (magic.Name[0] == "White Wind" && WhiteWindcount.Value >= PlayerInfo.HPP) castSpell = true;
                    else if (magic.Name[0] == "Restoral" && Restoralcount.Value >= PlayerInfo.HPP) castSpell = true;
                    else if (magic.Name[0] == "Exuviation" && Exuviationcount.Value >= PlayerInfo.HPP) castSpell = true;
                    else if (magic.Name[0] == "Wild Carrot" && WildCarrotcount.Value >= PlayerInfo.HPP) castSpell = true;
                    else if (magic.Name[0] == "Cureaga" && Curagacount.Value >= PartyInfo.averageHPP()) castSpell = true;
                    else if (magic.Name[0] == "Cureaga II" && CuragaIIcount.Value >= PartyInfo.averageHPP()) castSpell = true;
                    else if (magic.Name[0] == "Cureaga III" && CuragaIIIcount.Value >= PartyInfo.averageHPP()) castSpell = true;
                    else if (magic.Name[0] == "Cureaga IV" && CuragaIVcount.Value >= PartyInfo.averageHPP()) castSpell = true;
                    else if (magic.Name[0] == "Cureaga V" && CuragaVcount.Value >= PartyInfo.averageHPP()) castSpell = true;
                    else if (ptCure.Checked)
                    {
                        var partymembers = (from object itemChecked in CurePTlist.Items select itemChecked.ToString()).ToList();
                        foreach (string member in partymembers)
                        {
                            var partymember = api.Party.GetPartyMembers().Find(p => p.Name == member);
                            if (magic.Name[0] == "Cure" && Cureptcount.Value >= partymember.CurrentHPP) castSpell = true;
                            else if (magic.Name[0] == "Cure II" && CureIIptcount.Value >= partymember.CurrentHPP) castSpell = true;
                            else if (magic.Name[0] == "Cure III" && CureIIIptcount.Value >= partymember.CurrentHPP) castSpell = true;
                            else if (magic.Name[0] == "Cure IV" && CureIVptcount.Value >= partymember.CurrentHPP) castSpell = true;
                            else if (magic.Name[0] == "Cure V" && CureVptcount.Value >= partymember.CurrentHPP) castSpell = true;
                            else if (magic.Name[0] == "Cure VI" && CureVIptcount.Value >= partymember.CurrentHPP) castSpell = true;
                            else if (magic.Name[0] == "Full Cure" && FullCureptcount.Value >= partymember.CurrentHPP) castSpell = true;
                            if (castSpell)
                            {
                                int slot = partymember.MemberNumber;
                                targ = (slot > 5 ? (slot > 11 ? $"<a{((slot - 12) + 20)}>" : $"<a{((slot - 6) + 10)}>") : $"<p{slot}>");
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (macontrol.ContainsKey((uint)magic.Index))
                    {
                        if (magic.Skill == 39)
                        {
                            if (!NINtoolCheck(magic.Name[0].Replace(": Ichi", "").Replace(": Ni", "").Replace(": San", ""))) continue;
                            else castSpell = true;
                        }
                        else if (macontrol[magic.Index].ToString().Contains("I ="))
                        {
                            if (IndiDic["Active"])
                            {
                                if (macontrol[magic.Index].ToString().Contains("P ="))
                                {
                                    if (IndiDic["Element"] != magic.Element || IndiDic["Enemy"] ||
                                       !PlayerInfo.HasBuff((short)macontrol[magic.Index].B))
                                        castSpell = true;
                                }
                                else if (macontrol[magic.Index].ToString().Contains("E ="))
                                {
                                    if (IndiDic["Element"] != magic.Element || !IndiDic["Enemy"])
                                        castSpell = true;
                                }
                            }
                            else
                            {
                                castSpell = true;
                            }
                        }
                        else if (macontrol[magic.Index].ToString().Contains("b ="))
                        {
                            if (!PlayerInfo.HasBuff((short)macontrol[magic.Index].B) &&
                                !PlayerInfo.HasBuff((short)macontrol[magic.Index].b))
                                castSpell = true;
                        }
                        else if (macontrol[magic.Index].ToString().Contains("H ="))
                        {
                            if (PlayerInfo.HasBuff((short)macontrol[magic.Index].H))
                                castSpell = true;
                        }
                        else if (macontrol[magic.Index].ToString().Contains("B ="))
                        {
                            if (!PlayerInfo.HasBuff((short)macontrol[magic.Index].B))
                                castSpell = true;
                        }
                    }
                    else
                    {
                        if (Recast.GetSpellRecast((int)magic.Index) == 0)
                            castSpell = true;
                    }
                }
                if (castSpell && DynaProccontrole.Checked && targ == "<t>" && !PlayerInfo.DynaStrike("MA", PlayerInfo.DynaTime(), TargetInfo.Name))
                    castSpell = false;
                if (PlayerInfo.Status != 1) break;
                if (castSpell && PlayerInfo.MP >= magic.MPCost)
                {
                    isCasting = true;
                    api.ThirdParty.SendString($"/ma \"{magic.Name[0]}\" {targ}");
                    Casting();
                }
            }
        }
        private bool MAautoJA(string M)
        {
            var ja = (from object itemChecked in playerJA.CheckedItems select itemChecked.ToString()).ToList();
            var magic = api.Resources.GetSpell(M, 0);
            #region BLK MAJA
            if (PlayerInfo.MP < magic.MPCost && !PlayerInfo.HasBuff(47) && !PlayerInfo.HasBuff(229))
            {
                if (ja.Contains("Manafont") && Recast.GetAbilityRecast(0) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Manafont\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                else if (ja.Contains("Manawell") && Recast.GetAbilityRecast(35) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Manawell\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                else return false;
            }
            if (ja.Contains("Elemental Seal") && !PlayerInfo.HasBuff(79) && Recast.GetAbilityRecast(38) == 0)
            {
                api.ThirdParty.SendString("/ja \"Elemental Seal\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Cascade") && !PlayerInfo.HasBuff(598) && magic.Skill == 36 && Recast.GetAbilityRecast(12) == 0)
            {
                api.ThirdParty.SendString("/ja \"Cascade\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Subtle Sorcery") && !PlayerInfo.HasBuff(493) && magic.Skill == 36 && Recast.GetAbilityRecast(254) == 0)
            {
                api.ThirdParty.SendString("/ja \"Subtle Sorcery\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region WHM MAJA
            List<string> DivineSealList = new List<string>(new string[] {"Cure", "Cure II", "Cure III", "Cure IV", "Cure V", "Cure VI", "Full Cure", "Pollen",
            "Healing Breeze", "Wild Carrot", "Magic Fruit", "Exuviation", "Plenilune Embrace", "White Wind", "Restoral", "Poisona", "Paralyna", "Blindna",
            "Silena", "Cursna", "Stona", "Erase", "Cura", "Cura II", "Cura III"});
            
            if (DivineSealList.Contains(magic.Name[0]) && ja.Contains("Divine Seal") && !PlayerInfo.HasBuff(78))
            {
                if (Recast.GetAbilityRecast(26) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Divine Seal\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            List<string> DivineCaressList = new List<string>(new string[] {"Poisona", "Paralyna", "Blindna", "Silena", "Cursna", "Stona"});
            
            if (DivineCaressList.Contains(magic.Name[0]) && ja.Contains("Divine Caress") && !PlayerInfo.HasBuff(453))
            {
                if (Recast.GetAbilityRecast(32) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Divine Caress\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region RDM MAJA
            if (ja.Contains("Chainspell") && !PlayerInfo.HasBuff(48) && Recast.GetAbilityRecast(0) == 0)
            {
                api.ThirdParty.SendString("/ja \"Chainspell\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Saboteur") && !PlayerInfo.HasBuff(454) && magic.Skill == 35 && Recast.GetAbilityRecast(36) == 0)
            {
                api.ThirdParty.SendString("/ja \"Saboteur\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Spontaneity") && !PlayerInfo.HasBuff(230) && !PlayerInfo.HasBuff(48) && Recast.GetAbilityRecast(37) == 0)
            {
                api.ThirdParty.SendString("/ja \"Spontaneity\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Stymie") && !PlayerInfo.HasBuff(494) && magic.Skill == 35 && Recast.GetAbilityRecast(254) == 0)
            {
                api.ThirdParty.SendString("/ja \"Stymie\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region PLD MAJA
            if (ja.Contains("Divine Emblem") && !PlayerInfo.HasBuff(438) && magic.Skill == 32 && Recast.GetAbilityRecast(80) == 0)
            {
                api.ThirdParty.SendString("/ja \"Divine Emblem\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region DRK MAJA
            if (ja.Contains("Dark Seal") && !PlayerInfo.HasBuff(345) && magic.Skill == 37 && Recast.GetAbilityRecast(89) == 0)
            {
                api.ThirdParty.SendString("/ja \"Dark Seal\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            List<string> NetherVoidList = new List<string>(new string[] {"Absorb-MND", "Absorb-CHR", "Absorb-VIT", "Absorb-AGI", "Absorb-INT", "Absorb-DEX",
            "Absorb-STR", "Absorb-TP", "Absorb-ACC", "Absorb-Attri", "Drain", "Drain II", "Aspir", "Aspir II"});
            if (NetherVoidList.Contains(magic.Name[0]) && ja.Contains("Nether Void") && !PlayerInfo.HasBuff(439) && Recast.GetAbilityRecast(91) == 0)
            {
                api.ThirdParty.SendString("/ja \"Nether Void\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region NIN MAJA
            List<string> FutaeList = new List<string>(new string[] {"Katon", "Hyoton", "Huton", "Doton", "Raiton", "Suiton", "Kurayami", "Hojo"});
            if (FutaeList.Contains(Regex.Replace(magic.Name[0], ":.*", "")) && ja.Contains("Futae") &&
            !PlayerInfo.HasBuff(441) && Recast.GetAbilityRecast(148) == 0)
            {
                api.ThirdParty.SendString("/ja \"Futae\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region BLU MAJA
            if (magic.Skill == 43)
            {
                List<string> UnbridledLearningList = new List<string>(new string[] {"Harden Shell", "Thunderbolt", "Absolute Terror", "Gates of Hades", "Tourbillion",
                "Pyric Bulwark", "Bilgestorm", "Bloodrake", "Droning Whirlwind", "Carcharian Verve", "Blistering Roar", "Mighty Guard", "Cruel Joke", "Cesspool",
                "Tearing Gust"});
                if (UnbridledLearningList.Contains(magic.Name[0]) && !PlayerInfo.HasBuff(485) && !PlayerInfo.HasBuff(505))
                {
                    if (ja.Contains("Unbridled Learning") && Recast.GetAbilityRecast(81) == 0)
                    {
                        api.ThirdParty.SendString("/ja \"Unbridled Learning\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    else if (ja.Contains("Unbridled Wisdom") && Recast.GetAbilityRecast(254) == 0)
                    {
                        api.ThirdParty.SendString("/ja \"Unbridled Wisdom\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    else return false;
                }
                List<string> blusupportspells = new List<string>(new string[] { "Metallic Body","Cocoon","Refueling","Feather Barrier","Memento Mori","Zephyr Mantle",
                "Warm-Up","Amplification","Triumphant Roar","Saline Coat","Reactor Cool","Exuviation","Plasma Charge","Regeneration","Battery Charge",
                "Animating Wail","Magic Barrier","Fantod","Occultation", "Mighty Guard"});
                if (ja.Contains("Diffusion") && Recast.GetAbilityRecast(184) == 0 && blusupportspells.Contains(magic.Name[0]) && !PlayerInfo.HasBuff(356))
                {
                    api.ThirdParty.SendString("/ja \"Diffusion\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (magic.Element == 15)
                {
                    if (ja.Contains("Efflux") && Recast.GetAbilityRecast(185) == 0 && !PlayerInfo.HasBuff(457))
                    {
                        api.ThirdParty.SendString("/ja \"Efflux\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    if (ja.Contains("Burst Affinity") && Recast.GetAbilityRecast(182) == 0 && !PlayerInfo.HasBuff(165))
                    {
                        api.ThirdParty.SendString("/ja \"Burst Affinity\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                }
                else
                {
                    if (ja.Contains("Convergence") && Recast.GetAbilityRecast(183) == 0 && !PlayerInfo.HasBuff(355))
                    {
                        api.ThirdParty.SendString("/ja \"Convergence\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    if (ja.Contains("Chain Affinity") && Recast.GetAbilityRecast(181) == 0 && !PlayerInfo.HasBuff(164))
                    {
                        api.ThirdParty.SendString("/ja \"Chain Affinity\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                }
            }
            #endregion
            #region BRD MAJA
            if (magic.Skill == 40 || magic.Skill == 41 || magic.Skill == 42)
            {
                if (ja.Contains("Soul Voice") && !PlayerInfo.HasBuff(52) && Recast.GetAbilityRecast(0) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Soul Voice\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Pianissimo") && !PlayerInfo.HasBuff(409) && Recast.GetAbilityRecast(112) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Pianissimo\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Nightingale") && !PlayerInfo.HasBuff(347) && Recast.GetAbilityRecast(109) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Nightingale\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Troubadour") && !PlayerInfo.HasBuff(348) && Recast.GetAbilityRecast(110) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Troubadour\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Tenuto") && !PlayerInfo.HasBuff(455) && Recast.GetAbilityRecast(47) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Tenuto\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Marcato") && !PlayerInfo.HasBuff(231) && Recast.GetAbilityRecast(48) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Marcato\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Clarion Call") && !PlayerInfo.HasBuff(499) && Recast.GetAbilityRecast(254) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Clarion Call\" <me>");
                }
            }
            #endregion
            #region SCH MAJA
            if (PlayerInfo.MainJob == 20 || PlayerInfo.SubJob == 20)
            {
                List<string> TabulaRasa = new List<string>(new string[] {"Embrava", "Kaustra"});
                List<string> AddendumWhite = new List<string>(new string[] {"Poisona","Paralyna","Blindna","Silena","Cursna","Reraise","Erase","Viruna","Stona",
                "Raise II","Reraise II","Raise III","Reraise III"});
                List<string> AddendumBlack = new List<string>(new string[] {"Sleep","Dispel","Sleep II","Stone IV","Water IV","Aero IV","Fire IV","Blizzard IV",
                "Thunder IV","Stone V","Water V","Aero V","Break","Fire V","Blizzard V","Thunder V"});
                if (ja.Contains("Tabula Rasa") && !PlayerInfo.HasBuff(377) && Recast.GetAbilityRecast(0) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Tabula Rasa\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Light Arts") && magic.MagicType == 1 && !PlayerInfo.HasBuff(358) && Recast.GetAbilityRecast(228) == 0 &&
                    !PlayerInfo.HasBuff(401))
                {
                    api.ThirdParty.SendString("/ja \"Light Arts\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Dark Arts") && magic.MagicType == 2 && !PlayerInfo.HasBuff(359) && Recast.GetAbilityRecast(228) == 0 &&
                    !PlayerInfo.HasBuff(402))
                {
                    api.ThirdParty.SendString("/ja \"Dark Arts\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Enlightenment") && !PlayerInfo.HasBuff(359) && !PlayerInfo.HasBuff(359) &&
                    !PlayerInfo.HasBuff(416) && Recast.GetAbilityRecast(235) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Enlightenment\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                /* if (magic.Name[0].Contains("helix") && ja.Contains("Modus Veritas") && !PlayerInfo.HasBuff(416) && Recast.GetAbilityRecast(235) == 0)
                {
                    api.ThirdParty.SendString("/ja \"Modus Veritas\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                } */
                if (SchCharges >= 1 || PlayerInfo.HasBuff(377))
                {   
                    if (magic.MagicType == 1 && (PlayerInfo.HasBuff(358) || PlayerInfo.HasBuff(401) || PlayerInfo.HasBuff(377)))
                    {
                        #region SCH White MA Stragems
                        if (SchCharges >= 1 && AddendumWhite.Contains(magic.Name[0]) && ja.Contains("Addendum: White") &&
                            !PlayerInfo.HasBuff(401))
                        {
                            api.ThirdParty.SendString("/ja \"Addendum: White\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        else if (AddendumWhite.Contains(magic.Name[0]) && !PlayerInfo.HasBuff(401)) return false;
                        if (SchCharges >= 1 && ja.Contains("Penury") && !PlayerInfo.HasBuff(360))
                        {
                            api.ThirdParty.SendString("/ja \"Penury\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        if (SchCharges >= 1 && ja.Contains("Celerity") && !PlayerInfo.HasBuff(362))
                        {
                            api.ThirdParty.SendString("/ja \"Celerity\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        if (SchCharges >= 1 && ja.Contains("Accession") && !PlayerInfo.HasBuff(366) &&
                           (magic.Skill == 33 || magic.Skill == 34))
                        {
                            api.ThirdParty.SendString("/ja \"Accession\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        if (SchCharges >= 1 && ja.Contains("Rapture") && !PlayerInfo.HasBuff(364))
                        {
                            api.ThirdParty.SendString("/ja \"Rapture\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        if (SchCharges >= 2 && ja.Contains("Altruism") && !PlayerInfo.HasBuff(412))
                        {
                            api.ThirdParty.SendString("/ja \"Altruism\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 2;
                        }
                        if (SchCharges >= 1 && ja.Contains("Tranquility") && !PlayerInfo.HasBuff(414))
                        {
                            api.ThirdParty.SendString("/ja \"Tranquility\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        if (SchCharges >= 1 && ja.Contains("Perpetuance") && !PlayerInfo.HasBuff(469))
                        {
                            api.ThirdParty.SendString("/ja \"Perpetuance\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        #endregion
                    }
                    else if (magic.MagicType == 2 && (PlayerInfo.HasBuff(359) || PlayerInfo.HasBuff(402) || PlayerInfo.HasBuff(377)))
                    {
                        #region SCH Black MA Stragems
                        if (SchCharges >= 1 && AddendumBlack.Contains(magic.Name[0]) && ja.Contains("Addendum: Black") &&
                            !PlayerInfo.HasBuff(402))
                        {
                            api.ThirdParty.SendString("/ja \"Addendum: Black\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        else if (AddendumBlack.Contains(magic.Name[0]) && !PlayerInfo.HasBuff(402)) return false;
                        if (SchCharges >= 1 && ja.Contains("Parsimony") && !PlayerInfo.HasBuff(361))
                        {
                            api.ThirdParty.SendString("/ja \"Parsimony\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        if (SchCharges >= 1 && ja.Contains("Alacrity") && !PlayerInfo.HasBuff(363))
                        {
                            api.ThirdParty.SendString("/ja \"Alacrity\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        if (SchCharges >= 1 && ja.Contains("Manifestation") && !PlayerInfo.HasBuff(367) && magic.Skill == 35)
                        {
                            api.ThirdParty.SendString("/ja \"Manifestation\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        if (SchCharges >= 1 && ja.Contains("Ebullience") && !PlayerInfo.HasBuff(365))
                        {
                            api.ThirdParty.SendString("/ja \"Ebullience\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        if (SchCharges >= 1 && ja.Contains("Focalization") && !PlayerInfo.HasBuff(413))
                        {
                            api.ThirdParty.SendString("/ja \"Focalization\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        if (SchCharges >= 1 && ja.Contains("Equanimity") && !PlayerInfo.HasBuff(415))
                        {
                            api.ThirdParty.SendString("/ja \"Equanimity\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        if (SchCharges >= 1 && ja.Contains("Immanence") && !PlayerInfo.HasBuff(470))
                        {
                            api.ThirdParty.SendString("/ja \"Immanence\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            if (!PlayerInfo.HasBuff(377)) SchCharges -= 1;
                        }
                        #endregion
                    }
                }
                else if (AddendumWhite.Contains(magic.Name[0]) && !PlayerInfo.HasBuff(401)) return false;
                else if (AddendumBlack.Contains(magic.Name[0]) && !PlayerInfo.HasBuff(402)) return false;
            }
            #endregion
            #region GEO MAJA
            if (ja.Contains("Bolster") && magic.Skill == 44 && !PlayerInfo.HasBuff(513) &&
                Recast.GetAbilityRecast(0) == 0)
            {
                api.ThirdParty.SendString("/ja \"Bolster\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Collimated Fervor") && !PlayerInfo.HasBuff(517) && Recast.GetAbilityRecast(245) == 0)
            {
                api.ThirdParty.SendString("/ja \"Collimated Fervor\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Theurgic Focus") && magic.Skill == 36 && !PlayerInfo.HasBuff(519) &&
                Recast.GetAbilityRecast(249) == 0)
            {
                api.ThirdParty.SendString("/ja \"Theurgic Focus\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            if (ja.Contains("Widened Compass") && magic.Skill == 44 && !PlayerInfo.HasBuff(508) &&
                Recast.GetAbilityRecast(130) == 0)
            {
                api.ThirdParty.SendString("/ja \"Widened Compass\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
            #region RUN MAJA
            if (ja.Contains("Embolden") && magic.Skill == 34 && !PlayerInfo.HasBuff(534) &&
                Recast.GetAbilityRecast(72) == 0)
            {
                api.ThirdParty.SendString("/ja \"Embolden\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            #endregion
             return true;
        }
        private bool NINtoolCheck(string nin)
        {
            var item = nintools[nin];
            if (Inventory.ItemQuantityByName(item.ElementAt(0)) > 0) return true;
            else if (Inventory.ItemQuantityByName(item.ElementAt(1)) > 0)
            {
                WindowInfo.SendText($"/item \"{item.ElementAt(1)}\"<me>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
                return true;
            }
            else if (PlayerInfo.MainJob == 13 && Inventory.ItemQuantityByName(item.ElementAt(2)) > 0) return true;
            else if (PlayerInfo.MainJob == 13 && Inventory.ItemQuantityByName(item.ElementAt(3)) > 0)
            {
                WindowInfo.SendText($"/item \"{item.ElementAt(3)}\"<me>");
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
                return true;
            }
            return false;
        }
        private void Casting(bool trust = false)
        {
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
            var count = 0;
            float lastPercent = 0;
            var castingbreak = false;
            var castPercent = api.CastBar.Percent;
            while (castPercent < 1)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.1));
                if (TargetInfo.ID == PlayerInfo.ServerID)
                    TargetInfo.SetTarget(0);
                castPercent = api.CastBar.Percent;
                if (lastPercent != castPercent)
                {
                    count = 0;
                    lastPercent = castPercent;
                }
                else if (count == 10)
                {
                    if (trust && TargetInfo.ID > 0 && TargetInfo.ID != PlayerInfo.ServerID)
                        castingbreak = true;
                    
                    break;
                }
                else
                {
                    count++;
                    lastPercent = castPercent;
                }
            }
            isCasting = false;
            if (castingbreak && trust)
                return;
            Thread.Sleep(TimeSpan.FromSeconds(2.0));
        }
        #endregion
        #region WS: WeaponSkill (use)
        private void PlayerWS()
        {
            LastFunction = "PlayerWS";
            if (!botRunning || PlayerInfo.Status == 0 || TargetInfo.ID == 0) return;
            if (DynaProccontrole.Checked && !PlayerInfo.DynaStrike("WS", PlayerInfo.DynaTime(), TargetInfo.Name)) return;
            List<string> SelfTargWS = new List<string>(new string[] { "Myrkr", "Starlight", "Moonlight", "Dagan" });
            var wsname = selectedWS.Text;
            var wstarg = "t";
            var amtarg = "t";
            var sekkanokitarg = "t";
            if (SelfTargWS.Contains(wsname))
                wstarg = "me";
            if (SelfTargWS.Contains(amname.Text))
                amtarg = "me";
            if (SelfTargWS.Contains(sekkanokiWs.Text))
                sekkanokitarg = "me";
            
            if (wsam.Checked && amname.Text != "")
            {
                if (AfterMathTier.Value == 1 && PlayerInfo.TP >= 1000 &&
                   (TargetInfo.HPP >= TragetHPPbottom.Value &&
                    TargetInfo.HPP <= TragetHPPtop.Value) &&
                    PlayerInfo.Status == 1 && TargetInfo.ID > 0 &&
                    !PlayerInfo.HasBuff(270))
                {
                    api.ThirdParty.SendString("/ws \"" + amname.Text + "\" <"+amtarg+">");
                    Thread.Sleep(TimeSpan.FromSeconds(4.0));
                }
                else if (AfterMathTier.Value == 2 && PlayerInfo.TP >= 2000 &&
                        (TargetInfo.HPP >= TragetHPPbottom.Value &&
                         TargetInfo.HPP <= TragetHPPtop.Value) &&
                         PlayerInfo.Status == 1 && TargetInfo.ID > 0 &&
                         !PlayerInfo.HasBuff(271))
                {
                    api.ThirdParty.SendString("/ws \"" + amname.Text + "\" <"+amtarg+">");
                    Thread.Sleep(TimeSpan.FromSeconds(4.0));
                }
                else if (AfterMathTier.Value == 3 && PlayerInfo.TP >= 3000 &&
                        (TargetInfo.HPP >= TragetHPPbottom.Value &&
                         TargetInfo.HPP <= TragetHPPtop.Value) &&
                         PlayerInfo.Status == 1 && TargetInfo.ID > 0 &&
                         !PlayerInfo.HasBuff(272))
                {
                    api.ThirdParty.SendString("/ws \"" + amname.Text + "\" <"+amtarg+">");
                    Thread.Sleep(TimeSpan.FromSeconds(4.0));
                }
            }

            var ja = (from object itemChecked in playerJA.CheckedItems
                      select itemChecked.ToString()).ToList();
            var wstp = WStp.Value;
            if (ja.Contains("Sekkanoki") && !PlayerInfo.HasBuff(54) && Recast.GetAbilityRecast(140) == 0) wstp = 2000;
            if (PlayerInfo.TP >= wstp &&  api.Player.GetPlayerInfo().MainJob == 12 || api.Player.GetPlayerInfo().SubJob == 12)
            {
                if (ja.Contains("Sekkanoki") && !PlayerInfo.HasBuff(16) &&
                    !PlayerInfo.HasBuff(408) && !PlayerInfo.HasBuff(54) && Recast.GetAbilityRecast(140) == 0 &&
                    PlayerInfo.Status == 1 && TargetInfo.ID > 0 && PlayerInfo.TP >= 2000)
                {
                    api.ThirdParty.SendString("/ja \"Sekkanoki\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Hagakure") && !PlayerInfo.HasBuff(16) &&
                    !PlayerInfo.HasBuff(483) && Recast.GetAbilityRecast(54) == 0 &&
                    PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                {
                    api.ThirdParty.SendString("/ja \"Hagakure\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Sengikori") && !PlayerInfo.HasBuff(16) && !PlayerInfo.HasBuff(483) &&
                    !PlayerInfo.HasBuff(440) && Recast.GetAbilityRecast(141) == 0 &&
                    PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                {
                    api.ThirdParty.SendString("/ja \"Sengikori\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (ja.Contains("Konzen-ittai") && !PlayerInfo.HasBuff(16) &&
                    Recast.GetAbilityRecast(140) == 0 &&
                    TargetInfo.ID > 0)
                {
                    api.ThirdParty.SendString("/ja \"Konzen-ittai\" <t>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            if (ws.Checked && !wsam.Checked && PlayerInfo.Status == 1)
            {
                if (PlayerInfo.TP >= wstp &&
                    TargetInfo.HPP >= TragetHPPbottom.Value &&
                    TargetInfo.HPP <= TragetHPPtop.Value &&
                    PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                {
                    if (PlayerInfo.HasBuff(483))
                    {
                        string WSSekkanoki = wsname;
                        if (sekkanokiWs.Text != "")
                            WSSekkanoki = sekkanokiWs.Text;
                        api.ThirdParty.SendString("/ws \"" + WSSekkanoki + "\" <"+sekkanokitarg+">");
                        Thread.Sleep(TimeSpan.FromSeconds(4.0));
                    }
                    api.ThirdParty.SendString("/ws \"" + wsname + "\" <"+wstarg+">");
                    Thread.Sleep(TimeSpan.FromSeconds(4.0));
                }
            }

            if (ws.Checked && wsam.Checked &&
               (PlayerInfo.TP >= wstp &&
                TargetInfo.HPP >= TragetHPPbottom.Value &&
                TargetInfo.HPP <= TragetHPPtop.Value) &&
                PlayerInfo.Status == 1 && TargetInfo.ID > 0)
            {
                if (PlayerInfo.HasBuff(270) || PlayerInfo.HasBuff(271) ||
                    PlayerInfo.HasBuff(272) || PlayerInfo.HasBuff(273))
                {
                    api.ThirdParty.SendString("/ws \"" + wsname + "\" <"+wstarg+">");
                    Thread.Sleep(TimeSpan.FromSeconds(4.0));
                }
            }
            else if (ws.Checked && wsam.Checked && amname.Text == "" && PlayerInfo.Status == 1)
            {
                if (PlayerInfo.TP >= wstp &&
                    TargetInfo.HPP >= TragetHPPbottom.Value &&
                    TargetInfo.HPP <= TragetHPPtop.Value &&
                    PlayerInfo.Status == 1 && TargetInfo.ID > 0)
                {
                    api.ThirdParty.SendString("/ws \"" + wsname + "\" <"+wstarg+">");
                    Thread.Sleep(TimeSpan.FromSeconds(4.0));
                }
            }
        }
        #endregion
        #endregion
        #region Methods: PET
        public void pInfo()
        {
            label20.Text = "Pets Name: " + PetInfo.Name;
            label21.Text = @"Pet ID: " + PetInfo.ID;
            label22.Text = @"Pets HP%: " + PetInfo.HPP;
            label23.Text = @"Pets TP: " + PetInfo.TPP;
        }
        #region PET: BST
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
                        if (!PetReady.Items.Contains("Tortoise Stomp")) PetReady.Items.Add("Tortoise Stomp");
                        if (!PetReady.Items.Contains("Harden Shell")) PetReady.Items.Add("Harden Shell");
                        if (!PetReady.Items.Contains("Aqua Breath")) PetReady.Items.Add("Aqua Breath");
                        break;
                    #endregion
                    #region Familiar: Antlion
                    case "Antlion Familiar":
                    case "Cursed Annabelle":
                    case "Chopsuey Chucky":
                        if (!PetReady.Items.Contains("Sandpit")) PetReady.Items.Add("Sandpit");
                        if (!PetReady.Items.Contains("Sandblast")) PetReady.Items.Add("Sandblast");
                        if (!PetReady.Items.Contains("Venom Spray")) PetReady.Items.Add("Venom Spray");
                        if (!PetReady.Items.Contains("Mandibular Bite")) PetReady.Items.Add("Mandibular Bite");
                        break;
                    #endregion
                    #region Familiar: Apkallu
                    case "Surging Storm":
                    case "Submerged Iyo":
                    case "Dapper Mac":
                        if (!PetReady.Items.Contains("Wing Slap")) PetReady.Items.Add("Wing Slap");
                        if (!PetReady.Items.Contains("Beak Lunge")) PetReady.Items.Add("Beak Lunge");
                        break;
                    #endregion
                    #region Familiar: Beetle
                    case "Beetle Familiar":
                    case "Panzer Galahad":
                    case "Hurler Percival":
                        if (!PetReady.Items.Contains("Spoil")) PetReady.Items.Add("Spoil");
                        if (!PetReady.Items.Contains("Rhino Guard")) PetReady.Items.Add("Rhino Guard");
                        if (!PetReady.Items.Contains("Rhino Attack")) PetReady.Items.Add("Rhino Attack");
                        if (!PetReady.Items.Contains("Power Attack")) PetReady.Items.Add("Power Attack");
                        if (!PetReady.Items.Contains("Hi-Freq Field")) PetReady.Items.Add("Hi-Freq Field");
                        break;
                    #endregion
                    #region Familiar: Chapuli
                    case "Bouncing Bertha":
                    case "Scissorleg Xerin":
                        if (!PetReady.Items.Contains("Sensilla Blades")) PetReady.Items.Add("Sensilla Blades");
                        if (!PetReady.Items.Contains("Tegmina Buffet")) PetReady.Items.Add("Tegmina Buffet");
                        break;
                    #endregion
                    #region Familiar: Coeurl
                    case "Crafty Clyvonne":
                        if (!PetReady.Items.Contains("Chaotic Eye")) PetReady.Items.Add("Chaotic Eye");
                        if (!PetReady.Items.Contains("Blaster")) PetReady.Items.Add("Blaster");
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
                        if (!PetReady.Items.Contains("Metallic Body")) PetReady.Items.Add("Metallic Body");
                        if (!PetReady.Items.Contains("Bubble Shower")) PetReady.Items.Add("Bubble Shower");
                        if (!PetReady.Items.Contains("Bubble Curtain")) PetReady.Items.Add("Bubble Curtain");
                        if (!PetReady.Items.Contains("Scissor Guard")) PetReady.Items.Add("Scissor Guard");
                        if (!PetReady.Items.Contains("Big Scissors")) PetReady.Items.Add("Big Scissors");
                        break;
                    #endregion
                    #region Familiar: Diremite
                    case "Anklebiter Jedd":
                    case "Diremite Familiar":
                    case "Lifedrinker Lars":
                        if (!PetReady.Items.Contains("Grapple")) PetReady.Items.Add("Grapple");
                        if (!PetReady.Items.Contains("Spinning Top")) PetReady.Items.Add("Spinning Top");
                        if (!PetReady.Items.Contains("Double Claw")) PetReady.Items.Add("Double Claw");
                        if (!PetReady.Items.Contains("Filamented Hold")) PetReady.Items.Add("Filamented Hold");
                        break;
                    #endregion
                    #region Familiar: Eft
                    case "Eft Familiar":
                    case "Ambusher Allie":
                    case "Bugeyed Broncha":
                    case "Suspicious Alice":
                        if (!PetReady.Items.Contains("Geist Wall")) PetReady.Items.Add("Geist Wall");
                        if (!PetReady.Items.Contains("Toxic Spit")) PetReady.Items.Add("Toxic Spit");
                        if (!PetReady.Items.Contains("Numbing Noise")) PetReady.Items.Add("Numbing Noise");
                        if (!PetReady.Items.Contains("Nimble Snap")) PetReady.Items.Add("Nimble Snap");
                        if (!PetReady.Items.Contains("Cyclotail")) PetReady.Items.Add("Cyclotail");
                        break;
                    #endregion
                    #region Familiar: Fly
                    case "Mayfly Familiar":
                    case "Shellbuster Orob":
                    case "Mailbuster Cetas":
                    case "Headbreaker Ken":
                        if (!PetReady.Items.Contains("Cursed Sphere")) PetReady.Items.Add("Cursed Sphere");
                        if (!PetReady.Items.Contains("Venom")) PetReady.Items.Add("Venom");
                        break;
                    #endregion
                    #region Familiar: Flytrap
                    case "Flytrap Familiar":
                    case "Voracious Audrey":
                    case "Presto Julio":
                        if (!PetReady.Items.Contains("Gloeosuccus")) PetReady.Items.Add("Gloeosuccus");
                        if (!PetReady.Items.Contains("Palsy Pollen")) PetReady.Items.Add("Palsy Pollen");
                        if (!PetReady.Items.Contains("Soporific")) PetReady.Items.Add("Soporific");
                        break;
                    #endregion
                    #region Familiar: Funguar
                    case "Funguar Familiar":
                    case "Discreet Louise":
                    case "Brainy Waluis":
                        if (!PetReady.Items.Contains("Frog Kick")) PetReady.Items.Add("Frog Kick");
                        if (!PetReady.Items.Contains("Queasyshroom")) PetReady.Items.Add("Queasyshroom");
                        if (!PetReady.Items.Contains("Silence Gas")) PetReady.Items.Add("Silence Gas");
                        if (!PetReady.Items.Contains("Numbshroom")) PetReady.Items.Add("Numbshroom");
                        if (!PetReady.Items.Contains("Spore")) PetReady.Items.Add("Spore");
                        if (!PetReady.Items.Contains("Dark Spore")) PetReady.Items.Add("Dark Spore");
                        if (!PetReady.Items.Contains("Shakeshroom")) PetReady.Items.Add("Shakeshroom");
                        break;
                    #endregion
                    #region Familiar: Hippogryph
                    case "Faithful Falcorr":
                        if (!PetReady.Items.Contains("Back Heel")) PetReady.Items.Add("Back Heel");
                        if (!PetReady.Items.Contains("Jettatura")) PetReady.Items.Add("Jettatura");
                        if (!PetReady.Items.Contains("Choke Breath")) PetReady.Items.Add("Choke Breath");
                        if (!PetReady.Items.Contains("Fantod")) PetReady.Items.Add("Fantod");
                        break;
                    #endregion
                    #region Familiar: Ladybug
                    case "Dipper Yuly":
                    case "Threestar Lynn":
                        if (!PetReady.Items.Contains("Sudden Lunge")) PetReady.Items.Add("Sudden Lunge");
                        if (!PetReady.Items.Contains("Spiral Spin")) PetReady.Items.Add("Spiral Spin");
                        if (!PetReady.Items.Contains("Noisome Powder")) PetReady.Items.Add("Noisome Powder");
                        break;
                    #endregion
                    #region Familiar: Leech
                    case "Fatso Fargann":
                        if (!PetReady.Items.Contains("Suction")) PetReady.Items.Add("Suction");
                        if (!PetReady.Items.Contains("Drainkiss")) PetReady.Items.Add("Drainkiss");
                        if (!PetReady.Items.Contains("Acid Mist")) PetReady.Items.Add("Acid Mist");
                        if (!PetReady.Items.Contains("TP Drainkiss")) PetReady.Items.Add("TP Drainkiss");
                        break;
                    #endregion
                    #region Familiar: Lizard
                    case "Lizard Familiar":
                    case "Coldblood Como":
                    case "Audacious Anna":
                    case "Warlike Patrick":
                        if (!PetReady.Items.Contains("Blockhead")) PetReady.Items.Add("Blockhead");
                        if (!PetReady.Items.Contains("Secretion")) PetReady.Items.Add("Secretion");
                        if (!PetReady.Items.Contains("Baleful Gaze")) PetReady.Items.Add("Baleful Gaze");
                        if (!PetReady.Items.Contains("Fireball")) PetReady.Items.Add("Fireball");
                        if (!PetReady.Items.Contains("Tail Blow")) PetReady.Items.Add("Tail Blow");
                        if (!PetReady.Items.Contains("Plague Breath")) PetReady.Items.Add("Plague Breath");
                        if (!PetReady.Items.Contains("Brain Crush")) PetReady.Items.Add("Brain Crush");
                        if (!PetReady.Items.Contains("Infrasonics")) PetReady.Items.Add("Infrasonics");
                        break;
                    #endregion
                    #region Familiar: Lycopodium
                    case "Flowerpot Merle":
                        if (!PetReady.Items.Contains("Head Butt")) PetReady.Items.Add("Head Butt");
                        if (!PetReady.Items.Contains("Scream")) PetReady.Items.Add("Scream");
                        if (!PetReady.Items.Contains("Wild Oats")) PetReady.Items.Add("Wild Oats");
                        if (!PetReady.Items.Contains("Leaf Dagger")) PetReady.Items.Add("Leaf Dagger");
                        break;
                    #endregion
                    #region Familiar: Lynx
                    case "Bloodclaw Shasra":
                        if (!PetReady.Items.Contains("Chaotic Eye")) PetReady.Items.Add("Chaotic Eye");
                        if (!PetReady.Items.Contains("Blaster")) PetReady.Items.Add("Blaster");
                        if (!PetReady.Items.Contains("Charged Whisker")) PetReady.Items.Add("Charged Whisker");
                        break;
                    #endregion
                    #region Familiar: Mandragora
                    case "Flowerpot Bill":
                    case "Flowerpot Ben":
                    case "Homunculus":
                    case "Sharpwit Hermes":
                        if (!PetReady.Items.Contains("Head Butt")) PetReady.Items.Add("Head Butt");
                        if (!PetReady.Items.Contains("Scream")) PetReady.Items.Add("Scream");
                        if (!PetReady.Items.Contains("Dream Flower")) PetReady.Items.Add("Dream Flower");
                        if (!PetReady.Items.Contains("Wild Oats")) PetReady.Items.Add("Wild Oats");
                        if (!PetReady.Items.Contains("Leaf Dagger")) PetReady.Items.Add("Leaf Dagger");
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
                        if (!PetReady.Items.Contains("Intimidate")) PetReady.Items.Add("Intimidate");
                        if (!PetReady.Items.Contains("Recoil Dive")) PetReady.Items.Add("Recoil Dive");
                        if (!PetReady.Items.Contains("Water Wall")) PetReady.Items.Add("Water Wall");
                        break;
                    #endregion
                    #region Familiar: Raaz
                    case "Caring Kiyomaro":
                    case "Vivacious Vickie":
                        if (!PetReady.Items.Contains("Sweeping Gouge")) PetReady.Items.Add("Sweeping Gouge");
                        if (!PetReady.Items.Contains("Zealous Snort")) PetReady.Items.Add("Zealous Snort");
                        break;
                    #endregion
                    #region Familiar: Rabbit
                    case "Pondering Peter":
                    case "Hare Familiar":
                    case "Keeneared Steffi":
                    case "Droopy Dortwin":
                    case "Lucky Lulush":
                        if (!PetReady.Items.Contains("Whirl Claws")) PetReady.Items.Add("Whirl Claws");
                        if (!PetReady.Items.Contains("Dust Cloud")) PetReady.Items.Add("Dust Cloud");
                        if (!PetReady.Items.Contains("Foot Kick")) PetReady.Items.Add("Foot Kick");
                        if (!PetReady.Items.Contains("Wild Carrot")) PetReady.Items.Add("Wild Carrot");
                        break;
                    #endregion
                    #region Familiar: Raptor
                    case "Swift Sieghard":
                    case "Fleet Reinhard":
                        if (!PetReady.Items.Contains("Scythe Tail")) PetReady.Items.Add("Scythe Tail");
                        if (!PetReady.Items.Contains("Ripper Fang")) PetReady.Items.Add("Ripper Fang");
                        if (!PetReady.Items.Contains("Chomp Rush")) PetReady.Items.Add("Chomp Rush");
                        break;
                    #endregion
                    #region Familiar: Sabotender
                    case "Amigo Sabotender":
                        if (!PetReady.Items.Contains("1000 Needles")) PetReady.Items.Add("1000 Needles");
                        if (!PetReady.Items.Contains("Needleshot")) PetReady.Items.Add("Needleshot");
                        break;
                    #endregion
                    #region Familiar: Sheep
                    case "Sheep Familiar":
                    case "Nursery Nazuna":
                    case "Rhyming Shizuna":
                    case "Lullaby Melodia":
                        if (!PetReady.Items.Contains("Sheep Song")) PetReady.Items.Add("Sheep Song");
                        if (!PetReady.Items.Contains("Sheep Charge")) PetReady.Items.Add("Sheep Charge");
                        if (!PetReady.Items.Contains("Lamb Chop")) PetReady.Items.Add("Lamb Chop");
                        if (!PetReady.Items.Contains("Rage")) PetReady.Items.Add("Rage");
                        break;
                    #endregion
                    #region Familiar: Slug
                    case "Gooey Gerard":
                    case "Generous Arthur":
                        if (!PetReady.Items.Contains("Purulent Ooze")) PetReady.Items.Add("Purulent Ooze");
                        if (!PetReady.Items.Contains("Corrosive Ooze")) PetReady.Items.Add("Corrosive Ooze");
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
                        if (!PetReady.Items.Contains("Tickling Tendrils")) PetReady.Items.Add("Tickling Tendrils");
                        if (!PetReady.Items.Contains("Stink Bomb")) PetReady.Items.Add("Stink Bomb");
                        if (!PetReady.Items.Contains("Nectarous Deluge")) PetReady.Items.Add("Nectarous Deluge");
                        if (!PetReady.Items.Contains("Nepenthic Plunge")) PetReady.Items.Add("Nepenthic Plunge");
                        break;
                    #endregion
                    #region Familiar: Tiger
                    case "Tiger Familiar":
                    case "Saber Siravarde":
                    case "Gorefang Hobs":
                    case "Blackbeard Randy":
                        if (!PetReady.Items.Contains("Claw Cyclone")) PetReady.Items.Add("Claw Cyclone");
                        if (!PetReady.Items.Contains("Razor Fang")) PetReady.Items.Add("Razor Fang");
                        if (!PetReady.Items.Contains("Roar")) PetReady.Items.Add("Roar");
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
                        if (!PetReady.Items.Contains("Molting Plumage")) PetReady.Items.Add("Molting Plumage");
                        if (!PetReady.Items.Contains("Swooping Frenzy")) PetReady.Items.Add("Swooping Frenzy");
                        if (!PetReady.Items.Contains("Pentapeck")) PetReady.Items.Add("Pentapeck");
                        break;
                    #endregion
                }
            }

            #region BST: Pet Ready
            var joblvl = 0;
            if (PlayerInfo.MainJob == 9) joblvl = PlayerInfo.MainJobLevel;
            else if (PlayerInfo.SubJob == 9) joblvl = PlayerInfo.SubJobLevel;
            if (joblvl >= 25 && !PetJA.Items.Contains("Sic")) PetJA.Items.Add("Sic");
            if (joblvl >= 45 && !PetJA.Items.Contains("Snarl")) PetJA.Items.Add("Snarl");
            if (joblvl >= 75 && PlayerInfo.HasAbility(162) && !PetJA.Items.Contains("Killer Instinct")) PetJA.Items.Add("Killer Instinct");
            if (joblvl >= 75 && PlayerInfo.HasAbility(161) && !PetJA.Items.Contains("Feral Howl")) PetJA.Items.Add("Feral Howl");
            if (joblvl >= 83 && !PetJA.Items.Contains("Spur")) PetJA.Items.Add("Spur");
            if (joblvl >= 93 && !PetJA.Items.Contains("Run Wild")) PetJA.Items.Add("Run Wild");
            if (joblvl >= 96 && !PetJA.Items.Contains("Unleash")) PetJA.Items.Add("Unleash");
            #endregion
        }
        #endregion
        #region JA: BST (use)
        private void PetReadyJA()
        {
            LastFunction = "PetReadyJA";
            if (PlayerInfo.Status == 0 || !botRunning || TargetInfo.ID == 0) return;

            #region BST Pet JA
            var bstja = (from object itemChecked in PetJA.CheckedItems select itemChecked.ToString()).ToList();

            foreach (string D in bstja)
            {
                if (PlayerInfo.Status == 0 || !botRunning || TargetInfo.ID == 0) break;
                var ability = api.Resources.GetAbility(D, 0);
                if (PlayerInfo.HasAbility(ability.ID) && Recast.GetAbilityRecast(102) == 0 && !PlayerInfo.HasBuff(16))
                {
                    api.ThirdParty.SendString("/pet \"" + ability.Name[0] + "\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            #endregion
            #region BST Pet Ready
            var petja = (from object itemChecked in PetReady.CheckedItems select itemChecked.ToString()).ToList();
            if (petja.Count == 0) return;

            foreach (string P in petja)
            {
                if (PlayerInfo.Status == 0 || !botRunning || TargetInfo.ID == 0) break;
                var ability = api.Resources.GetAbility(P, 0);
                if (PlayerInfo.HasAbility(ability.ID) && Recast.GetAbilityRecast(102) == 0 && !PlayerInfo.HasBuff(16) &&
                        PetInfo.TPP > BstJATP.Value)
                {
                    api.ThirdParty.SendString("/pet \"" + ability.Name[0] + "\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
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

            if (PlayerInfo.MainJob != 14 && PlayerInfo.SubJob != 14) return;

            #region JA: DRG
            if ((PlayerInfo.MainJobLevel >= 25 || PlayerInfo.SubJobLevel >= 25) &&
                 PlayerInfo.HasAbility(592) && !WyvernJA.Items.Contains("Spirit Link")) WyvernJA.Items.Add("Spirit Link");
            if (PlayerInfo.MainJobLevel >= 75 && PlayerInfo.HasAbility(681) && !WyvernJA.Items.Contains("Deep Breathing")) WyvernJA.Items.Add("Deep Breathing");
            if (PlayerInfo.MainJobLevel >= 90 && !WyvernJA.Items.Contains("Smiting Breath")) WyvernJA.Items.Add("Smiting Breath");
            if (PlayerInfo.MainJobLevel >= 90 && !WyvernJA.Items.Contains("Restoring Breath")) WyvernJA.Items.Add("Restoring Breath");
            if (PlayerInfo.MainJobLevel >= 95 && !WyvernJA.Items.Contains("Steady Wing")) WyvernJA.Items.Add("Steady Wing");
            #endregion
        }
        #endregion
        #region JA: DRG (use)
        private void WyvernUseJA()
        {
            LastFunction = "WyvernUseJA";
            var petja = (from object itemChecked in WyvernJA.CheckedItems select itemChecked.ToString()).ToList();

            if (petja.Count == 0 || PlayerInfo.Status == 0 || PlayerInfo.HasBuff(16)) return;

            if (petja.Contains("Restoring Breath") && PlayerInfo.Status == 1 &&
                PlayerInfo.HPP <= RestoringBreathHP.Value && Recast.GetAbilityRecast(239) == 0)
            {
                if (petja.Contains("Deep Breathing") && !PlayerInfo.HasBuff(16) &&
                    Recast.GetAbilityRecast(164) == 0 && TargetInfo.ID > 0)
                {
                    api.ThirdParty.SendString("/ja \"Deep Breathing\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                api.ThirdParty.SendString("/pet \"Restoring Breath\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }

            if (petja.Contains("Steady Wing") && PlayerInfo.Status == 1 &&
                PetInfo.HPP < DragonPetHP.Value && !PlayerInfo.HasBuff(16) && Recast.GetAbilityRecast(70) == 0)
            {
                api.ThirdParty.SendString("/pet \"Steady Wing\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }

            if (petja.Contains("Spirit Link") && PlayerInfo.Status == 1 &&
                PetInfo.HPP < WyvernSpirit.Value && PlayerInfo.HPP > PlayerSpirit.Value &&
                Recast.GetAbilityRecast(162) == 0 && !PlayerInfo.HasBuff(16))
            {
                api.ThirdParty.SendString("/ja \"Spirit Link\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }

            if (petja.Contains("Smiting Breath") && PlayerInfo.Status == 1 &&
                TargetInfo.HPP > BreathMIN.Value && TargetInfo.HPP <= BreathMAX.Value &&
                Recast.GetAbilityRecast(238) == 0 && !PlayerInfo.HasBuff(16))
            {
                if (petja.Contains("Deep Breathing") && !PlayerInfo.HasBuff(16) &&
                    Recast.GetAbilityRecast(164) == 0 && TargetInfo.ID > 0)
                {
                    api.ThirdParty.SendString("/ja \"Deep Breathing\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                api.ThirdParty.SendString("/pet \"Smiting Breath\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
        }
        #endregion
        #endregion
        #region PET: SMN
        #region JA: SMN (get/set)
        private void SMNGetJA()
        {
            if (SMNAbilityList.Items.Count > 0) SMNAbilityList.Items.Clear();
            if (SMNJA.Items.Count > 0) SMNJA.Items.Clear();
            if (PlayerInfo.MainJob != 15 && PlayerInfo.SubJob != 15) return;
            var joblvl = 0;
            if (PlayerInfo.MainJob == 15) joblvl = PlayerInfo.MainJobLevel;
            else if (PlayerInfo.SubJob == 15) joblvl = PlayerInfo.SubJobLevel;
            Dictionary<string, uint> SumJA = new Dictionary<string, uint>()
            {
                {"Astral Flow", 1},{"Apogee", 70},{"Mana Cede", 87},{"Astral Conduit", 96}
            };
            foreach (KeyValuePair<string, uint> kvp in SumJA)
            {
                if (SMNSelect.SelectedItem.ToString().Contains("Spirit"))
                {
                    if (joblvl >= 50 && !SMNJA.Items.Contains("Elemental Siphon")) SMNJA.Items.Add("Elemental Siphon");
                }
                else if (joblvl >= kvp.Value) SMNJA.Items.Add(kvp.Key);
            }
            Dictionary<string, dynamic> SummoningJA = new Dictionary<string, dynamic>()
            {
                {"Carbuncle", new Dictionary<string, uint>() {{"Searing Light", 1},{"Healing Ruby", 1},{"Poison Nails", 5},{"Shining Ruby", 24},
                    {"Glittering Ruby", 44},{"Meteorite", 55},{"Healing Ruby II", 65},{"Holy Mist", 76},{"Soothing Ruby", 94},{"Pacifying Ruby", 99}}},
                {"Fenrir", new  Dictionary<string, uint>() {{"Howling Moon", 1},{"Moonlit Charge", 10},{"Crescent Fang", 10},{"Lunar Cry", 21},
                    {"Lunar Roar", 32},{"Ecliptic Growl", 43},{"Ecliptic Howl", 54},{"Eclipse Bite", 65},{"Lunar Bay", 78},{"Heavenward Howl", 96},
                    {"Impact", 99}}},
                {"Ifrit", new  Dictionary<string, uint>() {{"Inferno", 1},{"Punch", 1},{"Fire II", 10},{"Burning Strike", 23},{"Double Punch", 30},
                    {"Crimson Howl", 38},{"Fire IV", 60},{"Flaming Crush", 70},{"Meteor Strike", 75},{"Inferno Howl", 88},{"Conflag Strike", 99}}},
                {"Titan", new  Dictionary<string, uint>() {{"Earthen Fury", 1},{"Rock Throw", 1},{"Stone II", 10},{"Rock Buster", 21},{"Megalith Throw", 35},
                    {"Earthen Ward", 46},{"Stone IV", 60},{"Mountain Buster", 70},{"Geocrush", 75},{"Earthen Armor", 82},{"Crag Throw", 99}}},
                {"Leviathan", new  Dictionary<string, uint>() {{"Tidal Wave", 1},{"Barracuda Dive", 1},{"Water II", 10},{"Tail Whip", 26},{"Slowga", 33},
                    {"Spring Water", 47},{"Water IV", 60},{"Spinning Dive", 70},{"Grand Fall", 75},{"Tidal Roar", 84},{"Soothing Current", 99}}},
                {"Garuda", new  Dictionary<string, uint>() {{"Aerial Blast", 1},{"Claw", 1},{"Aero II", 10},{"Aerial Armor", 25},{"Whispering Wind", 36},
                    {"Hastega", 48},{"Aero IV", 60},{"Predator Claws", 70},{"Wind Blade", 75},{"Fleet Wind", 86},{"Hastega II", 99}}},
                {"Shiva", new  Dictionary<string, uint>() {{"Diamond Dust", 1},{"Axe Kick", 1},{"Blizzard II", 10},{"Frost Armor", 28},{"Sleepga", 39},
                    {"Double Slap", 50},{"Blizzard IV", 60},{"Rush", 70},{"Heavenly Strike", 75},{"Diamond Storm", 90},{"Crystal Blessing", 99}}},
                {"Ramuh", new  Dictionary<string, uint>() {{"Judgment Bolt", 1},{"Shock Strike", 1},{"Thunder II", 10},{"Thunderspark", 19},
                    {"Rolling Thunder", 31},{"Lightning Armor", 42},{"Thunder IV", 60},{"Chaotic Strike", 70},{"Thunderstorm", 75},{"Shock Squall", 92},
                    {"Volt Strike", 99}}},
                {"Diabolos", new  Dictionary<string, uint>() {{"Ruinous Omen", 1},{"Camisado", 1},{"Somnolence", 20},{"Nightmare", 29},{"Ultimate Terror", 37},
                    {"Noctoshield", 49},{"Dream Shroud", 56},{"Nether Blast", 65},{"Night Terror", 80},{"Pavor Nocturnus", 98},{"Blindside", 99}}},
                {"Cait Sith", new  Dictionary<string, uint>() {{"Altana's Favor", 1},{"Regal Scratch", 1},/*{"Raise II", 15},*/{"Mewing Lullaby", 25},
                    {"Reraise II", 30},{"Eerie Eye", 55},{"Level ? Holy", 75},{"Regal Gash", 99}}},
            };
            if (!SummoningJA.ContainsKey((string)SMNSelect.SelectedItem)) return;
            foreach (KeyValuePair<string, uint> kvp in SummoningJA[(string)SMNSelect.SelectedItem])
            {
                if (joblvl >= kvp.Value) SMNAbilityList.Items.Add(kvp.Key);
            }
            if (joblvl >= 55) SMNAbilityList.Items.Add("Avatar's Favor");
        }
        #endregion
        #region JA: SMN (use)
        private void SMNUseJA()
        {
            LastFunction = "SMNUseJA";
            if (PlayerInfo.Status == 0 || PlayerInfo.Status == 33) return;
            var petja = (from object itemChecked in SMNAbilityList.CheckedItems select itemChecked.ToString()).ToList();
            var ja = (from object itemChecked in SMNJA.CheckedItems select itemChecked.ToString()).ToList();
            if (PlayerInfo.Status == 0 || PlayerInfo.HasBuff(16)) return;
            var magic = api.Resources.GetSpell((string)SMNSelect.SelectedItem, 0);
            var joblvl = 0;
            if (PlayerInfo.MainJob == 15) joblvl = PlayerInfo.MainJobLevel;
            else if (PlayerInfo.SubJob == 15) joblvl = PlayerInfo.SubJobLevel;
            if (PetInfo.ID == 0 && PlayerInfo.MP >= magic.MPCost && SMNpetMPUSEset.Value <= PlayerInfo.MPP && Recast.GetSpellRecast((int)magic.Index) == 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(((double) pullDelay.Value) + 3.0));
                api.ThirdParty.SendString("/ma \""+magic.Name[0]+"\" <me>");
                Casting();
            }
            Dictionary<string, uint> AvatarFavorbuff = new Dictionary<string, uint>()
            {
                {"Carbuncle", 422},{"Fenrir", 429},{"Ifrit", 423},{"Titan", 426},{"Leviathan", 428},{"Garuda", 425},{"Shiva", 424},{"Ramuh", 427},
                {"Diabolos", 430},{"Cait Sith", 577}
            };
            if (PetInfo.Status == 0) return;
            if (PetInfo.ID != 0 && petja.Contains("Avatar's Favor") && Recast.GetAbilityRecast(176) == 0 &&
                !PlayerInfo.HasBuff((short)AvatarFavorbuff[magic.Name[0]]) && !PlayerInfo.HasBuff(431))
            {
                api.ThirdParty.SendString("/pet \"Avatar's Favor\" <me>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            Dictionary<string, dynamic> SMNcontrol = new Dictionary<string, dynamic>()
            {
                {"Carbuncle", new Dictionary<string, dynamic>() 
                    {
                    {"Healing Ruby II", new {ward=0,hp2=0,tp=0}},{"Healing Ruby", new {ward=0,hp1=0,tp=0}},{"Shining Ruby", new {ward=0,buff=40,buff2=41}},
                    {"Glittering Ruby", new {ward=0}},{"Pacifying Ruby", new {ward=0}},{"Soothing Ruby", new {ward=0}},{"Poison Nails", new {rage=0}},
                    {"Meteorite", new {rage=0,tp=0}},{"Holy Mist", new {rage=0,tp=0}},{"Searing Light", new {af=0,rage=0,tp=0}}
                    }},
                {"Fenrir", new  Dictionary<string, dynamic>() 
                    {
                    {"Heavenward Howl", new {ward=0,buff=487,buff2=488}},{"Ecliptic Howl", new {ward=0,buff=90,buff2=92}},{"Ecliptic Growl", new {ward=0,buff=0}},
                    {"Lunar Roar", new {ward=0}},{"Lunar Cry", new {ward=0}},{"Lunar Bay", new {rage=0,tp=0}},{"Eclipse Bite", new {rage=0}},
                    {"Crescent Fang", new {rage=0}},{"Moonlit Charge", new {rage=0}},{"Impact", new {rage=0}},{"Howling Moon", new {af=0,rage=0}}
                    }},
                {"Ifrit", new  Dictionary<string, dynamic>() 
                    {
                    {"Crimson Howl", new {ward=0,buff=68}},{"Inferno Howl", new {ward=0,buff=94}},{"Meteor Strike", new {rage=0,tp=0}},{"Fire IV", new {rage=0,tp=0}},
                    {"Fire II", new {rage=0,tp=0}},{"Conflag Strike", new {rage=0}},{"Flaming Crush", new {rage=0}},{"Double Punch", new {rage=0}},
                    {"Burning Strike", new {rage=0}},{"Punch", new {rage=0}},{"Inferno", new {af=0,rage=0,tp=0}}
                    }},
                {"Titan", new  Dictionary<string, dynamic>() 
                    {
                    {"Earthen Armor", new {ward=0,buff=458}},{"Earthen Ward", new {ward=0,buff=07}},{"Geocrush", new {rage=0,tp=0}},{"Mountain Buster", new {rage=0}},
                    {"Crag Throw", new {rage=0}},{"Stone IV", new {rage=0,tp=0}},{"Stone II", new {rage=0,tp=0}},{"Megalith Throw", new {rage=0}},
                    {"Rock Throw", new {rage=0}},{"Rock Buster", new {rage=0}},{"Earthen Fury", new {af=0,rage=0,tp=0}}
                    }},
                {"Leviathan", new  Dictionary<string, dynamic>() 
                    {
                    {"Spring Water", new {ward=0,hp1=0,tp=0}},{"Soothing Current", new {ward=0,buff=586}},{"Tidal Roar", new {ward=0}},{"Slowga", new {ward=0}},
                    {"Grand Fall", new {rage=0,tp=0}},{"Water IV", new {rage=0,tp=0}},{"Water II", new {rage=0,tp=0}},{"Barracuda Dive", new {rage=0}},
                    {"Tail Whip", new {rage=0}},{"Spinning Dive", new {rage=0}},{"Tidal Wave", new {af=0,rage=0,tp=0}}
                    }},
                {"Garuda", new  Dictionary<string, dynamic>() 
                    {
                    {"Whispering Wind", new {ward=0,hp1=0,tp=0}},{"Hastega II", new {ward=0,buff=33}},{"Hastega", new {ward=0,buff=33}},
                    {"Aerial Armor", new {ward=0,buff=36}},{"Fleet Wind", new {ward=0,buff=176}},{"Aero IV", new {rage=0,tp=0}},{"Aero II", new {rage=0,tp=0}},
                    {"Wind Blade", new {rage=0,tp=0}},{"Predator Claws", new {rage=0}},{"Claw", new {rage=0}},{"Aerial Blast", new {af=0,rage=0,tp=0}}
                    }},
                {"Shiva", new  Dictionary<string, dynamic>() 
                    {
                    {"Crystal Blessing", new {ward=0,buff=587}},{"Frost Armor", new {ward=0,buff=05}},{"Diamond Storm", new {ward=0}},{"Sleepga", new {ward=0}},
                    {"Heavenly Strike", new {rage=0,tp=0}},{"Blizzard IV", new {rage=0,tp=0}},{"Blizzard II", new {rage=0,tp=0}},{"Rush", new {rage=0}},
                    {"Double Slap", new {rage=0}},{"Axe Kick", new {rage=0}},{"Diamond Dust", new {af=0,rage=0,tp=0}}
                    }},
                {"Ramuh", new  Dictionary<string, dynamic>() 
                    {
                    {"Rolling Thunder", new {ward=0,buff=89}},{"Lightning Armor", new {ward=0,buff=08}},{"Shock Squall", new {ward=0}},{"Volt Strike", new {rage=0}},
                    {"Thunderstorm", new {rage=0,tp=0}},{"Thunder IV", new {rage=0,tp=0}},{"Thunderspark", new {rage=0,tp=0}},{"Thunder II", new {rage=0,tp=0}},
                    {"Chaotic Strike", new {rage=0}},{"Shock Strike", new {rage=0}},{"Judgment Bolt", new {af=0,rage=0,tp=0}}
                    }},
                {"Diabolos", new  Dictionary<string, dynamic>() 
                    {
                    {"Dream Shroud", new {ward=0,buff=190,buff2=191}},{"Noctoshield", new {ward=0,buff=116}},{"Pavor Nocturnus", new {ward=0}},
                    {"Somnolence", new {ward=0,tp=0}},{"Ultimate Terror", new {ward=0}},{"Nightmare", new {ward=0}},{"Blindside", new {rage=0}},
                    {"Night Terror", new {rage=0,tp=0}},{"Nether Blast", new {rage=0,tp=0}},{"Camisado", new {rage=0}},{"Ruinous Omen", new {af=0,rage=0,tp=0}}
                    }},
                {"Cait Sith", new  Dictionary<string, dynamic>() 
                    {
                    {"Reraise II", new {ward=0,buff=113}},{"Eerie Eye", new {ward=0}},{"Mewing Lullaby", new {ward=0}},/*{"Raise II", new {ward=0}},*/
                    {"Regal Scratch", new {rage=0}},{"Regal Gash", new {rage=0}},{"Level ? Holy", new {rage=0}},{"Altana's Favor", new {af=0,ward=0,buff=113}}
                    }},
                };
            if (!SMNcontrol.ContainsKey((string)SMNSelect.SelectedItem))
            {
                if (ja.Contains("Elemental Siphon") && Recast.GetAbilityRecast(175) == 0 && SMNHPPset1.Value >= PlayerInfo.MPP)
                {
                    api.ThirdParty.SendString("/ja \"Elemental Siphon\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            else if (petja.Count == 0) return;
            else
            {
                foreach (KeyValuePair<string, dynamic> kvp in SMNcontrol[(string)SMNSelect.SelectedItem])
                {
                    var useAbility = false;
                    var Ability = api.Resources.GetAbility(kvp.Key, 0);
                    var targ = ((Ability.ValidTargets & (1 << 0)) != 0 ? "<me>" : "<t>");
                    if (kvp.Value.ToString().Contains("tp =") && SMNpetTPUSEset.Value > PetInfo.TPP) continue;
                    if (ja.Contains("Astral Conduit") && Ability.MP >= PlayerInfo.MP && Recast.GetAbilityRecast(254) == 0)
                    {
                        api.ThirdParty.SendString("/ja \"Astral Conduit\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    if (ja.Contains("Apogee") && ApogeeMPPset.Value >= PlayerInfo.MPP && Recast.GetAbilityRecast(108) == 0)
                    {
                        api.ThirdParty.SendString("/ja \"Apogee\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    if (ja.Contains("Mana Cede") && ManaCedeMPPset.Value >= PlayerInfo.MPP && ManaCedeTPset.Value <= PetInfo.TPP && Recast.GetAbilityRecast(71) == 0)
                    {
                        api.ThirdParty.SendString("/ja \"Mana Cede\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    if (kvp.Value.ToString().Contains("af =") && petja.Contains(kvp.Key) && ja.Contains("Astral Flow"))
                    {
                        if (kvp.Value.ToString().Contains("rage =") && Recast.GetAbilityRecast(174) != 0) continue;
                        if (kvp.Value.ToString().Contains("ward =") && Recast.GetAbilityRecast(173) != 0) continue;
                        if ((joblvl * 2) <= PlayerInfo.MP) useAbility = true;
                        {
                            useAbility = true;
                            api.ThirdParty.SendString("/ja \"Astral Flow\" <me>");
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                        }
                    }
                    else if (kvp.Value.ToString().Contains("rage =") && petja.Contains(kvp.Key) && Recast.GetAbilityRecast(174) == 0)
                    {
                        if (Ability.MP <= PlayerInfo.MP) useAbility = true;
                    }
                    else if (kvp.Value.ToString().Contains("ward =") && petja.Contains(kvp.Key) && Recast.GetAbilityRecast(173) == 0)
                    {
                        if (kvp.Value.ToString().Contains("hp1 =") && SMNHPPset1.Value >= PlayerInfo.HPP && Ability.MP <= PlayerInfo.MP) useAbility = true;
                        else if (kvp.Value.ToString().Contains("hp2 =") && SMNHPPset2.Value >= PlayerInfo.HPP && Ability.MP <= PlayerInfo.MP) useAbility = true;
                        else if (kvp.Value.ToString().Contains("buff2 =") && Ability.MP <= PlayerInfo.MP)
                        {
                            if (!PlayerInfo.HasBuff((short)kvp.Value.buff2) || !PlayerInfo.HasBuff((short)kvp.Value.buff)) useAbility = true;
                        }
                        else if (kvp.Value.ToString().Contains("buff =") && Ability.MP <= PlayerInfo.MP)
                        {
                            if (Ability.Name[0] == "Glittering Ruby")
                            {
                                if (!PlayerInfo.HasBuff(119) || !PlayerInfo.HasBuff(120) || !PlayerInfo.HasBuff(121) || !PlayerInfo.HasBuff(122) ||
                                !PlayerInfo.HasBuff(123) || !PlayerInfo.HasBuff(124) || !PlayerInfo.HasBuff(125)) useAbility = true;
                            }
                            else if (Ability.Name[0] == "Ecliptic Growl")
                            {
                                if (!PlayerInfo.HasBuff(119) && !PlayerInfo.HasBuff(120) && !PlayerInfo.HasBuff(121) && !PlayerInfo.HasBuff(122) &&
                                !PlayerInfo.HasBuff(123) && !PlayerInfo.HasBuff(124) && !PlayerInfo.HasBuff(125)) useAbility = true;
                            }
                            else if (!PlayerInfo.HasBuff((short)kvp.Value.buff)) useAbility = true;
                        }
                        else useAbility = true;
                    }
                    if (useAbility)
                    {
                        api.ThirdParty.SendString(String.Format("/pet \"{0}\" {1}", Ability.Name[0], targ));
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                }
            }
        }
        #endregion
        #endregion
        #region PET: PUP
        #region JA: PUP (get/set)
        private void PUPGetJA()
        {
            if (PUPJA.Items.Count > 0) PUPJA.Items.Clear();
            if (PlayerInfo.MainJob != 18 && PlayerInfo.SubJob != 18) return;
            List<uint> pupabilitylist = new List<uint>(new uint[] {647, 822, 649, 691, 692, 778, 821, 852,});
            foreach (uint P in pupabilitylist)
            {
                var ability = api.Resources.GetAbility(P);
                if (PlayerInfo.HasAbility(P))
                {
                    PUPJA.Items.Add(ability.Name[0]);
                }   
            }
        }
        #endregion
        #region JA: PUP (use)
        private void PUPUseJA()
        {
            LastFunction = "PUPUseJA";
            if (PetInfo.ID != 0 && PetInfo.Status == 0 && PlayerInfo.Status == 1 && PUPautoengage.Checked && Recast.GetAbilityRecast(207) == 0)
            {
                api.ThirdParty.SendString("/pet \"Deploy\" <t>");
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
            var petja = (from object itemChecked in PUPJA.CheckedItems select itemChecked.ToString()).ToList();
            if (AutoCallPUP.Checked && PetInfo.ID == 0)
            {
                if (Recast.GetAbilityRecast(205) == 0)
                {    
                    api.ThirdParty.SendString("/ja \"Activate\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                else if(Recast.GetAbilityRecast(115) == 0 && petja.Contains("Deus Ex Automata"))
                {    
                    api.ThirdParty.SendString("/ja \"Deus Ex Automata\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            if (PlayerInfo.Status == 0 || PetInfo.ID == 0 || PlayerInfo.HasBuff(16)) return;
            else
            {
                Dictionary<string, short> PUPManeuverbuff = new Dictionary<string, short>()
                {
                    {"Fire Maneuver", 300},{"Ice Maneuver", 301},{"Wind Maneuver", 302},{"Earth Maneuver", 303},{"Thunder Maneuver", 304},{"Water Maneuver", 305},
                    {"Light Maneuver", 306},{"Dark Maneuver", 307}
                };
                if ((string)Maneuver1select.SelectedItem != "Not Selected")
                {
                    if (PlayerInfo.HasBuffcount(PUPManeuverbuff[(string)Maneuver1select.SelectedItem]) < Maneuver1set.Value && Recast.GetAbilityRecast(210) == 0)
                    {
                        api.ThirdParty.SendString(String.Format("/pet \"{0}\" <me>", (string)Maneuver1select.SelectedItem));
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                }
                if ((string)Maneuver2select.SelectedItem != "Not Selected")
                {
                    if (PlayerInfo.HasBuffcount(PUPManeuverbuff[(string)Maneuver2select.SelectedItem]) < Maneuver2set.Value && Recast.GetAbilityRecast(210) == 0)
                    {
                        api.ThirdParty.SendString(String.Format("/pet \"{0}\" <me>", (string)Maneuver2select.SelectedItem));
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                }
                if ((string)Maneuver3select.SelectedItem != "Not Selected")
                {
                    if (PlayerInfo.HasBuffcount(PUPManeuverbuff[(string)Maneuver3select.SelectedItem]) < Maneuver3set.Value && Recast.GetAbilityRecast(210) == 0)
                    {
                        api.ThirdParty.SendString(String.Format("/pet \"{0}\" <me>", (string)Maneuver3select.SelectedItem));
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                }
                if (petja.Count == 0) return;
                if (petja.Contains("Cooldown") && Recast.GetAbilityRecast(114) == 0 && PlayerInfo.HasBuff(299))
                {
                    api.ThirdParty.SendString("/ja \"Cooldown\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Repair") && Recast.GetAbilityRecast(206) == 0 && Inventory.ItemQuantityByName(Repairselect.SelectedText) > 0 && Repairset.Value >= PetInfo.HPP)
                {
                    api.ThirdParty.SendString("/ja \"Repair\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Role Reversal") && Recast.GetAbilityRecast(211) == 0)
                {
                    if (RRPlayer.Checked && RRPlayerHPPset.Value >= PlayerInfo.HPP && RRPetHPPset.Value <= PetInfo.HPP)
                    {
                        api.ThirdParty.SendString("/ja \"Role Reversal\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    else if (RRPET.Checked && RRPlayerHPPset.Value <= PlayerInfo.HPP && RRPetHPPset.Value >= PetInfo.HPP)
                    {
                        api.ThirdParty.SendString("/ja \"Role Reversal\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                }
                if (petja.Contains("Tactical Switch") && Recast.GetAbilityRecast(213) == 0)
                {
                    if (TSPlayer.Checked && TSPlayerTPset.Value >= PlayerInfo.TP && TSPetTPset.Value <= PetInfo.TPP)
                    {
                        api.ThirdParty.SendString("/ja \"Tactical Switch\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    else if (TSPET.Checked && TSPlayerTPset.Value <= PlayerInfo.TP && TSPetTPset.Value >= PetInfo.TPP)
                    {
                        api.ThirdParty.SendString("/ja \"Tactical Switch\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                }
                if (petja.Contains("Ventriloquy") && Recast.GetAbilityRecast(212) == 0)
                {
                    if (VentriloquyPet.Checked && api.Entity.GetEntity(TargetInfo.ID).ClaimID == PlayerInfo.ServerID)
                    {
                        api.ThirdParty.SendString("/ja \"Ventriloquy\" <pet>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    else if (VentriloquyPlayer.Checked && api.Entity.GetEntity(TargetInfo.ID).ClaimID != PlayerInfo.ServerID)
                    {
                        api.ThirdParty.SendString("/ja \"Ventriloquy\" <me>");
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                }
                if (petja.Contains("Overdrive") && Recast.GetAbilityRecast(0) == 0 && !PlayerInfo.HasBuff(166))
                {
                    api.ThirdParty.SendString("/ja \"Overdrive\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
                if (petja.Contains("Heady Artifice") && Recast.GetAbilityRecast(254) == 0 && !PlayerInfo.HasBuff(166))
                {
                    api.ThirdParty.SendString("/ja \"Heady Artifice\" <me>");
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
        }
        #endregion
        #endregion
        #endregion
        #region Methods: FRM
        #region Farming: populate target list
        private bool IsUpper(string value)// Consider string to be uppercase if it has no lowercase letters.
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsLower(value[i]))
                {
                    return false;
                }
            }
            return true;
        }
        private bool IsLower(string value)// Consider string to be lowercase if it has no uppercase letters.
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsUpper(value[i]))
                {
                    return false;
                }
            }
            return true;
        }
        private bool FirstIsLower(string value)// Consider string to be lowercase if it has no uppercase letters.
        {
            if (char.IsUpper(value[0]))
            {
                return false;
            }
            return true;
        }
        private void PopulateTargetLists(string idType)
        {
            if (MainWindow.TESTMODE && MainWindow.STATUS.Contains(@":: Final Fantasy Not Found ::")) return;
            wantedID.Clear();
            wantedNM.Clear();

            #region variables
            var zone = api.Player.ZoneId;
            var hexs = zone.ToString("X");
            if (!dats.ContainsKey(hexs)) return;
            var path = "";
            var xloc = "";

            var list = new ArrayList();
            var tb = new byte[32];
            #endregion

            if (FFXIPath == "")
            {
                foreach (var pm in from p in Process.GetProcessesByName("pol") from ProcessModule pm in p.Modules where pm.ModuleName.ToLower() == "ffximain.dll" select pm)
                {
                    xloc = pm.FileName.Remove(pm.FileName.Length - 13);
                }
                FFXIPath = xloc;

                dats.TryGetValue(hexs, out path);
                xloc = xloc + path;
            }
            else
            {
                dats.TryGetValue(hexs, out path);
                xloc = FFXIPath + path;
            }

            var myStream = new FileStream(xloc, FileMode.Open, FileAccess.Read);

            var size = (int)myStream.Length;
            var buffer = new byte[size];

            int num;
            var sum = 0;
            while ((num = myStream.Read(buffer, sum, size - sum)) > 0)
                sum += num;
            
            #region populate targets
            for (var x = 0; x < buffer.Length; x = x + 32)
            {
                Buffer.BlockCopy(buffer, x, tb, 0, 32);

                path = Encoding.ASCII.GetString(tb);
                var strg = path.Substring(0, 28);
                var tmp1 = strg;
                var tmp2 = tmp1.Replace(char.ConvertFromUtf32(0), null);

                var exist = list.Contains(tmp2);
                var empty = (tmp2.Length == 0);
                var mobid = tb[28] + ((tb[29] & 15) << 8);
                var waste = notWanted.Contains(tmp2);
                if (!waste) waste = IsUpper(tmp2);
                if (!waste) waste = IsLower(tmp2);
                if (!waste) waste = FirstIsLower(tmp2);
                if (!waste) waste = tmp2.IndexOfAny("_#[]:".ToCharArray()) != -1;
                if (!(empty) && x != 0 && !(exist) && !(waste))
                {
                    wantedID.Add(string.Format("{0:X}", mobid), tmp2);
                    if (!wantedNM.ContainsValue(tmp2))
                    {
                        wantedNM.Add(string.Format("{0:X}", mobid), tmp2);
                    }
                }
            }
            #endregion
        }
        #endregion
        #region Function: TargetMoving
        public bool TargetMoving()
        {
            if (TargetInfo.ID <= 0 || TargetInfo.HPP == 0)
                return false;

            var targetLastDistance = TargetInfo.Distance;
            Thread.Sleep(TimeSpan.FromSeconds(1.0));
            var targetCurrentDistance = TargetInfo.Distance;

            if (targetLastDistance == targetCurrentDistance)
                return false;

            return true;
        }
        #endregion
        #region Function: Detect/Attack Aggro
        private void DetectAggro()
        {
            if (!aggro.Checked || PlayerInfo.Status == 1 || isPulled)
                return;

            var searchID = (float)aggroRange.Value;
            var targetID = -1;

            for (var x = 0; x < 2048; x++)
            {
                if (PlayerInfo.Status == 1)
                    return;

                var entity = api.Entity.GetEntity(x);

                if (entity.WarpPointer == 0 || entity.HealthPercent == 0 || entity.TargetID <= 0 ||
                    !GetBit(entity.SpawnFlags, 4))
                    continue;

                if (wantedNM.ContainsValue(entity.Name) && searchID > entity.Distance && entity.Status == 1)
                {
                    var vertdiff = Math.Abs((PlayerInfo.Y - entity.Y));
                    if (vertdiff >= (mobheightdist.Checked ? (float)mobheightdistValue.Value : float.PositiveInfinity)) continue;
                    searchID = entity.Distance;
                    targetID = (int)entity.TargetID;
                }
            }

            if (targetID == -1)
                return;

            var wanted = api.Entity.GetEntity(targetID);
            

            if (wanted.ClaimID != 0 || wanted.HealthPercent == 0 ||
                targetID <= 0 || !GetBit(wanted.SpawnFlags, 4)) return;

            if (isMoving)
                isMoving = false;

            if (usenav.Checked && naviMove)
                naviMove = false;
            api.AutoFollow.IsAutoFollowing = false;

            if (TargetInfo.ID != targetID)
            {
                SetTarget(targetID);

                TargetInfo.FaceTarget(TargetInfo.X, TargetInfo.Z);
                Thread.Sleep(TimeSpan.FromSeconds(0.4));
            }

            if (!TargetMoving() || !(wanted.Distance > (float)aggroRange.Value))
            {
                if (wanted.ClaimID == 0 && wanted.HealthPercent != 0 && wanted.TargetID > 0)
                {
                    if (rangeaggro.Checked && pullCommand.Text != "" &&
                        wanted.HealthPercent != 0 && wanted.TargetID > 0)
                    {
                        api.ThirdParty.SendString(pullCommand.Text);

                        var delay = DateTime.Now.AddSeconds((double)pullDelay.Value);
                        while (DateTime.Now < delay)
                        {
                            TargetInfo.FaceTarget(TargetInfo.X, TargetInfo.Z);
                            Thread.Sleep(TimeSpan.FromSeconds(0.1));
                        }
                    }

                    if (!TargetInfo.LockedOn && AutoLock.Checked)
                        api.ThirdParty.SendString("/lockon <t>");

                    if (wanted.ClaimID == PlayerInfo.ServerID ||
                        wanted.ClaimID == 0 && wanted.TargetID > 0)
                    {
                        api.ThirdParty.SendString("/attack <t>");
                        Thread.Sleep(TimeSpan.FromSeconds(4.0));

                        if (PlayerInfo.Status == 0)
                        {
                            api.ThirdParty.SendString("/attack <t>");
                            Thread.Sleep(TimeSpan.FromSeconds(4.0));
                        }
                    }

                }
            }

            if (api.Target.GetTargetInfo().TargetId > 0 && PlayerInfo.Status == 0 &&
                wanted.Distance > (float)aggroRange.Value)
            {
                if (usenav.Checked && selectedNavi.Text != "")
                    naviMove = true;

                SetTarget(0);
            }

            if (PlayerInfo.Status == 0 && wanted.ClaimID != api.Player.ServerId)
            {
                SetTarget(0);

                if (usenav.Checked && selectedNavi.Text != "")
                    naviMove = true;
            }
        }
        #endregion
        #region Function: Get/Set Target
        private void SetTarget(int ID)
        {
            if (ManualTargMode.Checked || OpenDoor) return;
            TargetInfo.SetTarget(ID);
        }
        public void FindTarget()
        {
            if (SelectedTargets.Items.Count == 0 || PlayerInfo.Status == 1 || isPulled || partyAssist.Checked || assist.Checked)
                return;
            float searchID = 999;
            var targetID = -1;

            for (var x = 0; x < 2048; x++)
            {

                var entity = api.Entity.GetEntity(x);

                if (entity.WarpPointer == 0 || entity.HealthPercent == 0 || entity.TargetID <= 0 ||
                    !GetBit(entity.SpawnFlags, 4) || entity.ClaimID != 0 || ignoreTarget.Contains((int)entity.TargetID)) continue;

                foreach (ListViewItem item in SelectedTargets.Items)
                {

                    if (item.SubItems[1].Text.Contains(entity.Name) && SelectedTargets.Columns[0].Width == 0 ||
                        (item.Text.Contains(entity.TargetID.ToString("X")) && SelectedTargets.Columns[0].Width == 35))
                    {
                        if (entity.HealthPercent != 0 && entity.Distance <= (float)targetSearchDist.Value)
                        {
                            if (searchID > entity.Distance &&
                                entity.Distance > (float)pullTolorance.Value &&
                                entity.ClaimID == 0 && entity.HealthPercent != 0 &&
                                GetBit(entity.SpawnFlags, 4))
                            {
                                var vertdiff = Math.Abs((PlayerInfo.Y - entity.Y));
                                if (vertdiff >= (mobheightdist.Checked ? (float)mobheightdistValue.Value : float.PositiveInfinity)) continue;
                                searchID = entity.Distance;
                                targetID = Convert.ToInt32(entity.TargetID);
                            }
                        }
                    }
                }
            }

            if (targetID == -1)
                return;

            var target = api.Entity.GetEntity(targetID);

            if (isMoving)
                isMoving = false;

            if (usenav.Checked && naviMove)
                naviMove = false;

            while (api.AutoFollow.IsAutoFollowing)
            {
                if (api.AutoFollow.IsAutoFollowing)
                    api.AutoFollow.IsAutoFollowing = false;
            }

            Thread.Sleep(TimeSpan.FromSeconds(0.5));

            if (target.ClaimID != 0 || target.HealthPercent == 0)
                return;

            SetTarget(targetID);
            Thread.Sleep(TimeSpan.FromSeconds(0.3));

            TargetInfo.FaceTarget(target.X, target.Z);
            Thread.Sleep(TimeSpan.FromSeconds(0.4));

            if (!TargetInfo.LockedOn && AutoLock.Checked)
                WindowInfo.SendText("/lockon <t>");

            if (runPullDistance.Checked && target.TargetID != PlayerInfo.ServerID && target.TargetID != 0)
                TargetDist(1, (int)target.TargetID);

            if (target.ClaimID == 0 && target.HealthPercent != 0 && target.TargetID > 0 &&
                target.Distance <= (float)targetSearchDist.Value && pullCommand.Text != "" &&
                target.Distance > 5)
            {
                var nullCount = 0;
                while (Math.Truncate(target.Distance) <= Math.Truncate((float)targetSearchDist.Value) &&
                       target.ClaimID == 0)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(0.5));
                    WindowInfo.SendText(pullCommand.Text);

                    var delay = DateTime.Now.AddSeconds((double)pullDelay.Value);
                    while (DateTime.Now < delay)
                    {
                        TargetInfo.FaceTarget(TargetInfo.X, TargetInfo.Z);
                        Thread.Sleep(TimeSpan.FromSeconds(0.1));

                        if (target.Distance > (float)targetSearchDist.Value &&
                            target.ClaimID == PlayerInfo.ServerID)
                            break;
                    }
                    nullCount = nullCount + 1;

                    if (nullCount >= 3)
                    {
                        ignoreTarget.Add(TargetInfo.ID);
                        break;
                    }

                    Thread.Sleep(TimeSpan.FromSeconds(0.5));
                }
            }
            else if (target.ClaimID == 0 && target.HealthPercent != 0 && target.TargetID > 0 &&
                     target.Distance <= (float)targetSearchDist.Value && pullCommand.Text == "")
            {
                if (runTarget.Checked && target.TargetID != PlayerInfo.ServerID && target.TargetID != 0)
                    TargetDist(2, (int)target.TargetID);

                TargetInfo.Attack();

                return;
            }
            else if (target.Distance <= 5)
            {
                TargetInfo.Attack();
                return;
            }

            Thread.Sleep(TimeSpan.FromSeconds(0.5));

            if (runTarget.Checked && target.TargetID != PlayerInfo.ServerID && target.TargetID != 0)
                TargetDist(2, (int)target.TargetID);

            if (PlayerInfo.Status == 0 && target.ClaimID == PlayerInfo.ServerID &&
                !ignoreTarget.Contains(TargetInfo.ID))
            {
                TargetInfo.Attack();
            }

            if (PlayerInfo.Status == 0 && target.ClaimID != api.Player.ServerId)
            {
                SetTarget(0);

                if (usenav.Checked && selectedNavi.Text != "" && !naviMove)
                    naviMove = true;
            }
        }
        #endregion
        #endregion
        #region Methods: NAV
        public int FindClosestWayPoint()
        {
            var maxRange = 50.0;
            var outRange = -1;
            for (int i = 0; i < navPathX.Count(); i++)
            {
                var x = Math.Pow(PlayerInfo.X - navPathX[i], 2.0);
                var z = Math.Pow(PlayerInfo.Z - navPathZ[i], 2.0);
                var y = Math.Pow(PlayerInfo.Y - navPathY[i], 2.0);
                var dist = (navPathY[i] == 0 ? Math.Sqrt(x + z) : Math.Sqrt(x + z + y));
                if (dist < maxRange)
                {
                    maxRange = dist;
                    outRange = i;
                }
            }

            return outRange;
        }
        public void CheckDoor(int navid)
        {
            var items = navPathdoor[navid].Split(';');
            if (lastcommandtarget != items[1])
            {
                api.AutoFollow.IsAutoFollowing = false;
                OpenDoor = true;
                TargetInfo.SetTarget(int.Parse(items[1]));
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                api.ThirdParty.SendString("/lockon <t>");
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                while (TargetInfo.Distance > 4)
                {
                    api.ThirdParty.KeyDown(API.Keys.NUMPAD8);
                    Thread.Sleep(TimeSpan.FromSeconds(0.1));
                }

                api.ThirdParty.KeyUp(API.Keys.NUMPAD8);
                while (TargetInfo.ID == int.Parse(items[1]))
                {
                    api.ThirdParty.KeyPress(API.Keys.NUMPADENTER);
                    Thread.Sleep(TimeSpan.FromSeconds(0.5));
                }
                lastcommandtarget = items[1];
                OpenDoor = false;
            }
        }
        public void FollowTarget()
        {
            if (!botRunning || !followplayer.Checked || followName.Text == "")
                return;
            var followID = TargetInfo.GetTargetIdByName(followName.Text);
            if (followID == -1)
                return;
            var followed = api.Entity.GetEntity(Convert.ToInt32(followID));
            if (followed.Status == 0 && PlayerInfo.Status == 0)
            {
                if (TargetInfo.ID != followID)
                {
                    api.Target.SetTarget(Convert.ToInt32(0));
                    Thread.Sleep(TimeSpan.FromSeconds(0.5));
                    api.Target.SetTarget(Convert.ToInt32(followID));
                    Thread.Sleep(TimeSpan.FromSeconds(0.5));
                }

                if (AutoLock.Checked && !TargetInfo.LockedOn)
                    api.ThirdParty.SendString("/lockon <t>");
                
                isMoving = true;
                while (Math.Truncate(TargetInfo.Distance) >= (float)followDist.Value)
                {
                    api.AutoFollow.SetAutoFollowCoords(TargetInfo.X - PlayerInfo.X,
                                                       TargetInfo.Y - PlayerInfo.Y,
                                                       TargetInfo.Z - PlayerInfo.Z);

                    api.AutoFollow.IsAutoFollowing = true;

                    Thread.Sleep(TimeSpan.FromSeconds(0.1));
                }
                api.AutoFollow.IsAutoFollowing = false;
                isMoving = false;
            }
        }
        public void TargetDist(int ID, int TargetID)
        {
            if (TargetID == 0)
                return;

            var entity = api.Entity.GetEntity(TargetID);
            var search = 0;

            if (runPullDistance.Checked && ID == 1 && TargetInfo.ID > 0)
            {
                isMoving = true;
                while (Math.Truncate(entity.Distance) >= (float)numericUpDown21.Value && entity.ClaimID == 0)
                {
                    api.AutoFollow.SetAutoFollowCoords(TargetInfo.X - PlayerInfo.X,
                                                       TargetInfo.Y - PlayerInfo.Y,
                                                       TargetInfo.Z - PlayerInfo.Z);

                    api.AutoFollow.IsAutoFollowing = true;
                    Thread.Sleep(TimeSpan.FromSeconds(0.1));

                    if (TargetInfo.ID == 0 || TargetInfo.ID == PlayerInfo.ServerID)
                        break;

                    if (Math.Abs(entity.Distance - search) < 1)
                    {
                        api.AutoFollow.IsAutoFollowing = false;
                        isMoving = false;
                    }
                }
                api.AutoFollow.IsAutoFollowing = false;
                isMoving = false;
            }
            else if (runTarget.Checked && ID == 2 && TargetInfo.ID > 0)
            {
                var dist = Math.Round(api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).Distance, 1);
                var last = Math.Round(api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).Distance, 1);

                var move = true;
                var time = 15;

                isMoving = true;
                while (Math.Truncate(entity.Distance) >= (float)KeepTargetRange.Value && entity.ClaimID == 0)
                {
                    api.AutoFollow.SetAutoFollowCoords(TargetInfo.X - PlayerInfo.X,
                                                       TargetInfo.Y - PlayerInfo.Y,
                                                       TargetInfo.Z - PlayerInfo.Z);

                    api.AutoFollow.IsAutoFollowing = true;
                    Thread.Sleep(TimeSpan.FromSeconds(0.1));

                    if (TargetInfo.ID == 0 || TargetInfo.ID == PlayerInfo.ServerID)
                        break;

                    dist = Math.Round(api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).Distance, 1);

                    if (Math.Abs(last - dist) < 0.1)
                    {
                        if (move)
                        {
                            move = false;

                            if (time != 15)
                                time = time + 10;

                            for (var x = 0; x < 15; x++)
                            {
                                WindowInfo.KeyPress(API.Keys.NUMPAD2);
                                x++;
                            }
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            for (var x = 0; x < time; x++)
                            {
                                WindowInfo.KeyPress(API.Keys.NUMPAD6);
                                x++;
                            }
                        }
                        else if (!move)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));

                            move = true;
                            if (time == 15)
                                time = time + 10;
                            else
                                time = time + 10;

                            for (var x = 0; x < 15; x++)
                            {
                                WindowInfo.KeyPress(API.Keys.NUMPAD2);
                                x++;
                            }
                            Thread.Sleep(TimeSpan.FromSeconds(1.0));
                            for (var x = 0; x < time; x++)
                            {
                                WindowInfo.KeyPress(API.Keys.NUMPAD4);
                                x++;
                            }
                        }
                        Thread.Sleep(TimeSpan.FromSeconds(1.0));
                    }
                    last = Math.Round(api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).Distance, 1);
                }
                api.AutoFollow.IsAutoFollowing = false;
                isMoving = false;
            }

            if (api.AutoFollow.IsAutoFollowing)
                api.AutoFollow.IsAutoFollowing = false;
        }
        public bool isStuck(bool a = false)
        {
            if (a && (TargetInfo.ID <= 0 || TargetInfo.HPP == 0))
                return false;
            var FirstX = PlayerInfo.X;
            var FirstZ = PlayerInfo.Z;
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
            var Dchange = (Math.Pow(FirstX - PlayerInfo.X, 2) + Math.Pow(FirstZ - PlayerInfo.Z, 2));
            if (Math.Abs(Dchange) < (double)StuckDistance.Value)
                    return true;

            return false;
        }
        public void ReturnIdleLocation()
        {
            var dist = Math.Truncate(Math.Sqrt((idleX - PlayerInfo.X) + (idleZ - PlayerInfo.Z) + (idleY - PlayerInfo.Y)));

            if (IdleLocation.Checked && dist > 1 && PlayerInfo.Status == 0)
            {
                while (dist > (double)IdleLocationDist.Value && PlayerInfo.Status == 0)
                {
                    dist = Math.Truncate(Math.Sqrt((idleX - PlayerInfo.X) + (idleZ - PlayerInfo.Z) + (idleY - PlayerInfo.Y)));

                    api.AutoFollow.SetAutoFollowCoords(idleX - PlayerInfo.X,
                                                       idleY - PlayerInfo.Y,
                                                       idleZ - PlayerInfo.Z);

                    api.AutoFollow.IsAutoFollowing = true;
                    Thread.Sleep(TimeSpan.FromSeconds(0.1));
                }
                if (api.AutoFollow.IsAutoFollowing)
                    api.AutoFollow.IsAutoFollowing = false;
            }
        }
        public void OpenNavi(string path)
        {
            var file = new FileInfo(path);
            var ipos = 0;

            using (var sr = file.OpenText())
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var items = line.Split(':');
                    if (items[0] == "WAYPOINT")
                    {
                        Array.Resize(ref navPathX, ipos + 1);
                        Array.Resize(ref navPathZ, ipos + 1);
                        Array.Resize(ref navPathY, ipos + 1);
                        Array.Resize(ref navPathfirst, ipos + 1);
                        Array.Resize(ref navPathdoor, ipos + 1);
                        Array.Resize(ref navPathpause, ipos + 1);
                        //Array.Resize(ref navPathForceHeal, ipos + 1);
                        navPathX[ipos] = double.Parse(items[1]);
                        navPathZ[ipos] = double.Parse(items[2]);
                        navPathY[ipos] = ((items.Length == 3) ? 0 : double.Parse(items[3]));
                        navPathfirst[ipos] = false;
                        navPathdoor[ipos] = "";
                        navPathpause[ipos] = "";
                        //navPathdoor[ipos] = 0;
                        //navPathpause[ipos] = 0;
                        //navPathForceHeal = false;
                        if (items.Length > 4)
                        {
                            for (int i = 4; i <= (items.Length - 1); i++)
                            {
                                if (items[i] == "First")
                                    navPathfirst[ipos] = true;
                                if (items[i].Contains("Door"))
                                    navPathdoor[ipos] = items[i];
                                if (items[i].Contains("Pause"))
                                    navPathpause[ipos] = items[i];
                                //if (items[i] == "Heal")
                                //    navPathForceHeal[ipos] = true;
                                //if (items[i].Contains("Door"))
                                //    navPathdoor[ipos] = int.Parse(items[i].Split(':')[1]);
                                //if (items[i].Contains("Pause"))
                                //    navPathpause[ipos] = double.Parse(items[i].Split(':')[1]);
                            }
                        }

                        ipos++;
                    }
                }
            }
        }
        private void RefreshToolStripMenuItemClick(object sender, EventArgs e)
        {
            updatenav();
        }
        private void updatenav()
        {
            selectedNavi.Items.Clear();
            var path = string.Format("{0}\\Nav\\", Application.StartupPath);
            foreach (var file in Directory.GetFiles(path, "*.xin"))
            {
                if (!selectedNavi.Items.Contains(new FileInfo(file).Name)) selectedNavi.Items.Add(new FileInfo(file).Name);
            }
        }
        private void SelectedNaviSelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedNavi.Text == "") return;
            if (selectedNavi.Text.Contains("Linear")) Linear.Checked = true;
            else if (selectedNavi.Text.Contains("Circular")) Circular.Checked = true;
            var path = string.Format("{0}\\Nav\\", Application.StartupPath);
            var navi = new FileInfo(path + selectedNavi.Text);

            if (navi.Exists)
            {
                OpenNavi(navi.ToString());
            }
        }
        private void RecordIdleLocation_Click(object sender, EventArgs e)
        {
            idleX = PlayerInfo.X;
            idleY = PlayerInfo.Y;
            idleZ = PlayerInfo.Z;
            RecordIdleLocation.Text = $"X:{idleX.ToString("00.###")}/Y:{idleY.ToString("00.###")}/Z:{idleZ.ToString("00.###")}";
        }
        #endregion
        #region Methods: Command Interface
        public void commandInterface()
        {
            string cmd1 = api.ThirdParty.ConsoleGetArg(1).ToLower();
            if (cmd1 == "start")
                startScriptToolStripMenuItem.PerformClick();
            else if (cmd1 == "stop")
                stopScriptToolStripMenuItem.PerformClick();
            else if (cmd1 == "toggle")
            {
                string cmd2 = api.ThirdParty.ConsoleGetArg(2).ToLower();
                if (cmd2 == "farmbot")
                {
                    if (botRunning)
                        stopScriptToolStripMenuItem.PerformClick();
                    else
                        startScriptToolStripMenuItem.PerformClick();
                }
                else if (cmd2 == "eventbot")
                {
                    if (ScriptOnEventTool.botRunning)
                        MainWindow.oneventbot.stopScriptToolStripMenuItem.PerformClick();
                    else
                        MainWindow.oneventbot.startScriptToolStripMenuItem.PerformClick();
                }
                else if (cmd2 == "hud")
                {
                    showHUD.Checked = !showHUD.Checked;
                }
            }
            else if (cmd1 == "set")
            {
                string cmd2 = api.ThirdParty.ConsoleGetArg(2).ToLower();
                //if (cmd2 == "weaponskill" || cmd2 == "ws")
                if (cmd2 == "hudxy")
                {
                    hudX.Value = decimal.Parse(api.ThirdParty.ConsoleGetArg(3));
                    hudY.Value = decimal.Parse(api.ThirdParty.ConsoleGetArg(4));
                }
            }
            else if (cmd1 == "extravariables")
            {
                    var sstr = api.ThirdParty.ConsoleGetArg(2).Split(':');
                    if (sstr[0] == "INDI")
                        IntToIndiStat(int.Parse(sstr[1]));
                /* foreach (string str in api.ThirdParty.ConsoleGetArg(2).Split(';'))
                {
                } */
            }
        }
        private Button hudinfobutton;
        private Panel panel2;
        private Label label40;
        public CheckBox autoengageAvatar;
        public NumericUpDown IdleLocationDist;
        #endregion

        #region Methods: EliteMMO
        #region class: PlayerInfo
        public static class PlayerInfo
        {
            public static int Status => (int)api.Entity.GetLocalPlayer().Status;
            public static string Name => api.Party.GetPartyMembers().First().Name;
            public static int HPP => api.Party.GetPartyMembers().First().CurrentHPP;
            public static int MPP => api.Party.GetPartyMembers().First().CurrentMPP;
            public static uint HP => api.Party.GetPartyMembers().First().CurrentHP;
            public static uint MP => api.Party.GetPartyMembers().First().CurrentMP;
            public static uint MaxHP => api.Player.HPMax;
            public static uint MaxMP => api.Player.MPMax;
            public static int TP => (int)api.Party.GetPartyMembers().First().CurrentTP;
            public static int MainJob => api.Player.GetPlayerInfo().MainJob;
            public static int MainJobLevel => api.Player.GetPlayerInfo().MainJobLevel;
            public static int SubJob => api.Player.GetPlayerInfo().SubJob;
            public static int SubJobLevel => api.Player.GetPlayerInfo().SubJobLevel;
            public static bool HasBuff(short id) => api.Player.GetPlayerInfo().Buffs.Any(b => b == id);
            public static int HasBuffcount(short id) => api.Player.GetPlayerInfo().Buffs.Where(b => b == id).Count();
            public static bool HasAbility(uint id) => api.Player.HasAbility(id);
            public static bool HasSpell(uint id) => api.Player.HasSpell(id);
            public static bool HasBlueMagicSpellSet(int id) => api.Player.HasBlueMagicSpellSet(id);
            public static bool HasWeaponSkill(uint id) => api.Player.HasWeaponSkill(id);
            public static int ServerID => (int)api.Entity.GetLocalPlayer().ServerID;
            public static int TargetID => (int)api.Entity.GetLocalPlayer().TargetID;
            public static float X => api.Entity.GetLocalPlayer().X;
            public static float Y => api.Entity.GetLocalPlayer().Y;
            public static float Z => api.Entity.GetLocalPlayer().Z;
            public static float H => api.Entity.GetLocalPlayer().H;
            public static bool HasKeyItem(uint id) => api.Player.HasKeyItem(id);
            public static int MeritPoints => api.Player.GetPlayerInfo().MeritPoints;
            public static int UsedJobPoints => api.Player.GetJobPoints(MainJob).SpentJobPoints;
            public static int UseableJobPoints => api.Player.GetJobPoints(MainJob).JobPoints;
            public static int CapacityPoints => api.Player.GetJobPoints(MainJob).CapacityPoints;
            public static double GetAngleFrom(double x, double z)
            {
                var angleInDegrees = (Math.Atan2(PlayerInfo.Z - z,
                    PlayerInfo.X - x) * 180 / Math.PI) * -1;
                return (Math.Floor(angleInDegrees * (10 ^ 0) + 0.5) / (10 ^ 0));
            }
            public static bool DynaZone()
            {
                List<int> DynaZones = new List<int>(new int[] {39,40,41,42,134,135,185,186,187,188});
                if (DynaZones.Contains(api.Player.ZoneId)) return true;
                else return false;
            }
            public static string DynaTime()
            {
                string vtz = "Morning";
                uint vanahour = api.VanaTime.CurrentHour;
                if (vanahour >= 0 && vanahour < 8) vtz = "Morning";
                else if (vanahour >= 8 && vanahour < 16) vtz = "Noon";
                else if (vanahour >= 16 && vanahour < 24) vtz = "Night";
                return vtz;
            }
            public static bool DynaStrike(string typ, string time, string target)
            {
                if (!PlayerInfo.DynaZone()) return true;
                if (target == "Nightmare Taurus") return true;
                else if (NoProcDynaMobs.Contains(target)) return NoneProc;
                else if (DynaMobProc[time][typ].Contains(target)) return true;
                return false;
            }
            public static int GetFinishingMoves()
            {
                var retVal = 0;
                if (PlayerInfo.HasBuff(381)) { retVal = 1; }
                else if (PlayerInfo.HasBuff(382)) { retVal = 2; }
                else if (PlayerInfo.HasBuff(383)) { retVal = 3; }
                else if (PlayerInfo.HasBuff(384)) { retVal = 4; }
                else if (PlayerInfo.HasBuff(385)) { retVal = 5; }
                else if (PlayerInfo.HasBuff(588)) { retVal = 6; }
                return retVal;
            }
        }
        #endregion
        #region class: TargetInfo
        public static class TargetInfo
        {
            public static void Attack()
            {
                var count = 0;

                while (PlayerInfo.Status == 0)
                {
                    WindowInfo.SendText("/attack <t>");
                    Thread.Sleep(TimeSpan.FromSeconds(3.0));

                    if (PlayerInfo.Status == 1 || count == 2)
                        break;

                    count = count + 1;
                    Thread.Sleep(TimeSpan.FromSeconds(1.0));
                }
            }
            public static string Name => api.Entity.GetEntity((int) api.Target.GetTargetInfo().TargetIndex).Name;
            public static int ID => (int) api.Entity.GetEntity((int) api.Target.GetTargetInfo().TargetIndex).TargetID;
            public static int HPP => api.Entity.GetEntity((int) api.Target.GetTargetInfo().TargetIndex).HealthPercent;
            public static double Distance => Math.Truncate((10 * api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).Distance) / 10);
            public static bool LockedOn => api.Target.GetTargetInfo().LockedOn;
            public static float X => api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).X;
            public static float Y => api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).Y;
            public static float Z => api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).Z;
            public static float H => api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).H;
            public static void SetTarget(int ID) => api.Target.SetTarget(ID);
            public static int GetTargetIdByName(string name)
            {
                for (var x = 0; x < 2048; x++)
                {
                    var ID = api.Entity.GetEntity(x);

                    if (ID.Name != null && ID.Name.ToLower().Equals(name.ToLower()))
                        return (int) ID.TargetID;
                }
                return -1;
            }
            public static int GetTargetIndexByName(string name)
            {
                for (var x = 0; x < 2048; x++)
                {
                    var ID = api.Entity.GetEntity(x);

                    if (ID.Name != null && ID.Name.ToLower().Equals(name.ToLower()))
                        return (int)ID.ServerID;
                }
                return -1;
            }
            public static void FaceTarget(float x, float z)
            {
                if (TargetInfo.ID == PlayerInfo.ServerID || TargetInfo.ID == 0)
                    return;

                var p = api.Entity.GetLocalPlayer();
                var angle = (byte)(Math.Atan((z - p.Z) / (x - p.X)) * -(128.0f / Math.PI));

                if (p.X > x)
                    angle += 128;

                var radian = (((float)angle) / 255) * 2 * Math.PI;
                api.Entity.SetEntityHPosition(api.Entity.LocalPlayerIndex, (float)radian);
            }
            public static bool IsFacingTarget(float x1, float z1, float h1, float x2, float z2)
            {
                var angle = GetDifferenceAngle(x1, z1, x2, z2);
                var rotation = ((h1 / (2 * 3.14159265359f)) * 255);
                return Math.Abs((angle - rotation) + -128.0f) < 20;
            }
            private static float GetDifferenceAngle(float x1, float z1, float x2, float z2)
            {
                var angle = Math.Atan((z2 - z1) / (x2 - x1));
                angle *= -(128.0f / 3.14159265359f);
                return (float) (x2 > x1 ? angle + 128 : angle);
            }
        }
        #endregion
        #region class: RecastInfo
        public static class Recast
        {
            public static int GetSpellRecast(int id) => api.Recast.GetSpellRecast(id);
            public static int GetAbilityRecast(int id)
            {
                var IDs = api.Recast.GetAbilityIds();
                for (var x = 0; x < IDs.Count; x++)
                {
                    if (IDs[x] == id)
                        return api.Recast.GetAbilityRecast(x);
                }
                return 0;
            }
        }
        #endregion
        #region class: WindowInfo
        public static class WindowInfo
        {
            public static void SendText(string text) => api.ThirdParty.SendString(text);
            public static void KeyPress(API.Keys key) => api.ThirdParty.KeyPress(key);
            public static void KeyUp(API.Keys key) => api.ThirdParty.KeyUp(key);
            public static void KeyDown(API.Keys key) => api.ThirdParty.KeyDown(key);
        }
        #endregion
        #region class: PartyInfo
        public static class PartyInfo
        {
            public static int Count(int PartyNumber = 0)
            {
                var allience = api.Party.GetAllianceInfo();
                var pc = 0;
                if (PartyNumber == 1 || PartyNumber == 0)
                    pc = pc + allience.Party0Count;
                if (PartyNumber == 2 || PartyNumber == 0)
                    pc = pc + allience.Party1Count;
                if (PartyNumber == 3 || PartyNumber == 0)
                    pc = pc + allience.Party2Count;
                return pc;
            }
            public static bool ContainsName(string name)
            {
                foreach (var member in api.Party.GetPartyMembers().Where(p => p.Active != 0).ToList())
                {
                    if (Regex.Replace(member.Name, "([A-Z])", " $1", RegexOptions.Compiled).Trim() == name)
                        return true;
                }
                return false;
            }
            public static bool ContainsID(uint ID)
            {
                foreach (var member in api.Party.GetPartyMembers().Where(p => p.Active != 0).ToList())
                {
                    if (member.ID == ID)
                        return true;
                }
                return false;
            }
            public static int averageHPP()
            {
                int hpp = 0;
                var members = api.Party.GetPartyMembers().Where(p => p.Active != 0).ToList();
                foreach (var member in members)
                {
                    if (member.Active != 0)
                        hpp = (hpp + member.CurrentHPP);
                }
                return (int)Math.Round((double)(hpp / members.Count));
            }
        }
        #endregion
        #region class: PetInfo
        public static class PetInfo
        {
            public static string Name
            {
                get
                {
                    var p = api.Entity.GetEntity(api.Entity.GetLocalPlayer().PetIndex).Name;

                    return p != null
                        ? Regex.Replace(api.Entity.GetEntity(api.Entity.GetLocalPlayer().PetIndex).Name, "([A-Z])", " $1",
                            RegexOptions.Compiled).Trim() : null;
                }
            }
            public static int ID => (int)api.Entity.GetEntity(api.Entity.GetLocalPlayer().PetIndex).ServerID;
            public static int HPP => api.Entity.GetEntity(api.Entity.GetLocalPlayer().PetIndex).HealthPercent;
            public static int MPP => api.Entity.GetEntity(api.Entity.GetLocalPlayer().PetIndex).ManaPercent;
            public static int TPP => (int) api.Player.PetTP;
            public static int Status => (int) api.Entity.GetEntity(api.Entity.GetLocalPlayer().PetIndex).Status;
        }
        #endregion
        #region class: Inventory
        public static class Inventory
        {
            public static int ItemQuantityByName(string name)
            {
                var count = api.Inventory.GetContainerCount(0);
                var itemc = 0;

                for (var x = 0; x < count; x++)
                {
                    var item = api.Inventory.GetContainerItem(0, x);
                    if (item.Id != 0 && api.Resources.GetItem(item.Id).Name[0] == name)
                    {
                        itemc = itemc + (int)item.Count;
                    }
                }
                return itemc;
            }
        }
        #endregion
        #endregion
    }
}
