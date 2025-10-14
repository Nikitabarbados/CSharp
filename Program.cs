namespace sharp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 1
            Console.WriteLine("1. Середнє арифметичне трьох чисел");
            double a, b, c;
            Console.Write("Введіть a: ");
            a = double.Parse(Console.ReadLine());
            Console.Write("Введіть b: ");
            b = double.Parse(Console.ReadLine());
            Console.Write("Введіть c: ");
            c = double.Parse(Console.ReadLine());
            Console.WriteLine("Середнє = " + (a + b + c) / 3);
            Console.WriteLine();

            // 3
            Console.WriteLine("3. Ступінь числа");
            double num, pow;
            Console.Write("Число: ");
            num = double.Parse(Console.ReadLine());
            Console.Write("Ступінь: ");
            pow = double.Parse(Console.ReadLine());
            Console.WriteLine("Результат = " + (num, pow));
            Console.WriteLine();

            // 4
            Console.WriteLine("4. Площа і довжина кола");
            const double pi = 3.14159;
            double r;
            Console.Write("Радіус: ");
            r = double.Parse(Console.ReadLine());
            Console.WriteLine("Площа = " + (pi * r * r));
            Console.WriteLine("Довжина = " + (2 * pi * r));
            Console.WriteLine();

            // 5
            Console.WriteLine("5. Гривні в долари і євро");
            double uah;
            Console.Write("Гривні: ");
            uah = double.Parse(Console.ReadLine());
            Console.WriteLine("Долари = " + (uah / 41));
            Console.WriteLine("Євро = " + (uah / 44));
            Console.WriteLine();

            // 6
            Console.WriteLine("6. Кілометри в милі");
            double km;
            Console.Write("Кілометри: ");
            km = double.Parse(Console.ReadLine());
            Console.WriteLine("Сухопутні милі = " + (km * 0.621371));
            Console.WriteLine("Морські милі = " + (km / 1.852));
            Console.WriteLine();

            // 7
            Console.WriteLine("7. Відсоток P від числа N");
            double N, P;
            Console.Write("N: ");
            N = double.Parse(Console.ReadLine());
            Console.Write("P: ");
            P = double.Parse(Console.ReadLine());
            Console.WriteLine("Результат = " + (N * P / 100));
            Console.WriteLine();

            // 8
            Console.WriteLine("8. Температура");
            double cels, fahr;
            Console.Write("Цельсій: ");
            cels = double.Parse(Console.ReadLine());
            fahr = (cels * 9 / 5) + 32;
            Console.WriteLine("Фаренгейт = " + fahr);

            Console.Write("Фаренгейт: ");
            fahr = double.Parse(Console.ReadLine());
            cels = (fahr - 32) * 5 / 9;
            Console.WriteLine("Цельсій = " + cels);
        }
    }
}
