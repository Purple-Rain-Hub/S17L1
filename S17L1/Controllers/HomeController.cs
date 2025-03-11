using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using S17L1.Models;
using S17L1.Services;
using S17L1.ViewModel;

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

        public IActionResult AddPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPageViewModel addPageViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Errore nel modello del form";
                return RedirectToAction("AddPage");
            }

            var result = await _bookService.AddBookAsync(addPageViewModel);

            if (!result)
            {
                TempData["Error"] = "errore nel salvataggio dell'entit� nel Db";
                return RedirectToAction("AddPage");
            }

            return RedirectToAction("Index");
        }

        [Route("book/details/{id:guid}")]
        public async Task<IActionResult> DetailsPage(Guid id)
        {
            var book = await _bookService.GetBookById(id);
            if (book == null)
            {
                TempData["Error"] = "Errore nel trovare l'entit� nel Db";
                return RedirectToAction("Index");
            }

            var bookDetails = new DetailsPageViewModel()
            {
                Id = book.Id,
                Titolo = book.Titolo,
                Autore = book.Autore,
                Genere = book.Genere,
                Disponibilita = book.Disponibilita,
                Copertina = book.Copertina
            };
            return View(bookDetails);

        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _bookService.DeleteBookById(id);

            if (!result)
            {
                TempData["Error"] = "Errore durante la delete dell'entit� dal Db";
            }

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> EditPage(Guid id)
        {
            var book = await _bookService.GetBookById(id);

            EditPageViewModel bookEdit = new()
            {
                Id = id,
                Autore = book.Autore,
                Titolo = book.Titolo,
                Genere = book.Genere,
                Disponibilita = book.Disponibilita,
                Copertina= book.Copertina
            };

            return View(bookEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, EditPageViewModel model)
        {
            var result = await _bookService.UpdateBook(id, model);

            if (!result)
            {
                TempData["Error"] = "Errore nella modifica dell'entit� sul Db";
            }

            return RedirectToAction("Index");
        }
    }
}
