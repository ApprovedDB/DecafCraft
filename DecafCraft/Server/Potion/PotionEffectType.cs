using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DecafCraft.Server.Potion
{
    public class PotionEffectType : IEquatable<PotionEffectType>
    {
        private readonly int _id;
        private readonly string _name;
        private readonly bool _isInstant;
        private readonly double _durationModifier;

        public virtual int GetId() => _id;
        public virtual string GetName() => _name;
        public virtual bool IsInstant() => _isInstant;
        public virtual double GetDurationModifier() => _durationModifier;
        
        private static readonly Dictionary<int, PotionEffectType> PotionEffectTypes = new Dictionary<int, PotionEffectType>();
        private static readonly Dictionary<string, PotionEffectType> PotionEffects = new Dictionary<string, PotionEffectType>();
        private static bool _acceptingNew = true;
        
        public static readonly PotionEffectType SPEED = new PotionEffectType(1);
        public static readonly PotionEffectType SLOW = new PotionEffectType(2);
        public static readonly PotionEffectType FAST_DIGGING = new PotionEffectType(3);
        public static readonly PotionEffectType SLOW_DIGGING = new PotionEffectType(4);
        public static readonly PotionEffectType INCREASE_DAMAGE = new PotionEffectType(5);
        public static readonly PotionEffectType HEAL = new PotionEffectType(6);
        public static readonly PotionEffectType HARM = new PotionEffectType(7);
        public static readonly PotionEffectType JUMP = new PotionEffectType(8);
        public static readonly PotionEffectType CONFUSION = new PotionEffectType(9);
        public static readonly PotionEffectType REGENERATION = new PotionEffectType(10);
        public static readonly PotionEffectType DAMAGE_RESISTANCE = new PotionEffectType(11);
        public static readonly PotionEffectType FIRE_RESISTANCE = new PotionEffectType(12);
        public static readonly PotionEffectType WATER_BREATHING = new PotionEffectType(13);
        public static readonly PotionEffectType INVISIBILITY = new PotionEffectType(14);
        public static readonly PotionEffectType BLINDNESS = new PotionEffectType(15);
        public static readonly PotionEffectType NIGHT_VISION = new PotionEffectType(16);
        public static readonly PotionEffectType HUNGER = new PotionEffectType(17);
        public static readonly PotionEffectType WEAKNESS = new PotionEffectType(18);
        public static readonly PotionEffectType POISON = new PotionEffectType(19);
        public static readonly PotionEffectType WITHER = new PotionEffectType(20);
        public static readonly PotionEffectType HEALTH_BOOST = new PotionEffectType(21);
        public static readonly PotionEffectType ABSORPTION = new PotionEffectType(22);
        public static readonly PotionEffectType SATURATION = new PotionEffectType(23);
        
        public PotionEffectType(int id)
        {
            _id = id;
        }

        public PotionEffect CreateEffect(int duration, int amplifier)
        {
            return new PotionEffect(this, duration, amplifier);
        }

        public static PotionEffectType GetEffectByName(string name)
        {
            Debug.Assert(!ReferenceEquals(null, name), "name cannot be null");
            return PotionEffects[name.ToLower()];
        }

        public static void RegisterPotionEffectType(PotionEffectType type)
        {
            if(PotionEffects.ContainsKey(type.GetName().ToLower())) throw new ArgumentException("Cannot set already-set type");
            if(!_acceptingNew) throw new InvalidOperationException("No longer accepting new potion effect types (can only be done by the server implementation)");
            PotionEffectTypes.Add(type.GetId(), type);
            PotionEffects.Add(type.GetName().ToLower(), type);
        }

        public static void DenyRegistrations()
        {
            _acceptingNew = false;
        }

        public IEnumerable<PotionEffectType> GetEffects()
        {
            return PotionEffectTypes.Values;
        }

        public bool Equals(PotionEffectType other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _id == other._id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PotionEffectType) obj);
        }

        public override int GetHashCode()
        {
            return _id;
        }
    }
}