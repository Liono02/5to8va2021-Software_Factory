using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System;
using System.Data;
using System.Collections.Generic;
using SoftwareFactory.Core;


namespace SoftwareFactory.AdoMySql.Mapeadores
{
    public class MapCliente: Mapeador<Cliente>
    {
        public MapCliente(AdoAGBD ado):base(ado)
        {
            Tabla="Cliente";
        }
        public override Cliente ObjetoDesdeFila(DataRow fila)
        => new Cliente
        (
            CUIT : Convert.ToInt32(fila["CUIT"]),
            RazonSocial : fila["RazonSocial"].ToString()
        );
        public void AltaCliente(Cliente cliente)
        => EjecutarComandoCon("AltaCliente",ConfigurarAltaCliente,cliente);
        public void ConfigurarAltaCliente(Cliente cliente)
        {
            SetComandoSP("altaCliente");

            BP.CrearParametro("unCuit")
            .SetValor(cliente.CUIT)
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .AgregarParametro();

            BP.CrearParametro("unaRazonSocial")
            .SetTipoVarchar(45)
            .SetValor(cliente.RazonSocial)
            .AgregarParametro();

        }
        public List<Cliente> ObtenerClientes() => ColeccionDesdeTabla();
        
    }   
}