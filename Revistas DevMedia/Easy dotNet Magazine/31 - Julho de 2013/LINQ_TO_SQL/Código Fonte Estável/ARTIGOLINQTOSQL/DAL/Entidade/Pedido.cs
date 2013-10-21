using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Configuration;
using DAL.Entidade;


namespace DAL.Entidade
{
    [Table(Name="Pedido")]
    public class Pedido
    {

        #region Atributos
        private Int32 id;
        private Int32 idCliente;
        private Double totalPedido;
        
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

        [Column(Name="IdCliente")]
        public Int32 IdCliente
        {
            get
            {
                return this.idCliente;
            }

            set
            {
                this.idCliente = value;
            }
        }

        [Column(Name="TotalPedido",DbType="float")]
        public Double TotalPedido
        {
            get
            {
                return this.totalPedido;
            }

            set
            {
                this.totalPedido = value;
            }
        }

        #endregion

        #region Construtores

        public Pedido()
        {

        }

        public Pedido(int id, int idCliente, Double totalPedido)
        {
            this.Id = id;
            this.IdCliente = idCliente;
            this.TotalPedido = totalPedido;
        }

        #endregion

        #region Sobrescritas
        public override string ToString()
        {
            return this.Id + ", " + this.IdCliente +", " + this.TotalPedido;
        }
        #endregion


    }
}
