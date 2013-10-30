using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCSeguranca.Ed109.DTO
{
    public class UsuarioDTO
    {
        private Nullable<long> id;
        private String login;
        private String senha;
        private String senhaCrypto;
        private String algoritmo;
        private PerfilDTO perfilDTO;
        private ClienteDTO clienteDTO;

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

        public virtual String Login
        {
            get
            {
                return this.login;
            }

            set
            {
                this.login = value;
            }
        }


        public virtual String Senha
        {
            get
            {
                return this.senha;
            }

            set
            {
                this.senha = value;
            }
        }

        public virtual String SenhaCrypto
        {
            get
            {
                return this.senhaCrypto;
            }

            set
            {
                this.senhaCrypto = value;
            }
        }

        public virtual String Algoritmo
        {
            get
            {
                return this.algoritmo;
            }

            set
            {
                this.algoritmo = value;
            }
        }

        public virtual PerfilDTO PerfilDTO
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


        public virtual ClienteDTO ClienteDTO
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
    }
}
