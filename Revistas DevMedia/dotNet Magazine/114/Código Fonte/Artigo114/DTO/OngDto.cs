// -----------------------------------------------------------------------
// <copyright file="OngDto.cs" company="CS Services Consultoria em Sistemas">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class OngDto
    {

        public Nullable<long> Id { get; set; }
        public String Cnpj { get; set; }
        public String Cpf { get; set; }
        public String NomeFantasia { get; set; }
        public String RazaoSocial { get; set; }
        public String Estado { get; set; }

        public IList<ProjetoDto> Projetos { get; set; }
        public IList<NecessidadeDto> Necessidades { get; set; }

    }
}
