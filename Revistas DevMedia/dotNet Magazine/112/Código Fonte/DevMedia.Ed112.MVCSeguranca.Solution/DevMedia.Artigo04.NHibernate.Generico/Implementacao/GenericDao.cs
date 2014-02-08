using System;
using System.Collections.Generic;
using System.Linq;

using DevMedia.Artigo04.NHibernate.Generico.Interfaces;
using NHibernate;

namespace DevMedia.Artigo04.NHibernate.Generico.Implementacao
{
    /// <summary>
    /// Classe Abstrata para Persistência com NHibernate
    /// </summary>
    /// <typeparam name="E">Entidade devidamente Mapeada</typeparam>
   public class GenericDao<E> : IDisposable, IGenericDao<E> where E: class
   {
       #region Atributos

       private ISessionFactory fabrica;
       private ISession sessao;
       private ITransaction transacao;

       #endregion

       #region Construtor
       public GenericDao(String assembly, String stringDeConexao)
       {
           if (HibernateUtil.AssemblyMapeamento == null)
           {
               HibernateUtil.AssemblyMapeamento = assembly;
           }

           if (HibernateUtil.StringDeConexao == null)
           {
               HibernateUtil.StringDeConexao = stringDeConexao;
           }

           if (HibernateUtil.AssemblyMapeamento != null && HibernateUtil.FabricaDeSessao != null){

               fabrica = HibernateUtil.FabricaDeSessao;

           } else {
               throw new Exception("Fabrica de Sessão Nula!");
           }
       }

       #endregion

       #region Métodos OCP
       public ISessionFactory getFabricaDeSessao()
       {
           return HibernateUtil.FabricaDeSessao;
       }

       public ISession getSessao()
       {
           return HibernateUtil.Sessao;
       }

       public Boolean checaSessaoAberta()
       {
           return HibernateUtil.IsJaAberta;
       }

       public void setStringDeConexao(String connString)
       {
           HibernateUtil.StringDeConexao = connString;
       }

       public void setAssembly(String assembly)
       {
           HibernateUtil.AssemblyMapeamento = assembly;
       }

       public void FechaSessao()
       {
           HibernateUtil.fechaSessao();
       }


       #endregion

       #region Métodos CRUD

       /// <summary>
       /// Métodos para buscar todas as Entidades
       /// </summary>
       /// <returns>Lista de Entidades</returns>
       public virtual IList<E> listarTudo()
       {
           try
           {
               ValidaSessionFactory();
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

       private void ValidaSessionFactory()
       {
           if (fabrica == null)
           {
               fabrica = HibernateUtil.FabricaDeSessao;
           }
       }

       /// <summary>
       /// Método que busca uma entidade pelo seu Identificador único
       /// </summary>
       /// <param name="id">Id da Entidade</param>
       /// <returns></returns>
       public virtual E listarPorId(Nullable<long> id)
       { 
           try
           {
               ValidaSessionFactory();
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

       /// <summary>
       /// Persiste uma Entidade na Base de Dados
       /// </summary>
       /// <param name="entidade">Entidade a ser persistida</param>
       public virtual void salvar(E entidade)
       {
           try
           {
               ValidaSessionFactory();
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
       /// Método para atualizar uma entidade
       /// </summary>
       /// <param name="entidade">Entidade ser atualizada</param>
       public virtual void atualizar(E entidade)
       {
           try
           {
               ValidaSessionFactory();
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
       /// Método para exclusão de uma entidade
       /// </summary>
       /// <param name="entidade">Entidade a ser Excluída</param>
       public virtual void excluir(E entidade)
       {
           try
           {
               ValidaSessionFactory();
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
