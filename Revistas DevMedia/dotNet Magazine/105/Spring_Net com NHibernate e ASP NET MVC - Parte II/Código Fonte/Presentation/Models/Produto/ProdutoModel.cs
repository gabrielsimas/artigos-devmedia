using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Models.Produto
{
    public class ProdutoModel
    {
        [Required(ErrorMessage = "Informe o Nome do Produto.")]
        [Display(Name = "Nome do Produto: ")]
        [DataType(DataType.Text)]
        public String Nome {get; set;}

        [Required(ErrorMessage = "Informe o Preço do Produto.")]
        [Display(Name="Preço do Produto: ")]
        public Double Preco { get; set; }

        [Required(ErrorMessage = "Informe a Margem de Lucro (sem %).")]
        [Display(Name="Margem de Lucro: ")]
        public Double PctLucro { get; set; }
    }
}