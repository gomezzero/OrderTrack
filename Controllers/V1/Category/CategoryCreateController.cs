using Microsoft.AspNetCore.Mvc;
using OrderTrack.DTOs;
using OrderTrack.Models;
using OrderTrack.Repositories;

namespace OrderTrack.Controllers.V1.Categorys
{
    [Route("api/v1/categorys")]
    public class CategoryCreateController(ICategory category) : CategoryController(category)
    {
        [HttpPost]
        public async Task<ActionResult<Category>> Create(CategoryDTO inputCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCategory = new Category(inputCategory.Name, inputCategory.Description);

            await _category.Add(newCategory);
        
            return Ok(newCategory);
        }
    }
}