using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class MovieRating
{
    public int MovieRatingId { get; set; }

    public string Code { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
