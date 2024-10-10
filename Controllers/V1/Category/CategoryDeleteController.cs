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
    [Route("api/v1/categorys")]
    public class CategoryDeleteController(ICategory category) : CategoryController(category)
    {
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var user = await _category.CheckExistence(id);

            if (user == false)
            {
                return NotFound();
            }

            await _category.Delete(id);

            return NotFound();
        }
    }
}