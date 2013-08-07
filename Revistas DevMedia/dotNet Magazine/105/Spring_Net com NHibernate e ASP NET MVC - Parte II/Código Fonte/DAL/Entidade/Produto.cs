using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entidade
{
    public class Produto
    {
        #region Atributos
        private int id;
        private String nome;
        private Double preco;
        private Double pctLucro;

        #endregion

        #region Propriedades
        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual String Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public virtual Double Preco
        {
            get { return preco; }
            set { preco = value; }
        }

        public virtual Double PctLucro
        {
            get { return pctLucro; }
            set { pctLucro = value; }
        }

        
         
        #endregion

        #region Construtores

        public Produto()
        {

        }

        public Produto(int id, String nome, Double preco, Double pctLucro/*, ItemNota item*/)
        {
            this.Id = id;
            this.Nome = nome;
            this.Preco = preco;
            this.PctLucro = pctLucro;
            //this.ItemNota = item;
        }

        #endregion

        #region Sobrescritas
        public override bool Equals(object obj)
        {
            if (obj is Produto)
            {
                Produto produto = obj as Produto;

                if (obj != null)
                {
                    return produto.Id.Equals(this.Id);
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Id > 0 ? this.Id.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return this.Id.ToString() + ", " + this.Nome + ", " + this.Preco.ToString() + ", " + this.PctLucro.ToString() /*+ this.ItemNota*/; 
        }
        #endregion
    }
}
