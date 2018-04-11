using System.Collections.Generic;
using DecafCraft.Server.Potion;
using DecafCraft.Server.Projectiles;

namespace DecafCraft.Server.Entity
{
    public interface ILivingEntity : IEntity, IDamageable, IProjectileSource
    {
        /// <summary>
        /// Gets the height of the living entity's eyes above its location.
        /// </summary>
        /// <returns>Height of the living entity's eyes</returns>
        double GetEyeHeight();

        /// <summary>
        /// Gets the height of the living entity's eyes above its location.
        /// </summary>
        /// <param name="ignoreSneaking">If set true, the effects of sneaking will be ignored</param>
        /// <returns>Height of the living entity's eyes</returns>
        double GetEyeHeight(bool ignoreSneaking);

        /// <summary>
        /// Get the location of where the living entity's eyes are located.
        /// </summary>
        /// <returns>The location where the living entity's eyes are located</returns>
        Location GetEyeLocation();

        /// <summary>
        /// Get the current amount of breath the living entity has.
        /// </summary>
        /// <returns>Amount of remaning breath</returns>
        int GetRemainingBreath();

        /// <summary>
        /// Set the current amount of breath the living entity has.
        /// </summary>
        void SetRemainingBreath(int breath);

        /// <summary>
        /// Gets the max amount of breath the living entity has.
        /// </summary>
        /// <returns>The max amount of breath</returns>
        int GetMaximumBreath();

        /// <summary>
        /// Sets the max amount of breath the living entity has.
        /// </summary>
        /// <param name="breath">The max amount of breath</param>
        void SetMaximumBreath(int breath);

        /// <summary>
        /// Gets the max amount of invincibility ticks the living entity has. 
        /// </summary>
        /// <returns>The max amount of invincibility ticks</returns>
        int GetMaximumITicks();

        /// <summary>
        /// Sets the max amount of invincibility ticks the living entity has.
        /// </summary>
        /// <param name="ticks">The max amount of invincibility ticks</param>
        void SetMaximumITicks(int ticks);

        /// <summary>
        /// Gets the living entity's last amount of damage taken.
        /// </summary>
        /// <returns>Damage taken since the last no damage ticks time period</returns>
        double GetLastDamage();

        /// <summary>
        /// Set the living entity's last amount of damage dealt.
        /// </summary>
        /// <param name="damage">Amount of damage</param>
        void SetLastDamage(double damage);

        /// <summary>
        /// Get current amount of invincibility ticks the living entity has.
        /// </summary>
        /// <returns>The amount of invincibility ticks</returns>
        int GetITicks();

        /// <summary>
        /// Set current amount of invincibility ticks the living entity has.
        /// </summary>
        /// <param name="ticks">The amount of invincibility ticks</param>
        void SetITicks(int ticks);

        /// <summary>
        /// Adds the given potion effect to the living entity.
        /// </summary>
        /// <param name="effect">Effect to be added</param>
        /// <param name="force">Whether conflicting effects should be removed</param>
        /// <returns>Whether the effect was added or not</returns>
        bool AddPotionEffect(PotionEffect effect, bool force = false);

        /// <summary>
        /// Adds all of the given potions effects to the living entity.
        /// </summary>
        /// <param name="effects">Effects to be added</param>
        /// <returns>Whether all of the effects were added or not</returns>
        bool AddPotionEffects(IEnumerable<PotionEffect> effects);

        /// <summary>
        /// Whether the living entity has an existing instance of the given potion effect or not.
        /// </summary>
        /// <param name="type">Potiong effect to check for</param>
        /// <returns>Whether or not the living entity has the given effect active</returns>
        bool HasPotionEffect(PotionEffectType type);

        /// <summary>
        /// Removes the given potion effect from the living entity.
        /// </summary>
        /// <param name="type">Potion effect to remove</param>
        void RemovePotionEffect(PotionEffectType type);

        /// <summary>
        /// Gets all currently active potion effects on the living entity.
        /// </summary>
        /// <returns>A collection of PotionEffects</returns>
        IEnumerable<PotionEffect> GetActivePotionEffects();

        /// <summary>
        /// Checks whether the living entity has line of sight of another entity.
        /// </summary>
        /// <param name="entity">The entity to determine line of sight to</param>
        /// <returns>If the living entity has line of sight of the other entity</returns>
        bool HasLineOfSight(IEntity entity);

        /// <summary>
        /// Whether or not the entity despawns when far away from players.
        /// </summary>
        /// <returns>Whether the entity despawns when far away from players</returns>
        bool RemoveWhenFarAway();

        /// <summary>
        /// Sets whether or not the entity despawns when far away from players.
        /// </summary>
        /// <param name="remove">Whether the entity despawns when far away from players</param>
        void SetRemoveWhenFarAway(bool remove);
    }
}