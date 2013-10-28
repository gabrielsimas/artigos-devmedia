using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Configuration;

namespace MVCSeguranca.Ed109.Entidade
{
   public class Compras
   {
       #region Atributos

       private Nullable<long> id;
       private Double total;
       private Cliente cliente;

       #endregion

       #region Construtores

       public Compras()
       {

       }

       public Compras(Nullable<long> id, Double total, Cliente cliente)
       {
           this.id = id;
           this.total = total;
           this.cliente = cliente;
           
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

       public virtual Double Total
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

       public virtual Cliente Cliente
       {
           get
           {
               return this.cliente;
           }

           set
           {
               this.cliente = value;
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
    