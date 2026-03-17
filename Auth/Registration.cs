using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using BookStore.AgePolicy;
using BookStore.Services;

namespace BookStore.Auth
{
    public class Registration
    {
        private readonly Store store;
        private readonly UserAge userAge;
        private readonly Validator validator;

        public Registration(Store store,UserAge userAge, Validator validator)
        {
            this.userAge = userAge;
            this.validator = validator;
            this.store = store;
        }
        public async Task RegistrationUser()
        {
            DateOnly datebirth;
            while (true)
            {
                datebirth = validator.DateValidation("Введите дату рождения : ");
                if (userAge.IsAllowedAge(datebirth)) break;
                else Console.WriteLine("Указаный возраст не проходит регистрацию!");
            }
            string? firstName = validator.Validation("Введите имя :", p => !string.IsNullOrWhiteSpace(p));
            string? secondName = validator.Validation("Введите фамилию :", p => !string.IsNullOrEmpty(p));
            string? patronymic = validator.Validation("Введите отчество :", p => !string.IsNullOrEmpty(p));
            string? email = validator.Validation("Введите Email :", p => Regex.IsMatch(p, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"));
            string? phoneNumber = validator.Validation("Введите номер телефона :", p => Regex.IsMatch(p, @"^\+?\d{10,15}$"));
            string? password = validator.Validation("Введите пароль :", p=> p.Length <= 25 && p.Length>=8);
            await store.CreateUser(firstName,secondName,patronymic, datebirth, email,phoneNumber,password);
        }
    }
}
