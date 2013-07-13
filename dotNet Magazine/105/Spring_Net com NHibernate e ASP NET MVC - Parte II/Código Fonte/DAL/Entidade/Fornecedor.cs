using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entidade
{
    public class Fornecedor
    {
        #region Atributos
        private int id;
        private String nome;

        #endregion

        #region Construtores
        public Fornecedor()
        {

        }

        public Fornecedor(int id, String nome)
        {
            this.Id = id;
            this.Nome = nome;
            //this.NotasFiscais = notas;
        }
        #endregion

        #region Métodos

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

        #endregion

        #region Sobrescrita
        public override bool Equals(object obj)
        {
            if (obj is Fornecedor)
            {
                Fornecedor fornecedor = obj as Fornecedor;

                if (obj != null)
                {
                    return fornecedor.Id.Equals(this.Id);
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
            return this.Id.ToString() + ", " + this.Nome;
        }
        #endregion
    }
}
