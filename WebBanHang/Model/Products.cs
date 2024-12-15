using System;
using System.Collections.Generic;

namespace WebBanHang.Model;

public partial class Products
{
    public int ProductId { get; set; }

    public int UnitInStock { get; set; }

    public string? Thumb { get; set; }

    public string ProductName { get; set; } = null!;

    public string? SpecialStatus { get; set; }

    public decimal Price { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();

    public virtual ProductDetails ProductNavigation { get; set; } = null!;

    public virtual Stocks? Stock { get; set; }

    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();
}
