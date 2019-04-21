using DataAccessLayer;
using DataAccessLayer.LN;
using ModelsSGH;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WaterMonitoringSystemApp.Controllers
{
    public class FdsAPIController : ApiController
    {
        IData_Sensors _dfsl;
        ITreatmentUnit _tu;
        public FdsAPIController(IData_Sensors dfs, ITreatmentUnit tu)
        {
            _dfsl = dfs;
            _tu = tu;
        }

        public FdsAPIController() : this(new Data_Sensors(), new TreatmentUnitImplement())
        {

        }

        // GET: api/FlowDataSensorsAPI
        public string Get()
        {
            var tU = _tu.GetTreatmentUnits();
            string dataJsonTu = JsonConvert.SerializeObject(tU, Formatting.Indented);
            //return new string[] { "value1", "value2" };
            return dataJsonTu;
        }

        // GET: api/FlowDataSensorsAPI/5
        public string Get(int id)
        {
            return "Hola amigos:" + id;
        }

        // POST: api/FlowDataSensorsAPI
        public string Post([FromBody]DataFlowSensorsDTO _dfs)
        {
            _dfs = _dfsl.addDataSensors(_dfs);
            string dataJson = JsonConvert.SerializeObject(_dfs);
            // var saludo = _sal.saludos("hola amigos");
            return dataJson;
        }

        // PUT: api/FlowDataSensorsAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FlowDataSensorsAPI/5
        public void Delete(int id)
        {
        }
    }
}
