/***********************************************************/
/* Практическая работа №7                                   */
/* Задание: Определить место каждого из 8 тиктокеров        */
/*          по количеству просмотров.                       */
/*          Проверка: все просмотры должны быть разными.    */
/*          Условный оператор не использовать.              */
/***********************************************************/

using System;

class Program
{
    static void Main()
    {
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();
        Console.Title = "\t\t\t\tПрактическая работа №7";

        int[] views = new int[8];

        Console.WriteLine("Введите просмотры 8 тиктокеров по убыванию:");
        for (int i = 0; i < 8; i++)
        {
            Console.Write("Просмотры тиктокера №" + (i + 1) + ": ");
            views[i] = int.Parse(Console.ReadLine());
        }

        // Сравниваем каждую пару (i, j) при j > i.
        int duplicateCount = 0;
        for (int i = 0; i < 7; i++)
        {
            for (int j = i + 1; j < 8; j++)
            {
                duplicateCount = duplicateCount + Convert.ToInt32(views[i] == views[j]);
            }
        }

        // Сравниваем соседние пары
        // Если текущий меньше следующего — нарушение убывания.
        int disorderCount = 0;
        for (int i = 0; i < 7; i++)
        {
            disorderCount = disorderCount + Convert.ToInt32(views[i] < views[i + 1]);
        }

        int duplicateFlag = Convert.ToInt32(duplicateCount > 0);
        int disorderFlag = Convert.ToInt32(disorderCount > 0);


        // 0 — всё ок; 1 — дубликаты; 2 — порядок; 3 — и то, и другое
        int messageIndex = duplicateFlag + disorderFlag * 2;

        string[] messages = new string[4];
        messages[0] = "Рейтинг тиктокеров:";
        messages[1] = "Ошибка! У тиктокеров одинаковые просмотры!";
        messages[2] = "Ошибка! Просмотры должны быть введены по убыванию!";
        messages[3] = "Ошибка! Есть дубликаты и порядок нарушен!";

        Console.WriteLine("\n" + messages[messageIndex]);

        int hasError = Convert.ToInt32(messageIndex > 0);
        int totalIterations = (1 - hasError) * 8;

        for (int i = 0; i < totalIterations; i++)
        {
            Console.WriteLine((i + 1) + " место: " + views[i] + " тыс. просмотров");
        }

        Console.ReadKey();
    }
}