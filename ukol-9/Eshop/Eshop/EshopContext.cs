using Microsoft.EntityFrameworkCore;
using Eshop.Entities;

namespace Eshop
{
    public class EshopContext : DbContext
    {
        public EshopContext(DbContextOptions<EshopContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Price> Prices { get; set; } = null!;
    }
}
