using AO7K2W_HFT_2021221.Models;
using System.Linq;

namespace AO7K2W_HFT_2021221.Repository
{
    public interface ICrewRepository
    {
        void Create(Crew crew);
        void Delete(int id);
        Crew Read(int id);
        IQueryable<Crew> ReadAll();
        void Update(Crew crew);
    }
}