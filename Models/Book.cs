using System.ComponentModel.DataAnnotations;

namespace BibliotecaOnline.Models;

public class Book : IValidatableObject
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Il titolo è obbligatorio")]
    public required string Title { get; set; }
    
    [Required(ErrorMessage = "L'autore è obbligatorio")]
    public required string Author { get; set; } 
    
    [Required(ErrorMessage = "L'anno di pubblicazione è obbligatorio")]
    public required int ReleaseYear { get; set; }
    
    [Required(ErrorMessage = "Il genere è obbligatorio")]
    public required string  Genre { get; set; } 

    [Required(ErrorMessage = "L'ISBN è obbligatorio")]
    [StringLength(13, MinimumLength = 10, ErrorMessage = "L'ISBN deve essere tra 10 e 13 caratteri")]
    public required string Isbn { get; set; }

    [Url(ErrorMessage = "Inserisci un URL valido")]
    [StringLength(100, ErrorMessage = "L'URL non può superare i 100 caratteri.")]
    public string? CoverUrl { get; set; } 

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        int currentYear = DateTime.Now.Year;

        if (ReleaseYear < 1000 || ReleaseYear > currentYear)
        {
            yield return new ValidationResult(
                "Inserisci un anno di pubblicazione valido.",
                new[] { nameof(ReleaseYear) }
            );
        }
    }
}