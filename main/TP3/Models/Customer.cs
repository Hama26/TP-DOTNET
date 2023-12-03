using System;
using System.Collections.Generic;

namespace TP3.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Membershiptype { get; set; }

    public virtual MembershipType? MembershiptypeNavigation { get; set; }
}
