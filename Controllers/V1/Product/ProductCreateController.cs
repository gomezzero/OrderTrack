using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderTrack.DTOs;
using OrderTrack.Models;
using OrderTrack.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace OrderTrack.Controllers.V1.Products
{
    [Route("api/v1/products")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("products")]
    public class ProductCreateController(IProduct product) : ProductController(product)
    {
        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates a new Product",
            Description = "Adds a new Product to the system with the provided name and description."
        )]
        [SwaggerResponse(201, "The Product was successfully created", typeof(Product))]
        [SwaggerResponse(400, "If the Product data is invalid")]
        public async Task<ActionResult<Product>> Create([FromBody] ProductDTO inputProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newProduct = new Product(inputProduct.Name, inputProduct.Description, inputProduct.Stock, inputProduct.CategoryId);

            await _product.Add(newProduct);

            return Ok(newProduct);
        }
    }
}