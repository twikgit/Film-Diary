using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Role
{
    public short RoleId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
