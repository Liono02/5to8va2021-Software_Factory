﻿using System;
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
            int CUIT;
            string RazonSocial;
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
                    Console.Clear();
                    Console.Write("Ingrese un numero de CUIT: ");
                    CUIT=Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingrese una razon social: ");
                    RazonSocial=Convert.ToString(Console.ReadLine());

                    AdoSoftware.AltaCliente(new Cliente (CUIT,RazonSocial));
                break;
                
                case 2:
                    Console.Clear();
                    
                    break;
                
                    
            }

            }while(opcionMenuAdmin!=3||OpcionMenuCliente!=3 );
        }


    }
}
