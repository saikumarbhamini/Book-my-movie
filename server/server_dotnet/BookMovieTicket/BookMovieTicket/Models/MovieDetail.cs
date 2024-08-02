using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BookMovieTicket.Models;

public partial class MovieDetail
{
    public string ImdbId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string? OriginalTitle { get; set; }

    public bool? IsAdult { get; set; }

    public int? YearOfRelease { get; set; }

    public int? Runtime { get; set; }

    public string? Genres { get; set; }
    [JsonIgnore]
    public virtual Movie Imdb { get; set; } = null!;
}
