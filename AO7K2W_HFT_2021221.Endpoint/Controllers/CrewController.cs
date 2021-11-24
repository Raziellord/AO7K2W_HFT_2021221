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
    public class CrewController : ControllerBase
    {
        ICrewLogic cl;
        public CrewController(ICrewLogic cl)
        {
            this.cl = cl;
        }

        // GET: /crew
        [HttpGet]
        public IEnumerable<Crew> Get()
        {
            return cl.ReadAll();
        }

        // GET /crew/5
        [HttpGet("{id}")]
        public Crew Get(int id)
        {
            return cl.Read(id);
        }

        // POST /crew
        [HttpPost]
        public void Post([FromBody] Crew value)
        {
            cl.Create(value);
        }

        // PUT /crew
        [HttpPut("{id}")]
        public void Put([FromBody] Crew value)
        {
            cl.Update(value);
        }


        // DELETE /crew/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.Delete(id);
        }
    }
}
