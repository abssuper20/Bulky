﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BulkyWeb_Razor.Models
{
    public class Category
    {
        public int Id { get; set; }
        [DisplayName("Category Name"), MaxLength(30)]
        public string Name { get; set; }
        [DisplayName("Display Order"), Range(1, 100, ErrorMessage = "Display order must be between values 1-100")]
        public int DisplayOrder { get; set; }
    }
}
