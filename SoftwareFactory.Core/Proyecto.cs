using System;

namespace SoftwareFactory.Core
{
    public class Proyecto
    {
        public byte IdProyecto { get; set; }
        public Empleado Empleado { get; set; }
        public string Descripcion { get; set; }
        public decimal Presupuesto { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
    }
}
