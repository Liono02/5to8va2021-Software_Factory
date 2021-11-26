using System;

namespace Operaciones_de_admin
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuCliente operacionesCliente = new MenuCliente();
            MenuProyecto operacionesProyecto = new MenuProyecto();
            int Opcion;
            int OpcionMenuClientes;
            int OpcionMenuProy;
            do
            {

            
                Console.WriteLine("----------SOFTWARE FACTORY--MENU DE OPERACIONES----------");
                Console.WriteLine("(1) Mostrar menu de operaciones sobre clientes");
                Console.WriteLine("(2) Mostrar menu de operaciones sobre proyectos");
                Console.WriteLine("(3) Salir");
                Console.Write("Ingrese la opcion: ");
                Opcion = Convert.ToInt16(Console.ReadLine());
                switch (Opcion) 
                {
                    case 1:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("----------MENU DE OPERACIONES SOBRE CLIENTES----------");
                            Console.WriteLine("(1) Ingresar un cliente");
                            Console.WriteLine("(2) Mostrar a los clientes");
                            Console.WriteLine("(3) Volver");
                            Console.Write("Ingrese la opcion deseada: ");
                            OpcionMenuClientes=Convert.ToInt16(Console.ReadLine());
                            switch(OpcionMenuClientes)
                            {
                                case 1:
                                    operacionesCliente.DarAltaCliente();
                                    break;
                                case 2:
                                    operacionesCliente.MostrarClientes();
                                    break;
                                case 3:
                                    Console.Clear();
                                    break;
                                default:
                                    Console.WriteLine("No se ha selecionado ninguna opcion...");
                                    break;
                            }
                        }while(OpcionMenuClientes != 3);
                        
                        break;
                    case 2:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("----------MENU DE OPERACIONES SOBRE PROYECTOS----------");
                            Console.WriteLine("(1) Ingresar un Proyecto");
                            Console.WriteLine("(2) Mostrar los Proyectos");
                            Console.WriteLine("(3) Volver");
                            Console.Write("Ingrese la opcion deseada: ");
                            OpcionMenuProy = Convert.ToInt16(Console.ReadLine());
                            switch (OpcionMenuProy)
                            {
                                case 1:
                                    operacionesProyecto.DarAltaProyecto();
                                    break;
                                case 2:
                                    operacionesProyecto.MostrarProyectos();
                                    break;
                                case 3:
                                    Console.Clear();
                                    break;
                                default:
                                    Console.WriteLine("No se ha selecionado ninguna opcion...");
                                    break;
                            }
                        }while(OpcionMenuProy != 3);
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("No se ha ingresado ninguna opcion...");
                        break;
                }   
            }while(Opcion!=3);
        }
    }
}
