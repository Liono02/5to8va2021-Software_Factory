using System;

namespace Operaciones_de_admin
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuCliente operaciones = new MenuCliente();
            int Opcion;
            Console.WriteLine("----------SOFTWARE FACTORY--MENU DE OPERACIONES----------");
            Console.WriteLine("(1) Mostrar menu de operaciones sobre clientes");
            Console.WriteLine("(2) Salir");
            Console.Write("Ingrese la opcion: ");
            Opcion = Convert.ToInt16(Console.ReadLine());
            switch (Opcion) 
            {
                case 1:
                    operaciones.MenuParaClientes(Opcion);
                break;
                case 2:
                break;
                default:
                    Console.WriteLine("No se ha ingresado ninguna opcion");
                break;
            }
        }
    }
}
