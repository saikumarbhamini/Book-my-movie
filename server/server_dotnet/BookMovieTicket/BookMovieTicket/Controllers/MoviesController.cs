using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookMovieTicket.Data;
using BookMovieTicket.Models;
using BookMovieTicket.Services;

namespace BookMovieTicket.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private readonly MoviesService _service;
    public MoviesController(MoviesService service)
    {
        _service=service;
    }

    [HttpGet]
    public IEnumerable<Movie> GetMovies()
    {
        return _service.GetAllMovies();
    }

    [HttpGet("{id}")]
    public ActionResult<Movie?> GetMovieById(string id)
    {
        var movie = _service.GetMovieById(id);
        if (movie is null)
            return NotFound();
        return movie;
    }
}