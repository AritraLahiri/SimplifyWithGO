﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimplifyWithGO.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public required string Name { get; set; }

        [Range(1, 10)]
        [Required]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }


    }
}
