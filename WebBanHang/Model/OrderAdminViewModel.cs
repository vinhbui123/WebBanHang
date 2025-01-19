namespace WebBanHang.Model
{
	public class OrderAdminViewModel
	{

		public Order Order { get; set; }
		public List<OrderItem> OrderItems { get; set; }
		
		public Ship? Ship { get; set; }
	}
}
