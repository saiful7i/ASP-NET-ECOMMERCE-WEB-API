using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_net_ecommerce_web_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp_net_ecommerce_web_api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController:ControllerBase
    {
        private static List<Category> categories = new List<Category>();

        //GET: /api/categories => Read Categories
        [HttpGet]//using fot get request 
        public IActionResult GetCategories([FromQuery] string searchValue=""){
            
            if(!string.IsNullOrEmpty(searchValue)){
                Console.WriteLine($"{searchValue}");
                var searchCategories = categories.Where(c => c.CategoryName.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
                return Ok(searchCategories);
                }
    
            return Ok(categories);
        }

        //POST: /api/categories => Read Categories
        [HttpGet]//using fot get request 
        public IActionResult GetCategories([FromQuery] string searchValue=""){
            
            if(!string.IsNullOrEmpty(searchValue)){
                Console.WriteLine($"{searchValue}");
                var searchCategories = categories.Where(c => c.CategoryName.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
                return Ok(searchCategories);
                }
    
            return Ok(categories);
        }
                
    }
}