using System;
using System.Collections.Generic;

namespace WebBanHang.Model;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public decimal TotalPrice { get; set; }

    public string OrderStatus { get; set; } = null!;

    public string PaymentMethodName { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public DateOnly? ReceivedDate { get; set; }

    public bool Ship { get; set; }

    public int StoreId { get; set; }

    public string? Note { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual OrderItem? OrderItem { get; set; }
}
