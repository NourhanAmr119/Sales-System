using Microsoft.EntityFrameworkCore;
using System;
using WebApplication8.Models;

namespace WebApplication8.Models
{
    public class Order_context : DbContext
    {
        public Order_context(DbContextOptions<Order_context> options) : base(options)
        {

        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) { }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Customer_Name)
                .IsRequired()
                .HasMaxLength(50)
               .IsUnicode(false);

                entity.Property(e => e.Order_Number)
               .IsRequired();
       

                entity.Property(e => e.Price)
               .IsRequired()
              .HasColumnType("money");

                entity.Property(e => e.Payment_Strategy)
               .IsRequired()
               .HasMaxLength(50)
              .IsUnicode(false);
                entity.Property(e => e.Store_Name)
               .IsRequired()
               .HasMaxLength(50)
              .IsUnicode(false);
                entity.Property(e => e.Product_Name)
             .IsRequired()
             .HasMaxLength(50)
            .IsUnicode(false);

            });
        }
        public DbSet<WebApplication8.Models.Order> Order { get; set; }

        public static implicit operator Order_context(Store_context v)
        {
            throw new NotImplementedException();
        }
    }
}
