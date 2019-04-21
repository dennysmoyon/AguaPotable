using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsSGH
{
    public class UsersDTO
    {
        [Key]
        public string Id { get; set; }
        [Display(Name ="Ciudad")]
        public string Hometown { get; set; }
        [Display(Name = "Correo")]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        [Display(Name = "Usuario")]
        public string UserName { get; set; }
        public string IdRole { get; set; }
        public string DescriptionRole { get; set;}
        public List<RolesDTO> ListaRoles { get; set; }

    }
}
