using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    public class Cart : ICart
    {
        public int TotalCost { get; set; }
        private IInventory Inventory { get; set; }
        private IPromotions Promotions { get; set; }
        private Dictionary<Item, int> CartItems { get; } = new Dictionary<Item, int>();

        public Cart(IInventory inventory, IPromotions promotion)
        {
            Inventory = inventory;
            Promotions = promotion;
        }
   
        public void AddToCart(Item item, int quantity)
        {
            if(Inventory.SKUInventory.Contains(item))
                CartItems.Add(item, quantity);
        }

        public void ApplyPromotion()
        {
            SetTotalCost();

            foreach (Promotion promotion in Promotions.Promotions)
            {
                if (CartItems.ContainsKey(promotion.Item))
                {
                    if (promotion.Item2 == null)
                        TotalCost -= ((CartItems[promotion.Item] / promotion.Quantity) * promotion.Discount);                   
                    else if(CartItems.ContainsKey(promotion.Item2))
                        TotalCost -= (promotion.Discount * Math.Min(CartItems[promotion.Item], CartItems[promotion.Item2]));
                }
            }
        }

        private void SetTotalCost()
        {
            foreach (var cart in CartItems)
                TotalCost += (cart.Value * cart.Key.Price);
        }
    }
}
