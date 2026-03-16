using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BookStore
{
    public class Registration
    {
        private readonly UserAgeChecker userAge;
        private readonly Validator validator;

        public Registration(UserAgeChecker userAge, Validator validator)
        {
            this.userAge = userAge;
            this.validator = validator;
        }
        public void RegistrationUser()
        {
            while (true)
            {
                DateOnly datebirth = validator.DateValidation("Введите дату рождения : ");
                if (userAge.IsAllowedAge(datebirth)) break;
                else Console.WriteLine("Указаный возраст не проходит регистрацию!");
            }
            string? firstName = validator.Validation("Введите имя :", p => !string.IsNullOrWhiteSpace(p));
            string? secondName = validator.Validation("Введите фамилию :", p => !string.IsNullOrEmpty(p));
            string? patronymic = validator.Validation("Введите отчество :", p => !string.IsNullOrEmpty(p));
            string? email = validator.Validation("Введите Email :", p => Regex.IsMatch(p, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"));
            string? phoneNumber = validator.Validation("Введите номер телефона :", p => Regex.IsMatch(p, @"^\+?\d{10,15}$"));
        }
    }
}
