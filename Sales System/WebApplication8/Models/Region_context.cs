using Microsoft.EntityFrameworkCore;
using WebApplication8.Models;

namespace WebApplication8.Models
{
    public class Region_context : DbContext
    {
        public Region_context(DbContextOptions<Region_context> options) : base(options)
        {
            Options = options;
        }
        public DbContextOptions<Region_context> Options { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) { }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
               .IsUnicode(false);

                entity.Property(e => e.Description)
               .IsRequired()
               .HasMaxLength(100)
              .IsUnicode(false);




            });
        }
        public DbSet<WebApplication8.Models.Region> Region { get; set; }
    }
}
