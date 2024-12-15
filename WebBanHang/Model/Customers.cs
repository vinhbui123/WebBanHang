using System;
using System.Collections.Generic;

namespace WebBanHang.Model;

public partial class Customers
{
    public int CustomerId { get; set; }

    public string FullName { get; set; } = null!;

    public DateTime? Birthday { get; set; }

    public string? Avatar { get; set; }

    public string? Address { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int? LocationId { get; set; }

    public int? District { get; set; }

    public int? Ward { get; set; }

    public DateTime? CreateDate { get; set; }

    public string Password { get; set; } = null!;

    public string? Salt { get; set; }

    public DateTime? LastLogin { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();
}
