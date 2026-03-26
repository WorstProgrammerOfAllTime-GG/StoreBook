using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.UI
{
    public class UIAuthorization
    {
        public void UI()
        {
            string[] inputItems = {"Администратор", "Читатель"};

            for (int i = 0, counter = i+1; i < inputItems.Length; i++,counter++)
            {
                Console.WriteLine($"{counter}.{inputItems[i]}");
            }
            while(true)
            {
                Console.WriteLine("Выберите номер роли : ");
                string? role = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(role))
                {
                    switch (role)
                    {
                        case "1":
                            Console.WriteLine("Открываем окно администратора"); // заглушка
                            break;
                        case "2": Console.WriteLine("Открываем окно читателя"); // заглушка
                            break;
                        default: Console.WriteLine("Неверно введено значение, повторите попытку");
                            break;
                    }
                }
            }
        }
    }
}
