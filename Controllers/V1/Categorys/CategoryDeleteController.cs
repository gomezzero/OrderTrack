using Microsoft.AspNetCore.Mvc;
using OrderTrack.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace OrderTrack.Controllers.V1.Categorys
{
    [Route("api/v1/categories")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("categories")]
    public class CategoryDeleteController(ICategory category) : CategoryController(category)
    {
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletes a category by ID",
            Description = "Removes the specified category from the system."
        )]
        [SwaggerResponse(204, "The category was successfully deleted")]
        [SwaggerResponse(404, "If the category with the specified ID is not found")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var exists = await _category.CheckExistence(id);

            if (!exists)
            {
                return NotFound();
            }

            await _category.Delete(id);
            return NoContent();
        }
    }
}