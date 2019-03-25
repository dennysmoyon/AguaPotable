using DataAccessLayer;
using DataAccessLayer.LN;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WaterMonitoringSystemApp.Reports;

namespace WaterMonitoringSystemApp.Controllers
{
    public class FlowDataSensorsController : Controller
    {

        public IData_Sensors _dataSensors;

        public FlowDataSensorsController(IData_Sensors dataSensors)
        {
            _dataSensors = dataSensors;
        }

        public FlowDataSensorsController() : this( new Data_Sensors())
        {
        }
        // GET: FlowDataSensors
        public ActionResult Index()
        {
            var dataDFS = _dataSensors.getDataSensors();
            return View(dataDFS);
        }

        public ActionResult showChartLevelWater() {
            return View();
        }

        public ActionResult Monitor() {
            return View();
        }

        /*public ActionResult reportSensors() {
            var dataDFS = _dataSensors.getDataSensors();
            DataSensorsReport dsfReport = new DataSensorsReport();
            byte[] abyteReport = dsfReport.PrepareReport(dataDFS);
            return File(abyteReport, "application/pdf");
        }*/

        public ActionResult reportSensors(string dateSince, string dateUntil)
        {
            try
            {
                DateTime _dateSince = DateTime.ParseExact(dateSince, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                DateTime _dateUntil = DateTime.ParseExact(dateUntil, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                //if (id == null) {
                //    id = "";
                //    dates = new string[4];                   
                //    dates[0] = "";
                //    dates[1] = "";
                //}
                //else {
                //    dates = id.Split('!');
                //_dateSince = Convert.ToDateTime(dateSince);
                //_dateUntil = Convert.ToDateTime(dateUntil);
                //}


                var dataDFS = _dataSensors.filterReportSensors(_dateSince, _dateUntil);
                DataSensorsReport dsfReport = new DataSensorsReport();
                byte[] abyteReport = dsfReport.PrepareReport(dataDFS, dateSince, dateUntil);
                return File(abyteReport, "application/pdf");


            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "FlowDataSensors", "reportSensors"));

            }
        }


        /// <summary>
        /// Retorna Un JSON del historial de datos de lectura de los sensores.
        /// </summary>
        /// <returns></returns>
        public ActionResult getFlowDataSensors() {
            var lstDataSensors = _dataSensors.getDataSensors();
            return Json(lstDataSensors, JsonRequestBehavior.AllowGet);
        }
    }
}