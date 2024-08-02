using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BookMovieTicket.Models;

public partial class MovieRating
{
    public string ImdbId { get; set; } = null!;

    public decimal? ImdbRating { get; set; }

    public int? ImdbVotes { get; set; }
    
    [JsonIgnore]
    public virtual Movie Imdb { get; set; } = null!;
}
