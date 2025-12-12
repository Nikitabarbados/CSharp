using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Інтернет-магазин";

            try
            {
                var store = new OnlineStoreApp();
                store.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Критична помилка: {ex.Message}");
                Console.ReadKey();
            }
        }
    }

    public class OnlineStoreApp
    {
        private readonly ProductRepository repository;
        private readonly ShoppingCart cart;
        private readonly DiscountManager discountManager;

        public OnlineStoreApp()
        {
            repository = new ProductRepository();
            cart = new ShoppingCart();
            discountManager = new DiscountManager();

            cart.ItemAdded += OnItemAdded;
            cart.ItemRemoved += OnItemRemoved;

            InitializeStore();
        }

        private void InitializeStore()
        {
            repository.Add(new Electronics("Ноутбук Dell XPS 15", 45000, "Dell", 24));
            repository.Add(new Electronics("Смартфон iPhone 15", 35000, "Apple", 12));
            repository.Add(new Electronics("Навушники Sony WH-1000XM5", 12000, "Sony", 24));

            repository.Add(new Clothing("Футболка Nike", 1200, "L", "Бавовна"));
            repository.Add(new Clothing("Джинси Levis", 2500, "M", "Денім"));

            repository.Add(new Book("Clean Code", 800, "Robert Martin", "978-0132350884"));
            repository.Add(new Book("Design Patterns", 950, "Gang of Four", "978-0201633610"));

            discountManager.AddDiscount(new PercentageDiscount(10, 10000));
            discountManager.AddDiscount(new FixedDiscount(500, 5000));
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                ShowMainMenu();

                var choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            ShowAllProducts();
                            break;
                        case "2":
                            SearchProducts();
                            break;
                        case "3":
                            AddProductToCart();
                            break;
                        case "4":
                            ViewCart();
                            break;
                        case "5":
                            RemoveFromCart();
                            break;
                        case "6":
                            Checkout();
                            break;
                        case "7":
                            ShowStatistics();
                            break;
                        case "0":
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Невірний вибір!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }

                if (running && choice != "0")
                {
                    Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("Дякуємо за покупки! До побачення!");
        }

        private void ShowMainMenu()
        {
            Console.WriteLine("ІНТЕРНЕТ-МАГАЗИН");
            Console.WriteLine();
            Console.WriteLine("1  Показати всі товари");
            Console.WriteLine("2  Пошук товарів");
            Console.WriteLine("3  Додати товар до кошика");
            Console.WriteLine("4  Переглянути кошик");
            Console.WriteLine("5  Видалити з кошика");
            Console.WriteLine("6  Оформити замовлення");
            Console.WriteLine("7  Статистика");
            Console.WriteLine("8  Вихід");
            Console.WriteLine();
            Console.Write("Ваш вибір: ");
        }
        private void ShowAllProducts()
        {
            Console.Clear();
            Console.WriteLine("КАТАЛОГ ТОВАРІВ\n");

            var products = repository.GetAll();

            var grouped = products.GroupBy(p => p.GetType().Name);

            foreach (var group in grouped)
            {
                Console.WriteLine($"\n{TranslateCategory(group.Key)}:");
                Console.WriteLine(new string('─', 60));

                int index = 1;
                foreach (var product in group)
                {
                    Console.WriteLine($"{index}. {product}");
                    index++;
                }
            }
        }

        private void SearchProducts()
        {
            Console.Clear();
            Console.Write("Введіть назву товару для пошуку: ");
            string query = Console.ReadLine();

            var results = repository.Search(query);

            Console.WriteLine($"\nЗнайдено товарів: {results.Count()}\n");

            int index = 1;
            foreach (var product in results)
            {
                Console.WriteLine($"{index}. {product}");
                index++;
            }
        }

        private void AddProductToCart()
        {
            ShowAllProducts();

            Console.Write("\n\nВведіть ID товару для додавання: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var product = repository[id];
                if (product != null)
                {
                    Console.Write("Кількість: ");
                    if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
                    {
                        cart.AddItem(product, quantity);
                    }
                    else
                    {
                        Console.WriteLine("Невірна кількість!");
                    }
                }
                else
                {
                    Console.WriteLine("Товар не знайдено!");
                }
            }
        }

        private void ViewCart()
        {
            Console.Clear();
            Console.WriteLine("ВАШ КОШИК\n");

            if (cart.ItemCount == 0)
            {
                Console.WriteLine("Кошик порожній");
                return;
            }

            cart.DisplayItems();

            decimal subtotal = cart.GetSubtotal();
            decimal discount = discountManager.CalculateDiscount(subtotal);
            decimal total = subtotal - discount;

            Console.WriteLine(new string('═', 60));
            Console.WriteLine($"Проміжний підсумок: {subtotal:C0} грн");
            if (discount > 0)
            {
                Console.WriteLine($"Знижка: -{discount:C0} грн");
            }
            Console.WriteLine($"РАЗОМ ДО СПЛАТИ: {total:C0} грн");
        }

        private void RemoveFromCart()
        {
            ViewCart();

            if (cart.ItemCount > 0)
            {
                Console.Write("\n\nВведіть ID товару для видалення: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    cart.RemoveItem(id);
                }
            }
        }

        private void Checkout()
        {
            if (cart.ItemCount == 0)
            {
                Console.WriteLine("Кошик порожній!");
                return;
            }

            ViewCart();

            Console.Write("\n\nПідтвердити замовлення? (Y/N): ");
            if (Console.ReadLine()?.ToUpper() == "Y")
            {
                var order = new Order(cart, discountManager);
                order.SaveToFile();

                Console.WriteLine("\nЗамовлення успішно оформлено!");
                Console.WriteLine($"Номер замовлення: {order.OrderNumber}");

                cart.Clear();
            }
        }
        private void ShowStatistics()
        {
            Console.Clear();
            Console.WriteLine("СТАТИСТИКА МАГАЗИНУ\n");

            var products = repository.GetAll().ToList();

            Console.WriteLine($"Всього товарів: {products.Count}");
            Console.WriteLine($"Середня ціна: {products.Average(p => p.Price):C0} грн");
            Console.WriteLine($"Найдорожчий товар: {products.Max(p => p.Price):C0} грн");
            Console.WriteLine($"Найдешевший товар: {products.Min(p => p.Price):C0} грн");

            var byCategory = products.GroupBy(p => p.GetType().Name).Select(g => new { Category = g.Key, Count = g.Count(), AvgPrice = g.Average(p => p.Price) });

            Console.WriteLine("\nЗа категоріями:");
            foreach (var stat in byCategory)
            {
                Console.WriteLine($"{TranslateCategory(stat.Category)}: {stat.Count} шт., середня ціна {stat.AvgPrice:C0} грн");
            }

            var orders = Order.LoadFromFiles();
            if (orders.Any())
            {
                Console.WriteLine($"\nВсього замовлень: {orders.Count}");
                Console.WriteLine($"Загальна сума: {orders.Sum(o => o.TotalAmount):C0} грн");
            }
        }

        private void OnItemAdded(object sender, CartEventArgs e)
        {
            Console.WriteLine($"\nДодано: {e.Product.Name} x{e.Quantity}");
        }

        private void OnItemRemoved(object sender, CartEventArgs e)
        {
            Console.WriteLine($"\nВидалено: {e.Product.Name}");
        }

        private string TranslateCategory(string category)
        {
            return category switch
            {
                "Electronics" => "Електроніка",
                "Clothing" => "Одяг",
                "Book" => "Книги",
                _ => category
            };
        }
    }
}