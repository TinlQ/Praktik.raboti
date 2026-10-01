//******************************************************************************//
//* Практическая работа #8                                                     *//
//*Выполнил: Прохорчук К.А, Группа-2ИСП                                        *//
//*Задание: Определить место каждого из 8 тиктокеров по количеству просмотров. *//
//******************************************************************************//

using System;

namespace P.R__8
{
    internal class Pr8
    {
        static void Main()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.Title = "\t\t\t\tПрактическая работа №7";

            string repeat = "да";

            do
            {
                int[] views = new int[8];

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Введите просмотры 8 тиктокеров по убыванию:");

                int i = 0;

                // Ввод 8 просмотров
                do
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Просмотры тиктокера №" + (i + 1) + ": ");

                    try
                    {
                        views[i] = int.Parse(Console.ReadLine());
                        i = i + 1;
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка! Введите целое число!");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    catch (OverflowException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка! Число слишком большое!");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }

                } while (i < 8);

                // Проверяем одинаковые просмотры
                int duplicateCount = 0;

                i = 0;

                do
                {
                    int j = i + 1;

                    do
                    {
                        duplicateCount = duplicateCount +
                            Convert.ToInt32(views[i] == views[j]);

                        j = j + 1;

                    } while (j < 8);

                    i = i + 1;

                } while (i < 7);

                // Проверяем порядок по убыванию
                int disorderCount = 0;

                i = 0;

                do
                {
                    disorderCount = disorderCount +
                        Convert.ToInt32(views[i] < views[i + 1]);

                    i = i + 1;

                } while (i < 7);

                int duplicateFlag =
                    Convert.ToInt32(duplicateCount > 0);

                int disorderFlag =
                    Convert.ToInt32(disorderCount > 0);

                // 0 — всё правильно
                // 1 — одинаковые просмотры
                // 2 — нарушен порядок
                // 3 — одинаковые просмотры и нарушен порядок

                int messageIndex =
                    duplicateFlag + disorderFlag * 2;

                string[] messages = new string[4];

                messages[0] = "Рейтинг тиктокеров:";
                messages[1] = "Ошибка! У тиктокеров одинаковые просмотры!";
                messages[2] = "Ошибка! Просмотры должны быть введены по убыванию!";
                messages[3] = "Ошибка! Есть одинаковые просмотры и порядок нарушен!";

                // Выбираем цвет
                ConsoleColor[] colors = new ConsoleColor[2];

                colors[0] = ConsoleColor.White;
                colors[1] = ConsoleColor.Red;

                Console.ForegroundColor = colors[Convert.ToInt32(messageIndex > 0)];

                Console.WriteLine("\n" + messages[messageIndex]);

                // При ошибке рейтинг не выводим
                int hasError =
                    Convert.ToInt32(messageIndex > 0);

                int totalIterations =
                    (1 - hasError) * 8 + hasError;

                i = 0;

                do
                {
                    string[] result = new string[2];

                    result[0] = "";
                    result[1] =
                        (i + 1) + " место: " +
                        views[i] + " тыс. просмотров";

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine(
                        result[Convert.ToInt32(hasError == 0)]);

                    i = i + 1;

                } while (i < totalIterations);

                // Повторный запуск
                Console.ForegroundColor = ConsoleColor.White;

                do
                {
                    Console.Write("\nПовторить программу? (да/нет): ");

                    repeat = Console.ReadLine().ToLower();

                    try
                    {
                        string[] answers = new string[2];

                        answers[0] = "да";
                        answers[1] = "нет";

                        int answerIndex =
                            Array.IndexOf(answers, repeat);

                        string answer =
                            answers[answerIndex];

                        break;
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(
                            "Ошибка! Введите только «да» или «нет»!");

                        Console.ForegroundColor = ConsoleColor.White;

                        continue;
                    }

                } while (true);

                Console.Clear();

            } while (repeat == "да");

            Environment.Exit(0);
        }
    }
}