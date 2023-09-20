using System;
using System.Collections.Generic;

namespace SWPProjekt.Model;

public partial class Complaint
{
    public int Id { get; set; }

    public string Subject { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Userid { get; set; }

    public int? Responseid { get; set; }

    public virtual Response? Response { get; set; }

    public virtual User User { get; set; } = null!;
}
