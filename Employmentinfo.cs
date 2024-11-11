using System;
using System.Collections.Generic;

namespace project3WithDBFirstAndLinq.Models;

public partial class Employmentinfo
{
    public int? Uid { get; set; }

    public string? EmployerName { get; set; }

    public string? JobTitle { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? JobDescription { get; set; }

    public decimal? Salary { get; set; }

    public string? SupervisorName { get; set; }

    public string? SupervisorPhone { get; set; }

    public virtual PersonalInfo? UidNavigation { get; set; }
}
