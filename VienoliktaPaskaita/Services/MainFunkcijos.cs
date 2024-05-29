using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienoliktaPaskaita.Contracts;
using VienoliktaPaskaita.Models;

namespace VienoliktaPaskaita.Services
{
    public class MainFunkcijos
    {
        public void IsvestiAutorius(IDatabaseService databaseService)
        {
            List<Author> AuthorDetails = (databaseService.GetAuthorDetails()).ToList();
            Console.WriteLine("Visi autoriai:");
            foreach (Author author in AuthorDetails)
            {
                Console.WriteLine(author);
            }
        }

        public void IsvestiKnygas(IDatabaseService databaseService)
        {
            List<Book> BookDetails = (databaseService.GetBookDetails()).ToList();
            Console.WriteLine("Visos Knygos:");
            foreach (Book book in BookDetails)
            {
                Console.WriteLine(book);
            }
        }

        public void IsvestiKnyguKopija(IDatabaseService databaseService)
        {
            List<BookCopy> BookCopyDetails = (databaseService.GetBookCopyDetails()).ToList();
            Console.WriteLine("Visos Knygu Kopijos:");
            foreach (BookCopy bookCopy in BookCopyDetails)
            {
                Console.WriteLine(bookCopy);
            }
        }
    }
}
