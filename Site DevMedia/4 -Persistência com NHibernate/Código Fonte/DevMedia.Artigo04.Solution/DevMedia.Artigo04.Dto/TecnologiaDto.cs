using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevMedia.Artigo04.Dto
{
    public class TecnologiaDto
    {
        public Nullable<long> Id {get; set;}
        public String Nome {get; set;}

        public ArtigoDto ArtigoDto { get; set; }
    }
}
