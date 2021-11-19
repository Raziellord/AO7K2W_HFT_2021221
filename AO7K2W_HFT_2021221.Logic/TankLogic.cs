using AO7K2W_HFT_2021221.Models;
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
    }
}
