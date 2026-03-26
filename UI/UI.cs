using BookStore.Auth;
using BookStore.AuthorizationAndRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookStore.UI
{
    public class UI
    {
        Registration registration;
        AuthorizationAndRegistration.Authorization authorization;
        public UI(Registration registration, AuthorizationAndRegistration.Authorization authorization)
        {
             this.registration = registration;   
             this.authorization = authorization;
        }
        public async Task StartWindow()
        {
            
            ShowSplash();
            bool isRunning = true;
            while (isRunning)
            {
               isRunning = await ShowMainMenu();
            }         
        }

        private void ShowSplash()
        {
            string text = "BookStore";
            Console.Clear();
            Console.CursorVisible = false;

            int x = (Console.WindowWidth - text.Length) / 2;
            int y = Console.WindowHeight / 2;

            ConsoleColor[] colors =
            {
                 ConsoleColor.Red,
                 ConsoleColor.Yellow,
                 ConsoleColor.Green,
                 ConsoleColor.Cyan,
                 ConsoleColor.Blue,
                 ConsoleColor.Magenta
            };

            for (int i = 0; i < 10; i++)
            {
                foreach (var color in colors)
                {
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = color;
                    Console.Write(text);
                    Thread.Sleep(100);
                }
            }
            Console.ResetColor();
            Console.Clear();

        }


        private async Task<bool> ShowMainMenu()
        {
            Console.Clear();
            Console.Title = "Меню";
            string[] menuItems = {"Авторизация", "Регистрация", "Выход"};
            string line = new string('=', 30);

            int maxLength = menuItems.Max(item => item.Length);
            int xLine = (Console.WindowWidth - maxLength)/2;
            int yLine = 5;

            int indent = 2;


            Console.CursorVisible = false;

            Console.SetCursorPosition(xLine,yLine);
            Console.WriteLine(line);
           
            int bottomY = yLine + indent + indent * (menuItems.Length + 1);
            Console.SetCursorPosition(xLine, bottomY);
            Console.WriteLine(line);

            int number = 1;
            foreach (var item in menuItems)
            {
                string numberedItem = $"{number++}.{item}";
                int xText = xLine + line.Length / 2 - numberedItem.Length/2;
                int yText =  yLine + indent;
                indent += 2;
                Console.SetCursorPosition(xText,yText);
                Console.WriteLine(numberedItem);
            }
            string prompt = "Введите значение: ";
            int xPrompt = xLine;
            int yPrompt = yLine + indent;
            Console.SetCursorPosition(xPrompt, yPrompt);
            Console.CursorVisible = true;
            Console.Write(prompt);
            string userInput = Console.ReadLine();
            return await ChoiceUserMenu(userInput);
        }

        private async Task<bool> ChoiceUserMenu(string userInput)
        {         
            switch (userInput)
            {
                case "1":                   
                    //ShowAuth();
                    return true;

                case "2":
                   await registration.RegistrationUser();
                   return true;

                case "3":
                    return false;

                default:
                    Console.WriteLine("Неверный ввод");
                    Thread.Sleep(1000);
                    return true;
            }
        }

        
    }
}

    

