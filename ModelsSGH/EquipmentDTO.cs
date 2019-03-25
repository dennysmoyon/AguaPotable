using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsSGH
{
    public class EquipmentDTO
    {
        [Key]
        public int Id_Equipment { get; set; }

        [Display(Name = "Código EQ.")]
        public string Cod_Equipment { get; set; }

        [Display(Name = "Unidad de Tratamiento")]
        [Required(ErrorMessage = "Elija la Unidad de Tratamiento")]
        public int Id_Tu { get; set; }

        [Display(Name = "Medida")]
        public string Size { get; set; }

        [Display(Name = "Descripcion")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} tiene que estar entre {2} y {1} caracteres.")]
        [Required(ErrorMessage = "Debe ingresar un descripción")]
        public string Description { get; set; }

        [Display(Name = "Color")]
        [Required(ErrorMessage = "Ingresa el color de equipo")]
        public string Color { get; set; }

        [Display(Name = "Posición")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "{0} tiene que estar entre {2} y {1} caracteres.")]
        [Required(ErrorMessage = "Defina el lugar de ubicación el dispositivo")]
        public string Position { get; set; }

        [Display(Name = "Código UT.")]
        public TreatmentUnitDTO treatmentUnitDto { get; set; }

        public bool active { get; set; }
        public IEnumerable<TreatmentUnitDTO> LstUnitTreatment { get; set; }
        public List<ComponentDTO> LstComponent { get; set; }

    }
}
