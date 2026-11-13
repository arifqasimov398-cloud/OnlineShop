namespace Web.DTOs.Stores
{
    public class CreateStoreDto
    {   
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int SellerId { get; set; }   
    }
}
