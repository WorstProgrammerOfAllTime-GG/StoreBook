using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Auth
{
    public class InputValidator
    {
        public string InputData(string text)
        {
            Console.WriteLine(text);
            string ? data = Console.ReadLine();
            return data;
        }
    }
}
