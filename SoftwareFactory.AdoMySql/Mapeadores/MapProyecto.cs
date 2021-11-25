using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System;
using System.Data;
using System.Collections.Generic;
using SoftwareFactory.Core;

namespace SoftwareFactory.AdoMySql.Mapeadores
{
    public class MapProyecto: Mapeador<Proyecto>
    {
         public MapProyecto(AdoAGBD ado):base(ado)
        {
            Tabla="Cliente";
        }
    }
}