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
    public class CrewController : ControllerBase
    {
        ICrewLogic cl;
        IHubContext<SignalRHub> hub;
        public CrewController(ICrewLogic cl , IHubContext<SignalRHub> hub)
        {
            this.cl = cl;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("CrewCreated", value);
        }

        // PUT /crew
        [HttpPut]
        public void Put([FromBody] Crew value)
        {
            cl.Update(value);
            this.hub.Clients.All.SendAsync("CrewUpdated", value);
        }


        // DELETE /crew/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var crewToDelete = this.cl.Read(id);
            cl.Delete(id);
            this.hub.Clients.All.SendAsync("CrewDeleted", crewToDelete);

        }
    }
}
