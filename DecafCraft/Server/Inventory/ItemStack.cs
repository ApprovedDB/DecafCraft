using System;

namespace DecafCraft.Server.Inventory
{
    public class ItemStack : ICloneable
    {
        public byte ItemCount { get; set; }
        public int ItemId { get; set; }
        public byte NbtData { get; set; }
        public byte MetaData { get; set; }
        
        public object Clone()
        {
            return this;
        }
    }
}