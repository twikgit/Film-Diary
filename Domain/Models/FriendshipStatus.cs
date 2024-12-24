using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class FriendshipStatus
{
    public int RequesterId { get; set; }

    public int AddresseeId { get; set; }

    public DateTime SpecifiedDatetime { get; set; }

    public string StatusCode { get; set; } = null!;

    public int SpecifiedId { get; set; }

    public virtual Friendship Friendship { get; set; } = null!;

    public virtual Customer Specified { get; set; } = null!;

    public virtual Status StatusCodeNavigation { get; set; } = null!;
}
