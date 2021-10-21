using AO7K2W_HFT_2021221.Data;
using AO7K2W_HFT_2021221.Models;
using System;
using System.Linq;

namespace AO7K2W_HFT_2021221.Repository
{
    public class TankRepository : ITankRepository
    {
        TankDbContext db;
        public TankRepository(TankDbContext db)
        {
            this.db = db;
        }

        public void Create(Tank tank)
        {
            db.Tanks.Add(tank);
            db.SaveChanges();
        }
        public Tank Read(int id)
        {
            return db.Tanks.FirstOrDefault(t => t.Id == id);
        }
        public IQueryable<Tank> ReadAll()
        {
            return db.Tanks;
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public void Update(Tank tank)
        {
            var oldtank = Read(tank.Id);
            oldtank.Model = tank.Model;
            oldtank.Eliminations = tank.Eliminations;
            oldtank.CrewSpace = tank.CrewSpace;
            oldtank.ConflictId = tank.ConflictId;
            oldtank.Conflict = tank.Conflict;
            oldtank.Nickname = tank.Nickname;
            oldtank.StartOfService = tank.StartOfService;

            db.SaveChanges();

        }
    }
}
