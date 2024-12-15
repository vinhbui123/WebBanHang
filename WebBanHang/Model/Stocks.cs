using System;
using System.Collections.Generic;

namespace WebBanHang.Model;

public partial class Stocks
{
    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual Products Products { get; set; } = null!;
}
