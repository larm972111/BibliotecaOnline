namespace BibliotecaOnline.Models;
using Microsoft.AspNetCore.Identity;

public class LibraryMember
{
    public int Id {get; set; }

    public required string Name {get; set; }

    public required string Surname {get; set; }

    public ICollection<Loan> Loans { get; set; } = new List<Loan>();

    public string? IdentityUserId { get; set; }

    public IdentityUser? IdentityUser { get; set; }
}