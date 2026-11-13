namespace Web.Entities
{
    public class Store:BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int SellerId { get; set; }
        public User Seller { get; set; } = null;
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
