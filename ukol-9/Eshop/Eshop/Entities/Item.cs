namespace Eshop.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual List<Price> PriceList { get; set; } = null!;
        public virtual List<Customer> Customers { get; set; } = null!;
        public DateTime SoldDate { get; set; }
    }
}
