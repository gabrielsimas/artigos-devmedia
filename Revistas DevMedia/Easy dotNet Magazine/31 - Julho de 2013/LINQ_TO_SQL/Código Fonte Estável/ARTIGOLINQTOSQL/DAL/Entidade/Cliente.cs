using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Configuration;

namespace DAL.Entidade
{
    [Table(Name="CLIENTE")]
    public class Cliente
    {

        #region Atributos
        private Int32 id;
        private String nome;
        private String email;
        private Int32 idPais;
        private Int32 idPedido;
        private EntityRef<Pais> pais;

        #endregion

        #region Propriedades

        [Column(Name = "Id", IsPrimaryKey = true, IsDbGenerated = true)]
        public Int32 Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
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

        [Column(Storage="idPais",Name="IdPais")]
        public Int32 IdPais
        {
            get
            {
                return this.idPais;
            }

            set
            {
                this.idPais = value;
            }
        }

        public Int32 IdPedido {
            set {
                this.idPedido = value;
            }

            get {
                return this.idPedido;
            }
        }

        [Association(Storage = "pedidos", ThisKey = "IdPedido", OtherKey = "Id")]
        public EntitySet<Pedido> Pedidos
        {
            get
            {
                return this.pedidos;
            }

            set
            {
                this.pedidos = value;
            }

        }
    

        [Association(Storage="pais",ThisKey="IdPais",OtherKey="Id")]
        public Pais Pais
        {
            get
            {
                return this.pais.Entity;
            }

            set
            {
                this.pais.Entity = value;
            }
        }
        #endregion

        #region Construtores

        public Cliente()
        {
            this.Pais = new Pais();
        }

        public Cliente(int id, String nome, String email, Pais pais)
        {
            this.Id = id;
            this.Nome = nome;
            this.Email = email;
            this.Pais = pais;
        }

        #endregion

        #region Sobrescritas
        public override string ToString()
        {
            return this.Id + ", " + this.Nome + ", " + this.Email + ", " + this.Pais;
        }

        #endregion

    }
}
