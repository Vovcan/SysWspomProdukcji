using System;
using System.Collections.Generic;

namespace SWPProjekt.Model;

public partial class Production
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime? StartDate { get; set; }

    public DateTime? PlannedFinishDate { get; set; }

    public DateTime? FinishDate { get; set; }

    public float OtherPayments { get; set; }

    public float ProductionPrice { get; set; }

    public int Projectid { get; set; }

    public virtual ICollection<ProductionDelivery> ProductionDeliveries { get; set; } = new List<ProductionDelivery>();

    public virtual ICollection<ProductionManager> ProductionManagers { get; set; } = new List<ProductionManager>();

    public virtual Project Project { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual ICollection<WorkingHour> WorkingHours { get; set; } = new List<WorkingHour>();
}
