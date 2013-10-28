using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCSeguranca.Ed109.Generic.Interface.Spring
{
    public interface IGenericDAO<E> where E: class
    {
        void criar(E entidade);
        IList<E> ListarTudo();
        E listarPorId(Nullable<long> id);
        void atualizar(E entidade);
        void apagar(E entidade);
        Boolean ehSucesso();
        void x9(E entidade);
    }
}
