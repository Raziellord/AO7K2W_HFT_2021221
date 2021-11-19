﻿using AO7K2W_HFT_2021221.Models;
using AO7K2W_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO7K2W_HFT_2021221.Logic
{
    public class CrewLogic : ICrewLogic
    {
        ICrewRepository crewRepo;
        public CrewLogic(ICrewRepository crewRepo)
        {
            this.crewRepo = crewRepo;
        }
        public void Create(Crew crew)
        {
            crewRepo.Create(crew);
        }

        public void Delete(int id)
        {
            crewRepo.Delete(id);
        }

        public Crew Read(int id)
        {
            return crewRepo.Read(id);
        }

        public IEnumerable<Crew> ReadAll()
        {
            return crewRepo.ReadAll();
        }

        public void Update(Crew crew)
        {
            crewRepo.Update(crew);
        }

        
    }
}
