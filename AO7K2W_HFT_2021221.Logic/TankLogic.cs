using AO7K2W_HFT_2021221.Models;
using AO7K2W_HFT_2021221.Repository;
using AO7K2W_HFT_2021221.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO7K2W_HFT_2021221.Logic
{
    public class TankLogic : ITankLogic
    {
        IRepository<Tank> tankRepo;
        public TankLogic(IRepository<Tank> tankRepo)
        {
            this.tankRepo = tankRepo;
        }
        public void Create(Tank tank)
        {
            if (tank.Nickname != null || tank.Nickname != "" || tank.StartOfService > DateTime.Parse("1800.01.01"))
            {
                tankRepo.Create(tank);
            }
            else
            {
                throw new ArgumentException("Please check if you have given the correct data for : Nickname & StartOfService!");
            }
            
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
        
        public IEnumerable<Tank> TanksWithRadioMan()
        {
            return tankRepo.ReadAll().Where(c => c.Crews.Any(z => z.Profession.Contains("Radioman")));
        }

        public IEnumerable<KeyValuePair<string, double>> TankAverageStartOfServiceByConflict()
        {
            return from x in tankRepo.ReadAll()
                   group x by x.Conflict.NameOfConflict into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.StartOfService.Year));
        }

        public IEnumerable<Tank> TanksFromConflictsWithOneOrLessCasualties()
        {
            return tankRepo.ReadAll().Where(c => c.Conflict.Casualties <= 1);
        }

        public IEnumerable<Tank> TanksWhereAverageCrewAgeOver30()
        {
            return tankRepo.ReadAll().Where(t => t.Crews.Average(z => z.Age) > 30);
        }
    }
}
