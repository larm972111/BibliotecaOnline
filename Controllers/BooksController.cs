using Microsoft.AspNetCore.Mvc;
using BibliotecaOnline.Data; 
using BibliotecaOnline.Models;

namespace BibliotecaOnline.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Protezione da attacchi CSRF
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                
                _context.SaveChanges();
                
                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }
    }
}