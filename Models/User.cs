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
        public string ? FirstName { get; set; }
        public string ? SecondName { get; set; }      
        public string ? Patronymic { get; set; }
        public DateOnly DateBirth { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public List<Role> Roles { get; set; } = new List<Role>();

        public User(int id,string firstname,string secondname,
            string patronymic,DateOnly dateBirth, string email,
            string phoneNumber, string password)
        {
            ID = id; 
            FirstName = firstname;
            SecondName = secondname;
            Patronymic = patronymic;
            DateBirth = dateBirth;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
        }
    }
}
