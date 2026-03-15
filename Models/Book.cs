using BookStore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book 
    {
        public int ID { get; init; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public DateOnly? DatePublication { get; set; }
        public List<Genre> Genres { get; set; } = new List<Genre>();
        public BookStatus Status { get; set; }
        public decimal Price { get; set; }
    }
}
