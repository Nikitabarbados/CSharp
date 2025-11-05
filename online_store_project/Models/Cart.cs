using System;
using System.Collections.Generic;

namespace OnlineStore.Models
{
    public class Cart
    {
        private List<(Product product, int qty)> items = new List<(Product, int)>();

        public (Product product, int qty) this[int index]
        {
            get => items[index];
        }

        public int Count => items.Count;

        public void AddProduct(Product p, int qty = 1)
        {
            if (p is null) 
                throw new ArgumentNullException(nameof(p));
            if (qty <= 0)
                throw new ArgumentException("Quantity must be > 0");

            if (p.Stock < qty)
            {
                Console.WriteLine($"Недостатньо товару {p.Name} на складі. Потрібно {qty}, доступно {p.Stock}.");
                return;
            }

            var existingIndex = items.FindIndex(x => x.product == p);

            if (existingIndex >= 0)
            {
                var e = items[existingIndex];
                items[existingIndex] = (e.product, e.qty + qty);
            }
            else
            {
                items.Add((p, qty));
            }

            p.Stock -= qty;
        }

        public static Cart operator +(Cart c, (Product p, int qty) add)
        {
            c.AddProduct(add.p, add.qty);
            return c;
        }

        public double Total() => items.Sum(x => x.product.Price * x.qty);

        public override string ToString()
        {
            return $"Кошик: {items.Count} позицій, загалом {Total()} грн";
        }

        public IEnumerable<(Product product, int qty)> Items => items.AsReadOnly();
    }
}
