using System;

namespace SoftwareFactory.Core
{
    public class Proyecto
    {
        public short IdProyecto { get; set; }
        public Cliente Cliente { get; set; }
        public string Descripcion { get; set; }
        public decimal Presupuesto { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime? Fin { get; set; }

        public Proyecto() { }
        public Proyecto(Cliente cliente, string descripcion, decimal presupuesto, DateTime inicio)
        {
            Cliente = cliente;
            Descripcion = descripcion;
            Presupuesto = presupuesto;
            Inicio = inicio;
            Fin = null;
        }
    }
}
