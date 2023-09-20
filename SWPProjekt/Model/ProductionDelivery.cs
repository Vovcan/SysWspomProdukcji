using System;
using System.Collections.Generic;

namespace SWPProjekt.Model;

public partial class ProductionDelivery
{
    public int Id { get; set; }

    public ulong InOut { get; set; }

    public int Amount { get; set; }

    public DateTime Date { get; set; }

    public int Productionid { get; set; }

    public int Deliveryid { get; set; }

    public virtual Delivery Delivery { get; set; } = null!;

    public virtual Production Production { get; set; } = null!;
}
