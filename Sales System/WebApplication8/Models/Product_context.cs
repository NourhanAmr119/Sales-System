using Microsoft.EntityFrameworkCore;
using WebApplication8.Models;

namespace WebApplication8.Models
{
    public class Product_context : DbContext
    {
        public Product_context(DbContextOptions<Product_context> options) : base(options)
        {
            Options = options;
        }
        public DbContextOptions<Product_context> Options { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) { }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
               .IsUnicode(false);

                entity.Property(e => e.Type)
               .IsRequired()
               .HasMaxLength(100)
              .IsUnicode(false);

                entity.Property(e => e.Price)
               .IsRequired()
              .HasColumnType("money");

                

            });
        }
        public DbSet<WebApplication8.Models.Product> Product { get; set; }
    }
}
        

