using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public class Validator
    {
        public string Validation(string text, Func<string, bool> validator)
        {
            while (true)
            {
                Console.WriteLine(text);
                string? data = Console.ReadLine();
                if (data != null && validator.Invoke(data))
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
                }
                else Console.WriteLine("Неверно введены данные, повторите попытку!");
            }
        }
    }
}
