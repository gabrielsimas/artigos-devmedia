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
    public class ManterJogador : BLLGenericaPrincipal<JogadorDTO,JogadorDAO,Jogador>, IEspecificoJogador
    {

        public JogadorDTO ListarJogadorPeloCodigoConfederacao(int codCBF)
        {
            try
            {

                Jogador jogador = new Jogador();
                JogadorDTO jogadorDTO = new JogadorDTO();

                jogador = InstanciaDAO().listarTudo().Where(jg => jg.IdConf == codCBF).Single();

                Utils.Copy(typeof(Jogador), jogador, typeof(JogadorDTO), jogadorDTO);

                return jogadorDTO;
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public IList<JogadorDTO> ListarJogadorPeloNome(string nome)
        {
            try
            {
                IList<Jogador> jogadores = new List<Jogador>();
                IList<JogadorDTO> jogadoresDTO = new List<JogadorDTO>();
                
                jogadores = InstanciaDAO().listarTudo().Where(jg => jg.NomeCompleto.Contains(nome)).ToList();

                foreach(Jogador jogador in jogadores){

                    JogadorDTO dto = new JogadorDTO();
                    Utils.Copy(typeof(Jogador),jogador,typeof(JogadorDTO),dto);
                    jogadoresDTO.Add(dto);
                }

                return jogadoresDTO;

            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
