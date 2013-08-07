using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.DTO
{
  public class JogadorDTO
  {
      public Int32 Id { get; set; }
      public String NomeCompleto { get; set; }
      public String Apelido { get; set; }
      public DateTime DataNascimento { get; set; }
      public String EstadoNatal { get; set; }
      public String PaisNatal { get; set; }
      public PosicaoDTO Posicao { get; set; }
      public ClubeDTO Clube { get; set; }
  }
}
