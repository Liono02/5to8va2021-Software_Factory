using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;
using SoftwareFactory.Core;

namespace Operaciones_de_admin
{
    class MenuCliente
    {
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
            Console.Write("Ingrese la opcion deseada");
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
                    break;
                default:
                    Console.WriteLine("No se ha selecionado ninguna opcion...");
                    break;   
            }

            }while(opcionMenuAdmin!=3||OpcionMenuCliente!=3 );
        }
            public void DarAltaCliente()
            {
                int CUIT;
                string RazonSocial;
                Console.Clear();
                Console.Write("Ingrese un numero de CUIT: ");
                CUIT=Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese una razon social: ");
                RazonSocial=Convert.ToString(Console.ReadLine());

                AdoSoftware.AltaCliente(new Cliente (CUIT,RazonSocial));
            }
            public void MostrarClientes()
            {
                List<Cliente> clientes=new List<Cliente>(AdoSoftware.ObtenerClientes());
                   
                Console.Clear();
                for(int i=0;i<clientes.Count;i++)
                {
                    Console.WriteLine(clientes[i]);
                }
            }

    }
}
