using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookMovieTicket.Data;
using BookMovieTicket.Models;
using BookMovieTicket.Services;

namespace BookMovieTicket.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController(MoviesService service) : ControllerBase
{
    [HttpGet]
    public IEnumerable<Movie> GetMovies()
    {
        return service.GetAllMovies();
    }

    [HttpGet("{id}")]
    public ActionResult<Movie?> GetMovieById(string id)
    {
        var movie = service.GetMovieById(id);
        if (movie is null)
            return NotFound();
        return movie;
    }
    
    [HttpGet("movie-detail/{id}")]
    public ActionResult<MovieDetail?> GetMovieDetail(string id)
    {
        var movieDetail = service.GetMovieDetail(id);
        if (movieDetail is null)
            return NotFound();
        return movieDetail;
    }
}