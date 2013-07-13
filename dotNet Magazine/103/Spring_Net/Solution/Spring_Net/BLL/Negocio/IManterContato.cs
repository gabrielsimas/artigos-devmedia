using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAL.Entidade;
using DAL.Persistencia;

namespace BLL.Negocio
{
    public interface IManterContato
    {
        Boolean InserirContato(Contato contato);
        Boolean AtualizarContato(Contato contatoNovo);
        Boolean ExcluirContato(Contato contato);
        List<Contato> listarContatos();
        Contato buscarContatoPorId(int id);
    }
}
