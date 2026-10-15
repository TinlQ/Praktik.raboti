//******************************************************************************//
//* Практическая работа #11                                                    *//
//* Выполнил: Прохорчук К.А, Группа-2ИСП                                       *//
//* Задание: Подсчитать статистику символов во введённом тексте.               *//
//******************************************************************************//

using System;

namespace P.R__11
{
    internal class PrStats
    {
        static void Main()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.Title = "Статистика символов";

            string repeat = "y";

            do
            {
                try
                {
                    Console.WriteLine("Введите строки текста.");
                    Console.WriteLine("Пустая строка — конец ввода.");
                    Console.WriteLine();

                    string text = "";
                    string line;

                    // Читаем строки, пока пользователь не введет пустую строку
                    do
                    {
                        Console.Write("> ");
                        line = Console.ReadLine() ?? "";

                        if (line.Length > 0)
                        {
                            text += line ;
                        }

                    } while (line.Length > 0);

                    // Проверяем, введен ли текст
                    if (text.Length == 0)
                    {
                        Console.WriteLine("Текст не введён.");
                    }
                    else
                    {
                        // Массив для подсчета частоты каждого символа (по его Unicode-коду)
                        int[] freq = new int[65536];

                        int total = 0, letters = 0, digits = 0,
                            spaces = 0, punct = 0, other = 0;

                        // Считаем типы символов и их частоту
                        for (int i = 0; i < text.Length; i++)
                        {
                            char c = text[i];
                            freq[c]++;
                            total++;

                            if (char.IsLetter(c)) letters++;
                            else if (char.IsDigit(c)) digits++;
                            else if (char.IsWhiteSpace(c)) spaces++;
                            else if (char.IsPunctuation(c)) punct++;
                            else other++;
                        }

                        // Вывод общей статистики
                        Console.WriteLine("\n\tОбщая статистика");
                        Console.WriteLine("Всего символов: " + total);
                        Console.WriteLine("Букв: " + letters);
                        Console.WriteLine("Цифр: " + digits);
                        Console.WriteLine("Пробельных: " + spaces);
                        Console.WriteLine("Знаков препинания: " + punct);
                        Console.WriteLine("Прочих: " + other);

                        // Вывод частоты символов
                        Console.WriteLine("\n\tЧастота символов ");
                        for (int code = 0; code < 65536; code++)
                        {
                            if (freq[code] > 0)
                            {
                                char c = (char)code;
                                string view = c == ' ' ? "[пробел]"
                                            : c == '\n' ? "[\\n]"
                                            : c == '\t' ? "[таб]"
                                            : c.ToString();

                                Console.WriteLine("'" + view + "' — " + freq[code]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка: " + ex.Message);
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine();
                do
                {
                    Console.Write("Повторить программу? (y/n): ");
                    repeat = (Console.ReadLine() ?? "").ToLower();
                } while (repeat != "y" && repeat != "n");

                Console.Clear();

            } while (repeat == "y");

            Environment.Exit(0);
        }
    }
}
