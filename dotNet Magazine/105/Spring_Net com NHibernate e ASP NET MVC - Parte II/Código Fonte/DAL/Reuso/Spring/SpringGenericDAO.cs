using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
//using DAL.Entidade;
using Spring.Data.NHibernate.Support;
using Spring.Data.NHibernate;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;

namespace DAL.Reuso.Spring
{
    [Repository]
    public abstract class SpringGenericDAO<E> : IGenericDAO<E> where E : class
    {
        
        #region Propriedades
        protected ISessionFactory FabricaDeSessao { get; set; }
        
         
        #endregion

        #region Métodos de Controle
        
        #endregion      
        #region Métodos CRUD
        [Transaction(ReadOnly = true)]
        public IList<E> listarTudo()
        {
            
            var dados = FabricaDeSessao.GetCurrentSession().CreateCriteria(typeof(E)).List();
            return dados.OfType<E>().ToList();
            
        }

        [Transaction(ReadOnly = true)]
        public E listaPorId(int id)
        {
            return FabricaDeSessao.GetCurrentSession().Get(typeof(E), id) as E;
        }

        [Transaction(ReadOnly=false)]
        public void Salvar(E entidade)
        {
            FabricaDeSessao.GetCurrentSession().Save(entidade);
        }

        [Transaction(ReadOnly=false)]
        public void Atualizar(E entidade)
        {
            FabricaDeSessao.GetCurrentSession().SaveOrUpdate(entidade);
        }

        [Transaction(ReadOnly=false)]
        public void Excluir(E entidade)
        {
            FabricaDeSessao.GetCurrentSession().Delete(entidade);
        }
        #endregion
    }
}
