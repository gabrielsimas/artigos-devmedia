using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MVCSeguranca.Ed109.DTO;

namespace MVCSeguranca.Ed109.DTO.Util
{
    public interface IAcessoDTO
    {
        ClienteDTO  clienteDTO {get; set;}
        ComprasDTO comprasDTO { get; set; }
        UsuarioDTO usuarioDTO { get; set; }
        PerfilDTO perfilDTO { get; set; }
    }
}
