using Book_API.Models;
using Book_API.Repositories;
using Dapper;

namespace Book_API.Services
{
    public class BooksService : IBooksRepository
    {

        private readonly IBooksRepository _booksRepository;
        public BooksService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }
        public void AddNewBook(Book book)
        {
            _booksRepository.AddNewBook(book);
        }

        public Book CorrectInfo(int id, string title, string author, int year)
        {
            return _booksRepository.CorrectInfo(id, title, author, year);
        }

        public void DeleteBook(int id)
        {
            _booksRepository.DeleteBook(id);
        }

        public List<Book> GetAllBooks()
        {
            return _booksRepository.GetAllBooks();
        }

        public Book GetBookBylId(int id)
        {
            return _booksRepository.GetBookBylId(id);   
        }
    }
}
