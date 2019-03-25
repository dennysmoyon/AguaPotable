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
    public class ComponentController : Controller
    {
        // GET: Component
        IComponent _component;
        IEquipment _equipment;
        public ComponentController(IComponent component, IEquipment equipment)
        {
            _component = component;
            _equipment = equipment;
        }

        public ComponentController():this(new ComponentImplement(), new EquipmentImplement())
        {

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCmp(string id) {
            ViewBag.codEquip = id;
            var component = new ComponentDTO();
            component.EquipmentDTO = new EquipmentDTO();
            component.EquipmentDTO = _equipment.GetEquipment(id);
            component.Id_Equipment = component.EquipmentDTO.Id_Equipment;
            return View(component);
        }

        [HttpPost]
        public ActionResult AddCmp(ComponentDTO component) {
            if (ModelState.IsValid) {
                component.active = true;
                component.Cod_Component = Utilitis.GeneratedCode(ParameterClass.codTypeComponent);
                _component.AddComponent(component);
                return RedirectToAction("index", "Equipment");
            }

            return View(component);
        }

        public ActionResult DetailCmp(int id) {
            return View(_component.GetComponent(id));
        }
    }
}