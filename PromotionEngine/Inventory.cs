using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
    public class Inventory : IInventory
    {
        public List<Item> SKUInventory { get; } = new List<Item>();
        public void AddSKUs(Item item) => SKUInventory.Add(item);
    }
}
