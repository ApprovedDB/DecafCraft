namespace DecafCraft.Server.Network
{
    public abstract class Packet
    {
        public int IncomingId;
        public int OutgoingId;

        public virtual void RegisterPacket(int packetInId = 0x0, int packetOutId = 0x0)
        {
            IncomingId = packetInId;
            OutgoingId = packetOutId;
        }

        public virtual void Enque()
        {
            
        }
    }
}