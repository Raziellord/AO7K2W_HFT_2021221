using AO7K2W_HFT_2021221.Models;
using System.Linq;

namespace AO7K2W_HFT_2021221.Repository
{
    interface IConflictRepository
    {
        void Create(Conflict conflict);
        void Delete(int id);
        Conflict Read(int id);
        IQueryable<Conflict> ReadAll();
        void Update(Conflict conflict);
    }
}