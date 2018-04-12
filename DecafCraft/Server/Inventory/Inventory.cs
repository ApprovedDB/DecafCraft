using System.Collections.Generic;
using System.Linq;
using DecafCraft.Server.Entity;
using DecafCraft.Utils;

namespace DecafCraft.Server.Inventory
{
    public class Inventory
    {
        private readonly int _size;
        private byte _maxStackSize;
        private string _name;
        private string _title;
        private readonly ItemStack[] _items;

        public int GetInventorySize() => _size;
        public byte GetMaxStackSize() => _maxStackSize;
        public void SetMaxStackSize(byte stackSize) => _maxStackSize = stackSize;
        public string GetName() => _name;
        public string GetTitle() => _title;

        public ItemStack[] GetAllItems() => _items;

        public Inventory(int size)
        {
            _size = size;
            _items = new ItemStack[size];
        }

        public StatusReturn<bool> SetItemStackInSlot(int index, ItemStack itemStack = null)
        {
            if (index > _size) return new StatusReturn<bool>(false, "Index is larger than the size of the inventory");
            if (itemStack != null && itemStack.ItemCount == 0) return new StatusReturn<bool>(false, "ItemStack stack size must be greater than 0");
            return new StatusReturn<bool>(true, $"ItemStack successfully placed in slot {index}");
        }

        public StatusReturn<ItemStack> GetItemStackInSlot(int index)
        {
            return index > _size
                ? new StatusReturn<ItemStack>(null, "Index is larger than the size of the inventory")
                : new StatusReturn<ItemStack>(_items[index - 1]);
        }

        private int TryPutItem(ItemStack item)
        {
            if (item.ItemCount > _maxStackSize) item.ItemCount = _maxStackSize;
            if (!_items.Contains(item))
            {
                _items[GetEmptySlot()] = item;
                return 0;
            }

            foreach (ItemStack stack in _items)
            {
                if (!stack.Equals(item)) continue;
                stack.ItemCount = stack.ItemCount + item.ItemCount > (byte) 255
                    ? (byte) 255
                    : (byte) (stack.ItemCount + item.ItemCount);

                return stack.ItemCount + item.ItemCount - 255;
            }

            return item.ItemCount;
        }

        public StatusReturn<Dictionary<ItemStack, int>> PutItemsInInventory(IEnumerable<ItemStack> items)
        {
            Dictionary<ItemStack, int> extraItems = new Dictionary<ItemStack, int>();
            foreach (ItemStack stack in items)
            {
                int extra = TryPutItem(stack);
                if(extra > 0) extraItems.Add(stack, extra);
            }
            return extraItems.Count > 0 
                ? new StatusReturn<Dictionary<ItemStack, int>>(extraItems, "Some items were unable to be put in to the inventory")
                : new StatusReturn<Dictionary<ItemStack, int>>(extraItems, "All items were successfully put in to the inventory");
        }
        
        public int GetEmptySlot()
        {
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i].ItemCount == 0) return i;
            }
            return -1;
        }

        //TODO: Get a better name
        public int FindFirstSlotForStack(ItemStack stack)
        {
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i].Equals(stack)) return i;
            }
            return -1;
        }

        public Dictionary<int, ItemStack> GetAllItemStacks(ItemStack stack)
        {
            Dictionary<int, ItemStack> items = new Dictionary<int, ItemStack>();
            for (int i = 0; i < _items.Length; i++)
            {
                if(_items[i].Equals(stack)) items.Add(i, _items[i]);
            }

            return items;
        }
    }
}