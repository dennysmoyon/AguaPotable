using ModelsSGH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.LN
{
    public interface IComponent
    {
        void AddComponent(ComponentDTO componentDTO);
        void UpdateComponent(ComponentDTO componentDTO);
        void DeleteComponent(int id);
        ComponentDTO GetComponent(int idComp);
        ComponentDTO GetComponent(string codComp);
        List<ComponentDTO> GetComponents();
    }
}
