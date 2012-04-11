using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamilla.Network.Protocols.Wow.ObjectPackets;

namespace Kamilla.Network.Protocols.Wow.Game
{
    [Flags]
    public enum UnitFlags : uint
    {
        None                        = 0x00000000,
        Flag_0_0x1                  = 0x00000001,
        /// <summary>
        /// Can select. Cannot be attacked
        /// </summary>
        SelectableNotAttackable     = 0x00000002,
        /// <summary>
        /// Applied in SPELL_AURA_MOD_CONFUSE (5)
        /// Applied in SPELL_AURA_MOD_FEAR (7)
        /// </summary>
        Influenced                  = 0x00000004, // Stops movement packets
        /// <summary>
        /// Enables Detailed Collision, Allows swimming
        /// When set for pets allows the popup menu to be shown (dismiss, rename, etc)
        /// </summary>
        PlayerControlled            = 0x00000008, // 2.4.2
        /// <summary>
        /// Rename? Dead?
        /// </summary>
        Flag_0x10                   = 0x00000010,
        /// <summary>
        /// Spells are free, and some have no reagent cost
        /// </summary>
        Preparation                 = 0x00000020, // 3.0.3
        /// <summary>
        /// Elite
        /// </summary>
        PlusMob                     = 0x00000040, // 3.0.2
        /// <summary>
        /// Can select. Cannot be attacked
        /// </summary>
        SelectableNotAttackable_2   = 0x00000080,
        NotAttackable               = 0x00000100,
        Flag_0x200                  = 0x00000200,
        /// <summary>
        /// Looting animation is shown
        /// </summary>
        Looting                     = 0x00000400,
        PetInCombat                 = 0x00000800, // 3.0.2
        Flag_12_0x1000              = 0x00001000,
        Silenced                    = 0x00002000, // 3.0.3
        Flag_14_0x4000              = 0x00004000,
        Flag_15_0x8000              = 0x00008000,
        /// <summary>
        /// Can select. Cannot be attacked
        /// </summary>
        SelectableNotAttackable_3   = 0x10000,
        /// <summary>
        /// Pacifies the target, preventing spells from being cast that have PreventionType == Pacified
        /// </summary>
        Pacified = 0x20000,//3.0.3
        Stunned = 0x40000,
        CanPerformAction_Mask1      = 0x00060000,
        /// <summary>
        /// Unit is in Combat
        /// </summary>
        Combat                      = 0x00080000, // 3.1.1
        /// <summary>
        /// Unit is currently on a taxi
        /// </summary>
        TaxiFlight                  = 0x00100000, // 3.1.1
        Disarmed                    = 0x00200000, // 3.1.1
        Confused                    = 0x00400000, // 3.0.3
        Feared                      = 0x00800000,
        Possessed                   = 0x01000000, // 3.1.1
        NotSelectable               = 0x02000000,
        Skinnable                   = 0x04000000,
        Mounted                     = 0x08000000,
        Flag_28_0x10000000          = 0x10000000,
        Flag_29_0x20000000          = 0x20000000,
        Flag_30_0x40000000          = 0x40000000,
        Flag_31_0x80000000          = 0x80000000,
    }

    [Flags]
    public enum UnitFlags2
    {
        FeignDeath          = 0x0001,
        NoModel             = 0x0002,
        Flag_0x4            = 0x0004,
        Flag_0x8            = 0x0008,
        MirrorImage         = 0x0010,
        Flag_0x20           = 0x0020,
        ForceAutoRunForward = 0x0040,
        /// <summary>
        /// Treat as disarmed?
        /// Treat main and off hand weapons as not being equipped?
        /// </summary>
        Flag_0x80           = 0x0080,
        /// <summary>
        /// Skip checks on ranged weapon?
        /// Treat it as not being equipped?
        /// </summary>
        Flag_0x400          = 0x0400,
        Flag_0x800          = 0x0800,
        Flag_0x1000         = 0x1000,
    }

    [Flags]
    public enum UnitDynamicFlags
    {
        None                    = 0x00,
        Lootable                = 0x01,
        TrackUnit               = 0x02,
        TaggedByOther           = 0x04,
        TaggedByMe              = 0x08,
        SpecialInfo             = 0x10,
        Dead                    = 0x20,
        ReferAFriendLinked      = 0x40,
        IsTappedByAllThreatList = 0x80,
    }

    [Flags]
    public enum NpcFlags
    {
        None                  = 0x00000000,
        Gossip                = 0x00000001,       // 100%
        QuestGiver            = 0x00000002,       // guessed, probably ok
        Unk1                  = 0x00000004,
        Unk2                  = 0x00000008,
        Trainer               = 0x00000010,       // 100%
        TrainerClass          = 0x00000020,       // 100%
        TrainerProfession     = 0x00000040,       // 100%
        Vendor                = 0x00000080,       // 100%
        VendorAmmo            = 0x00000100,       // 100%, general goods vendor
        VendorFood            = 0x00000200,       // 100%
        VendorPoison          = 0x00000400,       // guessed
        VendorReagent         = 0x00000800,       // 100%
        Repair                = 0x00001000,       // 100%
        FlightMaster          = 0x00002000,       // 100%
        SpiritHealer          = 0x00004000,       // guessed
        SpiritGuide           = 0x00008000,       // guessed
        Innkeeper             = 0x00010000,       // 100%
        Banker                = 0x00020000,       // 100%
        Petitioner            = 0x00040000,       // 100% 0xc0000 = guild petitions, 0x40000 = arena team petitions
        TabardDesigner        = 0x00080000,       // 100%
        BattleMaster          = 0x00100000,       // 100%
        Auctioneer            = 0x00200000,       // 100%
        StableMaster          = 0x00400000,       // 100%
        GuildBanker           = 0x00800000,       // cause client to send 997 opcode
        Spellclick            = 0x01000000,       // cause client to send 1015 opcode (spell click), dynamic, set at loading and don't must be set in db
    }

    /// <summary>
    /// Used in UNIT_FIELD_BYTES_1, 1st byte
    /// </summary>
    public enum StandState : byte
    {
        Stand                   = 0,
        Sit                     = 1,
        SittingInChair          = 2,
        /// <summary>
        /// AnimationData Id 99 or 100
        /// </summary>
        Sleeping                = 3,
        /// <summary>
        /// AnimationData Id 102
        /// </summary>
        SittingInLowChair       = 4,
        /// <summary>
        /// AnimationData Id 103
        /// </summary>
        SittingInMediumChair    = 5,
        /// <summary>
        /// AnimationData Id 104
        /// </summary>
        SittingInHighChair      = 6,
        Dead                    = 7,
        Kneeling                = 8,
        /// <summary>
        /// 201 = submerge
        /// 
        /// </summary>
        Type9                   = 9,
    }

    /// <summary>
    /// Used in UNIT_FIELD_BYTES_2, 2nd byte
    /// </summary>
    [Flags]
    public enum PvPState
    {
        None            = 0x0,
        PVP             = 0x1,
        FFAPVP          = 0x4,
        InPvPSanctuary  = 0x8,
    }

    /// <summary>
    /// Used in UNIT_FIELD_BYTES_1, 3rd byte
    /// </summary>
    [Flags]
    public enum StateFlag
    {
        None            = 0x0,
        AlwaysStand     = 0x1,
        Sneaking        = 0x2,
        UnTrackable     = 0x4,
    }

    /// <summary>
    /// Used in UNIT_FIELD_BYTES_2, 1st byte
    /// </summary>
    public enum SheathType : sbyte
    {
        Undetermined    = -1,
        None            = 0,
        Melee           = 1,
        Ranged          = 2,

        Shield          = 4,
        Rod             = 5,
        Light           = 7,
    }

    /// <summary>
    /// Used in UNIT_FIELD_BYTES_2, 4th byte
    /// </summary>
    /// <remarks>
    /// Values from the first column of SpellShapeshiftForm.dbc
    /// </remarks>
    public enum ShapeshiftForm
    {
        Normal              = 0,
        Cat                 = 1,
        TreeOfLife          = 2,
        Travel              = 3,
        Aqua                = 4,
        Bear                = 5,
        Ambient             = 6,
        Ghoul               = 7,
        DireBear            = 8,
        CreatureBear        = 14,
        CreatureCat         = 15,
        GhostWolf           = 16,
        BattleStance        = 17,
        DefensiveStance     = 18,
        BerserkerStance     = 19,
        EpicFlightForm      = 27,
        Shadow              = 28,
        Stealth             = 30,
        Moonkin             = 31,
        SpiritOfRedemption  = 32,
        End
    }

    public class WowUnit : WowObject
    {
        public Races Race
        {
            get { return (Races)GetByte(UnitUpdateFields.UNIT_FIELD_BYTES_0, 0); }
            set { SetByte(UnitUpdateFields.UNIT_FIELD_BYTES_0, (byte)value, 0); }
        }
        public Classes Class
        {
            get { return (Classes)GetByte(UnitUpdateFields.UNIT_FIELD_BYTES_0, 1); }
            set { SetByte(UnitUpdateFields.UNIT_FIELD_BYTES_0, (byte)value, 1); }
        }
        public Genders Gender
        {
            get { return (Genders)GetByte(UnitUpdateFields.UNIT_FIELD_BYTES_0, 2); }
            set { SetByte(UnitUpdateFields.UNIT_FIELD_BYTES_0, (byte)value, 2); }
        }
        /// <summary>
        /// Gets or sets the power type of the current unit.
        /// </summary>
        public PowerType PowerType
        {
            get { return (PowerType)GetByte(UnitUpdateFields.UNIT_FIELD_BYTES_0, 3); }
            set { SetByte(UnitUpdateFields.UNIT_FIELD_BYTES_0, (byte)value, 3); }
        }

        public SheathType Sheath
        {
            get { return (SheathType)GetByte(UnitUpdateFields.UNIT_FIELD_BYTES_2, 0); }
            set { SetByte(UnitUpdateFields.UNIT_FIELD_BYTES_2, (byte)value, 0); }
        }

        public uint Level
        {
            get { return GetUInt(UnitUpdateFields.UNIT_FIELD_LEVEL); }
            set { SetUInt(UnitUpdateFields.UNIT_FIELD_LEVEL, value); }
        }

        public uint Health
        {
            get { return GetUInt(UnitUpdateFields.UNIT_FIELD_HEALTH); }
            set { SetUInt(UnitUpdateFields.UNIT_FIELD_HEALTH, value); }
        }

        public uint MaxHealth
        {
            get { return GetUInt(UnitUpdateFields.UNIT_FIELD_MAXHEALTH); }
            set { SetUInt(UnitUpdateFields.UNIT_FIELD_MAXHEALTH, value); }
        }

        public UnitFlags Flags
        {
            get { return (UnitFlags)GetUInt(UnitUpdateFields.UNIT_FIELD_FLAGS); }
            set { SetUInt(UnitUpdateFields.UNIT_FIELD_FLAGS, (uint)value); }
        }

        public UnitFlags2 Flags2
        {
            get { return (UnitFlags2)GetUInt(UnitUpdateFields.UNIT_FIELD_FLAGS_2); }
            set { SetUInt(UnitUpdateFields.UNIT_FIELD_FLAGS_2, (uint)value); }
        }

        public UnitDynamicFlags DynamicFlags
        {
            get { return (UnitDynamicFlags)GetUInt(UnitUpdateFields.UNIT_DYNAMIC_FLAGS); }
            set { SetUInt(UnitUpdateFields.UNIT_DYNAMIC_FLAGS, (uint)value); }
        }

        public NpcFlags NpcFlags
        {
            get { return (NpcFlags)GetUInt(UnitUpdateFields.UNIT_NPC_FLAGS); }
            set { SetUInt(UnitUpdateFields.UNIT_NPC_FLAGS, (uint)value); }
        }

        public uint Model
        {
            get { return GetUInt(UnitUpdateFields.UNIT_FIELD_DISPLAYID); }
            set { SetUInt(UnitUpdateFields.UNIT_FIELD_DISPLAYID, value); }
        }

        public uint NativeModel
        {
            get { return GetUInt(UnitUpdateFields.UNIT_FIELD_NATIVEDISPLAYID); }
            set { SetUInt(UnitUpdateFields.UNIT_FIELD_NATIVEDISPLAYID, value); }
        }

        public uint MountModel
        {
            get { return GetUInt(UnitUpdateFields.UNIT_FIELD_MOUNTDISPLAYID); }
            set { SetUInt(UnitUpdateFields.UNIT_FIELD_MOUNTDISPLAYID, value); }
        }

        public float BoundingRadius
        {
            get { return GetFloat(UnitUpdateFields.UNIT_FIELD_BOUNDINGRADIUS); }
            set { SetFloat(UnitUpdateFields.UNIT_FIELD_BOUNDINGRADIUS, value); }
        }

        public float CombatReach
        {
            get { return GetFloat(UnitUpdateFields.UNIT_FIELD_COMBATREACH); }
            set { SetFloat(UnitUpdateFields.UNIT_FIELD_COMBATREACH, value); }
        }

        public float CastSpeed
        {
            get { return GetFloat(UnitUpdateFields.UNIT_MOD_CAST_SPEED); }
            set { SetFloat(UnitUpdateFields.UNIT_MOD_CAST_SPEED, value); }
        }

        public float CastHaste
        {
            get { return GetFloat(UnitUpdateFields.UNIT_MOD_CAST_HASTE); }
            set { SetFloat(UnitUpdateFields.UNIT_MOD_CAST_HASTE, value); }
        }

        public float HoverHeight
        {
            get { return GetFloat(UnitUpdateFields.UNIT_FIELD_HOVERHEIGHT); }
            set { SetFloat(UnitUpdateFields.UNIT_FIELD_HOVERHEIGHT, value); }
        }

        public WowGuid Creator
        {
            get { return new WowGuid(GetULong(UnitUpdateFields.UNIT_FIELD_CREATEDBY)); }
            set { SetULong(UnitUpdateFields.UNIT_FIELD_CREATEDBY, value.Raw); }
        }

        public uint Faction
        {
            get { return GetUInt(UnitUpdateFields.UNIT_FIELD_FACTIONTEMPLATE); }
            set { SetUInt(UnitUpdateFields.UNIT_FIELD_FACTIONTEMPLATE, value); }
        }

        public uint BaseAttackTime
        {
            get { return GetUInt(UnitUpdateFields.UNIT_FIELD_BASEATTACKTIME); }
            set { SetUInt(UnitUpdateFields.UNIT_FIELD_BASEATTACKTIME, value); }
        }

        public uint BaseAttackTime2
        {
            get { return GetUInt(UnitUpdateFields.UNIT_FIELD_BASEATTACKTIME_2); }
            set { SetUInt(UnitUpdateFields.UNIT_FIELD_BASEATTACKTIME_2, value); }
        }

        //public uint Mana
        //{
        //    get
        //    {
        //        if (this is WowPlayer)
        //        {
        //            // we need to use ChrClassesXPowerTypes.dbc
        //            if (PowerType == PowerType.Mana)
        //                return GetUInt(UnitUpdateFields.UNIT_FIELD_POWER1);
        //        }
        //        else if (PowerType == PowerType.Mana)
        //            return GetUInt(UnitUpdateFields.UNIT_FIELD_POWER1);

        //        return 0;
        //    }
        //}

        /// <summary>
        /// Gets or sets a <see cref="System.Boolean"/> value
        /// that indicates whether the current unit is dead or not.
        /// </summary>
        public bool IsDead
        {
            get { return (DynamicFlags & UnitDynamicFlags.Dead) != 0; }
            set
            {
                if (value)
                    DynamicFlags |= UnitDynamicFlags.Dead;
                else
                    DynamicFlags &= ~UnitDynamicFlags.Dead;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="System.Boolean"/> value
        /// that indicates whether the current unit is being tracked or not.
        /// </summary>
        public bool IsTracked
        {
            get { return (DynamicFlags & UnitDynamicFlags.TrackUnit) != 0; }
            set
            {
                if (value)
                    DynamicFlags |= UnitDynamicFlags.TrackUnit;
                else
                    DynamicFlags &= ~UnitDynamicFlags.TrackUnit;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="System.Boolean"/> value
        /// that indicates whether the current unit is lootable or not.
        /// </summary>
        public bool IsLootable
        {
            get { return (DynamicFlags & UnitDynamicFlags.Lootable) != 0; }
            set
            {
                if (value)
                    DynamicFlags |= UnitDynamicFlags.Lootable;
                else
                    DynamicFlags &= ~UnitDynamicFlags.Lootable;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="System.Boolean"/> value that indicates
        /// whether the current unit is mounted or not.
        /// </summary>
        public bool IsMounted
        {
            get { return (Flags & UnitFlags.Mounted) != 0; }
            set
            {
                if (value)
                    Flags |= UnitFlags.Mounted;
                else
                    Flags &= ~UnitFlags.Mounted;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="System.Boolean"/> value
        /// that indicates whether the current unit is in combat or not.
        /// </summary>
        public bool IsInCombat
        {
            get { return (Flags & UnitFlags.Combat) != 0; }
            set
            {
                if (value)
                    Flags |= UnitFlags.Combat;
                else
                    Flags &= ~UnitFlags.Combat;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="System.Boolean"/> value
        /// that indicates whether the current unit is on texi or not.
        /// </summary>
        public bool IsOnTaxi
        {
            get { return (Flags & UnitFlags.TaxiFlight) != 0; }
            set
            {
                if (value)
                    Flags |= UnitFlags.TaxiFlight;
                else
                    Flags &= ~UnitFlags.TaxiFlight;
            }
        }

        #region Unit Update Fields Getters & Setters
        public bool ValueExists(UnitUpdateFields index) { return ValueExists((uint)index); }

        public ulong GetULong(UnitUpdateFields index) { return GetULong((uint)index); }
        public long GetLong(UnitUpdateFields index) { return GetLong((uint)index); }
        public float GetFloat(UnitUpdateFields index) { return GetFloat((uint)index); }
        public uint GetUInt(UnitUpdateFields index) { return GetUInt((uint)index); }
        public int GetInt(UnitUpdateFields index) { return GetInt((uint)index); }
        public ushort GetShort(UnitUpdateFields index, byte offset) { return GetShort((uint)index, offset); }
        public byte GetByte(UnitUpdateFields index, byte offset) { return GetByte((uint)index, offset); }

        public void SetULong(UnitUpdateFields index, ulong value) { SetULong((uint)index, value); }
        public void SetLong(UnitUpdateFields index, long value) { SetLong((uint)index, value); }
        public void SetFloat(UnitUpdateFields index, float value) { SetFloat((uint)index, value); }
        public void SetUInt(UnitUpdateFields index, uint value) { SetUInt((uint)index, value); }
        public void SetInt(UnitUpdateFields index, int value) { SetInt((uint)index, value); }
        public void SetShort(UnitUpdateFields index, ushort value, byte offset) { SetShort((uint)index, value, offset); }
        public void SetByte(UnitUpdateFields index, byte value, byte offset) { SetByte((uint)index, value, offset); }
        #endregion

        public WowUnit()
            : this(ObjectTypeId.Unit)
        {
        }

        protected WowUnit(ObjectTypeId type)
            : base(type)
        {
            this.CombatReach = 1.0f;
            this.BoundingRadius = 1.0f;
            this.CastHaste = 1.0f;
            this.CastSpeed = 1.0f;
            this.HoverHeight = 1.0f;
            this.BaseAttackTime = 2000;
            this.BaseAttackTime2 = 2000;
            this.Sheath = SheathType.Melee;
        }

        #region Threat
        public class TThreatList : Dictionary<WowGuid, uint> { }

        TThreatList m_threatList = new TThreatList();
        public TThreatList ThreatList { get { return m_threatList; } }

        List<WowGuid> m_attackedBy = new List<WowGuid>();
        public List<WowGuid> AttackedBy { get { return m_attackedBy; } }

        public void SetThreatAgainst(WowGuid target, uint threat)
        {
            m_threatList[target] = threat;
        }

        public uint GetThreatAgainst(WowGuid target)
        {
            uint threat;
            m_threatList.TryGetValue(target, out threat);
            return threat;
        }

        public void ClearThreatList()
        {
            m_threatList.Clear();
        }

        public void SetAttackedBy(WowGuid source)
        {
            if (!m_attackedBy.Contains(source))
                m_attackedBy.Add(source);
        }

        public bool IsAttackedBy(WowGuid unit)
        {
            return m_attackedBy.Contains(unit);
        }

        public void UnsetAttackedBy(WowGuid source)
        {
            m_attackedBy.Remove(source);
        }
        #endregion

        #region Auras
        public readonly AuraCollection Auras = new AuraCollection();

        public void ApplyAuraUpdate(AuraUpdate update)
        {
            if (update.Full)
                Auras.Clear();

            foreach (var aura in update.Auras)
                Auras[aura.Slot] = aura;
        }

        public bool HasAura(uint spell)
        {
            return HasAura(aura => aura.Spell == spell);
        }

        public bool HasAura(uint spell, WowGuid caster)
        {
            return HasAura(aura => aura.Spell == spell && aura.Caster == caster);
        }

        public bool HasAura(Predicate<Aura> predicate)
        {
            foreach (var aura in Auras)
            {
                if (predicate(aura))
                    return true;
            }

            return false;
        }

        public Aura GetAura(uint spell)
        {
            return GetAura(aura => aura.Spell == spell);
        }

        public Aura GetAura(uint spell, WowGuid caster)
        {
            return GetAura(aura => aura.Spell == spell && aura.Caster == caster);
        }

        public Aura GetAura(Predicate<Aura> predicate)
        {
            foreach (var aura in Auras)
            {
                if (predicate(aura))
                    return aura;
            }

            return null;
        }

        public bool TryGetAura(uint spell, out Aura aura)
        {
            return TryGetAura(aur => aur.Spell == spell, out aura);
        }

        public bool TryGetAura(uint spell, WowGuid caster, out Aura aura)
        {
            return TryGetAura(aur => aur.Spell == spell && aur.Caster == caster, out aura);
        }

        public bool TryGetAura(Predicate<Aura> predicate, out Aura aura)
        {
            foreach (var aura_i in Auras)
            {
                if (predicate(aura_i))
                {
                    aura = aura_i;
                    return true;
                }
            }

            aura = null;
            return false;
        }
        #endregion
    }
}
