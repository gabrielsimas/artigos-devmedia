using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Reuso
{
    public interface IGenericDAO<T> where T: class
    {
        IList<T> listarTudo();
        T listaPorId(int id);
        void Salvar(T entidade);
        void Atualizar(T entidade);
        void Excluir(T entidade);

    }
}
