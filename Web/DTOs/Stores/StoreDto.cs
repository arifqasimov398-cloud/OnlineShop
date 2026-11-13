namespace Web.DTOs.Stores
{
    public class StoreDto
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string SellerName { get; set; } = string.Empty;
    }
}
