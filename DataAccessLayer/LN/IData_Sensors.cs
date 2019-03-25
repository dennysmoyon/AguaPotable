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
        List<DataFlowSensorsDTO>  filterReportSensors(DateTime _dateSince, DateTime _dateUntil);
        DataFlowSensorsDTO addDataSensors(DataFlowSensorsDTO data);


    }
}
