﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimplifyWithGO.DataContext;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 3,
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 1,
                            Name = "Clothing"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 2,
                            Name = "Grocery"
                        });
                });

            modelBuilder.Entity("Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("PriceFor100")
                        .HasColumnType("float");

                    b.Property<double>("PriceFor50")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryID = 1,
                            Description = "Dell Inspiron 15 3000",
                            ImageUrl = "https://via.placeholder.com/150",
                            ListPrice = 500.0,
                            Name = "Laptop",
                            Price = 450.0,
                            PriceFor100 = 350.0,
                            PriceFor50 = 400.0
                        },
                        new
                        {
                            Id = 2,
                            CategoryID = 2,
                            Description = "Polo T-Shirt",
                            ImageUrl = "https://via.placeholder.com/150",
                            ListPrice = 50.0,
                            Name = "T-Shirt",
                            Price = 40.0,
                            PriceFor100 = 30.0,
                            PriceFor50 = 35.0
                        },
                        new
                        {
                            Id = 3,
                            CategoryID = 3,
                            Description = "Basmati Rice",
                            ImageUrl = "https://via.placeholder.com/150",
                            ListPrice = 20.0,
                            Name = "Rice",
                            Price = 15.0,
                            PriceFor100 = 5.0,
                            PriceFor50 = 10.0
                        },
                        new
                        {
                            Id = 4,
                            CategoryID = 1,
                            Description = "Samsung Galaxy S10",
                            ImageUrl = "https://via.placeholder.com/150",
                            ListPrice = 800.0,
                            Name = "Mobile",
                            Price = 750.0,
                            PriceFor100 = 650.0,
                            PriceFor50 = 700.0
                        },
                        new
                        {
                            Id = 5,
                            CategoryID = 2,
                            Description = "Levis Jeans",
                            ImageUrl = "https://via.placeholder.com/150",
                            ListPrice = 60.0,
                            Name = "Jeans",
                            Price = 50.0,
                            PriceFor100 = 30.0,
                            PriceFor50 = 40.0
                        },
                        new
                        {
                            Id = 6,
                            CategoryID = 3,
                            Description = "Whole Wheat",
                            ImageUrl = "https://via.placeholder.com/150",
                            ListPrice = 10.0,
                            Name = "Wheat",
                            Price = 5.0,
                            PriceFor100 = 3.0,
                            PriceFor50 = 4.0
                        },
                        new
                        {
                            Id = 7,
                            CategoryID = 1,
                            Description = "Formal Shirt",
                            ImageUrl = "https://via.placeholder.com/150",
                            ListPrice = 30.0,
                            Name = "Shirt",
                            Price = 25.0,
                            PriceFor100 = 15.0,
                            PriceFor50 = 20.0
                        });
                });

            modelBuilder.Entity("Models.Product", b =>
                {
                    b.HasOne("Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
