using System;

namespace SoftwareFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int Opcion;
            Console.WriteLine("--------SOFTWARE FACTORY-MENU DE OPERACIONES-------");
            Console.WriteLine("(1) Ingresar un nuevo cliente");
            Console.WriteLine("(2) Mostrar los clientes ingresados");
            Console.WriteLine("(3) Salir");
            Console.Write("Ingrese la operacion deseada: ");
            Opcion = Convert.ToInt16(Console.ReadLine());

            switch (Opcion) 
            {
                case 1:

                    break;
                case 2:

                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("No se ha selecionado ninguna opcion");
                    break;

            }
        }
    }
}
