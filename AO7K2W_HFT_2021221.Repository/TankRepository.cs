using AO7K2W_HFT_2021221.Data;
using AO7K2W_HFT_2021221.Models;
using AO7K2W_HFT_2021221.Repository.GenericRepository;
using AO7K2W_HFT_2021221.Repository.Interfaces;
using System;
using System.Linq;

namespace AO7K2W_HFT_2021221.Repository
{
    public class TankRepository : Repository<Tank>, IRepository<Tank>
    {
       
        public TankRepository(TankDbContext ctx) :base(ctx)
        {
            
        }

        
        public override Tank Read(int id)
        {
            return ctx.Tanks.FirstOrDefault(tank => tank.TankId == id);
        }
        public override void Update(Tank item)
        {
            var old = Read(item.TankId);
            if (old == null)
            {
                throw new ArgumentException("Item not exist..");
            }
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
