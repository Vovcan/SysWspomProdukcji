using System;
using System.Collections.Generic;

namespace SWPProjekt.Model;

public partial class LostProduct
{
    public int Id { get; set; }

    public float Amount { get; set; }

    public DateTime? Date { get; set; }

    public int Deliveryid { get; set; }

    public virtual Delivery Delivery { get; set; } = null!;

    public LostProduct( float amount, DateTime date, int Deliveryid)
    {
        Amount = amount;
        Date = date == default ? DateTime.Now : date;
        this.Deliveryid = Deliveryid;
    }
    public LostProduct()
    {
        
    }
}
