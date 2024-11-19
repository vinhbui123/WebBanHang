using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public int UnitInStock { get; set; }

    public string? Thumb { get; set; }

    public string? Videos { get; set; }

    public int TypeId { get; set; }

    public string? Tag { get; set; }

    public string? SpecialStatus { get; set; }

    public string? Color { get; set; }

    public string? Brand { get; set; }

    public string? Model { get; set; }

    public DateOnly ModelYear { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public decimal PriceDiscounts { get; set; }

    public string? Cover { get; set; }

    public string ProductName { get; set; } = null!;

    public string ProductStatus { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Stock? Stock { get; set; }

    public virtual TypeProduct Type { get; set; } = null!;

    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();
}
