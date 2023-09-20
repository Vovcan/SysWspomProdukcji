using System;
using System.Collections.Generic;

namespace SWPProjekt.Model;

public partial class JobTitle
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
