//******************************************************************************//
//* Практическая работа #8                                                     *//
//* Выполнил: Прохорчук К.А, Группа-2ИСП                                        *//
//* Задание: 8 тиктокеров, просмотры по убыванию, без одинаковых, нулей        *//
//*          и отрицательных. Определить место тиктокера с N.                  *//
//******************************************************************************//

using System;

namespace P.R__8
{
    internal class Pr8
    {
        static void Main()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.Title = "Практическая работа №8";

            string repeat = "y";

            do
            {
                int v1 = 0, v2 = 0, v3 = 0, v4 = 0,
                    v5 = 0, v6 = 0, v7 = 0, v8 = 0;

                Console.WriteLine("Введите просмотры 8 тиктокеров по убыванию:");
                Console.WriteLine();

                int i = 0, cur = 0;

                do
                {
                    Console.Write("Просмотры тиктокера №" + (i + 1) + ": ");
                    try
                    {
                        cur = int.Parse(Console.ReadLine());

                        // Ноль - DivideByZeroException
                        int nz = 5 % cur;

                        // Отрицательное - OverflowException
                        uint pos = uint.Parse(cur.ToString());

                        // Дубликат - ArgumentOutOfRangeException
                        int matches =
                              Convert.ToInt32(cur == v1) + Convert.ToInt32(cur == v2)
                            + Convert.ToInt32(cur == v3) + Convert.ToInt32(cur == v4)
                            + Convert.ToInt32(cur == v5) + Convert.ToInt32(cur == v6)
                            + Convert.ToInt32(cur == v7) + Convert.ToInt32(cur == v8);
                        string dup = "x".Substring(
                            0, 1 + 100 * Convert.ToInt32(matches > 0));

                        
                        v1 = cur * Convert.ToInt32(i == 0) + v1 * Convert.ToInt32(i != 0);
                        v2 = cur * Convert.ToInt32(i == 1) + v2 * Convert.ToInt32(i != 1);
                        v3 = cur * Convert.ToInt32(i == 2) + v3 * Convert.ToInt32(i != 2);
                        v4 = cur * Convert.ToInt32(i == 3) + v4 * Convert.ToInt32(i != 3);
                        v5 = cur * Convert.ToInt32(i == 4) + v5 * Convert.ToInt32(i != 4);
                        v6 = cur * Convert.ToInt32(i == 5) + v6 * Convert.ToInt32(i != 5);
                        v7 = cur * Convert.ToInt32(i == 6) + v7 * Convert.ToInt32(i != 6);
                        v8 = cur * Convert.ToInt32(i == 7) + v8 * Convert.ToInt32(i != 7);

                        i = i + 1;
                    }
                    catch (FormatException fex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Возникла ошибка: " + fex.Message +
                                          " Введите ещё раз.");
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    catch (OverflowException oex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Возникла ошибка: " + oex.Message +
                                          " Введите ещё раз.");
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    catch (DivideByZeroException dzex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Возникла ошибка: " + dzex.Message +
                                          " Введите ещё раз.");
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    catch (ArgumentOutOfRangeException aoorex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Возникла ошибка: " + aoorex.Message +
                                          " Введите ещё раз.");
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Возникла ошибка: " + ex.Message +
                                          " Введите ещё раз.");
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                } while (i < 8);

                // Проверка порядка убывания
                int a = 0, b = 0;
                int disorder = 0;
                i = 0;

                do
                {
                    a = v1 * Convert.ToInt32(i == 0) + v2 * Convert.ToInt32(i == 1)
                      + v3 * Convert.ToInt32(i == 2) + v4 * Convert.ToInt32(i == 3)
                      + v5 * Convert.ToInt32(i == 4) + v6 * Convert.ToInt32(i == 5)
                      + v7 * Convert.ToInt32(i == 6);

                    b = v2 * Convert.ToInt32(i == 0) + v3 * Convert.ToInt32(i == 1)
                      + v4 * Convert.ToInt32(i == 2) + v5 * Convert.ToInt32(i == 3)
                      + v6 * Convert.ToInt32(i == 4) + v7 * Convert.ToInt32(i == 5)
                      + v8 * Convert.ToInt32(i == 6);

                    disorder = disorder + Convert.ToInt32(a < b);
                    i = i + 1;
                } while (i < 7);

                try
                {
                    string ordCheck = "x".Substring(
                        0, 1 + 100 * Convert.ToInt32(disorder > 0));
                }
                catch (ArgumentOutOfRangeException aoorex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Возникла ошибка: " + aoorex.Message +
                                      " Введите ещё раз.");
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                // Ввод N 
                int n = 0;

                try
                {
                    int skip = 5 % Convert.ToInt32(disorder == 0);

                    int k = 0;
                    do
                    {
                        try
                        {
                            Console.Write("Введите N: ");
                            n = int.Parse(Console.ReadLine());
                            k = 1;
                        }
                        catch (FormatException fex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Возникла ошибка: " + fex.Message +
                                              " Введите ещё раз.");
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        catch (OverflowException oex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Возникла ошибка: " + oex.Message +
                                              " Введите ещё раз.");
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Возникла ошибка: " + ex.Message +
                                              " Введите ещё раз.");
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    } while (k < 1);

                    int place = 1
                        + Convert.ToInt32(v1 > n) + Convert.ToInt32(v2 > n)
                        + Convert.ToInt32(v3 > n) + Convert.ToInt32(v4 > n)
                        + Convert.ToInt32(v5 > n) + Convert.ToInt32(v6 > n)
                        + Convert.ToInt32(v7 > n) + Convert.ToInt32(v8 > n);

                    Console.WriteLine();
                    Console.WriteLine("Тиктокер с " + n +
                                      " тыс. просмотров занял " + place + " место.");
                }
                catch (DivideByZeroException)
                {
                    // disorder > 0 — пропускаем ввод N
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