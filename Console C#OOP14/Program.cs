using System.Text;
using System.Text.RegularExpressions;
// ------------------------------------------------------------------------------------------------------
// Instagram v.0.01

//class Program
//{
//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        var Alex = new User() { Name = "Олександр" };
//        var Olha = new InstagramFollower();
//        var Mykola = new InstagramFollower();

//        Alex.AddSubscriber(Olha);
//        Alex.AddSubscriber(Mykola);

//        Alex.MakeStory("Красивий захід сонця!");
//        Alex.MakeReel("Веселий танець!");
//        Alex.PostPhoto("Нове фото профілю!");
//    }
//}

//// підписник
//interface ISubscriber
//{
//    void Like(string content);
//    void Comment(string content);
//    void Message(string content);
//    void Ignore(string content);
//    void Unsubscribe();
//}

//// видавець
//abstract class Publisher
//{
//    protected List<ISubscriber> subscribers = new List<ISubscriber>();

//    public void AddSubscriber(ISubscriber subscriber)
//    {
//        subscribers.Add(subscriber);
//    }

//    public void RemoveSubscriber(ISubscriber subscriber)
//    {
//        subscribers.Remove(subscriber);
//    }

//    public void NotifySubscribers(string content)
//    {
//        var random = new Random(); // рандомна дія підписника
//        // насправді, тут би вистачило викликати просто subscriber.Update(content);,
//        // і хай би підписник сам вирішував, що робити, але поки для прикладу я зробив різні дії
//        foreach (var subscriber in subscribers)
//        {
//            int randomAction = random.Next(5);
//            if (randomAction == 0) subscriber.Like(content);
//            else if (randomAction == 1) subscriber.Comment(content);
//            else if (randomAction == 2) subscriber.Message(content);
//            else if (randomAction == 3) subscriber.Ignore(content);
//            else subscriber.Unsubscribe();
//        }
//    }
//}

//class User : Publisher
//{
//    public string? Name { get; set; }
//    public void MakeStory(string content)
//    {
//        Console.WriteLine(Name + " створив сторіс: " + content);
//        NotifySubscribers(content);
//    }

//    public void MakeReel(string content)
//    {
//        Console.WriteLine(Name + " виклав рілс: " + content);
//        NotifySubscribers(content);
//    }

//    public void PostPhoto(string content)
//    {
//        Console.WriteLine(Name + " користувач опублікував фото: " + content);
//        NotifySubscribers(content);
//    }
//}

//class InstagramFollower : ISubscriber
//{
//    public void Like(string content)
//    {
//        Console.WriteLine("Лайк!");
//    }

//    public void Comment(string content)
//    {
//        Console.WriteLine("Коментар!");
//    }

//    public void Message(string content)
//    {
//        Console.WriteLine("Надіслано повідомлення!");
//    }

//    public void Ignore(string content)
//    {
//        Console.WriteLine("Проігноровано");
//    }

//    public void Unsubscribe()
//    {
//        Console.WriteLine("Відписався від користувача");
//        // технічно, тут треба було б якось передати посилання на юзера, від якого відписуємося,
//        // але для простоти прикладу я це поки пропустив
//    }
//}
// ------------------------------------------------------------------------------------------------------
// ========================================================================================================
// ------------------------------------------------------------------------------------------------------

// Instagran v.0.02

//class Program
//{
//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        var andriy = new User();

//        var petro = new InstagramFollower();
//        var maria = new InstagramFollower();

//        // тепер підписники можуть підписуватися на видавців, а не видавець схвалює підписників
//        petro.AddPublisher(andriy);
//        maria.AddPublisher(andriy);

//        andriy.MakeStory("Красивий захід сонця!");
//        andriy.MakeReel("Веселий танець!");
//        andriy.PostPhoto("Нове фото профілю!");
//    }
//}

//// інтерфейс підписника
//interface ISubscriber
//{
//    void Like(string content);
//    void Comment(string content);
//    void Message(string content);
//    void Ignore(string content);
//    void Unsubscribe(Publisher publisher);
//}

//// абстрактний клас видавця
//abstract class Publisher
//{
//    protected List<ISubscriber> subscribers = new List<ISubscriber>();

//    public void AddSubscriber(ISubscriber subscriber)
//    {
//        if (!subscribers.Contains(subscriber)) // уникаємо дублювання підписників
//        {
//            subscribers.Add(subscriber);
//        }
//    }

//    public void RemoveSubscriber(ISubscriber subscriber)
//    {
//        subscribers.Remove(subscriber);
//    }

//    protected void NotifySubscribers(string content)
//    {
//        var random = new Random();
//        List<ISubscriber> copyOfSubscribers = new(subscribers);

//        foreach (var subscriber in copyOfSubscribers)
//        {
//            int randomAction = random.Next(0, 5);
//            switch (randomAction)
//            {
//                case 0:
//                    subscriber.Like(content);
//                    break;
//                case 1:
//                    subscriber.Comment(content);
//                    break;
//                case 2:
//                    subscriber.Message(content);
//                    break;
//                case 3:
//                    subscriber.Ignore(content);
//                    break;
//                case 4:
//                    subscriber.Unsubscribe(this); // тепер підписник може відписатися сам
//                    break;
//                default:
//                    break;
//            }
//        }
//    }
//}

//// приклад класу користувача-видавця
//class User : Publisher
//{
//    public void MakeStory(string content)
//    {
//        Console.WriteLine($"користувач створив сторіс: {content}");
//        NotifySubscribers(content);
//    }

//    public void MakeReel(string content)
//    {
//        Console.WriteLine($"користувач створив рілс: {content}");
//        NotifySubscribers(content);
//    }

//    public void PostPhoto(string content)
//    {
//        Console.WriteLine($"користувач опублікував фото: {content}");
//        NotifySubscribers(content);
//    }
//}

//// приклад класу користувача-підписника
//class InstagramFollower : ISubscriber
//{
//    List<Publisher> publishers = new List<Publisher>();

//    public void AddPublisher(Publisher publisher)
//    {
//        if (!publishers.Contains(publisher))
//        {
//            publishers.Add(publisher);
//            publisher.AddSubscriber(this);
//        }
//    }

//    public void Like(string content)
//    {
//        Console.WriteLine("Лайкнуто!");
//    }

//    public void Comment(string content)
//    {
//        Console.WriteLine("Закоментовано!");
//    }

//    public void Message(string content)
//    {
//        Console.WriteLine("Надіслано повідомлення!");
//    }

//    public void Ignore(string content)
//    {
//        Console.WriteLine("Проігноровано");
//    }

//    public void Unsubscribe(Publisher publisher)
//    {
//        Console.WriteLine("відписано від користувача");

//        if (publishers.Contains(publisher))
//        {
//            publisher.RemoveSubscriber(this);
//            publishers.Remove(publisher);
//        }
//    }
//}
// ------------------------------------------------------------------------------------------------------
// ========================================================================================================
// ------------------------------------------------------------------------------------------------------

// Instagram v.0.03

//class Program
//{
//    static void Main()
//    {
//        Console.OutputEncoding = Encoding.UTF8;

//        var andriy = new InstagramUser();
//        var petro = new InstagramUser();
//        var maria = new InstagramUser();

//        petro.Subscribe(andriy);
//        maria.Subscribe(andriy);

//        andriy.MakeStory("Красивий захід сонця!");
//        andriy.MakeReel("Веселий танець!");
//        andriy.PostPhoto("Нове фото профілю!");
//    }
//}

//// інтерфейс підписника (наближено до класичного observer: лише update від видавця)
//interface ISubscriber
//{
//    void Update(IPublisher publisher, string content);
//}

//// інтерфейс видавця (наблизжено до subject: attach, detach, notify)
//interface IPublisher
//{
//    void AddSubscriber(ISubscriber subscriber);
//    void RemoveSubscriber(ISubscriber subscriber);
//    void NotifySubscribers(string content);
//}

//// звісно, як користувачі Instagram, ми можемо бути і підписниками, і видавцями одночасно
//class InstagramUser : IPublisher, ISubscriber
//{
//    private List<ISubscriber> subscribers = new List<ISubscriber>(); // мої підписники
//    private List<IPublisher> followedPublishers = new List<IPublisher>(); // кого я читаю

//    // реалізація IPublisher
//    public void AddSubscriber(ISubscriber subscriber)
//    {
//        if (!subscribers.Contains(subscriber))
//        {
//            subscribers.Add(subscriber);
//        }
//    }

//    public void RemoveSubscriber(ISubscriber subscriber)
//    {
//        subscribers.Remove(subscriber);
//    }

//    public void NotifySubscribers(string content)
//    {
//        List<ISubscriber> copyOfSubscribers = new(subscribers);

//        foreach (var subscriber in copyOfSubscribers)
//        {
//            // передаємо this як посилання на Видавця (а то раптом підписник захоче відписатися)
//            subscriber.Update(this, content);
//        }
//    }

//    // реалізація ISubscriber: наближено до класичного update, з випадковою логікою дій
//    public void Update(IPublisher publisher, string content)
//    {
//        var random = new Random();
//        int randomAction = random.Next(5);
//        switch (randomAction)
//        {
//            case 0:
//                Like(content);
//                break;
//            case 1:
//                Comment(content);
//                break;
//            case 2:
//                Message(content);
//                break;
//            case 3:
//                Ignore(content);
//                break;
//            case 4:
//                Unsubscribe(publisher);
//                break;
//            default:
//                break;
//        }
//    }

//    // методи для підписки на/відписки від Видавця (допоміжні, не з інтерфейсів)
//    public void Subscribe(IPublisher publisher)
//    {
//        if (!followedPublishers.Contains(publisher))
//        {
//            followedPublishers.Add(publisher);
//            publisher.AddSubscriber(this);
//        }
//    }

//    public void Unsubscribe(IPublisher publisher)
//    {
//        if (followedPublishers.Contains(publisher))
//        {
//            Console.WriteLine("З мене досить! Відписка!");
//            publisher.RemoveSubscriber(this);
//            followedPublishers.Remove(publisher);
//        }
//    }

//    // методи реакцій на сповіщення (внутрішні)
//    private void Like(string content)
//    {
//        Console.WriteLine("Лайкнуто!");
//    }

//    private void Comment(string content)
//    {
//        Console.WriteLine("Закоментовано!");
//    }

//    private void Message(string content)
//    {
//        Console.WriteLine("Надіслано повідомлення!");
//    }

//    private void Ignore(string content)
//    {
//        Console.WriteLine("Проігноровано");
//    }

//    // методи публікації контенту
//    public void MakeStory(string content)
//    {
//        Console.WriteLine($"користувач створив сторіс: {content}");
//        NotifySubscribers(content);
//    }

//    public void MakeReel(string content)
//    {
//        Console.WriteLine($"користувач створив рілс: {content}");
//        NotifySubscribers(content);
//    }

//    public void PostPhoto(string content)
//    {
//        Console.WriteLine($"користувач опублікував фото: {content}");
//        NotifySubscribers(content);
//    }
//}
// ------------------------------------------------------------------------------------------------------
// ========================================================================================================
// ------------------------------------------------------------------------------------------------------
// ну і ще один шикарний приклад до кучі:
// Weather Example, нехай проблеми та негоди не роблять вам в житті погоди :)

//namespace ObserverPatternExample
//{
//    interface Observer
//    {
//        void Update(string city, string weatherInfo);
//    }

//    interface Subject
//    {
//        void RegisterObserver(Observer observer);
//        void RemoveObserver(Observer observer);
//        void NotifyObservers();
//    }

//    interface DisplayElement
//    {
//        void Display();
//    }

//    class WttrWeatherData : Subject
//    {
//        List<Observer> observers = new List<Observer>();
//        string city = "";
//        string weatherInfo = "";

//        public void RegisterObserver(Observer observer)
//        {
//            observers.Add(observer);
//        }

//        public void RemoveObserver(Observer observer)
//        {
//            observers.Remove(observer);
//        }

//        public void NotifyObservers()
//        {
//            foreach (Observer ob in observers)
//            {
//                ob.Update(city, weatherInfo);
//            }
//        }

//        private void MeasurementsChanged()
//        {
//            NotifyObservers();
//        }

//        private void SetMeasurements(string city, string weatherInfo)
//        {
//            this.city = city;
//            this.weatherInfo = weatherInfo;
//            MeasurementsChanged();
//        }

//        public async Task GetWeatherFromWttrAsync(string city)
//        {
//            string url = $"https://wttr.in/{city}?T";

//            using (var client = new HttpClient())
//            {
//                try
//                {
//                    var response = await client.GetAsync(url);
//                    response.EnsureSuccessStatusCode();

//                    var data = await response.Content.ReadAsStringAsync();

//                    SetMeasurements(city, data);
//                }
//                catch (HttpRequestException e)
//                {
//                    Console.WriteLine($"Ошибка при получении данных: {e.Message}");
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine($"Неизвестная ошибка: {e.Message}");
//                }
//            }
//        }
//    }

//    class ConsoleApplication : Observer, DisplayElement
//    {
//        string city = "";
//        string weatherInfo = "";
//        Subject source;

//        public ConsoleApplication(Subject source)
//        {
//            this.source = source;
//            this.source.RegisterObserver(this);
//        }

//        public void Update(string city, string weatherInfo)
//        {
//            this.city = city;
//            this.weatherInfo = weatherInfo;
//            Display();
//        }

//        public void Display()
//        {
//            Console.WriteLine($"Погода в {city}:");

//            // парсимо температуру повітря на сайті wttr.in
//            string tempPattern = @"([+-]?\d+)\((\d+)\)\s*°C";
//            Match tempMatch = Regex.Match(weatherInfo, tempPattern);
//            if (tempMatch.Success)
//            {
//                string temp = tempMatch.Groups[1].Value;
//                string feels = tempMatch.Groups[2].Value;
//                Console.WriteLine($"Температура повітря: {temp}°C (відчувається як {feels}°C)");
//            }

//            // парсимо вітер
//            string windPattern = @"([↖↗↘↙→←↓↑])?\s*(\d+(?:-\d+)?)\s*km/h";
//            Match windMatch = Regex.Match(weatherInfo, windPattern);
//            if (windMatch.Success)
//            {
//                string direction = windMatch.Groups[1].Success ? windMatch.Groups[1].Value : "";
//                string speed = windMatch.Groups[2].Value;
//                Console.WriteLine($"Швидкість вітру: {direction} {speed} км/год");
//            }

//            // парсимо опади
//            string precipPattern = @"(\d+\.?\d*)\s*mm";
//            Match precipMatch = Regex.Match(weatherInfo, precipPattern);
//            if (precipMatch.Success)
//            {
//                string precip = precipMatch.Groups[1].Value;
//                Console.WriteLine($"Опади: {precip} мм");
//            }

//            // парсимо локацію
//            string locationPattern = @"Location:\s*.+?\s*\[[\d\.]+\s*,[\d\.]+\]";
//            Match locMatch = Regex.Match(weatherInfo, locationPattern, RegexOptions.Singleline);
//            if (locMatch.Success)
//            {
//                string fullLocation = locMatch.Groups[0].Value.Replace("Location:", "Місцезнаходження:").Trim();
//                Console.WriteLine(fullLocation);
//            }
//            else
//            {
//                Console.WriteLine("Місцезнаходження: невідомо");
//            }

//            Console.WriteLine();
//        }
//    }

//    class Program
//    {
//        public static async Task Main()
//        {
//            Console.OutputEncoding = System.Text.Encoding.UTF8;
//            Console.Title = "Observer";

//            var weather = new WttrWeatherData();
//            var app = new ConsoleApplication(weather);

//            await weather.GetWeatherFromWttrAsync("Одеса");
//            await weather.GetWeatherFromWttrAsync("Київ");
//            await weather.GetWeatherFromWttrAsync("Львів");
//            await weather.GetWeatherFromWttrAsync("Харків");
//            await weather.GetWeatherFromWttrAsync("Ужгород");
//            await weather.GetWeatherFromWttrAsync("Миколаїв");
//            await weather.GetWeatherFromWttrAsync("Барселона");
//        }
//    }
//}
// ------------------------------------------------------------------------------------------------------
//namespace EventsExample
//{
//    /* події сигналізують системі про те, що сталася певна подія.
//    якщо потрібно відстежити ці дії, то події якраз дозволяють це зробити.

//    https://metanit.com/sharp/tutorial/3.14.php

//    події в .net базуються на моделі делегата. модель делегата відповідає
//    шаблону розробки спостерігача, який дозволяє підписнику зареєструватися у постачальника
//    і отримувати від нього сповіщення. відправник події надсилає сповіщення про подію,
//    а приймач події отримує сповіщення і визначає відповідь на нього.

//    подія — це повідомлення, надіслане об'єктом, щоб повідомити про вчинення дії.
//    ця дія може бути викликана взаємодією користувача, наприклад натисканням кнопки,
//    або іншою програмною логікою, наприклад зміною значення властивості.

//    об'єкт, що викликає подію, називається відправником подій.
//    відправнику подій невідомий об'єкт чи метод, який отримуватиме (оброблятиме)
//    створені ним події. зазвичай подія є компонентом відправника подій;
//    наприклад, подія click — компонент класу button, а подія propertychanged — компонент класу,
//    що реалізує інтерфейс inotifypropertychanged.

//    щоб визначити подію, в c# необхідно використовувати ключове слово event.
//    */

//    class DaysCounter // клас-видавець, в якому проводиться підрахунок
//    {
//        public delegate void MyEventHandler(); // тип делегата, який задає сигнатуру методів-обробників події

//        // подія PayRent з типом делегата MyEventHandler
//        public event MyEventHandler? PayRent; // назва події (чорний день місяця, коли треба платити оренду)

//        public void StartCounting()
//        {
//            for (int i = 1; i <= 31; i++)
//            {
//                Console.Write(i + ", ");
//                if (i == 18) // колись я платив кожного 18го числа... нащастя, тепер я живу в своєму домі
//                {
//                    Console.WriteLine("\n");
//                    if (PayRent != null) // якщо є хоч один підписник на подію (адже комусь має бути цікаво настання цієї дати, наприклад власнику квартири)
//                        PayRent(); // генерація події класом-видавцем
//                }
//            }
//        }
//    }

//    class Oleksandr // клас-підписник, що реагує на подію (коли настав 25-й день місяця) записом рядка в консоль
//    {
//        double money = 12500;
//        double happiness = 89;

//        public void LoseMoney() // метод оплати оренди за квартиру
//        {
//            Console.WriteLine("Олександр каже: Сьогодні найсумніший день у місяці...");
//            money -= 8000;
//            happiness -= 50;
//        }

//        public void BuyRevo()
//        {
//            Console.WriteLine("One shot - one hit");
//            money -= 55;
//            happiness += 5;
//        }
//    }

//    class LandLady // ще один клас-підписник (господиня квартири)
//    {
//        public void GetPaid()
//        {
//            Console.WriteLine("Кіра (не Найтлі): Юхуху! Нарешті цей день настав!!\n");
//        }
//    }

//    class Program
//    {
//        static void Main()
//        {
//            Console.OutputEncoding = Encoding.UTF8;

//            var counter = new DaysCounter(); // екземпляр класу-видавця
//            var alex = new Oleksandr(); // екземпляр класу-підписника
//            var kira = new LandLady(); // ще один екземпляр класу-підписника

//            // counter.StartCounting(); // краще не запускати підрахунок, поки немає підписників!

//            // підписка на подію
//            counter.PayRent += alex.LoseMoney;
//            counter.PayRent += kira.GetPaid;

//            counter.StartCounting();
//        }
//    }
//}
// ------------------------------------------------------------------------------------------------------
//using static EventsExample.DaysCounter;

//namespace EventsExample
//{
//    /* події сигналізують системі про те, що сталася певна подія.
//    якщо потрібно відстежити ці дії, то події якраз дозволяють це зробити.

//    https://metanit.com/sharp/tutorial/3.14.php

//    події в .net базуються на моделі делегата. модель делегата відповідає
//    шаблону розробки спостерігача, який дозволяє підписнику зареєструватися у постачальника
//    і отримувати від нього сповіщення. відправник події надсилає сповіщення про подію,
//    а приймач події отримує сповіщення і визначає відповідь на нього.

//    подія — це повідомлення, надіслане об'єктом, щоб повідомити про вчинення дії.
//    ця дія може бути викликана взаємодією користувача, наприклад натисканням кнопки,
//    або іншою програмною логікою, наприклад зміною значення властивості.

//    об'єкт, що викликає подію, називається відправником подій.
//    відправнику подій невідомий об'єкт чи метод, який отримуватиме (оброблятиме)
//    створені ним події. зазвичай подія є компонентом відправника подій;
//    наприклад, подія click — компонент класу button, а подія propertychanged — компонент класу,
//    що реалізує інтерфейс inotifypropertychanged.

//    щоб визначити подію, в c# необхідно використовувати ключове слово event.
//    */

//    class DaysCounter // клас-видавець, в якому проводиться підрахунок
//    {
//        public delegate void MyEventHandler(); // тип делегата, який задає сигнатуру методів-обробників події

//        // подія PayRent з типом делегата MyEventHandler
//        public event MyEventHandler? PayRent; // назва події (чорний день місяця, коли треба платити оренду)

//        public void StartCounting()
//        {
//            for (int i = 1; i <= 31; i++)
//            {
//                Console.Write(i + ", ");
//                if (i == 5) // колись я платив кожного 18го числа... нащастя, тепер я живу в своєму домі
//                {
//                    Console.WriteLine("\n");
//                    if (PayRent != null) // якщо є хоч один підписник на подію (адже комусь має бути цікаво настання цієї дати, наприклад власнику квартири)
//                        PayRent(); // генерація події класом-видавцем
//                }
//            }
//        }
//    }

//    class Oleksandr // клас-підписник, що реагує на подію (коли настав 25-й день місяця) записом рядка в консоль
//    {
//        double money = 12500;
//        double happiness = 89;
//        public void LoseMoney() // метод оплати оренди за квартиру
//        {
//            Console.WriteLine("Олександр каже: Сьогодні найсумніший день у місяці...");
//            money -= 8000;
//            happiness -= 50;
//        }
//    }

//    class LandLady // ще один клас-підписник (господиня квартири)
//    {
//        public event MyEventHandler? CelebrateGoodDay;

//        public void GetPaid()
//        {
//            if (CelebrateGoodDay != null)
//            {
//                CelebrateGoodDay(); // подія на подію
//            }
//            Console.WriteLine("Кіра (не Найтлі): Юхуху! Нарешті цей день настав!!\n");
//        }

//        public void BuyChehol()
//        {
//            Console.WriteLine("Ура! В мене є зайві 8 тисяч гривень! Можна купити собі новий чехол для смартфона зі стразіками!\n");
//        }
//    }

//    class Program
//    {
//        static void Main()
//        {
//            Console.OutputEncoding = Encoding.UTF8;

//            var counter = new DaysCounter(); // екземпляр класу-видавця
//            var alex = new Oleksandr(); // екземпляр класу-підписника
//            var kira = new LandLady(); // ще один екземпляр класу-підписника

//            // counter.StartCounting(); // краще не запускати підрахунок, поки немає підписників!

//            kira.CelebrateGoodDay += kira.BuyChehol;
//            counter.PayRent += kira.GetPaid;


//            counter.StartCounting();

//        }
//    }
//}
// ------------------------------------------------------------------------------------------------------
//namespace EventsExample
//{
//    class DaysCounter
//    {
//        public delegate void MyEventHandler();

//        /* подія PayRent розгортається в .net 9 у приватне поле
//         * MyEventHandler? payRent з автоматично генерованими методами доступу add/remove:
//         * 
//        private MyEventHandler? payRent; // private!!! це тут важливо, щоб зовнішній код не міг викликати подію напряму

//        public event MyEventHandler? PayRent
//        {
//            add { payRent = (MyEventHandler?)Delegate.Combine(payRent, value); }
//            remove { payRent = (MyEventHandler?)Delegate.Remove(payRent, value); }
//        }
//        з урахуванням nullable reference types для безпеки типів.
//        */

//        /* секції add/remove можна реалізувати вручну, якщо потрібна додаткова логіка
//         * при підписці/відписці від події. в цьому прикладі вони приблизно так виглядають:
//         * public void add_PayRent(MyEventHandler? value)
//                {
//                    // метод add_payrent: додає обробник до ланцюжка делегатів з lock-free thread-safety з c# 4.0
//                    // використовує цикл з Interlocked.CompareExchange для атомарного оновлення без блокувань
//                    // Delegate.Combine викликається для об'єднання, результат повторно пробується присвоїти, доки не успішно
//                    MyEventHandler? currentHandler;
//                    MyEventHandler? newHandler;
//                    do
//                    {
//                        currentHandler = PayRent;
//                        newHandler = (MyEventHandler?)Delegate.Combine(currentHandler, value);
//                    }
//                    while (Interlocked.CompareExchange(ref PayRent, newHandler, currentHandler) != currentHandler);
//                }

//                public void remove_PayRent(MyEventHandler? value)
//                {
//                    // метод remove_payrent: видаляє обробник з ланцюжка делегатів з lock-free thread-safety з c# 4.0
//                    // аналогічно цикл з Interlocked.CompareExchange для атомарного видалення
//                    // Delegate.Remove викликається, результат атомарно присвоюється
//                    MyEventHandler? currentHandler;
//                    MyEventHandler? newHandler;
//                    do
//                    {
//                        currentHandler = PayRent;
//                        newHandler = (MyEventHandler?)Delegate.Remove(currentHandler, value);
//                    }
//                    while (Interlocked.CompareExchange(ref PayRent, newHandler, currentHandler) != currentHandler);
//                } */

//        public event MyEventHandler? PayRent;

//        public void StartCounting()
//        {
//            for (int i = 1; i <= 31; i++)
//            {
//                Console.Write(i + ", ");
//                if (i == 18)
//                {
//                    Console.WriteLine("\n");
//                    if (PayRent != null)
//                        PayRent();
//                    // виклик PayRent(); розгортається в payRent?.Invoke(),
//                    // але з явною перевіркою null це просто payRent без ?., оскільки null вже перевірено.

//                }
//            }
//        }
//    }

//    class Oleksandr
//    {
//        double money = 12500;
//        double happiness = 89;

//        public void LoseMoney()
//        {
//            Console.WriteLine("Олександр каже: Сьогодні найсумніший день у місяці...");
//            money -= 8000;
//            happiness -= 50;
//        }

//        public void BuyRevo()
//        {
//            Console.WriteLine("One shot - one hit");
//            money -= 55;
//            happiness += 5;
//        }
//    }

//    class LandLady
//    {
//        public void GetPaid()
//        {
//            Console.WriteLine("Кіра (не Найтлі): Юхуху! Нарешті цей день настав!!\n");
//        }
//    }

//    class Program
//    {
//        static void Main()
//        {
//            Console.OutputEncoding = Encoding.UTF8;

//            var counter = new DaysCounter();
//            var alex = new Oleksandr();
//            var kira = new LandLady();

//            counter.PayRent += alex.LoseMoney;
//            counter.PayRent += kira.GetPaid;
//            // counter.PayRent(); так не можна зробити, події можна лише викликати всередині класу, де вони оголошені
//            // технічно це реалізується тим, що компілятор створює приватне поле делегата

//            // counter.PayRent += alex.LoseMoney; розгортається в: counter.add_PayRent(new MyEventHandler(alex.LoseMoney));
//            // де new MyEventHandler(alex.LoseMoney) створює делегат, що посилається на метод LoseMoney інстансу alex
//            counter.StartCounting();
//        }
//    }
//}
// ------------------------------------------------------------------------------------------------------
//namespace EventsExample
//{
//    class DaysCounter
//    {
//        public delegate void MyEventHandler();

//        private MyEventHandler? payRent;

//        public event MyEventHandler? PayRent
//        {
//            add
//            {
//                Console.WriteLine("Обробник події додано");
//                MyEventHandler? currentHandler;
//                MyEventHandler? newHandler;
//                do
//                {
//                    currentHandler = payRent;
//                    newHandler = (MyEventHandler?)Delegate.Combine(currentHandler, value);
//                }
//                while (Interlocked.CompareExchange(ref payRent, newHandler, currentHandler) != currentHandler);
//            }
//            remove
//            {
//                Console.WriteLine("Обробник події прибрано");
//                MyEventHandler? currentHandler;
//                MyEventHandler? newHandler;
//                do
//                {
//                    currentHandler = payRent;
//                    newHandler = (MyEventHandler?)Delegate.Remove(currentHandler, value);
//                }
//                while (Interlocked.CompareExchange(ref payRent, newHandler, currentHandler) != currentHandler);
//            }
//        }

//        public void StartCounting()
//        {
//            for (int i = 1; i <= 31; i++)
//            {
//                Console.Write(i + ", ");
//                if (i == 18)
//                {
//                    Console.WriteLine("\n");
//                    if (payRent != null)
//                        payRent();
//                }
//            }
//        }
//    }

//    class Oleksandr
//    {
//        double money = 12500;
//        double happiness = 89;

//        public void LoseMoney()
//        {
//            Console.WriteLine("Олександр каже: Сьогодні найсумніший день у місяці...");
//            money -= 8000;
//            happiness -= 50;
//        }

//        public void BuyRevo()
//        {
//            Console.WriteLine("One shot - one hit");
//            money -= 55;
//            happiness += 5;
//        }
//    }

//    class LandLady
//    {
//        public void GetPaid()
//        {
//            Console.WriteLine("Кіра (не Найтлі): Юхуху! Нарешті цей день настав!!\n");
//        }
//    }

//    class Program
//    {
//        static void Main()
//        {
//            Console.OutputEncoding = Encoding.UTF8;

//            var counter = new DaysCounter();
//            var alex = new Oleksandr();
//            var kira = new LandLady();

//            counter.PayRent += alex.LoseMoney;
//            counter.PayRent += kira.GetPaid;
//            counter.PayRent -= alex.LoseMoney;

//            counter.StartCounting();
//        }
//    }
//}
// ------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------------