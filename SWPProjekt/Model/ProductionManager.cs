using System;
using System.Collections.Generic;

namespace SWPProjekt.Model;

public partial class ProductionManager
{
    public int Id { get; set; }

    public int Productionid { get; set; }

    public int Userid { get; set; }

    public virtual Production Production { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
