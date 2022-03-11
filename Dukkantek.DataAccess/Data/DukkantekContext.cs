using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryProduct> InventoryProducts { get; set; }

        #region Tracker Changes
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();
            var timestamp = DateTime.Now;
            var entities = ChangeTracker.Entries().Where(r =>
                (r.State == EntityState.Added || r.State == EntityState.Modified));
            foreach (var entry in entities)
            {
                entry.Property("UpdateDate").CurrentValue = timestamp;

                if (entry.State == EntityState.Added)
                {
                    entry.Property("InsertDate").CurrentValue = timestamp;
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<InventoryProduct>(entity =>
            {
                entity.HasOne<Product>(x => x.Product)
                    .WithMany(x => x.ProductInventories)
                    .HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne<Inventory>(x => x.Inventory)
                    .WithMany(x => x.InventoryProducts)
                    .HasForeignKey(x=>x.InventoryId)
                    .OnDelete(DeleteBehavior.NoAction);
               
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne<ProductCategory>(x => x.ProductCategory)
                    .WithMany(x => x.Products)
                    .HasForeignKey(x => x.CategoryId)
                    .OnDelete(DeleteBehavior.NoAction);

            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
