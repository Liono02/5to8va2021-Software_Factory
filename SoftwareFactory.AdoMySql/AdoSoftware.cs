using System.Collections.Generic;
using et12.edu.ar.AGBD.Ado;
using SoftwareFactory.Core;
using SoftwareFactory.AdoMySql.Mapeadores;


namespace SoftwareFactory.AdoMySql
{
    public class AdoSoftware : IAdo
    {
        public AdoAGBD Ado { get; set; }
        public MapCliente MapCliente { get; set; }
        public AdoSoftware(AdoAGBD ado)
        {
            Ado = ado;
            MapCliente = new MapCliente(Ado);
            MapProyecto= new MapProyecto(Ado);
        }
        public void AltaCliente(Cliente cliente) => MapCliente.AltaCliente(cliente);
        public List<Cliente> ObtenerClientes() => MapCliente.ObtenerClientes();

    }
}
