using System;
using System.Collections.Generic;

namespace WebBanHang.Model;

public partial class Promotion
{
    public int PromotionId { get; set; }

    public string PromotionName { get; set; } = null!;

    public decimal PromotionDiscounts { get; set; }

    public string? Thumb { get; set; }

    public DateOnly StartDay { get; set; }

    public DateOnly EndDay { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Products> Products { get; set; } = new List<Products>();
}
