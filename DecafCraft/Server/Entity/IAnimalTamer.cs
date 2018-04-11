using System;

namespace DecafCraft.Server.Entity
{
    public interface IAnimalTamer
    {
        string GetName();
        Guid GetUniqueId();
    }
}