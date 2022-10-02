﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories.Context;

#nullable disable

namespace FridgeMicroservice.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Repositories.Entities.FridgeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Fridges");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3c165161-00eb-4e3d-8201-3f9f246f1a60"),
                            CreatedDate = new DateTime(2022, 10, 2, 10, 19, 45, 69, DateTimeKind.Utc).AddTicks(5472),
                            Manufacturer = "LG",
                            ModelId = new Guid("f45af848-0446-4887-988a-91c085e8752d"),
                            OwnerName = "Alex"
                        },
                        new
                        {
                            Id = new Guid("cf0b48dc-e3ab-45cb-8df3-899241c43dab"),
                            CreatedDate = new DateTime(2022, 10, 2, 10, 19, 45, 69, DateTimeKind.Utc).AddTicks(5475),
                            Manufacturer = "Samsung",
                            ModelId = new Guid("418f528e-bd47-4e38-8ea6-7061ae5c3730"),
                            OwnerName = "Martin"
                        },
                        new
                        {
                            Id = new Guid("06aa3d8f-2035-40fe-a1f8-cb8bae493669"),
                            CreatedDate = new DateTime(2022, 10, 2, 10, 19, 45, 69, DateTimeKind.Utc).AddTicks(5476),
                            Manufacturer = "Atlant",
                            ModelId = new Guid("418f528e-bd47-4e38-8ea6-7061ae5c3730"),
                            OwnerName = "Espio"
                        });
                });

            modelBuilder.Entity("Repositories.Entities.FridgeProductEntity", b =>
                {
                    b.Property<Guid>("FridgeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ProductCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("FridgeId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("FridgeProduct", (string)null);
                });

            modelBuilder.Entity("Repositories.Entities.ModelEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductionYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Models");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f45af848-0446-4887-988a-91c085e8752d"),
                            CreatedDate = new DateTime(2022, 10, 2, 10, 19, 45, 69, DateTimeKind.Utc).AddTicks(5543),
                            Name = "RT-700",
                            ProductionYear = 2019
                        },
                        new
                        {
                            Id = new Guid("418f528e-bd47-4e38-8ea6-7061ae5c3730"),
                            CreatedDate = new DateTime(2022, 10, 2, 10, 19, 45, 69, DateTimeKind.Utc).AddTicks(5545),
                            Name = "HG50",
                            ProductionYear = 2010
                        });
                });

            modelBuilder.Entity("Repositories.Entities.ProductEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LinkImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1a9bc728-9ff9-4388-95d0-ca0984d780dc"),
                            CreatedDate = new DateTime(2022, 10, 2, 10, 19, 45, 69, DateTimeKind.Utc).AddTicks(5749),
                            LinkImage = "https://craves.everybodyshops.com/wp-content/uploads/ThinkstockPhotos-535489242-1024x683@2x.jpg",
                            Name = "Milk"
                        },
                        new
                        {
                            Id = new Guid("54d223dc-f4f7-4bda-9d64-e412bde218e6"),
                            CreatedDate = new DateTime(2022, 10, 2, 10, 19, 45, 69, DateTimeKind.Utc).AddTicks(5750),
                            LinkImage = "https://www.expatica.com/app/uploads/sites/2/2014/05/bread.jpg",
                            Name = "Bread"
                        },
                        new
                        {
                            Id = new Guid("3dfaa31a-3bc9-415b-ae2d-d7ca7335df49"),
                            CreatedDate = new DateTime(2022, 10, 2, 10, 19, 45, 69, DateTimeKind.Utc).AddTicks(5756),
                            LinkImage = "https://images5.alphacoders.com/102/1022723.jpg",
                            Name = "Juice"
                        },
                        new
                        {
                            Id = new Guid("17f4a9f2-6f80-4dad-951a-c4c446c08989"),
                            CreatedDate = new DateTime(2022, 10, 2, 10, 19, 45, 69, DateTimeKind.Utc).AddTicks(5757),
                            LinkImage = "https://pm1.narvii.com/6810/05dbd7aaebf3454313b99edfd566b06356a59be3v2_hq.jpg",
                            Name = "Cheese"
                        },
                        new
                        {
                            Id = new Guid("ef1e53a0-08b5-44b6-a986-5198e52d801e"),
                            CreatedDate = new DateTime(2022, 10, 2, 10, 19, 45, 69, DateTimeKind.Utc).AddTicks(5758),
                            LinkImage = "https://g.foolcdn.com/image/?url=https%3A//g.foolcdn.com/editorial/images/218648/eggs-brown-getty_BSCxkDW.jpg&w=2000&op=resize",
                            Name = "Egg"
                        });
                });

            modelBuilder.Entity("Repositories.Entities.FridgeEntity", b =>
                {
                    b.HasOne("Repositories.Entities.ModelEntity", "Model")
                        .WithMany("Fridges")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Repositories.Entities.FridgeProductEntity", b =>
                {
                    b.HasOne("Repositories.Entities.FridgeEntity", "Fridge")
                        .WithMany("FridgeProducts")
                        .HasForeignKey("FridgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repositories.Entities.ProductEntity", "Product")
                        .WithMany("FridgeProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fridge");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Repositories.Entities.FridgeEntity", b =>
                {
                    b.Navigation("FridgeProducts");
                });

            modelBuilder.Entity("Repositories.Entities.ModelEntity", b =>
                {
                    b.Navigation("Fridges");
                });

            modelBuilder.Entity("Repositories.Entities.ProductEntity", b =>
                {
                    b.Navigation("FridgeProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
