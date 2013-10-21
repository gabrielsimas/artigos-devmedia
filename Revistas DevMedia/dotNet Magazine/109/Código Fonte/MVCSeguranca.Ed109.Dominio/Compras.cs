using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Configuration;

namespace MVCSeguranca.Ed109.Entidade
{
   [Table(Name="Compras")]
   public class Compras
   {
       #region Atributos
       private Nullable<long> id;
       private Nullable<long> idCliente;
       private Double total;
       private EntityRef<Cliente> cliente;
       #endregion

       #region Construtores

       public Compras()
       {

       }

       public Compras(Nullable<long> id, Nullable<long> idCliente , Double total, EntityRef<Cliente> cliente)
       {
           this.id = id;
           this.idCliente = idCliente;
           this.total = total;
           this.cliente = cliente;
           
       }

       #endregion

       #region Propriedades

       [Column(Name="Id",IsPrimaryKey=true, IsDbGenerated=true)]
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

       public Nullable<long> IdCliente
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

       [Column(Name="Total")]
       public Double Total
       {
           get
           {
               return this.total;
           }

           set
           {
               this.total = value;
           }
       }

       [Association(ThisKey="IdCliente",OtherKey="Id")]
       public Cliente Cliente
       {
           get
           {
               return this.cliente.Entity;
           }

           set
           {
               this.cliente.Entity  = value;
           }
       }

       #endregion

       #region Sobrescritas

       public override bool Equals(object obj)
       {
           if (obj is Compras)
           {
               Compras compras = (Compras)obj;

               if (compras.Id.HasValue && compras.id.HasValue){
                   return compras.Id.Equals(this.id);
               }
           }

           return false;
       }

       public override string ToString()
       {
           return this.id + ", " + this.total;
       }

       public override int GetHashCode()
       {
           return this.id.HasValue ? this.id.GetHashCode() : 0;
       }

       #endregion
   }
}
    