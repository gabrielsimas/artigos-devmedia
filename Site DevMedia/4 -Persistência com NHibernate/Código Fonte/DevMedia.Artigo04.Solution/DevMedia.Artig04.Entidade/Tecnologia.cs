using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevMedia.Artigo04.Entidade
{
    public class Tecnologia
    {
        #region Atributos
        private Nullable<long> id;
        private String nome;

        private Artigo artigo;
        #endregion

        #region Construtores
        public Tecnologia()
        {

        }

        public Tecnologia(int id, String nome, Artigo artigo)
        {
            this.id = id;
            this.nome = nome;
            this.artigo = artigo;
        }
        #endregion

        #region Propriedades
        
        public virtual Nullable<long> Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public virtual String Nome
        {
            get { return this.nome; }
            set { this.nome = value; }
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
            if(obj is Tecnologia ){
                Tecnologia tecnologia = (Tecnologia)obj;

                if (tecnologia.Id != null && this.id != null){
                    return tecnologia.Id.Equals(this.id);
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
            return this.id +","+ this.nome;
        }
        #endregion
    }
}
