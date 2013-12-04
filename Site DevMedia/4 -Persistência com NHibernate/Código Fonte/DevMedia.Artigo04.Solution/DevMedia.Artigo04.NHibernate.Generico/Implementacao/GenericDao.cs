using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DevMedia.Artigo04.NHibernate.Generico.Interfaces;
using NHibernate;

namespace DevMedia.Artigo04.NHibernate.Generico.Implementacao
{
   public class GenericDao<E> : IDisposable, IGenericDao<E> where E: class
   {
       #region Atributos

       private ISessionFactory fabrica;
       private ISession sessao;
       private ITransaction transacao;

       #endregion

       #region Construtor
       public GenericDao()
       {
           this.fabrica = HibernateUtil.FabricaDeSessao;
       }
       #endregion

       #region Métodos CRUD

       public virtual IList<E> listarTudo()
       {
           try
           {
               this.sessao = HibernateUtil.Sessao;
               var dados = sessao.CreateCriteria(typeof(E)).List();
               return dados.OfType<E>().ToList();
           }
           catch
           {

               throw;
           }
           finally
           {
               HibernateUtil.fechaSessao();
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
               HibernateUtil.fechaSessao();
           }
       }

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

       public void Dispose()
       {
           HibernateUtil.fechaSessao();
       }

       #endregion

   }
}
