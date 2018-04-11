using DecafCraft.Server.Projectiles;

namespace DecafCraft.Server.Entity
{
    public interface IProjectile : IEntity
    {

        /// <summary>
        /// Retrieve the shooter of this projectile.
        /// </summary>
        /// <returns>The shooter of this projectile</returns>
        IProjectileSource GetShooter();

        /// <summary>
        /// Set the shooter of this projectile.
        /// </summary>
        /// <param name="source">The shooter of this projectile</param>
        void SetShooter(IProjectileSource source);
        
        /// <summary>
        /// Gets whether or not this projectile should bounce when it hits something.
        /// </summary>
        /// <returns>Whether or not the projectile bounces</returns>
        bool DoesBounce();
        
        /// <summary>
        /// Sets whether or not this projectile should bounce when it hits something.
        /// </summary>
        /// <param name="bounces">Whether or not the projectile bounces</param>
        void SetBounce(bool bounces);
    }
}