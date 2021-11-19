using AO7K2W_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO7K2W_HFT_2021221.Logic
{
    interface ICrewLogic
    {
        void Create(Crew crew);
        void Delete(int id);
        IEnumerable<Crew> ReadAll();
        Crew Read(int id);
        void Update(Crew crew);
    }
}
