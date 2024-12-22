using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Actor
{
    public int ActorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly? BirthDate { get; set; }

    public short? Height { get; set; }

    public string? Bio { get; set; }

    public string? Nationality { get; set; }

    public string? PhotoUrl { get; set; }

    public virtual ICollection<MovieCast> MovieCasts { get; set; } = new List<MovieCast>();

    public virtual Country? NationalityNavigation { get; set; }
}
