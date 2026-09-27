//**********************************************************************//
//* Практическая работа #7                                             *//
//*Выполнил: Прохорчук К.А, Группа-2ИСП                                *//
//*Задание: Определить, какое место занял тиктокер по кол-ву просмотров*//
//**********************************************************************//
using System;

class Program
{
    static void Main()
    {
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();
        Console.Title = "\t\t\t\tПрактическая работа #5";

        // Просмотры 8 тиктокеров (в тысячах)
        int[] views = new int[8];

        // Ввод просмотров
        Console.WriteLine("Введите просмотры 8 тиктокеров по убыванию:");
        for (int i = 0; i < 8; i++)
        {
            Console.Write("Просмотры тиктокера №" + (i + 1) + ": ");
            views[i] = int.Parse(Console.ReadLine());
        }

        // Ввод N 
        Console.Write("\nВведите N (просмотры искомого тиктокера): ");
        int N = int.Parse(Console.ReadLine());

        // Определение места
        int place = 0;

        for (int i = 0; i < 8; i++)
        {
            place = place + ((views[i] >= N) ? 1 : 0);
        }

        Console.WriteLine("\nТиктокер с " + N + " тыс. просмотров занял " + place + " место");

        Console.ReadKey();
    }
}