using System.ComponentModel.DataAnnotations;

namespace FilmVault.Models;

public class Director
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

    public bool IsAwardWinner { get; set; }
}
