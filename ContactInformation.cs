using System;
using System.Collections.Generic;

namespace project3WithDBFirstAndLinq.Models;

public partial class ContactInformation
{
    public int? Uid { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? AlternatePhoneNumber { get; set; }

    public string? EmergencyContactName { get; set; }

    public string? EmergencyContactRelation { get; set; }

    public string? EmergencyContactPhone { get; set; }

    public string? LinkedInProfile { get; set; }

    public string? FacebookProfile { get; set; }

    public string? TwitterHandle { get; set; }

    public virtual PersonalInfo? UidNavigation { get; set; }
}
