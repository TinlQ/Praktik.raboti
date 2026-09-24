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
            // Решение
            Console.WriteLine("Здравствуйте!");
                Console.Write("Введите месяц (1-12): ");
                int month = int.Parse(Console.ReadLine());

                Console.Write("Введите число (1-31): ");
                int day = int.Parse(Console.ReadLine());

                switch (month) //Проверяю месяц
                {
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
                        
                        if (day < 1 || day > 31) // Если месяц введен правильно, проверяыем день
                    {
                            Console.WriteLine("Ошибка! Число должно быть от 1 до 31!");
                        }
                        else
                        {
                            
                            int maxDays; // Определяю максимальное кол-во дней в месяце 

                        switch (month)
                            {
                                case 2:
                                    maxDays = 28;
                                    break;
                                case 4:
                                case 6:
                                case 9:
                                case 11:
                                    maxDays = 30;
                                    break;
                                default:
                                    maxDays = 31;
                                    break;
                            }

                            if (day > maxDays)
                            {
                                Console.WriteLine("Ошибка! В месяце " + month + " только " + maxDays + " дней!");
                            }
                            else
                            {
                                Console.WriteLine("Дата корректна " + day + "." + month);
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Ошибка: месяц должен быть от 1 до 12!");
                        break;

                    Console.ReadKey();
            }
            }
        }
    }
    

