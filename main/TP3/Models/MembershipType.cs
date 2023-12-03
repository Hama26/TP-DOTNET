using System;
using System.Collections.Generic;

namespace TP3.Models;

public partial class MembershipType
{
    public int Id { get; set; }

    public decimal SignUpFee { get; set; }

    public int DurationInMonths { get; set; }

    public decimal DiscountRate { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
