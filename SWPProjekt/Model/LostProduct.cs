using System;
using System.Collections.Generic;

namespace SWPProjekt.Model;

public partial class LostProduct
{
    public int Id { get; set; }

    public float Amount { get; set; }

    public DateTime Date { get; set; }

    public int Deliveryid { get; set; }

    public virtual Delivery Delivery { get; set; } = null!;
}
