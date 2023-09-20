using System;
using System.Collections.Generic;

namespace SWPProjekt.Model;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public ulong TemporaryPassword { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public int PhoneNumber { get; set; }

    public string Email { get; set; } = null!;

    public ulong Active { get; set; }

    public int? SalaryByMonth { get; set; }

    public float? SalaryByHour { get; set; }

    public string Picture { get; set; } = null!;

    public int JobTitleid { get; set; }

    public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();

    public virtual JobTitle JobTitle { get; set; } = null!;

    public virtual ICollection<ProductionManager> ProductionManagers { get; set; } = new List<ProductionManager>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<Response> Responses { get; set; } = new List<Response>();

    public virtual ICollection<TaskUser> TaskUsers { get; set; } = new List<TaskUser>();

    public virtual ICollection<WorkingHour> WorkingHours { get; set; } = new List<WorkingHour>();
}
