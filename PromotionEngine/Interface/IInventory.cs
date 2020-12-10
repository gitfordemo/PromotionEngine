using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
    public interface IInventory
    {
        void AddSKUs(Item item);
        List<Item> SKUInventory { get; }
    }
}
