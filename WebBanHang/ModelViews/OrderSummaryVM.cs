using System;
using System.Collections.Generic;
using WebBanHang.Model;

namespace WebBanHang.ViewModels
{
	public class OrderSummaryVM
	{
		public int OrderId { get; set; }
		public DateTime OrderDate { get; set; }
		public decimal TotalPrice { get; set; }
		public string OrderStatus { get; set; } = string.Empty;
		public List<OrderItemVM> Items { get; set; } = new List<OrderItemVM>();
	}
}
