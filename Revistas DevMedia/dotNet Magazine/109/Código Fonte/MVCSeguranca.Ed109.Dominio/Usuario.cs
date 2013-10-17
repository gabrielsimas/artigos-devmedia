using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Configuration;

namespace MVCSeguranca.Ed109.Entidade
{
    [Table(Name="Usuario")]
    public class Usuario
    {
        #region Atributos

        private Nullable<long> id;
        private Nullable<long> idPerfil;
        private Nullable<long> idCliente;
        private String login;
        private String senha;
        private EntityRef<Perfil> perfil;
        private EntityRef<Cliente> cliente;

        #endregion

        #region Construtores

        public Usuario()
        {

        }

        public Usuario(Nullable<long> id, Nullable<long> idPerfil, Nullable<long> idCliente ,String login, String senha,EntityRef<Perfil> perfil, EntityRef<Cliente> cliente)
        {
            this.id = id;
            this.login = login;
            this.senha = senha;
            this.perfil = perfil;
            this.cliente = cliente;
        }

        #endregion

        #region Propriedades

        [Column(Name="Id",IsPrimaryKey=true, IsDbGenerated=true)]
        public Nullable<long> Id
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

        public Nullable<long> IdCliente
        {
            get
            {
                return this.idCliente;
            }

            set
            {
                this.idCliente = value;
            }
        }

        public Nullable<long> IdPerfil
        {
            get
            {
                return this.idPerfil;
            }

            set
            {
                this.idPerfil = value;
            }
        }

        [Column(Name="Login")]
        public String Login
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

        [Column(Name="Senha")]
        public String Senha
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

        [Association(ThisKey="IdPerfil",OtherKey="Id")]
        public Perfil Perfil
        {
            get
            {
                return this.perfil.Entity;
            }

            set
            {
                this.perfil.Entity = value;
            }
        }

        [Association(ThisKey="IdCliente",OtherKey="Id")]
        public Cliente Cliente
        {
            get
            {
                return this.cliente.Entity;
            }

            set
            {
                this.cliente.Entity = value;
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
            return this.id + "," + this.login + "," + this.senha;
        }

        public override int GetHashCode()
        {
            return this.id.HasValue ? this.id.GetHashCode() : 0;
        }

        #endregion


    }
}
