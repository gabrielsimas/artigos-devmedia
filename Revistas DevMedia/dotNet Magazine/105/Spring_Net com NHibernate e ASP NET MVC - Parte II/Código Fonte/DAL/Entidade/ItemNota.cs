using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entidade
{
    public class ItemNota
    {
        #region Atributos
        private int id;
        private Double precoUnitario;
        private int quantidade;
        private Double totalLinha;

        private NotaFiscal notaFiscal;
        private Produto produto;
        #endregion

        #region Propriedades
        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual int Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

        public virtual Double PrecoUnitario
        {
            get { return precoUnitario; }
            set { precoUnitario = value; }
        }

        public virtual Double TotalLinha
        {
            get {
                totalLinha = this.PrecoUnitario * this.Quantidade;
                return totalLinha;
            }

            set
            {
                totalLinha = this.PrecoUnitario * this.Quantidade;
            }
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
        public ItemNota(int id, Double precoUnitatio, int quantidade, Double totalLinha, Produto produto, NotaFiscal notaFiscal)
        {
            this.Id = id;
            this.PrecoUnitario = precoUnitario;
            this.Quantidade = quantidade;
            this.TotalLinha = totalLinha;
            this.Produto = produto;
            this.NotaFiscal = notaFiscal;
        }

        public ItemNota()
        {

        }
        #endregion

        #region Sobrescritas
        public override bool Equals(object obj)
        {
            if (obj is ItemNota)
            {
                ItemNota itemNota = obj as ItemNota;

                if (obj != null)
                {
                    return itemNota.Id.Equals(this.Id);
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
            return this.Id.ToString() + ", " + this.PrecoUnitario.ToString() + ", " + this.Quantidade.ToString() + ", " + this.TotalLinha.ToString() + this.Produto + this.NotaFiscal;
        }
        #endregion
    }
}
