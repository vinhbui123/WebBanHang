using System;
using System.Collections.Generic;

namespace WebBanHang.Model;

public partial class OrderItems
{
    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public int Quantity { get; set; }

    public decimal ListPrice { get; set; }

    public virtual Orders Order { get; set; } = null!;

    public virtual Products Products { get; set; } = null!;
}
