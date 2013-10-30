using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MVCSeguranca.Ed109.DTO;

namespace MVCSeguranca.Ed109.DTO.Util
{
    public class AcessoDTO : IAcessoDTO 
    {

        public ClienteDTO clienteDTO
        {
            get
            {
                return this.clienteDTO;
            }
            set
            {
                this.clienteDTO = value;
            }
        }

        public ComprasDTO comprasDTO
        {
            get
            {
                return this.comprasDTO;
            }
            set
            {
                this.comprasDTO = value;
            }
        }

        public UsuarioDTO usuarioDTO
        {
            get
            {
                return this.usuarioDTO;
            }
            set
            {
                this.usuarioDTO = value;
            }
        }

        public PerfilDTO perfilDTO
        {
            get
            {
                return this.perfilDTO;
            }
            set
            {
                this.perfilDTO = value;
            }
        }
    }
}
