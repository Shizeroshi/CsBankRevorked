using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static void Main()
        {
                Console.WriteLine("Приветствуем вас в банке RoflBank, что вы хотите сделать?");

            string Name;
            string LastName;

                Client client = new Client();
                client.Info = ShowConsoleInfo;
                client.Error = ShowConsoleError;
            for (; ; )
            {
                Console.WriteLine("1. Открыть счёт");
                Console.WriteLine("2. Внести деньги");
                Console.WriteLine("3. Снять деньги");
                Console.WriteLine("4. Закрыть счёт");
                string answerStart = Console.ReadLine();
                if (answerStart == "1")
                {
                    if(client.GetIsOpen() == false)
                    {
                        Console.Write("Введите имя: ");
                        Name = Console.ReadLine();
                        Console.Write("Введите Фамилию: ");
                        LastName = Console.ReadLine();
                        client.OpenAccount(Name, LastName);
                    }
                    else
                    {
                        client.ErrorAccount();
                    }
                    
                }
                if (answerStart == "2") client.SetMoney();
                if (answerStart == "3") client.TakeMoney();
                if (answerStart == "4") client.CloseAccount(); 
            }
        }

        static void ShowConsoleInfo(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        static void ShowConsoleError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}
