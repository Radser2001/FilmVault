using System.ComponentModel.DataAnnotations;

namespace FilmVault.Models;

public class Movie
{
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string? Title { get; set; }

    public Director? Director { get; set; }

    public ICollection<Genre>? Genres { get; set; }

    public bool IsAvailableIn4K { get; set; }
}
