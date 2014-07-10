// -----------------------------------------------------------------------
// <copyright file="GenericSpringNetDao.cs" company="CS Services Consultoria em Sistemas">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace IoC.SpringNet.Dal.Implementacao
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using IoC.SpringNet.Dal.Interface;

    using NHibernate;
    using Spring.Stereotype;
    using Spring.Transaction.Interceptor;

    /// <summary>
    /// Classe abstrata genérica para persistência do Spring.NET com NHibernate
    /// </summary>
    [Repository]
    public abstract class GenericSpringNetDao<E> : IGenericDao<E> where E: class
    {

        #region Injeção de Dependências

        protected ISessionFactory FabricaDeSessao { get; set; }

        #endregion

        #region Métodos CRUD

        [Transaction(ReadOnly = true)]
        public IList<E> listarTudo()
        {
            var dados = FabricaDeSessao.GetCurrentSession().CreateCriteria(typeof(E)).List();
            return dados.OfType<E>().ToList();
        }

        [Transaction(ReadOnly = true)]
        public E listarPorId(long? id)
        {
            return FabricaDeSessao.GetCurrentSession().Get(typeof(E), id) as E;
        }

        [Transaction(Spring.Transaction.TransactionPropagation.Required,ReadOnly = false)]
        public void salvar(E entidade)
        {
            FabricaDeSessao.GetCurrentSession().Save(entidade);
        }

        [Transaction(Spring.Transaction.TransactionPropagation.Required, ReadOnly = false)]
        public void atualizar(E entidade)
        {
            FabricaDeSessao.GetCurrentSession().SaveOrUpdate(entidade);
        }

        [Transaction(Spring.Transaction.TransactionPropagation.Required, ReadOnly = false)]
        public void excluir(E entidade)
        {
            FabricaDeSessao.GetCurrentSession().Delete(entidade);
        }

        [Transaction(Spring.Transaction.TransactionPropagation.Required, ReadOnly = true)]
        public ISessionFactory pegaFabricaDeSessao()
        {
            return this.FabricaDeSessao;
        }
        

        #endregion
    }
}
