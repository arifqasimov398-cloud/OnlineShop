namespace Web.DTOs.Products
{
    public class CreateProductDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int StoreId { get; set; }
        public int CategoryId { get; set; }
    }
}
