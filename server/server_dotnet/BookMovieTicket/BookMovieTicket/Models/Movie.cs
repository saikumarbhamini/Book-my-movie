using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BookMovieTicket.Models;

public partial class Movie
{
    public string Title { get; set; } = null!;

    public string ImdbId { get; set; } = null!;

    public string? PosterPath { get; set; }

    public string? WikiLink { get; set; }

    public virtual MovieAdditionalInfo? AdditionalInfo { get; set; }
    public virtual MovieDetail? MovieDetail { get; set; }
    public virtual MovieRating? MovieRating { get; set; }
    
    [JsonIgnore]
    public ICollection<Show>? Shows { get; set; } = null!;
}
