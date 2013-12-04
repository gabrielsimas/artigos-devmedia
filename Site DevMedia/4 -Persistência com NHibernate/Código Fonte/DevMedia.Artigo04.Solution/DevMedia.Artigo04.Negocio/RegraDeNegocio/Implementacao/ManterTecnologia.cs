using DevMedia.Artigo04.Negocio.RegraDeNegocio.Interface;
using DevMedia.Artigo04.Dal.Implementacao;
using DevMedia.Artigo04.Dto;
using DevMedia.Artigo04.Entidade;

namespace DevMedia.Artigo04.Negocio.RegraDeNegocio.Implementacao
{
    public class ManterTecnologia : NegocioAbstratoGenerico<TecnologiaDto,TecnologiaDao,Tecnologia>, IManterTecnologia
    {

    }
}
