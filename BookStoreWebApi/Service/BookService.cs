using AutoMapper;
using BookStoreWebApi.Domain.Models;
using BookStoreWebApi.Domain.Repository;
using BookStoreWebApi.DTO;

namespace BookStoreWebApi.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookrepo;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookrepo, IMapper mapper)
        {
            _bookrepo = bookrepo;
            _mapper = mapper;
        }
        public async Task<int> AddBookAsync(BookModelDTO _book)
        {
            var mapped = _mapper.Map<Books>(_book);
            if(mapped == null)
            {
                throw new Exception("Entity could not be mapped");
            }
            return await _bookrepo.AddBooksAsync(mapped);
        }

        public async Task DeleteBookAsync(int bookId)
        {
            await _bookrepo.DeleteBookAsync(bookId);
        }

        

        public async Task<List<BookModelDTO>> GetAllBookAsync()
        {
            var bookList = await _bookrepo.GetAllBooksAsync();
            var mapped = _mapper.Map<List<BookModelDTO>>(bookList);
            return mapped;
        }

        public async Task<BookModelDTO> GetBookByIdAsync(int bookId)
        {
            var _book = await _bookrepo.GetBookByIdAsync(bookId);
            var mapped = _mapper.Map<BookModelDTO>(_book);
            return mapped;
        }

        public async Task UpdateBookAsync(int bookId, BookModelDTO _book)
        {
            var mapped = _mapper.Map<Books>(_book);
            if(mapped == null)
            {
                throw new Exception("Enity cold not be mapped");
            }
            await _bookrepo.UpdateBookAsync(bookId, mapped);

        }
    }
}
