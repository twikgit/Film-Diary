using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Status
{
    public string StatusCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<FriendshipStatus> FriendshipStatuses { get; set; } = new List<FriendshipStatus>();
}
