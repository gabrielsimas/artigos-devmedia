using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Negocio.DTO;

namespace Negocio.Genericos
{
    public interface IEspecificoJogador
    {
        JogadorDTO ListarJogadorPeloCodigoConfederacao(int codCBF);
        IList<JogadorDTO> ListarJogadorPeloNome(String nome);
    }
}
