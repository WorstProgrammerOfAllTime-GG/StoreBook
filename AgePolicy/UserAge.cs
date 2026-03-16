using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public class UserAge
    {
        int CalculateAge(DateOnly birthDate)
        {
            int age = DateTime.Today.Year - birthDate.Year;
            if (birthDate > DateOnly.FromDateTime(DateTime.Today).AddYears(-age))
                age--;
            return age;
        }
        public bool IsAllowedAge(DateOnly birthDate) => CalculateAge(birthDate) >= 14;
    }
}
