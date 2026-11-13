namespace Web.DTOs.Products
{
    public class ProductDto
    {
        public int  Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string StoreName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
    }
}
