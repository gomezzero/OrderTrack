using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderTrack.Repositories;

namespace OrderTrack.Controllers.V1.Categorys
{
    [Route("api/v1/[controller]")]
    public class CategoryController(ICategory category) : ControllerBase
    {
        protected readonly ICategory _category = category;
    }
}