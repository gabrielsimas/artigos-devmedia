using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCSeguranca.Ed109.DTO
{
    public class PerfilDTO
    {

        private Nullable<long> id;
        private String nome;
        private IList<UsuarioDTO> usuariosDTO;

        public virtual Nullable<long> Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        public virtual String Nome
        {
            get
            {
                return this.nome;
            }
            set
            {
                this.nome = value;
            }
        }

        public virtual IList<UsuarioDTO> UsuariosDTO
        {
            get
            {
                return this.usuariosDTO;
            }

            set
            {
                this.usuariosDTO = value;
            }
        }

    }
}
