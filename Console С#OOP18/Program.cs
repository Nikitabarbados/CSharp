using System;
using System.IO;
using System.Net;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Xml.Linq;
// -------------------------------------------------------------------------------------------------------
//namespace ReadKey
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            while (true)
//            {
//                ConsoleKeyInfo k = Console.ReadKey(true);

//                switch (k.Key)
//                {
//                    case ConsoleKey.D1:
//                        Console.WriteLine("1 pressed!");
//                        break;
//                    case ConsoleKey.D2:
//                        Console.WriteLine("2 pressed!");
//                        break;
//                    case ConsoleKey.D3:
//                        Console.WriteLine("3 pressed!");
//                        break;
//                    case ConsoleKey.Spacebar:
//                        Console.WriteLine("Space pressed!");
//                        break;
//                    case ConsoleKey.Escape:
//                        Console.WriteLine("Escape pressed!");
//                        break;
//                    case ConsoleKey.Enter:
//                        Console.WriteLine("Enter pressed!");
//                        break;
//                }
//            }
//        }
//    }
//}
// -------------------------------------------------------------------------------------------------------
//namespace ConsoleApplication1
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            while (true)
//            {
//                if (Console.KeyAvailable)
//                {
//                    ConsoleKeyInfo k = Console.ReadKey(true);
//                    Console.Write(k.KeyChar);
//                }
//                else
//                {
//                    Console.Write("_");
//                }
//                Thread.Sleep(15);
//            }
//        }
//    }
//}
// -------------------------------------------------------------------------------------------------------
//Cat c = new Cat();

//....

//c = null;
// -------------------------------------------------------------------------------------------------------
//-**System.IO * *
//  -**Інтерфейси / Базові класи * *
//    -TextReader(абстрактний клас) – Представляє читача, що може читати послідовну серію символів.
//    - TextWriter (абстрактний клас) – Представляє писаря, що може записувати послідовну серію символів.
//  - **Потоки (Streams)**
//    - Stream (абстрактний клас) – Забезпечує загальний вигляд послідовності байтів.
//    - **FileStream** (клас) – Забезпечує потік для файлу, підтримує синхронні та асинхронні операції читання/запису.
//    - MemoryStream (клас) – Створює потік, чиє сховище – у пам'яті.
//    - BufferedStream (клас) – Додає шар буферизації для читання/запису в інший потік (запечатаний).
//    - UnmanagedMemoryStream (клас) – Забезпечує доступ до неуправляємих блоків пам'яті з коду.
//    - UnmanagedMemoryAccessor (клас) – Забезпечує випадковий доступ до неуправляємих блоків пам'яті.
//  - **Читачі та Писарі (Readers and Writers)**
//    - **BinaryReader** (клас) – Читає примітивні типи даних як бінарні значення в конкретному кодуванні.
//    - **BinaryWriter** (клас) – Записує примітивні типи в бінарному форматі до потоку та підтримує запис рядків.
//    - **StreamReader** (клас) – Реалізує TextReader для читання символів з байтового потоку в конкретному кодуванні.
//    - **StreamWriter** (клас) – Реалізує TextWriter для запису символів до потоку в конкретному кодуванні.
//    - StringReader (клас) – Реалізує TextReader для читання з рядка.
//    - StringWriter (клас) – Реалізує TextWriter для запису інформації до рядка (підтримується StringBuilder).
//  - **Операції з файлами (File Operations)**
//    - **File** (клас) – Надає статичні методи для створення, копіювання, видалення, переміщення файлів та відкриття FileStream.
//    - **FileInfo** (клас) – Надає властивості та екземплярні методи для операцій з файлами; базовий клас – FileSystemInfo (запечатаний).
//    - FileStream (клас) – (також у Потоках)
//    - FileStreamOptions (клас) – Опції конфігурації для FileStream.
//  - **Операції з директоріями (Directory Operations)**
//    - **Directory** (клас) – Розкриває статичні методи для створення, переміщення та переліку директорій (запечатаний).
//    - **DirectoryInfo** (клас) – Розкриває екземплярні методи для операцій з директоріями; базовий клас – FileSystemInfo (запечатаний).
//    - EnumerationOptions (клас) – Опції для переліку файлів та директорій.
//  - **Інші утиліти (Other Utilities)**
//    - **Path** (клас) – Виконує кросплатформові операції з рядками, що містять інформацію про шляхи файлів/директорій.
//    - FileSystemInfo (абстрактний клас) – Базовий клас для FileInfo та DirectoryInfo.
//    - FileSystemWatcher (клас) – Слухає сповіщення про зміни файлової системи та викликає події.
//    - **DriveInfo** (клас) – Надає інформацію про диск.
//    - FileSystemAclExtensions (клас) – Розширення для маніпуляції ACL-атрибутами безпеки (специфічно для Windows).
//    - WindowsRuntimeStorageExtensions (клас) – Розширення для інтерфейсів сховища Windows Runtime.
//    - WindowsRuntimeStreamExtensions (клас) – Розширення для конвертації між потоками Windows Runtime та керованими.
//  - **Винятки (Exceptions)**
//    - **IOException** (клас) – Кидається при помилці вводу/виводу.
//    - **FileNotFoundException** (клас) – Кидається, коли файл не існує.
//    - **DirectoryNotFoundException** (клас) – Кидається, коли директорія не знайдена.
//    - **DriveNotFoundException** (клас) – Кидається, коли диск недоступний.
//    - EndOfStreamException (клас) – Кидається при читанні за кінець потоку.
//    - FileLoadException (клас) – Кидається при неможливості завантаження асемблі.
//    - InvalidDataException (клас) – Кидається, коли потік даних у невалідному форматі.
//    - FileFormatException (клас) – Кидається, коли файл/потік не відповідає очікуваному формату.
//    - PathTooLongException (клас) – Кидається, коли шлях перевищує максимальну довжину.
//    - InternalBufferOverflowException (клас) – Кидається при переповненні внутрішнього буфера.
//    - PipeException (клас) – Кидається при помилці в іменованому каналі.
//  - **Типи подій (Event-related Types)**
//    - FileSystemEventArgs (клас) – Дані для подій Changed, Created, Deleted у FileSystemWatcher.
//    - RenamedEventArgs (клас) – Дані для події Renamed у FileSystemWatcher.
//    - ErrorEventArgs (клас) – Дані для події Error у FileSystemWatcher.
//    - FileSystemEventHandler (делегат) – Обробник для подій Changed, Created, Deleted.
//    - RenamedEventHandler (делегат) – Обробник для події Renamed.
//    - ErrorEventHandler (делегат) – Обробник для події Error.
//  - **Перелічення (Enums)**
//    - **DriveType** – Константи типів дисків (CDRom, Fixed, Network тощо).
//    - **FileAccess** – Константи доступу: читання, запис або читання/запис.
//    - **FileAttributes** – Атрибути файлів та директорій.
//    - **FileMode** – Спосіб відкриття файлу операційною системою.
//    - FileOptions – Розширені опції для створення FileStream.
//    - FileShare – Контроль доступу інших операцій до того ж файлу.
//    - HandleInheritability – Чи успадковується базовий дескриптор дочірніми процесами.
//    - MatchCasing – Тип регістру символів для співставлення.
//    - MatchType – Тип співставлення з wildcards.
//    - NotifyFilters – Зміни, за якими стежити в файлі/папці.
//    - SearchOption – Пошук лише в поточній директорії чи з піддиректоріями.
//    - SeekOrigin – Позиція в потоці для пошуку.
//    - UnixFileMode – Права доступу Unix-файлової системи (бітова комбінація).
//    - WatcherChangeTypes – Можливі зміни файлу/директорії.
// -------------------------------------------------------------------------------------------------------
//namespace FileStreamExample
//{
//    class Program
//    {
//        static void Main()
//        {
//            Console.OutputEncoding = Encoding.UTF8;
//            Console.Write("Введіть шлях до файлу: ");
//            string? filePath = Console.ReadLine();
//            using var fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);

//            Console.WriteLine("Введіть рядок для запису у файл:");
//            string? writeText = Console.ReadLine();
//            byte[] writeBytes = Encoding.UTF8.GetBytes(writeText); // перетворення рядка на масив байтів
//            fs.Write(writeBytes, 0, writeBytes.Length);
//            fs.Flush(); // зберігаємо дані на диск

//            fs.Seek(0, SeekOrigin.Begin); // встановлюємо курсор на початок файлу
//            var readBytes = new byte[fs.Length];
//            fs?.Read(readBytes, 0, (int)fs.Length);
//            string readText = Encoding.UTF8.GetString(readBytes);
//            Console.WriteLine("Дані, прочитані з файлу: {0}", readText);
//        }
//    }
//}

// рядок досить просто перетворити на масив байтів, а що робити з інтами або даблами?
// int i = 10;
// double d = 3.14159;

// byte[] bytesInteger = BitConverter.GetBytes(i); // ділимо інт на 4 частини
// byte[] bytesDouble = BitConverter.GetBytes(d); // ділимо дабл на 8 частин

// fs.Write(bytesInteger);
// fs.Write(bytesDouble);
// -------------------------------------------------------------------------------------------------------
//namespace StreamWriterAndReader
//{
//    class Program
//    {
//        static void Main()
//        {
//            Console.OutputEncoding = Encoding.UTF8;

//            var fs = new FileStream(@"file.txt", FileMode.Create, FileAccess.ReadWrite);

//            var sw = new StreamWriter(fs);
//            sw.AutoFlush = true;

//            string writeText = "Привіт, ";
//            sw.Write(writeText);

//            int number = 2026;
//            sw.Write(number);

//            // sw.Dispose(); // зберегти дані на диск, але й закрити потік

//            fs.Seek(0, SeekOrigin.Begin);

//            var sr = new StreamReader(fs);
//            string readText = sr.ReadToEnd();
//            Console.WriteLine(readText);

//            fs.Close();
//        }
//    }
//}
// -------------------------------------------------------------------------------------------------------
//StreamReader, StreamWriter
//для запису текста у файл!
//все пишеться як текст!
//якщо записати число 45 у файл, то там воно збережеться як 
//"45"
// -------------------------------------------------------------------------------------------------------
//namespace RandomLineRead
//{
//    class Program
//    {
//        static void Main()
//        {
//            Console.OutputEncoding = Encoding.UTF8;

//            string path = "lines.txt";

//            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
//            using (var sw = new StreamWriter(fs, Encoding.UTF8))
//            {
//                for (int i = 1; i <= 10; i++)
//                {
//                    sw.WriteLine($"Рядок номер {i}");
//                }
//            }

//            string[] lines = File.ReadAllLines(path, Encoding.UTF8);

//            Random rnd = new Random();
//            int index = rnd.Next(lines.Length);

//            Console.WriteLine($"Випадковий рядок №{index + 1}:");
//            Console.WriteLine(lines[index]);
//        }
//    }
//}
// -------------------------------------------------------------------------------------------------------
//                                                 MessagePack
//namespace BinaryWriterAndReader
//{
//    class Program
//    {
//        static void Main()
//        {
//            Console.OutputEncoding = Encoding.UTF8;
//            string path = "file.bin";

//            var fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);

//            var bw = new BinaryWriter(fs);

//            double d = 3.1415927;
//            int i = 1234;
//            string s = "some text";

//            bw.Write(d);
//            bw.Write(i);
//            bw.Write(s);

//            bw.Flush();

//            fs.Seek(0, SeekOrigin.Begin);

//            var br = new BinaryReader(fs);

//            Console.WriteLine(br.ReadDouble());
//            Console.WriteLine(br.ReadInt32());
//            Console.WriteLine(br.ReadString());

//            fs.Close();
//        }
//    }
//}
// -------------------------------------------------------------------------------------------------------
//namespace DirectoryExample
//{
//    class Program
//    {
//        static void Main()
//        {
//            Console.OutputEncoding = Encoding.UTF8;

//            string[] files = Directory.GetFiles(@"C:\1\");
//            foreach (string name in files)
//                Console.WriteLine(name);
//            Console.WriteLine();

//            ///////////////////////////////////////////////////////////////////////////////

//            string[] dirs = Directory.GetDirectories(@"C:\");
//            foreach (string name in dirs)
//                Console.WriteLine(name);
//            Console.WriteLine();

//            ///////////////////////////////////////////////////////////////////////////////

//            string[] drives = Directory.GetLogicalDrives();
//            foreach (string name in drives)
//                Console.WriteLine(name);
//            Console.WriteLine();

//            try
//            {
//                DriveInfo[] dr = DriveInfo.GetDrives();
//                foreach (DriveInfo d in dr)
//                {
//                    if (d.IsReady)
//                        Console.WriteLine("{0,-5} {1}     ", d.Name, d.TotalSize);
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }

//            ///////////////////////////////////////////////////////////////////////////////

//            string path = @"C:\1\";
//            Directory.CreateDirectory(path);
//            Console.WriteLine(Directory.Exists(path));
//            // Directory.Delete(path); // якщо папка не пуста, буде виключення
//            Console.WriteLine(Directory.Exists(path));
//            Console.WriteLine();
//        }
//    }
//}
// -------------------------------------------------------------------------------------------------------
//Console.WriteLine(Directory.GetCreationTime("C:/1/"));
//Console.WriteLine(Directory.GetLastWriteTime("C:/1/"));
//Console.WriteLine(Directory.GetLastAccessTime("C:/1/"));
// -------------------------------------------------------------------------------------------------------
//namespace PathExample
//{
//    class Program
//    {
//        static void Main()
//        {
//            string p = @"D:\1\2\3\4\5.txt"; // довільний рядок (можливий шлях до файлу)

//            Console.WriteLine(Path.GetDirectoryName(p));
//            Console.WriteLine(Path.ChangeExtension(p, ".mp3"));
//            Console.WriteLine(Path.GetExtension(p));
//            Console.WriteLine(Path.GetFileName(p));
//            Console.WriteLine(Path.GetFullPath(p));
//            Console.WriteLine(Path.GetInvalidFileNameChars());
//            Console.WriteLine(Path.GetPathRoot(p));
//            Console.WriteLine(Path.GetRandomFileName());
//            Console.WriteLine(Path.GetTempFileName());
//            Console.WriteLine(Path.IsPathRooted(p));
//            Console.WriteLine(Path.HasExtension(p));
//        }
//    }
//}
// -------------------------------------------------------------------------------------------------------
//namespace WordFrequencyAnalyzer
//{
//    class Program
//    {
//        // функція для очищення тексту (видаляємо знаки пунктуації та перетворюємо в нижній регістр)
//        static string CleanText(string text)
//        {
//            var sb = new StringBuilder();
//            foreach (char c in text)
//            {
//                if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
//                    sb.Append(char.IsLetter(c) ? char.ToLowerInvariant(c) : c);
//            }
//            return sb.ToString();
//        }

//        // функція підрахунку частоти слів
//        static Dictionary<string, int> GetWordFrequency(string text)
//        {
//            string cleaned = CleanText(text);
//            string[] wordList = cleaned.Split(new char[] { ' ', '\t', '\n', '\r', '\f', '\v' }, StringSplitOptions.RemoveEmptyEntries);
//            var wordFrequency = new Dictionary<string, int>();

//            foreach (string word in wordList)
//            {
//                if (word.Length >= 5 && word.Length <= 20)
//                {
//                    if (wordFrequency.ContainsKey(word))
//                        wordFrequency[word]++;
//                    else
//                        wordFrequency[word] = 1;
//                }
//            }
//            return wordFrequency;
//        }

//        // функція отримання топ-N найпопулярніших слів
//        static List<KeyValuePair<string, int>> GetTopWords(Dictionary<string, int> wordFrequency, int topN = 50)
//        {
//            return wordFrequency.OrderByDescending(kv => kv.Value).Take(topN).ToList();
//        }

//        static string ReadTextFromFile(string filepath)
//        {
//            try
//            {
//                return File.ReadAllText(filepath, Encoding.UTF8);
//            }
//            catch (DecoderFallbackException)
//            {
//                // якщо не вдалося прочитати в UTF-8, пробуємо інше кодування
//                return File.ReadAllText(filepath, Encoding.GetEncoding("windows-1251"));
//            }
//        }

//        static void Main()
//        {
//            Console.OutputEncoding = Encoding.UTF8;

//            string filepath = @"C:\!Files\text\kobzar.txt";
//            string text = ReadTextFromFile(filepath);
//            // отримуємо частоту слів
//            Dictionary<string, int> wordFrequency = GetWordFrequency(text);
//            // отримуємо топ-500 найпопулярніших слів
//            List<KeyValuePair<string, int>> topWords = GetTopWords(wordFrequency, topN: 500);

//            // виводимо таблицю
//            Console.WriteLine("{0,-4} {1,-25} {2,-20}", "№", "слово", "зустрічається разів");
//            Console.WriteLine(new string('-', 50));

//            int index = 1;
//            foreach (var entry in topWords)
//            {
//                Console.WriteLine("{0,-4} {1,-25} {2,-20}", index, entry.Key, entry.Value);
//                index++;
//            }
//        }
//    }
//}
// -------------------------------------------------------------------------------------------------------
//namespace FileSearcher
//{
//    class Program
//    {
//        static void Main()
//        {
//            Console.OutputEncoding = System.Text.Encoding.UTF8;

//            // визначаємо початковий шлях залежно від ОС для кросплатформенності
//            string startPath;
//            string fileMask = "*.dll"; // маска файлів

//            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
//                startPath = @"C:\Windows\system32\";
//            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
//            {
//                startPath = "/usr/lib/";
//                fileMask = "*.so";
//            }
//            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
//            {
//                startPath = "/usr/lib/";
//                fileMask = "*.dylib";
//            }
//            else
//            {
//                startPath = Directory.GetCurrentDirectory();
//            }

//            int total = 0;
//            try
//            {
//                // пошук файлів рекурсивно з урахуванням маски
//                var files = Directory.EnumerateFiles(startPath, fileMask, SearchOption.AllDirectories);
//                foreach (string fullPath in files)
//                {
//                    Console.WriteLine(fullPath);
//                    total++;
//                }
//            }
//            catch (UnauthorizedAccessException ex)
//            {
//                Console.WriteLine($"Помилка доступу: {ex.Message}");
//            }
//            catch (DirectoryNotFoundException ex)
//            {
//                Console.WriteLine($"Директорія не знайдена: {ex.Message}");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Загальна помилка: {ex.Message}");
//            }

//            Console.WriteLine($"\nЗагальна кількість файлів: {total}\n");
//        }
//    }
//}
// -------------------------------------------------------------------------------------------------------
//HTML
//p
//h1
//div
//a
//DTD
//JSON
// -------------------------------------------------------------------------------------------------------
//<? xml version = "1.0" encoding = "utf-8" ?>
//< !DOCTYPE recipe >
//< recipe name = "хліб" preptime = "5min" cooktime = "180min" >
//   < title >
//      Простий хліб
//   </ title >
//   < composition >
//      < ingredient amount = "3" unit = "стакан" > Борошно </ ingredient >
//      < ingredient amount = "0.25" unit = "грам" > Дріжджі </ ingredient >
//      < ingredient amount = "1.5" unit = "стакан" > Вода </ ingredient >
//   </ composition >
//   < instructions >
//     < step >
//        Змішати всі інгредієнти та ретельно замісити.
//     </step>
//     <step>
//        Закрити тканиною та залишити на одну годину в теплому приміщенні. 
//     </step>
//     <!-- 
//        <step>
//           Подивитися сторіз друзів в інстаграмі
//        </step>
//         - це сумнівний крок...
//      -->
//     <step>
//        Замісити ще раз, покласти на лист і поставити в духовку.
//     </step>
//   </instructions>
//</recipe>
// -------------------------------------------------------------------------------------------------------
//7 articles in the left menu
//LIFO

//<body>
//<p>

//</p>
//</body>
// -------------------------------------------------------------------------------------------------------
//<? xml version = "1.0" encoding = "UTF-8" ?>
//< breakfast_menu >
//  < food >
//    < name > Бельгійські вафлі </ name >
//    < price >₴205.95 </ price >
//    < description > Наші знамениті бельгійські вафлі з великою кількістю справжнього кленового сиропу</description>
//    <calories>650</calories>
//  </food>
//  <food>
//    <name>Французький тост</name>
//    <price>₴154.50</price>
//    <description>Товсті скибки, приготовані з нашого домашнього кислого хліба</description>
//    <calories>600</calories>
//  </food>
//  <food>
//    <name>Домашній сніданок</name>
//    <price>₴236.95</price>
//    <description>Два яйця, бекон або ковбаса, тост і наші мега-популярні картопляні оладки</description>
//    <calories>950</calories>
//  </food>
//  <food>
//    <name>Омлет з овочами</name>
//    <price>₴157.25</price>
//    <description>Пухкий омлет з свіжими овочами, сиром та зеленню</description>
//    <calories>450</calories>
//  </food>
//  <food>
//    <name>Йогурт з фруктами</name>
//    <price>₴253.75</price>
//    <description>Натуральний йогурт з сезонними фруктами та горіхами</description>
//    <calories>300</calories>
//  </food>
//</breakfast_menu>
// -------------------------------------------------------------------------------------------------------
//<? xml version = "1.0" encoding = "UTF-8" ?>
//< address_book xmlns = "http://sunmeat.site/contacts" >
//    < contact id = "1" >
//        < name > Іван Петренко </ name >
//        < email > ivan.petrenko@email.com </ email >
//        < phone > +380501234567 </ phone >
//        < address > Київ, вул.Хрещатик, 1 </ address >
//        < notes > Друг з університету</notes>
//    </contact>
//    <contact id = "2" >
//        < name > Марія Коваленко</name>
//        <email>marina.kov @ukr.net</email>
//        <phone>+380671112233</phone>
//        <address>Львів, пл.Ринок, 10</address>
//        <notes>Колежанка по роботі</notes>
//    </contact>
//    <contact id = "3" >
//        < name > Олег Сидоренко</name>
//        <email>oleg.sidorenko @gmail.com</email>
//        <phone>+380501234568</phone>
//        <address>Одеса, вул.Дерибасівська, 5</address>
//        <notes>Сусід</notes>
//    </contact>
//    <contact id = "4" >
//        < name > Анна Шевченко</name>
//        <email>anna.shev @i.ua</email>
//        <phone>+380681234567</phone>
//        <address>Харків, вул.Сумська, 20</address>
//        <notes>Сестра</notes>
//    </contact>
//    <contact id = "5" >
//        < name > Віктор Бондаренко</name>
//        <email>viktor.bond @outlook.com</email>
//        <phone>+380661234567</phone>
//        <address>Дніпро, пр.Яворницького, 15</address>
//        <notes>Клієнт</notes>
//    </contact>
//    <contact id = "6" >
//        < name > Софія Литвин</name>
//        <email>sofia.litvin @email.com</email>
//        <phone>+380671234568</phone>
//        <address>Ізмаїл, вул.Лермонтова, 3</address>
//        <notes>Подруга з дитинства</notes>
//    </contact>
//    <contact id = "7" >
//        < name > Дмитро Грищенко</name>
//        <email>dmytro.grish @ukr.net</email>
//        <phone>+380501234569</phone>
//        <address>Чернівці, вул.Головна, 8</address>
//        <notes>Спортсмен</notes>
//    </contact>
//    <contact id = "30" >
//        < name > Юлія Мороз</name>
//        <email>yulia.moroz @gmail.com</email>
//        <phone>+380691234567</phone>
//        <address>Тернопіль, вул.Гетьмана, 12</address>
//        <notes>Вчителька</notes>
//    </contact>
//    <meta>
//        <count>30</count>
//        <last_update>2025-11-10</last_update>
//    </meta>
//</address_book>
// -------------------------------------------------------------------------------------------------------

// -------------------------------------------------------------------------------------------------------

// -------------------------------------------------------------------------------------------------------
