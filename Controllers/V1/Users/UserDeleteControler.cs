using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderTrack.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace OrderTrack.Controllers.V1.Users
{
    [Route("api/v1/useres")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("useres")]
    public class UserDeleteControler(IUser user) : UserController(user)
    {
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletes a user by ID",
            Description = "Removes the specified user from the system."
        )]
        [SwaggerResponse(204, "The user was successfully deleted")]
        [SwaggerResponse(404, "If the user with the specified ID is not found")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var exists = await _user.CheckExistence(id);

            if (!exists)
            {
                return NotFound($"el usuario {id} no existe en la base de datos");
            }

            await _user.Delete(id);
            return Ok($"El Usuario Identificado con el N°{id} fue eliminada");
        }
    }
}