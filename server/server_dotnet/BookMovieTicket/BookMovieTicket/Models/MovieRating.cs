using System;
using System.Collections.Generic;

namespace BookMovieTicket.Models;

public partial class MovieRating
{
    public string ImdbId { get; set; } = null!;

    public decimal? ImdbRating { get; set; }

    public int? ImdbVotes { get; set; }

    public virtual Movie Imdb { get; set; } = null!;
}
