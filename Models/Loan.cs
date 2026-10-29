namespace BibliotecaOnline.Models;

public class Loan
{
    public int Id { get; set; }

    public int LibraryMemberId { get; set; }
    public LibraryMember LibraryMember { get; set; } = null!;

    public int BookCopyId { get; set; }
    public BookCopy BookCopy { get; set; } = null!;

    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnedAt { get; set; }
}