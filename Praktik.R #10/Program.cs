//******************************************************************************//
//* Практическая работа #10                                                    *//
//* Выполнил: Прохорчук К.А, Группа-2ИСП                                        *//
//* Задание: Подсчитать количество чётных элементов в каждом столбце матрицы    *//
//*          M = 5 x N = 6, элементы — случайные из [-98; 54].                  *//
//******************************************************************************//

using System;

namespace P.R__10
{
    internal class Pr10
    {
        const int M = 5;
        const int N = 6;
        const int MIN = -98;
        const int MAX = 54;

        static void Main()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.Title = "Практическая работа №10";

            string repeat = "y";

            do
            {
                int[,] matrix = new int[M, N];
                int[] counts = new int[N];

                Random rnd = new Random();

                // Заполнение
                for (int i = 0; i < M; i++)
                    for (int j = 0; j < N; j++)
                        matrix[i, j] = rnd.Next(MIN, MAX + 1);

                // Вывод матрицы
                Console.WriteLine("Исходный массив:");
                Console.WriteLine();

                for (int i = 0; i < M; i++)
                {
                    for (int j = 0; j < N; j++)
                        Console.Write(matrix[i, j] + "\t");
                    Console.WriteLine();
                }

                // Подсчёт чётных по столбцам
                for (int j = 0; j < N; j++)
                {
                    int c = 0;
                    for (int i = 0; i < M; i++)
                        if (matrix[i, j] % 2 == 0)
                            c++;
                    counts[j] = c;
                }

                Console.WriteLine();
                Console.WriteLine("Количество чётных элементов в каждом столбце:");

                for (int j = 0; j < N; j++)
                    Console.WriteLine("  Столбец " + (j + 1) + ": " + counts[j]);

                // Повтор программы
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