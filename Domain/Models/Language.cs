using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Language
{
    public int LanguageId { get; set; }

    public string Code { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
