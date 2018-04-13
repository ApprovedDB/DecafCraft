using System;
using DecafCraft.Utils;

namespace DecafCraft.Server.Entity
{
    public interface IEntity
    {
        Vector GetDirection();
        void SetAge(int ticks);
        Location GetLocation();
        bool SetPosition(Location location);
        void SpawnEntity();
        void DespawnEntity();
        void SetVolcity(Vector velocity);
        Vector GetVelocity();
        bool OnGround();
        int GetFireTicks();
        int GetMaxFireTicks();
        void SetFireTicks(int ticks);
        bool IsDead();
        bool IsValid();
        bool IsEmpty();
        bool Eject();
        double GetFallDistance();
        void SetFallDistance(double distance);
        void SetLastDamageCause();
        Guid GetUniqueId();
        void PlayEffect(); //TODO: Add EntityEffects
        EntityType GetType();
        IEntity GetPassenger();
        bool SetPassenger();
        bool IsInsideVehicle();
        bool LeaveVehicle();
        IEntity GetVehicle();
    }
}