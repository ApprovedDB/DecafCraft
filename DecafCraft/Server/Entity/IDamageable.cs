namespace DecafCraft.Server.Entity
{
    public interface IDamageable : IEntity
    {
        /// <summary>
        /// Deals the given amount of damage to this entity, from the specified entity.
        /// </summary>
        /// <param name="amount">Amount of damage to deal</param>
        /// <param name="source">Entity that is dealing the damage</param>
        void Damage(double amount, IEntity source);

        /// <summary>
        /// Get this entity's current health.
        /// </summary>
        /// <returns>Current health</returns>
        double GetHealth();

        /// <summary>
        /// Set this entity's current health.
        /// </summary>
        /// <param name="health">Health amount</param>
        void SetHealth(double health);

        /// <summary>
        /// Get this entity's max health.
        /// </summary>
        /// <returns>Maximum health</returns>
        double GetMaxHealth();

        /// <summary>
        /// Set this entity's max health.
        /// </summary>
        /// <param name="health">Maximum health amount</param>
        void SetMaxHealth(double health);

        /// <summary>
        /// Resets maximum health back to default
        /// </summary>
        void ResetMaxHealth();
    }
}