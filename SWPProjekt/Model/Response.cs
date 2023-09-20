using System;
using System.Collections.Generic;

namespace SWPProjekt.Model;

public partial class Response
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int Userid { get; set; }

    public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();

    public virtual User User { get; set; } = null!;
}
