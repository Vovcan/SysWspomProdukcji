using System;
using System.Collections.Generic;

namespace SWPProjekt.Model;

public partial class Task
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime? CreationDate { get; set; }

    public DateTime? Deadline { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? FinishDate { get; set; }

    public int Priority { get; set; }

    public int TaskStatus { get; set; }

    public int Productionid { get; set; }

    public virtual Production Production { get; set; } = null!;

    public virtual ICollection<TaskUser> TaskUsers { get; set; } = new List<TaskUser>();
}
