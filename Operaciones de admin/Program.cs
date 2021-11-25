using System;

namespace Operaciones_de_admin
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuCliente operaciones = new MenuCliente();
            MenuProyecto operaciones2 = new MenuProyecto();
            int Opcion;
            Console.WriteLine("----------SOFTWARE FACTORY--MENU DE OPERACIONES----------");
            Console.WriteLine("(1) Mostrar menu de operaciones sobre clientes");
            Console.WriteLine("(2) Mostrar menu de operaciones sobre proyectos");
            Console.WriteLine("(3) Salir");
            Console.Write("Ingrese la opcion: ");
            Opcion = Convert.ToInt16(Console.ReadLine());
            switch (Opcion) 
            {
                case 1:
                    operaciones.MenuParaClientes(Opcion);
                break;
                case 2:
                operaciones2.MenuParaProyectos(Opcion);
                break;
                case 3:
                    break;
                default:
                    Console.WriteLine("No se ha ingresado ninguna opcion...");
                break;
            }
        }
    }
}
