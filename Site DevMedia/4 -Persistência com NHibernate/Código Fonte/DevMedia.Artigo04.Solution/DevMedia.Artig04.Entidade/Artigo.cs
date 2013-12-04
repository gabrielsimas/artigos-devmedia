using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevMedia.Artigo04.Entidade
{
    public class Artigo
    {
        #region Atributos
        private Nullable<long> id;
        private String titulo;
        private String descricao;
        private Double valor;
        private DateTime dataInicio;
        private DateTime dataFim;
        private DateTime dataPublicacao;

        private Tecnologia tecnologia;
        private Autor autor;
        #endregion

        #region Construtores
        public Artigo()
        {

        }

        public Artigo(int id, String titulo, String descricao, Double valor, DateTime dataInicio, DateTime dataFim, DateTime dataPublicacao, Tecnologia tecnologia, Autor autor)
        {
            this.id = id;
            this.titulo = titulo;
            this.descricao = descricao;
            this.valor = valor;
            this.dataInicio = dataInicio;
            this.dataFim = dataFim;
            this.dataPublicacao = dataPublicacao;
            this.tecnologia = tecnologia;
            this.autor = autor;
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

        public virtual String Titulo
        {
            get
            {
                return this.titulo;
            }
            set
            {
                this.titulo = value;
            }
        }

        public virtual String Descricao
        {
            get
            {
                return this.descricao;
            }

            set
            {
                this.descricao = value;
            }
        }

        public virtual Double Valor
        {
            get
            {
                return this.valor;
            }

            set
            {
                this.valor = value;
            }
        }

        public virtual DateTime DataInicio
        {
            get
            {
                return this.dataInicio;
            }

            set
            {
                this.dataInicio = value;
            }
        }

        public virtual DateTime DataFim
        {
            get
            {
                return this.dataFim;
            }

            set
            {
                this.dataFim = value;
            }
        }

        public virtual DateTime DataPublicacao
        {
            get
            {
                return this.dataPublicacao;
            }

            set
            {
                this.dataPublicacao = value;
            }
        }

        public virtual Autor Autor
        {
            get
            {
                return this.autor;
            }

            set
            {
                this.autor = value;
            }
        }

        public virtual Tecnologia Tecnologia
        {
            get
            {
                return this.tecnologia;
            }

            set
            {
                this.tecnologia = value;
            }
        }

        #endregion

        #region Sobrescritas
        public override bool Equals(object obj)
        {
            if (obj is Artigo)
            {
                Artigo artigo = (Artigo)obj;

                if (artigo.Id != null && this.id != null)
                {
                    return artigo.Id.Equals(this.id);
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
            return this.id + "," + this.titulo + "," + this.descricao + "," + this.valor + "," + this.dataInicio + "," + this.dataFim + "," + this.dataPublicacao;
        }
        #endregion
    }
}
