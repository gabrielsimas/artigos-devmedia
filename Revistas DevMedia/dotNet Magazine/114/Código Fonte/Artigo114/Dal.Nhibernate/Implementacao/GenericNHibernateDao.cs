// -----------------------------------------------------------------------
// <copyright file="GenericNHibernateDao.cs" company="CS Services Consultoria em Sistemas">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Orm.Nhibernate.Dal.Implementacao
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Orm.Nhibernate.Dal.Interface;
    using NHibernate;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public abstract class GenericNHibernateDao<E> : IDisposable, IGenericDao<E> where E: class
    {
        
        #region Atributos

        private ISessionFactory fabrica;
        private ISession sessao;
        private ITransaction transacao;
        private Boolean isTeste = true;
        
        #endregion

        #region Construtor
        public GenericNHibernateDao()
        {
            this.fabrica = NHibernateUtils.FabricaDeSessao;
        }

        public GenericNHibernateDao(Boolean IsTeste)
        {
            this.fabrica = NHibernateUtils.FabricaDeSessao;
        }
        #endregion

        #region Métodos CRUD

        public virtual void setTeste(Boolean isTeste){
            if (isTeste == null) {
                isTeste = false;
            }

            this.isTeste = isTeste;
        }

        public virtual IList<E> listarTudo()
        {
            try
            {
                this.sessao = NHibernateUtils.Sessao;
                var dados = sessao.CreateCriteria(typeof(E)).List();
                return dados.OfType<E>().ToList();
            }
            catch
            {

                throw;
            }
            finally
            {
                NHibernateUtils.fechaSessao();
            }
        }

        public virtual E listarPorId(Nullable<long> id)
        {
            try
            {
                sessao = fabrica.OpenSession();
                E dado = (E)sessao.Get(typeof(E), id);
                return dado;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                NHibernateUtils.fechaSessao();
            }
        }

        public virtual void salvar(E entidade)
        {
            try
            {
                sessao = fabrica.OpenSession();
                transacao = sessao.BeginTransaction();
                sessao.Save(entidade);

                if (!this.isTeste)
                {
                    transacao.Commit();
                }
                else
                {
                    transacao.Rollback();
                }
            }
            catch (Exception)
            {
                transacao.Rollback();
                throw;
            }
            finally
            {
                NHibernateUtils.fechaSessao();
            }
        }

        public virtual void atualizar(E entidade)
        {
            try
            {
                sessao = fabrica.OpenSession();
                transacao = sessao.BeginTransaction();
                sessao.Update(entidade);

                if (!this.isTeste)
                {
                    transacao.Commit();
                }
                else
                {
                    transacao.Rollback();
                }
            }
            catch (Exception)
            {
                transacao.Rollback();
                throw;
            }
            finally
            {
                NHibernateUtils.fechaSessao();
            }
        }

        public virtual void excluir(E entidade)
        {
            try
            {
                sessao = fabrica.OpenSession();
                transacao = sessao.BeginTransaction();
                sessao.Delete(entidade);

                if (!this.isTeste)
                {
                    transacao.Commit();
                }
                else
                {
                    transacao.Rollback();
                }
            }
            catch (Exception)
            {
                transacao.Rollback();
                throw;
            }
            finally
            {
                NHibernateUtils.fechaSessao();
            }
        }

        public void Dispose()
        {
            NHibernateUtils.fechaSessao();
        }

        #endregion
        
    }
}
