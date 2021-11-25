using System;
using System.Collections.Generic;
using et12.edu.ar.AGBD.Ado;
using SoftwareFactory.Core;
using SoftwareFactory.AdoMySql;

namespace Operaciones_de_admin
{
    public class MenuProyecto
    {
        IAdo Ado = new AdoSoftware(FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "admin"));
        public void MenuParaProyectos(int Opcion)
        {
            int opcionMenuAdmin = Opcion;
            int OpcionMenuCliente;

            do
            {
                Console.Clear();
                Console.WriteLine("----------MENU DE OPERACIONES SOBRE Proyectos----------");
                Console.WriteLine("(1) Ingresar un Proyecto");
                Console.WriteLine("(2) Mostrar los Proyectos");
                Console.WriteLine("(3) Salir");
                Console.Write("Ingrese la opcion deseada: ");

                OpcionMenuCliente = Convert.ToInt16(Console.ReadLine());
                switch (OpcionMenuCliente)
                {
                    case 1:
                        DarAltaProyecto();
                        break;
                    case 2:
                        MostrarProyectos();
                        break;
                    case 3:
                        opcionMenuAdmin = 3;
                        break;
                    default:
                        Console.WriteLine("No se ha selecionado ninguna opcion...");
                        break;
                }

            } while (opcionMenuAdmin != 3);
        }
            public void DarAltaProyecto()
        {
            short idProyecto;
            string Descripcion;
            decimal Presupuesto;
            DateTime Inicio;
            DateTime? Fin;
            Fin=null;

            Console.Clear();
            Console.Write("Ingrese un id de proyecto: ");
            idProyecto = Convert.ToByte(Console.ReadLine());
            Cliente cliente = SeleccionarCliente();
            Console.Write("Ingrese una descripcion: ");
            Descripcion=Convert.ToString(Console.ReadLine());
            Console.Write("Ingrese un presupuesto: ");
            Presupuesto=Convert.ToDecimal(Console.ReadLine());
            Console.Write("Ingrese una fecha de inicio: ");
            Inicio=Convert.ToDateTime(Console.ReadLine());

            Ado.AltaProyecto(new Proyecto(idProyecto, cliente, Descripcion, Presupuesto, Inicio ));
        }

        private Cliente SeleccionarCliente()
        {
            int opc;
            List<Cliente> clientes = Ado.ObtenerClientes();
            for (int i = 0; i < clientes.Count; i++)
            {
                
                Console.WriteLine($"{i}) {clientes[i]}");
            }
            Console.Write("Ingrese x) cliente deseado en el proyecto: ");
            opc=Convert.ToInt32(Console.ReadLine());
            return clientes[opc];
        }

        public void MostrarProyectos()
        {
            Console.WriteLine("-----LISTA DE PROYECTOS-----");
            List<Proyecto> proyectos = Ado.ObtenerProyectos();
            for (int i = 0; i < proyectos.Count; i++)
            {
                
                Console.WriteLine(proyectos[i]);
            }
            Console.ReadKey();
        }
    }
}