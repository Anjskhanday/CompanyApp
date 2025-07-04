﻿using System.ComponentModel.DataAnnotations;

namespace Company.DTO
{
    public class CategoryDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryCode { get; set; }

        [Required(ErrorMessage = "CompanyId is invalid.")]
        public int CompanyId { get; set; }
    }
}
