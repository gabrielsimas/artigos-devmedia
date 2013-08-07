using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.DTO
{
   public class PosicaoDTO
    {

       public Int32 Id { get; set; }
       public String Nome { get; set; }

       public JogadorDTO Jogador { get; set; }

    }
}
