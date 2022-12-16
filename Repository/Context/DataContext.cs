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

            Guid[] GuidProductArr = { new Guid("997d3739-f810-48a2-9363-d5bcddde1a10"),
                                      new Guid("bba48c53-6c71-4924-98f1-f710d9baecf5"),
                                      new Guid("a6bea552-82df-4bd6-b372-df456969e59a"),
                                      new Guid("37ad541b-d101-46e6-89cf-07fe2848f3fa"),
                                      new Guid("438167bf-46cf-47b1-8ca8-307ff3299063") };

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
                    Id = GuidProductArr[0],
                    CreatedDate = DateTime.UtcNow,
                    Name = "Milk",
                    LinkImage = "https://craves.everybodyshops.com/wp-content/uploads/ThinkstockPhotos-535489242-1024x683@2x.jpg"
                },

                new ProductEntity
                {
                    Id = GuidProductArr[1],
                    CreatedDate = DateTime.UtcNow,
                    Name = "Bread",
                    LinkImage = "https://www.expatica.com/app/uploads/sites/2/2014/05/bread.jpg"
                },

                new ProductEntity
                {
                    Id = GuidProductArr[2],
                    CreatedDate = DateTime.UtcNow,
                    Name = "Juice",
                    LinkImage = "https://images5.alphacoders.com/102/1022723.jpg"
                },

                new ProductEntity
                {
                    Id = GuidProductArr[3],
                    CreatedDate = DateTime.UtcNow,
                    Name = "Cheese",
                    LinkImage = "https://pm1.narvii.com/6810/05dbd7aaebf3454313b99edfd566b06356a59be3v2_hq.jpg"
                },

                new ProductEntity
                {
                    Id = GuidProductArr[4],
                    CreatedDate = DateTime.UtcNow,
                    Name = "Egg",
                    LinkImage = "https://g.foolcdn.com/image/?url=https%3A//g.foolcdn.com/editorial/images/218648/eggs-brown-getty_BSCxkDW.jpg&w=2000&op=resize"
                });

            modelBuilder.Entity<FridgeProductEntity>().HasData(
               new FridgeProductEntity
               {
                   Id = Guid.NewGuid(),
                   CreatedDate = DateTime.UtcNow,
                   FridgeId = GuidFridgeArr[0],
                   ProductId = GuidProductArr[0],
                   ProductCount = 100
               });

            modelBuilder.Entity<FridgeProductEntity>().HasData(
               new FridgeProductEntity
               {
                   Id = Guid.NewGuid(),
                   CreatedDate = DateTime.UtcNow,
                   FridgeId = GuidFridgeArr[0],
                   ProductId = GuidProductArr[3],
                   ProductCount = 100
               });

            modelBuilder.Entity<FridgeProductEntity>().HasData(
               new FridgeProductEntity
               {
                   Id = Guid.NewGuid(),
                   CreatedDate = DateTime.UtcNow,
                   FridgeId = GuidFridgeArr[1],
                   ProductId = GuidProductArr[4],
                   ProductCount = 30
               });

            modelBuilder.Entity<FridgeProductEntity>().HasData(
               new FridgeProductEntity
               {
                   Id = Guid.NewGuid(),
                   CreatedDate = DateTime.UtcNow,
                   FridgeId = GuidFridgeArr[1],
                   ProductId = GuidProductArr[2],
                   ProductCount = 123
               });

            modelBuilder.Entity<FridgeProductEntity>().HasData(
               new FridgeProductEntity
               {
                   Id = Guid.NewGuid(),
                   CreatedDate = DateTime.UtcNow,
                   FridgeId = GuidFridgeArr[2],
                   ProductId = GuidProductArr[0],
                   ProductCount = 23
               });

            modelBuilder.Entity<FridgeProductEntity>().HasData(
               new FridgeProductEntity
               {
                   Id = Guid.NewGuid(),
                   CreatedDate = DateTime.UtcNow,
                   FridgeId = GuidFridgeArr[2],
                   ProductId = GuidProductArr[1],
                   ProductCount = 454
               });

            modelBuilder.Entity<FridgeProductEntity>().HasData(
               new FridgeProductEntity
               {
                   Id = Guid.NewGuid(),
                   CreatedDate = DateTime.UtcNow,
                   FridgeId = GuidFridgeArr[2],
                   ProductId = GuidProductArr[4],
                   ProductCount = 10
               });
        }
    }
}
