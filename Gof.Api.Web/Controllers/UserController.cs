using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gof.Api.Web.Controllers
{
    using Gof.Api.Core.Infrastructure;
    using Gof.Api.Dto;
    using Gof.Api.Feature;

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        public UsersController(ICommandBus commandBus)
        {
            this._commandBus = commandBus;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var command = new UserFilterCommand();
            return await new QueryResponder<IList<UserInfo>>(this._commandBus, this).RespondTo(command);
            
            // var userInfo = new UserInfo()
            // {
            //     Name = "XX",
            //     PhoneNumber = "11111",
            //     UserId = 1
            // };
            // return Ok(userInfo);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            // var userInfo = new UserInfo()
            // {
            //     Name = "XX",
            //     PhoneNumber = "11111",
            //     UserId = 1
            // };
            // return Ok(userInfo);
            var command = new GetUserInfoCommand();
            return await new QueryResponder<UserInfo>(this._commandBus, this).RespondTo(command);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
