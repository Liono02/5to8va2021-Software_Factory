using System;
using System.Collections.Generic;
using et12.edu.ar.AGBD.Ado;

namespace SoftwareFactory.AdoMySql
{
    public class AdoSoftware
    {
        public AdoMySql Ado{ get; set; }
        public AdoMySql MapCliente{ get; set; }
        public AdoSoftware(AdoAGBD Ado)
        {
            Ado=Ado;
            MapCliente= new MapCliente(Ado);
        }
        public void AltaCliente(Cliente cliente) =>MapCliente.AltaCliente(cliente);
        public List<cliente> ObtenerClientes() => MapCliente.ObtenerClientes(); 
    }
}
