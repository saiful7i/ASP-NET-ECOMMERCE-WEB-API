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
            
            if(string.IsNullOrEmpty(searchValue)){
                var searchCategories = categories.Where(c => c.CategoryName.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
                return Ok(searchCategories);
                }
    
            return Ok(categories);
        }


        //POST: /api/categories => Read Categories
        [HttpPost]//using fot post request 
        public IActionResult CreateCategories([FromBody] Category categoryData){
            if(string.IsNullOrEmpty(categoryData.CategoryName)){
                return BadRequest("Category Name is required and can not be empty");
            }
            if(categoryData.CategoryName.Length < 2){
                return BadRequest("Category name must be atleast 2 characters long");
            }
            
            var newCategory = new Category{
                CategoryId = Guid.NewGuid(),
                CategoryName=categoryData.CategoryName,
                CategoryDescription=categoryData.CategoryDescription,
                CreateAt = DateTime.UtcNow,
        };
        categories.Add(newCategory);
        return Created($"/api/categories/{newCategory.CategoryId}",newCategory);
        }

    //Delete: /api/categories/{categoryId} => Delete a Categories
        [HttpDelete("{categoryId:guid}")]
        public IActionResult DeleteByIdCategory(Guid categoryId){
            var foundCategory = categories.FirstOrDefault(category => category.CategoryId == categoryId);
            if(foundCategory == null){
            return NotFound("Category with this id does not exits");
            }
        categories.Remove(foundCategory);
        return NoContent();

        }

    //PUT: /api/categories/{categoryId} => Update a Categories
        [HttpPut("{categoryId:guid}")]
        public IActionResult UpdateByIdCategory(Guid categoryId,[FromBody] Category categoryData){
            if (categoryData == null){
                return BadRequest("Category date is missing");
            }

            var foundCategory = categories.FirstOrDefault(category => category.CategoryId == categoryId);

            if (foundCategory == null){
                return NotFound("Category with this id does not exist.");
            }

            if(!string.IsNullOrEmpty(categoryData.CategoryName)){
                Console.WriteLine($"Condition have no Problem");
                
                if(categoryData.CategoryName.Length >= 2){
                    foundCategory.CategoryName = categoryData.CategoryName;
                    
                }
                else{
                    return BadRequest("Category name must be atleast 2 character long");
                }
            }

            if(!string.IsNullOrWhiteSpace(categoryData.CategoryDescription)){
                foundCategory.CategoryDescription = categoryData.CategoryDescription;
            }

            return NoContent();
        }        
    }
}