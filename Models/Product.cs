using SimplifyWithGO.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        [Display(Name = "Printed Price")]
        [Range(1, 100000, ErrorMessage = "Price should be between 1-100000")]
        public double ListPrice { get; set; }

        [Display(Name = "Listed Price")]
        [Range(1, 1000, ErrorMessage = "Price should be between 1-100000")]
        public double Price { get; set; }

        public double PriceFor50 { get; set; }

        public double PriceFor100 { get; set; }

        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category? Category { get; set; }

    }
}
