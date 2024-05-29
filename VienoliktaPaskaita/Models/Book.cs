using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VienoliktaPaskaita.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public string Genre { get; set; }


        public Book(int authorId, string title, int publicationYear, string genre)
        {
            AuthorId = authorId;
            Title = title;
            PublicationYear = publicationYear;
            Genre = genre;
        }
        public Book(int id,int authorId, string title, int publicationYear, string genre)
        {
            Id = id;
            AuthorId = authorId;
            Title = title;
            PublicationYear = publicationYear;
            Genre = genre;
        }

        public override string ToString()
        {
            return $"Id:{Id} | AuthorID:{AuthorId} | Title:{Title} | PublicationYear:{PublicationYear} | Genre:{Genre}";
        }
    }
}
