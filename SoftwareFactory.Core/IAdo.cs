using System.Collections.Generic;

namespace SoftwareFactory.Core
{
    public interface IAdo
    {
        // Cliente
        void AltaCliente(Cliente cliente);
        List<Cliente> ObtenerClientes();
        // Proyecto
        void AltaProyecto(Proyecto proyecto);
        List<Proyecto> ObtenerProyectos();
    }
}