using Microsoft.EntityFrameworkCore;
using WebApplication8.Models;

namespace WebApplication8.Models
{
    public class Sales_context : DbContext
    {
        public Sales_context(DbContextOptions<Sales_context> options) : base(options)
        {
            Options = options;
        }
        public DbContextOptions<Sales_context> Options { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) { }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sales>(entity =>
            {
                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
               .IsUnicode(false);

                entity.Property(e => e.Supplier)
               .IsRequired()
               .HasMaxLength(250)
              .IsUnicode(false);

                entity.Property(e => e.Price)
               .IsRequired()
              .HasColumnType("money");

                entity.Property(e => e.Date_of_purchase)
               .HasColumnType("date")
               .HasDefaultValueSql("(getdate())");


            });
        }
        public DbSet<WebApplication8.Models.Sales> Sales { get; set; }
    }
}

