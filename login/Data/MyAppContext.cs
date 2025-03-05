using login.Models;
using Microsoft.EntityFrameworkCore;

namespace login.Data
{
    public class MyAppContext:DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    id = 1,
                    Name = "microphone",
                    Price = 100,
                    SerialNumberId=10
                }
            );
            modelBuilder.Entity<SerialNumber>().HasData(
                new SerialNumber
                {
                    id = 10,
                    Name = "MIC150",
                    ItemId = 1
                }
            );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }
    }
}
