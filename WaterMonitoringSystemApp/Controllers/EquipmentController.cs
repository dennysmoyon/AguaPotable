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
    public class EquipmentController : Controller
    {
        ITreatmentUnit _treatmentUnit;
        IEquipment _equipment;
        public EquipmentController(ITreatmentUnit treatmentUnit, IEquipment equipment)
        {
            _treatmentUnit = treatmentUnit;
            _equipment = equipment;
        }

        public EquipmentController() : this(new TreatmentUnitImplement(), new EquipmentImplement())
        {
                
        }

        // GET: Equipment
        public ActionResult Index()
        {
            var lstEquipment = _equipment.GetEquipments();
            return View(lstEquipment);
        }

        //Get
        public ActionResult Add() {
            EquipmentDTO objEquipment = new EquipmentDTO();
            objEquipment.LstUnitTreatment = _treatmentUnit.GetTreatmentUnits();
            return View(objEquipment);
        }

        [HttpPost]
        public ActionResult Add(EquipmentDTO equipment) {

            if (ModelState.IsValid) {
                equipment.Cod_Equipment = Utilitis.GeneratedCode(ParameterClass.codTypeEquiment);
                equipment.active = true;
                _equipment.AddEquipment(equipment);
                return RedirectToAction("Index");
            }
            equipment.LstUnitTreatment = _treatmentUnit.GetTreatmentUnits();
            return View(equipment);
        }

        public ActionResult DetailEq(int id) {
            var equipDto = _equipment.GetEquipment(id);
            equipDto.LstUnitTreatment = _treatmentUnit.GetTreatmentUnits();
            return View(equipDto);
        }

        public ActionResult UpdateEq(int id) {
            var equipDto = _equipment.GetEquipment(id);
            equipDto.LstUnitTreatment = _treatmentUnit.GetTreatmentUnits();
            return View(equipDto);
        }

        [HttpPost]
        public ActionResult UpdateEq(EquipmentDTO equipDto) {

            if (ModelState.IsValid) {
                equipDto.active = true;
                _equipment.UpdateEquipment(equipDto);
                return RedirectToAction("index");
            }
            equipDto.LstUnitTreatment = _treatmentUnit.GetTreatmentUnits();
            return View(equipDto);
        }

        public ActionResult DeleteEq(int id) {
            return View(_equipment.GetEquipment(id));
        }

        [HttpPost]
        public ActionResult DeleteEq(int id, FormCollection form) {

            _equipment.DeleteEquipment(id);
            return RedirectToAction("index");
        }
        
    } 
}