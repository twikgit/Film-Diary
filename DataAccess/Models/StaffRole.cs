using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class StaffRole
{
    public int StaffRoleId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
