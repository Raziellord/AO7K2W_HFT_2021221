using AO7K2W_HFT_2021221.Logic;
using AO7K2W_HFT_2021221.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AO7K2W_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IConflictLogic cf;
        ICrewLogic cw;
        ITankLogic tl;
        public StatController(IConflictLogic cf, ICrewLogic cw, ITankLogic tl)
        {
            this.cf = cf;
            this.cw = cw;
            this.tl = tl;
        }

        //---------------------------------------- CONFLICT STATS --------------------------------------
        //GET:  /stat/conflictswhereavgeliminationover100
        //WORKS
        [HttpGet]
        public IEnumerable<Conflict> ConflictsWhereAvgEliminationOver100()
        {
            return cf.ConflictsWhereAvgEliminationOver100();
        }
        //GET: /stat/conflictswhereavgcrewageover30
        //WORKS
        [HttpGet]
        public IEnumerable<Conflict> ConflictsWhereAvgCrewAgeOver30()
        {
            return cf.ConflictsWhereAvgCrewAgeOver30();
        }
        //GET: /stat/conflictswheretankhasradioman
        //WORKS
        [HttpGet]
        public IEnumerable<Conflict> ConflictsWhereTankHasRadioman()
        {
            return cf.ConflictsWhereTankHasRadioman();
        }
        //GET: /stat/conflictswheretankservicestartaverageover1950
        //WORKS
        [HttpGet]
        public IEnumerable<Conflict> ConflictsWhereTankServiceStartAverageOver1950()
        {
            return cf.ConflictsWhereTankServiceStartAverageOver1950();
        }
        //GET /stat/conflictswheregeneralmajorparticipated
        //WORKS
        [HttpGet]
        public IEnumerable<Conflict> ConflictsWhereGeneralMajorParticipated()
        {
            return cf.ConflictsWhereGeneralMajorParticipated();
        }
        //---------------------------------------- CONFLICT STATS --------------------------------------

        //---------------------------------------- TANK  STATS -----------------------------------------

        // GET: /stat/tankaverageeliminationbyconflict
        //WORKS
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> TankAverageEliminationByConflict()
        {
            return tl.TankAverageEliminationByConflict();
        }
        //GET : /stat/tankswithradioman
        //WORKS
        [HttpGet]
        public IEnumerable<Tank> TanksWithRadioMan()
        {
            return tl.TanksWithRadioMan();
        }
        //GET : /stat/tankaveragestartofservicebyconflict
        //WORKS
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> TankAverageStartOfServiceByConflict()
        {
            return tl.TankAverageStartOfServiceByConflict();
        }
        //GET: /stat/tanksfromconflictswithoneorlesscasusalties
        //WORKS
        [HttpGet]
        public IEnumerable<Tank> TanksFromConflictsWithOneOrLessCasualties()
        {
            return tl.TanksFromConflictsWithOneOrLessCasualties();
        }
        //GET: /stat/tankswhereaveragecrewageover30
        //WORKS
        [HttpGet]
        public IEnumerable<Tank> TanksWhereAverageCrewAgeOver30()
        {
            return tl.TanksWhereAverageCrewAgeOver30();
        }

        //---------------------------------------- TANK  STATS -----------------------------------------

        //---------------------------------------- CREW  STATS -----------------------------------------

        //GET: /stat/avgagebytank
        //WORKS
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGAgeByTank()
        {
            return cw.AVGAgeByTank();
        }
        //GET: /stat/oldestagebytank
        //WORKS
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> OldestAgeByTank()
        {
            return cw.OldestAgeByTank();
        }
        //GET: /stat/crewsafter1950tanks
        //WORKS
        [HttpGet]
        public IEnumerable<Crew> CrewsAfter1950Tanks()
        {
            return cw.CrewsAfter1950Tanks();
        }
        //GET: /stat/crewswhereconflictwinnerusa
        //WORKS
        [HttpGet]
        public IEnumerable<Crew> CrewsWhereConflictWinnerUSA()
        {
            return cw.CrewsWhereConflictWinnerUSA();
        }
        //GET: /stat/crewswhoparticipatedinrussianconflict
        //WORKS
        public IEnumerable<Crew> CrewsWhoParticipatedInRussianConflict()
        {
            return cw.CrewsWhoParticipatedInRussianConflict();
        }
    }
    //---------------------------------------- CREW  STATS -----------------------------------------
}
