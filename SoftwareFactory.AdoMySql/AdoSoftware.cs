using System;
using System.Collections.Generic;
using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using SoftwareFactory.Core;

namespace SoftwareFactory.AdoMySql
{
    public class AdoSoftware
    {
        public AdoMySql Ado{ get; set; }
        public AdoMySql MapCliente{ get; set; }
        public AdoSoftware(AdoAGBD ado)
        {
            Ado=ado;
            MapCliente= new MapCliente(Ado);
        }
        public void AltaCliente(Cliente cliente) =>MapCliente.AltaCliente(cliente);
        public List<Cliente> ObtenerClientes() => MapCliente.ObtenerClientes(); 
        
    }
}
