using AO7K2W_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO7K2W_HFT_2021221.Logic
{
    public interface ITankLogic
    {
        void Create(Tank tank);
        void Delete(int id);
        IEnumerable<Tank> ReadAll();
        Tank Read(int id);
        void Update(Tank tank);
        IEnumerable<KeyValuePair<string, double>> TankAverageEliminationByConflict();
        IEnumerable<Tank> TanksWithRadioMan();
        IEnumerable<KeyValuePair<string, double>> TankAverageStartOfServiceByConflict();
        IEnumerable<Tank> TanksFromConflictsWithOneOrLessCausalties();
        IEnumerable<Tank> TanksWhereAverageCrewAgeOver30();
    }
}
