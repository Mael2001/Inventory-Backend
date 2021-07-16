using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supermarket.Context;
using Supermarket.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Supermarket.Controllers
{
    [Route("")]
    [ApiController]
    public class SupermarketController : ControllerBase
    {
        private readonly GroceryAppContext _assistantDbContext;

        public SupermarketController(GroceryAppContext assistantDbContext)
        {
            _assistantDbContext = assistantDbContext;
        }
        // GET: api/<SupermarketController>
        [HttpGet("")]
        public IReadOnlyList<Groceries> Get()
        {
            return _assistantDbContext.Grocery.ToList();
        }

        // GET: api/<SupermarketController>
        [HttpGet("/filter/{name}")]
        public IReadOnlyList<Groceries> Get(string name)
        {
            return _assistantDbContext.Grocery.Where(x=>x.name.ToLower().Contains(name.ToLower())).ToList();
        }
        // GET api/<SupermarketController>/5
        [HttpGet("{id}")]
        public Groceries Get(int id)
        {
            return _assistantDbContext.Grocery.FirstOrDefault(x => x.id == id);
        }

        // POST api/<SupermarketController>
        [HttpPost]
        public Groceries Post([FromBody] Groceries value)
        {
            _assistantDbContext.Grocery.Add(value);
            _assistantDbContext.SaveChanges();
            return value;
        }
        // POST api/<SupermarketController>/reduce
        [HttpPost("/reduce")]
        public Groceries PostReduceQuantity([FromBody] Groceries value)
        {
            _assistantDbContext.Grocery.Remove(_assistantDbContext.Grocery.FirstOrDefault(x => x.id == value.id));
            _assistantDbContext.SaveChanges();
            _assistantDbContext.Grocery.Add(value);
            _assistantDbContext.SaveChanges();
            return value;
        }

        // PUT api/<SupermarketController>/5
        [HttpPost("/edit")]
        public Groceries EditGroceries([FromBody] Groceries value)
        {
            _assistantDbContext.Grocery.Remove(_assistantDbContext.Grocery.FirstOrDefault(x => x.id == value.id));
            _assistantDbContext.SaveChanges();
            _assistantDbContext.Grocery.Add(value);
            _assistantDbContext.SaveChanges();
            return value;
        }

        // DELETE api/<SupermarketController>/5
        [HttpDelete("{id}")]
        public Groceries Delete(int id)
        {
            var value = _assistantDbContext.Grocery.FirstOrDefault(x => x.id == id);
            _assistantDbContext.Grocery.Remove(value);
            _assistantDbContext.SaveChanges();
            return value;
        }
    }
}
