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
            Console.Clear();
            DateOnly datebirth;
            while (true)
            {

                datebirth = validator.DateRegValidation("Введите дату рождения : ");                              
                if (userAge.IsAllowedAge(datebirth)) break;
                else Console.WriteLine("Указаный возраст не проходит регистрацию!");
            }
            string? firstName = validator.ValidationReg("Введите имя : ", p => !string.IsNullOrWhiteSpace(p));
            string? secondName = validator.ValidationReg("Введите фамилию : ", p => !string.IsNullOrWhiteSpace(p));
            string? patronymic = validator.ValidationReg("Введите отчество : ", p => !string.IsNullOrWhiteSpace(p));
            string? email = validator.ValidationReg("Введите Email : ", p=> !validator.RegEmailExists(p) && Regex.IsMatch(p, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"));
            string? phoneNumber = validator.ValidationReg("Введите номер телефона : ", p=> !validator.RegPhoneExists(p) && Regex.IsMatch(p, @"^\+?\d{10,15}$"));
            string? password = validator.ValidationReg("Введите пароль : ", p=> p.Length <= 25 && p.Length>=8 && !string.IsNullOrWhiteSpace(p));
            await store.CreateUser(firstName,secondName,patronymic, datebirth, email,phoneNumber,password);
        }
    }
}
