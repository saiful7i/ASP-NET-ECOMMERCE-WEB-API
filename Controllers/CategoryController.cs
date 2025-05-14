using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_net_ecommerce_web_api.DTOs;
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
        public IActionResult GetCategories([FromQuery] string searchValue="")
        {
            
            // if(string.IsNullOrEmpty(searchValue)){
            //     var searchCategories = categories.Where(c => c.CategoryName.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
            //     return Ok(searchCategories);
            //     }

            var categoriesList= categories.Select(c=>new CategoryReadDto
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                CategoryDescription = c.CategoryDescription,
                CreateAt = c.CreateAt,
            }).ToList();
    
            return Ok(ApiResponse<List<CategoryReadDto>>.SuccessResponse(categoriesList,200,"Category Data Return Successful"));
        }


        //POST: /api/categories => Read Categories
        [HttpPost]//using fot post request 
        public IActionResult CreateCategories([FromBody] CategoryCreateDto categoryData)
        {
           
            var newCategory = new Category
            {
                CategoryId = Guid.NewGuid(),
                CategoryName=categoryData.CategoryName,
                CategoryDescription=categoryData.CategoryDescription,
                CreateAt = DateTime.UtcNow,
            };
            categories.Add(newCategory);

            var categoryReadDto = new CategoryReadDto
            {
                CategoryId = Guid.NewGuid(),
                CategoryName= newCategory.CategoryName,
                CategoryDescription = newCategory.CategoryDescription,
                CreateAt = newCategory.CreateAt 
            };

            return Created($"/api/categories/{newCategory.CategoryId}",ApiResponse<CategoryReadDto>.SuccessResponse(categoryReadDto,201,"Category Create Successful"));
        }

    //PUT: /api/categories/{categoryId} => Update a Categories
        [HttpPut("{categoryId:guid}")]
        public IActionResult UpdateByIdCategory(Guid categoryId,[FromBody] CategoryUpdateDto categoryData)
        {
            if (categoryData == null)
            {
                return BadRequest("Category date is missing");
            }

            var foundCategory = categories.FirstOrDefault(category => category.CategoryId == categoryId);

            if (foundCategory == null)
            {
                return NotFound("Category with this id does not exist.");
            }

            if(!string.IsNullOrEmpty(categoryData.CategoryName))
            {
                Console.WriteLine($"Condition have no Problem");
                
                if(categoryData.CategoryName.Length >= 2)
                {
                    foundCategory.CategoryName = categoryData.CategoryName;
                    
                }
                else
                {
                    return BadRequest("Category name must be atleast 2 character long");
                }
            }

            if(!string.IsNullOrWhiteSpace(categoryData.CategoryDescription))
            {
                foundCategory.CategoryDescription = categoryData.CategoryDescription;
            }

            return Ok(ApiResponse<object>.SuccessResponse(null,204,"Category Update Successful"));
        }

        
    //Delete: /api/categories/{categoryId} => Delete a Categories
        [HttpDelete("{categoryId:guid}")]
        public IActionResult DeleteByIdCategory(Guid categoryId)
        {
            var foundCategory = categories.FirstOrDefault(category => category.CategoryId == categoryId);
            if(foundCategory == null)
            {
            return NotFound("Category with this id does not exits");
            }
        categories.Remove(foundCategory);
        return Ok(ApiResponse<object>.SuccessResponse(null,204,"Category Deleted successfully"));

        }
        
    }
}