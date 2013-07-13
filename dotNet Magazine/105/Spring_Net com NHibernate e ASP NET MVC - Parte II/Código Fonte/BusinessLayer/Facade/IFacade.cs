using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Facade
{
    public interface IFacade<F> where F: class
    {
        Boolean salvar(F dto);
        Boolean editar(F dto);
        Boolean excluir(F dto);
        F buscaPorId(int id);
        IList<F> buscarTodos();
    }
}
