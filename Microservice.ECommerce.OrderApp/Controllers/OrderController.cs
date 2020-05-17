using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice.ECommerce.OrderApp.Model;
using Microservice.ECommerce.OrderApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.ECommerce.OrderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly MemoryOrder inMemoryOrder;

        public OrderController()
        {
            this.inMemoryOrder = new MemoryOrder();
        }

        // GET: api/Order
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            var orders = this.inMemoryOrder.GetOrders();
            return orders;
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var order = this.inMemoryOrder.GetOrders().First(x => x.OrderId == id);
                return Ok(order);
            }
            catch
            {
                return NotFound("No Order found");
            }
        }

        // POST: api/Order
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Order/5
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
