using AutoMapper;
using BookMovieTicket.Dto;
using BookMovieTicket.Models;
using BookMovieTicket.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BookMovieTicket.Controllers;

[ApiController]
[Route("[controller]")]
public class TheatresController(TheatreService service, MoviesService moviesService, IMapper mapper): ControllerBase
{

    [HttpGet]
    public IEnumerable<MovieTheater> GetMovieTheatres()
    {
        return service.GetMovieTheaters();
    }
    
    [HttpGet("{id}")]
    public ActionResult<MovieTheater> GetMovieTheatre(int id)
    {
        var theatre = service.GetMovieTheatre(id);
        if (theatre is null)
            return NotFound();
        return theatre;
    }

    [HttpPost]
    public IActionResult CreateMovieTheatres(MovieTheater newTheater)
    {
        var theatre = service.Create(newTheater);
        return CreatedAtAction(nameof(GetMovieTheatre), new { id = theatre!.Id }, theatre);
    }

    [HttpGet("screen/{id}")]
    public ActionResult<TheatreScreen> GetTheatreScreen(int id)
    {
        var screen = service.GetTheatreScreen(id);
        if (screen is null)
            return NotFound();
        return screen;
    }

    [HttpPost("screen")]
    public IActionResult CreateTheatreScreen(TheatreScreen theatreScreen)
    {
        var screen = service.Create(theatreScreen);
        return CreatedAtAction(nameof(GetTheatreScreen), new { id = screen!.Id }, screen);
    }
    

    [HttpGet("shows/{movieId}")]
    public IEnumerable<Show> GetShows(string movieId)
    {
        var movie = moviesService.GetMovieById(movieId);
        if (movie is null)
            return [];
        return service.GetShows(movieId);
    }

    [HttpGet("show/{showId}")]
    public ActionResult<ShowDto> GetShow(int showId)
    {
        var show = service.GetShow(showId);
        if (show is null)
            return NotFound();
        var showResponse = new ShowDto
        {
            Id = show.Id,
            Movie = show.Movie,
            ShowTime = show.ShowTime,
            Theatre = show.Theatre,
        };
        return showResponse;
    }

    [HttpPost("show")]
    public IActionResult CreateShow([FromBody] CreateShowDto showDto)
    {
        var movie = moviesService.GetMovieById(showDto.MovieId);
        if (movie is null)
            return BadRequest("movieId is incorrect");
        var screen = service.GetTheatreScreen(showDto.ScreenId);
        if (screen is null)
            return BadRequest("screenId is incorrect");
        var newShow = new Show
        {
            MovieId = showDto.MovieId,
            ShowTime = showDto.ShowTime,
            ScreenId = showDto.ScreenId,
            TheatreId = showDto.TheatreId
        };
        service.CreateShow(newShow);
        return CreatedAtAction(nameof(GetShow), new { showId = newShow!.Id }, newShow);
    }
}