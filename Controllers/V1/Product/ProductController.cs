using Microsoft.AspNetCore.Mvc;
using OrderTrack.Repositories;

namespace OrderTrack.Controllers.V1.Products
{
    [Route("api/v1/[controller]")]
    public class ProductController(IProduct product) : ControllerBase
    {
        protected readonly IProduct _product =  product;
    }
}