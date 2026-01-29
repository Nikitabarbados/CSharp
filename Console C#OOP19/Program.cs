using System;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Collections.Generic;
// ------------------------------------------------------------------------------------------
//public class Student
//{
//    public string Name { get; set; }
//    public int Age { get; set; }
//}

//class Program
//{
//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        // джерело даних: список студентів
//        var students = new List<Student>
//        {
//            new Student { Name = "Олександр", Age = 19 },
//            new Student { Name = "Марія", Age = 22 },
//            new Student { Name = "Олег", Age = 21 },
//            new Student { Name = "Анна", Age = 18 }
//        };

//        // запит на Query Syntax: вибрати імена студентів старше 20 років
//        IEnumerable<string> adultStudents = from student in students
//                                            where student.Age > 20
//                                            select student.Name; // Name з типом даних стрінг!

//        // виконання запиту
//        Console.WriteLine("Студенти старше 20 років:");
//        foreach (var name in adultStudents)
//        {
//            Console.WriteLine(name); // Марія, Олег
//        }
//    }
//}
// ------------------------------------------------------------------------------------------
//var adultStudents = from student in students
//                    where student.Age > 20
//                    select new { student.Name, student.Age };
// ------------------------------------------------------------------------------------------
//// запит на Query Syntax: вибрати імена студентів старше 20 років
//IEnumerable<Student> adultStudents = from s in students // students - джерело даних
//                                                        // s - змінна діючого елемента, поточний елемент колекції
//                                     where s.Age > 20 // умова фільтрації
//                                     select s; // проекція: вибрати весь об'єкт студента, а не одне якесь поле
// ------------------------------------------------------------------------------------------
//public class Product
//{
//    public string Name { get; set; }
//    public decimal Price { get; set; }
//    public string Category { get; set; }
//}

//class Program
//{
//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        var products = new List<Product>
//        {
//            new Product { Name = "Ноутбук", Price = 25000m, Category = "Електроніка" },
//            new Product { Name = "Книжка", Price = 150m, Category = "Книги" },
//            new Product { Name = "Смартфон", Price = 18000m, Category = "Електроніка" },
//            new Product { Name = "Ручка", Price = 15m, Category = "Канцелярія" },
//            new Product { Name = "Планшет", Price = 12000m, Category = "Електроніка" },
//            new Product { Name = "Журнал", Price = 80m, Category = "Книги" },
//            new Product { Name = "Олівець", Price = 10m, Category = "Канцелярія" }
//        };

//        // запит: фільтрує дорогі продукти, сортує за ціною, групує за категорією та обчислює середню ціну
//        var expensiveProductsByCategory = products
//            .Where(p => p.Price > 100m) // фільтрує продукти дорожче 100 грн
//            .OrderByDescending(p => p.Price) // сортує за ціною за спаданням
//            .GroupBy(p => p.Category) // групує за категорією
//            .Select(g => new // проектує результат в анонімний тип
//            {
//                Category = g.Key,
//                AveragePrice = g.Average(p => p.Price), // обчислює середню ціну в групі
//                Products = g.ToList() // зберігає список продуктів у групі
//            });

//        // виконує запит і виводить результати
//        Console.WriteLine("Дорогі продукти за категоріями (середня ціна):");
//        foreach (var group in expensiveProductsByCategory)
//        {
//            Console.WriteLine($"\nКатегорія: {group.Category}");
//            Console.WriteLine($"Середня ціна: {group.AveragePrice:F2} грн");
//            foreach (var prod in group.Products)
//            {
//                Console.WriteLine($"  - {prod.Name}: {prod.Price} грн");
//            }
//        }
//        // вивід:
//        // Категорія: Електроніка
//        // Середня ціна: 18333.33 грн
//        //   - Ноутбук: 25000 грн
//        //   - Смартфон: 18000 грн
//        //   - Планшет: 12000 грн
//    }
//}
// ------------------------------------------------------------------------------------------
//public class Book
//{
//    public string Title { get; set; }
//    public string Author { get; set; }
//    public string Genre { get; set; }
//    public double Rating { get; set; }
//    public int ReviewsCount { get; set; }
//}

//class Program
//{
//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        var books = new List<Book>
//        {
//            new Book { Title = "Сонячна машина", Author = "Володимир Винниченко", Genre = "Фантастика", Rating = 4.2, ReviewsCount = 150 },
//            new Book { Title = "Дім солі", Author = "Світлана Тараторіна", Genre = "Фантастика", Rating = 4.5, ReviewsCount = 200 },
//            new Book { Title = "Колонія", Author = "Макс Кідрук", Genre = "Фантастика", Rating = 4.3, ReviewsCount = 500 },
//            new Book { Title = "Лазарус", Author = "Світлана Тараторіна", Genre = "Фантастика", Rating = 4.6, ReviewsCount = 300 },
//            new Book { Title = "Кайдашева сім'я", Author = "Іван Нечуй-Левицький", Genre = "Роман", Rating = 4.7, ReviewsCount = 1000 },
//            new Book { Title = "Маруся", Author = "Марко Вовчок", Genre = "Роман", Rating = 4.4, ReviewsCount = 800 },
//            new Book { Title = "Тигролови", Author = "Іван Багряний", Genre = "Роман", Rating = 4.6, ReviewsCount = 600 },
//            new Book { Title = "Вигнанець і перевертень", Author = "Андрій Кокотюха", Genre = "Детектив", Rating = 4.1, ReviewsCount = 250 },
//            new Book { Title = "Готель Велика Пруссія", Author = "Богдан Коломійчук", Genre = "Детектив", Rating = 4.5, ReviewsCount = 400 },
//            new Book { Title = "Аномалія", Author = "Андрій Новік", Genre = "Детектив", Rating = 4.2, ReviewsCount = 150 }
//        };

//        // запит: групує книги за жанром, обчислює агрегати та сортує за середнім рейтингом
//        var booksByGenre = (from book in books
//                            group book by book.Genre into genreGroup
//                            select new
//                            {
//                                Genre = genreGroup.Key,
//                                Count = genreGroup.Count(), // підраховує кількість книг у групі
//                                AverageRating = genreGroup.Average(b => b.Rating), // середній рейтинг групи
//                                TotalReviews = genreGroup.Sum(b => b.ReviewsCount), // загальна кількість відгуків
//                                FirstBook = genreGroup.First().Title // вибирає першу книгу як приклад
//                            }).OrderByDescending(g => g.AverageRating); // сортує групи за середнім рейтингом (за спаданням)

//        Console.WriteLine("Книги, згруповані за жанром (відсортовані за середнім рейтингом):");
//        foreach (var group in booksByGenre)
//        {
//            Console.WriteLine($"\nЖанр: {group.Genre}");
//            Console.WriteLine($"Кількість: {group.Count}");
//            Console.WriteLine($"Середній рейтинг: {group.AverageRating:F1}");
//            Console.WriteLine($"Загальна кількість відгуків: {group.TotalReviews}");
//            Console.WriteLine($"Приклад: {group.FirstBook}");
//        }
//    }
//}
// ------------------------------------------------------------------------------------------
//class Program
//{
//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        string xmlString = @"<?xml version=""1.0"" encoding=""utf-8""?>
//                            <Library>
//                                <Book>
//                                    <Title>Сонячна машина</Title>
//                                    <Author>Володимир Винниченко</Author>
//                                    <Genre>Фантастика</Genre>
//                                    <Rating>4,2</Rating>
//                                    <ReviewsCount>150</ReviewsCount>
//                                </Book>
//                                <Book>
//                                    <Title>Дім солі</Title>
//                                    <Author>Світлана Тараторіна</Author>
//                                    <Genre>Фантастика</Genre>
//                                    <Rating>4,5</Rating>
//                                    <ReviewsCount>200</ReviewsCount>
//                                </Book>
//                                <Book>
//                                    <Title>Колонія</Title>
//                                    <Author>Макс Кідрук</Author>
//                                    <Genre>Фантастика</Genre>
//                                    <Rating>4,3</Rating>
//                                    <ReviewsCount>500</ReviewsCount>
//                                </Book>
//                                <Book>
//                                    <Title>Лазарус</Title>
//                                    <Author>Світлана Тараторіна</Author>
//                                    <Genre>Фантастика</Genre>
//                                    <Rating>4,6</Rating>
//                                    <ReviewsCount>300</ReviewsCount>
//                                </Book>
//                                <Book>
//                                    <Title>Кайдашева сім'я</Title>
//                                    <Author>Іван Нечуй-Левицький</Author>
//                                    <Genre>Роман</Genre>
//                                    <Rating>4,7</Rating>
//                                    <ReviewsCount>1000</ReviewsCount>
//                                </Book>
//                                <Book>
//                                    <Title>Маруся</Title>
//                                    <Author>Марко Вовчок</Author>
//                                    <Genre>Роман</Genre>
//                                    <Rating>4,4</Rating>
//                                    <ReviewsCount>800</ReviewsCount>
//                                </Book>
//                                <Book>
//                                    <Title>Тигролови</Title>
//                                    <Author>Іван Багряний</Author>
//                                    <Genre>Роман</Genre>
//                                    <Rating>4,6</Rating>
//                                    <ReviewsCount>600</ReviewsCount>
//                                </Book>
//                                <Book>
//                                    <Title>Вигнанець і перевертень</Title>
//                                    <Author>Андрій Кокотюха</Author>
//                                    <Genre>Детектив</Genre>
//                                    <Rating>4,1</Rating>
//                                    <ReviewsCount>250</ReviewsCount>
//                                </Book>
//                                <Book>
//                                    <Title>Готель Велика Пруссія</Title>
//                                    <Author>Богдан Коломійчук</Author>
//                                    <Genre>Детектив</Genre>
//                                    <Rating>4,5</Rating>
//                                    <ReviewsCount>400</ReviewsCount>
//                                </Book>
//                                <Book>
//                                    <Title>Аномалія</Title>
//                                    <Author>Андрій Новік</Author>
//                                    <Genre>Детектив</Genre>
//                                    <Rating>4,2</Rating>
//                                    <ReviewsCount>150</ReviewsCount>
//                                </Book>
//                            </Library>";

//        // для зовнішнього файлу: XDocument doc = XDocument.Load("books.xml");
//        var doc = XDocument.Parse(xmlString);

//        // LINQ to XML: групує за жанром, обчислює агрегати, фільтрує (>4.3), сортує за рейтингом
//        var booksByGenre = (from book in doc.Descendants("Book")
//                            let genre = book?.Element("Genre")?.Value
//                            let rating = double.Parse(book.Element("Rating").Value)
//                            let reviews = int.Parse(book.Element("ReviewsCount").Value)
//                            group new { book, rating, reviews } by genre into genreGroup
//                            let avgRating = genreGroup.Average(g => g.rating)
//                            where avgRating > 4.3 // фільтрує групи з високим середнім рейтингом
//                            select new
//                            {
//                                Genre = genreGroup.Key,
//                                Count = genreGroup.Count(), // кількість книг у групі
//                                AverageRating = avgRating, // середній рейтинг
//                                TotalReviews = genreGroup.Sum(g => g.reviews), // загальна кількість відгуків
//                                TopBook = genreGroup.OrderByDescending(g => g.rating).First().book.Element("Title").Value // топ-книга за рейтингом
//                            }).OrderByDescending(g => g.AverageRating); // сортує групи за середнім рейтингом (за спаданням)

//        Console.WriteLine("Аналіз книг з XML (групи з рейтингом >4.3, відсортовані):");
//        foreach (var group in booksByGenre)
//        {
//            Console.WriteLine($"\nЖанр: {group.Genre}");
//            Console.WriteLine($"Кількість: {group.Count}");
//            Console.WriteLine($"Середній рейтинг: {group.AverageRating:F1}");
//            Console.WriteLine($"Загальна кількість відгуків: {group.TotalReviews}");
//            Console.WriteLine($"Топ-книга: {group.TopBook}");
//        }
//    }
//}
// ------------------------------------------------------------------------------------------
//public class Creature
//{
//    public string Name { get; set; } // назва істоти
//    public bool Flying { get; set; } // літає?
//    public bool Ranged { get; set; } // стріляє на відстані?
//    public int Attack { get; set; } // атака
//    public int Defense { get; set; } // захист
//    public int Health { get; set; } // здоров'я (HP)
//    public int Speed { get; set; } // швидкість
//}

//class Program
//{
//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        var creatures = new List<Creature>
//        {
//            new Creature { Name = "Стрілець", Flying = false, Ranged = true, Attack = 6, Defense = 3, Health = 10, Speed = 6 },
//            new Creature { Name = "Арбалетник", Flying = false, Ranged = true, Attack = 6, Defense = 3, Health = 10, Speed = 6 },
//            new Creature { Name = "Грифон", Flying = true, Ranged = false, Attack = 6, Defense = 6, Health = 25, Speed = 7 },
//            new Creature { Name = "Королівський грифон", Flying = true, Ranged = false, Attack = 9, Defense = 8, Health = 30, Speed = 9 },
//            new Creature { Name = "Монах", Flying = false, Ranged = true, Attack = 13, Defense = 11, Health = 40, Speed = 6 },
//            new Creature { Name = "Фанатик", Flying = false, Ranged = true, Attack = 14, Defense = 14, Health = 40, Speed = 7 },
//            new Creature { Name = "Ангел", Flying = true, Ranged = false, Attack = 20, Defense = 20, Health = 200, Speed = 12 },
//            new Creature { Name = "Архангел", Flying = true, Ranged = true, Attack = 30, Defense = 30, Health = 250, Speed = 18 } // літає та стріляє для прикладу
//        };

//        var flyingOrRanged = creatures
//            .Where(c => c.Flying || c.Ranged) // лямбда: фільтрує за умовою (літає АБО стріляє)
//            .OrderByDescending(c => c.Attack) // лямбда: сортує за атакою (за спаданням)
//            .Select(c => new // лямбда в Select для проекції
//            {
//                Name = c.Name,
//                Attack = c.Attack,
//                Defense = c.Defense,
//                Health = c.Health,
//                Speed = c.Speed,
//                Type = c.Flying ? (c.Ranged ? "Літаючий + Стріляючий" : "Літаючий") : "Стріляючий"
//            })
//            .ToList();  // матеріалізація результату

//        Console.WriteLine("Літаючі або стріляючі істоти фракції Замок з HoMM 3 (відсортовані за атакою):");
//        foreach (var unit in flyingOrRanged)
//        {
//            Console.WriteLine($"- {unit.Name}: Атака {unit.Attack}, Захист {unit.Defense}, HP {unit.Health}, Швидкість {unit.Speed} ({unit.Type})");
//        }
//    }
//}
// ------------------------------------------------------------------------------------------
public class Student
{
    public string Name {
        get;
        set;
    }
    public List<int> Grades { 
        get;
        set;
    }

    public double AverageGrade => Grades.Average();
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        var students = new List<Student>
        {
            new Student { Name = "Андрій", Grades = new List<int> { 10, 9, 8, 7, 12, 11 } },
            new Student { Name = "Олег",   Grades = new List<int> { 5, 7, 6, 8 } },
            new Student { Name = "Анна",   Grades = new List<int> { 9, 10, 11, 12, 8, 9 } },
            new Student { Name = "Марія",  Grades = new List<int> { 12, 12, 11 } }
        };

        var filteredStudents = from s in students
            let gradesCount = s.Grades.Count

            where s.AverageGrade > 7 && gradesCount > 5 && s.Name.StartsWith("А", StringComparison.OrdinalIgnoreCase)
            select s;

        Console.WriteLine("Студенти, які відповідають умовам:");

        foreach (var st in filteredStudents)
        {
            Console.WriteLine($"{st.Name} — середній бал: {st.AverageGrade:F2}, оцінок: {st.Grades.Count}");
        }
    }
}

// ------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------