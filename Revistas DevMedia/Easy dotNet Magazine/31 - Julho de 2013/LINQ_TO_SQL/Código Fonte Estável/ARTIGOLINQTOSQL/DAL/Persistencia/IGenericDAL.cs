using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Persistencia
{
    public interface IGenericDAL<E> where E: class
    {
        void Salvar(E entidade);
        List<E> listarTudo();
        E ListarPorId(Expression<Func<E, bool>> predicado);
        void Alterar(E entidade);
        void Excluir(E entidade);
    }
}
