using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class Store
{
    public int StoreId { get; set; }

    public string StoreName { get; set; } = null!;

    public string StoreAddress { get; set; } = null!;

    public string? Thumb { get; set; }

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
