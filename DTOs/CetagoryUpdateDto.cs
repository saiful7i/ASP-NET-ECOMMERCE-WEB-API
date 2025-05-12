using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace asp_net_ecommerce_web_api.DTOs
{
    public class CategoryUpdateDto
    {
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Category name Must be between 2 and 100 character long")]
        public string CategoryName { get; set; } = string.Empty;
        [StringLength(500, ErrorMessage = "Category description cannot exceed 500 characters.")]
        public string CategoryDescription { get; set; } =string.Empty;
    }
}