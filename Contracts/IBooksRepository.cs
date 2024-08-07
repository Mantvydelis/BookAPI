using Book_API.Models;

namespace Book_API.Repositories
{
    public interface IBooksRepository
    {
        List<Book> GetAllBooks();

        Book GetBookBylId(int id);

        void AddNewBook(Book book);

        Book CorrectInfo(int id, string title, string author, int year);

        void DeleteBook(int id);

    }
}
