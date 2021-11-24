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
        [HttpGet]
        public IEnumerable<Conflict> ConflictsWhereAvgEliminationOver100()
        {
            return cf.ConflictsWhereAvgEliminationOver100();
        }
        //GET: /stat/conflictswhereavgcrewageover30
        [HttpGet]
        public IEnumerable<Conflict> ConflictsWhereAvgCrewAgeOver30()
        {
            return cf.ConflictsWhereAvgCrewAgeOver30();
        }
        //GET: /stat/conflictswheretankhasradioman
        [HttpGet]
        public IEnumerable<Conflict> ConflictsWhereTankHasRadioman()
        {
            return cf.ConflictsWhereTankHasRadioman();
        }
        //GET: /stat/conflictswheretankservicestartaverageover1950
        [HttpGet]
        public IEnumerable<Conflict> ConflictsWhereTankServiceStartAvereageOver1950()
        {
            return cf.ConflictsWhereTankServiceStartAvereageOver1950();
        }
        //GET /stat/conflictswheregeneralmajorparticipated
        [HttpGet]
        public IEnumerable<Conflict> ConflictsWhereGeneralMajorParticipated()
        {
            return cf.ConflictsWhereGeneralMajorParticipated();
        }
        //---------------------------------------- CONFLICT STATS --------------------------------------

        //---------------------------------------- TANK  STATS -----------------------------------------

        // GET: /stat/tankaverageeliminationbyconflict
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> TankAverageEliminationByConflict()
        {
            return tl.TankAverageEliminationByConflict();
        }
        //GET : /stat/tankswithradioman
        [HttpGet]
        public IEnumerable<Tank> TanksWithRadioMan()
        {
            return tl.TanksWithRadioMan();
        }
        //GET : /stat/tankaveragestartofservicebyconflict
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> TankAverageStartOfServiceByConflict()
        {
            return tl.TankAverageStartOfServiceByConflict();
        }
        //GET : /stat/tanksfromconflictswithoneorlesscasualties
        [HttpGet]
        public IEnumerable<Tank> TanksFromConflictsWithOneOrLessCausalties()
        {
            return tl.TanksFromConflictsWithOneOrLessCausalties();
        }
        //GET: /stat/tankswhereaveragecrewageover30
        [HttpGet]
        public IEnumerable<Tank> TanksWhereAverageCrewAgeOver30()
        {
            return tl.TanksWhereAverageCrewAgeOver30();
        }

        //---------------------------------------- TANK  STATS -----------------------------------------

        //---------------------------------------- CREW  STATS -----------------------------------------

        //GET: AVGAgeByTank
        public IEnumerable<KeyValuePair<string, double>> AVGAgeByTank()
        {
            return cw.AVGAgeByTank();
        }

        public IEnumerable<KeyValuePair<string, double>> OldestAgeByTank()
        {
            return cw.OldestAgeByTank();
        }

        public IEnumerable<Crew> CrewsAfter1950Tanks()
        {
            return cw.CrewsAfter1950Tanks();
        }

        public IEnumerable<Crew> CrewsWhereConflictWinnerUSA()
        {
            return cw.CrewsWhereConflictWinnerUSA();
        }

        public IEnumerable<Crew> CrewsWhoParticipatedInRussianConflict()
        {
            return cw.CrewsWhoParticipatedInRussianConflict();
        }
    }
    //---------------------------------------- CREW  STATS -----------------------------------------
}
