using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class UserListStatus
{
    public int UserListStatusId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<UserList> UserLists { get; set; } = new List<UserList>();
}
