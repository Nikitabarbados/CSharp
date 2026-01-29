using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.NET.Models
{
    public class User
    {
        public int Id { get; set; }         // первинний ключ
        public string? Name { get; set; }   // інші поля
        public int Age { get; set; }
    }
}
