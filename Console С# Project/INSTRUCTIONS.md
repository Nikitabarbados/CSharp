# 📖 Інструкції по використанню проєкту

## 🚀 Швидкий старт

### Крок 1: Створення проєкту

1. Відкрийте Visual Studio 2022
2. Виберіть "Create a new project"
3. Оберіть "Console App" (C#)
4. Назва проєкту: `OnlineStore`
5. Framework: `.NET 6.0` або вище

### Крок 2: Структура файлів

Створіть наступні файли в проєкті:

```
OnlineStore/
├── Program.cs
├── Models.cs
├── ProductRepository.cs
├── ShoppingCart.cs
├── DiscountSystem.cs
└── Order.cs
```

### Крок 3: Копіювання коду

1. Скопіюйте код з кожного артефакту в відповідний файл
2. Всі класи повинні бути в namespace `OnlineStore`
3. Переконайтеся, що всі using директиви присутні

### Крок 4: Додавання іконки (опціонально)

1. Додайте файл `app.ico` до проєкту
2. В Properties проєкту встановіть іконку

### Крок 5: Компіляція та запуск

```bash
# Через термінал
dotnet build
dotnet run

# Або в Visual Studio
F5 (Start Debugging)
Ctrl+F5 (Start Without Debugging)
```

## 📋 Вимоги до системи

- **ОС:** Windows 10/11, macOS, Linux
- **.NET:** Version 6.0 або вище
- **RAM:** Мінімум 4GB
- **Диск:** 100MB вільного місця
- **IDE:** Visual Studio 2022 / VS Code / Rider

## 🎮 Як користуватися програмою

### Головне меню

При запуску програми ви побачите меню:

```
1️⃣  Показати всі товари
2️⃣  Пошук товарів
3️⃣  Додати товар до кошика
4️⃣  Переглянути кошик
5️⃣  Видалити з кошика
6️⃣  Оформити замовлення
7️⃣  Статистика
0️⃣  Вихід
```

### Сценарії використання

#### 🛍️ Сценарій 1: Покупка товару

1. Виберіть `1` - Показати всі товари
2. Запам'ятайте ID потрібного товару
3. Виберіть `3` - Додати товар до кошика
4. Введіть ID товару
5. Введіть кількість
6. Виберіть `4` - Переглянути кошик
7. Виберіть `6` - Оформити замовлення
8. Підтвердіть замовлення (Y)

#### 🔍 Сценарій 2: Пошук товару

1. Виберіть `2` - Пошук товарів
2. Введіть назву товару (частину назви)
3. Перегляньте результати
4. При необхідності додайте до кошика

#### 📊 Сценарій 3: Перегляд статистики

1. Виберіть `7` - Статистика
2. Переглядайте інформацію про:
   - Кількість товарів
   - Середні ціни
   - Статистику по категоріях
   - Історію замовлень

## 🔧 Налаштування

### Зміна початкових даних

В файлі `Program.cs`, метод `InitializeStore()`:

```csharp
private void InitializeStore()
{
    // Додайте свої товари
    _repository.Add(new Electronics("Назва", ціна, "Бренд", гарантія));
    _repository.Add(new Clothing("Назва", ціна, "Розмір", "Матеріал"));
    _repository.Add(new Book("Назва", ціна, "Автор", "ISBN"));
    
    // Додайте знижки
    _discountManager.AddDiscount(new PercentageDiscount(10, 10000));
}
```

### Зміна шляху збереження

В файлі `Order.cs`:

```csharp
private static readonly string OrdersDirectory = "Orders"; // Змініть шлях
```

## 📝 Генерація документації

### XML Documentation

1. В Properties проєкту увімкніть "Generate XML documentation file"
2. Перебудуйте проєкт
3. XML файл буде створено в папці bin

### HTML Documentation (за допомогою Doxygen)

1. Встановіть Doxygen: https://www.doxygen.nl/
2. Створіть файл Doxyfile:

```bash
doxygen -g
```

3. Відредагуйте Doxyfile:

```
PROJECT_NAME = "OnlineStore"
INPUT = .
RECURSIVE = YES
GENERATE_HTML = YES
OUTPUT_DIRECTORY = docs
```

4. Згенеруйте документацію:

```bash
doxygen Doxyfile
```

5. Відкрийте `docs/html/index.html`

## 🐛 Виправлення проблем

### Проблема: Програма не запускається

**Рішення:**
- Перевірте версію .NET: `dotnet --version`
- Перебудуйте проєкт: `dotnet clean && dotnet build`
- Перевірте наявність всіх файлів

### Проблема: Помилка серіалізації

**Рішення:**
- Перевірте права доступу до папки Orders
- Вручну створіть папку Orders
- Перевірте валідність JSON файлів

### Проблема: NullReferenceException

**Рішення:**
- Переконайтеся, що InitializeStore() викликається
- Перевірте наявність товарів у репозиторії
- Використовуйте null-conditional оператори

### Проблема: Encoding issues (кирилиця)

**Рішення:**
В `Main()` додайте:

```csharp
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;
```

## 📊 Тестування

### Ручне тестування

#### Тест 1: Додавання товару
- ✅ Товар додається до кошика
- ✅ Кількість коректна
- ✅ Ціна відображається правильно

#### Тест 2: Знижки
- ✅ Знижка застосовується при перевищенні мінімуму
- ✅ Обирається найбільша знижка
- ✅ Розрахунки коректні

#### Тест 3: Серіалізація
- ✅ Замовлення зберігається
- ✅ Замовлення завантажується
- ✅ Дані не пошкоджені

#### Тест 4: Обробка помилок
- ✅ Невірний ID товару
- ✅ Від'ємна кількість
- ✅ Порожній кошик

### Unit тести (приклад)

```csharp
[TestClass]
public class ProductTests
{
    [TestMethod]
    public void Product_Price_CannotBeNegative()
    {
        // Arrange & Act & Assert
        Assert.ThrowsException<ArgumentException>(() => 
            new Electronics("Test", -100, "Brand", 12)
        );
    }
    
    [TestMethod]
    public void ShoppingCart_AddItem_IncreasesCount()
    {
        // Arrange
        var cart = new ShoppingCart();
        var product = new Electronics("Laptop", 1000, "Dell", 24);
        
        // Act
        cart.AddItem(product, 1);
        
        // Assert
        Assert.AreEqual(1, cart.ItemCount);
    }
}
```

## 📚 Додаткові ресурси

### Корисні посилання

- [Microsoft C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [LINQ Tutorial](https://www.tutorialsteacher.com/linq)
- [Design Patterns in C#](https://refactoring.guru/design-patterns/csharp)
- [SOLID Principles](https://www.digitalocean.com/community/conceptual_articles/s-o-l-i-d-the-first-five-principles-of-object-oriented-design)

### Рекомендовані книги

- "C# 10 in a Nutshell" - Joseph Albahari
- "Clean Code" - Robert C. Martin
- "Design Patterns" - Gang of Four
- "Pro C# 10" - Andrew Troelsen

## 🎓 Навчальні матеріали

### Основні концепції

1. **ООП в C#**
   - Інкапсуляція, Успадкування, Поліморфізм
   - Абстрактні класи та інтерфейси

2. **LINQ**
   - Query syntax vs Method syntax
   - Aggregate functions
   - Grouping and Joining

3. **Серіалізація**
   - JSON.NET
   - Binary Serialization
   - XML Serialization

4. **Патерни**
   - Creational: Factory, Singleton
   - Structural: Repository, Composite
   - Behavioral: Observer, Strategy

### Практичні завдання

#### Завдання 1: Додати новий тип товару
Створіть клас `Food` з властивостями:
- ExpirationDate
- Calories
- IsOrganic

#### Завдання 2: Реалізувати нову знижку
Створіть `SeasonalDiscount` з:
- Період дії (StartDate, EndDate)
- Різні відсотки для різних категорій

#### Завдання 3: Додати пошук
Реалізуйте пошук за:
- Ціновим діапазоном
- Категорією
- Брендом

## 💡 Поради

### Best Practices

✅ **DO:**
- Використовуйте осмислені назви
- Пишіть XML коментарі
- Обробляйте виключення
- Застосовуйте SOLID принципи
- Використовуйте async/await для I/O операцій

❌ **DON'T:**
- Не ігноруйте warnings
- Не використовуйте magic numbers
- Не дублюйте код
- Не забувайте про null checks
- Не робіть надто довгі методи

### Performance Tips

- Використовуйте `StringBuilder` для конкатенації рядків
- Кешуйте результати LINQ запитів
- Використовуйте `AsReadOnly()` для колекцій
- Застосовуйте lazy loading де можливо

## 🔐 Безпека

### Рекомендації

- Валідуйте всі user inputs
- Використовуйте try-catch блоки
- Обмежуйте доступ до файлів
- Не зберігайте конфіденційні дані в plain text

## 📞 Підтримка

### Як отримати допомогу

1. Перечитайте документацію
2. Перевірте FAQ вище
3. Подивіться приклади в коді
4. Зверніться до викладача
5. Використайте Stack Overflow

Цей проєкт - відмінна можливість продемонструвати ваші знання C# та .NET. 

**Зроблено з ❤️ для навчання .NET**
