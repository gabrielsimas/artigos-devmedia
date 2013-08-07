using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAL.Entidade;
using DAL.Persistencia;
using DAL.Generico;
using Negocio.DTO;
using Negocio.Genericos;

namespace Negocio.CasosDeUso
{
    public class ManterPosicao : BLLGenericaPrincipal<PosicaoDTO,PosicaoDAO,Posicao>
    {
    }
}
