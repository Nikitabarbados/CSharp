using System;

namespace OnlineStore
{
    [Serializable]
    public abstract class Product
    {
        private static int nextId = 1;
        private decimal price;

        public int Id { 
            get;
            private set;
        }

        public string Name {
            get; 
            set;
        }

        public decimal Price
        {
            get => price;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Ціна не може бути від'ємною");

                price = value;
            }
        }

        protected Product(string name, decimal price)
        {
            Id = nextId++;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
        }

        public abstract string GetCategory();

        public abstract string GetDescription();

        public virtual decimal CalculateTotal(int quantity)
        {
            return Price * quantity;
        }

        public override string ToString()
        {
            return $"[{Id}] {Name} - {Price:C0} грн | {GetDescription()}";
        }

        public static bool operator == (Product left, Product right)
        {
            if (ReferenceEquals(left, right))
                return true;
            if (left is null || right is null)
                return false;
            return 
                left.Id == right.Id;
        }

        public static bool operator != (Product left, Product right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            return obj is Product product && Id == product.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    [Serializable]
    public class Electronics : Product
    {
        public string Brand {
            get;
            set;
        }

        public int WarrantyMonths { 
            get;
            set; 
        }

        public Electronics(string name, decimal price, string brand, int warrantyMonths) : base(name, price)
        {
            Brand = brand;
            WarrantyMonths = warrantyMonths;
        }

        public override string GetCategory()
        {
            return "Електроніка";
        }

        public override string GetDescription()
        {
            return
                $"Бренд: {Brand}, Гарантія: {WarrantyMonths} міс.";
        }
        public override decimal CalculateTotal(int quantity)
        {
            decimal baseTotal = base.CalculateTotal(quantity);

            if (quantity > 2)
            {
                decimal warrantyFee = Price * 0.05m * quantity;
                return baseTotal + warrantyFee;
            }
            return baseTotal;
        }
    }

    [Serializable]
    public class Clothing : Product
    {
        public string Size {
            get; 
            set; 
        }

        public string Material { 
            get;
            set; 
        }

        public Clothing(string name, decimal price, string size, string material) : base(name, price)
        {
            Size = size;
            Material = material;
        }

        public override string GetCategory()
        {
            return "Одяг";
        }

        public override string GetDescription()
        {
            return 
                $"Розмір: {Size}, Матеріал: {Material}";
        }
        public override decimal CalculateTotal(int quantity)
        {
            decimal baseTotal = base.CalculateTotal(quantity);

            if (quantity >= 3)
            {
                return baseTotal * 0.9m;
            }
            return baseTotal;
        }
    }

    [Serializable]
    public class Book : Product
    {
        public string Author {
            get;
            set;
        }

        public string ISBN { 
            get; 
            set;
        }

        public Book(string name, decimal price, string author, string isbn) : base(name, price)
        {
            Author = author;
            ISBN = isbn;
        }

        public override string GetCategory()
        {
            return "Книги";
        }

        public override string GetDescription()
        {
            return $"Автор: {Author}, ISBN: {ISBN}";
        }
    }
    public interface IDiscountable
    {
        decimal ApplyDiscount(decimal discountPercent);

        bool IsDiscountValid(decimal minimumPrice);
    }

    public static class ProductExtensions
    {
        public static decimal GetDiscountedPrice(this Product product, decimal discountPercent)
        {
            if (discountPercent < 0 || discountPercent > 100)
                throw new ArgumentException("Знижка повинна бути між 0 і 100");

            return product.Price * (1 - discountPercent / 100);
        }
    }
}