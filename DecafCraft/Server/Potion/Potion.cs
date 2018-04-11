using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using DecafCraft.Server.Entity;

namespace DecafCraft.Server.Potion
{
    public class Potion : IEquatable<Potion>
    {
        private bool _extended = false;
        private bool _splash = false;
        private int _level = 1;
        private int _name = -1;
        private PotionType _type;

        public bool HasExtendedDuration() => _extended;
        public bool IsSplashPotion() => _splash;
        public int GetLevel() => _level;
        public PotionType GetPotionType() => _type;

        public void SetHasExtendedDuration(bool extend)
        {
            if (_type == null || _type.IsInstant())
                throw new InvalidOperationException("Instant potions cannot be extended");
            _extended = extend;
        }

        public void SetLevel(int level)
        {
            Debug.Assert(_type != null, "No-effect potions don't have a level");
            int max = _type.GetMaxLevel();
            Debug.Assert(level > 0 && level <= max, "Level must be " +  (max == 1 ? "" : "between 1 and ") + $"{max} for this potion");
            _level = level;
        }
        
        public void SetSplash(bool splash) => _splash = splash;
        public void SetPotionType(PotionType type) => _type = type;

        //public IEnumerable<PotionEffect> GetPotionEffects() => GetEffectsFromDamage(GetDamageValue());
        
        private static readonly int EXTENDED_BIT = 0x40;
        private static readonly int POTION_BIT = 0xF;
        private static readonly int SPLASH_BIT = 0x4000;
        private static readonly int TIER_BIT = 0x20;
        private static readonly int TIER_SHIFT = 5;
        private static readonly int NAME_BIT = 0x3F;

        public Potion(PotionType type, int level = 1)
        {
            _type = type;
            if (type != null)
                _name = type.GetDamageValue();

            if (type == null || type == PotionType.WATER)
                _level = 0;
            
            Debug.Assert(type != null, "Type cannot be null");
            Debug.Assert(type != PotionType.WATER && level > 0 && level < 3, "Level must be 1 or 2");
            _level = level;
        }

        public Potion Splash()
        {
            SetSplash(true);
            return this;
        }

        public Potion Extend()
        {
            SetHasExtendedDuration(true);
            return this;
        }

        /*
        public void Apply(ItemStack stack)
        {
            Debug.Assert(stack == null, "ItemStack cannot be null")
            Debug.Assert(stack.GetStackType() == Material.POTION, "given itemstack is not a potion");
            stack.SetDurability(GetDamageValue());
        }

        public void Apply(ILivingEntity entity)
        {
            Debug.Assert(entity == null, "Entity cannot be null");
            entity.AddPotionEffects(GetPotionEffects());
        }
        
        public ItemStack ToItemStack(ItemStack stack, int amount)
        {
            return new ItemStack(Material.POTION, amount, GetDamageValue());
        }
        
        public Potion FromItemStack(ItemStack stack)
        {
            Debug.Assert(stack != null, "item cannot be null");
            if(stack.GetStackType() != Material.Potion)
                throw new InvalidOperationException("item is not a potion");
                
            return FromDamageValue(stack.GetDurability()); //TODO: Working in to a new method of getting the potion
        }
        */

        public bool Equals(Potion other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _extended == other._extended && _splash == other._splash && _level == other._level && Equals(_type, other._type);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Potion) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = _extended.GetHashCode();
                hashCode = (hashCode * 397) ^ _splash.GetHashCode();
                hashCode = (hashCode * 397) ^ _level;
                hashCode = (hashCode * 397) ^ (_type != null ? _type.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}