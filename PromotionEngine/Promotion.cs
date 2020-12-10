using System.Collections.Generic;

namespace PromotionEngine
{
    public class Promotion : IPromotions
    {
        public Item Item { get; set; }
        public int Quantity { get; set; } 
        public Item Item2 { get; set; }
        public char UnitId2 { get; set; }
        public int Discount { get; set; }
        public List<Promotion> Promotions { get; set; } = new List<Promotion>();

        public void AddPromotion(Item item, int quantity, int discount)
        {
            Promotions.Add(new Promotion() { Item = item, Quantity = quantity, Discount = discount});
        }

        public void AddPromotion(Item item1, Item item2, int discount)
        {
            Promotions.Add(new Promotion() { Item = item1, Item2 = item2, Discount = discount });
        }
    }
}
