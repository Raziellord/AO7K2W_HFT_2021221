using AO7K2W_HFT_2021221.Models;
using System.Linq;

namespace AO7K2W_HFT_2021221.Repository
{
    public interface ITankRepository
    {
        void Create(Tank tank);
        void Delete(int id);
        Tank Read(int id);
        IQueryable<Tank> ReadAll();
        void Update(Tank tank);
    }
}