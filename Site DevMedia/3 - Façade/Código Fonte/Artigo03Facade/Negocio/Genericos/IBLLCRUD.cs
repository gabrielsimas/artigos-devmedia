using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.Genericos
{
   public interface IBLLCRUD<E>
    {
       Boolean cadastrar(E dto);
       E listarPorId(int id);
       IList<E> listarTudo();
       Boolean alterar(E dto);
       Boolean excluir(E dto);
    }
}
