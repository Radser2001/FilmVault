using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmVault.Models;

public class Genre
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Name { get; set; }

    [JsonIgnore]
    public ICollection<Movie>? Movies { get; set; }
}
