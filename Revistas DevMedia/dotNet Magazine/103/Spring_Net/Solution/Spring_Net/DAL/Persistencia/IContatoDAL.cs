using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAL.Entidade;

namespace DAL.Persistencia
{
    public interface IContatoDAL
    {
        void Salvar(Contato entidade);
        List<Contato> listarTudo();
        Contato listarPorId(int id);
        void Atualizar(Contato entidade);
        void Apagar(Contato entidade);
    }
}
