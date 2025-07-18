namespace Eshop.Entities
{
    public class Price
    {
        public int Id { get; set; }
        public float Value { get; set; }
        public int ItemId { get; set; }
        public DateTime SetDate { get; set; }
        public virtual List<Item> Items { get; set; } = null!;
    }
}
