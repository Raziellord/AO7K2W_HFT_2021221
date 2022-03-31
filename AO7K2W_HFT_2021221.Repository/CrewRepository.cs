using AO7K2W_HFT_2021221.Data;
using AO7K2W_HFT_2021221.Models;
using AO7K2W_HFT_2021221.Repository.GenericRepository;
using AO7K2W_HFT_2021221.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO7K2W_HFT_2021221.Repository
{
    public class CrewRepository : Repository<Crew>, IRepository<Crew>
    {

        public CrewRepository(TankDbContext ctx) : base(ctx)
        {
        }
        
        public override Crew Read(int id)
        {
            return ctx.Crews.FirstOrDefault(crew => crew.CrewId == id);
        }

        public override void Update(Crew item)
        {
            var old = Read(item.CrewId);
            if (old == null)
            {
                throw new ArgumentException("Item does not exist..");
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
