using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VienoliktaPaskaita.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }

        public Author(string firstName, string lastName, DateTime birthDate, string country)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Country = country;
        }
        public Author(int id, string firstName, string lastName, DateTime birthDate, string country)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Country = country;
        }

        public override string ToString()
        {
            return $"Id:{Id} | FirstName:{FirstName} | LastName:{LastName} | BirthDate:{BirthDate} | Country:{Country}";
        }
    }
}
