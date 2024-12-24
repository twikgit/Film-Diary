using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly? BirthDate { get; set; }

    public string? Bio { get; set; }

    public string? Nationality { get; set; }

    public int StaffRoleId { get; set; }

    public virtual Country? NationalityNavigation { get; set; }

    public virtual StaffRole StaffRole { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
