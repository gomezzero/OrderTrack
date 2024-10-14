using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderTrack.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace OrderTrack.Controllers.V1.Products
{
    [Route("api/v1/products")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("products")]
    public class ProductDeleteController(IProduct product) : ProductController(product)
    {
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletes a product by ID",
            Description = "Removes the specified product from the system."
        )]
        [SwaggerResponse(204, "The product was successfully deleted")]
        [SwaggerResponse(404, "If the product with the specified ID is not found")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var exists = await _product.CheckExistence(id);

            if (!exists)
            {
                return NotFound($"El Producto N°{id} no existe en la base de datos");
            }

            await _product.Delete(id);
            return Ok($"El Producto N°{id} fue eliminada");
        }
    }
}