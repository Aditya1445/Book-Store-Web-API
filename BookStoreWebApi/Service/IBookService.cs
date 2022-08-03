using BookStoreWebApi.DTO;

namespace BookStoreWebApi.Service
{
    public interface IBookService
    {
        Task<List<BookModelDTO>> GetAllBookAsync();

        Task<BookModelDTO> GetBookByIdAsync(int bookId);

        Task<int> AddBookAsync(BookModelDTO _book);

        Task UpdateBookAsync(int bookId, BookModelDTO _book);

        Task DeleteBookAsync(int bookId);
        
    }
}
