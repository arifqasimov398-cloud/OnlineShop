namespace Web.DTOs.Orders
{
    public class OrderDto
    {
        public int Id { get; set; } 
        public string BuyerName { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
