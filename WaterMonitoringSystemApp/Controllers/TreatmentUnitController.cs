using DataAccessLayer.LN;
using ModelsSGH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WaterMonitoringSystemApp.Reesources;

namespace WaterMonitoringSystemApp.Controllers
{
    [Authorize]
    public class TreatmentUnitController : Controller
    {
        ITreatmentUnit _treatmentUnit;

        public TreatmentUnitController(ITreatmentUnit treatmentUnit)
        {
            _treatmentUnit = treatmentUnit;
        }

        public TreatmentUnitController() : this(new TreatmentUnitImplement()) {

        }

        // GET: TreatmentUnit
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            var lstTreatmentUnit = _treatmentUnit.GetTreatmentUnits();
            return View(lstTreatmentUnit);
        }

        public ActionResult Add() {
            return View(new TreatmentUnitDTO());
        }

        [HttpPost]
        public ActionResult Add(TreatmentUnitDTO objTu) {

            if (ModelState.IsValid){

                objTu.Cod_Tu = Utilitis.GeneratedCode(ParameterClass.codTypeTreatmentUnit);
                _treatmentUnit.AddTreatmentUnit(objTu);
                return RedirectToAction("Index");
            }
            return View(objTu);
        }

        //Get
        public ActionResult DetailTu(int id) {
            return View(_treatmentUnit.GetTreatmentUnit(id));
        }

        public ActionResult UpdateTu(int id) {
            return View(_treatmentUnit.GetTreatmentUnit(id));
        }

        [HttpPost]
        public ActionResult UpdateTu(TreatmentUnitDTO objTu) {

            if (ModelState.IsValid) {
                objTu.active = true;
                _treatmentUnit.UpdateTreatmentUnit(objTu);
                return RedirectToAction("index");
            }

            return View(objTu);
        }

        public ActionResult DeleteTu(int id) {
            return View(_treatmentUnit.GetTreatmentUnit(id));
        }

        [HttpPost]
        public ActionResult DeleteTu(int id, FormCollection collection) {
            _treatmentUnit.DeleteTreatmentUnit(id);
            return RedirectToAction("Index");
        }

        public ActionResult getTu() {
            var tus = _treatmentUnit.GetTreatmentUnits();
            return Json(tus, JsonRequestBehavior.AllowGet);
        }
    }
}