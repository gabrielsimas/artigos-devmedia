using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data.Linq;

using MVCSeguranca.Ed109.Generic.Interface;

namespace MVCSeguranca.Ed109.Generic.Implementacao
{
    public abstract class AbstractGenericDAO<E,F> : IDisposable,IGenericDAO<E> where E: class where F: DataContext
    {

        #region Atributos

        internal F dataSource;
        private bool disposed = false;

        #endregion

        #region Construtores

        public AbstractGenericDAO(F fonteDeDados)
        {
            this.dataSource = fonteDeDados;
        }

        #endregion

        #region Métodos Crud

        public void salvar(E entidade)
        {
            this.dataSource.GetTable<E>().InsertOnSubmit(entidade);
        }

        public IList<E> listarTudo()
        {
            return this.dataSource.GetTable<E>().ToList();
        }

        public E ListarPorId(System.Linq.Expressions.Expression<Func<E, bool>> predicado)
        {
            return this.dataSource.GetTable<E>().Single(predicado);
        }

        public void Alterar(E entidade)
        {
            this.dataSource.GetTable<E>().Attach(entidade, true);
        }

        public void Excluir(E entidade)
        {
            this.dataSource.GetTable<E>().DeleteOnSubmit(entidade);
        }

        #endregion

        #region Limpeza do objeto

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.dataSource.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
