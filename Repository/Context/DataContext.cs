using Microsoft.EntityFrameworkCore;
using Repositories.Entities;

namespace Repositories.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            Database.EnsureCreated();
        }

        public DbSet<FridgeEntity> Fridges { get; set; } = default!;
        public DbSet<ModelEntity> Models { get; set; } = default!;
        public DbSet<ProductEntity> Products { get; set; } = default!;
        public DbSet<FridgeProductEntity> FridgeProducts { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Local variables
            Guid[] GuidModelArr = { Guid.NewGuid(),
                                    Guid.NewGuid() };

            Guid[] GuidFridgeArr = { Guid.NewGuid(),
                                     Guid.NewGuid(),
                                     Guid.NewGuid() };

            // Set main settings for entities
            modelBuilder.Entity<ModelEntity>(
                entity =>
                {
                    entity.Property(e => e.Id)
                          .IsRequired();
                });

            modelBuilder.Entity<FridgeEntity>(
               entity =>
               {
                   entity.Property(e => e.Id)
                         .IsRequired();

                   entity.HasOne(m => m.Model)
                         .WithMany(f => f.Fridges)
                         .HasForeignKey(m => m.ModelId);

                   entity.HasMany(p => p.Products)
                         .WithMany(f => f.Fridges)
                         .UsingEntity<FridgeProductEntity>(
                       j => j
                           .HasOne(p => p.Product)
                           .WithMany(fp => fp.FridgeProducts)
                           .HasForeignKey(p => p.ProductId),
                       j => j
                           .HasOne(f => f.Fridge)
                           .WithMany(fp => fp.FridgeProducts)
                           .HasForeignKey(f => f.FridgeId),
                       j =>
                       {
                           j.Property(fp => fp.ProductCount).HasDefaultValue(0);
                           j.HasKey(t => new { t.FridgeId, t.ProductId });
                           j.ToTable("FridgeProduct");
                       });
               });

            modelBuilder.Entity<ProductEntity>(
            entity =>
            {
                entity.Property(e => e.Id)
                        .IsRequired();

                entity.HasIndex(n => n.Name)
                        .IsUnique();
            }); 

            modelBuilder.Entity<FridgeProductEntity>(
                entity =>
                {
                    entity.Property(e => e.Id)
                          .IsRequired();
                });

            // SEEDDATA
            modelBuilder.Entity<FridgeEntity>().HasData(
                new FridgeEntity
                {
                    Id = GuidFridgeArr[0],
                    ModelId = GuidModelArr[0],
                    CreatedDate = DateTime.UtcNow,
                    Manufacturer = "LG",
                    OwnerName = "Alex"
                },

                new FridgeEntity
                {
                    Id = GuidFridgeArr[1],
                    ModelId = GuidModelArr[1],
                    CreatedDate = DateTime.UtcNow,
                    Manufacturer = "Samsung",
                    OwnerName = "Martin"
                },

                new FridgeEntity
                {
                    Id = GuidFridgeArr[2],
                    ModelId = GuidModelArr[1],
                    CreatedDate = DateTime.UtcNow,
                    Manufacturer = "Atlant",
                    OwnerName = "Espio"
                });

            modelBuilder.Entity<ModelEntity>().HasData(
                new ModelEntity
                {
                    Id = GuidModelArr[0],
                    CreatedDate = DateTime.UtcNow,
                    Name = "RT-700",
                    ProductionYear = 2019
                },

                new ModelEntity
                {
                    Id = GuidModelArr[1],
                    CreatedDate = DateTime.UtcNow,
                    Name = "HG50",
                    ProductionYear = 2010
                });

            modelBuilder.Entity<ProductEntity>().HasData(

                new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.UtcNow,
                    Name = "Milk",
                    LinkImage = "https://craves.everybodyshops.com/wp-content/uploads/ThinkstockPhotos-535489242-1024x683@2x.jpg"
                },

                new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.UtcNow,
                    Name = "Bread",
                    LinkImage = "https://www.expatica.com/app/uploads/sites/2/2014/05/bread.jpg"
                },

                new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.UtcNow,
                    Name = "Juice",
                    LinkImage = "https://images5.alphacoders.com/102/1022723.jpg"
                },

                new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.UtcNow,
                    Name = "Cheese",
                    LinkImage = "https://pm1.narvii.com/6810/05dbd7aaebf3454313b99edfd566b06356a59be3v2_hq.jpg"
                },

                new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.UtcNow,
                    Name = "Egg",
                    LinkImage = "https://g.foolcdn.com/image/?url=https%3A//g.foolcdn.com/editorial/images/218648/eggs-brown-getty_BSCxkDW.jpg&w=2000&op=resize"
                });
        }
    }
}
