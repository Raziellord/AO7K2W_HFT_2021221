using AO7K2W_HFT_2021221.Data;
using AO7K2W_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO7K2W_HFT_2021221.Repository
{
    class ConflictRepository : IConflictRepository
    {
        TankDbContext db;
        public ConflictRepository(TankDbContext db)
        {
            this.db = db;
        }

        public void Create(Conflict conflict)
        {
            db.Conflicts.Add(conflict);
            db.SaveChanges();
        }
        public Conflict Read(int id)
        {
            return db.Conflicts.FirstOrDefault(t => t.Id == id);
        }
        public IQueryable<Conflict> ReadAll()
        {
            return db.Conflicts;
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public void Update(Conflict conflict)
        {
            var oldconflict = Read(conflict.Id);
            oldconflict.NameOfConflict = conflict.NameOfConflict;
            oldconflict.DateOfConflict = conflict.DateOfConflict;
            oldconflict.Casualties = conflict.Casualties;
            oldconflict.Winner = conflict.Winner;


            db.SaveChanges();

        }
    }
}
