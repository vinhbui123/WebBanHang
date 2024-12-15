using System;
using System.Collections.Generic;

namespace WebBanHang.Model;

public partial class Orders
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public decimal TotalPrice { get; set; }

    public string OrderStatus { get; set; } = null!;

    public int PaymentMethodId { get; set; }

    public DateOnly OrderDate { get; set; }

    public DateOnly? ReceivedDate { get; set; }

    public bool Ship { get; set; }

    public int StoreId { get; set; }

    public string? Note { get; set; }

    public virtual Customers Customer { get; set; } = null!;

    public virtual ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();

    public virtual PaymentMethod PaymentMethod { get; set; } = null!;

    public virtual ICollection<Ship> Ships { get; set; } = new List<Ship>();
}
