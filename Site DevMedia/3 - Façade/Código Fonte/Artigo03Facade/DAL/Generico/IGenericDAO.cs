using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Generico
{
    public interface IGenericDAO<E> where E: class
    {
        IList<E> listarTudo();
        E listarPorId(Int32 id);
        void salvar(E entidade);
        void atualizar(E entidade);
        void excluir(E entidade);
    }
}
