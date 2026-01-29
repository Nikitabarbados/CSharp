using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
// --------------------------------------------------------------------------------------------------
//class MyCollection
//{
//    int[] arr;

//    public MyCollection()
//    {
//        arr = [1, 2, 3, 8];
//    }

//    // рівень доступу - будь-який (може бути й приватним), але зазвичай публічний - з турботою про клієнта
//    // тип результату - будь-який окрім void
//    // this - особливість синтаксису + адреса об'єкта колекції (індексатор не може бути статичним)
//    // у квадратних дужках може бути один або навіть кілька індексів (якщо їх кілька, вони перелічуються через кому)
//    // типи індексів будь-які, але зазвичай int або uint
//    public int this[int index]
//    {
//        get
//        {
//            return arr[index];
//        }
//        set
//        {
//            // у секції set не можна робити змінну з назвою value, це контекстне ключове слово
//            arr[index] = value;
//        }
//    }

//    public int this[string index]
//    {
//        get
//        {
//            if (index == "Олександр")
//            {
//                return arr[0];
//            }
//            else
//            {
//                return arr[int.Parse(index)];
//            }
//        }
//        set
//        {
//            if (index == "Олександр")
//            {
//                Console.WriteLine("Привіт!");
//                arr[0] = value;
//            }
//            else
//                Console.WriteLine("Хто ви?");
//        }
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        var c = new MyCollection();
//        Console.WriteLine(c[0]); // відбувається звернення до елемента колекції на читання (get)
//        c[0] = 10; // відбувається звернення до елемента колекції на запис (set)
//        // Console.WriteLine(c[5]);
//        // c[5] = 10;

//        c["Микола"] = 50;
//        Console.WriteLine(c[0]); // 10
//        Console.WriteLine(c["Олександр"]); // 10
//    }
//}
// --------------------------------------------------------------------------------------------------
//abstract class Device { }

//class Laptop : Device
//{
//    private double price;
//    private string vendor;

//    public Laptop(string vendor, double price)
//    {
//        SetPrice(price);
//        SetVendor(vendor);
//    }

//    public void SetPrice(double price)
//    {
//        if (price > 0) this.price = price;
//    }

//    public double GetPrice()
//    {
//        return price;
//    }

//    public void SetVendor(string vendor)
//    {
//        this.vendor = vendor;
//    }

//    public string GetVendor()
//    {
//        return vendor;
//    }

//    public override string ToString()
//    {
//        return "Виробник: " + vendor + ", ціна: ₴" + price; // vendor - виробник, price - ціна
//    }
//}

//class Store
//{
//    private Laptop[] laptops;

//    public Store(uint size)
//    {
//        laptops = new Laptop[size];
//    }

//    public Laptop this[uint index]
//    {
//        get
//        {
//            if (index >= laptops.Length)
//            {
//                throw new IndexOutOfRangeException("індекс поза межами масиву"); // index out of range - індекс поза межами
//            }
//            else
//            {
//                return laptops[index];
//            }
//        }
//        set
//        {
//            laptops[index] = value;
//        }
//    }

//    public int GetCount()
//    {
//        return laptops.Length;
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        var s = new Store(3);
//        s[0] = new Laptop("ЛьвівТек", 37261.1);
//        s[1] = new Laptop("КиївКомплюктерс", 80732.2);
//        s[2] = new Laptop("ХарківЛаб", 29973.3);

//        try
//        {
//            for (uint i = 0; i < s.GetCount(); i++)
//            {
//                Console.WriteLine(s[i]);
//            }
//            // тест на помилку: s[3] викличе IndexOutOfRangeException
//            // Console.WriteLine(s[3]);
//        }
//        catch (IndexOutOfRangeException exception)
//        {
//            Console.WriteLine(exception.Message);
//        }
//    }
//}
// --------------------------------------------------------------------------------------------------
//abstract class Device
//{

//}

//class Laptop : Device
//{
//    private double price;
//    private string? vendor;

//    public Laptop(string vendor, double price)
//    {
//        SetPrice(price);
//        SetVendor(vendor);
//    }

//    public void SetPrice(double price)
//    {
//        if (price > 0)
//            this.price = price;
//    }

//    public double GetPrice()
//    {
//        return price;
//    }

//    public void SetVendor(string vendor)
//    {
//        this.vendor = vendor;
//    }

//    public string? GetVendor()
//    {
//        return vendor;
//    }

//    public override string ToString()
//    {
//        return "Виробник: " + vendor + ", ціна: ₴" + price;
//    }
//}

//class Store // магазин ноутбуків, що містить колекцію ноутбуків
//{
//    List<Laptop> laptops = new List<Laptop>();

//    public Laptop this[int index] // індексатор для доступу до ноутбуків за індексом
//    {
//        get
//        {
//            return laptops[index];
//        }
//        set
//        {
//            laptops.Add(value); // додаємо новий ноутбук у колекцію (якщо вона побудована на List<T>, він жеж в минулому vector<T>)
//            // laptops[index] = value; // альтернативний варіант, якщо колекція побудована на масиві
//        }
//    }

//    public int GetCount()
//    {
//        return laptops.Count;
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        var s = new Store();
//        s[0] = new Laptop("ЛьвівТек", 37261.1);
//        s[1] = new Laptop("КиївКомплюктерс", 80732.2);
//        s[2] = new Laptop("ХарківЛаб", 29973.3);

//        try
//        {
//            for (int i = 0; i < s.GetCount(); i++)
//            {
//                Console.WriteLine(s[i]);
//            }
//            // тест на помилку: s[3] викличе IndexOutOfRangeException
//            // Console.WriteLine(s[3]);
//        }
//        catch (IndexOutOfRangeException exception)
//        {
//            Console.WriteLine(exception.Message);
//        }
//    }
//}
// --------------------------------------------------------------------------------------------------

//abstract class Device { }

//class Laptop : Device
//{
//    private double price;
//    private string? vendor;

//    public Laptop(string vendor, double price)
//    {
//        SetPrice(price);
//        SetVendor(vendor);
//    }

//    public void SetPrice(double price)
//    {
//        if (price > 0)
//            this.price = price;
//    }

//    public double GetPrice() => price;

//    public void SetVendor(string vendor) => this.vendor = vendor;

//    public string? GetVendor() => vendor;

//    public override string ToString()
//    {
//        return $"Виробник: {vendor}, ціна: ₴{price}";
//    }
//}

//class Store
//{
//    private List<Laptop> laptops = new List<Laptop>();

//    public Laptop this[int index]
//    {
//        get
//        {
//            if (index < 0 || index >= laptops.Count)
//                throw new IndexOutOfRangeException("Невірний індекс ноутбука!");
//            return laptops[index];
//        }
//        set
//        {
//            if (index < 0)
//                throw new IndexOutOfRangeException("Індекс не може бути від’ємним!");

//            while (index >= laptops.Count)
//            {
//                laptops.Add(null!); 
//            }
//            laptops[index] = value;
//        }
//    }

//    public int GetCount() => laptops.Count;
//}

//class Program
//{
//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        var s = new Store();
//        s[0] = new Laptop("ЛьвівТек", 37261.1);
//        s[0] = new Laptop("КиївКомплюктерс", 80732.2);
//        s[0] = new Laptop("ХарківЛаб", 29973.3);
//        s[2] = new Laptop("ОдесаНоут", 99999.9); 

//        for (int i = 0; i < s.GetCount(); i++)
//        {
//            Console.WriteLine($"[{i}] " + (s[i]?.ToString() ?? "<пусто>"));
//        }
//    }
//}
// --------------------------------------------------------------------------------------------------
//abstract class Device { }

//class Laptop : Device
//{
//    private double price;
//    private string? vendor;

//    public Laptop(string vendor, double price)
//    {
//        SetPrice(price);
//        SetVendor(vendor);
//    }

//    public void SetPrice(double price)
//    {
//        if (price > 0) this.price = price;
//    }

//    public double GetPrice()
//    {
//        return price;
//    }

//    public void SetVendor(string vendor)
//    {
//        this.vendor = vendor;
//    }

//    public string? GetVendor()
//    {
//        return vendor;
//    }

//    public override string ToString()
//    {
//        return "виробник: " + vendor + ", ціна: ₴" + price; // vendor - виробник, price - ціна
//    }
//}

//class Store
//{
//    private List<Laptop> laptops = new List<Laptop>();

//    // індексатор для доступу за індексом (get/set), дозволяє додавання при index == Count
//    public Laptop this[int index]
//    {
//        get
//        {
//            if (index < 0 || index >= laptops.Count)
//            {
//                throw new IndexOutOfRangeException("індекс за межами допустимого діапазону"); // index out of range exception - виняток індексу за межами
//            }
//            return laptops[index];
//        }
//        set
//        {
//            if (index < 0 || index > laptops.Count)
//            {
//                throw new IndexOutOfRangeException("індекс за межами допустимого діапазону.");
//            }
//            if (index == laptops.Count)
//            {
//                laptops.Add(value);
//            }
//            else
//            {
//                laptops[index] = value;
//            }
//        }
//    }

//    // перевантажений індексатор для пошуку за ціною (get only, точний збіг)
//    public Laptop this[double price]
//    {
//        get
//        {
//            int index = FindByPrice(price);
//            if (index == -1)
//            {
//                throw new KeyNotFoundException("ноутбук з вказаною ціною не знайдено."); // key not found exception - виняток ключа не знайдено
//            }
//            return laptops[index];
//        }
//    }

//    // перевантажений індексатор для пошуку за назвою виробника (get only, точний збіг, чутливий до регістру)
//    public Laptop this[string name]
//    {
//        get
//        {
//            int index = FindByName(name);
//            if (index == -1)
//            {
//                throw new KeyNotFoundException("ноутбук з вказаною назвою не знайдено.");
//            }
//            return laptops[index];
//        }
//    }

//    public int GetCount()
//    {
//        return laptops.Count;
//    }

//    private int FindByName(string name)
//    {
//        for (int i = 0; i < laptops.Count; i++)
//        {
//            if (laptops[i].GetVendor() == name)
//            {
//                return i;
//            }
//        }
//        return -1;
//    }

//    private int FindByPrice(double price)
//    {
//        for (int i = 0; i < laptops.Count; i++)
//        {
//            if (laptops[i].GetPrice() == price)
//            {
//                return i;
//            }
//        }
//        return -1;
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        var s = new Store();
//        s[0] = new Laptop("ЛьвівКомп", 37261.1);
//        s[1] = new Laptop("КиївТек", 80732.2);
//        s[2] = new Laptop("ОдесаЕлектрон", 45003.5);
//        s[3] = new Laptop("ДніпроДевайс", 62004.0);

//        Console.WriteLine("список ноутбуків за індексами:");
//        for (int i = 0; i < s.GetCount(); i++)
//        {
//            Console.WriteLine(s[i]);
//        }

//        Console.WriteLine("\nпошук за назвою та ціною:");
//        try
//        {
//            Console.WriteLine(s["КиївЛап"]);
//            Console.WriteLine(s[4500.5]); // існує
//            Console.WriteLine(s[9999.99]); // не існує, викличе виняток
//        }
//        catch (KeyNotFoundException e)
//        {
//            Console.WriteLine(e.Message);
//        }

//        // демонстрація додавання через індексатор при index == Count
//        Console.WriteLine("\nдодавання нового ноутбука через індексатор:");
//        s[s.GetCount()] = new Laptop("ЗапоріжжяСистемc", 38000.0);
//        Console.WriteLine(s[s.GetCount() - 1]);
//    }
//}
// --------------------------------------------------------------------------------------------------
//class MyCollection
//{
//    private readonly int[,] arr;
//    private readonly int rows;
//    private readonly int cols;

//    public MyCollection(int rows, int cols)
//    {
//        if (rows <= 0) throw new ArgumentOutOfRangeException(nameof(rows), "кількість рядків має бути більшою за нуль."); // number of rows must be greater than zero - кількість рядків має бути більшою за нуль
//        if (cols <= 0) throw new ArgumentOutOfRangeException(nameof(cols), "кількість стовпців має бути більшою за нуль."); // number of columns must be greater than zero - кількість стовпців має бути більшою за нуль

//        this.rows = rows;
//        this.cols = cols;
//        arr = new int[rows, cols];
//    }

//    public int GetRows()
//    {
//        return rows;
//    }

//    public int GetCols()
//    {
//        return cols;
//    }

//    // багатовимірний індексатор для доступу до елементів 2d-масиву
//    public int this[int r, int c]
//    {
//        get
//        {
//            if (r < 0 || r >= GetRows()) throw new ArgumentOutOfRangeException(nameof(r), "індекс рядка поза межами."); // row index is out of range - індекс рядка поза межами
//            if (c < 0 || c >= GetCols()) throw new ArgumentOutOfRangeException(nameof(c), "індекс стовпця поза межами."); // column index is out of range - індекс стовпця поза межами
//            return arr[r, c];
//        }
//        set
//        {
//            if (r < 0 || r >= GetRows()) throw new ArgumentOutOfRangeException(nameof(r), "індекс рядка поза межами.");
//            if (c < 0 || c >= GetCols()) throw new ArgumentOutOfRangeException(nameof(c), "індекс стовпця поза межами.");
//            arr[r, c] = value;
//        }
//    }

//    // метод для виведення матриці
//    public void Print()
//    {
//        Console.WriteLine("матриця:");
//        for (int i = 0; i < GetRows(); i++)
//        {
//            for (int j = 0; j < GetCols(); j++)
//            {
//                Console.Write("{0,4}", this[i, j]);
//            }
//            Console.WriteLine();
//        }
//    }

//    // метод для обчислення суми елементів
//    public int Sum()
//    {
//        int sum = 0;
//        for (int i = 0; i < GetRows(); i++)
//        {
//            for (int j = 0; j < GetCols(); j++)
//            {
//                sum += this[i, j];
//            }
//        }
//        return sum;
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        var collection = new MyCollection(4, 5);

//        Console.WriteLine("ініціалізація матриці 4x5 з добутками (i+1)*(j+1):");
//        for (int i = 0; i < collection.GetRows(); i++)
//        {
//            for (int j = 0; j < collection.GetCols(); j++)
//            {
//                collection[i, j] = (i + 1) * (j + 1);
//            }
//        }
//        collection.Print();

//        Console.WriteLine("\nсума елементів: {0}", collection.Sum());

//        // тест на помилку
//        try
//        {
//            Console.WriteLine("\nспроба доступу поза межами: collection[4, 0]");
//            Console.WriteLine(collection[4, 0]);
//        }
//        catch (ArgumentOutOfRangeException ex)
//        {
//            Console.WriteLine("помилка: {0}", ex.Message);
//        }

//        // приклад оновлення елемента
//        Console.WriteLine("\nоновлення елемента [0,2] на 100:");
//        collection[0, 2] = 100;
//        collection.Print();
//    }
//}
// --------------------------------------------------------------------------------------------------
//class Person
//{
//    private uint _age;
//    public uint GetAge()
//    {
//        return _age;
//    }
//    public void SetAge(uint age)
//    {
//        if (age > 150)
//        {
//            throw new ArgumentOutOfRangeException(nameof(age), "Age cannot be greater than 150.");
//        }
//        _age = age;
//    }
//}

//class Program
//{
//    static void Main()
//    {

//    }
//}
// --------------------------------------------------------------------------------------------------
//class Person
//{
//    // auto-implemented property (автовластивість)
//    public uint Age { get; set; } // властивості - це черговий синтаксичний цукор над методами доступу (геттерами і сеттерами)
//                                  // компілятор неявно створить приховане приватне поле для збереження значення властивості
//                                  // щось на кшталт: private uint _age; // <Age>k__BackingField
//                                  // а також створить методи доступу:
//                                  // public uint get_Age() { return _age; }
//                                  // public void set_Age(uint value) { _age = value; }

//}

//class Program
//{
//    static void Main()
//    {
//        Person p = new Person();
//        p.Age = 21;
//        Console.WriteLine(p.Age);
//    }
//}
// --------------------------------------------------------------------------------------------------
//class Person
//{
//    uint age; // доведеться додати поле для зберігання значення явно (але клієнт все одно не помітить різниці, тому що це частина реалізації, і вона закрита для клієнта)

//    // якщо все ж таки є певні перевірки на вхідні дані, то можна використовувати звичайні властивості
//    public uint Age
//    {

//        get
//        {
//            return age; // повертаємо значення поля, секцію доводиться зробити явною, тому що назву для поля ми придумали свою, і компілятор іі так просто не підбере з контексту
//        }
//        set
//        { // в явних властивостях так само, як і в індексаторах , можна використовувати перевірки вхідних даних та контекстне ключове слово value
//            if (value > 130)
//            {
//                throw new ArgumentOutOfRangeException("Age must be between 0 and 130.");
//            }
//            age = value;
//        }
//    }

//    // секції get і set під капотом перетворяться на такі методи:
//    // public uint get_Age() { return age; }
//    // public void set_Age(uint value) { ... }
//}

//class Program
//{
//    static void Main()
//    {
//        var p = new Person();
//        p.Age = 21; // p.SetAge(21);
//        Console.WriteLine(p.Age); // p.GetAge(); 
//        p.Age = 150; // це викличе виняток ArgumentOutOfRangeException
//        // звернення до властивості виглядає для користувача як начебто звернення до публічного поля, і він не помічає,
//        що реалізація властивості відрізняється від звичайної - тобто всі перевірки для поля під капотом залишуться!!!
//    }
//}
// --------------------------------------------------------------------------------------------------
//namespace PropertiesExample
//{
//    /*
//    у .net властивості (properties) — це компоненти класу, які надають гнучкий механізм
//    для читання, запису або обчислення значень полів.
//    вони часто використовуються як заміна публічних полів для контролю доступу
//    та модифікації даних.

//    властивості дозволяють інкапсулювати дані та приховувати внутрішні деталі реалізації,
//    при цьому надаючи доступ до цих даних через методи доступу (get і set).
//    це забезпечує зручний синтаксис та додатковий рівень абстракції.
//    */

//    public class Person
//    {
//        // автоматична властивість для імені (get/set)
//        public string Name { get; set; } = "Олександр";

//        // властивість з користувацькою реалізацією для віку (з валідацією)
//        private uint age = 18;
//        public uint Age
//        {
//            get
//            {
//                return age;
//            }
//            set
//            {
//                if (value >= 0 && value <= 100)
//                    age = value;
//                // інакше залишається поточне значення
//            }
//        }

//        // властивість тільки для читання для повного імені (обчислювана)
//        public string FullName
//        {
//            get
//            {
//                return $"{Name} Ковальчук"; // приклад обчислення
//            }
//        }

//        // властивість тільки для ініціалізації (init-only, C# 9+)
//        public string Email { get; init; } = "example@email.com";

//        // required властивість (С# 11+)
//        // новинка для обов'язкових полів при створенні об'єкта
//        // значення можна встановити тільки під час ініціалізації
//        public required string Address { get; set; }

//        // властивість-лямбда (expression-bodied, C# 6+ для зручності)
//        public bool IsAdult => Age >= 18;

//        // властивість для позиції (складена, з вкладеною структурою)
//        public Point Position { get; set; } = new Point();

//        // вкладена структура для демонстрації
//        public struct Point
//        {
//            public Point()
//            {
//                X = 10;
//                Y = 20;
//            }

//            public int X { get; set; }
//            public int Y { get; set; }
//        }
//    }

//    class Program
//    {
//        static void Main()
//        {
//            Console.OutputEncoding = Encoding.UTF8;

//            // створення об'єкта з init-only та required (C# 11+)
//            var person = new Person
//            {
//                Email = "ivan@email.com", // init-only можна встановити тільки тут
//                Address = "вул. Шевченка, 1" // required
//            };

//            Console.WriteLine("початкове ім'я: {0}", person.Name);
//            Console.WriteLine("початковий вік: {0}", person.Age);

//            // тестування set для авто-властивості
//            person.Name = "Микола";
//            Console.WriteLine("оновлене ім'я: {0}", person.Name);

//            // тестування властивості з валідацією
//            person.Age = 25;
//            Console.WriteLine("вік після 25: {0}", person.Age);
//            person.Age = 234; // не зміниться
//            Console.WriteLine("вік після 234 (без змін): {0}", person.Age);

//            // read-only властивість
//            Console.WriteLine("повне ім'я: {0}", person.FullName);

//            // властивість-лямбда
//            Console.WriteLine("дорослий: {0}", person.IsAdult);

//            Console.WriteLine("позиція: X={0}, Y={1}", person.Position.X, person.Position.Y);

//            // спроба змінити init-only після створення (помилка компіляції, але для демо - коментар)
//            // person.Email = "new@email.com"; // помилка: init-only

//            Console.WriteLine("\nдемонстрація властивостей завершено.");
//        }
//    }
//}
// --------------------------------------------------------------------------------------------------
//                                                      УСПАДКУВАННЯ
// --------------------------------------------------------------------------------------------------
//class Person /* : Object */
//{

//}

//struct Point /* : ValueType */
//{

//}
// --------------------------------------------------------------------------------------------------
//class Person
//{
//    public string Name { get; set; }
//    public string Lastname { get; set; }
//    public int Age { get; set; }

//    public Person() : this("Іван", "Іваненко", 25)
//    {
//        Console.WriteLine("конструктор Person без параметрів");
//    }

//    public Person(string name, string lastname, int age)
//    {
//        Console.WriteLine("конструктор Person з параметрами");
//        Name = name;
//        Lastname = lastname;
//        Age = age;
//    }

//    public override string ToString()
//    {
//        return Name + " " + Lastname + ", вік: " + Age;
//    }
//}

//class Policeman : Person
//{
//    class PoliceCap { }
//    class PoliceBadge { }

//    PoliceCap furazhka = new();
//    PoliceBadge znachok = new();

//    public string Rank { get; set; } // звання

//    public Policeman()
//    {
//        Console.WriteLine("конструктор Policeman без параметрів");
//        Rank = "молодший лейтенант";
//    }

//    public Policeman(string name, string lastname, int age, string zvannya) : base(name, lastname, age)
//    {
//        Console.WriteLine("конструктор Policeman з параметрами");
//        Rank = zvannya;
//    }

//    public override string ToString()
//    {
//        return Name + " " + Lastname + ", вік: " + Age + "\nзвання: " + Rank;
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        var p = new Policeman("Іван", "Франко", 37, "старший сержант");
//        Console.WriteLine(p);
//    }
//}
// --------------------------------------------------------------------------------------------------
//раніше в класі було делегування конструкторів, де в головному конструкторі викликалися СЕТТЕРИ

//тепер з появою властивостей, дуже велике прохання: якщо є відповідна властивість в класі або структурі,
//то в головному конструкторі - звертатися саме до ВЛАСТИВОСТІ, а не до сеттера
// --------------------------------------------------------------------------------------------------
//// конструктор похідного типу за замовчуванням звертається до конструктора базового типу за замовчуванням
//public Policeman() : base("Іван", "Іванов", 30) // іноді буває ситуація, що в батьківському типі немає конструктора без параметрів,
//// в такому випадку потрібно явно викликати конструктор базового типу з параметрами
///* : base() по дефолту */ // : this("Іван", "Іванов", 30, "молодший лейтенант")
//{
//    Console.WriteLine("конструктор Policeman без параметрів");
//    Rank = "молодший лейтенант";
//}

//public Policeman(string name, string lastname, int age, string zvannya) : base(name, lastname, age)
//{
//    Console.WriteLine("конструктор Policeman з параметрами");
//    Rank = zvannya;
//}
// --------------------------------------------------------------------------------------------------
//class Person
//{
//    public string Name { get; set; }
//    public string Lastname { get; set; }
//    public int Age { get; set; }

//    public void Test()
//    {
//        Console.WriteLine("Person Test");
//    }
//}

//class Student : Person
//{
//    private void Test()
//    {
//        Console.WriteLine("Student Test");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Person p = new Person();
//        p.Test();

//        Student s = new Student();
//        s.Test(); // спрацює метод із класу Person, тому що в похідному типі метод приватний!
//    }
//}
// --------------------------------------------------------------------------------------------------
//class Person
//{
//    public string Name { get; set; }
//    public string Lastname { get; set; }
//    public int Age { get; set; }

//    public void Test()
//    {
//        Console.WriteLine("Person Test");
//    }
//}

//class Student : Person
//{
//    private new void Test() // приховуємо (hiding) метод із базового класу, new єдине що робить - це прибирає попередження компілятора
//    {
//        Console.WriteLine("Student Test");
//    }

//    public void ShowInfo()
//    {
//        Test(); // викликаємо приватний метод із цього класу
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Person p = new Person();
//        p.Test();

//        Student s = new Student();
//        s.Test(); // спрацює метод із класу Person, тому що в похідному типі метод приватний!

//        s.ShowInfo();
//    }
//}
// --------------------------------------------------------------------------------------------------
//class Person
//{
//    public void Test()
//    {
//        Console.WriteLine("Person Test");
//    }
//}

//class Student : Person
//{
//    public new void Test()
//    {
//        Console.WriteLine("Student Test");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Person p = new Person();
//        p.Test();

//        Student s = new Student();
//        s.Test(); // Calls Student.Test

//        // якщо не підключити пізнє зв'язування (певним чином), то компілятор звертає увагу саме на тип посилання, а не об'єкта!
//        // тобто, якщо ми створюємо об'єкт типу Student, але посилання має тип Person, то буде викликано метод Test з класу Person
//        Person p2 = new Student();
//        p.Test(); // Calls Person.Test
//    }
////}
// --------------------------------------------------------------------------------------------------
//                                                      ДИНАМІЧНИЙ ПОЛІМОРФІЗМ
//using System.Text;
//// батьківський клас задає інтерфейс (метод Test), тобто набір певних дій для своїх нащадків
//class Person
//{
//    // для динамічного (пізнього) зв'язування метод має бути позначений як virtual
//    public virtual void Test()
//    {
//        Console.WriteLine("Person Test");
//    }
//}
//class Student : Person
//{
//    // тепер, коли в батьківському класі метод позначений як virtual, ми можемо перевизначити його в нащадку за допомогою ключового слова override
//    public override void Test() // якщо не написати override, то буде створено новий метод, який не матиме відношення до методу батьківського класу
//    {
//        Console.WriteLine("Student Test");
//   }
//}
//class Program
//{
//    static void Main()
//    {
//        Person p = new Person();
//        p.Test(); // Calls Person.Test
//        Student s = new Student();
//        s.Test(); // Calls Student.Test
//        // тепер, коли в батьківському класі метод позначений як virtual, а в нащадку як override, при зверненні до методу через посилання на батьківський клас буде викликано метод нащадка (динамічне зв'язування)
//        Person p2 = new Student(); // в рантаймі визначається, який саме метод викликати з якого класу (вирішується динамічно, по типу об'єкта, на який посилається змінна, а не по типу самої змінної)
//        p2.Test(); // Calls Student.Test
//    }
//}

// --------------------------------------------------------------------------------------------------

// --------------------------------------------------------------------------------------------------

// --------------------------------------------------------------------------------------------------

// --------------------------------------------------------------------------------------------------