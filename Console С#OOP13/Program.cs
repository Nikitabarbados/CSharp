using System;
using System.Text;
using System.Reflection;
// -----------------------------------------------------------------
//static void Main()
//{
//    while (true)
//    {
//        Thread.Sleep(1000);
//        Console.WriteLine("234");
//    }
//}
// -----------------------------------------------------------------
//class Program
//{
//    static void Method1()
//    {
//        while (true)
//        {
//            Console.WriteLine("1");
//            Thread.Sleep(1000);
//        }
//    }

//    static void Main()
//    {
//        Thread t = new Thread(Method1);
//        t.Start();

//        while (true)
//        {
//            Console.WriteLine("main");
//            Thread.Sleep(1511);
//        }
//    }
//}
// -----------------------------------------------------------------
//class Program
//{
//    // написано кілька методів для майбутніх посилань на них
//    static int Summ(int a, int b)
//    {
//        Console.WriteLine("сума двох цілих чисел: ");
//        return a + b;
//    }

//    static int Diff(int a, int b)
//    {
//        Console.WriteLine("різниця двох цілих чисел: ");
//        return a - b;
//    }

//    static int Product(int a, int b)
//    {
//        Console.WriteLine("добуток двох цілих чисел: ");
//        return a * b;
//    }

//    // створено тип делегата для посилань на методи з відповідною сигнатурою
//    // це посилальний тип для об'єктів-покажчиків на методи
//    // рядок нижче просто визначає тип, і поки не створює ніякі об'єкти!
//    // https://mattwarren.org/2017/01/25/How-do-.NET-delegates-work/
//    delegate int MyPointerTypeToSomeMethod(int first, int second); // локальний делегат

//    // CLR розгортає цей рядок, і створює посилальний тип, подібний до такого класу (дуже спрощено):
//    /*
//    class MyPointerTypeToSomeMethod : MulticastDelegate
//    {
//        // внутрішній захищений конструктор, що ініціалізує делегат з target (об'єкт) та methodptr (покажчик на метод)
//        protected MyPointerTypeToSomeMethod(object target, IntPtr methodPtr) : base(target, methodPtr) { }

//        // при new MyPointerTypeToSomeMethod(Summ): jit компілятор інлайнить виклик конструктора через COMDelegate::GetDelegateCtor()
//        // для статичного методу: _target = null, _methodPtrAux = pointer на Summ

//        // invoke генерується компілятором з точною сигнатурою делегата, віртуальний для перевизначення
//        public virtual int Invoke(int first, int second);

//        // методи для асинхронного виклику, надаються CLR для всіх делегатів
//        public virtual IAsyncResult BeginInvoke(int first, int second, AsyncCallback? callback, object? state);

//        public virtual int EndInvoke(IAsyncResult result);
//    }
//    */

//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        // приклад створення посилання на делегат
//        // без об'єкта посилання не використовувати
//        MyPointerTypeToSomeMethod ptr = Summ;

//        // ініціалізація делегата: створено об'єкт, що інкапсулює покажчик на метод
//        // ptr тепер указує на метод summ
//        ptr = new MyPointerTypeToSomeMethod(Summ);

//        // альтернативний синтаксис: пряме присвоєння
//        ptr = Summ;

//        // косвений виклик через делегат
//        Console.WriteLine($"результат виклику summ: {ptr(10, 15)}");

//        // приклад з diff
//        MyPointerTypeToSomeMethod ptrDiff = Diff;
//        Console.WriteLine($"результат виклику diff: {ptrDiff(20, 5)}");

//        // приклад з product
//        MyPointerTypeToSomeMethod ptrProduct = Product;
//        Console.WriteLine($"результат виклику product: {ptrProduct(10, 15)}");

//        // var автоматично підбере тип делегата на основі методу
//        // var test = Summ;

//        // локальні делегати рідко застосовуються на практиці, зазвичай вони або в загальній видимості, або використовують вбудовані Func<> та Action<>
//    }
//}
// -----------------------------------------------------------------
// делегати можна робити як для користувацьких методів, так і для вбудованих
//class Program
//{
//    struct Person
//    {
//        public string FirstName;
//        public string LastName;
//        public DateTime BirthDay;

//        public Person(string FirstName, string LastName, DateTime BirthDay)
//        {
//            this.FirstName = FirstName;
//            this.LastName = LastName;
//            this.BirthDay = BirthDay;
//        }

//        public override string ToString()
//        {
//            return $"Ім'я: {FirstName} {LastName}; Дата народження: {BirthDay:d}.";
//        }

//        public static string GetTypeName() { return "Людина"; }
//    }

//    private delegate string StringData();

//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        var bd = new DateTime(1989, 3, 10);
//        var p = new Person("Олександр", "Загоруйко", bd);

//        var del = bd.ToLongDateString; // делегат на вбудований метод структури DateTime
//        Console.WriteLine(del());

//        del = p.ToString; // делегат на користувацький екземплярний метод
//        Console.WriteLine(del());

//        del = Person.GetTypeName; // делегат на користувацький статичний метод
//        Console.WriteLine(del());
//    }
//}
// -----------------------------------------------------------------
//class Program
//{
//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        // колекція персон для сортування
//        Person[] persons = {
//            new Person("Богдан", "Шевченко", new DateTime(1996, 1, 1)),
//            new Person("Галина", "Котляревська", new DateTime(1992, 11, 6)),
//            new Person("Олександр", "Довженко", new DateTime(1991, 5, 11)),
//            new Person("Віра", "Лесько", new DateTime(1990, 10, 8))
//        };

//        // вивід до сортування
//        Console.WriteLine("до сортування:\n");
//        foreach (var person in persons) Console.WriteLine(person);

//        // сортування за ім'ям
//        Console.WriteLine("\nпісля сортування за ім'ям:\n");
//        Sorter<Person>.BubbleSort(persons, PersonFirstnameComparer);
//        foreach (var person in persons) Console.WriteLine(person);

//        // сортування за прізвищем
//        Console.WriteLine("\nпісля сортування за прізвищем:\n");
//        Sorter<Person>.BubbleSort(persons, PersonLastnameComparer);
//        foreach (var person in persons) Console.WriteLine(person);

//        // сортування за датою народження
//        Console.WriteLine("\nпісля сортування за датою народження:\n");
//        Sorter<Person>.BubbleSort(persons, PersonBirthdayComparer);
//        foreach (var person in persons) Console.WriteLine(person);

//        Console.WriteLine("\nдемонстрація делегатів завершена.");
//    }

//    public class Person
//    {
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public DateTime Birthday { get; set; }

//        public Person(string firstName, string lastName, DateTime birthday)
//        {
//            FirstName = firstName;
//            LastName = lastName;
//            Birthday = birthday;
//        }

//        public override string ToString()
//        {
//            return $"{FirstName,-10} : {LastName,-12} : {Birthday:dd.MM.yyyy}.";
//        }
//    }

//    // статичний клас для сортування, generic (<T>) для універсальності
//    static class Sorter<T>
//    {
//        // кастомний делегат для компаратора !!!
//        public delegate bool Comparer(T obj1, T obj2);

//        // бульбашкове сортування з оптимізацією (зупинка при відсутності обмінів)
//        public static void BubbleSort(T[] array, Comparer del)
//        {
//            bool swapped;
//            for (int i = 0; i < array.Length - 1; i++)
//            {
//                swapped = false;
//                for (int j = 0; j < array.Length - i - 1; j++)
//                {
//                    if (del(array[j + 1], array[j]))
//                    {
//                        T temporary = array[j];
//                        array[j] = array[j + 1];
//                        array[j + 1] = temporary;
//                        swapped = true;
//                    }
//                }
//                // якщо без обмінів, масив відсортований
//                if (!swapped) break;
//            }
//        }
//    }

//    // компаратор за ім'ям, повертає true якщо obj1 < obj2
//    static bool PersonFirstnameComparer(Person o1, Person o2)
//    {
//        return o1.FirstName.CompareTo(o2.FirstName) < 0;
//    }

//    // компаратор за прізвищем
//    static bool PersonLastnameComparer(Person o1, Person o2)
//    {
//        return o1.LastName.CompareTo(o2.LastName) < 0;
//    }

//    // компаратор за датою народження (раніше = менше)
//    static bool PersonBirthdayComparer(Person o1, Person o2)
//    {
//        return o1.Birthday < o2.Birthday;
//    }
//}
// -----------------------------------------------------------------
//IComparable - 2 об'єкти (один порівнює себе з іншим)

//IComparer - 3 об'єкти (один порівнює 2 інших)
// -----------------------------------------------------------------
//class Program
//{
//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        Person[] persons = {
//            new Person("Богдан", "Шевченко", new DateTime(1996, 1, 1)),
//            new Person("Галина", "Котляревська", new DateTime(1992, 11, 6)),
//            new Person("Олександр", "Довженко", new DateTime(1991, 5, 11)),
//            new Person("Віра", "Лесько", new DateTime(1990, 10, 8))
//        };

//        Console.WriteLine("до сортування:\n");
//        foreach (var person in persons) Console.WriteLine(person);

//        Console.WriteLine("\nпісля сортування за ім'ям:\n");
//        Sorter<Person>.BubbleSort(persons, PersonFirstnameComparer);
//        foreach (var person in persons) Console.WriteLine(person);

//        Console.WriteLine("\nпісля сортування за прізвищем:\n");
//        Sorter<Person>.BubbleSort(persons, PersonLastnameComparer);
//        foreach (var person in persons) Console.WriteLine(person);

//        Console.WriteLine("\nпісля сортування за датою народження:\n");
//        Sorter<Person>.BubbleSort(persons, PersonBirthdayComparer);
//        foreach (var person in persons) Console.WriteLine(person);

//        Console.WriteLine("\nпісля сортування за довжиною прізвища (довгі → короткі):\n");
//        Sorter<Person>.BubbleSort(persons, PersonLastnameLengthComparer);
//        foreach (var person in persons) Console.WriteLine(person);

//        Console.WriteLine("\nдемонстрація делегатів завершена.");
//    }
//    public class Person
//    {
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public DateTime Birthday { get; set; }
//        public Person(string firstName, string lastName, DateTime birthday)
//        {
//            FirstName = firstName;
//            LastName = lastName;
//            Birthday = birthday;
//        }
//        public override string ToString()
//        {
//            return $"{FirstName,-10} : {LastName,-15} : {Birthday:dd.MM.yyyy}.";
//        }
//    }
//    static class Sorter<T>
//    {
//        public delegate bool Comparer(T obj1, T obj2);
//        public static void BubbleSort(T[] array, Comparer del)
//        {
//            bool swapped;
//            for (int pr = 0; pr < array.Length - 1; pr++)
//            {
//                swapped = false;
//                for (int index = array.Length - 1; index > 0; index--)
//                {
//                    if (del(array[index], array[index - 1]))
//                    {
//                        T temporary = array[index];
//                        array[index] = array[index - 1];
//                        array[index - 1] = temporary;
//                        swapped = true;
//                    }
//                }
//                if (!swapped) break;
//            }
//        }
//    }
//    static bool PersonFirstnameComparer(Person o1, Person o2)
//    {
//        return o1.FirstName.CompareTo(o2.FirstName) < 0;
//    }
//    static bool PersonLastnameComparer(Person o1, Person o2)
//    {
//        return o1.LastName.CompareTo(o2.LastName) < 0;
//    }
//    static bool PersonBirthdayComparer(Person o1, Person o2)
//    {
//        return o1.Birthday < o2.Birthday;
//    }
//    static bool PersonLastnameLengthComparer(Person o1, Person o2)
//    {
//        return o1.LastName.Length > o2.LastName.Length;
//    }
//}
// -----------------------------------------------------------------
//class Program
//{
//    delegate void VoidDelegate(double a, double b);
//    delegate double DoubleDelegate(double a, double b);

//    // ===================================================================

//    static void Sum(double a, double b)
//    {
//        Console.WriteLine($"сума: {a + b}");
//    }

//    static void Difference(double a, double b)
//    {
//        Console.WriteLine($"різниця: {a - b}");
//    }

//    static void Product(double a, double b) // добуток
//    {
//        Console.WriteLine($"добуток: {a * b}");
//    }

//    static void Quotient(double a, double b) // частка
//    {
//        Console.WriteLine($"частка: {a / b}");
//    }

//    // ===================================================================

//    static double SumFunc(double a, double b)
//    {
//        return a + b;
//    }

//    static double DifferenceFunc(double a, double b)
//    {
//        return a - b;
//    }

//    static double ProductFunc(double a, double b) // добуток
//    {
//        return a * b;
//    }

//    static double QuotientFunc(double a, double b) // частка
//    {
//        return a / b;
//    }

//    // ===================================================================

//    public static void Main(string[] args)
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        // приклад з void делегатом
//        Console.WriteLine("Приклад з void делегатом:");
//        VoidDelegate? vd = Sum;
//        vd += Difference; // додаємо метод до invocation list в ланцюжок
//        vd += Product;
//        vd += Quotient;

//        vd -= Product;
//        // втім, замість рядка вище можна використати, для спокою:
//        // vd = vd is not null ? (VoidDelegate?)Delegate.Remove(vd, Product) : null;
//        // але якщо методу в ланцюжку немає, то нічого страшного все одно не станеться

//        if (vd != null) // можна і так: vd?.Invoke(70, 2);
//        { // можна і без перевірки, бо ми точно знаємо, що vd не null
//            vd(70, 2);
//        }
//        Console.ReadKey();

//        // ===================================================================

//        // приклад з double делегатом
//        Console.WriteLine("\nПриклад з double делегатом:");
//        DoubleDelegate dd = SumFunc;
//        dd += DifferenceFunc;
//        dd += ProductFunc;
//        dd += QuotientFunc;
//        dd -= ProductFunc;
//        double result = dd(70, 2);
//        Console.WriteLine($"результат: {result}");
//        Console.ReadKey();

//        // ===================================================================

//        // рефлексія над invocation list void делегата
//        Console.WriteLine("\nInvocation list void делегата:");
//        VoidDelegate vd2 = Sum;
//        vd2 += Difference;
//        vd2 += Product;
//        vd2 += Quotient;

//        for (int i = 0; i < vd2?.GetInvocationList().Length; i++)
//        {
//            MethodInfo mi = vd2.GetInvocationList()[i].Method;
//            Console.Write("Назва методу в ланцюжку - " + mi.Name + ": ");
//            mi.Invoke(null, [5, 7]);
//        }
//        Console.ReadKey();

//        // ===================================================================

//        // рефлексивно отримуємо інформацію про метод Main
//        Console.WriteLine("\nРефлексія:");
//        Type t = typeof(Program);
//        MethodInfo? mainMi = t.GetMethod("Main", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
//        Console.WriteLine($"параметр методу Main називається: {mainMi?.GetParameters()[0].Name}");

//        // отримуємо всі приватні статичні методи класу string
//        MethodInfo[] ar = typeof(string).GetMethods(BindingFlags.NonPublic | BindingFlags.Static);
//        Console.WriteLine("приватні статичні методи string:");
//        foreach (var m in ar)
//        {
//            Console.WriteLine(m.Name);
//        }
//    }
//}

///* // ще приклад використання ланцюжку
//class Program
//{
//    delegate void MakeBurger();

//    static void AddBun()
//    {
//        Console.WriteLine($"додаємо булку");
//    }

//    static void AddPatty(string ingredient)
//    {
//        Console.WriteLine($"додаємо котлету");
//    }

//    static void AddVeggies(string ingredient)
//    {
//        Console.WriteLine($"додаємо овочі");
//    }

//    static void Main()
//    {
//        MakeBurger prepare = AddBun;
//        prepare += AddPatty;
//        prepare += AddCheese;
//        prepare += AddCheese;
//        prepare += AddCheese;
//        prepare += AddVeggies;
//        prepare += AddBun;

//        Console.WriteLine("Приготування бургера:");
//        prepare();
//    }
//}
//*/
// -----------------------------------------------------------------
//функція - іменований відрізок коду
// -----------------------------------------------------------------
//class Program
//{
//    delegate void MakeBurger();

//    static void AddBun()
//    {
//        Console.WriteLine($"додаємо булку");
//    }

//    static void AddVeggies()
//    {
//        Console.WriteLine($"додаємо овочі");
//    }

//    static void AddCheese()
//    {
//        Console.WriteLine($"додаємо сир");
//    }

//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        MakeBurger prepare = AddBun;
//        prepare += delegate () {
//            Console.WriteLine("Kakleta");
//            Console.WriteLine("Pureshka");
//            Console.WriteLine("Kakleta");
//        };
//        prepare += AddCheese;
//        prepare += AddCheese;
//        prepare += AddCheese;
//        prepare += AddVeggies;
//        prepare += AddBun;

//        Console.WriteLine("Приготування бургера:");
//        prepare();
//    }
//}
// -----------------------------------------------------------------
//class Program
//{
//    delegate int MakeBurger(string ing);

//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        MakeBurger prepare = delegate (string param) {
//            Console.WriteLine("Kakleta");
//            Console.WriteLine("Pureshka");
//            Console.WriteLine("Kakleta");
//            return 10;
//        };


//        Console.WriteLine("Приготування бургера:");
//        prepare("test");
//    }
//}
// -----------------------------------------------------------------
//class Program
//{
//    // сигнатура делегата без параметрів
//    delegate void AnonymousVoid();

//    // сигнатура делегата з параметрами
//    delegate void AnonymousWithParams(int begin, int end);

//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        // використовуємо анонімний метод без параметрів
//        // анонімний метод — це метод без імені, що реалізує делегат
//        AnonymousVoid a = delegate
//        {
//            var info = new DirectoryInfo("C:\\");
//            foreach (DirectoryInfo d in info.GetDirectories())
//                Console.WriteLine(d.Name);
//        };

//        a(); // запускаємо

//        // ======================================================================================

//        // використовуємо анонімний метод з параметрами
//        AnonymousWithParams del = delegate (int a, int b)
//        {
//            Console.Write("Сьогодні {0}-й день року. До нового року ще {1} дні(в).\n", a, b - a);
//        };

//        // обчислюємо номер поточного дня в році програмно
//        // dayofyear — властивість datetime, що повертає номер дня (1-365/366)
//        int currentYear = DateTime.Now.Year;
//        int totalDays = DateTime.IsLeapYear(currentYear) ? 366 : 365;
//        int currentDay = DateTime.Now.DayOfYear;

//        del(currentDay, totalDays); // викликаємо з динамічними значеннями
//    }
//}
// -----------------------------------------------------------------
//delegate void AnonymousWithParams(int begin, int end);

//static void Method(AnonymousVoid func)
//{
//    func();
//}
//static void Main()
//{
//    Console.OutputEncoding = Encoding.UTF8;

//    Method(delegate {
//        var info = new DirectoryInfo("C:\\");
//        foreach (var d in info.GetDirectories())
//            Console.WriteLine(d.Name + ": " + d.CreationTime + " " + d.LastAccessTime + " " + d.LastWriteTime);
//    });
// -----------------------------------------------------------------
//class Program
//{
//    static int first = 777;
//    static int second = 1000;

//    // метод для запуску потоку з анонімним методом як аргументом
//    // анонімний метод передається як делегат threadstart
//    static void AnotherThread(ThreadStart action)
//    {
//        var t = new Thread(action); // створення вторинного потоку
//        t.IsBackground = true; // вторинний потік став фоновим (завершиться разом з головним)
//        t.Start(); // запуск вторинного потоку
//    }

//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        // передаємо анонімний метод як аргумент для створення потоку
//        // анонімний метод виконує корисну роботу — виводить символи в циклі
//        AnotherThread(delegate // по факту, це передача набору інструкцій, прописаних на колінці :)
//        {
//            for (int i = 0; i < second; i++)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.Write("+");
//                Thread.Sleep(10);
//            }
//        });

//        // цикл у головному потоці
//        for (int i = 0; i < first; i++)
//        {
//            Console.ForegroundColor = ConsoleColor.Blue;
//            Console.Write("-");
//            Thread.Sleep(10);
//        } // потоки не синхронізовані, тому символи виводяться у довільному порядку та іноді не тим кольором
//    }
//}
// -----------------------------------------------------------------
//class Program
//{
//    /* лямбда-вирази — це по суті заміна анонімним методам, черговий синтаксичний цукор :)

//у всіх лямбда-виразах має бути лямбда-оператор =>.
//цей оператор розділяє вираз на дві частини:
//1) у лівій частині — параметри (їх може бути 0 або більше)
//2) у правій частині — тіло методу

//бувають одиночні (однорядкові) та блочні лямбда-вирази.
//усе дуже просто, якщо після циклу for або оператора if йде одна строка коду,
//то зовсім не треба включати цей рядок в фігурні дужки.
//це стосується й одиночних лямбда-виразів,
//а от якщо у виразі декілька рядків, то потрібно буде захопити цей блок у фігурні дужки.

//використання лямбда-виразу можна розділити на три етапи:
//- визначення делегата, сумісного з лямбда-виразом
//- створення екземпляра делегата, якому присвоюється лямбда-вираз
//- використання виразу, що відбувається при зверненні до делегата

// */

//    // делегат для обчислення значення в квадраті (лямбда-вираз — анонімна функція, що замінює метод)
//    delegate double MyDelegateType(double value);

//    // сигнатура делегата, сумісного з іншим лямбда-виразом (делегат визначає тип методу для лямбди)
//    delegate int LambdaDelegate(int step);

//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        MyDelegateType power = value => value * value; // обчислюємо квадрат числа
//        // рядок коду визще розгортається в:
//        // MyDelegateType power = delegate(double value) { return value * value; };
//        // подумайте, звідки відомо, що параметр value має тип double?

//        Console.WriteLine($"квадрат числа 5 дорівнює {power(5)}"); // виводить: квадрат числа 5 дорівнює 25

//        // приклад використання лямбди для інкременту в циклі
//        LambdaDelegate del = a => ++a;
//        // рядок коду вище розгортається в:
//        // LambdaDelegate del = delegate(int a) { return ++a; };

//        int start = 0;
//        int finish = 7;

//        Console.WriteLine("\nсимуляція бігу:");

//        while (start <= finish)
//        {
//            Console.WriteLine($"бігун зараз на {start} кілометрі. до фінішу залишилося {finish - start} км.");
//            start = del(start);
//        }
//    }
//}
// -----------------------------------------------------------------
//class Program
//{
//    // блочні лямбда-вирази
//    // сигнатура делегата для обчислення степеня (блочний лямбда-вираз з умовою та циклом)
//    delegate int PowerDelegate(int number, int power);

//    // делегат для рекурсивного фібоначчі (лямбда з рекурсією, захоплює зовнішню змінну делегата)
//    delegate long FibonacciDelegate(int index);

//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        // приклад блочного лямбда-виразу для обчислення степеня
//        Console.WriteLine("\nобчислення степеня:\n");

//        PowerDelegate powerCalc = (number, power) =>
//        {
//            if (power == 0) return 1;

//            int answer = 1;
//            for (int i = 0; i < power; i++)
//                answer *= number;

//            return answer;
//        };

//        Console.WriteLine($"2 у 5-й степені дорівнює {powerCalc(2, 5)}"); // виводить: 2 у 5-й степені дорівнює 32

//        // приклад рекурсивної лямбди для фібоначчі (змінну типу делегата fibonacci потрібно ініціалізувати перед запуском лямбди!)
//        Console.WriteLine("\nпослідовність фібоначчі:\n");

//        // числа фібоначчі звісно ефективніше обчислювати циклом :)
//        // але, просто для прикладу — лямбди вміють у рекурсію!
//        FibonacciDelegate? fibonacci = null;

//        fibonacci = (index) => index > 1 ?
//            fibonacci(index - 1) + fibonacci(index - 2) : index;

//        for (int i = 0; i < 40;) Console.WriteLine(fibonacci(++i));
//    }
//}
// -----------------------------------------------------------------
//class Program
//{
//    delegate int PowerDelegate(int number, int power);


//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;


//        PowerDelegate powerCalc = (number, power) =>
//        {
//            if (power == 0) return 1;

//            int answer = 1;
//            for (int i = 0; i < power; i++)
//                answer *= number;

//            return answer;
//        };

//        Console.WriteLine(powerCalc(2, 5));

//    }
//}
// -----------------------------------------------------------------
//class Program
//{
//    // делегат для умов фільтрації
//    delegate bool FilterCondition(int number);

//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

//        // виклик методів з передачею лямбда-виразу як параметра
//        int[] evenNumbers = Filter(numbers, x => x % 2 == 0);
//        Console.WriteLine("Парні числа: " + string.Join(", ", evenNumbers));

//        int[] oddNumbers = Filter(numbers, x => x % 2 != 0);
//        Console.WriteLine("Непарні числа: " + string.Join(", ", oddNumbers));

//        int[] greaterThanFive = Filter(numbers, x => x > 5);
//        Console.WriteLine("Числа більші за 5: " + string.Join(", ", greaterThanFive));

//        int[] multiplesOfThree = Filter(numbers, x => x % 3 == 0);
//        Console.WriteLine("Кратні 3: " + string.Join(", ", multiplesOfThree));
//    }

//    // метод фільтрації з передачею лямбда-виразу
//    static int[] Filter(int[] array, FilterCondition condition)
//    {
//        var result = new List<int>();
//        foreach (var n in array)
//        {
//            if (condition(n))
//            {
//                result.Add(n);
//            }
//        }
//        return result.ToArray();
//    }
//}
// -----------------------------------------------------------------
//class Program
//{
//    // делегат для умов фільтрації
//    delegate bool FilterCondition(int number);

//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

//        // виклик методів з передачею лямбда-виразу як параметра
//        int[] evenNumbers = Filter(numbers, delegate (int x) { return x % 2 == 0; });
//        Console.WriteLine("Парні числа: " + string.Join(", ", evenNumbers));

//        int[] oddNumbers = Filter(numbers, x => x % 2 != 0);
//        Console.WriteLine("Непарні числа: " + string.Join(", ", oddNumbers));

//        int[] greaterThanFive = Filter(numbers, x => x < 5);
//        Console.WriteLine("Числа більші за 5: " + string.Join(", ", greaterThanFive));

//        int[] multiplesOfThree = Filter(numbers, x => x % 3 == 0);
//        Console.WriteLine("Кратні 3: " + string.Join(", ", multiplesOfThree));
//    }

//    // метод фільтрації з передачею лямбда-виразу
//    static int[] Filter(int[] array, FilterCondition condition)
//    {
//        // x => x % 2 == 0
//        // FilterCondition condition = delegate (int x) { return x % 2 == 0; }
//        var result = new List<int>();
//        foreach (var n in array)
//        {
//            if (condition(n))
//            {
//                result.Add(n);
//            }
//        }
//        return result.ToArray();
//    }
//}
// -----------------------------------------------------------------
//class Program
//{
//    // делегат для умов фільтрації
//    delegate bool FilterCondition(Person person);

//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        Person[] persons = {
//            new Person("Богдан", "Шевченко", new DateTime(1996, 1, 1)),
//            new Person("Галина", "Котляревська", new DateTime(1992, 11, 6)),
//            new Person("Олександр", "Довженко", new DateTime(1991, 5, 11)),
//            new Person("Віра", "Лесько", new DateTime(1990, 10, 8)),
//            new Person("Андрій", "Сковорода", new DateTime(1985, 3, 15))
//        };

//        Console.WriteLine("до фільтрації:\n");
//        foreach (var person in persons) Console.WriteLine(person);

//        Console.WriteLine("\nперсони з ім'ям на 'А':\n");
//        Person[] nameA = Filter(persons, p => p.FirstName.StartsWith("А"));
//        foreach (var person in nameA) Console.WriteLine(person);

//        Console.WriteLine("\nперсони з роком народження < 1990:\n");
//        Person[] before2010 = Filter(persons, p => p.Birthday.Year < 1990);
//        foreach (var person in before2010) Console.WriteLine(person);

//        Console.WriteLine("\nперсони з прізвищем < 7 символів:\n");
//        Person[] shortLastname = Filter(persons, p => p.LastName.Length < 7);
//        foreach (var person in shortLastname) Console.WriteLine(person);
//    }

//    public class Person
//    {
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public DateTime Birthday { get; set; }

//        public Person(string firstName, string lastName, DateTime birthday)
//        {
//            FirstName = firstName;
//            LastName = lastName;
//            Birthday = birthday;
//        }

//        public override string ToString()
//        {
//            return $"{FirstName,-10} : {LastName,-12} : {Birthday:dd.MM.yyyy}.";
//        }
//    }

//    // метод фільтрації з передачею лямбда-виразу
//    static Person[] Filter(Person[] array, FilterCondition condition)
//    {
//        var result = new List<Person>();
//        foreach (var p in array)
//        {
//            if (condition(p))
//            {
//                result.Add(p);
//            }
//        }
//        return result.ToArray();
//    }
//}
// -----------------------------------------------------------------

// -----------------------------------------------------------------