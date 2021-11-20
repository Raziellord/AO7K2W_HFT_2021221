using AO7K2W_HFT_2021221.Models;
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

        public IEnumerable<KeyValuePair<string,double>> AVGAgeByTank()
        {
            return from x in crewRepo.ReadAll()
                   group x by x.Tank.Nickname into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.Age));
        }
        public IEnumerable<KeyValuePair<string,double>> OldestAgeByTank()
        {
            return from x in crewRepo.ReadAll()
                   group x by x.Tank.Nickname into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Max(t => t.Age));
        }

        public IEnumerable<Crew> CrewsAfter1950Tanks()
        {
            return crewRepo.ReadAll().Where(t => t.Tank.StartOfService.Year > 1950);
        }

        public IEnumerable<Crew> CrewsWhereConflictWinnerUSA()
        {
            return crewRepo.ReadAll().Where(t => t.Tank.Conflict.Winner == "USA");
        }

    }
}
