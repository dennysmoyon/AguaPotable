using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsSGH;
using AutoMapper;

namespace DataAccessLayer.LN
{
    public class EquipmentImplement : IEquipment
    {
        public void AddEquipment(EquipmentDTO equipmentDTO)
        {
            using (var dbContext = new DataFlowSensorsDBEntities()) {
                var equipment = Mapper.Map<Equipment>(equipmentDTO);
                dbContext.Equipment.Add(equipment);
                dbContext.SaveChanges();
            }
        }

        public EquipmentDTO GetEquipment(string codEquip)
        {
            using (var dbContext = new DataFlowSensorsDBEntities()) {
                var equipment = dbContext.Equipment.FirstOrDefault(eq => eq.Cod_Equipment == codEquip);
                var equipmentDto = Mapper.Map<EquipmentDTO>(equipment);
                equipmentDto.treatmentUnitDto = Mapper.Map<TreatmentUnitDTO>(equipment.TreatmentUnit);
                return equipmentDto;
            }
        }

        public EquipmentDTO GetEquipment(int idEquip)
        {
            using (var dbContext = new DataFlowSensorsDBEntities())
            {
                var equipment = dbContext.Equipment.FirstOrDefault(eq => eq.Id_Equipment == idEquip);
                var equipmentDto = Mapper.Map<EquipmentDTO>(equipment);
                equipmentDto.treatmentUnitDto = Mapper.Map<TreatmentUnitDTO>(equipment.TreatmentUnit);
                return equipmentDto;
            }
        }

        public List<EquipmentDTO> GetEquipments()
        {
            List<EquipmentDTO> lstEquimentDTO = new List<EquipmentDTO>();
            EquipmentDTO equipDto = null;
            using (var dbContext = new DataFlowSensorsDBEntities()) {
                var lstEquipment = dbContext.Equipment.Where(qr => qr.active == true);

                foreach (var equip in lstEquipment)
                {
                    equipDto = new EquipmentDTO();
                    equipDto = Mapper.Map<EquipmentDTO>(equip);
                    equipDto.treatmentUnitDto = Mapper.Map<TreatmentUnitDTO>(equip.TreatmentUnit);
                    equipDto.LstComponent = Mapper.Map<IEnumerable<ComponentDTO>>(equip.Component).ToList();
                    lstEquimentDTO.Add(equipDto);
                    
                }

                return lstEquimentDTO;
            }
        }

        public void UpdateEquipment(EquipmentDTO equipmentDTO)
        {
            using (var dbContext = new DataFlowSensorsDBEntities()) {
                var equipment = dbContext.Equipment.FirstOrDefault(eq => eq.Id_Equipment == equipmentDTO.Id_Equipment);
                Mapper.Map(equipmentDTO, equipment);
                dbContext.SaveChanges();
            }
        }

        public void DeleteEquipment(int id) {
            using (var dbContext = new DataFlowSensorsDBEntities()) {
                var equipment = dbContext.Equipment.FirstOrDefault(eq => eq.Id_Equipment == id);
                equipment.active = false;
                dbContext.SaveChanges();
            }
        }
    }
}
