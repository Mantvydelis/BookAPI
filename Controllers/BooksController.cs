using Book_API.Models;
using Book_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Book_API.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class BooksController : Controller
    {
        private readonly IBooksRepository _BooksService;

        public BooksController(IBooksRepository booksService)
        {
            _BooksService = booksService;
        }


        [HttpGet("GetAllBooks")]
        public IActionResult Index()
        {
            var allBooks = _BooksService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("GetBookById")]
        public IActionResult GetBookById(int id)
        {
            var BookId = _BooksService.GetBookBylId(id);
            return Ok(BookId);
        }

        [HttpPost("AddNewBook")]
        public IActionResult AddNewBook(Book book)
        {
            try
            {
                _BooksService.AddNewBook(book);
                return Ok();
            }
            catch
            {
                return Problem();
            }

        }


        [HttpPost("CorrectBookInfo")]
        public IActionResult CorrectInfo(int id, string title, string author, int year)
        {
            try
            {
                var elId = _BooksService.CorrectInfo(id, title, author, year);
                return Ok(elId);

            }
            catch
            {
                return Problem();
            }
        }

        [HttpDelete("DeleteBook")]
        public IActionResult DeleteBook(int id)
        {
            _BooksService.DeleteBook(id);
            return Ok();
        }
    }
}




//GET / api / books - Grąžina visų knygų sąrašą.
//GET /api/books/{id} -Grąžina vieną knygą pagal ID.
//POST /api/books - Prideda naują knygą.
//PUT /api/books/{id} -Atnaujina egzistuojančią knygą pagal ID.
//DELETE /api/books/{id} -Ištrina knygą pagal ID.
