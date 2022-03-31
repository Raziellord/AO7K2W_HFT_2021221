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
    public class ConflictLogic : IConflictLogic
    {
        IRepository<Conflict> conflictRepo;
        public ConflictLogic(IRepository<Conflict> conflictRepo)
        {
            this.conflictRepo = conflictRepo;
        }
        public void Create(Conflict conflict)
        {
            if (conflict.NameOfConflict != null || conflict.NameOfConflict != "")
            {
                conflictRepo.Create(conflict);
            }
            else
            {
                throw new ArgumentException("Invalid Name! Please give a name.");
            }
            
        }

        public void Delete(int id)
        {
            conflictRepo.Delete(id);
        }

        public IEnumerable<Conflict> ReadAll()
        {
            return conflictRepo.ReadAll();
        }

        public Conflict Read(int id)
        {
            return conflictRepo.Read(id);
        }

        public void Update(Conflict conflict)
        {
            conflictRepo.Update(conflict);
        }

        public IEnumerable<Conflict> ConflictsWhereAvgEliminationOver100()
        {
            return conflictRepo.ReadAll().Where(t => t.Tanks.Average(e => e.Eliminations) > 100);
        }
        public IEnumerable<Conflict> ConflictsWhereAvgCrewAgeOver30()
        {
            return conflictRepo.ReadAll().Where(t => t.Tanks.Any(t => t.Crews.Average(z => z.Age) > 30));
        }
        public IEnumerable<Conflict> ConflictsWhereTankHasRadioman()
        {
            return conflictRepo.ReadAll().Where(t => t.Tanks.Any(c => c.Crews.Any(p => p.Profession.Contains("Radioman"))));
        }

        public IEnumerable<Conflict> ConflictsWhereTankServiceStartAverageOver1950()
        {
            return conflictRepo.ReadAll().Where(t => t.Tanks.Average(s => s.StartOfService.Year) > 1950);
        }

        public IEnumerable<Conflict> ConflictsWhereGeneralMajorParticipated()
        {
            return conflictRepo.ReadAll().Where(t => t.Tanks.Any(c => c.Crews.Any(r => r.Rank.Contains("General Major"))));
        }
        
    }
}
