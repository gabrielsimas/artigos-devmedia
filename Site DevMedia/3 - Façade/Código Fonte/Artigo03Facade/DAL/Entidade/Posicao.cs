using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entidade
{
    public class Posicao
    {
        #region Atributos

        private Int32 id;
        private String nome;

        private Jogador jogador;

        #endregion

        #region Propriedades
        public virtual Int32 Id
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

        public virtual Jogador Jogador
        {
            get
            {
                return this.jogador;
            }

            set
            {
                this.jogador = value;
            }
        }
        #endregion

        #region Construtores

        public Posicao()
        {

        }

        public Posicao(Int32 id, String nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

        #endregion

        #region Sobrescritas

        public override bool Equals(object obj)
        {
            if (obj is Posicao){
                Posicao posicao = (Posicao)obj;
                if (posicao.Id != null && this.id != null){
                    return posicao.Id.Equals(this.id);
                }
            }

            return false;
        }

        public override string ToString()
        {
            return this.id + ", " + this.nome;
        }

        public override int GetHashCode()
        {
            return this.id != null ? this.id.GetHashCode() : 0;
        }

        #endregion
    }
}
