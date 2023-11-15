using System;
using System.Collections.Generic;

namespace SWPProjekt.Model;

public partial class Sale
{
    public int Id { get; set; }

    public DateTime? DateOfSale { get; set; }

    public float Amount { get; set; }

    public float Price { get; set; }

    public int Deliveryid { get; set; }

    public virtual Delivery Delivery { get; set; } = null!;
}
