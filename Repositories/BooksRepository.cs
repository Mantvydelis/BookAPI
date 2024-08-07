using Book_API.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Book_API.Repositories
{
    public class BooksRepository : IBooksRepository
    {

        private readonly string _dbConnectionString;
        public BooksRepository(string connectionString)
        {
            _dbConnectionString = connectionString;
        }

        public List<Book> GetAllBooks()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            List<Book> result = dbConnection.
                Query<Book>(@"SELECT [Id] 
                 ,[Title]
                 ,[Author]
                  ,[Year] FROM [dbo].[Books]").ToList();
            dbConnection.Close();
            return result;


        }

        public void AddNewBook(Book book)
        {
            string sqlCommand = "INSERT INTO Books ([Id],[Title],[Author],[Year]) VALUES (@Id, @Title, @Author, @Year)";

            using (var connection = new SqlConnection(_dbConnectionString))
            {
                var naujiduomenys = new
                {
                    Title = book.Title,
                    Author = book.Author,
                    Year = book.Year
                };

                connection.Execute(sqlCommand, naujiduomenys);
            }
        }

        public Book GetBookBylId(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(_dbConnectionString))
            {
                dbConnection.Open();
                var result = dbConnection.QueryFirstOrDefault<Book>(
                    "SELECT * FROM Books WHERE Id = @Id",
                    new { Id = id }
                );


                return new Book(result.Id, result.Title, result.Author, result.Year);
            }
        }

        public Book CorrectInfo(int id, string title, string author, int year)
        {
            string sqlCommand = "UPDATE Books " +
                "SET Title = @Title, Author = @Author, Year = @Year " +
                "WHERE Id = @Id; SELECT* FROM Books WHERE Id = @Id";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                var pakeistiDuomenys = new
                {
                    Id = id,
                    Title = title,
                    Author = author,
                    Year = year

                };

                var result = connection.QueryFirstOrDefault<Book>(sqlCommand, pakeistiDuomenys);

                return new Book(result.Id, result.Title, result.Author, result.Year);
            }
        }


            public void DeleteBook(int id)
            {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            dbConnection.Execute(@"DELETE FROM Books WHERE Id = @id", new { Id = id });
            dbConnection.Close();


        }
        }
    } 
