using BookStore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Order
    {
        public int Id { get; init; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public User? User { get; set; }
        public OrderStatus? Status { get; set; }
    }
}
