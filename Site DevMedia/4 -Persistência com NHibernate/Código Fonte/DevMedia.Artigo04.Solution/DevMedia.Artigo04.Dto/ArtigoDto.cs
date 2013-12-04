using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevMedia.Artigo04.Dto
{
    public class ArtigoDto
    {
        public Nullable<long> Id {get; set;}
        public String Titulo {get; set;}
        public String Descricao {get; set;}
        public Double Valor {get; set;}
        public DateTime DataInicio {get; set;}
        public DateTime DataFim {get; set;}
        public DateTime DataPublicacao {get; set;}

        public TecnologiaDto Tecnologia {get; set;}
        public AutorDto Autor { get; set; }
       
    }
}
