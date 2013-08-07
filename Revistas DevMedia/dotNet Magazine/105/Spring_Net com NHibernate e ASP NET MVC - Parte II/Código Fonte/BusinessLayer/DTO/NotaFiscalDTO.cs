using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.DTO
{
    public class NotaFiscalDTO
    {
        public  String Tipo {get; set;}
        public DateTime DtEntrega { get; set; }
        public DateTime DtNota { get; set; }
        public Double Total { get; set; }

        public int IdFornecedor { get; set; }
        public String NomeFornecedor { get; set; }

        public IList<ItemNotaDTO> itemsNotaDTO { get; set; }


    }
}
