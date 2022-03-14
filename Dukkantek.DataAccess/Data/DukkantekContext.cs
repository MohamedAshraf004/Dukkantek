using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dukkantek.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Dukkantek.DataAccess.Data
{
    public class DukkantekContext : DbContext
    {
        public DukkantekContext(DbContextOptions<DukkantekContext> options):base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        #region Tracker Changes
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();
            var timestamp = DateTime.Now;
            var entities = ChangeTracker.Entries()
                .Where(r => r.State == EntityState.Added || r.State == EntityState.Modified);
            foreach (var entry in entities)
            {
                entry.Property("UpdateDate").CurrentValue = timestamp;
                if (entry.State == EntityState.Added)
                    entry.Property("InsertDate").CurrentValue = timestamp;
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<ProductCategory>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Order>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<OrderDetail>().HasQueryFilter(x => !x.IsDeleted);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(x => x.ProductCategory)
                    .WithMany(x => x.Products)
                    .HasForeignKey(x => x.CategoryId)
                    .OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasOne(x => x.Product)
                    .WithMany(x => x.OrderDetails)
                    .HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(x => x.Order)
                    .WithMany(x => x.OrderDetails)
                    .HasForeignKey(x => x.OrderId)
                    .OnDelete(DeleteBehavior.NoAction);

            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
