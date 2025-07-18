using Eshop.Entities;

namespace Eshop
{
    public static class EshopContextSeed
    {
        private static EshopContext _context = null!;

        public static void SeedDatabase(EshopContext context)
        {
            _context = context;

            CreateItems();
            CreateCustomers();
            CreatePrices();
        }

        private static void CreateItems()
        {
            if (_context.Items.Any())
            {
                return;
            }

            var rnd = new Random();

            for (var i = 0; i < 20; i++)
            {
                var item = new Item { Name = $"Item {i}", SoldDate = DateTime.Now.AddYears(-rnd.Next(10, 40)) };
                _context.Items.Add(item);
            }

            _context.SaveChanges();
        }

        private static void CreateCustomers()
        {
            if (_context.Customers.Any())
            {
                return;
            }

            var rnd = new Random();

            for (var i = 0; i < 20; i++)
            {
                var customer = new Customer { Name = $"Customer {i}" };
                _context.Customers.Add(customer);
            }

            _context.SaveChanges();
        }

        private static void CreatePrices()
        {
            if (_context.Prices.Any())
            {
                return;
            }

            var rnd = new Random();

            for (var i = 0; i < 20; i++)
            {
                var price = new Price { Value = i, ItemId = i, SetDate = DateTime.Now.AddYears(-rnd.Next(10, 40)) };
                _context.Prices.Add(price);
            }

            _context.SaveChanges();
        }
    }
    }
