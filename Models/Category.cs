using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_net_ecommerce_web_api.Models
{
    public class Category{
        public Guid CategoryId{ get; set; }
        public string CategoryName{ get; set; } = string.Empty;
        public string? CategoryDescription{ get; set; } = string.Empty;
        public DateTime CreateAt{ get; set; }    
};
}