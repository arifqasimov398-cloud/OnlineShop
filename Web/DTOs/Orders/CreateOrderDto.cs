namespace Web.DTOs.Orders
{
    public class CreateOrderDto
    {
        public int BuyerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
