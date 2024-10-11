using Microsoft.AspNetCore.Mvc;
using OrderTrack.DTOs;
using OrderTrack.Models;
using OrderTrack.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace OrderTrack.Controllers.V1.Categorys
{
    [Route("api/v1/categories")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("categories")]
    public class CategoryCreateController(ICategory category) : CategoryController(category)
    {
        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates a new category",
            Description = "Adds a new category to the system with the provided name and description."
        )]
        [SwaggerResponse(201, "The category was successfully created", typeof(Category))]
        [SwaggerResponse(400, "If the category data is invalid")]
        public async Task<ActionResult<Category>> Create([FromBody] CategoryDTO inputCategory)
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