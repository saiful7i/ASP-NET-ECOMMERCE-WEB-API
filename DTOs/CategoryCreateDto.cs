using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_net_ecommerce_web_api.DTOs
{
    public class CategoryCreateDto
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set;}  = string.Empty;
        
    }
}