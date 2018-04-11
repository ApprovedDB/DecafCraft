using DecafCraft.Server.Entity;
using DecafCraft.Utils;

namespace DecafCraft.Server.Projectiles
{
    public interface IProjectileSource
    {
        /// <summary>
        /// Launches an instance of IProjectile from the ProjectileSource.
        /// </summary>
        /// <param name="projectile">The projectile to be launched</param>
        /// <returns>The launched projectile</returns>
        IProjectile LaunchProjectile(IProjectile projectile);

        /// <summary>
        /// Launches an instance of IProjectile from the ProjectileSource.
        /// </summary>
        /// <param name="projectile">The projectile to be launched</param>
        /// <param name="velocity">The velocity with which to launch</param>
        /// <returns>The launched projectile</returns>
        IProjectile LaunchProjectile(IProjectile projectile, Vector velocity);
    }
}