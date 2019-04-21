using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsSGH
{
    public class RolesDTO
    {
        [Key]
        public string id { get; set; }
        [Display]
        [Required(ErrorMessage ="Ingresa el detalle del rol")]
        public string Name { get; set; }
    }
}
