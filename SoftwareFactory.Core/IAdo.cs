using System.Collections.Generic;

namespace SoftwareFactory.Core
{
    public interface IAdo
    {
        void AltaCliente(Cliente cliente);
        List<Cliente> ObtenerClientes();
        void AltaProyecto(Proyecto proyecto);
        List<Proyecto> ObtenerProyecto();
    }
}