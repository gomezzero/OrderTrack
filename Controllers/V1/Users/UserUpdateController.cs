using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderTrack.DTOs;
using OrderTrack.Repositories;
using OrderTrack.Utils;
using Swashbuckle.AspNetCore.Annotations;

namespace OrderTrack.Controllers.V1.Users
{
    [Route("api/v1/useres")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("useres")]
    public class UserUpdateController(IUser user) : UserController(user)
    {
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Updates an existing user",
            Description = "Updates the user with the specified ID, if it exists, with the provided new details."
        )]
        [SwaggerResponse(204, "The user was successfully updated")]
        [SwaggerResponse(400, "If the provided user data is invalid")]
        [SwaggerResponse(404, "If the user with the specified ID is not found")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UserDTO updateUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var checkUser = await _user.CheckExistence(id);

            if (!checkUser)
            {
                return NotFound($"el usuario {id} no existe en la base de datos");
            }

            var user = await _user.GetById(id);

            if (user == null)
            {
                return NotFound("El usuaro no existe en la base de datos");
            }

            user.Name = updateUser.Name;
            user.Email = updateUser.Email;
            user.Address = updateUser.Address;

            if (!string.IsNullOrWhiteSpace(updateUser.Password))
            {
                user.Password = PasswordHasher.HashPassword(updateUser.Password);
            }

            await _user.Update(user);
            return Ok($"El Usuario N°{id} fue actualizado");
        }
    }
}