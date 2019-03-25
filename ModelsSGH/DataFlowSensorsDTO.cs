using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ModelsSGH
{
    public class DataFlowSensorsDTO
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el dato del sensor de PH")]
        [Display(Name = "PH")]
        public decimal Data_Sensor_PH { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el dato del sensor de nivel de agua")]
        [Display(Name = "Nivel de agua")]
        public decimal Data_Sensor_LW { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el dato del sensor de Oxigeno disuelto")]
        [Display(Name = "Oxigeno Disuelto")]
        public decimal Data_Sensor_OD { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el dato del sensor de Conductividad")]
        [Display(Name = "Conductividad")]
        public decimal Data_Sensor_CT { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el dato del sensor de ORP")]
        [Display(Name = "ORP")]
        public decimal Data_Sensor_ORP { get; set; }
        [Display(Name = "Fecha de registro")]
        public DateTime? Date_Register { get; set; }

        public string hours { get; set; }
        public bool _now { get; set; }

        /**SHORT FIELDS**/
        public decimal PH { get { return this.Data_Sensor_PH; }
                            set { this.Data_Sensor_PH = value; }}
        public decimal LW { get { return this.Data_Sensor_LW; }
                            set { this.Data_Sensor_LW = value; }}
        public decimal OD { get { return this.Data_Sensor_OD; }
                            set { this.Data_Sensor_OD = value; }}
        public decimal CT { get { return this.Data_Sensor_CT; }
                            set { this.Data_Sensor_CT = value; }}
        public decimal ORP { get { return this.Data_Sensor_ORP; }
                             set { this.Data_Sensor_ORP = value;}}
    }
}
