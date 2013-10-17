using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Configuration;

namespace MVCSeguranca.Ed109.Entidade
{   
    [Table(Name="Perfil")]
    public class Perfil
    {

        #region atributos

        private Nullable<long> id;
        private Nullable<long> idUsuario;
        private String nome;
        private EntitySet<Usuario> usuarios;

        #endregion

        #region Construtores

        public Perfil()
        {

        }

        public Perfil(Nullable<long> id, String nome, EntitySet<Usuario> usuarios)
        {
            this.id = id;
            this.nome = nome;
            this.usuarios = usuarios;
        }

        #endregion

        #region Propriedades

        [Column(Name="Id",IsPrimaryKey=true,IsDbGenerated=true)]
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

        public Nullable<long> IdUsuario
        {
            get
            {
                return this.idUsuario;
            }

            set
            {
                this.idUsuario = value;
            }
        }

        [Column(Name="Nome")]
        public String Nome
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

        [Association(ThisKey="IdUsuario",OtherKey="Id")]
        public EntitySet<Usuario> Usuarios
        {
            get
            {
                return this.usuarios;
            }

            set
            {
                this.usuarios = value;
            }
        }

        #endregion

        #region Sobrescritas

        public override bool Equals(object obj)
        {

            if (obj is Perfil)
            {
                Perfil perfil = (Perfil)obj;

                if (perfil.Id.HasValue && perfil.id.HasValue){
                    return perfil.Id.Equals(this.id);
                }
            }
            return false;
        }

        public override string ToString()
        {
            return this.id + "," + this.nome;
        }

        public override int GetHashCode()
        {
            return this.id.HasValue ? this.id.GetHashCode() : 0;
        }

        #endregion

    }
}
