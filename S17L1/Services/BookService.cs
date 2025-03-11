using S17L1.Data;
using S17L1.ViewModel;
using S17L1.Models;
using Microsoft.EntityFrameworkCore;

namespace S17L1.Services
{
    public class BookService
    {
        private readonly EpiBooksDbContext _context;

        public BookService(EpiBooksDbContext context) { _context = context; }

        private async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<BooksViewModel> GetAllBooksAsync()
        {
            try
            {
                var booksList = new BooksViewModel();

                booksList.Books = await _context.Books.ToListAsync();

                return booksList;
            }
            catch
            {
                return new BooksViewModel() { Books = new List<Book>() };
            }
        }

        public async Task<bool> AddBookAsync(AddPageViewModel addPageViewModel)
        {
            var book = new Book()
            {
                Id = Guid.NewGuid(),
                Titolo = addPageViewModel.Titolo,
                Autore = addPageViewModel.Autore,
                Genere = addPageViewModel.Genere,
                Disponibilita = addPageViewModel.Disponibilita,
                Copertina = addPageViewModel.Copertina
            };

            _context.Books.Add(book);

            return await SaveAsync();
        }

        public async Task<Book?> GetBookById(Guid id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return null;
            }

            return book;
        }

        public async Task<bool> DeleteBookById(Guid id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return false;
            }

            _context.Books.Remove(book);
            return await SaveAsync();
        }

        public async Task<bool> UpdateBook(Guid id, EditPageViewModel editPageViewModel)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return false;
            }

            book.Id = id;
            book.Titolo = editPageViewModel.Titolo;
            book.Autore = editPageViewModel.Autore;
            book.Genere = editPageViewModel.Genere;
            book.Disponibilita = editPageViewModel.Disponibilita;
            book.Copertina = editPageViewModel.Copertina;

            return await SaveAsync();
        }
    }
}
