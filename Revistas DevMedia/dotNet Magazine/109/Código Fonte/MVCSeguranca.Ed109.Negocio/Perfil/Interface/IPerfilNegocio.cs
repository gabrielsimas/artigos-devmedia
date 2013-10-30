using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MVCSeguranca.Ed109.DTO;

namespace MVCSeguranca.Ed109.Negocio.Perfil.Interface
{
    public interface IPerfilNegocio
    {

        Boolean cadastraPerfil(PerfilDTO dto);
        IList<PerfilDTO> listarPerfil();
    }
}
