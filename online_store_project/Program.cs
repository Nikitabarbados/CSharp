using System;
using OnlineStore.Models;

namespace OnlineStore
{
    internal class Program
    {
        static void Main()
        {
            Console.Title = "Інтернет-магазин - Учбовий Проект";

            var apple = new Product("Яблуко", 10.0, 5);
            var milk = new Product("Молоко", 30.0, 3);
            var bread = new Product("Хліб", 25.0, 2);

            apple.PriceChanged += (p, oldP, newP)
            {
                Console.WriteLine($"[EVENT] Ціна {p.Name} змінена з {oldP} на {newP}");
            };

            apple.ChangePrice(12.0);

            var ivan = new Customer("Іван", "ivan@example.com");
            ivan.Buy(apple);
            ivan.Buy(milk);

            var cart = ivan.Cart;
            cart += (bread, 1); 
            Console.WriteLine(cart.ToString());

            for (int i = 0; i < cart.Count; i++)
            {
                var item = cart[i];
                Console.WriteLine($"Item {i}: {item.Name} - {item.Price} грн");
            }

            var products = new[] { apple, milk, bread };

            var cheap = products.Where(p => p.Price < 30).OrderBy(p => p.Price);

            Console.WriteLine("Продукти дешевші за 30 грн:");

            foreach (var p in cheap) 
                Console.WriteLine($" - {p.Name} : {p.Price}");

            ivan.Checkout();

            Console.WriteLine("\nТести завершено. Натисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}
