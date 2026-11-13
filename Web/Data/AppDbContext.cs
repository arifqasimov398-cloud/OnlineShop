namespace Web.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; } 
        public DbSet<Product> Products { get; set; }
        public DbSet <Store>Stores { get; set; }
        protected override void OnModelCreating(ModelBuilder mdb)
        {
            mdb.Entity<Store>()
                .HasOne(s => s.Seller)
                .WithMany(u => u.Stores)
                .HasForeignKey(s => s.SellerId)
                .OnDelete(DeleteBehavior.Restrict);
            mdb.Entity<Product>(e=> 
            {
                e.Property(e => e.Name).HasMaxLength(256).IsRequired();
                
                e.Property(e => e.Price).HasColumnType("decimal(18,2)").IsRequired();

                e.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            mdb.Entity<Order>(O=>
            {
                O.Property(O=> O.TotalPrice).HasColumnType("decimal(18,2)").IsRequired();
                
                O.HasOne(o => o.Buyer)
                    .WithMany(u => u.Orders)
                    .HasForeignKey(o => o.BuyerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            
        }
    }
}
