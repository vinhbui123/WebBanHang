namespace WebBanHang.ModelViews
{
    public class OrderVm
    {
        public PaymentUserInformationVM UserInformation { get; set; }
        public List<WebBanHang.ModelViews.CartItem> CartItems { get; internal set; }
        //public List<WebBanHang.ModelViews.CartItem> CartItems { get; set; }
    }
}
