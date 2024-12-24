using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public string Title { get; set; } = null!;

    public DateOnly ReleaseDate { get; set; }

    public int Duration { get; set; }

    public string Description { get; set; } = null!;

    public int? Rating { get; set; }

    public long? Budget { get; set; }

    public long? Revenue { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public int? DeletedBy { get; set; }

    public string? PosterUrl { get; set; }

    public bool IsAiring { get; set; }

    public virtual Customer? CreatedByNavigation { get; set; }

    public virtual Customer? DeletedByNavigation { get; set; }

    public virtual ICollection<MovieCast> MovieCasts { get; set; } = new List<MovieCast>();

    public virtual MovieRating? RatingNavigation { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual Customer? UpdatedByNavigation { get; set; }

    public virtual ICollection<UserList> UserLists { get; set; } = new List<UserList>();

    public virtual ICollection<Country> CountryCodes { get; set; } = new List<Country>();

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();

    public virtual ICollection<Language> Languages { get; set; } = new List<Language>();

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
