using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class Ship
{
    public int ShipId { get; set; }

    public int ShipperId { get; set; }

    public string ShipStatus { get; set; } = null!;

    public DateOnly OrderDate { get; set; }

    public string ShippingAddresses { get; set; } = null!;

    public DateOnly ExpectedDeliveryDate { get; set; }

    public string? Note { get; set; }

    public virtual Order Shipper { get; set; } = null!;
}
