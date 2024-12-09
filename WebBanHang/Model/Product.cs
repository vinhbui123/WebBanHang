﻿using System;
using System.Collections.Generic;

namespace WebBanHang.Model;

public partial class Product
{
    public int ProductId { get; set; }

    public int TypeId { get; set; }

    public int UnitInStock { get; set; }

    public string? Thumb { get; set; }

    public string ProductName { get; set; } = null!;

    public string? SpecialStatus { get; set; }

    public decimal Price { get; set; }

    public decimal? PriceDiscounts { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ProductDetail ProductNavigation { get; set; } = null!;

    public virtual Stock? Stock { get; set; }

    public virtual TypeProduct Type { get; set; } = null!;

    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();
}
