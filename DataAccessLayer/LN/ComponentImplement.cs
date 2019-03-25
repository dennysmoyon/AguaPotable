using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsSGH;
using AutoMapper;

namespace DataAccessLayer.LN
{
    public class ComponentImplement : IComponent
    {
        public ComponentImplement()
        {
           
        }

        public void AddComponent(ComponentDTO componentDTO)
        {
            using (var dbContext = new DataFlowSensorsDBEntities()) {

                var _component = Mapper.Map<Component>(componentDTO);
                dbContext.Component.Add(_component);
                dbContext.SaveChanges();
            }
        }

        public ComponentDTO GetComponent(string codComp)
        {
            using (var dbcontext = new DataFlowSensorsDBEntities())
            {

                var component = dbcontext.Component.FirstOrDefault(cpI => cpI.Cod_Component.Equals(codComp) && cpI.active == true);

                ComponentDTO cp = new ComponentDTO();
                if (component != null) {
                    cp = Mapper.Map<ComponentDTO>(component);
                    cp.EquipmentDTO = Mapper.Map<EquipmentDTO>(component.Equipment);
                    cp.EquipmentDTO.treatmentUnitDto = Mapper.Map<TreatmentUnitDTO>(component.Equipment.TreatmentUnit);
                    return cp;
                }
                return cp;
                
            }
        }

        public ComponentDTO GetComponent(int idComp)
        {
            using (var dbcontext = new DataFlowSensorsDBEntities()) {

                var component = dbcontext.Component.FirstOrDefault(cpI => cpI.Id_Component == idComp && cpI.active == true);

                ComponentDTO cp = new ComponentDTO();
                if (component != null)
                {
                    cp = Mapper.Map<ComponentDTO>(component);
                    cp.EquipmentDTO = Mapper.Map<EquipmentDTO>(component.Equipment);
                    cp.EquipmentDTO.treatmentUnitDto = Mapper.Map<TreatmentUnitDTO>(component.Equipment.TreatmentUnit);
                    return cp;
                }
                return cp;
            }
        }

        public List<ComponentDTO> GetComponents()
        {
            throw new NotImplementedException();
        }

        public void DeleteComponent(int id) {

            using (var dbContext = new DataFlowSensorsDBEntities()) {

                var componentUp  = dbContext.Component.FirstOrDefault(sq => sq.Id_Component == id && sq.active == true);
                if (componentUp != null) {
                    componentUp.active = false;
                    dbContext.SaveChanges();
                }
            }
        }

        public void UpdateComponent(ComponentDTO componentDTO)
        {
            using (var dbContext = new DataFlowSensorsDBEntities()) {
                var componentUp = dbContext.Component.FirstOrDefault(sq => sq.Id_Component == componentDTO.Id_Component && sq.active == true);
                if (componentUp != null)
                {
                    Mapper.Map(componentDTO, componentUp);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
