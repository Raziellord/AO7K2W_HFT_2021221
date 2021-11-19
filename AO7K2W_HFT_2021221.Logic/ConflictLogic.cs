using AO7K2W_HFT_2021221.Models;
using AO7K2W_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO7K2W_HFT_2021221.Logic
{
    public class ConflictLogic : IConflictLogic
    {
        IConflictRepository conflictRepo;
        public ConflictLogic(IConflictRepository conflictRepo)
        {
            this.conflictRepo = conflictRepo;
        }
        public void Create(Conflict conflict)
        {
            conflictRepo.Create(conflict);
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
    }
}
