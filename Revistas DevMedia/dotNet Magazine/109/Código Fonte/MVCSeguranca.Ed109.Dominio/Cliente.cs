using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCSeguranca.Ed109.Entidade
{
    
    public class Cliente
    {
        #region Atributos

        private Nullable<long> id;
        private String nome;
        private String email;
        private IList<Compras> compras;

        #endregion

        #region Construtores

        public Cliente()
        {

        }

        public Cliente(Nullable<long> id, String nome, String email)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
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

        public virtual IList<Compras> Compras
        {
            get
            {
                return this.compras;
            }

            set
            {
                this.compras = value;
            }
        }

        #endregion

        #region Sobrescritas
        public override bool Equals(object obj)
        {
            if (obj is Cliente)
            {
                Cliente cliente = (Cliente)obj;
                
                if (cliente.Id.HasValue && cliente.id.HasValue){
                    return cliente.Id.Equals(cliente.id);
                }
            }

            return false;
        }

        public override string ToString()
        {
            return this.id + ", " + this.nome + "," + this.email;
        }

        public override int GetHashCode()
        {
            return this.id.HasValue ? this.id.GetHashCode() : 0;
        }
        #endregion
    }
}
