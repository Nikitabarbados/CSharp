using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore
{
    public delegate void CartEventHandler(object sender, CartEventArgs e);

    public class CartEventArgs : EventArgs
    {
        public Product Product {
            get;
            set;
        }
        public int Quantity { 
            get; 
            set; 
        }
        public DateTime EventTime {
            get; 
            set; 
        }

        public CartEventArgs(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            EventTime = DateTime.Now;
        }
    }

    [Serializable]
    public class CartItem
    {
        private int quantity;

        public Product Product {
            get;
            set;
        }

        public int Quantity
        {
            get => quantity;

            set
            {
                if (value < 0)
                    throw new ArgumentException("Кількість не може бути від'ємною");

                quantity = value;
            }
        }

        public decimal Total => Product.CalculateTotal(Quantity);

        public CartItem(Product product, int quantity)
        {
            Product = product ?? throw new ArgumentNullException(nameof(product));
            Quantity = quantity;
        }

        public override string ToString()
        {
            return 
                $"{Product.Name} x{Quantity} = {Total:C0} грн";
        }

        public static CartItem operator +(CartItem item, int quantity)
        {
            item.Quantity += quantity;
            return item;
        }

        public static CartItem operator - (CartItem item, int quantity)
        {
            item.Quantity = Math.Max(0, item.Quantity - quantity);
            return item;
        }
    }

    public class ShoppingCart
    {
        private readonly Dictionary<int, CartItem> items;

        public event CartEventHandler ItemAdded;

        public event CartEventHandler ItemRemoved;

        public event CartEventHandler ItemQuantityChanged;

        public int ItemCount => items.Count;

        public int TotalUnits => items.Values.Sum(item => item.Quantity);

        public CartItem this[int productId]
        {
            get
            {
                items.TryGetValue(productId, out CartItem item);
                return item;
            }
        }

        public ShoppingCart()
        {
            items = new Dictionary<int, CartItem>();
        }

        public void AddItem(Product product, int quantity)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (quantity <= 0)
                throw new ArgumentException("Кількість повинна бути більше нуля");

            if (items.ContainsKey(product.Id))
            {
                items[product.Id] += quantity;
                OnItemQuantityChanged(new CartEventArgs(product, quantity));
            }
            else
            {
                items[product.Id] = new CartItem(product, quantity);
                OnItemAdded(new CartEventArgs(product, quantity));
            }
        }

        public void RemoveItem(int productId)
        {
            if (items.TryGetValue(productId, out CartItem item))
            {
                items.Remove(productId);
                OnItemRemoved(new CartEventArgs(item.Product, item.Quantity));
            }
        }

        public void UpdateQuantity(int productId, int newQuantity)
        {
            if (items.TryGetValue(productId, out CartItem item))
            {
                if (newQuantity <= 0)
                {
                    RemoveItem(productId);
                }
                else
                {
                    item.Quantity = newQuantity;
                    OnItemQuantityChanged(new CartEventArgs(item.Product, newQuantity));
                }
            }
        }

        public void Clear()
        {
            items.Clear();
        }

        public IEnumerable<CartItem> GetItems()
        {
            return items.Values.ToList().AsReadOnly();
        }

        public decimal GetSubtotal()
        {
            return 
                items.Values.Select(item => item.Total).DefaultIfEmpty(0).Sum();
        }

        public void DisplayItems()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Кошик порожній");
                return;
            }

            int index = 1;
            foreach (var item in items.Values)
            {
                Console.WriteLine($"{index}. {item}");
                index++;
            }

            Console.WriteLine($"\nЗагальна кількість: {TotalUnits} од.");
        }

        public bool Contains(int productId)
        {
            return items.ContainsKey(productId);
        }

        public IEnumerable<CartItem> GetItemsByCategory<T>() where T : Product
        {
            return items.Values.Where(item => item.Product is T);
        }

        protected virtual void OnItemAdded(CartEventArgs e)
        {
            ItemAdded?.Invoke(this, e);
        }

        protected virtual void OnItemRemoved(CartEventArgs e)
        {
            ItemRemoved?.Invoke(this, e);
        }

        protected virtual void OnItemQuantityChanged(CartEventArgs e)
        {
            ItemQuantityChanged?.Invoke(this, e);
        }

        public static ShoppingCart operator + (ShoppingCart cart, Product product)
        {
            cart.AddItem(product, 1);
            return cart;
        }

        public CartItem GetMostExpensiveItem()
        {
            return
                items.Values.OrderByDescending(item => item.Product.Price).FirstOrDefault();
        }

        public CartStatistics GetStatistics()
        {
            var itemList = items.Values.ToList();

            return new CartStatistics
            {
                UniqueItems = itemList.Count,
                TotalUnits = TotalUnits,
                Subtotal = GetSubtotal(),
                AverageItemPrice = itemList.Any() ? itemList.Average(i => i.Product.Price) : 0,
                MostExpensiveItem = GetMostExpensiveItem()?.Product.Name ?? "Немає"
            };
        }
    }

    public class CartStatistics
    {
        public int UniqueItems {
            get; 
            set; 
        }
        public int TotalUnits {
            get; 
            set; 
        }
        public decimal Subtotal { 
            get;
            set;
        }
        public decimal AverageItemPrice { 
            get; 
            set; 
        }
        public string MostExpensiveItem {
            get;
            set; 
        }

        public override string ToString()
        {
            return 
                $"Унікальних товарів: {UniqueItems}, " + $"Всього одиниць: {TotalUnits}, " + $"Сума: {Subtotal:C0} грн, " + $"Середня ціна: {AverageItemPrice:C0} грн, " + $"Найдорожчий: {MostExpensiveItem}";
        }
    }
}