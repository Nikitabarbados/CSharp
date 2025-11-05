using System;

namespace OnlineStore.Models
{
    public class Customer
    {
        public string Name {
            get;
            set;
        }
        public string Email {
            get; 
            set; 
        }
        public Cart Cart {
            get; 
            private set;
        }

        public Customer(string name, string email)
        {
            Name = name;
            Email = email;
            Cart = new Cart();
        }

        public void Buy(Product p)
        {
            Cart.AddProduct(p, 1);
            Console.WriteLine($"{Name} додав {p.Name} до кошика.");
        }

        public void Checkout()
        {
            Console.WriteLine($"{Name} оформив замовлення на суму {Cart.Total()} грн");
            Cart = new Cart();
        }
    }
}
