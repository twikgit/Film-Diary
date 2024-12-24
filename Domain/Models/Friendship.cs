using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Friendship
{
    public int RequesterId { get; set; }

    public int AddresseeId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Customer Addressee { get; set; } = null!;

    public virtual ICollection<FriendshipStatus> FriendshipStatuses { get; set; } = new List<FriendshipStatus>();

    public virtual Customer Requester { get; set; } = null!;
}
