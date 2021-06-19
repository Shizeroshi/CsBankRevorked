using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Bank
{
    public class Client
    {
        //public ReadLine Readline;
        
        public Message Info;
        public Message Error;

        public string Name { get; set; }
        public string LastName { get; set; }

        public int Sum { get; set; }       // сумма на счету

        public Client()
        {
            Sum = 0;
        }
        
        private bool IsOpen = false;

        public bool GetIsOpen()
        {
           return IsOpen;
        }

        public void ErrorAccount()
        {
            Error?.Invoke("У вас и так открыт счёт");
        }

        public bool OpenAccount(string Name, string LastName)
        {
            if(IsOpen == false)
            {
                this.Name = Name;
                this.LastName = LastName;
                IsOpen = true;
                Info?.Invoke("Счёт на имя: '" + Name + " " + LastName + "' Открыт");
                return true;
            }
            else
            {
                ErrorAccount();
                return false;
            }
        }

        public int SetMoney()
        {
            if(IsOpen)
            {
                    Info?.Invoke("У вас на счету " + Sum + " Денег");
                    Info?.Invoke("Сколько желаете положить?");
                    int answerSetMoney = Int32.Parse(ReadLine());
                    Sum = Sum + answerSetMoney;
                    Info?.Invoke("Вы положили: " + answerSetMoney);
                    Info?.Invoke("У вас на счету теперь: " + Sum);
                return Sum;
            }
            else
            {
                Error?.Invoke("Вы не можете положить деньги поскольку у вас закрыт счёт");
                return 0;
            }
        }

        public int TakeMoney()
        {
            if(IsOpen)
            {
                if(Sum <= 0)
                {
                    Error?.Invoke("Вы не можете снять деньги по скольку их нет на счету");
                    return 0;
                }
                else
                {
                    Info?.Invoke("Сколько желаете снять?");
                    int answerTakeMoney = Int32.Parse(ReadLine());
                    if(answerTakeMoney > Sum)
                    {
                        Error?.Invoke("Вы не можете снять больше чем есть на счету");
                        return 0;
                    }
                    else
                    {
                        Sum = Sum - answerTakeMoney;
                        Info?.Invoke("Вы Сняли: " + answerTakeMoney);
                        Info?.Invoke("У вас на счету теперь: " + Sum);
                        return Sum;
                    }
                }
            }
            else
            {
                Error?.Invoke("Вы не можете снять деньги поскольку у вас закрыт счёт");
                return 0;
            }
        }

        public bool CloseAccount()
        {
            if(IsOpen)
            {
                IsOpen = false;
                Info?.Invoke("Вы закрыли счёт");
                return false;
            }
            else
            {
                Error?.Invoke("Счёт и так закрыт");
                return false;
            }
        }
    }
}
