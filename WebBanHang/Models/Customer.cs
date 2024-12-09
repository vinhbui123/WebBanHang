using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? FullName { get; set; }

    public string? Avatar { get; set; }

    public int AccountId { get; set; }

	public string? Password { get; set; }

	public bool IsActive { get; set; }

    public DateTime? Created { get; set; }

    public string Salt { get; set; }
	public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
