using System;
using System.Collections.Generic;
using et12.edu.ar.AGBD.Ado;
using SoftwareFactory.Core;
using SoftwareFactory.AdoMySql;

namespace Operaciones_de_admin
{
    public class MenuCliente
    {
        IAdo Ado = new AdoSoftware(FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "admin"));
        public void DarAltaCliente()
        {
            int cUIT;
            string razonSocial;
            Console.Clear();
            Console.Write("Ingrese un numero de CUIT: ");
            cUIT = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese una razon social: ");
            razonSocial = Convert.ToString(Console.ReadLine());

            Ado.AltaCliente(new Cliente(cUIT, razonSocial));
        }
        public void MostrarClientes()
        {
            Console.Clear();
            Console.WriteLine("-----LISTA DE CLIENTES-----");
            List<Cliente> clientes = Ado.ObtenerClientes();
            for (int i = 0; i < clientes.Count; i++)
            {
                
                Console.WriteLine(clientes[i]);
            }
            Console.ReadKey();
        }

    }
}
