
namespace sharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //Console.WriteLine("P45");
            //Console.WriteLine("Alex");

            //Console.BackgroundColor = ConsoleColor.Yellow;
            //Console.Clear();
            //Console.ForegroundColor = ConsoleColor.Blue;

            //Console.SetCursorPosition(10, 5);
            //Console.WriteLine("^_^");

            //Console.Title = "My Second C# App";

            //string? name = Console.ReadLine();

            //Console.WriteLine("Hello, World!");
            //Console.WriteLine("P45");
            //Console.WriteLine("Alex");

            //Console.ReadKey();

            //Console.SetWindowSize(15, 15);
            // ---------------------------------------------------------------------------
            //name насправді це не об'єкт, а посилання на об'єкт
            //об'єкт тут знаходиться справа від знаку рівності
            //string? name = "Alex";
            //string* name = new string("Alex");

            //#region якась лабуда
            //string name = "Alex";
            //int age = 36;
            //double weight = 70.5;
            //#endregion
            //#region якась іще лабуда
            //Console.WriteLine($"Hello, {{ my name is {name}, I am {age + 1} years old and I weigh {weight} kg.");
            //Console.WriteLine("Hello, my name is {0}, I am {1} years old and I weigh {2} kg.", name, age, weight);
            //Console.WriteLine("Hello, my name is " + name + ", I am " + age + " years old and I weigh " + weight + " kg.");
            //#endregion
            // ---------------------------------------------------------------------------
            //int age = 5;
            //Console.WriteLine(age.CompareTo(5));
            // ---------------------------------------------------------------------------
            //// наводимо на тип, якщо там структура - то це значимий тип з точки зору дот нет
            //int age = 25; // тут нема посилання, age - це вже об'єкт, і вданному випадку він буде розміщений на стеке
            //// наводимо на тип, якщо там клас - то це посилальний тип з точки зору дот нет
            //string name = "World"; // тут уже 2 сутності, це об'єкт типу стрінг, який розміщено в купі, і є посилання на цей об'єкт, яке розміщено на стеке
            //                       // string* name = new string("World");
            //                       // в дот нет немає вказівників, але є посилання, які працюють схоже на вказівники
            //                       // по факту, посилання це той самий покажчик, але без арифметики ++ -- * &
            //                       // string name = "Alex";
            //                       // в данному випадку, посилання знаходиться на стеке, а об'єкт в купі
            // ----------------------------------------------------------------------------
            //float a = 10 / 3.0F; // 4Б
            //Console.WriteLine(a);
            //double b = 10 / 3.0; // 8Б
            //Console.WriteLine(b);
            //decimal c = 10 / 3.0M; // 16Б
            //Console.WriteLine(c);

            //char c = '5';
            //Console.WriteLine(Char.IsLetter(c));
            // ---------------------------------------------------------------------------
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            //string name = "Олександр";
            //Console.WriteLine(name.ToUpper());
            //Console.WriteLine(name.Contains("лекс"));
            //name = name.Replace("кса", "Андрій");
            //Console.WriteLine(name);
            // ---------------------------------------------------------------------------
            //int num1;
            //int num2;
            //int num3;

            //Console.WriteLine("Input 3 numbers:");
            //num1 = int.Parse(Console.ReadLine());
            //num2 = int.Parse(Console.ReadLine());
            //num3 = int.Parse(Console.ReadLine());

            //Console.WriteLine("Mean value: " + (double)(num1 + num2 + num3) / 3);

            //// task 2
            //int a = 2;
            //int b = 12;

            //Console.WriteLine("Input a for ax + b = 0:");
            //a = int.Parse(Console.ReadLine());
            //Console.WriteLine("Input b for ax + b = 0:");
            //b = int.Parse(Console.ReadLine());

            //Console.WriteLine(a + "x + " + b + " = 0, x = " + (double)(-b / a));

            //// task 3
            //double nBase;
            //double power;

            //Console.WriteLine("Input base b:");
            //nBase = double.Parse(Console.ReadLine());
            //Console.WriteLine("Input power n:");
            //power = double.Parse(Console.ReadLine());

            //Console.WriteLine("b^n = " + Math.Pow(nBase, power));

            //// task 4
            //double r;
            //double pi = Math.PI;

            //Console.WriteLine("Input radius of a circle:");
            //r = double.Parse(Console.ReadLine());

            //Console.WriteLine("Area of the circle: " + pi * Math.Pow(r, 2) + "\nCircumfrence of the circle: " + 2 * pi * r);
            // ---------------------------------------------------------------------------
        }
    }
}