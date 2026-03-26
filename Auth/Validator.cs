using BookStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Auth
{
    public class Validator
    {
        private Store store;
        private InputValidator input;
        public Validator(Store store, InputValidator input)
        {
            this.store = store;
            this.input = input;
            
        }
        public string ValidationReg(string text, Func<string, bool> validator)
        {
            while (true)
            {
                string? data = input.InputData(text);               
                if (data != null && validator.Invoke(data))
                {
                    return data;
                }
                else Console.WriteLine("Неверно введены данные, повторите попытку!");
            }
        }
        public DateOnly DateRegValidation(string text)
        {
            while (true)
            {
                string ? data = input.InputData(text);
                if (!string.IsNullOrWhiteSpace(data) && DateOnly.TryParse(data, out DateOnly date))
                {
                    return date;
                }
                else Console.WriteLine("Неверный формат даты, повторите попытку!");
            }
        }

        public bool RegEmailExists(string email) =>  store.isExsist(email, u=> u.Email!);
        public bool RegPhoneExists(string phone) =>  store.isExsist(phone, u=> u.PhoneNumber!);

        public User ? ValidationAuth(string textLog, string textPass)            
        {
            while (true)
            {
                string? login = input.InputData(textLog);
                string? password = input.InputData(textPass);

                if (!string.IsNullOrWhiteSpace(login)&&
                    !string.IsNullOrWhiteSpace(password))
                {
                    User? user = store.AuthVerification(login, password);
                    if (user != null)
                    {
                        return user;
                    }
                    else Console.WriteLine("Неверно введены логин или пароль, повторите попытку!");
                }                      
            }
        }
    }
}
