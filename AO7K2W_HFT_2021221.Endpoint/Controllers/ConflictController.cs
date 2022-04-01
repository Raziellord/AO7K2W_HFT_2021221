﻿using AO7K2W_HFT_2021221.Endpoint.Services;
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
    public class ConflictController : ControllerBase
    {
        IConflictLogic cl;

        IHubContext<SignalRHub> hub;
        public ConflictController(IConflictLogic cl, IHubContext<SignalRHub> hub)
        {
            this.cl = cl;
            this.hub = hub;
        }
        // GET: /conflict
        [HttpGet]
        public IEnumerable<Conflict> ReadAll()
        {
            return cl.ReadAll();
        }

        // GET conflict/5
        [HttpGet("{id}")]
        public Conflict Read(int id)
        {
            return cl.Read(id);
        }

        // POST /conflict
        [HttpPost]
        public void Create([FromBody] Conflict value)
        {
            cl.Create(value);
            this.hub.Clients.All.SendAsync("ConflictCreated", value);
        }

        // PUT /conflict
        [HttpPut]
        public void Put([FromBody] Conflict value)
        {
            this.cl.Update(value);
            this.hub.Clients.All.SendAsync("ConflictUpdated", value);
        }

        // DELETE /conflict/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var conflictToDelete = this.cl.Read(id);
            this.cl.Delete(id);
            this.hub.Clients.All.SendAsync("ConflictDeleted", conflictToDelete);
        }

    }
}
