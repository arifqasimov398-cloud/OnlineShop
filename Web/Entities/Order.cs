namespace Web.Entities
{
    public class Order:BaseEntity
    {
        public int BuyerId { get; set; }
        public  User Buyer { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }   
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        
    }
}
