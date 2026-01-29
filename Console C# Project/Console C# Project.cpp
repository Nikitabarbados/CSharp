// OnlineStore.csproj - This is the main project file, but since this is text-based, I'll provide all source files below.
// Assume this is a Windows Forms Application project in Visual Studio.
// Target framework: .NET 8.0 or similar.
// Add references: System.Xml, System.Text.Json for serialization.
// For icon: You need to add an icon file (e.g., store.ico) to the project and set it in Form properties.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml.Serialization;

// Namespace for the entire application
namespace OnlineStore
{
    // Delegate for event handling, e.g., when a product is added to cart
    public delegate void ProductAddedHandler(Product product);

    /// <summary>
    /// Interface for products, ensuring polymorphism.
    /// </summary>
    public interface IProduct
    {
        string Name { get; set; }
        decimal Price { get; set; }
        string GetDescription();
    }

        /// <summary>
        /// Base abstract class for products, demonstrating inheritance and encapsulation.
        /// </summary>
        [Serializable] // For serialization
        public abstract class Product : IProduct
    {
        private string name;
        private decimal price;

        /// <summary>
        /// Product name property with encapsulation.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

            /// <summary>
            /// Product price property with validation.
            /// </summary>
            public decimal Price
        {
            get { return price; }
            set
            {
                if (value < 0) throw new ArgumentException("Price cannot be negative.");
                price = value;
            }
        }

            /// <summary>
            /// Constructor for Product.
            /// </summary>
            /// <param name="name">Product name.</param>
            /// <param name="price">Product price.</param>
            protected Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        /// <summary>
        /// Abstract method for description, to be overridden (polymorphism).
        /// </summary>
        public abstract string GetDescription();

        // Operator overloading: + to combine prices (e.g., for bundles)
        public static decimal operator +(Product p1, Product p2)
        {
            return p1.Price + p2.Price;
        }
    }

    /// <summary>
    /// Derived class for Electronics, inheriting from Product.
    /// </summary>
    [Serializable]
    public class Electronics : Product
    {
        public string Brand{ get; set; }

            /// <summary>
            /// Constructor for Electronics.
            /// </summary>
            public Electronics(string name, decimal price, string brand) : base(name, price)
        {
            Brand = brand;
        }

        public override string GetDescription()
        {
            return $"{Name} by {Brand} - ${Price}";
        }
    }

    /// <summary>
    /// Derived class for Clothing, inheriting from Product.
    /// </summary>
    [Serializable]
    public class Clothing : Product
    {
        public string Size{ get; set; }

            /// <summary>
            /// Constructor for Clothing.
            /// </summary>
            public Clothing(string name, decimal price, string size) : base(name, price)
        {
            Size = size;
        }

        public override string GetDescription()
        {
            return $"{Name} (Size {Size}) - ${Price}";
        }
    }

    /// <summary>
    /// Generic collection class for products, using generics and collections.
    /// Implements indexer.
    /// </summary>
    /// <typeparam name="T">Type of product, must implement IProduct.</typeparam>
    [Serializable]
    public class ProductCollection<T> where T : IProduct
    {
        private List<T> products = new List<T>();

    /// <summary>
    /// Adds a product to the collection.
    /// </summary>
    /// <param name="product">Product to add.</param>
    public void Add(T product)
    {
        products.Add(product);
    }

    /// <summary>
    /// Indexer for accessing products by index.
    /// </summary>
    /// <param name="index">Index.</param>
    /// <returns>Product at index.</returns>
    public T this[int index]
    {
        get { return products[index]; }
        set { products[index] = value; }
    }

        /// <summary>
        /// Gets the count of products.
        /// </summary>
        public int Count = > products.Count;

        /// <summary>
        /// LINQ example: Get products above a certain price.
        /// </summary>
        /// <param name="minPrice">Minimum price.</param>
        /// <returns>List of products.</returns>
        public IEnumerable<T> GetExpensiveProducts(decimal minPrice)
        {
            return products.Where(p = > p.Price > minPrice);
        }
    }

        /// <summary>
        /// Singleton pattern for StoreManager, following SOLID (Single Responsibility).
        /// </summary>
        [Serializable]
    public class StoreManager
    {
        private static StoreManager instance;
        private static readonly object lockObject = new object();

        public ProductCollection<IProduct> Products{ get; } = new ProductCollection<IProduct>();
        public ProductCollection<IProduct> Cart{ get; } = new ProductCollection<IProduct>();

        // Event using delegate
        public event ProductAddedHandler ProductAddedToCart;

        private StoreManager() {}

        /// <summary>
        /// Gets the singleton instance.
        /// </summary>
        public static StoreManager Instance
        {
            get
            {
                lock(lockObject)
                {
                    if (instance == null)
                    {
                        instance = new StoreManager();
                    }
                    return instance;
                }
            }
        }

            /// <summary>
            /// Adds product to cart and raises event.
            /// </summary>
            /// <param name="product">Product to add.</param>
            public void AddToCart(IProduct product)
        {
            Cart.Add(product);
            ProductAddedToCart ? .Invoke((Product)product); // Raise event
        }

        /// <summary>
        /// Saves data to file using JSON serialization.
        /// </summary>
        public void SaveToFile(string filePath)
        {
            var data = new{ Products = Products, Cart = Cart };
            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// Loads data from file using JSON deserialization.
        /// </summary>
        public void LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var data = JsonSerializer.Deserialize<Dictionary<string, ProductCollection<IProduct>>>(json);
                // Note: Deserialization might need custom handling for derived types, simplified here.
            }
        }
    }

    /// <summary>
    /// Main form for the application.
    /// </summary>
    public class MainForm : Form
    {
        private ListBox productListBox;
        private ListBox cartListBox;
        private Button addToCartButton;
        private Button saveButton;
        private Button loadButton;
        private Label totalLabel;

        public MainForm()
        {
            Text = "Online Store"; // Title
            // Set Icon: In Visual Studio, set form.Icon to your .ico file.

            productListBox = new ListBox{ Left = 10, Top = 10, Width = 200, Height = 200 };
            cartListBox = new ListBox{ Left = 220, Top = 10, Width = 200, Height = 200 };
            addToCartButton = new Button{ Text = "Add to Cart", Left = 10, Top = 220 };
            saveButton = new Button{ Text = "Save", Left = 120, Top = 220 };
            loadButton = new Button{ Text = "Load", Left = 230, Top = 220 };
            totalLabel = new Label{ Text = "Total: $0", Left = 340, Top = 220 };

            Controls.Add(productListBox);
            Controls.Add(cartListBox);
            Controls.Add(addToCartButton);
            Controls.Add(saveButton);
            Controls.Add(loadButton);
            Controls.Add(totalLabel);

            // Initialize data (thoughtful data)
            var manager = StoreManager.Instance;
            manager.Products.Add(new Electronics("Laptop", 999.99m, "Dell"));
            manager.Products.Add(new Clothing("T-Shirt", 19.99m, "M"));
            manager.Products.Add(new Electronics("Phone", 599.99m, "Apple"));

            // Populate list
            foreach(var p in manager.Products)
            {
                productListBox.Items.Add(p.GetDescription());
            }

            // Event handler
            addToCartButton.Click += (s, e) = >
            {
                if (productListBox.SelectedIndex >= 0)
                {
                    var product = manager.Products[productListBox.SelectedIndex];
                    manager.AddToCart(product);
                }
            };

            // Subscribe to event
            manager.ProductAddedToCart += (product) = >
            {
                cartListBox.Items.Add(product.GetDescription());
                UpdateTotal();
            };

            saveButton.Click += (s, e) = > manager.SaveToFile("store.json");
            loadButton.Click += (s, e) = > { manager.LoadFromFile("store.json"); RefreshLists(); };
        }

        private void UpdateTotal()
        {
            var manager = StoreManager.Instance;
            decimal total = 0;
            for (int i = 0; i < manager.Cart.Count; i++)
            {
                total += manager.Cart[i].Price; // Using indexer
            }
            totalLabel.Text = $"Total: ${total}";
        }

        private void RefreshLists()
        {
            productListBox.Items.Clear();
            cartListBox.Items.Clear();
            var manager = StoreManager.Instance;
            foreach(var p in manager.Products)
            {
                productListBox.Items.Add(p.GetDescription());
            }
            foreach(var p in manager.Cart)
            {
                cartListBox.Items.Add(p.GetDescription());
            }
            UpdateTotal();
        }
    }

    /// <summary>
    /// Program entry point.
    /// </summary>
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}"); // Handle exceptions
            }
        }
    }
}