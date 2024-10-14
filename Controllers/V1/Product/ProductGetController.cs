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

namespace OrderTrack.Controllers.V1.Products
{
    [Route("api/v1/products")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("products")]
    public class ProductGetController(IProduct product) : ProductController(product)
    {
        [HttpGet]
        [SwaggerOperation(
             Summary = "Retrieves all products",
             Description = "Returns a list of all products in the system."
         )]
        [SwaggerResponse(200, "A list of products", typeof(IEnumerable<Product>))]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _product.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Retrieves a Product by ID",
            Description = "Returns the Product details for the specified ID."
        )]
        [SwaggerResponse(200, "The Product with the specified ID", typeof(Product))]
        [SwaggerResponse(404, "If the Product with the specified ID is not found")]
        public async Task<ActionResult<Product>> GetById([FromRoute] int id)
        {
            var Product = await _product.GetById(id);

            if (Product == null)
            {
                return NotFound();
            }
            return Product;
        }
    }
}