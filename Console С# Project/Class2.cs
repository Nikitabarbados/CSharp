using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore
{
    public interface IRepository<T> where T : Product
    {
        void Add(T item);
        void Remove(int id);
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Search(string query);
    }
    public class ProductRepository : IRepository<Product>
    {
        private readonly List<Product> products;

        public int Count => products.Count;

        public Product this[int id]
        {
            get
            {
                return 
                    products.FirstOrDefault(p => p.Id == id);
            }
        }

        public ProductRepository()
        {
            products = new List<Product>();
        }
        public void Add(Product item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            products.Add(item);
        }

        public void Remove(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                products.Remove(product);
            }
        }
        public Product GetById(int id)
        {
            return 
                products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return 
                products.AsReadOnly();
        }

        public IEnumerable<Product> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return GetAll();

            return 
                products.Where (p =>p.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 || p.GetCategory().IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }
        public IEnumerable<T> GetByCategory<T>() where T : Product
        {
            return 
                products.OfType<T>();
        }

        public IEnumerable<Product> GetTopExpensive(int count)
        {
            return 
                products.OrderByDescending(p => p.Price).Take(count);
        }

        public IEnumerable<Product> GetByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return products.Where(p => p.Price >= minPrice && p.Price <= maxPrice).OrderBy(p => p.Price);
        }
    }

    public class ProductGroup<T> where T : Product
    {
        private readonly List<T> items;

        public string GroupName { 
            get; 
            set; 
        }
        public int Count => items.Count;

        public ProductGroup(string groupName)
        {
            GroupName = groupName;
            items = new List<T>();
        }

        public void AddItem(T item)
        {
            items.Add(item);
        }

        public IEnumerable<T> GetItems()
        {
            return items.AsReadOnly();
        }

        public decimal GetTotalValue()
        {
            return items.Sum(item => item.Price);
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= items.Count)
                    throw new IndexOutOfRangeException("Індекс поза межами групи");
                return items[index];
            }
        }
    }
    public class ProductCollection : List<Product>
    {
        public event EventHandler<ProductEventArgs> CollectionChanged;

        public new void Add(Product item)
        {
            base.Add(item);
            OnCollectionChanged(new ProductEventArgs(item, "Added"));
        }
        public new bool Remove(Product item)
        {
            bool removed = base.Remove(item);
            if (removed)
            {
                OnCollectionChanged(new ProductEventArgs(item, "Removed"));
            }
            return removed;
        }
        protected virtual void OnCollectionChanged(ProductEventArgs e)
        {
            CollectionChanged?.Invoke(this, e);
        }

        public CollectionStatistics GetStatistics()
        {
            return new CollectionStatistics
            {
                TotalItems = this.Count,
                TotalValue = this.Sum(p => p.Price),
                AveragePrice = this.Any() ? this.Average(p => p.Price) : 0,
                MaxPrice = this.Any() ? this.Max(p => p.Price) : 0,
                MinPrice = this.Any() ? this.Min(p => p.Price) : 0
            };
        }
    }
    public class ProductEventArgs : EventArgs
    {
        public Product Product { 
            get; 
        }
        public string Action {
            get;
        }
        public DateTime Timestamp {
            get;
        }

        public ProductEventArgs(Product product, string action)
        {
            Product = product;
            Action = action;
            Timestamp = DateTime.Now;
        }
    }
    public struct CollectionStatistics
    {
        public int TotalItems {
            get;
            set;
        }
        public decimal TotalValue { 
            get;
            set; 
        }
        public decimal AveragePrice {
            get;
            set; 
        }
        public decimal MaxPrice { 
            get; 
            set;
        }
        public decimal MinPrice {
            get; 
            set; 
        }

        public override string ToString()
        {
            return $"Товарів: {TotalItems}, Загальна вартість: {TotalValue:C0}, " + $"Середня ціна: {AveragePrice:C0}, Min: {MinPrice:C0}, Max: {MaxPrice:C0}";
        }
    }
}