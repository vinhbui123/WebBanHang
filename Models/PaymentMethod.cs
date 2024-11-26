using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class PaymentMethod
{
    public int PaymentMethodId { get; set; }

    public string PaymentMethodName { get; set; } = null!;

    public string? Thumb { get; set; }
}
