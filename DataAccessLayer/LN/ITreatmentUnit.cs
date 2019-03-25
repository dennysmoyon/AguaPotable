using ModelsSGH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.LN
{
    public interface ITreatmentUnit
    {
        void AddTreatmentUnit(TreatmentUnitDTO treatmentUnitDTO);
        void UpdateTreatmentUnit(TreatmentUnitDTO treatmentUnitDTO);
        void DeleteTreatmentUnit(int id);
        TreatmentUnitDTO GetTreatmentUnit(int idTu);
        TreatmentUnitDTO GetTreatmentUnit(string codTu);
        List<TreatmentUnitDTO> GetTreatmentUnits();
    }
}
