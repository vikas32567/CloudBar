using Microsoft.EntityFrameworkCore;

namespace WebApp.Context
{
    public class CloudBarEfContext : DbContext
    {
        public CloudBarEfContext(DbContextOptions<CloudBarEfContext> options) : base(options)
        {
        }

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Spirit> Spirits { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOrder> UserOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drink>(entity => {
                entity.Property(d => d.OverheadCost).HasColumnType<double>("DECIMAL(10,2)");
            });

            modelBuilder.Entity<Order>(entity => {
                entity.Property(o => o.Price).HasColumnType<double>("DECIMAL(10,2)");
            });

            modelBuilder.Entity<OrderItem>(entity => {
                entity.Property(oi => oi.Price).HasColumnType<double>("DECIMAL(10,2)");
            });

            modelBuilder.Entity<Recipe>(entity => {
                entity.Property(r => r.Percentage).IsRequired();
            });

            modelBuilder.Entity<Spirit>(entity => {
                entity.Property(p => p.Price).HasColumnType<double>("DECIMAL(10,2)");
            });

            modelBuilder.Entity<User>(entity => {
                entity.Property(u => u.Email).IsRequired();
            });

            modelBuilder.Entity<UserOrder>(entity => {
                entity.Property(uo => uo.Created).HasDefaultValueSql("GETDATE()");
            });
        }
    }
}