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
    public class TankController : ControllerBase
    {
        ITankLogic tl;
        public TankController(ITankLogic tl)
        {
            this.tl = tl;
        }
        // GET: /tank
        [HttpGet]
        public IEnumerable<Tank> Get()
        {
            return tl.ReadAll();
        }

        // GET /tank/5
        [HttpGet("{id}")]
        public Tank Get(int id)
        {
            return tl.Read(id);
        }

        // POST /tank
        [HttpPost]
        public void Post([FromBody] Tank value)
        {
            tl.Create(value);
        }

        // PUT /tank
        [HttpPut("{id}")]
        public void Put([FromBody] Tank value)
        {
            tl.Update(value);
        }

        // DELETE /tank/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            tl.Delete(id);
        }
    }
}
