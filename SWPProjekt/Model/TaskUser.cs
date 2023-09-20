using System;
using System.Collections.Generic;

namespace SWPProjekt.Model;

public partial class TaskUser
{
    public int Id { get; set; }

    public int Taskid { get; set; }

    public int Userid { get; set; }

    public virtual Task Task { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
