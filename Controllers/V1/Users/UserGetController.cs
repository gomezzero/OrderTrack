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

namespace OrderTrack.Controllers.V1.Users
{
    [Route("api/v1/useres")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("useres")]
    public class UserGetController(IUser user) : UserController(user)
    {
        [HttpGet]
        [SwaggerOperation(
            Summary = "Retrieves all users",
            Description = "Returns a list of all users in the system."
        )]
        [SwaggerResponse(200, "A list of users", typeof(IEnumerable<User>))]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _user.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Retrieves a user by ID",
        Description = "Returns the user details for the specified ID."
        )]
        [SwaggerResponse(200, "The user with the specified ID", typeof(User))]
        [SwaggerResponse(404, "If the User with the specified ID is not found")]
        public async Task<ActionResult<User>> GetById([FromRoute] int id)
        {
            var user = await _user.GetById(id);

            if (user == null)
            {
                return NotFound($"el usuario {id} no existe en la base de datos");
            }
            return user;
        }
    }
}