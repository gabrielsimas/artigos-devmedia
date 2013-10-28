using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCSeguranca.Ed109.Entidade
{
    
    public class Usuario
    {
        #region Atributos

        private Nullable<long> id;
        private String login;
        private String senha;
        private String senhaMD5;
        private String senhaPBKDF2;
        private Perfil perfil;
        private Cliente cliente;

        #endregion

        #region Construtores

        public Usuario()
        {

        }

        public Usuario(Nullable<long> id, String login, String senha, String senhaMD5, String senhaPBKDF2, Perfil perfil, Cliente cliente)
        {
            this.id = id;
            this.login = login;
            this.senha = senha;
            this.senhaMD5 = senhaMD5 ;
            this.senhaPBKDF2 = senhaPBKDF2;
            this.perfil = perfil;
            this.cliente = cliente;
        }

        #endregion

        #region Propriedades

        
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

        public virtual String SenhaMD5
        {
            get
            {
                return this.senhaMD5;
            }

            set
            {
                this.senhaMD5 = value;
            }
        }

        public virtual String SenhaPBKDF2
        {
            get
            {
                return this.senhaPBKDF2;
            }

            set
            {
                this.senhaPBKDF2 = value;
            }
        }

        public virtual Perfil Perfil
        {
            get
            {
                return this.perfil;
            }

            set
            {
                this.perfil = value;
            }
        }

        
        public virtual Cliente Cliente
        {
            get
            {
                return this.cliente;
            }

            set
            {
                this.cliente = value;
            }
        }

        #endregion

        #region Sobrescritas

        public override bool Equals(object obj)
        {
            if (obj is Usuario)
            {
                Usuario usuario = (Usuario)obj;

                if (usuario.Id.HasValue  && usuario.id.HasValue )
                {
                    return usuario.Id.Equals(this.id);
                }

            }

            return false;
        }

        public override string ToString()
        {
            return this.id + "," + this.login + "," + this.senha + "," + this.senhaMD5 + "," + this.senhaPBKDF2;
        }

        public override int GetHashCode()
        {
            return this.id.HasValue ? this.id.GetHashCode() : 0;
        }

        #endregion


    }
}
