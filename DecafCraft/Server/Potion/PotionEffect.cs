using System;
using System.Diagnostics;
using DecafCraft.Server.Entity;

namespace DecafCraft.Server.Potion
{
    public class PotionEffect : IEquatable<PotionEffect>
    {
        private const string Amplifier = "amplifier";
        private const string Duration = "duration";
        private const string Type = "effect";
        private const string Ambient = "ambient";
        
        private readonly int _amplifier;
        private readonly int _duration;
        private readonly PotionEffectType _type;
        private readonly bool _ambient;

        public int GetAmplifier() => _amplifier;
        public int GetDuration() => _duration;
        public PotionEffectType GetEffectType() => _type;
        public bool IsAmbient() => _ambient;
        
        public PotionEffect(PotionEffectType type, int duration, int amplifier, bool ambient = true)
        {
            Debug.Assert(ReferenceEquals(null, type), "effect type cannot be null");
            _type = type;
            _duration = duration;
            _amplifier = amplifier;
            _ambient = ambient;
        }

        public bool Apply(ILivingEntity entity)
        {
            return entity.AddPotionEffect(this);
        }

        public bool Equals(PotionEffect other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _amplifier == other._amplifier && _duration == other._duration && Equals(_type, other._type) && _ambient == other._ambient;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((PotionEffect) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = _amplifier;
                hashCode = (hashCode * 397) ^ _duration;
                hashCode = (hashCode * 397) ^ (_type != null ? _type.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _ambient.GetHashCode();
                return hashCode;
            }
        }
    }
}