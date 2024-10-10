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

namespace OrderTrack.Controllers.V1.Categorys
{
    [Route("api/v1/categorys")]
    public class CategoryUpdateClass(ICategory category) : CategoryController(category)
    {
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryDTO updateCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var checkCategory = await _category.CheckExistence(id);

            if (!checkCategory)
            {
                return NotFound();
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