using Microsoft.AspNetCore.Mvc;
using OrderTrack.DTOs;
using OrderTrack.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace OrderTrack.Controllers.V1.Categorys
{
    [Route("api/v1/categories")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("categories")]
    public class CategoryUpdateClass(ICategory category) : CategoryController(category)
    {
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Updates an existing category",
            Description = "Updates the category with the specified ID, if it exists, with the provided new details."
        )]
        [SwaggerResponse(204, "The category was successfully updated")]
        [SwaggerResponse(400, "If the provided category data is invalid")]
        [SwaggerResponse(404, "If the category with the specified ID is not found")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CategoryDTO updateCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var checkCategory = await _category.CheckExistence(id);

            if (!checkCategory)
            {
                return NotFound($"la categoria N°{id} no existe en la base de datos");
            }

            var category = await _category.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            category.Name = updateCategory.Name;
            category.Description = updateCategory.Description;

            await _category.Update(category);
            return NoContent();
        }
    }
}