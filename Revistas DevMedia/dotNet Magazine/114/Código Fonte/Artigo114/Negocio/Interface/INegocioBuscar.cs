namespace Negocio.Interface
{
    using System.Collections.Generic;

    public interface INegocioBuscar<DTO> where DTO: class
    {
        DTO buscarPorId(int id);
        IList<DTO> buscarTudo();
    }
}
