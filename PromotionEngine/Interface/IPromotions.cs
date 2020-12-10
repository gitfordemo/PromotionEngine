using System.Collections.Generic;

namespace PromotionEngine
{
    public interface IPromotions
    {
       List<Promotion> Promotions { get; set; }
       void AddPromotion(Item item, int quantity, int discount);
       void AddPromotion(Item item1, Item item2, int discount);
    }
}
