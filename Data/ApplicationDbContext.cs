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
}