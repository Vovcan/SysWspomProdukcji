﻿using System;
using System.Collections.Generic;

namespace SWPProjekt.Model;

public partial class Warehouse
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Zip { get; set; } = null!;

    public int Full { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();
}