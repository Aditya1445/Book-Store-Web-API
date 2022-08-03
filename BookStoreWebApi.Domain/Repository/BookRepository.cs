using BookStoreWebApi.Domain.Dbcontext;
using BookStoreWebApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWebApi.Domain.Repository
{
    public class BookRepository : IBookRepository
    {

        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddBooksAsync(Books _book)
        {
            var _newBook = new Books()
            {
                title = _book.title,
                description = _book.description,
                author = _book.author,
                price = _book.price,
                datePublished = _book.datePublished,
                numberOfCopies = _book.numberOfCopies
            };
            _context.Books.Add(_newBook);
            await _context.SaveChangesAsync();
            return _newBook.Id;
        }

        public async Task DeleteBookAsync(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);
            if(book == null)
            {
                throw new Exception("Entity not present");
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Books>> GetAllBooksAsync()
        {
            var _bookList = await _context.Books.ToListAsync();
            return _bookList;
        }

        public async Task<Books> GetBookByIdAsync(int bookId)
        {
            var _book = await _context.Books.FindAsync(bookId);
            return _book!;
        }

        public async Task UpdateBookAsync(int bookId, Books _book)
        {
            var getBook = await _context.Books.FirstOrDefaultAsync(e => e.Id == bookId);
            
            if(getBook != null)
            {
                getBook.title = _book.title;
                getBook.description = _book.description;
                getBook.price = _book.price;
                getBook.author = _book.author;
            }    
            
            //var book = new Books()
            //{
            //    Id = bookId,
            //    title = _book.title,
            //    description = _book.description,
            //    author = _book.author,
            //    price = _book.price
            //};
            //_context.Books.Update(_book);
            await _context.SaveChangesAsync();
        }
    }
}
