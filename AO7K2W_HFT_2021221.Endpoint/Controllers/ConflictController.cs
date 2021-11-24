using AO7K2W_HFT_2021221.Logic;
using AO7K2W_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AO7K2W_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConflictController : ControllerBase
    {
        IConflictLogic cl;
        public ConflictController(IConflictLogic cl)
        {
            this.cl = cl;
        }
        // GET: /conflict
        [HttpGet]
        public IEnumerable<Conflict> Get()
        {
            return cl.ReadAll();
        }

        // GET conflict/5
        [HttpGet("{id}")]
        public Conflict Get(int id)
        {
            return cl.Read(id);
        }

        // POST /conflict
        [HttpPost]
        public void Post([FromBody] Conflict value)
        {
            cl.Create(value);
        }

        // PUT /conflict
        [HttpPut("{id}")]
        public void Put([FromBody] Conflict value)
        {
            cl.Update(value);
        }

        // DELETE /conflict/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.Delete(id);
        }
    }
}
