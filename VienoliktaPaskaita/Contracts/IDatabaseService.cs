using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienoliktaPaskaita.Models;

namespace VienoliktaPaskaita.Contracts
{
    public interface IDatabaseService
    {
        public IEnumerable<Author> GetAuthorDetails();

        public void DeleteAuthor(int Id);

        public void InsertAuthor(Author author);

        public IEnumerable<Book> GetBookDetails();

        public IEnumerable<BookCopy> GetBookCopyDetails();
    }
}
