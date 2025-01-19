using System;
using System.Collections.Generic;

namespace WebBanHang.Model;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public int Quantity { get; set; }

    public decimal ListPrice { get; set; }

    public virtual Order Order { get; set; } = null!;
}
