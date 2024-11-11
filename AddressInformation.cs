using System;
using System.Collections.Generic;

namespace project3WithDBFirstAndLinq.Models;

public partial class AddressInformation
{
    public int? Uid { get; set; }

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public string? Country { get; set; }

    public string? ResidentialStatus { get; set; }

    public int? DurationOfStayYears { get; set; }

    public virtual MemberInformation? UidNavigation { get; set; }
}
