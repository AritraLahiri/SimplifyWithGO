using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fresh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PriceFor50 = table.Column<double>(type: "float", nullable: false),
                    PriceFor100 = table.Column<double>(type: "float", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 3, "Electronics" },
                    { 2, 1, "Clothing" },
                    { 3, 2, "Grocery" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryID", "Description", "ImageUrl", "ListPrice", "Name", "Price", "PriceFor100", "PriceFor50" },
                values: new object[,]
                {
                    { 1, 1, "Dell Inspiron 15 3000", "https://via.placeholder.com/150", 500.0, "Laptop", 450.0, 350.0, 400.0 },
                    { 2, 2, "Polo T-Shirt", "https://via.placeholder.com/150", 50.0, "T-Shirt", 40.0, 30.0, 35.0 },
                    { 3, 3, "Basmati Rice", "https://via.placeholder.com/150", 20.0, "Rice", 15.0, 5.0, 10.0 },
                    { 4, 1, "Samsung Galaxy S10", "https://via.placeholder.com/150", 800.0, "Mobile", 750.0, 650.0, 700.0 },
                    { 5, 2, "Levis Jeans", "https://via.placeholder.com/150", 60.0, "Jeans", 50.0, 30.0, 40.0 },
                    { 6, 3, "Whole Wheat", "https://via.placeholder.com/150", 10.0, "Wheat", 5.0, 3.0, 4.0 },
                    { 7, 1, "Formal Shirt", "https://via.placeholder.com/150", 30.0, "Shirt", 25.0, 15.0, 20.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryID",
                table: "Product",
                column: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
