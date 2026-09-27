//***************************************************************//
//* Практическая работа #6                                      *//
//*Выполнил: Прохорчук К.А, Группа-2ИСП                         *//
//*Задание: Определить правильность даты, введеной с клавиатуры *//
//***************************************************************//

using System;

namespace P.R__6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.Title = "\t\t\t\tПрактическая работа #5";
            // Решение
            Console.WriteLine("Здравствуйте!");
            Console.Write("Введите месяц (1-12): ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("Введите число (1-31): ");
            int day = int.Parse(Console.ReadLine());

            
            switch (month)
            {
                // месяцы: 1..12
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:

                    // Проверка дня
                    switch (day)
                    {
                        // дни: 1..31 
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                        case 16:
                        case 17:
                        case 18:
                        case 19:
                        case 20:
                        case 21:
                        case 22:
                        case 23:
                        case 24:
                        case 25:
                        case 26:
                        case 27:
                        case 28:
                        case 29:
                        case 30:
                        case 31:

                            // Определяем maxDays для месяца
                            switch (month)
                            {
                                case 2:
                                    // Февраль: 28 дней
                                    switch (day)
                                    {
                                        case 29:
                                        case 30:
                                        case 31:
                                            Console.WriteLine("Ошибка! В месяце 2 только 28 дней!");
                                            break;
                                        default:
                                            Console.WriteLine("Дата корректна " + day + "." + month);
                                            break;
                                    }
                                    break;

                                case 4:
                                case 6:
                                case 9:
                                case 11:
                                    // 30-дневные месяцы
                                    switch (day)
                                    {
                                        case 31:
                                            Console.WriteLine("Ошибка! В месяце " + month + " только 30 дней!");
                                            break;
                                        default:
                                            Console.WriteLine("Дата корректна " + day + "." + month);
                                            break;
                                    }
                                    break;

                                default:
                                    // 31-дневные месяцы: 1, 3, 5, 7, 8, 10, 12
                                    Console.WriteLine("Дата корректна " + day + "." + month);
                                    break;
                            }
                            break; 
                        default:
                            Console.WriteLine("Ошибка! Число должно быть от 1 до 31!");
                            break;
                    }
                    break;

                // --- Неправильные месяцы ---
                default:
                    Console.WriteLine("Ошибка: месяц должен быть от 1 до 12!");
                    break;
            }

            Console.ReadKey();
        }
    }
}