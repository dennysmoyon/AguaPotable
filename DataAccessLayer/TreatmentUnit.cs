//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class TreatmentUnit
    {
        public TreatmentUnit()
        {
            this.Equipment = new HashSet<Equipment>();
        }
    
        public int Id_Tu { get; set; }
        public string Cod_Tu { get; set; }
        public string Description { get; set; }
        public string Addrress { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public Nullable<double> Capacity { get; set; }
        public Nullable<bool> active { get; set; }
    
        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
