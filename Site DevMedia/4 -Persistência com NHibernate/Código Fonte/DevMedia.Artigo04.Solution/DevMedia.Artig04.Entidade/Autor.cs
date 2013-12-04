using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevMedia.Artigo04.Entidade
{
    public class Autor
    {

        #region Atributos
        private Nullable<long> id;
        private String nomeCompleto;
        private String email;
        private String contaDevmedia;

        private Artigo artigo;
        #endregion

        #region Construtores
        public Autor()
        {

        }

        public Autor(int id, String nomeCompleto, String email, String contaDevmedia, Artigo artigo)
        {
            this.id = id;
            this.nomeCompleto = nomeCompleto;
            this.email = email;
            this.contaDevmedia = contaDevmedia;
            this.artigo = artigo;
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

        public virtual String NomeCompleto
        {
            get
            {
                return this.nomeCompleto;
            }

            set
            {
                this.nomeCompleto = value;
            }
        }

        public virtual String Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
            }
        }

        public virtual String ContaDevmedia
        {
            get
            {
                return this.contaDevmedia;
            }

            set
            {
                this.contaDevmedia = value;
            }
        }

        public virtual Artigo Artigo
        {
            get
            {
                return this.artigo;
            }

            set
            {
                this.artigo = value;
            }
        }
        #endregion

        #region Sobrescritas
        public override bool Equals(object obj)
        {
            if (obj is Autor)
            {
                Autor autor = (Autor)obj;

                if (autor.Id != null && this.id != null)
                {
                    return autor.Id.Equals(this.id);
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.id != null ? this.id.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return this.id + "," + this.nomeCompleto + "," + this.email + "," + this.contaDevmedia;
        }
        #endregion

    }
}
