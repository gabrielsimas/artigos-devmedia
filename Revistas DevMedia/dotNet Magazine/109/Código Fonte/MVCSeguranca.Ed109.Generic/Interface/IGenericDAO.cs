using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Linq.Expressions;

namespace MVCSeguranca.Ed109.Generic.Interface
{
    public interface IGenericDAO<E> where E: class
    {
        void salvar(E entidade);
        IList<E> listarTudo();
        E ListarPorId(Expression<Func<E, bool>> predicado);
        void Alterar(E entidade);
        void Excluir(E entidade);
    }
}
