using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CarsalesMockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {
        // private static readonly List<Subscriber> subscribers = new List<Subscriber>{
        //     new Subscriber(){
        //         Id = 0,
        //         Name = "John Doe",
        //         Email = "john.doe@gmail.com"
        //         }
        // };
        private readonly CarsalesMockApiDbContext _context;

        public SubscriberController(CarsalesMockApiDbContext context) {
            _context = context;
        }

        // GET: api/<SubscriberController>
        [HttpGet]
        public async Task<ActionResult<List<Subscriber>>> GetAll()
        {
            try
            {
                var subscribers =  await _context.Subscribers.ToListAsync();
                return subscribers;
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<SubscriberController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subscriber>> GetById(Guid id)
        {
            try
            {
                var subscriber = await _context.Subscribers.SingleOrDefaultAsync(item => item.Id == id);
                if (subscriber == null)
                {
                    return new StatusCodeResult(StatusCodes.Status404NotFound);
                }
                return subscriber;
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        //PUT api/<SubscriberController>/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Subscriber>> Put([FromBody] Subscriber subscriber)
        {
            _context.Entry(subscriber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }

        //POST api/<SubscriberController>
        [HttpPost]
        public async Task<ActionResult<Subscriber>> Post([FromBody] Subscriber subscriber)
        {
            try
            {
                var result = _context.Subscribers.AddAsync(subscriber);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = subscriber.Id }, subscriber);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<SubscriberController> for testing only
        // [HttpDelete]
        // public void Delete()
        // {
        //     subscribers.Clear();
        // }
    }
}
