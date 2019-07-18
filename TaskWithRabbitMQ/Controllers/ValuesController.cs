using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaskWithRabbitMQ.Framework;
using TaskWithRabbitMQ.Model;

namespace TaskWithRabbitMQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
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

        // POST api/values/CreateNewInventory
        [HttpPost("CreateNewInventory")]
        public string CreateInventory([FromBody] Inventory inventory)
        {
            return new CallRabbitMQ().SendNewInventory(inventory);
        }

        // POST api/values/CreateNewRecod
        [HttpPost("CreateNewRecod")]
        public string CreateNewRecod([FromBody] InventoryMaintenanceHistory imh)
        {
            return new CallRabbitMQ().SendNewRecordMaintenanceHistory(imh);
        }
    }
}
