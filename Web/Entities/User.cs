
namespace Web.Entities
{
    public class User:BaseEntity
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public UserRole Role { get; set; }
        public List<Store> Stores { get; set; }=new List<Store>();
        public List<Order> Orders { get; set; }= new List<Order>();
         
    }
}
