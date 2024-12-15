using System;
using System.Collections.Generic;

namespace WebBanHang.Model;

public partial class ProductDetail
{
    public int ProductId { get; set; }

    public string? Videos { get; set; }

    public string? Color { get; set; }

    public string? Brand { get; set; }

    public string? Model { get; set; }

    public DateOnly? ModelYear { get; set; }

    public string? Description { get; set; }

    public virtual Product? Product { get; set; }
}
