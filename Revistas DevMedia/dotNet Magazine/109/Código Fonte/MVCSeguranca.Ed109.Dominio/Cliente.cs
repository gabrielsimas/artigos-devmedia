using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Configuration;

namespace MVCSeguranca.Ed109.Entidade
{
    [Table(Name="Cliente")]
    public class Cliente
    {
        #region Atributos
        private Nullable<long> id;
        private Nullable<long> idCompras;
        private String nome;
        private String email;
        private EntitySet<Compras> compras;

        #endregion

        #region Construtores

        public Cliente()
        {

        }

        public Cliente(Nullable<long> id, Nullable<long> idCompras,String nome, String email)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.idCompras = idCompras;
        }
        #endregion

        #region Propriedades

        [Column(Name="Id",IsPrimaryKey=true,IsDbGenerated=true)]
        public Nullable<long> Id
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

        public Nullable<long> IdCompras
        {
            get
            {
                return this.idCompras;
            }

            set
            {
                this.idCompras = value;
            }
        }

        [Column(Name="Nome")]
        public String Nome
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

        [Column(Name="Email")]
        public String Email
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

        [Association(ThisKey="IdCompras",OtherKey="Id")]
        public EntitySet<Compras> Compras
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
