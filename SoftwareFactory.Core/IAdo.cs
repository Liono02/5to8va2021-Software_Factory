using System.Collections.Generic;

namespace SoftwareFactory.Core
{
    public interface IAdo
    {
        void AltaCliente(Cliente cliente);
        void AltaProyecto(Proyecto proyecto);
        List<Cliente> ObtenerClientes();
        List<Proyecto> ObtenerProyecto();
    }
}