using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Spring.Data;
using Spring.Data.NHibernate.Support;
using Spring.Data.NHibernate;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using NHibernate;

using MVCSeguranca.Ed109.Generic.Interface.Spring;
using System.Reflection;

namespace MVCSeguranca.Ed109.Generic.Implementacao.Spring
{
    [Repository]
    public class AbstractGenericDAO<E> : IGenericDAO<E> where E: class, new()
    {

        #region Atributos

        private ISessionFactory criaFabricaSessao;
        private HibernateTemplate hibernate;
        private Boolean isSucesso;
    
        #endregion

        #region Propriedades

        protected ISessionFactory CriaFabricaSessao
        {
            set
            {
                this.hibernate = new HibernateTemplate(value);
            }
        }

        public Boolean IsSucesso
        {
            get
            {
                return this.isSucesso;
            }

            set
            {
                this.isSucesso = value;
            }
        }

        #endregion

        #region CRUD
        public bool ehSucesso()
        {
            return this.isSucesso;
        }


        [Transaction(transactionPropagation: global::Spring.Transaction.TransactionPropagation.Required,ReadOnly=false)]
        public void criar(E entidade) 
        {
            try
            {
                hibernate.Save(entidade);
                this.isSucesso = true;
            }
            catch (Exception )
            {
                this.isSucesso = false;
                throw;
                
            }
            
        }

        [Transaction(transactionPropagation: global::Spring.Transaction.TransactionPropagation.Supports,ReadOnly=true)]
        public IList<E> ListarTudo()
        {
            try {
             
                IList<E> lista = new List<E>();

               lista = hibernate.LoadAll(typeof(E)).Cast<E>().ToList();
               this.isSucesso = true;
               return lista;
            }
            catch (Exception)
            {
                this.isSucesso = false;
                throw;
            }
        }

        [Transaction(transactionPropagation:global::Spring.Transaction.TransactionPropagation.Supports,ReadOnly=true)]
        public E listarPorId(Nullable<long> id)
        {
            try
            {
                E entidade = new E();
                entidade = (E)hibernate.Load(typeof(E), id);
                this.isSucesso = true;
                return entidade;
            }
            catch (Exception)
            {
                this.isSucesso = false;
                throw;
            } 
        }

        [Transaction(transactionPropagation: global::Spring.Transaction.TransactionPropagation.Required,ReadOnly=false)]
        public void atualizar(E entidade)
        {
            try
            {
                hibernate.Update(entidade);
                this.isSucesso = true;
            }
            catch (Exception)
            {
                this.isSucesso = false;
                throw;
            }
        }

        [Transaction(transactionPropagation: global::Spring.Transaction.TransactionPropagation.Required,ReadOnly=false)]
        public void apagar(E entidade)
        {
            try
            {
                hibernate.Delete(entidade);
                this.isSucesso = true;
            }
            catch (Exception)
            {
                this.isSucesso = false;
                throw;
            }

        }

        public void x9(E entidade)
        {
            FieldInfo[] fields = entidade.GetType().GetFields();
            String str = "";
            foreach (FieldInfo f in fields)
            {
                Console.WriteLine("{0} => {1}\r\n",f.Name,f.GetValue(entidade));
            }

            Console.Out.WriteLine(str);
        }

        #endregion
    }
}
