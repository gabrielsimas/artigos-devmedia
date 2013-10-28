using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCSeguranca.Ed109.Entidade
{   
    public class Perfil
    {

        #region atributos

        private Nullable<long> id;
        private String nome;
        private IList<Usuario> usuarios;

        #endregion

        #region Construtores

        public Perfil()
        {

        }

        public Perfil(Nullable<long> id, String nome, IList<Usuario> usuarios)
        {
            this.id = id;
            this.nome = nome;
            this.usuarios = usuarios;
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

        public virtual IList<Usuario> Usuarios
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
