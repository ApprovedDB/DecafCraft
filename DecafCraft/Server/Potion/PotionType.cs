using System.Collections.Generic;

namespace DecafCraft.Server.Potion
{
    public class PotionType
    {
        private readonly int _damageValue;
        private readonly int _maxLevel;
        private readonly PotionEffectType _effectType;

        public PotionEffectType GetEffectType() => _effectType;
        public int GetDamageValue() => _damageValue;
        public int GetMaxLevel() => _maxLevel;
        public bool IsInstant() => _effectType?.IsInstant() ?? true;
        
        public static readonly List<PotionType> Values = new List<PotionType>();
        
        public static readonly PotionType WATER = new PotionType(0, null, 0);
        public static readonly PotionType REGEN = new PotionType(1, PotionEffectType.REGENERATION, 2);
        public static readonly PotionType SPEED = new PotionType(2, PotionEffectType.SPEED, 2);
        public static readonly PotionType FIRE_RESISTANCE = new PotionType(3, PotionEffectType.FIRE_RESISTANCE, 1);
        public static readonly PotionType POISON = new PotionType(4, PotionEffectType.POISON, 2);
        public static readonly PotionType INSTANT_HEAL = new PotionType(5, PotionEffectType.HEAL, 2);
        public static readonly PotionType NIGHT_VISION = new PotionType(6, PotionEffectType.NIGHT_VISION, 1);
        public static readonly PotionType WEAKNESS = new PotionType(9, PotionEffectType.WEAKNESS, 1);
        public static readonly PotionType STRENGTH = new PotionType(9, PotionEffectType.INCREASE_DAMAGE, 2);
        public static readonly PotionType SLOWNESS = new PotionType(10, PotionEffectType.SLOW, 1);
        public static readonly PotionType INSTANT_DAMAGE = new PotionType(12, PotionEffectType.HARM, 2);
        public static readonly PotionType WATER_BREATHING = new PotionType(13, PotionEffectType.WATER_BREATHING, 1);
        public static readonly PotionType INVISIBILITY = new PotionType(14, PotionEffectType.INVISIBILITY, 1);
        
        public PotionType(int damageValue, PotionEffectType effect, int maxLevel)
        {
            _damageValue = damageValue;
            _effectType = effect;
            _maxLevel = maxLevel;
            Values.Add(this);
        }

        public static PotionType GetByEffect(PotionEffectType effectType)
        {
            if (effectType == null)
                return WATER;
            
            foreach (PotionType type in PotionType.Values)
            {
                if (effectType.Equals(type._effectType))
                    return type;
            }
            
            return null;
        }
    }
}