using System;
using System.Collections.Generic;

namespace project3WithDBFirstAndLinq.Models;

public partial class PersonalInfo
{
    public int Uid { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? Nationality { get; set; }

    public string? MaritalStatus { get; set; }

    public string? Ssn { get; set; }

    public string? PassportNumber { get; set; }

    public string? Religion { get; set; }

    public string? Hobbies { get; set; }

    public virtual Bankdetail? Bankdetail { get; set; }

    public virtual MemberInformation UidNavigation { get; set; } = null!;

    //internal DateOnly? DateOfBirth(DateOnly? dateOfBirth)
    //{
      //  throw new NotImplementedException();
    //}
}
