using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Linq.Expressions;

namespace MVCSeguranca.Ed109.Generic.Interface
{
    public interface IGenericDAO<E> where E: class
    {
        Boolean salvar(E entidade);
        IList<E> listarTudo();
        E ListarPorId(Expression<Func<E, bool>> predicado);
        Boolean Alterar(E entidade);
        Boolean Excluir(E entidade);
    }
}
