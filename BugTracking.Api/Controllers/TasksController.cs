using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace BugTracking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        // GET api/tasks
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/tasks/id
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/tasks
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/tasks/id
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/tasks/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
