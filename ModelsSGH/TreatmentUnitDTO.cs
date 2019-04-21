using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsSGH
{
    public class TreatmentUnitDTO
    {
        [Key]
        public int Id_Tu { get; set; }

        [Display(Name = "Código UT.")]
        public string Cod_Tu { get; set; }

        [Display(Name ="Descripcion")]
        [Required(ErrorMessage ="Ingrese la descripción")]
        public string Description { get; set; }

        [Display(Name ="Dirección")]
        public string Addrress { get; set; }

        [Display(Name ="Latitud")]
        public decimal Latitude { get; set; }

        [Display(Name ="Longitud")]
        public decimal Longitude { get; set; }

        [Display(Name ="Capacidad")]
        public  float Capacity { get; set; }

        public List<EquipmentDTO> Equipments { get; set; }
        public bool  active { get; set; }

    }
}
