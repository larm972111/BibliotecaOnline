namespace BibliotecaOnline.Models;

public class LibraryMember
{
    public int Id {get; set; }

    public required string Name {get; set; }

    public required string Surname {get; set; }

    public ICollection<Loan> Loans { get; set; } = new List<Loan>();
}