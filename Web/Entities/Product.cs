namespace Web.Entities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; } 
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

    }
}
