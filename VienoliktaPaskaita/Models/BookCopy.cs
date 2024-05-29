using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VienoliktaPaskaita.Models
{
    public class BookCopy
    {
        public int Id { get; set; }
        public int BookId { get; set; }

        public string Condition { get; set; }    

        public decimal Price { get; set; }

        public int InStock { get; set; }

        public BookCopy(int bookId, string condition, decimal price, int inStock) 
        {
            BookId = bookId;
            Condition = condition;
            Price = price;
            InStock = inStock;

        }

        public BookCopy(int id, int bookId, string condition, decimal price, int inStock)
        {
            Id = id;
            BookId = bookId;
            Condition = condition;
            Price = price;
            InStock = inStock;
        }


        public override string ToString()
        {
            return $"Id:{Id} | BookId:{BookId} | Condition:{Condition} | Price:{Price} | InStock:{InStock}";
        }
    }
}
