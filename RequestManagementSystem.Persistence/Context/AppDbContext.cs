using Microsoft.EntityFrameworkCore;
using RequestManagementSystem.Domain.Entities;
using RequestManagementSystem.Persistence.Context.SeedData;

namespace RequestManagementSystem.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=RequestManagementSystem;Username=postgres;Password=nigaR123");
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCategory>().HasKey(src => new { src.CategoryId, src.UserId });

            modelBuilder.Entity<Request>()
                .HasOne(r => r.CreateUser)
                .WithMany(u => u.CreatedRequests)
                .HasForeignKey(r => r.CreateUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Request>()
                .HasOne(r => r.ExecutorUser)
                .WithMany(u => u.ExecutedRequests)
                .HasForeignKey(r => r.ExecutorUserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Seeder();
        }
    }
}
