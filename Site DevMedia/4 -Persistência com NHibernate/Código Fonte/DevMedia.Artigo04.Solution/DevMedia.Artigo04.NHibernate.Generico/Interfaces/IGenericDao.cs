using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevMedia.Artigo04.NHibernate.Generico.Interfaces
{
    public interface IGenericDao<E> where E: class
    {
        IList<E> listarTudo();
        E listarPorId(Nullable<long> id);
        void salvar(E entidade);
        void atualizar(E entidade);
        void excluir(E entidade);
    }
}
