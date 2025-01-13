using WebBanHang.Model;

namespace WebBanHang.ModelViews
{
    public class CartItem
    {
        public Model.Product product { get; set; }
        public int amount { get; set; }
        public decimal TotalPrice => amount * (product.PriceDiscounts.HasValue ? product.PriceDiscounts.Value : product.Price);

    }
}
