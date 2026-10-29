using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaOnline.Models;

[Index(nameof(InventoryNumber), IsUnique = true)]
public class BookCopy
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;

    [Required(ErrorMessage = "Il numero inventariale è obbligatorio")]
    [RegularExpression(@"^B\d{2}-\d{3}$", ErrorMessage = "Formato previsto (es. B01-012).")]
    public required string InventoryNumber { get; set; }

}