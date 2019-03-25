using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WaterMonitoringSystemApp.Reesources
{
    public static class ParameterClass
    {
        /// <summary>
        /// Roles de usuarios
        /// </summary>
        public static string Supervisor = "Supervisor";
        public static string Administrador = "Administrador";
        public static string Invitado = "Invitado";

        /// <summary>
        /// Tipo de codigos a generar
        /// </summary>
        public static string codTypeComponent = "COM";
        public static string codTypeEquiment = "EQU";
        public static string codTypeTreatmentUnit = "UTR";

    }
}