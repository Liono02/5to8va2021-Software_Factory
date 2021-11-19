using System;
using System.Collections.Generic;
using et12.edu.ar.AGBD.Ado;
using SoftwareFactory.Core;
using SoftwareFactory.AdoMySql;

namespace Operaciones_de_admin
{
    class MenuCliente
    {
        IAdo Ado = new AdoSoftware(FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "admin"));
        public void MenuParaClientes( int Opcion) 
        {
            int opcionMenuAdmin=Opcion;
            int OpcionMenuCliente;

            do
            {
                Console.Clear();
                Console.WriteLine("----------MENU DE OPERACIONES SOBRE CLIENTES----------");
                Console.WriteLine("(1) Ingresar un cliente");
                Console.WriteLine("(2) Mostrar a los clientes");
                Console.WriteLine("(3) Salir");
                Console.Write("Ingrese la opcion deseada: ");
                
                OpcionMenuCliente=Convert.ToInt16(Console.ReadLine());
                switch(OpcionMenuCliente)
                {
                    case 1:
                        DarAltaCliente();
                        break;
                    case 2:
                        MostrarClientes();
                        break;
                    case 3:
                        opcionMenuAdmin = 3;
                        break;
                    default:
                        Console.WriteLine("No se ha selecionado ninguna opcion...");
                        break;   
                }

            }while(opcionMenuAdmin!=3);
        }
            public void DarAltaCliente()
            {
                int cUIT;
                string razonSocial;
                Console.Clear();
                Console.Write("Ingrese un numero de CUIT: ");
                cUIT=Convert.ToInt32(Console.ReadLine());
                Console.Write("Ingrese una razon social: ");
                razonSocial=Convert.ToString(Console.ReadLine());

                Ado.AltaCliente(new Cliente (cUIT,razonSocial));
            }
            public void MostrarClientes()
            {
                List<Cliente> clientes=new List<Cliente>(Ado.ObtenerClientes());
            
                
                for(int i=0;i<clientes.Count;i++)
                {
                    Console.WriteLine(clientes[i]);
                }
            }

    }
}
