using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System;
using System.Data;
using System.Collections.Generic;
using SoftwareFactory.Core;
using MySql.Data.MySqlClient;

namespace SoftwareFactory.AdoMySql.Mapeadores
{
    public class MapProyecto: Mapeador<Proyecto>
    {
        public MapCliente MapCliente{ get; set; }
        public MapProyecto(AdoAGBD ado):base(ado)
        {
            Tabla="Proyecto";
        }

        public MapProyecto(MapCliente mapCliente): this(mapCliente.AdoAGBD)
            => MapCliente = mapCliente;
        public override Proyecto ObjetoDesdeFila(DataRow fila)
        => new Proyecto()
        {
            IdProyecto = Convert.ToInt16(fila["idProyecto"]),
            Cliente = MapCliente.ClientePorCuit(Convert.ToInt32(fila["CUIT"])),
            Descripcion = Convert.ToString(fila["Descripcion"]),
            Presupuesto = Convert.ToDecimal(fila["Presupuesto"]),
            Inicio = Convert.ToDateTime(fila["Inicio"]),
            Fin = Convert.ToDateTime(fila["Fin"] != DBNull.Value ? fila["Fin"] : null )
        };
        
        public void AltaProyecto(Proyecto proyecto)
        => EjecutarComandoCon("AltaProyecto",ConfigurarAltaProyecto,proyecto);
        public void ConfigurarAltaProyecto(Proyecto proyecto)
        {
            SetComandoSP("altaProyecto");

            BP.CrearParametro("unIdProyecto")
            .SetValor(proyecto.IdProyecto)
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .AgregarParametro();

            BP.CrearParametro("unCuit")
            .SetTipo(MySqlDbType.Int32)
            .SetValor(proyecto.Cliente.CUIT)
            .AgregarParametro();

            BP.CrearParametro("unaDescripcion")
            .SetTipoVarchar(45)
            .SetValor(proyecto.Descripcion)
            .AgregarParametro();

            BP.CrearParametro("unPresupuesto")
            .SetTipoDecimal(10,2)
            .SetValor(proyecto.Presupuesto)
            .AgregarParametro();

            BP.CrearParametro("unInicio")
            .SetTipo(MySqlDbType.DateTime)
            .SetValor(proyecto.Inicio)
            .AgregarParametro();

            BP.CrearParametro("unFin")
            .SetTipo(MySqlDbType.DateTime)
            .SetValor(proyecto.Fin)
            .AgregarParametro();

        }

        public List<Proyecto> ObtenerProyectos() => ColeccionDesdeTabla();
    }
}