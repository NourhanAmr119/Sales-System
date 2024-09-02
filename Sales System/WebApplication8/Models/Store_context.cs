using Microsoft.EntityFrameworkCore;
using WebApplication8.Models;

namespace WebApplication8.Models
{
    public class Store_context:DbContext
    {
        public Store_context(DbContextOptions<Store_context> options) : base(options)
        {

        }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured) { }
            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Store>(entity =>
                {
                    entity.Property(e => e.Store_Name)
                    .IsRequired()
                    .HasMaxLength(150)
                   .IsUnicode(false);

                    entity.Property(e => e.Region)
                   .IsRequired()
                   .HasMaxLength(250)
                  .IsUnicode(false);

                    entity.Property(e => e.Revenue)
                   .IsRequired()
                  .HasColumnType("money");
                    entity.Property(e => e.Product_Name)
                   .IsRequired()
                   .HasMaxLength(150)
                  .IsUnicode(false);


                });
            }
            public DbSet<WebApplication8.Models.Store> Store { get; set; }
        }
    }

