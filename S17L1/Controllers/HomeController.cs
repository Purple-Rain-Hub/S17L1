using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using S17L1.Models;
using S17L1.Services;

namespace S17L1.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookService _bookService;

        public HomeController(BookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var booksList = await _bookService.GetAllBooksAsync();
            return View(booksList);
        }
    }
}
