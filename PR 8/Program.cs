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

        // === Ввод через do-while ===
        Console.WriteLine("Введите просмотры 8 тиктокеров по убыванию:");
        int i = 0;
        do
        {
            Console.Write("Просмотры тиктокера №" + (i + 1) + ": ");
            views[i] = int.Parse(Console.ReadLine());
            i++;
        }
        while (i < 8);

        // === Проверка порядка через do-while ===
        int disorderCount = 0;
        int k = 0;
        do
        {
            disorderCount = disorderCount + Convert.ToInt32(views[k] < views[k + 1]);
            k++;
        }
        while (k < 7);

        // === Флаг ошибки: 0 — ок, 1 — есть нарушения ===
        int errorFlag = Convert.ToInt32(disorderCount > 0);

        // === Сообщение об ошибке ===
        string[] errorMessages = new string[2];
        errorMessages[0] = "";
        errorMessages[1] = "Ошибка! Просмотры должны быть введены по убыванию!";

        Console.WriteLine(errorMessages[errorFlag]);
        // === Вывод рейтинга через do-while ===
        // Внутри тела выбираем строку по индексу errorFlag:
        //   errorFlag = 0 → ratingLines[1] (рейтинг)
        //   errorFlag = 1 → ratingLines[0] (пустая строка)
        int m = 0;
        do
        {
            string[] ratingLines = new string[2];
            ratingLines[0] = "";   // при ошибке — пусто
            ratingLines[1] = (m + 1) + " место: " + views[m] + " тыс. просмотров";

           
            Console.WriteLine(ratingLines[1 - errorFlag]);

            m++;
        }
        while (m < 8);

        Console.ReadKey();
    }
}