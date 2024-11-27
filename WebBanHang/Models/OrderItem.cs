using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class OrderItem
{
    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public int Quantity { get; set; }

    public decimal ListPrice { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
