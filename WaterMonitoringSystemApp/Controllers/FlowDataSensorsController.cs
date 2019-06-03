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
    [AllowAnonymous]
    public class FlowDataSensorsController : Controller
    {

        public IData_Sensors _dataSensors;
        public IEquipment _equipment;

        public FlowDataSensorsController(IData_Sensors dataSensors, IEquipment equipment)
        {
            _dataSensors = dataSensors;
            _equipment = equipment;
        }

        public FlowDataSensorsController() : this( new Data_Sensors(), new EquipmentImplement())
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

        public ActionResult Monitor(int id) {

            ViewBag.idEquipment = id;
            var equipment = _equipment.GetEquipment(id);
            return View(equipment);
        }

        public ActionResult reportSensors(string dateSince, string dateUntil, int idEq)
        {
            try
            {
                DateTime _dateSince = DateTime.ParseExact(dateSince, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                DateTime _dateUntil = DateTime.ParseExact(dateUntil, "dd-MM-yyyy", CultureInfo.InvariantCulture);

 
                var dataDFS = _dataSensors.filterReportSensors(_dateSince, _dateUntil, idEq);
                DataSensorsReport dsfReport = new DataSensorsReport();
                var equipment = _equipment.GetEquipment(idEq);
                byte[] abyteReport = dsfReport.PrepareReport(dataDFS, dateSince, dateUntil, equipment);
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
        public ActionResult getFlowDataSensors(int id) {
            var lstDataSensors = _dataSensors.getDataSensors(id);
            return Json(lstDataSensors, JsonRequestBehavior.AllowGet);
        }
    }
}