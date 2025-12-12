# 🛒 Інтернет-магазин ElectroShop

## 📖 Опис проєкту

Консольний додаток інтернет-магазину, розроблений на платформі .NET з використанням мови C#. Проєкт демонструє всі ключові концепції об'єктно-орієнтованого програмування та функціонал платформи .NET.

## ✨ Основні можливості

- 📦 Управління каталогом товарів (електроніка, одяг, книги)
- 🛒 Функціональний кошик покупок
- 💰 Система знижок (процентні, фіксовані, промо-коди)
- 📋 Оформлення та збереження замовлень
- 🔍 Пошук та фільтрація товарів
- 📊 Статистика продажів
- 💾 Збереження даних у JSON форматі

## 🎯 Чому обрана ця тема

Інтернет-магазин - це практична задача, яка:
- Відображає реальну бізнес-логіку
- Дозволяє продемонструвати всі аспекти ООП
- Має чітку структуру та зрозумілу функціональність
- Може бути легко розширена новими можливостями

## 🏗️ Архітектура проєкту

### Структура класів

```
OnlineStore/
├── Program.cs                 # Головний файл програми
├── Models.cs                  # Моделі товарів
├── ProductRepository.cs       # Репозиторій для роботи з даними
├── ShoppingCart.cs           # Кошик покупок
├── DiscountSystem.cs         # Система знижок
└── Order.cs                  # Система замовлень
```

### UML діаграма класів

```
┌─────────────────┐
│    Product      │ (Abstract)
├─────────────────┤
│ + Id            │
│ + Name          │
│ + Price         │
├─────────────────┤
│ + GetCategory() │
│ + GetDescription()│
└────────┬────────┘
         │
    ┌────┴─────┬─────────┐
    │          │         │
┌───▼──┐  ┌───▼──┐  ┌──▼────┐
│Electronics│  │Clothing│  │  Book  │
└──────┘  └──────┘  └───────┘
```

## 📚 Реалізовані концепції C# та .NET

### 1. Об'єктно-орієнтоване програмування (ООП)

#### Інкапсуляція
```csharp
private decimal _price;

public decimal Price
{
    get => _price;
    set
    {
        if (value < 0)
            throw new ArgumentException("Ціна не може бути від'ємною");
        _price = value;
    }
}
```

#### Успадкування
```csharp
public abstract class Product { }
public class Electronics : Product { }
public class Clothing : Product { }
public class Book : Product { }
```

#### Поліморфізм
```csharp
public abstract string GetCategory();
public abstract string GetDescription();
public virtual decimal CalculateTotal(int quantity);
```

### 2. Властивості (Properties)
```csharp
public int Id { get; private set; }
public string Name { get; set; }
public decimal Total => Price * Quantity; // Обчислювана властивість
```

### 3. Індексатори
```csharp
public Product this[int id]
{
    get => _products.FirstOrDefault(p => p.Id == id);
}

public CartItem this[int productId]
{
    get => _items.TryGetValue(productId, out CartItem item) ? item : null;
}
```

### 4. Перевантаження операторів
```csharp
public static bool operator ==(Product left, Product right)
{
    if (ReferenceEquals(left, right)) return true;
    if (left is null || right is null) return false;
    return left.Id == right.Id;
}

public static CartItem operator +(CartItem item, int quantity)
{
    item.Quantity += quantity;
    return item;
}
```

### 5. Делегати та події
```csharp
// Делегат
public delegate void CartEventHandler(object sender, CartEventArgs e);

// Події
public event CartEventHandler ItemAdded;
public event CartEventHandler ItemRemoved;
public event CartEventHandler ItemQuantityChanged;

// Виклик події
protected virtual void OnItemAdded(CartEventArgs e)
{
    ItemAdded?.Invoke(this, e);
}
```

### 6. Generics та колекції
```csharp
// Generic інтерфейс
public interface IRepository<T> where T : Product
{
    void Add(T item);
    IEnumerable<T> GetAll();
}

// Колекції
private readonly List<Product> _products;
private readonly Dictionary<int, CartItem> _items;

// Generic метод
public IEnumerable<T> GetByCategory<T>() where T : Product
{
    return _products.OfType<T>();
}
```

### 7. LINQ
```csharp
// Фільтрація
var results = _repository.Search(query);

// Групування
var grouped = products.GroupBy(p => p.GetType().Name);

// Агрегація
decimal total = _items.Values.Sum(item => item.Total);
var average = products.Average(p => p.Price);
var max = products.Max(p => p.Price);

// Сортування
var topExpensive = _products
    .OrderByDescending(p => p.Price)
    .Take(count);
```

### 8. Файлова система та серіалізація
```csharp
// Серіалізація в JSON
var options = new JsonSerializerOptions
{
    WriteIndented = true,
    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
};

string jsonString = JsonSerializer.Serialize(this, options);
File.WriteAllText(fileName, jsonString);

// Десеріалізація
string jsonString = File.ReadAllText(fileName);
return JsonSerializer.Deserialize<Order>(jsonString);

// Робота з директоріями
if (!Directory.Exists(OrdersDirectory))
{
    Directory.CreateDirectory(OrdersDirectory);
}
```

### 9. Патерни проєктування

#### Repository Pattern
```csharp
public interface IRepository<T> where T : Product
{
    void Add(T item);
    void Remove(int id);
    T GetById(int id);
    IEnumerable<T> GetAll();
}
```

#### Strategy Pattern (Система знижок)
```csharp
public interface IDiscount
{
    decimal Calculate(decimal amount);
    bool IsApplicable(decimal amount);
}

public class PercentageDiscount : IDiscount { }
public class FixedDiscount : IDiscount { }
```

#### Observer Pattern (Події)
```csharp
public event CartEventHandler ItemAdded;
_cart.ItemAdded += OnItemAdded;
```

#### Factory Pattern
```csharp
public class OrderFactory
{
    public Order CreateOrder(ShoppingCart cart, string notes = null)
    {
        return new Order(cart, _discountManager) { Notes = notes };
    }
}
```

#### Template Method Pattern
```csharp
public abstract class Discount
{
    public abstract decimal Calculate(decimal amount);
    public virtual bool IsApplicable(decimal amount)
    {
        return amount >= MinimumAmount;
    }
}
```

### 10. Принципи SOLID

#### Single Responsibility Principle (SRP)
- `Product` - відповідає лише за представлення товару
- `ShoppingCart` - тільки за управління кошиком
- `DiscountManager` - тільки за знижки
- `ProductRepository` - тільки за зберігання даних

#### Open/Closed Principle (OCP)
- Система знижок: можна додавати нові типи знижок без зміни існуючого коду
```csharp
public class NewDiscount : Discount { }
```

#### Liskov Substitution Principle (LSP)
- Всі похідні класи `Product` можуть використовуватися замість базового класу
```csharp
Product product = new Electronics(...);
Product product = new Book(...);
```

#### Interface Segregation Principle (ISP)
- `IRepository<T>` - мінімальний інтерфейс для репозиторію
- `IDiscount` - тільки необхідні методи для знижок

#### Dependency Inversion Principle (DIP)
- Класи залежать від абстракцій (`IRepository`, `IDiscount`), а не від конкретних реалізацій

## 🚀 Як запустити проєкт

### Вимоги
- .NET 6.0 або вище
- Visual Studio 2022 / VS Code / Rider

### Кроки запуску

1. Створіть новий консольний проєкт:
```bash
dotnet new console -n OnlineStore
cd OnlineStore
```

2. Скопіюйте всі файли проєкту

3. Запустіть програму:
```bash
dotnet run
```

або

Відкрийте рішення у Visual Studio та натисніть F5

## 💡 Труднощі та їх вирішення

### 1. Труднощі з серіалізацією
**Проблема:** JSON серіалізація не працювала з абстрактними класами

**Рішення:** Використали атрибут `[Serializable]` та збереження конкретних даних замість посилань на об'єкти

### 2. Управління подіями
**Проблема:** Події спрацьовували декілька разів

**Рішення:** Правильна підписка/відписка на події, використання оператора `?.` для перевірки null

### 3. Робота з LINQ
**Проблема:** Складність комплексних запитів

**Рішення:** Розбиття складних запитів на прості ланцюжки методів

### 4. Індексатори та колекції
**Проблема:** Обробка відсутніх елементів

**Рішення:** Використання `TryGetValue`, `FirstOrDefault` та обробка null

## 📈 Результати

### Що вийшло в результаті

✅ Повнофункціональний інтернет-магазин  
✅ Всі необхідні концепції реалізовані  
✅ Зрозумілий та зручний інтерфейс  
✅ Збереження даних працює коректно  
✅ Код добре структурований та задокументований

### Основні класи та методи

#### Program.cs
- `Main()` - точка входу
- `Run()` - головний цикл програми
- `ShowAllProducts()` - відображення каталогу
- `AddProductToCart()` - додавання до кошика
- `Checkout()` - оформлення замовлення

#### Models.cs
- `Product` - базовий клас товару
- `Electronics`, `Clothing`, `Book` - типи товарів
- `GetCategory()`, `GetDescription()` - інформація про товар
- `CalculateTotal()` - розрахунок вартості

#### ProductRepository.cs
- `Add()`, `Remove()`, `GetById()` - CRUD операції
- `Search()` - пошук товарів
- `GetByCategory<T>()` - фільтрація за категорією
- Індексатор `this[int id]`

#### ShoppingCart.cs
- `AddItem()`, `RemoveItem()` - управління товарами
- `GetSubtotal()` - розрахунок суми
- Події: `ItemAdded`, `ItemRemoved`, `ItemQuantityChanged`
- Індексатор для доступу до товарів

#### DiscountSystem.cs
- `IDiscount` - інтерфейс знижок
- `PercentageDiscount`, `FixedDiscount` - типи знижок
- `DiscountManager.CalculateDiscount()` - розрахунок найкращої знижки

#### Order.cs
- `SaveToFile()` - серіалізація замовлення
- `LoadFromFile()`, `LoadFromFiles()` - завантаження
- `DisplayDetails()` - відображення деталей
- `GetStatistics()` - статистика замовлень

## 📝 Висновки

Проєкт успішно демонструє:
- Глибоке розуміння ООП
- Вміння використовувати advanced функції C#
- Застосування патернів проєктування
- Дотримання принципів SOLID
- Роботу з файлами та серіалізацією
- Використання LINQ для обробки даних

## 🔮 Можливі покращення

- Додати базу даних (Entity Framework)
- Реалізувати графічний інтерфейс (WPF/WinForms)
- Додати автентифікацію користувачів
- Інтегрувати платіжну систему
- Додати тести (Unit Tests)
- Реалізувати багатопоточність

## 👨‍💻 Автор

Проєкт виконано в рамках дисципліни "Основи платформи .NET"

---

**Дата створення:** 2024  
**Версія .NET:** 6.0+  
**Ліцензія:** MIT
