using DataAccessLayer.LN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsSGH;

namespace DataAccessLayer
{
    public class Data_Sensors : IData_Sensors
    {
        public Data_Sensors()
        {
        }

        /// <summary>
        /// Agregar datos de FlowDataSensors
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataFlowSensorsDTO addDataSensors(DataFlowSensorsDTO data)
        {
            try
            {
                using (var dbContext = new DataFlowSensorsDBEntities())
                {
                    var dataSensors = new FlowDataSensors();
                    dataSensors.Data_Sensor_CONDUCTIVITY = data.Data_Sensor_CT;
                    dataSensors.Data_Sensor_DISOLVED_OXYGEN = data.Data_Sensor_OD;
                    dataSensors.Data_Sensor_ORP = data.Data_Sensor_ORP;
                    dataSensors.Data_Sensor_PH = data.Data_Sensor_PH;
                    dataSensors.Data_Sensor_WATER_LEVEL = data.Data_Sensor_LW;
                    dataSensors.Date_Register = DateTime.Now;
                    dbContext.FlowDataSensors.Add(dataSensors);
                    dbContext.SaveChanges();
                    int id = dataSensors.Id;

                    //Reasignacion.
                    dataSensors = dataSensors = new FlowDataSensors();
                    dataSensors =  dbContext.FlowDataSensors.FirstOrDefault(sc => sc.Id == id);
                    data.Id = dataSensors.Id;
                    data.Data_Sensor_CT = dataSensors.Data_Sensor_CONDUCTIVITY;
                    data.Data_Sensor_LW = dataSensors.Data_Sensor_WATER_LEVEL;
                    data.Data_Sensor_OD = dataSensors.Data_Sensor_DISOLVED_OXYGEN;
                    data.Data_Sensor_ORP = dataSensors.Data_Sensor_ORP;
                    data.Data_Sensor_PH = dataSensors.Data_Sensor_PH;
                    data.Date_Register = dataSensors.Date_Register;
                    if (dataSensors.Date_Register == null)
                    {
                        data.hours = null;
                    }
                    else
                    {
                        var dateDb = (DateTime)dataSensors.Date_Register;
                        data.hours = dateDb.Hour.ToString() + ":" + dateDb.Minute.ToString() + ":" + dateDb.Second.ToString();
                        if (dateDb.Day == DateTime.Now.Day && dateDb.Month == DateTime.Now.Month && dateDb.Year == DateTime.Now.Year)
                            data._now = true;
                    }

                    ///notificacion al socket
                    WebSocketImplement.notifier(data);

                    return data;
                }
            }

            catch (Exception ex){

                throw ex;
            }
        }

        /// <summary>
        /// Obtener la lista flujo de datos de sesores.
        /// </summary>
        /// <returns></returns>
        public List<DataFlowSensorsDTO> getDataSensors()
        {
            try
            {
                using (var dbContext = new DataFlowSensorsDBEntities()) {

                    var listDataSensors = dbContext.FlowDataSensors.OrderByDescending((x) => x.Date_Register);
                    List<DataFlowSensorsDTO> lstDFS = new List<DataFlowSensorsDTO>();
                    DataFlowSensorsDTO itemDFS = null;
                    foreach (var dataSensor in listDataSensors) {
                        itemDFS = new DataFlowSensorsDTO();
                        itemDFS.Data_Sensor_CT = dataSensor.Data_Sensor_CONDUCTIVITY;
                        itemDFS.Data_Sensor_OD = dataSensor.Data_Sensor_DISOLVED_OXYGEN;
                        itemDFS.Data_Sensor_ORP = dataSensor.Data_Sensor_ORP;
                        itemDFS.Data_Sensor_PH = dataSensor.Data_Sensor_PH;
                        itemDFS.Data_Sensor_LW = dataSensor.Data_Sensor_WATER_LEVEL;
                        itemDFS.Date_Register = dataSensor.Date_Register;
                        itemDFS._now = false;
                        if (dataSensor.Date_Register == null)
                        {
                            itemDFS.hours = null;
                        }
                        else {
                            var dateDb =  (DateTime)dataSensor.Date_Register;
                            itemDFS.hours = dateDb.Hour.ToString() + ":" + dateDb.Minute.ToString() + ":" + dateDb.Second.ToString();
                            if (dateDb.Day == DateTime.Now.Day && dateDb.Month == DateTime.Now.Month && dateDb.Year == DateTime.Now.Year)
                                itemDFS._now = true;
                        }
                        
                        
                        lstDFS.Add(itemDFS);
                    }

                    return lstDFS;
                }
            }
            catch (Exception ex) {
                throw ex;
            }
            
        }

        public List<DataFlowSensorsDTO> filterReportSensors(DateTime _dateSince, DateTime _dateUntil) {

            using (var dbContext =  new DataFlowSensorsDBEntities()) {

                var lstDataReports = from dfs in dbContext.FlowDataSensors
                                     where dfs.Date_Register >= _dateSince && dfs.Date_Register <= _dateUntil
                                     select dfs;

                List<DataFlowSensorsDTO> lstDFS = new List<DataFlowSensorsDTO>();
                DataFlowSensorsDTO itemDFS = null;
                foreach (var dataSensor in lstDataReports)
                {
                    itemDFS = new DataFlowSensorsDTO();
                    itemDFS.Data_Sensor_CT = dataSensor.Data_Sensor_CONDUCTIVITY;
                    itemDFS.Data_Sensor_OD = dataSensor.Data_Sensor_DISOLVED_OXYGEN;
                    itemDFS.Data_Sensor_ORP = dataSensor.Data_Sensor_ORP;
                    itemDFS.Data_Sensor_PH = dataSensor.Data_Sensor_PH;
                    itemDFS.Data_Sensor_LW = dataSensor.Data_Sensor_WATER_LEVEL;
                    itemDFS.Date_Register = dataSensor.Date_Register;
                    itemDFS._now = false;
                    if (dataSensor.Date_Register == null)
                    {
                        itemDFS.hours = null;
                    }
                    else
                    {
                        var dateDb = (DateTime)dataSensor.Date_Register;
                        itemDFS.hours = dateDb.Hour.ToString() + ":" + dateDb.Minute.ToString() + ":" + dateDb.Second.ToString();
                        if (dateDb.Day == DateTime.Now.Day && dateDb.Month == DateTime.Now.Month && dateDb.Year == DateTime.Now.Year)
                            itemDFS._now = true;
                    }


                    lstDFS.Add(itemDFS);
                }

                return lstDFS;
            }
        }
     
    }
}
