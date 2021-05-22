using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace CarsalesMockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {
        private static readonly List<Subscriber> subscribers = new List<Subscriber>{
            new Subscriber(){
                Id = 0,
                Name = "John Doe",
                Email = "john.doe@gmail.com"
                }
        };

        // GET: api/<SubscriberController>
        [HttpGet]
        public ActionResult<List<Subscriber>> Get()
        {
            try
            {
                return subscribers;
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<SubscriberController>/5
        [HttpGet("{id}")]
        public ActionResult<Subscriber> GetById(int id)
        {
            try
            {
                return subscribers.Find(item => item.Id == id);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<SubscriberController>
        [HttpPost]
        public ActionResult<Subscriber> Post([FromBody] Subscriber value)
        {
            try
            {
                value.Id = subscribers.Count;
                subscribers.Add(value);
                return CreatedAtAction(nameof(GetById), new { id = value.Id }, value);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<SubscriberController> for testing only
        [HttpDelete]
        public void Delete()
        {
            subscribers.Clear();
        }
    }
}
