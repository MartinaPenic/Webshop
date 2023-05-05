using Microsoft.EntityFrameworkCore;
using Webshop.API.Models.Entities;

namespace Webshop.API.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductRatingEntity> Ratings { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<ShowcaseEntity> Showcases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>().Property(p => p.Price).HasPrecision(16, 3);
            modelBuilder.Entity<ProductEntity>().Property(p => p.CreatedAt).HasDefaultValueSql("getdate()");
        }
    }
}
