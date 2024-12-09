﻿using System;
using System.Collections.Generic;

namespace WebBanHang.Model;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? FullName { get; set; }

    public string? Avatar { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? Password { get; set; }

    public bool Active { get; set; }

    public string? Salt { get; set; }

    public DateOnly? CreateDate { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
