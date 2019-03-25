using AutoMapper;
using ModelsSGH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Automapper
{
    public class AutomapperConfig
    {
        public static void Configure() {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<TreatmentUnitDTO, TreatmentUnit>().ReverseMap();
                cfg.CreateMap<ComponentDTO, Component>().ReverseMap();
                cfg.CreateMap<EquipmentDTO, Equipment>().ReverseMap();
            });
        }
    }
}
