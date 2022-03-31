using AO7K2W_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO7K2W_HFT_2021221.Logic
{
    public interface IConflictLogic
    {
        void Create(Conflict conflict);
        void Delete(int id);
        IEnumerable<Conflict> ReadAll();
        Conflict Read(int id);
        void Update(Conflict conflict);
        IEnumerable<Conflict> ConflictsWhereAvgEliminationOver100();
        IEnumerable<Conflict> ConflictsWhereAvgCrewAgeOver30();
        IEnumerable<Conflict> ConflictsWhereTankHasRadioman();
        IEnumerable<Conflict> ConflictsWhereTankServiceStartAverageOver1950();
        IEnumerable<Conflict> ConflictsWhereGeneralMajorParticipated();
    }
}
