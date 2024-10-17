using FilmVault.Services;
using FilmVault.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmVault.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    MovieService _service;

    public MovieController(MovieService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<Movie> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Movie> GetById(int id)
    {
        var Movie = _service.GetById(id);

        if (Movie is not null)
        {
            return Movie;
        }
        else
        {
            return NotFound();
        }
    }


    [HttpPost]
    public IActionResult Create(Movie newMovie)
    {
        var Movie = _service.Create(newMovie);
        return CreatedAtAction(nameof(GetById), new { id = Movie!.Id }, Movie);
    }

    [HttpPut("{id}/addGenre")]
    public IActionResult AddGenre(int id, int genreId)
    {
        var MovieToUpdate = _service.GetById(id);

        if (MovieToUpdate is not null)
        {
            _service.AddGenre(id, genreId);
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPut("{id}/updateDirector")]
    public IActionResult UpdateDirector(int id, int directorId)
    {
        var MovieToUpdate = _service.GetById(id);

        if (MovieToUpdate is not null)
        {
            _service.UpdateDirector(id, directorId);
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var Movie = _service.GetById(id);

        if (Movie is not null)
        {
            _service.DeleteById(id);
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }
}