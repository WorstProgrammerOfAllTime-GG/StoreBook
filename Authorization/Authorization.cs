using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookStore.AuthorizationAndRegistration
{
    public class Authorization
    {
        public void Registration ()
        {
            while (true)
            {
                DateOnly datebirth = DateValidation("Введите дату рождения : ");
                if (IsAllowedAge(datebirth)) break;
                else Console.WriteLine("Указаный возраст не проходит регистрацию!");
            }
            string? firstName = Validation("Введите имя :", p => !string.IsNullOrWhiteSpace(p));
            string? secondName = Validation("Введите фамилию :", p => !string.IsNullOrEmpty(p));
            string? patronymic = Validation("Введите отчество :", p => !string.IsNullOrEmpty(p));               
            string? email = Validation("Введите Email :", p => Regex.IsMatch(p, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"));
            string? phoneNumber = Validation("Введите номер телефона :", p => Regex.IsMatch(p, @"^\+?\d{10,15}$"));
        }

        public string Validation(string text, Func<string,bool> validator)
        {
            while(true)
            {
                Console.WriteLine(text);
                string? data = Console.ReadLine();
                if (data !=null && validator.Invoke(data))
                {                
                   return data;                   
                } 
                else Console.WriteLine("Неверно введены данные, повторите попытку!");
            }            
        }

        public DateOnly DateValidation(string text)
        {
            while (true)
            {
                Console.WriteLine(text);
                if (DateOnly.TryParse(Console.ReadLine(), out DateOnly date))
                {           
                    return date;                  
                } else Console.WriteLine("Неверно введены данные, повторите попытку!");
            }          
        }

        int CalculateAge(DateOnly birthDate)
        {
            int age = DateTime.Today.Year - birthDate.Year;
            if (birthDate > DateOnly.FromDateTime(DateTime.Today).AddYears(-age))
                age--;
            return age;
        }
        bool IsAllowedAge(DateOnly birthDate) => CalculateAge(birthDate) >= 14;
    }
}
