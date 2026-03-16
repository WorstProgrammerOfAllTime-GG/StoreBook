using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class Store
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<User> Users { get; set; } = new List<User>();
        public List<Order> Orders { get; set; } = new List<Order>();

        private int lastID;
        private int startID;
        private User ? user;

        public Store()
        {
            Task<int> task = DeSerializeID();
            if (task.Result == 0) startID = task.Result;
            else lastID = task.Result;
        }
        public async Task CreateUser(string firstname, string secondname, 
            string patronymic, DateOnly datebirth,string email, string phonenumber,
            string password)
        {
            int id = CreateID();
            user = new User(id,firstname,secondname,patronymic,datebirth,email,
                phonenumber,password);
            Users.Add(user);
           await SerializeID(lastID);                     
        }

        public async Task SerializeID(int id)
        {
            using(FileStream fs = new FileStream("id.json", FileMode.Create))
            {
                await JsonSerializer.SerializeAsync<int>(fs, id);
            }
        }

        public async Task<int> DeSerializeID()
        {
            using (FileStream fs = new FileStream("id.json", FileMode.OpenOrCreate))
            {
                if (fs.Length == 0)
                    return 0;
                return await JsonSerializer.DeserializeAsync<int>(fs);
            }
        }

        public int CreateID()
        {
           return ++lastID;
        }
    }
}
