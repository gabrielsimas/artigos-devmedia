using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using DAL.Generico;

namespace DAL.Generico
{
    public abstract class GenericDAO<E> : IGenericDAO<E>,IDisposable where E: class
    {
        #region Atributos
        private ISessionFactory fabrica;
        private ISession sessao;
        private ITransaction transacao;
        #endregion
        
        #region Construtores

        /// <summary>
        /// 
        /// </summary>
        public GenericDAO()
        {
            fabrica = HibernateUtil.FabricaDeSessao;
        }

        #endregion

        #region Métodos
        /// <summary>
        /// 
        /// </summary>
        /// <returns>E</returns>
        public virtual IList<E> listarTudo()
        {
            try
            {
                sessao = fabrica.OpenSession();
                var dados = sessao.CreateCriteria(typeof(E)).List();
                return dados.OfType<E>().ToList();
            }
            catch
            {
                throw;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>E</returns>
        public virtual E listarPorId(int id)
        {
            try
            {
                sessao = fabrica.OpenSession();
                E dado = (E) sessao.Get(typeof(E),id);
                return dado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidade"></param>
        public virtual void salvar(E entidade)
        {
            try
            {
                sessao = fabrica.OpenSession();
                transacao = sessao.BeginTransaction();
                sessao.Save(entidade);
                transacao.Commit();
            }
            catch (Exception)
            {
                transacao.Rollback();
                throw;
            }
            finally
            {
                HibernateUtil.fechaSessao();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidade"></param>
        public virtual void atualizar(E entidade)
        {
            try
            {
                sessao = fabrica.OpenSession();
                transacao = sessao.BeginTransaction();
                sessao.Update(entidade);
                transacao.Commit();
            }
            catch (Exception)
            {
                transacao.Rollback();
                throw;
            }
            finally
            {
                HibernateUtil.fechaSessao();
            }
        }

        /// <summary>
        /// Exclui a 
        /// </summary>
        /// <param name="entidade"></param>
        public virtual void excluir(E entidade)
        {
            try
            {
                sessao = fabrica.OpenSession();
                transacao = sessao.BeginTransaction();
                sessao.Delete(entidade);
                transacao.Commit();
            }
            catch (Exception)
            {
                transacao.Rollback();
                throw;
            }
            finally
            {
                HibernateUtil.fechaSessao();
            }
        }
        #endregion

        /// <summary>
        /// Destrói o objeto
        /// </summary>
        public void Dispose()
        {
            HibernateUtil.fechaSessao();
        }
    }
}
