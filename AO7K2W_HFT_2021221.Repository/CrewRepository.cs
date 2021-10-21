using AO7K2W_HFT_2021221.Data;
using AO7K2W_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO7K2W_HFT_2021221.Repository
{
    public class CrewRepository : ICrewRepository
    {
        TankDbContext db;
        public CrewRepository(TankDbContext db)
        {
            this.db = db;
        }

        public void Create(Crew crew)
        {
            db.Crews.Add(crew);
            db.SaveChanges();
        }
        public Crew Read(int id)
        {
            return db.Crews.FirstOrDefault(t => t.Id == id);
        }
        public IQueryable<Crew> ReadAll()
        {
            return db.Crews;
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public void Update(Crew crew)
        {
            var oldcrew = Read(crew.Id);
            oldcrew.Name = crew.Name;
            oldcrew.Profession = crew.Profession;
            oldcrew.Age = crew.Age;
            oldcrew.Rank = crew.Rank;
            oldcrew.TankId = crew.TankId;
            db.SaveChanges();

        }
    }
}
