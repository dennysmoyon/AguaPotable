using ModelsSGH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.LN
{
    public interface IEquipment
    {
        void AddEquipment(EquipmentDTO equipmentDTO);
        void UpdateEquipment(EquipmentDTO equipmentDTO);

        void DeleteEquipment(int id); 
        EquipmentDTO GetEquipment(int idEquip);
        EquipmentDTO GetEquipment(string codEquip);
        List<EquipmentDTO> GetEquipments();
    }
}
