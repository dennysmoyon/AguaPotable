using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsSGH;

namespace DataAccessLayer.LN
{
    public interface IData_Sensors
    {
        List<DataFlowSensorsDTO> getDataSensors();
        List<DataFlowSensorsDTO> getDataSensors(int idEquipment);
        List<DataFlowSensorsDTO>  filterReportSensors(DateTime _dateSince, DateTime _dateUntil, int cod_eq);
        DataFlowSensorsDTO addDataSensors(DataFlowSensorsDTO data);


    }
}
