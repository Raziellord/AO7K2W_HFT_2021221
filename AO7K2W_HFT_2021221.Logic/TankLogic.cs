﻿using AO7K2W_HFT_2021221.Models;
using AO7K2W_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO7K2W_HFT_2021221.Logic
{
    public class TankLogic : ITankLogic
    {
        ITankRepository tankRepo;
        public TankLogic(ITankRepository tankRepo)
        {
            this.tankRepo = tankRepo;
        }
        public void Create(Tank tank)
        {
            tankRepo.Create(tank);
        }

        public void Delete(int id)
        {
            tankRepo.Delete(id);
        }

        public Tank Read(int id)
        {
            return tankRepo.Read(id);
        }

        public IEnumerable<Tank> ReadAll()
        {
            return tankRepo.ReadAll();
        }

        public void Update(Tank tank)
        {
            tankRepo.Update(tank);
        }

        public double AVGElimination()
        {
            return tankRepo.ReadAll().Average(t => t.Eliminations);
        }

        public IEnumerable<KeyValuePair<string,double>> TankAverageEliminationByConflict()
        {
            return from x in tankRepo.ReadAll()
                   group x by x.Conflict.NameOfConflict into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.Eliminations));
        }
        
        
    }
}
