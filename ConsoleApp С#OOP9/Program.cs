// ---------------------------------------------------------------------------
using System;
using System.Text;
// ---------------------------------------------------------------------------
//protected

//поле або метод бачать: клас компонента, нащадки усюди - в поточній збірці або в інших збірках
// ---------------------------------------------------------------------------
//protected internal -більш публічний: в поточній збірці БАЧАТЬ УСІ класи, 
//в тому числі НЕ нащадки, а в інших збірках - бачать лише нащадки
// ---------------------------------------------------------------------------
//private protected -бачить клас та його нащадки АЛЕ ЛИШЕ в межах збірки
// ---------------------------------------------------------------------------
//Student s = new Student();

//// upcasting examples
//Person p = new Student();
//// Student s2 = new Person(); // error!
//Object o = new Student();
// ---------------------------------------------------------------------------
//// downcasting examples
//// Student s2 = p; // error! requires explicit cast
//Student s2 = (Student)p; // ok
//s2.Test();

//// bad downcasting example
//// Student s3 = (Cat)p; // compile error!
//// Cat c = (Cat)p; // compile error!
// ---------------------------------------------------------------------------
//                                          as  is
//                                          class Program
//{
//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        // у .net оператори as та is використовуються для перевірок та перетворень типів даних

//        object someObject = "Це рядок";

//        // оператор as використовується для спроби перетворення об'єкта до вказаного типу
//        // якщо перетворення неможливе, результатом буде null, А НЕ ВИНЯТОК
//        // часто застосовується для роботи з об'єктами різних типів, для безпечного перетворення без винятків
//        string? asString = someObject as string;
//        if (asString != null)
//        {
//            Console.WriteLine("Перетворення пройшло успішно: " + asString);
//        }
//        else
//        {
//            Console.WriteLine("Перетворення не вдалося.");
//        }

//        // приклад з невдалим перетворенням: int не перетвориться на string
//        object intObject = 42;
//        string? failedAsString = intObject as string;
//        if (failedAsString != null)
//        {
//            Console.WriteLine("Перетворення int на string успішне: " + failedAsString);
//        }
//        else
//        {
//            Console.WriteLine("Перетворення int на string не вдалося.");
//        }

//        // оператор is використовується для перевірки, чи є об'єкт екземпляром вказаного типу
//        // повертає true, якщо перевірка успішна, і false, якщо об'єкт не є екземпляром вказаного типу
//        if (someObject is string)
//        {
//            Console.WriteLine("Об'єкт є рядком.");
//        }
//        else
//        {
//            Console.WriteLine("Об'єкт не є рядком.");
//        }

//        // у сучасному c# 9+ (актуально для .net 9) is підтримує pattern matching для безпечного розпакування
//        // це кращий підхід, ніж as, бо уникає null-перевірки та є більш виразним
//        if (someObject is string patternString)
//        { // якщо перевірка пройшла (true), то значення someObject автоматично присвоюється
//          // новій локальній змінній patternString (типу string). і можна одразу використовувати
//          // patternString всередині блоку if, без додаткових перетворень чи перевірки на null
//            Console.WriteLine($"Об'єкт є рядком через pattern matching: {patternString}");
//        }
//        else
//        {
//            Console.WriteLine("Об'єкт не є рядком через pattern matching.");
//        }

//        // приклад pattern matching з int: показує тип та значення
//        if (intObject is int patternInt)
//        {
//            Console.WriteLine($"Об'єкт є int через pattern matching: {patternInt}");
//        }
//        else
//        {
//            Console.WriteLine("Об'єкт не є int.");
//        }

//        // приклад з null: is false для будь-якого типу
//        object? nullObject = null;
//        if (nullObject is string)
//        {
//            Console.WriteLine("Null є рядком.");
//        }
//        else
//        {
//            Console.WriteLine("Null не є рядком.");
//        }

//        // ці оператори часто використовуються для обробки об'єктів та типів даних у runtime
//        // коли точний тип об'єкта невідомий до моменту виконання програми
//        // вони допомагають уникнути помилок та забезпечують безпеку при роботі з типами даних
//    }
//}
// ---------------------------------------------------------------------------
///*
//методи розширення в c# дозволяють додавати нові методи до наявних типів
//без зміни їхнього визначення

//це досягається за допомогою статичного методу, який приймає об'єкт, до якого застосовується
//розширення, як перший параметр


//методи розширення в c# мають бути статичними, бо вони, хоч і викликаються через екземпляр об'єкта,
//але синтаксично належать статичному класу

//це означає, що вони не мають доступу до стану конкретного об'єкта,
//оскільки не пов'язані з конкретним екземпляром класу, до якого застосовуються

//замість цього вони приймають об'єкт як перший параметр і працюють з ним,
//але сам метод лишається статичним

//для створення методу розширення для типу даних виконайте такі кроки:
//1. створіть статичний клас, у якому буде визначено метод розширення
//2. визначте статичний метод у цьому класі з ключовим словом this,
//вказавши тип даних, до якого хочете додати метод
//*/

//static class Extensions
//{
//    // метод розширення для сортування символів у рядку
//    public static string Sort(this string s)
//    {
//        // перетворення рядка на масив символів для сортування
//        char[] charArray = s.ToCharArray();
//        Array.Sort(charArray);
//        return new string(charArray);
//    }

//    // метод розширення для видалення пробілів
//    public static string RemoveSpaces(this string s)
//    {
//        Console.WriteLine("привіт з мого методу розширення!");
//        return s.Replace(" ", "");
//    }

//    // метод розширення для тестового виведення
//    public static void EEEEERockMethod(this string s)
//    {
//        Console.WriteLine("єєєєєєєєєє рок!");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        string name = "    Олександр    ";

//        // сортування символів у рядку
//        name = name.Sort();
//        // насправді це буде виклик ось такий: 
//        // name = Extensions.Sort(name);

//        // як компілятор шукає потрібний метод?
//        // він виконує пошук за суворими правилами, щоб уникнути неоднозначностей.
//        // спочатку шукає метод Sort безпосередньо в string(або його базових класах / інтерфейсах). якщо знайде — використовує його
//        // якщо не знайшов, переходить до extension-методів. шукає в статичних класах (тільки статичні класи, позначені static class, можуть містити extension-методи),
//        // в методах з ключовим словом this - перший параметр має бути this T тип, де T — тип об'єкта (тут this string s для string),

//        // видалення пробілів
//        name = name.RemoveSpaces();
//        Console.WriteLine(name);

//        // тестовий метод розширення
//        name.EEEEERockMethod();

//        // додатковий приклад: комбінування методів
//        string testString = "Привіт, Київ!";
//        string sortedAndClean = testString.Sort().RemoveSpaces();
//        Console.WriteLine($"посортований та очищений: {sortedAndClean}");
//    }
//}
// ---------------------------------------------------------------------------
//static class Extensions
//{
//    public static void Print(this object value)
//    {
//        Console.WriteLine(value);
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        "методи розширення в c#".Print();
//        10.Print();
//        0.85.Print();
//    }
//}
// ---------------------------------------------------------------------------
///*
//в дот нет усі типи, включно з простими типами даних та користувацькими типами
//(класи, структури, перелічення тощо), є похідними від базового класу system.object

//цей клас є частиною простору імен system і надає низку загальних методів та функціональності для всіх об'єктів у c#

//методи класу object:

//a. ToString() - повертає рядкове представлення об'єкта
//за замовчуванням цей метод повертає ім'я типу об'єкта

//b. Equals(object obj) - слугує для порівняння об'єктів на рівність
//у базовій реалізації він порівнює посилання на об'єкти,
//і в більшості випадків його слід перевизначати в похідних класах для коректного порівняння вмісту об'єктів

//c. GetHashCode() - повертає геш-код об'єкта
//цей метод також часто перевизначається в похідних класах,
//щоб забезпечити відповідність правилам рівності та гешування

//перевизначення методів equals та gethashcode у похідних класах має сенс, коли об'єкти мають
//бути коректно використані в колекціях, таких як dictionary або hashset,
//де використовується хешування для забезпечення швидкого доступу та пошуку

//d. GetType() - повертає об'єкт system.type, що представляє тип поточного об'єкта

//e. MemberwiseClone() - створює поверхневу копію поточного об'єкта

//f. ReferenceEquals(object obj1, object obj2) - статичний метод для перевірки, чи посилаються
//два об'єкти на один екземпляр (порівняння посилань)

//g. Finalize() - метод для очищення ресурсів перед garbage collection
//в .net 9+ рекомендується використовувати IDisposable з using для детермінованого очищення
//*/

//class CustomObject
//{
//    public int Value { get; }
//    public string Name { get; }

//    public CustomObject(int value, string name)
//    {
//        Value = value;
//        Name = name;
//    }

//    // перевизначення ToString для користувацького рядкового представлення
//    public override string ToString()
//    {
//        return $"користувацький об'єкт: значення {Value}, ім'я {Name}";
//    }

//    // перевизначення Equals для порівняння за значенням, а не посиланням
//    public override bool Equals(object? obj)
//    {
//        if (obj == null || GetType() != obj.GetType())
//            return false;

//        // порівняння вмісту: значення value та name
//        CustomObject other = (CustomObject)obj;
//        return Value == other.Value && Name == other.Name;
//    }

//    // перевизначення GetHashCode для узгодженості з equals
//    public override int GetHashCode()
//    {
//        return HashCode.Combine(Value, Name);
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        // створення двох об'єктів object для демонстрації базових методів
//        object obj1 = new object();
//        object obj2 = new object();
//        object obj3 = obj1;

//        // Equals: базово порівнює посилання, false для різних об'єктів
//        bool areEqual = obj1.Equals(obj2);
//        Console.WriteLine($"об'єкти obj1 та obj2 рівні (equals): {areEqual}");

//        // ReferenceEquals: статичний метод для точного порівняння посилань
//        bool refEqual = ReferenceEquals(obj1, obj2);
//        Console.WriteLine($"об'єкти obj1 та obj2 посилаються на один (referenceequals): {refEqual}");

//        bool refEqualSame = ReferenceEquals(obj1, obj3);
//        Console.WriteLine($"об'єкти obj1 та obj3 посилаються на один (referenceequals): {refEqualSame}");

//        // отримання геш-коду
//        int hash1 = obj1.GetHashCode();
//        int hash2 = obj2.GetHashCode();
//        Console.WriteLine($"геш-код obj1: {hash1}, obj2: {hash2}");

//        // рядкове представлення: за замовчуванням тип
//        var str1 = obj1.ToString();
//        Console.WriteLine($"рядкове представлення obj1: {str1}");

//        // отримання типу
//        Type type = obj1.GetType();
//        Console.WriteLine($"тип об'єкта obj1: {type.FullName}");
//        Console.WriteLine($"чи є абстрактним: {type.IsAbstract}");

//        // створення користувацьких об'єктів для демонстрації перевизначень
//        CustomObject custom1 = new CustomObject(42, "Олександр");
//        CustomObject custom2 = new CustomObject(42, "Олександр");
//        CustomObject custom3 = new CustomObject(100, "Марія");

//        // ToString перевизначено
//        Console.WriteLine($"рядкове представлення custom1: {custom1}");

//        // Equals перевизначено: true за значенням
//        bool customEqual = custom1.Equals(custom2);
//        Console.WriteLine($"custom1 та custom2 рівні (equals): {customEqual}");

//        bool customNotEqual = custom1.Equals(custom3);
//        Console.WriteLine($"custom1 та custom3 рівні (equals): {customNotEqual}");

//        // GetHashCode узгоджено: однакові хеші для рівних об'єктів
//        int customHash1 = custom1.GetHashCode();
//        int customHash2 = custom2.GetHashCode();
//        Console.WriteLine($"хеш custom1: {customHash1}, custom2: {customHash2}");

//        // демонстрація в колекціях: hashset уникає дублікатів завдяки equals та hashcode
//        var hashSet = new HashSet<CustomObject> { custom1, custom2, custom3 };
//        Console.WriteLine($"розмір hashset: {hashSet.Count}"); // 2, бо custom1 == custom2

//        // Dictionary: ключі за hashcode та equals
//        var dictionary = new Dictionary<CustomObject, string>
//        {
//            { custom1, "перший запис" },
//            { custom2, "другий запис" } // перезапише, бо ключі рівні
//        };
//        Console.WriteLine($"значення для custom1: {dictionary[custom1]}"); // "другий запис"

//        // finalize: в .net 9+ не рекомендується, але для демонстрації (викликається gc)
//        // custom1.Finalize(); // protected, не викликається явно; GC.Collect() може прискорити
//        Console.WriteLine("finalize викликається garbage collector'ом перед видаленням, не явно");
//    }
//}
// ---------------------------------------------------------------------------
///*
//   Boxing — це перетворення value type (наприклад, int, struct) на reference type (object),
//   а unboxing — навпаки. 
//   Це базова фішка C# для уніфікації типів, але зі своїми "підводними каменями".

//   Чому це важливо?

//   1. Продуктивність та пам'ять: Boxing створює об'єкт на heap, що викликає алокацію
//   (24+ байт на int) і додатковий тиск на Garbage Collector (GC). 
//   У високонавантажених додатках (ігри, сервери) це призводить до пауз GC, лагів і витоків пам'яті. 
//   Unboxing додає перевірки типів (може кинути InvalidCastException).

//   2. Типова безпека: Дозволяє value types працювати з колекціями як ArrayList
//   чи object-параметрами, - але без generics (List<T>) це "брудний" код.

//   3. У .NET 9 з'явилася нова фішка "Object Stack Allocation for Boxes":
//   Якщо boxed value type не "втікає" з методу (не зберігається в статичних/глобальних змінних), то алокується на stack, а не heap. 
//   Це усуває алокації, зменшує GC на 20-50% у типових сценаріях (наприклад, Equals() на int). 
//   Компілятор JIT робить це автоматично для 64-бітних додатків. .NET 8 — завжди heap, з алокаціями.

//   4. Масштабованість: У enterprise (ASP.NET, Unity) уникнення boxing — ключ до швидкості.
//   З generics (List<int>) boxing мінімізується, але legacy-код все ще страждає.

//   Без розуміння особливостей упаковки та розпаковки код стає повільним і непередбачуваним.
//   У .NET 9 це оптимізували, але все одно: порада уникати boxing, усюди де можна (та використовувати generics, ref structs).  
//*/

//using System.Collections; // Для ArrayList (legacy з boxing)
//using System.Diagnostics; // Для Stopwatch — вимірювання часу

//namespace BoxingUnboxingSimpleDemo
//{
//    /*
//       Struct — це value type. Boxing копіює весь вміст (X, Y) в object на heap (або stack у .NET 9).
//       structs більші за int, показують витрати.
//    */
//    public struct Point
//    {
//        public int X { get; }
//        public int Y { get; }

//        public Point(int x, int y)
//        {
//            X = x;
//            Y = y;
//        }

//        // це типовий сценарій, де boxing ховається в методах базового класу.
//        public override bool Equals(object? obj)
//        {
//            if (obj is Point p) // безпечний unboxing з 'is'
//            {
//                return X == p.X && Y == p.Y;
//            }
//            return false;
//        }

//        public override int GetHashCode() => X * 31 + Y;
//    }

//    internal class Program
//    {
//        // https://giannisakritidis.com/blog/Objects-On-Stack/
//        // статична змінна для "ескейпу": змушує зробити алокацію на heap в .NET 9
//        // якщо box "втікає" (зберігається поза методом), алокація буде на heap.
//        private static object? escapedBox;

//        static void Main()
//        {
//            Console.OutputEncoding = System.Text.Encoding.UTF8;

//            // 1: ПРОСТИЙ BOXING/UNBOXING INT
//            // int (stack) -> object (boxing) -> int (unboxing). У .NET 9 — все на stack, якщо локально.
//            Console.WriteLine("Крок 1: Boxing int...");
//            int num = 42; // Value type на stack
//            object boxedNum = num; // BOXING: Створює object
//            Console.WriteLine($"Оригінал: {num}");
//            Console.WriteLine($"Boxed: {boxedNum} (тип: {boxedNum.GetType().Name})");

//            int unboxedNum = (int)boxedNum; // UNBOXING: Каст з перевіркою
//            Console.WriteLine($"Unboxed: {unboxedNum}\n");

//            /* num (value type на stack) перетворюється на object (reference type).
//            CLR створює новий об'єкт на heap (традиційно), який містить копію значення 42 у своєму полі (типу int).
//            але не в .NET 9 (якщо нема ескейпа, а тут його нема).
//            boxedNum стає посиланням (reference) на цей об'єкт.

//            чому копіюється? бо value type — це "значення", а object — "посилання".
//            щоб уніфікувати (наприклад, для колекцій чи методів, що приймають object),
//            потрібно створити окрему сутність з копією. оригінал num не змінюється.

//            де лежить об'єкт після boxing у .NET 9?
//            якщо об'єкт не ескейпить з методу (тобто не зберігається в статичних змінних, полях класу, масивах чи не повертається з методу),
//            то в .NET 9 JIT-компілятор може алокувати його на stack замість heap.
//            це нова оптимізація "Object stack allocation for boxes" (escape analysis): об'єкт стає локальним,
//            автоматично очищається при виході з методу, без GC. boxedNum — локальна змінна, не ескейпить, тож на stack.
//            у .NET <= 8 — завжди на heap (алокація ~24+ байти на int, включаючи header об'єкта + sync block).
//            це призводить до тиску на GC. у .NET 9 — до 20-50% менше алокацій/пауз GC у типових сценаріях (наприклад, Equals на int).*/

//            // 2: BOXING STRUCT
//            // копіює весь struct. буде більше витрат, ніж з int.
//            Console.WriteLine("Крок 2: Boxing struct...");
//            Point pt = new Point(10, 20);
//            object boxedPt = pt; // BOXING struct
//            Console.WriteLine($"Оригінал: ({pt.X}, {pt.Y})");
//            Point unboxedPt = (Point)boxedPt; // UNBOXING
//            Console.WriteLine($"Unboxed: ({unboxedPt.X}, {unboxedPt.Y})");

//            bool equal = pt.Equals(boxedPt); // внутрішній boxing
//            Console.WriteLine($"Equals: {equal}\n");

//            // 3: ПРОДУКТИВНІСТЬ З STOPWATCH
//            // порівнюємо цикли з/без boxing. у .NET 9 — boxing швидший (stack).
//            Console.WriteLine("Крок 3: Продуктивність (1 млн ітерацій)...");
//            var swNoBox = Stopwatch.StartNew();
//            long sumNo = 0;
//            for (int i = 0; i < 1000000; i++)
//            {
//                sumNo += i; // без boxing
//            }
//            swNoBox.Stop();
//            Console.WriteLine($"Без boxing: {swNoBox.ElapsedMilliseconds} ms, Сума: {sumNo}");

//            var swBox = Stopwatch.StartNew();
//            long sumBox = 0;
//            object[] boxes = new object[1000000]; // підготовка для boxing
//            for (int i = 0; i < 1000000; i++)
//            {
//                boxes[i] = i; // BOXING
//            }
//            for (int i = 0; i < 1000000; i++)
//            {
//                sumBox += (int)boxes[i]; // UNBOXING
//            }
//            swBox.Stop();
//            Console.WriteLine($"З boxing: {swBox.ElapsedMilliseconds} ms, Сума: {sumBox}");
//            Console.WriteLine($"Різниця: {swBox.ElapsedMilliseconds - swNoBox.ElapsedMilliseconds} ms (менше в .NET 9)\n");

//            // 4: ПОМИЛКА UNBOXING
//            // InvalidCastException, якщо тип не співпадає. завжди перевіряємо!
//            Console.WriteLine("Крок 4: Помилка unboxing...");
//            object wrong = "рядок"; // не int
//            try
//            {
//                int bad = (int)wrong; // кине помилку
//            }
//            catch (InvalidCastException ex)
//            {
//                Console.WriteLine($"Помилка: {ex.Message} — перевір тип!\n");
//            }

//            // 5: КОЛЕКЦІЇ — ARRAYLIST VS LIST<INT>
//            // при використанні ArrayList — відбувається boxing кожного додавання. з List<int> — ні.
//            Console.WriteLine("Крок 5: Колекції...");
//            ArrayList arrList = new ArrayList();
//            var listInt = new List<int>();

//            var swArr = Stopwatch.StartNew();
//            for (int i = 0; i < 10000; i++)
//            {
//                arrList.Add(i); // BOXING
//            }
//            swArr.Stop();
//            Console.WriteLine($"ArrayList (boxing): {swArr.ElapsedMilliseconds} ms");

//            var swList = Stopwatch.StartNew();
//            for (int i = 0; i < 10000; i++)
//            {
//                listInt.Add(i); // без boxing
//            }
//            swList.Stop();
//            Console.WriteLine($"List<int> (без boxing): {swList.ElapsedMilliseconds} ms\n");

//            Console.WriteLine("=== ДЕМОНСТРАЦІЯ ЗАВЕРШЕНА. Натисніть клавішу. ===");
//            Console.ReadKey();
//        }

//        // МЕТОД COMPARE: без ескейпу — stack у .NET 9
//        // параметри object — boxing, але локально: stack alloc.
//        private static bool Compare(object? x, object? y)
//        {
//            return x?.Equals(y) ?? false;
//        }

//        // МЕТОД З ЕСКЕЙПОМ: Heap через статичну змінну
//        // escapedBox = x; — "втікає", змушує класти на heap.
//        private static bool CompareEscaped(object? a, object? b)
//        {
//            escapedBox = a; // ескейп!
//            return a?.Equals(b) ?? false;
//        }
//    }
//}
// ---------------------------------------------------------------------------
//abstract class Animal
//{
//    protected string? name;
//    protected double weight;

//    public Animal()
//    {
//        Console.WriteLine("конструктор Animal за замовчуванням!");
//    }

//    public void Eat()
//    {
//        Console.WriteLine("у всіх тварин є здатність до харчування");
//    }

//    public void Breath()
//    {
//        Console.WriteLine("у всіх тварин є здатність до дихання");
//    }

//    public void Growth()
//    {
//        Console.WriteLine("у всіх тварин є здатність до росту");
//    }
//}

//abstract class Mammal : Animal
//{
//    protected int teeth;
//    protected string? diafragma;
//    protected int age;

//    public Mammal()
//    {
//        Console.WriteLine("конструктор Mammal за замовчуванням!");
//    }

//    public void Suckle()
//    {
//        Console.WriteLine("у ссавців є здатність годувати молоком");
//    }
//}

//abstract class Cat : Mammal
//{
//    protected string? breed; // порода

//    public Cat()
//    {
//        Console.WriteLine("конструктор Cat за замовчуванням!");
//    }

//    public virtual void About()
//    {
//        Console.WriteLine("кіт на ім'я " + name);
//        Console.WriteLine("вік: " + age);
//    }
//}

//class Munchkin : Cat
//{
//    protected short height;

//    public Munchkin()
//    {
//        Console.WriteLine("конструктор Munchkin за замовчуванням!");
//    }

//    public override void About()
//    {
//        base.About();
//        Console.WriteLine("зріст: " + height + " см");
//    }
//}

//public class Program
//{
//    public static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        var munchkin = new Munchkin();
//        munchkin.Breath();
//        munchkin.Eat();
//        munchkin.Growth();
//    }
//}
// ---------------------------------------------------------------------------
//КЛАС = РЕАЛІЗАЦІЯ + ІНТЕРФЕЙС
//ІНТЕРФЕЙС = КЛАС - РЕАЛІЗАЦІЯ

// ---------------------------------------------------------------------------

// ---------------------------------------------------------------------------