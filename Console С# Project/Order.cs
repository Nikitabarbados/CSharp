using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OnlineStore
{
    public enum OrderStatus
    {
        Created,        
        Processing,    
        Shipped,        
        Delivered,    
        Cancelled      
    }

    [Serializable]
    public class Order
    {
        private static readonly string OrdersDirectory = "Orders";
        private static int orderCounter = 1;

        public string OrderNumber { 
            get;
            private set; 
        }

        public DateTime OrderDate { 
            get;
            private set;
        }

        public List<OrderItem> Items {
            get;
            private set;
        }

        public decimal SubtotalAmount {
            get; 
            private set; 
        }

        public decimal DiscountAmount {
            get;
            private set;
        }

        public decimal TotalAmount {
            get;
            private set; 
        }

        public OrderStatus Status {
            get; 
            set; 
        }

        public string Notes {
            get; 
            set; 
        }

        public Order()
        {
            Items = new List<OrderItem>();
        }

        public Order(ShoppingCart cart, DiscountManager discountManager)
        {
            if (cart == null)
                throw new ArgumentNullException(nameof(cart));

            OrderNumber = GenerateOrderNumber();
            OrderDate = DateTime.Now;
            Status = OrderStatus.Created;

            Items = cart.GetItems().Select(item => new OrderItem(item.Product, item.Quantity)).ToList();

            SubtotalAmount = cart.GetSubtotal();
            DiscountAmount = discountManager?.CalculateDiscount(SubtotalAmount) ?? 0;
            TotalAmount = SubtotalAmount - DiscountAmount;
        }

        private static string GenerateOrderNumber()
        {
            return 
                $"ORD-{DateTime.Now:yyyyMMdd}-{orderCounter++:D4}";
        }

        public void SaveToFile()
        {
            try
            {
                if (!Directory.Exists(OrdersDirectory))
                {
                    Directory.CreateDirectory(OrdersDirectory);
                }

                string fileName = Path.Combine(OrdersDirectory, $"{OrderNumber}.json");

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                string jsonString = JsonSerializer.Serialize(this, options);
                File.WriteAllText(fileName, jsonString);

                Console.WriteLine($"Замовлення збережено: {fileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка збереження: {ex.Message}");
                throw;
            }
        }

        public static Order LoadFromFile(string orderNumber)
        {
            try
            {
                string fileName = Path.Combine(OrdersDirectory, $"{orderNumber}.json");

                if (!File.Exists(fileName))
                {
                    throw new FileNotFoundException($"Замовлення {orderNumber} не знайдено");
                }

                string jsonString = File.ReadAllText(fileName);
                return JsonSerializer.Deserialize<Order>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка завантаження: {ex.Message}");
                throw;
            }
        }

        public static List<Order> LoadFromFiles()
        {
            var orders = new List<Order>();

            try
            {
                if (!Directory.Exists(OrdersDirectory))
                {
                    return orders;
                }

                var orderFiles = Directory.GetFiles(OrdersDirectory, "*.json");

                foreach (var file in orderFiles)
                {
                    try
                    {
                        string jsonString = File.ReadAllText(file);
                        var order = JsonSerializer.Deserialize<Order>(jsonString);
                        if (order != null)
                        {
                            orders.Add(order);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Помилка читання файлу {file}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка завантаження замовлень: {ex.Message}");
            }

            return orders;
        }
        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
            SaveToFile();
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"ЗАМОВЛЕННЯ #{OrderNumber,-36} ");
            Console.WriteLine($"Дата: {OrderDate:dd.MM.yyyy HH:mm}");
            Console.WriteLine($"Статус: {TranslateStatus(Status)}");
            Console.WriteLine();
            Console.WriteLine("ТОВАРИ:");
            Console.WriteLine(new string('─', 60));

            int index = 1;
            foreach (var item in Items)
            {
                Console.WriteLine($"{index}. {item}");
                index++;
            }

            Console.WriteLine(new string('═', 60));
            Console.WriteLine($"Проміжний підсумок: {SubtotalAmount:C0} грн");

            if (DiscountAmount > 0)
            {
                Console.WriteLine($"Знижка: -{DiscountAmount:C0} грн");
            }

            Console.WriteLine($"ВСЬОГО ДО СПЛАТИ: {TotalAmount:C0} грн");

            if (!string.IsNullOrEmpty(Notes))
            {
                Console.WriteLine($"\nКоментар: {Notes}");
            }
        }

        private string TranslateStatus(OrderStatus status)
        {
            return status switch
            {
                OrderStatus.Created => "Створено",
                OrderStatus.Processing => "В обробці",
                OrderStatus.Shipped => "Відправлено",
                OrderStatus.Delivered => "Доставлено",
                OrderStatus.Cancelled => "Скасовано", 
                _ => status.ToString()
            };
        }

        public static OrderStatistics GetStatistics(IEnumerable<Order> orders)
        {
            var orderList = orders.ToList();

            if (!orderList.Any())
            {
                return new OrderStatistics();
            }

            return new OrderStatistics
            {
                TotalOrders = orderList.Count,
                TotalRevenue = orderList.Sum(o => o.TotalAmount),
                AverageOrderValue = orderList.Average(o => o.TotalAmount),
                TotalDiscount = orderList.Sum(o => o.DiscountAmount),
                CompletedOrders = orderList.Count(o => o.Status == OrderStatus.Delivered),
                CancelledOrders = orderList.Count(o => o.Status == OrderStatus.Cancelled)
            };
        }

        public override string ToString()
        {
            return $"Замовлення {OrderNumber} від {OrderDate:dd.MM.yyyy} - {TotalAmount:C0} грн ({TranslateStatus(Status)})";
        }
    }

    [Serializable]
    public class OrderItem
    {
        public string ProductName {
            get; 
            set;
        }
        public decimal Price { 
            get; 
            set; 
        }
        public int Quantity {
            get;
            set; 
        }
        public decimal Total => Price * Quantity;

        public OrderItem() {}

        public OrderItem(Product product, int quantity)
        {
            ProductName = product.Name;
            Price = product.Price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{ProductName} x{Quantity} @ {Price:C0} = {Total:C0} грн";
        }
    }

    public class OrderStatistics
    {
        public int TotalOrders {
            get;
            set;
        }
        public decimal TotalRevenue { 
            get;
            set;
        }
        public decimal AverageOrderValue { 
            get;
            set; 
        }
        public decimal TotalDiscount { 
            get;
            set;
        }
        public int CompletedOrders { 
            get; 
            set; 
        }
        public int CancelledOrders { 
            get;
            set; 
        }

        public void Display()
        {
            Console.WriteLine("СТАТИСТИКА ЗАМОВЛЕНЬ");
            Console.WriteLine(new string('═', 60));
            Console.WriteLine($"Всього замовлень: {TotalOrders}");
            Console.WriteLine($"Загальний дохід: {TotalRevenue:C0} грн");
            Console.WriteLine($"Середній чек: {AverageOrderValue:C0} грн");
            Console.WriteLine($"Загальна знижка: {TotalDiscount:C0} грн");
            Console.WriteLine($"Виконано: {CompletedOrders}");
            Console.WriteLine($"Скасовано: {CancelledOrders}");
        }
    }

    public class OrderFactory
    {
        private readonly DiscountManager discountManager;

        public OrderFactory(DiscountManager discountManager)
        {
            discountManager = discountManager;
        }

        public Order CreateOrder(ShoppingCart cart, string notes = null)
        {
            var order = new Order(cart, discountManager)
            {
                Notes = notes
            };

            return order;
        }

        public Order CreateExpressOrder(Product product, int quantity)
        {
            var cart = new ShoppingCart();
            cart.AddItem(product, quantity);

            var order = new Order(cart, discountManager)
            {
                Notes = "Експрес-замовлення"
            };

            return order;
        }
    }
}