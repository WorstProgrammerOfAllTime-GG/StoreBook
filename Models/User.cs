using BookStore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class User
    {
        public int ID { get; init; }
        public string ? FristName { get; set; }
        public string ? SecondName { get; set; }      
        public string ? Patronymic { get; set; }
        public DateOnly DateBirth { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        List<Role> Roles { get; set; } = new List<Role>();

        public User(string fullName, DateOnly dateBirth, string email,
            string phoneNumber, string password)
        {
            
        }
    }
}
