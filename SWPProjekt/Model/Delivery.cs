using System;
using System.Collections.Generic;

namespace SWPProjekt.Model;

public partial class Delivery
{
    public int Id { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public float Amount { get; set; }

    public int CurrentAmount { get; set; }

    public float FullPrice { get; set; }

    public float PriceByUnit { get; set; }

    public int DeliveryNumber { get; set; }

    public int Unitid { get; set; }

    public int Productid { get; set; }

    public int Warehouseid { get; set; }

    public virtual ICollection<LostProduct> LostProducts { get; set; } = new List<LostProduct>();

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<ProductionDelivery> ProductionDeliveries { get; set; } = new List<ProductionDelivery>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual Unit Unit { get; set; } = null!;

    public virtual Warehouse Warehouse { get; set; } = null!;
}
