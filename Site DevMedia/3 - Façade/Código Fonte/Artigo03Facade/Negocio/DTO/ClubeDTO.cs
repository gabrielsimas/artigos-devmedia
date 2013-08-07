using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.DTO
{
    public class ClubeDTO
    {
        public Int32 Id { get; set; }
        public String NomeCompleto { get; set; }
        public String Apelido { get; set; }
        public DateTime DataFundacao { get; set; }
        public String Distintivo { get; set; }
        public String Cidade { get; set; }
        public String Estado { get; set; }
        public List<JogadorDTO> Elenco { get; set; }

        /*
        public override string ToString()
        {
            return Id + ", \n" + NomeCompleto + ", \n" + Apelido + ", \n" + DataFundacao + ", \n" + Distintivo + ", \n" + Cidade + ", \n" + Estado;
        }
         */
    }
}
