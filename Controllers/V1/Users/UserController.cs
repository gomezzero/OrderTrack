using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderTrack.Repositories;

namespace OrderTrack.Controllers.V1.Users
{
    [Route("api/v1/[controller]")]
    public class UserController(IUser user) : ControllerBase
    {
        protected readonly IUser _user = user;
    }
}