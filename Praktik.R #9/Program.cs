//******************************************************************************//
//* Практическая работа #9                                                     *//
//* Выполнил: Прохорчук К.А, Группа-2ИСП                                        *//
//* Задание: В массиве из 15 вещественных чисел найти номер максимального      *//
//*          по модулю элемента и сумму модулей элементов между первым         *//
//*          положительным и последним отрицательным.                          *//
//******************************************************************************//

using System;

namespace P.R__9
{
    internal class Pr9
    {
        const int N = 15;

        static void Main()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.Title = "Практическая работа №9";

            string repeat = "y";

            do
            {
                double[] A = new double[N];

                Console.WriteLine("Введите " + N + " вещественных чисел:");
                Console.WriteLine();

                for (int i = 0; i < N; i++)
                {
                    do
                    {
                        Console.Write("A[" + i + "] = ");
                        try
                        {
                            A[i] = double.Parse(
                                (Console.ReadLine() ?? "").Replace(',', '.'));
                            break;
                        }
                        catch (Exception ex)
                        {
                            string msg = "Ошибка: " + ex.Message;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(msg.Substring(0, msg.Length));
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    } while (true);
                }

                Console.WriteLine();
                Console.WriteLine("Исходный массив:");
                for (int i = 0; i < N; i++)
                    Console.Write(A[i] + "  ");
                Console.WriteLine();

                // Номер максимального по модулю
                int maxIndex = 0;
                for (int i = 1; i < N; i++)
                    if (Math.Abs(A[i]) > Math.Abs(A[maxIndex]))
                        maxIndex = i;

                Console.WriteLine();
                Console.WriteLine("Максимальный по модулю: A[" + maxIndex + "] = " + A[maxIndex] +
                                  " (|A| = " + Math.Abs(A[maxIndex]) + ")");

                // Сумма модулей между первым положительным  и последним отрицательным
                int firstPos = -1, lastNeg = -1;

                for (int i = 0; i < N; i++)
                    if (A[i] > 0) { firstPos = i; break; }

                for (int i = N - 1; i >= 0; i--)
                    if (A[i] < 0) { lastNeg = i; break; }

                int noRange = Convert.ToInt32(firstPos == -1)
                            + Convert.ToInt32(lastNeg == -1)
                            + Convert.ToInt32(firstPos >= lastNeg);

                const string err = "Элементов между первым положительным " + "и последним отрицательным нет.";
                Console.WriteLine(err.Substring(0, err.Length * Convert.ToInt32(noRange > 0)));

                // Считаем сумму только когда диапазон существует
                double sum = 0;
                int hasRange = 1 - Convert.ToInt32(noRange > 0);

                for (int i = firstPos + 1; i < lastNeg; i++)
                    sum = sum + Math.Abs(A[i]) * hasRange;

                const string res = "Сумма модулей: ";
                Console.WriteLine(res.Substring(0, res.Length * hasRange)
                                  + sum.ToString().Substring(0, sum.ToString().Length * hasRange));

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