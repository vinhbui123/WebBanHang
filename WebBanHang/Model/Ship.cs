using System;
using System.Collections.Generic;

namespace WebBanHang.Model;

public partial class Ship
{
    public int OrderId { get; set; }

    public int ShipId { get; set; }

    public int ShipperId { get; set; }

    public string ShippingAddresses { get; set; } = null!;

    public DateOnly ExpectedDeliveryDate { get; set; }

    public string ShipStatus { get; set; } = null!;

    public virtual Orders Shipper { get; set; } = null!;
}
