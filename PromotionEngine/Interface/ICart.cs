namespace PromotionEngine
{
    public interface ICart
    {
        int TotalCost { get; set; }
        void AddToCart(Item item, int quantity);
        void ApplyPromotion();
    }
}
