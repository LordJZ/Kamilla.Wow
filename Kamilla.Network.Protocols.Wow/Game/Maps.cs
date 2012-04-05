
namespace Kamilla.Network.Protocols.Wow.Game
{
    [LocalizedNameContainer(typeof(MapsNames))]
    public enum Maps : uint
    {
        NoMap = uint.MaxValue,

        /// <summary>
        /// Eastern Kingdoms
        /// </summary>
        [LocalizedName("Map0")]
        Azeroth = 0,
        /// <summary>
        /// Kalimdor
        /// </summary>
        [LocalizedName("Map1")]
        Kalimdor = 1,
        /// <summary>
        /// Testing
        /// </summary>
        [LocalizedName("Map13")]
        test = 13,
        /// <summary>
        /// Scott Test
        /// </summary>
        [LocalizedName("Map25")]
        ScottTest = 25,
        /// <summary>
        /// Alterac Valley
        /// </summary>
        [LocalizedName("Map30")]
        PVPZone01 = 30,
        /// <summary>
        /// Shadowfang Keep
        /// </summary>
        [LocalizedName("Map33")]
        Shadowfang = 33,
        /// <summary>
        /// Stormwind Stockade
        /// </summary>
        [LocalizedName("Map34")]
        StormwindJail = 34,
        /// <summary>
        /// <unused>StormwindPrison
        /// </summary>
        [LocalizedName("Map35")]
        StormwindPrison = 35,
        /// <summary>
        /// Deadmines
        /// </summary>
        [LocalizedName("Map36")]
        DeadminesInstance = 36,
        /// <summary>
        /// Azshara Crater
        /// </summary>
        [LocalizedName("Map37")]
        PVPZone02 = 37,
        /// <summary>
        /// Collin's Test
        /// </summary>
        [LocalizedName("Map42")]
        Collin = 42,
        /// <summary>
        /// Wailing Caverns
        /// </summary>
        [LocalizedName("Map43")]
        WailingCaverns = 43,
        /// <summary>
        /// <unused> Monastery
        /// </summary>
        [LocalizedName("Map44")]
        Monastery = 44,
        /// <summary>
        /// Razorfen Kraul
        /// </summary>
        [LocalizedName("Map47")]
        RazorfenKraulInstance = 47,
        /// <summary>
        /// Blackfathom Deeps
        /// </summary>
        [LocalizedName("Map48")]
        Blackfathom = 48,
        /// <summary>
        /// Uldaman
        /// </summary>
        [LocalizedName("Map70")]
        Uldaman = 70,
        /// <summary>
        /// Gnomeregan
        /// </summary>
        [LocalizedName("Map90")]
        GnomeragonInstance = 90,
        /// <summary>
        /// Sunken Temple
        /// </summary>
        [LocalizedName("Map109")]
        SunkenTemple = 109,
        /// <summary>
        /// Razorfen Downs
        /// </summary>
        [LocalizedName("Map129")]
        RazorfenDowns = 129,
        /// <summary>
        /// Emerald Dream
        /// </summary>
        [LocalizedName("Map169")]
        EmeraldDream = 169,
        /// <summary>
        /// Scarlet Monastery
        /// </summary>
        [LocalizedName("Map189")]
        MonasteryInstances = 189,
        /// <summary>
        /// Zul'Farrak
        /// </summary>
        [LocalizedName("Map209")]
        TanarisInstance = 209,
        /// <summary>
        /// Blackrock Spire
        /// </summary>
        [LocalizedName("Map229")]
        BlackRockSpire = 229,
        /// <summary>
        /// Blackrock Depths
        /// </summary>
        [LocalizedName("Map230")]
        BlackrockDepths = 230,
        /// <summary>
        /// Onyxia's Lair
        /// </summary>
        [LocalizedName("Map249")]
        OnyxiaLairInstance = 249,
        /// <summary>
        /// Opening of the Dark Portal
        /// </summary>
        [LocalizedName("Map269")]
        CavernsOfTime = 269,
        /// <summary>
        /// Scholomance
        /// </summary>
        [LocalizedName("Map289")]
        SchoolofNecromancy = 289,
        /// <summary>
        /// Ancient Zul'Gurub
        /// </summary>
        [LocalizedName("Map309")]
        Zulgurub = 309,
        /// <summary>
        /// Stratholme
        /// </summary>
        [LocalizedName("Map329")]
        Stratholme = 329,
        /// <summary>
        /// Maraudon
        /// </summary>
        [LocalizedName("Map349")]
        Mauradon = 349,
        /// <summary>
        /// Deeprun Tram
        /// </summary>
        [LocalizedName("Map369")]
        DeeprunTram = 369,
        /// <summary>
        /// Ragefire Chasm
        /// </summary>
        [LocalizedName("Map389")]
        OrgrimmarInstance = 389,
        /// <summary>
        /// Molten Core
        /// </summary>
        [LocalizedName("Map409")]
        MoltenCore = 409,
        /// <summary>
        /// Dire Maul
        /// </summary>
        [LocalizedName("Map429")]
        DireMaul = 429,
        /// <summary>
        /// Alliance PVP Barracks
        /// </summary>
        [LocalizedName("Map449")]
        AlliancePVPBarracks = 449,
        /// <summary>
        /// Horde PVP Barracks
        /// </summary>
        [LocalizedName("Map450")]
        HordePVPBarracks = 450,
        /// <summary>
        /// Development Land
        /// </summary>
        [LocalizedName("Map451")]
        development = 451,
        /// <summary>
        /// Blackwing Lair
        /// </summary>
        [LocalizedName("Map469")]
        BlackwingLair = 469,
        /// <summary>
        /// Warsong Gulch
        /// </summary>
        [LocalizedName("Map489")]
        PVPZone03 = 489,
        /// <summary>
        /// Ruins of Ahn'Qiraj
        /// </summary>
        [LocalizedName("Map509")]
        AhnQiraj = 509,
        /// <summary>
        /// Arathi Basin
        /// </summary>
        [LocalizedName("Map529")]
        PVPZone04 = 529,
        /// <summary>
        /// Outland
        /// </summary>
        [LocalizedName("Map530")]
        Expansion01 = 530,
        /// <summary>
        /// Ahn'Qiraj Temple
        /// </summary>
        [LocalizedName("Map531")]
        AhnQirajTemple = 531,
        /// <summary>
        /// Karazhan
        /// </summary>
        [LocalizedName("Map532")]
        Karazahn = 532,
        /// <summary>
        /// Naxxramas
        /// </summary>
        [LocalizedName("Map533")]
        Stratholme_Raid = 533,
        /// <summary>
        /// The Battle for Mount Hyjal
        /// </summary>
        [LocalizedName("Map534")]
        HyjalPast = 534,
        /// <summary>
        /// Hellfire Citadel: The Shattered Halls
        /// </summary>
        [LocalizedName("Map540")]
        HellfireMilitary = 540,
        /// <summary>
        /// Hellfire Citadel: The Blood Furnace
        /// </summary>
        [LocalizedName("Map542")]
        HellfireDemon = 542,
        /// <summary>
        /// Hellfire Citadel: Ramparts
        /// </summary>
        [LocalizedName("Map543")]
        HellfireRampart = 543,
        /// <summary>
        /// Magtheridon's Lair
        /// </summary>
        [LocalizedName("Map544")]
        HellfireRaid = 544,
        /// <summary>
        /// Coilfang: The Steamvault
        /// </summary>
        [LocalizedName("Map545")]
        CoilfangPumping = 545,
        /// <summary>
        /// Coilfang: The Underbog
        /// </summary>
        [LocalizedName("Map546")]
        CoilfangMarsh = 546,
        /// <summary>
        /// Coilfang: The Slave Pens
        /// </summary>
        [LocalizedName("Map547")]
        CoilfangDraenei = 547,
        /// <summary>
        /// Coilfang: Serpentshrine Cavern
        /// </summary>
        [LocalizedName("Map548")]
        CoilfangRaid = 548,
        /// <summary>
        /// Tempest Keep
        /// </summary>
        [LocalizedName("Map550")]
        TempestKeepRaid = 550,
        /// <summary>
        /// Tempest Keep: The Arcatraz
        /// </summary>
        [LocalizedName("Map552")]
        TempestKeepArcane = 552,
        /// <summary>
        /// Tempest Keep: The Botanica
        /// </summary>
        [LocalizedName("Map553")]
        TempestKeepAtrium = 553,
        /// <summary>
        /// Tempest Keep: The Mechanar
        /// </summary>
        [LocalizedName("Map554")]
        TempestKeepFactory = 554,
        /// <summary>
        /// Auchindoun: Shadow Labyrinth
        /// </summary>
        [LocalizedName("Map555")]
        AuchindounShadow = 555,
        /// <summary>
        /// Auchindoun: Sethekk Halls
        /// </summary>
        [LocalizedName("Map556")]
        AuchindounDemon = 556,
        /// <summary>
        /// Auchindoun: Mana-Tombs
        /// </summary>
        [LocalizedName("Map557")]
        AuchindounEthereal = 557,
        /// <summary>
        /// Auchindoun: Auchenai Crypts
        /// </summary>
        [LocalizedName("Map558")]
        AuchindounDraenei = 558,
        /// <summary>
        /// Nagrand Arena
        /// </summary>
        [LocalizedName("Map559")]
        PVPZone05 = 559,
        /// <summary>
        /// The Escape From Durnholde
        /// </summary>
        [LocalizedName("Map560")]
        HillsbradPast = 560,
        /// <summary>
        /// Blade's Edge Arena
        /// </summary>
        [LocalizedName("Map562")]
        bladesedgearena = 562,
        /// <summary>
        /// Black Temple
        /// </summary>
        [LocalizedName("Map564")]
        BlackTemple = 564,
        /// <summary>
        /// Gruul's Lair
        /// </summary>
        [LocalizedName("Map565")]
        GruulsLair = 565,
        /// <summary>
        /// Eye of the Storm
        /// </summary>
        [LocalizedName("Map566")]
        NetherstormBG = 566,
        /// <summary>
        /// Zul'Aman
        /// </summary>
        [LocalizedName("Map568")]
        ZulAman = 568,
        /// <summary>
        /// Northrend
        /// </summary>
        [LocalizedName("Map571")]
        Northrend = 571,
        /// <summary>
        /// Ruins of Lordaeron
        /// </summary>
        [LocalizedName("Map572")]
        PVPLordaeron = 572,
        /// <summary>
        /// ExteriorTest
        /// </summary>
        [LocalizedName("Map573")]
        ExteriorTest = 573,
        /// <summary>
        /// Utgarde Keep
        /// </summary>
        [LocalizedName("Map574")]
        Valgarde70 = 574,
        /// <summary>
        /// Utgarde Pinnacle
        /// </summary>
        [LocalizedName("Map575")]
        UtgardePinnacle = 575,
        /// <summary>
        /// The Nexus
        /// </summary>
        [LocalizedName("Map576")]
        Nexus70 = 576,
        /// <summary>
        /// The Oculus
        /// </summary>
        [LocalizedName("Map578")]
        Nexus80 = 578,
        /// <summary>
        /// The Sunwell
        /// </summary>
        [LocalizedName("Map580")]
        SunwellPlateau = 580,
        /// <summary>
        /// Transport: Rut'theran to Auberdine
        /// </summary>
        [LocalizedName("Map582")]
        Transport176244 = 582,
        /// <summary>
        /// Transport: Menethil to Theramore
        /// </summary>
        [LocalizedName("Map584")]
        Transport176231 = 584,
        /// <summary>
        /// Magister's Terrace
        /// </summary>
        [LocalizedName("Map585")]
        Sunwell5ManFix = 585,
        /// <summary>
        /// Transport: Exodar to Auberdine
        /// </summary>
        [LocalizedName("Map586")]
        Transport181645 = 586,
        /// <summary>
        /// Transport: Feathermoon Ferry
        /// </summary>
        [LocalizedName("Map587")]
        Transport177233 = 587,
        /// <summary>
        /// Transport: Menethil to Auberdine
        /// </summary>
        [LocalizedName("Map588")]
        Transport176310 = 588,
        /// <summary>
        /// Transport: Orgrimmar to Grom'Gol
        /// </summary>
        [LocalizedName("Map589")]
        Transport175080 = 589,
        /// <summary>
        /// Transport: Grom'Gol to Undercity
        /// </summary>
        [LocalizedName("Map590")]
        Transport176495 = 590,
        /// <summary>
        /// Transport: Undercity to Orgrimmar
        /// </summary>
        [LocalizedName("Map591")]
        Transport164871 = 591,
        /// <summary>
        /// Transport: Borean Tundra Test
        /// </summary>
        [LocalizedName("Map592")]
        Transport186238 = 592,
        /// <summary>
        /// Transport: Booty Bay to Ratchet
        /// </summary>
        [LocalizedName("Map593")]
        Transport20808 = 593,
        /// <summary>
        /// Transport: Howling Fjord Sister Mercy (Quest)
        /// </summary>
        [LocalizedName("Map594")]
        Transport187038 = 594,
        /// <summary>
        /// The Culling of Stratholme
        /// </summary>
        [LocalizedName("Map595")]
        StratholmeCOT = 595,
        /// <summary>
        /// Transport: Naglfar
        /// </summary>
        [LocalizedName("Map596")]
        Transport187263 = 596,
        /// <summary>
        /// Craig Test
        /// </summary>
        [LocalizedName("Map597")]
        CraigTest = 597,
        /// <summary>
        /// Sunwell Fix (Unused)
        /// </summary>
        [LocalizedName("Map598")]
        Sunwell5Man = 598,
        /// <summary>
        /// Halls of Stone
        /// </summary>
        [LocalizedName("Map599")]
        Ulduar70 = 599,
        /// <summary>
        /// Drak'Tharon Keep
        /// </summary>
        [LocalizedName("Map600")]
        DrakTheronKeep = 600,
        /// <summary>
        /// Azjol-Nerub
        /// </summary>
        [LocalizedName("Map601")]
        Azjol_Uppercity = 601,
        /// <summary>
        /// Halls of Lightning
        /// </summary>
        [LocalizedName("Map602")]
        Ulduar80 = 602,
        /// <summary>
        /// Ulduar
        /// </summary>
        [LocalizedName("Map603")]
        UlduarRaid = 603,
        /// <summary>
        /// Gundrak
        /// </summary>
        [LocalizedName("Map604")]
        GunDrak = 604,
        /// <summary>
        /// Development Land (non-weighted textures)
        /// </summary>
        [LocalizedName("Map605")]
        development_nonweighted = 605,
        /// <summary>
        /// QA and DVD
        /// </summary>
        [LocalizedName("Map606")]
        QA_DVD = 606,
        /// <summary>
        /// Strand of the Ancients
        /// </summary>
        [LocalizedName("Map607")]
        NorthrendBG = 607,
        /// <summary>
        /// Violet Hold
        /// </summary>
        [LocalizedName("Map608")]
        DalaranPrison = 608,
        /// <summary>
        /// Ebon Hold
        /// </summary>
        [LocalizedName("Map609")]
        DeathKnightStart = 609,
        /// <summary>
        /// Transport: Tirisfal to Vengeance Landing
        /// </summary>
        [LocalizedName("Map610")]
        Transport_Tirisfal_Vengeance_Landing = 610,
        /// <summary>
        /// Transport: Menethil to Valgarde
        /// </summary>
        [LocalizedName("Map612")]
        Transport_Menethil_Valgarde = 612,
        /// <summary>
        /// Transport: Orgrimmar to Warsong Hold
        /// </summary>
        [LocalizedName("Map613")]
        Transport_Orgrimmar_Warsong_Hold = 613,
        /// <summary>
        /// Transport: Stormwind to Valiance Keep
        /// </summary>
        [LocalizedName("Map614")]
        Transport_Stormwind_Valiance_Keep = 614,
        /// <summary>
        /// The Obsidian Sanctum
        /// </summary>
        [LocalizedName("Map615")]
        ChamberOfAspectsBlack = 615,
        /// <summary>
        /// The Eye of Eternity
        /// </summary>
        [LocalizedName("Map616")]
        NexusRaid = 616,
        /// <summary>
        /// Dalaran Sewers
        /// </summary>
        [LocalizedName("Map617")]
        DalaranArena = 617,
        /// <summary>
        /// The Ring of Valor
        /// </summary>
        [LocalizedName("Map618")]
        OrgrimmarArena = 618,
        /// <summary>
        /// Ahn'kahet: The Old Kingdom
        /// </summary>
        [LocalizedName("Map619")]
        Azjol_LowerCity = 619,
        /// <summary>
        /// Transport: Moa'ki to Unu'pe
        /// </summary>
        [LocalizedName("Map620")]
        Transport_Moaki_Unupe = 620,
        /// <summary>
        /// Transport: Moa'ki to Kamagua
        /// </summary>
        [LocalizedName("Map621")]
        Transport_Moaki_Kamagua = 621,
        /// <summary>
        /// Transport: Orgrim's Hammer
        /// </summary>
        [LocalizedName("Map622")]
        Transport192241 = 622,
        /// <summary>
        /// Transport: The Skybreaker
        /// </summary>
        [LocalizedName("Map623")]
        Transport192242 = 623,
        /// <summary>
        /// Vault of Archavon
        /// </summary>
        [LocalizedName("Map624")]
        WintergraspRaid = 624,
        /// <summary>
        /// unused
        /// </summary>
        [LocalizedName("Map627")]
        unused = 627,
        /// <summary>
        /// Isle of Conquest
        /// </summary>
        [LocalizedName("Map628")]
        IsleofConquest = 628,
        /// <summary>
        /// Icecrown Citadel
        /// </summary>
        [LocalizedName("Map631")]
        IcecrownCitadel = 631,
        /// <summary>
        /// The Forge of Souls
        /// </summary>
        [LocalizedName("Map632")]
        IcecrownCitadel5Man = 632,
        /// <summary>
        /// Abyssal Maw Exterior
        /// </summary>
        [LocalizedName("Map637")]
        AbyssalMaw = 637,
        /// <summary>
        /// Gilneas
        /// </summary>
        [LocalizedName("Map638")]
        Gilneas = 638,
        /// <summary>
        /// Transport: Alliance Airship BG
        /// </summary>
        [LocalizedName("Map641")]
        Transport_AllianceAirshipBG = 641,
        /// <summary>
        /// Transport: HordeAirshipBG
        /// </summary>
        [LocalizedName("Map642")]
        Transport_HordeAirshipBG = 642,
        /// <summary>
        /// Throne of the Tides
        /// </summary>
        [LocalizedName("Map643")]
        AbyssalMaw_Interior = 643,
        /// <summary>
        /// Halls of Origination
        /// </summary>
        [LocalizedName("Map644")]
        Uldum = 644,
        /// <summary>
        /// Blackrock Caverns
        /// </summary>
        [LocalizedName("Map645")]
        BlackRockSpire_4_0 = 645,
        /// <summary>
        /// Deepholm
        /// </summary>
        [LocalizedName("Map646")]
        Deephome = 646,
        /// <summary>
        /// Transport: Orgrimmar to Thunder Bluff
        /// </summary>
        [LocalizedName("Map647")]
        Transport_Orgrimmar_to_Thunderbluff = 647,
        /// <summary>
        /// LostIsles
        /// </summary>
        [LocalizedName("Map648")]
        LostIsles = 648,
        /// <summary>
        /// Trial of the Crusader
        /// </summary>
        [LocalizedName("Map649")]
        ArgentTournamentRaid = 649,
        /// <summary>
        /// Trial of the Champion
        /// </summary>
        [LocalizedName("Map650")]
        ArgentTournamentDungeon = 650,
        /// <summary>
        /// ElevatorSpawnTest
        /// </summary>
        [LocalizedName("Map651")]
        ElevatorSpawnTest = 651,
        /// <summary>
        /// Gilneas2
        /// </summary>
        [LocalizedName("Map654")]
        Gilneas2 = 654,
        /// <summary>
        /// GilneasPhase1
        /// </summary>
        [LocalizedName("Map655")]
        GilneasPhase1 = 655,
        /// <summary>
        /// GilneasPhase2
        /// </summary>
        [LocalizedName("Map656")]
        GilneasPhase2 = 656,
        /// <summary>
        /// The Vortex Pinnacle
        /// </summary>
        [LocalizedName("Map657")]
        SkywallDungeon = 657,
        /// <summary>
        /// Pit of Saron
        /// </summary>
        [LocalizedName("Map658")]
        QuarryofTears = 658,
        /// <summary>
        /// Lost Isles Volcano Eruption
        /// </summary>
        [LocalizedName("Map659")]
        LostIslesPhase1 = 659,
        /// <summary>
        /// Deephome Ceiling
        /// </summary>
        [LocalizedName("Map660")]
        Deephomeceiling = 660,
        /// <summary>
        /// Lost Isles Town in a Box
        /// </summary>
        [LocalizedName("Map661")]
        LostIslesPhase2 = 661,
        /// <summary>
        /// Transport: Alliance Vashj'ir Ship
        /// </summary>
        [LocalizedName("Map662")]
        Transport197195 = 662,
        /// <summary>
        /// Halls of Reflection
        /// </summary>
        [LocalizedName("Map668")]
        HallsOfReflection = 668,
        /// <summary>
        /// Blackwing Descent
        /// </summary>
        [LocalizedName("Map669")]
        BlackwingDescent = 669,
        /// <summary>
        /// Grim Batol
        /// </summary>
        [LocalizedName("Map670")]
        GrimBatolDungeon = 670,
        /// <summary>
        /// The Bastion of Twilight
        /// </summary>
        [LocalizedName("Map671")]
        GrimBatolRaid = 671,
        /// <summary>
        /// Transport: The Skybreaker (Icecrown Citadel Raid)
        /// </summary>
        [LocalizedName("Map672")]
        Transport197347 = 672,
        /// <summary>
        /// Transport: Orgrim's Hammer (Icecrown Citadel Raid)
        /// </summary>
        [LocalizedName("Map673")]
        Transport197348 = 673,
        /// <summary>
        /// Transport: Ship to Vashj'ir
        /// </summary>
        [LocalizedName("Map674")]
        Transport197349_2 = 674,
        /// <summary>
        /// Transport: The Skybreaker (IC Dungeon)
        /// </summary>
        [LocalizedName("Map712")]
        Transport197349 = 712,
        /// <summary>
        /// Transport: Orgrim's Hammer (IC Dungeon)
        /// </summary>
        [LocalizedName("Map713")]
        Transport197350 = 713,
        /// <summary>
        /// Trasnport: The Mighty Wind (Icecrown Citadel Raid)
        /// </summary>
        [LocalizedName("Map718")]
        Transport201834 = 718,
        /// <summary>
        /// Mount Hyjal Phase 1
        /// </summary>
        [LocalizedName("Map719")]
        MountHyjalPhase1 = 719,
        /// <summary>
        /// Firelands
        /// </summary>
        [LocalizedName("Map720")]
        Firelands1 = 720,
        /// <summary>
        /// Firelands Terrain 2
        /// </summary>
        [LocalizedName("Map721")]
        Firelands2 = 721,
        /// <summary>
        /// Stormwind
        /// </summary>
        [LocalizedName("Map723")]
        Stormwind = 723,
        /// <summary>
        /// The Ruby Sanctum
        /// </summary>
        [LocalizedName("Map724")]
        ChamberofAspectsRed = 724,
        /// <summary>
        /// The Stonecore
        /// </summary>
        [LocalizedName("Map725")]
        DeepholmeDungeon = 725,
        /// <summary>
        /// Twin Peaks
        /// </summary>
        [LocalizedName("Map726")]
        CataclysmCTF = 726,
        /// <summary>
        /// STV Diamond Mine BG
        /// </summary>
        [LocalizedName("Map727")]
        STV_Mine_BG = 727,
        /// <summary>
        /// The Battle for Gilneas (Old City Map)
        /// </summary>
        [LocalizedName("Map728")]
        TheBattleforGilneas = 728,
        /// <summary>
        /// Maelstrom Zone
        /// </summary>
        [LocalizedName("Map730")]
        MaelstromZone = 730,
        /// <summary>
        /// Stonetalon Bomb
        /// </summary>
        [LocalizedName("Map731")]
        DesolaceBomb = 731,
        /// <summary>
        /// Tol Barad
        /// </summary>
        [LocalizedName("Map732")]
        TolBarad = 732,
        /// <summary>
        /// Ahn'Qiraj Terrace
        /// </summary>
        [LocalizedName("Map734")]
        AhnQirajTerrace = 734,
        /// <summary>
        /// Twilight Highlands Dragonmaw Phase
        /// </summary>
        [LocalizedName("Map736")]
        TwilightHighlandsDragonmawPhase = 736,
        /// <summary>
        /// Ship to Vashj'ir (Orgrimmar -> Vashj'ir)
        /// </summary>
        [LocalizedName("Map738")]
        Transport200100 = 738,
        /// <summary>
        /// Vashj'ir Sub - Horde
        /// </summary>
        [LocalizedName("Map739")]
        Transport200101 = 739,
        /// <summary>
        /// Vashj'ir Sub - Alliance
        /// </summary>
        [LocalizedName("Map740")]
        Transport200102 = 740,
        /// <summary>
        /// Twilight Highlands Horde Transport
        /// </summary>
        [LocalizedName("Map741")]
        Transport200103 = 741,
        /// <summary>
        /// Vashj'ir Sub - Horde - Circling Abyssal Maw
        /// </summary>
        [LocalizedName("Map742")]
        Transport203729 = 742,
        /// <summary>
        /// Vashj'ir Sub - Alliance circling Abyssal Maw
        /// </summary>
        [LocalizedName("Map743")]
        Transport203730 = 743,
        /// <summary>
        /// Uldum Phase Oasis
        /// </summary>
        [LocalizedName("Map746")]
        UldumPhaseOasis = 746,
        /// <summary>
        /// Transport: Deepholm Gunship
        /// </summary>
        [LocalizedName("Map747")]
        Transport_203732 = 747,
        /// <summary>
        /// Transport: Onyxia/Nefarian Elevator
        /// </summary>
        [LocalizedName("Map748")]
        Transport203858 = 748,
        /// <summary>
        /// Transport: Gilneas Moving Gunship
        /// </summary>
        [LocalizedName("Map749")]
        Transport203859 = 749,
        /// <summary>
        /// Transport: Gilneas Static Gunship
        /// </summary>
        [LocalizedName("Map750")]
        Transport203860 = 750,
        /// <summary>
        /// Redridge - Orc Bomb
        /// </summary>
        [LocalizedName("Map751")]
        RedgridgeOrcBomb = 751,
        /// <summary>
        /// Redridge - Bridge Phase One
        /// </summary>
        [LocalizedName("Map752")]
        RedridgeBridgePhaseOne = 752,
        /// <summary>
        /// Redridge - Bridge Phase Two
        /// </summary>
        [LocalizedName("Map753")]
        RedridgeBridgePhaseTwo = 753,
        /// <summary>
        /// Throne of the Four Winds
        /// </summary>
        [LocalizedName("Map754")]
        SkywallRaid = 754,
        /// <summary>
        /// Lost City of the Tol'vir
        /// </summary>
        [LocalizedName("Map755")]
        UldumDungeon = 755,
        /// <summary>
        /// Baradin Hold
        /// </summary>
        [LocalizedName("Map757")]
        BaradinHold = 757,
        /// <summary>
        /// Uldum Phased Entrance
        /// </summary>
        [LocalizedName("Map759")]
        UldumPhasedEntrance = 759,
        /// <summary>
        /// Twilight Highlands Phased Entrance
        /// </summary>
        [LocalizedName("Map760")]
        TwilightHighlandsPhasedEntrance = 760,
        /// <summary>
        /// The Battle for Gilneas
        /// </summary>
        [LocalizedName("Map761")]
        Gilneas_BG_2 = 761,
        /// <summary>
        /// Twilight Highlands Zeppelin 1
        /// </summary>
        [LocalizedName("Map762")]
        Transport_203861 = 762,
        /// <summary>
        /// Twilight Highlands Zeppelin 2
        /// </summary>
        [LocalizedName("Map763")]
        Transport_203862 = 763,
        /// <summary>
        /// Uldum - Phase Wrecked Camp
        /// </summary>
        [LocalizedName("Map764")]
        UldumPhaseWreckedCamp = 764,
        /// <summary>
        /// Krazzworks Attack Zeppelin
        /// </summary>
        [LocalizedName("Map765")]
        Transport203863 = 765,
        /// <summary>
        /// Transport: Gilneas Moving Gunship 02
        /// </summary>
        [LocalizedName("Map766")]
        Transport_2033864 = 766,
        /// <summary>
        /// Transport: Gilneas Moving Gunship 03
        /// </summary>
        [LocalizedName("Map767")]
        Transport_2033865 = 767,
        /// <summary>
        /// Zul'Gurub
        /// </summary>
        [LocalizedName("Map859")]
        Zul_Gurub5Man = 859,
        /// <summary>
        /// Molten Front
        /// </summary>
        [LocalizedName("Map861")]
        FirelandsDailies = 861,
        /// <summary>
        /// Scenario: Alcaz Island
        /// </summary>
        [LocalizedName("Map930")]
        ScenarioAlcazIsland = 930,
        /// <summary>
        /// End Time
        /// </summary>
        [LocalizedName("Map938")]
        COTDragonblight = 938,
        /// <summary>
        /// Well of Eternity
        /// </summary>
        [LocalizedName("Map939")]
        COTWarOfTheAncients = 939,
        /// <summary>
        /// Hour of Twilight
        /// </summary>
        [LocalizedName("Map940")]
        TheHourOfTwilight = 940,
        /// <summary>
        /// Nexus Legendary
        /// </summary>
        [LocalizedName("Map951")]
        NexusLegendary = 951,
        /// <summary>
        /// Dragon Soul
        /// </summary>
        [LocalizedName("Map967")]
        DeathwingBack = 967,
        /// <summary>
        /// Rated Eye of the Storm
        /// </summary>
        [LocalizedName("Map968")]
        EyeoftheStorm2_0 = 968,
        /// <summary>
        /// Darkmoon Faire
        /// </summary>
        [LocalizedName("Map974")]
        DarkmoonFaire = 974,
        /// <summary>
        /// Maelstrom Deathwing Fight
        /// </summary>
        [LocalizedName("Map977")]
        MaelstromDeathwingFight = 977,
        /// <summary>
        /// Tol'Vir Arena
        /// </summary>
        [LocalizedName("Map980")]
        TolVirArena = 980,
    }
}
