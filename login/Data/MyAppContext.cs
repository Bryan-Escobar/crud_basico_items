using login.Models;
using Microsoft.EntityFrameworkCore;

namespace login.Data
{
    public class MyAppContext:DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
    }
}
