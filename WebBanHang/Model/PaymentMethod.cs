﻿using System;
using System.Collections.Generic;

namespace WebBanHang.Model;

public partial class PaymentMethod
{
    public int PaymentMethodId { get; set; }

    public string PaymentMethodName { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}