using System;

namespace OnlineStore.Models
{
    public class Product
    {
        public string Name { 
            get;
            set;
        }
        public double Price { 
            get; 
            private set;
        }
        public int Stock { 
            get;
            set;
        }

        public delegate void PriceChangedHandler(Product product, double oldPrice, double newPrice);
        public event PriceChangedHandler? PriceChanged;

        public Product(string name, double price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }

        public void ChangePrice(double newPrice)
        {
            var old = Price;
            Price = newPrice;
            PriceChanged?.Invoke(this, old, newPrice);
        }

        public override string ToString() => $"{Name} - {Price} грн (в наявності: {Stock})";

        public static bool operator ==(Product? a, Product? b)
        {
            if (ReferenceEquals(a, b)) 
                return true;
            if (a is null || b is null)
                return false;

            return a.Name == b.Name && Math.Abs(a.Price - b.Price) < 0.0001;
        }

        public static bool operator != (Product? a, Product? b) => !(a == b);

        public override bool Equals(object? obj)
        {
            return obj is Product p && this == p;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Price);
        }
    }
}
