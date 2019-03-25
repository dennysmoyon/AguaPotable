using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsSGH;
using AutoMapper;

namespace DataAccessLayer.LN
{
    public class TreatmentUnitImplement : ITreatmentUnit 
    {

        public void AddTreatmentUnit(TreatmentUnitDTO treatmentUnitDTO)
        {
            treatmentUnitDTO.active = true;
            using (var dbContext = new DataFlowSensorsDBEntities()) {
                var _treatmentUnit = Mapper.Map<TreatmentUnit>(treatmentUnitDTO);
                dbContext.TreatmentUnit.Add(_treatmentUnit);
                dbContext.SaveChanges();
            }
        }

        public TreatmentUnitDTO GetTreatmentUnit(string codTu)
        {
            TreatmentUnitDTO treatUnitDTO = new TreatmentUnitDTO();
            using (var dbContext = new DataFlowSensorsDBEntities()) {
                var treatmentUnit = dbContext.TreatmentUnit.First(tu => tu.Cod_Tu == codTu);
                treatUnitDTO = Mapper.Map<TreatmentUnitDTO>(treatmentUnit);
                return treatUnitDTO;
            }
        }

        public TreatmentUnitDTO GetTreatmentUnit(int idTu)
        {
            TreatmentUnitDTO treatUnitDTO = new TreatmentUnitDTO();
            using (var dbContext = new DataFlowSensorsDBEntities())
            {
                var treatmentUnit = dbContext.TreatmentUnit.First(tu => tu.Id_Tu == idTu);
                treatUnitDTO = Mapper.Map<TreatmentUnitDTO>(treatmentUnit);
                return treatUnitDTO;
            }
        }

        public List<TreatmentUnitDTO> GetTreatmentUnits()
        {
            List<TreatmentUnitDTO> lstTreatUnitDTO = new List<TreatmentUnitDTO>();
            using (var dbContext = new DataFlowSensorsDBEntities()) {
                var lstTu = dbContext.TreatmentUnit.Where(qr => qr.active == true);
                lstTreatUnitDTO = Mapper.Map<IEnumerable<TreatmentUnitDTO>>(lstTu).ToList();
            }
            return lstTreatUnitDTO;
        }

        public void UpdateTreatmentUnit(TreatmentUnitDTO treatmentUnitDTO)
        {
            using (var dbcontext = new DataFlowSensorsDBEntities()) {
                var treatmentUnit = dbcontext.TreatmentUnit.FirstOrDefault(tu => tu.Id_Tu == treatmentUnitDTO.Id_Tu);
                Mapper.Map(treatmentUnitDTO, treatmentUnit);
                dbcontext.SaveChanges();
            }
        }

        public void DeleteTreatmentUnit(int id) {
            using (var dbcontext = new DataFlowSensorsDBEntities()) {
                var tuDelete = dbcontext.TreatmentUnit.FirstOrDefault(qr => qr.Id_Tu == id);
                tuDelete.active = false;
                dbcontext.SaveChanges();
            }
        }
    }
}
