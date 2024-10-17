using FilmVault.Data;
using FilmVault.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmVault.Services;

public class MovieService
{
    private readonly MovieContext _context;

    public MovieService(MovieContext context)
    {
        _context = context;
    }

    public IEnumerable<Movie> GetAll()
    {
        return _context.Movies
            .AsNoTracking()
            .ToList();
    }

    public Movie? GetById(int id)
    {
        return _context.Movies
            .Include(m => m.Genres)
            .Include(m => m.Director)
            .AsNoTracking()
            .SingleOrDefault(m => m.Id == id);
    }

    public Movie? Create(Movie newMovie)
    {
        _context.Movies.Add(newMovie);
        _context.SaveChanges();

        return newMovie;
    }

    public void AddGenre(int movieId, int genreId)
    {
        var movieToUpdate = _context.Movies.Find(movieId);
        var genreToAdd = _context.Genres.Find(genreId);

        if (movieToUpdate is null || genreToAdd is null)
        {
            throw new InvalidOperationException("Movie or genre does not exist");
        }

        if (movieToUpdate.Genres is null)
        {
            movieToUpdate.Genres = new List<Genre>();
        }

        movieToUpdate.Genres.Add(genreToAdd);
        _context.SaveChanges();
    }

    public void UpdateDirector(int movieId, int directorId)
    {
        var movieToUpdate = _context.Movies.Find(movieId);
        var directorToUpdate = _context.Directors.Find(directorId);

        if (movieToUpdate is null || directorToUpdate is null)
        {
            throw new InvalidOperationException("Movie or director does not exist");
        }

        movieToUpdate.Director = directorToUpdate;
        _context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var movieToDelete = _context.Movies.Find(id);

        if (movieToDelete is not null)
        {
            _context.Movies.Remove(movieToDelete);
            _context.SaveChanges();
        }
    }
}
