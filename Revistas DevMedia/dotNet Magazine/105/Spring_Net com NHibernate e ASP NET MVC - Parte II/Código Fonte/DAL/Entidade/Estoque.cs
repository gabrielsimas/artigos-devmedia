using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entidade
{
    public class Estoque
    {
        #region Atributos
        private int id;
        private Double custo;
        private int quantidade;
        private int qtdNovoPedido;

        private Produto produto;
        private NotaFiscal notaFiscal;
        #endregion

        #region Propriedades

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual Double Custo
        {
            get { return custo; }
            set { custo = value; }
        }

        public virtual int Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

        public virtual int QtdNovoPedido
        {
            get { return qtdNovoPedido; }
            set { qtdNovoPedido = value; }
        }

        public virtual Produto Produto
        {
            get { return produto; }
            set { produto = value; }
        }

        public virtual NotaFiscal NotaFiscal
        {
            get { return notaFiscal; }
            set { notaFiscal = value; }
        }

        #endregion

        #region Construtores
        public Estoque()
        {

        }

        public Estoque(int id, Double custo, int quantidade, int qtdNovoPedido, Produto produto, NotaFiscal notaFiscal)
        {
            this.Id = id;
            this.Custo = custo;
            this.Quantidade = quantidade;
            this.QtdNovoPedido = qtdNovoPedido;
            this.Produto = produto;
            this.NotaFiscal = notaFiscal;
        }
        #endregion

        #region Sobrescritas
        
        public override bool Equals(object obj)
        {
            if (obj is Estoque)
            {
                Estoque estoque = obj as Estoque;

                if (obj != null)
                {
                    return estoque.Id.Equals(this.Id);
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
            return this.Id.ToString() + ", " + this.Custo.ToString() + ", " + this.Quantidade.ToString() + ", " + this.QtdNovoPedido.ToString() + ", " + this.Produto + this.NotaFiscal;
        }
        #endregion
    }
}
