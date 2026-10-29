using Microsoft.EntityFrameworkCore;
using BibliotecaOnline.Models;

namespace BibliotecaOnline.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Book> Books { get; set; } = default!;
    public DbSet<BookCopy> BookCopies { get; set; } = default!;
    public DbSet<LibraryMember> LibraryMembers { get; set; } = default!;
    public DbSet<Loan> Loans { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookCopy>()
            .HasOne(copy => copy.Book)
            .WithMany()
            .HasForeignKey(copy => copy.BookId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Loan>()
            .HasOne(loan => loan.BookCopy)
            .WithMany()
            .HasForeignKey(loan => loan.BookCopyId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Loan>()
            .HasOne(loan => loan.LibraryMember)
            .WithMany(member => member.Loans)
            .HasForeignKey(loan => loan.LibraryMemberId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}