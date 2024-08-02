using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookMovieTicket.Models;

public partial class MovieAdditionalInfo
{
    public string ImdbId { get; set; } = null!;

    public string? Story { get; set; }

    public string? Summary { get; set; }

    public string? Tagline { get; set; }

    public string? Actors { get; set; }

    public string? WinsNominations { get; set; }

    public DateOnly? ReleaseDate { get; set; }
    [JsonIgnore]
    public virtual Movie Imdb { get; set; } = null!;
}
