using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.DTO
{
    public class ItemNotaDTO
    {
        //public int Id { get; set; }

        public int IdNotaFiscal { get; set; }

        public Double PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
        public Double TotalLinha { get; set; }

        public int IdProduto { get; set; }
        public String NomeProduto { get; set; }
        public Double PrecoProduto { get; set; }
        public Double PctLucro { get; set; }
    }
}
