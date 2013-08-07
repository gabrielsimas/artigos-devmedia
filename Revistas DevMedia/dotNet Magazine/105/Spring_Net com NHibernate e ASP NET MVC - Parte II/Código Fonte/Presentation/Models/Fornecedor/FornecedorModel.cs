using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Models.Fornecedor
{
    public class FornecedorModel
    {

        [Required(ErrorMessage = "Informe o Nome do Fornecedor")]
        [Display(Name = "Razão Social: ")]
        [DataType(DataType.Text)]
        public String Nome { get; set; }

    }
}