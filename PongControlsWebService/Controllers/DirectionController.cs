using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PongControlsWebService.Model;


namespace PongControlsWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectionController : ControllerBase
    {
        
        

        // GET: api/Direction
        [HttpGet]
        public string Get()
        {
            string i = Direction.action;
            return i;
        }

        // GET: api/Direction/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Direction
        [HttpPost]
        public void Post([FromBody] string direction)
        {
            Direction.action = direction;
        }

        // PUT: api/Direction/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete()
        {
            //directionList.Clear();
        }
    }
}
