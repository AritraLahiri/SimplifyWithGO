using Microsoft.EntityFrameworkCore;
using Models;
using SimplifyWithGO.Models;


namespace SimplifyWithGO.DataContext
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        // Category Table
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Electronics",
                    DisplayOrder = 3
                },
                new Category
                {
                    Id = 2,
                    Name = "Clothing",
                    DisplayOrder = 1
                },
                new Category
                {
                    Id = 3,
                    Name = "Grocery",
                    DisplayOrder = 2
                }
            );

            modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        Id = 1,
                        Name = "Laptop",
                        Description = "Dell Inspiron 15 3000",
                        ImageUrl = "https://via.placeholder.com/150",
                        ListPrice = 500,
                        Price = 450,
                        PriceFor50 = 400,
                        PriceFor100 = 350,
                        CategoryID = 1
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "T-Shirt",
                        Description = "Polo T-Shirt",
                        ImageUrl = "https://via.placeholder.com/150",
                        ListPrice = 50,
                        Price = 40,
                        PriceFor50 = 35,
                        PriceFor100 = 30,
                        CategoryID = 2
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Rice",
                        Description = "Basmati Rice",
                        ImageUrl = "https://via.placeholder.com/150",
                        ListPrice = 20,
                        Price = 15,
                        PriceFor50 = 10,
                        PriceFor100 = 5,
                        CategoryID = 3
                    },
                    new Product
                    {
                        Id = 4,
                        Name = "Mobile",
                        Description = "Samsung Galaxy S10",
                        ImageUrl = "https://via.placeholder.com/150",
                        ListPrice = 800,
                        Price = 750,
                        PriceFor50 = 700,
                        PriceFor100 = 650,
                        CategoryID = 1
                    }
                    ,

                    new Product
                    {
                        Id = 5,
                        Name = "Jeans",
                        Description = "Levis Jeans",
                        ImageUrl = "https://via.placeholder.com/150",
                        ListPrice = 60,
                        Price = 50,
                        PriceFor50 = 40,
                        PriceFor100 = 30,
                        CategoryID = 2
                    },
                    new Product
                    {
                        Id = 6,
                        Name = "Wheat",
                        Description = "Whole Wheat",
                        ImageUrl = "https://via.placeholder.com/150",
                        ListPrice = 10,
                        Price = 5,
                        PriceFor50 = 4,
                        PriceFor100 = 3,
                        CategoryID = 3
                    },
                    new Product
                    {
                        Id = 7,
                        Name = "Shirt",
                        Description = "Formal Shirt",
                        ImageUrl = "https://via.placeholder.com/150",
                        ListPrice = 30,
                        Price = 25,
                        PriceFor50 = 20,
                        PriceFor100 = 15,
                        CategoryID = 1
                    }
                );
        }


    }
}
