using S17L1.Data;
using S17L1.ViewModel;
using S17L1.Models;
using Microsoft.EntityFrameworkCore;

namespace S17L1.Services
{
    public class BookService
    {
        private readonly EpiBooksDbContext _context;

        public BookService(EpiBooksDbContext context) {  _context = context; }

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
                return new BooksViewModel() { Books = new List<Book>()};
            }
        }
    }
}
