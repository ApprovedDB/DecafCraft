using System.Collections.Concurrent;

namespace DecafCraft.Server.Network
{
    public class PacketHandler
    {
        public ConcurrentQueue<Packet> PacketQueue = new ConcurrentQueue<Packet>();
    }
}