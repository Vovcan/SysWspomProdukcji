using System;
using System.Collections.Generic;

namespace SWPProjekt.Model;

public partial class Project
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime? StartDate { get; set; }

    public DateTime? FinishDate { get; set; }

    public DateTime? ProjectTime { get; set; }

    public int Userid { get; set; }

    public virtual ICollection<Production> Productions { get; set; } = new List<Production>();

    public virtual User User { get; set; } = null!;
}
