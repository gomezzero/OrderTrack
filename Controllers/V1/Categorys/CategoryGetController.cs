using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderTrack.Models;
using OrderTrack.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace OrderTrack.Controllers.V1.Categorys
{
    [Route("api/v1/categories")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("categories")]
    public class CategoryGetController(ICategory category) : CategoryController(category)
    {
        [HttpGet]
        [SwaggerOperation(
            Summary = "Retrieves all categories",
            Description = "Returns a list of all categories in the system."
        )]
        [SwaggerResponse(200, "A list of categories", typeof(IEnumerable<Category>))]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            var categories = await _category.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Retrieves a category by ID",
            Description = "Returns the category details for the specified ID."
        )]
        [SwaggerResponse(200, "The category with the specified ID", typeof(Category))]
        [SwaggerResponse(404, "If the category with the specified ID is not found")]
        public async Task<ActionResult<Category>> GetById([FromRoute] int id)
        {
            var category = await _category.GetById(id);

            if (category == null)
            {
                return NotFound();
            }
            return category;
        }
    }
}