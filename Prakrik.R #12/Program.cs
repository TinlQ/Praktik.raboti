//******************************************************************************//
//* Практическая работа #12                                                    *//
//* Выполнил: Прохорчук К.А, Группа-2ИСП                                       *//
//* Задание: Найти индексы всех вхождений анаграмм образца p в строку s.       *//
//******************************************************************************//
using System;
using System.Collections.Generic;


namespace Prakrik.R__12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Практическая работа № 12";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Здравствуйте!");

            bool repeat = true;

            while (repeat)
            {
                try
                {
                    Console.WriteLine("=== Поиск вхождений анаграмм ===");

                    Console.Write("Введите строку s: ");
                    string s = Console.ReadLine() ?? string.Empty;

                    Console.Write("Введите образец p: ");
                    string p = Console.ReadLine() ?? string.Empty;

                    // Вызов пользовательской функции 
                    int[] indices = FindAnagramIndices(s, p);

                    // String.Join
                    Console.WriteLine("Индексы вхождений анаграмм: ["
                                      + string.Join(", ", indices) + "]");
                }
                catch (Exception ex)
                {
                 
                    HandleError(ex);
                }

                Console.Write("Повторить выполнение? (y/n): ");
                string answer = (Console.ReadLine() ?? string.Empty).Trim().ToLower();

                repeat = answer == "y" || answer == "yes"
                      || answer == "д" || answer == "да";
            }

            Console.WriteLine("Работа программы завершена.");
        }

        // Проверяет, являются ли строки a и b анаграммами.
        // Использует char[] и ToCharArray()
        // Возвращает bool
        static bool AreAnagrams(string a, string b)
        {
            // Длины должны совпадать
            if (a.Length != b.Length)
                return false;

            
            char[] arrA = a.ToCharArray();
            char[] arrB = b.ToCharArray();

            // Сортируем массивы символов
            Array.Sort(arrA);
            Array.Sort(arrB);

            // Посимвольное сравнение
            for (int i = 0; i < arrA.Length; i++)
            {
                if (arrA[i] != arrB[i])
                    return false;
            }

            return true;
        }

        // Возвращает массив индексов всех вхождений
        // анаграмм образца p в строку s.
        // Возвращает int[]
        static int[] FindAnagramIndices(string s, string p)
        {
            
            if (s == null)
                throw new ArgumentNullException(nameof(s),
                    "Строка s не может быть null.");

            if (p == null)
                throw new ArgumentNullException(nameof(p),
                    "Образец p не может быть null.");

            if (p.Length == 0)
                throw new ArgumentException(
                    "Образец p не может быть пустым.", nameof(p));

            // Если образец длиннее строки - совпадений нет
            if (p.Length > s.Length)
                return new int[0];

            // Локальная переменная внутри функции 
            List<int> result = new List<int>();

            // Перебираем все подстроки длины p.Length
            // Substring() 
            for (int i = 0; i <= s.Length - p.Length; i++)
            {
                string window = s.Substring(i, p.Length);

            
                if (AreAnagrams(window, p))
                    result.Add(i);
            }

            // List → массив
            return result.ToArray();
        }

       
        static void HandleError(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка: " + ex.Message);
            Console.ResetColor();
        }
    }
}
