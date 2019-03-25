using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsSGH
{
    public class ComponentDTO
    {
        [Key]
        public int Id_Component { get; set; }
        public int Id_Equipment { get; set; }
        [Display(Name = "Codigo COM.")]
        public string Cod_Component { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "{0} tiene que estar entre {2} y {1} caracteres.")]
        public string Description { get; set; }
        [Display(Name = "Serie")]
        public string Serie { get; set; }
        [Display(Name = "Marca")]
        public string Mark { get; set; }
        [Display(Name = "Material")]
        public string Material { get; set; }
        [Display(Name = "Utilidad")]
        public string Utility { get; set; }
        public bool active { get; set; }
        public EquipmentDTO EquipmentDTO { get; set; }
        public List<EquipmentDTO> LstEquipment { get; set; }
    }
}
