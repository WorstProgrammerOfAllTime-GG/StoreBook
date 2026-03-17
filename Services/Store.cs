using BookStore.Models;
using BookStore.Serialize;
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
        private const string IdPath = "id.json";
        private const string UsersPath = "users.json";
        public List<Book> Books { get; set; } = new List<Book>();
        public List<User> Users { get; set; } = new List<User>();
        public List<Order> Orders { get; set; } = new List<Order>();

        private int lastID;
        readonly IStorage storage;

        public Store(IStorage storage)
        {
           this.storage = storage;
        }

        public async Task Initialize()
        {
            lastID = await storage.LoadAsync<int?>(IdPath) ?? 0;
            Users = await  storage.LoadAsync<List<User>>(UsersPath) ?? new List<User>();
        }
        public async Task CreateUser(string firstname, string secondname, 
            string patronymic, DateOnly datebirth,string email, string phonenumber,
            string password)
        {
            int id = CreateID();
            var user = new User(id,firstname,secondname,patronymic,datebirth,email,
                phonenumber,password);
            Users.Add(user);
           await storage.SaveAsync<int>(IdPath,lastID);
           await storage.SaveAsync<List<User>>(UsersPath, Users);
        }
       
        private int CreateID()
        {
           return ++lastID;
        }
    }
}
