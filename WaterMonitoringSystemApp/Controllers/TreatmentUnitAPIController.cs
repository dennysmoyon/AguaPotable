using DataAccessLayer.LN;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WaterMonitoringSystemApp.Controllers
{
    public class TreatmentUnitAPIController : ApiController
    {
        ITreatmentUnit _tU;
        public TreatmentUnitAPIController(ITreatmentUnit tU)
        {
            _tU = tU;
        }

        public TreatmentUnitAPIController(): this(new TreatmentUnitImplement())
        {

        }
        // GET: api/TreatmentUnitAPI
        public ICollection<string> Get()
        {
          
            return null;
        }

        // GET: api/TreatmentUnitAPI/5
        public string Get(int id)
        {
            var lstTU = _tU.GetTreatmentUnit(id);
            if (lstTU == null)
                return "";

            var jsonTU = JsonConvert.SerializeObject(lstTU, Formatting.Indented);
            return jsonTU;
        }

        // POST: api/TreatmentUnitAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TreatmentUnitAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TreatmentUnitAPI/5
        public void Delete(int id)
        {
        }
    }
}
