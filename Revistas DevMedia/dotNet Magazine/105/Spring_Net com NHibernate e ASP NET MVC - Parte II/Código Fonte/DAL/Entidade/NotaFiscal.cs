using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entidade
{
    public class NotaFiscal
    {
        #region Atributos

        private int id;
        private String tipo;
        private DateTime dtEntrega;
        private DateTime dtNota;
        private Double total;

        private Fornecedor fornecedor;
        private IList<ItemNota> itemsNota;

        #endregion

        #region Propriedades
        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual String Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public virtual DateTime DtEntrega {
            get {return dtEntrega;}
            set {dtEntrega = value;}
        }

        public virtual DateTime DtNota {
            get {return dtNota;}
            set {dtNota = value;}
        }

        public virtual Double Total
        {
            get { return total; }
            set { total = value; }
        }

        public virtual Fornecedor Fornecedor
        {
            get { return fornecedor; }
            set { fornecedor = value; }
        }

        public virtual IList<ItemNota> ItemsNota
        {
            get { return itemsNota; }
            set { itemsNota = value; }
        }
        #endregion

        #region Construtores
        public NotaFiscal()
        {

        }

        public NotaFiscal(int id, String tipo, DateTime dtEntrega, DateTime dtNota, Double total, Fornecedor fornecedor, IList<ItemNota> itemsNota )
        {
            this.Id = id;
            this.Tipo = tipo;
            this.DtEntrega = dtEntrega;
            this.DtNota = dtNota;
            this.Total = total;
            this.Fornecedor = fornecedor;
            this.ItemsNota = itemsNota;
        }
        #endregion

        #region Sobrescritas
        public override bool Equals(object obj)
        {
            if (obj is NotaFiscal)
            {
                NotaFiscal notaFiscal = obj as NotaFiscal;

                if (obj != null)
                {
                    return notaFiscal.Id.Equals(this.Id);
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
            return this.Id.ToString() + ", " + this.Tipo + ", " + this.DtEntrega.ToString() + ", " + this.DtNota.ToString() + ", " + this.Total.ToString() + ", " + this.Fornecedor + ", " + this.ItemsNota;
        }
        #endregion
        }
}
