namespace Eshop.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual List<Item> SoldItems { get; set; } = null!;
    }
}
