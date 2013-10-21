using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAL.Entidade;
using DAL.FonteDeDados;
using System.Data.Linq;
using System.Linq.Expressions;

namespace DAL.Persistencia
{
    public abstract class AbstractDAL<E> : IGenericDAL<E> where E: class
    {

        #region Atributos

        private ConexaoBD conexao;

        #endregion

        #region Propriedades

        public ConexaoBD Conexao
        {
            get
            {
                return this.conexao;
            }

            set
            {
                this.conexao = value;
                     
            }
        }

        #endregion

        #region Construtores

        public AbstractDAL()
        {
            Conexao = new ConexaoBD();
        }

        #endregion

        #region Métodos

        public void Salvar(E entidade)
        {
            Conexao.GetTable<E>().InsertOnSubmit(entidade);
            Conexao.SubmitChanges();
        }

        public void Alterar(E entidade)
        {
            Conexao.GetTable<E>().Attach(entidade, true);
            Conexao.SubmitChanges();
        }

        public void Excluir(E entidade)
        {
            Conexao.GetTable<E>().DeleteOnSubmit(entidade);
            Conexao.SubmitChanges();
        }

        public List<E> listarTudo()
        {
            return Conexao.GetTable<E>().ToList();
        }

        public E ListarPorId(Expression<Func<E, bool>> predicado)
        {
            return Conexao.GetTable<E>().Single(predicado);
        }

        #endregion

        
    }
}
