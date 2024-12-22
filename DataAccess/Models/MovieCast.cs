using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class MovieCast
{
    public int ActorId { get; set; }

    public int MovieId { get; set; }

    public string? CharacterName { get; set; }

    public virtual Actor Actor { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;
}
