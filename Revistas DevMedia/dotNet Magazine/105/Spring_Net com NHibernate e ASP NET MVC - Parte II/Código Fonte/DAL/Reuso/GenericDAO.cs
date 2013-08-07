using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAL.Util;
using NHibernate;

namespace DAL.Reuso
{
    public abstract class GenericDAO<E> : IDisposable, IGenericDAO<E> where E: class
    {
        #region Atributos
        private ISessionFactory fabrica;
        private ISession sessao;
        private ITransaction transacao;
        #endregion
        
        #region Construtores

        public GenericDAO()
        {
            fabrica = HibernateUtil.FabricaDeSessao;
        }

        #endregion

        #region Métodos
        public IList<E> listarTudo()
        {
            try
            {
                sessao = fabrica.OpenSession();
                //transacao = sessao.BeginTransaction();
                var dados = sessao.CreateCriteria(typeof(E)).List();
                return dados.OfType<E>().ToList();
            }
            catch
            {
                //transacao.Rollback();
                throw;
            }
            
        }

        public E listaPorId(int id)
        {
            try
            {
                sessao = fabrica.OpenSession();
                //sessao = IniciadorNHibernate.PegaSessaoAtual();
                return sessao.Get(typeof(E), id) as E;
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Salvar(E entidade)
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
                if (sessao.IsOpen)
                {
                    sessao.Close();
                }
            }
        }

        public void Atualizar(E entidade)
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
                if (sessao.IsOpen)
                {
                    sessao.Close();
                }
            }
        }

        /// <summary>
        /// Exclui a 
        /// </summary>
        /// <param name="entidade"></param>
        public void Excluir(E entidade)
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
                if (sessao.IsOpen)
                {
                    sessao.Close();
                }
            }
        }
        #endregion

        /// <summary>
        /// Destrói o objeto
        /// </summary>
        public void Dispose()
        {
            if (sessao.IsOpen)
            {
                sessao.Close();
            }

            fabrica.Close();
        }
    }
}
