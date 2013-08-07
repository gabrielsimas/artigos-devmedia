using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Negocio.Genericos;
using Negocio.DTO;
using DAL.Entidade;
using DAL.Persistencia;
using DAL.Generico;

namespace Negocio.CasosDeUso
{
    public class ManterClube : BLLGenericaPrincipal<ClubeDTO,ClubeDAO,Clube>, IEspecificoClube
    {

        public IList<ClubeDTO> ListarClubesPorEstado(string estado)
        {
            try
            {
                IList<Clube> clubes = new List<Clube>();
                IList<ClubeDTO> clubesDTO = new List<ClubeDTO>();

                clubes = InstanciaDAO().listarTudo().Where(cl => cl.Estado == estado).ToList();

                foreach(Clube clube in clubes){
                    ClubeDTO clubeDTO = new ClubeDTO();
                    Utils.Copy(typeof(Clube), clube, typeof(ClubeDTO), clubeDTO);
                    clubesDTO.Add(clubeDTO);
                }

                return clubesDTO;

            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public IList<ClubeDTO> ListarClubesPorCidade(string cidade)
        {
               try
                {
                    IList<Clube> clubes = new List<Clube>();
                    IList<ClubeDTO> clubesDTO = new List<ClubeDTO>();

                    clubes = InstanciaDAO().listarTudo().Where(cl => cl.Cidade == cidade).ToList();

                    foreach (Clube clube in clubes)
                    {
                        ClubeDTO clubeDTO = new ClubeDTO();
                        Utils.Copy(typeof(Clube), clube, typeof(ClubeDTO), clubeDTO);
                        clubesDTO.Add(clubeDTO);
                    }

                    return clubesDTO;

                }
                catch (Exception)
                {

                    throw;
                }
            
        }
    }
}
