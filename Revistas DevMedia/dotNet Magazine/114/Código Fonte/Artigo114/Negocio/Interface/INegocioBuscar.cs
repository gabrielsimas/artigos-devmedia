// -----------------------------------------------------------------------
// <copyright file="INegocioBuscar.cs" company="CS Services Consultoria em Sistemas">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Negocio.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public interface INegocioBuscar<DTO> where DTO: class
    {
        DTO buscarPorId(int id);
        IList<DTO> buscarTudo();
    }
}
