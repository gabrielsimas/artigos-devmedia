using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevMedia.Artigo04.Dto
{
    public class AutorDto
    {
        public Nullable<long> Id { get; set; }

        public String NomeCompleto { get; set; }

        public String Email { get; set; }

        public String ContaDevmedia { get; set; }

        public ArtigoDto ArtigoDto { get; set; }
    }
}
