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
using OrderTrack.Utils;
using Swashbuckle.AspNetCore.Annotations;

namespace OrderTrack.Controllers.V1.Users
{
    [Route("api/v1/useres")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("useres")]
    public class UserCreateController(IUser user) : UserController(user)
    {
        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates a new User",
            Description = "Adds a new User to the system with the provided name and description."
        )]
        [SwaggerResponse(201, "The User was successfully created", typeof(User))]
        [SwaggerResponse(400, "If the User data is invalid")]
        public async Task<ActionResult<User>> Create([FromBody] UserDTO imputUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hashedPassword = PasswordHasher.HashPassword(imputUser.Password);

            var newUser = new User(imputUser.Name, imputUser.Email, imputUser.Address, hashedPassword);

            await _user.Add(newUser);

            return Ok(newUser);
        }
    }
}