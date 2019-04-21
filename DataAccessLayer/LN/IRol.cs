using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.LN
{
    public interface IRol
    {
        void addRolUser(string rol, string idUser);
        AspNetRoles getRole(string rol);
        List<AspNetRoles> getRols();
    }
}
