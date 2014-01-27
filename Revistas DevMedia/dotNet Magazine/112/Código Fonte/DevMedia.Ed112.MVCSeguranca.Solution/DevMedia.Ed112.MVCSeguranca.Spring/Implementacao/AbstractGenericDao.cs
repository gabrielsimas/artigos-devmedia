// -----------------------------------------------------------------------
// <copyright file="AbstractGenericDao.cs" company="CS Services Consultoria em Sistemas">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DevMedia.Ed112.MVCSeguranca.SpringNet.Implementacao
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using DevMedia.Ed112.MVCSeguranca.SpringNet.Interface;
    using Spring.Data.NHibernate;
    using Spring.Data.NHibernate.Support;
    using Spring.Stereotype;
    using Spring.Transaction.Interceptor;
    using NHibernate;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [Repository]
    public abstract class AbstractGenericDao<E>: IGenericDao <E> where E: class
    {

        #region Injeção de Dependências

        protected ISessionFactory sessionFactory;

        protected ISessionFactory SessionFactory
        {
            get
            {
                return this.sessionFactory;
            }

            set
            {
                this.sessionFactory = value;
            }
        }
        #endregion

        #region Métodos CRUD

        [Transaction(ReadOnly=false)]
        public void Criar(E entidade)
        {
            this.SessionFactory.GetCurrentSession().Save(entidade);
        }

        [Transaction(ReadOnly=true)]
        public IList<E> listarTudo()
        {
            var dados = this.SessionFactory.GetCurrentSession().CreateCriteria(typeof(E)).List();
            return dados.OfType<E>().ToList();
        }

        [Transaction(ReadOnly=true)]
        public E listaPorId(int id)
        {
            return this.SessionFactory.GetCurrentSession().Get(typeof(E), id) as E;
        }

        [Transaction(ReadOnly=false)]
        public void Atualizar(E entidade)
        {
            this.SessionFactory.GetCurrentSession().SaveOrUpdate(entidade);
        }

        [Transaction(ReadOnly=false)]
        public void Excluir(E entidade)
        {
            this.SessionFactory.GetCurrentSession().Delete(entidade);
        }

        #endregion
        
    }
}
