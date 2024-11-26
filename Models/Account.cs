using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Salt { get; set; }

    public string? Avatar { get; set; }

    public string? AcccountName { get; set; }

    public int RoleId { get; set; }

    public bool? Active { get; set; }

    public virtual Role Role { get; set; } = null!;
}
