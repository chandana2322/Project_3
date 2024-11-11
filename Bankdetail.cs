using System;
using System.Collections.Generic;

namespace project3WithDBFirstAndLinq.Models;

public partial class Bankdetail
{
    public int Uid { get; set; }

    public string? BankName { get; set; }

    public string? AccountNumber { get; set; }

    public string? BankBranch { get; set; }

    public string? Ifsccode { get; set; }

    public string? AccountType { get; set; }

    public string? AccountHolderName { get; set; }

    public string? SwiftCode { get; set; }

    public string? BankCountry { get; set; }

    public string? Currency { get; set; }

    public virtual PersonalInfo UidNavigation { get; set; } = null!;
}
