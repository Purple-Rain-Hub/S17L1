﻿using S17L1.Data;
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
            var fileName = addPageViewModel.FileCopertina.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "images", fileName);
            
            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await addPageViewModel.FileCopertina.CopyToAsync(stream);
            }

            var webPath = "/uploads/images/" + fileName;

            var book = new Book()
            {
                Id = Guid.NewGuid(),
                Titolo = addPageViewModel.Titolo,
                Autore = addPageViewModel.Autore,
                Genere = addPageViewModel.Genere,
                Disponibilita = addPageViewModel.Disponibilita,
                Copertina = webPath
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

            if (editPageViewModel.FileCopertina != null)
            {
                if (!string.IsNullOrEmpty(book.Copertina))
                {
                    var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", book.Copertina.TrimStart('/'));
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }
                }

                var fileName = editPageViewModel.FileCopertina.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "images", fileName);

                await using (var stream = new FileStream(path, FileMode.Create))
                {
                    await editPageViewModel.FileCopertina.CopyToAsync(stream);
                }

                book.Copertina = "/uploads/images/" + fileName;
            }

            book.Id = id;
            book.Titolo = editPageViewModel.Titolo;
            book.Autore = editPageViewModel.Autore;
            book.Genere = editPageViewModel.Genere;
            book.Disponibilita = editPageViewModel.Disponibilita;

            return await SaveAsync();
        }

        public async Task<bool> AddBorrow(Guid id, AddBorrowPageViewModel model)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email
            };

            _context.Users.Add(user);

            var borrow = new Borrow()
            {
                UserId = user.Id,
                BookId = id,
                BorrowEndDate = model.BorrowEndDate
            };

            _context.Borrows.Add(borrow);

            return await SaveAsync();
        }

        public async Task<BorrowPageViewModel> GetAllBorrows()
        {
            try
            {
                var borrowList = new BorrowPageViewModel();

                borrowList.Borrows = await _context.Borrows.Include(b => b.User).Include(b=> b.Book).ToListAsync();

                return borrowList;
            }
            catch
            {
                return new BorrowPageViewModel() { Borrows = new List<Borrow>() };
            }
        }

    }
}
