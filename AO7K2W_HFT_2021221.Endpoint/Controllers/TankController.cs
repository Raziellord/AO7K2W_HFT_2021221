using AO7K2W_HFT_2021221.Endpoint.Services;
using AO7K2W_HFT_2021221.Logic;
using AO7K2W_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<SignalRHub> hub;
        public TankController(ITankLogic tl, IHubContext<SignalRHub> hub)
        {
            this.tl = tl;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("TankCreated", value);
        }

        // PUT /tank
        [HttpPut]
        public void Put([FromBody] Tank value)
        {
            this.tl.Update(value);
            this.hub.Clients.All.SendAsync("TankUpdated", value);
        }

        // DELETE /tank/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var tankToDelete = this.tl.Read(id);
            this.tl.Delete(id);
            this.hub.Clients.All.SendAsync("TankDeleted", tankToDelete);
        }
    }
}
