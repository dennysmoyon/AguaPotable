using ModelsSGH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.LN
{
    public interface IUsers
    {
        UsersDTO getUser(string id);
        List<UsersDTO> getUsers();
    }
}
