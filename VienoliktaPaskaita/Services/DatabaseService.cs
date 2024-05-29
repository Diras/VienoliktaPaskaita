using Dapper;
using System.Data;
using System.Data.SqlClient;
using VienoliktaPaskaita.Contracts;
using VienoliktaPaskaita.Models;


namespace VienoliktaPaskaita.Services
{
    public class DatabaseService: IDatabaseService
    {
        private readonly string _connectionString;
        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<Author> GetAuthorDetails()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"
                SELECT *
                FROM Authors
                ";

                return db.Query<Author>(sql);
            }
        }

        public IEnumerable<Book> GetBookDetails()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"
                SELECT *
                FROM Books
                ";

                return db.Query<Book>(sql);
            }
        }

        public IEnumerable<BookCopy> GetBookCopyDetails()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"
                SELECT *
                FROM BookCopies
                ";

                return db.Query<BookCopy>(sql);
            }
        }

        public void InsertAuthor(Author author)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = "INSERT INTO Authors (FirstName, LastName, BirthDate, Country) " +
                    "VALUES (@FirstName, @Lastname, @BirthDate, @Country);";
                db.Execute(sql, author);
            }
        }

        public void UpdateAuthor(Author author, int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = "UPDATE Authors " +
                                   "SET FirstName = @FirstName, LastName = @LastName, BirthDate = @BirthDate, Country = @Country " +
                                   "WHERE Id = @Id";
                db.Execute(sql, new { author.FirstName, author.LastName, author.BirthDate, author.Country, Id = id });
            }
        }

        public void DeleteAuthor(int Id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"
                DELETE FROM Authors WHERE Id = @Id";
                db.Query(sql, new { Id });
            }
        }
    }
}

