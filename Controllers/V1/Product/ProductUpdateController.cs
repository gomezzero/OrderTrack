using Microsoft.AspNetCore.Mvc;
using OrderTrack.DTOs;
using OrderTrack.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace OrderTrack.Controllers.V1.Products
{
    [Route("api/v1/products")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("products")]
    public class ProductUpdateController(IProduct product) : ProductController(product)
    {
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Updates an existing Product",
            Description = "Updates the Product with the specified ID, if it exists, with the provided new details."
        )]
        [SwaggerResponse(204, "The Product was successfully updated")]
        [SwaggerResponse(400, "If the provided Product data is invalid")]
        [SwaggerResponse(404, "If the Product with the specified ID is not found")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductDTO updateProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var checkProduct = await _product.CheckExistence(id);

            if (!checkProduct)
            {
                return NotFound($"el Producto N°{id} no existe en la base de datos");
            }

            var Product = await _product.GetById(id);

            if (Product == null)
            {
                return NotFound();
            }

            Product.Name = updateProduct.Name;
            Product.Description = updateProduct.Description;
            Product.Stock = updateProduct.Stock;
            Product.CategoryId = updateProduct.CategoryId;

            await _product.Update(Product);
            return NoContent();
        }
    }
}