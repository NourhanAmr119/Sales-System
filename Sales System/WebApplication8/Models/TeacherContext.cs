using Microsoft.EntityFrameworkCore;

namespace WebApplication8.Models
{
    public class TeacherContext:DbContext
    {
        public TeacherContext(DbContextOptions<TeacherContext>options) :base(options)
        { 
        
        }
        public DbSet<Teacher> Teachers { get; set; }
        public object Teacher { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured) { }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
               .IsUnicode(false);

                entity.Property(e => e.Skills)
               .IsRequired()
               .HasMaxLength(250)
              .IsUnicode(false);

                entity.Property(e => e.Salary)
               .IsRequired()
              .HasColumnType("money");

                entity.Property(e => e.Addedon)
               .HasColumnType("date")
               .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Gender)
               .IsRequired()
               .HasMaxLength(50)
              .IsUnicode(false);


            });
        }
    }
}
