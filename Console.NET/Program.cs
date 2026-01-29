using Console.NET.Infrastructure;
using Console.NET.Models;

namespace Console.NET
{
    internal class Program
    {
        static void Main()
        {
            var context = new AppDbContext();

            // context.Database.EnsureDeleted(); // якщо БД була, вона дропнеться
            context.Database.EnsureCreated(); // створюємо БД заново

            var users = context.Users?.ToList(); // SELECT

            for (int i = 0; i < users!.Count; i++)
                Console.WriteLine(users[i].Name + " " + users[i].Age);

        }
    }
}
