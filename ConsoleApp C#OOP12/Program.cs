// -----------------------------------------------------
//SOLID

//low coupling - (слабке зв'язування) - класів буде багато, вони будуть пов'язані між собою так чи інакше (як приклад - Людина та Кіт),
//і задача програміста, не прибрати повністю а послабити ці зв'язки за рахунок використання абстрактних класів та інтерфейсів

//high cohesion - (високе зчеплення) - клас не має буи занадто великим

//гнучка архітектура дозволить суттєво зменшити кількість правок коду в класі

//в ідеалі, клас пишеться швидко, і після його створення програміст взагалі ніколи не повертається в тіло класу для правок
// -----------------------------------------------------
//Делегат у .NET — це тип, який представляє посилання на метод (або навіть об'єкт, який містить цілий масив посилань на методи)  
//з певною сигнатурою (параметрами та типом повернення).

//в с++ існували покажчики на функціі, в дот нет - це такий же концепт,
//АЛЕ в дот нет - все об'єкт, того чи іншого типу, в тому числі - покажчики на функціі.

//технічно, Він дозволяє передавати методи       
//як аргументи в інші методи, повертати їх з методів або зберігати   
//в змінних.

//Делегати вирішують проблему жорсткого зв'язування коду, роблячи програми гнучкішими та модульнішими.
// -----------------------------------------------------
using System;
using System.Text;
// -----------------------------------------------------

//class Kitchen
//{
//    public delegate void Ingredient();

//    public static void ChefBurger(Ingredient chain)
//    {
//        Console.WriteLine("Починаємо приготування чізбургера");
//        chain?.Invoke();
//        Console.WriteLine("Чізбургер готовий! \n");
//    }

//    public static void Bulka()
//    {
//        Console.WriteLine("Додаємо булочку");
//    }

//    public static void Cheese()
//    {
//        Console.WriteLine("Кладемо сир");
//    }

//    public static void Cucumber()
//    {
//        Console.WriteLine("Додаємо маринований огірок");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Kitchen.Ingredient recept = null;
//        recept += Kitchen.Bulka;
//        recept += Kitchen.Cheese;
//        recept += Kitchen.Cucumber;

//        Kitchen.ChefBurger(recept);

//        Console.ReadKey();
//    }
//}
// -----------------------------------------------------
//class Program
//{
//    // рядок нижче НЕ створює ніяких об'єктів, його задача - описати новий класовий тип
//    delegate void MyDelegate(int a, int b);

//    /* // виглядати клас буде приблизно так, 
//    class MyDelegate : MulticastDelegate {
//        // наявність такого типу дозволить створювати ОБ'ЄКТИ типу делегата, які і будуть покажчиками на функціі, або в термінах дот нет - посилання на метод 
//        // але! це будуть покажчики НЕ на будь який метод, А ЛИШЕ ТОЙ, що приймає 2 параметри типу інт і нічого не повертає!
//    }
//     */

//    static void Sum(int a, int b)
//    {
//        Console.WriteLine("SUM: " + (a + b));
//    }

//    static void Difference(int a, int b)
//    {
//        Console.WriteLine("DIFF: " + (a - b));
//    }

//    static void Product(int a, int b)
//    {
//        Console.WriteLine("PRODUCT: " + (a * b));
//    }

//    static int Dilennya(int a, int b)
//    {
//        return a / b;
//    }

//    static void Main()
//    {
//        MyDelegate ptr = new MyDelegate(Sum); // справа від оператора = створюється об'єкт, який буде покажчиком на функцію
//                                              // в конструктор цього об'єкта в якості агрумента передається АДРЕСА метода Сум
//                                              // нью поверне адресу цього об'єкта-покажчика, і ця адреса пишеться в ПОСИЛАННЯ зліва від дорівнює
//                                              // MyDelegate ptr = new MyDelegate(Dilennya); // ПОМИЛКА! тому що функція ДІлення повертає НЕ воід!
//                                              // MyDelegate ptr = new MyDelegate(Main); // ПОМИЛКА! тому що функція Мейн приймає НЕ 2 інти!

//        ptr = new MyDelegate(Difference);
//        ptr = new MyDelegate(Product);
//    }

//}
// -----------------------------------------------------
//class Program
//{
//    delegate void MyDelegate(int a, int b);

//    static void Sum(int a, int b)
//    {
//        Console.WriteLine("SUM: " + (a + b));
//    }

//    static void Difference(int a, int b)
//    {
//        Console.WriteLine("DIFF: " + (a - b));
//    }

//    static void Product(int a, int b)
//    {
//        Console.WriteLine("PRODUCT: " + (a * b));
//    }

//    static void Main()
//    {
//        // MyDelegate ptr = new MyDelegate(Sum);
//        MyDelegate ptr = Sum; // об'єкт буде створено НЕЯВНО
//        Sum(10, 15); // прямий виклик функціі по іі ідентифікатору
//        ptr(10, 15); // непрямий виклик через делегат
//    }

//}
// -----------------------------------------------------
//class Program
//{
//    delegate void MyDelegate(int a, int b);

//    static void Sum(int a, int b)
//    {
//        Console.WriteLine("SUM: " + (a + b));
//    }

//    static void Difference(int a, int b)
//    {
//        Console.WriteLine("DIFF: " + (a - b));
//    }

//    static void Product(int a, int b)
//    {
//        Console.WriteLine("PRODUCT: " + (a * b));
//    }

//    static void DoSomething(MyDelegate pf)
//    {
//        pf(1, 2);
//    }

//    static void Main()
//    {
//        MyDelegate ptr = Sum;
//        DoSomething(ptr); // передача адреси метода як аргументу
//    }

//}
// -----------------------------------------------------
//class Program
//{
//    delegate void MyDelegate(int a, int b);

//    static void Sum(int a, int b)
//    {
//        Console.WriteLine("SUM: " + (a + b));
//    }

//    static void Difference(int a, int b)
//    {
//        Console.WriteLine("DIFF: " + (a - b));
//    }

//    static void Product(int a, int b)
//    {
//        Console.WriteLine("PRODUCT: " + (a * b));
//    }

//    static void DoSomething(MyDelegate pf)
//    {
//        pf(1, 2);
//    }

//    static void Main()
//    {
//        DoSomething(Sum); // передача адреси метода як аргументу
//        DoSomething(Difference);
//        DoSomething(Product);
//    }

//}
// -----------------------------------------------------
//class Program
//{
//    delegate void MyDelegate(int a, int b);

//    static void Sum(int a, int b)
//    {
//        Console.WriteLine("SUM: " + (a + b));
//    }

//    static void Difference(int a, int b)
//    {
//        Console.WriteLine("DIFF: " + (a - b));
//    }

//    static void Product(int a, int b)
//    {
//        Console.WriteLine("PRODUCT: " + (a * b));
//    }

//    // ДуСамсинг - не знає зарання, який саме алгоритм виконається
//    static void DoSomething(MyDelegate pf, int a, int b)
//    {
//        pf(a, b);
//    }

//    static void Main()
//    {
//        DoSomething(Sum, 10, 15); // передача адреси метода як першого аргументу, А ТАКОЖ ДАНИХ - 2 та 3 аргумент
//        DoSomething(Difference, 20, 5);
//        DoSomething(Product, 5, 6);
//    }

//}
// -----------------------------------------------------
//class Program
//{
//    delegate void SomeTask();

//    static void DishWash()
//    {
//        Console.WriteLine("Миємо посуд");
//    }

//    static void SweepFloor()
//    {
//        Console.WriteLine("Підмітаємо підлогу");
//    }

//    static void WaterFlowers()
//    {
//        Console.WriteLine("Поливаємо квіти");
//    }

//    // універсальний метод, який може зробити передану задачу
//    static void Brother(SomeTask task)
//    {
//        task();
//    }

//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;
//        Brother(WaterFlowers); // делегуємо задачу в інший контекст
//        Brother(SweepFloor);
//        Brother(DishWash);

//        Brother(() => Console.WriteLine("Погодувати кота"));
//    }

//}
// -----------------------------------------------------
//class Program
//{
//    delegate void SomeTask();

//    static void DishWash()
//    {
//        Console.WriteLine("Миємо посуд");
//    }

//    static void SweepFloor()
//    {
//        Console.WriteLine("Підмітаємо підлогу");
//    }

//    static void WaterFlowers()
//    {
//        Console.WriteLine("Поливаємо квіти");
//    }

//    // універсальний метод, який може зробити передану задачу
//    static void Brother(SomeTask task)
//    {
//        Console.WriteLine("Брат починає виконувати передані інструкціі...");
//        Thread.Sleep(2000);

//        task();
//        Thread.Sleep(2000);
//        Console.WriteLine("Готово!");
//    }

//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;
//        Brother(() => {
//            Console.WriteLine("Погодувати кота");
//            Console.WriteLine("Погодувати кота 2");
//            Console.WriteLine("Погодувати кота 3");
//            Console.WriteLine("Погодувати кота 4");
//            Console.WriteLine("Погодувати кота 5");
//        });

//        Brother(SweepFloor);
//    }

//}
// -----------------------------------------------------
//class Program
//{
//    delegate void SomeTask();

//    static void DishWash()
//    {
//        Console.WriteLine("Миємо посуд");
//    }

//    static void SweepFloor()
//    {
//        Console.WriteLine("Підмітаємо підлогу");
//    }

//    static void WaterFlowers()
//    {
//        Console.WriteLine("Поливаємо квіти");
//    }

//    // універсальний метод, який може зробити передану задачу
//    static void Brother(SomeTask task)
//    {
//        Console.WriteLine("Брат починає виконувати передані інструкціі...");
//        Thread.Sleep(2000);

//        task();
//        Thread.Sleep(2000);
//        Console.WriteLine("Готово!");
//    }

//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        SomeTask tasks = WaterFlowers;
//        tasks += SweepFloor;
//        tasks += DishWash;
//        tasks += WaterFlowers;
//        // в середині об'єкта тепер буде цілий масив посилань на методи 
//        Brother(tasks);
//    }

//}
// -----------------------------------------------------
//class Program
//{
//    /*
//    делегат — це об'єкт, який зберігає посилання на метод (або декілька методів),
//    і може викликати його (їх) за допомогою цього посилання.

//    використання делегатів можна описати чотирма кроками:

//    1. визначення в коді методів з певною сигнатурою та типом поверненого значення
//    2. визначення типу для делегатів з сигнатурою, що точно відповідає сигнатурі методів
//    3. створення об'єкта делегата та зв'язування його з методом (або методами)
//    4. виклик методу (або методів) через посилання на об'єкт делегата
//    */

//    static void Sum(int a, int b) // 1
//    {
//        Console.WriteLine(a + b);
//    }

//    delegate void Calculate(int x, int y); // 2

//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        Calculate del = new Calculate(Sum); // 3
//        Calculate test = Sum; // неявне створення об'єкта типу делегата
//        test(5, 7); // 4
//    }
//}
// -----------------------------------------------------
//class Program
//{
//    delegate void ArrayProcessor(double[] array);

//    // метод, який приймає дані та делегат (алгоритм обробки)
//    static void ProcessArray(double[] array, ArrayProcessor algorithm)
//    {
//        Console.WriteLine("Назва алгоритму: " + algorithm.Method.Name);
//        algorithm(array);
//    }

//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        double[] numbers = { 1, 2, 3, 4, 5 };

//        Console.WriteLine("Передача алгоритмів в якості аргумента:");

//        // першим аргументом є масив даних, другим - метод обробки (алгоритм)
//        ProcessArray(numbers, ShowSum);
//        ProcessArray(numbers, ShowProduct);
//        ProcessArray(numbers, ShowIncremented);
//        ProcessArray(numbers, ShowSquares);
//        ProcessArray(numbers, ShowReversed);
//        ProcessArray(numbers, ShowEveryThird);
//        ProcessArray(numbers, ShowEven);
//    }

//    ///////////////////////////////////////////////////////
//    // алгоритми обробки:

//    static void ShowSum(double[] array)
//    {
//        double total = 0;
//        foreach (double num in array)
//            total += num;
//        Console.WriteLine($"Сума елементів: {total}");
//    }

//    static void ShowProduct(double[] array)
//    {
//        double total = 1;
//        foreach (double num in array)
//            total *= num;
//        Console.WriteLine($"Добуток елементів: {total}");
//    }

//    static void ShowIncremented(double[] array)
//    {
//        Console.WriteLine("Елементи з +1:");
//        foreach (double num in array)
//            Console.Write((num + 1) + ", ");
//        Console.WriteLine();
//    }

//    static void ShowSquares(double[] array)
//    {
//        Console.WriteLine("Квадрати елементів:");
//        foreach (double num in array)
//            Console.Write(num * num + ", ");
//        Console.WriteLine();
//    }

//    static void ShowReversed(double[] array)
//    {
//        Console.WriteLine("Елементи навпаки:");
//        for (int i = array.Length - 1; i >= 0; i--)
//            Console.Write(array[i] + ", ");
//        Console.WriteLine();
//    }

//    static void ShowEveryThird(double[] array)
//    {
//        Console.WriteLine("Кожен третій елемент:");
//        for (int i = 0; i < array.Length; i += 3)
//            Console.Write(array[i] + ", ");
//        Console.WriteLine();
//    }

//    static void ShowEven(double[] array)
//    {
//        Console.WriteLine("Парні значення:");
//        foreach (double num in array)
//            if (num % 2 == 0) Console.Write(num + ", ");
//        Console.WriteLine();
//    }
//}
// -----------------------------------------------------
//class Program
//{
//    // колбек - це функція, передана як параметр інший функції, яка викликається після завершення основної операції для обробки результату.
//    // в c# колбеки реалізуються через делегати, ось наприклад власний делегат для дій з рядком.

//    delegate void Notify(string message);

//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        // приклади з різними колбеками
//        SendEmail("oleksandr@itstep.org", ConsoleNotify);
//        SendEmail("oleg-poshta.com", TitleNotify);
//        SendEmail("marijka@ukr.net", FileNotify);
//        Console.ReadKey();
//        // SendEmail("olha1138@gmail.com", MessageBoxNotify);
//    }

//    static bool IsValidEmail(string email)
//    {
//        // спрощена перевірка email
//        return email.Contains("@") && email.Contains(".");
//    }

//    static void SendEmail(string email, Notify notify)
//    {
//        if (!IsValidEmail(email))
//        {
//            notify("Невірний формат email-адреси."); // виклик колбеку
//            return;
//        }

//        // імітація відправки, так само виклик колбеку
//        notify($"Повідомлення успішно відправлено на {email}.");
//    }

//    // різні способи повідомлення користувача:
//    static void ConsoleNotify(string message)
//    {
//        Console.WriteLine(message);
//    }

//    static void TitleNotify(string message)
//    {
//        Console.Title = message;
//    }

//    static void FileNotify(string message)
//    {
//        File.AppendAllText("log.txt", $"{DateTime.Now}: {message}\n", Encoding.UTF8);
//    }
//}
// -----------------------------------------------------

// -----------------------------------------------------

// -----------------------------------------------------

// -----------------------------------------------------