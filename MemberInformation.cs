using System;
using System.Collections.Generic;

namespace project3WithDBFirstAndLinq.Models;

public partial class MemberInformation
{
    public int Uid { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? Age { get; set; }

    public virtual PersonalInfo? PersonalInfo { get; set; }
}
