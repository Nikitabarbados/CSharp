using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Console.NET.Models;
using Console.NET.Infrastructure.Repositories;

namespace Console.NET.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=AppDbContext")
        {

        }
}
}
