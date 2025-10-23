using System;
using System.Text;

// ------------------------------------------------------------------------------------------------
//enum DayOfWeek { Monday = 1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }

//class Program
//{
//    static string GetUkrainianDay(DayOfWeek day)
//    {
//        // переклад назви дня тижня на українську
//        return day switch
//        {
//            DayOfWeek.Monday => "понеділок",
//            DayOfWeek.Tuesday => "вівторок",
//            DayOfWeek.Wednesday => "середа",
//            DayOfWeek.Thursday => "четвер",
//            DayOfWeek.Friday => "п'ятниця",
//            DayOfWeek.Saturday => "субота",
//            DayOfWeek.Sunday => "неділя",
//            _ => "невідомий день"
//        };
//    }

//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;
//        Console.ForegroundColor = ConsoleColor.Green;

//        DayOfWeek day = DayOfWeek.Saturday;

//        // перелічення — клас, що представляє непорожній список іменованих цілочислених констант з певними значеннями
//        for (int i = 0, j = 18; j <= 31; i++, j++)
//        {
//            Console.WriteLine($"{j}, {GetUkrainianDay(day)}");

//            if (day == DayOfWeek.Sunday)
//                Console.WriteLine();

//            day++;

//            if (day > DayOfWeek.Sunday)
//                day = DayOfWeek.Monday;
//        }
//    }
//}
// ------------------------------------------------------------------------------------------------

//enum State : short { Stop = 12, Wait = 14, Go = 10, Blink = 0 }

//class Program
//{
//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;
//        Console.Title = "Світлофор";
//        Console.CursorVisible = false;

//        State trafficLightState = State.Stop; // початковий стан світлофора

//        while (true)
//        {
//            Console.BackgroundColor = (ConsoleColor)trafficLightState;
//            Console.Clear();
//            Console.ForegroundColor = ConsoleColor.White;
//            Console.WriteLine(GetStateDescription(trafficLightState));

//            if (trafficLightState == State.Stop)
//            {
//                Thread.Sleep(4000);
//                trafficLightState = State.Wait;
//            }
//            else if (trafficLightState == State.Wait)
//            {
//                Thread.Sleep(2000);
//                trafficLightState = State.Go;
//            }
//            else if (trafficLightState == State.Go)
//            {
//                Thread.Sleep(4000);
//                trafficLightState = State.Blink;
//            }
//            else if (trafficLightState == State.Blink)
//            {
//                for (int i = 0; i < 3; i++)
//                {
//                    Console.BackgroundColor = (ConsoleColor)State.Blink;
//                    Console.Clear();
//                    Thread.Sleep(300);
//                    Console.BackgroundColor = (ConsoleColor)State.Go;
//                    Console.Clear();
//                    Console.ForegroundColor = ConsoleColor.White;
//                    Console.WriteLine(GetStateDescription(State.Blink));
//                    Thread.Sleep(300);
//                }
//                trafficLightState = State.Stop;
//            }
//        }
//    }

//    static string GetStateDescription(State state)
//    {
//        return state switch
//        {
//            State.Stop => "\n\tЧервоний сигнал (СТОП)",
//            State.Wait => "\n\tЖовтий сигнал (ЧЕКАЙТЕ)",
//            State.Go => "\n\tЗелений сигнал (ІДІТЬ)",
//            State.Blink => "\n\tМигання (ПОПЕРЕДЖЕННЯ)",
//            _ => "\n\tНевідомий стан"
//        };
//        // стани: stop - червоний (зупинка), wait - жовтий (очікування), go - зелений (рух), blink - мигання (попередження з чорним та зеленим тлом)
//    }
//}
// ------------------------------------------------------------------------------------------------
//class Program
//{
//    enum Months : byte { Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec }

//    enum MachineState
//    {
//        PowerOff = 0,
//        Running = 5,
//        Sleeping = 10,
//        Hibernating = Sleeping + 5
//    }

//    [Flags] // атрибут, що вказує, що enum використовується як набір прапорців
//    enum Days
//    {
//        None = 0x0,
//        Monday = 0x1,
//        Tuesday = 0x2,
//        Wednesday = 0x4,
//        Thursday = 0x8,
//        Friday = 0x10,
//        Saturday = 0x20,
//        Sunday = 0x40
//    }

//    public enum ResultCode
//    {
//        Success,
//        Warning,
//        Error
//    }

//    [Flags]
//    public enum MessagingOptions
//    {
//        None = 0,
//        Buffered = 0x01,
//        Persistent = 0x02,
//        Durable = 0x04,
//        Broadcast = 0x08
//    }

//    public static int ResultCodeFromDataSource()
//    {
//        return 0;
//        // return -4; // для перевірки помилки поза діапазоном
//    }

//    public static ResultCode PerformAction()
//    {
//        // викликаємо метод, який повертає int
//        int result = ResultCodeFromDataSource();

//        if (!Enum.IsDefined(typeof(ResultCode), result))
//        {
//            throw new InvalidOperationException("Enum поза діапазоном!");
//        }

//        // це вдасться, навіть якщо результат < 0 або > 2, але перевірка запобігає
//        return (ResultCode)result;
//    }

//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        // демонстрація enum Days з прапорцями
//        Days meetingDays = Days.Tuesday | Days.Thursday;
//        Console.WriteLine("Дні зустрічей: " + meetingDays);

//        var s = Enum.GetName(typeof(Days), 4);
//        Console.WriteLine(s + "\n");

//        Console.WriteLine("Значення enum Days:");
//        foreach (Days d in Enum.GetValues<Days>())
//            Console.Write((int)d + ", ");
//        Console.WriteLine("\n");

//        Console.WriteLine("Назви enum Days:");
//        foreach (string str in Enum.GetNames<Days>())
//            Console.Write(str + ", ");
//        Console.WriteLine("\n");

//        // демонстрація enum Months
//        Console.WriteLine("Назви місяців:");
//        foreach (string m in Enum.GetNames<Months>())
//            Console.Write(m + ", ");
//        Console.WriteLine("\n");

//        // демонстрація enum MachineState
//        Console.WriteLine("Стани машини:");
//        foreach (MachineState ms in Enum.GetValues<MachineState>())
//            Console.WriteLine($"{ms} = {(int)ms}");
//        Console.WriteLine();

//        // демонстрація ResultCode з приведенням типів
//        ResultCode result = PerformAction();

//        switch (result)
//        {
//            case ResultCode.Success:
//                Console.WriteLine("виконується код для успішного результату");
//                break;

//            case ResultCode.Warning:
//                Console.WriteLine("виконується код для попередження");
//                break;

//            case ResultCode.Error:
//                Console.WriteLine("виконується код для помилки");
//                break;
//        }
//        Console.WriteLine();

//        // демонстрація MessagingOptions з парсингом
//        string optionsString = "Persistent";

//        // використовуємо generic Enum.Parse (сучасний підхід)
//        MessagingOptions parsedResult = Enum.Parse<MessagingOptions>(optionsString);

//        if (parsedResult == MessagingOptions.Persistent)
//        {
//            Console.WriteLine("Це працює!");
//        }

//        ///////////////////////////////////////////////

//        optionsString = "Persistent, Buffered";

//        parsedResult = Enum.Parse<MessagingOptions>(optionsString); // парсинг рядка з кількома прапорцями

//        if (parsedResult.HasFlag(MessagingOptions.Persistent) && parsedResult.HasFlag(MessagingOptions.Buffered))
//        {
//            Console.WriteLine("Це працює!");
//        }

//        ///////////////////////////////////////////////

//        optionsString = "3"; // "3" представляє собою поєднання Buffered (0x01) і Persistent (0x02)

//        parsedResult = Enum.Parse<MessagingOptions>(optionsString);

//        if (parsedResult.HasFlag(MessagingOptions.Persistent) && parsedResult.HasFlag(MessagingOptions.Buffered))
//        {
//            Console.WriteLine("Це працює знову!");
//        }

//        ///////////////////////////////////////////////

//        optionsString = "Persistent, Buf3fered";

//        // спроба парсингу з generic TryParse (сучасний підхід)
//        if (Enum.TryParse(optionsString, out MessagingOptions tryResult))
//        {
//            if (tryResult.HasFlag(MessagingOptions.Persistent) && tryResult.HasFlag(MessagingOptions.Buffered))
//            {
//                Console.WriteLine("Це працює!");
//            }
//        }
//        else
//        {
//            Console.WriteLine("Щось не так!\n\n");
//        }

//        ///////////////////////////////////////////////

//        MessagingOptions value = MessagingOptions.Buffered | MessagingOptions.Persistent;

//        // загальний формат, який використовується за замовчуванням
//        Console.WriteLine("За замовчуванням    : " + value);

//        // формат прапорців
//        Console.WriteLine("F (прапорці)  : " + value.ToString("F"));

//        // цілочисловий формат
//        Console.WriteLine("D (число)    : " + value.ToString("D"));

//        // шістнадцятковий формат
//        Console.WriteLine("X (hex)    : " + value.ToString("X"));

//    }
//}
// ------------------------------------------------------------------------------------------------

//[Flags]
//enum Days
//{
//    None = 0,
//    Monday = 1,
//    Tuesday = 2,
//    Wednesday = 4,
//    Thursday = 8,
//    Friday = 16,
//    Saturday = 32,
//    Sunday = 64
//}

//class Program
//{
//    static void Main()
//    {
//        Days personWorkDays = (Days)37;

//        Console.WriteLine(personWorkDays);
//    }
//}

// ------------------------------------------------------------------------------------------------
//namespace EnumerationsAndStructures
//{
//    enum Discount // види знижок
//    {
//        Default = 0, Incentive = 2, Patron = 5, Vip = 15, Student = 10, Senior = 12, Family = 8, Loyalty = 20, Bulk = 25, Seasonal = 18
//    }

//    /* З точки зору .NET, enum Discount є спеціальним значущим типом (value type), який компілюється в структуру (value class у IL),
//    що успадковується від System.Enum. Це забезпечує типобезпеку, порівняння та серіалізацію, але з особливими правилами (наприклад,
//    базовий тип зазвичай int). Enum-члени стають статичними полями типу Discount у цій структурі.
//    Ось як це виглядає внутрішньо в метаданих .NET (приблизний еквівалент на C#, бо компілятор не дозволяє прямо успадковуватися від Enum
//    для кастомних типів — це робиться через ключове слово enum):
//    [Serializable]
//    public class Discount : Enum  // у IL: .class value public auto ansi sealed Discount extends [mscorlib]System.Enum
//    {
//        // приховане поле для значення (underlying type: int)
//        public int value__;  // це генерується автоматично
//        // статичні поля для кожного члена (readonly, з значеннями)
//        public static readonly Discount Default = new Discount(0);
//        public static readonly Discount Incentive = new Discount(2);
//        public static readonly Discount Patron = new Discount(5);
//        public static readonly Discount Vip = new Discount(15);
//        public static readonly Discount Student = new Discount(10);
//        public static readonly Discount Senior = new Discount(12);
//        public static readonly Discount Family = new Discount(8);
//        public static readonly Discount Loyalty = new Discount(20);
//        public static readonly Discount Bulk = new Discount(25);
//        public static readonly Discount Seasonal = new Discount(18);
//        // приватний конструктор (enum не можна інстанціювати вручну)
//        private Discount(int value)
//        {
//            this.value__ = value;
//        }
//        // еnum реалізує інтерфейси для порівняння, форматування тощо
//        // (IComparable<Discount>, IFormattable, IConvertible — генерується автоматично)
//    } */

//    enum CommodityType // типи товарів
//    {
//        FrozenFood, Food, DomesticChemistry, BuildingMaterials, Electronics, Clothing, Books, Furniture, Automotive, MedicalSupplies
//    }

//    struct Dimensions // габарити
//    {
//        public double Length;
//        public double Width;
//    }

//    struct ConsignmentItem // елемент замовлення
//    {
//        public string Name;             // найменування
//        public decimal Weight;          // вага
//        public decimal Price;           // заявлена вартість
//        public Dimensions Dimensions;   // розміри
//        public CommodityType Type;      // тип товару
//        public Discount Discount;       // знижка
//    }

//    struct Consignment // замовлення
//    {
//        public decimal TotalWeight;
//        public decimal TotalPrice;
//        public decimal TotalDiscountedPrice;
//        public List<ConsignmentItem> Commodities;
//    }

//    enum TransportType
//    {
//        Semitrailer, Coupling, Refrigerator, OpenSideTruck, Tank, Car, Train, Airplane, Ship, Bicycle
//    }

//    struct Transport
//    {
//        public string Name;                         // назва
//        public decimal Capacity;                    // місткість
//        public TransportType Type;                  // тип
//        public List<ConsignmentItem> Commodities;   // перелік товарів
//    }

//    enum DistanceSun : ulong
//    {
//        Sun = 0,
//        Mercury = 57900000,
//        Venus = 108200000,
//        Earth = 149600000,
//        Mars = 227900000,
//        Jupiter = 7783000000,
//        Saturn = 1427000000,
//        Uranus = 2870000000,
//        Neptune = 4496000000,
//        Pluto = 5946000000
//    }

//    class EnumSwitchExample
//    {
//        public Transport Refrigerator;
//        public Transport Semitrailer;
//        public Transport Coupling;
//        public Transport OpenSideTruck;
//        public Transport Tank;
//        public Transport Car;
//        public Transport Train;
//        public Transport Airplane;
//        public Transport Ship;
//        public Transport Bicycle;

//        public EnumSwitchExample()
//        {
//            Refrigerator = new Transport { Name = "Холодильник", Capacity = 10000, Type = TransportType.Refrigerator, Commodities = new List<ConsignmentItem>() };
//            Semitrailer = new Transport { Name = "Напівпричіп", Capacity = 20000, Type = TransportType.Semitrailer, Commodities = new List<ConsignmentItem>() };
//            Coupling = new Transport { Name = "Зчеплення", Capacity = 15000, Type = TransportType.Coupling, Commodities = new List<ConsignmentItem>() };
//            OpenSideTruck = new Transport { Name = "Відкритий борт", Capacity = 18000, Type = TransportType.OpenSideTruck, Commodities = new List<ConsignmentItem>() };
//            Tank = new Transport { Name = "Цистерна", Capacity = 12000, Type = TransportType.Tank, Commodities = new List<ConsignmentItem>() };
//            Car = new Transport { Name = "Автомобіль", Capacity = 500, Type = TransportType.Car, Commodities = new List<ConsignmentItem>() };
//            Train = new Transport { Name = "Поїзд", Capacity = 50000, Type = TransportType.Train, Commodities = new List<ConsignmentItem>() };
//            Airplane = new Transport { Name = "Літак", Capacity = 1000, Type = TransportType.Airplane, Commodities = new List<ConsignmentItem>() };
//            Ship = new Transport { Name = "Корабель", Capacity = 100000, Type = TransportType.Ship, Commodities = new List<ConsignmentItem>() };
//            Bicycle = new Transport { Name = "Велосипед", Capacity = 50, Type = TransportType.Bicycle, Commodities = new List<ConsignmentItem>() };
//        }

//        public void SetTransport(ConsignmentItem item)
//        {
//            switch (item.Type)
//            {
//                case CommodityType.FrozenFood:
//                    Refrigerator.Commodities.Add(item);
//                    break;
//                case CommodityType.Food:
//                    Semitrailer.Commodities.Add(item);
//                    break;
//                case CommodityType.DomesticChemistry:
//                    Coupling.Commodities.Add(item);
//                    break;
//                case CommodityType.BuildingMaterials:
//                    OpenSideTruck.Commodities.Add(item);
//                    break;
//                case CommodityType.Electronics:
//                    Tank.Commodities.Add(item);
//                    break;
//                case CommodityType.Clothing:
//                    Car.Commodities.Add(item);
//                    break;
//                case CommodityType.Books:
//                    Train.Commodities.Add(item);
//                    break;
//                case CommodityType.Furniture:
//                    Airplane.Commodities.Add(item);
//                    break;
//                case CommodityType.Automotive:
//                    Ship.Commodities.Add(item);
//                    break;
//                case CommodityType.MedicalSupplies:
//                    Bicycle.Commodities.Add(item);
//                    break;
//                default:
//                    Semitrailer.Commodities.Add(item);
//                    break;
//            }
//        }

//        public void PrintTransports()
//        {
//            Console.WriteLine("Розподіл товарів по транспорту:");
//            Console.WriteLine($"Холодильник: {Refrigerator.Commodities.Count} товарів");
//            Console.WriteLine($"Напівпричіп: {Semitrailer.Commodities.Count} товарів");
//            Console.WriteLine($"Зчеплення: {Coupling.Commodities.Count} товарів");
//            Console.WriteLine($"Відкритий борт: {OpenSideTruck.Commodities.Count} товарів");
//            Console.WriteLine($"Цистерна: {Tank.Commodities.Count} товарів");
//            Console.WriteLine($"Автомобіль: {Car.Commodities.Count} товарів");
//            Console.WriteLine($"Поїзд: {Train.Commodities.Count} товарів");
//            Console.WriteLine($"Літак: {Airplane.Commodities.Count} товарів");
//            Console.WriteLine($"Корабель: {Ship.Commodities.Count} товарів");
//            Console.WriteLine($"Велосипед: {Bicycle.Commodities.Count} товарів");
//        }
//    }

//    class Program
//    {
//        static void Main()
//        {
//            Console.OutputEncoding = Encoding.UTF8;

//            // тест 1: перелік всіх видів знижок
//            Console.WriteLine("Усі можливі види знижок:");
//            foreach (Discount d in Enum.GetValues<Discount>())
//                Console.WriteLine($"{d} = {(int)d}%");
//            Console.WriteLine();

//            // тест 2: перелік всіх типів товарів
//            Console.WriteLine("Усі можливі типи товарів:");
//            foreach (CommodityType ct in Enum.GetValues<CommodityType>())
//                Console.WriteLine(ct);
//            Console.WriteLine();

//            // тест 3: перелік всіх типів транспорту
//            Console.WriteLine("Усі можливі типи транспорту:");
//            foreach (TransportType tt in Enum.GetValues<TransportType>())
//                Console.WriteLine(tt);
//            Console.WriteLine();

//            // тест 4: демонстрація struct Dimensions
//            Dimensions dims1 = new Dimensions { Length = 10.5, Width = 5.2 };
//            Dimensions dims2 = new Dimensions { Length = 20.0, Width = 10.0 };
//            Console.WriteLine($"Габарити 1: довжина {dims1.Length}, ширина {dims1.Width}");
//            Console.WriteLine($"Габарити 2: довжина {dims2.Length}, ширина {dims2.Width}");
//            Console.WriteLine();

//            // тест 5: створення елементів замовлення з різними типами та знижками
//            ConsignmentItem item1 = new ConsignmentItem { Name = "Морозиво", Weight = 5.0m, Price = 100.0m, Dimensions = dims1, Type = CommodityType.FrozenFood, Discount = Discount.Student };
//            ConsignmentItem item2 = new ConsignmentItem { Name = "Хліб", Weight = 2.0m, Price = 20.0m, Dimensions = dims1, Type = CommodityType.Food, Discount = Discount.Vip };
//            ConsignmentItem item3 = new ConsignmentItem { Name = "Миючий засіб", Weight = 3.0m, Price = 50.0m, Dimensions = dims1, Type = CommodityType.DomesticChemistry, Discount = Discount.Patron };
//            ConsignmentItem item4 = new ConsignmentItem { Name = "Цегла", Weight = 10.0m, Price = 200.0m, Dimensions = dims1, Type = CommodityType.BuildingMaterials, Discount = Discount.Default };
//            ConsignmentItem item5 = new ConsignmentItem { Name = "Телевізор", Weight = 15.0m, Price = 500.0m, Dimensions = dims2, Type = CommodityType.Electronics, Discount = Discount.Loyalty };
//            ConsignmentItem item6 = new ConsignmentItem { Name = "Сорочка", Weight = 0.5m, Price = 30.0m, Dimensions = dims1, Type = CommodityType.Clothing, Discount = Discount.Family };
//            ConsignmentItem item7 = new ConsignmentItem { Name = "Книга", Weight = 1.0m, Price = 15.0m, Dimensions = dims1, Type = CommodityType.Books, Discount = Discount.Seasonal };
//            ConsignmentItem item8 = new ConsignmentItem { Name = "Стіл", Weight = 25.0m, Price = 300.0m, Dimensions = dims2, Type = CommodityType.Furniture, Discount = Discount.Bulk };
//            ConsignmentItem item9 = new ConsignmentItem { Name = "Шина", Weight = 8.0m, Price = 150.0m, Dimensions = dims2, Type = CommodityType.Automotive, Discount = Discount.Senior };
//            ConsignmentItem item10 = new ConsignmentItem { Name = "Бинт", Weight = 0.2m, Price = 10.0m, Dimensions = dims1, Type = CommodityType.MedicalSupplies, Discount = Discount.Incentive };

//            // тест 6: створення замовлення з розрахунком знижок
//            var allItems = new List<ConsignmentItem> { item1, item2, item3, item4, item5, item6, item7, item8, item9, item10 };
//            decimal totalWeight = allItems.Sum(i => i.Weight);
//            decimal totalPrice = allItems.Sum(i => i.Price);
//            decimal totalDiscounted = allItems.Sum(i => i.Price * (1 - (decimal)(int)i.Discount / 100));
//            Consignment consignment = new Consignment
//            {
//                TotalWeight = totalWeight,
//                TotalPrice = totalPrice,
//                TotalDiscountedPrice = totalDiscounted,
//                Commodities = allItems
//            };

//            Console.WriteLine($"Загальна вага замовлення: {consignment.TotalWeight} кг");
//            Console.WriteLine($"Загальна вартість: {consignment.TotalPrice} грн");
//            Console.WriteLine($"Вартість з урахуванням знижок: {consignment.TotalDiscountedPrice} грн");
//            Console.WriteLine();

//            // тест 7: демонстрація розподілу по транспорту
//            EnumSwitchExample example = new EnumSwitchExample();
//            foreach (var item in allItems)
//                example.SetTransport(item);
//            example.PrintTransports();
//            Console.WriteLine();

//            // тест 8: демонстрація enum DistanceSun з розрахунком
//            Console.WriteLine("Відстані від Сонця (км):");
//            ulong earthToMars = (ulong)DistanceSun.Mars - (ulong)DistanceSun.Earth;
//            foreach (DistanceSun ds in Enum.GetValues<DistanceSun>())
//                Console.WriteLine($"{ds} = {(ulong)ds}");
//            Console.WriteLine($"Відстань від Землі до Марса: {earthToMars} км");
//            Console.WriteLine();

//            // тест 9: групування товарів по типах
//            Console.WriteLine("Групування товарів по типах:");
//            var groupedByType = allItems.GroupBy(i => i.Type);
//            foreach (var group in groupedByType)
//            {
//                Console.WriteLine($"{group.Key}: {group.Count()} товарів, загальна вага {group.Sum(i => i.Weight)} кг");
//            }
//            Console.WriteLine();

//            // тест 10: пошук товарів з певною знижкою
//            var vipItems = allItems.Where(i => i.Discount == Discount.Vip).ToList();
//            Console.WriteLine("Товари з VIP знижкою:");
//            foreach (var item in vipItems)
//                Console.WriteLine($"- {item.Name}: {item.Price} грн");
//        }
//    }
//}
// ------------------------------------------------------------------------------------------------
//class Program
//{
//    /* перевантаження операторів у c# дозволяє розробникам визначати або змінювати
//     * поведінку операторів для користувацьких типів даних (класів і структур).
//     * це робить використання об'єктів цих типів більш інтуїтивним і зручним.
//     * наприклад, ви можете перевантажити оператори для виконання арифметичних операцій
//     * з об'єктами користувацьких класів так само, як це робиться з вбудованими типами даних,
//     * такими як int або double.
//     * 
//     * ось кілька причин, чому може знадобитися перевантаження операторів:
//    - зручність використання: дозволяє створювати більш природний і зрозумілий код,
//    який простіше читати та підтримувати.
//    - скорочення коду: спрощує код, звільняючи від необхідності викликати методи
//    для виконання операцій.
//    - підвищення виразності: забезпечує можливість використання звичних операторів
//    для об'єктів користувацьких типів, роблячи код більш виразним.
//    - інкапсуляція логіки: логіка операцій може бути інкапсульована всередині класів,
//    що робить код більш модульним і керованим. */

//    class MyInt
//    {
//        int i;

//        public MyInt(int some)
//        {
//            i = some;
//        }

//        // оператор ++ або -- змінює об'єкт,
//        // а що він буде повертати, вирішується на основі того,
//        // префіксно він викликається чи постфіксно:
//        // якщо використовується префіксна нотація, то повертається значення, що повертає оператор,
//        // якщо постфіксна - то початкове значення об'єкта.
//        // при цьому важливо не змінювати в коді викликаючий об'єкт,
//        // і тоді все бере на себе компілятор.

//        public static MyInt operator ++(MyInt original)
//        {
//            // правильний для префіксного та постфіксного:
//            MyInt copy = new MyInt(original.i);
//            copy.i++;
//            return copy;

//            // завжди префіксний:
//            // original.i++;
//            // return original;
//        }

//        public static MyInt operator -(MyInt original)
//        {
//            MyInt copy = new MyInt(original.i);
//            copy.i = -copy.i;
//            return copy;
//        }

//        public override string ToString()
//        {
//            return i.ToString();
//        }
//    }

//    public static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        MyInt m = new MyInt(5);
//        Console.WriteLine($"Початкове значення: {m}");

//        m++;
//        Console.WriteLine($"Після постфіксного ++: {m}");

//        ++m;
//        Console.WriteLine($"Після префіксного ++: {m}");

//        Console.WriteLine($"Префіксне ++m: {++m}");

//        Console.WriteLine($"Постфіксне m++: {m++}");

//        Console.WriteLine($"Після m++: {m}");

//        Console.WriteLine($"Унарний -: {-m}");

//        Console.WriteLine($"Оригінальне m: {m}");
//    }
//}
// ------------------------------------------------------------------------------------------------
//class Program
//{
//    class MyInt
//    {
//        private int i;

//        public MyInt(int some)
//        {
//            i = some;
//        }

//        public int Value => i;

//        public static MyInt operator +(MyInt left, MyInt right)
//        {
//            return new MyInt(left.i + right.i);
//        }

//        public static MyInt operator -(MyInt left, MyInt right)
//        {
//            return new MyInt(left.i - right.i);
//        }

//        public static MyInt operator *(MyInt left, MyInt right)
//        {
//            return new MyInt(left.i * right.i);
//        }

//        public static MyInt operator /(MyInt left, MyInt right)
//        {
//            if (right.i == 0)
//            {
//                throw new DivideByZeroException("ділення на нуль заборонено");
//            }
//            return new MyInt(left.i / right.i);
//        }

//        public static MyInt operator -(MyInt original)
//        {
//            return new MyInt(-original.i);
//        }

//        public override string ToString()
//        {
//            return i.ToString();
//        }
//    }

//    class MyDouble
//    {
//        private double d;

//        public MyDouble(double some)
//        {
//            d = some;
//        }

//        public double Value => d;

//        public static MyDouble operator +(MyDouble left, MyDouble right)
//        {
//            return new MyDouble(left.d + right.d);
//        }

//        public static MyDouble operator +(MyDouble left, MyInt right)
//        {
//            return new MyDouble(left.d + right.Value);
//        }

//        public static MyDouble operator +(MyInt left, MyDouble right)
//        {
//            return new MyDouble(left.Value + right.d);
//        }

//        public static MyDouble operator -(MyDouble left, MyDouble right)
//        {
//            return new MyDouble(left.d - right.d);
//        }

//        public static MyDouble operator *(MyDouble left, MyDouble right)
//        {
//            return new MyDouble(left.d * right.d);
//        }

//        public static MyDouble operator /(MyDouble left, MyDouble right)
//        {
//            if (right.d == 0)
//            {
//                throw new DivideByZeroException("ділення на нуль заборонено");
//            }
//            return new MyDouble(left.d / right.d);
//        }

//        public static MyDouble operator -(MyDouble original)
//        {
//            return new MyDouble(-original.d);
//        }

//        public override string ToString()
//        {
//            return d.ToString();
//        }
//    }

//    public static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        MyInt a = new MyInt(5);
//        MyInt b = new MyInt(10);
//        Console.WriteLine($"a + b = {a + b}"); // 15
//        Console.WriteLine($"a - b = {a - b}"); // -5
//        Console.WriteLine($"a * b = {a * b}"); // 50
//        Console.WriteLine($"a / b = {a / b}"); // 0
//        Console.WriteLine($"-a = {-a}"); // -5

//        MyDouble c = new MyDouble(5.5);
//        MyDouble dObj = new MyDouble(2.0);
//        Console.WriteLine($"c + dObj = {c + dObj}"); // 7.5
//        Console.WriteLine($"c - dObj = {c - dObj}"); // 3.5
//        Console.WriteLine($"c * dObj = {c * dObj}"); // 11
//        Console.WriteLine($"c / dObj = {c / dObj}"); // 2.75
//        Console.WriteLine($"c + b = {c + b}"); // 15.5
//        Console.WriteLine($"-c = {-c}"); // -5.5
//    }
//}
// ------------------------------------------------------------------------------------------------
//class Program
//{
//    class Person
//    {
//        public int age;

//        public Person()
//        {
//            age = 0;
//        }

//        // разом із перевантаженням == рекомендується перевизначити метод equals з класу object
//        public override bool Equals(object? someStranger)
//        {
//            // у цьому методі персону можна порівнювати з об'єктами будь-якого типу (кішками, собаками, студентами, інтами, рядками тощо)

//            // перевіряємо, об'єкт якого типу прийшов як параметр
//            if (someStranger is not Person whoIsIt)
//            {
//                Console.WriteLine("це не person або посилання є null");
//                return false;
//            }

//            // якщо вік прийшовшої персони співпадає з віком поточної персони, то вони умовно рівні
//            return whoIsIt.age == age;
//        }

//        public override int GetHashCode()
//        {
//            return age.GetHashCode();
//        }

//        public static bool operator ==(Person left, Person right)
//        {
//            // деякі оператори перевантажуються в c# тільки парно:
//            // == !=
//            // > <
//            // >= <=

//            if (left is null)
//            {
//                return right is null;
//            }

//            if (right is null)
//            {
//                return false;
//            }

//            return left.Equals(right);
//        }

//        public static bool operator !=(Person left, Person right)
//        {
//            return !(left == right);
//        }

//        public static bool operator >(Person left, Person right)
//        {
//            if (left is null || right is null)
//            {
//                return false;
//            }
//            return left.age > right.age;
//        }

//        public static bool operator <(Person left, Person right)
//        {
//            if (left is null || right is null)
//            {
//                return false;
//            }
//            return left.age < right.age;
//        }

//        public static bool operator >=(Person left, Person right)
//        {
//            if (left is null || right is null)
//            {
//                return false;
//            }
//            return left.age >= right.age;
//        }

//        public static bool operator <=(Person left, Person right)
//        {
//            if (left is null || right is null)
//            {
//                return false;
//            }
//            return left.age <= right.age;
//        }
//    }

//    public static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        Person one = new Person { age = 20 };
//        Person two = new Person { age = 20 };
//        Person three = new Person { age = 25 };

//        if (one == two)
//        {
//            Console.WriteLine("one == two: рівні");
//        }

//        if (one != three)
//        {
//            Console.WriteLine("one != three: не рівні");
//        }

//        if (one < three)
//        {
//            Console.WriteLine("one < three: менше");
//        }

//        if (three > one)
//        {
//            Console.WriteLine("three > one: більше");
//        }

//        if (one <= two)
//        {
//            Console.WriteLine("one <= two: менше або рівне");
//        }

//        if (three >= one)
//        {
//            Console.WriteLine("three >= one: більше або рівне");
//        }
//    }
//}
// ------------------------------------------------------------------------------------------------
//class Program
//{
//    class MyPoint
//    {
//        private int x;
//        private int y;

//        public MyPoint(int x, int y)
//        {
//            this.x = x;
//            this.y = y;
//        }

//        public MyPoint(double d)
//        {
//            x = (int)d;
//            y = (int)(d - (int)d);
//        }

//        public static explicit operator int(MyPoint point)
//        {
//            return point.x + point.y;
//        }

//        public static implicit operator double(MyPoint point)
//        {
//            return point.x + point.y;
//        }

//        public static implicit operator MyPoint(int number)
//        {
//            return new MyPoint(number, number);
//        }

//        public static explicit operator MyPoint(double number)
//        {
//            return new MyPoint((int)number, (int)((number - (int)number) * 100));
//        }

//        public override string ToString()
//        {
//            return $"x = {x}, y = {y}";
//        }
//    }

//    public static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        MyPoint p = new MyPoint(5, 7);
//        Console.WriteLine(p); // викликає tostring
//        Console.WriteLine(p.ToString());
//        double d = p; // неявне перетворення до double
//        Console.WriteLine($"подвійне значення: {d}");
//        MyPoint a = (MyPoint)d; // лише явно!
//        Console.WriteLine(a.ToString());

//        // додаткові тести
//        MyPoint b = 10; // неявне з int
//        Console.WriteLine($"з int: {b}");
//        int sum = (int)p; // явне до int
//        Console.WriteLine($"сума як int: {sum}");
//    }
//}
// ------------------------------------------------------------------------------------------------
//class Program
//{
//    class TriState
//    {
//        public static readonly TriState yes = new TriState(1.0);
//        public static readonly TriState no = new TriState(0.0);
//        public static readonly TriState maybe = new TriState(0.5);

//        private double value;

//        private TriState(double value)
//        {
//            this.value = value;
//        }

//        public TriState(TriState ts)
//        {
//            this.value = ts.value;
//        }

//        public override string ToString()
//        {
//            return value switch
//            {
//                1.0 => "ТАК :)",
//                0.0 => "НІ :(",
//                _ => "Можливо ;)"
//            };
//        }

//        // оператор && повертає:
//        // NO, якщо один з операндів також НІ
//        // MAYBE, якщо один з операндів МОЖЛИВО, а інший МОЖЛИВО або ТАК
//        // YES, якщо обидва операнди ТАК
//        public static TriState operator &(TriState left, TriState right)
//        {
//            if (left.value == 0.0 || right.value == 0.0) return no;
//            if (left.value == 0.5 || right.value == 0.5) return maybe;
//            return yes;
//        }

//        public static TriState operator |(TriState left, TriState right)
//        {
//            if (left.value == 1.0 || right.value == 1.0) return yes;
//            if (left.value == 0.5 || right.value == 0.5) return maybe;
//            return no;
//        }

//        public static TriState operator !(TriState ans)
//        {
//            return ans.value switch
//            {
//                1.0 => no,
//                0.0 => yes,
//                _ => maybe
//            };
//        }

//        public static bool operator true(TriState ans)
//        {
//            return ans.value > 0.0;
//        }

//        public static bool operator false(TriState ans)
//        {
//            return ans.value == 0.0;
//        }
//    }

//    public static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        string question = "чи припинили ви пити коньяк по ранках?";
//        TriState answer = new TriState(TriState.maybe);

//        Console.WriteLine(question);
//        Console.WriteLine($"відповідь: {answer}");

//        if (answer)
//        {
//            Console.WriteLine("вітаємо!");
//        }
//        else if (!answer)
//        {
//            Console.WriteLine("шкода.");
//        }
//        else
//        {
//            Console.WriteLine("невизначено.");
//        }

//        TriState yesAns = TriState.yes;
//        TriState noAns = TriState.no;
//        TriState maybeAns = TriState.maybe;

//        Console.WriteLine($"так && ні = {yesAns & noAns}");
//        Console.WriteLine($"можливо || ні = {maybeAns | noAns}");
//        Console.WriteLine($"!так = {!yesAns}");
//        Console.WriteLine($"!можливо = {!maybeAns}");
//    }
//}
// ------------------------------------------------------------------------------------------------
//using System.Text;

//class Cat
//{
//    public static implicit operator Dog(Cat c)
//    {
//        return new Dog();
//    }
//}

//class Dog
//{
//    public static implicit operator Cat(Dog d)
//    {
//        return new Cat();
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Cat c = new Cat();
//        Dog d = c;

//        Dog d2 = new Dog();
//        Cat c2 = d2;
//    }
//}

// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------