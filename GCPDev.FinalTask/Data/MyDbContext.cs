using GCPDev.FinalTask.Models;
using Microsoft.EntityFrameworkCore;

namespace GCPDev.FinalTask.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<WishModel> Wishes { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WishModel>(e => e.Property(o => o.Name).HasColumnType("nvarchar(100)").IsRequired());
            modelBuilder.Entity<WishModel>(e => e.Property(o => o.Description).HasColumnType("nvarchar(250)").IsRequired());
        }
    }
}
