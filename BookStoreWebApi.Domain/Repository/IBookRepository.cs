using BookStoreWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWebApi.Domain.Repository
{
    public interface IBookRepository
    {
        Task<List<Books>> GetAllBooksAsync();

        Task<Books> GetBookByIdAsync(int bookId);

        Task<int> AddBooksAsync(Books _book);

        Task UpdateBookAsync(int bookId, Books _book);

        Task DeleteBookAsync(int bookId);


    }
}
