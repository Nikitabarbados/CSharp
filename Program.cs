// ------------------------------------------------------------------------
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Console_С_OOP4
{
    // ------------------------------------------------------------------------
    //{
    //    internal class Program
    //    {
    //        public static void Function(int a, int b, int c)
    //        {
    //            Console.WriteLine(a + " " + b + " " + c);
    //        }

    //        public static void Main()
    //        {
    //            Function(10, 20, 30); // a = 10, b = 20, c = 30
    //        }
    //    }
    //}
    // ------------------------------------------------------------------------
    //    class Program
    //    {
    //    public static void Function(int a = 0, int b = 0, int c = 0)
    //    {
    //        Console.WriteLine(a + " " + b + " " + c);
    //    }

    //    public static void Main()
    //        {
    //        Function(10, 20); // a = 10, b = 20, c = 0 (default)
    //        }
    //    }
    //}
    // ------------------------------------------------------------------------
    //    class Program
    //    {
    //        public static void Function(int a = 0, int b = 0, int c = 0)
    //        {
    //            Console.WriteLine(a + " " + b + " " + c);
    //        }

    //        public static void Main()
    //        {
    //            Function(c: 15, a: 20, b: 25); // named parameters
    //            Function(c: 15, a: 20); // named parameters
    //        }
    //    }
    //}
    // ------------------------------------------------------------------------
    //    class Program
    //    {
    //        public static void Function(int a, int b, int c)
    //        {
    //            Console.WriteLine(a + " " + b + " " + c);
    //        }

    //        public static void Main()
    //        {
    //            Function(c: 15, a: 20, b: 25); // named parameters
    //            Function(c: 15, a: 20); // error!
    //        }
    //    }
    //}
    // ------------------------------------------------------------------------
    //    class Program
    //    {
    //        public static void Main()
    //        {
    //            int x = 10;
    //            double d = 3.14;
    //            Program p = new Program();
    //            Console.WriteLine(nameof(x));
    //            Console.WriteLine(nameof(d));
    //            Console.WriteLine(nameof(p));
    //        }
    //    }
    //}
    // ------------------------------------------------------------------------
    //    class Program
    //    {
    //        public static void Main()
    //        {
    //            Console.WriteLine(); // cw
    //            for (int i = 0; i < length; i++) // for
    //            {
    //            }
    //            for (int i = length - 1; i >= 0; i--) // forr
    //            {
    //            }
    //        }
    //    }
    //}
    // ------------------------------------------------------------------------
    //    class Program
    //    {
    //        static void Main()
    //        {
    //            Console.InputEncoding = Encoding.UTF8;
    //            Console.OutputEncoding = Encoding.UTF8;

    //            // демонстрація іменованих параметрів та оператора nameof
    //            // метод з параметрами, які можна викликати з іменованими аргументами
    //            // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments
    //            DisplayMessage(
    //                message: "привіт, світe!",  // іменований параметр message
    //                color: ConsoleColor.Blue,  // іменований параметр color
    //                repeat: 3                  // іменований параметр repeat
    //            );

    //            // використання nameof для отримання імені параметра як рядка
    //            // https://learn.microsoft.com/uk-ua/dotnet/csharp/language-reference/operators/nameof
    //            string paramName = nameof(ConsoleColor.Blue);
    //            Console.WriteLine($"колір задано за допомогою nameof: {paramName}");

    //            // ще один приклад: перевірка імені змінної
    //            int value = 42;
    //            Console.WriteLine($"значення змінної {nameof(value)}: {value}");
    //        }

    //        // метод, який демонструє іменовані параметри
    //        static void DisplayMessage(string message, ConsoleColor color = ConsoleColor.White, int repeat = 1)
    //        {
    //            Console.ForegroundColor = color;
    //            for (int i = 0; i < repeat; i++)
    //            {
    //                Console.WriteLine(message);
    //            }
    //            Console.ResetColor();
    //        }
    //    }
    //}

    // https://learn.microsoft.com/uk-ua/previous-versions/visualstudio/visual-studio-2015/ide/visual-csharp-code-snippets
    /*
    список сніпетів для c# у visual studio (стандартні сніпети з vs 2022, актуальні для .net 9)
    | shortcut               | description                                                                 |
    |------------------------|-----------------------------------------------------------------------------|
    | #if      |             | створює директиву #if та #endif. |
    | #region  |             | створює директиву #region та #endregion. |
    | ~        |             | створює фіналізатор (деструктор) для класу. |
    | attribute|             | створює оголошення класу, що походить від Attribute. |
    | checked  |             | створює блок checked. |
    | class    |             | створює оголошення класу. |
    | ctor     |             | створює конструктор для класу. |
    | cw       |             | створює виклик Console.WriteLine. |
    | do       |             | створює цикл do while. |
    | else     |             | створює блок if-else. |
    | enum     |             | створює оголошення enum. |
    | equals   |             | створює метод, що перевизначає Equals з класу Object. |
    | exception|             | створює оголошення класу, що походить від Exception. |
    | for      |             | створює цикл for. |
    | foreach  |             | створює цикл foreach. |
    | forr     |             | створює цикл for з декрементом змінної. |
    | if       |             | створює блок if. |
    | indexer  |             | створює оголошення індексатора. |
    | interface|             | створює оголошення інтерфейсу. |
    | invoke   |             | створює блок для безпечного виклику події. |
    | iterator |             | створює ітератор. |
    | iterindex|             | створює іменований ітератор та індексатор за допомогою вкладеного класу. |
    | lock     |             | створює блок lock. |
    | mbox     |             | створює виклик System.Windows.Forms.MessageBox.Show (може знадобитися додати посилання). |
    | namespace|             | створює оголошення namespace. |
    | prop     |             | створює автореалізовану властивість. |
    | propfull |             | створює оголошення властивості з get та set. |
    | propg    |             | створює тільки для читання автореалізовану властивість з приватним set. |
    | sim      |             | створює статичний int Main метод. |
    | struct   |             | створює оголошення struct. |
    | svm      |             | створює статичний void Main метод. |
    */

    // ------------------------------------------------------------------------
    //    class Program
    //    {
    //        static void Main(string[] args) // svm
    //        {
    //        }
    //    }
    //}
    // ------------------------------------------------------------------------
    //    class Program
    //    {
    //        static void Main(string[] args) // svm
    //        {
    //            int[] ar = new int[5]; // 0 0 0 0 0
    //                                   // статичних масивів більше нема!
    //                                   // Array ar = new Array(int, 5);
    //            foreach (int elem in ar)
    //            { // elem = ar[0], elem = ar[1] ... elem -- copy!!!
    //              // elem = 10; // elem - readonly
    //                Console.WriteLine(elem);
    //            }
    //        }
    //    }
    //}
    // ------------------------------------------------------------------------
    //    class Program
    //    {
    //        static void Main(string[] args) // svm
    //        {
    //            int[] ar = new int[5] { 10, 20, 33, 50, 75 };
    //            // статичних масивів більше нема!
    //            // Array ar = new Array(int, 5);
    //            foreach (int elem in ar)
    //            { // elem = ar[0], elem = ar[1] ... elem -- copy!!!
    //              // elem = 10; // elem - readonly
    //                Console.WriteLine(elem);
    //            }
    //        }
    //    }
    //}
    // ------------------------------------------------------------------------
    //    class Program
    //    {
    //        static void Main(string[] args) // svm
    //        {
    //            int[] ar = [10, 20, 33, 50, 75, 123, 234, 23, 42, 34, 34, 53, 45, 3, 65, 3, 56, 345, 634, 5];
    //            // статичних масивів більше нема!
    //            // Array ar = new Array(int, 5);
    //            foreach (int elem in ar)
    //            { // elem = ar[0], elem = ar[1] ... elem -- copy!!!
    //              // elem = 10; // elem - readonly
    //                Console.WriteLine(elem);
    //            }
    //        }
    //    }
    //}
    // ------------------------------------------------------------------------
    //    class Program
    //    {
    //        static void Main(string[] args) // svm
    //        {
    //            int[,] ar = new int[4, 5]; // 4 рядка, 5 стовпчиків

    //            foreach (int elem in ar)
    //            {
    //                Console.WriteLine(elem);
    //            }
    //        }
    //    }
    //}
    // ------------------------------------------------------------------------
    //    class Program
    //    {
    //        static void Main(string[] args) // svm
    //        {
    //            int[,] ar = new int[4, 5]; // 4 рядка, 5 стовпчиків
    //            for (int y = 0; y < ar.GetLength(0); y++) // rows
    //            {
    //                for (int x = 0; x < ar.GetLength(1); x++) // columns
    //                {
    //                    Console.Write(ar[y, x] + " ");
    //                }
    //                Console.WriteLine();
    //                Console.WriteLine();
    //            }
    //        }
    //    }
    //}
    // ------------------------------------------------------------------------
    //    class Program
    //    {
    //        static void Main(string[] args) // svm
    //        {
    //            var r = new Random();

    //            int[,] ar = new int[4, 5]; // 4 рядка, 5 стовпчиків

    //            for (int y = 0; y < ar.GetLength(0); y++) // rows
    //            {
    //                for (int x = 0; x < ar.GetLength(1); x++) // columns
    //                {
    //                    ar[y, x] = r.Next(0, 10); // 0...9
    //                    Console.Write(ar[y, x] + " ");
    //                }
    //                Console.WriteLine();
    //                Console.WriteLine();
    //            }
    //        }
    //    }
    //}
    // ------------------------------------------------------------------------
    //    class Program
    //    {
    //        static void Main(string[] args)
    //        {
    //            int[,] ar = new int[10, 10];
    //            int value = 1;

    //            for (int y = 0; y < 10; y++)
    //            {
    //                if (y % 2 == 0)
    //                {
    //                    for (int x = 0; x < 10; x++)
    //                        ar[y, x] = value++;
    //                }
    //                else
    //                {
    //                    for (int x = 9; x >= 0; x--)
    //                        ar[y, x] = value++;
    //                }
    //            }

    //            for (int y = 0; y < 10; y++)
    //            {
    //                for (int x = 0; x < 10; x++)
    //                    Console.Write(ar[y, x] + " ");
    //                Console.WriteLine();
    //            }
    //        }
    //    }
    //}
    // ------------------------------------------------------------------------
    //    static void Method1()
    //    {
    //        string text = "Бла 25 грн бла бла... Сьогодні 45 ₴ курс долара становить 15 гривен";
    //        var regex = new Regex(@"\s?\d+((\.|,)\d+)? ?((грн)|(гривень?)|(₴))?\.?"); // (\s\d+(\.\d+)? грн\.)

    //        Match match = regex.Match(text);

    //        while (match.Success)
    //        {
    //            Console.WriteLine("позиція: " + match.Index + "; значення: " + match.Value);
    //            match = match.NextMatch(); // для циклу while
    //        }
    //        Console.WriteLine();
    //    }
    //}
    // ------------------------------------------------------------------------
    //Console.WriteLine("hello!");

    // using System;      // додається автоматично, якщо потрібно
    // using System.Text;
    //
    // internal partial class Program  // назва: Program, partial для сумісності з user-кодом
    // {
    //     // top-level змінні/поля тут (якщо є глобальні, але в цьому прикладі — все локально в Main)
    //
    //     [CompilerGenerated]  // атрибут компілятора для auto-generated
    //     [System.Runtime.CompilerServices.CompilerGenerated]
    //     private static void <Main>$(string[] args)  // сигнатура: void Main (без args у виводі, бо не використовуємо)
    //     {
    //         // сюди вставляються ВСІ top-level statements ПОСЛІДОВНО:
    //         // (компілятор переносить їх сюди, зберігаючи порядок)

    // Console.WriteLine("hello!");
    // }
    // }
    // }
    // ------------------------------------------------------------------------
    //    partial class Cat // model
    //    {
    //        private string nick = "Barsik";
    //        private int age = 2;

    //        public Cat()
    //        {
    //            Console.WriteLine("c-tor");
    //        }
    //    }

    //    partial class Cat // view
    //    {
    //        public Cat(string nick, int age)
    //        {
    //            this.nick = nick;
    //            this.age = age;
    //        }

    //        public override string? ToString()
    //        {
    //            return nick + " " + age;
    //        }
    //    }

    //    class Program
    //    {
    //        static void Main(string[] args)
    //        {
    //            Cat c = new Cat();
    //            Console.WriteLine(c);
    //        }
    //    }
    //}
    // ------------------------------------------------------------------------
    //    class User
    //    {
    //        public static int count;
    //        // private static int test = GetSomeDataFromInternet();
    //        // private static

    //        static User()
    //        {
    //            // іноді в класі БАГАТО статичних полів (5 або більше)
    //            // іноді ініціалізація цих полів СКЛАДНА (значення треба отримати через один або навіть більше викликів пених методів
    //            // всі ці методи можуть працювати довго, це можуть бути мережеві запити, це може бути звернення до БД

    //            // статичний конструктор призначений як раз для таких рідкісних ситуацій
    //            // 1) всі статичні поля можна буде проініціалізувати в одному місці
    //            // 2) в такому конструкторі можна запустити додаткові потоки

    //            // параметрів такий конструктор не приймає (і тому його не можна перевантажити)
    //            // робити його не обов'язково, і якщо його явно немає, то його компілятор не зробить
    //            // конструктор спрацює в одному з 2 випадків:
    //            // 1) при створенні ПЕРШОГО об'єкта поточного класу
    //            // 2) при зверненні до будь якого статичного поля або методу

    //            count = 0;
    //            // another static fields initialization 
    //            Console.WriteLine("STATIC C-TOR");
    //        }

    //        public User()
    //        {
    //            Console.WriteLine("C-TOR WITHOUT PARAMETERS");
    //        }
    //    }

    //    class Program
    //    {
    //        static void Main()
    //        {
    //            Console.OutputEncoding = Encoding.UTF8;

    //            Console.WriteLine(User.count);
    //            // User x = new User();
    //            //new User();
    //            //new User();


    //        }
    //    }
    //}
// ------------------------------------------------------------------------

// ------------------------------------------------------------------------

// ------------------------------------------------------------------------

// ------------------------------------------------------------------------

// ------------------------------------------------------------------------

// ------------------------------------------------------------------------

// ------------------------------------------------------------------------