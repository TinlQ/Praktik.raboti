//***************************************************************//
//* Практическая работа #5                                      *//
//*Выполнил: Прохорчук К.А, Группа-2ИСП                         *//
//*Задание: Определить правильность даты, введеной с клавиатуры *//
//***************************************************************//

using System;

namespace P.R__4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.Title = "\t\t\t\tПрактическая работа #5";

            //Решение 
            int month, number, MaximumDay;

            Console.WriteLine("Здравствуйте!");
            Console.Write("Пожалуйста, введите месяц(от 1 до 12)\t");
            month = Convert.ToInt32(Console.ReadLine());
            Console.Write("Спасибо! А теперь введите число (от 1 до 31)\t");
            number = Convert.ToInt32(Console.ReadLine());

            if (month < 1||month > 12)
            { Console.WriteLine("Ошибка, вы ввели неправильный месяц, попробуйте еще раз"); }
            else if (number < 1 || number > 31)
            { Console.WriteLine("Ошибка, вы ввели неправильный день, попробуйте еще раз"); }
            if (month == 2 )
            { MaximumDay = 28; } // сколько дней у Февраля (без високосного года)
            else if (month == 4|| month == 6|| month == 9|| month == 11)
                { MaximumDay = 30; } // сколько дней Апрель, Июнь, Сентябрь, Ноябрь
            else { MaximumDay = 31; } // остальные дни
            if (number > MaximumDay)
            { Console.WriteLine("Ошибка, в месяце " + month + " только " + MaximumDay + " дней"); }
            else { Console.WriteLine("Дата корректна " + number + " / " + month); }
            Console.ReadKey();
        }
    }
}
