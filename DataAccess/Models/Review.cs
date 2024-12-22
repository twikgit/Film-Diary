using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int CustomerId { get; set; }

    public int MovieId { get; set; }

    public string ReviewContent { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public int? DeletedBy { get; set; }

    public virtual Customer CreatedByNavigation { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Customer? DeletedByNavigation { get; set; }

    public virtual Movie Movie { get; set; } = null!;

    public virtual Customer? UpdatedByNavigation { get; set; }
}
