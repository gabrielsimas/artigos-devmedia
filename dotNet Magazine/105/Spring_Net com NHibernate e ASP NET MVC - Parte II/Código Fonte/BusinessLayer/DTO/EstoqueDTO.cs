using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.DTO
{
    public class EstoqueDTO
    {
        //public int Id { get; set; }
        
        public int IdNotaFiscal { get; set; }
        
        public Double Custo { get; set; }
        public int Quantidade {get; set;}
        public int QtdNovoPedido { get; set; }
        
        public int IdProduto { get; set; }
        public String NomeProduto { get; set; }
        public Double PrecoProduto { get; set; }
        public Double PctLucro { get; set; }
        
    }
}
