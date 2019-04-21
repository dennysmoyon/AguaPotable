using AutoMapper;
using ModelsSGH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.LN
{
    public class UsersImplement : IUsers
    {
        public UsersDTO getUser(string id)
        {
            using (var dbContext = new DataFlowSensorsDBEntities()) {
                return  Mapper.Map<UsersDTO>(dbContext.AspNetUsers.FirstOrDefault(usr => usr.Id == id));
            }
        }

        public List<UsersDTO> getUsers()
        {
            List<UsersDTO> listUsers = new List<UsersDTO>();
            using (var dbContext = new DataFlowSensorsDBEntities())
            {
                var _listUsers = dbContext.AspNetUsers.ToList();
                UsersDTO user = null;
                foreach (var item in _listUsers) {
                    user = new UsersDTO();
                    user.Id = item.Id;
                    user.UserName = item.UserName;
                    user.Hometown = item.Hometown;
                    user.Email = item.Email;
                    if (item.AspNetRoles.ToList().Count > 0)
                    {
                        var role = item.AspNetRoles.ToList()[0];
                        user.IdRole = role.Id;
                        user.DescriptionRole = role.Name;
                    }
                    else {
                        user.IdRole = "";
                        user.DescriptionRole = "";

                    }
                    user.ListaRoles = Mapper.Map<List<RolesDTO>>(dbContext.AspNetRoles.ToList());
                    listUsers.Add(user);
                }
                return listUsers;
            }
        }
    }
}
