using DataAccessLayer.LN;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WaterMonitoringSystemApp.Controllers
{
    [Authorize]
    public class UserRolController : Controller
    {
        IUsers _user;
        IRol _role;
        public UserRolController(IUsers user, IRol role)
        {
            _user = user;
            _role = role;
        }

        public UserRolController() : this(new UsersImplement(), new RolImplement())
        {

        }
        // GET: UserRol
        [Authorize(Roles = "Administrador")]
        public ActionResult Index() 
        {
            var users = _user.getUsers();
            return View(users);
        }

        public ActionResult addRole(string idUser, string idRol) {
            try
            {
                _role.addRolUser(idRol, idUser);
                return Json(new { success = true, responseText = "Se actualizo el rol correctamente" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e) {
                return Json(new { success = false, responseText = e.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}