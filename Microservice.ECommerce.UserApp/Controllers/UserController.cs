using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice.ECommerce.UserApp.EFDataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.ECommerce.UserApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult Get()
        {
            var users = this.userRepository.GetAllUsers();
            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = this.userRepository.GetAllUsers().First(x => x.Id == id);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound($"User Id:{id} not found");
            }
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
