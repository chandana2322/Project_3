using System;
using System.Collections.Generic;

namespace project3WithDBFirstAndLinq.Models;

public partial class Educationinfo
{
    public int? Uid { get; set; }

    public string? HighSchoolName { get; set; }

    public int? HighSchoolGraduationYear { get; set; }

    public string? UniversityName { get; set; }

    public string? Degree { get; set; }

    public string? Major { get; set; }

    public int? GraduationYear { get; set; }

    public decimal? Gpa { get; set; }

    public string? Certifications { get; set; }

    public string? Scholarships { get; set; }

    public virtual PersonalInfo? UidNavigation { get; set; }
}
