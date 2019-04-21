using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.LN
{
    public class RolImplement : IRol
    {
        public void addRolUser(string rol, string idUser)
        {
            using (var dbContext = new DataFlowSensorsDBEntities()) {
                var user = dbContext.AspNetUsers.FirstOrDefault(usr => usr.Id == idUser);
                if (user != null) {

                    var role_db = user.AspNetRoles.ToList().FirstOrDefault(rl => rl.Id == rol);
                    if (role_db != null) {
                        return;
                    }

                    //Buscamos el Rol agregar
                    var role = dbContext.AspNetRoles.FirstOrDefault(rl => rl.Id == rol);

                    //Eliminamos todos los existentes
                    foreach (var _roleDb in user.AspNetRoles.ToList()) {
                        user.AspNetRoles.Remove(_roleDb);
                    }

                    dbContext.SaveChanges();

                    //Actualizamos
                    user.AspNetRoles.Add(role);
                    dbContext.SaveChanges();

                }
            }
        }

        public AspNetRoles getRole(string rol) {
            using (var dbContext = new DataFlowSensorsDBEntities()) {
                var objRol = dbContext.AspNetRoles.FirstOrDefault(rl => rl.Id == rol);
                return objRol;
            }
        }

        public List<AspNetRoles> getRols()
        {
            List<AspNetRoles> rols = new List<AspNetRoles>();
            using (var dbContext = new DataFlowSensorsDBEntities()) {
                rols = dbContext.AspNetRoles.ToList();
                return rols;
            }
        }
    }
}
