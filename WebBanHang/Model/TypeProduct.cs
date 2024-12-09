using System;
using System.Collections.Generic;

namespace WebBanHang.Model;

public partial class TypeProduct
{
    public int TypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
